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

    Private Sub Phone_box_keypress(sender As Object, e As KeyPressEventArgs) Handles Phone_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)

        If e.KeyChar = Chr(13) Then
            Call koneksi()
            query = "select * from customer where phone_number_customer='" & Phone_box.Text & "'"
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                id_customer = dr.Item("id")
                name_label.Text = " " + dr.Item("name_customer") + ""
                addres_label.Text = "" + dr.Item("addres_customer") + " "
            Else
                MsgBox("Customer Tidak Ditemukan", MsgBoxStyle.Information, "Missing")
                name_label.Text = ""
                addres_label.Text = ""
            End If
        End If


    End Sub

    Private Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        Call kosong()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Customer.Show()
    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If total_box.Text = "" Or
            Phone_box.Text = "" Or
            name_label.Text = "" Then
            MsgBox("Isi semua Kolom", MsgBoxStyle.Information, "Belum Lengkap")
        Else
            query = "Insert into header_transaction(id_employee,id_customer,transaction_date_time_header_transaction) values('{0}','{1}','{2}'"
            query = String.Format(query, id_customer, employe.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd"))
            aksi(query)
        End If
    End Sub

    Sub kosong()
        Phone_box.Text = ""
        total_box.Text = ""
        name_label.Text = ""
        addres_label.Text = ""

    End Sub

    Sub kondisi_awal()
        query = "Select a.id_header_transactionr 'Id Deposit', a.id_service,a.price_detail_transaction 'price',a.total_unit_transaction 'Total', b.id_customer,b.id_employee,b.transaction_date_time_header_transaction 'Date' from detail_transaction a, header_transaction b where a.id_header_transactionr=b.id"
        datagrid_view.DataSource = read(query)
        Call kosong()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class