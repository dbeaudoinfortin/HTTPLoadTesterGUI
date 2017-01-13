Imports Newtonsoft

Public Class Settings
    Public Shared settingsPath As String = Application.LocalUserAppDataPath & "\settings.json"

    Public JavaHome As String
    Public LoadTesterJar As String

    Public RecorderTestDirectory As String
    Public RecorderListenerPort As String
    Public RecorderForwardingHost As String
    Public RecorderForwardingHTTPPort As String
    Public RecorderForwardingHTTPsPort As String
    Public RecorderMaxHeap As String
    Public RecorderStartImmediately As Boolean
    Public RecorderStartJConsole As Boolean
    Public RecorderPathSubstitutions As String
    Public RecorderQuerySubstitutions As String
    Public RecorderBodySubstitutions As String

    Public PlayerMaxHeap As String
    Public PlayerStartJConsole As Boolean

    Public Sub New()
        Dim javaHomeEnv As String = System.Environment.GetEnvironmentVariable("JAVA_HOME")

        If javaHomeEnv Is Nothing Then
            JavaHome = ""
        Else
            JavaHome = javaHomeEnv
        End If

        LoadTesterJar = Application.StartupPath & "\HTTPLoadTester.jar"

        RecorderTestDirectory = "C:\"

        RecorderListenerPort = "80"
        RecorderForwardingHost = "localhost"
        RecorderForwardingHTTPPort = "80"
        RecorderForwardingHTTPsPort = "443"
        PlayerMaxHeap = "1G"
        RecorderMaxHeap = "512m"

        RecorderStartImmediately = False
        RecorderStartJConsole = True
        PlayerStartJConsole = True
    End Sub

    Public Shared Function Load(ByRef path As String) As Settings
        'If the path doesn't exist, return an default settings
        If Not System.IO.File.Exists(Settings.settingsPath) Then
            Return New Settings()
        End If

        'Attempt to load settings
        Dim settingsString As String = Utils.GetFileContents(path)
        Return Json.JsonConvert.DeserializeObject(Of Settings)(settingsString)
    End Function
    Public Sub Save()
        Save(Me, settingsPath)
    End Sub

    Public Shared Sub Save(ByRef settingsObj As Settings, ByRef path As String)
        Utils.SaveTextToFile(Json.JsonConvert.SerializeObject(settingsObj), path)
    End Sub
End Class
