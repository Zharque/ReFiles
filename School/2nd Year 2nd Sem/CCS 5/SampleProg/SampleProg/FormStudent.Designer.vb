<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.TxtStudId = New System.Windows.Forms.TextBox()
        Me.TxtStudLName = New System.Windows.Forms.TextBox()
        Me.TxtStudFName = New System.Windows.Forms.TextBox()
        Me.TxtStudDegree = New System.Windows.Forms.TextBox()
        Me.DgvStud = New System.Windows.Forms.DataGridView()
        Me.TxtSearch = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DgvStud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(13, 157)
        Me.BtnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(100, 38)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "SAVE"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Enabled = False
        Me.BtnUpdate.Location = New System.Drawing.Point(121, 157)
        Me.BtnUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(188, 38)
        Me.BtnUpdate.TabIndex = 1
        Me.BtnUpdate.Text = "SAVE CHANGES"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.Location = New System.Drawing.Point(317, 157)
        Me.BtnDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(104, 38)
        Me.BtnDelete.TabIndex = 2
        Me.BtnDelete.Text = "DELETE"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Location = New System.Drawing.Point(429, 157)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(99, 38)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "CLOSE"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TxtStudId
        '
        Me.TxtStudId.Location = New System.Drawing.Point(141, 12)
        Me.TxtStudId.Name = "TxtStudId"
        Me.TxtStudId.ReadOnly = True
        Me.TxtStudId.Size = New System.Drawing.Size(387, 30)
        Me.TxtStudId.TabIndex = 8
        '
        'TxtStudLName
        '
        Me.TxtStudLName.Location = New System.Drawing.Point(141, 48)
        Me.TxtStudLName.Name = "TxtStudLName"
        Me.TxtStudLName.Size = New System.Drawing.Size(387, 30)
        Me.TxtStudLName.TabIndex = 9
        '
        'TxtStudFName
        '
        Me.TxtStudFName.Location = New System.Drawing.Point(141, 84)
        Me.TxtStudFName.Name = "TxtStudFName"
        Me.TxtStudFName.Size = New System.Drawing.Size(387, 30)
        Me.TxtStudFName.TabIndex = 10
        '
        'TxtStudDegree
        '
        Me.TxtStudDegree.Location = New System.Drawing.Point(141, 120)
        Me.TxtStudDegree.Name = "TxtStudDegree"
        Me.TxtStudDegree.Size = New System.Drawing.Size(387, 30)
        Me.TxtStudDegree.TabIndex = 11
        '
        'DgvStud
        '
        Me.DgvStud.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvStud.Location = New System.Drawing.Point(535, 48)
        Me.DgvStud.Name = "DgvStud"
        Me.DgvStud.RowTemplate.Height = 28
        Me.DgvStud.Size = New System.Drawing.Size(515, 147)
        Me.DgvStud.TabIndex = 12
        '
        'TxtSearch
        '
        Me.TxtSearch.Location = New System.Drawing.Point(642, 12)
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(408, 30)
        Me.TxtSearch.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 25)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Student ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 25)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Last Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 25)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "First Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(53, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 25)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Degree:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(534, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 25)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Last Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FormMainStud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1066, 206)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSearch)
        Me.Controls.Add(Me.DgvStud)
        Me.Controls.Add(Me.TxtStudDegree)
        Me.Controls.Add(Me.TxtStudFName)
        Me.Controls.Add(Me.TxtStudLName)
        Me.Controls.Add(Me.TxtStudId)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.BtnSave)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormMainStud"
        Me.Text = "STUDENT"
        CType(Me.DgvStud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TxtStudId As System.Windows.Forms.TextBox
    Friend WithEvents TxtStudLName As System.Windows.Forms.TextBox
    Friend WithEvents TxtStudFName As System.Windows.Forms.TextBox
    Friend WithEvents TxtStudDegree As System.Windows.Forms.TextBox
    Friend WithEvents DgvStud As System.Windows.Forms.DataGridView
    Friend WithEvents TxtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
