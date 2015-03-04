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
    Private ReadOnly _controller As Controller
    Private ReadOnly _mainWindow As MainWindow

    Private _clientSocket As Socket

    Public Sub New(listeningIpAddress As String, listeningPortNumber As Integer, controllerInstance As Controller, mainWindow As MainWindow)

        _mainWindow = mainWindow

        _listeningIpAddress = IPAddress.Parse(listeningIpAddress)
        _listeningPortNumber = listeningPortNumber
        _controller = controllerInstance

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
        'Stop the thread.
        _clientSocket.Close()
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
                _controller.StartController()

                'Create a new client object.
                _client = New ConnectedClient(Me, _clientSocket)
            End While
        Loop
    End Sub

    Private Sub IncomingMessage(arr() As Byte)
        'Don't know if we really need to receive messages from a client...
        _controller.ReceiveMessage()
    End Sub

    Public Sub OutgoingMessage(arr() As Byte)
        'Send a message to the simulator.
        _client.SendMessage(New Byte() {})
    End Sub

End Class
