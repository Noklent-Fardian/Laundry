﻿Imports System.Data.SqlClient
Public Class Customer
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim query As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX;Database=Laundry;Integrated Security=True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Sub add_btn()
        Dim edit_btn, delete_btn As New DataGridViewButtonColumn
        edit_btn.HeaderText = "Edit"
        edit_btn.Text = "Edit"
        edit_btn.Name = "Edit"
        edit_btn.FlatStyle = FlatStyle.Flat
        edit_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(edit_btn)
        delete_btn.HeaderText = "Delete"
        delete_btn.Text = "Delete"
        delete_btn.Name = "Delete"
        delete_btn.FlatStyle = FlatStyle.Flat
        delete_btn.UseColumnTextForButtonValue = True
        datagrid_view.Columns.Add(delete_btn)
    End Sub
    Sub kosong()
        id_box.Text = ""
        name_box.Text = ""
        phone_box.Text = ""
        RichTextBox1.Text = ""

    End Sub
    Sub removebtn()
        datagrid_view.Columns.RemoveAt(5)
        datagrid_view.Columns.RemoveAt(4)
    End Sub
    Sub kondisiawal()
        query = "Select* from customer "
        datagrid_view.DataSource = read(query)
        Call kosong()
        Call add_btn()
    End Sub
    Private Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        Call kosong()
    End Sub

    Private Sub Customer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub

    Private Sub phone_box_keypress(sender As Object, e As KeyPressEventArgs) Handles phone_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
                OrElse kunci = Keys.Back) Then
            kunci = 0

        End If
        e.Handled = CBool(kunci)

    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        If e.ColumnIndex = 4 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            name_box.Text = datagrid_view.CurrentRow.Cells(1).Value
            phone_box.Text = datagrid_view.CurrentRow.Cells(2).Value
            RichTextBox1.Text = datagrid_view.CurrentRow.Cells(3).Value
        ElseIf e.ColumnIndex = 5 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            If MessageBox.Show("Yakin mau hapus data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                query = "Delete  customer where id='" & id_box.Text & "'"
                aksi(query)
                MsgBox("Hapusdata Berhasil", MsgBoxStyle.Information, "Berhasil")
                Call removebtn()
                Call kondisiawal()
            Else

                MsgBox("Hapus data gagal", MsgBoxStyle.Critical, "Gagal")
                Call removebtn()
                Call kondisiawal()
            End If
        End If
    End Sub

    Private Sub search_box_keypress(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            query = "select from customer where id like '%" & search_box.Text & "%' or name_customer like '%" & search_box.Text & "%'"
            datagrid_view.AutoGenerateColumns = True
            datagrid_view.DataSource = read(query)
            Call add_btn()


        End If

    End Sub
End Class