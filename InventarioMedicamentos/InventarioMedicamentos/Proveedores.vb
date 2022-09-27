Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Proveedores
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', p.telefono as 'Celular', m.nom_marca as 'Marca', p.id_marca as 'ID de la Marca' FROM proveedores p inner JOIN marca m on p.id_marca= m.id_marca;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
        TextBox13.Focus()
    End Sub

    Private Sub mostrar2()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT m.id_marca AS 'ID', m.nom_marca as 'Nombre de la marca', m.direccion as 'domicilio', m.calificacion as 'Puntaje' FROM marca m;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        TextBox13.Focus()
        TextBox10.Text = ""
        TextBox13.Text = ""
        ComboBox3.SelectedValue = -1
        TextBox12.Text = ""
    End Sub

    Private Sub limpiar2()
        TextBox11.Text = ""
        ComboBox4.SelectedIndex = -1
    End Sub

    Private Sub limpiar3()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub

    Sub Cargar_datos()
        conn.Open()
        Dim query As String = "SELECT * FROM marca;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        ComboBox3.DataSource = ds.Tables(0)
        ComboBox3.DisplayMember = "nom_marca"
        ComboBox3.ValueMember = "id_marca"
        conn.Close()
    End Sub

    Private Sub Proveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        mostrar()
        mostrar2()
        Cargar_datos()
        TextBox13.Focus()
        ComboBox3.SelectedValue = -1
        DataGridView1.Columns(4).Visible = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        mostrar()
        Me.Hide()
        Index.Show()
        limpiar()
        limpiar2()
        limpiar3()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        limpiar()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        limpiar2()
        mostrar()
        mostrar2()
        Cargar_datos()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        limpiar3()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'Guardar
        conn = objetoconexion.AbrirCon

        If TextBox13.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Nombre.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox13.Focus()
            Exit Sub
        End If
        If ComboBox3.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar Marca.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Exit Sub
        End If
        If TextBox12.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Telefono.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox12.Focus()
            Exit Sub
        End If

        If TextBox12.Text.Length < 8 Then
            MessageBox.Show("Debe Ingresar un Número de Teléfono Valido.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox12.Focus()
            Exit Sub
        End If

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into proveedores(nom_proveedores,telefono,id_marca)values(@nom,@tel,@mar);"

            cmd.Parameters.AddWithValue("@nom", TextBox13.Text)
            cmd.Parameters.AddWithValue("@mar", ComboBox3.SelectedValue)
            cmd.Parameters.AddWithValue("@tel", TextBox12.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
            limpiar()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update proveedores set nom_proveedores=@nom, telefono=@tel, id_marca=@mar WHERE id_proveedores=@id"

            cmd.Parameters.AddWithValue("@nom", TextBox13.Text)
            cmd.Parameters.AddWithValue("@mar", ComboBox3.SelectedValue)
            cmd.Parameters.AddWithValue("@tel", TextBox12.Text)

            cmd.Parameters.AddWithValue("@id", TextBox10.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
            limpiar()


        Catch ex As Exception
        End Try

        Button11.Enabled = False
        Button13.Enabled = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from proveedores where id_proveedores=@id"
            cmd.Parameters.AddWithValue("@id", TextBox10.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

            limpiar()

        Catch ex As Exception
        End Try

        Button11.Enabled = False
        Button13.Enabled = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Lo cambié al DataGridView1_CellDoubleClick
    End Sub

    Private Sub TextBox12_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox12.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        conn = objetoconexion.AbrirCon
        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Nombre.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If
        If TextBox5.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Dirección.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Exit Sub
        End If
        If TextBox6.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Calificación.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Exit Sub
        End If

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into marca(nom_marca,direccion,calificacion)values(@nom,@dir,@cali);"

            cmd.Parameters.AddWithValue("@nom", TextBox2.Text)
            cmd.Parameters.AddWithValue("@dir", TextBox5.Text)
            cmd.Parameters.AddWithValue("@cali", TextBox6.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            Cargar_datos()
            mostrar2()
            limpiar3()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update marca set nom_marca=@nom, direccion=@dir, calificacion=@cali WHERE id_marca=@id"

            cmd.Parameters.AddWithValue("@nom", TextBox2.Text)
            cmd.Parameters.AddWithValue("@dir", TextBox5.Text)
            cmd.Parameters.AddWithValue("@cali", TextBox6.Text)

            cmd.Parameters.AddWithValue("@id", TextBox1.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            Cargar_datos()
            mostrar2()
            limpiar3()

        Catch ex As Exception
        End Try

        Button8.Enabled = False
        Button15.Enabled = False
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from marca WHERE id_marca=@id"
            cmd.Parameters.AddWithValue("@id", TextBox1.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar2()

            limpiar2()

        Catch ex As Exception
        End Try

        Button8.Enabled = False
        Button15.Enabled = False
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        'Lo cambié al DataGridView2_CellDoubleClick
    End Sub

    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ComboBox4.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox4.Focus()
            Exit Sub
        End If
        If TextBox11.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox11.Focus()
            Exit Sub
        End If

        If ComboBox4.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', p.telefono as 'Celular', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where p.id_proveedores like '%" & TextBox11.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox4.SelectedItem = "Nombre" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', p.telefono as 'Celular', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where p.nom_proveedores like '%" & TextBox11.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try


        ElseIf ComboBox4.SelectedItem = "Celular" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', p.telefono as 'Celular', m.nom_marca as 'Marca' from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where p.telefono like '%" & TextBox11.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox4.SelectedItem = "Marca" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select p.id_proveedores AS 'ID', p.nom_proveedores as 'Nombre del Proveedor', p.telefono as 'Celular', m.nom_marca as 'Marca', p.id_marca from proveedores p inner JOIN marca m on p.id_marca= m.id_marca where m.nom_marca like '%" & TextBox11.Text & "%'"
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

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try

            TextBox10.Text = row.Cells(0).Value.ToString()
            TextBox12.Text = row.Cells(2).Value.ToString()
            TextBox13.Text = row.Cells(1).Value.ToString()
            Dim x As String
            x = row.Cells(3).Value.ToString()
            ComboBox3.SelectedIndex = row.Cells(4).Value - 1

            DataGridView1.Columns(4).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

        Button11.Enabled = True
        Button13.Enabled = True
    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try

            TextBox2.Text = row.Cells(1).Value.ToString()
            TextBox5.Text = row.Cells(2).Value.ToString()
            TextBox6.Text = row.Cells(3).Value.ToString()
            TextBox1.Text = row.Cells(0).Value.ToString()

        Catch ex As Exception
        End Try

        Button8.Enabled = True
        Button15.Enabled = True
    End Sub

    Private Sub textbox13_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox13.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub combobox3_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub textbox12_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox12.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub



    Private Sub textbox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub

    Private Sub textbox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub

    Private Sub textbox6_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox6.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button5.PerformClick()
        End If
    End Sub



    Private Sub combobox4_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button10.PerformClick()
        End If
    End Sub

    Private Sub textbox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button10.PerformClick()
        End If
    End Sub

End Class