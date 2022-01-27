Imports System.Data.SqlClient

Public Class Header_Transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, id_service, id_customer, id_transaction, price_detail, duration As String

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
    Sub delete_btn()
        Dim delete As New DataGridViewButtonColumn
        delete.HeaderText = "Action"
        delete.Text = "Delete"
        delete.Name = "Delete"
        delete.FlatStyle = FlatStyle.Flat
        delete.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(delete)
    End Sub
    Sub remove()
        datagrid_view.Columns.RemoveAt(5)
    End Sub
    Sub estimation1()
        Call koneksi()
        query = "select dateadd(day,a.estimation_duration_service,b.transaction_date_time_header_transaction) as coba from service a,header_transaction b, detail_transaction c where c.id_service=a.id and c.id_header_transactionr=b.id "
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        duration = dr.Item("coba")
        estimation_label.Text = duration

    End Sub
    Sub price1()
        Call koneksi()
        query = "select  a.price_unit_service*b.total_unit_transaction as total from service a, detail_transaction b where b.id_service=a.id"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        price_detail = dr.Item("total")
        price_label.Text = price_detail

    End Sub

    Private Sub Header_Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kosong()
        Call service()
        refresh_btn.Enabled = False
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

        End If

    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call kosong()
        Call remove()
        Call delete_btn()
    End Sub

    Private Sub add_btn_Click(sender As Object, e As EventArgs) Handles add_btn.Click
        If name_label.Text = "" Or
                total_box.Text = "" Then
            MsgBox("Lengkapi data", MsgBoxStyle.Information, "Lengkapi")
        ElseIf CheckBox1.Checked = True Then
            query = "insert into header_transaction(id_employee,id_customer,transaction_date_time_header_transaction,complete_estimation_date_time_header_transaction)values('{0}','{1}','{2}','{3}')"
            query = String.Format(query, employe, id_customer, DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm"))


        End If
    End Sub

    Private Sub check_btn_Click(sender As Object, e As EventArgs) Handles check_btn.Click
        If name_label.Text = "" Then
            MsgBox("Lengkapi data", MsgBoxStyle.Information, "Lengkapi")

        Else
            query = "select e.id, a.name_service,c.id 'Prepaid Package',a.price_unit_service,b.total_unit_transaction,a.price_unit_service*b.total_unit_transaction'Total' from service a, detail_transaction b, prepaid_package c,unit d,header_transaction e where b.id_service=a.id and b.id_prepaid_transaction=c.id and a.id_unit=d.id and e.id_customer='" & id_customer & "'"
            datagrid_view.DataSource = read(query)
            Call estimation1()
            Call price1()
            Call delete_btn()
            check_btn.Enabled = False
            refresh_btn.Enabled = True

        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Sub kosong()
        Phone_box.Text = ""
        total_box.Text = ""
        name_label.Text = ""
        addres_label.Text = ""
        price_label.Text = ""
        estimation_label.Text = ""
        CheckBox1.Checked = False

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class