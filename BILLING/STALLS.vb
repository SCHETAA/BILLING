Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class STALLS
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        PictureBox1.BackColor = Color.PapayaWhip
        TextBox1.Text = Label1.Text
        searchMENU()
        STALLINFOS()
        STALLINFO.Show()
    End Sub

    Sub searchMENU()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from STALL_TBL where STALL_ID like '%" & TextBox1.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("STALL_ID"), dr("STALL_SIZE"), dr("STALL_PRICE"), dr("STALL_STATUS"))
        End While
    End Sub


    Sub STALLINFOS()
        Dim i As Integer = DataGridView1.CurrentRow.Index
        STALLINFO.Label1.Text = DataGridView1.Item(0, i).Value
        STALLINFO.Label2.Text = DataGridView1.Item(1, i).Value
        STALLINFO.Label3.Text = DataGridView1.Item(2, i).Value
        STALLINFO.Label7.Text = DataGridView1.Item(3, i).Value


    End Sub

    Private Sub STALLS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Refresh()
        connect()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PictureBox2.BackColor = Color.PapayaWhip
        TextBox1.Text = Label2.Text
        searchMENU()
        STALLINFOS()
        STALLINFO.Show()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        TextBox1.Text = Label3.Text
        searchMENU()
        STALLINFOS()
        STALLINFO.Show()
    End Sub
End Class