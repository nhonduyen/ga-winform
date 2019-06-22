Public Class frmThaydoiMatkhau
    Dim count As Integer = 0
    Dim sql As String = "" ' Query
    Dim ds As Data.DataSet 'DataSet 
    Dim r As DataRow 'Column
    Private Sub frmThaydoiMatkhau_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTaikhoan.Text = cztaikhoan.Trim
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        CMgrDataBase.GetInstance().Open("GA")         'DATABASE CONNECT
        If txtmatkhaumoi.Text.Trim = txtnhaplaimatkhaumoi.Text.Trim And txtnhaplaimatkhaumoi.Text.Trim.Length >= 6 Then

            If MessageBox.Show("Bạn có muốn thay đổi mật khẩu không?", " Confirm!!!", MessageBoxButtons.YesNo) = vbYes Then
                sql = "update TB_USER set czPass = '" + txtmatkhaumoi.Text.Trim + "' where czManhanvien  = '" + txtTaikhoan.Text + "'"
                CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub
End Class