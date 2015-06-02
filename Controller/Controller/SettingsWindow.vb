Public Class SettingsWindow

    'Save the settings.
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim textBoxValue As Integer
        Dim valueError As Boolean

        'Check if values are valid.
        If Not Integer.TryParse(TextBoxGeneralServerPort.Text, textBoxValue) Then
            valueError = True
        Else
            If (TextBoxGeneralServerPort.Text < 1 OrElse TextBoxGeneralServerPort.Text > 65535) Then
                valueError = True
            End If
        End If

        If Not Integer.TryParse(TextBoxDelayGreenToOrange.Text, textBoxValue) Then
            valueError = True
        End If
        If Not Integer.TryParse(TextBoxDelayOrangeToRed.Text, textBoxValue) Then
            valueError = True
        End If
        If Not Integer.TryParse(TextBoxDelayVehicleQueue.Text, textBoxValue) Then
            valueError = True
        End If
        If Not Integer.TryParse(TextBoxDelayBetweenStates.Text, textBoxValue) Then
            valueError = True
        End If
        If Not Integer.TryParse(TextBoxDelayMinimumDelayBetweenBusStates.Text, textBoxValue) Then
            valueError = True
        End If
        If Not Integer.TryParse(TextBoxDelayConflictingBusTrafficLightDelay.Text, textBoxValue) Then
            valueError = True
        End If

        If Not valueError Then
            If CheckBoxGeneralStartTrafficLightsRed.Checked Then
                My.Settings.StartTrafficLichtsRed = True
            Else
                My.Settings.StartTrafficLichtsRed = False
            End If

            If CheckBoxAutoClearLog.Checked Then
                My.Settings.AutoClearLog = True
            Else
                My.Settings.AutoClearLog = False
            End If

            If CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Checked Then
                My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled = True
            Else
                My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled = False
            End If

            My.Settings.ListeningPortNumber = TextBoxGeneralServerPort.Text
            My.Settings.GreenToOrangeDelay = TextBoxDelayGreenToOrange.Text
            My.Settings.OrangeToRedDelay = TextBoxDelayOrangeToRed.Text
            My.Settings.ExtraVehicleDelay = TextBoxDelayVehicleQueue.Text
            My.Settings.StateDelay = TextBoxDelayBetweenStates.Text
            My.Settings.MinimumBusStateDelay = TextBoxDelayMinimumDelayBetweenBusStates.Text
            My.Settings.ConflictingBusTrafficLightDelay = TextBoxDelayConflictingBusTrafficLightDelay.Text
            My.Settings.Save()

            Close()
        Else
            MessageBox.Show("Could not save settings. Please check if the entered values are valid.", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ButtonClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonClose.Click
        Close()
    End Sub

    'Load all initial settings properties into the textboxes.
    Private Sub SettingsWindow_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        If My.Settings.StartTrafficLichtsRed = True Then
            CheckBoxGeneralStartTrafficLightsRed.Checked = True
        Else
            CheckBoxGeneralStartTrafficLightsRed.Checked = False
        End If

        If My.Settings.AutoClearLog = True Then
            CheckBoxAutoClearLog.Checked = True
        Else
            CheckBoxAutoClearLog.Checked = False
        End If

        If My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled Then
            CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Checked = True
        Else
            CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Checked = False
        End If

        TextBoxGeneralServerPort.Text = My.Settings.ListeningPortNumber
        TextBoxDelayGreenToOrange.Text = My.Settings.GreenToOrangeDelay
        TextBoxDelayOrangeToRed.Text = My.Settings.OrangeToRedDelay
        TextBoxDelayVehicleQueue.Text = My.Settings.ExtraVehicleDelay
        TextBoxDelayBetweenStates.Text = My.Settings.StateDelay
        TextBoxDelayMinimumDelayBetweenBusStates.Text = My.Settings.MinimumBusStateDelay
        TextBoxDelayConflictingBusTrafficLightDelay.Text = My.Settings.ConflictingBusTrafficLightDelay
    End Sub

    'Restore settings to the defaults.
    Private Sub ButtonRestoreDefaults_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRestoreDefaults.Click
        My.Settings.ListeningPortNumber = 10000
        My.Settings.StartTrafficLichtsRed = True
        My.Settings.AutoClearLog = True
        My.Settings.GreenToOrangeDelay = 15
        My.Settings.OrangeToRedDelay = 3
        My.Settings.ExtraVehicleDelay = 0
        My.Settings.StateDelay = 2
        My.Settings.MinimumBusStateDelay = 3
        My.Settings.ConflictingBusTrafficLightDelay = 10
        My.Settings.PedestrianCyclistTrafficLightsAlwaysEnabled = False

        TextBoxGeneralServerPort.Text = My.Settings.ListeningPortNumber
        CheckBoxGeneralStartTrafficLightsRed.Checked = True
        CheckBoxAutoClearLog.Checked = True
        TextBoxDelayGreenToOrange.Text = My.Settings.GreenToOrangeDelay
        TextBoxDelayOrangeToRed.Text = My.Settings.OrangeToRedDelay
        TextBoxDelayVehicleQueue.Text = My.Settings.ExtraVehicleDelay
        TextBoxDelayBetweenStates.Text = My.Settings.StateDelay
        TextBoxDelayMinimumDelayBetweenBusStates.Text = My.Settings.MinimumBusStateDelay
        TextBoxDelayConflictingBusTrafficLightDelay.Text = My.Settings.ConflictingBusTrafficLightDelay
        CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Checked = False
    End Sub
End Class