Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Medicamentos
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' FROM medicamento e;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        TextBox15.Focus()
        TextBox1.Clear()
        TextBox15.Text = ""
        CheckBox1.Checked = False
        TextBox14.Text = ""
        TextBox11.Text = ""
        TextBox12.Text = ""
        DateTimePicker1.Value = (Date.Now())
        TextBox9.Text = ""
        TextBox8.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub limpiar2()
        TextBox13.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Index.Show()
        limpiar()
        limpiar2()

        mostrar()
    End Sub

    Private Sub Medicamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox15.Focus()
        mostrar()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        limpiar()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        limpiar2()
        mostrar()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'Guardar
        conn = objetoconexion.AbrirCon

        If TextBox15.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Nombre del Medicamento.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox15.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Cantidad Existente.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If
        If TextBox14.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Empaque.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox14.Focus()
            Exit Sub
        End If
        If TextBox11.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Unidad de Medida.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox11.Focus()
            Exit Sub
        End If
        If TextBox9.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Formula.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox9.Focus()
            Exit Sub
        End If
        If TextBox8.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Dosis.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox8.Focus()
            Exit Sub
        End If
        If TextBox3.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Precauciones.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox3.Focus()
            Exit Sub
        End If
        If TextBox5.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Detalles.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Exit Sub
        End If
        If TextBox4.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Precio de Compra.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox4.Focus()
            Exit Sub
        End If
        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Precio de Venta.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub

        End If

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into medicamento(nom_med,receta,Cantidad_existente,presentacion,uni_medida,fec_caducidad,formula,dosis,precauciones,descripcion,precio_costo,precio_final)values(@nom,@rec,@can,@pre,@uni,@fec,@fom,@dos,@cau,@des,@pc,@pf);"

            cmd.Parameters.AddWithValue("@nom", TextBox15.Text)
            cmd.Parameters.AddWithValue("@rec", CheckBox1.Checked)
            cmd.Parameters.AddWithValue("@can", TextBox1.Text)
            cmd.Parameters.AddWithValue("@pre", TextBox14.Text)
            cmd.Parameters.AddWithValue("@uni", TextBox11.Text)
            cmd.Parameters.AddWithValue("@fec", DateTimePicker1.Value.Date)
            cmd.Parameters.AddWithValue("@fom", TextBox9.Text)
            cmd.Parameters.AddWithValue("@dos", TextBox8.Text)
            cmd.Parameters.AddWithValue("@cau", TextBox3.Text)
            cmd.Parameters.AddWithValue("@des", TextBox5.Text)
            cmd.Parameters.AddWithValue("@pc", TextBox4.Text)
            cmd.Parameters.AddWithValue("@pf", TextBox2.Text)

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
            cmd.CommandText = "update medicamento set nom_med=@nom, Cantidad_existente=@can, receta=@rec, presentacion=@pre, uni_medida=@uni, fec_caducidad=@fec, formula=@fom, dosis=@dos, precauciones=@cau, descripcion=@des, precio_costo=@pc, precio_final=@pf WHERE id_med=@id"

            cmd.Parameters.AddWithValue("@nom", TextBox15.Text)
            cmd.Parameters.AddWithValue("@rec", CheckBox1.Checked)
            cmd.Parameters.AddWithValue("@can", TextBox1.Text)
            cmd.Parameters.AddWithValue("@pre", TextBox14.Text)
            cmd.Parameters.AddWithValue("@uni", TextBox11.Text)
            cmd.Parameters.AddWithValue("@fec", DateTimePicker1.Value.Date)
            cmd.Parameters.AddWithValue("@fom", TextBox9.Text)
            cmd.Parameters.AddWithValue("@dos", TextBox8.Text)
            cmd.Parameters.AddWithValue("@cau", TextBox3.Text)
            cmd.Parameters.AddWithValue("@des", TextBox5.Text)
            cmd.Parameters.AddWithValue("@pc", TextBox4.Text)
            cmd.Parameters.AddWithValue("@pf", TextBox2.Text)


            cmd.Parameters.AddWithValue("@id", TextBox12.Text)

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
            cmd.CommandText = "delete from medicamento where id_med=@id"
            cmd.Parameters.AddWithValue("@id", TextBox12.Text)
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

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        'Está en DataGridView2_CellDoubleClick 
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox13.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox13.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.id_med like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.nom_med like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Receta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.receta like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Cantidad existente" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.Cantidad_existente like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Empaque" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.presentacion like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Unidad de Medica" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.uni_medida like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Fecha de Caducidad" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.fec_caducidad like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Formula" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.formula like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Dosis" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.dosis like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Precausiones" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.precauciones like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Detalles" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.descripcion like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Precio de Compra" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.precio_costo like '%" & TextBox13.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Precio de Venta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "select e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles', e.precio_costo as 'Precio Costo', e.precio_final as 'Precio Final' from medicamento e where e.precio_final like '%" & TextBox13.Text & "%'"
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

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try

            TextBox12.Text = row.Cells(0).Value.ToString()
            TextBox15.Text = row.Cells(1).Value.ToString()
            CheckBox1.Checked = row.Cells(2).Value.ToString()
            TextBox1.Text = row.Cells(3).Value.ToString()
            TextBox14.Text = row.Cells(4).Value.ToString()
            DateTimePicker1.Value = row.Cells(6).Value.ToString()
            TextBox11.Text = row.Cells(5).Value.ToString()
            TextBox9.Text = row.Cells(7).Value.ToString()
            TextBox8.Text = row.Cells(8).Value.ToString()
            TextBox3.Text = row.Cells(9).Value.ToString()
            TextBox5.Text = row.Cells(10).Value.ToString()
            TextBox4.Text = row.Cells(11).Value.ToString()
            TextBox2.Text = row.Cells(12).Value.ToString()

        Catch ex As Exception
        End Try

        Button11.Enabled = True
        Button13.Enabled = True
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TextBox15_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox15.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub CheckBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox14.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub DateTimePicker1_KeyDown(sender As Object, e As KeyEventArgs) Handles DateTimePicker1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox8_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox8.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub

    Private Sub TextBox11_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox11.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button14.PerformClick()
        End If
    End Sub



    Private Sub combobox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button10.PerformClick()
        End If
    End Sub

    Private Sub textbox13_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox13.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button10.PerformClick()
        End If
    End Sub

End Class