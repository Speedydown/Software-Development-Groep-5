Imports System.ComponentModel
Imports System.Threading

Public Class Controller
    Private WithEvents _controllerThread As BackgroundWorker
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow

    Public Sub New(server As Server, mainWindow As MainWindow)
        _server = server
        _mainWindow = mainWindow

        'Create a new thread.
        _controllerThread = New BackgroundWorker
        _controllerThread.WorkerSupportsCancellation = True
    End Sub

    Public Sub StartController()
        'Start the controller if it is not already started.
        If Not _controllerThread.IsBusy() Then
            _controllerThread.RunWorkerAsync()
            _mainWindow.LogMessage("Controller started.")
        Else
            _mainWindow.LogMessage("Controller is already started.")
        End If

    End Sub

    Public Sub StopController()
        'Stop the controller if it started.
        If _controllerThread.IsBusy() Then
            _controllerThread.CancelAsync()
            _mainWindow.LogMessage("Controller stopped.")
        Else
            _mainWindow.LogMessage("Controller has not been started.")
        End If
    End Sub

    Private Sub Controller(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _controllerThread.DoWork
        Do While Not _controllerThread.CancellationPending
            'TODO Controller routines here.
        Loop
    End Sub

    Public Sub ReceiveMessage()
        'TODO Process a incoming message from the simulator
    End Sub

    Private Sub SendMessage()
        _server.OutgoingMessage(New Byte() {})
    End Sub

End Class
