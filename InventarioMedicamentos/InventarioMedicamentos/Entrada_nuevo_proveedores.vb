Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_nuevo_proveedores
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', m.nom_marca as 'Marca' FROM proveedores p inner JOIN marca m on p.id_marca= m.id_marca;"
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

            Entrada_nuevo.TextBox9.Text = row.Cells(1).Value.ToString()
            Entrada_nuevo.TextBox4.Text = row.Cells(0).Value.ToString()
            Entrada_nuevo.TextBox8.Text = row.Cells(2).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Entrada_nuevo_proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox4.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where p.id_proveedores like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre del Proveedor" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where p.nom_proveedores like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Marca" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where m.nom_marca like '%" & TextBox4.Text & "%'"
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