Public Class STALLINFO
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        STALLS.PictureBox1.BackColor = Color.DodgerBlue
    End Sub

    Private Sub STALLINFO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        connect()
    End Sub
End Class