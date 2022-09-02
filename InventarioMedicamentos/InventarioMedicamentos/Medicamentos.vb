Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Medicamentos
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

    Private Sub limpiar()
        TextBox15.Focus()
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
    End Sub

    Private Sub limpiar2()
        TextBox13.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Medicamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            MsgBox("Debe Ingresar Nombre del Medicamento")
            TextBox15.Focus()
            Exit Sub
        End If
        If TextBox14.Text.Length = 0 Then
            MsgBox("Debe Ingresar Empaque")
            TextBox14.Focus()
            Exit Sub
        End If
        If TextBox11.Text.Length = 0 Then
            MsgBox("Debe Ingresar Unidad de Medida")
            TextBox11.Focus()
            Exit Sub
        End If
        
        If TextBox9.Text.Length = 0 Then
            MsgBox("Debe Ingresar Formula")
            TextBox9.Focus()
            Exit Sub
        End If
        If TextBox8.Text.Length = 0 Then
            MsgBox("Debe Ingresar Dosis")
            TextBox8.Focus()
            Exit Sub
        End If
        If TextBox3.Text.Length = 0 Then
            MsgBox("Debe Ingresar Precauciones")
            TextBox3.Focus()
            Exit Sub
        End If
        If TextBox5.Text.Length = 0 Then
            MsgBox("Debe Ingresar Descripción")
            TextBox5.Focus()
            Exit Sub
        End If

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into medicamento(nom_med,receta,Cantidad_existente,presentacion,uni_medida,fec_caducidad,formula,dosis,precauciones,descripcion)values(@nom,@rec,@can,@pre,@uni,@fec,@fom,@dos,@cau,@des);"

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

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update medicamento set nom_med=@nom, Cantidad_existente=@can, receta=@rec, presentacion=@pre, uni_medida=@uni, fec_caducidad=@fec, formula=@fom, dosis=@dos, precauciones=@cau, descripcion=@des WHERE id_med=@id"

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

            cmd.Parameters.AddWithValue("@id", TextBox12.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

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

        If ComboBox1.SelectedItem = "ID" Then
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

        ElseIf ComboBox1.SelectedItem = "Nombre" Then
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

        ElseIf ComboBox1.SelectedItem = "Receta" Then
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

        ElseIf ComboBox1.SelectedItem = "Cantidad existente" Then
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

        ElseIf ComboBox1.SelectedItem = "Empaque" Then
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

        ElseIf ComboBox1.SelectedItem = "Unidad de Medica" Then
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

        ElseIf ComboBox1.SelectedItem = "Fecha de Caducidad" Then
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

        ElseIf ComboBox1.SelectedItem = "Formula" Then
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

        ElseIf ComboBox1.SelectedItem = "Dosis" Then
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

        ElseIf ComboBox1.SelectedItem = "Precausiones" Then
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

        ElseIf ComboBox1.SelectedItem = "Detalles" Then
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
        Catch ex As Exception
        End Try

        Button11.Enabled = True
        Button13.Enabled = True
    End Sub
End Class