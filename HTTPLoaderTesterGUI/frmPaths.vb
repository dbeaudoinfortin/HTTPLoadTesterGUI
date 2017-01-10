Public Class frmPaths

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Close()
    End Sub

    Private Sub frmPaths_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtJavaHome.Text = GlobalSettings.JavaHome
        txtTesterJar.Text = GlobalSettings.LoadTesterJar
        txtRecorderMaxHeap.Text = GlobalSettings.RecorderMaxHeap
        txtPlayerMaxHeap.Text = GlobalSettings.PlayerMaxHeap
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If Not IO.Directory.Exists(txtJavaHome.Text) Then
            MsgBox("Invalid Java directory path.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        ElseIf Not IO.File.Exists(txtJavaHome.Text & "\java.exe") Then
            MsgBox("Cannot locate java.exe in Java directory path '" + txtJavaHome.Text + "'.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        If Not IO.File.Exists(txtTesterJar.Text) Then
            MsgBox("Invalid Jar file path.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If

        GlobalSettings.JavaHome = txtJavaHome.Text
        GlobalSettings.LoadTesterJar = txtTesterJar.Text
        GlobalSettings.RecorderMaxHeap = txtRecorderMaxHeap.Text
        GlobalSettings.PlayerMaxHeap = txtPlayerMaxHeap.Text
        GlobalSettings.Save()
        Close()
    End Sub

    Private Sub cmdBrowseJavaHome_Click(sender As Object, e As EventArgs) Handles cmdBrowseJavaHome.Click
        If (txtJavaHome.Text IsNot Nothing And Not txtJavaHome.Text = "") Then
            DirDialog.SelectedPath = txtJavaHome.Text
        End If

        If (DirDialog.ShowDialog() = DialogResult.OK) Then
            txtJavaHome.Text = DirDialog.SelectedPath
        End If
    End Sub

    Private Sub cmdBrowseTesterJar_Click(sender As Object, e As EventArgs) Handles cmdBrowseTesterJar.Click

        If (txtTesterJar.Text IsNot Nothing And Not txtTesterJar.Text = "") Then
            FileDialog.FileName = txtTesterJar.Text
        End If

        If (FileDialog.ShowDialog() = DialogResult.OK) Then
            txtTesterJar.Text = FileDialog.FileName
        End If
    End Sub
End Class