Imports System.ComponentModel
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Module Server
    Public Property CancelPending As Byte
    Private _serverThread As Thread
    Private _connectedClient As ConnectedClient
    Private _clientSocket As TcpClient
    Private _threadStarted As Byte
    Private _mainWindow As MainWindow

    Public Sub StartServer()

        If _serverThread Is Nothing Then
            If My.Settings.AutoClearLog Then
                _mainWindow.ClearLog()
            End If

            'Create a new thread.
            _serverThread = New Thread(AddressOf ServerWorker)
            _serverThread.IsBackground = True
            _serverThread.Start()
        Else
            _mainWindow.LogMessage(1, "Server is already started.")
        End If
    End Sub

    Public Sub StopServer()

        'Stop the controller if it started.
        If _serverThread IsNot Nothing AndAlso _serverThread.IsAlive() Then

            If Not CancelPending Then

                'Close the client socket, if a simulator is connected.
                If _clientSocket IsNot Nothing Then
                    _clientSocket.Close()

                    _clientSocket = Nothing

                    _mainWindow.LogMessage(1, "Client socket closed.")
                End If

                'Remove the client from the server.
                If _connectedClient IsNot Nothing Then
                    _connectedClient = Nothing

                    _mainWindow.LogMessage(1, "Client removed from server.")
                End If

                'Stop the thread.
                Thread.VolatileWrite(_threadStarted, 0)

                CancelPending = True
            Else
                _mainWindow.LogMessage(1, "Cancel is pending. Please wait.")

            End If
        Else
            _mainWindow.LogMessage(1, "Server has not been started.")
        End If
    End Sub

    Private Sub ServerWorker()
        Thread.VolatileWrite(_threadStarted, 1)

        _mainWindow.LogMessage(1, "Starting server...")

        Try
            'Listen for the simulator to connect.
            Dim tcpListener As New TcpListener(IPAddress.Any, My.Settings.ListeningPortNumber)
            tcpListener.Start()

            _mainWindow.LogMessage(1, "Server is listening on " + _mainWindow.GetIpAddress() + ":" + My.Settings.ListeningPortNumber.ToString + "...")
            _mainWindow.LogMessage(1, "Waiting for simulator to connect...")

            While Thread.VolatileRead(_threadStarted) = 1

                'Sleep to avoid locking up the CPU.
                Thread.Sleep(10)

                'Check if there is a connection pending.
                If tcpListener.Pending Then
                    If _connectedClient Is Nothing Then
                        'Accept the connection.
                        _clientSocket = tcpListener.AcceptTcpClient()

                        _mainWindow.LogMessage(1, "Client connected.")

                        'Start the controller.
                        Controller.StartController()

                        'Create a new client object.
                        _connectedClient = New ConnectedClient(_clientSocket, _mainWindow)
                    End If
                End If
            End While

            If Controller.CheckControllerStarted() Then
                _mainWindow.LogMessage(1, "Stopping controller.")

                Controller.StopController()

                If Controller.GetThread() IsNot Nothing Then
                    If Controller.GetThread().IsAlive Then
                        Controller.GetThread.Join()
                    End If
                End If
            End If

            tcpListener.Stop()

            _mainWindow.LogMessage(1, "Server stopped.")
            CancelPending = False

            _serverThread = Nothing

        Catch exception As Exception
            _mainWindow.LogMessage(2, exception.Message)
        End Try
    End Sub

    Public Sub IncomingMessage(ByVal rawMessage As Byte())

        Dim message As Message = New Message(rawMessage(0), New Integer() {rawMessage(1), rawMessage(2), rawMessage(3)})

        Controller.ReceiveMessage(message)
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

    Public Sub SetMainWindow(ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow
    End Sub

    Public Function CheckClientConnected() As Boolean

        If (_connectedClient IsNot Nothing) Then
            Return True
        End If

        Return False
    End Function

    Public Function CheckServerStarted() As Boolean
        If _serverThread IsNot Nothing Then
            If (_serverThread.IsAlive) Then
                Return True
            End If
        End If

        Return False
    End Function

End Module
