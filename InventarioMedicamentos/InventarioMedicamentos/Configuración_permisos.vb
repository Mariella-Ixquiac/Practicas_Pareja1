Public Class Configuración_permisos

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Index.Show()
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
         "SELECT * FROM login WHERE id_rol = 4;" 

            'Salidas
            'If CheckBox1.Checked = True Then
            'Index.Button1.enabled = 1
            'Else
            '    Index.Button1.enabled = 0
            'End If

            If CheckBox14.Checked = True Then
                Index.Button1.Enabled = 1
            Else
                Index.Button1.Enabled = 0
            End If

            'Entradas
            'If CheckBox2.Checked = True Then
            '    Index.Button2.enabled = 1
            'Else
            '    Index.Button2.enabled = 0
            'End If

            If CheckBox13.Checked = True Then
                Index.Button2.Enabled = 1
            Else
                Index.Button2.Enabled = 0
            End If

            'Inventario
            'If CheckBox3.Checked = True Then
            '    Index.Button6.enabled = 1
            'Else
            '    Index.Button6.enabled = 0
            'End If

            If CheckBox12.Checked = True Then
                Index.Button6.Enabled = 1
            Else
                Index.Button6.Enabled = 0
            End If

            'Medicamentos/Productos
            'If CheckBox4.Checked = True Then
            '    Index.Button3.enabled = 1
            'Else
            '    Index.Button3.enabled = 0
            'End If

            If CheckBox11.Checked = True Then
                Index.Button3.Enabled = 1
            Else
                Index.Button3.Enabled = 0
            End If

            'Proveedores
            'If CheckBox5.Checked = True Then
            '    Index.Button5.enabled = 1
            'Else
            '    Index.Button5.enabled = 0
            'End If

            If CheckBox10.Checked = True Then
                Index.Button5.Enabled = 1
            Else
                Index.Button5.Enabled = 0
            End If

            'Clientes
            'If CheckBox6.Checked = True Then
            '    Index.Button4.enabled = 1
            'Else
            '    Index.Button4.enabled = 0
            'End If

            If CheckBox9.Checked = True Then
                Index.Button4.Enabled = 1
            Else
                Index.Button4.Enabled = 0
            End If

            'Configuración
            If CheckBox8.Checked = True Then
                Index.Button7.Enabled = 1
            Else
                Index.Button7.Enabled = 0
            End If


    End Sub

    Private Sub Configuración_permisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Comparar el id del administrador 

    End Sub
End Class