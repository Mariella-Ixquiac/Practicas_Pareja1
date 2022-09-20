Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Salida_Nuevo
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender', m.precio_final as 'Precio', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)', v.id_cliente, v.id_medicamento FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento;"

        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub


    Private Sub mostrar2()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT e.id_med AS 'ID', e.Cantidad_existente AS 'Cantidad de existencia' FROM medicamento e;"

        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        Button6.Focus()
        TextBox6.Text = ""
        DateTimePicker2.Value = (Date.Now())
        TextBox2.Text = ""
        TextBox9.Text = ""
        TextBox4.Text = ""
        TextBox8.Text = ""
        TextBox3.Text = ""
        TextBox10.Text = ""
        DateTimePicker1.Value = (Date.Now())
        TextBox5.Text = ""
        TextBox1.Text = ""
        TextBox7.Text = ""
    End Sub

    Private Sub limpiar2()
        Button6.Focus()
        TextBox6.Text = ""

        TextBox3.Text = ""
        TextBox10.Text = ""
        DateTimePicker1.Value = (Date.Now())
        TextBox5.Text = ""
        TextBox1.Text = ""
        TextBox7.Text = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()

        mostrar()
        Index.Show()
        limpiar()
        TextBox10.Text = "0.00"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Salida_nuevo_cliente.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Salida_Nueva_productos.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar un Cliente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button6.Focus()
            Exit Sub
        End If
        If TextBox3.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar un Medicamento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button4.Focus()
            Exit Sub
        End If
        If TextBox7.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar una Cantidad.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Exit Sub
        End If

        If Convert.ToDouble(TextBox7.Text) > Convert.ToDouble(TextBox1.Text) Then
            MessageBox.Show("No se tienen sufiecientes medicamentos en Existencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Exit Sub
        End If

        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into venta(fec_venta,id_cliente,id_medicamento,unidades_compradas,unidades_vendidas,precio,subtotal_venta,total)values(@fec,@cli,@med,@unc,@unv,@pre,@sub,@tot);"

            'stock
            Dim S As Double
            S = Convert.ToDouble(TextBox1.Text) - Convert.ToDouble(TextBox7.Text)
            TextBox1.Text = S

            'subtotal
            Dim T As Double
            T = (TextBox5.Text) * (TextBox7.Text)

            'total
            Dim T1 As Double
            T1 = TextBox14.Text + ((TextBox5.Text) * (TextBox7.Text))
            TextBox14.Text = T + TextBox12.Text
            TextBox12.Text = T1

            cmd.Parameters.AddWithValue("@fec", DateTimePicker2.Value.Date)
            cmd.Parameters.AddWithValue("@cli", TextBox2.Text)
            cmd.Parameters.AddWithValue("@med", TextBox3.Text)
            cmd.Parameters.AddWithValue("@unc", S)
            cmd.Parameters.AddWithValue("@unv", TextBox7.Text)
            cmd.Parameters.AddWithValue("@pre", TextBox5.Text)
            cmd.Parameters.AddWithValue("@sub", T)
            cmd.Parameters.AddWithValue("@tot", T1)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

        Catch ex As Exception
        End Try

        conn = objetoconexion.AbrirCon
        cmd = conn.CreateCommand
        cmd.CommandText = "update medicamento set Cantidad_existente=@can WHERE id_med=@id"

        cmd.Parameters.AddWithValue("@id", TextBox3.Text)
        cmd.Parameters.AddWithValue("@can", TextBox1.Text)

        cmd.ExecuteNonQuery()
        conn.Close()
        conn.Dispose()
        mostrar2()
        mostrar()
        limpiar2()
    End Sub

    Private Sub Salida_Nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        mostrar2()
        DataGridView2.Columns(9).Visible = False
        DataGridView2.Columns(10).Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        limpiar()
        mostrar()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update venta set fec_venta=@fec, id_cliente=@cli, id_medicamento=@med, unidades_compradas=@unc, unidades_vendidas=@unv, precio=@pre, subtotal_venta=@sub, total=@tot WHERE id_venta=@id"

            Dim S As Double
            S = Convert.ToDouble(TextBox1.Text) - Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox13.Text)
            TextBox1.Text = S
            Dim T As Double
            T = (TextBox5.Text) * (TextBox7.Text)

            Dim T1 As Double
            T1 = ((TextBox5.Text) * (TextBox7.Text))

            TextBox12.Text = TextBox12.Text + T1


            cmd.Parameters.AddWithValue("@fec", DateTimePicker2.Value.Date)
            cmd.Parameters.AddWithValue("@cli", TextBox2.Text)
            cmd.Parameters.AddWithValue("@med", TextBox3.Text)
            cmd.Parameters.AddWithValue("@unc", S)
            cmd.Parameters.AddWithValue("@unv", TextBox7.Text)
            cmd.Parameters.AddWithValue("@pre", TextBox5.Text)
            cmd.Parameters.AddWithValue("@sub", T)
            cmd.Parameters.AddWithValue("@tot", T1)

            cmd.Parameters.AddWithValue("@id", TextBox6.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

        Catch ex As Exception
        End Try

        Try
            conn = objetoconexion.AbrirCon
            cmd = conn.CreateCommand
            cmd.CommandText = "update medicamento set Cantidad_existente=@can WHERE id_med=@id"

            cmd.Parameters.AddWithValue("@id", TextBox3.Text)
            cmd.Parameters.AddWithValue("@can", TextBox1.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar2()
            mostrar()

            limpiar2()
        Catch ex As Exception
        End Try

        Button5.Enabled = False
        Button10.Enabled = False

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        conn = objetoconexion.AbrirCon
        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update venta set unidades_compradas=@unc, total=@tot WHERE id_venta=@id"

            Dim S As Double
            S = Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox13.Text)
            TextBox1.Text = S

            Dim A As Double
            A = TextBox12.Text - TextBox14.Text
            TextBox1.Text = A

            TextBox12.Text = A
            cmd.Parameters.AddWithValue("@id", TextBox6.Text)
            cmd.Parameters.AddWithValue("@unc", S)
            cmd.Parameters.AddWithValue("@tot", TextBox12.Text)

        Catch ex As Exception
        End Try


        Try

            conn = objetoconexion.AbrirCon
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from venta where id_venta=@id"
            cmd.Parameters.AddWithValue("@id", TextBox6.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

        Catch ex As Exception
        End Try

        Try
            conn = objetoconexion.AbrirCon
            cmd = conn.CreateCommand
            cmd.CommandText = "update medicamento set Cantidad_existente=@can WHERE id_med=@id"

            cmd.Parameters.AddWithValue("@id", TextBox3.Text)
            cmd.Parameters.AddWithValue("@can", TextBox1.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar2()
            mostrar()
            limpiar2()
        Catch ex As Exception
        End Try

        Button5.Enabled = False
        Button10.Enabled = False


    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim row As DataGridViewRow = DataGridView1.CurrentRow
        Try

            TextBox1.Text = row.Cells(1).Value.ToString()
            TextBox3.Text = row.Cells(0).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try

            TextBox6.Text = row.Cells(0).Value.ToString()
            DateTimePicker2.Value = row.Cells(1).Value.ToString()
            TextBox9.Text = row.Cells(2).Value.ToString()
            TextBox10.Text = row.Cells(3).Value.ToString()
            TextBox1.Text = row.Cells(4).Value.ToString()
            TextBox7.Text = row.Cells(5).Value.ToString()
            TextBox5.Text = row.Cells(6).Value.ToString()
            TextBox12.Text = row.Cells(8).Value.ToString()

            TextBox13.Text = row.Cells(5).Value.ToString()

            TextBox2.Text = row.Cells(9).Value.ToString()
            TextBox3.Text = row.Cells(10).Value.ToString()

            DataGridView2.Columns(9).Visible = False
            DataGridView2.Columns(10).Visible = False


            TextBox4.Text = ""
            TextBox8.Text = ""
            DateTimePicker1.Value = (Date.Now())

        Catch ex As Exception
        End Try


        Button5.Enabled = True
        Button10.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView2.DataSource = ""


    End Sub
End Class