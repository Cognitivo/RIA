<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CostodeVenta
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CostodeVenta))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.dgvVentasCosto = New System.Windows.Forms.DataGridView()
        Me.FECHAVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCosteo = New ContaExpress.DsCosteo()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cmbAnho = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.VENTASTableAdapter = New ContaExpress.DsCosteoTableAdapters.VENTASTableAdapter()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblNroFactura = New System.Windows.Forms.Label()
        Me.lblRucCliente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalVenta = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgwVentasDetalleCosto = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOVENTALISTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTOPROMEDIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENTADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTASDETALLECOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDETALLECOSTOTableAdapter = New ContaExpress.DsCosteoTableAdapters.VENTASDETALLECOSTOTableAdapter()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVentasCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCosteo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwVentasDetalleCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDETALLECOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 41)
        Me.Panel1.TabIndex = 498
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(6, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.TabIndex = 462
        Me.PictureBox1.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(35, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(229, 30)
        Me.BuscarTextBox.TabIndex = 461
        '
        'dgvVentasCosto
        '
        Me.dgvVentasCosto.AllowUserToAddRows = False
        Me.dgvVentasCosto.AllowUserToDeleteRows = False
        Me.dgvVentasCosto.AllowUserToResizeColumns = False
        Me.dgvVentasCosto.AllowUserToResizeRows = False
        Me.dgvVentasCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvVentasCosto.AutoGenerateColumns = False
        Me.dgvVentasCosto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVentasCosto.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVentasCosto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVentasCosto.ColumnHeadersHeight = 35
        Me.dgvVentasCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAVENTADataGridViewTextBoxColumn, Me.NUMVENTADataGridViewTextBoxColumn, Me.CODVENTADataGridViewTextBoxColumn, Me.NOMBRECLIENTEDataGridViewTextBoxColumn, Me.RUCCLIENTEDataGridViewTextBoxColumn, Me.TOTALVENTADataGridViewTextBoxColumn, Me.TIPOVENTADataGridViewTextBoxColumn})
        Me.dgvVentasCosto.DataSource = Me.VENTASBindingSource
        Me.dgvVentasCosto.Location = New System.Drawing.Point(3, 81)
        Me.dgvVentasCosto.Name = "dgvVentasCosto"
        Me.dgvVentasCosto.ReadOnly = True
        Me.dgvVentasCosto.RowHeadersVisible = False
        Me.dgvVentasCosto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvVentasCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentasCosto.Size = New System.Drawing.Size(261, 476)
        Me.dgvVentasCosto.TabIndex = 499
        '
        'FECHAVENTADataGridViewTextBoxColumn
        '
        Me.FECHAVENTADataGridViewTextBoxColumn.DataPropertyName = "FECHAVENTA"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHAVENTADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHAVENTADataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHAVENTADataGridViewTextBoxColumn.Name = "FECHAVENTADataGridViewTextBoxColumn"
        Me.FECHAVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'NUMVENTADataGridViewTextBoxColumn
        '
        Me.NUMVENTADataGridViewTextBoxColumn.DataPropertyName = "NUMVENTA"
        Me.NUMVENTADataGridViewTextBoxColumn.HeaderText = "Factura Nro"
        Me.NUMVENTADataGridViewTextBoxColumn.Name = "NUMVENTADataGridViewTextBoxColumn"
        Me.NUMVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODVENTADataGridViewTextBoxColumn
        '
        Me.CODVENTADataGridViewTextBoxColumn.DataPropertyName = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.HeaderText = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.Name = "CODVENTADataGridViewTextBoxColumn"
        Me.CODVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODVENTADataGridViewTextBoxColumn.Visible = False
        '
        'NOMBRECLIENTEDataGridViewTextBoxColumn
        '
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NOMBRECLIENTE"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.HeaderText = "NOMBRECLIENTE"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.Name = "NOMBRECLIENTEDataGridViewTextBoxColumn"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'RUCCLIENTEDataGridViewTextBoxColumn
        '
        Me.RUCCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "RUCCLIENTE"
        Me.RUCCLIENTEDataGridViewTextBoxColumn.HeaderText = "RUCCLIENTE"
        Me.RUCCLIENTEDataGridViewTextBoxColumn.Name = "RUCCLIENTEDataGridViewTextBoxColumn"
        Me.RUCCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.RUCCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'TOTALVENTADataGridViewTextBoxColumn
        '
        Me.TOTALVENTADataGridViewTextBoxColumn.DataPropertyName = "TOTALVENTA"
        Me.TOTALVENTADataGridViewTextBoxColumn.HeaderText = "TOTALVENTA"
        Me.TOTALVENTADataGridViewTextBoxColumn.Name = "TOTALVENTADataGridViewTextBoxColumn"
        Me.TOTALVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALVENTADataGridViewTextBoxColumn.Visible = False
        '
        'TIPOVENTADataGridViewTextBoxColumn
        '
        Me.TIPOVENTADataGridViewTextBoxColumn.DataPropertyName = "TIPOVENTA"
        Me.TIPOVENTADataGridViewTextBoxColumn.HeaderText = "TIPOVENTA"
        Me.TIPOVENTADataGridViewTextBoxColumn.Name = "TIPOVENTADataGridViewTextBoxColumn"
        Me.TIPOVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.TIPOVENTADataGridViewTextBoxColumn.Visible = False
        '
        'VENTASBindingSource
        '
        Me.VENTASBindingSource.DataMember = "VENTAS"
        Me.VENTASBindingSource.DataSource = Me.DsCosteo
        '
        'DsCosteo
        '
        Me.DsCosteo.DataSetName = "DsCosteo"
        Me.DsCosteo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'btnFiltrar
        '
        Me.btnFiltrar.BackColor = System.Drawing.Color.Silver
        Me.btnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnFiltrar.Location = New System.Drawing.Point(191, 49)
        Me.btnFiltrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(67, 27)
        Me.btnFiltrar.TabIndex = 543
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = False
        '
        'cmbAnho
        '
        Me.cmbAnho.BackColor = System.Drawing.Color.White
        Me.cmbAnho.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAnho.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbAnho.FormattingEnabled = True
        Me.cmbAnho.Items.AddRange(New Object() {"2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cmbAnho.Location = New System.Drawing.Point(111, 47)
        Me.cmbAnho.MaxDropDownItems = 12
        Me.cmbAnho.Name = "cmbAnho"
        Me.cmbAnho.Size = New System.Drawing.Size(73, 28)
        Me.cmbAnho.TabIndex = 542
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.White
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(6, 47)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(99, 28)
        Me.cmbMes.TabIndex = 541
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Location = New System.Drawing.Point(-1, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(265, 67)
        Me.Panel2.TabIndex = 544
        '
        'VENTASTableAdapter
        '
        Me.VENTASTableAdapter.ClearBeforeFill = True
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(279, 50)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(107, 23)
        Me.lblEmpresa.TabIndex = 545
        Me.lblEmpresa.Text = "Nro de Factura:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNroFactura
        '
        Me.lblNroFactura.BackColor = System.Drawing.Color.Transparent
        Me.lblNroFactura.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASBindingSource, "NUMVENTA", True))
        Me.lblNroFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNroFactura.Location = New System.Drawing.Point(386, 50)
        Me.lblNroFactura.Name = "lblNroFactura"
        Me.lblNroFactura.Size = New System.Drawing.Size(243, 23)
        Me.lblNroFactura.TabIndex = 546
        Me.lblNroFactura.Text = "Factura Nro"
        Me.lblNroFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRucCliente
        '
        Me.lblRucCliente.BackColor = System.Drawing.Color.LightGray
        Me.lblRucCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASBindingSource, "RUCCLIENTE", True))
        Me.lblRucCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRucCliente.Location = New System.Drawing.Point(368, 94)
        Me.lblRucCliente.Name = "lblRucCliente"
        Me.lblRucCliente.Size = New System.Drawing.Size(158, 23)
        Me.lblRucCliente.TabIndex = 548
        Me.lblRucCliente.Text = "RucCliente"
        Me.lblRucCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(279, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 23)
        Me.Label2.TabIndex = 547
        Me.Label2.Text = "Ruc:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASBindingSource, "NOMBRECLIENTE", True))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(583, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 23)
        Me.Label1.TabIndex = 550
        Me.Label1.Text = "Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightGray
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(476, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(107, 23)
        Me.Label3.TabIndex = 549
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalVenta
        '
        Me.lblTotalVenta.BackColor = System.Drawing.Color.LightGray
        Me.lblTotalVenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASBindingSource, "TOTALVENTA", True))
        Me.lblTotalVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalVenta.ForeColor = System.Drawing.Color.DarkRed
        Me.lblTotalVenta.Location = New System.Drawing.Point(750, 523)
        Me.lblTotalVenta.Name = "lblTotalVenta"
        Me.lblTotalVenta.Size = New System.Drawing.Size(177, 32)
        Me.lblTotalVenta.TabIndex = 554
        Me.lblTotalVenta.Text = "TotalVenta"
        Me.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightGray
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(643, 528)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 23)
        Me.Label5.TabIndex = 553
        Me.Label5.Text = "Total Venta:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.LightGray
        Me.lblFecha.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENTASBindingSource, "FECHAVENTA", True))
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.Location = New System.Drawing.Point(368, 127)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(460, 23)
        Me.lblFecha.TabIndex = 552
        Me.lblFecha.Text = "Fecha"
        Me.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.LightGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(279, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 23)
        Me.Label7.TabIndex = 551
        Me.Label7.Text = "Fecha:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgwVentasDetalleCosto
        '
        Me.dgwVentasDetalleCosto.AllowUserToAddRows = False
        Me.dgwVentasDetalleCosto.AllowUserToDeleteRows = False
        Me.dgwVentasDetalleCosto.AllowUserToResizeColumns = False
        Me.dgwVentasDetalleCosto.AllowUserToResizeRows = False
        Me.dgwVentasDetalleCosto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwVentasDetalleCosto.AutoGenerateColumns = False
        Me.dgwVentasDetalleCosto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwVentasDetalleCosto.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwVentasDetalleCosto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwVentasDetalleCosto.ColumnHeadersHeight = 35
        Me.dgwVentasDetalleCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADVENTADataGridViewTextBoxColumn, Me.PRECIOVENTALISTA, Me.COSTOPROMEDIODataGridViewTextBoxColumn, Me.CODVENTADataGridViewTextBoxColumn1})
        Me.dgwVentasDetalleCosto.DataSource = Me.VENTASDETALLECOSTOBindingSource
        Me.dgwVentasDetalleCosto.Location = New System.Drawing.Point(273, 164)
        Me.dgwVentasDetalleCosto.Name = "dgwVentasDetalleCosto"
        Me.dgwVentasDetalleCosto.ReadOnly = True
        Me.dgwVentasDetalleCosto.RowHeadersVisible = False
        Me.dgwVentasDetalleCosto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwVentasDetalleCosto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwVentasDetalleCosto.Size = New System.Drawing.Size(656, 351)
        Me.dgwVentasDetalleCosto.TabIndex = 555
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigo"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CANTIDADVENTADataGridViewTextBoxColumn
        '
        Me.CANTIDADVENTADataGridViewTextBoxColumn.DataPropertyName = "CANTIDADVENTA"
        Me.CANTIDADVENTADataGridViewTextBoxColumn.FillWeight = 30.0!
        Me.CANTIDADVENTADataGridViewTextBoxColumn.HeaderText = "Cantidad"
        Me.CANTIDADVENTADataGridViewTextBoxColumn.Name = "CANTIDADVENTADataGridViewTextBoxColumn"
        Me.CANTIDADVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRECIOVENTALISTA
        '
        Me.PRECIOVENTALISTA.DataPropertyName = "PRECIOVENTALISTA"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PRECIOVENTALISTA.DefaultCellStyle = DataGridViewCellStyle4
        Me.PRECIOVENTALISTA.FillWeight = 50.0!
        Me.PRECIOVENTALISTA.HeaderText = "Precio de Venta"
        Me.PRECIOVENTALISTA.Name = "PRECIOVENTALISTA"
        Me.PRECIOVENTALISTA.ReadOnly = True
        '
        'COSTOPROMEDIODataGridViewTextBoxColumn
        '
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.DataPropertyName = "COSTOPROMEDIO"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.HeaderText = "Costo (Fifo) * Cantidad"
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.Name = "COSTOPROMEDIODataGridViewTextBoxColumn"
        Me.COSTOPROMEDIODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODVENTADataGridViewTextBoxColumn1
        '
        Me.CODVENTADataGridViewTextBoxColumn1.DataPropertyName = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn1.HeaderText = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn1.Name = "CODVENTADataGridViewTextBoxColumn1"
        Me.CODVENTADataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODVENTADataGridViewTextBoxColumn1.Visible = False
        '
        'VENTASDETALLECOSTOBindingSource
        '
        Me.VENTASDETALLECOSTOBindingSource.DataMember = "VENTASDETALLECOSTO"
        Me.VENTASDETALLECOSTOBindingSource.DataSource = Me.DsCosteo
        '
        'VENTASDETALLECOSTOTableAdapter
        '
        Me.VENTASDETALLECOSTOTableAdapter.ClearBeforeFill = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.Location = New System.Drawing.Point(273, 78)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(656, 81)
        Me.Panel3.TabIndex = 556
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightGray
        Me.Panel4.Location = New System.Drawing.Point(273, 521)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(656, 36)
        Me.Panel4.TabIndex = 557
        '
        'CostodeVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(938, 559)
        Me.Controls.Add(Me.dgwVentasDetalleCosto)
        Me.Controls.Add(Me.lblTotalVenta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblRucCliente)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNroFactura)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.btnFiltrar)
        Me.Controls.Add(Me.cmbAnho)
        Me.Controls.Add(Me.cmbMes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvVentasCosto)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "CostodeVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costo de Productos por Venta  | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVentasCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCosteo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwVentasDetalleCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDETALLECOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dgvVentasCosto As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents cmbAnho As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents VENTASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCosteo As ContaExpress.DsCosteo
    Friend WithEvents VENTASTableAdapter As ContaExpress.DsCosteoTableAdapters.VENTASTableAdapter
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblNroFactura As System.Windows.Forms.Label
    Friend WithEvents lblRucCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalVenta As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgwVentasDetalleCosto As System.Windows.Forms.DataGridView
    Friend WithEvents VENTASDETALLECOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENTASDETALLECOSTOTableAdapter As ContaExpress.DsCosteoTableAdapters.VENTASDETALLECOSTOTableAdapter
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents FECHAVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRECLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOVENTALISTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTOPROMEDIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENTADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
