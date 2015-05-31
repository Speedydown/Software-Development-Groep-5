<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainWindow))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnableVerboseLoggingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonStop = New System.Windows.Forms.ToolStripButton()
        Me.ListBoxStatus = New System.Windows.Forms.ListBox()
        Me.GroupBoxTrafficLightController = New System.Windows.Forms.GroupBox()
        Me.ButtonTrafficLightControllerStop = New System.Windows.Forms.Button()
        Me.ButtonTrafficLightControllerStart = New System.Windows.Forms.Button()
        Me.GroupBoxVehicleAnnouncement = New System.Windows.Forms.GroupBox()
        Me.TextBoxVehicleAnnouncementId = New System.Windows.Forms.TextBox()
        Me.ButtonVehicleAnnouncementReceive = New System.Windows.Forms.Button()
        Me.LabelVehicleAnnouncementDistance = New System.Windows.Forms.Label()
        Me.ComboBoxVehicleAnnouncementDistance = New System.Windows.Forms.ComboBox()
        Me.LabelVehicleAnnouncementId = New System.Windows.Forms.Label()
        Me.GroupBoxTrafficLightState = New System.Windows.Forms.GroupBox()
        Me.TextBoxTrafficLightStateId = New System.Windows.Forms.TextBox()
        Me.ButtonTrafficLightStateChangeState = New System.Windows.Forms.Button()
        Me.LabelTrafficLightStateState = New System.Windows.Forms.Label()
        Me.ComboBoxTrafficLightStateState = New System.Windows.Forms.ComboBox()
        Me.LabelTrafficLightStateId = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPageTest = New System.Windows.Forms.TabPage()
        Me.GroupBoxOptions = New System.Windows.Forms.GroupBox()
        Me.LabelOptionsSpeed = New System.Windows.Forms.Label()
        Me.ComboBoxOptionsSpeed = New System.Windows.Forms.ComboBox()
        Me.GroupBoxAutoSpawn = New System.Windows.Forms.GroupBox()
        Me.LabelAutoSpawnInfo = New System.Windows.Forms.Label()
        Me.ButtonAutoSpawnStopTestController = New System.Windows.Forms.Button()
        Me.ButtonAutoSpawnStartTestController = New System.Windows.Forms.Button()
        Me.GroupBoxSpawnVehicleTypes = New System.Windows.Forms.GroupBox()
        Me.CheckBoxSpawnVehicleTypesPedestrian = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpawnVehicleCyclists = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpawnVehicleBuses = New System.Windows.Forms.CheckBox()
        Me.CheckBoxSpawnVehicleTypesCars = New System.Windows.Forms.CheckBox()
        Me.TabPageVehicle = New System.Windows.Forms.TabPage()
        Me.GroupBoxSpawnVehicle = New System.Windows.Forms.GroupBox()
        Me.ButtonSpawnVehicle = New System.Windows.Forms.Button()
        Me.LabelSpawnVehicleType = New System.Windows.Forms.Label()
        Me.ComboBoxSpawnVehicleType = New System.Windows.Forms.ComboBox()
        Me.ComboBoxSpawnVehicleEnd = New System.Windows.Forms.ComboBox()
        Me.LabelSpawnVehicleEnd = New System.Windows.Forms.Label()
        Me.ComboBoxSpawnVehicleStart = New System.Windows.Forms.ComboBox()
        Me.LabelSpawnVehicleStart = New System.Windows.Forms.Label()
        Me.TabPageTrafficLight = New System.Windows.Forms.TabPage()
        Me.TabPageDebugging = New System.Windows.Forms.TabPage()
        Me.GroupBoxInfo = New System.Windows.Forms.GroupBox()
        Me.LabelInfoCurrentStateValue = New System.Windows.Forms.Label()
        Me.LabelInfoCurrentTimerValue = New System.Windows.Forms.Label()
        Me.LabelInfoCurrentState = New System.Windows.Forms.Label()
        Me.LabelInfoCurrentTimer = New System.Windows.Forms.Label()
        Me.GroupBoxVehicleQueue = New System.Windows.Forms.GroupBox()
        Me.ButtonVehicleQueueGetQueueSize = New System.Windows.Forms.Button()
        Me.ButtonVehicleQueueResetAllQueues = New System.Windows.Forms.Button()
        Me.ButtonVehicleQueueResetQueue = New System.Windows.Forms.Button()
        Me.TextBoxVehicleQueueId = New System.Windows.Forms.TextBox()
        Me.LabelVehicleQueueId = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBoxTrafficLightController.SuspendLayout()
        Me.GroupBoxVehicleAnnouncement.SuspendLayout()
        Me.GroupBoxTrafficLightState.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPageTest.SuspendLayout()
        Me.GroupBoxOptions.SuspendLayout()
        Me.GroupBoxAutoSpawn.SuspendLayout()
        Me.GroupBoxSpawnVehicleTypes.SuspendLayout()
        Me.TabPageVehicle.SuspendLayout()
        Me.GroupBoxSpawnVehicle.SuspendLayout()
        Me.TabPageTrafficLight.SuspendLayout()
        Me.TabPageDebugging.SuspendLayout()
        Me.GroupBoxInfo.SuspendLayout()
        Me.GroupBoxVehicleQueue.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ViewToolStripMenuItem, Me.OptionsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowIPAddressToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ShowIPAddressToolStripMenuItem
        '
        Me.ShowIPAddressToolStripMenuItem.Name = "ShowIPAddressToolStripMenuItem"
        Me.ShowIPAddressToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ShowIPAddressToolStripMenuItem.Text = "Show IP address"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearLogToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'ClearLogToolStripMenuItem
        '
        Me.ClearLogToolStripMenuItem.Name = "ClearLogToolStripMenuItem"
        Me.ClearLogToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ClearLogToolStripMenuItem.Text = "Clear Log"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnableVerboseLoggingToolStripMenuItem, Me.ToolStripSeparator3, Me.SettingsToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'EnableVerboseLoggingToolStripMenuItem
        '
        Me.EnableVerboseLoggingToolStripMenuItem.CheckOnClick = True
        Me.EnableVerboseLoggingToolStripMenuItem.Name = "EnableVerboseLoggingToolStripMenuItem"
        Me.EnableVerboseLoggingToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.EnableVerboseLoggingToolStripMenuItem.Text = "Enable Verbose Logging"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(198, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(201, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings..."
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonStart, Me.ToolStripButtonStop})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(542, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonStart
        '
        Me.ToolStripButtonStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonStart.Image = CType(resources.GetObject("ToolStripButtonStart.Image"), System.Drawing.Image)
        Me.ToolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonStart.Name = "ToolStripButtonStart"
        Me.ToolStripButtonStart.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonStart.Text = "Start"
        '
        'ToolStripButtonStop
        '
        Me.ToolStripButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonStop.Image = CType(resources.GetObject("ToolStripButtonStop.Image"), System.Drawing.Image)
        Me.ToolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonStop.Name = "ToolStripButtonStop"
        Me.ToolStripButtonStop.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonStop.Text = "Stop"
        '
        'ListBoxStatus
        '
        Me.ListBoxStatus.FormattingEnabled = True
        Me.ListBoxStatus.Location = New System.Drawing.Point(12, 53)
        Me.ListBoxStatus.Name = "ListBoxStatus"
        Me.ListBoxStatus.Size = New System.Drawing.Size(518, 316)
        Me.ListBoxStatus.TabIndex = 2
        '
        'GroupBoxTrafficLightController
        '
        Me.GroupBoxTrafficLightController.Controls.Add(Me.ButtonTrafficLightControllerStop)
        Me.GroupBoxTrafficLightController.Controls.Add(Me.ButtonTrafficLightControllerStart)
        Me.GroupBoxTrafficLightController.Location = New System.Drawing.Point(212, 6)
        Me.GroupBoxTrafficLightController.Name = "GroupBoxTrafficLightController"
        Me.GroupBoxTrafficLightController.Size = New System.Drawing.Size(178, 139)
        Me.GroupBoxTrafficLightController.TabIndex = 6
        Me.GroupBoxTrafficLightController.TabStop = False
        Me.GroupBoxTrafficLightController.Text = "Traffic Light Controller"
        '
        'ButtonTrafficLightControllerStop
        '
        Me.ButtonTrafficLightControllerStop.Location = New System.Drawing.Point(52, 47)
        Me.ButtonTrafficLightControllerStop.Name = "ButtonTrafficLightControllerStop"
        Me.ButtonTrafficLightControllerStop.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTrafficLightControllerStop.TabIndex = 8
        Me.ButtonTrafficLightControllerStop.Text = "Stop"
        Me.ButtonTrafficLightControllerStop.UseVisualStyleBackColor = True
        '
        'ButtonTrafficLightControllerStart
        '
        Me.ButtonTrafficLightControllerStart.Location = New System.Drawing.Point(52, 19)
        Me.ButtonTrafficLightControllerStart.Name = "ButtonTrafficLightControllerStart"
        Me.ButtonTrafficLightControllerStart.Size = New System.Drawing.Size(75, 23)
        Me.ButtonTrafficLightControllerStart.TabIndex = 7
        Me.ButtonTrafficLightControllerStart.Text = "Start"
        Me.ButtonTrafficLightControllerStart.UseVisualStyleBackColor = True
        '
        'GroupBoxVehicleAnnouncement
        '
        Me.GroupBoxVehicleAnnouncement.Controls.Add(Me.TextBoxVehicleAnnouncementId)
        Me.GroupBoxVehicleAnnouncement.Controls.Add(Me.ButtonVehicleAnnouncementReceive)
        Me.GroupBoxVehicleAnnouncement.Controls.Add(Me.LabelVehicleAnnouncementDistance)
        Me.GroupBoxVehicleAnnouncement.Controls.Add(Me.ComboBoxVehicleAnnouncementDistance)
        Me.GroupBoxVehicleAnnouncement.Controls.Add(Me.LabelVehicleAnnouncementId)
        Me.GroupBoxVehicleAnnouncement.Location = New System.Drawing.Point(205, 6)
        Me.GroupBoxVehicleAnnouncement.Name = "GroupBoxVehicleAnnouncement"
        Me.GroupBoxVehicleAnnouncement.Size = New System.Drawing.Size(216, 139)
        Me.GroupBoxVehicleAnnouncement.TabIndex = 8
        Me.GroupBoxVehicleAnnouncement.TabStop = False
        Me.GroupBoxVehicleAnnouncement.Text = "Vehicle Announcement"
        '
        'TextBoxVehicleAnnouncementId
        '
        Me.TextBoxVehicleAnnouncementId.Location = New System.Drawing.Point(72, 19)
        Me.TextBoxVehicleAnnouncementId.Name = "TextBoxVehicleAnnouncementId"
        Me.TextBoxVehicleAnnouncementId.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxVehicleAnnouncementId.TabIndex = 10
        '
        'ButtonVehicleAnnouncementReceive
        '
        Me.ButtonVehicleAnnouncementReceive.Location = New System.Drawing.Point(72, 103)
        Me.ButtonVehicleAnnouncementReceive.Name = "ButtonVehicleAnnouncementReceive"
        Me.ButtonVehicleAnnouncementReceive.Size = New System.Drawing.Size(90, 23)
        Me.ButtonVehicleAnnouncementReceive.TabIndex = 13
        Me.ButtonVehicleAnnouncementReceive.Text = "Receive"
        Me.ButtonVehicleAnnouncementReceive.UseVisualStyleBackColor = True
        '
        'LabelVehicleAnnouncementDistance
        '
        Me.LabelVehicleAnnouncementDistance.AutoSize = True
        Me.LabelVehicleAnnouncementDistance.Location = New System.Drawing.Point(7, 47)
        Me.LabelVehicleAnnouncementDistance.Name = "LabelVehicleAnnouncementDistance"
        Me.LabelVehicleAnnouncementDistance.Size = New System.Drawing.Size(52, 13)
        Me.LabelVehicleAnnouncementDistance.TabIndex = 11
        Me.LabelVehicleAnnouncementDistance.Text = "Distance:"
        '
        'ComboBoxVehicleAnnouncementDistance
        '
        Me.ComboBoxVehicleAnnouncementDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxVehicleAnnouncementDistance.FormattingEnabled = True
        Me.ComboBoxVehicleAnnouncementDistance.Items.AddRange(New Object() {"Below", "Before"})
        Me.ComboBoxVehicleAnnouncementDistance.Location = New System.Drawing.Point(72, 47)
        Me.ComboBoxVehicleAnnouncementDistance.Name = "ComboBoxVehicleAnnouncementDistance"
        Me.ComboBoxVehicleAnnouncementDistance.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxVehicleAnnouncementDistance.TabIndex = 12
        '
        'LabelVehicleAnnouncementId
        '
        Me.LabelVehicleAnnouncementId.AutoSize = True
        Me.LabelVehicleAnnouncementId.Location = New System.Drawing.Point(7, 19)
        Me.LabelVehicleAnnouncementId.Name = "LabelVehicleAnnouncementId"
        Me.LabelVehicleAnnouncementId.Size = New System.Drawing.Size(21, 13)
        Me.LabelVehicleAnnouncementId.TabIndex = 9
        Me.LabelVehicleAnnouncementId.Text = "ID:"
        '
        'GroupBoxTrafficLightState
        '
        Me.GroupBoxTrafficLightState.Controls.Add(Me.TextBoxTrafficLightStateId)
        Me.GroupBoxTrafficLightState.Controls.Add(Me.ButtonTrafficLightStateChangeState)
        Me.GroupBoxTrafficLightState.Controls.Add(Me.LabelTrafficLightStateState)
        Me.GroupBoxTrafficLightState.Controls.Add(Me.ComboBoxTrafficLightStateState)
        Me.GroupBoxTrafficLightState.Controls.Add(Me.LabelTrafficLightStateId)
        Me.GroupBoxTrafficLightState.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxTrafficLightState.Name = "GroupBoxTrafficLightState"
        Me.GroupBoxTrafficLightState.Size = New System.Drawing.Size(200, 139)
        Me.GroupBoxTrafficLightState.TabIndex = 0
        Me.GroupBoxTrafficLightState.TabStop = False
        Me.GroupBoxTrafficLightState.Text = "Traffic Light State"
        '
        'TextBoxTrafficLightStateId
        '
        Me.TextBoxTrafficLightStateId.Location = New System.Drawing.Point(45, 19)
        Me.TextBoxTrafficLightStateId.Name = "TextBoxTrafficLightStateId"
        Me.TextBoxTrafficLightStateId.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxTrafficLightStateId.TabIndex = 2
        '
        'ButtonTrafficLightStateChangeState
        '
        Me.ButtonTrafficLightStateChangeState.Location = New System.Drawing.Point(45, 74)
        Me.ButtonTrafficLightStateChangeState.Name = "ButtonTrafficLightStateChangeState"
        Me.ButtonTrafficLightStateChangeState.Size = New System.Drawing.Size(90, 23)
        Me.ButtonTrafficLightStateChangeState.TabIndex = 5
        Me.ButtonTrafficLightStateChangeState.Text = "Change State"
        Me.ButtonTrafficLightStateChangeState.UseVisualStyleBackColor = True
        '
        'LabelTrafficLightStateState
        '
        Me.LabelTrafficLightStateState.AutoSize = True
        Me.LabelTrafficLightStateState.Location = New System.Drawing.Point(7, 47)
        Me.LabelTrafficLightStateState.Name = "LabelTrafficLightStateState"
        Me.LabelTrafficLightStateState.Size = New System.Drawing.Size(35, 13)
        Me.LabelTrafficLightStateState.TabIndex = 3
        Me.LabelTrafficLightStateState.Text = "State:"
        '
        'ComboBoxTrafficLightStateState
        '
        Me.ComboBoxTrafficLightStateState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTrafficLightStateState.FormattingEnabled = True
        Me.ComboBoxTrafficLightStateState.Items.AddRange(New Object() {"Red", "Orange", "Green"})
        Me.ComboBoxTrafficLightStateState.Location = New System.Drawing.Point(45, 47)
        Me.ComboBoxTrafficLightStateState.Name = "ComboBoxTrafficLightStateState"
        Me.ComboBoxTrafficLightStateState.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxTrafficLightStateState.TabIndex = 4
        '
        'LabelTrafficLightStateId
        '
        Me.LabelTrafficLightStateId.AutoSize = True
        Me.LabelTrafficLightStateId.Location = New System.Drawing.Point(7, 19)
        Me.LabelTrafficLightStateId.Name = "LabelTrafficLightStateId"
        Me.LabelTrafficLightStateId.Size = New System.Drawing.Size(21, 13)
        Me.LabelTrafficLightStateId.TabIndex = 1
        Me.LabelTrafficLightStateId.Text = "ID:"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPageTest)
        Me.TabControl.Controls.Add(Me.TabPageVehicle)
        Me.TabControl.Controls.Add(Me.TabPageTrafficLight)
        Me.TabControl.Controls.Add(Me.TabPageDebugging)
        Me.TabControl.Location = New System.Drawing.Point(12, 375)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(518, 178)
        Me.TabControl.TabIndex = 4
        '
        'TabPageTest
        '
        Me.TabPageTest.Controls.Add(Me.GroupBoxOptions)
        Me.TabPageTest.Controls.Add(Me.GroupBoxAutoSpawn)
        Me.TabPageTest.Controls.Add(Me.GroupBoxSpawnVehicleTypes)
        Me.TabPageTest.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTest.Name = "TabPageTest"
        Me.TabPageTest.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTest.Size = New System.Drawing.Size(510, 152)
        Me.TabPageTest.TabIndex = 3
        Me.TabPageTest.Text = "Test"
        Me.TabPageTest.UseVisualStyleBackColor = True
        '
        'GroupBoxOptions
        '
        Me.GroupBoxOptions.Controls.Add(Me.LabelOptionsSpeed)
        Me.GroupBoxOptions.Controls.Add(Me.ComboBoxOptionsSpeed)
        Me.GroupBoxOptions.Location = New System.Drawing.Point(137, 6)
        Me.GroupBoxOptions.Name = "GroupBoxOptions"
        Me.GroupBoxOptions.Size = New System.Drawing.Size(159, 139)
        Me.GroupBoxOptions.TabIndex = 5
        Me.GroupBoxOptions.TabStop = False
        Me.GroupBoxOptions.Text = "Options"
        '
        'LabelOptionsSpeed
        '
        Me.LabelOptionsSpeed.AutoSize = True
        Me.LabelOptionsSpeed.Location = New System.Drawing.Point(7, 19)
        Me.LabelOptionsSpeed.Name = "LabelOptionsSpeed"
        Me.LabelOptionsSpeed.Size = New System.Drawing.Size(41, 13)
        Me.LabelOptionsSpeed.TabIndex = 6
        Me.LabelOptionsSpeed.Text = "Speed:"
        '
        'ComboBoxOptionsSpeed
        '
        Me.ComboBoxOptionsSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxOptionsSpeed.FormattingEnabled = True
        Me.ComboBoxOptionsSpeed.Items.AddRange(New Object() {"Slow", "Normal", "Fast", "Spam"})
        Me.ComboBoxOptionsSpeed.Location = New System.Drawing.Point(50, 19)
        Me.ComboBoxOptionsSpeed.Name = "ComboBoxOptionsSpeed"
        Me.ComboBoxOptionsSpeed.Size = New System.Drawing.Size(88, 21)
        Me.ComboBoxOptionsSpeed.TabIndex = 7
        '
        'GroupBoxAutoSpawn
        '
        Me.GroupBoxAutoSpawn.Controls.Add(Me.LabelAutoSpawnInfo)
        Me.GroupBoxAutoSpawn.Controls.Add(Me.ButtonAutoSpawnStopTestController)
        Me.GroupBoxAutoSpawn.Controls.Add(Me.ButtonAutoSpawnStartTestController)
        Me.GroupBoxAutoSpawn.Location = New System.Drawing.Point(302, 6)
        Me.GroupBoxAutoSpawn.Name = "GroupBoxAutoSpawn"
        Me.GroupBoxAutoSpawn.Size = New System.Drawing.Size(202, 139)
        Me.GroupBoxAutoSpawn.TabIndex = 8
        Me.GroupBoxAutoSpawn.TabStop = False
        Me.GroupBoxAutoSpawn.Text = "Auto Spawn"
        '
        'LabelAutoSpawnInfo
        '
        Me.LabelAutoSpawnInfo.AutoSize = True
        Me.LabelAutoSpawnInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAutoSpawnInfo.Location = New System.Drawing.Point(16, 81)
        Me.LabelAutoSpawnInfo.Name = "LabelAutoSpawnInfo"
        Me.LabelAutoSpawnInfo.Size = New System.Drawing.Size(168, 26)
        Me.LabelAutoSpawnInfo.TabIndex = 11
        Me.LabelAutoSpawnInfo.Text = "Note: Traffic Light Contoller will be" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "started automatically."
        '
        'ButtonAutoSpawnStopTestController
        '
        Me.ButtonAutoSpawnStopTestController.Location = New System.Drawing.Point(40, 47)
        Me.ButtonAutoSpawnStopTestController.Name = "ButtonAutoSpawnStopTestController"
        Me.ButtonAutoSpawnStopTestController.Size = New System.Drawing.Size(121, 23)
        Me.ButtonAutoSpawnStopTestController.TabIndex = 10
        Me.ButtonAutoSpawnStopTestController.Text = "Stop Test Controller"
        Me.ButtonAutoSpawnStopTestController.UseVisualStyleBackColor = True
        '
        'ButtonAutoSpawnStartTestController
        '
        Me.ButtonAutoSpawnStartTestController.Location = New System.Drawing.Point(40, 19)
        Me.ButtonAutoSpawnStartTestController.Name = "ButtonAutoSpawnStartTestController"
        Me.ButtonAutoSpawnStartTestController.Size = New System.Drawing.Size(121, 23)
        Me.ButtonAutoSpawnStartTestController.TabIndex = 9
        Me.ButtonAutoSpawnStartTestController.Text = "Start Test Controller"
        Me.ButtonAutoSpawnStartTestController.UseVisualStyleBackColor = True
        '
        'GroupBoxSpawnVehicleTypes
        '
        Me.GroupBoxSpawnVehicleTypes.Controls.Add(Me.CheckBoxSpawnVehicleTypesPedestrian)
        Me.GroupBoxSpawnVehicleTypes.Controls.Add(Me.CheckBoxSpawnVehicleCyclists)
        Me.GroupBoxSpawnVehicleTypes.Controls.Add(Me.CheckBoxSpawnVehicleBuses)
        Me.GroupBoxSpawnVehicleTypes.Controls.Add(Me.CheckBoxSpawnVehicleTypesCars)
        Me.GroupBoxSpawnVehicleTypes.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxSpawnVehicleTypes.Name = "GroupBoxSpawnVehicleTypes"
        Me.GroupBoxSpawnVehicleTypes.Size = New System.Drawing.Size(125, 139)
        Me.GroupBoxSpawnVehicleTypes.TabIndex = 0
        Me.GroupBoxSpawnVehicleTypes.TabStop = False
        Me.GroupBoxSpawnVehicleTypes.Text = "Spawn Vehicle Types"
        '
        'CheckBoxSpawnVehicleTypesPedestrian
        '
        Me.CheckBoxSpawnVehicleTypesPedestrian.AutoSize = True
        Me.CheckBoxSpawnVehicleTypesPedestrian.Checked = True
        Me.CheckBoxSpawnVehicleTypesPedestrian.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSpawnVehicleTypesPedestrian.Location = New System.Drawing.Point(7, 90)
        Me.CheckBoxSpawnVehicleTypesPedestrian.Name = "CheckBoxSpawnVehicleTypesPedestrian"
        Me.CheckBoxSpawnVehicleTypesPedestrian.Size = New System.Drawing.Size(81, 17)
        Me.CheckBoxSpawnVehicleTypesPedestrian.TabIndex = 4
        Me.CheckBoxSpawnVehicleTypesPedestrian.Text = "Pedestrians"
        Me.CheckBoxSpawnVehicleTypesPedestrian.UseVisualStyleBackColor = True
        '
        'CheckBoxSpawnVehicleCyclists
        '
        Me.CheckBoxSpawnVehicleCyclists.AutoSize = True
        Me.CheckBoxSpawnVehicleCyclists.Checked = True
        Me.CheckBoxSpawnVehicleCyclists.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSpawnVehicleCyclists.Location = New System.Drawing.Point(7, 44)
        Me.CheckBoxSpawnVehicleCyclists.Name = "CheckBoxSpawnVehicleCyclists"
        Me.CheckBoxSpawnVehicleCyclists.Size = New System.Drawing.Size(61, 17)
        Me.CheckBoxSpawnVehicleCyclists.TabIndex = 2
        Me.CheckBoxSpawnVehicleCyclists.Text = "Cyclists"
        Me.CheckBoxSpawnVehicleCyclists.UseVisualStyleBackColor = True
        '
        'CheckBoxSpawnVehicleBuses
        '
        Me.CheckBoxSpawnVehicleBuses.AutoSize = True
        Me.CheckBoxSpawnVehicleBuses.Checked = True
        Me.CheckBoxSpawnVehicleBuses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSpawnVehicleBuses.Location = New System.Drawing.Point(7, 67)
        Me.CheckBoxSpawnVehicleBuses.Name = "CheckBoxSpawnVehicleBuses"
        Me.CheckBoxSpawnVehicleBuses.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxSpawnVehicleBuses.TabIndex = 3
        Me.CheckBoxSpawnVehicleBuses.Text = "Buses"
        Me.CheckBoxSpawnVehicleBuses.UseVisualStyleBackColor = True
        '
        'CheckBoxSpawnVehicleTypesCars
        '
        Me.CheckBoxSpawnVehicleTypesCars.AutoSize = True
        Me.CheckBoxSpawnVehicleTypesCars.Checked = True
        Me.CheckBoxSpawnVehicleTypesCars.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSpawnVehicleTypesCars.Location = New System.Drawing.Point(7, 20)
        Me.CheckBoxSpawnVehicleTypesCars.Name = "CheckBoxSpawnVehicleTypesCars"
        Me.CheckBoxSpawnVehicleTypesCars.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxSpawnVehicleTypesCars.TabIndex = 1
        Me.CheckBoxSpawnVehicleTypesCars.Text = "Cars"
        Me.CheckBoxSpawnVehicleTypesCars.UseVisualStyleBackColor = True
        '
        'TabPageVehicle
        '
        Me.TabPageVehicle.Controls.Add(Me.GroupBoxSpawnVehicle)
        Me.TabPageVehicle.Controls.Add(Me.GroupBoxVehicleAnnouncement)
        Me.TabPageVehicle.Location = New System.Drawing.Point(4, 22)
        Me.TabPageVehicle.Name = "TabPageVehicle"
        Me.TabPageVehicle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageVehicle.Size = New System.Drawing.Size(510, 152)
        Me.TabPageVehicle.TabIndex = 0
        Me.TabPageVehicle.Text = " Vehicle"
        Me.TabPageVehicle.UseVisualStyleBackColor = True
        '
        'GroupBoxSpawnVehicle
        '
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.ButtonSpawnVehicle)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.LabelSpawnVehicleType)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.ComboBoxSpawnVehicleType)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.ComboBoxSpawnVehicleEnd)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.LabelSpawnVehicleEnd)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.ComboBoxSpawnVehicleStart)
        Me.GroupBoxSpawnVehicle.Controls.Add(Me.LabelSpawnVehicleStart)
        Me.GroupBoxSpawnVehicle.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxSpawnVehicle.Name = "GroupBoxSpawnVehicle"
        Me.GroupBoxSpawnVehicle.Size = New System.Drawing.Size(193, 139)
        Me.GroupBoxSpawnVehicle.TabIndex = 0
        Me.GroupBoxSpawnVehicle.TabStop = False
        Me.GroupBoxSpawnVehicle.Text = "Spawn Vehicle"
        '
        'ButtonSpawnVehicle
        '
        Me.ButtonSpawnVehicle.Location = New System.Drawing.Point(50, 103)
        Me.ButtonSpawnVehicle.Name = "ButtonSpawnVehicle"
        Me.ButtonSpawnVehicle.Size = New System.Drawing.Size(90, 23)
        Me.ButtonSpawnVehicle.TabIndex = 7
        Me.ButtonSpawnVehicle.Text = "Spawn"
        Me.ButtonSpawnVehicle.UseVisualStyleBackColor = True
        '
        'LabelSpawnVehicleType
        '
        Me.LabelSpawnVehicleType.AutoSize = True
        Me.LabelSpawnVehicleType.Location = New System.Drawing.Point(7, 75)
        Me.LabelSpawnVehicleType.Name = "LabelSpawnVehicleType"
        Me.LabelSpawnVehicleType.Size = New System.Drawing.Size(34, 13)
        Me.LabelSpawnVehicleType.TabIndex = 5
        Me.LabelSpawnVehicleType.Text = "Type:"
        '
        'ComboBoxSpawnVehicleType
        '
        Me.ComboBoxSpawnVehicleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSpawnVehicleType.FormattingEnabled = True
        Me.ComboBoxSpawnVehicleType.Items.AddRange(New Object() {"Car", "Cyclist", "Bus", "Pedestrian"})
        Me.ComboBoxSpawnVehicleType.Location = New System.Drawing.Point(50, 75)
        Me.ComboBoxSpawnVehicleType.Name = "ComboBoxSpawnVehicleType"
        Me.ComboBoxSpawnVehicleType.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxSpawnVehicleType.TabIndex = 6
        '
        'ComboBoxSpawnVehicleEnd
        '
        Me.ComboBoxSpawnVehicleEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSpawnVehicleEnd.FormattingEnabled = True
        Me.ComboBoxSpawnVehicleEnd.Items.AddRange(New Object() {"North", "East", "South", "West", "Frontage road"})
        Me.ComboBoxSpawnVehicleEnd.Location = New System.Drawing.Point(50, 47)
        Me.ComboBoxSpawnVehicleEnd.Name = "ComboBoxSpawnVehicleEnd"
        Me.ComboBoxSpawnVehicleEnd.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxSpawnVehicleEnd.TabIndex = 4
        '
        'LabelSpawnVehicleEnd
        '
        Me.LabelSpawnVehicleEnd.AutoSize = True
        Me.LabelSpawnVehicleEnd.Location = New System.Drawing.Point(7, 47)
        Me.LabelSpawnVehicleEnd.Name = "LabelSpawnVehicleEnd"
        Me.LabelSpawnVehicleEnd.Size = New System.Drawing.Size(29, 13)
        Me.LabelSpawnVehicleEnd.TabIndex = 3
        Me.LabelSpawnVehicleEnd.Text = "End:"
        '
        'ComboBoxSpawnVehicleStart
        '
        Me.ComboBoxSpawnVehicleStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSpawnVehicleStart.FormattingEnabled = True
        Me.ComboBoxSpawnVehicleStart.Items.AddRange(New Object() {"North", "East", "South", "West", "Frontage road"})
        Me.ComboBoxSpawnVehicleStart.Location = New System.Drawing.Point(50, 19)
        Me.ComboBoxSpawnVehicleStart.Name = "ComboBoxSpawnVehicleStart"
        Me.ComboBoxSpawnVehicleStart.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxSpawnVehicleStart.TabIndex = 2
        '
        'LabelSpawnVehicleStart
        '
        Me.LabelSpawnVehicleStart.AutoSize = True
        Me.LabelSpawnVehicleStart.Location = New System.Drawing.Point(7, 19)
        Me.LabelSpawnVehicleStart.Name = "LabelSpawnVehicleStart"
        Me.LabelSpawnVehicleStart.Size = New System.Drawing.Size(32, 13)
        Me.LabelSpawnVehicleStart.TabIndex = 1
        Me.LabelSpawnVehicleStart.Text = "Start:"
        '
        'TabPageTrafficLight
        '
        Me.TabPageTrafficLight.Controls.Add(Me.GroupBoxTrafficLightController)
        Me.TabPageTrafficLight.Controls.Add(Me.GroupBoxTrafficLightState)
        Me.TabPageTrafficLight.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTrafficLight.Name = "TabPageTrafficLight"
        Me.TabPageTrafficLight.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTrafficLight.Size = New System.Drawing.Size(510, 152)
        Me.TabPageTrafficLight.TabIndex = 1
        Me.TabPageTrafficLight.Text = "Traffic Light"
        Me.TabPageTrafficLight.UseVisualStyleBackColor = True
        '
        'TabPageDebugging
        '
        Me.TabPageDebugging.Controls.Add(Me.GroupBoxInfo)
        Me.TabPageDebugging.Controls.Add(Me.GroupBoxVehicleQueue)
        Me.TabPageDebugging.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDebugging.Name = "TabPageDebugging"
        Me.TabPageDebugging.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDebugging.Size = New System.Drawing.Size(510, 152)
        Me.TabPageDebugging.TabIndex = 2
        Me.TabPageDebugging.Text = "Debugging"
        Me.TabPageDebugging.UseVisualStyleBackColor = True
        '
        'GroupBoxInfo
        '
        Me.GroupBoxInfo.Controls.Add(Me.LabelInfoCurrentStateValue)
        Me.GroupBoxInfo.Controls.Add(Me.LabelInfoCurrentTimerValue)
        Me.GroupBoxInfo.Controls.Add(Me.LabelInfoCurrentState)
        Me.GroupBoxInfo.Controls.Add(Me.LabelInfoCurrentTimer)
        Me.GroupBoxInfo.Location = New System.Drawing.Point(213, 7)
        Me.GroupBoxInfo.Name = "GroupBoxInfo"
        Me.GroupBoxInfo.Size = New System.Drawing.Size(201, 138)
        Me.GroupBoxInfo.TabIndex = 6
        Me.GroupBoxInfo.TabStop = False
        Me.GroupBoxInfo.Text = "Info"
        '
        'LabelInfoCurrentStateValue
        '
        Me.LabelInfoCurrentStateValue.AutoSize = True
        Me.LabelInfoCurrentStateValue.Location = New System.Drawing.Point(74, 32)
        Me.LabelInfoCurrentStateValue.Name = "LabelInfoCurrentStateValue"
        Me.LabelInfoCurrentStateValue.Size = New System.Drawing.Size(27, 13)
        Me.LabelInfoCurrentStateValue.TabIndex = 8
        Me.LabelInfoCurrentStateValue.Text = "N/A"
        '
        'LabelInfoCurrentTimerValue
        '
        Me.LabelInfoCurrentTimerValue.AutoSize = True
        Me.LabelInfoCurrentTimerValue.Location = New System.Drawing.Point(74, 19)
        Me.LabelInfoCurrentTimerValue.Name = "LabelInfoCurrentTimerValue"
        Me.LabelInfoCurrentTimerValue.Size = New System.Drawing.Size(27, 13)
        Me.LabelInfoCurrentTimerValue.TabIndex = 8
        Me.LabelInfoCurrentTimerValue.Text = "N/A"
        '
        'LabelInfoCurrentState
        '
        Me.LabelInfoCurrentState.AutoSize = True
        Me.LabelInfoCurrentState.Location = New System.Drawing.Point(7, 32)
        Me.LabelInfoCurrentState.Name = "LabelInfoCurrentState"
        Me.LabelInfoCurrentState.Size = New System.Drawing.Size(70, 13)
        Me.LabelInfoCurrentState.TabIndex = 7
        Me.LabelInfoCurrentState.Text = "Current state:"
        '
        'LabelInfoCurrentTimer
        '
        Me.LabelInfoCurrentTimer.AutoSize = True
        Me.LabelInfoCurrentTimer.Location = New System.Drawing.Point(7, 19)
        Me.LabelInfoCurrentTimer.Name = "LabelInfoCurrentTimer"
        Me.LabelInfoCurrentTimer.Size = New System.Drawing.Size(69, 13)
        Me.LabelInfoCurrentTimer.TabIndex = 7
        Me.LabelInfoCurrentTimer.Text = "Current timer:"
        '
        'GroupBoxVehicleQueue
        '
        Me.GroupBoxVehicleQueue.Controls.Add(Me.ButtonVehicleQueueGetQueueSize)
        Me.GroupBoxVehicleQueue.Controls.Add(Me.ButtonVehicleQueueResetAllQueues)
        Me.GroupBoxVehicleQueue.Controls.Add(Me.ButtonVehicleQueueResetQueue)
        Me.GroupBoxVehicleQueue.Controls.Add(Me.TextBoxVehicleQueueId)
        Me.GroupBoxVehicleQueue.Controls.Add(Me.LabelVehicleQueueId)
        Me.GroupBoxVehicleQueue.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxVehicleQueue.Name = "GroupBoxVehicleQueue"
        Me.GroupBoxVehicleQueue.Size = New System.Drawing.Size(200, 139)
        Me.GroupBoxVehicleQueue.TabIndex = 0
        Me.GroupBoxVehicleQueue.TabStop = False
        Me.GroupBoxVehicleQueue.Text = "Vehicle Queue"
        '
        'ButtonVehicleQueueGetQueueSize
        '
        Me.ButtonVehicleQueueGetQueueSize.Location = New System.Drawing.Point(45, 46)
        Me.ButtonVehicleQueueGetQueueSize.Name = "ButtonVehicleQueueGetQueueSize"
        Me.ButtonVehicleQueueGetQueueSize.Size = New System.Drawing.Size(121, 23)
        Me.ButtonVehicleQueueGetQueueSize.TabIndex = 3
        Me.ButtonVehicleQueueGetQueueSize.Text = "Get queue size"
        Me.ButtonVehicleQueueGetQueueSize.UseVisualStyleBackColor = True
        '
        'ButtonVehicleQueueResetAllQueues
        '
        Me.ButtonVehicleQueueResetAllQueues.Location = New System.Drawing.Point(45, 104)
        Me.ButtonVehicleQueueResetAllQueues.Name = "ButtonVehicleQueueResetAllQueues"
        Me.ButtonVehicleQueueResetAllQueues.Size = New System.Drawing.Size(121, 23)
        Me.ButtonVehicleQueueResetAllQueues.TabIndex = 5
        Me.ButtonVehicleQueueResetAllQueues.Text = "Reset all queues"
        Me.ButtonVehicleQueueResetAllQueues.UseVisualStyleBackColor = True
        '
        'ButtonVehicleQueueResetQueue
        '
        Me.ButtonVehicleQueueResetQueue.Location = New System.Drawing.Point(45, 75)
        Me.ButtonVehicleQueueResetQueue.Name = "ButtonVehicleQueueResetQueue"
        Me.ButtonVehicleQueueResetQueue.Size = New System.Drawing.Size(121, 23)
        Me.ButtonVehicleQueueResetQueue.TabIndex = 4
        Me.ButtonVehicleQueueResetQueue.Text = "Reset queue"
        Me.ButtonVehicleQueueResetQueue.UseVisualStyleBackColor = True
        '
        'TextBoxVehicleQueueId
        '
        Me.TextBoxVehicleQueueId.Location = New System.Drawing.Point(45, 19)
        Me.TextBoxVehicleQueueId.Name = "TextBoxVehicleQueueId"
        Me.TextBoxVehicleQueueId.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxVehicleQueueId.TabIndex = 2
        '
        'LabelVehicleQueueId
        '
        Me.LabelVehicleQueueId.AutoSize = True
        Me.LabelVehicleQueueId.Location = New System.Drawing.Point(7, 19)
        Me.LabelVehicleQueueId.Name = "LabelVehicleQueueId"
        Me.LabelVehicleQueueId.Size = New System.Drawing.Size(21, 13)
        Me.LabelVehicleQueueId.TabIndex = 1
        Me.LabelVehicleQueueId.Text = "ID:"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 561)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.ListBoxStatus)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.Text = "Controller"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBoxTrafficLightController.ResumeLayout(False)
        Me.GroupBoxVehicleAnnouncement.ResumeLayout(False)
        Me.GroupBoxVehicleAnnouncement.PerformLayout()
        Me.GroupBoxTrafficLightState.ResumeLayout(False)
        Me.GroupBoxTrafficLightState.PerformLayout()
        Me.TabControl.ResumeLayout(False)
        Me.TabPageTest.ResumeLayout(False)
        Me.GroupBoxOptions.ResumeLayout(False)
        Me.GroupBoxOptions.PerformLayout()
        Me.GroupBoxAutoSpawn.ResumeLayout(False)
        Me.GroupBoxAutoSpawn.PerformLayout()
        Me.GroupBoxSpawnVehicleTypes.ResumeLayout(False)
        Me.GroupBoxSpawnVehicleTypes.PerformLayout()
        Me.TabPageVehicle.ResumeLayout(False)
        Me.GroupBoxSpawnVehicle.ResumeLayout(False)
        Me.GroupBoxSpawnVehicle.PerformLayout()
        Me.TabPageTrafficLight.ResumeLayout(False)
        Me.TabPageDebugging.ResumeLayout(False)
        Me.GroupBoxInfo.ResumeLayout(False)
        Me.GroupBoxInfo.PerformLayout()
        Me.GroupBoxVehicleQueue.ResumeLayout(False)
        Me.GroupBoxVehicleQueue.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListBoxStatus As System.Windows.Forms.ListBox
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShowIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBoxTrafficLightState As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonTrafficLightStateChangeState As System.Windows.Forms.Button
    Friend WithEvents LabelTrafficLightStateState As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTrafficLightStateState As System.Windows.Forms.ComboBox
    Friend WithEvents LabelTrafficLightStateId As System.Windows.Forms.Label
    Friend WithEvents TextBoxTrafficLightStateId As System.Windows.Forms.TextBox
    Friend WithEvents ClearLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBoxVehicleAnnouncement As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxVehicleAnnouncementId As System.Windows.Forms.TextBox
    Friend WithEvents ButtonVehicleAnnouncementReceive As System.Windows.Forms.Button
    Friend WithEvents LabelVehicleAnnouncementDistance As System.Windows.Forms.Label
    Friend WithEvents ComboBoxVehicleAnnouncementDistance As System.Windows.Forms.ComboBox
    Friend WithEvents LabelVehicleAnnouncementId As System.Windows.Forms.Label
    Friend WithEvents GroupBoxTrafficLightController As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonTrafficLightControllerStop As System.Windows.Forms.Button
    Friend WithEvents ButtonTrafficLightControllerStart As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPageVehicle As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxSpawnVehicle As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSpawnVehicle As System.Windows.Forms.Button
    Friend WithEvents LabelSpawnVehicleType As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSpawnVehicleType As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxSpawnVehicleEnd As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSpawnVehicleEnd As System.Windows.Forms.Label
    Friend WithEvents ComboBoxSpawnVehicleStart As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSpawnVehicleStart As System.Windows.Forms.Label
    Friend WithEvents TabPageTrafficLight As System.Windows.Forms.TabPage
    Friend WithEvents TabPageDebugging As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxVehicleQueue As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonVehicleQueueResetAllQueues As System.Windows.Forms.Button
    Friend WithEvents ButtonVehicleQueueResetQueue As System.Windows.Forms.Button
    Friend WithEvents TextBoxVehicleQueueId As System.Windows.Forms.TextBox
    Friend WithEvents LabelVehicleQueueId As System.Windows.Forms.Label
    Friend WithEvents GroupBoxInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LabelInfoCurrentTimerValue As System.Windows.Forms.Label
    Friend WithEvents LabelInfoCurrentTimer As System.Windows.Forms.Label
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnableVerboseLoggingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonVehicleQueueGetQueueSize As System.Windows.Forms.Button
    Friend WithEvents TabPageTest As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxSpawnVehicleTypes As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxSpawnVehicleTypesPedestrian As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSpawnVehicleCyclists As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSpawnVehicleBuses As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxSpawnVehicleTypesCars As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxAutoSpawn As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAutoSpawnStopTestController As System.Windows.Forms.Button
    Friend WithEvents ButtonAutoSpawnStartTestController As System.Windows.Forms.Button
    Friend WithEvents LabelAutoSpawnInfo As System.Windows.Forms.Label
    Friend WithEvents LabelInfoCurrentStateValue As System.Windows.Forms.Label
    Friend WithEvents LabelInfoCurrentState As System.Windows.Forms.Label
    Friend WithEvents GroupBoxOptions As System.Windows.Forms.GroupBox
    Friend WithEvents LabelOptionsSpeed As System.Windows.Forms.Label
    Friend WithEvents ComboBoxOptionsSpeed As System.Windows.Forms.ComboBox

End Class
