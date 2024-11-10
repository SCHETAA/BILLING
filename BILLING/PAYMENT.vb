Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class PAYMENT
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim p As Integer
        Dim sum As Integer
        If AMOUNTTB.Text = "" Then
            MsgBox("PLEASE INPUT AMOUNT!!", vbCritical, "PAYMENT FAILED")
        Else
            p = Val(AMOUNTTB.Text)

            If (p < Label5.Text) Then
                MsgBox("PAYMENT UNABLE TO PROCESS", vbCritical, "PAYMENT FAILED")

            Else

                sum = AMOUNTTB.Text - Label5.Text
                Label7.Text = sum
                MsgBox("PAYMENT RECEIVED!")
                TextBox1.Text = "COMPLETE"

                addTRansac()





            End If
        End If
    End Sub

    Sub addTRansac()
        Dim cntun, cntflb As String


        str = "Select COUNT(TENANT_ID) as cntun from TRANSACTION_TBL where RFID = '" & tap.Label12.Text & "'" 'RFID txtbox label 12
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntun = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntun = "1" Then
            MsgBox("Username Already Exist")
        End If

        str = "Select COUNT(TENANT_ID) as cntflb from TRANSACTION_TBL where STALL_ID = '" & tap.Label26.Text & "' and PURCHASER = '" & TextBox2.Text & "' and AMOUNTDUE = '" & Label5.Text & "' and PAYMENT = '" & AMOUNTTB.Text & "' and CHANGE = '" & Label7.Text & "' and STATUS = '" & TextBox1.Text & "' and DATE = '" & Label18.Text & "'"
        cmd = New SqlClient.SqlCommand(str, sqlconn)
        dr = cmd.ExecuteReader
        While dr.Read
            cntflb = dr.GetValue(0)
        End While
        dr.Close()
        cmd.Dispose()

        If cntflb = "1" Then
            MsgBox("User Already Exist")
        End If

        If cntun = "0" And cntflb = "0" Then


            query = "insert into TRANSACTION_TBL (TENANT_ID,RFID,PURCHASER,AMOUNTDUE,PAYMENT,CHANGE,STATUS,DATE) values (@TENANT_ID,@RFID,@PURCHASER,@AMOUNTDUE,@PAYMENT,@CHANGE,@STATUS,@DATE)"
            cmd = New SqlClient.SqlCommand(query, sqlconn)

            With cmd


                .Parameters.AddWithValue("@TENANT_ID", tap.Label11.Text)
                .Parameters.AddWithValue("@RFID", tap.Label12.Text)
                .Parameters.AddWithValue("@PURCHASER", TextBox2.Text)
                .Parameters.AddWithValue("@AMOUNTDUE", Label5.Text)
                .Parameters.AddWithValue("@PAYMENT", AMOUNTTB.Text)
                .Parameters.AddWithValue("@CHANGE", Label7.Text)
                .Parameters.AddWithValue("@STATUS", TextBox1.Text)
                .Parameters.AddWithValue("@DATE", Label18.text)






            End With
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End If
        dr.Close()
        cmd.Dispose()

    End Sub

    Private Sub PAYMENT_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click, Label12.Click, Label13.Click, Label17.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label18.Text = Date.Now.ToString("dddd, MMMM d, yyyy")
    End Sub
End Class