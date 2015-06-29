<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Venta_Pagare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Venta_Pagare))
        Me.CbxEstado = New System.Windows.Forms.ComboBox()
        Me.VENTASPAGAREBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPagare = New ContaExpress.DsPagare()
        Me.ESTADOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxcliente = New System.Windows.Forms.ComboBox()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaCreacion = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Cbxmoneda = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxcotizacion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbxvalor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbxobservacion = New System.Windows.Forms.TextBox()
        Me.dgvPagare = New System.Windows.Forms.DataGridView()
        Me.NroPagare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaVencimientoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaCreacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodpagareDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodClienteDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodVentaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMonedaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CotizacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValorDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodestadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxImprimirPagare = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ESTADOTableAdapter = New ContaExpress.DsPagareTableAdapters.ESTADOTableAdapter()
        Me.CLIENTESTableAdapter = New ContaExpress.DsPagareTableAdapters.CLIENTESTableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DsPagareTableAdapters.MONEDATableAdapter()
        Me.VENTAS_PAGARETableAdapter = New ContaExpress.DsPagareTableAdapters.VENTAS_PAGARETableAdapter()
        Me.TxtVentas = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNroCuota = New System.Windows.Forms.TextBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.lblNroPagare = New Telerik.WinControls.UI.RadLabel()
        Me.ImpPagareTableAdapter = New ContaExpress.DsPagareTableAdapters.ImpPagareTableAdapter()
        Me.rbtVerImpresos = New System.Windows.Forms.RadioButton()
        Me.rbtverPendientes = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CmbAño = New Telerik.WinControls.UI.RadComboBox()
        Me.BtnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.CmbMes = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem3 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem4 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem5 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem6 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem7 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem8 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem9 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem10 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem11 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem12 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem13 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem14 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem15 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem16 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem17 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem18 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem19 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem20 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem21 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem22 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem23 = New Telerik.WinControls.UI.RadComboBoxItem()
        CType(Me.VENTASPAGAREBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ESTADOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxImprimirPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNroPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CbxEstado
        '
        Me.CbxEstado.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VENTASPAGAREBindingSource, "Codestado", True))
        Me.CbxEstado.DataSource = Me.ESTADOBindingSource
        Me.CbxEstado.DisplayMember = "DESCRIPCION"
        Me.CbxEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxEstado.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.CbxEstado.FormattingEnabled = True
        Me.CbxEstado.Location = New System.Drawing.Point(618, 89)
        Me.CbxEstado.Name = "CbxEstado"
        Me.CbxEstado.Size = New System.Drawing.Size(165, 24)
        Me.CbxEstado.TabIndex = 0
        Me.CbxEstado.ValueMember = "CODESTADO"
        '
        'VENTASPAGAREBindingSource
        '
        Me.VENTASPAGAREBindingSource.DataMember = "VENTAS_PAGARE"
        Me.VENTASPAGAREBindingSource.DataSource = Me.DsPagare
        '
        'DsPagare
        '
        Me.DsPagare.DataSetName = "DsPagare"
        Me.DsPagare.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ESTADOBindingSource
        '
        Me.ESTADOBindingSource.DataMember = "ESTADO"
        Me.ESTADOBindingSource.DataSource = Me.DsPagare
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(569, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Estado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Silver
        Me.Label2.Location = New System.Drawing.Point(400, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cliente:"
        '
        'cbxcliente
        '
        Me.cbxcliente.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VENTASPAGAREBindingSource, "CodCliente", True))
        Me.cbxcliente.DataSource = Me.CLIENTESBindingSource
        Me.cbxcliente.DisplayMember = "NOMBRE"
        Me.cbxcliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxcliente.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cbxcliente.FormattingEnabled = True
        Me.cbxcliente.Location = New System.Drawing.Point(448, 131)
        Me.cbxcliente.Name = "cbxcliente"
        Me.cbxcliente.Size = New System.Drawing.Size(334, 24)
        Me.cbxcliente.TabIndex = 2
        Me.cbxcliente.ValueMember = "CODCLIENTE"
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsPagare
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(357, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Fecha Creacion:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(341, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Fecha Vencimiento:"
        '
        'dtpFechaCreacion
        '
        Me.dtpFechaCreacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaCreacion.CalendarMonthBackground = System.Drawing.Color.DimGray
        Me.dtpFechaCreacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "FechaCreacion", True))
        Me.dtpFechaCreacion.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCreacion.Location = New System.Drawing.Point(446, 164)
        Me.dtpFechaCreacion.Name = "dtpFechaCreacion"
        Me.dtpFechaCreacion.Size = New System.Drawing.Size(334, 26)
        Me.dtpFechaCreacion.TabIndex = 457
        '
        'dtpFechaVencimiento
        '
        Me.dtpFechaVencimiento.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaVencimiento.CalendarMonthBackground = System.Drawing.Color.DimGray
        Me.dtpFechaVencimiento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "FechaVencimiento", True))
        Me.dtpFechaVencimiento.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVencimiento.Location = New System.Drawing.Point(446, 199)
        Me.dtpFechaVencimiento.Name = "dtpFechaVencimiento"
        Me.dtpFechaVencimiento.Size = New System.Drawing.Size(334, 26)
        Me.dtpFechaVencimiento.TabIndex = 458
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(376, 241)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 460
        Me.Label5.Text = "Factura Nro:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(393, 275)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 462
        Me.Label6.Text = "Moneda:"
        '
        'Cbxmoneda
        '
        Me.Cbxmoneda.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VENTASPAGAREBindingSource, "CodMoneda", True))
        Me.Cbxmoneda.DataSource = Me.MONEDABindingSource
        Me.Cbxmoneda.DisplayMember = "DESMONEDA"
        Me.Cbxmoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cbxmoneda.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Cbxmoneda.FormattingEnabled = True
        Me.Cbxmoneda.Location = New System.Drawing.Point(448, 269)
        Me.Cbxmoneda.Name = "Cbxmoneda"
        Me.Cbxmoneda.Size = New System.Drawing.Size(130, 24)
        Me.Cbxmoneda.TabIndex = 461
        Me.Cbxmoneda.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsPagare
        '
        'tbxcotizacion
        '
        Me.tbxcotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxcotizacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "Cotizacion", True))
        Me.tbxcotizacion.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbxcotizacion.Location = New System.Drawing.Point(649, 270)
        Me.tbxcotizacion.Name = "tbxcotizacion"
        Me.tbxcotizacion.Size = New System.Drawing.Size(133, 23)
        Me.tbxcotizacion.TabIndex = 463
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Silver
        Me.Label7.Location = New System.Drawing.Point(586, 275)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 464
        Me.Label7.Text = "Cotizacion:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Silver
        Me.Label8.Location = New System.Drawing.Point(408, 307)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 466
        Me.Label8.Text = "Valor:"
        '
        'tbxvalor
        '
        Me.tbxvalor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxvalor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "Valor", True))
        Me.tbxvalor.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.tbxvalor.Location = New System.Drawing.Point(448, 302)
        Me.tbxvalor.Multiline = True
        Me.tbxvalor.Name = "tbxvalor"
        Me.tbxvalor.Size = New System.Drawing.Size(334, 23)
        Me.tbxvalor.TabIndex = 465
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Silver
        Me.Label9.Location = New System.Drawing.Point(372, 334)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 468
        Me.Label9.Text = "Observacion:"
        '
        'tbxobservacion
        '
        Me.tbxobservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxobservacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "Observacion", True))
        Me.tbxobservacion.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.tbxobservacion.Location = New System.Drawing.Point(448, 334)
        Me.tbxobservacion.Multiline = True
        Me.tbxobservacion.Name = "tbxobservacion"
        Me.tbxobservacion.Size = New System.Drawing.Size(334, 95)
        Me.tbxobservacion.TabIndex = 467
        '
        'dgvPagare
        '
        Me.dgvPagare.AllowUserToAddRows = False
        Me.dgvPagare.AllowUserToDeleteRows = False
        Me.dgvPagare.AllowUserToResizeRows = False
        Me.dgvPagare.AutoGenerateColumns = False
        Me.dgvPagare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPagare.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvPagare.ColumnHeadersHeight = 35
        Me.dgvPagare.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroPagare, Me.NUMVENTA, Me.NOMBRE, Me.FechaVencimientoDataGridViewTextBoxColumn, Me.FechaCreacionDataGridViewTextBoxColumn, Me.CodpagareDataGridViewTextBoxColumn, Me.CodClienteDataGridViewTextBoxColumn, Me.CodVentaDataGridViewTextBoxColumn, Me.CodMonedaDataGridViewTextBoxColumn, Me.CotizacionDataGridViewTextBoxColumn, Me.ValorDataGridViewTextBoxColumn, Me.ObservacionDataGridViewTextBoxColumn, Me.CodestadoDataGridViewTextBoxColumn})
        Me.dgvPagare.DataSource = Me.VENTASPAGAREBindingSource
        Me.dgvPagare.Location = New System.Drawing.Point(-1, 96)
        Me.dgvPagare.Name = "dgvPagare"
        Me.dgvPagare.ReadOnly = True
        Me.dgvPagare.RowHeadersVisible = False
        Me.dgvPagare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPagare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPagare.Size = New System.Drawing.Size(332, 371)
        Me.dgvPagare.TabIndex = 469
        '
        'NroPagare
        '
        Me.NroPagare.DataPropertyName = "NroPagare"
        Me.NroPagare.FillWeight = 70.0!
        Me.NroPagare.HeaderText = "Nro Pagare"
        Me.NroPagare.Name = "NroPagare"
        Me.NroPagare.ReadOnly = True
        '
        'NUMVENTA
        '
        Me.NUMVENTA.DataPropertyName = "NUMVENTA"
        Me.NUMVENTA.HeaderText = "Nro Factura"
        Me.NUMVENTA.Name = "NUMVENTA"
        Me.NUMVENTA.ReadOnly = True
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.FillWeight = 180.0!
        Me.NOMBRE.HeaderText = "Cliente"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'FechaVencimientoDataGridViewTextBoxColumn
        '
        Me.FechaVencimientoDataGridViewTextBoxColumn.DataPropertyName = "FechaVencimiento"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechaVencimientoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechaVencimientoDataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.FechaVencimientoDataGridViewTextBoxColumn.HeaderText = "Fecha Venc."
        Me.FechaVencimientoDataGridViewTextBoxColumn.Name = "FechaVencimientoDataGridViewTextBoxColumn"
        Me.FechaVencimientoDataGridViewTextBoxColumn.ReadOnly = True
        Me.FechaVencimientoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FechaVencimientoDataGridViewTextBoxColumn.Visible = False
        '
        'FechaCreacionDataGridViewTextBoxColumn
        '
        Me.FechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FechaCreacionDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FechaCreacionDataGridViewTextBoxColumn.FillWeight = 70.0!
        Me.FechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion"
        Me.FechaCreacionDataGridViewTextBoxColumn.Name = "FechaCreacionDataGridViewTextBoxColumn"
        Me.FechaCreacionDataGridViewTextBoxColumn.ReadOnly = True
        Me.FechaCreacionDataGridViewTextBoxColumn.Visible = False
        '
        'CodpagareDataGridViewTextBoxColumn
        '
        Me.CodpagareDataGridViewTextBoxColumn.DataPropertyName = "Codpagare"
        Me.CodpagareDataGridViewTextBoxColumn.HeaderText = "Codpagare"
        Me.CodpagareDataGridViewTextBoxColumn.Name = "CodpagareDataGridViewTextBoxColumn"
        Me.CodpagareDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodpagareDataGridViewTextBoxColumn.Visible = False
        '
        'CodClienteDataGridViewTextBoxColumn
        '
        Me.CodClienteDataGridViewTextBoxColumn.DataPropertyName = "CodCliente"
        Me.CodClienteDataGridViewTextBoxColumn.HeaderText = "CodCliente"
        Me.CodClienteDataGridViewTextBoxColumn.Name = "CodClienteDataGridViewTextBoxColumn"
        Me.CodClienteDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodClienteDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodClienteDataGridViewTextBoxColumn.Visible = False
        '
        'CodVentaDataGridViewTextBoxColumn
        '
        Me.CodVentaDataGridViewTextBoxColumn.DataPropertyName = "CodVenta"
        Me.CodVentaDataGridViewTextBoxColumn.HeaderText = "CodVenta"
        Me.CodVentaDataGridViewTextBoxColumn.Name = "CodVentaDataGridViewTextBoxColumn"
        Me.CodVentaDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodVentaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodVentaDataGridViewTextBoxColumn.Visible = False
        '
        'CodMonedaDataGridViewTextBoxColumn
        '
        Me.CodMonedaDataGridViewTextBoxColumn.DataPropertyName = "CodMoneda"
        Me.CodMonedaDataGridViewTextBoxColumn.HeaderText = "CodMoneda"
        Me.CodMonedaDataGridViewTextBoxColumn.Name = "CodMonedaDataGridViewTextBoxColumn"
        Me.CodMonedaDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodMonedaDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodMonedaDataGridViewTextBoxColumn.Visible = False
        '
        'CotizacionDataGridViewTextBoxColumn
        '
        Me.CotizacionDataGridViewTextBoxColumn.DataPropertyName = "Cotizacion"
        Me.CotizacionDataGridViewTextBoxColumn.HeaderText = "Cotizacion"
        Me.CotizacionDataGridViewTextBoxColumn.Name = "CotizacionDataGridViewTextBoxColumn"
        Me.CotizacionDataGridViewTextBoxColumn.ReadOnly = True
        Me.CotizacionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CotizacionDataGridViewTextBoxColumn.Visible = False
        '
        'ValorDataGridViewTextBoxColumn
        '
        Me.ValorDataGridViewTextBoxColumn.DataPropertyName = "Valor"
        Me.ValorDataGridViewTextBoxColumn.HeaderText = "Valor"
        Me.ValorDataGridViewTextBoxColumn.Name = "ValorDataGridViewTextBoxColumn"
        Me.ValorDataGridViewTextBoxColumn.ReadOnly = True
        Me.ValorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ValorDataGridViewTextBoxColumn.Visible = False
        '
        'ObservacionDataGridViewTextBoxColumn
        '
        Me.ObservacionDataGridViewTextBoxColumn.DataPropertyName = "Observacion"
        Me.ObservacionDataGridViewTextBoxColumn.HeaderText = "Observacion"
        Me.ObservacionDataGridViewTextBoxColumn.Name = "ObservacionDataGridViewTextBoxColumn"
        Me.ObservacionDataGridViewTextBoxColumn.ReadOnly = True
        Me.ObservacionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ObservacionDataGridViewTextBoxColumn.Visible = False
        '
        'CodestadoDataGridViewTextBoxColumn
        '
        Me.CodestadoDataGridViewTextBoxColumn.DataPropertyName = "Codestado"
        Me.CodestadoDataGridViewTextBoxColumn.HeaderText = "Codestado"
        Me.CodestadoDataGridViewTextBoxColumn.Name = "CodestadoDataGridViewTextBoxColumn"
        Me.CodestadoDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodestadoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodestadoDataGridViewTextBoxColumn.Visible = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(35, 0)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(311, 35)
        Me.BuscarTextBox.TabIndex = 476
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 35)
        Me.PictureBox1.TabIndex = 477
        Me.PictureBox1.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.CancelarPictureBox)
        Me.Panel5.Controls.Add(Me.GuardarPictureBox)
        Me.Panel5.Controls.Add(Me.pbxImprimirPagare)
        Me.Panel5.Controls.Add(Me.ModificarPictureBox)
        Me.Panel5.Controls.Add(Me.EliminarPictureBox)
        Me.Panel5.Controls.Add(Me.NuevoPictureBox)
        Me.Panel5.Location = New System.Drawing.Point(339, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(467, 35)
        Me.Panel5.TabIndex = 480
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CancelarPictureBox.Location = New System.Drawing.Point(131, 0)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GuardarPictureBox.Location = New System.Drawing.Point(99, 0)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'pbxImprimirPagare
        '
        Me.pbxImprimirPagare.BackColor = System.Drawing.Color.Transparent
        Me.pbxImprimirPagare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxImprimirPagare.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxImprimirPagare.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbxImprimirPagare.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.pbxImprimirPagare.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxImprimirPagare.Location = New System.Drawing.Point(432, 0)
        Me.pbxImprimirPagare.Name = "pbxImprimirPagare"
        Me.pbxImprimirPagare.Size = New System.Drawing.Size(33, 33)
        Me.pbxImprimirPagare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxImprimirPagare.TabIndex = 454
        Me.pbxImprimirPagare.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ModificarPictureBox.Location = New System.Drawing.Point(67, 0)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EliminarPictureBox.Location = New System.Drawing.Point(35, 0)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NuevoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.NuevoPictureBox.Enabled = False
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.NewOff
        Me.NuevoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NuevoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'ESTADOTableAdapter
        '
        Me.ESTADOTableAdapter.ClearBeforeFill = True
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'VENTAS_PAGARETableAdapter
        '
        Me.VENTAS_PAGARETableAdapter.ClearBeforeFill = True
        '
        'TxtVentas
        '
        Me.TxtVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVentas.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "NUMVENTA", True))
        Me.TxtVentas.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TxtVentas.Location = New System.Drawing.Point(448, 234)
        Me.TxtVentas.Name = "TxtVentas"
        Me.TxtVentas.Size = New System.Drawing.Size(165, 26)
        Me.TxtVentas.TabIndex = 481
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Silver
        Me.Label10.Location = New System.Drawing.Point(621, 241)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 483
        Me.Label10.Text = "Nro Cuota:"
        '
        'txtNroCuota
        '
        Me.txtNroCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroCuota.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "NroCuota", True))
        Me.txtNroCuota.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.txtNroCuota.Location = New System.Drawing.Point(681, 236)
        Me.txtNroCuota.Name = "txtNroCuota"
        Me.txtNroCuota.Size = New System.Drawing.Size(101, 23)
        Me.txtNroCuota.TabIndex = 482
        '
        'RadLabel7
        '
        Me.RadLabel7.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.RadLabel7.BackColor = System.Drawing.Color.Silver
        Me.RadLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.RadLabel7.Location = New System.Drawing.Point(345, 49)
        Me.RadLabel7.Name = "RadLabel7"
        '
        '
        '
        Me.RadLabel7.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel7.RootElement.AngleTransform = 0.0!
        Me.RadLabel7.RootElement.FlipText = False
        Me.RadLabel7.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel7.RootElement.Text = Nothing
        Me.RadLabel7.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel7.Size = New System.Drawing.Size(90, 18)
        Me.RadLabel7.TabIndex = 485
        Me.RadLabel7.Text = "Nº de Pagare:"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        Me.RadLabel7.TextWrap = False
        '
        'lblNroPagare
        '
        Me.lblNroPagare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNroPagare.AutoSize = False
        Me.lblNroPagare.BackColor = System.Drawing.Color.Silver
        Me.lblNroPagare.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASPAGAREBindingSource, "NroPagare", True))
        Me.lblNroPagare.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblNroPagare.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblNroPagare.Location = New System.Drawing.Point(444, 47)
        Me.lblNroPagare.Name = "lblNroPagare"
        '
        '
        '
        Me.lblNroPagare.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.lblNroPagare.RootElement.AngleTransform = 0.0!
        Me.lblNroPagare.RootElement.FlipText = False
        Me.lblNroPagare.RootElement.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblNroPagare.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.lblNroPagare.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.lblNroPagare.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.lblNroPagare.RootElement.Text = Nothing
        Me.lblNroPagare.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.lblNroPagare.Size = New System.Drawing.Size(216, 23)
        Me.lblNroPagare.TabIndex = 484
        Me.lblNroPagare.Text = "XXXXXXXX"
        Me.lblNroPagare.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblNroPagare.TextWrap = False
        '
        'ImpPagareTableAdapter
        '
        Me.ImpPagareTableAdapter.ClearBeforeFill = True
        '
        'rbtVerImpresos
        '
        Me.rbtVerImpresos.AutoSize = True
        Me.rbtVerImpresos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbtVerImpresos.Location = New System.Drawing.Point(185, 39)
        Me.rbtVerImpresos.Name = "rbtVerImpresos"
        Me.rbtVerImpresos.Size = New System.Drawing.Size(146, 19)
        Me.rbtVerImpresos.TabIndex = 4581126
        Me.rbtVerImpresos.Text = "Ver Pagares Impresos"
        Me.rbtVerImpresos.UseVisualStyleBackColor = True
        '
        'rbtverPendientes
        '
        Me.rbtverPendientes.AutoSize = True
        Me.rbtverPendientes.Checked = True
        Me.rbtverPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.rbtverPendientes.Location = New System.Drawing.Point(7, 39)
        Me.rbtverPendientes.Name = "rbtverPendientes"
        Me.rbtverPendientes.Size = New System.Drawing.Size(157, 19)
        Me.rbtverPendientes.TabIndex = 4581124
        Me.rbtverPendientes.TabStop = True
        Me.rbtverPendientes.Text = "Ver Pagares Pendientes"
        Me.rbtverPendientes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.Location = New System.Drawing.Point(340, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(459, 400)
        Me.Panel1.TabIndex = 4581127
        '
        'CmbAño
        '
        Me.CmbAño.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAño.BackColor = System.Drawing.Color.White
        Me.CmbAño.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem13, Me.RadComboBoxItem14, Me.RadComboBoxItem15, Me.RadComboBoxItem16, Me.RadComboBoxItem17, Me.RadComboBoxItem18, Me.RadComboBoxItem19, Me.RadComboBoxItem20, Me.RadComboBoxItem21, Me.RadComboBoxItem22, Me.RadComboBoxItem23})
        Me.CmbAño.Location = New System.Drawing.Point(157, 64)
        Me.CmbAño.MaxDropDownItems = 12
        Me.CmbAño.Name = "CmbAño"
        '
        '
        '
        Me.CmbAño.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.CmbAño.RootElement.AngleTransform = 0.0!
        Me.CmbAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbAño.RootElement.FlipText = False
        Me.CmbAño.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.CmbAño.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.CmbAño.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.CmbAño.RootElement.Text = Nothing
        Me.CmbAño.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.CmbAño.Size = New System.Drawing.Size(99, 26)
        Me.CmbAño.TabIndex = 4581130
        Me.CmbAño.TabStop = False
        Me.CmbAño.ThemeName = "Breeze"
        CType(Me.CmbAño.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'BtnFiltro
        '
        Me.BtnFiltro.AllowDrop = True
        Me.BtnFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltro.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnFiltro.Location = New System.Drawing.Point(262, 64)
        Me.BtnFiltro.Name = "BtnFiltro"
        '
        '
        '
        Me.BtnFiltro.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.BtnFiltro.RootElement.AngleTransform = 0.0!
        Me.BtnFiltro.RootElement.FlipText = False
        Me.BtnFiltro.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFiltro.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.BtnFiltro.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.BtnFiltro.RootElement.Text = Nothing
        Me.BtnFiltro.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.BtnFiltro.Size = New System.Drawing.Size(69, 26)
        Me.BtnFiltro.TabIndex = 4581128
        Me.BtnFiltro.Text = "Filtrar"
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.CmbMes.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbMes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMes.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2, Me.RadComboBoxItem3, Me.RadComboBoxItem4, Me.RadComboBoxItem5, Me.RadComboBoxItem6, Me.RadComboBoxItem7, Me.RadComboBoxItem8, Me.RadComboBoxItem9, Me.RadComboBoxItem10, Me.RadComboBoxItem11, Me.RadComboBoxItem12})
        Me.CmbMes.Location = New System.Drawing.Point(7, 64)
        Me.CmbMes.MaxDropDownItems = 12
        Me.CmbMes.Name = "CmbMes"
        '
        '
        '
        Me.CmbMes.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.CmbMes.RootElement.AngleTransform = 0.0!
        Me.CmbMes.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbMes.RootElement.FlipText = False
        Me.CmbMes.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMes.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.CmbMes.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.CmbMes.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.CmbMes.RootElement.Text = Nothing
        Me.CmbMes.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.CmbMes.Size = New System.Drawing.Size(144, 26)
        Me.CmbMes.TabIndex = 4581129
        Me.CmbMes.TabStop = False
        Me.CmbMes.ThemeName = "Breeze"
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Enero"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "Febrero"
        '
        'RadComboBoxItem3
        '
        Me.RadComboBoxItem3.Name = "RadComboBoxItem3"
        Me.RadComboBoxItem3.Text = "Marzo"
        '
        'RadComboBoxItem4
        '
        Me.RadComboBoxItem4.Name = "RadComboBoxItem4"
        Me.RadComboBoxItem4.Text = "Abril"
        '
        'RadComboBoxItem5
        '
        Me.RadComboBoxItem5.Name = "RadComboBoxItem5"
        Me.RadComboBoxItem5.Text = "Mayo"
        '
        'RadComboBoxItem6
        '
        Me.RadComboBoxItem6.Name = "RadComboBoxItem6"
        Me.RadComboBoxItem6.Text = "Junio"
        '
        'RadComboBoxItem7
        '
        Me.RadComboBoxItem7.Name = "RadComboBoxItem7"
        Me.RadComboBoxItem7.Text = "Julio"
        '
        'RadComboBoxItem8
        '
        Me.RadComboBoxItem8.Name = "RadComboBoxItem8"
        Me.RadComboBoxItem8.Text = "Agosto"
        '
        'RadComboBoxItem9
        '
        Me.RadComboBoxItem9.Name = "RadComboBoxItem9"
        Me.RadComboBoxItem9.Text = "Septiembre"
        '
        'RadComboBoxItem10
        '
        Me.RadComboBoxItem10.Name = "RadComboBoxItem10"
        Me.RadComboBoxItem10.Text = "Octubre"
        '
        'RadComboBoxItem11
        '
        Me.RadComboBoxItem11.Name = "RadComboBoxItem11"
        Me.RadComboBoxItem11.Text = "Noviembre"
        '
        'RadComboBoxItem12
        '
        Me.RadComboBoxItem12.Name = "RadComboBoxItem12"
        Me.RadComboBoxItem12.Text = "Diciembre"
        '
        'RadComboBoxItem13
        '
        Me.RadComboBoxItem13.Name = "RadComboBoxItem13"
        Me.RadComboBoxItem13.Text = "2010"
        '
        'RadComboBoxItem14
        '
        Me.RadComboBoxItem14.Name = "RadComboBoxItem14"
        Me.RadComboBoxItem14.Text = "2011"
        '
        'RadComboBoxItem15
        '
        Me.RadComboBoxItem15.Name = "RadComboBoxItem15"
        Me.RadComboBoxItem15.Text = "2012"
        '
        'RadComboBoxItem16
        '
        Me.RadComboBoxItem16.Name = "RadComboBoxItem16"
        Me.RadComboBoxItem16.Text = "2013"
        '
        'RadComboBoxItem17
        '
        Me.RadComboBoxItem17.Name = "RadComboBoxItem17"
        Me.RadComboBoxItem17.Text = "2014"
        '
        'RadComboBoxItem18
        '
        Me.RadComboBoxItem18.Name = "RadComboBoxItem18"
        Me.RadComboBoxItem18.Text = "2015"
        '
        'RadComboBoxItem19
        '
        Me.RadComboBoxItem19.Name = "RadComboBoxItem19"
        Me.RadComboBoxItem19.Text = "2016"
        '
        'RadComboBoxItem20
        '
        Me.RadComboBoxItem20.Name = "RadComboBoxItem20"
        Me.RadComboBoxItem20.Text = "2017"
        '
        'RadComboBoxItem21
        '
        Me.RadComboBoxItem21.Name = "RadComboBoxItem21"
        Me.RadComboBoxItem21.Text = "2018"
        '
        'RadComboBoxItem22
        '
        Me.RadComboBoxItem22.Name = "RadComboBoxItem22"
        Me.RadComboBoxItem22.Text = "2019"
        '
        'RadComboBoxItem23
        '
        Me.RadComboBoxItem23.Name = "RadComboBoxItem23"
        Me.RadComboBoxItem23.Text = "2020"
        '
        'Venta_Pagare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 446)
        Me.Controls.Add(Me.CmbAño)
        Me.Controls.Add(Me.BtnFiltro)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.rbtVerImpresos)
        Me.Controls.Add(Me.rbtverPendientes)
        Me.Controls.Add(Me.RadLabel7)
        Me.Controls.Add(Me.lblNroPagare)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNroCuota)
        Me.Controls.Add(Me.TxtVentas)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgvPagare)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbxobservacion)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbxvalor)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbxcotizacion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Cbxmoneda)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtpFechaVencimiento)
        Me.Controls.Add(Me.dtpFechaCreacion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbxcliente)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbxEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Venta_Pagare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagares  | Cogent SIG"
        CType(Me.VENTASPAGAREBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ESTADOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxImprimirPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNroPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxcliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaCreacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Cbxmoneda As System.Windows.Forms.ComboBox
    Friend WithEvents tbxcotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbxvalor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbxobservacion As System.Windows.Forms.TextBox
    Friend WithEvents dgvPagare As System.Windows.Forms.DataGridView
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbxImprimirPagare As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents DsPagare As ContaExpress.DsPagare
    Friend WithEvents ESTADOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ESTADOTableAdapter As ContaExpress.DsPagareTableAdapters.ESTADOTableAdapter
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsPagareTableAdapters.CLIENTESTableAdapter
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsPagareTableAdapters.MONEDATableAdapter
    Friend WithEvents VENTASPAGAREBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENTAS_PAGARETableAdapter As ContaExpress.DsPagareTableAdapters.VENTAS_PAGARETableAdapter
    Friend WithEvents TxtVentas As System.Windows.Forms.TextBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNroCuota As System.Windows.Forms.TextBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblNroPagare As Telerik.WinControls.UI.RadLabel
    Friend WithEvents NroPagare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaVencimientoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaCreacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodpagareDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodClienteDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodVentaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodMonedaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CotizacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodestadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImpPagareTableAdapter As ContaExpress.DsPagareTableAdapters.ImpPagareTableAdapter
    Friend WithEvents rbtVerImpresos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtverPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CmbAño As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents BtnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents CmbMes As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents RadComboBoxItem13 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem14 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem15 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem16 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem17 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem18 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem19 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem20 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem21 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem22 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem23 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem3 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem4 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem5 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem6 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem7 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem8 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem9 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem10 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem11 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem12 As Telerik.WinControls.UI.RadComboBoxItem
End Class
