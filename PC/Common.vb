Module Common
    'Public FmName As String = ""                    'Form Name
    Public UserGroup As Integer                     ' 1 Admin 2 User 3 Guest
    'Public UserNum As String
    Public UserName As String

    Public ipAddress As String = ""

    Public dbcondition As Boolean                   'DB Condition

    Public msgcheck1 As Boolean = True
    Public msgcheck2 As Boolean


    Public time As String
    Public day As String        'Monthcalender date
    Public calender As MonthCalendar        'Monthcalender
    'KDY Public dateitem As Pabo.Calendar.DateItem()
    'KDY Public MonthCalendar1 As New Pabo.Calendar.MonthCalendar
    'Public textdate1 As String
    'Public textdate2 As String
    'Public R As Integer
    'Public rowct As Integer            'row count
    'Public CalendarDay As String            ' Calendar date
    'Public Style As New SourceGridStyle        'SourceGridStyle
    'Public excl As New CMgrExcel
    Public i, j As Integer
    Public ExcelDataSet As New DataSet              'Excel dataset 

    Public ut As New CMgrUtility  'event

    'Public PRODUCT1 As String
    Public DATEE As String 'Date
    ' Public TESTMUCHIN As String = "TS"
End Module
