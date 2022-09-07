Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_nuevo
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_compra AS 'ID', c.fec_compra as 'Fecha de la compra', c.unidades_compradas as 'Stock', p.nom_proveedores as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento', c.precio_costo as 'Precio costo', c.total_PC as 'Total', c.precio_final as 'Precio Final', c.total as 'Total' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"
        'hola
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
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

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim row As DataGridViewRow = DataGridView2.CurrentRow
        Try
            Dim T As Integer
            T = (Convert.ToDouble(TextBox3.Text) * Convert.ToDouble(TextBox1.Text))
            Dim T1 As Integer
            T1 = (Convert.ToDouble(TextBox3.Text) * Convert.ToDouble(TextBox2.Text))

            TextBox6.Text = row.Cells(0).Value.ToString()
            DateTimePicker2.Value = row.Cells(1).Value.ToString()
            TextBox3.Text = row.Cells(2).Value.ToString()
            TextBox4.Text = row.Cells(3).Value.ToString()
            TextBox5.Text = row.Cells(4).Value.ToString()
            TextBox1.Text = row.Cells(5).Value.ToString()
            T = row.Cells(6).Value.ToString()
            TextBox2.Text = row.Cells(7).Value.ToString()
            T1 = row.Cells(8).Value.ToString()

        Catch ex As Exception
        End Try

    End Sub

    Private Sub Entrada_nuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class