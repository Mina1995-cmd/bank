Public Class Form3
    Dim cn As New ADODB.Connection
    Dim r_customer As New ADODB.Recordset
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataDataSet.Customer_details' table. You can move, or remove it, as needed.
        Me.Customer_detailsTableAdapter.Fill(Me.DataDataSet.Customer_details)
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\Admin\Documents\Data.mdb"
        cn.Open()

        r_customer.Open("select * from Customer_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)

        Me.TextBox5.Text = Form2.TextBox1.Text
    End Sub
    Sub Reterive()
        TextBox1.Text = r_customer("Account Number").Value
        TextBox2.Text = r_customer(" Name").Value
        TextBox3.Text = r_customer("Address").Value
        TextBox4.Text = r_customer("Balance").Value
        TextBox5.Text = r_customer("Branch ID").Value
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 4 Then
        Else
            If TextBox4.Text.Length <> 6 Then
            Else

            End If
        End If
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Then
            MsgBox("Please enter all details!!!")
        Else
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Customer_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            'rs.Move(r_branch.AbsolutePosition - 1)
            With rs
                .AddNew()
                .Fields("Account Number").Value = TextBox1.Text
                .Fields("Name").Value = TextBox2.Text
                .Fields("Address").Value = TextBox3.Text
                .Fields("Balance").Value = TextBox4.Text
                .Fields("Branch ID").Value = TextBox5.Text
            End With
            rs.Update()
            MsgBox("Saved Successfull....!")
            TextBox1.Text = rs.Fields("Account Number").Value + 1
            rs.MoveNext()
            rs.Close()
            r_customer.Requery()
            rs = Nothing
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Then
            MsgBox("please enter Account Number to Delete!!!")
            Dim dl As New ADODB.Recordset
            dl.Open("select * from Customer_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            dl.Move(r_customer.AbsolutePosition - 1)
            dl.Fields("Account Number").Value = TextBox1.Text
            dl.Fields("Name").Value = TextBox2.Text
            dl.Fields("Address").Value = TextBox3.Text
            dl.Fields("Balance").Value = TextBox4.Text
            dl.Fields("Branch ID").Value = TextBox5.Text
            dl.Delete()
            MsgBox("Deleted.....!!!")
            dl.Close()
            r_customer.Requery()
            dl = Nothing
        End If

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim up As New ADODB.Recordset
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Or TextBox5.Text = Nothing Then
            MsgBox("please enter Account Number to Update!!!")
        Else
            up.Open("select * from Customer_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            up.Move(r_customer.AbsolutePosition - 1)
            up.Fields("Account Number").Value = TextBox1.Text
            up.Fields("Name").Value = TextBox2.Text
            up.Fields("Address").Value = TextBox3.Text
            up.Fields("Balance").Value = TextBox4.Text
            up.Fields("Branch ID").Value = TextBox5.Text
            up.Update()
            MsgBox("Updated.....!!!")
            up.Close()
            r_customer.Requery()
            up = Nothing

        End If
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        If r_customer.RecordCount <= 0 Then
            MsgBox("There is no data")
        Else
            r_customer.MoveNext()
            If r_customer.EOF Then

                r_customer.MoveFirst()
            End If
            Reterive()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Account Number must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Account Number must be numbers only")
        End If
    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Balance must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Balance must be numbers only")
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Branch ID must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Branch ID must be numbers only")
        End If
    End Sub
End Class

