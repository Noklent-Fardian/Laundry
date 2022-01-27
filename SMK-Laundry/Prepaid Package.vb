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


    Sub kondisiawal()
        query = "select a.id,b.name_customer 'Customer', concat(c.name_service,' ',d.total_unit,' ',e.name_unit ) 'Package',a.price,d.total_unit*a.price 'Price Total' ,dateadd(day,c.estimation_duration_service,a.start_date)'Estimation'from prepaid_package a, customer b,service c, package d,unit e where a.id_customer=b.id and  a.id_package=d.id and d.id_service=c.id and c.id_unit=e.id"
        datagrid_view.DataSource = read(query)
        Call kosong()
    End Sub

    Private Sub Prepaid_Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call unit()
        Call kondisiawal()
    End Sub

    Private Sub search_box_TextChanged(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            query = "select a.id,b.name_customer 'Customer', concat(c.name_service,' ',d.total_unit,' ',e.name_unit ) 'Package',a.price from prepaid_package a, customer b,service c, package d,unit e where a.id_customer=b.id and  a.id_package=d.id and d.id_service=c.id and c.id_unit=e.id and b.name_customer like '%" & search_box.Text & "%'"
            datagrid_view.AutoGenerateColumns = True
            datagrid_view.DataSource = read(query)

        End If

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If ComboBox1.Text = "" Or
                name_label.Text = "" Then
            MsgBox("Data belum lengkap", MsgBoxStyle.Information, "Belum lengkap")
        Else
            query = "insert into prepaid_package(id_customer,id_package,price,start_date) values('{0}','{1}','{2}','{3}')"
            query = String.Format(query, id_customer, id_package, price_box.Text, DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm"))
            aksi(query)

            MsgBox("Insert Data PrepaidPackage Berhasil ", MsgBoxStyle.Information, "Information")

            Call kondisiawal()
        End If
    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click

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