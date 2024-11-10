Imports System.Reflection.Emit

Public Class tap
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text.Length > 9 Then

            searchMENU()







            If DataGridView1.Rows.Count = 0 Then

                Panel2.Show()

                Panel1.Hide()
                '  Timer2.Enabled = True
                TextBox1.Clear()



            Else
                MsgBox("TENANT RFID ACCESS", MsgBoxStyle.Exclamation, "FUNCTION")
                TextBox1.Clear()
                Panel2.Hide()
                Panel1.Show()
                Dim i As Integer = DataGridView1.CurrentRow.Index
                Label11.Text = DataGridView1.Item(0, i).Value
                Label12.Text = DataGridView1.Item(1, i).Value
                Label21.Text = DataGridView1.Item(2, i).Value
                Label18.Text = DataGridView1.Item(3, i).Value
                Label19.Text = DataGridView1.Item(4, i).Value
                Label13.Text = DataGridView1.Item(5, i).Value
                Label14.Text = DataGridView1.Item(6, i).Value
                Label15.Text = DataGridView1.Item(7, i).Value
                '\\   skip muna to par ./. \\
                ' Label17.Text = DataGridView1.Item(8, i).Value
                Label23.Text = DataGridView1.Item(9, i).Value
                Label25.Text = DataGridView1.Item(10, i).Value
                Label26.Text = DataGridView1.Item(11, i).Value
            End If
        End If
    End Sub

    Sub searchMENU()
        Dim i As Integer
        DataGridView1.Rows.Clear()
        str = "Select * from TENANT_TBL where RFID like '%" & TextBox1.Text & "%' "
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            DataGridView1.Rows.Add(dr("TENANT_ID"), dr("RFID"), dr("FNAME"), dr("MNAME"), dr("LNAME"), dr("CONTACT"), dr("ADDRESS"), dr("EMAIL"), dr("TENANT_IMG"), dr("DATE_STAMP"), dr("USER_STAMP"), dr("STALL"))
        End While
    End Sub
    Private Sub tap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Panel2.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click, Label9.Click, Label8.Click, Label7.Click, Label6.Click, Label5.Click, Label17.Click, Label16.Click, Label15.Click, Label14.Click, Label13.Click, Label12.Click, Label11.Click, Label10.Click, Label19.Click, Label18.Click, Label21.Click, Label23.Click, Label25.Click, Label26.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel1.Hide()
        TextBox1.Clear()
    End Sub

    Private Sub Label27_Click(sender As Object, e As EventArgs) Handles Label27.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class