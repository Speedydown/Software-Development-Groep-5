Imports System.ComponentModel
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

Public Class Server

    Private WithEvents _serverThread As BackgroundWorker
    Private _client As ConnectedClient
    Private ReadOnly _listeningPortNumber As Integer
    Private ReadOnly _listeningIpAddress As IPAddress
    Private _controller As Controller
    Private ReadOnly _mainWindow As MainWindow

    Private _clientSocket As Socket

    Public Sub New(ByVal listeningIpAddress As String, ByVal listeningPortNumber As Integer, ByVal controllerInstance As Controller, ByVal mainWindow As MainWindow)

        _mainWindow = mainWindow

        _listeningIpAddress = IPAddress.Parse(listeningIpAddress)
        _listeningPortNumber = listeningPortNumber
        '_controller = controllerInstance

        'Create a new thread.
        _serverThread = New BackgroundWorker
        _serverThread.WorkerSupportsCancellation = True
    End Sub

    Public Sub StartServer()
        _mainWindow.LogMessage("Starting server...")

        'TODO Check (if the server is already started).
        _serverThread.RunWorkerAsync()
    End Sub

    Public Sub StopServer()
        _mainWindow.LogMessage("Stopping server...")

        'TODO Check (if the server is started/stopped).
        'Close the client socket.
        If _clientSocket IsNot Nothing Then
            _clientSocket.Close()
        End If

        'Stop the thread.
        _serverThread.CancelAsync()
    End Sub

    Private Sub Server(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _serverThread.DoWork
        Do While Not _serverThread.CancellationPending

            'Listen for the simulator to connect.
            Dim tcpListener As New TcpListener(_listeningIpAddress, _listeningPortNumber)
            tcpListener.Start()

            _mainWindow.LogMessage("Waiting for simulator to connect...")

            While True
                'Sleep to avoid locking up the CPU.
                Thread.Sleep(10)

                'Wait (and block) for the simulator to connect.
                _clientSocket = tcpListener.AcceptSocket()

                'Log the IP address from the connected simulator.
                Dim clientIpAddress As IPEndPoint = CType(_clientSocket.RemoteEndPoint, IPEndPoint)
                _mainWindow.LogMessage("Simulator connected. IP: " + clientIpAddress.Address.ToString() + ".")

                'Start the controller.
                _controller = New Controller(Me, _mainWindow)
                _controller.StartController()

                'Create a new client object.
                _client = New ConnectedClient(Me, _clientSocket)
            End While
        Loop
    End Sub

    Public Sub IncomingMessage(message As Byte())
        'Don't know if we really need to receive messages from a client...
        '_controller.ReceiveMessage(New Message().DecodeMessage(message))
        _controller.ReceiveMessage(message)

    End Sub

    Public Sub OutgoingMessage(ByVal parameters As Byte())
        'Send a message to the simulator.
        _client.SendMessage(New Message().EncodeMessage(parameters))
    End Sub

End Class
