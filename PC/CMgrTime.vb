Imports System

Public Class CMgrTime
    'private string TimeNow = "";
    'private string ResultTime = "";

    Public Sub New()
    End Sub


    '14-digit string of the system returns the current time
    Public Function NowTime() As String
        Return System.DateTime.Now.ToString("yyyyMMddHHmmss")
    End Function


    '14-digit string return DateTime type value...
    Public Function ToDBTime(ByVal sysTime As DateTime) As String
        Return sysTime.ToString("yyyyMMddHHmmss")
    End Function


    'Enter the current time received from the separate units of a particular time depending on the result, plus or minus a certain value returns the time
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

    Public Function DiffTime(ByVal fTime As String, ByVal cTime As String) As Long
        Dim sYear As Integer = Convert.ToInt32(fTime.Substring(0, 4))
        Dim sMonth As Integer = Convert.ToInt32(fTime.Substring(4, 2))
        Dim sDay As Integer = Convert.ToInt32(fTime.Substring(6, 2))
        Dim sHour As Integer = Convert.ToInt32(fTime.Substring(8, 2))
        Dim sMinute As Integer = Convert.ToInt32(fTime.Substring(10, 2))
        Dim sSecond As Integer = Convert.ToInt32(fTime.Substring(12))

        Dim cYear As Integer = Convert.ToInt32(cTime.Substring(0, 4))
        Dim cMonth As Integer = Convert.ToInt32(cTime.Substring(4, 2))
        Dim cDay As Integer = Convert.ToInt32(cTime.Substring(6, 2))
        Dim cHour As Integer = Convert.ToInt32(cTime.Substring(8, 2))
        Dim cMinute As Integer = Convert.ToInt32(cTime.Substring(10, 2))
        Dim cSecond As Integer = Convert.ToInt32(cTime.Substring(12))

        If cYear < 2010 Or cYear > 2200 Then

            MessageBox.Show("Years Range Over")
            Return 0
        ElseIf cMonth < 1 Or cMonth > 12 Then

            MessageBox.Show("Month Range Over")
            Return 0
        ElseIf cDay < 1 Or cDay > 31 Then

            MessageBox.Show("Month Range Over")
            Return 0
        ElseIf cHour < 0 Or cHour > 23 Then

            MessageBox.Show("Hour Range Over")
            Return 0
        ElseIf cMinute < 0 Or cMinute > 59 Then

            MessageBox.Show("Minute Range Over")
            Return 0
        ElseIf cSecond < 0 Or cSecond > 59 Then

            MessageBox.Show("Second Range Over")
            Return 0
        End If

        Dim sTime As New DateTime(sYear, sMonth, sDay, sHour, sMinute, sSecond)
        Dim eTime As New DateTime(cYear, cMonth, cDay, cHour, cMinute, cSecond)
        Dim nDiffTime As Long = (eTime.Ticks - sTime.Ticks) / 10000000

        If nDiffTime = 0 Then
            MessageBox.Show("Error! Start Time Same End Time")
            Return 0
        End If

        'Dim dfTime As System.TimeSpan = eTime - sTime
        'Dim rTime As DateTime = sTime 
        'Return dfTime.ToString().Trim()
        Return nDiffTime
    End Function
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
End Class
