Imports IBM.Data.DB2
Public Class FormLogin
    Private DbConnLogin As Common.DbConnection

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim VUid As String
        Dim VPass As String
        Dim StrLogin As String
        Dim CmdLogin As DB2Command
        'Dim RdrLogin As DB2DataReader

        Try
            VUid = Me.TxtUserName.Text
            VPass = Me.TxtPassword.Text
            StrLogin = "select studid from account where Userid = '" & VUid & "' " _
                & "and Password = '" & VPass & "'"
            CmdLogin = New DB2Command(StrLogin, DbConnLogin)


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub UsernameLabel_Click(sender As Object, e As EventArgs) Handles UsernameLabel.Click

    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
