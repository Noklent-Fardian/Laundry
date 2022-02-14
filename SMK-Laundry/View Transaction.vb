Imports System.Data.SqlClient
Public Class View_transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, query2, transaction, header, prepaid As String

    Sub koneksi()
        conn = New SqlConnection("Server =NOX; Database =Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Sub select_btn()
        Dim pilih As New DataGridViewButtonColumn
        pilih.HeaderText = "Acton"
        pilih.Text = "Select"
        pilih.Name = "Select"
        pilih.FlatStyle = FlatStyle.Flat
        pilih.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(pilih)
    End Sub
    Sub completebtn()
        Dim complete As New DataGridViewButtonColumn
        complete.HeaderText = "Action"
        complete.Text = "Complete"
        complete.Name = "Complete"
        complete.FlatStyle = FlatStyle.Flat
        complete.UseColumnTextForButtonValue = True
        datadrid_view2.Columns.Add(complete)
    End Sub
    Sub removebtn()
        datagrid_view.Columns.RemoveAt(6)
    End Sub
    Sub remove2()
        datadrid_view2.Columns.RemoveAt(7)
    End Sub
    Sub kondisiawal()
        GroupBox2.Hide()
        query = "select a.id ,a.id_customer,b.name_customer,c.name_employee,a.transaction_date_time_header_transaction,a.complete_estimation_date_time_header_transaction from header_transaction a,customer b, employee c where b.id=a.id_customer and c.id=a.id_employee"
        datagrid_view.DataSource = read(query)
        datagrid_view.AllowUserToAddRows = False
        Call select_btn()
        query2 = "select a.id,b.name_service,a.id_prepaid_transaction,a.price_detail_transaction,a.total_unit_transaction,a.price_detail_transaction*a.total_unit_transaction 'Total price',a.completed_datetime_detail_transaction from detail_transaction a, service b where b.id=a.id_service and a.id_header_transactionr ='" & datagrid_view.CurrentRow.Cells(0).Value & "'"
        datadrid_view2.DataSource = read(query2)
        Call completebtn()


    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
        If e.ColumnIndex = 6 Then
            Call remove2()
            query2 = "select a.id,b.name_service,a.id_prepaid_transaction,a.price_detail_transaction,a.total_unit_transaction,a.price_detail_transaction*a.total_unit_transaction 'Total price',a.completed_datetime_detail_transaction from detail_transaction a, service b where b.id=a.id_service and a.id_header_transactionr ='" & id_box.Text & "'"
            datadrid_view2.DataSource = read(query2)
            GroupBox2.Show()
            Call completebtn()

        End If
        Call removebtn()
        Call select_btn()

    End Sub

    Private Sub datadrid_view2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datadrid_view2.CellContentClick
        id_detail_box.Text = datadrid_view2.CurrentRow.Cells(0).Value
        If e.ColumnIndex = 7 Then
            query2 = "update detail_transaction set completed_datetime_detail_transaction='" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm") & "' where id='" & id_detail_box.Text & "'"
            aksi(query2)
            Call remove2()
            query = "select a.id,b.name_service,a.id_prepaid_transaction,a.price_detail_transaction,a.total_unit_transaction,a.price_detail_transaction*a.total_unit_transaction 'Total price',a.completed_datetime_detail_transaction from detail_transaction a, service b where b.id=a.id_service and a.id_header_transactionr ='" & id_box.Text & "'"
            datadrid_view2.DataSource = read(query)
            Call completebtn()
        End If
    End Sub
    Private Sub search_box_TextChanged(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            Call removebtn()
            query = "select a.id ,a.id_customer,b.name_customer,c.name_employee,a.transaction_date_time_header_transaction,a.complete_estimation_date_time_header_transaction from header_transaction a,customer b, employee c where b.id=a.id_customer and c.id=a.id_employee and b.name_customer like '%" & search_box.Text & "%' "
            datagrid_view.DataSource = read(query)
            Call select_btn()


        End If

    End Sub

    Private Sub search_box_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Sub kosong()
        id_box.Text = ""
        search_box.Text = ""
    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call removebtn()
        Call remove2()
        Call kondisiawal()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub View_transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub
End Class