Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_nuevo
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Unidades compradas', c.precio_costo as 'Precio costo (Q)', c.total_PC as 'Total (Q)', c.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)', c.id_proveedores, c.id_medicamento FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"

        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        Button6.Focus()
        TextBox6.Text = ""
        DateTimePicker2.Value = (Date.Now())
        TextBox4.Text = ""
        TextBox9.Text = ""
        TextBox8.Text = ""
        TextBox5.Text = ""
        TextBox10.Text = ""
        DateTimePicker1.Value = (Date.Now())
        TextBox3.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Entrada_nuevo_productos.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Entrada_nuevo_proveedores.Show()
    End Sub

    Private Sub Entrada_nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        DataGridView2.Columns(9).Visible = False
        DataGridView2.Columns(10).Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        conn = objetoconexion.AbrirCon

        If TextBox4.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar un Proveedor.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button6.Focus()
            Exit Sub
        End If
        If TextBox5.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar un Medicamento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Button4.Focus()
            Exit Sub
        End If

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "insert into compra(fec_compra,unidades_compradas,id_proveedores,id_medicamento,precio_costo,total_PC,precio_final,total)values(@fec,@uni,@pro,@med,@cos,@tpc,@fin,@tpf);"
            Dim T As Double
            T = (TextBox3.Text) * (TextBox1.Text)

            Dim T1 As Double
            T1 = (TextBox3.Text) * (TextBox2.Text)

            cmd.Parameters.AddWithValue("@fec", DateTimePicker2.Value.Date)
            cmd.Parameters.AddWithValue("@uni", TextBox3.Text)
            cmd.Parameters.AddWithValue("@pro", TextBox4.Text)
            cmd.Parameters.AddWithValue("@med", TextBox5.Text)
            cmd.Parameters.AddWithValue("@cos", TextBox1.Text)
            cmd.Parameters.AddWithValue("@tpc", T)
            cmd.Parameters.AddWithValue("@fin", TextBox2.Text)
            cmd.Parameters.AddWithValue("@tpf", T1)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
            limpiar()

        Catch ex As Exception
            MessageBox.Show(ex.innerexception.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "update compra set fec_compra=@fec, unidades_compradas=@uni, id_proveedores=@pro, id_medicamento=@med, precio_costo=@cos, total_PC=@tpc, precio_final=@fin, total=@tpf WHERE id_compra=@id"

            Dim T As Double
            T = (TextBox3.Text) * (TextBox1.Text)
            Dim T1 As Double
            T1 = (TextBox3.Text) * (TextBox2.Text)

            cmd.Parameters.AddWithValue("@fec", DateTimePicker2.Value.Date)
            cmd.Parameters.AddWithValue("@uni", TextBox3.Text)
            cmd.Parameters.AddWithValue("@pro", TextBox4.Text)
            cmd.Parameters.AddWithValue("@med", TextBox5.Text)
            cmd.Parameters.AddWithValue("@cos", TextBox1.Text)
            cmd.Parameters.AddWithValue("@tpc", T)
            cmd.Parameters.AddWithValue("@fin", TextBox2.Text)
            cmd.Parameters.AddWithValue("@tpf", T1)

            cmd.Parameters.AddWithValue("@id", TextBox6.Text)

            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()
            limpiar()
        Catch ex As Exception

        End Try
        Button1.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        conn = objetoconexion.AbrirCon

        Try
            cmd = conn.CreateCommand
            cmd.CommandText = "delete from compra where id_compra=@id"
            cmd.Parameters.AddWithValue("@id", TextBox6.Text)
            cmd.ExecuteNonQuery()
            conn.Close()
            conn.Dispose()
            mostrar()

            limpiar()

        Catch ex As Exception
        End Try

        Button1.Enabled = False
        Button5.Enabled = False
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try

            TextBox6.Text = row.Cells(0).Value.ToString()
            DateTimePicker2.Value = row.Cells(1).Value.ToString()
            TextBox9.Text = row.Cells(2).Value.ToString()
            TextBox10.Text = row.Cells(3).Value.ToString()
            TextBox3.Text = row.Cells(4).Value.ToString()
            TextBox1.Text = row.Cells(5).Value.ToString()
            TextBox2.Text = row.Cells(7).Value.ToString()
            TextBox4.Text = row.Cells(9).Value.ToString()
            TextBox5.Text = row.Cells(10).Value.ToString()

            DataGridView2.Columns(9).Visible = False
            DataGridView2.Columns(10).Visible = False

            TextBox8.Text = ""
            DateTimePicker1.Value = (Date.Now())

        Catch ex As Exception
        End Try

        Button1.Enabled = True
        Button5.Enabled = True
    End Sub

End Class