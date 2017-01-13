Imports System.Text
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
        If GlobalSettings.RecorderStartJConsole Then LaunchJConsole(BuildJConsoleCommand())
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
        txtTestPlanDir.Text = GlobalSettings.RecorderTestDirectory
        chRecorderStart.Checked = GlobalSettings.RecorderStartImmediately
        chJConsoleStart.Checked = GlobalSettings.RecorderStartJConsole
        txtRecorderPathSub.Text = GlobalSettings.RecorderPathSubstitutions
        txtRecorderQuerySub.Text = GlobalSettings.RecorderQuerySubstitutions
        txtRecorderBodySub.Text = GlobalSettings.RecorderBodySubstitutions
    End Sub

    Private Sub cmdBrowseTestPlanDirectory_Click(sender As Object, e As EventArgs) Handles cmdBrowseTestPlanDirectory.Click
        If (txtTestPlanDir.Text IsNot Nothing And Not txtTestPlanDir.Text = "") Then
            DirDialog.SelectedPath = txtTestPlanDir.Text
        End If

        If (DirDialog.ShowDialog() = DialogResult.OK) Then
            txtTestPlanDir.Text = DirDialog.SelectedPath
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
        javaCommand.Append(" -dir ")
        javaCommand.Append(GlobalSettings.RecorderTestDirectory)
        javaCommand.Append(" -port ")
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

    Private Function BuildJConsoleCommand() As String
        Dim javaCommand As New StringBuilder()
        With javaCommand
            .Append("localhost:9011")
        End With
        Return javaCommand.ToString
    End Function

    Private Sub txtRecorderPort_LostFocus(sender As Object, e As EventArgs) Handles txtRecorderPort.LostFocus
        If GlobalSettings.RecorderListenerPort <> txtRecorderPort.Text Then
            GlobalSettings.RecorderListenerPort = txtRecorderPort.Text
            GlobalSettings.Save()
        End If

    End Sub

    Private Sub txtTestPlanDir_LostFocus(sender As Object, e As EventArgs) Handles txtTestPlanDir.LostFocus
        If GlobalSettings.RecorderTestDirectory <> txtTestPlanDir.Text Then
            GlobalSettings.RecorderTestDirectory = txtTestPlanDir.Text
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

    Private Sub chRecorderStart_CheckedChanged(sender As Object, e As EventArgs) Handles chRecorderStart.CheckedChanged
        GlobalSettings.RecorderStartImmediately = chRecorderStart.Checked
        GlobalSettings.Save()
    End Sub

    Private Sub chJConsoleStart_CheckedChanged(sender As Object, e As EventArgs) Handles chJConsoleStart.CheckedChanged
        GlobalSettings.RecorderStartJConsole = chJConsoleStart.Checked
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
End Class
