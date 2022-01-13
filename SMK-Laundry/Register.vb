Imports System.Data.SqlClient
Public Class Register
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim query, id_job As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security= true")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call jobtitle()
    End Sub
    Sub jobtitle()
        query = "select * From job"
        ComboBox1.DataSource = read(query)
        ComboBox1.ValueMember = "name_job"
        ComboBox1.DisplayMember = "name_job"

    End Sub

    Private Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        name_box.Text = ""
        email_box.Text = ""
        password_box.Text = ""
        confirm_box.Text = ""
        RichTextBox1.Text = ""
        phone_box.Text = ""
        DateTimePicker1.Value = Today
        ComboBox1.Text = ""
        salary_box.Text = ""
    End Sub
    Private Sub phone_number_keypress(sender As Object, e As KeyPressEventArgs) Handles phone_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
        OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
    Private Sub phone_box_TextChanged(sender As Object, e As EventArgs) Handles phone_box.TextChanged

    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If name_box.Text = "" Or
            email_box.Text = "" Or
            password_box.Text = "" Or
            confirm_box.Text = "" Or
            RichTextBox1.Text = "" Or
            phone_box.Text = "" Or
            DateTimePicker1.Value = Today Or
            ComboBox1.Text = "" Or
            salary_box.Text = "" Then
            MsgBox("Semua kolom harus diisi", MsgBoxStyle.Information, "Kurang kengkap")
        ElseIf password_box.Text <> confirm_box.Text Then
            MsgBox("Password tidak sama", MsgBoxStyle.Information, "Harus beda")
            password_box.Text = ""
            confirm_box.Text = ""
        Else query = "insert into Employee( name_employee,email_employee,password_employee,addres_employee,phone_number_employee,date_of_birth_employee,id_job,salary_employee)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
            query = String.Format(query, name_box.Text, email_box.Text, password_box.Text, RichTextBox1.Text, phone_box.Text, DateTimePicker1.Value.ToString("yyyy/MM/dd"), id_job, salary_box.Text)
            aksi(query)
            MsgBox("Register berhasil", MsgBoxStyle.Information, "Berhasil")
            name_box.Text = ""
            email_box.Text = ""
            password_box.Text = ""
            confirm_box.Text = ""
            RichTextBox1.Text = ""
            phone_box.Text = ""
            DateTimePicker1.Value = Today
            ComboBox1.Text = ""
            salary_box.Text = ""
            Login.Show()
            Me.Hide()


        End If
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

    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Login.Show()
        Me.Hide()
        name_box.Text = ""
        email_box.Text = ""
        password_box.Text = ""
        confirm_box.Text = ""
        RichTextBox1.Text = ""
        phone_box.Text = ""
        DateTimePicker1.Value = Today
        ComboBox1.Text = ""
        salary_box.Text = ""
    End Sub

    Private Sub salary_keypress(sender As Object, e As KeyPressEventArgs) Handles salary_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
               OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub
End Class