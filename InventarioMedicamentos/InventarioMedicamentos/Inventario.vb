Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Inventario
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' FROM medicamento e;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            ComboBox2.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            TextBox1.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
    End Sub
End Class