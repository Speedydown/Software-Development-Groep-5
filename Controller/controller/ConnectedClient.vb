Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class ConnectedClient

    Private WithEvents _clientThread As Thread
    Private ReadOnly _clientSocket As TcpClient
    Private _networkStream As NetworkStream
    Private ReadOnly _mainWindow As MainWindow

    Public Sub New(ByVal clientSocket As TcpClient, mainWindow As MainWindow)

        _clientSocket = clientSocket
        _mainWindow = mainWindow

        'Create a new thread.
        _clientThread = New Thread(AddressOf ConnectedClientWorker)
        _clientThread.IsBackground = True
        _clientThread.Start()
    End Sub

    Private Sub ConnectedClientWorker()

        _mainWindow.LogMessage(5, "Connected Client Worker started.")
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

                Server.IncomingMessage(message)
            Loop

        Catch exception As Exception
            _mainWindow.LogMessage(2, exception.Message + ".")
        Finally
            'Remove the client from the server when the connection is gone.
            _mainWindow.LogMessage(5, "Disconnecting client from server.")

            If Not Server.CancelPending Then
                Server.StopServer()
            End If
        End Try

        _mainWindow.LogMessage(5, "Connected Client Worker stopped.")
        _clientThread = Nothing

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
