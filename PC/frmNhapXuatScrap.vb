Imports System.Runtime.InteropServices
Imports System.Data.OleDb
Imports System.IO
Imports System.Diagnostics
Imports Excel = Microsoft.Office.Interop.Excel
Imports System

Public Class frmNhapXuatScrap
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
    Private Sub frmNhapXuatScrap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerFrom.Value = Now
        DateTimePickerTo.Value = Now

        Dim nI As Integer = 0
        Dim model As New SourceGrid2.VisualModels.Header

        Dim title() As String = {"Số" + vbLf + "thứ tự", "Số Order", "Tên khách hàng", "Mã khách hàng", "Ngày Order", "Loại thép", "Độ dày" + vbLf + "(mm)", "Độ rộng" + vbLf + "(mm)", "Chiều dài" + vbLf + "(mm)", "Khối lượng" + vbLf + "order", "Tổng khối lượng" + vbLf + "đã xuất", "Khối lượng" + vbLf + "còn lại", "Tình trạng" + vbLf + "(Xuất/Nhập)", "Số lần" + vbLf + "(Xuất/Nhập)", "Người lên" + vbLf + "kế hoạch", "Ghi chú"}


        model.BackColor = Color.CornflowerBlue         'Cell Color Change 
        model.ForeColor = Color.Black           'Change font
        model.Font = New Font("Arial", 9.75, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center


        'Show Items

        Grid_NhapXuatScrap.BorderStyle = BorderStyle.FixedSingle
        Grid_NhapXuatScrap.Redim(1, 16)

        Grid_NhapXuatScrap.Rows(0).AutoSizeMode = SourceGrid2.AutoSizeMode.None
        Grid_NhapXuatScrap.Rows(0).Height = 40


        'Show Items
        For nI = 0 To 15
            Grid_NhapXuatScrap(0, nI) = New SourceGrid2.Cells.Real.ColumnHeader(title(nI), Style.visualColHeader, SourceGrid2.BehaviorModels.ColumnHeader.NoSortNoResizeHeader)
        Next

        Grid_NhapXuatScrap.Columns(0).Width = 60 'so thu tu.
        Grid_NhapXuatScrap.Columns(1).Width = 200 'so order.
        Grid_NhapXuatScrap.Columns(2).Width = 200 'ten khach hang.
        Grid_NhapXuatScrap.Columns(3).Width = 150 'ma khach hang
        Grid_NhapXuatScrap.Columns(4).Width = 100 'ngay order
        Grid_NhapXuatScrap.Columns(5).Width = 100 'loai thep
        Grid_NhapXuatScrap.Columns(6).Width = 0
        Grid_NhapXuatScrap.Columns(7).Width = 0
        Grid_NhapXuatScrap.Columns(8).Width = 0
        Grid_NhapXuatScrap.Columns(9).Width = 100
        Grid_NhapXuatScrap.Columns(10).Width = 130
        Grid_NhapXuatScrap.Columns(11).Width = 130
        Grid_NhapXuatScrap.Columns(12).Width = 130
        Grid_NhapXuatScrap.Columns(13).Width = 130
        Grid_NhapXuatScrap.Columns(14).Width = 100
        Grid_NhapXuatScrap.Columns(15).Width = 200

        For nI = 0 To 15
            Grid_NhapXuatScrap(0, nI).VisualModel = model
        Next
        count = ut.Init(1, 10, 15, False, Me.Grid_NhapXuatScrap)
    End Sub


    Private Sub btnImportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportExcel.Click
        LoadData()
    End Sub

    Public Sub LoadData()
        Dim sql1 As String = ""
        Dim ds1 As Data.DataSet 'DataSet 
        Dim r1 As DataRow 'Column
        Dim countMaterial As Integer = 0
        Dim l As Integer = 0
        Dim listMaterial As New List(Of String)
        Dim countUpthanhcong As Integer = 0
        Dim countUpkothanhcong As Integer = 0

        Dim i As Integer = 0
        Dim sql As String = "" ' Query       
        Dim stringTest As String = ""
        Dim checkTitle As String = ""
        strFilePath = OpenFile()
        If strFilePath = "" Then
            Return
        End If
        Dim countRow As String = 0

        If MessageBox.Show("Bạn có muốn Load file Excel?", "Load Excel file", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            frmXacnhanthoigian.ShowDialog()
            If checkClick = True Then
                ExcelApp = CreateObject("Excel.Application")
                ExcelBook = ExcelApp.Workbooks.Open(strFilePath)
                ExcelSheet = ExcelBook.Worksheets(1)
                ExcelApp.Visible = False
                checkTitle = ExcelSheet.Cells._Default(1, 1).Value

                If checkTitle <> "SET ORDER SCRAP TO SECURIRY SYSTEM" Then
                    MessageBox.Show("Đây không phải là Form scrap", "Cảnh báo")
                    Exit Sub
                End If

                For i = 4 To 1000
                    stringTest = ExcelSheet.Cells._Default(i, 2).Value

                    If stringTest.Count > 1 Then
                        countRow = i
                        Exit For
                    End If
                Next

                For l = 4 To countRow
                    listMaterial.Add(ExcelSheet.Cells._Default(l, 3).Value)
                Next

                For j As Integer = 4 To countRow
                    sql1 = "select * from TB_SCRAP where OrderNo  = '" + listMaterial(j - 4) + "'"
                    ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
                    countMaterial = ds1.Tables(0).Rows.Count


                    If countMaterial = 0 Then
                        Dim DateOrder As String = ExcelSheet.Cells._Default(j, 2).Value
                        Dim OrderNo As String = ExcelSheet.Cells._Default(j, 3).Value
                        Dim czTenkhachhang As String = ExcelSheet.Cells._Default(j, 4).Value
                        Dim czCustomerCode As String = ExcelSheet.Cells._Default(j, 5).Value
                        Dim czQtyOrder As String = ExcelSheet.Cells._Default(j, 6).Value
                        Dim csType As String = ExcelSheet.Cells._Default(j, 7).Value
                        Dim czRemark As String = ExcelSheet.Cells._Default(j, 8).Value


                        sql = "insert into TB_SCRAP (nPrimUID, DateOrder, OrderNo, czTenkhachhang, " + _
                "czCustomerCode, czQtyOrder, csType, czRemark, czManhanvien, czDateImport, czStatus) values (" & _
                    CreatenPrimUID() & _
                   ", '" + DateOrder + _
                   "', '" + OrderNo + _
                   "', '" + czTenkhachhang + _
                   "', '" + czCustomerCode + _
                   "', '" + czQtyOrder + _
                   "', '" + csType + _
                   "', '" + czRemark + _
                   "', '" + cztaikhoan + "', '" + xacnhanthoigian

                        If RadioXuat.Checked = True Then
                            sql = sql + "', N'" + RadioXuat.Text.Trim + "')"
                        Else
                            sql = sql + "', N'" + RadioNhap.Text.Trim + "')"
                        End If

                        CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                        countUpthanhcong = countUpthanhcong + 1
                    Else
                        countUpkothanhcong = countUpkothanhcong + 1
                    End If
                Next
            End If
            checkClick = False
        End If
        MessageBox.Show("Load dữ liệu thành công!!!" + vbLf + " + Thành công: " + countUpthanhcong.ToString + "(Hợp đồng)" + vbLf + " + Không thành công: " + countUpkothanhcong.ToString + "(Hợp đồng) (Lí do: Hợp đồng này đã có trên hệ thống)")
    End Sub

    Function CreatenPrimUID() As Integer
        Dim month As String = Now.Month.ToString
        Dim takeSeq As Integer = 0
        Dim Seq As String = ""
        Dim year As String = Now.Year.ToString.Substring(2, 2)

        If Now.Month.ToString.Length = 1 Then
            month = "0" + month
        End If

        Dim day As String = Now.Day.ToString
        If Now.Day.ToString.Length = 1 Then
            day = "0" + day
        End If
        sql = "select top 1 *  from  TB_SCRAP where nPrimUID like '" + year + month + day + "%'  order by  nPrimUID desc"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet   
        count = ds.Tables(0).Rows.Count
        If count = 0 Then
            nprimUID = CType(year + month + day + "001", Integer)
        Else
            r = ds.Tables(0).Rows(0)
            nprimUID = CType(r("nPrimUID"), Integer)
            takeSeq = CType(nprimUID.ToString.Substring(6, 3), Integer)
            takeSeq = takeSeq + 1

            If takeSeq.ToString.Length = 1 Then
                Seq = "00" + takeSeq.ToString

            ElseIf takeSeq.ToString.Length = 2 Then
                Seq = "0" + takeSeq.ToString
            Else
                Seq = takeSeq.ToString
            End If
            nprimUID = CType(year + month + day + Seq, Integer)
        End If
        Return nprimUID
    End Function

    Public Function OpenFile() As String
        Dim strName = ""

        OpenFileDialog1.Filter = "File Excel (*.xlsx)|*.xlsx|File Excel (*.xls)|*.xls"

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            strName = OpenFileDialog1.FileName
        Else

        End If
        Return strName
    End Function

    Private Sub timerNhapXuatScrap_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerNhapXuatScrap.Tick
        Real_ReSet()
    End Sub

    Private Sub Real_ReSet()
        If g1 > T Then   'Quotient > Page Count
            Exit Sub
        Else
            ReSet()
            T = (count1 \ 10) 'Quotient  Get
            If count1 = 10 Then 'Only One Page, Count = 20 then Quotient = 0
                T = 0
            End If

            k1 = (count1 Mod 10)  'Remainder  Get
            If count1 = 10 Then 'Only One Page Remainder = 20
                k1 = 10
            End If

            If g1 < T And count >= 10 Then    'Greater than the quotient value ClickCount
                NextPage()
            Else
                NextPageLast()
            End If
        End If

    End Sub

    Private Sub ReSet()
        count = 0  'The group, the total number of re-search when Initialize
        Dim nowtime As String = Now.ToString.Replace("-", "").Replace(":", "").Substring(0, 8)
        Dim page As Integer = 0

        If txtInput.Text = "" Then
            sql = "select * from TB_SCRAP where"
            Dim a As TimeSpan = DateTimePickerTo.Value - DateTimePickerFrom.Value

            For i As Integer = 0 To a.Days
                sql = sql + " czDateImport like '" + DateTimePickerFrom.Value.AddDays(i).ToString.Substring(0, 10) + "%' or "
            Next

            sql = sql.Substring(0, sql.Length - 4)



            If cbStatus.Text = "Xuất" Then
                sql = sql + " and czStatus =N'Xuất'"
            ElseIf cbStatus.Text = "Nhập" Then
                sql = sql + " and czStatus =N'Nhập'"
            End If
        Else

            If cbTypeSearch.Text = "Số Order" Then
                sql = "select * from TB_SCRAP where OrderNo like '%" + txtInput.Text.Trim + "%'"
            Else
                sql = "select * from TB_SCRAP where DateOrder like '%" + txtInput.Text.Trim + "%'"
            End If

        End If




        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count
        lblTotal.Text = "Tổng: " + count.ToString
        If count Mod 10 = 0 Then
            page = count \ 10
        Else
            page = (count \ 10) + 1
        End If

        If count = 0 Then
            page = 1
        End If


        lblPageCurrent.Text = "Trang: " + (g1 + 1).ToString + "/" + page.ToString
        count1 = count

    End Sub

    Private Sub SCHDisplay(ByVal nI As Integer)

        Dim nJ As Integer = 0
        'Grid  FONT BACKCOLOR FORECOLOR Active Window
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
        Grid_NhapXuatScrap(nI, 0).Value = ""
        Grid_NhapXuatScrap(nI, 1).Value = r("OrderNo")
        Grid_NhapXuatScrap(nI, 2).Value = r("czTenkhachhang").ToString
        Grid_NhapXuatScrap(nI, 3).Value = r("czCustomerCode")
        Grid_NhapXuatScrap(nI, 4).Value = r("DateOrder")
        Grid_NhapXuatScrap(nI, 5).Value = r("csType")
        Grid_NhapXuatScrap(nI, 6).Value = r("czThick")
        Grid_NhapXuatScrap(nI, 7).Value = r("czWidth")
        Grid_NhapXuatScrap(nI, 8).Value = r("czLength")
        Grid_NhapXuatScrap(nI, 9).Value = r("czQtyOrder")
        Dim tongkhoiluong As Integer = 0
        Dim demlannhapxuat As Integer = r("czChitietxuatScrap").ToString.Trim.Split("|").Count


        If demlannhapxuat > 0 And r("czChitietxuatScrap").ToString.Trim <> "" Then
            For i As Integer = 0 To demlannhapxuat - 1
                For j As Integer = 1 To 5
                    If j = 2 Then
                        tongkhoiluong = tongkhoiluong + CType(r("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                    End If
                Next
            Next
        End If


        Grid_NhapXuatScrap(nI, 10).Value = tongkhoiluong

        If r("czQtyOrder").ToString.Trim <> "" Then
            Grid_NhapXuatScrap(nI, 11).Value = CType(r("czQtyOrder"), Integer) - tongkhoiluong
        End If

        Grid_NhapXuatScrap(nI, 12).Value = r("czStatus")

        If r("czChitietxuatScrap").ToString.Trim = "" Then
            Grid_NhapXuatScrap(nI, 13).Value = 0
        Else
            Grid_NhapXuatScrap(nI, 13).Value = r("czChitietxuatScrap").ToString.Trim.Split("|").Count
        End If

        Grid_NhapXuatScrap(nI, 14).Value = r("czManhanvien")
        Grid_NhapXuatScrap(nI, 15).Value = r("czRemark")


        For i As Integer = 1 To 10
            Grid_NhapXuatScrap(i, 0).Value = ((g1 * 13) + i).ToString()
        Next

        For nJ = 1 To 10 'nJ=0->header
            Grid_NhapXuatScrap(nJ, 0).VisualModel = model
        Next

        For nI = 1 To 15
            For nJ = 1 To 10
                If nI = 1 Then
                    Grid_NhapXuatScrap(nJ, nI).VisualModel = model1
                Else
                    Grid_NhapXuatScrap(nJ, nI).VisualModel = model2
                End If
            Next
        Next

    End Sub

    Private Sub NextPage()
        timerNhapXuatScrap.Stop()
        Dim nI As Integer = 0

        For nI = 1 To 10
            SCHDisplay(nI)
        Next
        timerNhapXuatScrap.Start()
    End Sub

    Private Sub NextPageLast()
        timerNhapXuatScrap.Stop()

        Dim nI As Integer = 0
        For nI = 1 To k1  'Value to Remainder
            SCHDisplay(nI)
        Next
        count = ut.Init2CLICK(k1 + 1, 10, 15, True, Me.Grid_NhapXuatScrap) 'Empty Grid Initialize 

        timerNhapXuatScrap.Start()
    End Sub

    Private Sub Grid_NhapXuatScrap_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grid_NhapXuatScrap.DoubleClick
        timerNhapXuatScrap.Stop()
        Dim _frmShipDetail As New frmShipDetail      
        Dim sql3 As String = ""
        nhapxuathanghoa = True       
        orderno = Grid_NhapXuatScrap(Grid_NhapXuatScrap.MouseCell.Row, 1).Value

       

        If Grid_NhapXuatScrap(Grid_NhapXuatScrap.MouseCell.Row, 9).Value.ToString.Trim <> "" Then
            khoiluongOrder = CType(Grid_NhapXuatScrap(Grid_NhapXuatScrap.MouseCell.Row, 9).Value.ToString.Trim, Integer)
        End If

        If Grid_NhapXuatScrap.MouseCell.Column = 0 And Grid_NhapXuatScrap.MouseCell.DisplayText.Length() > 0 And Grid_NhapXuatScrap.MouseCell.Row > 0 Then
            frmDangkiThongtinNhapXuatScrap.ShowDialog()
        ElseIf Grid_NhapXuatScrap.MouseCell.Column = 1 And Grid_NhapXuatScrap(Grid_NhapXuatScrap.MouseCell.Row, 1).Value.ToString.Trim <> "" And Grid_NhapXuatScrap.MouseCell.Row > 0 Then
            _frmShipDetail.ShowDialog()
        End If
    End Sub
End Class