Imports System.ComponentModel
Imports System.Threading

Public Class Controller
    Private WithEvents _controllerThread As BackgroundWorker
    Private ReadOnly _server As Server
    Private ReadOnly _mainWindow As MainWindow
    Private _message As Byte()
    Private Shared ReadOnly Random As New Random(DateTime.UtcNow.Millisecond)

    Public Sub New(ByVal server As Server, ByVal mainWindow As MainWindow)
        _server = server
        _mainWindow = mainWindow

        'Create a new thread.
        _controllerThread = New BackgroundWorker
        _controllerThread.WorkerSupportsCancellation = True
    End Sub

    Public Sub StartController()

        'Start the controller if it is not already started.
        If Not _controllerThread.IsBusy() And Not _controllerThread.CancellationPending Then
            _controllerThread.RunWorkerAsync()
            _mainWindow.LogMessage("Controller started.")
        Else
            _mainWindow.LogMessage("Controller is already started.")
        End If
    End Sub

    Public Sub StopController()
        'Stop the controller if it started.
        If _controllerThread.IsBusy And Not _controllerThread.CancellationPending Then
            _controllerThread.CancelAsync()
            _mainWindow.LogMessage("Controller stopped.")
        Else
            _mainWindow.LogMessage("Controller has not been started.")
        End If
    End Sub

    Private Sub Controller(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _controllerThread.DoWork
        Do While Not _controllerThread.CancellationPending
            'TODO Controller routines here.

            Thread.Sleep(3000)

            'TESTING (SEND A RANDOM MESSAGE EVERY THREE SECONDS)
            'Generates a random message.
            Dim randomMessage = Random.Next(0, 2)

            Dim numbers As Byte()

            If randomMessage = 0 Then
                numbers = New Byte() {1, Random.Next(0, 5), Random.Next(0, 5), Random.Next(0, 4)}
            End If
            If randomMessage = 1 Then
                numbers = New Byte() {2, Random.Next(0, 256), Random.Next(0, 3)}
            End If

            SendMessage(numbers)
        Loop
    End Sub

    Public Sub ReceiveMessage(ByVal message As Byte())
        'TODO Pass message to controller.
    End Sub

    Private Sub SendMessage(ByVal message As Byte())
        _server.OutgoingMessage(message)
    End Sub
End Class
