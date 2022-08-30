Imports System.Text
Imports System.Security.Cryptography

Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Form1
    Dim CadenaConexion = "Server = localhost;Database=inventario_medicamentos;User id=root;Password=;Port=3306;"
    Dim conn As New MySqlConnection(CadenaConexion)
    Dim cmd As MySqlCommand

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
            MsgBox("Debe Ingresar un Usuario")
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text.Length = 0 Then
            MsgBox("Debe Ingresar una Contraseña")
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

        Index.Show()
                Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
End Class
