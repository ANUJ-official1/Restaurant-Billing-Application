Public Class loginform
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim validCredentials As New Dictionary(Of String, String) From {
          {"Anuj", "Mourya"},
          {"Anjali", "Sinha"},
          {"Manisha", "Mani"},
          {"Sharmila", "Shy"},
          {"Amol", "Patle"},
          {"Pratik", "Pratik"}
      }

        ' Get the input from the text boxes
        Dim username As String = TextBoxUsername.Text
        Dim password As String = TextBoxPassword.Text

        ' Check if the credentials are valid
        If validCredentials.ContainsKey(username) AndAlso validCredentials(username) = password Then
            MessageBox.Show("Login successful!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Dim Menuform As New Menuform()
            Menuform.Show()
            Me.Hide()
        Else
            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TextBoxUsername.Clear()
        TextBoxPassword.Clear()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged

    End Sub

    Private Sub TextBoxUsername_TextChanged(sender As Object, e As EventArgs) Handles TextBoxUsername.TextChanged

    End Sub
End Class