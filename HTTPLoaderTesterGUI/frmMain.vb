Public Class frmMain
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs) Handles tsRecorderStatus.Click

    End Sub

    Private Sub cmdRecorderLaunch_Click(sender As Object, e As EventArgs) Handles cmdRecorderLaunch.Click
        txtRecorderConsole.Clear()

        Using consoleProcess As New Process()
            With consoleProcess.StartInfo
                .WorkingDirectory = "C:\Program Files\Java\jdk1.8.0_102\bin"
                .FileName = "java.exe"
                .UseShellExecute = False
                .CreateNoWindow = True
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .Arguments = "-version"
            End With

            consoleProcess.Start()

            Dim err As String = consoleProcess.StandardError.ReadLine
            Dim out As String = consoleProcess.StandardOutput.ReadLine

            While (out IsNot Nothing) Or (err IsNot Nothing)

                If out IsNot Nothing Then
                    txtRecorderConsole.AppendText(out)
                    txtRecorderConsole.AppendText(vbCrLf)
                End If
                If err IsNot Nothing Then
                    txtRecorderConsole.AppendText(err)
                    txtRecorderConsole.AppendText(vbCrLf)
                End If
                out = consoleProcess.StandardOutput.ReadLine
                err = consoleProcess.StandardError.ReadLine
            End While

            consoleProcess.WaitForExit()
        End Using
    End Sub

    Private Sub ConfigurePathsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfigurePathsToolStripMenuItem.Click

    End Sub
End Class
