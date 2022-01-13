<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Manage_Employee
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.search_box = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.datagrid_view = New System.Windows.Forms.DataGridView()
        Me.LaundryDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LaundryDataSet = New SMK_Laundry.LaundryDataSet()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.salary_box = New System.Windows.Forms.TextBox()
        Me.phone_box = New System.Windows.Forms.TextBox()
        Me.confirm_box = New System.Windows.Forms.TextBox()
        Me.password_box = New System.Windows.Forms.TextBox()
        Me.email_box = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.name_box = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.reset_btn = New System.Windows.Forms.Button()
        Me.submit_btn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.datagrid_view, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LaundryDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LaundryDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(35, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(217, 31)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Esemka Laundry"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(424, 14)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(313, 22)
        Me.DateTimePicker1.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(900, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 25)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Label2"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.MediumAquamarine
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Location = New System.Drawing.Point(1046, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 41)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.search_box)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-5, 49)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1203, 103)
        Me.Panel1.TabIndex = 12
        '
        'search_box
        '
        Me.search_box.Location = New System.Drawing.Point(900, 45)
        Me.search_box.Name = "search_box"
        Me.search_box.Size = New System.Drawing.Size(223, 22)
        Me.search_box.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(817, 43)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 25)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Search"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 22.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label3.Location = New System.Drawing.Point(422, 26)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(330, 42)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Manage Employee"
        '
        'datagrid_view
        '
        Me.datagrid_view.AllowUserToAddRows = False
        Me.datagrid_view.AllowUserToDeleteRows = False
        Me.datagrid_view.AutoGenerateColumns = False
        Me.datagrid_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagrid_view.DataSource = Me.LaundryDataSetBindingSource
        Me.datagrid_view.Location = New System.Drawing.Point(-8, 149)
        Me.datagrid_view.Name = "datagrid_view"
        Me.datagrid_view.RowHeadersWidth = 51
        Me.datagrid_view.RowTemplate.Height = 24
        Me.datagrid_view.Size = New System.Drawing.Size(1203, 239)
        Me.datagrid_view.TabIndex = 13
        '
        'LaundryDataSetBindingSource
        '
        Me.LaundryDataSetBindingSource.DataSource = Me.LaundryDataSet
        Me.LaundryDataSetBindingSource.Position = 0
        '
        'LaundryDataSet
        '
        Me.LaundryDataSet.DataSetName = "LaundryDataSet"
        Me.LaundryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(788, 543)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(296, 24)
        Me.ComboBox1.TabIndex = 37
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Location = New System.Drawing.Point(788, 481)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(296, 22)
        Me.DateTimePicker2.TabIndex = 36
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(182, 624)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(296, 96)
        Me.RichTextBox1.TabIndex = 35
        Me.RichTextBox1.Text = ""
        '
        'salary_box
        '
        Me.salary_box.Location = New System.Drawing.Point(788, 594)
        Me.salary_box.Name = "salary_box"
        Me.salary_box.Size = New System.Drawing.Size(296, 22)
        Me.salary_box.TabIndex = 34
        '
        'phone_box
        '
        Me.phone_box.Location = New System.Drawing.Point(788, 428)
        Me.phone_box.MaxLength = 12
        Me.phone_box.Name = "phone_box"
        Me.phone_box.Size = New System.Drawing.Size(296, 22)
        Me.phone_box.TabIndex = 33
        '
        'confirm_box
        '
        Me.confirm_box.Location = New System.Drawing.Point(182, 578)
        Me.confirm_box.Name = "confirm_box"
        Me.confirm_box.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.confirm_box.Size = New System.Drawing.Size(296, 22)
        Me.confirm_box.TabIndex = 32
        '
        'password_box
        '
        Me.password_box.Location = New System.Drawing.Point(182, 529)
        Me.password_box.Name = "password_box"
        Me.password_box.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.password_box.Size = New System.Drawing.Size(296, 22)
        Me.password_box.TabIndex = 31
        '
        'email_box
        '
        Me.email_box.Location = New System.Drawing.Point(182, 477)
        Me.email_box.Name = "email_box"
        Me.email_box.Size = New System.Drawing.Size(296, 22)
        Me.email_box.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label10.Location = New System.Drawing.Point(572, 587)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 29)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Salary"
        '
        'name_box
        '
        Me.name_box.Location = New System.Drawing.Point(182, 421)
        Me.name_box.Name = "name_box"
        Me.name_box.Size = New System.Drawing.Size(296, 22)
        Me.name_box.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label9.Location = New System.Drawing.Point(30, 469)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 29)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Email"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label8.Location = New System.Drawing.Point(30, 521)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 29)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label7.Location = New System.Drawing.Point(30, 570)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 29)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Confirm"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label6.Location = New System.Drawing.Point(30, 634)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 29)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Addres"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label5.Location = New System.Drawing.Point(572, 421)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(176, 29)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Phone Number"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label11.Location = New System.Drawing.Point(572, 475)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 29)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Date Of Birth"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label12.Location = New System.Drawing.Point(572, 539)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 29)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "Position"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Label13.Location = New System.Drawing.Point(30, 414)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 29)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "Name"
        '
        'reset_btn
        '
        Me.reset_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.reset_btn.Location = New System.Drawing.Point(788, 646)
        Me.reset_btn.Name = "reset_btn"
        Me.reset_btn.Size = New System.Drawing.Size(97, 35)
        Me.reset_btn.TabIndex = 39
        Me.reset_btn.Text = "Reset"
        Me.reset_btn.UseVisualStyleBackColor = True
        '
        'submit_btn
        '
        Me.submit_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.submit_btn.Location = New System.Drawing.Point(972, 646)
        Me.submit_btn.Name = "submit_btn"
        Me.submit_btn.Size = New System.Drawing.Size(97, 35)
        Me.submit_btn.TabIndex = 38
        Me.submit_btn.Text = "Submit"
        Me.submit_btn.UseVisualStyleBackColor = True
        '
        'Manage_Employee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.MediumAquamarine
        Me.ClientSize = New System.Drawing.Size(1191, 762)
        Me.Controls.Add(Me.reset_btn)
        Me.Controls.Add(Me.submit_btn)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.salary_box)
        Me.Controls.Add(Me.phone_box)
        Me.Controls.Add(Me.confirm_box)
        Me.Controls.Add(Me.password_box)
        Me.Controls.Add(Me.email_box)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.name_box)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.datagrid_view)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Name = "Manage_Employee"
        Me.Text = "Manage Employee"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.datagrid_view, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LaundryDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LaundryDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents datagrid_view As DataGridView
    Friend WithEvents LaundryDataSetBindingSource As BindingSource
    Friend WithEvents LaundryDataSet As LaundryDataSet
    Friend WithEvents search_box As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents salary_box As TextBox
    Friend WithEvents phone_box As TextBox
    Friend WithEvents confirm_box As TextBox
    Friend WithEvents password_box As TextBox
    Friend WithEvents email_box As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents name_box As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents reset_btn As Button
    Friend WithEvents submit_btn As Button
End Class
