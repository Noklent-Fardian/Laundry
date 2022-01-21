Imports System.Data.SqlClient

Public Class Header_Transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, id_service, id_customer, id_transaction As String
    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Private Sub total_box_keypress(sender As Object, e As KeyPressEventArgs) Handles total_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)

    End Sub
    Sub service()
        query = "select * from service order by name_service"
        ComboBox1.DataSource = read(query)
        ComboBox1.ValueMember = "name_service"
        ComboBox1.DisplayMember = "name_service"

    End Sub

    Private Sub Header_Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisi_awal()
        Call service()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        query = "select * from service where name_service='" & ComboBox1.Text & "'"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_service = dr.Item("id")
            price_box.Text = dr.Item("price_unit_service")

        End If

    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick

    End Sub

    Sub kosong()
        Phone_box.Text = ""
        price_box.Text = ""
        total_box.Text = ""
        addres_label.Text = ""
        name_label.Text = ""
    End Sub

    Sub kondisi_awal()
        query = "select a.id_header_transactionr 'Id Deposit', a.id_service,a.price_detail_transaction 'price',a.total_unit_transaction 'Total', b.id_customer,b.id_employee,b.transaction_date_time_header_transaction 'Date' from detail_transaction a, header_transaction b where a.id_header_transactionr=b.id"
        datagrid_view.DataSource = read(query)

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class