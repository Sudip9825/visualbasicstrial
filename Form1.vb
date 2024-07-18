
Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
    Private Sub Guna2CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Guna2CheckBox1.CheckedChanged
        If Guna2CheckBox1.Checked = True Then
            guna2passwordtxtbox.PasswordChar = ""
        Else
            guna2passwordtxtbox.PasswordChar = "*"
        End If
    End Sub

    Private Sub Guna2registerButton_Click(sender As Object, e As EventArgs) Handles Guna2registerButton.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=LAPTOP-CRJNO9SI;Initial Catalog=expensetracker_users;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")
        con.Open()
        Dim query As String = "select * from expensetracker_users where
          FirstName=@fname,LastName=@lname,UserName=@uname,Email=@email and Password=@pass"
        Dim cmd As SqlCommand = New SqlCommand(query, con)
        cmd.Parameters.AddWithValue("@fname", Guna2fnameTextBox.Text)
        cmd.Parameters.AddWithValue("@lname", Guna2lastnameTextBox.Text)
        cmd.Parameters.AddWithValue("@uname", Guna2usernametxtbox.Text)
        cmd.Parameters.AddWithValue("@email", Guna2EmailTextBox.Text)
        cmd.Parameters.AddWithValue("@pass", guna2passwordtxtbox.Text)
        Dim dr As SqlDataReader
        If dr.HasRows = True Then
            MessageBox.Show("login success")
        Else
            MessageBox.Show("login failed")

        End If
    End Sub
End Class
