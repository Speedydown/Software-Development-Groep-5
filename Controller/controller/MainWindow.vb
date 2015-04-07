Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Public Class MainWindow
    Dim _server As Server

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ShowIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowIPAddressToolStripMenuItem.Click
        MessageBox.Show("IP address: " + GetIpAddress() + ".", "IP address", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MainWindow_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LogMessage("Click the button to start the server.")

        'Create server instance.
        _server = New Server(10000, Me)
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

    Public Function GetIpAddress() As String
        'Test if a network card is active.
        Dim u As New UdpClient("74.125.133.94", 1)
        Dim ipAddress As IPAddress = CType(u.Client.LocalEndPoint, IPEndPoint).Address

        For Each networkInterface As NetworkInterface In networkInterface.GetAllNetworkInterfaces()
            Dim ipInterfaceProperties As IPInterfaceProperties = networkInterface.GetIPProperties()

            For Each unicastIpAddressInformation As UnicastIPAddressInformation In ipInterfaceProperties.UnicastAddresses
                If ipAddress.Equals(unicastIpAddressInformation.Address) Then
                    Return unicastIpAddressInformation.Address.ToString()
                End If
            Next unicastIpAddressInformation
        Next networkInterface

        Return False
    End Function
End Class
