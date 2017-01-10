Imports System.Text

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
        LaunchJConsole(BuildJConsoleCommand())
    End Sub
    Private Sub LaunchJConsole(ByRef CommandString As String)
        Dim JConsoleProcess As New Process()
        With JConsoleProcess.StartInfo
            .WorkingDirectory = GlobalSettings.JavaHome
            .FileName = "jconsole.exe"
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardOutput = False
            .RedirectStandardError = False
            .WindowStyle = ProcessWindowStyle.Maximized
            .Arguments = CommandString
        End With

        txtRecorderConsole.AppendText("Launching JConsole process..." & vbCrLf & vbCrLf)
        Application.DoEvents()
        JConsoleProcess.Start()
    End Sub

    Private Sub LaunchRecorderThread(ByVal JavaCommandString As String)

        Try
            Dim RecorderProcess As New Process()
            With RecorderProcess.StartInfo
                .WorkingDirectory = GlobalSettings.JavaHome
                .FileName = "CMD"
                .UseShellExecute = False
                .CreateNoWindow = False
                .RedirectStandardOutput = False
                .RedirectStandardError = False
                .WindowStyle = ProcessWindowStyle.Maximized
                .Arguments = JavaCommandString
            End With

            txtRecorderConsole.Text = "Using command: CMD " & JavaCommandString & vbCrLf & vbCrLf & "Launching Recorder Proxy process..." & vbCrLf & vbCrLf
            tsRecorderStatus.Text = "Recorder Started"
            cmdRecorderLaunch.Enabled = False
            Application.DoEvents()

            'Launch a new thread to monitor the process
            Task.Run(Sub()
                         RecorderProcess.Start()
                         RecorderProcess.WaitForExit()

                         Me.Invoke(Sub()
                                       txtRecorderConsole.AppendText("Recorder Proxy process terminated with code " & RecorderProcess.ExitCode & vbCrLf & vbCrLf)
                                       tsRecorderStatus.Text = "Recorder Stopped"
                                       cmdRecorderLaunch.Enabled = True
                                   End Sub)
                         RecorderProcess.Close()
                     End Sub)

        Catch ex As Exception
            MsgBox("Unable to start Recorder Proxy process." & vbCrLf & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub ConfigurePathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurePathsToolStripMenuItem.Click
        frmPaths.ShowDialog()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalSettings = Settings.Load(Settings.settingsPath)
        txtRecorderHost.Text = GlobalSettings.RecorderForwardingHost
        txtRecorderHttpPort.Text = GlobalSettings.RecorderForwardingHTTPPort
        txtRecorderHttpsPort.Text = GlobalSettings.RecorderForwardingHTTPsPort
        txtRecorderPort.Text = GlobalSettings.RecorderListenerPort
        txtTestPlanDir.Text = GlobalSettings.RecorderTestDirectory
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
        With javaCommand
            .Append("/K java.exe ")
            .Append("-Xmx")
            .Append(GlobalSettings.RecorderMaxHeap)
            .Append(" -Dcom.sun.management.jmxremote")
            .Append(" -Dcom.sun.management.jmxremote.port=9011")
            .Append(" -Dcom.sun.management.jmxremote.local.only=false")
            .Append(" -Dcom.sun.management.jmxremote.authenticate=false")
            .Append(" -Dcom.sun.management.jmxremote.ssl=false")
            .Append(" -cp """)
            .Append(GlobalSettings.LoadTesterJar)
            .Append(""" ")
            .Append(RECORDER_PROXY_CLASS)
            .Append(" -dir ")
            .Append(txtTestPlanDir.Text)
            .Append(" -port ")
            .Append(txtRecorderPort.Text)
            .Append(" -fhost ")
            .Append(txtRecorderHost.Text)
            .Append(" -fhttpport ")
            .Append(txtRecorderHttpPort.Text)
            .Append(" -fhttpsport ")
            .Append(txtRecorderHttpsPort.Text)

        End With
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
End Class
