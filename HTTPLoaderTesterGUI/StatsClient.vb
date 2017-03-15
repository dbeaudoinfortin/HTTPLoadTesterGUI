Imports System.Net
Imports System.Net.Http
Imports System.Windows.Forms.DataVisualization.Charting
Imports Newtonsoft.Json

Class StatsClient
    Public Shared RestClient As New HttpClient()
    Public Shared ActionStatsLastUpdate As New Date(1900, 1, 1)
    Public Shared TestPlanStatsLastUpdate As New Date(1900, 1, 1)

    Shared Sub New()
        RestClient.BaseAddress = New Uri("http://localhost:5009/player/")
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

    Public Shared Function GetActionStats() As TimeStats
        Dim response As HttpResponseMessage = RestClient.GetAsync("aggregateActionStats").Result
        If response.StatusCode <> HttpStatusCode.OK Then
            Throw New Exception
        End If
        Dim json As String = response.Content.ReadAsStringAsync().Result
        Return JsonConvert.DeserializeObject(Of TimeStats)(json)
    End Function

    Public Shared Function GetTestPlanStats() As TimeStats
        Dim response As HttpResponseMessage = RestClient.GetAsync("testPlanStats").Result
        If response.StatusCode <> HttpStatusCode.OK Then
            Throw New Exception
        End If
        Dim json As String = response.Content.ReadAsStringAsync().Result
        Return JsonConvert.DeserializeObject(Of TimeStats)(json)
    End Function
End Class
