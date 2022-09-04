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
        '    If DateTimePicker1.Value = DateTimePicker2.Value Then
        '        MsgBox("Debe Ingresar Fechas distintas", "ATENCIÓN")
        '        Exit Sub
        '    End If
        'LE PONGO ESA VALIDACIÓN?

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox2.SelectedIndex = -1 Then
            MsgBox("Debe Ingresar un Campo para Buscar", "ATENCIÓN")
            ComboBox2.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Length = 0 Then
            MsgBox("Debe Ingresar Datos", "ATENCIÓN")
            TextBox1.Focus()
            Exit Sub
        End If

        If ComboBox2.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.id_med like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Nombre" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.nom_med like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Receta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.receta like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Cantidad existente" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.Cantidad_existente like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Empaque" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.presentacion like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Unidad de Medica" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.uni_medida like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Fecha de Caducidad" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.fec_caducidad like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Formula" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.formula like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Dosis" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.dosis like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Precausiones" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.precauciones like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Detalles" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' from medicamento e where e.descripcion like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

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