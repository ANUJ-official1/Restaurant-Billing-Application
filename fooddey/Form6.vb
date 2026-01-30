Imports System.Data.SqlClient

Public Class SaleReport
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim id As Integer = Convert.ToInt32(DataGridView1.SelectedRows(0).Cells("ID").Value)
            Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\fooddey\fooddey\fooddey\Database1.mdf;Integrated Security=True"
            Using connection As New SqlConnection(connectionString)
                Dim query As String = "DELETE FROM SaleReport WHERE ID = @ID"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@ID", id)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Data Deleted Successfully")
        Else
            MessageBox.Show("Please select a row to delete")
        End If
        ' Ensure the index is within the valid range
        Dim index As Integer = DataGridView1.CurrentCell.RowIndex
        If index >= 0 AndAlso index < DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows.RemoveAt(index)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim connectionString As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\source\repos\fooddey\fooddey\fooddey\Database1.mdf;Integrated Security=True"
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT * FROM SaleReport"
            Using adapter As New SqlDataAdapter(query, connection)
                Dim table As New DataTable()
                adapter.Fill(table)
                DataGridView1.DataSource = table
            End Using
        End Using
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class