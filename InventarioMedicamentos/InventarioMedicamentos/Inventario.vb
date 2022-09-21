Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Inventario
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        mostrar()
        Index.Show()
        limpiar()
    End Sub

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub


    Private Sub mostrar2()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub limpiar2()
        TextBox2.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mostrar()
        mostrar2()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComboBox2.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox2.Focus()
            Exit Sub
        End If
        If TextBox1.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Focus()
            Exit Sub
        End If

        If ComboBox2.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.id_compra like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Fecha de la Compra" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.fec_compra like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Nombre del Medicamento" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where  m.nom_med like '%" & TextBox1.Text & "%'”
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
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where a.nom_marca like '%" & TextBox1.Text & "%'”
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
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where m.fec_caducidad like '%" & TextBox1.Text & "%'”
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
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where m.uni_medida like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Stock" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where m.Cantidad_existente like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Precio Costo (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where m.precio_costo like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Total (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.total_PC like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Precio Final (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where m.precio_final like '%" & TextBox1.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView2.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox2.SelectedItem = "Total Final (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT c.id_compra as 'ID', c.fec_compra as 'Fecha de la Compra', m.nom_med as 'Nombre del Medicamento', a.nom_marca as 'Nombre del Proveedor',  m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', m.precio_costo as 'Precio Costo (Q)', c.total_PC as 'Total (Q)', m.precio_final as 'Precio Final (Q)', c.total as 'Total (Q)' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento where c.total like '%" & TextBox1.Text & "%'”
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
        mostrar()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.SelectedIndex = -1 Then
            MessageBox.Show("Debe Ingresar un Campo para Buscar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBox1.Focus()
            Exit Sub
        End If
        If TextBox2.Text.Length = 0 Then
            MessageBox.Show("Debe Ingresar Datos", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox2.Focus()
            Exit Sub
        End If

        If ComboBox1.SelectedItem = "ID" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where v.id_venta Like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()
            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre del Cliente" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where c.ape_cliente Like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Fecha de la Venta" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where v.fec_venta like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Nombre del Medicamento" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where m.nom_med like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Fecha de Caducidad" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where m.fec_caducidad like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Unidad de Medida" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where m.uni_medida like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Stock" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where m.Cantidad_existente like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Unidades a Vender" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where v.unidades_vendidas like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Precio (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where m.precio_final like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Subtotal (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where v.subtotal_venta Like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
                conn.Dispose()

            Catch ex As Exception
            End Try

        ElseIf ComboBox1.SelectedItem = "Total (Q)" Then
            conn = objetoconexion.AbrirCon
            Try
                Dim query As String = "SELECT v.id_venta as 'ID', concat(c.ape_cliente, ', ', c.nom_cliente) as 'Nombre del Cliente', v.fec_venta as 'Fecha de la Venta', m.nom_med as 'Nombre del Medicamento', m.fec_caducidad as 'Fecha de Caducidad', m.uni_medida as 'Unidad de Medida', m.Cantidad_existente as 'Stock', v.unidades_vendidas as 'Unidades a Vender', m.precio_final as 'Precio (Q)', v.subtotal_venta as 'Subtotal (Q)', v.total as 'Total (Q)' FROM venta v inner join clientes c on c.id_cliente=v.id_cliente inner join medicamento m on m.id_med= v.id_medicamento where v.total Like '%" & TextBox2.Text & "%'”
                Dim adpt As New MySqlDataAdapter(query, conn)
                Dim ds As New DataSet()
                adpt.Fill(ds)
                DataGridView1.DataSource = ds.Tables(0)
                conn.Close()
            conn.Dispose()

        Catch ex As Exception
        End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        limpiar2()
        mostrar2()
    End Sub
End Class