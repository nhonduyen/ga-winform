Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.IO
Imports System.Diagnostics
Imports Excel = Microsoft.Office.Interop.Excel
Imports System
Public Class frmNhapKhoNguyenLieu
    Dim count1 As Integer = 0

    Dim T As Integer  'Page Count
    Dim k1 As Integer 'Get the Remainder  of the show ending the top of the list for the number of variables
    Dim g1 As Integer = 0 'By comparing the end of the event would show the number of clicks to obtain shares Wed
    Dim index As Integer = 0  'Show the number of list 


    Dim strExcel As String = "Select *  FROM [Sheet2$] "
    Dim dbtables As New DataTable
    Dim strWhere As String = "Select *  FROM [Sheet1$] " '  ORDER BY CoilID DESC
    Dim dbTable As New DataTable

    Dim ExcelApp As Microsoft.Office.Interop.Excel.Application
    Dim ExcelBook1 As Microsoft.Office.Interop.Excel.Workbook
    Dim ExcelSheet1 As Microsoft.Office.Interop.Excel.Worksheet
    Dim ExcelSheet2 As Microsoft.Office.Interop.Excel.Worksheet


    Dim ExcelBook As Microsoft.Office.Interop.Excel.Workbook
    Dim ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet

    Dim dt As New DataTable

    '-----------------------------------------

    Dim soCoil As Integer = 0

    Dim nRowClick As Integer = 0
    Dim nSeqNo As Integer

    Dim count As Integer = 0
    Dim sql As String = "" ' Query
    Dim ds As Data.DataSet 'DataSet 
    Dim r As DataRow 'Column
    Dim hWnd As Integer
    '-----------------------------------------
    ' Set a specified window's show state 
    <DllImport("User32")> Private Shared Function ShowWindow(ByVal hwnd As Integer, ByVal nCmdShow As Integer) As Integer
    End Function
    Private Sub frmNhapKhoNguyenLieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerTo.Value = Now
        DateTimePickerFrom.Value = Now
        Dim nI As Integer = 0
        Dim model As New SourceGrid2.VisualModels.Header

        Dim title() As String = {"Số" + vbLf + "thứ tự", "Mã vào cổng", "Thời gian" + vbLf + "vào cổng", "Nhà cung cấp",
                                 "Mã nguyên liệu", "Chủng loại", "Bề mặt", "Độ dầy", "Độ rộng", "Khối lượng thực", "Khối lượng gộp",
                                 "Số lượng coil", "Số xe/" + vbLf + "Số container", "Ngày giao hàng", "Tình trạng hàng", "Mã" +
                                 vbLf + "nhân viên", "Chấp Thuận", "Ghi chú", "Trạng Thái"}


        model.BackColor = Color.CornflowerBlue         'Cell Color Change 
        model.ForeColor = Color.Black           'Change font
        model.Font = New Font("Arial", 9.75, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center


        'Show Items

        Grid_NhapKho.BorderStyle = BorderStyle.FixedSingle
        Grid_NhapKho.Redim(1, 19)

        Grid_NhapKho.Rows(0).AutoSizeMode = SourceGrid2.AutoSizeMode.None
        Grid_NhapKho.Rows(0).Height = 40


        'Show Items
        For nI = 0 To 18
            Grid_NhapKho(0, nI) = New SourceGrid2.Cells.Real.ColumnHeader(title(nI), Style.visualColHeader, SourceGrid2.BehaviorModels.ColumnHeader.NoSortNoResizeHeader)
        Next
        Grid_NhapKho.Columns(0).Width = 55
        Grid_NhapKho.Columns(1).Width = 100
        Grid_NhapKho.Columns(2).Width = 150
        Grid_NhapKho.Columns(3).Width = 0
        Grid_NhapKho.Columns(4).Width = 200
        Grid_NhapKho.Columns(5).Width = 100
        Grid_NhapKho.Columns(6).Width = 0
        Grid_NhapKho.Columns(7).Width = 90
        Grid_NhapKho.Columns(8).Width = 90
        Grid_NhapKho.Columns(9).Width = 130
        Grid_NhapKho.Columns(10).Width = 0
        Grid_NhapKho.Columns(11).Width = 0
        Grid_NhapKho.Columns(12).Width = 0
        Grid_NhapKho.Columns(13).Width = 0
        Grid_NhapKho.Columns(14).Width = 0
        Grid_NhapKho.Columns(15).Width = 110
        Grid_NhapKho.Columns(16).Width = 0
        Grid_NhapKho.Columns(17).Width = 130
        Grid_NhapKho.Columns(18).Width = 100

        For nI = 0 To 18
            Grid_NhapKho(0, nI).VisualModel = model
        Next

        count = ut.Init(1, 10, 18, False, Me.Grid_NhapKho)
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        LoadData()
    End Sub
    Private Sub LoadData()
        Dim i As Integer = 0
        Dim l As Integer = 0
        Dim sql As String = "" ' Query 

        Dim sql1 As String = ""
        Dim ds1 As Data.DataSet 'DataSet 
        Dim r1 As DataRow 'Column
        Dim countMaterial As Integer = 0

        Dim stringTest As String = ""
        Dim stringTitle As String = ""
        strFilePath = OpenFile()
        If strFilePath = "" Then
            Return
        End If
        Dim countRow As Integer = 0
        Dim listMaterial As New List(Of String)
        Dim countUpthanhcong As Integer = 0
        Dim countUpkothanhcong As Integer = 0
        If MessageBox.Show("Bạn có muốn Load file Excel?", "Load Excel file", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            frmXacnhanthoigian.ShowDialog()
            If checkClick = True Then
                ExcelApp = CreateObject("Excel.Application")
                ExcelBook = ExcelApp.Workbooks.Open(strFilePath)
                ExcelSheet = ExcelBook.Worksheets(1)
                ExcelApp.Visible = False
                stringTitle = ExcelSheet.Cells._Default(1, 4).Value

                If stringTitle <> "Material No" Then
                    MessageBox.Show("Đây không phải là form Nhập kho nguyên liệu", "Cảnh báo!")
                    Exit Sub
                End If


                For i = 2 To 1000
                    stringTest = ExcelSheet.Cells._Default(i, 2).Value
                    If stringTest Is Nothing Then
                        Exit For
                    End If
                    If stringTest.Count > 0 Then
                        countRow = i
                    End If
                Next

                For l = 2 To countRow
                    listMaterial.Add(ExcelSheet.Cells._Default(l, 3).Value)
                Next

                For j As Integer = 2 To countRow

                    sql1 = "select * from TB_NHAPKHO where czMaNguyenLieu  = '" + listMaterial(j - 2) + "'"
                    ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
                    countMaterial = ds1.Tables(0).Rows.Count

                    If countMaterial = 0 Then
                        countUpthanhcong = countUpthanhcong + 1
                        Dim czOrderNo As String = ExcelSheet.Cells._Default(j, 2).Value
                        Dim czMaNguyenLieu As String = ExcelSheet.Cells._Default(j, 3).Value
                        Dim czProductionDate As String = ExcelSheet.Cells._Default(j, 11).Value


                        Dim czChungloai As String = ExcelSheet.Cells._Default(j, 5).Value
                        Dim czDoday As String = ExcelSheet.Cells._Default(j, 6).Value
                        Dim czRong As String = ExcelSheet.Cells._Default(j, 7).Value
                        Dim czkhoiluongthuc As String = CType(ExcelSheet.Cells._Default(j, 8).Value.ToString.Trim, Integer)
                        Dim czGhichu As String = ExcelSheet.Cells._Default(j, 12).Value
                        Dim czNgayImport As String = xacnhanthoigian
                        Dim _nPrimUID As Integer = CType(CreatenPrimUID(), Integer)
                        sql = "insert into TB_NHAPKHO (nPrimUID, czOrderNo, czMaNguyenLieu, czProductionDate, czChungloai, czDoDay, czChieuRong, czKhoiLuongthuc, czGhichu, czNgayImport, czManhanvien, czTrangThai) values (" & _
                        _nPrimUID & _
                        ", '" + czOrderNo + _
                        "', '" + czMaNguyenLieu + _
                        "', '" + czProductionDate + _
                        "', '" + czChungloai + _
                        "', '" + czDoday + _
                        "', '" + czRong + _
                        "', " & czkhoiluongthuc & _
                        ", '" + czGhichu + _
                        "', '" + czNgayImport + _
                        "', '" + cztaikhoan + _
                        "', N'Chưa nhập')"
                        CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                    Else
                        countUpkothanhcong = countUpkothanhcong + 1
                    End If
                Next
            End If
            checkClick = False

        End If
        MessageBox.Show("Load file Excel thành công!!!" + vbLf + " + Thành công: " + countUpthanhcong.ToString + "(Coils)" + vbLf + " + Không thành công: " + countUpkothanhcong.ToString + "(Coils) (Lí do: Coil đã có trên hệ thống)")
    End Sub
    Public Function OpenFile() As String
        Dim strName = ""

        OpenFileDialog1.Filter = "File Excel (*.xlsx)|*.xlsx|File Excel (*.xls)|*.xls"

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            strName = OpenFileDialog1.FileName
        Else

        End If
        Return strName
    End Function
    Function CreatenPrimUID() As Integer
        Dim sql As String = "" ' Query
        Dim ds As Data.DataSet 'DataSet 
        Dim r As DataRow 'Column
        Dim nPrimUID As Integer = 0
        Dim takeSeq As Integer = 0
        Dim Seq As String = ""
        Dim count As Integer

        Dim year As String = Now.Year.ToString.Substring(2, 2)

        Dim month As String = Now.Month.ToString
        If Now.Month.ToString.Length = 1 Then
            month = "0" + month
        End If

        Dim day As String = Now.Day.ToString
        If Now.Day.ToString.Length = 1 Then
            day = "0" + day
        End If

        sql = "select top 1 *  from  TB_NHAPKHO where nPrimUID like '" + year + month + day + "%' order by  nPrimUID desc"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet   
        count = ds.Tables(0).Rows.Count

        If count = 0 Then
            nPrimUID = CType(year + month + day + "001", Integer)
        Else
            r = ds.Tables(0).Rows(0)
            nPrimUID = CType(r("nPrimUID"), Integer)
            takeSeq = CType(nPrimUID.ToString.Substring(6, 3), Integer)
            takeSeq = takeSeq + 1

            If takeSeq.ToString.Length = 1 Then
                Seq = "00" + takeSeq.ToString
            End If
            If takeSeq.ToString.Length = 2 Then
                Seq = "0" + takeSeq.ToString
            End If
            If takeSeq.ToString.Length = 3 Then
                Seq = takeSeq.ToString
            End If
            nPrimUID = CType(year + month + day + Seq, Integer)
        End If
        Return nPrimUID
    End Function

    Private Sub timerNhapkho_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerNhapkho.Tick
        Real_ReSet()
        SetColor()
    End Sub
    Private Sub SetColor()
        Dim model As New SourceGrid2.VisualModels.Header
        model.BackColor = Color.White         'Cell Color Change 
        model.ForeColor = Color.Black           'Change font
        model.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model1 As New SourceGrid2.VisualModels.Header
        model1.BackColor = Color.White         'Cell Color Change 
        model1.ForeColor = Color.Blue           'Change font
        model1.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        'Grid  FONT BACKCOLOR FORECOLOR Active Window
        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.LightGray  'Cell Color Change 
        model2.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model3 As New SourceGrid2.VisualModels.Header
        model3.BackColor = Color.White         'Cell Color Change       
        model1.ForeColor = Color.Black           'Change font
        model1.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model4 As New SourceGrid2.VisualModels.Header
        model4.BackColor = Color.PaleGreen         'Cell Color Change 
        model4.ForeColor = Color.DarkBlue           'Change font
        model4.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model4.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim modelClick As New SourceGrid2.VisualModels.Header
        modelClick.BackColor = Color.Orange      'Cell Color Change 
        modelClick.ForeColor = Color.Black       'Font Color Change
        modelClick.Font = New Font("Arial", 11, FontStyle.Bold) 'Size Style Change
        modelClick.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center


        For nJ = 1 To 10 'nJ=0->header
            Grid_NhapKho(nJ, 0).VisualModel = model2
        Next
        For i As Integer = 1 To 10
            For j As Integer = 1 To 18
                Try
                    If Grid_NhapKho(i, 0).Value.ToString.Trim = "" Then
                        Grid_NhapKho(i, j).VisualModel = model3
                        Grid_NhapKho(i, 0).VisualModel = model2
                    End If
                    If i = nRowClick And Grid_NhapKho(i, 0).Value.ToString.Trim <> "" Then

                        For cot As Integer = 0 To 18
                            Grid_NhapKho(nRowClick, cot).VisualModel = modelClick
                        Next
                    ElseIf i <> nRowClick And Grid_NhapKho(i, 0).Value.ToString.Trim <> "" And Grid_NhapKho(i, 18).Value.ToString.Trim = "Chưa nhập" Then

                        If j = 1 Then
                            Grid_NhapKho(i, j).VisualModel = model1
                        Else
                            Grid_NhapKho(i, j).VisualModel = model
                        End If
                    ElseIf i <> nRowClick And Grid_NhapKho(i, 18).Value = "Đã nhập" Then
                        Grid_NhapKho(i, j).VisualModel = model4
                    ElseIf i <> nRowClick And Grid_NhapKho(i, 0).Value.ToString.Trim = "" Then
                        Grid_NhapKho(i, j).VisualModel = model3
                    End If
                Catch ex As Exception

                End Try


            Next
        Next
    End Sub
    Private Sub Real_ReSet()
        If g1 > T Then
            Exit Sub
        Else
            ReSet()
            T = (count1 \ 10)
            If count1 = 10 Then
                T = 0
            End If
            k1 = (count1 Mod 10)
            If count1 = 10 Then
                k1 = 10
            End If
            If g1 < T And count >= 10 Then
                NextPage()
            Else
                NextPageLast()
            End If
        End If
    End Sub
    Private Sub ReSet()
        Dim page As Integer = 0
        Dim sql1 As String = ""
        Dim ds1 As DataSet
        Dim countA As Integer = 0
        Dim a As TimeSpan = DateTimePickerTo.Value - DateTimePickerFrom.Value
        'sql = "select * from TB_NHAPKHO where (czThoiGianNhap>= '" + dateFrom.Value.ToString.Replace("-", "").Substring(0, 8) + "0000' and czThoiGianNhap <= '" + dateTo.Value.ToString.Replace("-", "").Substring(0, 8) + "2359') order by nPrimUID desc"

        If txtInput.Text.Trim = "" Then
            sql = "select * from TB_NHAPKHO where"
            For i As Integer = 0 To a.Days
                sql = sql + " czNgayImport like '" + DateTimePickerFrom.Value.AddDays(i).ToString.Substring(0, 10) + "%' or "
            Next
            sql = sql.Substring(0, sql.Length - 4)
        Else
            sql = "select * from TB_NHAPKHO where czMaNguyenLieu like '%" + txtInput.Text.Trim + "%'"
        End If

        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count
        count1 = count

        If count Mod 10 = 0 Then
            page = count \ 10
        Else
            page = (count \ 10) + 1
        End If

        If page = 0 And g1 = 0 Then
            lblTranghientai.Text = "(0/0)"
        Else
            lblTranghientai.Text = "(" + (g1 + 1).ToString + "/" + page.ToString + ")"
        End If
    End Sub
    Private Sub SCHDisplay(ByVal nI As Integer)
        Dim nJ As Integer = 0
        Dim model As New SourceGrid2.VisualModels.Header
        model.BackColor = Color.LightGray  'Cell Color Change 
        model.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model1 As New SourceGrid2.VisualModels.Header
        model1.BackColor = Color.White      'Cell Color Change 
        model1.ForeColor = Color.Blue       'Font Color Change
        model1.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        'Grid  FONT BACKCOLOR FORECOLOR Active Window
        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.White      'Cell Color Change 
        model2.ForeColor = Color.Black
        model2.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        'Grid  FONT BACKCOLOR FORECOLOR Active Window
        Dim model3 As New SourceGrid2.VisualModels.Header
        model3.BackColor = Color.White      'Cell Color Change 
        model3.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model3.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center       

        Dim model4 As New SourceGrid2.VisualModels.Header
        model4.BackColor = Color.Orange  'Cell Color Change 
        model4.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model4.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        r = ds.Tables(0).Rows(nI + (index - 1))
        Grid_Nhapkho(nI, 0).Value = ""
        Grid_NhapKho(nI, 1).Value = r("nPrimUID").ToString.Trim

        If r("czThoiGianNhap").ToString.Trim <> "" Then
            Grid_NhapKho(nI, 2).Value = r("czThoiGianNhap").ToString.Trim.Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":")
        Else
            Grid_NhapKho(nI, 2).Value = r("czThoiGianNhap").ToString.Trim
        End If

        Grid_Nhapkho(nI, 3).Value = r("czNhaCungCap").ToString.Trim
        Grid_Nhapkho(nI, 4).Value = r("czMaNguyenLieu").ToString.Trim
        Grid_Nhapkho(nI, 5).Value = r("czChungloai").ToString.Trim
        Grid_Nhapkho(nI, 6).Value = r("czBeMat").ToString.Trim
        Grid_Nhapkho(nI, 7).Value = r("czDoDay").ToString.Trim
        Grid_Nhapkho(nI, 8).Value = r("czChieuRong").ToString.Trim
        Grid_Nhapkho(nI, 9).Value = r("czKhoiLuongthuc").ToString.Trim
        Grid_Nhapkho(nI, 10).Value = r("czKhoiLuongGop").ToString.Trim
        Grid_Nhapkho(nI, 11).Value = r("czSoLuongCoil").ToString.Trim
        Grid_Nhapkho(nI, 12).Value = r("czSoContainer").ToString.Trim
        Grid_Nhapkho(nI, 13).Value = r("czNgayGiaoHang").ToString.Trim
        Grid_Nhapkho(nI, 14).Value = r("czTinhTrangHang").ToString.Trim
        Grid_Nhapkho(nI, 15).Value = r("czManhanvien").ToString.Trim
        Grid_Nhapkho(nI, 16).Value = r("czChapThuan").ToString.Trim
        Grid_Nhapkho(nI, 17).Value = r("czGhichu").ToString.Trim
        Grid_Nhapkho(nI, 18).Value = r("czTrangThai").ToString.Trim

        For i As Integer = 1 To 10
            Grid_NhapKho(i, 0).Value = ((g1 * 10) + i).ToString()
        Next

        For nI = 1 To 18
            For nJ = 1 To 10

                If nI = 1 Then
                    Grid_NhapKho(nJ, nI).VisualModel = model1
                Else
                    Grid_NhapKho(nJ, nI).VisualModel = model2
                End If

            Next
        Next
    End Sub
    Private Sub NextPage()
        timerNhapkho.Stop()
        Dim nI As Integer = 0

        For nI = 1 To 10
            SCHDisplay(nI)
        Next
        timerNhapkho.Start()
    End Sub
    Private Sub NextPageLast()
        timerNhapkho.Stop()

        Dim nI As Integer = 0
        For nI = 1 To k1  'Value to Remainder
            SCHDisplay(nI)
        Next
        count = ut.Init2CLICK(k1 + 1, 10, 18, True, Me.Grid_NhapKho) 'Empty Grid Initialize 

        timerNhapkho.Start()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        timerNhapkho.Stop()
        g1 = g1 + 1 'Click Count Get
        If g1 > T Or (g1 = T And k1 = 0) Then
            g1 = g1 - 1  'Click to keep the number
        Else
            index = index + 10  ' Next Page when required to show the next record.
            If g1 < T Then    'Greater than the quotient value ClickCount
                NextPage()
            Else    'Click the quotient value of reclaimed ground like going anymore because there is no Page button to disable the thing
                NextPageLast()
            End If
        End If
        timerNhapkho.Start()
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim na As Integer
        Dim nI As Integer = 0
        Dim nJ As Integer = 0
        timerNhapkho.Stop()
        If g1 > 0 Then
            g1 = g1 - 1
            index = index - 10
        End If
        If count1 >= 10 Then
            na = 10
        Else
            na = count1
        End If
        For nI = 1 To na
            r = ds.Tables(0).Rows(nI + (index - 1))
            Grid_NhapKho(nI, 0).Value = ""
            Grid_NhapKho(nI, 1).Value = r("nPrimUID")
            Grid_NhapKho(nI, 2).Value = r("czThoiGianNhap")
            Grid_NhapKho(nI, 3).Value = r("czNhaCungCap")
            Grid_NhapKho(nI, 4).Value = r("czMaNguyenLieu")
            Grid_NhapKho(nI, 5).Value = r("czChungloai")
            Grid_NhapKho(nI, 6).Value = r("czBeMat")
            Grid_NhapKho(nI, 7).Value = r("czDoDay")
            Grid_NhapKho(nI, 8).Value = r("czChieuRong")
            Grid_NhapKho(nI, 9).Value = r("czKhoiLuongthuc")
            Grid_NhapKho(nI, 10).Value = r("czKhoiLuongGop")
            Grid_NhapKho(nI, 11).Value = r("czSoLuongCoil")
            Grid_NhapKho(nI, 12).Value = r("czSoContainer")
            Grid_NhapKho(nI, 13).Value = r("czNgayGiaoHang")
            Grid_NhapKho(nI, 14).Value = r("czTinhTrangHang")
            Grid_NhapKho(nI, 15).Value = r("czManhanvien")
            Grid_NhapKho(nI, 16).Value = r("czChapThuan")
            Grid_NhapKho(nI, 17).Value = r("czGhichu")
            Grid_NhapKho(nI, 18).Value = r("czTrangThai")
        Next
        For i As Integer = 1 To 10
            Grid_NhapKho(i, 0).Value = ((g1 * 10) + i).ToString()
        Next
        count = ut.Init2CLICK(na + 1, 10, 7, True, Me.Grid_NhapKho) 'Empty Grid Initialize 
        timerNhapkho.Start()
    End Sub

    Private Sub Grid_NhapKho_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grid_NhapKho.DoubleClick
        nprimUID = Grid_NhapKho(Grid_NhapKho.MouseCell.Row, 1).Value.ToString.Trim
        coilID = Grid_NhapKho(Grid_NhapKho.MouseCell.Row, 4).Value.ToString.Trim
        If Grid_NhapKho.MouseCell.Column = 1 And Grid_NhapKho.MouseCell.DisplayText.Length() > 0 And Grid_NhapKho.MouseCell.Row > 0 Then
            frmDangkiThongtinNhapkhoNguyenlieu.Show()
        End If
        If Grid_NhapKho.MouseCell.Column = 4 And Grid_NhapKho.MouseCell.DisplayText.Length() > 0 And Grid_NhapKho.MouseCell.Row > 0 And Grid_NhapKho(Grid_NhapKho.MouseCell.Row, 14).Value.ToString.Trim = "Chưa nhập" Then
            If MessageBox.Show("Bạn có muốn xóa thông tin vừa chọn?" + vbLf + vbLf + "(*) Mã cuộn: " + Grid_NhapKho(Grid_NhapKho.MouseCell.Row, 4).Value.ToString.Trim, " Xác nhận!", MessageBoxButtons.YesNo) = vbYes Then
                sql = "delete TB_XUATKHO where czMaNguyenLieu = '" + Grid_NhapKho(Grid_NhapKho.MouseCell.Row, 4).Value.ToString.Trim + "'"
                CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
            End If
        Else
            If Grid_NhapKho.MouseCell.Column = 4 And Grid_NhapKho.MouseCell.Row > 0 Then
                MessageBox.Show("Coil này đã được nhập kho và không thể xóa trên hệ thống!", "Xác nhận")
            End If
        End If
    End Sub
End Class