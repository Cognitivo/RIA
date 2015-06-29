<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CalculoHistóricoPorProducto
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
        Me.components = New System.ComponentModel.Container()
        Me.cbxProducto = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxDeposito = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInfVentas = New ContaExpress.DsInfVentas()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbxMes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxAnho = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInfVentasTableAdapters.SUCURSALTableAdapter()
        Me.DsCalculoAjusteHistórico = New ContaExpress.dsCalculoAjusteHistórico()
        Me.CalculoAjusteHistoricoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CalculoAjusteHistoricoTableAdapter = New ContaExpress.dsCalculoAjusteHistóricoTableAdapters.CalculoAjusteHistoricoTableAdapter()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInfVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCalculoAjusteHistórico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoAjusteHistoricoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxProducto
        '
        Me.cbxProducto.DataSource = Me.PRODUCTOSBindingSource
        Me.cbxProducto.DisplayMember = "DESPRODUCTO"
        Me.cbxProducto.FormattingEnabled = True
        Me.cbxProducto.Location = New System.Drawing.Point(96, 69)
        Me.cbxProducto.Name = "cbxProducto"
        Me.cbxProducto.Size = New System.Drawing.Size(316, 21)
        Me.cbxProducto.TabIndex = 0
        Me.cbxProducto.ValueMember = "CODCODIGO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProductos
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.EnforceConstraints = False
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Producto"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Depósito"
        '
        'cbxDeposito
        '
        Me.cbxDeposito.DataSource = Me.SUCURSALBindingSource
        Me.cbxDeposito.DisplayMember = "DESSUCURSAL"
        Me.cbxDeposito.FormattingEnabled = True
        Me.cbxDeposito.Location = New System.Drawing.Point(96, 115)
        Me.cbxDeposito.Name = "cbxDeposito"
        Me.cbxDeposito.Size = New System.Drawing.Size(316, 21)
        Me.cbxDeposito.TabIndex = 3
        Me.cbxDeposito.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsInfVentas
        '
        'DsInfVentas
        '
        Me.DsInfVentas.DataSetName = "DsInfVentas"
        Me.DsInfVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Mes"
        '
        'cbxMes
        '
        Me.cbxMes.FormattingEnabled = True
        Me.cbxMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cbxMes.Location = New System.Drawing.Point(96, 156)
        Me.cbxMes.Name = "cbxMes"
        Me.cbxMes.Size = New System.Drawing.Size(121, 21)
        Me.cbxMes.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(61, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Año"
        '
        'cbxAnho
        '
        Me.cbxAnho.FormattingEnabled = True
        Me.cbxAnho.Items.AddRange(New Object() {"2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cbxAnho.Location = New System.Drawing.Point(96, 196)
        Me.cbxAnho.Name = "cbxAnho"
        Me.cbxAnho.Size = New System.Drawing.Size(121, 21)
        Me.cbxAnho.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Fecha Actual"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(93, 236)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(57, 17)
        Me.lblFecha.TabIndex = 9
        Me.lblFecha.Text = "Label6"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.Location = New System.Drawing.Point(20, 294)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(392, 73)
        Me.btnEjecutar.TabIndex = 10
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(395, 39)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Seleccione el producto que desea recalcular el stock, en el depósito, mes y año c" & _
    "orrespondiente."
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'DsCalculoAjusteHistórico
        '
        Me.DsCalculoAjusteHistórico.DataSetName = "dsCalculoAjusteHistórico"
        Me.DsCalculoAjusteHistórico.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalculoAjusteHistoricoBindingSource
        '
        Me.CalculoAjusteHistoricoBindingSource.DataMember = "CalculoAjusteHistorico"
        Me.CalculoAjusteHistoricoBindingSource.DataSource = Me.DsCalculoAjusteHistórico
        '
        'CalculoAjusteHistoricoTableAdapter
        '
        Me.CalculoAjusteHistoricoTableAdapter.ClearBeforeFill = True
        '
        'CalculoHistóricoPorProducto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 383)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbxAnho)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbxMes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbxDeposito)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxProducto)
        Me.Name = "CalculoHistóricoPorProducto"
        Me.Text = "Calculo Histórico Por Producto | Cogent SIG"
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInfVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCalculoAjusteHistórico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoAjusteHistoricoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbxProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxAnho As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents DsInfVentas As ContaExpress.DsInfVentas
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInfVentasTableAdapters.SUCURSALTableAdapter
    Friend WithEvents DsCalculoAjusteHistórico As ContaExpress.dsCalculoAjusteHistórico
    Friend WithEvents CalculoAjusteHistoricoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CalculoAjusteHistoricoTableAdapter As ContaExpress.dsCalculoAjusteHistóricoTableAdapters.CalculoAjusteHistoricoTableAdapter
End Class
