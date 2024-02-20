Imports IBM.Data.DB2
Public Class FormMainStud
    Private DbConnStud As Common.DbConnection

    'functions

    Private Sub PopulateGrid()
        Dim row As String()
        Dim StrStud As String
        Dim CmdStud As DB2Command
        Dim RdrStud As DB2DataReader

        Try
            StrStud = "Select * from sampleprog.student"
            CmdStud = New DB2Command(StrStud, DbConnStud)
            RdrStud = CmdStud.ExecuteReader
            Me.DgvStud.Rows.Clear()
            While RdrStud.Read
                row = New String() {RdrStud.GetString(0), RdrStud.GetString(1), _
                                    RdrStud.GetString(2), RdrStud.GetString(3)}
                Me.DgvStud.Rows.Add(row)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ClearTextBoxes()
        Me.TxtStudId.Clear()
        Me.TxtStudLName.Clear()
        Me.TxtStudFName.Clear()
        Me.TxtStudDegree.Clear()
        Me.TxtStudId.Focus()
    End Sub

    Private Sub GetLastStudId()
        Dim str As String
        Dim Cmd As DB2Command
        Dim rdr As DB2DataReader
        Dim VSTudId As Integer
        Try
            str = "select studId from sampleprog.student order by studId desc"
            Cmd = New DB2Command(str, DbConnStud)
            rdr = Cmd.ExecuteReader
            If rdr.HasRows Then
                rdr.Read()
                VSTudId = rdr.GetString(0)
                VSTudId = VSTudId + 1
            Else
                VSTudId = 1000
            End If
            Me.TxtStudId.Text = VSTudId
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    'tools

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DbConnStud = New DB2Connection("server=localhost;database=ccs5b;" + _
                                           "uid=db2admin;password=db2admin;")
            DbConnStud.Open()
            Me.DgvStud.ColumnCount = 4
            Me.DgvStud.Columns(0).Name = "Student ID"
            Me.DgvStud.Columns(1).Name = "Last Name"
            Me.DgvStud.Columns(2).Name = "First Name"
            Me.DgvStud.Columns(3).Name = "Degree"
            Call PopulateGrid()
            Call ClearTextBoxes()
            Call GetLastStudId()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim StrInsert As String
        Dim CmdInsert As DB2Command
        Dim VStudId As String
        Dim VLName As String
        Dim VFName As String
        Dim VDegree As String
        Try
            VStudId = Me.TxtStudId.Text
            VLName = Me.TxtStudLName.Text
            VFName = Me.TxtStudFName.Text
            VDegree = Me.TxtStudDegree.Text
            StrInsert = "insert into sampleprog.student values('" & VStudId & "', " _
                     & " '" & VLName & "','" & VFName & "','" & VDegree & "')"
            CmdInsert = New DB2Command(StrInsert, DbConnStud)
            CmdInsert.ExecuteNonQuery()
            Call PopulateGrid()
            Call ClearTextBoxes()
            Call GetLastStudId()
            MsgBox("New student record had been added...")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DGVStud_MouseUp(sender As Object, e As MouseEventArgs) Handles DgvStud.MouseUp
        Try
            With Me.DgvStud
                Me.TxtStudId.Text = .CurrentRow.Cells(0).Value
                Me.TxtStudLName.Text = .CurrentRow.Cells(1).Value
                Me.TxtStudFName.Text = .CurrentRow.Cells(2).Value
                Me.TxtStudDegree.Text = .CurrentRow.Cells(3).Value
            End With
            Me.BtnUpdate.Enabled = True
            Me.BtnDelete.Enabled = True
            Me.BtnSave.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BtnSaveChanges_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim StrUpdate As String
        Dim CmdUpdate As DB2Command

        Try
            StrUpdate = "update sampleprog.student set studLName = '" & Me.TxtStudLName.Text & "', " _
                & "StudFName = '" & Me.TxtStudFName.Text & "', " _
                & "StudDegree = '" & Me.TxtStudDegree.Text & "' " _
                & "where Studid = '" & Me.TxtStudId.Text & "'"
            CmdUpdate = New DB2Command(StrUpdate, DbConnStud)
            CmdUpdate.ExecuteNonQuery()

            Call PopulateGrid()
            Call ClearTextBoxes()
            Call GetLastStudId()

            Me.BtnSave.Enabled = True
            Me.BtnDelete.Enabled = False
            Me.BtnUpdate.Enabled = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim StrDelete As String
        Dim CmdDelete As DB2Command
        Try
            StrDelete = "delete from sampleprog.student where studid = '" & Me.TxtStudId.Text & "'"
            CmdDelete = New DB2Command(StrDelete, DbConnStud)

            If MessageBox.Show("The current record will be deleted. Proceed deleting?", _
                               "Student Maintenance", MessageBoxButtons.YesNo) = _
                                Windows.Forms.DialogResult.Yes Then
                CmdDelete.ExecuteNonQuery()
                Call PopulateGrid()
            End If

            Me.BtnUpdate.Enabled = False
            Me.BtnDelete.Enabled = False
            Me.BtnSave.Enabled = True
            Call ClearTextBoxes()
            Call GetLastStudId()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        DbConnStud.Close()
        Me.Close()
    End Sub

    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles TxtSearch.TextChanged
        Dim VStrLName As String
        Dim StrSearch As String
        Dim row As String()
        Dim CmdSearch As DB2Command
        Dim RdrSearch As DB2DataReader
        Try
            VStrLName = Me.TxtSearch.Text + "%"
            StrSearch = "Select * from sampleprog.student where StudLName like '" & VStrLName & "' "
            CmdSearch = New DB2Command(StrSearch, DbConnStud)
            RdrSearch = CmdSearch.ExecuteReader
            Me.DgvStud.Rows.Clear()
            While RdrSearch.Read
                row = New String() {RdrSearch.GetString(0), RdrSearch.GetString(1), RdrSearch.GetString(2), _
                                    RdrSearch.GetString(3)}
                Me.DgvStud.Rows.Add(row)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
