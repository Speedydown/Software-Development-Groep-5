Imports System.ComponentModel
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Server

    Private WithEvents _serverThread As BackgroundWorker
    Private _connectedClient As ConnectedClient
    Private ReadOnly _listeningPortNumber As Integer
    Private _controller As Controller
    Private ReadOnly _mainWindow As MainWindow
    Private _clientSocket As TcpClient

    Public Sub New(ByVal listeningPortNumber As Integer, ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow

        _listeningPortNumber = listeningPortNumber
        '_controller = controllerInstance

        'Create a new thread.
        _serverThread = New BackgroundWorker
        _serverThread.WorkerSupportsCancellation = True
    End Sub

    Public Sub StartServer()

        'Stop the controller if it started.
        If Not _serverThread.IsBusy() And Not _serverThread.CancellationPending Then
            _mainWindow.LogMessage(1, "Starting server...")

            _serverThread.RunWorkerAsync()
        Else
            _mainWindow.LogMessage(1, "Server is already started.")

        End If
    End Sub

    Public Sub StopServer()

        'Stop the controller if it started.
        If _serverThread.IsBusy() And Not _serverThread.CancellationPending Then
            _serverThread.CancelAsync()

            'Close the client socket, if a simulator is connected.
            If _clientSocket IsNot Nothing Then
                _clientSocket.Close()

                _mainWindow.LogMessage(1, "Client socket closed.")
            End If

            'Remove the client from the server.
            If _connectedClient IsNot Nothing Then
                _connectedClient = Nothing

                _mainWindow.LogMessage(1, "Client removed from server.")
            End If

            'Stop the thread.
            _serverThread.CancelAsync()

            _mainWindow.LogMessage(1, "Server stopped.")
        Else
            _mainWindow.LogMessage(1, "Server has not been started.")
        End If
    End Sub

    Private Sub Server(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _serverThread.DoWork

        Try
            'Listen for the simulator to connect.
            Dim tcpListener As New TcpListener(IPAddress.Any, _listeningPortNumber)
            tcpListener.Start()

            _mainWindow.LogMessage(1, "Server is listening on " + _mainWindow.GetIpAddress() + ":" + _listeningPortNumber.ToString + "...")
            _mainWindow.LogMessage(1, "Waiting for simulator to connect...")

            While Not _serverThread.CancellationPending

                'Sleep to avoid locking up the CPU.
                Thread.Sleep(10)

                'Check if there is a connection pending.
                If tcpListener.Pending Then
                    If _connectedClient Is Nothing Then
                        'Accept the connection.
                        _clientSocket = tcpListener.AcceptTcpClient()

                        'Start the controller.
                        _controller = New Controller(Me, _mainWindow)
                        _controller.StartController()

                        'Create a new client object.
                        _connectedClient = New ConnectedClient(Me, _clientSocket, _mainWindow)
                    End If
                End If
            End While

            tcpListener.Stop()

        Catch exception As Exception
            _mainWindow.LogMessage(2, exception.Message)
        End Try
    End Sub

    Public Sub IncomingMessage(ByVal rawMessage As Byte())

        Dim message As Message = New Message(rawMessage(0), New Integer() {rawMessage(1), rawMessage(2), rawMessage(3)})

        _controller.ReceiveMessage(message)
        _mainWindow.LogMessage(4, message.MessageToString() + ".")
    End Sub

    Public Sub OutgoingMessage(ByVal message As Message)

        'Check if client is connected before sending a message.
        If _connectedClient IsNot Nothing Then
            If _connectedClient.ClientSocket().Connected() Then

                'Send a message to the simulator.
                _connectedClient.SendMessage(message)
                _mainWindow.LogMessage(3, message.MessageToString() + ".")
            End If
        End If
    End Sub

    Public Sub ClientDisconnected(ByVal connectedClient As ConnectedClient)

        'Remove the client and stop the controller when the client disconnects.
        _connectedClient = Nothing
        _controller.StopController()
        _mainWindow.LogMessage(1, "Client disconnected.")
    End Sub

End Class
