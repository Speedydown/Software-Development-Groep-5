Imports System.ComponentModel
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class ConnectedClient

    Private WithEvents _clientThread As BackgroundWorker
    Private ReadOnly _clientSocket As Socket
    Private ReadOnly _server As Server
    Private _outgoingMessage() As Byte

    Public Sub New(ByVal server As Server, ByVal clientSocket As Socket)

        _server = server
        _clientSocket = clientSocket

        'Create a new thread.
        _clientThread = New BackgroundWorker
        _clientThread.WorkerSupportsCancellation = True
        _clientThread.RunWorkerAsync()
    End Sub

    Private Sub Client(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _clientThread.DoWork

        Dim receivedMessage(4) As Byte

        Do While _clientSocket.Connected
            'Sleep to avoid locking up the CPU.
            Thread.Sleep(10)

            'Read/write the network stream.
            Dim stream As Stream = New NetworkStream(_clientSocket)

            'Get data from the connected client. 
            Dim receivedBytes As Integer = _clientSocket.Receive(receivedMessage)

            'Read all incoming bytes.
            Do While _clientSocket.Available > 0
                receivedBytes = _clientSocket.Receive(receivedMessage)
            Loop

            'Send the incoming message to the server.
            _server.IncomingMessage(receivedMessage)

            'TODO Check for a message to be sent.
            'TODO Check for connection lost.
        Loop
    End Sub

    Public Sub SendMessage(ByVal message As Byte())
        _clientSocket.Send(message)
    End Sub

End Class
