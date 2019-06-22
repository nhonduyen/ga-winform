' **********************************************************************************************************
'  1. PROJECT  NAME : ZPSS 4 CBL
'  2. FUNCTION NAME :  									
'  3. EXPLAIN       :  
'  4. PROGRAMER     : 																			
'  5. PROGRAM DATE  : 2010.07.06																			
'  6. MODIFY  DATE  :																						
'																										
'     NEM		MODIFY DATE                 MODIFIER                    MODIFY CONTENT											
'     -----------------------------------------------------------------------------------------		
'     1.		2010.07.06		            											
'																										
'																										
'																										
'																										
'     -----------------------------------------------------------------------------------------		
'  7. NOTE          :																						
'																										
'																										
' **********************************************************************************************************
Imports System
Imports System.IO

Public Class CMgrUtility
    'private string TimeNow = "";
    'private string ResultTime = "";
    '
    Public Sub New()
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : 14-digit string of the system returns the current time
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function NowTime() As String
        Return System.DateTime.Now.ToString("yyyyMMddHHmmss")
    End Function


    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : 14-digit string return DateTime type value		
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function ToDBTime(ByVal sysTime As DateTime) As String
        Return sysTime.ToString("yyyyMMddHHmmss")
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''   
    ''' - ARGUMENT : 
    '''   
    ''' - COMMENT  : Enter the current time received from the separate units of a particular time depending on the result, ADD or SUBTRACTION a certain value returns the time
    '''   
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function CalTime(ByVal startTime As String, ByVal gubun As String, ByVal diffTime As Integer) As String
        Dim sYear As Integer = Convert.ToInt32(startTime.Substring(0, 4))
        Dim sMonth As Integer = Convert.ToInt32(startTime.Substring(4, 2))
        Dim sDay As Integer = Convert.ToInt32(startTime.Substring(6, 2))
        Dim sHour As Integer = Convert.ToInt32(startTime.Substring(8, 2))
        Dim sMinute As Integer = Convert.ToInt32(startTime.Substring(10, 2))
        Dim sSecond As Integer = Convert.ToInt32(startTime.Substring(12))

        Dim sTime As New DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond)

        gubun = gubun.ToUpper()
        Select Case gubun
            Case "Y"
                sTime = sTime.AddYears(diffTime)
                Exit Select
            Case "M"

                sTime = sTime.AddMonths(diffTime)
                Exit Select
            Case "D"

                sTime = sTime.AddDays(diffTime)
                Exit Select
            Case "H"

                sTime = sTime.AddHours(diffTime)
                Exit Select
            Case "B"

                sTime = sTime.AddMinutes(diffTime)
                Exit Select
            Case "S"

                sTime = sTime.AddSeconds(diffTime)
                Exit Select
        End Select

        Dim rtnTime As String = sTime.ToString("yyyyMMddHHmmss")

        Return rtnTime
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Change(ByVal cTime As String) As Integer
        Dim cYear As Integer = Convert.ToInt32(cTime.Substring(0, 4))
        Dim cMonth As Integer = Convert.ToInt32(cTime.Substring(4, 2))
        Dim cDay As Integer = Convert.ToInt32(cTime.Substring(6, 2))
        Dim cHour As Integer = Convert.ToInt32(cTime.Substring(8, 2))
        Dim cMinute As Integer = Convert.ToInt32(cTime.Substring(10, 2))
        Dim cSecond As Integer = Convert.ToInt32(cTime.Substring(12))

        If cHour >= 7 And cHour < 15 Then
            Return 1
        ElseIf cHour >= 15 And cHour < 23 Then
            Return 2
        Else
            Return 3
        End If

    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function DiffTime(ByVal cTime As String) As String
        Dim nowTime As String = System.DateTime.Now.ToString("yyyyMMddHHmmss")
        Dim sYear As Integer = Convert.ToInt32(nowTime.Substring(0, 4))
        Dim sMonth As Integer = Convert.ToInt32(nowTime.Substring(4, 2))
        Dim sDay As Integer = Convert.ToInt32(nowTime.Substring(6, 2))
        Dim sHour As Integer = Convert.ToInt32(nowTime.Substring(8, 2))
        Dim sMinute As Integer = Convert.ToInt32(nowTime.Substring(10, 2))
        Dim sSecond As Integer = Convert.ToInt32(nowTime.Substring(12))

        Dim cYear As Integer = Convert.ToInt32(cTime.Substring(0, 4))
        Dim cMonth As Integer = Convert.ToInt32(cTime.Substring(4, 2))
        Dim cDay As Integer = Convert.ToInt32(cTime.Substring(6, 2))
        Dim cHour As Integer = Convert.ToInt32(cTime.Substring(8, 2))
        Dim cMinute As Integer = Convert.ToInt32(cTime.Substring(10, 2))
        Dim cSecond As Integer = Convert.ToInt32(cTime.Substring(12))

        Dim sTime As New DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond)
        Dim eTime As New DateTime(cYear, cMonth, cDay, cHour, cMinute, cSecond)
        Dim a As New Integer

        Dim dfTime As System.TimeSpan = sTime - eTime
        Dim rTime As DateTime = sTime - dfTime

        Return rTime.ToString().Trim()
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub msgboxcheck(ByVal str As String)
        If msgcheck1 Then
            msgcheck1 = False
            msgcheck2 = MessageBox.Show(str)
        End If
        If msgcheck2 Then
            msgcheck2 = False
            msgcheck1 = True
        End If
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : MESSAGE LOG
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub AlarmMsgLog(ByVal strFunction As String, ByVal chType As Char, ByVal strMsg As String)
        Dim sql As String
        'Environment::MachineName


        'sql = "INSERT INTO TB_ALARM (OCCURE_DATETIME, TASK_NAME, MODULE_NAME, TYPE, MSG) VALUES('" + Date.Now + "', 'HMI', '" + strFunction + "','" + chType + "', '" + strMsg + "')"
        sql = "INSERT INTO TB_ALARM (OCCURE_DATETIME, TASK_NAME, MODULE_NAME, TYPE, MSG) VALUES('" + Date.Now + "','" + Environment.MachineName + "', '" + strFunction + "','" + chType + "', '" + strMsg + "')"
        CMgrDataBase.GetInstance().ExecuteNonQuery(sql)
        sql = "UPDATE TB_ALARM_HMI SET OCCURE_DAtETIME='" + Date.Now + "', TASK_NAME = '" + Environment.MachineName + "', MODULE_NAME = '" + strFunction + "' , TYPE = '" + chType + "', MSG ='" + strMsg + _
        "' WHERE SEQ_NO >=0"
        CMgrDataBase.GetInstance().ExecuteNonQuery(sql)
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : EVENT LOG
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub EventLog(ByVal EVENTNUMBER As Integer, ByVal msg As String)
        Dim sql As String
        Dim ds As DataTable
        Dim ttt As Integer

        sql = "select MaxRec = ISNULL(Max(RECNO), 0) + 1 from TB_HmiEvent"  ' NULL then 1 next 2 Plus after Searching
        ds = CMgrDataBase.GetInstance().ReturnDataTable("TB_HMIEVENT", sql)

        ttt = ds.Rows(0).Item(0)

        ' msg = "Name: " + UserName + ", " + msg
        sql = "INSERT INTO TB_HmiEvent(RECNO, EVTNO, MSGBUF, BECOMEDATE) VALUES(" + ttt.ToString + ", '" + CStr(EVENTNUMBER) + "', '" + msg + "', DBO.DBDATE(GETDATE()))"
        CMgrDataBase.GetInstance().ExecuteNonQuery(sql)

    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : DisplayTime
    '''
    ''' - ARGUMENT : String time : DATE DATA OF Character STRING 
    '''
    ''' - COMMENT : Date of Character String(Include Time) return Display Format
    '''
    ''' - RETURN : String / time
    '''
    '''*********************************************************************************************************
    Public Function DisplayTime(ByVal time As String) As String

        Select Case time.Length
            Case 17
                time = Mid(time, 1, 4) & "-" & Mid(time, 5, 2) & "-" & Mid(time, 7, 2) & " " & Mid(time, 9, 2) & _
                        ":" & Mid(time, 11, 2) & ":" & Mid(time, 13, 2) & "." & Mid(time, 15, 3)
            Case 14
                time = Mid(time, 1, 4) & "-" & Mid(time, 5, 2) & "-" & Mid(time, 7, 2) & " " & Mid(time, 9, 2) & _
                        ":" & Mid(time, 11, 2) & ":" & Mid(time, 13, 2)
            Case 8
                time = Mid(time, 1, 4) & "-" & Mid(time, 5, 2) & "-" & Mid(time, 7, 2)

            Case 6
                time = Mid(time, 1, 2) & ":" & Mid(time, 3, 2) & ":" & Mid(time, 5, 2)
        End Select
        Return time
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : On the date shown on the screen to save data in DB by converting each in the form will return.
    '''
    ''' - RETURN   : time
    '''
    '''*********************************************************************************************************
    Public Function NipTime(ByVal time As String) As String
        time = time.Replace("-", "")
        time = time.Replace(":", "")
        time = time.Replace(".", "")
        time = time.Replace(" ", "")
        time = time.Replace("/", "")
        Return time
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : On the date shown on the screen to save data in DB by converting each in the form will return.
    '''
    ''' - RETURN   : Point
    '''
    '''*********************************************************************************************************
    Public Function NipPoint(ByVal Point As String) As String
        Point = Point.Replace(".", "")
        Point = Point.Replace(" ", "")
        Return Point
    End Function


    'Public Sub JinDo(ByVal MTRL_NO As String, ByVal SMP_NO As String, ByVal SMP_SMPLNG_LOC As String, ByVal MTRL_TST_INDT_FG As String, ByVal JINCODE As String, ByVal JINVALUE As String)
    '    Dim sql As String
    '    sql = "update " + GblCommon.TBTESTORDER + " SET " + JINCODE + " = '" + JINVALUE + "' WHERE MTRL_NO = '" + MTRL_NO + "' and SMP_NO = '" _
    '                        + SMP_NO + "' and SMP_SMPLNG_LOC = '" + SMP_SMPLNG_LOC + "' AND MTRL_TST_INDT_FG = '" + _
    '                        MTRL_TST_INDT_FG + "' AND " + JINCODE + " = 'E'"
    '    CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet

    'End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : A function to create a new blank (Create sell functions, decision height)
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Init(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)

        Dim i, j As Integer
        For i = RowStart To RowCount
            grid.Rows.Insert(i)
            grid.Rows(i).AutoSizeMode = SourceGrid2.AutoSizeMode.None
            grid.Rows(i).Height = 27
        Next

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                If j = 0 And Check = True Then
                    grid(i, j) = New SourceGrid2.Cells.Real.CheckBox(False)
                Else
                    grid(i, j) = New SourceGrid2.Cells.Real.Cell
                End If
            Next
        Next
        Return RowCount - 1
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : A function to create a new blank (Create sell functions, decision height)
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Init4(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim i, j As Integer
        For i = RowStart To RowCount
            grid.Rows.Insert(i)
            grid.Rows(i).AutoSizeMode = SourceGrid2.AutoSizeMode.None
            grid.Rows(i).Height = 20
        Next

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                If j = 0 And Check = True Then
                    grid(i, j) = New SourceGrid2.Cells.Real.CheckBox(False)
                Else
                    grid(i, j) = New SourceGrid2.Cells.Real.Cell
                End If
            Next
        Next
        Return RowCount - 1
    End Function

    ''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : If the Value is Null then, Create Blank
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Init2(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim i, j As Integer
        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                'If j = 0 And Check = True Then

                'Else
                grid(i, j).Value = ""
                'End If
            Next
        Next
        Return RowCount - 1
    End Function

    ''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : wherever Create
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Init3(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnStart As Integer, ByVal ColumnCount As Integer, ByVal grid As SourceGrid2.Grid)

        Dim i, j As Integer
        For i = RowStart To RowCount
            grid.Rows(i).AutoSizeMode = SourceGrid2.AutoSizeMode.None
            grid.Rows(i).Height = 43
        Next

        For i = RowStart To RowCount
            For j = ColumnStart To ColumnCount
                grid(i, j) = New SourceGrid2.Cells.Real.Cell()
            Next
        Next
        Return RowCount - 1
    End Function

    Public Function Init2CLICK(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim model1 As New SourceGrid2.VisualModels.Header
        model1.BackColor = Color.LightGray  'CELL COLOR CHANGE
        model1.Font = New Font("Arial", 11, FontStyle.Bold) 'SIZE STYLE CHANGE
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' SIZE CENTER ARRAY

        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.White     'CELL COLOR CHANGE
        model2.Font = New Font("Arial", 11, FontStyle.Bold) 'SIZE STYLE CHANGE
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' SIZE CENTER ARRAY

        Dim i, j As Integer

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                grid(i, j).Value = ""
                If j = 0 Then
                    grid(i, j).VisualModel = model1
                Else
                    grid(i, j).VisualModel = model2
                End If
            Next
        Next
        Return RowCount - 1
    End Function

    Public Function Init2ALARM(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim model1 As New SourceGrid2.VisualModels.Header
        model1.BackColor = Color.White      'Cell Color Change 
        model1.Font = New Font("Arial", 11, FontStyle.Bold) 'Size Style Change
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' Size Center

        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.White      'Cell Color Change 
        model2.Font = New Font("Arial", 11, FontStyle.Bold) 'Size Style Change
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleLeft ' Size MiddleLeft

        Dim i, j As Integer

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                grid(i, j).Value = ""
                If j = 1 Or j = 2 Then
                    grid(i, j).VisualModel = model1
                Else
                    grid(i, j).VisualModel = model2
                End If
            Next
        Next
        Return RowCount - 1
    End Function

    Public Function InitGrid(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim i, j As Integer
        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.White     'CELL COLOR CHANGE
        model2.Font = New Font("Arial", 11, FontStyle.Bold) 'SIZE STYLE CHANGE
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' SIZE CENTER ARRAY

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                grid(i, j).Value = ""
                grid(i, j).VisualModel = model2
            Next
        Next
        Return RowCount - 1
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : DATA Character String, Character String Length
    ''' 
    ''' - COMMENT  : SPACE FUNCTION
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function Replace(ByVal DATA As String, ByVal Length As Integer) As String

        While (DATA.Length < Length)
            DATA = DATA + " "
        End While
        Return DATA
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : DATA Character String
    ''' 
    ''' - COMMENT  : NULL -> 0
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function STRINGNULL(ByVal DATA As String) As Double
        If DATA = "" Then
            DATA = 0
        End If
        Return DATA
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub filelog(ByVal msg As String)
        Dim i As Integer
        Dim filestream As FileStream = Nothing
        Dim msgtime, filename As String
        Dim fileinfo As System.IO.FileInfo

        msgtime = System.DateTime.Now.ToString("yyyyMMddHHmmss")
        filename = System.DateTime.Now.ToString("yyyyMMddHH")

        Dim fs As String() = System.IO.Directory.GetFiles("c:\CBL", "*.log")
        Dim filelist As New ArrayList
        filelist.AddRange(fs)
        filelist.Sort()
        For i = 0 To filelist.Count - 1
            If i > 8 Then
                My.Computer.FileSystem.DeleteFile(filelist(i - 9))
            ElseIf i = filelist.Count - 1 Then
                fileinfo = My.Computer.FileSystem.GetFileInfo(filelist(i))
                If fileinfo.Length > 1000 Then
                    Using Sw As StreamWriter = New StreamWriter("c:\CBL\log" + filename.ToString + ".log")
                        Sw.WriteLine(msg)
                        Sw.Close()
                    End Using
                Else
                    My.Computer.FileSystem.WriteAllText(filelist(i), msgtime + " " + msg + vbCrLf, True)
                End If
            End If
        Next
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridHeader
    '''
    ''' - ARGUMENT : Integer style : 
    '''
    ''' - COMMENT  : Grid Header¿¡ style Apply
    '''
    ''' - RETURN   : SourceGrid2.VisualModels.Header / headerstyle
    '''
    '''*********************************************************************************************************
    Public Function GridHeader(ByVal style As Integer, ByVal fontsize As Single) As SourceGrid2.VisualModels.Header

        Dim headerstyle As New SourceGrid2.VisualModels.Header
        Select Case style
            Case 1
                headerstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
            Case 2
                headerstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleLeft
            Case 3
                headerstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleRight
        End Select
        headerstyle.BackColor = Color.LightSteelBlue
        headerstyle.Font = New Drawing.Font("ARIAL", fontsize!, FontStyle.Bold)
        Return headerstyle
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridCommon
    '''
    ''' - ARGUMENT : Integer style : 
    '''
    ''' - COMMENT  : Grid Common style Apply
    '''
    ''' - RETURN   : SourceGrid2.VisualModels.Header / commonstyle
    '''
    '''*********************************************************************************************************
    Public Function GridCommon(ByVal style As Integer, ByVal fontsize As Single) As SourceGrid2.VisualModels.Common

        Dim commonstyle As New SourceGrid2.VisualModels.Common
        Select Case style
            Case 1
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
            Case 2
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleLeft
            Case 3
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleRight
            Case 4
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.TopCenter
        End Select
        commonstyle.Font = New Drawing.Font("ARIAL", fontsize!, FontStyle.Bold)
        Return commonstyle
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridColorCommon
    '''
    ''' - ARGUMENT : Integer style : 
    '''
    ''' - COMMENT  : Grid Common style Apply
    '''
    ''' - RETURN   : SourceGrid2.VisualModels.Header / commonstyle
    '''
    '''*********************************************************************************************************
    Public Function GridColorCommon(ByVal style As Integer, ByVal fontsize As Single) As SourceGrid2.VisualModels.Common
        Dim commonstyle As New SourceGrid2.VisualModels.Header
        Select Case style
            Case 1
                commonstyle.ForeColor = Color.Black
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
            Case 2
                commonstyle.ForeColor = Color.Blue
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
            Case 3
                commonstyle.ForeColor = Color.Red
                commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        End Select
        commonstyle.Font = New Drawing.Font("ARIAL", fontsize!, FontStyle.Bold)
        Return commonstyle
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridColorCommon
    '''
    ''' - ARGUMENT : Integer style : 
    '''
    ''' - COMMENT  : Grid Common style Application
    '''
    ''' - RETURN   : SourceGrid2.VisualModels.Header / commonstyle
    '''
    '''*********************************************************************************************************
    Public Function GridColorCommon1(ByVal style1 As Single, ByVal Min As Single, ByVal Max As Single) As SourceGrid2.VisualModels.Common
        Dim commonstyle As New SourceGrid2.VisualModels.Header
        If style1 > Max Then
            commonstyle.ForeColor = Color.Red
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        ElseIf style1 < Min Then
            commonstyle.ForeColor = Color.Blue
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        Else
            commonstyle.ForeColor = Color.Black
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        End If
        commonstyle.Font = New Drawing.Font("ARIAL", 12.0!, FontStyle.Bold)
        Return commonstyle
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridColorCommon
    '''
    ''' - ARGUMENT : Integer style : 
    '''
    ''' - COMMENT  : Grid Common style Application
    '''
    ''' - RETURN   : SourceGrid2.VisualModels.Header / commonstyle
    '''
    '''*********************************************************************************************************
    Public Function GridColorCommon2(ByVal style1 As Single, ByVal So As Single) As SourceGrid2.VisualModels.Common
        Dim commonstyle As New SourceGrid2.VisualModels.Header
        If style1 > So Then
            commonstyle.ForeColor = Color.Red
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        ElseIf style1 < So Then
            commonstyle.ForeColor = Color.Blue
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        Else
            commonstyle.ForeColor = Color.Black
            commonstyle.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter
        End If
        commonstyle.Font = New Drawing.Font("ARIAL", 12.0!, FontStyle.Bold)
        Return commonstyle
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridStyle
    '''
    ''' - ARGUMENT : SourceGrid2.Grid Grid ,Integer FixedRows : 
    '''
    ''' - COMMENT  : Grid Style SetUp
    '''
    ''' - RETURN   : SourceGrid2.Grid / Grid
    '''
    '''*********************************************************************************************************
    Public Sub GridStyle(ByVal Grid As SourceGrid2.Grid, ByVal FixedRows As Integer)
        Grid.BorderStyle = BorderStyle.Fixed3D
        Grid.FixedRows = FixedRows
        Grid.Selection.SelectionMode = SourceGrid2.GridSelectionMode.Row
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridClear_Check
    '''
    ''' - ARGUMENT : SourceGrid2.Grid Grid ,Integer StartRows,Integer StartCols : 
    '''
    ''' - COMMENT  : The Grid check box Initialize
    '''
    ''' - RETURN   : SourceGrid2.Grid / Grid
    '''
    '''*********************************************************************************************************
    Public Sub GridClear_Check(ByVal Grid As SourceGrid2.Grid, ByVal StartRows As Integer, ByVal StartCols As Integer)
        Dim i, j As Integer
        For i = StartRows To Grid.RowsCount - 1
            For j = StartCols To Grid.ColumnsCount - 1
                Select Case j
                    Case 0
                        Grid(i, j).Value = False
                    Case Else
                        Grid(i, j).Value = ""
                End Select
            Next
        Next
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridClear
    '''
    ''' - ARGUMENT : SourceGrid2.Grid Grid ,Integer StartRows,Integer StartCols :
    '''
    ''' - COMMENT  : Grid Initialize
    '''
    ''' - RETURN   : SourceGrid2.Grid / Grid
    '''
    '''*********************************************************************************************************
    Public Sub GridClear(ByVal Grid As SourceGrid2.Grid, ByVal StartRows As Integer, ByVal StartCols As Integer)
        Dim i, j As Integer
        For i = StartRows To Grid.RowsCount - 1
            For j = StartCols To Grid.ColumnsCount - 1
                Grid(i, j).Value = ""
            Next
        Next
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : GridCheck
    '''
    ''' - ARGUMENT : SourceGrid2.Grid Grid : 
    '''
    ''' - COMMENT  : CheckBox in Grid there are a few checks have been selected...
    '''
    ''' - RETURN   : Integer / count
    '''
    '''*********************************************************************************************************
    Public Function GridCheck(ByVal Grid As SourceGrid2.Grid) As Integer
        Dim i, count, num As Integer
        count = 0
        For i = 1 To Grid.RowsCount - 1
            If Grid(i, 0).Value Then
                count = count + 1
                num = i
            End If
        Next
        If count = 0 Then
            MessageBox.Show("You must select at least one")
            num = -1
        ElseIf count > 1 Then
            MessageBox.Show("Please select only one")
            For i = 1 To Grid.RowsCount - 1
                Grid(i, 0).Value = False
            Next
            num = -1
        End If
        Return num
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : System.Windows.Forms.KeyPressEventArgs e(System Event), TextBox textbox(TextBox Object)
    '''
    ''' - COMMENT  : KEY PRESS ONLY NUMBER, ENGLISH
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub ENG_NUM_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal textbox As TextBox)
        textbox.ImeMode = Windows.Forms.ImeMode.Disable
        Select Case e.KeyChar

            Case "0"c To "9"c
            Case "a"c To "z"c
            Case "A"c To "Z"c
            Case ChrW(Keys.Delete)
            Case ChrW(Keys.Back)
            Case Else
                e.Handled = True
        End Select
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : System.Windows.Forms.KeyPressEventArgs e(System Event), TextBox textbox(TextBox Object)
    '''
    ''' - COMMENT  : COMMENT: KEY PRESS ONLY NUMBER
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub NUM_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal textbox As TextBox)
        textbox.ImeMode = Windows.Forms.ImeMode.Disable
        Select Case e.KeyChar
            Case "0"c To "9"c
            Case ChrW(Keys.Back)
            Case Else
                e.Handled = True
        End Select
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : System.Windows.Forms.KeyPressEventArgs e(System Event), TextBox textbox(TextBox Object)
    '''
    ''' - COMMENT  : COMMENT: KEY PRESS ONLY B, E
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub divideMode_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal textbox As TextBox)
        textbox.ImeMode = Windows.Forms.ImeMode.Disable
        Select Case e.KeyChar
            Case "B"
            Case "E"
            Case Else
                e.Handled = True
        End Select
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : System.Windows.Forms.KeyPressEventArgs e(System Event), TextBox textbox(TextBox Object)
    '''
    ''' - COMMENT  : KEY PRESS ONLY POINT, NUMBER
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Sub NUM_Point_KeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal textbox As TextBox)
        textbox.ImeMode = Windows.Forms.ImeMode.Disable
        Select Case e.KeyChar
            Case "0"c To "9"c
            Case "."c
            Case ChrW(Keys.Delete)
            Case ChrW(Keys.Back)
            Case Else
                e.Handled = True
        End Select
    End Sub

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : Displayed on the screen 'error when the DB, so it does not need to save by converting to `return.
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function QuotationConvert(ByVal Quotation As String) As String
        Quotation = Quotation.Replace("'", "`")
        Return Quotation
    End Function

    'Public Function CodeConvert(ByVal code As Integer, ByVal CodeValue As String) As String
    '    Dim sql As String
    '    Dim ds As Data.DataSet 'DataSet
    '    sql = " SELECT CODE_MEAN FROM " + GblCommon.STANDARDCODEITEM + " WHERE CODE_SORT =  '" + code.ToString + _
    '          "' and code_value = '" + CodeValue + "'"
    '    ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet 
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim daterow As DataRow = ds.Tables(0).Rows(0)
    '        Return daterow("CODE_MEAN").ToString
    '        Exit Function
    '    Else
    '    End If
    '    Return CodeValue
    'End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : 
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : COIL NO '*' Reject
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function AsteriskDelete(ByVal Asterisk As String) As String
        Asterisk = Asterisk.Replace("*", "")
        Return Asterisk
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : CalTonPerHour
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : NULL
    '''
    '''*********************************************************************************************************
    Public Function CalTonPerHour(ByVal nThick As Integer, ByVal nWidth As Integer, ByVal nSpeed As Integer, ByVal nDensity As Integer) As Integer
        Dim nTonHour As Integer = 0
        Dim fTonHour As Integer = 0
        Dim fThick As Single = 0
        Dim fWidth As Single = 0
        Dim fSpeed As Single = 0
        Dim fDensity As Single = 0

        '/*----- WEIGHT CALCULATION ----------------------------------------------*/
        If nThick = 0 Or nWidth = 0 Or nSpeed = 0 Then
            Return 0
        End If
        fThick = CType(nThick, Single) / 1000.0 / 1000.0
        fWidth = CType(nWidth, Single) / 10.0 / 1000.0
        fSpeed = CType(nSpeed, Single) / 1.0
        If nDensity = 0 Then
            fDensity = 7930
        Else
            fDensity = CType(nDensity, Single)
        End If
        fTonHour = (fThick * fWidth * fSpeed * fDensity * 60) / 10.0
        nTonHour = CType(fTonHour, Integer)
        Return nTonHour
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : DayOnePlus
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : strDateTime
    '''
    '''*********************************************************************************************************
    Public Function DayOnePlus(ByVal strDateTime As String) As String
        strDateTime = DateAdd("d", 1, strDateTime) & " 00:00:00"
        Return strDateTime
    End Function

    '''**********************************************************************************************************	
    '''
    ''' - FUNCTION : DayOnePlus
    '''
    ''' - ARGUMENT : 
    '''
    ''' - COMMENT  : 
    '''
    ''' - RETURN   : strDateTime
    '''
    '''*********************************************************************************************************
    Public Function DayOnePlusTime6(ByVal strDateTime As String) As String
        strDateTime = DateAdd("d", 1, strDateTime) & " 06:00:00"
        Return strDateTime
    End Function

    Public Function Init2SCH(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)
        Dim model1 As New SourceGrid2.VisualModels.Header
        model1.BackColor = Color.LightGray  'CELL COLOR CHANGE
        model1.Font = New Font("Arial", 11, FontStyle.Bold) 'SIZE STYLE CHANGE
        model1.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' SIZE CENTER ARRAY

        Dim model2 As New SourceGrid2.VisualModels.Header
        model2.BackColor = Color.White     'CELL COLOR CHANGE
        model2.Font = New Font("Arial", 10, FontStyle.Bold) 'SIZE STYLE CHANGE
        model2.TextAlignment = SourceLibrary.Drawing.ContentAlignment.MiddleCenter ' SIZE CENTER ARRAY

        Dim i, j As Integer

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                grid(i, j).Value = ""
                If j = 0 Then
                    grid(i, j).VisualModel = model1
                Else
                    grid(i, j).VisualModel = model2
                End If
            Next
        Next
        Return RowCount - 1
    End Function

    Public Function Inita(ByVal RowStart As Integer, ByVal RowCount As Integer, ByVal ColumnCount As Integer, ByVal Check As Boolean, ByVal grid As SourceGrid2.Grid)

        Dim i, j As Integer
        For i = RowStart To RowCount
            grid.Rows.Insert(i)
            grid.Rows(i).AutoSizeMode = SourceGrid2.AutoSizeMode.None
            grid.Rows(i).Height = 25
        Next

        For i = RowStart To RowCount
            For j = 0 To ColumnCount
                If j = 0 And Check = True Then
                    grid(i, j) = New SourceGrid2.Cells.Real.CheckBox(False)
                Else
                    grid(i, j) = New SourceGrid2.Cells.Real.Cell
                End If
            Next
        Next
        Return RowCount - 1
    End Function
End Class
