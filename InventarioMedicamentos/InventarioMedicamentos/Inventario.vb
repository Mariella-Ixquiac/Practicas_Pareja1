Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration

Public Class Inventario
    Dim conn As New MySqlConnection
    Dim objetoconexion As New Class1
    Dim cmd As MySqlCommand

    Private Sub mostrar()
        conn = objetoconexion.AbrirCon

        Dim query As String = "SELECT e.id_med AS 'ID', e.nom_med as 'Nombre del Medicamentos', e.receta as 'Receta', e.Cantidad_existente AS 'Cantidad de existencia', e.presentacion as 'Empaque', e.uni_medida as 'Unidad de medida', e.fec_caducidad as 'Fecha de caducidad', e.formula as 'Formula', e.dosis as 'Dosis', e.precauciones as 'Precauciones', e.descripcion as 'Detalles' FROM medicamento e;"
        Dim adpt As New MySqlDataAdapter(query, conn)
        Dim ds As New DataSet()
        adpt.Fill(ds)
        DataGridView2.DataSource = ds.Tables(0)
        conn.Close()
        conn.Dispose()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Index.Show()
    End Sub

    Private Sub Inventario_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Primer Guardar
        Dim CadenaConexion = "Server = localhost;Database=inventario_medicamentos;User id=root;Password=;Port=3306;"
        Dim conn As New MySqlConnection(CadenaConexion)
        Dim da As MySqlDataAdapter
        Dim dt As DataTable
        conn.Open()
        Dim sQuery = "SELECT a.nom_marca as 'Nombre del Proveedor', m.nom_med as 'Nombre del Medicamento' FROM compra c inner JOIN proveedores p on c.id_proveedores= p.id_proveedores inner JOIN marca a on a.id_marca=p.id_proveedores inner JOIN medicamento m on m.id_med= c.id_medicamento;"

        da = New MySqlDataAdapter(sQuery, conn)
        dt = New DataTable
        da.Fill(dt)
        DataGridView2.DataSource = dt
        conn.Close()

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

    End Sub
    Private Sub limpiar()
        TextBox1.Text = ""
        ComboBox2.SelectedIndex = -1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        limpiar()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        mostrar()


    End Sub
End Class