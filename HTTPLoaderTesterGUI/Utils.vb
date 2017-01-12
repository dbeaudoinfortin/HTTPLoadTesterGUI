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

End Module
