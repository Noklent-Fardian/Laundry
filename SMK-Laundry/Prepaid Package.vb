Imports System.Data.SqlClient
Public Class Prepaid_Package
    Dim cmd As SqlCommand
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim query, id_prepaid, id_package, id_customer As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX;Database=Laundry;Integrated Security=True")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Sub kosong()
        id_boc.Text = ""
        name_label.Text = ""
        addres_label.Text = ""
        price_box.Text = ""
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Prepaid_Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class