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
    Private headers As String


    Private transient isStartDummy As Boolean

    Public Sub New()
        isStartDummy = False
        absoluteTime = Now
        timePassed = 0
        path = ""
        method = "POST"
        characterEncoding = "utf-8"
        content = ""
        contentLength = 0
        contentType = "text/html"
        scheme = "HTTP"
        queryString = ""
        headers = "{}"
    End Sub

    Public Overrides Function ToString() As String
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
