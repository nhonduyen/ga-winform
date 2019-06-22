Public Class frmXuatKhoThanhPham
    Dim count1 As Integer = 0

    Dim T As Integer  'Page Count
    Dim k1 As Integer 'Get the Remainder  of the show ending the top of the list for the number of variables
    Dim g1 As Integer = 0 'By comparing the end of the event would show the number of clicks to obtain shares Wed
    Dim index As Integer = 0  'Show the number of list 

    Dim ExcelApp As Microsoft.Office.Interop.Excel.Application
    Dim ExcelBook As Microsoft.Office.Interop.Excel.Workbook
    Dim ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet

    Dim count As Integer = 0
    Dim sql As String = "" ' Query
    Dim ds As Data.DataSet 'DataSet 
    Dim r As DataRow 'Column
    Dim nSeqNo As Integer
    <System.Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> Private Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer

    End Function
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CMgrDataBase.GetInstance().Open("GA")         'DATABASE CONNECT

        Me.Text = "PC - [Tài khoản: " + cztaikhoan + "]"

        dateTo.Value = Now
        dateFrom.Value = Now
        Dim nI As Integer = 0
        Dim model As New SourceGrid2.VisualModels.Header

        Dim title() As String = {"Số" + vbLf + "thứ tự", "Mã vào ra", "Thời gian Order", "Thời gian xuất", "Mã số cuộn" + vbLf + "(Prod no)", "Chủng loại" + vbLf + "(Spec)", "Bề mặt" + vbLf + "(Surface)", "Độ dày" + vbLf + "(Thick)", "Độ rộng" + vbLf + "(Width)", "Chiều dài" + vbLf + "(Length)", "Khối lượng thực" + vbLf + "(Net weight)", "Khối lượng gộp" + vbLf + "(Gross weight)", "Số xe/Số" + vbLf + "(Container)", "Ghi chú" + vbLf + "(Remark)", "Tình trạng", "Nơi xuất", "Số Order", "Tên khách hàng", "Người kiểm tra"}


        model.BackColor = Color.CornflowerBlue         'Cell Color Change 
        model.ForeColor = Color.Black           'Change font
        model.Font = New Font("Arial", 9.75, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center


        'Show Items

        Grid_Xuatkho.BorderStyle = BorderStyle.FixedSingle
        Grid_Xuatkho.Redim(1, 19)

        Grid_Xuatkho.Rows(0).AutoSizeMode = SourceGrid2.AutoSizeMode.None
        Grid_Xuatkho.Rows(0).Height = 40


        'Show Items
        For nI = 0 To 18
            Grid_Xuatkho(0, nI) = New SourceGrid2.Cells.Real.ColumnHeader(title(nI), Style.visualColHeader, SourceGrid2.BehaviorModels.ColumnHeader.NoSortNoResizeHeader)
        Next

        Grid_Xuatkho.Columns(0).Width = 70
        Grid_Xuatkho.Columns(1).Width = 100
        Grid_Xuatkho.Columns(2).Width = 200
        Grid_Xuatkho.Columns(3).Width = 200
        Grid_Xuatkho.Columns(4).Width = 200
        Grid_Xuatkho.Columns(5).Width = 100
        Grid_Xuatkho.Columns(6).Width = 100
        Grid_Xuatkho.Columns(7).Width = 100
        Grid_Xuatkho.Columns(8).Width = 100
        Grid_Xuatkho.Columns(9).Width = 100
        Grid_Xuatkho.Columns(10).Width = 130
        Grid_Xuatkho.Columns(11).Width = 130
        Grid_Xuatkho.Columns(12).Width = 0
        Grid_Xuatkho.Columns(13).Width = 210
        Grid_Xuatkho.Columns(14).Width = 100
        Grid_Xuatkho.Columns(15).Width = 0
        Grid_Xuatkho.Columns(16).Width = 0
        Grid_Xuatkho.Columns(17).Width = 200
        Grid_Xuatkho.Columns(18).Width = 200

        For nI = 0 To 18
            Grid_Xuatkho(0, nI).VisualModel = model
        Next

        count = ut.Init(1, 10, 18, False, Me.Grid_Xuatkho)
    End Sub

    Private Sub dateFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dateFrom.ValueChanged, dateTo.ValueChanged
        Dim datefromInput As String = dateFrom.Value.ToString.Substring(0, 10).Replace("-", "")
        Dim datetoInput As String = dateTo.Value.ToString.Substring(0, 10).Replace("-", "")
        If datefromInput > datetoInput Then
            datefromInput = datetoInput
            dateFrom.Value = dateTo.Value
            Exit Sub
        End If
    End Sub

    Private Sub timerXuatkho_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerXuatkho.Tick
        Real_ReSet()
        SetColor()
    End Sub
    Private Sub SetColor()
        Dim model4 As New SourceGrid2.VisualModels.Header
        model4.BackColor = Color.PaleGreen         'Cell Color Change 
        model4.ForeColor = Color.Blue           'Change font
        model4.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model4.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model As New SourceGrid2.VisualModels.Header
        model.BackColor = Color.LightGray  'Cell Color Change 
        model.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center     

        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.LightGray  'Cell Color Change 
        model2.ForeColor = Color.Red
        model2.Font = New Font("Arial", 9, FontStyle.Bold) 'Size Style Change
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        For i As Integer = 1 To 10
            If Grid_Xuatkho(i, 14).Value.ToString.Trim = "Đã xuất" And Grid_Xuatkho(i, 0).Value.ToString.Trim <> "" Then
                For j As Integer = 1 To 18
                    If j = 0 Then
                        Grid_Xuatkho(i, j).VisualModel = model
                    Else
                        Grid_Xuatkho(i, j).VisualModel = model4
                    End If

                Next
            End If
        Next
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
        Dim sql1 As String = "" ' Query
        Dim ds1 As Data.DataSet 'DataSet 
        Dim count2 As String = 0

        Dim sql3 As String = "" ' Query
        Dim ds3 As Data.DataSet 'DataSet 
        Dim count3 As String = 0

        If txtInput.Text.Trim = "" Then
            sql = "select * from TB_XUATKHO where"
            Dim a As TimeSpan = dateTo.Value - dateFrom.Value

            For i As Integer = 0 To a.Days
                sql = sql + " czNgayimport like '" + dateFrom.Value.AddDays(i).ToString.Substring(0, 10) + "%' or "
            Next

            sql = sql.Substring(0, sql.Length - 4)
        Else
            sql = "select * from TB_XUATKHO where CoilID like '%" + txtInput.Text.Trim + "%'"
        End If

        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        sql3 = sql + " and czTinhtrang = N'Chưa xuất' and CoilID <> 'TOTAL'"
        ds3 = CMgrDataBase.GetInstance().ReturnDataSet(sql3) 'DataSet    
        count3 = ds3.Tables(0).Rows.Count

        sql1 = sql + " and czTinhtrang = N'Đã xuất'"
        ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet    
        count2 = ds1.Tables(0).Rows.Count
        lblDaxuat.Text = "Đã xuất: " + count2.ToString
        Dim tongtinhtrang As Integer = CType(count2, Integer) + CType(count3, Integer)
        lblTotal.Text = "Tổng: " & tongtinhtrang

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
        Grid_Xuatkho(nI, 0).Value = r("nSoThutu")
        Grid_Xuatkho(nI, 1).Value = r("nPrimUID")
        Grid_Xuatkho(nI, 2).Value = r("czNgayOrder")

        If r("czGiora").ToString.Trim <> "" Then
            Grid_Xuatkho(nI, 3).Value = r("czGiora").ToString.Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":")
        Else
            Grid_Xuatkho(nI, 3).Value = ""
        End If

        Grid_Xuatkho(nI, 4).Value = r("CoilID")
        Grid_Xuatkho(nI, 5).Value = r("czChungloai")
        Grid_Xuatkho(nI, 6).Value = r("czBemat")
        Grid_Xuatkho(nI, 7).Value = r("czDoday")
        Grid_Xuatkho(nI, 8).Value = r("czRong")
        Grid_Xuatkho(nI, 9).Value = r("czDai")
        Grid_Xuatkho(nI, 10).Value = r("cznetWeight")
        Grid_Xuatkho(nI, 11).Value = r("czgrossweight")
        Grid_Xuatkho(nI, 12).Value = r("czSoxe")
        Grid_Xuatkho(nI, 13).Value = r("czGhichu")
        Grid_Xuatkho(nI, 14).Value = r("czTinhtrang")
        Grid_Xuatkho(nI, 15).Value = r("czNoixuat")
        Grid_Xuatkho(nI, 16).Value = r("czSoOrder")
        Grid_Xuatkho(nI, 17).Value = r("czTenkhachhang")
        Grid_Xuatkho(nI, 18).Value = r("czManhanvien")


        For i As Integer = 1 To 10
            Grid_Xuatkho(i, 0).Value = ((g1 * 10) + i).ToString()
            If Grid_Xuatkho(i, 4).Value = "TOTAL" Then
                Grid_Xuatkho(i, 0).Value = ""
            End If
        Next

        For nJ = 1 To 10 'nJ=0->header
            Grid_Xuatkho(nJ, 0).VisualModel = model
        Next


        For nI = 1 To 18
            For nJ = 1 To 10

                If nI = 1 Then
                    Grid_Xuatkho(nJ, nI).VisualModel = model1
                Else
                    Grid_Xuatkho(nJ, nI).VisualModel = model2
                End If

            Next
        Next


    End Sub

    Private Sub NextPage()
        timerXuatkho.Stop()
        Dim nI As Integer = 0

        For nI = 1 To 10
            SCHDisplay(nI)
        Next
        timerXuatkho.Start()
    End Sub

    Private Sub NextPageLast()
        timerXuatkho.Stop()

        Dim nI As Integer = 0
        For nI = 1 To k1  'Value to Remainder
            SCHDisplay(nI)
        Next
        count = ut.Init2CLICK(k1 + 1, 10, 18, True, Me.Grid_Xuatkho) 'Empty Grid Initialize 

        timerXuatkho.Start()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        timerXuatkho.Stop()
        g1 = g1 + 1 'Click Count Get

        If g1 > T Or (g1 = T And k1 = 0) Then

            MessageBox.Show("Đây là trang cuối.")
            g1 = g1 - 1  'Click to keep the number
        Else

            index = index + 10  ' Next Page when required to show the next record.

            If g1 < T Then    'Greater than the quotient value ClickCount
                NextPage()

            Else    'Click the quotient value of reclaimed ground like going anymore because there is no Page button to disable the thing
                NextPageLast()
            End If
        End If
        timerXuatkho.Start()
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim nJ As Integer = 0
        Dim na As Integer = 0
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
        If g1 > 0 Then
            g1 = g1 - 1
            index = index - 1
        End If

        If count1 >= 10 Then
            na = 10
        Else
            na = count1
        End If

        For nI = 1 To na
            r = ds.Tables(0).Rows(nI + (index - 1))
            Grid_Xuatkho(nI, 0).Value = r("nSoThutu")
            Grid_Xuatkho(nI, 1).Value = r("nPrimUID")
            Grid_Xuatkho(nI, 2).Value = r("czNgayOrder")

            If r("czGiora").ToString.Trim <> "" Then
                Grid_Xuatkho(nI, 3).Value = r("czGiora").ToString.Insert(4, "-").Insert(7, "-").Insert(10, " ").Insert(13, ":")
            Else
                Grid_Xuatkho(nI, 3).Value = ""
            End If

            Grid_Xuatkho(nI, 4).Value = r("CoilID")
            Grid_Xuatkho(nI, 5).Value = r("czChungloai")
            Grid_Xuatkho(nI, 6).Value = r("czBemat")
            Grid_Xuatkho(nI, 7).Value = r("czDoday")
            Grid_Xuatkho(nI, 8).Value = r("czRong")
            Grid_Xuatkho(nI, 9).Value = r("czDai")
            Grid_Xuatkho(nI, 10).Value = r("cznetWeight")
            Grid_Xuatkho(nI, 11).Value = r("czgrossweight")
            Grid_Xuatkho(nI, 12).Value = r("czSoxe")
            Grid_Xuatkho(nI, 13).Value = r("czGhichu")
            Grid_Xuatkho(nI, 14).Value = r("czTinhtrang")
            Grid_Xuatkho(nI, 15).Value = r("czNoixuat")
            Grid_Xuatkho(nI, 16).Value = r("czSoOrder")
            Grid_Xuatkho(nI, 17).Value = r("czTenkhachhang")
            Grid_Xuatkho(nI, 18).Value = r("czManhanvien")
        Next


        'For i As Integer = 1 To 18
        '    Grid_Xuatkho(i, 0).Value = ((g1 * 18) + i).ToString()
        'Next

        For nJ = 1 To 10 'nJ=0->header
            Grid_Xuatkho(nJ, 0).VisualModel = model
        Next


        For nI = 1 To 18
            For nJ = 1 To 10

                If nI = 1 Then
                    Grid_Xuatkho(nJ, nI).VisualModel = model1
                Else
                    Grid_Xuatkho(nJ, nI).VisualModel = model2
                End If
            Next
        Next
        count = ut.Init2CLICK(na + 1, 10, 18, True, Me.Grid_Xuatkho) 'Empty Grid Initialize 

        If g1 = 0 Then
            MessageBox.Show("Đay là trang đầu tiên.")
        End If
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        LoadData()
    End Sub
    Private Sub LoadData()
        timerXuatkho.Stop()
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
        Dim stringTitle As String = ""
        Dim stringTitle1 As String = ""
        strFilePath = OpenFile()
        If strFilePath = "" Then
            Return
        End If
        Dim countRow As Integer = 0

        If MessageBox.Show("Bạn có muốn Load file Excel?", "Load Excel file", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            frmXacnhanthoigian.ShowDialog()
            lblLoadingDulieu.Visible = True
            If checkClick = True Then

                ExcelApp = CreateObject("Excel.Application")
                ExcelBook = ExcelApp.Workbooks.Open(strFilePath)
                ExcelSheet = ExcelBook.Worksheets(1)
                ExcelApp.Visible = False
                stringTitle = ExcelSheet.Cells._Default(4, 2).Value
                stringTitle1 = ExcelSheet.Cells._Default(4, 3).Value
                If stringTitle <> "Prd.No" And stringTitle1 = "Spec." Then
                    MessageBox.Show("Đây không phải là Form xuất kho thành phẩm", "Cảnh báo!")
                    lblLoadingDulieu.Visible = False
                    Exit Sub
                End If

                For i = 6 To 10000
                    stringTest = ExcelSheet.Cells._Default(i, 2).Value
                    If stringTest Is Nothing Then
                        Exit For
                    End If
                    If stringTest.Count > 0 Then
                        countRow = i
                    End If
                Next

                For l = 6 To countRow
                    listMaterial.Add(ExcelSheet.Cells._Default(l, 2).Value)
                Next

                For j As Integer = 6 To countRow
                    sql1 = "select * from TB_XUATKHO where CoilID  = '" + listMaterial(j - 6) + "'"
                    ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
                    countMaterial = ds1.Tables(0).Rows.Count

                    If countMaterial = 0 Then
                        Dim czCoilNo As String = ExcelSheet.Cells._Default(j, 2).Value
                        Dim czDateHopDong As String = ExcelSheet.Cells._Default(j, 1).Value


                        Dim czChungloai As String = ExcelSheet.Cells._Default(j, 3).Value
                        Dim czBemat As String = ExcelSheet.Cells._Default(j, 4).Value
                        Dim czDoday As String = ExcelSheet.Cells._Default(j, 5).Value
                        Dim czRong As String = ExcelSheet.Cells._Default(j, 6).Value
                        Dim czChieudai As String = ExcelSheet.Cells._Default(j, 7).Value
                        Dim czkhoiluongthuc As String = CType(ExcelSheet.Cells._Default(j, 8).Value.ToString.Trim, Integer)
                        Dim czkhoiluonggop As String = CType(ExcelSheet.Cells._Default(j, 9).Value.ToString.Trim, Integer)
                        Dim czTenkhachhang As String = ExcelSheet.Cells._Default(j, 10).Value
                        Dim czGhichu As String = ExcelSheet.Cells._Default(j, 11).Value

                        sql = "insert into TB_XUATKHO (nPrimUID, CoilID, czChungloai, czBemat, czDoday, czRong, czDai, cznetWeight, czgrossweight, czTenkhachhang, czManhanvien, czTinhtrang, czNgayOrder, czNgayimport) values (" & _
                        CreatenPrimUID() & _
                        ", '" + czCoilNo + _
                        "', '" + czChungloai + _
                        "', '" + czBemat + _
                        "', '" + czDoday + _
                        "', '" + czRong + _
                        "', '" + czChieudai + _
                        "', " & czkhoiluongthuc & _
                        ", " & czkhoiluongthuc & _
                        ", '" + czTenkhachhang + _
                        "', '" + cztaikhoan + _
                        "', N'Chưa xuất', '" + czDateHopDong + "', '" + xacnhanthoigian + "')"
                        CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                        countUpthanhcong = countUpthanhcong + 1
                    Else
                        countUpkothanhcong = countUpkothanhcong + 1
                    End If
                Next
                'kill excel file
                Dim xlApp As Object = CreateObject("Excel.Application")

                'do some work with Excel

                'close any open files

                'get the window handle
                Dim xlHWND As Integer = ExcelApp.Hwnd 'xlApp.hwnd

                'this will have the process ID after call to GetWindowThreadProcessId
                Dim ProcIdXL As Integer = 0

                'get the process ID
                GetWindowThreadProcessId(xlHWND, ProcIdXL)

                'get the process
                Dim xproc As Process = Process.GetProcessById(ProcIdXL)
                xproc.Kill()

                ''Quit Excel
                'xlApp.quit()

                ''Release
                'System.Runtime.InteropServices.Marshal.FinalReleaseComObject(xlApp)

                ''set to nothing
                'xlApp = Nothing

                ''kill the process if still running
                'If Not xproc.HasExited Then
                '    xproc.Kill()
                'End If
                ''---------------
            End If
            checkClick = False
            
        End If
        lblLoadingDulieu.Visible = False
        MessageBox.Show("Load dữ liệu thành công!!!" + vbLf + " + Thành công: " + countUpthanhcong.ToString + "(Coils)" + vbLf + " + Không thành công: " + countUpkothanhcong.ToString + "(Coils) (Lí do: Coi đã có trên hệ thống)")
        timerXuatkho.Start()
    End Sub
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

        sql = "select top 1 *  from  TB_XUATKHO where nPrimUID like '" + year + month + day + "%' order by  nPrimUID desc"
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

    Public Function OpenFile() As String
        Dim strName = ""

        OpenFileDialog1.Filter = "File Excel (*.xlsx)|*.xlsx|File Excel (*.xls)|*.xls"

        If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            strName = OpenFileDialog1.FileName
        Else

        End If
        Return strName
    End Function


    Private Sub Grid_Xuatkho_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grid_Xuatkho.DoubleClick
        nprimUID = Grid_Xuatkho(Grid_Xuatkho.MouseCell.Row, 1).Value.ToString.Trim
        coilID = Grid_Xuatkho(Grid_Xuatkho.MouseCell.Row, 4).Value.ToString.Trim
        If Grid_Xuatkho.MouseCell.Column = 1 And Grid_Xuatkho.MouseCell.DisplayText.Length() > 0 And Grid_Xuatkho.MouseCell.Row > 0 Then
            frmDangkiThongtinXuatkhoThanhpham.Show()
        End If
        If Grid_Xuatkho.MouseCell.Column = 4 And Grid_Xuatkho.MouseCell.DisplayText.Length() > 0 And Grid_Xuatkho.MouseCell.Row > 0 And Grid_Xuatkho(Grid_Xuatkho.MouseCell.Row, 14).Value.ToString.Trim = "Chưa xuất" Then
            If MessageBox.Show("Bạn có muốn xóa thông tin vừa chọn?" + vbLf + vbLf + "(*) Mã cuộn: " + Grid_Xuatkho(Grid_Xuatkho.MouseCell.Row, 4).Value.ToString.Trim, " Xác nhận!", MessageBoxButtons.YesNo) = vbYes Then
                sql = "delete TB_XUATKHO where CoilID = '" + Grid_Xuatkho(Grid_Xuatkho.MouseCell.Row, 4).Value.ToString.Trim + "'"
                CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
            End If
        Else
            If Grid_Xuatkho.MouseCell.Column = 4 And Grid_Xuatkho.MouseCell.Row > 0 Then
                MessageBox.Show("Coil này đã được xuất và không thể xóa trên hệ thống!", "Xác nhận")
            End If
        End If
    End Sub
End Class
