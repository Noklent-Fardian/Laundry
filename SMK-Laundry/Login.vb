Public Class Login
    Dim query As String
    Dim nama, userID As String

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        query = "Select * from employee where email_employee='" & username_box.Text & "'and password_employee='" & password_box.Text & "'"
        If read(query).Rows.Count > 0 Then
            nama = read(query).Rows(0)("name_employee")
            userID = read(query).Rows(0)("id")
            MsgBox("Selamat Datang  " + nama, MsgBoxStyle.Information, "Succes")
            MainMenu.Show()
            MainMenu.Label2.Text = "Hello" + nama
            Manage_Employee.Label2.Text = "Hello" + nama
            Manage_Package.Label2.Text = "Hello" + nama

            Me.Hide()


        ElseIf username_box.Text = "" And password_box.Text = "" Then

            MsgBox("Mohon isi semua kolom", MsgBoxStyle.Information, "isi semua")
        Else
            MsgBox("Username atau Password salah", MsgBoxStyle.Critical, "error")
            username_box.Text = ""
            password_box.Text = ""
        End If
    End Sub



    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        username_box.Text = ""
        password_box.Text = ""
        Register.Show()
        Me.Hide()
    End Sub

    Private Sub Reset_btn_Click(sender As Object, e As EventArgs) Handles Reset_btn.Click
        username_box.Text = ""
        password_box.Text = ""

    End Sub
End Class
