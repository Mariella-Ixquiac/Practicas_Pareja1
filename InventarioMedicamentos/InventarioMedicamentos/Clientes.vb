Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Clientes
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_cliente AS 'ID', c.nom_cliente as 'Nombre del Cliente', c.ape_cliente as 'Apellidos del Cliente', c.nit as 'NIT', c.telefono_cliente as 'Celular del Cliente' FROM clientes c;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        TextBox1.Focus()
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub limpiar2()
        TextBox4.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Sub Cargar_datos()
        conn.Open()
        Dim query As String = "SELECT * FROM clientes;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        'ComboBox1.DataSource = ds.Tables(0)
        'ComboBox1.DisplayMember = "nom_proveedores"
        'ComboBox1.ValueMember = "id_proveedores"
        conn.Close()
    End Sub

    Private Sub Clientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Cargar_datos()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        limpiar2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into clientes(nom_cliente,ape_cliente,nit,telefono_cliente)values(@nom,@ape,@nit,@tel);"

            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ape", TextBox6.Text)
            cmd.Parameters.AddWithValue("@nit", TextBox2.Text)
            cmd.Parameters.AddWithValue("@tel", TextBox3.Text)


            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
        Catch ex As Exception


        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update clientes set nom_cliente=@nom, ape_cliente=@ape, nit=@nit, telefono_cliente=@tel WHERE id_cliente=@id"

            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@ape", TextBox6.Text)
            cmd.Parameters.AddWithValue("@nit", TextBox2.Text)
            cmd.Parameters.AddWithValue("@tel", TextBox3.Text)

            cmd.Parameters.AddWithValue("@id", TextBox5.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from clientes where id_cliente=@id"
            cmd.Parameters.AddWithValue("@id", TextBox5.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

            limpiar()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try

            TextBox1.Text = row.Cells(1).Value.ToString()
            TextBox6.Text = row.Cells(2).Value.ToString()
            TextBox2.Text = row.Cells(3).Value.ToString()
            TextBox3.Text = row.Cells(4).Value.ToString()
            TextBox5.Text = row.Cells(0).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select * from clientes where id_cliente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select * from clientes where nom_cliente like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Apellidos" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select * from clientes where ape_cliente like '%" & TextBox4.Text & "%'"
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
                Dim query As String = "select * from clientes where nit like '%" & TextBox4.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Celular" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select * from clientes where telefono_cliente like '%" & TextBox4.Text & "%'"
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
End Class