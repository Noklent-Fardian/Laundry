Imports System.Data.SqlClient
Public Class View_transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query As String

    Sub koneksi()
        conn = New SqlConnection("Server =NOX; Database =Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class