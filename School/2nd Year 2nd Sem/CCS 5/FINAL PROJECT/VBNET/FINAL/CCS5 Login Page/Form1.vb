Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label4_MouseHover(sender As Object, e As EventArgs) Handles Label4.MouseHover
        ToolTip1.Show("Put tutorial tip here", Label4)
    End Sub

    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        ToolTip1.Show("Put second tutorial tip here", Label5)
    End Sub

    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        ToolTip1.Show("Put third tutorial tip here", Label6)
    End Sub
End Class
