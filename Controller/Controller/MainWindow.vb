Public Class MainWindow
    Dim _controller As Controller
    Dim _server As Server

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create server and controller instances.
        _server = New Server("127.0.0.1", 8888, _controller, Me)
        _controller = New Controller(_server, Me)
    End Sub

    Private Sub ToolStripButtonControllerStart_Click(sender As Object, e As EventArgs) Handles ToolStripButtonControllerStart.Click
        'TODO Checks.
        'TODO GUI button "pressed" state.
        _server.StartServer()
    End Sub

    Private Sub ToolStripButtonControllerStop_Click(sender As Object, e As EventArgs) Handles ToolStripButtonControllerStop.Click
        'TODO Checks.
        'TODO GUI button "pressed" state.
        _server.StopServer()
    End Sub

    Public Sub LogMessage(message As String)
        'Adds a (log) message to the main window.
        Invoke(Sub()
                   statusListBox.Items.Add(message)
               End Sub)
    End Sub
End Class
