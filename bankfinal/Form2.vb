Public Class Form2

    Dim cn As New ADODB.Connection
    Dim r_branch As New ADODB.Recordset

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataDataSet.Branch_details' table. You can move, or remove it, as needed.
        Me.Branch_detailsTableAdapter.Fill(Me.DataDataSet.Branch_details)
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Users\Admin\Documents\Data.mdb"
        cn.Open()
        r_branch.Open("select * from Branch_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub
    Sub Reterive()
        TextBox1.Text = r_branch("Branch ID").Value
        TextBox2.Text = r_branch("Branch Code").Value
        TextBox3.Text = r_branch("Location").Value
        TextBox4.Text = r_branch("Total Customer").Value
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length <> 4 Then
        Else
        End If
        If TextBox2.Text.Length <> 4 Then
        Else
            If TextBox4.Text.Length <> 4 Then

            End If

        End If

        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Then
            MsgBox("Please enter all details!!!")
        Else
            Dim rs As New ADODB.Recordset
            rs.Open("select * from Branch_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            'rs.Move(r_branch.AbsolutePosition - 1)
            With rs
                .AddNew()
                .Fields("Branch ID").Value = TextBox1.Text
                .Fields("Branch Code").Value = TextBox2.Text
                .Fields("Location").Value = TextBox3.Text
                .Fields("Total Customer").Value = TextBox4.Text
            End With
            rs.Update()
            MsgBox("Saved Successfull....!")
            TextBox1.Text = rs.Fields("Branch ID").Value + 1
            rs.MoveNext()
            rs.Close()
            r_branch.Requery()
            rs = Nothing
        End If

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Then
            MsgBox("please enter all details to Delete!!!")
        Else
            Dim dl As New ADODB.Recordset
            dl.Open("select * from Branch_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            dl.Move(r_branch.AbsolutePosition - 1)
            dl.Fields("Branch ID").Value = TextBox1.Text
            dl.Fields("Branch Code").Value = TextBox2.Text
            dl.Fields("Location").Value = TextBox3.Text
            dl.Fields("Total Customer").Value = TextBox4.Text
            dl.Delete()
            MsgBox("Deleted.....!!!")
            dl.Close()
            r_branch.Requery()
            dl = Nothing
        End If
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Or TextBox3.Text = Nothing Or TextBox4.Text = Nothing Then
            MsgBox("please enter all details to Update!!!")
        Else
            Dim up As New ADODB.Recordset
            up.Open("select * from Branch_details", cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
            up.Move(r_branch.AbsolutePosition - 1)
            up.Fields("Branch ID").Value = TextBox1.Text
            up.Fields("Branch Code").Value = TextBox2.Text
            up.Fields("Location").Value = TextBox3.Text
            up.Fields("Total Customer").Value = TextBox4.Text
            up.Update()
            MsgBox("Updated.....!!!")
            up.Close()
            r_branch.Requery()
            up = Nothing
        End If
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If r_branch.RecordCount <= 0 Then
            MsgBox("There is no data")
        Else
            r_branch.MoveNext()
            If r_branch.EOF Then

                r_branch.MoveFirst()
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
            MsgBox("Branch ID must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Branch ID must be numbers only")

        End If
    End Sub

    Private Sub TextBox2_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Branch Code must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Branch Code must be numbers only")
        End If
    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Dim disallowedchars As String = "<.!@#$%^&*{<>}[]()~"
        If Char.IsLetter(e.KeyChar) = True Then
            e.Handled = True
            MsgBox("Total Customers must be numbers only")
        ElseIf disallowedchars.Contains(e.KeyChar.ToString.ToLower) Then
            e.KeyChar = ChrW(0)
            e.Handled = True
            MsgBox("Total Customers must be numbers only")
        End If
    End Sub
End Class
