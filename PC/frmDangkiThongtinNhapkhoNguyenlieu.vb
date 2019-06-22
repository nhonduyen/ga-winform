Public Class frmDangkiThongtinNhapkhoNguyenlieu
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
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDangkiThongtinNhapkhoNguyenlieu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtMaravaocong.Text = nprimUID.Trim
        sql = "select * from TB_NHAPKHO where nPrimUID = " & nprimUID
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        If count > 0 Then
            r = ds.Tables(0).Rows(0)
            txtCoilID.Text = r("czMaNguyenLieu")
            txtChungloai.Text = r("czChungloai")
            txtDoday.Text = r("czDoDay")
            txtDorong.Text = r("czChieuRong")
            txtKhoiluongthuc.Text = r("czKhoiLuongthuc")
            txtManhanvien.Text = r("czManhanvien")
            txtGhichu.Text = r("czGhichu")

        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim czChungloai As String = txtChungloai.Text      
        Dim czDoday As String = txtDoday.Text
        Dim czRong As String = txtDorong.Text       
        Dim czkhoiluongthuc As String = txtKhoiluongthuc.Text
        Dim czGhichu As String = txtGhichu.Text
        sql = "update TB_NHAPKHO set czChungloai = '" + czChungloai + "', czDoDay = '" + czDoday + "', czChieuRong = '" + czRong + "', czKhoiLuongthuc  = '" + czkhoiluongthuc + "', czGhichu = '" + czGhichu + "' where nPrimUID = " & nprimUID

        If MessageBox.Show("Bạn có muốn chỉnh sửa thông tin không?", "Xác nhận thông tin", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
        End If
        Me.Close()
    End Sub
End Class