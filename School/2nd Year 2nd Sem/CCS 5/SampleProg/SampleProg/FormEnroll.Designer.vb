<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEnroll
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
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.DgvCourseOfferings = New System.Windows.Forms.DataGridView()
        Me.DgvStudEnroll = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtStudId = New System.Windows.Forms.TextBox()
        Me.TxtDate = New System.Windows.Forms.TextBox()
        Me.BtnWithdraw = New System.Windows.Forms.Button()
        Me.BtnSubmit = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        CType(Me.DgvCourseOfferings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvStudEnroll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvCourseOfferings
        '
        Me.DgvCourseOfferings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCourseOfferings.Location = New System.Drawing.Point(16, 65)
        Me.DgvCourseOfferings.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvCourseOfferings.Name = "DgvCourseOfferings"
        Me.DgvCourseOfferings.RowTemplate.Height = 28
        Me.DgvCourseOfferings.Size = New System.Drawing.Size(809, 221)
        Me.DgvCourseOfferings.TabIndex = 0
        '
        'DgvStudEnroll
        '
        Me.DgvStudEnroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStudEnroll.Location = New System.Drawing.Point(16, 312)
        Me.DgvStudEnroll.Margin = New System.Windows.Forms.Padding(4)
        Me.DgvStudEnroll.Name = "DgvStudEnroll"
        Me.DgvStudEnroll.RowTemplate.Height = 28
        Me.DgvStudEnroll.Size = New System.Drawing.Size(578, 221)
        Me.DgvStudEnroll.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 25)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Student ID:"
        '
        'TxtStudId
        '
        Me.TxtStudId.Location = New System.Drawing.Point(130, 26)
        Me.TxtStudId.Name = "TxtStudId"
        Me.TxtStudId.Size = New System.Drawing.Size(153, 30)
        Me.TxtStudId.TabIndex = 3
        '
        'TxtDate
        '
        Me.TxtDate.Location = New System.Drawing.Point(655, 26)
        Me.TxtDate.Name = "TxtDate"
        Me.TxtDate.Size = New System.Drawing.Size(170, 30)
        Me.TxtDate.TabIndex = 4
        '
        'BtnWithdraw
        '
        Me.BtnWithdraw.Location = New System.Drawing.Point(612, 328)
        Me.BtnWithdraw.Name = "BtnWithdraw"
        Me.BtnWithdraw.Size = New System.Drawing.Size(213, 65)
        Me.BtnWithdraw.TabIndex = 5
        Me.BtnWithdraw.Text = "WITHDRAW"
        Me.BtnWithdraw.UseVisualStyleBackColor = True
        '
        'BtnSubmit
        '
        Me.BtnSubmit.Location = New System.Drawing.Point(612, 399)
        Me.BtnSubmit.Name = "BtnSubmit"
        Me.BtnSubmit.Size = New System.Drawing.Size(213, 65)
        Me.BtnSubmit.TabIndex = 6
        Me.BtnSubmit.Text = "SUBMIT"
        Me.BtnSubmit.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(612, 470)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(213, 65)
        Me.BtnClose.TabIndex = 7
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FormEnroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(851, 558)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSubmit)
        Me.Controls.Add(Me.BtnWithdraw)
        Me.Controls.Add(Me.TxtDate)
        Me.Controls.Add(Me.TxtStudId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvStudEnroll)
        Me.Controls.Add(Me.DgvCourseOfferings)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormEnroll"
        Me.Text = "Student Enrollment"
        CType(Me.DgvCourseOfferings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvStudEnroll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents DgvCourseOfferings As System.Windows.Forms.DataGridView
    Friend WithEvents DgvStudEnroll As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtStudId As System.Windows.Forms.TextBox
    Friend WithEvents TxtDate As System.Windows.Forms.TextBox
    Friend WithEvents BtnWithdraw As System.Windows.Forms.Button
    Friend WithEvents BtnSubmit As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
