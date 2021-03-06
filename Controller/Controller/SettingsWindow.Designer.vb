﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsWindow
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
        Me.LabelGeneralServerPort = New System.Windows.Forms.Label()
        Me.TextBoxGeneralServerPort = New System.Windows.Forms.TextBox()
        Me.LabelDelayGreenToOrange = New System.Windows.Forms.Label()
        Me.LabelDelayOrangeToRed = New System.Windows.Forms.Label()
        Me.LabelDelayVehicleQueue = New System.Windows.Forms.Label()
        Me.LabelDelayBetweenStates = New System.Windows.Forms.Label()
        Me.GroupBoxGeneral = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAutoClearLog = New System.Windows.Forms.CheckBox()
        Me.CheckBoxGeneralStartTrafficLightsRed = New System.Windows.Forms.CheckBox()
        Me.GroupBoxDelay = New System.Windows.Forms.GroupBox()
        Me.TextBoxDelayMinimumDelayBetweenBusStates = New System.Windows.Forms.TextBox()
        Me.LabelDelayMinimumDelayBetweenBusStates = New System.Windows.Forms.Label()
        Me.LabelDelayInfo = New System.Windows.Forms.Label()
        Me.TextBoxDelayBetweenStates = New System.Windows.Forms.TextBox()
        Me.TextBoxDelayVehicleQueue = New System.Windows.Forms.TextBox()
        Me.TextBoxDelayOrangeToRed = New System.Windows.Forms.TextBox()
        Me.TextBoxDelayGreenToOrange = New System.Windows.Forms.TextBox()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.ButtonRestoreDefaults = New System.Windows.Forms.Button()
        Me.GroupBoxPedestrianCyclistTrafficLights = New System.Windows.Forms.GroupBox()
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty = New System.Windows.Forms.CheckBox()
        Me.TextBoxDelayConflictingBusTrafficLightDelay = New System.Windows.Forms.TextBox()
        Me.LabelDelayConflictingBusTrafficLightDelay = New System.Windows.Forms.Label()
        Me.GroupBoxGeneral.SuspendLayout()
        Me.GroupBoxDelay.SuspendLayout()
        Me.GroupBoxPedestrianCyclistTrafficLights.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelGeneralServerPort
        '
        Me.LabelGeneralServerPort.AutoSize = True
        Me.LabelGeneralServerPort.Location = New System.Drawing.Point(6, 16)
        Me.LabelGeneralServerPort.Name = "LabelGeneralServerPort"
        Me.LabelGeneralServerPort.Size = New System.Drawing.Size(62, 13)
        Me.LabelGeneralServerPort.TabIndex = 1
        Me.LabelGeneralServerPort.Text = "Server port:"
        '
        'TextBoxGeneralServerPort
        '
        Me.TextBoxGeneralServerPort.Location = New System.Drawing.Point(74, 16)
        Me.TextBoxGeneralServerPort.Name = "TextBoxGeneralServerPort"
        Me.TextBoxGeneralServerPort.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxGeneralServerPort.TabIndex = 2
        '
        'LabelDelayGreenToOrange
        '
        Me.LabelDelayGreenToOrange.AutoSize = True
        Me.LabelDelayGreenToOrange.Location = New System.Drawing.Point(6, 16)
        Me.LabelDelayGreenToOrange.Name = "LabelDelayGreenToOrange"
        Me.LabelDelayGreenToOrange.Size = New System.Drawing.Size(159, 13)
        Me.LabelDelayGreenToOrange.TabIndex = 6
        Me.LabelDelayGreenToOrange.Text = "Delay between green to orange:"
        '
        'LabelDelayOrangeToRed
        '
        Me.LabelDelayOrangeToRed.AutoSize = True
        Me.LabelDelayOrangeToRed.Location = New System.Drawing.Point(6, 42)
        Me.LabelDelayOrangeToRed.Name = "LabelDelayOrangeToRed"
        Me.LabelDelayOrangeToRed.Size = New System.Drawing.Size(156, 13)
        Me.LabelDelayOrangeToRed.TabIndex = 8
        Me.LabelDelayOrangeToRed.Text = "Delay between orange and red:"
        '
        'LabelDelayVehicleQueue
        '
        Me.LabelDelayVehicleQueue.AutoSize = True
        Me.LabelDelayVehicleQueue.Location = New System.Drawing.Point(6, 68)
        Me.LabelDelayVehicleQueue.Name = "LabelDelayVehicleQueue"
        Me.LabelDelayVehicleQueue.Size = New System.Drawing.Size(187, 13)
        Me.LabelDelayVehicleQueue.TabIndex = 10
        Me.LabelDelayVehicleQueue.Text = "Extra delay for every vehicle in queue:"
        '
        'LabelDelayBetweenStates
        '
        Me.LabelDelayBetweenStates.AutoSize = True
        Me.LabelDelayBetweenStates.Location = New System.Drawing.Point(6, 94)
        Me.LabelDelayBetweenStates.Name = "LabelDelayBetweenStates"
        Me.LabelDelayBetweenStates.Size = New System.Drawing.Size(112, 13)
        Me.LabelDelayBetweenStates.TabIndex = 12
        Me.LabelDelayBetweenStates.Text = "Delay between states:"
        '
        'GroupBoxGeneral
        '
        Me.GroupBoxGeneral.Controls.Add(Me.CheckBoxAutoClearLog)
        Me.GroupBoxGeneral.Controls.Add(Me.CheckBoxGeneralStartTrafficLightsRed)
        Me.GroupBoxGeneral.Controls.Add(Me.LabelGeneralServerPort)
        Me.GroupBoxGeneral.Controls.Add(Me.TextBoxGeneralServerPort)
        Me.GroupBoxGeneral.Location = New System.Drawing.Point(7, 12)
        Me.GroupBoxGeneral.Name = "GroupBoxGeneral"
        Me.GroupBoxGeneral.Size = New System.Drawing.Size(349, 85)
        Me.GroupBoxGeneral.TabIndex = 0
        Me.GroupBoxGeneral.TabStop = False
        Me.GroupBoxGeneral.Text = "General"
        '
        'CheckBoxAutoClearLog
        '
        Me.CheckBoxAutoClearLog.AutoSize = True
        Me.CheckBoxAutoClearLog.Location = New System.Drawing.Point(9, 62)
        Me.CheckBoxAutoClearLog.Name = "CheckBoxAutoClearLog"
        Me.CheckBoxAutoClearLog.Size = New System.Drawing.Size(198, 17)
        Me.CheckBoxAutoClearLog.TabIndex = 4
        Me.CheckBoxAutoClearLog.Text = "Automatically clear log at server start"
        Me.CheckBoxAutoClearLog.UseVisualStyleBackColor = True
        '
        'CheckBoxGeneralStartTrafficLightsRed
        '
        Me.CheckBoxGeneralStartTrafficLightsRed.AutoSize = True
        Me.CheckBoxGeneralStartTrafficLightsRed.Location = New System.Drawing.Point(9, 42)
        Me.CheckBoxGeneralStartTrafficLightsRed.Name = "CheckBoxGeneralStartTrafficLightsRed"
        Me.CheckBoxGeneralStartTrafficLightsRed.Size = New System.Drawing.Size(225, 17)
        Me.CheckBoxGeneralStartTrafficLightsRed.TabIndex = 3
        Me.CheckBoxGeneralStartTrafficLightsRed.Text = "Set all traffic lights to red on controller start"
        Me.CheckBoxGeneralStartTrafficLightsRed.UseVisualStyleBackColor = True
        '
        'GroupBoxDelay
        '
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayConflictingBusTrafficLightDelay)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayConflictingBusTrafficLightDelay)
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayMinimumDelayBetweenBusStates)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayMinimumDelayBetweenBusStates)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayInfo)
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayBetweenStates)
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayVehicleQueue)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayBetweenStates)
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayOrangeToRed)
        Me.GroupBoxDelay.Controls.Add(Me.TextBoxDelayGreenToOrange)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayVehicleQueue)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayGreenToOrange)
        Me.GroupBoxDelay.Controls.Add(Me.LabelDelayOrangeToRed)
        Me.GroupBoxDelay.Location = New System.Drawing.Point(7, 103)
        Me.GroupBoxDelay.Name = "GroupBoxDelay"
        Me.GroupBoxDelay.Size = New System.Drawing.Size(349, 191)
        Me.GroupBoxDelay.TabIndex = 5
        Me.GroupBoxDelay.TabStop = False
        Me.GroupBoxDelay.Text = "Delay"
        '
        'TextBoxDelayMinimumDelayBetweenBusStates
        '
        Me.TextBoxDelayMinimumDelayBetweenBusStates.Location = New System.Drawing.Point(209, 120)
        Me.TextBoxDelayMinimumDelayBetweenBusStates.Name = "TextBoxDelayMinimumDelayBetweenBusStates"
        Me.TextBoxDelayMinimumDelayBetweenBusStates.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayMinimumDelayBetweenBusStates.TabIndex = 15
        '
        'LabelDelayMinimumDelayBetweenBusStates
        '
        Me.LabelDelayMinimumDelayBetweenBusStates.AutoSize = True
        Me.LabelDelayMinimumDelayBetweenBusStates.Location = New System.Drawing.Point(6, 120)
        Me.LabelDelayMinimumDelayBetweenBusStates.Name = "LabelDelayMinimumDelayBetweenBusStates"
        Me.LabelDelayMinimumDelayBetweenBusStates.Size = New System.Drawing.Size(174, 13)
        Me.LabelDelayMinimumDelayBetweenBusStates.TabIndex = 14
        Me.LabelDelayMinimumDelayBetweenBusStates.Text = "Minimum delay between bus states:"
        '
        'LabelDelayInfo
        '
        Me.LabelDelayInfo.AutoSize = True
        Me.LabelDelayInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDelayInfo.Location = New System.Drawing.Point(6, 169)
        Me.LabelDelayInfo.Name = "LabelDelayInfo"
        Me.LabelDelayInfo.Size = New System.Drawing.Size(191, 13)
        Me.LabelDelayInfo.TabIndex = 18
        Me.LabelDelayInfo.Text = "Delays are specified in seconds."
        '
        'TextBoxDelayBetweenStates
        '
        Me.TextBoxDelayBetweenStates.Location = New System.Drawing.Point(209, 94)
        Me.TextBoxDelayBetweenStates.Name = "TextBoxDelayBetweenStates"
        Me.TextBoxDelayBetweenStates.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayBetweenStates.TabIndex = 13
        '
        'TextBoxDelayVehicleQueue
        '
        Me.TextBoxDelayVehicleQueue.Location = New System.Drawing.Point(209, 68)
        Me.TextBoxDelayVehicleQueue.Name = "TextBoxDelayVehicleQueue"
        Me.TextBoxDelayVehicleQueue.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayVehicleQueue.TabIndex = 11
        '
        'TextBoxDelayOrangeToRed
        '
        Me.TextBoxDelayOrangeToRed.Location = New System.Drawing.Point(209, 42)
        Me.TextBoxDelayOrangeToRed.Name = "TextBoxDelayOrangeToRed"
        Me.TextBoxDelayOrangeToRed.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayOrangeToRed.TabIndex = 9
        '
        'TextBoxDelayGreenToOrange
        '
        Me.TextBoxDelayGreenToOrange.Location = New System.Drawing.Point(209, 16)
        Me.TextBoxDelayGreenToOrange.Name = "TextBoxDelayGreenToOrange"
        Me.TextBoxDelayGreenToOrange.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayGreenToOrange.TabIndex = 7
        '
        'ButtonClose
        '
        Me.ButtonClose.Location = New System.Drawing.Point(238, 361)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClose.TabIndex = 23
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Location = New System.Drawing.Point(157, 361)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(75, 23)
        Me.ButtonSave.TabIndex = 22
        Me.ButtonSave.Text = "Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'ButtonRestoreDefaults
        '
        Me.ButtonRestoreDefaults.Location = New System.Drawing.Point(50, 361)
        Me.ButtonRestoreDefaults.Name = "ButtonRestoreDefaults"
        Me.ButtonRestoreDefaults.Size = New System.Drawing.Size(101, 23)
        Me.ButtonRestoreDefaults.TabIndex = 21
        Me.ButtonRestoreDefaults.Text = "Restore Defaults"
        Me.ButtonRestoreDefaults.UseVisualStyleBackColor = True
        '
        'GroupBoxPedestrianCyclistTrafficLights
        '
        Me.GroupBoxPedestrianCyclistTrafficLights.Controls.Add(Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty)
        Me.GroupBoxPedestrianCyclistTrafficLights.Location = New System.Drawing.Point(7, 300)
        Me.GroupBoxPedestrianCyclistTrafficLights.Name = "GroupBoxPedestrianCyclistTrafficLights"
        Me.GroupBoxPedestrianCyclistTrafficLights.Size = New System.Drawing.Size(344, 50)
        Me.GroupBoxPedestrianCyclistTrafficLights.TabIndex = 19
        Me.GroupBoxPedestrianCyclistTrafficLights.TabStop = False
        Me.GroupBoxPedestrianCyclistTrafficLights.Text = "Pedestrian/Cyclist Traffic Lights"
        '
        'CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty
        '
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.AutoSize = True
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Location = New System.Drawing.Point(9, 20)
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Name = "CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty"
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Size = New System.Drawing.Size(331, 17)
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.TabIndex = 20
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.Text = "Enable pedestrian/cyclist traffic lights even when queue is empty"
        Me.CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty.UseVisualStyleBackColor = True
        '
        'TextBoxDelayConflictingBusTrafficLightDelay
        '
        Me.TextBoxDelayConflictingBusTrafficLightDelay.Location = New System.Drawing.Point(209, 146)
        Me.TextBoxDelayConflictingBusTrafficLightDelay.Name = "TextBoxDelayConflictingBusTrafficLightDelay"
        Me.TextBoxDelayConflictingBusTrafficLightDelay.Size = New System.Drawing.Size(121, 20)
        Me.TextBoxDelayConflictingBusTrafficLightDelay.TabIndex = 17
        '
        'LabelDelayConflictingBusTrafficLightDelay
        '
        Me.LabelDelayConflictingBusTrafficLightDelay.AutoSize = True
        Me.LabelDelayConflictingBusTrafficLightDelay.Location = New System.Drawing.Point(6, 146)
        Me.LabelDelayConflictingBusTrafficLightDelay.Name = "LabelDelayConflictingBusTrafficLightDelay"
        Me.LabelDelayConflictingBusTrafficLightDelay.Size = New System.Drawing.Size(158, 13)
        Me.LabelDelayConflictingBusTrafficLightDelay.TabIndex = 16
        Me.LabelDelayConflictingBusTrafficLightDelay.Text = "Conflicting bus traffic light delay:"
        '
        'SettingsWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 395)
        Me.Controls.Add(Me.GroupBoxPedestrianCyclistTrafficLights)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonRestoreDefaults)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.GroupBoxDelay)
        Me.Controls.Add(Me.GroupBoxGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsWindow"
        Me.ShowInTaskbar = False
        Me.Text = "Settings"
        Me.GroupBoxGeneral.ResumeLayout(False)
        Me.GroupBoxGeneral.PerformLayout()
        Me.GroupBoxDelay.ResumeLayout(False)
        Me.GroupBoxDelay.PerformLayout()
        Me.GroupBoxPedestrianCyclistTrafficLights.ResumeLayout(False)
        Me.GroupBoxPedestrianCyclistTrafficLights.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelGeneralServerPort As System.Windows.Forms.Label
    Friend WithEvents TextBoxGeneralServerPort As System.Windows.Forms.TextBox
    Friend WithEvents LabelDelayGreenToOrange As System.Windows.Forms.Label
    Friend WithEvents LabelDelayOrangeToRed As System.Windows.Forms.Label
    Friend WithEvents LabelDelayVehicleQueue As System.Windows.Forms.Label
    Friend WithEvents LabelDelayBetweenStates As System.Windows.Forms.Label
    Friend WithEvents GroupBoxGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxDelay As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxDelayBetweenStates As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDelayVehicleQueue As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDelayOrangeToRed As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDelayGreenToOrange As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxGeneralStartTrafficLightsRed As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ButtonRestoreDefaults As System.Windows.Forms.Button
    Friend WithEvents CheckBoxAutoClearLog As System.Windows.Forms.CheckBox
    Friend WithEvents LabelDelayInfo As System.Windows.Forms.Label
    Friend WithEvents TextBoxDelayMinimumDelayBetweenBusStates As System.Windows.Forms.TextBox
    Friend WithEvents LabelDelayMinimumDelayBetweenBusStates As System.Windows.Forms.Label
    Friend WithEvents GroupBoxPedestrianCyclistTrafficLights As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBoxPedestrianCyclistTrafficLightsEnableWhenQueueEmpty As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxDelayConflictingBusTrafficLightDelay As System.Windows.Forms.TextBox
    Friend WithEvents LabelDelayConflictingBusTrafficLightDelay As System.Windows.Forms.Label
End Class
