<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Stock))
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.CODDEPOSITO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKACTUAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKMINIMO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockActualBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInventario = New ContaExpress.DsInventario()
        Me.dgvSucursal = New System.Windows.Forms.DataGridView()
        Me.CODSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxBuscador = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnRefresh = New System.Windows.Forms.PictureBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxTodos = New System.Windows.Forms.CheckBox()
        Me.pnlNoHayStockNoRows = New System.Windows.Forms.Panel()
        Me.lblMensajeError = New System.Windows.Forms.Label()
        Me.StockActualTableAdapter = New ContaExpress.DsInventarioTableAdapters.StockActualTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblPagosEstado = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StockActualBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.btnRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNoHayStockNoRows.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToAddRows = False
        Me.dgvStock.AllowUserToDeleteRows = False
        Me.dgvStock.AllowUserToResizeRows = False
        Me.dgvStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStock.AutoGenerateColumns = False
        Me.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStock.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvStock.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvStock.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStock.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvStock.ColumnHeadersHeight = 35
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODDEPOSITO, Me.CODIGO, Me.DESPRODUCTO, Me.DESCODIGO1, Me.STOCKACTUAL, Me.STOCKMINIMO})
        Me.dgvStock.DataSource = Me.StockActualBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStock.GridColor = System.Drawing.Color.Silver
        Me.dgvStock.Location = New System.Drawing.Point(189, 37)
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.ReadOnly = True
        Me.dgvStock.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvStock.RowHeadersVisible = False
        Me.dgvStock.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvStock.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Gainsboro
        Me.dgvStock.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvStock.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dgvStock.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgvStock.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvStock.RowTemplate.DividerHeight = 1
        Me.dgvStock.RowTemplate.Height = 25
        Me.dgvStock.RowTemplate.ReadOnly = True
        Me.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStock.Size = New System.Drawing.Size(752, 543)
        Me.dgvStock.TabIndex = 2
        '
        'CODDEPOSITO
        '
        Me.CODDEPOSITO.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITO.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITO.Name = "CODDEPOSITO"
        Me.CODDEPOSITO.ReadOnly = True
        Me.CODDEPOSITO.Visible = False
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.FillWeight = 50.0!
        Me.CODIGO.HeaderText = "Codigo"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'DESPRODUCTO
        '
        Me.DESPRODUCTO.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTO.FillWeight = 140.0!
        Me.DESPRODUCTO.HeaderText = "Producto"
        Me.DESPRODUCTO.Name = "DESPRODUCTO"
        Me.DESPRODUCTO.ReadOnly = True
        '
        'DESCODIGO1
        '
        Me.DESCODIGO1.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1.FillWeight = 60.0!
        Me.DESCODIGO1.HeaderText = "Variante"
        Me.DESCODIGO1.Name = "DESCODIGO1"
        Me.DESCODIGO1.ReadOnly = True
        '
        'STOCKACTUAL
        '
        Me.STOCKACTUAL.DataPropertyName = "STOCKACTUAL"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N1"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.STOCKACTUAL.DefaultCellStyle = DataGridViewCellStyle2
        Me.STOCKACTUAL.FillWeight = 40.0!
        Me.STOCKACTUAL.HeaderText = "Stock"
        Me.STOCKACTUAL.Name = "STOCKACTUAL"
        Me.STOCKACTUAL.ReadOnly = True
        '
        'STOCKMINIMO
        '
        Me.STOCKMINIMO.DataPropertyName = "STOCKMINIMO"
        Me.STOCKMINIMO.HeaderText = "STOCKMINIMO"
        Me.STOCKMINIMO.Name = "STOCKMINIMO"
        Me.STOCKMINIMO.ReadOnly = True
        Me.STOCKMINIMO.Visible = False
        '
        'StockActualBindingSource
        '
        Me.StockActualBindingSource.DataMember = "StockActual"
        Me.StockActualBindingSource.DataSource = Me.DsInventario
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSucursal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSucursal.ColumnHeadersHeight = 35
        Me.dgvSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvSucursal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODSUCURSAL, Me.DESSUCURSAL, Me.TIPOSUCURSAL})
        Me.dgvSucursal.DataSource = Me.SUCURSALBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSucursal.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvSucursal.Location = New System.Drawing.Point(1, 57)
        Me.dgvSucursal.MultiSelect = False
        Me.dgvSucursal.Name = "dgvSucursal"
        Me.dgvSucursal.ReadOnly = True
        Me.dgvSucursal.RowHeadersVisible = False
        Me.dgvSucursal.RowHeadersWidth = 187
        Me.dgvSucursal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvSucursal.Size = New System.Drawing.Size(189, 523)
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
        Me.tbxBuscador.Location = New System.Drawing.Point(661, 6)
        Me.tbxBuscador.Name = "tbxBuscador"
        Me.tbxBuscador.Size = New System.Drawing.Size(238, 30)
        Me.tbxBuscador.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(632, 6)
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
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.RadLabel15)
        Me.Panel1.Controls.Add(Me.RadLabel16)
        Me.Panel1.Controls.Add(Me.tbxBuscador)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 40)
        Me.Panel1.TabIndex = 456
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.BackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.Image = Global.ContaExpress.My.Resources.Resources.Reload1
        Me.btnRefresh.Location = New System.Drawing.Point(903, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(35, 35)
        Me.btnRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnRefresh.TabIndex = 546
        Me.btnRefresh.TabStop = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.LinkColor = System.Drawing.Color.SaddleBrown
        Me.LinkLabel2.Location = New System.Drawing.Point(527, 22)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(99, 13)
        Me.LinkLabel2.TabIndex = 458
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Cargar Stock Inicial"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.LinkColor = System.Drawing.Color.SaddleBrown
        Me.LinkLabel1.Location = New System.Drawing.Point(543, 6)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(83, 13)
        Me.LinkLabel1.TabIndex = 458
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Crear Productos"
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
        Me.cbxTodos.Location = New System.Drawing.Point(2, 39)
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
        'StockActualTableAdapter
        '
        Me.StockActualTableAdapter.ClearBeforeFill = True
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
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(808, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "F4 - Refresh / F2 - Mostrar Total de Stock"
        '
        'lblPagosEstado
        '
        Me.lblPagosEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblPagosEstado.ForeColor = System.Drawing.Color.Black
        Me.lblPagosEstado.Name = "lblPagosEstado"
        Me.lblPagosEstado.Size = New System.Drawing.Size(60, 17)
        Me.lblPagosEstado.Text = "Inventario"
        '
        'Stock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.DarkGray
        Me.ClientSize = New System.Drawing.Size(940, 602)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pnlNoHayStockNoRows)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbxTodos)
        Me.Controls.Add(Me.dgvSucursal)
        Me.Controls.Add(Me.dgvStock)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.KeyPreview = True
        Me.Name = "Stock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventario  | Cogent SIG"
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StockActualBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNoHayStockNoRows.ResumeLayout(False)
        Me.pnlNoHayStockNoRows.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvStock As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSucursal As System.Windows.Forms.DataGridView
    Friend WithEvents tbxBuscador As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNoHayStockNoRows As System.Windows.Forms.Panel
    Friend WithEvents lblMensajeError As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents StockActualBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsInventario As ContaExpress.DsInventario
    Friend WithEvents StockActualTableAdapter As ContaExpress.DsInventarioTableAdapters.StockActualTableAdapter
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter
    Friend WithEvents CODENCARGADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRefresh As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPagosEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CODDEPOSITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKACTUAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKMINIMO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
