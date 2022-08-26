Public Class Index_entrada
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Entrada_nuevo.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Entrada_Buscar.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Index_entrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class