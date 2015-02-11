Imports System.ComponentModel
Imports System.Threading

Public Class Controller
    Private mainWindow As MainWindow
    Private WithEvents controllerThread As BackgroundWorker


    Public Sub New(MainWindowx As MainWindow)
        mainWindow = MainWindowx
        controllerThread = New BackgroundWorker
        controllerThread.WorkerSupportsCancellation = True
    End Sub

    Public Sub StartController()

        If Not controllerThread.IsBusy() Then
            controllerThread.RunWorkerAsync()
            SetText("Controller started.")
        Else
            SetText("Controller is already started.")
        End If

    End Sub

    Public Sub StopController()
        If controllerThread.IsBusy() Then
            controllerThread.CancelAsync()
            SetText("Controller stopped.")
        Else
            SetText("Controller has not been started.")
        End If
    End Sub

    Public Sub SetText(text As String)
        mainWindow.Invoke(Sub()
                              mainWindow.statusListBox.Items.Add(text)
                          End Sub)
    End Sub

    Private Sub Controller(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles controllerThread.DoWork
        Do While Not controllerThread.CancellationPending

        Loop
    End Sub

End Class
