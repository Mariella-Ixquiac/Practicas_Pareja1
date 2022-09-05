Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Salida_Nuevo

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Salida_nuevo_cliente.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Salida_Nueva_productos.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If NumericUpDown1.Value > TextBox1.Text Then
            MessageBox.Show("No se tienen sufiecientes medicamentos en Existencia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            Exit Sub
        End If

    End Sub
End Class