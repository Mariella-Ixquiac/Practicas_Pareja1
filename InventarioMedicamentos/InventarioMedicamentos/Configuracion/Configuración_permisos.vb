Imports System.Text
Imports System.Security.Cryptography
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Configuración_permisos
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Index_configuracion.Show()
    End Sub

    Private Sub Configuración_permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button3.Focus()
        GroupBox2.Enabled = 0
        GroupBox1.Enabled = 0
        GroupBox3.Enabled = 0
        GroupBox4.Enabled = 0
    End Sub

End Class