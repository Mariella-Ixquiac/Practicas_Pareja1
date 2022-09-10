Public Class Index

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        index_salida.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Index_entrada.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Medicamentos.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Clientes.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        Proveedores.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Hide()
        Inventario.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form1.Ban += 1
        Me.Hide()

        Index_configuracion.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Form1.Show()

        Form1.Ban = 0
        Form1.Ban2 = 0
    End Sub

    Private Sub Index_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class