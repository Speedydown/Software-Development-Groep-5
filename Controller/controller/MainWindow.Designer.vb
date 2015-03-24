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
        Me.LoadFileToolStripMenuItemLoadFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonControllerStart = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonControllerStop = New System.Windows.Forms.ToolStripButton()
        Me.ListBoxStatus = New System.Windows.Forms.ListBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(542, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadFileToolStripMenuItemLoadFile, Me.ToolStripSeparator1, Me.ExitToolStripMenuItemExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadFileToolStripMenuItemLoadFile
        '
        Me.LoadFileToolStripMenuItemLoadFile.Name = "LoadFileToolStripMenuItemLoadFile"
        Me.LoadFileToolStripMenuItemLoadFile.Size = New System.Drawing.Size(152, 22)
        Me.LoadFileToolStripMenuItemLoadFile.Text = "Load File..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'ExitToolStripMenuItemExit
        '
        Me.ExitToolStripMenuItemExit.Name = "ExitToolStripMenuItemExit"
        Me.ExitToolStripMenuItemExit.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItemExit.Text = "Exit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonControllerStart, Me.ToolStripButtonControllerStop})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(542, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButtonControllerStart
        '
        Me.ToolStripButtonControllerStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonControllerStart.Image = CType(resources.GetObject("ToolStripButtonControllerStart.Image"), System.Drawing.Image)
        Me.ToolStripButtonControllerStart.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonControllerStart.Name = "ToolStripButtonControllerStart"
        Me.ToolStripButtonControllerStart.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonControllerStart.Text = "Start controller"
        '
        'ToolStripButtonControllerStop
        '
        Me.ToolStripButtonControllerStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButtonControllerStop.Image = CType(resources.GetObject("ToolStripButtonControllerStop.Image"), System.Drawing.Image)
        Me.ToolStripButtonControllerStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonControllerStop.Name = "ToolStripButtonControllerStop"
        Me.ToolStripButtonControllerStop.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButtonControllerStop.Text = "Stop controller"
        '
        'ListBoxStatus
        '
        Me.ListBoxStatus.FormattingEnabled = True
        Me.ListBoxStatus.Location = New System.Drawing.Point(12, 53)
        Me.ListBoxStatus.Name = "ListBoxStatus"
        Me.ListBoxStatus.Size = New System.Drawing.Size(518, 316)
        Me.ListBoxStatus.TabIndex = 2
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(542, 378)
        Me.Controls.Add(Me.ListBoxStatus)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "MainWindow"
        Me.Text = "Controller"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadFileToolStripMenuItemLoadFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonControllerStart As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonControllerStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ListBoxStatus As System.Windows.Forms.ListBox

End Class
