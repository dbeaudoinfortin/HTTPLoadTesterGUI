﻿Imports Newtonsoft.Json

Public Class HTTPAction

    <JsonIgnore>
    Public id As Integer

    Public absoluteTime As Date
    Public timePassed As Long
    Public path As String
    Public method As String
    Public characterEncoding As String
    Public content As String
    Public contentType As String
    Public scheme As String
    Public queryString As String
    Public hasSubstitutions As Boolean
    Public headers As Dictionary(Of String, String)

    <JsonIgnore>
    Public isStartDummy As Boolean

    Public Sub New()
        Me.New(False, -1)
    End Sub

    Public Sub New(ByRef isStartDummy As Boolean, ByVal id As Integer)
        Me.isStartDummy = isStartDummy
        Me.id = id
        absoluteTime = Now
        timePassed = 0
        path = ""
        method = "POST"
        hasSubstitutions = False
        contentType = "text/html"
        scheme = "HTTP"
        headers = New Dictionary(Of String, String)

    End Sub

    Public Overrides Function ToString() As String
        If (isStartDummy) Then
            Return "Test Plan Start..."
        End If

        Dim sb As New System.Text.StringBuilder()
        If id > 0 Then
            sb.Append(id)
            sb.Append(": ")
        End If

        sb.Append(method)
        sb.Append(" ")
        sb.Append(path)
        If (queryString IsNot Nothing And queryString <> "") Then
            sb.Append("?")
            sb.Append(queryString)
        End If
        Return sb.ToString()
    End Function
End Class
