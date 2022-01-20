Imports System.Data.SqlClient

Public Class Header_Transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, id_package, id_customer As String


    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub
    Sub add_btn()
        Dim edit_btn, delete_btn As New DataGridViewButtonColumn
        edit_btn.HeaderText = "Edit"
        edit_btn.Text = "Edit"
        edit_btn.Name = "Edit"
        edit_btn.FlatStyle = FlatStyle.Flat
        edit_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(edit_btn)
        delete_btn.HeaderText = "Delete"
        delete_btn.Text = "Delete"
        delete_btn.Name = "Delete"
        delete_btn.FlatStyle = FlatStyle.Flat
        delete_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(edit_btn)
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class