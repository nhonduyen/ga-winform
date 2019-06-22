<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhapXuatScrap
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.btnDangki = New System.Windows.Forms.Button()
        Me.Grid_NhapXuatScrap = New SourceGrid2.Grid()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.cbTypeSearch = New System.Windows.Forms.ComboBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblPageCurrent = New System.Windows.Forms.Label()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnImportExcel = New System.Windows.Forms.Button()
        Me.timerNhapXuatScrap = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tbExcelFileAddress = New System.Windows.Forms.TextBox()
        Me.RadioNhap = New System.Windows.Forms.RadioButton()
        Me.RadioXuat = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(618, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(108, 37)
        Me.Button1.TabIndex = 114
        Me.Button1.Text = "Merge Cells"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportExcel.Location = New System.Drawing.Point(893, 16)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(108, 37)
        Me.btnExportExcel.TabIndex = 113
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DateTimePickerTo)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.DateTimePickerFrom)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(377, 57)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Thời gian làm việc"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTo.Location = New System.Drawing.Point(245, 19)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(119, 24)
        Me.DateTimePickerTo.TabIndex = 105
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(214, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 18)
        Me.Label1.TabIndex = 94
        Me.Label1.Text = "To"
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(79, 19)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(119, 24)
        Me.DateTimePickerFrom.TabIndex = 104
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 18)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "From"
        '
        'cbStatus
        '
        Me.cbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Items.AddRange(New Object() {"Tất cả", "Nhập", "Xuất"})
        Me.cbStatus.Location = New System.Drawing.Point(408, 24)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(121, 24)
        Me.cbStatus.TabIndex = 111
        Me.cbStatus.Text = "Tất cả"
        '
        'btnDangki
        '
        Me.btnDangki.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDangki.Location = New System.Drawing.Point(1007, 16)
        Me.btnDangki.Name = "btnDangki"
        Me.btnDangki.Size = New System.Drawing.Size(108, 37)
        Me.btnDangki.TabIndex = 110
        Me.btnDangki.Text = "ĐĂNG KÍ"
        Me.btnDangki.UseVisualStyleBackColor = True
        '
        'Grid_NhapXuatScrap
        '
        Me.Grid_NhapXuatScrap.AutoSizeMinHeight = 10
        Me.Grid_NhapXuatScrap.AutoSizeMinWidth = 10
        Me.Grid_NhapXuatScrap.AutoStretchColumnsToFitWidth = False
        Me.Grid_NhapXuatScrap.AutoStretchRowsToFitHeight = False
        Me.Grid_NhapXuatScrap.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None
        Me.Grid_NhapXuatScrap.CustomSort = False
        Me.Grid_NhapXuatScrap.GridToolTipActive = True
        Me.Grid_NhapXuatScrap.Location = New System.Drawing.Point(16, 66)
        Me.Grid_NhapXuatScrap.Name = "Grid_NhapXuatScrap"
        Me.Grid_NhapXuatScrap.Size = New System.Drawing.Size(1099, 329)
        Me.Grid_NhapXuatScrap.SpecialKeys = CType(((((((((((SourceGrid2.GridSpecialKeys.Ctrl_C Or SourceGrid2.GridSpecialKeys.Ctrl_V) _
                    Or SourceGrid2.GridSpecialKeys.Ctrl_X) _
                    Or SourceGrid2.GridSpecialKeys.Delete) _
                    Or SourceGrid2.GridSpecialKeys.Arrows) _
                    Or SourceGrid2.GridSpecialKeys.Tab) _
                    Or SourceGrid2.GridSpecialKeys.PageDownUp) _
                    Or SourceGrid2.GridSpecialKeys.Enter) _
                    Or SourceGrid2.GridSpecialKeys.Escape) _
                    Or SourceGrid2.GridSpecialKeys.Control) _
                    Or SourceGrid2.GridSpecialKeys.Shift), SourceGrid2.GridSpecialKeys)
        Me.Grid_NhapXuatScrap.TabIndex = 115
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtInput)
        Me.GroupBox3.Controls.Add(Me.cbTypeSearch)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(427, 400)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(347, 58)
        Me.GroupBox3.TabIndex = 121
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tìm kiếm"
        '
        'txtInput
        '
        Me.txtInput.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.ForeColor = System.Drawing.Color.DimGray
        Me.txtInput.Location = New System.Drawing.Point(10, 21)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(201, 24)
        Me.txtInput.TabIndex = 21
        Me.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbTypeSearch
        '
        Me.cbTypeSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTypeSearch.FormattingEnabled = True
        Me.cbTypeSearch.Items.AddRange(New Object() {"Số Order", "Ngày Order"})
        Me.cbTypeSearch.Location = New System.Drawing.Point(217, 20)
        Me.cbTypeSearch.Name = "cbTypeSearch"
        Me.cbTypeSearch.Size = New System.Drawing.Size(122, 26)
        Me.cbTypeSearch.TabIndex = 69
        Me.cbTypeSearch.Text = "Số Order"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(820, 415)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(58, 18)
        Me.lblTotal.TabIndex = 119
        Me.lblTotal.Text = "Tổng: 0"
        '
        'lblPageCurrent
        '
        Me.lblPageCurrent.AutoSize = True
        Me.lblPageCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageCurrent.Location = New System.Drawing.Point(820, 433)
        Me.lblPageCurrent.Name = "lblPageCurrent"
        Me.lblPageCurrent.Size = New System.Drawing.Size(84, 18)
        Me.lblPageCurrent.TabIndex = 118
        Me.lblPageCurrent.Text = "(Trang: 0/0)"
        '
        'btnPrev
        '
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Location = New System.Drawing.Point(910, 413)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(101, 37)
        Me.btnPrev.TabIndex = 117
        Me.btnPrev.Text = "Trang sau"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(1017, 413)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(98, 37)
        Me.btnNext.TabIndex = 116
        Me.btnNext.Text = "Trang trước"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnImportExcel
        '
        Me.btnImportExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportExcel.Location = New System.Drawing.Point(228, 13)
        Me.btnImportExcel.Name = "btnImportExcel"
        Me.btnImportExcel.Size = New System.Drawing.Size(108, 37)
        Me.btnImportExcel.TabIndex = 122
        Me.btnImportExcel.Text = "Import Excel"
        Me.btnImportExcel.UseVisualStyleBackColor = True
        '
        'timerNhapXuatScrap
        '
        Me.timerNhapXuatScrap.Enabled = True
        Me.timerNhapXuatScrap.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "File Name"
        '
        'tbExcelFileAddress
        '
        Me.tbExcelFileAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbExcelFileAddress.Location = New System.Drawing.Point(8, 19)
        Me.tbExcelFileAddress.Name = "tbExcelFileAddress"
        Me.tbExcelFileAddress.Size = New System.Drawing.Size(207, 24)
        Me.tbExcelFileAddress.TabIndex = 87
        '
        'RadioNhap
        '
        Me.RadioNhap.AutoSize = True
        Me.RadioNhap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioNhap.Location = New System.Drawing.Point(344, 14)
        Me.RadioNhap.Name = "RadioNhap"
        Me.RadioNhap.Size = New System.Drawing.Size(59, 20)
        Me.RadioNhap.TabIndex = 88
        Me.RadioNhap.Text = "Nhập"
        Me.RadioNhap.UseVisualStyleBackColor = True
        '
        'RadioXuat
        '
        Me.RadioXuat.AutoSize = True
        Me.RadioXuat.Checked = True
        Me.RadioXuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioXuat.Location = New System.Drawing.Point(345, 34)
        Me.RadioXuat.Name = "RadioXuat"
        Me.RadioXuat.Size = New System.Drawing.Size(52, 20)
        Me.RadioXuat.TabIndex = 89
        Me.RadioXuat.TabStop = True
        Me.RadioXuat.Text = "Xuất"
        Me.RadioXuat.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnImportExcel)
        Me.GroupBox1.Controls.Add(Me.RadioXuat)
        Me.GroupBox1.Controls.Add(Me.RadioNhap)
        Me.GroupBox1.Controls.Add(Me.tbExcelFileAddress)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 399)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(405, 57)
        Me.GroupBox1.TabIndex = 120
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tải dữ liệu lên"
        '
        'frmNhapXuatScrap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1131, 461)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblPageCurrent)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.Grid_NhapXuatScrap)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnExportExcel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cbStatus)
        Me.Controls.Add(Me.btnDangki)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 42)
        Me.Name = "frmNhapXuatScrap"
        Me.Text = "frmNhapXuatScrap"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnExportExcel As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePickerTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents btnDangki As System.Windows.Forms.Button
    Friend WithEvents Grid_NhapXuatScrap As SourceGrid2.Grid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents cbTypeSearch As System.Windows.Forms.ComboBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents lblPageCurrent As System.Windows.Forms.Label
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnImportExcel As System.Windows.Forms.Button
    Friend WithEvents timerNhapXuatScrap As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbExcelFileAddress As System.Windows.Forms.TextBox
    Friend WithEvents RadioNhap As System.Windows.Forms.RadioButton
    Friend WithEvents RadioXuat As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
