Public Class Form5
    Dim cn As New ADODB.Connection
    Dim r_transaction As New ADODB.Recordset
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataDataSet.Transaction_details' table. You can move, or remove it, as needed.
        Me.Transaction_detailsTableAdapter.Fill(Me.DataDataSet.Transaction_details)
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\Admin\Documents\Data.mdb"
        cn.Open()

        r_transaction.Open("select * from Transaction_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        Me.TextBox2.Text = Form2.TextBox1.Text
        Me.TextBox3.Text = Form3.TextBox1.Text
    End Sub
    Sub Reterive()
        TextBox1.Text = r_transaction("Transaction ID").Value
        TextBox2.Text = r_transaction("Branch ID").Value
        TextBox3.Text = r_transaction("Account Number").Value
        TextBox4.Text = r_transaction("Withdraw").Value
        TextBox5.Text = r_transaction("Deposit").Value
        TextBox6.Text = r_transaction("Date").Value


    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Or TextBox6.Text = Nothing Then
            MsgBox("Please enter all details!!!")
        Else
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Transaction_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            'rs.Move(r_branch.AbsolutePosition - 1)
            With rs
                .AddNew()
                .Fields("Transaction ID").Value = TextBox1.Text
                .Fields("Branch ID").Value = TextBox2.Text
                .Fields("Account Number").Value = TextBox3.Text
                .Fields("Withdraw").Value = TextBox4.Text
                .Fields("Deposit").Value = TextBox5.Text
                .Fields("Date").Value = TextBox6.Text

            End With
            rs.Update()
            MsgBox("Saved Successfull....!")
            TextBox1.Text = rs.Fields("Transaction ID").Value + 1
            rs.MoveNext()
            rs.Close()
            r_transaction.Requery()
            rs = Nothing
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text.Length <> 4 Then
        Else
            If TextBox4.Text.Length <> 6 Then
            Else
                If TextBox5.Text.Length <> 6 Then

                End If

            End If
        End If

        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Or TextBox6.Text = Nothing Then
            MsgBox("please enter all details to Delete!!!")

        Else
            Dim dl As New ADODB.Recordset
            dl.Open("select * from Transaction_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            dl.Move(r_transaction.AbsolutePosition - 1)
            dl.Fields("Transaction ID").Value = TextBox1.Text
            dl.Fields("Branch ID").Value = TextBox2.Text
            dl.Fields("Account Number").Value = TextBox3.Text
            dl.Fields("Withdraw").Value = TextBox4.Text
            dl.Fields("Deposit").Value = TextBox5.Text
            dl.Fields("Date").Value = TextBox6.Text
            dl.Delete()
            MsgBox("Deleted.....!!!")
            dl.Close()
            r_transaction.Requery()
            dl = Nothing
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim up As New ADODB.Recordset
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Or TextBox6.Text = Nothing Then
            MsgBox("please enter  to Delete!!!")
        Else
            up.Open("select * from Transaction_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            up.Move(r_transaction.AbsolutePosition - 1)
            up.Fields("Transaction ID").Value = TextBox1.Text
            up.Fields("Branch ID").Value = TextBox2.Text
            up.Fields("Account Number").Value = TextBox3.Text
            up.Fields("Withdraw").Value = TextBox4.Text
            up.Fields("Deposit").Value = TextBox5.Text
            up.Fields("Date").Value = TextBox6.Text
            up.Update()
            MsgBox("Updated.....!!!")
            up.Close()
            r_transaction.Requery()
            up = Nothing
        End If
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        If r_transaction.RecordCount <= 0 Then
            MsgBox("There is no data")
        Else
            r_transaction.MoveNext()
            If r_transaction.EOF Then

                r_transaction.MoveFirst()
            End If
            Reterive()
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Transaction ID must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Transaction ID must be numbers only")
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Withdraw must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Withdraw must be numbers only")
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Deposit must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Deposit must be numbers only")
        End If
    End Sub
End Class

