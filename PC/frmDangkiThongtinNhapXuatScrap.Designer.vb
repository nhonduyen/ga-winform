<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDangkiThongtinNhapXuatScrap
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtManhanvien = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOrder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTenkhachhang = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLoaiThep = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txKhoiluongOrder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtGhichu = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 36)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Nhân viên " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "nhập báo cáo"
        '
        'txtManhanvien
        '
        Me.txtManhanvien.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManhanvien.Location = New System.Drawing.Point(167, 50)
        Me.txtManhanvien.Name = "txtManhanvien"
        Me.txtManhanvien.ReadOnly = True
        Me.txtManhanvien.Size = New System.Drawing.Size(221, 24)
        Me.txtManhanvien.TabIndex = 132
        Me.txtManhanvien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 18)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Số Order"
        '
        'txtOrder
        '
        Me.txtOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrder.Location = New System.Drawing.Point(167, 144)
        Me.txtOrder.Name = "txtOrder"
        Me.txtOrder.ReadOnly = True
        Me.txtOrder.Size = New System.Drawing.Size(221, 24)
        Me.txtOrder.TabIndex = 134
        Me.txtOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 18)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Tên khách hàng"
        '
        'txtTenkhachhang
        '
        Me.txtTenkhachhang.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTenkhachhang.Location = New System.Drawing.Point(167, 191)
        Me.txtTenkhachhang.Name = "txtTenkhachhang"
        Me.txtTenkhachhang.Size = New System.Drawing.Size(221, 24)
        Me.txtTenkhachhang.TabIndex = 136
        Me.txtTenkhachhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(34, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 18)
        Me.Label3.TabIndex = 137
        Me.Label3.Text = "Loại thép"
        '
        'txtLoaiThep
        '
        Me.txtLoaiThep.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLoaiThep.Location = New System.Drawing.Point(167, 238)
        Me.txtLoaiThep.Name = "txtLoaiThep"
        Me.txtLoaiThep.Size = New System.Drawing.Size(221, 24)
        Me.txtLoaiThep.TabIndex = 138
        Me.txtLoaiThep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 288)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 18)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "KL order"
        '
        'txKhoiluongOrder
        '
        Me.txKhoiluongOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txKhoiluongOrder.Location = New System.Drawing.Point(167, 285)
        Me.txKhoiluongOrder.Name = "txKhoiluongOrder"
        Me.txKhoiluongOrder.Size = New System.Drawing.Size(221, 24)
        Me.txKhoiluongOrder.TabIndex = 140
        Me.txKhoiluongOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(426, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 18)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Ghi chú"
        '
        'txtGhichu
        '
        Me.txtGhichu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGhichu.Location = New System.Drawing.Point(528, 147)
        Me.txtGhichu.Multiline = True
        Me.txtGhichu.Name = "txtGhichu"
        Me.txtGhichu.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtGhichu.Size = New System.Drawing.Size(221, 162)
        Me.txtGhichu.TabIndex = 142
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(407, 341)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(117, 53)
        Me.btnCancel.TabIndex = 148
        Me.btnCancel.Text = "HỦY BỎ"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(264, 341)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 53)
        Me.btnSave.TabIndex = 147
        Me.btnSave.Text = "LƯU"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmDangkiThongtinNhapXuatScrap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(784, 425)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtGhichu)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txKhoiluongOrder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLoaiThep)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTenkhachhang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOrder)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtManhanvien)
        Me.MaximizeBox = False
        Me.Name = "frmDangkiThongtinNhapXuatScrap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Đăng kí thông tin Nhập Xuất Scrap"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtManhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTenkhachhang As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLoaiThep As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txKhoiluongOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtGhichu As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
