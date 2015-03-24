Public Class MainWindow
    Dim _server As Server

    Private Sub ExitToolStripMenuItemExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItemExit.Click
        Application.Exit()
    End Sub

    Private Sub MainWindow_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogMessage("Click the button to start the server.")

        'Create server instance.
        _server = New Server("127.0.0.1", 10000, Me)
    End Sub

    Private Sub ToolStripButtonControllerStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonControllerStart.Click
        'TODO Checks.
        'TODO GUI button "pressed" state.
        _server.StartServer()
    End Sub

    Private Sub ToolStripButtonControllerStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonControllerStop.Click
        'TODO Checks.
        'TODO GUI button "pressed" state.
        _server.StopServer()
    End Sub

    Public Sub LogMessage(ByVal message As String)
        'TODO Check if windows is created.

        'Adds a (log) message to the main window.
        Invoke(Sub()
                   ListBoxStatus.Items.Add(message)

                   'Autoscroll the listbox.
                   ListBoxStatus.SelectedIndex = ListBoxStatus.Items.Count - 1
                   ListBoxStatus.SelectedIndex = -1
               End Sub)
    End Sub

End Class
