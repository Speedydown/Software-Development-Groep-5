Public Class MainWindow
    Dim controller As Controller

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        controller = New Controller(Me)
    End Sub

    Private Sub ToolStripButtonControllerStart_Click(sender As Object, e As EventArgs) Handles ToolStripButtonControllerStart.Click
        controller.StartController()
    End Sub

    Private Sub ToolStripButtonControllerStop_Click(sender As Object, e As EventArgs) Handles ToolStripButtonControllerStop.Click
        controller.StopController()
    End Sub
End Class
