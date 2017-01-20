﻿Imports System.Text
Imports Newtonsoft

Public Class frmMain

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
        ReloadFromSettings()
    End Sub

    Private Sub ReloadFromSettings()
        txtRecorderHost.Text = GlobalSettings.RecorderForwardingHost
        txtRecorderHttpPort.Text = GlobalSettings.RecorderForwardingHTTPPort
        txtRecorderHttpsPort.Text = GlobalSettings.RecorderForwardingHTTPsPort
        txtRecorderPort.Text = GlobalSettings.RecorderListenerPort
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
            Dim testPlanString As String = Utils.GetFileContents(GlobalSettings.EditorTestPlanFile)
            EditorTestPlan = Json.JsonConvert.DeserializeObject(Of List(Of HTTPAction))(testPlanString)
        Catch ex As Exception
            ClearTestPlanEditor()
            Application.DoEvents()
            MsgBox("Unable to load test plan '" + GlobalSettings.EditorTestPlanFile + "'." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
            Return
        End Try

    End Sub
    Private Sub UpdateTestPlanEditor(ByRef EditorTestPlan As List(Of HTTPAction))
        lbActions.Items.Clear()
        lbActions.Enabled = True
        lbActions.Items.Add("Test Plan Start...")
        lbActions.Items.AddRange(EditorTestPlan)

        tsTestPlanStatus.Text = "No Test Plan Loaded"

        txtActionDelay.Text = ""
        txtActionDelay.Enabled = False
        cbActionScheme.SelectedItem = Nothing
        cbActionScheme.Enabled = False
        cbActionMethod.SelectedItem = Nothing
        cbActionMethod.Enabled = False
        txtActionPath.Text = ""
        txtActionPath.Enabled = False
        txtActionQuery.Text = ""
        txtActionQuery.Enabled = False
        txtActionEncoding.Enabled = False
        txtActionEncoding.Text = ""
        txtActionHeaders.Text = ""
        txtActionHeaders.Enabled = False
        txtActionBody.Text = ""
        txtActionBody.Enabled = False

        cmdAddAction.Enabled = False
        cmdDeleteActions.Enabled = False
        cmdUpdateAction.Enabled = False

    End Sub

    Private Sub ClearTestPlanEditor()
        lbActions.Items.Clear()
        lbActions.Enabled = False
        txtActionDelay.Text = ""
        txtActionDelay.Enabled = False
        cbActionScheme.SelectedItem = Nothing
        cbActionScheme.Enabled = False
        cbActionMethod.SelectedItem = Nothing
        cbActionMethod.Enabled = False
        txtActionPath.Text = ""
        txtActionPath.Enabled = False
        txtActionQuery.Text = ""
        txtActionQuery.Enabled = False
        txtActionEncoding.Enabled = False
        txtActionEncoding.Text = ""
        txtActionHeaders.Text = ""
        txtActionHeaders.Enabled = False
        txtActionBody.Text = ""
        txtActionBody.Enabled = False
        cmdAddAction.Enabled = False
        cmdDeleteActions.Enabled = False
        cmdUpdateAction.Enabled = False
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

        javaCommand.Append(""" -port ")
        javaCommand.Append(GlobalSettings.RecorderListenerPort)
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

    Private Sub txtRecorderPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderPort.LostFocus
        If GlobalSettings.RecorderListenerPort <> txtRecorderPort.Text Then
            GlobalSettings.RecorderListenerPort = txtRecorderPort.Text
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

    Private Sub txtRecorderHttpPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderHttpPort.LostFocus
        If GlobalSettings.RecorderForwardingHTTPPort <> txtRecorderHttpPort.Text Then
            GlobalSettings.RecorderForwardingHTTPPort = txtRecorderHttpPort.Text
            GlobalSettings.Save()
        End If
    End Sub

    Private Sub txtRecorderHttpsPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderHttpsPort.LostFocus
        If GlobalSettings.RecorderForwardingHTTPsPort <> txtRecorderHttpsPort.Text Then
            GlobalSettings.RecorderForwardingHTTPsPort = txtRecorderHttpsPort.Text
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles cmdLoadTestPlan.Click
        If (txtEditorTestPlanFile.Text IsNot Nothing And Not txtEditorTestPlanFile.Text = "") Then
            OpenFileDialog.FileName = txtEditorTestPlanFile.Text
        End If

        If (OpenFileDialog.ShowDialog() = DialogResult.OK) Then
            txtEditorTestPlanFile.Text = OpenFileDialog.FileName
        End If

        If GlobalSettings.EditorTestPlanFile <> txtEditorTestPlanFile.Text Then
            GlobalSettings.EditorTestPlanFile = txtEditorTestPlanFile.Text
            GlobalSettings.Save()
        End If

        LoadTestPlan()
    End Sub
End Class
