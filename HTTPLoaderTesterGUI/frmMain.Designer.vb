<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsRecorderStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsTestPlanStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsPlayerStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurePathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtRecorderConsole = New System.Windows.Forms.TextBox()
        Me.cmdRecorderLaunch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecorderHttpsPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecorderHttpPort = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecorderHost = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecorderPort = New System.Windows.Forms.TextBox()
        Me.cmdBrowseTestPlanDirectory = New System.Windows.Forms.Button()
        Me.txtTestPlanDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.DirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chRecorderStart = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRecorderStatus, Me.ToolStripStatusLabel1, Me.tsTestPlanStatus, Me.ToolStripStatusLabel2, Me.tsPlayerStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 699)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(850, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 1
        '
        'tsRecorderStatus
        '
        Me.tsRecorderStatus.Name = "tsRecorderStatus"
        Me.tsRecorderStatus.Size = New System.Drawing.Size(101, 17)
        Me.tsRecorderStatus.Text = "Recorder Stopped"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel1.Text = " | "
        '
        'tsTestPlanStatus
        '
        Me.tsTestPlanStatus.Name = "tsTestPlanStatus"
        Me.tsTestPlanStatus.Size = New System.Drawing.Size(115, 17)
        Me.tsTestPlanStatus.Text = "No Test Plan Loaded"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel2.Text = " | "
        '
        'tsPlayerStatus
        '
        Me.tsPlayerStatus.Name = "tsPlayerStatus"
        Me.tsPlayerStatus.Size = New System.Drawing.Size(86, 17)
        Me.tsPlayerStatus.Text = "Player Stopped"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SettingsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(850, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.OpenToolStripMenuItem.Text = "Open"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurePathsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ConfigurePathsToolStripMenuItem
        '
        Me.ConfigurePathsToolStripMenuItem.Name = "ConfigurePathsToolStripMenuItem"
        Me.ConfigurePathsToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ConfigurePathsToolStripMenuItem.Text = "Configure Paths"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(826, 669)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.chRecorderStart)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtRecorderConsole)
        Me.TabPage1.Controls.Add(Me.cmdRecorderLaunch)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtRecorderHttpsPort)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtRecorderHttpPort)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtRecorderHost)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtRecorderPort)
        Me.TabPage1.Controls.Add(Me.cmdBrowseTestPlanDirectory)
        Me.TabPage1.Controls.Add(Me.txtTestPlanDir)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(818, 643)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Recorder"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtRecorderConsole
        '
        Me.txtRecorderConsole.AcceptsReturn = True
        Me.txtRecorderConsole.AcceptsTab = True
        Me.txtRecorderConsole.AllowDrop = True
        Me.txtRecorderConsole.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecorderConsole.Location = New System.Drawing.Point(6, 226)
        Me.txtRecorderConsole.Multiline = True
        Me.txtRecorderConsole.Name = "txtRecorderConsole"
        Me.txtRecorderConsole.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRecorderConsole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtRecorderConsole.Size = New System.Drawing.Size(806, 180)
        Me.txtRecorderConsole.TabIndex = 12
        '
        'cmdRecorderLaunch
        '
        Me.cmdRecorderLaunch.Location = New System.Drawing.Point(6, 190)
        Me.cmdRecorderLaunch.Name = "cmdRecorderLaunch"
        Me.cmdRecorderLaunch.Size = New System.Drawing.Size(806, 29)
        Me.cmdRecorderLaunch.TabIndex = 11
        Me.cmdRecorderLaunch.Text = "Launch!"
        Me.cmdRecorderLaunch.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Proxy Forwarding HTTPS Port"
        '
        'txtRecorderHttpsPort
        '
        Me.txtRecorderHttpsPort.Location = New System.Drawing.Point(161, 110)
        Me.txtRecorderHttpsPort.Name = "txtRecorderHttpsPort"
        Me.txtRecorderHttpsPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHttpsPort.TabIndex = 9
        Me.txtRecorderHttpsPort.Text = "443"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Proxy Forwarding HTTP Port"
        '
        'txtRecorderHttpPort
        '
        Me.txtRecorderHttpPort.Location = New System.Drawing.Point(161, 84)
        Me.txtRecorderHttpPort.Name = "txtRecorderHttpPort"
        Me.txtRecorderHttpPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHttpPort.TabIndex = 7
        Me.txtRecorderHttpPort.Text = "80"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Proxy Forwarding Host"
        '
        'txtRecorderHost
        '
        Me.txtRecorderHost.Location = New System.Drawing.Point(161, 58)
        Me.txtRecorderHost.Name = "txtRecorderHost"
        Me.txtRecorderHost.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHost.TabIndex = 5
        Me.txtRecorderHost.Text = "localhost"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Listener HTTP Port"
        '
        'txtRecorderPort
        '
        Me.txtRecorderPort.Location = New System.Drawing.Point(161, 32)
        Me.txtRecorderPort.Name = "txtRecorderPort"
        Me.txtRecorderPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderPort.TabIndex = 3
        Me.txtRecorderPort.Text = "80"
        '
        'cmdBrowseTestPlanDirectory
        '
        Me.cmdBrowseTestPlanDirectory.Location = New System.Drawing.Point(737, 4)
        Me.cmdBrowseTestPlanDirectory.Name = "cmdBrowseTestPlanDirectory"
        Me.cmdBrowseTestPlanDirectory.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowseTestPlanDirectory.TabIndex = 2
        Me.cmdBrowseTestPlanDirectory.Text = "Browse..."
        Me.cmdBrowseTestPlanDirectory.UseVisualStyleBackColor = True
        '
        'txtTestPlanDir
        '
        Me.txtTestPlanDir.Location = New System.Drawing.Point(161, 6)
        Me.txtTestPlanDir.Name = "txtTestPlanDir"
        Me.txtTestPlanDir.Size = New System.Drawing.Size(570, 20)
        Me.txtTestPlanDir.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TestPlan Directory"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(818, 643)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Test Plan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(818, 643)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Player"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(139, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Start Recording Immediately"
        '
        'chRecorderStart
        '
        Me.chRecorderStart.AutoSize = True
        Me.chRecorderStart.Location = New System.Drawing.Point(161, 137)
        Me.chRecorderStart.Name = "chRecorderStart"
        Me.chRecorderStart.Size = New System.Drawing.Size(15, 14)
        Me.chRecorderStart.TabIndex = 14
        Me.chRecorderStart.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(340, 136)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(15, 14)
        Me.CheckBox1.TabIndex = 16
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(193, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Launch JConsole on Startup"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 721)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "HTTP Load Tester GUI"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents cmdBrowseTestPlanDirectory As Button
    Friend WithEvents txtTestPlanDir As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRecorderPort As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRecorderHttpsPort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRecorderHttpPort As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRecorderHost As TextBox
    Friend WithEvents tsRecorderStatus As ToolStripStatusLabel
    Friend WithEvents cmdRecorderLaunch As Button
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tsTestPlanStatus As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tsPlayerStatus As ToolStripStatusLabel
    Friend WithEvents txtRecorderConsole As TextBox
    Friend WithEvents DirDialog As FolderBrowserDialog
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConfigurePathsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label7 As Label
    Friend WithEvents chRecorderStart As CheckBox
    Friend WithEvents Label6 As Label
End Class
