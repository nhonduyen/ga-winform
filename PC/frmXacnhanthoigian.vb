Public Class frmXacnhanthoigian

    Private Sub btnXacnhan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnXacnhan.Click
        xacnhanthoigian = timeXacnhan.Text
        checkClick = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmXacnhanthoigian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timeXacnhan.Value = Now
    End Sub
End Class