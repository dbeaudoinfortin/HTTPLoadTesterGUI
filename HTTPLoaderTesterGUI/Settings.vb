Imports Newtonsoft

Public Class Settings
    Public Shared settingsPath As String = Application.LocalUserAppDataPath & "\settings.json"

    Public JavaHome As String
    Public LoadTesterJar As String

    Public RecorderMaxHeap As String
    Public RecorderStartJConsole As Boolean
    Public RecorderTestDirectory As String
    Public RecorderListenerHTTPPort As String
    Public RecorderListenerHTTPSPort As String
    Public RecorderForwardingHost As String
    Public RecorderForwardingHTTPPort As String
    Public RecorderForwardingHTTPsPort As String
    Public RecorderStartImmediately As Boolean
    Public RecorderFixedSubstitutions As String
    Public RecorderOverrideHostHeader As Boolean
    Public RecorderRewriteUrls As Boolean

    Public PlayerMaxHeap As String
    Public PlayerStartJConsole As Boolean
    Public PlayerTestPlanFile As String
    Public PlayerThreadCount As String
    Public PlayerStaggerTime As String
    Public PlayerMinRunTime As String
    Public PlayerCalcMinRunTime As Boolean
    Public PlayerActionDelay As String
    Public PlayerCalcActionDelay As Boolean
    Public PlayerHost As String
    Public PlayerHTTPPort As String
    Public PlayerHTTPSPort As String
    Public PlayerPauseOnStart As Boolean
    Public PlayerOverrideHTTPS As Boolean
    Public PlayerApplyFixedSubs As Boolean
    Public PlayerCookieWhitelist As String
    Public PlayerVariableSubstitutions As String
    Public PlayerShareConnections As Boolean

    Public EditorTestPlanFile As String

    Public Sub New()
        Dim javaHomeEnv As String = System.Environment.GetEnvironmentVariable("JAVA_HOME")

        If javaHomeEnv Is Nothing Then
            JavaHome = ""
        Else
            JavaHome = javaHomeEnv + "\bin"
        End If

        LoadTesterJar = Application.StartupPath & "\HTTPLoadTester.jar"

        RecorderTestDirectory = "C:\"

        RecorderListenerHTTPPort = "80"
        RecorderListenerHTTPSPort = "443"
        RecorderForwardingHost = "localhost"
        RecorderForwardingHTTPPort = "80"
        RecorderForwardingHTTPsPort = "443"
        PlayerMaxHeap = "1G"
        RecorderMaxHeap = "512m"

        RecorderStartImmediately = False
        RecorderStartJConsole = True
        RecorderOverrideHostHeader = False
        RecorderRewriteUrls = False

        PlayerStartJConsole = True

        PlayerTestPlanFile = "C:\"
        PlayerThreadCount = "1"
        PlayerStaggerTime = "10"
        PlayerMinRunTime = "120"
        PlayerCalcMinRunTime = True
        PlayerActionDelay = "10"
        PlayerCalcActionDelay = True
        PlayerHost = "localhost"
        PlayerHTTPPort = "80"
        PlayerHTTPSPort = "443"
        PlayerPauseOnStart = True
        PlayerOverrideHTTPS = True
        PlayerApplyFixedSubs = False
        PlayerShareConnections = False
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
        'Prevent saving the settings on startup
        If Initialization Then Return
        Utils.SaveTextToFile(Json.JsonConvert.SerializeObject(settingsObj), path)
    End Sub
End Class
