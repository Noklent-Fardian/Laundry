﻿Imports System.Data.SqlClient
Public Class Manage_Employee
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim query, id_job As String

    Sub koneksi()
        conn = New SqlConnection("Source=NOX; Database=Laundry; Integrated Security= True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Sub addbtn()
        Dim edit_btn, delete_btn As New DataGridViewColumn
        edit_btn.HeaderText = "Edit"
        edit_btn.Text = "Edit"
        edit_btn.Name = "Edit"
        edit_btn.flatstyle = FlatStyle.Flat
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub Manage_Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class