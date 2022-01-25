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