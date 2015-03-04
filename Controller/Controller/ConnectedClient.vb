Imports System.ComponentModel
Imports System.IO
Imports System.Net.Sockets
Imports System.Threading

Public Class ConnectedClient

    Private WithEvents _clientThread As BackgroundWorker
    Private ReadOnly _clientSocket As Socket
    Private _server As Server
    Private _outgoingMessage() As Byte

    Public Sub New(server As Server, clientSocket As Socket)

        _server = server
        _clientSocket = clientSocket

        'Create a new thread.
        _clientThread = New BackgroundWorker
        _clientThread.WorkerSupportsCancellation = True
        _clientThread.RunWorkerAsync()
    End Sub

    Private Sub Client(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _clientThread.DoWork

        Do While _clientSocket.Connected
            'Sleep to avoid locking up the CPU.
            Thread.Sleep(10)

            'Read/write the network stream.
            Dim stream As Stream = New NetworkStream(_clientSocket)
            Dim streamReader As New StreamReader(stream)
            Dim message As Byte = streamReader.Read()

            'TODO Check for a message to be sent.
            'TODO Check for connection lost.
        Loop
    End Sub

    Public Sub SendMessage(message() As Byte)
        _outgoingMessage = message
    End Sub

End Class
