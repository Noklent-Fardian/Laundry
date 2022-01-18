Imports System.Data.SqlClient
Public Class Manage_Service
    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim query, id_unit, id_category As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security=true")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub

    Sub kosongkandata()
        id_box.Text = ""
        name_box.Text = ""
        price_box.Text = ""
        duration_box.Text = ""

    End Sub

    Sub unit()
        query = "select * from unit order by name_unit"
        unit_select.DataSource = read(query)
        unit_select.ValueMember = "name_unit"
        unit_select.DisplayMember = "name_unit"
    End Sub

    Sub category()
        query = " Select * from category order by name_category"
        category_select.DataSource = read(query)
        category_select.ValueMember = "name_category"
        category_select.DisplayMember = "name_category"
    End Sub

    Sub addbtn()
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

    Sub kondisiawal()
        query = " Select a.id, a.name_service as Name, b.name_unit as Unit, c.name_category as Category,a.price_unit_service as Prce, a.estimation_duration_service as Estimation_Duration from service a, unit b, category c where a.id_unit=b.id and a.id_category=c.id"
        datagrid_view.DataSource = read(query)
        Call addbtn()
        Call kosongkandata()
    End Sub
    Sub remove_btn()
        datagrid_view.Columns.RemoveAt(7)
        datagrid_view.Columns.RemoveAt(6)
    End Sub


    Private Sub Manage_Service_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call unit()
        Call category()
        Call kondisiawal()
    End Sub

    Private Sub category_select_SelectedIndexChanged(sender As Object, e As EventArgs) Handles category_select.SelectedIndexChanged
        Call koneksi()
        query = " select * from category where name_category='" & category_select.Text & "'"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_category = dr.Item("id")
        End If
    End Sub

    Private Sub unit_select_SelectedIndexChanged(sender As Object, e As EventArgs) Handles unit_select.SelectedIndexChanged
        Call koneksi()
        query = "Select *from unit where name_unit='" & unit_select.Text & "'"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_unit = dr.Item("id")

        End If
    End Sub

    Private Sub price_box_keypress(sender As Object, e As KeyPressEventArgs) Handles price_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]") _
           OrElse kunci = Keys.Back Then
            kunci = 0

        End If
        e.Handled = CBool(kunci)

    End Sub

    Private Sub duration_box_keypress(sender As Object, e As KeyPressEventArgs) Handles duration_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]") _
            OrElse kunci = Keys.Back Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)

    End Sub



    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        If e.ColumnIndex = 6 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            name_box.Text = datagrid_view.CurrentRow.Cells(1).Value
            unit_select.Text = datagrid_view.CurrentRow.Cells(2).Value
            category_select.Text = datagrid_view.CurrentRow.Cells(3).Value
            price_box.Text = datagrid_view.CurrentRow.Cells(4).Value
            duration_box.Text = datagrid_view.CurrentRow.Cells(5).Value
        ElseIf e.ColumnIndex = 7 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            If MessageBox.Show("Yakin mau dihapus?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                query = "delete service where id='" & id_box.Text & "'"
                aksi(query)
                MsgBox("Berhasil hapus data", MsgBoxStyle.Information, "Information")
                Call remove_btn()
                Call kondisiawal()
            Else
                MsgBox("Gagal hapus data", MsgBoxStyle.Critical, "Gagal")
                Call remove_btn()
                Call kondisiawal()



            End If
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Call kosongkandata()
    End Sub


    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub refresh_btn_Click(sender As Object, e As EventArgs) Handles refresh_btn.Click
        Call remove_btn()
        Call kondisiawal()
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If name_box.Text = "" Or
                unit_select.Text = "" Or
                category_select.Text = "" Or
                price_box.Text = "" Or
                duration_box.Text = "" Then
            MsgBox("Isi semua Kolom", MsgBoxStyle.Information, "Belum lengkap")
        ElseIf id_box.Text = "" Then
            query = "Insert into service (name_service,id_unit,id_category,price_unit_service,estimation_duration_service) values('{0}','{1}','{2}','{3}','{4}')"
            query = String.Format(query, name_box.Text, id_unit, id_category, price_box.Text, duration_box.Text)
            aksi(query)
            MsgBox("Input Data Berhasil", MsgBoxStyle.Information, "Berhasil")
            Call remove_btn()
            Call kondisiawal()

        Else
            query = " Update service set name_service='" & name_box.Text & "',id_unit='" & id_unit & "',id_category='" & id_category & "',price_unit_service='" & price_box.Text & "',estimation_duration_service='" & duration_box.Text & "' where id='" & id_box.Text & "'"
            aksi(query)
            MsgBox("Update Data Employee Berhasil!", MsgBoxStyle.Information, "Information")
            Call remove_btn()
            Call kondisiawal()



        End If

    End Sub

    Private Sub search_box_keypress(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            Call remove_btn()
            query = " Select a.id, a.name_service , b.name_unit , c.name_category ,a.price_unit_service , a.estimation_duration_service from service a, unit b, category c where a.id_unit=b.id and a.id_category=c.id and a.name_service like '%" & search_box.Text & "%'"
            datagrid_view.AutoGenerateColumns = True
            datagrid_view.DataSource = read(query)
            Call addbtn()
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub
End Class