Imports MySql.Data.MySqlClient
Public Class DashBoard
    Dim MyConn As MySqlConnection
    Dim Command As MySqlCommand
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub PictureBox2_DoubleClick(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Do While Panel2.Width > 70
            Panel2.Width = Panel2.Width - 1
        Loop
        PictureBox6.Visible = True

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Do While Panel2.Width < 170
            Panel2.Width = Panel2.Width + 1
        Loop
        PictureBox6.Visible = False
    End Sub



    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Me.Close()
        Login.WindowState = FormWindowState.Normal

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs)
        TabControl1.SelectedIndex = 0
        dash.Show()
        BunifuCustomLabel1.Text = "SCHOOL ATTENDANCE SYSTEM"

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        TabControl1.SelectedIndex = 0
        attendance.Show()
        BunifuCustomLabel1.Text = "ATTENDANCE"

    End Sub

    Private Sub BunifuFlatButton4_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton4.Click
        TabControl1.SelectedIndex = 2
        registration.Show()
        BunifuCustomLabel1.Text = "REGISTRATION"
    End Sub

    Private Sub BunifuFlatButton3_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton3.Click
        TabControl1.SelectedIndex = 1
        statistics.Show()
        BunifuCustomLabel1.Text = "STATISTICS"
    End Sub


    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        OpenFileDialog1.ShowDialog()
        PictureBox2.ImageLocation = OpenFileDialog1.FileName

    End Sub

    Private Sub BunifuCards8_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BunifuImageButton2_Click(sender As Object, e As EventArgs) Handles BunifuImageButton2.Click
        MyConn = New MySqlConnection
        MyConn.ConnectionString =
            "server=localhost;userid=sas;password=attendance;database=school_attendance"

        Try
            MyConn.Open()
            Dim Query As String
            Query = ("INSERT INTO `course_registration`( `first_name`, `middle_name`, `last_name`, `date_of_birth`, `gender`, `email`, `phone_number`, `student_picture`, `level`, `courses`)
                     VALUES( '" & BunifuMetroTextbox1.Text & "','" & BunifuMetroTextbox2.Text & "','" & BunifuMetroTextbox3.Text & "','" & MetroDateTime1.Text & "','" & BunifuDropdown1.selectedValue & "','" & BunifuMetroTextbox4.Text & "','" & BunifuMetroTextbox5.Text & "','" & PictureBox2.ImageLocation & "' ,
   '" & BunifuDropdown2.selectedValue & "','" & CheckedListBox1.ValueMember & "')")
            Command = New MySqlCommand(Query, MyConn)
            Command.ExecuteNonQuery()
            MessageBox.Show("Registration Completed")
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        Finally

            MyConn.Close()

        End Try
    End Sub

    Private Sub BunifuMetroTextbox6_OnValueChanged(sender As Object, e As EventArgs)
        Enabled = False
    End Sub
    Sub dload()
        Dim con As New MySqlConnection
        con.ConnectionString = "server=localhost; userid=root; password=; database= school_attendance"
        con.Open()
        Dim cmd As New MySqlCommand("select * from course_registration", con)
        Dim adp As New MySqlDataAdapter(cmd)
        Dim a As New DataSet()
        adp.Fill(a, "course_registration")
        BunifuCustomDataGrid1.DataSource = a.Tables("course_registration").DefaultView
        con.Close()


    End Sub
    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dload()
    End Sub

    Sub checkme()

    End Sub
    Private Sub BunifuCards2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub BunifuFlatButton5_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton5.Click
        Dim conn As New MySqlConnection
        conn.ConnectionString = "server=localhost; userid=root; password=; database=school_attendance"
        Dim cmd As MySqlCommand

        Try
            conn.Open()

            Dim query1 As String
            query1 = "insert into attendance(studentID,status,course) values('" & BunifuMaterialTextbox1.Text & "','" & MetroComboBox1.SelectedItem & "', '" & MetroComboBox2.SelectedItem & "') "
            cmd = New MySqlCommand(query1, conn)

            If BunifuMaterialTextbox1.Text = "" Or MetroComboBox1.SelectedItem = "" Or MetroComboBox2.SelectedItem = "" Then
                MessageBox.Show("Fill all fields!")

            Else
                cmd.ExecuteNonQuery()
                MessageBox.Show("Submission Successful!")
                BunifuMaterialTextbox1.Text = ""
                MetroComboBox1.SelectedItem = ""
                MetroComboBox2.SelectedItem = ""
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        Finally

            conn.Close()

        End Try

    End Sub

    Private Sub MetroComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox2.SelectedIndexChanged

    End Sub

    Private Sub MetroComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MetroComboBox1.SelectedIndexChanged

    End Sub

    Private Sub BunifuMaterialTextbox1_OnValueChanged(sender As Object, e As EventArgs) Handles BunifuMaterialTextbox1.OnValueChanged

    End Sub
End Class