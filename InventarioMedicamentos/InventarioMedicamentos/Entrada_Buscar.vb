Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Entrada_Buscar

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Entrada_Buscar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox5.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar eL Número del Documento", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            TextBox5.Focus()
            Exit Sub
        End If

    End Sub
End Class