Imports IBM.Data.DB2
Public Class FrmLogin
    Private DBConnLogin As Common.DbConnection
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtrnOkay.Click
        Dim VUid As String
        Dim VPass As String
        Dim StrLogin As String
        Dim CmdLogin As DB2Command
        Dim RdrLogin As DB2DataReader
        Try
            VUid = Me.TxtUserName.Text
            VPass = Me.TxtPassword.Text
            StrLogin = "Select studid from account where Userid = '" & VUid & "' " _
                      & "and Password='" & VPass & "'"
            CmdLogin = New DB2Command(StrLogin, DBConnLogin)
            RdrLogin = CmdLogin.ExecuteReader
            If RdrLogin.HasRows Then
                RdrLogin.Read()
                FrmEnroll.TxtStudId.Text = RdrLogin.GetString(0)
                FrmEnroll.Show()
                Me.Hide()
            Else
                MsgBox("Invalid username/password..", MsgBoxStyle.Information)
                Me.TxtUserName.Clear()
                Me.TxtPassword.Clear()
                Me.TxtUserName.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DBConnLogin = New DB2Connection("server=localhost; database=enrol;" + "uid=db2admin;password=db2admin;")
            DBConnLogin.Open()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
