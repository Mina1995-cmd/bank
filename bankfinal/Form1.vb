Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "a" And TextBox2.Text = "a" Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
            Me.Hide()
            Form2.Show()
        Else
            MsgBox("enter valid username and password")


        End If

    End Sub
End Class

