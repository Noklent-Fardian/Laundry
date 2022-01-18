Public Class MainMenu
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub employee_btn_Click(sender As Object, e As EventArgs) Handles employee_btn.Click
        Manage_Employee.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Manage_Package.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click_(sender As Object, e As EventArgs) Handles Button2.Click
        Manage_Service.Show()
        Me.Hide()
    End Sub
End Class