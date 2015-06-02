Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Public Class MainWindow
    Dim _verboseLogging As Boolean

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    'Show a dialog box with the current IP address.
    Private Sub ShowIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowIPAddressToolStripMenuItem.Click
        MessageBox.Show("IP address: " + GetIpAddress() + ".", "IP address", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub MainWindow_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ComboBoxOptionsSpeed.SelectedIndex = 0

        LogMessage(1, "Controller Version 1.0 (02-06-2015).")

        Server.SetMainWindow(Me)
        Controller.SetMainWindow(Me)
        TrafficLightController.SetMainWindow(Me)
        TestController.SetMainWindow(Me)
    End Sub

    Private Sub ToolStripButtonStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonStart.Click
        Server.StartServer()
    End Sub

    Private Sub ToolStripButtonStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolStripButtonStop.Click
        Server.StopServer()
    End Sub

    'Ádd a message to the log.
    Public Sub LogMessage(ByVal type As Integer, ByVal message As String)
        Dim formattedMessage As String = Nothing

        'Set the message type.
        If type = 6 Then
            formattedMessage = formattedMessage + "[WARNING]"
        End If

        If type = 5 Then
            If Not _verboseLogging Then
                Return
            End If
            formattedMessage = formattedMessage + "[DEBUG]"
        End If

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

        'Invoke when the message is coming from a different thread.
        If IsHandleCreated Then
            Invoke(Sub()
                       ListBoxStatus.Items.Add(formattedMessage)

                       'Autoscroll the listbox.
                       ListBoxStatus.SelectedIndex = ListBoxStatus.Items.Count - 1
                       ListBoxStatus.SelectedIndex = -1
                   End Sub)
        End If
    End Sub

    'Get the current IP address.
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

    'Check if the simulator is connected.
    Private Function CheckServerReady() As Boolean
        If Server.CheckServerStarted() Then
            If Server.CheckClientConnected() Then
                Return True
            End If
        End If

        MessageBox.Show("Cannot perform this action. Please verify that the sever is started and the simulator is connected. Then try again.", "Server Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Return False
    End Function

    'Change a traffic light to a state (green/red/orange).
    Private Sub ButtonChangeTrafficLightStateState_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonTrafficLightStateChangeState.Click

        Dim textBoxValue As Integer
        Dim parameters(2) As Integer

        'Check if the entered value is valid.
        If Not Integer.TryParse(TextBoxTrafficLightStateId.Text, textBoxValue) Then
            MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            If (TextBoxTrafficLightStateId.Text >= 0 AndAlso TextBoxTrafficLightStateId.Text <= 50) Then
                parameters(0) = TextBoxTrafficLightStateId.Text
            Else
                MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If (ComboBoxTrafficLightStateState.SelectedIndex > -1) Then
            parameters(1) = ComboBoxTrafficLightStateState.SelectedIndex
        Else
            Return
        End If

        If CheckServerReady() Then
            'Create the message.
            Dim message As Message = New Message(2, parameters)

            'Send the message.
            Server.OutgoingMessage(message)
        End If
    End Sub

    Private Sub ClearLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearLogToolStripMenuItem.Click
        ClearLog()
    End Sub

    'Clear the log.
    Public Sub ClearLog()
        If IsHandleCreated Then
            Invoke(Sub()
                       ListBoxStatus.Items.Clear()
                   End Sub)
        End If
    End Sub

    'Send a vehicle announcement message to a traffic light.
    Private Sub ButtonVehicleAnnouncementReceive_Click(sender As Object, e As EventArgs) Handles ButtonVehicleAnnouncementReceive.Click
        Dim textBoxValue As Integer
        Dim parameters(2) As Integer

        'Check if the entered value is valid.
        If Not Integer.TryParse(TextBoxVehicleAnnouncementId.Text, textBoxValue) Then
            MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            If (TextBoxVehicleAnnouncementId.Text >= 0 AndAlso TextBoxVehicleAnnouncementId.Text <= 50) Then
                parameters(0) = TextBoxVehicleAnnouncementId.Text
            Else
                MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        End If

        If (ComboBoxVehicleAnnouncementDistance.SelectedIndex > -1) Then
            parameters(1) = ComboBoxVehicleAnnouncementDistance.SelectedIndex
        Else
            Return
        End If

        If CheckServerReady() Then
            'Send the message.
            Server.IncomingMessage(New Byte() {3, parameters(0), parameters(1), 0})
        End If
    End Sub

    Private Sub ButtonTrafficLightControllerStart_Click(sender As Object, e As EventArgs) Handles ButtonTrafficLightControllerStart.Click

        'Start the Traffic Light Controller.
        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                TrafficLightController.StartTrafficLightController(False)
            End If
        End If
    End Sub

    Private Sub ButtonTrafficLightControllerStop_Click(sender As Object, e As EventArgs) Handles ButtonTrafficLightControllerStop.Click

        'Stop the Traffic Light Controller.
        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                TrafficLightController.StopTrafficLightController()
            End If
        End If
    End Sub

    'Spawn a selected vehicle.
    Private Sub ButtonSpawnVehicle_Click(sender As Object, e As EventArgs) Handles ButtonSpawnVehicle.Click
        Dim parameters(2) As Integer

        'Collect parameters for the message.
        If (ComboBoxSpawnVehicleStart.SelectedIndex > -1) Then
            parameters(0) = ComboBoxSpawnVehicleStart.SelectedIndex
        Else
            Return
        End If

        If (ComboBoxSpawnVehicleEnd.SelectedIndex > -1) Then
            parameters(1) = ComboBoxSpawnVehicleEnd.SelectedIndex
        Else
            Return
        End If

        If (ComboBoxSpawnVehicleType.SelectedIndex > -1) Then
            parameters(2) = ComboBoxSpawnVehicleType.SelectedIndex
        Else
            Return
        End If

        'Check is the server is started, and send the message.
        If CheckServerReady() Then
            Dim message As Message = New Message(1, parameters)

            Server.OutgoingMessage(message)
        End If

    End Sub

    'Reset a traffic light queue.
    Private Sub ButtonVehicleQueueResetQueue_Click(sender As Object, e As EventArgs) Handles ButtonVehicleQueueResetQueue.Click
        Dim textBoxValue As Integer

        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                'Check if the entered value is valid.
                If Not Integer.TryParse(TextBoxVehicleQueueId.Text, textBoxValue) Then
                    MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    If (TextBoxVehicleQueueId.Text < 0 OrElse TextBoxVehicleQueueId.Text > 50) Then
                        MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If

                Controller.ResetQueue(textBoxValue)
            End If

            If CheckTrafficLightControllerStarted() Then
                'Reset the queue.
                TrafficLightController.ResetMaxQueue()
            End If
        End If
    End Sub

    'Reset all traffic light queues.
    Private Sub ButtonVehicleQueueResetAllQueues_Click(sender As Object, e As EventArgs) Handles ButtonVehicleQueueResetAllQueues.Click
        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                Controller.ResetQueue(Nothing)
            End If

            If CheckTrafficLightControllerStarted() Then
                TrafficLightController.ResetMaxQueue()
            End If
        End If
    End Sub

    'Update the "Current timer" label.
    Public Sub UpdateTimerLabel(value As String)
        If IsHandleCreated Then
            Invoke(Sub()
                       'Only update when the tab is selected.
                       If TabControl.SelectedTab IsNot TabControl.TabPages("TabPageDebugging") Then
                           Return
                       Else
                           If value IsNot Nothing Then
                               LabelInfoCurrentTimerValue.Text = value
                           Else
                               'If no timer is running, change the label back to the default text.
                               LabelInfoCurrentTimerValue.Text = "N/A"
                           End If

                       End If
                   End Sub)
        End If
    End Sub

    'Update the "Current state" label.
    Public Sub UpdateCurrentStateLabel(ByVal value As String)
        If IsHandleCreated Then
            Invoke(Sub()

                       If value IsNot Nothing Then
                           LabelInfoCurrentStateValue.Text = value
                       Else
                           'If no state is executed, change the label back to the default text.
                           LabelInfoCurrentStateValue.Text = "N/A"
                       End If
                   End Sub)
        End If
    End Sub

    'Show the "Settings" window.
    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        SettingsWindow.Owner = Me
        SettingsWindow.ShowDialog()
    End Sub

    'Enable/disable verbose logging.
    Private Sub EnableVerboseLoggingToolStripMenuItem_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles EnableVerboseLoggingToolStripMenuItem.CheckStateChanged
        If EnableVerboseLoggingToolStripMenuItem.Checked Then
            _verboseLogging = True

            LogMessage(1, "Verbose Logging enabled.")
        Else
            _verboseLogging = False

            LogMessage(1, "Verbose Logging disabled.")
        End If
    End Sub

    'Show the size of a traffic light.
    Private Sub ButtonVehicleQueueGetQueueSize_Click(sender As Object, e As EventArgs) Handles ButtonVehicleQueueGetQueueSize.Click
        Dim textBoxValue As Integer

        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                'Check if the entered value is valid.
                If Not Integer.TryParse(TextBoxVehicleQueueId.Text, textBoxValue) Then
                    MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                Else
                    If (TextBoxVehicleQueueId.Text < 0 OrElse TextBoxVehicleQueueId.Text > 50) Then
                        MessageBox.Show("Please enter a value between 0 and 50.", "Traffic Light ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End If

                'Compare the traffic lights to the entered values and show the queue size.
                For Each trafficLight In Controller.TrafficLightList
                    If TextBoxVehicleQueueId.Text = trafficLight.Id Then
                        MessageBox.Show("Current queue size is: " + trafficLight.GetVehicleCount().ToString() + ".", "Queue Size", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub CheckBoxSpawnVehicleTypesCars_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpawnVehicleTypesCars.CheckedChanged
        If Not CheckBoxSpawnVehicleTypesCars.Checked Then
            If Not CheckOneSelected() Then
                CheckBoxSpawnVehicleTypesCars.Checked = True
                TestController.SpawnCars = True
            Else
                TestController.SpawnCars = False
            End If
        Else
            TestController.SpawnCars = True
        End If
    End Sub

    'Check if at least one test vehicle type is selected.
    Public Function CheckOneSelected() As Boolean
        If (Not CheckBoxSpawnVehicleTypesCars.Checked) AndAlso (Not CheckBoxSpawnVehicleBuses.Checked) AndAlso (Not CheckBoxSpawnVehicleTypesPedestrian.Checked) AndAlso (Not CheckBoxSpawnVehicleCyclists.Checked) Then
            MessageBox.Show("Please select at least one type.", "Type Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CheckBoxSpawnVehicleCyclists_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpawnVehicleCyclists.CheckedChanged
        If Not CheckBoxSpawnVehicleCyclists.Checked Then
            If Not CheckOneSelected() Then
                CheckBoxSpawnVehicleCyclists.Checked = True
                TestController.SpawnCyclists = True
            Else
                TestController.SpawnCyclists = False
            End If
        Else
            TestController.SpawnCyclists = True
        End If
    End Sub

    Private Sub CheckBoxSpawnVehicleBuses_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpawnVehicleBuses.CheckedChanged
        If Not CheckBoxSpawnVehicleBuses.Checked Then
            If Not CheckOneSelected() Then
                CheckBoxSpawnVehicleBuses.Checked = True
                TestController.SpawnBuses = True
            Else
                TestController.SpawnBuses = False
            End If
        Else
            TestController.SpawnBuses = True
        End If
    End Sub

    Private Sub CheckBoxSpawnVehicleTypesPedestrians_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpawnVehicleTypesPedestrian.CheckedChanged
        If Not CheckBoxSpawnVehicleTypesPedestrian.Checked Then
            If Not CheckOneSelected() Then
                CheckBoxSpawnVehicleTypesPedestrian.Checked = True
                TestController.SpawnPedestrians = True
            Else
                TestController.SpawnPedestrians = False
            End If
        Else
            TestController.SpawnPedestrians = True
        End If
    End Sub

    Private Sub ComboBoxOptionsSpeed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOptionsSpeed.SelectedIndexChanged

        TestController.TestSpeed = ComboBoxOptionsSpeed.SelectedIndex
    End Sub

    'Stop the Test Controller.
    Private Sub ButtonAutoSpawnStopTestController_Click(sender As Object, e As EventArgs) Handles ButtonAutoSpawnStopTestController.Click
        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                If TrafficLightController.CheckTrafficLightControllerStarted Then
                    If TestController.CheckTestControllerStarted Then
                        TestController.StopTestController()
                    End If
                End If
            End If
        End If
    End Sub

    'Start the Test Controller.
    Private Sub ButtonAutoSpawnStartTestController_Click(sender As Object, e As EventArgs) Handles ButtonAutoSpawnStartTestController.Click
        If CheckServerReady() Then
            If Controller.CheckControllerStarted() Then
                If Not TrafficLightController.CheckTrafficLightControllerStarted() Then
                    TrafficLightController.StartTrafficLightController(True)
                Else
                    TestController.StartTestController()
                End If
            End If
        End If
    End Sub
End Class
