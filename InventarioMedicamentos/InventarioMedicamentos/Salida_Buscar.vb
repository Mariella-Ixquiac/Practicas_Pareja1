Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Salida_Buscar

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox5.Text.Length = 0 Then
            MsgBox("Debe Ingresar el Número del Documento", "ATENCIÓN")
            TextBox5.Focus()
            Exit Sub
        End If

    End Sub
    Private Sub limpiar()
        TextBox5.Clear()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar()

    End Sub
End Class