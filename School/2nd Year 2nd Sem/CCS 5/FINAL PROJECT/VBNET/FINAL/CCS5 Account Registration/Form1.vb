Public Class Form1

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Label5_MouseHover(sender As Object, e As EventArgs) Handles Label5.MouseHover
        ToolTip1.Show("Put tutorial tip here", Label5)
    End Sub

    Private Sub Label6_MouseHover(sender As Object, e As EventArgs) Handles Label6.MouseHover
        ToolTip1.Show("Put second tutorial tip here", Label6)
    End Sub

    Private Sub Label7_MouseHover(sender As Object, e As EventArgs) Handles Label7.MouseHover
        ToolTip1.Show("Put third tutorial tip here", Label7)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class
