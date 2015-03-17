Imports System.ComponentModel
Imports System.IO
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class ConnectedClient

    Private WithEvents _clientThread As BackgroundWorker
    Private ReadOnly _clientSocket As Socket
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow
    Private _outgoingMessage() As Byte

    Public Sub New(ByVal server As Server, ByVal clientSocket As Socket, ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
        _server = server
        _clientSocket = clientSocket

        'Create a new thread.
        _clientThread = New BackgroundWorker
        _clientThread.WorkerSupportsCancellation = True
        _clientThread.RunWorkerAsync()
    End Sub

    Private Sub Client(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _clientThread.DoWork

        Dim receivedMessage(4) As Byte

        Try
            Do While _clientSocket.Connected
                'Sleep to avoid locking up the CPU.
                Thread.Sleep(10)

                'Get data from the connected client. 
                _clientSocket.Receive(receivedMessage)

                'Read all incoming bytes.
                Do While _clientSocket.Available > 0
                    _clientSocket.Receive(receivedMessage)
                Loop

                'Send the incoming message to the server.
                _server.IncomingMessage(receivedMessage)

                'TODO Check for a message to be sent.
                'TODO Check for connection lost.
            Loop

        Catch exception As Exception
            _mainWindow.LogMessage("XERROR: " + exception.Message)
        Finally
            'Remove the client from the server when the connection is gone.
            _server.ClientDisconnected(Me)
        End Try
    End Sub

    Public Sub SendMessage(ByVal message As Byte())
        If _clientSocket IsNot Nothing Then
            If _clientSocket.Connected Then
                _clientSocket.Send(message)
            End If
        End If
    End Sub

    Public ReadOnly Property ClientSocket() As Socket
        Get
            Return _clientSocket
        End Get
    End Property

End Class
