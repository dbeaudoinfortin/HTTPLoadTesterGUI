Imports Newtonsoft

Module App
    Public Const RECORDER_PROXY_CLASS = "com.dbf.loadtester.recorder.proxy.RecorderProxy"
    Public Const PLAYER_CLASS = "com.dbf.loadtester.player.LoadTestPlayer"

    Public GlobalSettings As Settings = Settings.Load(Settings.settingsPath)

    Public EditorTestPlan As List(Of HTTPAction)

    Public Sub SaveEditorTestPlan()
        Utils.SaveTextToFile(Json.JsonConvert.SerializeObject(EditorTestPlan), GlobalSettings.EditorTestPlanFile)
    End Sub
End Module
