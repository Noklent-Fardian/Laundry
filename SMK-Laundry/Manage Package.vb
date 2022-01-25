Imports System.Data.SqlClient
Public Class Manage_Package
    Dim conn As SqlConnection
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim query, query2, id_Service As String

    Sub koneksi()
        conn = New SqlConnection("Server=NOX; Database=Laundry; Integrated Security=True")
        If conn.State = ConnectionState.Closed Then conn.Open()
    End Sub
    Sub kosong()
        id_box.Text = ""
        total_box.Text = ""
        price_box.Text = ""
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
        query = ("select a.id as Package_ID,b.name_service,a.total_unit, a.price from package a, service b where b.id=a.id_service ")
        query2 = (" Select a.id, a.name_service as Name, b.name_unit as Unit, c.name_category as Category,a.price_unit_service as Prce, a.estimation_duration_service as Estimation_Duration from service a, unit b, category c where a.id_unit=b.id and a.id_category=c.id")
        datagrid_view.DataSource = read(query)
        datagrid_view2.DataSource = read(query2)
        datagrid_view2.Hide()

        Call kosong()
        Call addbtn()
    End Sub
    Sub service()
        query = "select * from service order by name_service"
        ComboBox1.DataSource = read(query)
        ComboBox1.DisplayMember = "name_service"
        ComboBox1.ValueMember = "name_service"

    End Sub
    Private Sub Manage_Package_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call kondisiawal()
        Call service()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call koneksi()
        query = "select * from service where name_service='" & ComboBox1.Text & "'"
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            id_Service = dr.Item("id")
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MainMenu.Show()
        Me.Hide()
    End Sub



    Private Sub price_box_keypress(sender As Object, e As KeyPressEventArgs) Handles price_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
               OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub



    Private Sub total_box_keypress(sender As Object, e As KeyPressEventArgs) Handles total_box.KeyPress
        Dim kunci As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" _
            OrElse kunci = Keys.Back) Then
            kunci = 0
        End If
        e.Handled = CBool(kunci)
    End Sub

    Private Sub reset_btn_Click(sender As Object, e As EventArgs) Handles reset_btn.Click
        Call kosong()
        Call service()
        
    End Sub

    Sub removebt()
        datagrid_view.Columns.RemoveAt(5)
        datagrid_view.Columns.RemoveAt(4)
    End Sub

    Private Sub submit_btn_Click(sender As Object, e As EventArgs) Handles submit_btn.Click
        If ComboBox1.Text = "" Or
                total_box.Text = "" Or
                price_box.Text = "" Then
            MsgBox("Mohon isi semua kolom ", MsgBoxStyle.Information, "Kurang lengkap")
        ElseIf id_box.Text = "" Then
            query = "insert into package (id_service, total_unit,price ) values ('{0}','{1}','{2}')"
            query = String.Format(query, id_Service, total_box.Text, price_box.Text)
            aksi(query)
            MsgBox("Insert data berhasil", MsgBoxStyle.Information, "Berhasil")
            Call removebt()
            Call kondisiawal()
        Else
            query = "update package set id_service='" & id_Service & "',total_unit='" & total_box.Text & "',price='" & price_box.Text & "' where id='" & id_box.Text & "'"
            aksi(query)
            MsgBox("Berhasil update data", MsgBoxStyle.Information, "Berhasil")
            Call removebt()
            Call kondisiawal()
        End If
    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = False Then
            datagrid_view2.Hide()
        ElseIf CheckBox1.Checked = True Then
            datagrid_view2.Show()

        End If


    End Sub

    Private Sub search_box_TextChanged(sender As Object, e As EventArgs) Handles search_box.TextChanged

    End Sub

    Private Sub datagrid_view_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagrid_view.CellContentClick
        If e.ColumnIndex = 4 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            ComboBox1.Text = datagrid_view.CurrentRow.Cells(1).Value
            total_box.Text = datagrid_view.CurrentRow.Cells(2).Value
            price_box.Text = datagrid_view.CurrentRow.Cells(3).Value
        ElseIf e.ColumnIndex = 5 Then
            id_box.Text = datagrid_view.CurrentRow.Cells(0).Value
            If MessageBox.Show("Yakin hapus  " + datagrid_view.CurrentRow.Cells(1).Value, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                query = "delete from package where id='" & id_box.Text & "'"
                aksi(query)
                MsgBox("Berhasil hapus data", MsgBoxStyle.Information, "Berhasil")
                Call removebt()
                Call kondisiawal()
            Else
                MsgBox("Update gagal", MsgBoxStyle.Critical, "Gagal")
                Call removebt()
                Call kondisiawal()


            End If
        End If
    End Sub
    Private Sub search_box_keypress(sender As Object, e As KeyPressEventArgs) Handles search_box.KeyPress
        If e.KeyChar = Chr(13) Then
            Call removebt()
            query = "select a.id,b.name_service,a.total_unit, a.price from package a, service b where b.id=a.id_service and a.id like '%" & search_box.Text & "%'"
            datagrid_view.AutoGenerateColumns = True
            datagrid_view.DataSource = read(query)
            Call addbtn()


        End If

    End Sub
End Class