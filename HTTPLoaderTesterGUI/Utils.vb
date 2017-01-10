Imports System.Text

Module Utils
    Public Function GetFileContents(ByVal FullPath As String) As String
        Using objReader As New System.IO.StreamReader(FullPath)
            Return objReader.ReadToEnd()
        End Using
    End Function

    Public Sub SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByRef encoding As Encoding = Nothing)
        If (encoding Is Nothing) Then
            encoding = Encoding.UTF8
        End If

        Using objReader As New System.IO.StreamWriter(FullPath, False, encoding)
            objReader.Write(strData)
        End Using
    End Sub

    Public Sub AppendOutput(ByRef consoleProcess As Process, ByRef console As TextBox)
        Dim err As String = consoleProcess.StandardError.ReadLine
        Dim out As String = consoleProcess.StandardOutput.ReadLine
        While (out IsNot Nothing) Or (err IsNot Nothing)
            If out IsNot Nothing Then
                console.AppendText(out)
                console.AppendText(vbCrLf)
            End If
            If err IsNot Nothing Then
                console.AppendText(err)
                console.AppendText(vbCrLf)
            End If
            out = consoleProcess.StandardOutput.ReadLine
            err = consoleProcess.StandardError.ReadLine
            Application.DoEvents()
        End While
    End Sub
End Module
