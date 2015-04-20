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

        'Create server instance.
        _server = New Server(10000, Me)

        LogMessage(1, "Controller, Build " + DateTime.Now.ToString("dMyyyyhmm"))
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

    Public Sub LogMessage(ByVal type As Integer, ByVal message As String)
        'TODO Check if window is created.

        Dim formattedMessage As String = Nothing

        If type = 1 Then
            formattedMessage = formattedMessage + "[INFO]"
        End If
        If type = 2 Then
            formattedMessage = formattedMessage + "[ERROR]"
        End If
        If type = 3 Then
            formattedMessage = formattedMessage + "[SENT]"
        End If
        If type = 4 Then
            formattedMessage = formattedMessage + "[INCOMING]"
        End If

        formattedMessage = formattedMessage + (" " + message)


        'Adds a (log) message to the main window.
        Invoke(Sub()
                   ListBoxStatus.Items.Add(formattedMessage)

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
