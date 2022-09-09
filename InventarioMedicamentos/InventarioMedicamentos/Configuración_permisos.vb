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
        Index.Show()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Form1.id_rol = 1 Then

            'Salidas
            If CheckBox14.Checked = True Then
                Index.Button1.Enabled = 1
            Else
                Index.Button1.Enabled = 0
            End If

            'Entradas
            If CheckBox13.Checked = True Then
                Index.Button2.Enabled = 1
            Else
                Index.Button2.Enabled = 0
            End If

            'Inventario
            If CheckBox12.Checked = True Then
                Index.Button6.Enabled = 1
            Else
                Index.Button6.Enabled = 0
            End If

            'Medicamentos/Productos
            If CheckBox11.Checked = True Then
                Index.Button3.Enabled = 1
            Else
                Index.Button3.Enabled = 0
            End If

            'Proveedores
            If CheckBox10.Checked = True Then
                Index.Button5.Enabled = 1
            Else
                Index.Button5.Enabled = 0
            End If

            'Clientes
            If CheckBox9.Checked = True Then
                Index.Button4.Enabled = 1
            Else
                Index.Button4.Enabled = 0
            End If

            'Configuración
            If CheckBox8.Checked = False Then
                Index.Button7.Enabled = 1
            Else
                Index.Button7.Enabled = 0
            End If
        End If



        If Form1.id_rol = 4 Then
            'Salidas
            If CheckBox1.Checked = True Then
                Index.Button1.Enabled = 1
            Else
                Index.Button1.Enabled = 0
            End If


            'Entradas
            If CheckBox2.Checked = True Then
                Index.Button2.Enabled = 1
            Else
                Index.Button2.Enabled = 0
            End If


            'Inventario
            If CheckBox3.Checked = True Then
                Index.Button6.Enabled = 1
            Else
                Index.Button6.Enabled = 0
            End If


            'Medicamentos/ Productos
            If CheckBox4.Checked = True Then
                Index.Button3.Enabled = 1
            Else
                Index.Button3.Enabled = 0
            End If


            'Proveedores
            If CheckBox5.Checked = True Then
                Index.Button5.Enabled = 1
            Else
                Index.Button5.Enabled = 0
            End If


            'Clientes
            If CheckBox6.Checked = True Then
                Index.Button4.Enabled = 1
            Else
                Index.Button4.Enabled = 0
            End If

            Form1.Ban2 = 1
        End If
    End Sub

    Private Sub Configuración_permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        GroupBox2.Enabled = 0

        GroupBox1.Enabled = 0


        If Form1.Ban < 0 And Form1.Ban2 < 0 Then
            If Form1.id_rol = "1" Then

                Index.Button7.Enabled = 1
            End If


            If Form1.id_rol = "4" Then

                Index.Button7.Enabled = 0

            End If
        End If

    End Sub

End Class