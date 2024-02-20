Imports IBM.Data.DB2
Public Class Form1

    Private Sub DgInventoryView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgInventoryView.CellContentClick

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlSelect As String
        Dim CmdSelect As DB2Command
        Dim RdrSelect As DB2DataReader
        Dim DgvRow As String()
        Try

            DgInventoryView.ColumnCount = 4
            DgInventoryView.Columns(0).Name = "Item No"
            DgInventoryView.Columns(1).Name = "Item Name"
            DgInventoryView.Columns(2).Name = "Quantity"
            DgInventoryView.Columns(3).Name = "Price"

            Dim DbConn = New DB2Connection("server=localhost;database=ccs5a;" + "uid=Daval;password=06072001daval")
            DbConn.Open()
            SqlSelect = "select * from employee"
            CmdSelect = New DB2Command(SqlSelect, DbConn)
            RdrSelect = CmdSelect.ExecuteReader
            While RdrSelect.Read
                DgvRow = New String() {RdrSelect.GetString(0), RdrSelect.GetString(1), RdrSelect.GetString(2), RdrSelect.GetString(3)}
                DgInventoryView.Rows.Add(DgvRow)
            End While
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub
End Class
