Imports IBM.Data.DB2
Public Class FormEnroll
    Private DbConnEnroll As Common.DbConnection

    Private Sub PopulateCourseOfferings()
        Dim StrPopGrid As String
        Dim Row As String()
        Dim CmdPopGrid As DB2Command
        Dim RdrPopGrid As DB2DataReader
        Try
            StrPopGrid = "select classNo, c.CourseNo, classSection, c.CourseTitle, " _
                      & "ClassSize, Avail_Slot from sampleprog.Class cl join sampleprog.Course c on " _
                      & "cl.CourseNo = c.CourseNo"
            CmdPopGrid = New DB2Command(StrPopGrid, DbConnEnroll)
            RdrPopGrid = CmdPopGrid.ExecuteReader
            Me.DgvCourseOfferings.Rows.Clear()
            While RdrPopGrid.Read
                Row = New String() {RdrPopGrid.GetString(0), RdrPopGrid.GetString(1), _
                                RdrPopGrid.GetString(2), RdrPopGrid.GetString(3), _
                                    RdrPopGrid.GetString(4), RdrPopGrid.GetString(5)}
                Me.DgvCourseOfferings.Rows.Add(Row)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub GetLastEnrollNo(ByRef VEnrolNo)
        Dim StrGetLastNum As String
        Dim CmdGetLastNum As DB2Command
        Dim RdrGetLastNum As DB2DataReader

        Try
            StrGetLastNum = "Select enrolno from sampleprog.enrollment order by enrolno desc"
            CmdGetLastNum = New DB2Command(StrGetLastNum, DbConnEnroll)
            RdrGetLastNum = CmdGetLastNum.ExecuteReader
            If RdrGetLastNum.HasRows Then
                RdrGetLastNum.Read()
                VEnrolNo = RdrGetLastNum.GetString(0)
                VEnrolNo = VEnrolNo + 1
            Else
                VEnrolNo = 1
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormEnroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim StrPopGrid As String
        Dim Row As String()
        Dim CmdPopGrid As DB2Command
        Dim RdrPopGrid As DB2DataReader
        Try
            Me.TxtDate.Text = Date.Now.ToString("d")
            DbConnEnroll = New DB2Connection("server=localhost;database=ccs5b;" + _
                                             "uid=db2admin;password=db2admin;")
            DbConnEnroll.Open()
            With Me.DgvCourseOfferings
                .ColumnCount = 6
                .Columns(0).Name = "Offering No"
                .Columns(1).Name = "Course No"
                .Columns(2).Name = "Section"
                .Columns(3).Name = "Course Title"
                .Columns(4).Name = "Size"
                .Columns(5).Name = "Available"
                .Columns(2).Width = 75
                .Columns(3).Width = 250
            End With
            With Me.DgvStudEnroll
                .ColumnCount = 4
                .Columns(0).Name = "Offering No"
                .Columns(1).Name = "Course No"
                .Columns(2).Name = "Section"
                .Columns(3).Name = "Course Title"
                .Columns(2).Width = 75
                .Columns(3).Width = 250
            End With
            StrPopGrid = "select classNo, c.CourseNo, classSection, c.CourseTitle, " _
                      & "ClassSize,Avail_Slot from sampleprog.Class cl join sampleprog.Course c on " _
                      & "cl.CourseNo = c.CourseNo"
            CmdPopGrid = New DB2Command(StrPopGrid, DbConnEnroll)
            RdrPopGrid = CmdPopGrid.ExecuteReader
            While RdrPopGrid.Read
                Row = New String() {RdrPopGrid.GetString(0), RdrPopGrid.GetString(1), _
                                RdrPopGrid.GetString(2), RdrPopGrid.GetString(3), _
                                    RdrPopGrid.GetString(4), RdrPopGrid.GetString(5)}
                Me.DgvCourseOfferings.Rows.Add(Row)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        FormLogin.Close()
        DbConnEnroll.Close()
        Me.Close()
    End Sub

    Private Sub BtnWithdraw_Click(sender As Object, e As EventArgs) Handles BtnWithdraw.Click
        Dim VClassNo As Integer
        Dim StrWithdraw As String
        Dim CmdWithdraw As DB2Command

        Try
            'Remove the chosen course from the data grid inc case 
            If Me.DgvStudEnroll.SelectedRows.Count > 0 Then
                VClassNo = Me.DgvStudEnroll.CurrentRow.Cells(0).Value
                Me.DgvStudEnroll.Rows.RemoveAt(Me.DgvStudEnroll.CurrentRow.Index)
                StrWithdraw = "update sampleprog.class set Avail_Slot = Avail_Slot + 1 " _
                        & "where classNo = '" & VClassNo & "'"
                CmdWithdraw = New DB2Command(StrWithdraw, DbConnEnroll)
                CmdWithdraw.ExecuteNonQuery()
                Call PopulateCourseOfferings()
            Else
                MsgBox("You have not selected a row to be removed...")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BtnSubmit_Click(sender As Object, e As EventArgs) Handles BtnSubmit.Click
        Dim VNumRows As Integer
        Dim StrEnroll As String
        Dim CmdEnroll As DB2Command
        Dim VEnrolNo As Integer
        Try
            Call GetLastEnrollNo(VEnrolNo)
            If Me.DgvStudEnroll.RowCount > 0 Then
                For VNumRows = 0 To Me.DgvStudEnroll.RowCount - 2
                    With Me.DgvStudEnroll
                        StrEnroll = "insert into sampleprog.enrollment values ('" & VEnrolNo & "'," _
                            & " '" & Me.TxtStudId.Text & "','" & .Rows(VNumRows).Cells(0).Value & "', " _
                            & "'" & Date.Now.ToString("d") & "', '" & .Rows(VNumRows).Cells(1).Value & "', " _
                            & " '" & .Rows(VNumRows).Cells(3).Value & "')"
                        CmdEnroll = New DB2Command(StrEnroll, DbConnEnroll)
                        CmdEnroll.ExecuteNonQuery()
                    End With
                    VEnrolNo = VEnrolNo + 1
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class