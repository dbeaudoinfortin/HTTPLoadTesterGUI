<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPaths
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTesterJar = New System.Windows.Forms.TextBox()
        Me.cmdBrowseJavaHome = New System.Windows.Forms.Button()
        Me.txtJavaHome = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdBrowseTesterJar = New System.Windows.Forms.Button()
        Me.DirDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.FileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRecorderMaxHeap = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPlayerMaxHeap = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "HTTPLoadTester Jar"
        '
        'txtTesterJar
        '
        Me.txtTesterJar.Location = New System.Drawing.Point(116, 38)
        Me.txtTesterJar.Name = "txtTesterJar"
        Me.txtTesterJar.Size = New System.Drawing.Size(561, 20)
        Me.txtTesterJar.TabIndex = 8
        '
        'cmdBrowseJavaHome
        '
        Me.cmdBrowseJavaHome.Location = New System.Drawing.Point(683, 10)
        Me.cmdBrowseJavaHome.Name = "cmdBrowseJavaHome"
        Me.cmdBrowseJavaHome.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowseJavaHome.TabIndex = 7
        Me.cmdBrowseJavaHome.Text = "Browse..."
        Me.cmdBrowseJavaHome.UseVisualStyleBackColor = True
        '
        'txtJavaHome
        '
        Me.txtJavaHome.Location = New System.Drawing.Point(116, 12)
        Me.txtJavaHome.Name = "txtJavaHome"
        Me.txtJavaHome.Size = New System.Drawing.Size(561, 20)
        Me.txtJavaHome.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Java Directory"
        '
        'cmdBrowseTesterJar
        '
        Me.cmdBrowseTesterJar.Location = New System.Drawing.Point(683, 36)
        Me.cmdBrowseTesterJar.Name = "cmdBrowseTesterJar"
        Me.cmdBrowseTesterJar.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowseTesterJar.TabIndex = 10
        Me.cmdBrowseTesterJar.Text = "Browse..."
        Me.cmdBrowseTesterJar.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(6, 93)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(374, 32)
        Me.cmdOk.TabIndex = 11
        Me.cmdOk.Text = "OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(384, 93)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(374, 32)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'FileDialog
        '
        Me.FileDialog.Filter = "jar|*.jar"
        Me.FileDialog.Title = "Select File"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Recorder Max Heap"
        '
        'txtRecorderMaxHeap
        '
        Me.txtRecorderMaxHeap.Location = New System.Drawing.Point(116, 64)
        Me.txtRecorderMaxHeap.Name = "txtRecorderMaxHeap"
        Me.txtRecorderMaxHeap.Size = New System.Drawing.Size(264, 20)
        Me.txtRecorderMaxHeap.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(386, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Player Max Heap"
        '
        'txtPlayerMaxHeap
        '
        Me.txtPlayerMaxHeap.Location = New System.Drawing.Point(480, 64)
        Me.txtPlayerMaxHeap.Name = "txtPlayerMaxHeap"
        Me.txtPlayerMaxHeap.Size = New System.Drawing.Size(278, 20)
        Me.txtPlayerMaxHeap.TabIndex = 16
        '
        'frmPaths
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 137)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPlayerMaxHeap)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtRecorderMaxHeap)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdBrowseTesterJar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTesterJar)
        Me.Controls.Add(Me.cmdBrowseJavaHome)
        Me.Controls.Add(Me.txtJavaHome)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaths"
        Me.Text = "Configure Paths"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents txtTesterJar As TextBox
    Friend WithEvents cmdBrowseJavaHome As Button
    Friend WithEvents txtJavaHome As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdBrowseTesterJar As Button
    Friend WithEvents DirDialog As FolderBrowserDialog
    Friend WithEvents cmdOk As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents FileDialog As OpenFileDialog
    Friend WithEvents Label3 As Label
    Friend WithEvents txtRecorderMaxHeap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPlayerMaxHeap As TextBox
End Class
