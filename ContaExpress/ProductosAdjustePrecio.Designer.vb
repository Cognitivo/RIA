<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductosAdjustePrecio
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProductosAdjustePrecio))
        Me.dgvPrecios = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOREAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PRODUCTOAjustePrecioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.dgvListaPrecio = New System.Windows.Forms.DataGridView()
        Me.CODTIPOCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOCLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAplicar = New System.Windows.Forms.Button()
        Me.btnPreVisualizar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPorcentajeCambio = New System.Windows.Forms.Label()
        Me.tbxAjuste = New System.Windows.Forms.MaskedTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TIPOCLIENTETableAdapter = New ContaExpress.DsProductosTableAdapters.TIPOCLIENTETableAdapter()
        Me.PRODUCTOAjustePrecioTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOAjustePrecioTableAdapter()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FAMILIATableAdapter = New ContaExpress.DsProductosTableAdapters.FAMILIATableAdapter()
        Me.LINEATableAdapter = New ContaExpress.DsProductosTableAdapters.LINEATableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DsProductosTableAdapters.RUBROTableAdapter()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.pgbAplicarCambios = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cbxMarcar = New System.Windows.Forms.CheckBox()
        CType(Me.dgvPrecios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOAjustePrecioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPrecios
        '
        Me.dgvPrecios.AllowUserToAddRows = False
        Me.dgvPrecios.AllowUserToDeleteRows = False
        Me.dgvPrecios.AllowUserToResizeRows = False
        Me.dgvPrecios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrecios.AutoGenerateColumns = False
        Me.dgvPrecios.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrecios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.PRECIOREAL, Me.PRECIOVENTA, Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1, Me.DESCODIGO1DataGridViewTextBoxColumn, Me.CODPRECIODataGridViewTextBoxColumn, Me.Marcar})
        Me.dgvPrecios.DataSource = Me.PRODUCTOAjustePrecioBindingSource
        Me.dgvPrecios.Location = New System.Drawing.Point(143, 91)
        Me.dgvPrecios.Name = "dgvPrecios"
        Me.dgvPrecios.RowHeadersVisible = False
        Me.dgvPrecios.Size = New System.Drawing.Size(695, 447)
        Me.dgvPrecios.TabIndex = 0
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "Codigo"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.Width = 120
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Width = 200
        '
        'PRECIOREAL
        '
        Me.PRECIOREAL.DataPropertyName = "PRECIOREAL"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.PRECIOREAL.DefaultCellStyle = DataGridViewCellStyle1
        Me.PRECIOREAL.HeaderText = "Precio Venta"
        Me.PRECIOREAL.Name = "PRECIOREAL"
        Me.PRECIOREAL.Width = 150
        '
        'PRECIOVENTA
        '
        Me.PRECIOVENTA.DataPropertyName = "PRECIOVENTA"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.PRECIOVENTA.DefaultCellStyle = DataGridViewCellStyle2
        Me.PRECIOVENTA.HeaderText = "Precio a Visualizar"
        Me.PRECIOVENTA.Name = "PRECIOVENTA"
        Me.PRECIOVENTA.Width = 150
        '
        'CODTIPOCLIENTEDataGridViewTextBoxColumn1
        '
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1.Name = "CODTIPOCLIENTEDataGridViewTextBoxColumn1"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn1.Visible = False
        '
        'DESCODIGO1DataGridViewTextBoxColumn
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1DataGridViewTextBoxColumn.HeaderText = "DESCODIGO1"
        Me.DESCODIGO1DataGridViewTextBoxColumn.Name = "DESCODIGO1DataGridViewTextBoxColumn"
        Me.DESCODIGO1DataGridViewTextBoxColumn.Visible = False
        '
        'CODPRECIODataGridViewTextBoxColumn
        '
        Me.CODPRECIODataGridViewTextBoxColumn.DataPropertyName = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn.HeaderText = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn.Name = "CODPRECIODataGridViewTextBoxColumn"
        Me.CODPRECIODataGridViewTextBoxColumn.Visible = False
        '
        'Marcar
        '
        Me.Marcar.HeaderText = "Marcar"
        Me.Marcar.Name = "Marcar"
        Me.Marcar.Width = 50
        '
        'PRODUCTOAjustePrecioBindingSource
        '
        Me.PRODUCTOAjustePrecioBindingSource.DataMember = "PRODUCTOAjustePrecio"
        Me.PRODUCTOAjustePrecioBindingSource.DataSource = Me.DsProductos
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvListaPrecio
        '
        Me.dgvListaPrecio.AllowUserToAddRows = False
        Me.dgvListaPrecio.AllowUserToDeleteRows = False
        Me.dgvListaPrecio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvListaPrecio.AutoGenerateColumns = False
        Me.dgvListaPrecio.BackgroundColor = System.Drawing.Color.Silver
        Me.dgvListaPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvListaPrecio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODTIPOCLIENTE, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn, Me.DESTIPOCLIENTE, Me.FECGRADataGridViewTextBoxColumn, Me.RUCDataGridViewTextBoxColumn, Me.DIRECCIONDataGridViewTextBoxColumn, Me.TELEFONODataGridViewTextBoxColumn})
        Me.dgvListaPrecio.DataSource = Me.TIPOCLIENTEBindingSource
        Me.dgvListaPrecio.Location = New System.Drawing.Point(1, 91)
        Me.dgvListaPrecio.Name = "dgvListaPrecio"
        Me.dgvListaPrecio.ReadOnly = True
        Me.dgvListaPrecio.RowHeadersVisible = False
        Me.dgvListaPrecio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvListaPrecio.Size = New System.Drawing.Size(140, 447)
        Me.dgvListaPrecio.TabIndex = 1
        '
        'CODTIPOCLIENTE
        '
        Me.CODTIPOCLIENTE.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.Name = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.ReadOnly = True
        Me.CODTIPOCLIENTE.Visible = False
        Me.CODTIPOCLIENTE.Width = 200
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        Me.CODUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn
        '
        Me.CODEMPRESADataGridViewTextBoxColumn.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.Name = "CODEMPRESADataGridViewTextBoxColumn"
        Me.CODEMPRESADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn.Visible = False
        '
        'NUMTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NUMTIPOCLIENTE"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "NUMTIPOCLIENTE"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.Name = "NUMTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'DESTIPOCLIENTE
        '
        Me.DESTIPOCLIENTE.DataPropertyName = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTE.HeaderText = "Lista de Precio"
        Me.DESTIPOCLIENTE.Name = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTE.ReadOnly = True
        Me.DESTIPOCLIENTE.Width = 150
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'RUCDataGridViewTextBoxColumn
        '
        Me.RUCDataGridViewTextBoxColumn.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn.HeaderText = "RUC"
        Me.RUCDataGridViewTextBoxColumn.Name = "RUCDataGridViewTextBoxColumn"
        Me.RUCDataGridViewTextBoxColumn.ReadOnly = True
        Me.RUCDataGridViewTextBoxColumn.Visible = False
        '
        'DIRECCIONDataGridViewTextBoxColumn
        '
        Me.DIRECCIONDataGridViewTextBoxColumn.DataPropertyName = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.HeaderText = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.Name = "DIRECCIONDataGridViewTextBoxColumn"
        Me.DIRECCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DIRECCIONDataGridViewTextBoxColumn.Visible = False
        '
        'TELEFONODataGridViewTextBoxColumn
        '
        Me.TELEFONODataGridViewTextBoxColumn.DataPropertyName = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.HeaderText = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.Name = "TELEFONODataGridViewTextBoxColumn"
        Me.TELEFONODataGridViewTextBoxColumn.ReadOnly = True
        Me.TELEFONODataGridViewTextBoxColumn.Visible = False
        '
        'TIPOCLIENTEBindingSource
        '
        Me.TIPOCLIENTEBindingSource.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource.DataSource = Me.DsProductos
        '
        'btnAplicar
        '
        Me.btnAplicar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAplicar.Enabled = False
        Me.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAplicar.Location = New System.Drawing.Point(694, 11)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(112, 27)
        Me.btnAplicar.TabIndex = 3
        Me.btnAplicar.Text = "Aplicar Cambios"
        Me.btnAplicar.UseVisualStyleBackColor = False
        '
        'btnPreVisualizar
        '
        Me.btnPreVisualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreVisualizar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnPreVisualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreVisualizar.Location = New System.Drawing.Point(576, 11)
        Me.btnPreVisualizar.Name = "btnPreVisualizar"
        Me.btnPreVisualizar.Size = New System.Drawing.Size(112, 27)
        Me.btnPreVisualizar.TabIndex = 5
        Me.btnPreVisualizar.Text = "Pre-Visualizar"
        Me.btnPreVisualizar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblPorcentajeCambio)
        Me.Panel1.Controls.Add(Me.tbxAjuste)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnPreVisualizar)
        Me.Panel1.Controls.Add(Me.btnAplicar)
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(817, 51)
        Me.Panel1.TabIndex = 6
        '
        'lblPorcentajeCambio
        '
        Me.lblPorcentajeCambio.AutoSize = True
        Me.lblPorcentajeCambio.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblPorcentajeCambio.Location = New System.Drawing.Point(503, 13)
        Me.lblPorcentajeCambio.Name = "lblPorcentajeCambio"
        Me.lblPorcentajeCambio.Size = New System.Drawing.Size(64, 22)
        Me.lblPorcentajeCambio.TabIndex = 8
        Me.lblPorcentajeCambio.Text = "Label2"
        '
        'tbxAjuste
        '
        Me.tbxAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxAjuste.Location = New System.Drawing.Point(352, 10)
        Me.tbxAjuste.Mask = "9.99"
        Me.tbxAjuste.Name = "tbxAjuste"
        Me.tbxAjuste.Size = New System.Drawing.Size(145, 27)
        Me.tbxAjuste.TabIndex = 7
        Me.tbxAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(2, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(347, 46)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Elija una Lista de Precio para filtrar los Productos y sus Precios Respectivos. E" & _
    "n el Campo, cargue el ajuste que queire hacer. 0.9 = -10%, similarmente 1.1 = +1" & _
    "0% de ajuste!"
        '
        'TIPOCLIENTETableAdapter
        '
        Me.TIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOAjustePrecioTableAdapter
        '
        Me.PRODUCTOAjustePrecioTableAdapter.ClearBeforeFill = True
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DsProductos
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "LINEA"
        Me.LINEABindingSource.DataSource = Me.DsProductos
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "RUBRO"
        Me.RUBROBindingSource.DataSource = Me.DsProductos
        '
        'FAMILIATableAdapter
        '
        Me.FAMILIATableAdapter.ClearBeforeFill = True
        '
        'LINEATableAdapter
        '
        Me.LINEATableAdapter.ClearBeforeFill = True
        '
        'RUBROTableAdapter
        '
        Me.RUBROTableAdapter.ClearBeforeFill = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Tan
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.pgbAplicarCambios, Me.lblEstado})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 540)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(840, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'pgbAplicarCambios
        '
        Me.pgbAplicarCambios.Name = "pgbAplicarCambios"
        Me.pgbAplicarCambios.Size = New System.Drawing.Size(100, 16)
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(0, 17)
        '
        'cbxMarcar
        '
        Me.cbxMarcar.AutoSize = True
        Me.cbxMarcar.BackColor = System.Drawing.Color.Transparent
        Me.cbxMarcar.Location = New System.Drawing.Point(735, 68)
        Me.cbxMarcar.Name = "cbxMarcar"
        Me.cbxMarcar.Size = New System.Drawing.Size(92, 17)
        Me.cbxMarcar.TabIndex = 8
        Me.cbxMarcar.Text = "Marcar Todos"
        Me.cbxMarcar.UseVisualStyleBackColor = False
        '
        'ProductosAdjustePrecio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(840, 562)
        Me.Controls.Add(Me.cbxMarcar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvListaPrecio)
        Me.Controls.Add(Me.dgvPrecios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProductosAdjustePrecio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Precios | Cogent SIG"
        CType(Me.dgvPrecios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOAjustePrecioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPrecios As System.Windows.Forms.DataGridView
    Friend WithEvents dgvListaPrecio As System.Windows.Forms.DataGridView
    Friend WithEvents btnAplicar As System.Windows.Forms.Button
    Friend WithEvents btnPreVisualizar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents TIPOCLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsProductosTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents PRODUCTOAjustePrecioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOAjustePrecioTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOAjustePrecioTableAdapter
    Friend WithEvents CODTIPOCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbxAjuste As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblPorcentajeCambio As System.Windows.Forms.Label
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DsProductosTableAdapters.FAMILIATableAdapter
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEATableAdapter As ContaExpress.DsProductosTableAdapters.LINEATableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUBROTableAdapter As ContaExpress.DsProductosTableAdapters.RUBROTableAdapter
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pgbAplicarCambios As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cbxMarcar As System.Windows.Forms.CheckBox
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOREAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRECIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
