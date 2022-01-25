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
        Phone_box.Text = ""
    End Sub

    Sub unit()
        query = "select b.name_service from package a, service b where a.id_service=b.id"
        ComboBox1.DataSource = read(query)
        ComboBox1.DisplayMember = "name_service"
        ComboBox1.ValueMember = "name_service"
    End Sub
    Sub remove_btn()

        datagrid_view.Columns.RemoveAt(6)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Customer.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        query = "select a.id from package a,service b where name_service ='" & ComboBox1.Text & "' and a.id_service=b.id"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_package = dr.Item("id")
        End If
    End Sub

    Private Sub price_box_keypress(sender As Object, e As KeyPressEventArgs) Handles price_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        id_boc.Text = datagrid_view.CurrentRow.Cells(0).Value
        price_box.Text = datagrid_view.CurrentRow.Cells(5).Value
    End Sub

    Sub add_btn()
        Dim select_btn As New DataGridViewButtonColumn
        select_btn.headertext = "Action"
        select_btn.Text = "Select"
        select_btn.HeaderText = "select"
        select_btn.FlatStyle = FlatStyle.Flat
        select_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(select_btn)
    End Sub

    Sub kondisiawal()
        query = "select a.id 'DetailDeposit ID',d.name_customer 'Customer',b.name_service'Service',a.price_detail_transaction,a.total_unit_transaction,a.price_detail_transaction*a.total_unit_transaction 'Total price' from detail_transaction a,service b,header_transaction c,customer d where a.id_service=b.id and a.id_header_transactionr=c.id and c.id_customer=d.id"
        datagrid_view.DataSource = read(query)
        Call add_btn()
        Call kosong()
    End Sub

    Private Sub Prepaid_Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call unit()
        Call kondisiawal()
    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If id_boc.Text = "" Or
                ComboBox1.Text = "" Or
                price_box.Text = "" Or
                name_label.Text = "" Then
            MsgBox("Data belum lengkap", MsgBoxStyle.Information, "Belum lengkap")
        Else
            query = "insert into prepaid_package(id_customer,id_package,price,start_date) values('{0}','{1}','{2}','{3}')"
            query = String.Format(query, id_customer, id_package, price_box.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm"))
            aksi(query)
            Call koneksi()
            query = "select top (1) * from prepaid_package order by id desc"
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                id_prepaid = dr.Item("id")
            End If
            query = "update detail_transaction set id_prepaid_transaction='" & id_prepaid & "' where id='" & id_boc.Text & "'"
            aksi(query)
            MsgBox("Insert Data PrepaidPackage Berhasil ", MsgBoxStyle.Information, "Information")
            Call remove_btn()
            Call kondisiawal()
        End If
    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call remove_btn()
        Call kondisiawal()



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


End Class