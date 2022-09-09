<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Entrada_nuevo_proveedores
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Entrada_nuevo_proveedores))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(189, 73)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(50, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Buscar:"
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Turquoise
        Me.Button6.BackgroundImage = CType(resources.GetObject("Button6.BackgroundImage"), System.Drawing.Image)
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button6.Location = New System.Drawing.Point(192, 98)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(176, 25)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = " "
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Turquoise
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button5.Location = New System.Drawing.Point(15, 98)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(169, 25)
        Me.Button5.TabIndex = 3
        Me.Button5.Text = " "
        Me.Button5.UseVisualStyleBackColor = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(240, 70)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(128, 22)
        Me.TextBox4.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 73)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Campo:"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"ID", "Nombre del Proveedor", "Marca"})
        Me.ComboBox1.Location = New System.Drawing.Point(64, 69)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 23)
        Me.ComboBox1.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Teal
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label6.Location = New System.Drawing.Point(0, 431)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(379, 24)
        Me.Label6.TabIndex = 80
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Teal
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(379, 24)
        Me.Label5.TabIndex = 79
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Turquoise
        Me.Button7.BackgroundImage = CType(resources.GetObject("Button7.BackgroundImage"), System.Drawing.Image)
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button7.Location = New System.Drawing.Point(277, 36)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(91, 22)
        Me.Button7.TabIndex = 5
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label8.Location = New System.Drawing.Point(11, 37)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(165, 19)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "Lista de Proveedores"
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 130)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(355, 286)
        Me.DataGridView1.TabIndex = 76
        '
        'Entrada_nuevo_proveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Honeydew
        Me.ClientSize = New System.Drawing.Size(379, 455)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.DataGridView1)
        Me.Cursor = System.Windows.Forms.Cursors.Cross
        Me.Font = New System.Drawing.Font("Times New Roman", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Entrada_nuevo_proveedores"
        Me.Text = "Elegir Proveedor"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Private WithEvents Label6 As Label
    Private WithEvents Label5 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
