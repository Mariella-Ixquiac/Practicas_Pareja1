Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Inventario
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub
    Sub limpiar1()

        DateTimePicker2.Value = (Date.Now())
        DateTimePicker1.Value = (Date.Now())
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Index.Show()
        limpiar()
        limpiar1()
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Mostrar Base de Datos

        mostrar()


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            ComboBox2.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.None)
            TextBox1.Focus()
            Exit Sub
        End If

        If ComboBox2.SelectedItem = "Nombre del Medicamento" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where nom_med like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Nombre del Proveedor" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where nom_marca like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Fecha de Caducidad" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where fec_caducidad like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Unidad de Medida" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where uni_medida like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Cantidad de existencia" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where Cantidad_existente like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Unidades Compradas" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where unidades_compradas like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Precio de Compra" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where precio_costo like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Total Precio de Compra" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where total_PC like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Precio de Venta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where precio_final like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Total Precio de Venta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where total like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
        mostrar()

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        mostrar()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Buscar por fechas 
        If DateTimePicker2.Value = DateTimePicker1.Value Then
            MessageBox.Show("La fecha inicial no puede ir despues de la fecha final", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT m.nom_med as 'Nombre del Medicamento',a.nom_marca as 'Nombre del Proveedor', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Cantidad existente', c.unidades_compradas as 'Unidades Compradas', m.precio_costo as 'Precio de Compra (Q)', c.total_PC as 'Total precio de Compra', m.precio_final as 'Precio de Venta(Q)', c.total as 'Total Precio de Venta' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento WHERE fec_caducidad BETWEEN '%" & DateTimePicker2.Value & "%' AND '%" & DateTimePicker2.Value & "%';"
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        limpiar1()
    End Sub
End Class