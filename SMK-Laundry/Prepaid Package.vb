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

    Private Sub Phone_box_TextChanged(sender As Object, e As EventArgs) Handles Phone_box.TextChanged

    End Sub

    Sub kondisiawal()
        query = "select a.id 'DetailDeposit ID',d.name_customer 'Customer',b.name_service'Service',a.price_detail_transaction,a.total_unit_transaction,a.price_detail_transaction*a.total_unit_transaction 'Total price' from detail_transaction a,service b,header_transaction c,customer d where a.id_service=b.id and a.id_header_transactionr=c.id and c.id_customer=d.id"
        datagrid_view.DataSource = read(query)
        Dim btn As New DataGridViewButtonColumn()
        btn.HeaderText = "Action"
        btn.Text = "Select"
        btn.Name = "btnSelect"
        btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(btn)
        Call kosong()
    End Sub


    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Call unit()
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

    Private Sub Prepaid_Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class