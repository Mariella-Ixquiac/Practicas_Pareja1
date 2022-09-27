Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_Buscar
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CheckBox14.Checked = False
        limpiar()
        mostrar()
        Me.Hide()
        Index_entrada.Show()
    End Sub

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock',  c.precio_costo as 'Precio costo (Q)', c.total_PC as 'Total (Q)', c.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"
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

    Private Sub Entrada_Buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox5.Focus()
        mostrar()
        If CheckBox14.Checked = True And TextBox5.Text = "" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox5.Text & "%'"
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
            MessageBox.Show("Debe Ingresar eL Número del Documento.", "Atención.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox5.Focus()
            Exit Sub
        End If
        If TextBox5.Text = True Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock', c.precio_costo as 'Precio costo (Q)', c.total_PC as 'Total (Q)', c.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox5.Text & "%'"
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
                Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox5.Text & "%'"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

                TextBox9.Text = "***"
                TextBox2.Text = "***"
                TextBox3.Text = "***"
                TextBox4.Text = "***"
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', c.unidades_compradas as 'Stock', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"
            Dim adpt As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            adpt.Fill(ds)
            DataGridView2.DataSource = ds.Tables(0)
            conn.Close()
            conn.Dispose()
            TextBox9.Text = "***"
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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()
        mostrar()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If CheckBox14.Checked = True Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox5.Text & "%'"
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
                Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.unidades_compradas as 'Stock', c.precio_costo as 'Precio costo (Q)', c.total_PC as 'Total (Q)', c.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox5.Text & "%'"
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

    Private Sub TextBox5_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        End If
    End Sub

    Private Sub CheckBox14_KeyDown(sender As Object, e As KeyEventArgs) Handles CheckBox14.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button3.PerformClick()
        End If
    End Sub
End Class