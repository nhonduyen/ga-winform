Public Class frmShipDetail
    Dim sql As String = "" ' Query   
    Dim ds As Data.DataSet 'DataSet 
    Dim r As DataRow 'Column
    Dim count As String


    Private Sub frmShipDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If cztaikhoan = "060078" Then
            DataGridkhoiluong.Enabled = False
        End If


        timePickThoigianvao.Value = Now

        txtNgayvao.Text = timePickThoigianvao.Value.ToString.Substring(0, 10)
        txtOrderNo.Text = orderno.Trim
        txtMaNhanVien.Text = cztaikhoan
        txtKLOrder.Text = khoiluongOrder.ToString
        Dim chitietxuatScrap As String = ""

        Dim nTongKhoiluongGopdaxuat As String = 0
        Dim nTongkhoiluongThucdaxuat As String = 0
        sql = "select * from TB_SCRAP where OrderNo = '" + orderno.Trim + "'"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        If count > 0 Then
            r = ds.Tables(0).Rows(0)
            Dim countDataRow As Integer = r("czChitietxuatScrap").ToString.Trim.Split("|").Count
            DataGridkhoiluong.RowCount = countDataRow

            If countDataRow > 0 And r("czChitietxuatScrap").ToString.Trim.Split("|")(0).Trim <> "" Then
                For i As Integer = 0 To countDataRow - 1
                    DataGridkhoiluong(0, i).Value = i + 1
                    For j As Integer = 1 To 5
                        Dim iii As Integer = r("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_").Count
                        DataGridkhoiluong(j, i).Value = r("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1)

                        If j = 2 Then
                            nTongKhoiluongGopdaxuat = CType(nTongKhoiluongGopdaxuat, Integer) + CType(r("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                        End If


                        If j = 3 Then
                            nTongkhoiluongThucdaxuat = CType(nTongkhoiluongThucdaxuat, Integer) + CType(r("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                        End If

                    Next

                Next
            End If
        End If
        txtKLDaXuat.Text = nTongKhoiluongGopdaxuat
        txtKLgop.Text = nTongkhoiluongThucdaxuat
        txtKLConlai.Text = khoiluongOrder - nTongKhoiluongGopdaxuat
    End Sub

   
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        If txtKhoiluongthuc.Text.Trim = "" Then
            txtKhoiluongthuc.BackColor = Color.Red
            MessageBox.Show("Bạn điền thông tin chưa đầy đủ." + vbLf + "Chú ý những ô màu đỏ", "Cảnh báo!")
            Exit Sub
        Else
            txtKhoiluongthuc.BackColor = Color.White
        End If
        If txtKhoiluonggop.Text.Trim = "" Then
            txtKhoiluonggop.BackColor = Color.Red
            MessageBox.Show("Bạn điền thông tin chưa đầy đủ." + vbLf + "Chú ý những ô màu đỏ", "Cảnh báo!")
            Exit Sub
        Else
            txtKhoiluonggop.BackColor = Color.White
        End If
        If txtBiensoxe.Text.Trim = "" Then
            txtBiensoxe.BackColor = Color.Red
            MessageBox.Show("Bạn điền thông tin chưa đầy đủ." + vbLf + "Chú ý những ô màu đỏ", "Cảnh báo!")
            Exit Sub
        Else
            txtBiensoxe.BackColor = Color.White
        End If

        Dim chi_tiet_xuat_Scrap As String = ""
        Dim demhanghoa As Integer = DataGridkhoiluong.RowCount
        Dim chitietxuatScrap As String = ""       
        sql = "select * from TB_SCRAP where OrderNo = '" + orderno.Trim + "'"
        ds = CMgrDataBase.GetInstance().ReturnDataSet(sql) 'DataSet    
        count = ds.Tables(0).Rows.Count

        If count > 0 Then
            r = ds.Tables(0).Rows(0)
            chitietxuatScrap = r("czChitietxuatScrap").ToString.Trim

            If chitietxuatScrap <> "" Then
                chitietxuatScrap = chitietxuatScrap + "|" + timePickThoigianvao.Value.ToString.Substring(0, 16) + "_" + txtKhoiluongthuc.Text.Trim + "_" + txtKhoiluonggop.Text.Trim + "_" + txtBiensoxe.Text.Trim + "_" + txtMaNhanVien.Text.Trim
            Else
                chitietxuatScrap = timePickThoigianvao.Value.ToString.Substring(0, 16) + "_" + txtKhoiluongthuc.Text.Trim + "_" + txtKhoiluonggop.Text.Trim + "_" + txtBiensoxe.Text.Trim + "_" + txtMaNhanVien.Text.Trim
            End If

        End If


        sql = "update TB_SCRAP set czChitietxuatScrap = '" + chitietxuatScrap + "' where OrderNo = '" + orderno.Trim + "'"
        If MessageBox.Show("Bạn có muốn Lưu thông tin không?", " Xác nhận!", MessageBoxButtons.YesNo) = vbYes Then
            CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
            Me.Close()
        End If


    End Sub

   

    Private Sub txtKhoiluongthuc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKhoiluongthuc.KeyPress, txtKhoiluonggop.KeyPress
        If (Char.IsDigit(e.KeyChar) = False And Char.IsControl(e.KeyChar) = False) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub DataGridkhoiluong_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridkhoiluong.CellClick
        Dim sql1 As String = "" ' Query   
        Dim ds1 As Data.DataSet 'DataSet 
        Dim r1 As DataRow 'Column
        Dim count1 As String

        Dim sql2 As String = "" ' Query   
        Dim ds2 As Data.DataSet 'DataSet 
        Dim r2 As DataRow 'Column
        Dim count2 As String
        Dim czChitietxuatScrap As String = ""

        Dim ngayxuathang As String = ""
        Dim khoiluongthuc As String = ""
        Dim khoiluonggop As String = ""
        Dim biensoxe As String = ""
        Dim nguoikiemtra As String = ""
        Dim noidungxoa As String = ""


        sql1 = "select * from TB_SCRAP where OrderNo = '" + txtOrderNo.Text + "'"
        ds1 = CMgrDataBase.GetInstance().ReturnDataSet(sql1) 'DataSet    
        count1 = ds1.Tables(0).Rows.Count

        If count1 > 0 Then
            r1 = ds1.Tables(0).Rows(0)
            If r1("czChitietxuatScrap").ToString <> "" Then
                czChitietxuatScrap = r1("czChitietxuatScrap").ToString.Trim
            Else
                czChitietxuatScrap = r1("czChitietxuatScrap").ToString
            End If
        End If


        If e.ColumnIndex = 7 And e.RowIndex <> -1 Then

            If DataGridkhoiluong(6, e.RowIndex).Value = "Sửa" Then
                ngayxuathang = DataGridkhoiluong(1, e.RowIndex).Value.ToString.Trim
                khoiluongthuc = DataGridkhoiluong(2, e.RowIndex).Value.ToString.Trim
                khoiluonggop = DataGridkhoiluong(3, e.RowIndex).Value.ToString.Trim
                biensoxe = DataGridkhoiluong(4, e.RowIndex).Value.ToString.Trim
                nguoikiemtra = DataGridkhoiluong(5, e.RowIndex).Value.ToString.Trim
                noidungxoa = ngayxuathang + "_" + khoiluongthuc + "_" + khoiluonggop + "_" + biensoxe + "_" + nguoikiemtra
                czChitietxuatScrap = czChitietxuatScrap.Replace(czChitietxuatScrap.Split("|")(e.RowIndex), noidungxoa)


                sql = "update TB_SCRAP set czChitietxuatScrap = '" + czChitietxuatScrap + "' where OrderNo = '" + txtOrderNo.Text.Trim + "'"
                If MessageBox.Show("BẠN HÃY XÁC NHẬN THÔNG TIN TRƯỚC KHI CHỈNH SỬA:" + vbLf + vbLf + "+ Ngày xuất: " + ngayxuathang + vbLf + "+ Khối lượng thực: " + khoiluongthuc + vbLf + "+ Khối lượng gộp: " + khoiluonggop + vbLf + "+ Biển số xe: " + biensoxe + vbLf + "+ Người kiểm tra: " + nguoikiemtra, " Xác nhận!", MessageBoxButtons.YesNo) = vbYes Then
                    CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                End If

                '=======UPDATE LẠI THÔNG TIN====================
                Dim nKhoiluongdaxuat As String = 0
                Dim nTongkhoiluongThucdaxuat As String = 0
                sql2 = "select * from TB_SCRAP where OrderNo = '" + orderno.Trim + "'"
                ds2 = CMgrDataBase.GetInstance().ReturnDataSet(sql2) 'DataSet    
                count2 = ds2.Tables(0).Rows.Count
                If count2 > 0 Then
                    r2 = ds2.Tables(0).Rows(0)
                    Dim countDataRow As Integer = r2("czChitietxuatScrap").ToString.Trim.Split("|").Count
                    DataGridkhoiluong.RowCount = countDataRow

                    If countDataRow > 0 And r2("czChitietxuatScrap").ToString.Trim.Split("|")(0).Trim <> "" Then
                        For i As Integer = 0 To countDataRow - 1
                            DataGridkhoiluong(0, i).Value = i + 1
                            For j As Integer = 1 To 5
                                Dim iii As Integer = r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_").Count
                                DataGridkhoiluong(j, i).Value = r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1)

                                If j = 2 Then
                                    nKhoiluongdaxuat = nKhoiluongdaxuat + CType(r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                                End If

                                If j = 3 Then
                                    nTongkhoiluongThucdaxuat = nTongkhoiluongThucdaxuat + CType(r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                                End If

                            Next

                        Next
                    End If
                End If
                '======================
                txtKLDaXuat.Text = nKhoiluongdaxuat
                txtKLgop.Text = nTongkhoiluongThucdaxuat
                txtKLConlai.Text = khoiluongOrder - nKhoiluongdaxuat
            End If



            If DataGridkhoiluong(6, e.RowIndex).Value = "Xóa" Then
                ngayxuathang = DataGridkhoiluong(1, e.RowIndex).Value.ToString.Trim
                khoiluongthuc = DataGridkhoiluong(2, e.RowIndex).Value.ToString.Trim
                khoiluonggop = DataGridkhoiluong(3, e.RowIndex).Value.ToString.Trim
                biensoxe = DataGridkhoiluong(4, e.RowIndex).Value.ToString.Trim
                nguoikiemtra = DataGridkhoiluong(5, e.RowIndex).Value.ToString.Trim
                noidungxoa = ngayxuathang + "_" + khoiluongthuc + "_" + khoiluonggop + "_" + biensoxe + "_" + nguoikiemtra
                czChitietxuatScrap = czChitietxuatScrap.Replace(noidungxoa, "")

                If czChitietxuatScrap.Length > 0 Then
                    If czChitietxuatScrap(0) = "|" Then
                        czChitietxuatScrap = czChitietxuatScrap.Replace(czChitietxuatScrap(0), "")
                    End If

                    If czChitietxuatScrap(czChitietxuatScrap.Length - 1) = "|" Then
                        czChitietxuatScrap = czChitietxuatScrap.Replace(czChitietxuatScrap(czChitietxuatScrap.Length - 1), "")
                    End If

                    For i As Integer = 0 To czChitietxuatScrap.Length - 4

                        If czChitietxuatScrap(i) + czChitietxuatScrap(i + 1) = "||" Then
                            czChitietxuatScrap = czChitietxuatScrap.Replace("||", "|")
                            Exit For
                        End If

                    Next

                End If



                sql = "update TB_SCRAP set czChitietxuatScrap = '" + czChitietxuatScrap + "' where OrderNo = '" + txtOrderNo.Text.Trim + "'"
                If MessageBox.Show("BẠN HÃY XÁC NHẬN THÔNG TIN TRƯỚC KHI XÓA CÓ ĐÚNG KHÔNG?" + vbLf + vbLf + "+ Ngày xuất: " + ngayxuathang + vbLf + "+ Khối lượng thực: " + khoiluongthuc + vbLf + "+ Khối lượng gộp: " + khoiluonggop + vbLf + "+ Biển số xe: " + biensoxe + vbLf + "+ Người kiểm tra: " + nguoikiemtra, " Xác nhận!", MessageBoxButtons.YesNo) = vbYes Then
                    CMgrDataBase.GetInstance.ExecuteNonQuery(sql)
                End If

                '=======UPDATE LẠI THÔNG TIN====================
                Dim nKhoiluongdaxuat As String = 0
                Dim nTongkhoiluongThucdaxuat As String = 0
                sql2 = "select * from TB_SCRAP where OrderNo = '" + orderno.Trim + "'"
                ds2 = CMgrDataBase.GetInstance().ReturnDataSet(sql2) 'DataSet    
                count2 = ds2.Tables(0).Rows.Count
                If count2 > 0 Then
                    r2 = ds2.Tables(0).Rows(0)
                    Dim countDataRow As Integer = r2("czChitietxuatScrap").ToString.Trim.Split("|").Count
                    DataGridkhoiluong.RowCount = countDataRow

                    If countDataRow > 0 And r2("czChitietxuatScrap").ToString.Trim.Split("|")(0).Trim <> "" Then
                        For i As Integer = 0 To countDataRow - 1
                            DataGridkhoiluong(0, i).Value = i + 1
                            For j As Integer = 1 To 5
                                Dim iii As Integer = r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_").Count
                                DataGridkhoiluong(j, i).Value = r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1)

                                If j = 2 Then
                                    nKhoiluongdaxuat = nKhoiluongdaxuat + CType(r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                                End If

                                If j = 3 Then
                                    nTongkhoiluongThucdaxuat = nTongkhoiluongThucdaxuat + CType(r2("czChitietxuatScrap").ToString.Trim.Split("|")(i).Split("_")(j - 1), Integer)
                                End If

                            Next

                        Next
                    End If
                End If
                '======================
                txtKLDaXuat.Text = nKhoiluongdaxuat
                txtKLgop.Text = nTongkhoiluongThucdaxuat
                txtKLConlai.Text = khoiluongOrder - nKhoiluongdaxuat
            End If
        End If
    End Sub
End Class