Imports System.Data.SqlClient

Public Class Header_Transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, id_service, id_customer, id_transaction, price_detail As String
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
    Sub price()
        Call koneksi()
        query = "select  a.price_unit_service*b.total_unit_transaction from service a, detail_trasaction b"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        price_detail = dr.Item(query)
    End Sub

    Private Sub Header_Transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kosong()
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

        End If

    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call kosong()
    End Sub

    Private Sub add_btn_Click(sender As Object, e As EventArgs) Handles add_btn.Click
        If name_label.Text = "" Or
                total_box.Text = "" Then
            MsgBox("Lengkapi data", MsgBoxStyle.Information, "Lengkapi")


        End If
    End Sub

    Private Sub check_btn_Click(sender As Object, e As EventArgs) Handles check_btn.Click
        If name_label.Text = "" Then
            MsgBox("Lengkapi data", MsgBoxStyle.Information, "Lengkapi")

        Else
            query = "select a.name_service,c.id 'Prepaid Package',a.price_unit_service,b.total_unit_transaction,a.price_unit_service*b.total_unit_transaction'Total' from service a, detail_transaction b, prepaid_package c,unit d,header_transaction e where b.id_service=a.id and b.id_prepaid_transaction=c.id and a.id_unit=d.id and e.id_customer='" & id_customer & "'"
            datagrid_view.DataSource = read(query)
            Call delete_btn()



        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Sub kosong()
        Phone_box.Text = ""
        total_box.Text = ""
        name_label.Text = ""
        addres_label.Text = ""
        CheckBox1.Checked = False

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class