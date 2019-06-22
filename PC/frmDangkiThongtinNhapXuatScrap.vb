Public Class frmDangkiThongtinNhapXuatScrap
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

    Private Sub frmDangkiThongtinNhapXuatScrap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOrder.Text = orderno.Trim        
        sql = "select * from TB_SCRAP where OrderNo = '" + orderno + "'"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        If count > 0 Then
            r = ds.Tables(0).Rows(0)
            txtTenkhachhang.Text = r("czTenkhachhang").ToString.Trim
            txtLoaiThep.Text = r("csType").ToString.Trim
            txKhoiluongOrder.Text = r("czQtyOrder").ToString.Trim
            txtGhichu.Text = r("czRemark").ToString.Trim
            txtManhanvien.Text = r("czManhanvien").ToString.Trim
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim czTenkhachhang As String = txtTenkhachhang.Text
        Dim czLoaithep As String = txtLoaiThep.Text
        Dim czKhoiluongorder As String = txKhoiluongOrder.Text
        Dim czGhichu As String = txtGhichu.Text

        sql = "update TB_SCRAP set czTenkhachhang = '" + czTenkhachhang + "', csType = '" + czLoaithep + "', czQtyOrder = '" + czKhoiluongorder + "', czRemark = '" + czGhichu + "' where OrderNo = '" + orderno + "'"
        If MessageBox.Show("Bạn có muốn chỉnh sửa thông tin không?", "Xác nhận thông tin", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
        End If
        Me.Close()
    End Sub
End Class