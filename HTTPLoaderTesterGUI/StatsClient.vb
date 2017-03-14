Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json

Class StatsClient
    Public Shared RestClient As New HttpClient()

    Shared Sub New()
        RestClient.BaseAddress = New Uri("http://localhost:5009/admin/")
    End Sub

    Public Shared Function IsRunning() As Boolean
        Try
            Dim response As HttpResponseMessage = RestClient.GetAsync("running").Result
            If response.StatusCode <> HttpStatusCode.OK Then Return False

            Dim json As String = response.Content.ReadAsStringAsync().Result
            Return JsonConvert.DeserializeObject(Of Boolean)(json)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function GetPlayerThreadCount() As Integer
        Dim response As HttpResponseMessage = RestClient.GetAsync("runningThreadCount").Result
        If response.StatusCode <> HttpStatusCode.OK Then
            Throw New Exception
        End If
        Dim json As String = response.Content.ReadAsStringAsync().Result
        Return JsonConvert.DeserializeObject(Of Integer)(json)
    End Function
End Class
