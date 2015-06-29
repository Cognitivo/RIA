<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentasModificarCuotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VentasModificarCuotas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BuscarCompraTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.lblProvName = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvProveedor = New System.Windows.Forms.DataGridView()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREFANTASIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTORIZADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAppModVentas = New ContaExpress.dsAppModVentas()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.cbxListadoFactura = New System.Windows.Forms.ComboBox()
        Me.VENTASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblNuevoMonto = New System.Windows.Forms.Label()
        Me.tbxNuevoMonto = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.lblListaFactura = New System.Windows.Forms.Label()
        Me.lblValorFactura = New System.Windows.Forms.Label()
        Me.lblValorActual = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvFacturasCuotas = New System.Windows.Forms.DataGridView()
        Me.NUMVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NVONROCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AJUSTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAVCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTECUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODNUMEROCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDFORMACOBRAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FACTURACOBRARBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalDiferencia = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxSumaSaldos = New System.Windows.Forms.Label()
        Me.dtpFechaVto = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.tbxTotalCobrar = New System.Windows.Forms.Label()
        Me.lblFechaVencimiento = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btAplicarCambios = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.DsCobros2 = New ContaExpress.DsCobros()
        Me.TextBoxCodProducto = New Telerik.WinControls.UI.RadTextBox()
        Me.TextBoxCodCodigo = New Telerik.WinControls.UI.RadTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CLIENTESTableAdapter = New ContaExpress.dsAppModVentasTableAdapters.CLIENTESTableAdapter()
        Me.VENTASTableAdapter = New ContaExpress.dsAppModVentasTableAdapters.VENTASTableAdapter()
        Me.FACTURACOBRARTableAdapter = New ContaExpress.dsAppModVentasTableAdapters.FACTURACOBRARTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProvName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAppModVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelProducto.SuspendLayout()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturasCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FACTURACOBRARBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.DsCobros2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.BuscarCompraTextBox)
        Me.Panel1.Controls.Add(Me.PictureBox14)
        Me.Panel1.Controls.Add(Me.lblProvName)
        Me.Panel1.Controls.Add(Me.RadLabel16)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 40)
        Me.Panel1.TabIndex = 42
        '
        'BuscarCompraTextBox
        '
        Me.BuscarCompraTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarCompraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarCompraTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCompraTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarCompraTextBox.Location = New System.Drawing.Point(35, 5)
        Me.BuscarCompraTextBox.Name = "BuscarCompraTextBox"
        Me.BuscarCompraTextBox.Size = New System.Drawing.Size(209, 30)
        Me.BuscarCompraTextBox.TabIndex = 460
        '
        'PictureBox14
        '
        Me.PictureBox14.BackColor = System.Drawing.Color.Tan
        Me.PictureBox14.BackgroundImage = CType(resources.GetObject("PictureBox14.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox14.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox14.TabIndex = 461
        Me.PictureBox14.TabStop = False
        '
        'lblProvName
        '
        Me.lblProvName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProvName.AutoSize = False
        Me.lblProvName.BackColor = System.Drawing.Color.Transparent
        Me.lblProvName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblProvName.ForeColor = System.Drawing.Color.Black
        Me.lblProvName.Location = New System.Drawing.Point(328, 7)
        Me.lblProvName.Name = "lblProvName"
        '
        '
        '
        Me.lblProvName.RootElement.ForeColor = System.Drawing.Color.Black
        Me.lblProvName.Size = New System.Drawing.Size(518, 26)
        Me.lblProvName.TabIndex = 459
        Me.lblProvName.Text = "lblProvName"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Location = New System.Drawing.Point(250, 7)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Size = New System.Drawing.Size(81, 26)
        Me.RadLabel16.TabIndex = 458
        Me.RadLabel16.Text = "Cliente :"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(-1, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1056, 597)
        Me.SplitContainer1.SplitterDistance = 245
        Me.SplitContainer1.TabIndex = 43
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvProveedor, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(-1, -1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(246, 597)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'dgvProveedor
        '
        Me.dgvProveedor.AllowUserToAddRows = False
        Me.dgvProveedor.AllowUserToDeleteRows = False
        Me.dgvProveedor.AllowUserToResizeColumns = False
        Me.dgvProveedor.AllowUserToResizeRows = False
        Me.dgvProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProveedor.AutoGenerateColumns = False
        Me.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProveedor.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProveedor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProveedor.ColumnHeadersHeight = 35
        Me.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCLIENTEDataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn, Me.NOMBREFANTASIADataGridViewTextBoxColumn, Me.AUTORIZADODataGridViewTextBoxColumn})
        Me.dgvProveedor.DataSource = Me.CLIENTESBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProveedor.Location = New System.Drawing.Point(3, 3)
        Me.dgvProveedor.MultiSelect = False
        Me.dgvProveedor.Name = "dgvProveedor"
        Me.dgvProveedor.ReadOnly = True
        Me.dgvProveedor.RowHeadersVisible = False
        Me.dgvProveedor.RowHeadersWidth = 187
        Me.dgvProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedor.Size = New System.Drawing.Size(240, 591)
        Me.dgvProveedor.TabIndex = 2
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NOMBREFANTASIADataGridViewTextBoxColumn
        '
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.DataPropertyName = "NOMBREFANTASIA"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.HeaderText = "Nomb. Fantasia"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.Name = "NOMBREFANTASIADataGridViewTextBoxColumn"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.ReadOnly = True
        '
        'AUTORIZADODataGridViewTextBoxColumn
        '
        Me.AUTORIZADODataGridViewTextBoxColumn.DataPropertyName = "AUTORIZADO"
        Me.AUTORIZADODataGridViewTextBoxColumn.HeaderText = "AUTORIZADO"
        Me.AUTORIZADODataGridViewTextBoxColumn.Name = "AUTORIZADODataGridViewTextBoxColumn"
        Me.AUTORIZADODataGridViewTextBoxColumn.ReadOnly = True
        Me.AUTORIZADODataGridViewTextBoxColumn.Visible = False
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsAppModVentas
        '
        'DsAppModVentas
        '
        Me.DsAppModVentas.DataSetName = "dsAppModVentas"
        Me.DsAppModVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelProducto, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(-1, -1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(807, 597)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PanelProducto
        '
        Me.PanelProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelProducto.BackColor = System.Drawing.Color.LightGray
        Me.PanelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelProducto.Controls.Add(Me.cbxListadoFactura)
        Me.PanelProducto.Controls.Add(Me.lblNuevoMonto)
        Me.PanelProducto.Controls.Add(Me.tbxNuevoMonto)
        Me.PanelProducto.Controls.Add(Me.lblListaFactura)
        Me.PanelProducto.Controls.Add(Me.lblValorFactura)
        Me.PanelProducto.Controls.Add(Me.lblValorActual)
        Me.PanelProducto.Controls.Add(Me.Label11)
        Me.PanelProducto.Controls.Add(Me.dgvFacturasCuotas)
        Me.PanelProducto.Controls.Add(Me.Label12)
        Me.PanelProducto.Controls.Add(Me.Label7)
        Me.PanelProducto.Controls.Add(Me.Label6)
        Me.PanelProducto.Controls.Add(Me.Label1)
        Me.PanelProducto.Controls.Add(Me.lblTotalDiferencia)
        Me.PanelProducto.Controls.Add(Me.Label5)
        Me.PanelProducto.Controls.Add(Me.Label4)
        Me.PanelProducto.Controls.Add(Me.tbxSumaSaldos)
        Me.PanelProducto.Controls.Add(Me.dtpFechaVto)
        Me.PanelProducto.Controls.Add(Me.btnEliminar)
        Me.PanelProducto.Controls.Add(Me.btnNuevo)
        Me.PanelProducto.Controls.Add(Me.tbxTotalCobrar)
        Me.PanelProducto.Controls.Add(Me.lblFechaVencimiento)
        Me.PanelProducto.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PanelProducto.Location = New System.Drawing.Point(3, 83)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(801, 511)
        Me.PanelProducto.TabIndex = 1
        '
        'cbxListadoFactura
        '
        Me.cbxListadoFactura.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxListadoFactura.DataSource = Me.VENTASBindingSource
        Me.cbxListadoFactura.DisplayMember = "NUMVENTA"
        Me.cbxListadoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxListadoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxListadoFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxListadoFactura.FormattingEnabled = True
        Me.cbxListadoFactura.Location = New System.Drawing.Point(665, 262)
        Me.cbxListadoFactura.Name = "cbxListadoFactura"
        Me.cbxListadoFactura.Size = New System.Drawing.Size(132, 28)
        Me.cbxListadoFactura.TabIndex = 583
        Me.cbxListadoFactura.ValueMember = "CODVENTA"
        '
        'VENTASBindingSource
        '
        Me.VENTASBindingSource.DataMember = "VENTAS"
        Me.VENTASBindingSource.DataSource = Me.DsAppModVentas
        '
        'lblNuevoMonto
        '
        Me.lblNuevoMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevoMonto.Location = New System.Drawing.Point(577, 128)
        Me.lblNuevoMonto.Name = "lblNuevoMonto"
        Me.lblNuevoMonto.Size = New System.Drawing.Size(72, 38)
        Me.lblNuevoMonto.TabIndex = 581
        Me.lblNuevoMonto.Text = "Nuevo Monto:"
        Me.ToolTip1.SetToolTip(Me.lblNuevoMonto, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'tbxNuevoMonto
        '
        Me.tbxNuevoMonto.AllowDrop = True
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.SizeInPoints = 12.0!
        Me.tbxNuevoMonto.Appearance = Appearance2
        Me.tbxNuevoMonto.AutoSize = False
        Me.tbxNuevoMonto.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxNuevoMonto.CausesValidation = False
        Me.tbxNuevoMonto.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxNuevoMonto.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.tbxNuevoMonto.Location = New System.Drawing.Point(665, 134)
        Me.tbxNuevoMonto.Name = "tbxNuevoMonto"
        Me.tbxNuevoMonto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxNuevoMonto.Size = New System.Drawing.Size(132, 26)
        Me.tbxNuevoMonto.TabIndex = 580
        Me.ToolTip1.SetToolTip(Me.tbxNuevoMonto, "Nuevo Monto a insertar para la Nueva Cuota")
        '
        'lblListaFactura
        '
        Me.lblListaFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblListaFactura.Location = New System.Drawing.Point(563, 246)
        Me.lblListaFactura.Name = "lblListaFactura"
        Me.lblListaFactura.Size = New System.Drawing.Size(101, 53)
        Me.lblListaFactura.TabIndex = 579
        Me.lblListaFactura.Text = "Seleccione " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "la Factura a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ser modificada:"
        Me.ToolTip1.SetToolTip(Me.lblListaFactura, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'lblValorFactura
        '
        Me.lblValorFactura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblValorFactura.AutoSize = True
        Me.lblValorFactura.ForeColor = System.Drawing.Color.Black
        Me.lblValorFactura.Location = New System.Drawing.Point(639, 25)
        Me.lblValorFactura.Name = "lblValorFactura"
        Me.lblValorFactura.Size = New System.Drawing.Size(0, 13)
        Me.lblValorFactura.TabIndex = 575
        '
        'lblValorActual
        '
        Me.lblValorActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblValorActual.AutoSize = True
        Me.lblValorActual.ForeColor = System.Drawing.Color.Black
        Me.lblValorActual.Location = New System.Drawing.Point(639, 47)
        Me.lblValorActual.Name = "lblValorActual"
        Me.lblValorActual.Size = New System.Drawing.Size(0, 13)
        Me.lblValorActual.TabIndex = 574
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(566, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 541
        Me.Label11.Text = "Factura:"
        '
        'dgvFacturasCuotas
        '
        Me.dgvFacturasCuotas.AllowUserToAddRows = False
        Me.dgvFacturasCuotas.AllowUserToDeleteRows = False
        Me.dgvFacturasCuotas.AllowUserToResizeRows = False
        Me.dgvFacturasCuotas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvFacturasCuotas.AutoGenerateColumns = False
        Me.dgvFacturasCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFacturasCuotas.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvFacturasCuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFacturasCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMVENTA, Me.CODVENTA, Me.CODCLIENTE, Me.EstadoFila, Me.NVONROCUOTA, Me.AJUSTE, Me.FECHAVCTO, Me.SALDOCUOTA, Me.IMPORTECUOTA, Me.CODNUMEROCUOTA, Me.IDFORMACOBRAR, Me.CODVENTADataGridViewTextBoxColumn, Me.CODCLIENTEDataGridViewTextBoxColumn1})
        Me.dgvFacturasCuotas.DataSource = Me.FACTURACOBRARBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturasCuotas.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFacturasCuotas.Location = New System.Drawing.Point(0, 25)
        Me.dgvFacturasCuotas.Name = "dgvFacturasCuotas"
        Me.dgvFacturasCuotas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvFacturasCuotas.RowHeadersVisible = False
        Me.dgvFacturasCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturasCuotas.Size = New System.Drawing.Size(563, 404)
        Me.dgvFacturasCuotas.TabIndex = 573
        '
        'NUMVENTA
        '
        Me.NUMVENTA.DataPropertyName = "NUMVENTA"
        Me.NUMVENTA.HeaderText = "Factura"
        Me.NUMVENTA.Name = "NUMVENTA"
        '
        'CODVENTA
        '
        Me.CODVENTA.DataPropertyName = "CODVENTA"
        Me.CODVENTA.HeaderText = "CODVENTA"
        Me.CODVENTA.Name = "CODVENTA"
        Me.CODVENTA.ReadOnly = True
        Me.CODVENTA.Visible = False
        '
        'CODCLIENTE
        '
        Me.CODCLIENTE.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTE.HeaderText = "CODCLIENTE"
        Me.CODCLIENTE.Name = "CODCLIENTE"
        Me.CODCLIENTE.Visible = False
        '
        'EstadoFila
        '
        Me.EstadoFila.HeaderText = "EstadoFila"
        Me.EstadoFila.Name = "EstadoFila"
        Me.EstadoFila.Visible = False
        '
        'NVONROCUOTA
        '
        Me.NVONROCUOTA.DataPropertyName = "CODNUMEROCUOTA"
        Me.NVONROCUOTA.HeaderText = "NVONROCUOTA"
        Me.NVONROCUOTA.Name = "NVONROCUOTA"
        Me.NVONROCUOTA.Visible = False
        '
        'AJUSTE
        '
        Me.AJUSTE.HeaderText = "AJUSTE"
        Me.AJUSTE.Name = "AJUSTE"
        Me.AJUSTE.Visible = False
        '
        'FECHAVCTO
        '
        Me.FECHAVCTO.DataPropertyName = "FECHAVCTO"
        Me.FECHAVCTO.HeaderText = "Vencimiento"
        Me.FECHAVCTO.Name = "FECHAVCTO"
        '
        'SALDOCUOTA
        '
        Me.SALDOCUOTA.DataPropertyName = "SALDOCUOTA"
        Me.SALDOCUOTA.HeaderText = "Saldo"
        Me.SALDOCUOTA.Name = "SALDOCUOTA"
        '
        'IMPORTECUOTA
        '
        Me.IMPORTECUOTA.DataPropertyName = "IMPORTECUOTA"
        Me.IMPORTECUOTA.HeaderText = "Importe"
        Me.IMPORTECUOTA.Name = "IMPORTECUOTA"
        '
        'CODNUMEROCUOTA
        '
        Me.CODNUMEROCUOTA.DataPropertyName = "CODNUMEROCUOTA"
        Me.CODNUMEROCUOTA.HeaderText = "CODNUMEROCUOTA"
        Me.CODNUMEROCUOTA.Name = "CODNUMEROCUOTA"
        Me.CODNUMEROCUOTA.Visible = False
        '
        'IDFORMACOBRAR
        '
        Me.IDFORMACOBRAR.DataPropertyName = "IDFORMACOBRAR"
        Me.IDFORMACOBRAR.HeaderText = "IDFORMACOBRAR"
        Me.IDFORMACOBRAR.Name = "IDFORMACOBRAR"
        Me.IDFORMACOBRAR.ReadOnly = True
        Me.IDFORMACOBRAR.Visible = False
        '
        'CODVENTADataGridViewTextBoxColumn
        '
        Me.CODVENTADataGridViewTextBoxColumn.DataPropertyName = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.HeaderText = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.Name = "CODVENTADataGridViewTextBoxColumn"
        Me.CODVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODVENTADataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn1
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn1.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.Name = "CODCLIENTEDataGridViewTextBoxColumn1"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.Visible = False
        '
        'FACTURACOBRARBindingSource
        '
        Me.FACTURACOBRARBindingSource.DataMember = "FACTURACOBRAR"
        Me.FACTURACOBRARBindingSource.DataSource = Me.DsAppModVentas
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(566, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 540
        Me.Label12.Text = "Valor Actual:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 20)
        Me.Label7.TabIndex = 572
        Me.Label7.Text = "Detalle de Cuotas"
        Me.ToolTip1.SetToolTip(Me.Label7, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(283, 481)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(494, 30)
        Me.Label6.TabIndex = 571
        Me.Label6.Text = "OBS : Doble Click sobre las celdas ""Nuevo Monto"" y ""Vencimiento"" de la Grilla de " & _
    "Cuotas si desea Editarlos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(620, 432)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 570
        Me.Label1.Text = "Diferencia"
        '
        'lblTotalDiferencia
        '
        Me.lblTotalDiferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDiferencia.BackColor = System.Drawing.Color.Khaki
        Me.lblTotalDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDiferencia.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDiferencia.Location = New System.Drawing.Point(620, 452)
        Me.lblTotalDiferencia.Name = "lblTotalDiferencia"
        Me.lblTotalDiferencia.Size = New System.Drawing.Size(161, 25)
        Me.lblTotalDiferencia.TabIndex = 569
        Me.lblTotalDiferencia.Text = "0"
        Me.lblTotalDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(451, 432)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 16)
        Me.Label5.TabIndex = 568
        Me.Label5.Text = "Suma de los Saldos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(282, 432)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 16)
        Me.Label4.TabIndex = 567
        Me.Label4.Text = "Total a Cobrar"
        '
        'tbxSumaSaldos
        '
        Me.tbxSumaSaldos.AccessibleDescription = ""
        Me.tbxSumaSaldos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbxSumaSaldos.BackColor = System.Drawing.Color.White
        Me.tbxSumaSaldos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxSumaSaldos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbxSumaSaldos.ForeColor = System.Drawing.Color.Black
        Me.tbxSumaSaldos.Location = New System.Drawing.Point(451, 452)
        Me.tbxSumaSaldos.Name = "tbxSumaSaldos"
        Me.tbxSumaSaldos.Size = New System.Drawing.Size(161, 25)
        Me.tbxSumaSaldos.TabIndex = 566
        Me.tbxSumaSaldos.Text = "0"
        Me.tbxSumaSaldos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaVto
        '
        Me.dtpFechaVto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVto.Location = New System.Drawing.Point(665, 194)
        Me.dtpFechaVto.Name = "dtpFechaVto"
        Me.dtpFechaVto.Size = New System.Drawing.Size(132, 26)
        Me.dtpFechaVto.TabIndex = 562
        Me.ToolTip1.SetToolTip(Me.dtpFechaVto, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEliminar.Location = New System.Drawing.Point(672, 336)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(69, 28)
        Me.btnEliminar.TabIndex = 561
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNuevo.Location = New System.Drawing.Point(578, 336)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(70, 28)
        Me.btnNuevo.TabIndex = 560
        Me.btnNuevo.Text = "Agregar"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'tbxTotalCobrar
        '
        Me.tbxTotalCobrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbxTotalCobrar.BackColor = System.Drawing.Color.White
        Me.tbxTotalCobrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTotalCobrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.tbxTotalCobrar.ForeColor = System.Drawing.Color.Black
        Me.tbxTotalCobrar.Location = New System.Drawing.Point(282, 452)
        Me.tbxTotalCobrar.Name = "tbxTotalCobrar"
        Me.tbxTotalCobrar.Size = New System.Drawing.Size(161, 25)
        Me.tbxTotalCobrar.TabIndex = 559
        Me.tbxTotalCobrar.Text = "0"
        Me.tbxTotalCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFechaVencimiento
        '
        Me.lblFechaVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaVencimiento.Location = New System.Drawing.Point(577, 189)
        Me.lblFechaVencimiento.Name = "lblFechaVencimiento"
        Me.lblFechaVencimiento.Size = New System.Drawing.Size(72, 38)
        Me.lblFechaVencimiento.TabIndex = 564
        Me.lblFechaVencimiento.Text = "Nueva Fecha Vto:"
        Me.ToolTip1.SetToolTip(Me.lblFechaVencimiento, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(801, 74)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.34498!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.65502!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btAplicarCambios, 6, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelar, 5, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(-1, 5)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.30769!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.69231!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(802, 65)
        Me.TableLayoutPanel3.TabIndex = 546
        '
        'btAplicarCambios
        '
        Me.btAplicarCambios.BackColor = System.Drawing.Color.Tan
        Me.btAplicarCambios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btAplicarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAplicarCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAplicarCambios.Image = CType(resources.GetObject("btAplicarCambios.Image"), System.Drawing.Image)
        Me.btAplicarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAplicarCambios.Location = New System.Drawing.Point(615, 23)
        Me.btAplicarCambios.Name = "btAplicarCambios"
        Me.btAplicarCambios.Size = New System.Drawing.Size(184, 39)
        Me.btAplicarCambios.TabIndex = 547
        Me.btAplicarCambios.Text = "Aplicar Cambios"
        Me.btAplicarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAplicarCambios.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Tan
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(492, 23)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(117, 39)
        Me.btnCancelar.TabIndex = 548
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'DsCobros2
        '
        Me.DsCobros2.DataSetName = "DsCobros"
        Me.DsCobros2.EnforceConstraints = False
        Me.DsCobros2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBoxCodProducto
        '
        Me.TextBoxCodProducto.Location = New System.Drawing.Point(306, 22)
        Me.TextBoxCodProducto.Name = "TextBoxCodProducto"
        Me.TextBoxCodProducto.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodProducto.TabIndex = 186
        Me.TextBoxCodProducto.TabStop = False
        '
        'TextBoxCodCodigo
        '
        Me.TextBoxCodCodigo.Location = New System.Drawing.Point(342, 22)
        Me.TextBoxCodCodigo.Name = "TextBoxCodCodigo"
        Me.TextBoxCodCodigo.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodCodigo.TabIndex = 187
        Me.TextBoxCodCodigo.TabStop = False
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'VENTASTableAdapter
        '
        Me.VENTASTableAdapter.ClearBeforeFill = True
        '
        'FACTURACOBRARTableAdapter
        '
        Me.FACTURACOBRARTableAdapter.ClearBeforeFill = True
        '
        'VentasModificarCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 631)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "VentasModificarCuotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Refinanciar Cuotas de Clientes | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProvName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAppModVentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelProducto.ResumeLayout(False)
        Me.PanelProducto.PerformLayout()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturasCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FACTURACOBRARBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.DsCobros2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblProvName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelProducto As System.Windows.Forms.Panel
    Friend WithEvents TextBoxCodProducto As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TextBoxCodCodigo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btAplicarCambios As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents BuscarCompraTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DsAppModVentas As ContaExpress.dsAppModVentas
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.dsAppModVentasTableAdapters.CLIENTESTableAdapter
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREFANTASIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTORIZADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENTASTableAdapter As ContaExpress.dsAppModVentasTableAdapters.VENTASTableAdapter
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaVto As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblFechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents DsCobros2 As ContaExpress.DsCobros
    Friend WithEvents dgvFacturasCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents lblValorFactura As System.Windows.Forms.Label
    Friend WithEvents lblValorActual As System.Windows.Forms.Label
    Friend WithEvents lblListaFactura As System.Windows.Forms.Label
    Friend WithEvents lblNuevoMonto As System.Windows.Forms.Label
    Friend WithEvents tbxNuevoMonto As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDiferencia As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxSumaSaldos As System.Windows.Forms.Label
    Friend WithEvents tbxTotalCobrar As System.Windows.Forms.Label
    Friend WithEvents FACTURACOBRARBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FACTURACOBRARTableAdapter As ContaExpress.dsAppModVentasTableAdapters.FACTURACOBRARTableAdapter
    Friend WithEvents NUMVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoFila As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NVONROCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AJUSTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAVCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTECUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODNUMEROCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDFORMACOBRAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxListadoFactura As System.Windows.Forms.ComboBox
End Class
