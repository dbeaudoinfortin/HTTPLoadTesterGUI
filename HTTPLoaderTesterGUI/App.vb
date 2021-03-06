﻿Imports System.Net.Http
Imports System.Text
Imports Newtonsoft

Module App
    ''Track the start-up of the application to disable saving
    Public Initialization As Boolean = True

    Public Const RECORDER_PROXY_CLASS = "com.dbf.loadtester.recorder.proxy.RecorderProxy"
    Public Const PLAYER_CLASS = "com.dbf.loadtester.player.LoadTestPlayer"
    Public GlobalSettings As Settings = New Settings()
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

        Dim lineNumber As Integer = 0
        Dim actionString As String = ""
        Try
            Using objReader As New System.IO.StreamReader(GlobalSettings.EditorTestPlanFile)
                Do While objReader.Peek() >= 0
                    lineNumber += 1
                    actionString = objReader.ReadLine
                    Dim action As HTTPAction = Json.JsonConvert.DeserializeObject(Of HTTPAction)(actionString)
                    NewTestPlan.Add(action)
                    action.id = lineNumber
                Loop
            End Using
        Catch ex As Exception
            Throw New Exception("Failed to read line number " & lineNumber & ": '" & actionString & "'.", ex)
        End Try

        'Only set the test plan if no exceptions occured 
        EditorTestPlan = NewTestPlan
    End Sub

End Module
