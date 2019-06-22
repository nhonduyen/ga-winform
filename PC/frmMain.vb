Imports System.Threading
Imports System.Drawing.Printing
Imports SourceGrid2.Grid
Imports System.IO
Imports System.Net.Sockets
Imports System.Net
Imports System.Xml
Imports System.Drawing.Imaging

Public Class frmMain
    Public Child As New Form
    Private childname As String
    Dim nRote As Integer = 0
    Dim p As Process
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If cztaikhoan.Trim = "cont" Or cztaikhoan.Trim = "elect1" Or cztaikhoan.Trim = "elect2" Or cztaikhoan.Trim = "hse" Or cztaikhoan.Trim = "utility" Then
            btnXuatkho.Enabled = False          
            btnNhapkho.Enabled = False
            btnScrap.Enabled = False          
            PageDisplay("XUẤT KHO", windowsname("XUẤT KHO"))
        End If        

        PageDisplay("XUẤT KHO", windowsname("XUẤT KHO"))
        lblThongtinTaikhoan.Text = "Tài khoản: " + cztaikhoan.Trim + vbLf + "(Thay đổi mật khẩu)"        
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            MsgBox("Program is already running!", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Program is already running")
            End
        End If
        CMgrDataBase.GetInstance().Open("GA")         'DATABASE CONNECT
    End Sub
    Public Sub PageDisplay(ByVal action As String, ByVal windowsname As String)
        Dim intcheck As Integer
        'child.name => current screen, Windowsname => new screen(clicked)
        If Child.Name <> windowsname And windowsname.Length > 0 Then
            If Me.MdiChildren.Length <= 1 Then
                If Child.Visible = True Then
                    Child.Dispose()
                End If
                MainButtonClear()
                Select Case action  'change botton color to Yellow and set child the clicked screen class
                    Case "NHẬP KHO"
                        btnNhapkho.BackColor = Color.Yellow
                        Child = New frmNhapKhoNguyenLieu()
                        Exit Select
                    Case "XUẤT KHO"
                        btnXuatkho.BackColor = Color.Yellow
                        Child = New frmXuatKhoThanhPham()
                        Exit Select
                    Case "NHAP XUAT SCRAP"
                        btnScrap.BackColor = Color.Yellow
                        Child = New frmNhapXuatScrap()
                        Exit Select                                  
                    Case Else
                        intcheck = 1
                        Exit Select
                End Select

                If intcheck <> 1 Then
                    lblMainTitle.Text = "HỆ THỐNG QUẢN LÝ PHƯƠNG TIỆN - XUẤT NHẬP VẬT TƯ - [" + action + "]"
                    Child.MdiParent = Me
                    Child.StartPosition = FormStartPosition.Manual
                    Child.WindowState = FormWindowState.Normal
                    Child.Show()
                End If
                childname = action
            End If
        End If

    End Sub

    Private Sub MainButtonClear()
        btnNhapkho.BackColor = Color.Empty
        btnXuatkho.BackColor = Color.Empty
        btnScrap.BackColor = Color.Empty      
    End Sub
    Public Function windowsname(ByVal name As String) As String

        Dim childname As String

        Select Case name    
            Case "NHẬP KHO"
                childname = "frmNhapKhoNguyenLieu"
                Exit Select
            Case "XUẤT KHO"
                childname = "frmXuatKhoThanhPham"
                Exit Select       
            Case "NHAP XUAT SCRAP"
                childname = "frmNhapXuatScrap"
                Exit Select
            Case Else
                childname = ""
                Exit Select
        End Select

        Return childname

    End Function

    Private Sub cmdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXuatkho.Click, btnNhapkho.Click, btnScrap.Click
        Dim btn_click As Button
        btn_click = CType(sender, Button)


        Select Case btn_click.Name 
            Case "btnNhapkho"
                PageDisplay("NHẬP KHO", windowsname("NHẬP KHO"))
                Exit Select
            Case "btnXuatkho"
                PageDisplay("XUẤT KHO", windowsname("XUẤT KHO"))
                Exit Select      
            Case "btnScrap"
                PageDisplay("NHAP XUAT SCRAP", windowsname("NHAP XUAT SCRAP"))
                Exit Select
        End Select
    End Sub

    Private Sub lblThongtinTaikhoan_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblThongtinTaikhoan.MouseDoubleClick
        Dim _frmThaydoiMatkhau As New frmThaydoiMatkhau
        _frmThaydoiMatkhau.ShowDialog()
    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        For Each Me.p In Process.GetProcessesByName("PC")
            p.Kill()
        Next
    End Sub
End Class
