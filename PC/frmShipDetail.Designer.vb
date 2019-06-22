<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrderNo = New System.Windows.Forms.TextBox()
        Me.DataGridkhoiluong = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.OK = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.lblKhoiluongorder = New System.Windows.Forms.Label()
        Me.lblKhoiluongdaxuat = New System.Windows.Forms.Label()
        Me.lblKhoiluongconlai = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBiensoxe = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtKhoiluonggop = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtKhoiluongthuc = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.timePickThoigianvao = New System.Windows.Forms.DateTimePicker()
        Me.txtNgayvao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtKLgop = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtKLConlai = New System.Windows.Forms.TextBox()
        Me.txtKLDaXuat = New System.Windows.Forms.TextBox()
        Me.txtKLOrder = New System.Windows.Forms.TextBox()
        Me.txtMaNhanVien = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.DataGridkhoiluong, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Số hóa đơn"
        '
        'txtOrderNo
        '
        Me.txtOrderNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderNo.Location = New System.Drawing.Point(123, 57)
        Me.txtOrderNo.Name = "txtOrderNo"
        Me.txtOrderNo.ReadOnly = True
        Me.txtOrderNo.Size = New System.Drawing.Size(182, 24)
        Me.txtOrderNo.TabIndex = 1
        Me.txtOrderNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DataGridkhoiluong
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridkhoiluong.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridkhoiluong.ColumnHeadersHeight = 46
        Me.DataGridkhoiluong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DataGridkhoiluong.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column2, Me.Column3, Me.Column4, Me.Column6, Me.Column7, Me.OK})
        Me.DataGridkhoiluong.Enabled = False
        Me.DataGridkhoiluong.Location = New System.Drawing.Point(22, 261)
        Me.DataGridkhoiluong.Name = "DataGridkhoiluong"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridkhoiluong.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridkhoiluong.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridkhoiluong.Size = New System.Drawing.Size(694, 195)
        Me.DataGridkhoiluong.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Số thứ tự"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 50
        '
        'Column5
        '
        DataGridViewCellStyle2.Format = "g"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column5.HeaderText = "Ngày xuất hàng"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 150
        '
        'Column2
        '
        Me.Column2.HeaderText = "Khối lượng thực"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.HeaderText = "Khối lượng gộp"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Biển số xe"
        Me.Column4.Name = "Column4"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Người kiểm tra"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 60
        '
        'Column7
        '
        Me.Column7.HeaderText = "Thao tác"
        Me.Column7.Items.AddRange(New Object() {"Sửa", "Xóa"})
        Me.Column7.Name = "Column7"
        Me.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column7.ToolTipText = "Thao tác"
        '
        'OK
        '
        Me.OK.HeaderText = "Xác nhận"
        Me.OK.Name = "OK"
        Me.OK.Text = "OK"
        Me.OK.Width = 50
        '
        'lblKhoiluongorder
        '
        Me.lblKhoiluongorder.AutoSize = True
        Me.lblKhoiluongorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKhoiluongorder.Location = New System.Drawing.Point(6, 32)
        Me.lblKhoiluongorder.Name = "lblKhoiluongorder"
        Me.lblKhoiluongorder.Size = New System.Drawing.Size(89, 16)
        Me.lblKhoiluongorder.TabIndex = 3
        Me.lblKhoiluongorder.Text = "K.lượng Order"
        '
        'lblKhoiluongdaxuat
        '
        Me.lblKhoiluongdaxuat.AutoSize = True
        Me.lblKhoiluongdaxuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKhoiluongdaxuat.Location = New System.Drawing.Point(6, 65)
        Me.lblKhoiluongdaxuat.Name = "lblKhoiluongdaxuat"
        Me.lblKhoiluongdaxuat.Size = New System.Drawing.Size(104, 32)
        Me.lblKhoiluongdaxuat.TabIndex = 4
        Me.lblKhoiluongdaxuat.Text = "Tổng khối lượng" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "thực đã xuất"
        '
        'lblKhoiluongconlai
        '
        Me.lblKhoiluongconlai.AutoSize = True
        Me.lblKhoiluongconlai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKhoiluongconlai.Location = New System.Drawing.Point(6, 160)
        Me.lblKhoiluongconlai.Name = "lblKhoiluongconlai"
        Me.lblKhoiluongconlai.Size = New System.Drawing.Size(97, 16)
        Me.lblKhoiluongconlai.TabIndex = 5
        Me.lblKhoiluongconlai.Text = "K.lượng còn lại:"
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(183, 476)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(147, 57)
        Me.btnSave.TabIndex = 97
        Me.btnSave.Text = "LƯU" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "THÔNG TIN"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(349, 476)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 57)
        Me.Button1.TabIndex = 98
        Me.Button1.Text = "HỦY"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBiensoxe)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtKhoiluonggop)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtKhoiluongthuc)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.timePickThoigianvao)
        Me.GroupBox1.Controls.Add(Me.txtOrderNo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtNgayvao)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(22, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(321, 228)
        Me.GroupBox1.TabIndex = 99
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin xuất mới"
        '
        'txtBiensoxe
        '
        Me.txtBiensoxe.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBiensoxe.Location = New System.Drawing.Point(123, 184)
        Me.txtBiensoxe.Name = "txtBiensoxe"
        Me.txtBiensoxe.Size = New System.Drawing.Size(182, 24)
        Me.txtBiensoxe.TabIndex = 42
        Me.txtBiensoxe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 191)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 16)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Biển số xe"
        '
        'txtKhoiluonggop
        '
        Me.txtKhoiluonggop.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKhoiluonggop.Location = New System.Drawing.Point(123, 154)
        Me.txtKhoiluonggop.Name = "txtKhoiluonggop"
        Me.txtKhoiluonggop.Size = New System.Drawing.Size(182, 24)
        Me.txtKhoiluonggop.TabIndex = 40
        Me.txtKhoiluonggop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 16)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Khối lượng gộp"
        '
        'txtKhoiluongthuc
        '
        Me.txtKhoiluongthuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKhoiluongthuc.Location = New System.Drawing.Point(123, 124)
        Me.txtKhoiluongthuc.Name = "txtKhoiluongthuc"
        Me.txtKhoiluongthuc.Size = New System.Drawing.Size(182, 24)
        Me.txtKhoiluongthuc.TabIndex = 38
        Me.txtKhoiluongthuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Khối lượng thực"
        '
        'timePickThoigianvao
        '
        Me.timePickThoigianvao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timePickThoigianvao.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.timePickThoigianvao.Location = New System.Drawing.Point(227, 27)
        Me.timePickThoigianvao.Name = "timePickThoigianvao"
        Me.timePickThoigianvao.Size = New System.Drawing.Size(78, 24)
        Me.timePickThoigianvao.TabIndex = 36
        Me.timePickThoigianvao.Value = New Date(2013, 3, 12, 0, 0, 0, 0)
        '
        'txtNgayvao
        '
        Me.txtNgayvao.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNgayvao.Location = New System.Drawing.Point(123, 27)
        Me.txtNgayvao.Name = "txtNgayvao"
        Me.txtNgayvao.ReadOnly = True
        Me.txtNgayvao.Size = New System.Drawing.Size(98, 24)
        Me.txtNgayvao.TabIndex = 35
        Me.txtNgayvao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Thời gian xuất"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKLgop)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtKLConlai)
        Me.GroupBox2.Controls.Add(Me.lblKhoiluongorder)
        Me.GroupBox2.Controls.Add(Me.txtKLDaXuat)
        Me.GroupBox2.Controls.Add(Me.lblKhoiluongdaxuat)
        Me.GroupBox2.Controls.Add(Me.txtKLOrder)
        Me.GroupBox2.Controls.Add(Me.lblKhoiluongconlai)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(398, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(318, 200)
        Me.GroupBox2.TabIndex = 100
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thông tin khối lượng"
        '
        'txtKLgop
        '
        Me.txtKLgop.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKLgop.Location = New System.Drawing.Point(105, 112)
        Me.txtKLgop.Name = "txtKLgop"
        Me.txtKLgop.ReadOnly = True
        Me.txtKLgop.Size = New System.Drawing.Size(196, 24)
        Me.txtKLgop.TabIndex = 49
        Me.txtKLgop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 32)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Tổng khối lượng" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "gộp đã xuất"
        '
        'txtKLConlai
        '
        Me.txtKLConlai.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKLConlai.Location = New System.Drawing.Point(105, 155)
        Me.txtKLConlai.Name = "txtKLConlai"
        Me.txtKLConlai.ReadOnly = True
        Me.txtKLConlai.Size = New System.Drawing.Size(196, 24)
        Me.txtKLConlai.TabIndex = 47
        Me.txtKLConlai.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKLDaXuat
        '
        Me.txtKLDaXuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKLDaXuat.Location = New System.Drawing.Point(105, 69)
        Me.txtKLDaXuat.Name = "txtKLDaXuat"
        Me.txtKLDaXuat.ReadOnly = True
        Me.txtKLDaXuat.Size = New System.Drawing.Size(196, 24)
        Me.txtKLDaXuat.TabIndex = 46
        Me.txtKLDaXuat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtKLOrder
        '
        Me.txtKLOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKLOrder.Location = New System.Drawing.Point(105, 27)
        Me.txtKLOrder.Name = "txtKLOrder"
        Me.txtKLOrder.ReadOnly = True
        Me.txtKLOrder.Size = New System.Drawing.Size(196, 24)
        Me.txtKLOrder.TabIndex = 45
        Me.txtKLOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMaNhanVien
        '
        Me.txtMaNhanVien.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaNhanVien.Location = New System.Drawing.Point(503, 25)
        Me.txtMaNhanVien.Name = "txtMaNhanVien"
        Me.txtMaNhanVien.ReadOnly = True
        Me.txtMaNhanVien.Size = New System.Drawing.Size(196, 24)
        Me.txtMaNhanVien.TabIndex = 49
        Me.txtMaNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(404, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Người kiếm tra"
        '
        'frmShipDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(738, 556)
        Me.Controls.Add(Me.txtMaNhanVien)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.DataGridkhoiluong)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmShipDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiết hóa đơn xuất Scrap"
        CType(Me.DataGridkhoiluong, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents DataGridkhoiluong As System.Windows.Forms.DataGridView
    Friend WithEvents lblKhoiluongorder As System.Windows.Forms.Label
    Friend WithEvents lblKhoiluongdaxuat As System.Windows.Forms.Label
    Friend WithEvents lblKhoiluongconlai As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents timePickThoigianvao As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNgayvao As System.Windows.Forms.TextBox
    Friend WithEvents txtKhoiluonggop As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtKhoiluongthuc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBiensoxe As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtKLConlai As System.Windows.Forms.TextBox
    Friend WithEvents txtKLDaXuat As System.Windows.Forms.TextBox
    Friend WithEvents txtKLOrder As System.Windows.Forms.TextBox
    Friend WithEvents txtMaNhanVien As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents OK As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents txtKLgop As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
