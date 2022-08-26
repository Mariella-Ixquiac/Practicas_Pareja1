Imports System.Text
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim codigo As New UnicodeEncoding()
        Dim md5 As New MD5CryptoServiceProvider()
        Dim clave As String
        clave = TextBox2.Text
        Dim hash() As Byte = md5.ComputeHash(codigo.GetBytes(clave))
        Dim nuevaclave As String
        nuevaclave = Convert.ToBase64String(hash)


        Index.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
