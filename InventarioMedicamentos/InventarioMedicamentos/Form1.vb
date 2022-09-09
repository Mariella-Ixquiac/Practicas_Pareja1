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

    Public Ban As Integer

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
            MessageBox.Show("Debe Ingresar un Usuario", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar una Contraseña", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        MessageBox.Show("contraseña o:" & TextBox2.Text & vbCrLf & "contrseña n:" & nuevaclave)
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
        Else
            MsgBox("El usuario o la contraseña son incorrectos")
        End If

        TextBox1.Text = ""
        TextBox2.Text = ""
        CheckBox1.Checked = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Ban = -1
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

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
