Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Salida_nuevo_cliente
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT' FROM clientes c;"
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

    Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try

            Salida_Nuevo.TextBox9.Text = row.Cells(1).Value.ToString()
            Salida_Nuevo.TextBox8.Text = row.Cells(3).Value.ToString()
            Salida_Nuevo.TextBox4.Text = row.Cells(2).Value.ToString()
            Salida_Nuevo.TextBox2.Text = row.Cells(0).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Salida_nuevo_cliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBox1.Focus()
        mostrar()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        TextBox4.Text = ""
        ComboBox1.SelectedIndex = -1
        Me.Hide()
        mostrar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox4.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT' FROM clientes c where c.id_cliente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre del Cliente" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT' FROM clientes c where c.nom_cliente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Apellidos del Cliente" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT' FROM clientes c where c.ape_cliente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "NIT" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT' FROM clientes c where c.nit like '%" & TextBox4.Text & "%'"
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

    Private Sub combobox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub

    Private Sub textbox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub

End Class