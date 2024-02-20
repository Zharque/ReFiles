<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnroll
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
        Me.DgvCourseOfferings = New System.Windows.Forms.DataGridView()
        Me.DgvStudEnroll = New System.Windows.Forms.DataGridView()
        Me.BtnWithdraw = New System.Windows.Forms.Button()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStudId = New System.Windows.Forms.TextBox()
        Me.TxtDate = New System.Windows.Forms.TextBox()
        CType(Me.DgvCourseOfferings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvStudEnroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvCourseOfferings
        '
        Me.DgvCourseOfferings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCourseOfferings.Location = New System.Drawing.Point(23, 69)
        Me.DgvCourseOfferings.Name = "DgvCourseOfferings"
        Me.DgvCourseOfferings.Size = New System.Drawing.Size(779, 150)
        Me.DgvCourseOfferings.TabIndex = 0
        '
        'DgvStudEnroll
        '
        Me.DgvStudEnroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStudEnroll.Location = New System.Drawing.Point(23, 237)
        Me.DgvStudEnroll.Name = "DgvStudEnroll"
        Me.DgvStudEnroll.Size = New System.Drawing.Size(575, 150)
        Me.DgvStudEnroll.TabIndex = 1
        '
        'BtnWithdraw
        '
        Me.BtnWithdraw.Location = New System.Drawing.Point(689, 277)
        Me.BtnWithdraw.Name = "BtnWithdraw"
        Me.BtnWithdraw.Size = New System.Drawing.Size(113, 32)
        Me.BtnWithdraw.TabIndex = 2
        Me.BtnWithdraw.Text = "WITHDRAW"
        Me.BtnWithdraw.UseVisualStyleBackColor = True
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Location = New System.Drawing.Point(689, 315)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(113, 32)
        Me.BtnSubmit.TabIndex = 3
        Me.BtnSubmit.Text = "SUBMIT"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(689, 353)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(113, 32)
        Me.BtnClose.TabIndex = 4
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 29)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Studnet ID: "
        '
        'TxtStudId
        '
        Me.TxtStudId.Enabled = False
        Me.TxtStudId.Location = New System.Drawing.Point(163, 18)
        Me.TxtStudId.Name = "TxtStudId"
        Me.TxtStudId.Size = New System.Drawing.Size(156, 35)
        Me.TxtStudId.TabIndex = 6
        '
        'TxtDate
        '
        Me.TxtDate.Enabled = False
        Me.TxtDate.Location = New System.Drawing.Point(607, 18)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(195, 35)
        Me.TxtDate.TabIndex = 7
        '
        'FrmEnroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 29.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(828, 399)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtDate)
        Me.Controls.Add(Me.TxtStudId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.BtnWithdraw)
        Me.Controls.Add(Me.DgvStudEnroll)
        Me.Controls.Add(Me.DgvCourseOfferings)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FrmEnroll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Student Enrollment"
        CType(Me.DgvCourseOfferings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvStudEnroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvCourseOfferings As System.Windows.Forms.DataGridView
    Friend WithEvents DgvStudEnroll As System.Windows.Forms.DataGridView
    Friend WithEvents BtnWithdraw As System.Windows.Forms.Button
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtStudId As System.Windows.Forms.TextBox
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
End Class
