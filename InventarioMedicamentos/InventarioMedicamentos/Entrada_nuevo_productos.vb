﻿Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_nuevo_productos
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT m.id_med AS 'ID', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento m;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar2()
        TextBox4.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Entrada_nuevo_productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try

            Entrada_nuevo.TextBox10.Text = row.Cells(1).Value.ToString()
            Entrada_nuevo.DateTimePicker1.Value = row.Cells(2).Value.ToString()
            Entrada_nuevo.TextBox5.Text = row.Cells(0).Value.ToString()
            Entrada_nuevo.TextBox3.Text = row.Cells(3).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Debe Ingresar un Campo para Buscar")
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox4.Text.Length = 0 Then
            MsgBox("Debe Ingresar Datos")
            TextBox4.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select m.id_med AS 'ID', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento m where m.id_med like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre del Medicamento" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select m.id_med AS 'ID', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento m where m.nom_med like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Fecha de Caducidad" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select m.id_med AS 'ID', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento m where m.fec_caducidad like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Cantidad de existencia" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select m.id_med AS 'ID', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento m where m.Cantidad_existente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        limpiar2()
        mostrar()
    End Sub

End Class