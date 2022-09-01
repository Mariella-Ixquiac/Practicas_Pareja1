Public Class Configuración_permisos

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Index.Show()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        'Salidas
        If CheckBox1.Checked = True Then
            Index.Button1.Visible = 1
        Else
            Index.Button1.Visible = 0
        End If

        If CheckBox14.Checked = True Then
            Index.Button1.Visible = 1
        Else
            Index.Button1.Visible = 0
        End If

        'Entradas
        If CheckBox2.Checked = True Then
            Index.Button2.Visible = 1
        Else
            Index.Button2.Visible = 0
        End If

        If CheckBox13.Checked = True Then
            Index.Button2.Visible = 1
        Else
            Index.Button2.Visible = 0
        End If

        'Inventario
        If CheckBox3.Checked = True Then
            Index.Button6.Visible = 1
        Else
            Index.Button6.Visible = 0
        End If

        If CheckBox12.Checked = True Then
            Index.Button6.Visible = 1
        Else
            Index.Button6.Visible = 0
        End If

        'Medicamentos/Productos
        If CheckBox4.Checked = True Then
            Index.Button3.Visible = 1
        Else
            Index.Button3.Visible = 0
        End If

        If CheckBox11.Checked = True Then
            Index.Button3.Visible = 1
        Else
            Index.Button3.Visible = 0
        End If

        'Proveedores
        If CheckBox5.Checked = True Then
            Index.Button5.Visible = 1
        Else
            Index.Button5.Visible = 0
        End If

        If CheckBox10.Checked = True Then
            Index.Button5.Visible = 1
        Else
            Index.Button5.Visible = 0
        End If

        'Clientes
        If CheckBox6.Checked = True Then
            Index.Button4.Visible = 1
        Else
            Index.Button4.Visible = 0
        End If

        If CheckBox9.Checked = True Then
            Index.Button4.Visible = 1
        Else
            Index.Button4.Visible = 0
        End If

        'Configuración
        If CheckBox8.Checked = True Then
            Index.Button7.Visible = 1
        Else
            Index.Button7.Visible = 0
        End If

    End Sub
End Class