Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class ConnectedClient

    Private WithEvents _clientThread As BackgroundWorker
    Private ReadOnly _clientSocket As TcpClient
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow
    Private _networkStream As NetworkStream
    Private _outgoingMessage() As Byte

    Public Sub New(ByVal server As Server, ByVal clientSocket As TcpClient, ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
        _server = server
        _clientSocket = clientSocket

        'Create a new thread.
        _clientThread = New BackgroundWorker
        _clientThread.WorkerSupportsCancellation = True
        _clientThread.RunWorkerAsync()
    End Sub

    Private Sub Client(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _clientThread.DoWork

        _networkStream = _clientSocket.GetStream

        Try
            Dim message(3) As Byte
            Dim bytesProcessed As Integer

            Do
                Dim messageProcessed As Integer = 0

                Do While messageProcessed < message.Length
                    bytesProcessed = _networkStream.Read(message, messageProcessed, (message.Length - messageProcessed))
                    messageProcessed = messageProcessed + bytesProcessed
                Loop

                _server.IncomingMessage(message)
            Loop

        Catch exception As Exception
            _mainWindow.LogMessage(2, exception.Message + ".")
        Finally
            'Remove the client from the server when the connection is gone.
            _server.ClientDisconnected(Me)
        End Try
    End Sub

    Public Sub SendMessage(ByVal message As Message)

        If message IsNot Nothing Then
            Dim rawMessage() As Byte = {message.Type(), message.Parameters(0), message.Parameters(1), message.Parameters(2)}

            If rawMessage IsNot Nothing Then
                If _clientSocket IsNot Nothing And _clientSocket.Connected Then
                    If _networkStream IsNot Nothing Then

                        _networkStream.Write(rawMessage, 0, rawMessage.Length)
                    End If
                End If
            End If
        End If
    End Sub

    Public ReadOnly Property ClientSocket() As TcpClient
        Get
            Return _clientSocket
        End Get
    End Property

End Class
