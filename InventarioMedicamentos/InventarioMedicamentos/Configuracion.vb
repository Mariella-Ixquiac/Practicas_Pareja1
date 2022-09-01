Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Configuracion
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT l.id_login AS 'ID', l.usuario as 'Nombre del usuario', r.rol as 'Rol', l.nombre as 'Usuario', l.pssw as 'Clave' FROM login l inner JOIN rol r on l.id_rol= r.id_rol;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        TextBox1.Focus()
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
        TextBox5.Text = ""
        TextBox3.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub limpiar2()
        TextBox13.Text = ""
        ComboBox3.SelectedIndex = -1
    End Sub

    Sub Cargar_datos()
        conn.Open()
        Dim query As String = "SELECT * FROM rol;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        ComboBox2.DataSource = ds.Tables(0)
        ComboBox2.DisplayMember = "rol"
        ComboBox2.ValueMember = "id_rol"
        conn.Close()
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Configuracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        Cargar_datos()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        limpiar()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        limpiar2()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into login(usuario,nombre,id_rol,pssw)values(@usu,@nom,@rol,@psw);"

            cmd.Parameters.AddWithValue("@usu", TextBox3.Text)
            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@rol", ComboBox2.SelectedValue)
            cmd.Parameters.AddWithValue("@psw", TextBox7.Text)


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
            cmd.CommandText = "update login set usuario=@usu, nombre=@nom, id_rol=@rol, pssw=@psw WHERE id_login=@id"

            cmd.Parameters.AddWithValue("@usu", TextBox3.Text)
            cmd.Parameters.AddWithValue("@nom", TextBox1.Text)
            cmd.Parameters.AddWithValue("@rol", ComboBox2.SelectedValue)
            cmd.Parameters.AddWithValue("@psw", TextBox7.Text)

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
            cmd.CommandText = "delete from login where id_login=@id"
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

            TextBox3.Text = row.Cells(3).Value.ToString()
            TextBox1.Text = row.Cells(1).Value.ToString()
            ComboBox2.SelectedItem = row.Cells(2).Value.ToString()
            TextBox7.Text = row.Cells(4).Value.ToString()
            TextBox5.Text = row.Cells(0).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

End Class