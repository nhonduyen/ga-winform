<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblMainTitle = New System.Windows.Forms.Label()
        Me.btnXuatkho = New System.Windows.Forms.Button()
        Me.lblThongtinTaikhoan = New System.Windows.Forms.Label()
        Me.btnNhapkho = New System.Windows.Forms.Button()
        Me.btnScrap = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMainTitle
        '
        Me.lblMainTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(151, Byte), Integer))
        Me.lblMainTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMainTitle.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainTitle.ForeColor = System.Drawing.Color.White
        Me.lblMainTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblMainTitle.Location = New System.Drawing.Point(116, 1)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(1023, 42)
        Me.lblMainTitle.TabIndex = 64
        Me.lblMainTitle.Text = "GA MANAGEMENT"
        Me.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnXuatkho
        '
        Me.btnXuatkho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnXuatkho.Location = New System.Drawing.Point(505, 504)
        Me.btnXuatkho.Name = "btnXuatkho"
        Me.btnXuatkho.Size = New System.Drawing.Size(130, 43)
        Me.btnXuatkho.TabIndex = 67
        Me.btnXuatkho.Text = "XUẤT KHO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "THÀNH PHẨM"
        Me.btnXuatkho.UseVisualStyleBackColor = True
        '
        'lblThongtinTaikhoan
        '
        Me.lblThongtinTaikhoan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblThongtinTaikhoan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblThongtinTaikhoan.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThongtinTaikhoan.ForeColor = System.Drawing.Color.Black
        Me.lblThongtinTaikhoan.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblThongtinTaikhoan.Location = New System.Drawing.Point(1, 1)
        Me.lblThongtinTaikhoan.Name = "lblThongtinTaikhoan"
        Me.lblThongtinTaikhoan.Size = New System.Drawing.Size(118, 42)
        Me.lblThongtinTaikhoan.TabIndex = 72
        Me.lblThongtinTaikhoan.Text = "Tai khoản"
        '
        'btnNhapkho
        '
        Me.btnNhapkho.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNhapkho.Location = New System.Drawing.Point(376, 504)
        Me.btnNhapkho.Name = "btnNhapkho"
        Me.btnNhapkho.Size = New System.Drawing.Size(130, 43)
        Me.btnNhapkho.TabIndex = 75
        Me.btnNhapkho.Text = "NHẬP KHO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NGUYÊN LIỆU"
        Me.btnNhapkho.UseVisualStyleBackColor = True
        '
        'btnScrap
        '
        Me.btnScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScrap.Location = New System.Drawing.Point(634, 504)
        Me.btnScrap.Name = "btnScrap"
        Me.btnScrap.Size = New System.Drawing.Size(130, 43)
        Me.btnScrap.TabIndex = 77
        Me.btnScrap.Text = "NHẬP XUẤT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SCRAP"
        Me.btnScrap.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1, 504)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(376, 43)
        Me.Button1.TabIndex = 79
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(763, 504)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(371, 43)
        Me.Button2.TabIndex = 80
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(1136, 549)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnScrap)
        Me.Controls.Add(Me.btnNhapkho)
        Me.Controls.Add(Me.lblThongtinTaikhoan)
        Me.Controls.Add(Me.btnXuatkho)
        Me.Controls.Add(Me.lblMainTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PC"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lblMainTitle As System.Windows.Forms.Label
    Friend WithEvents btnXuatkho As System.Windows.Forms.Button
    Public WithEvents lblThongtinTaikhoan As System.Windows.Forms.Label
    Friend WithEvents btnNhapkho As System.Windows.Forms.Button
    Friend WithEvents btnScrap As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
