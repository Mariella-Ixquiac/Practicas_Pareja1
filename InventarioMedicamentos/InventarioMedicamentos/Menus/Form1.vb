Imports System.Text
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Form1
    Dim CadenaConexion = "Server = localhost;Database=inventario_medicamentos;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand
    Public id_rol As String

    Private Sub conectar()
        Dim squery As String = "SELECT * FROM login"
        Dim adpt As New MySqlDataAdapter(squery, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar un Usuario.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar una Contraseña.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        Dim codigo As New UnicodeEncoding()
            Dim md5 As New MD5CryptoServiceProvider()
            Dim clave As String
            clave = TextBox2.Text
            Dim hash() As Byte = md5.ComputeHash(codigo.GetBytes(clave))
            Dim nuevaclave As String
        nuevaclave = Convert.ToBase64String(hash)
        conn.Close()

        Dim comando As MySqlCommand = New MySqlCommand
        comando.Connection = conn

        conn.Open()
        comando.CommandText = "Select * From login Where usuario = '" + TextBox1.Text + "' And pssw = '" + TextBox2.Text + "'"
        Dim r As MySqlDataReader


        r = comando.ExecuteReader
        If r.HasRows <> False Then
            r.Read()
            id_rol = r.GetString("id_rol")
            Index.Show()
            Configuración_permisos.Show()
            Configuración_permisos.Hide()
            Me.Hide()

            If id_rol = "1" Then
                Index.Button5.Enabled = 1
                Index.Button3.Enabled = 1
                Index.Button4.Enabled = 1
                Index.Button6.Enabled = 1
                Index.Button2.Enabled = 1
                Index.Button1.Enabled = 1
                Index.Button7.Enabled = 1

                Index.Button1.BackColor = Color.Turquoise
                Index.Button2.BackColor = Color.Turquoise
                Index.Button6.BackColor = Color.Turquoise
                Index.Button5.BackColor = Color.Turquoise
                Index.Button3.BackColor = Color.Turquoise
                Index.Button4.BackColor = Color.Turquoise
                Index.Button7.BackColor = Color.Turquoise
            End If

            If id_rol = "2" Then
                Index.Button5.Enabled = 1
                Index.Button3.Enabled = 1
                Index.Button4.Enabled = 1
                Index.Button6.Enabled = 1
                Index.Button2.Enabled = 1
                Index.Button1.Enabled = 1
                Index.Button7.Enabled = 0
                Index.Button1.BackColor = Color.Turquoise
                Index.Button2.BackColor = Color.Turquoise
                Index.Button6.BackColor = Color.Turquoise
                Index.Button5.BackColor = Color.Turquoise
                Index.Button3.BackColor = Color.Turquoise
                Index.Button4.BackColor = Color.Turquoise
                Index.Button7.BackColor = Color.LightSeaGreen


            End If

            If id_rol = "3" Then
                Index.Button5.Enabled = 1
                Index.Button3.Enabled = 1
                Index.Button4.Enabled = 1
                Index.Button6.Enabled = 0
                Index.Button2.Enabled = 0
                Index.Button1.Enabled = 0
                Index.Button7.Enabled = 0
                Index.Button1.BackColor = Color.LightSeaGreen
                Index.Button2.BackColor = Color.LightSeaGreen
                Index.Button6.BackColor = Color.LightSeaGreen
                Index.Button5.BackColor = Color.Turquoise
                Index.Button3.BackColor = Color.Turquoise
                Index.Button4.BackColor = Color.Turquoise
                Index.Button7.BackColor = Color.LightSeaGreen
            End If

            If id_rol = "4" Then
                Index.Button5.Enabled = 0
                Index.Button3.Enabled = 0
                Index.Button4.Enabled = 0
                Index.Button6.Enabled = 1
                Index.Button2.Enabled = 1
                Index.Button1.Enabled = 1
                Index.Button7.Enabled = 0
                Index.Button1.BackColor = Color.Turquoise
                Index.Button2.BackColor = Color.Turquoise
                Index.Button6.BackColor = Color.Turquoise
                Index.Button5.BackColor = Color.LightSeaGreen
                Index.Button3.BackColor = Color.LightSeaGreen
                Index.Button4.BackColor = Color.LightSeaGreen
                Index.Button7.BackColor = Color.LightSeaGreen
            End If
        Else
            MessageBox.Show("El usuario o la contraseña son incorrectos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        CheckBox1.Checked = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Focus()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Call conectar()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.PasswordChar = ""
        Else
            TextBox2.PasswordChar = "*"
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub
End Class
