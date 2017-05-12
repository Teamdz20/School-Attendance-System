Imports MySql.Data.MySqlClient

Public Class Login
    Dim MyConn As MySqlConnection
    Dim Command As MySqlCommand


    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()

    End Sub



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub

    Private Sub BunifuCheckbox1_OnChange(sender As Object, e As EventArgs) Handles BunifuCheckbox1.OnChange
        BunifuMaterialTextbox2.isPassword = Not BunifuCheckbox1.Checked

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton1.Click
        MyConn = New MySqlConnection
        MyConn.ConnectionString =
            "server=localhost;userid=sas;password=attendance;database=school_attendance"
        Dim Reader As MySqlDataReader

        Try
            MyConn.Open()
            Dim Query As String
            Query = "select * from login where username='" & BunifuMaterialTextbox1.Text & "'and password ='" & BunifuMaterialTextbox2.Text & "'"

            Command = New MySqlCommand(Query, MyConn)
            Reader = Command.ExecuteReader()

            If Reader.Read Then
                DashBoard.Show()
                Me.WindowState = FormWindowState.Minimized
                MyConn.Close()

            ElseIf BunifuMaterialTextbox1.Text = "" And BunifuMaterialTextbox2.Text = "" Then
                MessageBox.Show("All Fields Must Be Filled!")
            Else MessageBox.Show("All fields are required!")

            End If
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally
            MyConn.Dispose()

        End Try




    End Sub
End Class
