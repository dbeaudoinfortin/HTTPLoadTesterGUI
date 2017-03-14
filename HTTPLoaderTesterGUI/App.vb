Imports System.Net.Http
Imports System.Text
Imports Newtonsoft

Module App
    Public Const RECORDER_PROXY_CLASS = "com.dbf.loadtester.recorder.proxy.RecorderProxy"
    Public Const PLAYER_CLASS = "com.dbf.loadtester.player.LoadTestPlayer"
    Public GlobalSettings As Settings = Settings.Load(Settings.settingsPath)
    Public EditorTestPlan As List(Of HTTPAction)


    Public Sub SaveEditorTestPlan()
        Dim testPlan As New StringBuilder()
        For Each action As HTTPAction In EditorTestPlan
            testPlan.AppendLine(Json.JsonConvert.SerializeObject(action))
        Next
        Utils.SaveTextToFile(testPlan.ToString, GlobalSettings.EditorTestPlanFile)
    End Sub

    Public Sub LoadTestPlanFromFile()
        Dim NewTestPlan As List(Of HTTPAction) = New List(Of HTTPAction)

        Using objReader As New System.IO.StreamReader(GlobalSettings.EditorTestPlanFile)

            Dim actionString As String
            Do While objReader.Peek() >= 0
                actionString = objReader.ReadLine
                NewTestPlan.Add(Json.JsonConvert.DeserializeObject(Of HTTPAction)(actionString))
            Loop
        End Using

        'Only set the test plan if no exceptions occured 
        EditorTestPlan = NewTestPlan
    End Sub

End Module
