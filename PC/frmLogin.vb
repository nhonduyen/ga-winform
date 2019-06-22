Imports System.Net

Public Class frmLogin
    Dim count As Integer = 0
    Dim count1 As Integer = 0

    Dim T As Integer  'Page Count
    Dim k1 As Integer 'Get the Remainder  of the show ending the top of the list for the number of variables
    Dim g1 As Integer = 0 'By comparing the end of the event would show the number of clicks to obtain shares Wed
    Dim index As Integer = 0  'Show the number of list 

    Dim ExcelApp As Microsoft.Office.Interop.Excel.Application
    Dim ExcelBook As Microsoft.Office.Interop.Excel.Workbook
    Dim ExcelSheet As Microsoft.Office.Interop.Excel.Worksheet


    Dim sql As String = "" ' Query
    Dim ds As Data.DataSet 'DataSet 
    Dim r As DataRow 'Column
    Dim nSeqNo As Integer
    Dim iiip As String = ""
    Private Sub btnDangnhap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDangnhap.Click
      
        Me.Hide()
        Dim sql1 As String = "" ' Query
        Dim ds1 As Data.DataSet 'DataSet 
        Dim count1 As Integer
        Dim sql2 As String = "" ' Query       
        sql = "select * from TB_USER where czManhanvien  = '" + txtTaikhoan.Text + "' and czPass = '" + Encode(txtMatkhau.Text.Trim()) + "'"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        If count > 0 Then
            IPAddress()
            If chckbGhinho.Checked = True Then
                sql1 = "select * from TB_TK where czIP = '" + iiip + "'"
                ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
                count1 = ds1.Tables(0).Rows.Count

                If count1 > 0 Then
                    sql2 = "update TB_TK set czUser  = '" + txtTaikhoan.Text.Trim + "', czPass = '" + txtMatkhau.Text.Trim + "' where czIP = '" + iiip + "'"
                    CMgrDataBase.GetInstance().ReturnDataSet(sql2) 'DataSet 
                Else
                    sql2 = "insert into TB_TK (czIP, czUser, czPass) values ('" + iiip + "', '" + txtTaikhoan.Text.Trim + "', '" + txtMatkhau.Text.Trim + "')"
                    CMgrDataBase.GetInstance.ExecuteNonQuery(sql2)
                End If
            End If

            Dim _frmMain As New frmMain
            cztaikhoan = txtTaikhoan.Text
            _frmMain.Show()
            Me.Hide()
        Else
            MessageBox.Show("Tài khoản hoặc Mật khẩu chưa đúng", "Thông báo")
        End If

    End Sub

    Private Sub IPAddress()
        'To get local address
        Dim LocalHostName As String = ""
        Dim i As Integer

        LocalHostName = Dns.GetHostName()
        Dim ipEnter As IPHostEntry = Dns.GetHostByName(LocalHostName)
        Dim IpAdd() As IPAddress = ipEnter.AddressList
        For i = 0 To IpAdd.GetUpperBound(0)
            iiip = IpAdd(i).ToString
        Next
    End Sub
    Public Function Encode(ByVal value)
        If String.IsNullOrWhiteSpace(value) Then
            value = ""
        End If
        Dim hash = System.Security.Cryptography.SHA1.Create()
        Dim encoder = New System.Text.ASCIIEncoding()
        Dim combine = encoder.GetBytes(value)

        Return BitConverter.ToString(hash.ComputeHash(combine)).ToLower().Replace("-", "")
    End Function

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql1 As String = "" ' Query
        Dim ds1 As Data.DataSet 'DataSet 
        Dim r1 As DataRow 'Column
        Dim count1 As Integer
        CMgrDataBase.GetInstance().Open("GA")         'DATABASE CONNECT
        IPAddress()
        sql1 = "select * from TB_TK where czIP = '" + iiip + "'"
        ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
        count1 = ds1.Tables(0).Rows.Count

        If count1 > 0 Then
            chckbGhinho.Checked = True
            r1 = ds1.Tables(0).Rows(0)
            txtTaikhoan.Text = r1("czUser").ToString.Trim
            txtMatkhau.Text = r1("czPass").ToString.Trim
        Else
            txtTaikhoan.Text = ""
            txtMatkhau.Text = ""
            chckbGhinho.Checked = False
        End If
    End Sub

    Private Sub txtMatkhau_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMatkhau.KeyDown, txtTaikhoan.KeyDown
        Dim sql1 As String = "" ' Query
        Dim ds1 As Data.DataSet 'DataSet 
        Dim count1 As Integer
        Dim sql2 As String = "" ' Query    
        If e.KeyCode = Keys.Enter Then
            sql = "select * from TB_USER where czManhanvien  = '" + txtTaikhoan.Text + "' and czPass = '" + txtMatkhau.Text + "'"
            ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
            count = ds.Tables(0).Rows.Count

            If count > 0 Then
                IPAddress()
                If chckbGhinho.Checked = True Then
                    sql1 = "select * from TB_TK where czIP = '" + iiip + "'"
                    ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet   
                    count1 = ds1.Tables(0).Rows.Count

                    If count1 > 0 Then
                        sql2 = "update TB_TK set czUser  = '" + txtTaikhoan.Text.Trim + "', czPass = '" + txtMatkhau.Text.Trim + "' where czIP = '" + iiip + "'"
                        CMgrDataBase.GetInstance().ReturnDataSet(sql2) 'DataSet 
                    Else
                        sql2 = "insert into TB_TK (czIP, czUser, czPass) values ('" + iiip + "', '" + txtTaikhoan.Text.Trim + "', '" + txtMatkhau.Text.Trim + "')"
                        CMgrDataBase.GetInstance.ExecuteNonQuery(sql2)
                    End If
                End If
                Dim _frmMain As New frmMain
                cztaikhoan = txtTaikhoan.Text
                _frmMain.Show()
                Me.Hide()
            Else
                MessageBox.Show("Tài khoản hoặc Mật khẩu chưa đúng", "Thông báo")
            End If
        End If

    End Sub


    Private Sub txtTaikhoan_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTaikhoan.KeyUp
        Dim sql1 As String = "" ' Query

        If txtTaikhoan.Text.Trim = "" Then
            txtMatkhau.Text = ""
            sql1 = "update TB_TK set czUser  = '" + txtTaikhoan.Text.Trim + "', czPass = '" + txtMatkhau.Text.Trim + "' where czIP = '" + iiip + "'"
            CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet 
        End If

    End Sub
End Class