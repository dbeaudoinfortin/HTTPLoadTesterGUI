Imports Newtonsoft.Json

Public Class HTTPAction
    Public absoluteTime As Date
    Public timePassed As Long
    Public path As String
    Public method As String
    Public characterEncoding As String
    Public content As String
    Public contentLength As Integer
    Public contentType As String
    Public scheme As String
    Public queryString As String
    Public headers As Dictionary(Of String, String)

    <JsonIgnore>
    Public isStartDummy As Boolean

    Public Sub New()
        Me.New(False)
    End Sub

    Public Sub New(ByRef isStartDummy As Boolean)
        Me.isStartDummy = isStartDummy
        absoluteTime = Now
        timePassed = 0
        path = ""
        method = "POST"
        contentLength = 0
        contentType = "text/html"
        scheme = "HTTP"
        headers = New Dictionary(Of String, String)
    End Sub

    Public Overrides Function ToString() As String
        If (isStartDummy) Then
            Return "Test Plan Start..."
        End If

        Dim sb As New System.Text.StringBuilder()
        sb.Append(method)
        sb.Append(" ")
        sb.Append(path)
        If (queryString IsNot Nothing And queryString <> "") Then
            sb.Append(queryString)
        End If
        Return sb.ToString()
    End Function
End Class
