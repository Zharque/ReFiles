Imports IBM.Data.DB2
Public Class Form1
    Private DbConn As Common.DbConnection
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SqlSelect As String
        Dim CmdSelect As DB2Command
        Dim RdrSelect As DB2DataReader
        Dim DgvRow As String()

        Try
            DgvInventoryView.ColumnCount = 4
            DgvInventoryView.Columns(0).Name = "Item No"
            DgvInventoryView.Columns(1).Name = "Item Name"
            DgvInventoryView.Columns(2).Name = "Quantity"
            DgvInventoryView.Columns(3).Name = "Price"
            DgvInventoryView.Columns(1).Width = 150

            DbConn = New DB2Connection("server=localhost;database=ccs5a;" + "uid=CC10;password=dkh10;")
            DbConn.Open()

            SqlSelect = "select * from inventory"
            CmdSelect = New DB2Command(SqlSelect, DbConn)
            RdrSelect = CmdSelect.ExecuteReader

            While RdrSelect.Read
                DgvRow = New String() {RdrSelect.GetString(0), RdrSelect.GetString(1), _
                                       RdrSelect.GetString(2), RdrSelect.GetString(3)}
                DgvInventoryView.Rows.Add(DgvRow)
            End While

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        DbConn.Close()
        Me.Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim SqlSearch As String
        Dim StrValue As String
        Dim CmdSearch As DB2Command
        Dim RdrSearch As DB2DataReader
        Dim RowSearch As String()
        Try
            StrValue = Me.TextBox1.Text + "%"
            SqlSearch = "select * from inventory where inv_des like '" & StrValue & "'"
            CmdSearch = New DB2Command(SqlSearch, DbConn)
            RdrSearch = CmdSearch.ExecuteReader

            DgvInventoryView.Rows.Clear()

            While RdrSearch.Read
                RowSearch = New String() {RdrSearch.GetString(0), RdrSearch.GetString(1), _
                                           RdrSearch.GetString(2), RdrSearch.GetString(3)}
                DgvInventoryView.Rows.Add(RowSearch)
            End While
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim SqlInsert As String
        Dim CmdInsert As DB2Command
        Dim V_InvNo As Integer
        Dim V_ItemDes As String
        Dim V_Qty As Integer
        Dim V_Price As Decimal

        Try
            V_InvNo = Me.TxtItemNo.Text
            V_ItemDes = Me.TxtItemName.Text
            V_Qty = Me.TxtQty.Text
            V_Price = Me.TxtPrice.Text
            SqlInsert = "insert into inventory values('" & V_InvNo & "', '" & V_ItemDes & "','" & V_Qty & "','" & V_Price & "')"
            CmdInsert = New DB2Command(SqlInsert, DbConn)
            CmdInsert.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
