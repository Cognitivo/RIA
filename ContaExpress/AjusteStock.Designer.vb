<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjusteStock
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjusteStock))
        Me.STOCKAJUSTENVBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInventario = New ContaExpress.DsInventario()
        Me.dgvSucursal = New System.Windows.Forms.DataGridView()
        Me.CODSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxBuscador = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxTodos = New System.Windows.Forms.CheckBox()
        Me.pnlNoHayStockNoRows = New System.Windows.Forms.Panel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPagosEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.STOCKAJUSTENVTableAdapter = New ContaExpress.DsInventarioTableAdapters.STOCKAJUSTENVTableAdapter()
        Me.dgwAjusteStock = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockReal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ajuste = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.STOCKAJUSTENVBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNoHayStockNoRows.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgwAjusteStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'STOCKAJUSTENVBindingSource
        '
        Me.STOCKAJUSTENVBindingSource.DataMember = "STOCKAJUSTENV"
        Me.STOCKAJUSTENVBindingSource.DataSource = Me.DsInventario
        '
        'DsInventario
        '
        Me.DsInventario.DataSetName = "DsInventario"
        Me.DsInventario.EnforceConstraints = False
        Me.DsInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvSucursal
        '
        Me.dgvSucursal.AllowUserToAddRows = False
        Me.dgvSucursal.AllowUserToDeleteRows = False
        Me.dgvSucursal.AllowUserToResizeColumns = False
        Me.dgvSucursal.AllowUserToResizeRows = False
        Me.dgvSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvSucursal.AutoGenerateColumns = False
        Me.dgvSucursal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSucursal.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSucursal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSucursal.ColumnHeadersHeight = 35
        Me.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSucursal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODSUCURSAL, Me.DESSUCURSAL, Me.TIPOSUCURSAL})
        Me.dgvSucursal.DataSource = Me.SUCURSALBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSucursal.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSucursal.Location = New System.Drawing.Point(1, 60)
        Me.dgvSucursal.MultiSelect = False
        Me.dgvSucursal.Name = "dgvSucursal"
        Me.dgvSucursal.ReadOnly = True
        Me.dgvSucursal.RowHeadersVisible = False
        Me.dgvSucursal.RowHeadersWidth = 187
        Me.dgvSucursal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSucursal.Size = New System.Drawing.Size(189, 520)
        Me.dgvSucursal.TabIndex = 1
        '
        'CODSUCURSAL
        '
        Me.CODSUCURSAL.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSAL.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSAL.Name = "CODSUCURSAL"
        Me.CODSUCURSAL.ReadOnly = True
        Me.CODSUCURSAL.Visible = False
        '
        'DESSUCURSAL
        '
        Me.DESSUCURSAL.DataPropertyName = "DESSUCURSAL"
        Me.DESSUCURSAL.HeaderText = "Lista de Depositos | Sucursales"
        Me.DESSUCURSAL.Name = "DESSUCURSAL"
        Me.DESSUCURSAL.ReadOnly = True
        '
        'TIPOSUCURSAL
        '
        Me.TIPOSUCURSAL.DataPropertyName = "TIPOSUCURSAL"
        Me.TIPOSUCURSAL.HeaderText = "TIPOSUCURSAL"
        Me.TIPOSUCURSAL.Name = "TIPOSUCURSAL"
        Me.TIPOSUCURSAL.ReadOnly = True
        Me.TIPOSUCURSAL.Visible = False
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsInventario
        '
        'tbxBuscador
        '
        Me.tbxBuscador.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxBuscador.BackColor = System.Drawing.Color.Tan
        Me.tbxBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscador.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.tbxBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscador.ForeColor = System.Drawing.Color.Black
        Me.tbxBuscador.Location = New System.Drawing.Point(698, 6)
        Me.tbxBuscador.Name = "tbxBuscador"
        Me.tbxBuscador.Size = New System.Drawing.Size(239, 30)
        Me.tbxBuscador.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(670, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.TabIndex = 455
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.RadLabel15)
        Me.Panel1.Controls.Add(Me.RadLabel16)
        Me.Panel1.Controls.Add(Me.tbxBuscador)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 40)
        Me.Panel1.TabIndex = 456
        '
        'RadLabel15
        '
        Me.RadLabel15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel15.AutoSize = False
        Me.RadLabel15.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.RadLabel15.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.Location = New System.Drawing.Point(121, 7)
        Me.RadLabel15.Name = "RadLabel15"
        '
        '
        '
        Me.RadLabel15.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.Size = New System.Drawing.Size(404, 26)
        Me.RadLabel15.TabIndex = 457
        Me.RadLabel15.Text = "Local"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Location = New System.Drawing.Point(1, 7)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Size = New System.Drawing.Size(127, 26)
        Me.RadLabel16.TabIndex = 456
        Me.RadLabel16.Text = "Inventario de:"
        '
        'cbxTodos
        '
        Me.cbxTodos.AutoSize = True
        Me.cbxTodos.BackColor = System.Drawing.Color.Transparent
        Me.cbxTodos.ForeColor = System.Drawing.Color.Black
        Me.cbxTodos.Location = New System.Drawing.Point(4, 42)
        Me.cbxTodos.Name = "cbxTodos"
        Me.cbxTodos.Size = New System.Drawing.Size(155, 17)
        Me.cbxTodos.TabIndex = 457
        Me.cbxTodos.Text = "Ver Sucursales y Depositos"
        Me.cbxTodos.UseVisualStyleBackColor = False
        '
        'pnlNoHayStockNoRows
        '
        Me.pnlNoHayStockNoRows.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlNoHayStockNoRows.Controls.Add(Me.lblMensajeError)
        Me.pnlNoHayStockNoRows.Location = New System.Drawing.Point(233, 207)
        Me.pnlNoHayStockNoRows.Name = "pnlNoHayStockNoRows"
        Me.pnlNoHayStockNoRows.Size = New System.Drawing.Size(649, 135)
        Me.pnlNoHayStockNoRows.TabIndex = 457
        Me.pnlNoHayStockNoRows.Visible = False
        '
        'lblMensajeError
        '
        Me.lblMensajeError.AutoSize = True
        Me.lblMensajeError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMensajeError.Location = New System.Drawing.Point(240, 10)
        Me.lblMensajeError.Name = "lblMensajeError"
        Me.lblMensajeError.Size = New System.Drawing.Size(134, 20)
        Me.lblMensajeError.TabIndex = 0
        Me.lblMensajeError.Text = "lblMensajeError"
        Me.lblMensajeError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Tan
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.lblPagosEstado})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 580)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(940, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 472
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel1.IsLink = True
        Me.ToolStripStatusLabel1.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel1.Text = "Ayuda"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(780, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "F2 - Editar Stock  - Esto Actualizara el Stock a Ingresado como Real ,calculando " & _
    "Automaticamente el Ajuste"
        '
        'lblPagosEstado
        '
        Me.lblPagosEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblPagosEstado.ForeColor = System.Drawing.Color.Black
        Me.lblPagosEstado.Name = "lblPagosEstado"
        Me.lblPagosEstado.Size = New System.Drawing.Size(88, 17)
        Me.lblPagosEstado.Text = "Ajuste de Stock"
        '
        'STOCKAJUSTENVTableAdapter
        '
        Me.STOCKAJUSTENVTableAdapter.ClearBeforeFill = True
        '
        'dgwAjusteStock
        '
        Me.dgwAjusteStock.AllowUserToAddRows = False
        Me.dgwAjusteStock.AllowUserToDeleteRows = False
        Me.dgwAjusteStock.AllowUserToResizeColumns = False
        Me.dgwAjusteStock.AllowUserToResizeRows = False
        Me.dgwAjusteStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwAjusteStock.AutoGenerateColumns = False
        Me.dgwAjusteStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwAjusteStock.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwAjusteStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwAjusteStock.ColumnHeadersHeight = 35
        Me.dgwAjusteStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.PRODUCTODataGridViewTextBoxColumn, Me.StockActual, Me.CODDEPOSITODataGridViewTextBoxColumn, Me.CODCODIGODataGridViewTextBoxColumn, Me.StockReal, Me.Ajuste})
        Me.dgwAjusteStock.DataSource = Me.STOCKAJUSTENVBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 9.75!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwAjusteStock.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgwAjusteStock.GridColor = System.Drawing.Color.Gainsboro
        Me.dgwAjusteStock.Location = New System.Drawing.Point(189, 37)
        Me.dgwAjusteStock.Name = "dgwAjusteStock"
        Me.dgwAjusteStock.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.75!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwAjusteStock.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgwAjusteStock.RowHeadersVisible = False
        Me.dgwAjusteStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwAjusteStock.Size = New System.Drawing.Size(752, 501)
        Me.dgwAjusteStock.TabIndex = 473
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 60.0!
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigo"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODUCTODataGridViewTextBoxColumn
        '
        Me.PRODUCTODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTO"
        Me.PRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.PRODUCTODataGridViewTextBoxColumn.Name = "PRODUCTODataGridViewTextBoxColumn"
        Me.PRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'StockActual
        '
        Me.StockActual.DataPropertyName = "STOCKACTUAL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockActual.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockActual.FillWeight = 40.0!
        Me.StockActual.HeaderText = "Stock Actual"
        Me.StockActual.Name = "StockActual"
        Me.StockActual.ReadOnly = True
        '
        'CODDEPOSITODataGridViewTextBoxColumn
        '
        Me.CODDEPOSITODataGridViewTextBoxColumn.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.Name = "CODDEPOSITODataGridViewTextBoxColumn"
        Me.CODDEPOSITODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODDEPOSITODataGridViewTextBoxColumn.Visible = False
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCODIGODataGridViewTextBoxColumn.Visible = False
        '
        'StockReal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StockReal.DefaultCellStyle = DataGridViewCellStyle5
        Me.StockReal.FillWeight = 40.0!
        Me.StockReal.HeaderText = "Stock Real"
        Me.StockReal.Name = "StockReal"
        Me.StockReal.ReadOnly = True
        '
        'Ajuste
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Ajuste.DefaultCellStyle = DataGridViewCellStyle6
        Me.Ajuste.FillWeight = 40.0!
        Me.Ajuste.HeaderText = "Ajuste"
        Me.Ajuste.Name = "Ajuste"
        Me.Ajuste.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(201, 543)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(733, 30)
        Me.Label1.TabIndex = 474
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'AjusteStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(940, 602)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxTodos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pnlNoHayStockNoRows)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvSucursal)
        Me.Controls.Add(Me.dgwAjusteStock)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.KeyPreview = True
        Me.Name = "AjusteStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste de Stock  Automatico | Cogent SIG"
        CType(Me.STOCKAJUSTENVBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNoHayStockNoRows.ResumeLayout(False)
        Me.pnlNoHayStockNoRows.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgwAjusteStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvSucursal As System.Windows.Forms.DataGridView
    Friend WithEvents tbxBuscador As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNoHayStockNoRows As System.Windows.Forms.Panel
    Friend WithEvents lblMensajeError As System.Windows.Forms.Label
    Friend WithEvents DsInventario As ContaExpress.DsInventario
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter
    Friend WithEvents CODENCARGADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPagosEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents STOCKAJUSTENVBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents STOCKAJUSTENVTableAdapter As ContaExpress.DsInventarioTableAdapters.STOCKAJUSTENVTableAdapter
    Friend WithEvents dgwAjusteStock As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ajuste As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
