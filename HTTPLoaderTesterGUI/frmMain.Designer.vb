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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsRecorderStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsPlayerStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsTestPlanStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfigurePathsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImportSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtRecorderHttpsPort = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRecorderBodySub = New System.Windows.Forms.TextBox()
        Me.txtRecorderQuerySub = New System.Windows.Forms.TextBox()
        Me.txtRecorderPathSub = New System.Windows.Forms.TextBox()
        Me.cbRecorderJConsoleStart = New System.Windows.Forms.CheckBox()
        Me.cbRecorderStart = New System.Windows.Forms.CheckBox()
        Me.txtRecorderConsole = New System.Windows.Forms.TextBox()
        Me.cmdRecorderLaunch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecorderFHttpsPort = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtRecorderFHttpPort = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecorderHost = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecorderHttpPort = New System.Windows.Forms.TextBox()
        Me.cmdBrowseTestPlanDirectory = New System.Windows.Forms.Button()
        Me.txtRecorderTestPlanDir = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.cbPlayerApplySubs = New System.Windows.Forms.CheckBox()
        Me.cbPlayerCalcActionDelay = New System.Windows.Forms.CheckBox()
        Me.cbPlayerOverrideHTTPS = New System.Windows.Forms.CheckBox()
        Me.cbPlayerCalcMinRunTime = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtPlayerActionDelay = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPlayerMinRunTime = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtPlayerHTTPSPort = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtPlayerHTTPPort = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtPlayerHost = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPlayerStaggerTime = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtPlayerThreadCount = New System.Windows.Forms.TextBox()
        Me.cbPlayerJConsoleStart = New System.Windows.Forms.CheckBox()
        Me.cbPlayerPause = New System.Windows.Forms.CheckBox()
        Me.txtPlayerConsole = New System.Windows.Forms.TextBox()
        Me.cmdPlayerLaunch = New System.Windows.Forms.Button()
        Me.cmdPlayerBrowse = New System.Windows.Forms.Button()
        Me.txtPlayerTestPlanFile = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmdLoadTestPlan = New System.Windows.Forms.Button()
        Me.txtEditorTestPlanFile = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmdDeleteActions = New System.Windows.Forms.Button()
        Me.lbActions = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbActionMethod = New System.Windows.Forms.ComboBox()
        Me.txtActionDelay = New System.Windows.Forms.TextBox()
        Me.cbActionScheme = New System.Windows.Forms.ComboBox()
        Me.cmdAddAction = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmdUpdateAction = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtActionBody = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtActionHeaders = New System.Windows.Forms.TextBox()
        Me.txtActionPath = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtActionEncoding = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtActionQuery = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.DirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ttGeneral = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRecorderStatus, Me.ToolStripStatusLabel1, Me.tsPlayerStatus, Me.ToolStripStatusLabel2, Me.tsTestPlanStatus})
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
        'tsPlayerStatus
        '
        Me.tsPlayerStatus.Name = "tsPlayerStatus"
        Me.tsPlayerStatus.Size = New System.Drawing.Size(86, 17)
        Me.tsPlayerStatus.Text = "Player Stopped"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel2.Text = " | "
        '
        'tsTestPlanStatus
        '
        Me.tsTestPlanStatus.Name = "tsTestPlanStatus"
        Me.tsTestPlanStatus.Size = New System.Drawing.Size(115, 17)
        Me.tsTestPlanStatus.Text = "No Test Plan Loaded"
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
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurePathsToolStripMenuItem, Me.ToolStripSeparator1, Me.ImportSettingsToolStripMenuItem, Me.ExportSettingsToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ConfigurePathsToolStripMenuItem
        '
        Me.ConfigurePathsToolStripMenuItem.Name = "ConfigurePathsToolStripMenuItem"
        Me.ConfigurePathsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ConfigurePathsToolStripMenuItem.Text = "Configure Global Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(206, 6)
        '
        'ImportSettingsToolStripMenuItem
        '
        Me.ImportSettingsToolStripMenuItem.Name = "ImportSettingsToolStripMenuItem"
        Me.ImportSettingsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ImportSettingsToolStripMenuItem.Text = "Import Settings"
        '
        'ExportSettingsToolStripMenuItem
        '
        Me.ExportSettingsToolStripMenuItem.Name = "ExportSettingsToolStripMenuItem"
        Me.ExportSettingsToolStripMenuItem.Size = New System.Drawing.Size(209, 22)
        Me.ExportSettingsToolStripMenuItem.Text = "Export Settings"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(826, 669)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label26)
        Me.TabPage1.Controls.Add(Me.txtRecorderHttpsPort)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtRecorderBodySub)
        Me.TabPage1.Controls.Add(Me.txtRecorderQuerySub)
        Me.TabPage1.Controls.Add(Me.txtRecorderPathSub)
        Me.TabPage1.Controls.Add(Me.cbRecorderJConsoleStart)
        Me.TabPage1.Controls.Add(Me.cbRecorderStart)
        Me.TabPage1.Controls.Add(Me.txtRecorderConsole)
        Me.TabPage1.Controls.Add(Me.cmdRecorderLaunch)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtRecorderFHttpsPort)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtRecorderFHttpPort)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtRecorderHost)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtRecorderHttpPort)
        Me.TabPage1.Controls.Add(Me.cmdBrowseTestPlanDirectory)
        Me.TabPage1.Controls.Add(Me.txtRecorderTestPlanDir)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(818, 643)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Recorder"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(50, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(105, 13)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Listener HTTPS Port"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderHttpsPort
        '
        Me.txtRecorderHttpsPort.Location = New System.Drawing.Point(161, 58)
        Me.txtRecorderHttpsPort.Name = "txtRecorderHttpsPort"
        Me.txtRecorderHttpsPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHttpsPort.TabIndex = 23
        Me.txtRecorderHttpsPort.Text = "443"
        Me.ttGeneral.SetToolTip(Me.txtRecorderHttpsPort, "HTTP port for listening to requests.")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 341)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Request Body Substitutions"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(57, 253)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Query Substitutions"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(63, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(92, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Path Substitutions"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderBodySub
        '
        Me.txtRecorderBodySub.AcceptsReturn = True
        Me.txtRecorderBodySub.AcceptsTab = True
        Me.txtRecorderBodySub.Location = New System.Drawing.Point(161, 338)
        Me.txtRecorderBodySub.Multiline = True
        Me.txtRecorderBodySub.Name = "txtRecorderBodySub"
        Me.txtRecorderBodySub.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtRecorderBodySub.Size = New System.Drawing.Size(570, 82)
        Me.txtRecorderBodySub.TabIndex = 19
        Me.ttGeneral.SetToolTip(Me.txtRecorderBodySub, "Text to match and substitute in the HTTP request body. JSON format.")
        '
        'txtRecorderQuerySub
        '
        Me.txtRecorderQuerySub.AcceptsReturn = True
        Me.txtRecorderQuerySub.AcceptsTab = True
        Me.txtRecorderQuerySub.Location = New System.Drawing.Point(161, 250)
        Me.txtRecorderQuerySub.Multiline = True
        Me.txtRecorderQuerySub.Name = "txtRecorderQuerySub"
        Me.txtRecorderQuerySub.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtRecorderQuerySub.Size = New System.Drawing.Size(570, 82)
        Me.txtRecorderQuerySub.TabIndex = 18
        Me.ttGeneral.SetToolTip(Me.txtRecorderQuerySub, "Text to match and substitute in the HTTP request query. JSON format.")
        '
        'txtRecorderPathSub
        '
        Me.txtRecorderPathSub.AcceptsReturn = True
        Me.txtRecorderPathSub.AcceptsTab = True
        Me.txtRecorderPathSub.Location = New System.Drawing.Point(161, 162)
        Me.txtRecorderPathSub.Multiline = True
        Me.txtRecorderPathSub.Name = "txtRecorderPathSub"
        Me.txtRecorderPathSub.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtRecorderPathSub.Size = New System.Drawing.Size(570, 82)
        Me.txtRecorderPathSub.TabIndex = 17
        Me.ttGeneral.SetToolTip(Me.txtRecorderPathSub, "Text to match and substitute in the HTTP request path. JSON format.")
        '
        'cbRecorderJConsoleStart
        '
        Me.cbRecorderJConsoleStart.AutoSize = True
        Me.cbRecorderJConsoleStart.Location = New System.Drawing.Point(173, 426)
        Me.cbRecorderJConsoleStart.Name = "cbRecorderJConsoleStart"
        Me.cbRecorderJConsoleStart.Size = New System.Drawing.Size(160, 17)
        Me.cbRecorderJConsoleStart.TabIndex = 16
        Me.cbRecorderJConsoleStart.Text = "Launch JConsole on Startup"
        Me.ttGeneral.SetToolTip(Me.cbRecorderJConsoleStart, "Automatically start JConsole when the Load Tester Recorder launches.")
        Me.cbRecorderJConsoleStart.UseVisualStyleBackColor = True
        '
        'cbRecorderStart
        '
        Me.cbRecorderStart.AutoSize = True
        Me.cbRecorderStart.Location = New System.Drawing.Point(9, 426)
        Me.cbRecorderStart.Name = "cbRecorderStart"
        Me.cbRecorderStart.Size = New System.Drawing.Size(158, 17)
        Me.cbRecorderStart.TabIndex = 14
        Me.cbRecorderStart.Text = "Start Recording Immediately"
        Me.cbRecorderStart.UseVisualStyleBackColor = True
        '
        'txtRecorderConsole
        '
        Me.txtRecorderConsole.AcceptsReturn = True
        Me.txtRecorderConsole.AcceptsTab = True
        Me.txtRecorderConsole.AllowDrop = True
        Me.txtRecorderConsole.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecorderConsole.Location = New System.Drawing.Point(6, 483)
        Me.txtRecorderConsole.Multiline = True
        Me.txtRecorderConsole.Name = "txtRecorderConsole"
        Me.txtRecorderConsole.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtRecorderConsole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtRecorderConsole.Size = New System.Drawing.Size(806, 154)
        Me.txtRecorderConsole.TabIndex = 12
        '
        'cmdRecorderLaunch
        '
        Me.cmdRecorderLaunch.Location = New System.Drawing.Point(6, 448)
        Me.cmdRecorderLaunch.Name = "cmdRecorderLaunch"
        Me.cmdRecorderLaunch.Size = New System.Drawing.Size(806, 29)
        Me.cmdRecorderLaunch.TabIndex = 11
        Me.cmdRecorderLaunch.Text = "Launch!"
        Me.cmdRecorderLaunch.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(149, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Proxy Forwarding HTTPS Port"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderFHttpsPort
        '
        Me.txtRecorderFHttpsPort.Location = New System.Drawing.Point(161, 136)
        Me.txtRecorderFHttpsPort.Name = "txtRecorderFHttpsPort"
        Me.txtRecorderFHttpsPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderFHttpsPort.TabIndex = 9
        Me.txtRecorderFHttpsPort.Text = "443"
        Me.ttGeneral.SetToolTip(Me.txtRecorderFHttpsPort, "The port used for forwarding HTTPS requests. ")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(142, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Proxy Forwarding HTTP Port"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderFHttpPort
        '
        Me.txtRecorderFHttpPort.Location = New System.Drawing.Point(161, 110)
        Me.txtRecorderFHttpPort.Name = "txtRecorderFHttpPort"
        Me.txtRecorderFHttpPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderFHttpPort.TabIndex = 7
        Me.txtRecorderFHttpPort.Text = "80"
        Me.ttGeneral.SetToolTip(Me.txtRecorderFHttpPort, "The port used for forwarding HTTP requests. ")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Proxy Forwarding Host"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderHost
        '
        Me.txtRecorderHost.Location = New System.Drawing.Point(161, 84)
        Me.txtRecorderHost.Name = "txtRecorderHost"
        Me.txtRecorderHost.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHost.TabIndex = 5
        Me.txtRecorderHost.Text = "localhost"
        Me.ttGeneral.SetToolTip(Me.txtRecorderHost, "The host to forward request to.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(57, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Listener HTTP Port"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecorderHttpPort
        '
        Me.txtRecorderHttpPort.Location = New System.Drawing.Point(161, 32)
        Me.txtRecorderHttpPort.Name = "txtRecorderHttpPort"
        Me.txtRecorderHttpPort.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderHttpPort.TabIndex = 3
        Me.txtRecorderHttpPort.Text = "80"
        Me.ttGeneral.SetToolTip(Me.txtRecorderHttpPort, "HTTP port for listening to requests.")
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
        'txtRecorderTestPlanDir
        '
        Me.txtRecorderTestPlanDir.Location = New System.Drawing.Point(161, 6)
        Me.txtRecorderTestPlanDir.Name = "txtRecorderTestPlanDir"
        Me.txtRecorderTestPlanDir.Size = New System.Drawing.Size(570, 20)
        Me.txtRecorderTestPlanDir.TabIndex = 1
        Me.txtRecorderTestPlanDir.Text = "C:\temp\"
        Me.ttGeneral.SetToolTip(Me.txtRecorderTestPlanDir, "The test plan directory. Recorded test plans will be saved in this directory.")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TestPlan Directory"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.cbPlayerApplySubs)
        Me.TabPage3.Controls.Add(Me.cbPlayerCalcActionDelay)
        Me.TabPage3.Controls.Add(Me.cbPlayerOverrideHTTPS)
        Me.TabPage3.Controls.Add(Me.cbPlayerCalcMinRunTime)
        Me.TabPage3.Controls.Add(Me.Label20)
        Me.TabPage3.Controls.Add(Me.txtPlayerActionDelay)
        Me.TabPage3.Controls.Add(Me.Label19)
        Me.TabPage3.Controls.Add(Me.txtPlayerMinRunTime)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.txtPlayerHTTPSPort)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.txtPlayerHTTPPort)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.txtPlayerHost)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txtPlayerStaggerTime)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.txtPlayerThreadCount)
        Me.TabPage3.Controls.Add(Me.cbPlayerJConsoleStart)
        Me.TabPage3.Controls.Add(Me.cbPlayerPause)
        Me.TabPage3.Controls.Add(Me.txtPlayerConsole)
        Me.TabPage3.Controls.Add(Me.cmdPlayerLaunch)
        Me.TabPage3.Controls.Add(Me.cmdPlayerBrowse)
        Me.TabPage3.Controls.Add(Me.txtPlayerTestPlanFile)
        Me.TabPage3.Controls.Add(Me.Label11)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(818, 643)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Player"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'cbPlayerApplySubs
        '
        Me.cbPlayerApplySubs.AutoSize = True
        Me.cbPlayerApplySubs.Location = New System.Drawing.Point(441, 214)
        Me.cbPlayerApplySubs.Name = "cbPlayerApplySubs"
        Me.cbPlayerApplySubs.Size = New System.Drawing.Size(115, 17)
        Me.cbPlayerApplySubs.TabIndex = 40
        Me.cbPlayerApplySubs.Text = "Apply Substitutions"
        Me.ttGeneral.SetToolTip(Me.cbPlayerApplySubs, "Apply variable substitutions, such as <THREAD_ID>, in the test plan.")
        Me.cbPlayerApplySubs.UseVisualStyleBackColor = True
        '
        'cbPlayerCalcActionDelay
        '
        Me.cbPlayerCalcActionDelay.AutoSize = True
        Me.cbPlayerCalcActionDelay.Checked = True
        Me.cbPlayerCalcActionDelay.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPlayerCalcActionDelay.Location = New System.Drawing.Point(653, 191)
        Me.cbPlayerCalcActionDelay.Name = "cbPlayerCalcActionDelay"
        Me.cbPlayerCalcActionDelay.Size = New System.Drawing.Size(132, 17)
        Me.cbPlayerCalcActionDelay.TabIndex = 39
        Me.cbPlayerCalcActionDelay.Text = "Use Test Plan Timings"
        Me.ttGeneral.SetToolTip(Me.cbPlayerCalcActionDelay, "Use test plan timings to determine action delay.")
        Me.cbPlayerCalcActionDelay.UseVisualStyleBackColor = True
        '
        'cbPlayerOverrideHTTPS
        '
        Me.cbPlayerOverrideHTTPS.AutoSize = True
        Me.cbPlayerOverrideHTTPS.Location = New System.Drawing.Point(653, 138)
        Me.cbPlayerOverrideHTTPS.Name = "cbPlayerOverrideHTTPS"
        Me.cbPlayerOverrideHTTPS.Size = New System.Drawing.Size(159, 17)
        Me.cbPlayerOverrideHTTPS.TabIndex = 38
        Me.cbPlayerOverrideHTTPS.Text = "Override HTTPS with HTTP"
        Me.ttGeneral.SetToolTip(Me.cbPlayerOverrideHTTPS, "Replace all HTTPS request with HTTP requests. Useful if the target host does not " &
        "support HTTPS.")
        Me.cbPlayerOverrideHTTPS.UseVisualStyleBackColor = True
        '
        'cbPlayerCalcMinRunTime
        '
        Me.cbPlayerCalcMinRunTime.AutoSize = True
        Me.cbPlayerCalcMinRunTime.Checked = True
        Me.cbPlayerCalcMinRunTime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPlayerCalcMinRunTime.Location = New System.Drawing.Point(653, 164)
        Me.cbPlayerCalcMinRunTime.Name = "cbPlayerCalcMinRunTime"
        Me.cbPlayerCalcMinRunTime.Size = New System.Drawing.Size(148, 17)
        Me.cbPlayerCalcMinRunTime.TabIndex = 37
        Me.cbPlayerCalcMinRunTime.Text = "Calculate Using Test Plan"
        Me.ttGeneral.SetToolTip(Me.cbPlayerCalcMinRunTime, "Will automatically calculate minimum run time using the timings in the test plan." &
        "")
        Me.cbPlayerCalcMinRunTime.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(66, 191)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 36
        Me.Label20.Text = "Action Delay (ms)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerActionDelay
        '
        Me.txtPlayerActionDelay.Enabled = False
        Me.txtPlayerActionDelay.Location = New System.Drawing.Point(161, 188)
        Me.txtPlayerActionDelay.Name = "txtPlayerActionDelay"
        Me.txtPlayerActionDelay.Size = New System.Drawing.Size(486, 20)
        Me.txtPlayerActionDelay.TabIndex = 35
        Me.txtPlayerActionDelay.Text = "10"
        Me.ttGeneral.SetToolTip(Me.txtPlayerActionDelay, "The time to pause between each action of the test plan. Set to zero for no delay." &
        "")
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(44, 165)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 13)
        Me.Label19.TabIndex = 34
        Me.Label19.Text = "Minimum Run Time (s)"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerMinRunTime
        '
        Me.txtPlayerMinRunTime.Enabled = False
        Me.txtPlayerMinRunTime.Location = New System.Drawing.Point(161, 162)
        Me.txtPlayerMinRunTime.Name = "txtPlayerMinRunTime"
        Me.txtPlayerMinRunTime.Size = New System.Drawing.Size(486, 20)
        Me.txtPlayerMinRunTime.TabIndex = 33
        Me.txtPlayerMinRunTime.Text = "120"
        Me.ttGeneral.SetToolTip(Me.txtPlayerMinRunTime, "Minimum runtime ensures that no thread will terminate before the last thread fini" &
        "shed at least 1 run.")
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(90, 139)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(65, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "HTTPS Port"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerHTTPSPort
        '
        Me.txtPlayerHTTPSPort.Location = New System.Drawing.Point(161, 136)
        Me.txtPlayerHTTPSPort.Name = "txtPlayerHTTPSPort"
        Me.txtPlayerHTTPSPort.Size = New System.Drawing.Size(486, 20)
        Me.txtPlayerHTTPSPort.TabIndex = 31
        Me.txtPlayerHTTPSPort.Text = "443"
        Me.ttGeneral.SetToolTip(Me.txtPlayerHTTPSPort, "Port to use for HTTPs requests.")
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(97, 113)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 13)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "HTTP Port"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerHTTPPort
        '
        Me.txtPlayerHTTPPort.Location = New System.Drawing.Point(161, 110)
        Me.txtPlayerHTTPPort.Name = "txtPlayerHTTPPort"
        Me.txtPlayerHTTPPort.Size = New System.Drawing.Size(570, 20)
        Me.txtPlayerHTTPPort.TabIndex = 29
        Me.txtPlayerHTTPPort.Text = "80"
        Me.ttGeneral.SetToolTip(Me.txtPlayerHTTPPort, "Port to use for HTTP requests.")
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(126, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Host"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerHost
        '
        Me.txtPlayerHost.Location = New System.Drawing.Point(161, 84)
        Me.txtPlayerHost.Name = "txtPlayerHost"
        Me.txtPlayerHost.Size = New System.Drawing.Size(570, 20)
        Me.txtPlayerHost.TabIndex = 27
        Me.txtPlayerHost.Text = "localhost"
        Me.ttGeneral.SetToolTip(Me.txtPlayerHost, "The target host.")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(26, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(129, 13)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Thread Stagger Time (ms)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerStaggerTime
        '
        Me.txtPlayerStaggerTime.Location = New System.Drawing.Point(161, 58)
        Me.txtPlayerStaggerTime.Name = "txtPlayerStaggerTime"
        Me.txtPlayerStaggerTime.Size = New System.Drawing.Size(570, 20)
        Me.txtPlayerStaggerTime.TabIndex = 25
        Me.txtPlayerStaggerTime.Text = "5000"
        Me.ttGeneral.SetToolTip(Me.txtPlayerStaggerTime, "The average time offset between the start of each subsequent thread (staggered st" &
        "art).")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(83, 35)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Thread Count"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlayerThreadCount
        '
        Me.txtPlayerThreadCount.Location = New System.Drawing.Point(161, 32)
        Me.txtPlayerThreadCount.Name = "txtPlayerThreadCount"
        Me.txtPlayerThreadCount.Size = New System.Drawing.Size(570, 20)
        Me.txtPlayerThreadCount.TabIndex = 23
        Me.txtPlayerThreadCount.Text = "1"
        Me.ttGeneral.SetToolTip(Me.txtPlayerThreadCount, "The total number of threads to run. Each thread will repeat the test plan at leas" &
        "t once and until the minimum runtime is reached.")
        '
        'cbPlayerJConsoleStart
        '
        Me.cbPlayerJConsoleStart.AutoSize = True
        Me.cbPlayerJConsoleStart.Location = New System.Drawing.Point(275, 214)
        Me.cbPlayerJConsoleStart.Name = "cbPlayerJConsoleStart"
        Me.cbPlayerJConsoleStart.Size = New System.Drawing.Size(160, 17)
        Me.cbPlayerJConsoleStart.TabIndex = 22
        Me.cbPlayerJConsoleStart.Text = "Launch JConsole on Startup"
        Me.ttGeneral.SetToolTip(Me.cbPlayerJConsoleStart, "Automatically start JConsole when the Load Tester Player launches.")
        Me.cbPlayerJConsoleStart.UseVisualStyleBackColor = True
        '
        'cbPlayerPause
        '
        Me.cbPlayerPause.AutoSize = True
        Me.cbPlayerPause.Location = New System.Drawing.Point(161, 214)
        Me.cbPlayerPause.Name = "cbPlayerPause"
        Me.cbPlayerPause.Size = New System.Drawing.Size(108, 17)
        Me.cbPlayerPause.TabIndex = 20
        Me.cbPlayerPause.Text = "Pause on Startup"
        Me.ttGeneral.SetToolTip(Me.cbPlayerPause, "Pause and wait for JMX invocation before starting the test plan.")
        Me.cbPlayerPause.UseVisualStyleBackColor = True
        '
        'txtPlayerConsole
        '
        Me.txtPlayerConsole.AcceptsReturn = True
        Me.txtPlayerConsole.AcceptsTab = True
        Me.txtPlayerConsole.AllowDrop = True
        Me.txtPlayerConsole.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayerConsole.Location = New System.Drawing.Point(6, 272)
        Me.txtPlayerConsole.Multiline = True
        Me.txtPlayerConsole.Name = "txtPlayerConsole"
        Me.txtPlayerConsole.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPlayerConsole.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.txtPlayerConsole.Size = New System.Drawing.Size(806, 368)
        Me.txtPlayerConsole.TabIndex = 18
        '
        'cmdPlayerLaunch
        '
        Me.cmdPlayerLaunch.Location = New System.Drawing.Point(6, 237)
        Me.cmdPlayerLaunch.Name = "cmdPlayerLaunch"
        Me.cmdPlayerLaunch.Size = New System.Drawing.Size(806, 29)
        Me.cmdPlayerLaunch.TabIndex = 17
        Me.cmdPlayerLaunch.Text = "Launch!"
        Me.cmdPlayerLaunch.UseVisualStyleBackColor = True
        '
        'cmdPlayerBrowse
        '
        Me.cmdPlayerBrowse.Location = New System.Drawing.Point(737, 4)
        Me.cmdPlayerBrowse.Name = "cmdPlayerBrowse"
        Me.cmdPlayerBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdPlayerBrowse.TabIndex = 5
        Me.cmdPlayerBrowse.Text = "Browse..."
        Me.cmdPlayerBrowse.UseVisualStyleBackColor = True
        '
        'txtPlayerTestPlanFile
        '
        Me.txtPlayerTestPlanFile.Location = New System.Drawing.Point(161, 6)
        Me.txtPlayerTestPlanFile.Name = "txtPlayerTestPlanFile"
        Me.txtPlayerTestPlanFile.Size = New System.Drawing.Size(570, 20)
        Me.txtPlayerTestPlanFile.TabIndex = 4
        Me.txtPlayerTestPlanFile.Text = "C:\"
        Me.ttGeneral.SetToolTip(Me.txtPlayerTestPlanFile, "The absolute path to the Json test plan file.")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(87, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "TestPlan File"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmdLoadTestPlan)
        Me.TabPage2.Controls.Add(Me.txtEditorTestPlanFile)
        Me.TabPage2.Controls.Add(Me.Label25)
        Me.TabPage2.Controls.Add(Me.cmdDeleteActions)
        Me.TabPage2.Controls.Add(Me.lbActions)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(818, 643)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Test Plan Editor"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdLoadTestPlan
        '
        Me.cmdLoadTestPlan.Location = New System.Drawing.Point(722, 6)
        Me.cmdLoadTestPlan.Name = "cmdLoadTestPlan"
        Me.cmdLoadTestPlan.Size = New System.Drawing.Size(90, 23)
        Me.cmdLoadTestPlan.TabIndex = 31
        Me.cmdLoadTestPlan.Text = "Load..."
        Me.cmdLoadTestPlan.UseVisualStyleBackColor = True
        '
        'txtEditorTestPlanFile
        '
        Me.txtEditorTestPlanFile.Location = New System.Drawing.Point(83, 8)
        Me.txtEditorTestPlanFile.Name = "txtEditorTestPlanFile"
        Me.txtEditorTestPlanFile.ReadOnly = True
        Me.txtEditorTestPlanFile.Size = New System.Drawing.Size(633, 20)
        Me.txtEditorTestPlanFile.TabIndex = 30
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(71, 13)
        Me.Label25.TabIndex = 29
        Me.Label25.Text = "Test Plan File"
        '
        'cmdDeleteActions
        '
        Me.cmdDeleteActions.Location = New System.Drawing.Point(6, 595)
        Me.cmdDeleteActions.Name = "cmdDeleteActions"
        Me.cmdDeleteActions.Size = New System.Drawing.Size(307, 30)
        Me.cmdDeleteActions.TabIndex = 23
        Me.cmdDeleteActions.Text = "Deleted Checked Actions"
        Me.cmdDeleteActions.UseVisualStyleBackColor = True
        '
        'lbActions
        '
        Me.lbActions.FormattingEnabled = True
        Me.lbActions.IntegralHeight = False
        Me.lbActions.Location = New System.Drawing.Point(6, 36)
        Me.lbActions.Name = "lbActions"
        Me.lbActions.Size = New System.Drawing.Size(307, 553)
        Me.lbActions.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbActionMethod)
        Me.GroupBox1.Controls.Add(Me.txtActionDelay)
        Me.GroupBox1.Controls.Add(Me.cbActionScheme)
        Me.GroupBox1.Controls.Add(Me.cmdAddAction)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.cmdUpdateAction)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtActionBody)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtActionHeaders)
        Me.GroupBox1.Controls.Add(Me.txtActionPath)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.txtActionEncoding)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtActionQuery)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Location = New System.Drawing.Point(322, 36)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(490, 601)
        Me.GroupBox1.TabIndex = 28
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Edit Action"
        '
        'cbActionMethod
        '
        Me.cbActionMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbActionMethod.FormattingEnabled = True
        Me.cbActionMethod.Items.AddRange(New Object() {"POST", "PUT", "HEAD", "GET", "DELETE"})
        Me.cbActionMethod.Location = New System.Drawing.Point(108, 72)
        Me.cbActionMethod.Name = "cbActionMethod"
        Me.cbActionMethod.Size = New System.Drawing.Size(376, 21)
        Me.cbActionMethod.TabIndex = 27
        '
        'txtActionDelay
        '
        Me.txtActionDelay.Location = New System.Drawing.Point(108, 19)
        Me.txtActionDelay.Name = "txtActionDelay"
        Me.txtActionDelay.Size = New System.Drawing.Size(376, 20)
        Me.txtActionDelay.TabIndex = 6
        Me.txtActionDelay.Text = "10"
        Me.ttGeneral.SetToolTip(Me.txtActionDelay, "The amount of time to wait before executing this action.")
        '
        'cbActionScheme
        '
        Me.cbActionScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbActionScheme.FormattingEnabled = True
        Me.cbActionScheme.Items.AddRange(New Object() {"HTTP", "HTTPS"})
        Me.cbActionScheme.Location = New System.Drawing.Point(108, 45)
        Me.cbActionScheme.Name = "cbActionScheme"
        Me.cbActionScheme.Size = New System.Drawing.Size(376, 21)
        Me.cbActionScheme.TabIndex = 26
        '
        'cmdAddAction
        '
        Me.cmdAddAction.Location = New System.Drawing.Point(248, 559)
        Me.cmdAddAction.Name = "cmdAddAction"
        Me.cmdAddAction.Size = New System.Drawing.Size(236, 30)
        Me.cmdAddAction.TabIndex = 25
        Me.cmdAddAction.Text = "Add New "
        Me.cmdAddAction.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(42, 292)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 16)
        Me.Label24.TabIndex = 20
        Me.Label24.Text = "Body"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdUpdateAction
        '
        Me.cmdUpdateAction.Location = New System.Drawing.Point(6, 559)
        Me.cmdUpdateAction.Name = "cmdUpdateAction"
        Me.cmdUpdateAction.Size = New System.Drawing.Size(236, 30)
        Me.cmdUpdateAction.TabIndex = 24
        Me.cmdUpdateAction.Text = "Update Action"
        Me.cmdUpdateAction.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(42, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Time Delay (ms)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(42, 178)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 16)
        Me.Label23.TabIndex = 18
        Me.Label23.Text = "Headers"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActionBody
        '
        Me.txtActionBody.AcceptsReturn = True
        Me.txtActionBody.AcceptsTab = True
        Me.txtActionBody.CausesValidation = False
        Me.txtActionBody.Location = New System.Drawing.Point(108, 291)
        Me.txtActionBody.Multiline = True
        Me.txtActionBody.Name = "txtActionBody"
        Me.txtActionBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtActionBody.Size = New System.Drawing.Size(376, 262)
        Me.txtActionBody.TabIndex = 19
        Me.ttGeneral.SetToolTip(Me.txtActionBody, "HTTP Request Headers in JSON format.")
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(42, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Scheme"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(42, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 16)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Method"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActionHeaders
        '
        Me.txtActionHeaders.AcceptsReturn = True
        Me.txtActionHeaders.AcceptsTab = True
        Me.txtActionHeaders.CausesValidation = False
        Me.txtActionHeaders.Location = New System.Drawing.Point(108, 177)
        Me.txtActionHeaders.Multiline = True
        Me.txtActionHeaders.Name = "txtActionHeaders"
        Me.txtActionHeaders.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtActionHeaders.Size = New System.Drawing.Size(376, 108)
        Me.txtActionHeaders.TabIndex = 17
        Me.ttGeneral.SetToolTip(Me.txtActionHeaders, "HTTP Request Headers in JSON format.")
        '
        'txtActionPath
        '
        Me.txtActionPath.Location = New System.Drawing.Point(108, 99)
        Me.txtActionPath.Name = "txtActionPath"
        Me.txtActionPath.Size = New System.Drawing.Size(376, 20)
        Me.txtActionPath.TabIndex = 12
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(-3, 150)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(105, 20)
        Me.Label22.TabIndex = 15
        Me.Label22.Text = "Character Encoding"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActionEncoding
        '
        Me.txtActionEncoding.Location = New System.Drawing.Point(108, 151)
        Me.txtActionEncoding.Name = "txtActionEncoding"
        Me.txtActionEncoding.Size = New System.Drawing.Size(376, 20)
        Me.txtActionEncoding.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(42, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(60, 16)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Path"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtActionQuery
        '
        Me.txtActionQuery.Location = New System.Drawing.Point(108, 125)
        Me.txtActionQuery.Name = "txtActionQuery"
        Me.txtActionQuery.Size = New System.Drawing.Size(376, 20)
        Me.txtActionQuery.TabIndex = 14
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(24, 126)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 16)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Query String"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.DefaultExt = "json"
        Me.OpenFileDialog.FileName = "settings.json"
        Me.OpenFileDialog.Filter = "json|*.json"
        Me.OpenFileDialog.Title = "Load Settings"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.DefaultExt = "json"
        Me.SaveFileDialog.FileName = "settings.json"
        Me.SaveFileDialog.Filter = "json|*.json"
        Me.SaveFileDialog.Title = "Save Settings"
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents cmdBrowseTestPlanDirectory As Button
    Friend WithEvents txtRecorderTestPlanDir As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtRecorderHttpPort As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRecorderFHttpsPort As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtRecorderFHttpPort As TextBox
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
    Friend WithEvents cbRecorderJConsoleStart As CheckBox
    Friend WithEvents cbRecorderStart As CheckBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ImportSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRecorderBodySub As TextBox
    Friend WithEvents txtRecorderQuerySub As TextBox
    Friend WithEvents txtRecorderPathSub As TextBox
    Friend WithEvents OpenFileDialog As OpenFileDialog
    Friend WithEvents SaveFileDialog As SaveFileDialog
    Friend WithEvents cmdPlayerBrowse As Button
    Friend WithEvents txtPlayerTestPlanFile As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cbPlayerJConsoleStart As CheckBox
    Friend WithEvents cbPlayerPause As CheckBox
    Friend WithEvents txtPlayerConsole As TextBox
    Friend WithEvents cmdPlayerLaunch As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents txtPlayerThreadCount As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtPlayerActionDelay As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtPlayerMinRunTime As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtPlayerHTTPSPort As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtPlayerHTTPPort As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtPlayerHost As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtPlayerStaggerTime As TextBox
    Friend WithEvents ttGeneral As ToolTip
    Friend WithEvents cbPlayerCalcMinRunTime As CheckBox
    Friend WithEvents cbPlayerOverrideHTTPS As CheckBox
    Friend WithEvents cbPlayerCalcActionDelay As CheckBox
    Friend WithEvents cbPlayerApplySubs As CheckBox
    Friend WithEvents lbActions As CheckedListBox
    Friend WithEvents cmdLoadTestPlan As Button
    Friend WithEvents txtEditorTestPlanFile As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cmdDeleteActions As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbActionMethod As ComboBox
    Friend WithEvents txtActionDelay As TextBox
    Friend WithEvents cbActionScheme As ComboBox
    Friend WithEvents cmdAddAction As Button
    Friend WithEvents Label24 As Label
    Friend WithEvents cmdUpdateAction As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtActionBody As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtActionHeaders As TextBox
    Friend WithEvents txtActionPath As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents txtActionEncoding As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtActionQuery As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtRecorderHttpsPort As TextBox
End Class
