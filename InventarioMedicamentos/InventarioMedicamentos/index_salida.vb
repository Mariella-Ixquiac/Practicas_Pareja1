﻿Public Class index_salida
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Salida_Nuevo.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Salida_Buscar.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub index_salida_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Focus()
    End Sub
End Class