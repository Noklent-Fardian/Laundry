Imports System.Data.SqlClient
Public Class Manage_Employee
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim query, id_job As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security= True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Sub addbtn()
        Dim edit_btn, delete_btn As New DataGridViewButtonColumn
        edit_btn.HeaderText = "Edit"
        edit_btn.Text = "Edit"
        edit_btn.Name = "Edit"
        edit_btn.flatstyle = FlatStyle.Flat
        edit_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(edit_btn)
        delete_btn.HeaderText = "Delete"
        delete_btn.Text = "Delete"
        delete_btn.Name = "Delete"
        delete_btn.FlatStyle = FlatStyle.Flat
        delete_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(delete_btn)
    End Sub
    Sub remove_bt()
        datagrid_view.Columns.RemoveAt(9)
        datagrid_view.Columns.RemoveAt(8)
    End Sub
    Sub jobtitle()
        query = "select * From job"
        ComboBox1.DataSource = read(query)
        ComboBox1.ValueMember = "name_job"
        ComboBox1.DisplayMember = "name_job"

    End Sub
    Sub kondisiawal()
        query = "Select a.id,a.name_employee,a.id_job,a.email_employee,a.addres_employee,a.phone_number_employee,a.date_of_birth_employee ,a.salary_employee from Employee a, job b where a.id_job=b.id"
        datagrid_view.DataSource = read(query)
        Call addbtn()
        Call kosong()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Manage_Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call jobtitle()
        Call kondisiawal()
    End Sub
    Private Sub phone_number_keypress(sender As Object, e As KeyPressEventArgs) Handles phone_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
        OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        query = "select * from job where name_job='" & ComboBox1.Text & "'"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_job = dr.Item("id")
        End If
    End Sub
    Private Sub salary_keypress(sender As Object, e As KeyPressEventArgs) Handles salary_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
               OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If name_box.Text = "" Or
            email_box.Text = "" Or
            password_box.Text = "" Or
            RichTextBox1.Text = "" Or
            phone_box.Text = "" Or
            DateTimePicker2.Value = Date.Now Or
            ComboBox1.Text = "" Or
            salary_box.Text = "" Then
            MsgBox("Semua kolom harus diisi", MsgBoxStyle.Information, "Kurang kengkap")
        ElseIf password_box.Text <> confirm_box.Text Then
            MsgBox("Password tidak sama", MsgBoxStyle.Information, "Harus beda")
            password_box.Text = ""
            confirm_box.Text = ""
        ElseIf id_box.Text = "" Then
            query = "insert into Employee( name_employee,email_employee,password_employee,addres_employee,phone_number_employee,date_of_birth_employee,id_job,salary_employee)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
            query = String.Format(query, name_box.Text, email_box.Text, password_box.Text, RichTextBox1.Text, phone_box.Text, DateTimePicker2.Value.ToString("yyyy/MM/dd"), id_job, salary_box.Text)
            aksi(query)
            MsgBox("Submit berhasil", MsgBoxStyle.Information, "Berhasil")
            Call remove_bt()
            Call kondisiawal()

        Else
            query = "update employee set password_employee='" & password_box.Text & "',name_employee='" & name_box.Text & "',email_employee='" & email_box.Text & "',addres_employee='" & RichTextBox1.Text & "',phone_number_employee='" & phone_box.Text & "',date_of_birth_employee='" & DateTimePicker2.Value.ToString("yyyy-MM-dd") & "',id_job='" & id_job & "',salary_employee='" & salary_box.Text & "'  where id='" & id_box.Text & "'"
            aksi(query)
            MsgBox("Update Data Employee Berhasil!", MsgBoxStyle.Information, "Information")
            Call remove_bt()
            Call kondisiawal()

        End If
    End Sub
    Sub kosong()
        id_box.Text = ""
        name_box.Text = ""
        email_box.Text = ""
        password_box.Text = ""
        confirm_box.Text = ""
        RichTextBox1.Text = ""
        phone_box.Text = ""
        DateTimePicker1.Value = Today
        salary_box.Text = ""
    End Sub

    Private Sub LaundryDataSetBindingSource_CurrentChanged(sender As Object, e As EventArgs) Handles LaundryDataSetBindingSource.CurrentChanged

    End Sub

    Private Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        Call kosong()
    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        If e.ColumnIndex = 8 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            name_box.Text = datagrid_view.CurrentRow.Cells(1).Value
            email_box.Text = datagrid_view.CurrentRow.Cells(3).Value
            phone_box.Text = datagrid_view.CurrentRow.Cells(5).Value
            ComboBox1.Text = datagrid_view.CurrentRow.Cells(2).Value
            RichTextBox1.Text = datagrid_view.CurrentRow.Cells(4).Value
            DateTimePicker2.Value = Date.Parse(datagrid_view.CurrentRow.Cells(6).Value)
            salary_box.Text = datagrid_view.CurrentRow.Cells(7).Value
        ElseIf e.ColumnIndex = 9 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            If MessageBox.Show("Yakin Mau Hapus", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                query = "delete from employee where id='" & id_box.Text & "'"
                aksi(query)
                MsgBox("Data Berhasil Dihapus", MsgBoxStyle.Information, "Sukses")
                Call remove_bt()
                Call kondisiawal()
            Else
                MsgBox("Hapus data Gagal", MsgBoxStyle.Critical, "Gagal")
                Call remove_bt()
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub



    Private Sub search_box_TextChanged(sender As Object, e As EventArgs) Handles search_box.TextChanged

    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call remove_bt()
        Call kondisiawal()

    End Sub

    Private Sub search_box_keypress(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            Call remove_bt()
            query = "Select a.id,a.name_employee,a.id_job,a.email_employee,a.addres_employee,a.phone_number_employee,a.date_of_birth_employee ,a.salary_employee from employee a, job b where a.id_job=b.id and a.id like '%" & search_box.Text & "%' or a.name_employee like '%" & search_box.Text & "%'"
            datagrid_view.AutoGenerateColumns = True
            datagrid_view.DataSource = read(query)
            Call addbtn()

        End If


    End Sub
End Class