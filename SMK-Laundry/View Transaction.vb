Imports System.Data.SqlClient
Public Class View_transaction
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, transaction, header, prepaid As String

    Sub koneksi()
        conn = New SqlConnection("Server =NOX; Database =Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Sub addbtn()
        Dim complete As New DataGridViewButtonColumn
        complete.HeaderText = "Action"
        complete.Text = "Complete"
        complete.Name = "Complete"
        complete.FlatStyle = FlatStyle.Flat
        complete.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(complete)
    End Sub
    Sub removebtn()
        datagrid_view.Columns.RemoveAt(9)
    End Sub

    Private Sub search_box_TextChanged(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            Call removebtn()
            query = "select a.id 'Deposit Id',b.name_customer 'name',c.name_employee 'Employee Name',e.name_service'Service Name',d.id_prepaid_transaction,d.price_detail_transaction,d.total_unit_transaction,a.transaction_date_time_header_transaction,d.completed_datetime_detail_transaction from header_transaction a,customer b,employee c,detail_transaction d,service e where a.id_customer=b.id and a.id=d.id_header_transactionr and a.id_employee=c.id and d.id_service=e.id and b.name_customer like '%" & search_box.Text & "%' "
            datagrid_view.DataSource = read(query)
            Call addbtn()

        End If

    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
        If e.ColumnIndex = 9 Then
            Call koneksi()
            query = "select * from detail_transaction where id_header_transactionr='" & id_box.Text & "'"
            cmd = New SqlCommand(query, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows Then
                transaction = dr.Item("id")
                header = dr.Item("id_header_transactionr")
                prepaid = dr.Item("id_prepaid_transaction")
            End If
            query = "update detail_transaction set completed_datetime_detail_transaction='" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm") & "' where id='" & transaction & "'"
            aksi(query)
            query = "update header_transaction set complete_estimation_date_time_header_transaction='" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh :mm") & "' where id='" & header & "'"
            aksi(query)
            query = "update prepaid_package set complete_date='" & DateTimePicker1.Value.ToString("yyyy-MM-dd hh:mm") & "' where id='" & prepaid & "'"
            aksi(query)
            MsgBox("Transaction Completed", MsgBoxStyle.Information, "Information")
        End If
        Call removebtn()
        Call kondisiawal()
    End Sub
    Sub kosong()
        id_box.Text = ""
        search_box.Text = ""
    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call removebtn()
        Call kondisiawal()
    End Sub

    Sub kondisiawal()
        datagrid_view.DataSource = Nothing
        query = "select a.id 'Deposit Id',b.name_customer 'name',c.name_employee 'Employee Name',e.name_service'Service Name',d.id_prepaid_transaction,d.price_detail_transaction,d.total_unit_transaction,a.transaction_date_time_header_transaction,d.completed_datetime_detail_transaction from header_transaction a,customer b,employee c,detail_transaction d,service e where a.id_customer=b.id and a.id=d.id_header_transactionr and a.id_employee=c.id and d.id_service=e.id"
        datagrid_view.DataSource = read(query)
        datagrid_view.AllowUserToAddRows = False
        Call addbtn()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub View_transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub
End Class