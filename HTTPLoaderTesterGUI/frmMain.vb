Imports System.Text
Imports Newtonsoft

Public Class frmMain
    Dim ActionCheckCount As Integer = 0
    Dim lbActionSelection As HTTPAction = Nothing

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub cmdRecorderLaunch_Click(sender As Object, e As EventArgs) Handles cmdRecorderLaunch.Click

        If (GlobalSettings.JavaHome = "") Then
            MsgBox("Java path not set.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        LaunchRecorderThread(BuildRecorderJavaCommand())
        If GlobalSettings.RecorderStartJConsole Then LaunchJConsole(BuildJConsoleCommand("9011"))
    End Sub
    Private Sub LaunchJConsole(ByRef CommandString As String)

        Dim JConsoleProcess As New Process()
        JConsoleProcess.StartInfo.FileName = GlobalSettings.JavaHome & "\jconsole.exe"
        JConsoleProcess.StartInfo.UseShellExecute = False
        JConsoleProcess.StartInfo.CreateNoWindow = True
        JConsoleProcess.StartInfo.RedirectStandardOutput = False
        JConsoleProcess.StartInfo.RedirectStandardError = False
        JConsoleProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        JConsoleProcess.StartInfo.Arguments = CommandString

        If Environment.OSVersion.Version.Major >= 6 Then
            JConsoleProcess.StartInfo.Verb = "runas"
        End If

        txtRecorderConsole.AppendText("Launching JConsole process..." & vbCrLf & vbCrLf)
        Application.DoEvents()

        'Launch a new thread to monitor the process
        Task.Run(Sub()
                     Try
                         JConsoleProcess.Start()
                         JConsoleProcess.WaitForExit()

                         Me.Invoke(Sub()
                                       txtRecorderConsole.AppendText("JConsole process terminated." & vbCrLf & vbCrLf)
                                   End Sub)
                         JConsoleProcess.Close()
                     Catch ex As Exception
                         MsgBox("Unable to start JConsole process." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
                     End Try
                 End Sub)
    End Sub

    Private Sub LaunchRecorderThread(ByVal JavaCommandString As String)

        Dim RecorderProcess As New Process()
        RecorderProcess.StartInfo.FileName = "CMD"
        RecorderProcess.StartInfo.UseShellExecute = False
        RecorderProcess.StartInfo.CreateNoWindow = False
        RecorderProcess.StartInfo.RedirectStandardOutput = False
        RecorderProcess.StartInfo.RedirectStandardError = False
        RecorderProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        RecorderProcess.StartInfo.Arguments = JavaCommandString
        If Environment.OSVersion.Version.Major >= 6 Then
            RecorderProcess.StartInfo.Verb = "runas"
        End If

        txtRecorderConsole.Text = "Using command: CMD " & JavaCommandString & vbCrLf & vbCrLf & "Launching Recorder Proxy process..." & vbCrLf & vbCrLf
        tsRecorderStatus.Text = "Recorder Started"
        cmdRecorderLaunch.Enabled = False
        Application.DoEvents()

        'Launch a new thread to monitor the process
        Task.Run(Sub()
                     Try
                         RecorderProcess.Start()
                         RecorderProcess.WaitForExit()

                         Me.Invoke(Sub()
                                       txtRecorderConsole.AppendText("Recorder Proxy process terminated." & vbCrLf & vbCrLf)
                                       tsRecorderStatus.Text = "Recorder Stopped"
                                       cmdRecorderLaunch.Enabled = True
                                   End Sub)
                         RecorderProcess.Close()
                     Catch ex As Exception
                         MsgBox("Unable to start Recorder Proxy process." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
                     End Try
                 End Sub)
    End Sub

    Private Sub ConfigurePathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurePathsToolStripMenuItem.Click
        frmPaths.ShowDialog()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbActions.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable


        ReloadFromSettings()
    End Sub

    Private Sub ReloadFromSettings()
        txtRecorderHost.Text = GlobalSettings.RecorderForwardingHost
        txtRecorderFHttpPort.Text = GlobalSettings.RecorderForwardingHTTPPort
        txtRecorderFHttpsPort.Text = GlobalSettings.RecorderForwardingHTTPsPort
        txtRecorderHttpPort.Text = GlobalSettings.RecorderListenerHttpPort
        txtRecorderHttpsPort.Text = GlobalSettings.RecorderListenerHttpsPort
        txtRecorderTestPlanDir.Text = GlobalSettings.RecorderTestDirectory
        cbRecorderStart.Checked = GlobalSettings.RecorderStartImmediately
        cbRecorderJConsoleStart.Checked = GlobalSettings.RecorderStartJConsole
        txtRecorderPathSub.Text = GlobalSettings.RecorderPathSubstitutions
        txtRecorderQuerySub.Text = GlobalSettings.RecorderQuerySubstitutions
        txtRecorderBodySub.Text = GlobalSettings.RecorderBodySubstitutions

        cbPlayerJConsoleStart.Checked = GlobalSettings.PlayerStartJConsole
        txtPlayerTestPlanFile.Text = GlobalSettings.PlayerTestPlanFile
        txtPlayerThreadCount.Text = GlobalSettings.PlayerThreadCount
        txtPlayerStaggerTime.Text = GlobalSettings.PlayerStaggerTime
        txtPlayerMinRunTime.Text = GlobalSettings.PlayerMinRunTime
        cbPlayerCalcMinRunTime.Checked = GlobalSettings.PlayerCalcMinRunTime
        txtPlayerActionDelay.Text = GlobalSettings.PlayerActionDelay
        cbPlayerCalcActionDelay.Checked = GlobalSettings.PlayerCalcActionDelay
        txtPlayerHost.Text = GlobalSettings.PlayerHost
        txtPlayerHTTPPort.Text = GlobalSettings.PlayerHTTPPort
        txtPlayerHTTPSPort.Text = GlobalSettings.PlayerHTTPSPort
        cbPlayerPause.Checked = GlobalSettings.PlayerPauseOnStart
        cbPlayerOverrideHTTPS.Checked = GlobalSettings.PlayerOverrideHTTPS
        cbPlayerApplySubs.Checked = GlobalSettings.PlayerApplySubs
        txtEditorTestPlanFile.Text = GlobalSettings.EditorTestPlanFile

        txtPlayerMinRunTime.Enabled = Not GlobalSettings.PlayerCalcMinRunTime
        txtPlayerActionDelay.Enabled = Not GlobalSettings.PlayerCalcActionDelay
        txtPlayerHTTPSPort.Enabled = Not GlobalSettings.PlayerOverrideHTTPS

        LoadTestPlan()
    End Sub

    Private Sub LoadTestPlan()
        If (GlobalSettings.EditorTestPlanFile Is Nothing Or GlobalSettings.EditorTestPlanFile = "") Then
            ClearTestPlanEditor()
            Return
        End If

        Try
            LoadTestPlanFromFile()
            UpdateTestPlanEditor()
        Catch ex As Exception
            ClearTestPlanEditor()
            Application.DoEvents()
            MsgBox("Unable to load test plan '" + GlobalSettings.EditorTestPlanFile + "'." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
            Return
        End Try

    End Sub
    Private Sub UpdateTestPlanEditor()
        lbActions.Items.Clear()
        lbActions.Enabled = True
        lbActions.Items.Add(New HTTPAction(True), CheckState.Indeterminate)
        lbActions.SelectedIndex = 0
        For Each action As HTTPAction In EditorTestPlan
            lbActions.Items.Add(action)
        Next

        tsTestPlanStatus.Text = "Test Plan Loaded - " + EditorTestPlan.Count.ToString + " Action(s)"
        UpdateActionEditor(DirectCast(lbActions.SelectedItem, HTTPAction), True)
        UpdateTestPlanButtons(True)
    End Sub

    Private Sub UpdateActionHeaders(ByRef headers As Dictionary(Of String, String))
        dgActionHeaders.Rows.Clear()
        If headers Is Nothing Then Return

        For Each header As KeyValuePair(Of String, String) In headers
            dgActionHeaders.Rows.Add(header.Key, header.Value)
        Next
    End Sub

    Private Sub UpdateActionEditor(ByRef action As HTTPAction, ByRef TestPlanEnabled As Boolean)
        Dim hasAction As Boolean = (action IsNot Nothing) AndAlso (Not action.isStartDummy)
        Dim hasBody As Boolean = False

        If (hasAction) Then
            txtActionDelay.Text = action.timePassed.ToString
            cbActionScheme.SelectedIndex = cbActionScheme.FindString(action.scheme)
            cbActionMethod.SelectedIndex = cbActionMethod.FindString(action.method)
            txtActionPath.Text = action.path
            txtActionQuery.Text = action.queryString
            txtActionEncoding.Text = action.characterEncoding
            txtActionContentType.Text = action.contentType
            txtActionBody.Text = action.content
            UpdateActionHeaders(action.headers)

            hasBody = action.method = "POST" Or action.method = "PUT"
        Else
            txtActionDelay.Text = ""
            cbActionScheme.SelectedIndex = 0
            cbActionMethod.SelectedIndex = 0
            txtActionContentType.Text = ""
            txtActionPath.Text = ""
            txtActionQuery.Text = ""
            txtActionEncoding.Text = ""
            UpdateActionHeaders(Nothing)
            txtActionBody.Text = ""
        End If

        txtActionDelay.Enabled = TestPlanEnabled
        cbActionScheme.Enabled = TestPlanEnabled
        cbActionMethod.Enabled = TestPlanEnabled
        txtActionPath.Enabled = TestPlanEnabled
        txtActionQuery.Enabled = TestPlanEnabled
        txtActionEncoding.Enabled = TestPlanEnabled
        txtActionContentType.Enabled = TestPlanEnabled
        dgActionHeaders.Enabled = TestPlanEnabled
        txtActionBody.Enabled = hasBody And TestPlanEnabled

        cmdAddAction.Enabled = TestPlanEnabled
        cmdUpdateAction.Enabled = TestPlanEnabled And hasAction
    End Sub
    Private Sub UpdateTestPlanButtons(ByRef TestPlanEnabled As Boolean)
        cmdDeleteActions.Enabled = TestPlanEnabled And ActionCheckCount > 0
    End Sub

    Private Sub ClearTestPlanEditor()
        lbActions.Items.Clear()
        lbActions.Enabled = False
        UpdateActionEditor(Nothing, False)
        UpdateTestPlanButtons(False)
        tsTestPlanStatus.Text = "No Test Plan Loaded"
    End Sub
    Private Sub cmdBrowseTestPlanDirectory_Click(sender As Object, e As EventArgs) Handles cmdBrowseTestPlanDirectory.Click
        If (txtRecorderTestPlanDir.Text IsNot Nothing And Not txtRecorderTestPlanDir.Text = "") Then
            DirDialog.SelectedPath = txtRecorderTestPlanDir.Text
        End If

        If (DirDialog.ShowDialog() = DialogResult.OK) Then
            txtRecorderTestPlanDir.Text = DirDialog.SelectedPath
        End If
        If GlobalSettings.RecorderTestDirectory <> txtRecorderTestPlanDir.Text Then
            GlobalSettings.RecorderTestDirectory = txtRecorderTestPlanDir.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Function BuildRecorderJavaCommand() As String
        Dim javaCommand As New StringBuilder()
        javaCommand.Append("/K """"")
        javaCommand.Append(GlobalSettings.JavaHome)
        javaCommand.Append("\java.exe"" ")
        javaCommand.Append("-Xmx")
        javaCommand.Append(GlobalSettings.RecorderMaxHeap)
        javaCommand.Append(" -Dcom.sun.management.jmxremote")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.port=9011")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.local.only=false")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.authenticate=false")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.ssl=false")
        javaCommand.Append(" -cp """)
        javaCommand.Append(GlobalSettings.LoadTesterJar)
        javaCommand.Append(""" ")
        javaCommand.Append(RECORDER_PROXY_CLASS)
        javaCommand.Append(" -dir """)
        javaCommand.Append(GlobalSettings.RecorderTestDirectory)

        'Deal with a special case where the trailing slash is seen as an escape character
        If (GlobalSettings.RecorderTestDirectory.EndsWith("\")) Then
            javaCommand.Append("\")
        End If

        javaCommand.Append(""" -httpPort ")
        javaCommand.Append(GlobalSettings.RecorderListenerHTTPPort)
        javaCommand.Append(" -httpsPort ")
        javaCommand.Append(GlobalSettings.RecorderListenerHTTPSPort)
        javaCommand.Append(" -fHost ")
        javaCommand.Append(GlobalSettings.RecorderForwardingHost)
        javaCommand.Append(" -fHttpPort ")
        javaCommand.Append(GlobalSettings.RecorderForwardingHTTPPort)
        javaCommand.Append(" -fHttpsPort ")
        javaCommand.Append(GlobalSettings.RecorderForwardingHTTPsPort)

        If GlobalSettings.RecorderStartImmediately Then
            javaCommand.Append(" -start ")
        End If

        If GlobalSettings.RecorderPathSubstitutions IsNot Nothing And GlobalSettings.RecorderPathSubstitutions <> "" Then
            javaCommand.Append(" -pathSubs ")
            javaCommand.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(GlobalSettings.RecorderPathSubstitutions)))
        End If

        If GlobalSettings.RecorderQuerySubstitutions IsNot Nothing And GlobalSettings.RecorderQuerySubstitutions <> "" Then
            javaCommand.Append(" -querySubs ")
            javaCommand.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(GlobalSettings.RecorderQuerySubstitutions)))
        End If

        If GlobalSettings.RecorderBodySubstitutions IsNot Nothing And GlobalSettings.RecorderBodySubstitutions <> "" Then
            javaCommand.Append(" -bodySubs ")
            javaCommand.Append(Convert.ToBase64String(Encoding.UTF8.GetBytes(GlobalSettings.RecorderBodySubstitutions)))
        End If

        javaCommand.Append("""")
        Return javaCommand.ToString
    End Function

    Private Function BuildJConsoleCommand(ByRef port As String) As String
        Dim javaCommand As New StringBuilder()
        With javaCommand
            .Append("localhost:")
            .Append(port)
        End With
        Return javaCommand.ToString
    End Function

    Private Sub txtRecorderHttpPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderHttpPort.LostFocus
        If GlobalSettings.RecorderListenerHTTPPort <> txtRecorderHttpPort.Text Then
            GlobalSettings.RecorderListenerHTTPPort = txtRecorderHttpPort.Text
            GlobalSettings.Save()
        End If

    End Sub

    Private Sub txtRecorderHttpsPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderHttpsPort.LostFocus
        If GlobalSettings.RecorderListenerHTTPSPort <> txtRecorderHttpsPort.Text Then
            GlobalSettings.RecorderListenerHTTPSPort = txtRecorderHttpsPort.Text
            GlobalSettings.Save()
        End If

    End Sub

    Private Sub txtTestPlanDir_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderTestPlanDir.LostFocus
        If GlobalSettings.RecorderTestDirectory <> txtRecorderTestPlanDir.Text Then
            GlobalSettings.RecorderTestDirectory = txtRecorderTestPlanDir.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderHost_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderHost.LostFocus
        If GlobalSettings.RecorderForwardingHost <> txtRecorderHost.Text Then
            GlobalSettings.RecorderForwardingHost = txtRecorderHost.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderFHttpPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderFHttpPort.LostFocus
        If GlobalSettings.RecorderForwardingHTTPPort <> txtRecorderFHttpPort.Text Then
            GlobalSettings.RecorderForwardingHTTPPort = txtRecorderFHttpPort.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderFHttpsPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderFHttpsPort.LostFocus
        If GlobalSettings.RecorderForwardingHTTPsPort <> txtRecorderFHttpsPort.Text Then
            GlobalSettings.RecorderForwardingHTTPsPort = txtRecorderFHttpsPort.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderPathSub_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderPathSub.LostFocus
        If GlobalSettings.RecorderPathSubstitutions <> txtRecorderPathSub.Text Then
            GlobalSettings.RecorderPathSubstitutions = txtRecorderPathSub.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderQuerySub_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderQuerySub.LostFocus
        If GlobalSettings.RecorderQuerySubstitutions <> txtRecorderQuerySub.Text Then
            GlobalSettings.RecorderQuerySubstitutions = txtRecorderQuerySub.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderBodySub_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderBodySub.LostFocus
        If GlobalSettings.RecorderBodySubstitutions <> txtRecorderBodySub.Text Then
            GlobalSettings.RecorderBodySubstitutions = txtRecorderBodySub.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub chRecorderStart_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecorderStart.CheckedChanged
        GlobalSettings.RecorderStartImmediately = cbRecorderStart.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub chJConsoleStart_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecorderJConsoleStart.CheckedChanged
        GlobalSettings.RecorderStartJConsole = cbRecorderJConsoleStart.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub ImportSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSettingsToolStripMenuItem.Click
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                GlobalSettings = Settings.Load(OpenFileDialog.FileName)
            Catch ex As Exception
                MsgBox("Unable to import settings from file '" + OpenFileDialog.FileName + "'." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
                Return
            End Try

            GlobalSettings.Save()
        End If

        Me.ReloadFromSettings()
    End Sub

    Private Sub ExportSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSettingsToolStripMenuItem.Click
        If SaveFileDialog.ShowDialog = DialogResult.OK Then
            Try
                Settings.Save(GlobalSettings, SaveFileDialog.FileName)
            Catch ex As Exception
                MsgBox("Unable to export settings to file '" + SaveFileDialog.FileName + "'." & vbCrLf & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
    End Sub

    Private Sub cbPlayerOverrideHTTPS_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerOverrideHTTPS.CheckedChanged
        txtPlayerHTTPSPort.Enabled = Not cbPlayerOverrideHTTPS.Checked
        GlobalSettings.PlayerOverrideHTTPS = cbPlayerOverrideHTTPS.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub cbPlayerCalcMinRunTime_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerCalcMinRunTime.CheckedChanged
        txtPlayerMinRunTime.Enabled = Not cbPlayerCalcMinRunTime.Checked
        GlobalSettings.PlayerCalcMinRunTime = cbPlayerCalcMinRunTime.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub cbPlayerCalcActionDelay_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerCalcActionDelay.CheckedChanged
        txtPlayerActionDelay.Enabled = Not cbPlayerCalcActionDelay.Checked
        GlobalSettings.PlayerCalcActionDelay = cbPlayerCalcActionDelay.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub cmdPlayerBrowse_Click(sender As Object, e As EventArgs) Handles cmdPlayerBrowse.Click
        If (txtPlayerTestPlanFile.Text IsNot Nothing And Not txtPlayerTestPlanFile.Text = "") Then
            OpenFileDialog.FileName = txtPlayerTestPlanFile.Text
        End If

        If (OpenFileDialog.ShowDialog() = DialogResult.OK) Then
            txtPlayerTestPlanFile.Text = OpenFileDialog.FileName
        End If

        If GlobalSettings.PlayerTestPlanFile <> txtPlayerTestPlanFile.Text Then
            GlobalSettings.PlayerTestPlanFile = txtPlayerTestPlanFile.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerTestPlanFile_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerTestPlanFile.LostFocus
        If GlobalSettings.PlayerTestPlanFile <> txtPlayerTestPlanFile.Text Then
            GlobalSettings.PlayerTestPlanFile = txtPlayerTestPlanFile.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerThreadCount_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerThreadCount.LostFocus
        If GlobalSettings.PlayerThreadCount <> txtPlayerThreadCount.Text Then
            GlobalSettings.PlayerThreadCount = txtPlayerThreadCount.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerStaggerTime_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerStaggerTime.LostFocus
        If GlobalSettings.PlayerStaggerTime <> txtPlayerStaggerTime.Text Then
            GlobalSettings.PlayerStaggerTime = txtPlayerStaggerTime.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerHost_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerHost.LostFocus
        If GlobalSettings.PlayerHost <> txtPlayerHost.Text Then
            GlobalSettings.PlayerHost = txtPlayerHost.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerHTTPPort_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerHTTPPort.LostFocus
        If GlobalSettings.PlayerHTTPPort <> txtPlayerHTTPPort.Text Then
            GlobalSettings.PlayerHTTPPort = txtPlayerHTTPPort.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerHTTPSPort_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerHTTPSPort.LostFocus
        If GlobalSettings.PlayerHTTPSPort <> txtPlayerHTTPSPort.Text Then
            GlobalSettings.PlayerHTTPSPort = txtPlayerHTTPSPort.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerMinRunTime_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerMinRunTime.LostFocus
        If GlobalSettings.PlayerMinRunTime <> txtPlayerMinRunTime.Text Then
            GlobalSettings.PlayerMinRunTime = txtPlayerMinRunTime.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtPlayerActionDelay_LostFocus(sender As Object, e As EventArgs) Handles txtPlayerActionDelay.LostFocus
        If GlobalSettings.PlayerActionDelay <> txtPlayerActionDelay.Text Then
            GlobalSettings.PlayerActionDelay = txtPlayerActionDelay.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub cbPlayerPause_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerPause.CheckedChanged
        GlobalSettings.PlayerPauseOnStart = cbPlayerPause.Checked
        GlobalSettings.Save()

    End Sub

    Private Sub cbPlayerJConsoleStart_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerJConsoleStart.CheckedChanged
        GlobalSettings.PlayerStartJConsole = cbPlayerJConsoleStart.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub cbPlayerApplySubs_CheckedChanged(sender As Object, e As EventArgs) Handles cbPlayerApplySubs.CheckedChanged
        GlobalSettings.PlayerApplySubs = cbPlayerApplySubs.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub txtPlayerHost_TextChanged(sender As Object, e As EventArgs) Handles txtPlayerHost.TextChanged

    End Sub

    Private Sub cmdPlayerLaunch_Click(sender As Object, e As EventArgs) Handles cmdPlayerLaunch.Click

        If (GlobalSettings.JavaHome = "") Then
            MsgBox("Java path not set.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        LaunchPlayerThread(BuildPlayerJavaCommand())
        If GlobalSettings.PlayerStartJConsole Then LaunchJConsole(BuildJConsoleCommand("9012"))
    End Sub

    Private Function BuildPlayerJavaCommand() As String
        Dim javaCommand As New StringBuilder()
        javaCommand.Append("/K """"")
        javaCommand.Append(GlobalSettings.JavaHome)
        javaCommand.Append("\java.exe"" ")
        javaCommand.Append("-Xmx")
        javaCommand.Append(GlobalSettings.PlayerMaxHeap)
        javaCommand.Append(" -Dcom.sun.management.jmxremote")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.port=9012")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.local.only=false")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.authenticate=false")
        javaCommand.Append(" -Dcom.sun.management.jmxremote.ssl=false")
        javaCommand.Append(" -cp """)
        javaCommand.Append(GlobalSettings.LoadTesterJar)
        javaCommand.Append(""" ")
        javaCommand.Append(PLAYER_CLASS)
        javaCommand.Append(" -testPlanFile """)
        javaCommand.Append(GlobalSettings.PlayerTestPlanFile)

        'Deal with a special case where the trailing slash is seen as an escape character
        If (GlobalSettings.PlayerTestPlanFile.EndsWith("\")) Then
            javaCommand.Append("\")
        End If

        javaCommand.Append(""" -threadCount ")
        javaCommand.Append(GlobalSettings.PlayerThreadCount)
        javaCommand.Append(" -staggerTime ")
        javaCommand.Append(GlobalSettings.PlayerStaggerTime)

        If (Not GlobalSettings.PlayerCalcMinRunTime) Then
            javaCommand.Append(" -minRunTime ")
            javaCommand.Append(GlobalSettings.PlayerMinRunTime)
        End If

        If (Not GlobalSettings.PlayerCalcActionDelay) Then
            javaCommand.Append(" -actionDelay ")
            javaCommand.Append(GlobalSettings.PlayerActionDelay)
        End If

        javaCommand.Append(" -host ")
        javaCommand.Append(GlobalSettings.PlayerHost)
        javaCommand.Append(" -httpPort ")
        javaCommand.Append(GlobalSettings.PlayerHTTPPort)
        javaCommand.Append(" -httpsPort ")
        javaCommand.Append(GlobalSettings.PlayerHTTPSPort)

        If GlobalSettings.PlayerPauseOnStart Then
            javaCommand.Append(" -pause ")
        End If

        If GlobalSettings.PlayerOverrideHTTPS Then
            javaCommand.Append(" -overrideHttps ")
        End If

        If GlobalSettings.PlayerApplySubs Then
            javaCommand.Append(" -applySubs ")
        End If

        javaCommand.Append("""")
        Return javaCommand.ToString
    End Function

    Private Sub LaunchPlayerThread(ByVal JavaCommandString As String)

        Dim PlayerProcess As New Process()
        PlayerProcess.StartInfo.FileName = "CMD"
        PlayerProcess.StartInfo.UseShellExecute = False
        PlayerProcess.StartInfo.CreateNoWindow = False
        PlayerProcess.StartInfo.RedirectStandardOutput = False
        PlayerProcess.StartInfo.RedirectStandardError = False
        PlayerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        PlayerProcess.StartInfo.Arguments = JavaCommandString
        If Environment.OSVersion.Version.Major >= 6 Then
            PlayerProcess.StartInfo.Verb = "runas"
        End If

        txtPlayerConsole.Text = "Using command: CMD " & JavaCommandString & vbCrLf & vbCrLf & "Launching Player Proxy process..." & vbCrLf & vbCrLf
        tsPlayerStatus.Text = "Player Started"
        cmdPlayerLaunch.Enabled = False
        Application.DoEvents()

        'Launch a new thread to monitor the process
        Task.Run(Sub()
                     Try
                         PlayerProcess.Start()
                         PlayerProcess.WaitForExit()

                         Me.Invoke(Sub()
                                       txtPlayerConsole.AppendText("Player process terminated." & vbCrLf & vbCrLf)
                                       tsPlayerStatus.Text = "Player Stopped"
                                       cmdPlayerLaunch.Enabled = True
                                   End Sub)
                         PlayerProcess.Close()
                     Catch ex As Exception
                         MsgBox("Unable to start Player process." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
                     End Try
                 End Sub)
    End Sub

    Private Sub cmdLoadTestPlan_Click(sender As Object, e As EventArgs) Handles cmdLoadTestPlan.Click
        If (txtEditorTestPlanFile.Text IsNot Nothing And Not txtEditorTestPlanFile.Text = "") Then
            OpenFileDialog.FileName = txtEditorTestPlanFile.Text
        Else
            OpenFileDialog.FileName = "testplan.json"
        End If

        If (OpenFileDialog.ShowDialog() = DialogResult.OK) Then
            txtEditorTestPlanFile.Text = OpenFileDialog.FileName
        End If

        If GlobalSettings.EditorTestPlanFile <> txtEditorTestPlanFile.Text Then
            GlobalSettings.EditorTestPlanFile = txtEditorTestPlanFile.Text
            GlobalSettings.Save()
        End If

        'Attempt to reload the file regardless of if it's the same
        LoadTestPlan()
    End Sub

    Private Sub cbActionMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbActionMethod.SelectedIndexChanged
        Dim HasBody As Boolean = cbActionMethod.SelectedItem.ToString = "POST" Or cbActionMethod.SelectedItem.ToString = "PUT"
        txtActionBody.Enabled = HasBody
    End Sub

    Private Function ValidateAndCreateAction(ByRef PreviousAction As HTTPAction) As HTTPAction
        Dim action As New HTTPAction

        If Not Long.TryParse(txtActionDelay.Text, action.timePassed) Or action.timePassed < 0 Then
            MsgBox("Time Delay must be a positive integer.", MsgBoxStyle.Critical, "Error")
            Return Nothing
        End If

        'AbsoluteTime is based on the previous action and the time passed
        If (PreviousAction Is Nothing Or PreviousAction.isStartDummy) Then
            action.absoluteTime = Now.AddMilliseconds(action.timePassed)
        Else
            action.absoluteTime = PreviousAction.absoluteTime.AddMilliseconds(action.timePassed)
        End If

        action.scheme = cbActionScheme.SelectedItem.ToString
        action.method = cbActionMethod.SelectedItem.ToString
        action.path = txtActionPath.Text
        action.queryString = txtActionQuery.Text
        action.characterEncoding = txtActionEncoding.Text

        Dim headers As New Dictionary(Of String, String)
        For Each header As DataGridViewRow In dgActionHeaders.Rows
            Dim keyValue As Object = header.Cells(0).Value
            If keyValue Is Nothing Then Continue For

            Dim key As String = keyValue.ToString
            If key = "" Then Continue For

            Dim value As String = header.Cells(1).Value.ToString
            headers.Add(key.ToString, value)
        Next
        action.headers = headers

        action.contentType = txtActionContentType.Text

        action.content = txtActionBody.Text
        action.contentLength = action.content.Length

        Return action
    End Function
    Private Sub cmdAddAction_Click(sender As Object, e As EventArgs) Handles cmdAddAction.Click
        Dim action As HTTPAction = validateAndCreateAction(DirectCast(lbActions.SelectedItem, HTTPAction))
        If (action Is Nothing) Then Return

        Dim insertIndex As Integer = lbActions.SelectedIndex

        If (insertIndex < 0) Then
            insertIndex = lbActions.Items.Count - 1
        Else
            insertIndex += 1
        End If

        lbActions.Items.Insert(insertIndex, action)
        EditorTestPlan.Insert(insertIndex - 1, action)

        RecalculateAbsoluteTimes()
        SaveEditorTestPlan()

        tsTestPlanStatus.Text = "Test Plan Loaded - " + EditorTestPlan.Count.ToString + " Action(s)"
    End Sub

    Private Sub cmdUpdateAction_Click(sender As Object, e As EventArgs) Handles cmdUpdateAction.Click
        Dim NewAction As HTTPAction = ValidateAndCreateAction(DirectCast(lbActions.SelectedItem, HTTPAction))
        If (NewAction Is Nothing) Then Return

        Dim insertIndex As Integer = lbActions.SelectedIndex
        Dim OldAction As HTTPAction = EditorTestPlan.Item(insertIndex - 1)
        Dim RecalulateTimes As Boolean = Not OldAction.timePassed.Equals(NewAction.timePassed)

        lbActions.Items.Item(insertIndex) = NewAction
        EditorTestPlan.Item(insertIndex - 1) = NewAction

        If (RecalulateTimes) Then RecalculateAbsoluteTimes()
        SaveEditorTestPlan()
    End Sub

    Private Sub cmdDeleteActions_Click(sender As Object, e As EventArgs) Handles cmdDeleteActions.Click
        Dim checkActions As List(Of HTTPAction) = lbActions.CheckedItems.Cast(Of HTTPAction).ToList

        For Each action In checkActions
            If (action.isStartDummy) Then Continue For
            lbActions.Items.Remove(action)
            EditorTestPlan.Remove(action)
        Next
        SaveEditorTestPlan()
        cmdDeleteActions.Enabled = False
    End Sub

    Private Sub lbActions_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lbActions.ItemCheck
        If e.CurrentValue = CheckState.Indeterminate Then
            e.NewValue = CheckState.Indeterminate
            Return
        End If

        If e.NewValue = CheckState.Checked Then
            ActionCheckCount += 1
        Else
            ActionCheckCount -= 1
            If ActionCheckCount < 0 Then ActionCheckCount = 0
        End If

        UpdateTestPlanButtons(True)
    End Sub

    Private Sub cmdRefreshTestPlan_Click(sender As Object, e As EventArgs) Handles cmdRefreshTestPlan.Click
        LoadTestPlan()
    End Sub

    Private Sub lbActions_MouseDown(sender As Object, e As MouseEventArgs) Handles lbActions.MouseDown

        Dim newSelection As HTTPAction = DirectCast(lbActions.SelectedItem, HTTPAction)

        If Not Object.ReferenceEquals(newSelection, lbActionSelection) Then
            lbActionSelection = newSelection
            UpdateActionEditor(DirectCast(lbActions.SelectedItem, HTTPAction), True)
        End If

        If newSelection Is Nothing Then Return
        If lbActions.Items.Count < 3 Then Return
        If DirectCast(lbActions.SelectedItem, HTTPAction).isStartDummy Then Return
        lbActions.DoDragDrop(lbActions.SelectedItem, DragDropEffects.Move)
    End Sub

    Private Sub lbActions_DragOver(sender As Object, e As DragEventArgs) Handles lbActions.DragOver
        e.Effect = DragDropEffects.Move
        Dim point As Point = lbActions.PointToClient(New Point(e.X, e.Y))
        Dim index As Integer = lbActions.IndexFromPoint(point)
        If (index < 1) Then Return
        lbActions.SelectedIndex = index
    End Sub

    Private Sub lbActions_DragDrop(sender As Object, e As DragEventArgs) Handles lbActions.DragDrop
        Dim point As Point = lbActions.PointToClient(New Point(e.X, e.Y))
        Dim NewIndex As Integer = lbActions.IndexFromPoint(point)
        If (NewIndex < 1) Then Return

        Dim ActionToMove As HTTPAction = DirectCast(e.Data.GetData(GetType(HTTPAction)), HTTPAction)
        Dim OldIndex As Integer = lbActions.Items.IndexOf(ActionToMove)

        'Don't replace an item with itself
        If (OldIndex = NewIndex) Then Return

        'We neeed to maintain the same checked state after the move
        Dim OldCheckState As CheckState = lbActions.GetItemCheckState(OldIndex)
        lbActions.Items.RemoveAt(OldIndex)
        lbActions.Items.Insert(NewIndex, ActionToMove)
        lbActions.SetItemCheckState(NewIndex, OldCheckState)

        ReorderAction(ActionToMove, NewIndex)
        lbActions.SelectedIndex = NewIndex
    End Sub

    Private Sub ReorderAction(ByRef ActionToMove As HTTPAction, ByRef NewIndex As Integer)
        'If replacing the first action, swap the start times 
        If (NewIndex = 1) Then
            Dim absoluteTime As Date = ActionToMove.absoluteTime
            Dim timePassed As Long = ActionToMove.timePassed
            Dim FirstAction As HTTPAction = EditorTestPlan.Item(0)
            ActionToMove.absoluteTime = FirstAction.absoluteTime
            ActionToMove.timePassed = FirstAction.timePassed
            FirstAction.absoluteTime = absoluteTime
            FirstAction.timePassed = timePassed
        End If

        EditorTestPlan.Remove(ActionToMove)
        EditorTestPlan.Insert(NewIndex - 1, ActionToMove)

        'We need to recalculate all of the absolute times!
        RecalculateAbsoluteTimes()
        SaveEditorTestPlan()
    End Sub

    Private Sub RecalculateAbsoluteTimes()
        If EditorTestPlan.Count > 1 Then
            For i As Integer = 1 To EditorTestPlan.Count - 1
                EditorTestPlan.Item(i).absoluteTime = EditorTestPlan.Item(i - 1).absoluteTime.AddMilliseconds(EditorTestPlan.Item(i).timePassed)
            Next
        End If
    End Sub

    Private Sub lbActions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbActions.SelectedIndexChanged
        lbActionSelection = DirectCast(lbActions.SelectedItem, HTTPAction)
        UpdateActionEditor(lbActionSelection, True)
    End Sub

    Private Sub frmMain_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin

    End Sub

    Private Sub frmMain_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd

    End Sub
End Class
