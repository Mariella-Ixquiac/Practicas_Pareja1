Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Salida_Buscar
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckBox14.Checked = False
        Me.Hide()
        mostrar()
        index_salida.Show()
        limpiar()
    End Sub

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender', m.precio_final as 'Precio', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()

    End Sub

    Private Sub limpiar()
        TextBox5.Focus()
        DateTimePicker2.Value = (Date.Now())
        TextBox1.Text = ""
        TextBox8.Text = ""
        TextBox7.Text = ""
        TextBox9.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Salida_Buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox5.Focus()
        mostrar()
        If CheckBox14.Checked = True And TextBox5.Text = "" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento where v.id_venta like '%" & TextBox5.Text & "%'"
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox5.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar el Número del Documento.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Exit Sub
        End If

        If TextBox5.Text = True Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender', m.precio_final as 'Precio', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento where v.id_venta like '%" & TextBox5.Text & "%';"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception

            End Try
            Dim row As DataGridViewRow = DataGridView2.CurrentRow
            Try

                DateTimePicker2.Value = row.Cells(1).Value.ToString()
                TextBox8.Text = row.Cells(2).Value.ToString()
                TextBox7.Text = row.Cells(3).Value.ToString()
                TextBox1.Text = row.Cells(4).Value.ToString()
                TextBox9.Text = row.Cells(5).Value.ToString()
                TextBox2.Text = row.Cells(6).Value.ToString()
                TextBox3.Text = row.Cells(7).Value.ToString()
                TextBox4.Text = row.Cells(8).Value.ToString()

            Catch ex As Exception

            End Try
        End If


        If CheckBox14.Checked = True Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento where v.id_venta like '%" & TextBox5.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

                TextBox2.Text = "***"
                TextBox3.Text = "***"
                TextBox4.Text = "***"
            Catch ex As Exception
            End Try
        End If

    End Sub


    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento;"
            Dim adpt As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            adpt.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0)
            conn.Close()
            conn.Dispose()
            TextBox2.Text = "***"
            TextBox3.Text = "***"
            TextBox4.Text = "***"
        Else
            mostrar()
        End If
    End Sub

    Private Sub DataGridView2_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentDoubleClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try

            TextBox5.Text = row.Cells(0).Value.ToString()
            DateTimePicker2.Value = row.Cells(1).Value.ToString()
            TextBox8.Text = row.Cells(2).Value.ToString()
            TextBox7.Text = row.Cells(3).Value.ToString()
            TextBox1.Text = row.Cells(4).Value.ToString()
            TextBox9.Text = row.Cells(5).Value.ToString()
            TextBox2.Text = row.Cells(6).Value.ToString()
            TextBox3.Text = row.Cells(7).Value.ToString()
            TextBox4.Text = row.Cells(8).Value.ToString()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
        mostrar()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If CheckBox14.Checked = True Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento where v.id_venta like '%" & TextBox5.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try
        End If
        If CheckBox14.Checked = False Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta AS 'ID', v.fec_venta as 'Fecha de la venta', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', m.nom_med as 'Nombre del Medicamento', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a vender', m.precio_final as 'Precio', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner JOIN clientes c on v.id_cliente= c.id_cliente inner JOIN medicamento m on m.id_med= v.id_medicamento where v.id_venta like '%" & TextBox5.Text & "%';"
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
End Class