<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodigodeBarra
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodigodeBarra))
        Me.BuscaProductoTextBox = New System.Windows.Forms.TextBox()
        Me.dgwBalanzas = New System.Windows.Forms.DataGridView()
        Me.CODCODIGODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESABLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMFAMILIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMLINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridView = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOVENTADataGridView = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTODataGridView = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSALDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRECIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BALANZA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MarcarBalanza = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CodigoPesableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.dgwCodigos = New System.Windows.Forms.DataGridView()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRECIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BALANZADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodigodeBarraBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.RadThemeManager1 = New Telerik.WinControls.RadThemeManager()
        Me.pnlCodigo = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rptPers = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rpt13x5 = New System.Windows.Forms.RadioButton()
        Me.rpt7x3 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbtEmpresa = New System.Windows.Forms.RadioButton()
        Me.rbtPrecio = New System.Windows.Forms.RadioButton()
        Me.rdbCodigo = New System.Windows.Forms.RadioButton()
        Me.RadButtonImprimir = New System.Windows.Forms.Button()
        Me.ChckTodoCodigo = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlBalanza = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnExportaraBalanza = New System.Windows.Forms.Button()
        Me.chbxMarcarTodoBalanza = New System.Windows.Forms.CheckBox()
        Me.pnlTools = New System.Windows.Forms.Panel()
        Me.pbxBalanza = New System.Windows.Forms.PictureBox()
        Me.pbxCodigo = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CodigodeBarraTableAdapter = New ContaExpress.DsProductosTableAdapters.CodigodeBarraTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsProductosTableAdapters.TableAdapterManager()
        Me.CodigoPesableTableAdapter = New ContaExpress.DsProductosTableAdapters.CodigoPesableTableAdapter()
        CType(Me.dgwBalanzas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigoPesableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigodeBarraBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlBalanza.SuspendLayout()
        Me.pnlTools.SuspendLayout()
        CType(Me.pbxBalanza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BuscaProductoTextBox
        '
        Me.BuscaProductoTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscaProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscaProductoTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BuscaProductoTextBox.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscaProductoTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscaProductoTextBox.Location = New System.Drawing.Point(31, 5)
        Me.BuscaProductoTextBox.Name = "BuscaProductoTextBox"
        Me.BuscaProductoTextBox.Size = New System.Drawing.Size(339, 29)
        Me.BuscaProductoTextBox.TabIndex = 202
        '
        'dgwBalanzas
        '
        Me.dgwBalanzas.AllowUserToAddRows = False
        Me.dgwBalanzas.AllowUserToDeleteRows = False
        Me.dgwBalanzas.AllowUserToResizeRows = False
        Me.dgwBalanzas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwBalanzas.AutoGenerateColumns = False
        Me.dgwBalanzas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwBalanzas.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwBalanzas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwBalanzas.ColumnHeadersHeight = 35
        Me.dgwBalanzas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCODIGODataGridViewTextBoxColumn1, Me.PESABLE, Me.VENCIMIENTO, Me.NUMFAMILIA, Me.NUMLINEA, Me.CODPRODUCTO, Me.CODUSUARIODataGridViewTextBoxColumn1, Me.CODEMPRESADataGridViewTextBoxColumn1, Me.FECGRADataGridViewTextBoxColumn1, Me.CODIGODataGridView, Me.PRECIODataGridViewTextBoxColumn1, Me.DESPRODUCTODataGridViewTextBoxColumn1, Me.DESCODIGO1DataGridViewTextBoxColumn1, Me.CODTIPOCLIENTE, Me.PRECIOVENTADataGridView, Me.PRODUCTODataGridView, Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1, Me.CODSUCURSALDataGridViewTextBoxColumn1, Me.CODPRECIODataGridViewTextBoxColumn1, Me.CODMONEDADataGridViewTextBoxColumn1, Me.BALANZA, Me.MarcarBalanza})
        Me.dgwBalanzas.DataSource = Me.CodigoPesableBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwBalanzas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgwBalanzas.GridColor = System.Drawing.Color.DimGray
        Me.dgwBalanzas.Location = New System.Drawing.Point(5, 53)
        Me.dgwBalanzas.MultiSelect = False
        Me.dgwBalanzas.Name = "dgwBalanzas"
        Me.dgwBalanzas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwBalanzas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwBalanzas.RowHeadersVisible = False
        Me.dgwBalanzas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgwBalanzas.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgwBalanzas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwBalanzas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwBalanzas.Size = New System.Drawing.Size(851, 569)
        Me.dgwBalanzas.TabIndex = 423
        '
        'CODCODIGODataGridViewTextBoxColumn1
        '
        Me.CODCODIGODataGridViewTextBoxColumn1.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.Name = "CODCODIGODataGridViewTextBoxColumn1"
        Me.CODCODIGODataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODCODIGODataGridViewTextBoxColumn1.Visible = False
        '
        'PESABLE
        '
        Me.PESABLE.DataPropertyName = "PESABLE"
        Me.PESABLE.HeaderText = "PESABLE"
        Me.PESABLE.Name = "PESABLE"
        Me.PESABLE.Visible = False
        '
        'VENCIMIENTO
        '
        Me.VENCIMIENTO.DataPropertyName = "VENCIMIENTO"
        Me.VENCIMIENTO.HeaderText = "VENCIMIENTO"
        Me.VENCIMIENTO.Name = "VENCIMIENTO"
        Me.VENCIMIENTO.Visible = False
        '
        'NUMFAMILIA
        '
        Me.NUMFAMILIA.DataPropertyName = "NUMFAMILIA"
        Me.NUMFAMILIA.HeaderText = "NUMFAMILIA"
        Me.NUMFAMILIA.Name = "NUMFAMILIA"
        Me.NUMFAMILIA.Visible = False
        '
        'NUMLINEA
        '
        Me.NUMLINEA.DataPropertyName = "NUMLINEA"
        Me.NUMLINEA.HeaderText = "NUMLINEA"
        Me.NUMLINEA.Name = "NUMLINEA"
        Me.NUMLINEA.Visible = False
        '
        'CODPRODUCTO
        '
        Me.CODPRODUCTO.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTO.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTO.Name = "CODPRODUCTO"
        Me.CODPRODUCTO.ReadOnly = True
        Me.CODPRODUCTO.Visible = False
        '
        'CODUSUARIODataGridViewTextBoxColumn1
        '
        Me.CODUSUARIODataGridViewTextBoxColumn1.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn1.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn1.Name = "CODUSUARIODataGridViewTextBoxColumn1"
        Me.CODUSUARIODataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn1.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn1
        '
        Me.CODEMPRESADataGridViewTextBoxColumn1.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn1.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn1.Name = "CODEMPRESADataGridViewTextBoxColumn1"
        Me.CODEMPRESADataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn1.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn1
        '
        Me.FECGRADataGridViewTextBoxColumn1.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.Name = "FECGRADataGridViewTextBoxColumn1"
        Me.FECGRADataGridViewTextBoxColumn1.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn1.Visible = False
        '
        'CODIGODataGridView
        '
        Me.CODIGODataGridView.DataPropertyName = "CODIGO"
        Me.CODIGODataGridView.HeaderText = "Código"
        Me.CODIGODataGridView.Name = "CODIGODataGridView"
        Me.CODIGODataGridView.ReadOnly = True
        '
        'PRECIODataGridViewTextBoxColumn1
        '
        Me.PRECIODataGridViewTextBoxColumn1.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn1.HeaderText = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn1.Name = "PRECIODataGridViewTextBoxColumn1"
        Me.PRECIODataGridViewTextBoxColumn1.ReadOnly = True
        Me.PRECIODataGridViewTextBoxColumn1.Visible = False
        '
        'DESPRODUCTODataGridViewTextBoxColumn1
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.Name = "DESPRODUCTODataGridViewTextBoxColumn1"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DESCODIGO1DataGridViewTextBoxColumn1
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn1.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1DataGridViewTextBoxColumn1.HeaderText = "Variante"
        Me.DESCODIGO1DataGridViewTextBoxColumn1.Name = "DESCODIGO1DataGridViewTextBoxColumn1"
        Me.DESCODIGO1DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CODTIPOCLIENTE
        '
        Me.CODTIPOCLIENTE.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.Name = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.ReadOnly = True
        Me.CODTIPOCLIENTE.Visible = False
        '
        'PRECIOVENTADataGridView
        '
        Me.PRECIOVENTADataGridView.DataPropertyName = "PRECIOVENTA"
        Me.PRECIOVENTADataGridView.HeaderText = "Precio"
        Me.PRECIOVENTADataGridView.Name = "PRECIOVENTADataGridView"
        Me.PRECIOVENTADataGridView.ReadOnly = True
        '
        'PRODUCTODataGridView
        '
        Me.PRODUCTODataGridView.DataPropertyName = "PRODUCTO"
        Me.PRODUCTODataGridView.HeaderText = "PRODUCTO"
        Me.PRODUCTODataGridView.Name = "PRODUCTODataGridView"
        Me.PRODUCTODataGridView.ReadOnly = True
        Me.PRODUCTODataGridView.Visible = False
        '
        'DESTIPOCLIENTEDataGridViewTextBoxColumn1
        '
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1.DataPropertyName = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1.HeaderText = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1.Name = "DESTIPOCLIENTEDataGridViewTextBoxColumn1"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1.ReadOnly = True
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn1.Visible = False
        '
        'CODSUCURSALDataGridViewTextBoxColumn1
        '
        Me.CODSUCURSALDataGridViewTextBoxColumn1.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn1.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn1.Name = "CODSUCURSALDataGridViewTextBoxColumn1"
        Me.CODSUCURSALDataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODSUCURSALDataGridViewTextBoxColumn1.Visible = False
        '
        'CODPRECIODataGridViewTextBoxColumn1
        '
        Me.CODPRECIODataGridViewTextBoxColumn1.DataPropertyName = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn1.HeaderText = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn1.Name = "CODPRECIODataGridViewTextBoxColumn1"
        Me.CODPRECIODataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODPRECIODataGridViewTextBoxColumn1.Visible = False
        '
        'CODMONEDADataGridViewTextBoxColumn1
        '
        Me.CODMONEDADataGridViewTextBoxColumn1.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn1.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn1.Name = "CODMONEDADataGridViewTextBoxColumn1"
        Me.CODMONEDADataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODMONEDADataGridViewTextBoxColumn1.Visible = False
        '
        'BALANZA
        '
        Me.BALANZA.DataPropertyName = "BALANZA"
        Me.BALANZA.HeaderText = "BALANZA"
        Me.BALANZA.Name = "BALANZA"
        Me.BALANZA.ReadOnly = True
        Me.BALANZA.Visible = False
        '
        'MarcarBalanza
        '
        Me.MarcarBalanza.HeaderText = "Marcar"
        Me.MarcarBalanza.Name = "MarcarBalanza"
        '
        'CodigoPesableBindingSource
        '
        Me.CodigoPesableBindingSource.DataMember = "CodigoPesable"
        Me.CodigoPesableBindingSource.DataSource = Me.DsProductos
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgwCodigos
        '
        Me.dgwCodigos.AllowUserToAddRows = False
        Me.dgwCodigos.AllowUserToDeleteRows = False
        Me.dgwCodigos.AllowUserToResizeRows = False
        Me.dgwCodigos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwCodigos.AutoGenerateColumns = False
        Me.dgwCodigos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwCodigos.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.75!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwCodigos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgwCodigos.ColumnHeadersHeight = 35
        Me.dgwCodigos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGO, Me.CODCODIGODataGridViewTextBoxColumn, Me.CODPRODUCTODataGridViewTextBoxColumn, Me.DESCODIGO2DataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn, Me.CODIGODataGridViewTextBoxColumn, Me.PRECIODataGridViewTextBoxColumn, Me.CODMONEDADataGridViewTextBoxColumn, Me.Producto, Me.DESCODIGO1DataGridViewTextBoxColumn, Me.CODTIPOCLIENTEDataGridViewTextBoxColumn, Me.PRECIOVENTA, Me.PRODUCTODataGridViewTextBoxColumn, Me.DESTIPOCLIENTEDataGridViewTextBoxColumn, Me.CODSUCURSALDataGridViewTextBoxColumn, Me.CODPRECIODataGridViewTextBoxColumn, Me.BALANZADataGridViewTextBoxColumn, Me.Marcar, Me.Cantidad})
        Me.dgwCodigos.DataSource = Me.CodigodeBarraBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwCodigos.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgwCodigos.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwCodigos.Location = New System.Drawing.Point(-1, 76)
        Me.dgwCodigos.Name = "dgwCodigos"
        Me.dgwCodigos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwCodigos.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgwCodigos.RowHeadersVisible = False
        Me.dgwCodigos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgwCodigos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwCodigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwCodigos.Size = New System.Drawing.Size(862, 546)
        Me.dgwCodigos.TabIndex = 423
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "Código"
        Me.CODIGO.Name = "CODIGO"
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.Visible = False
        '
        'CODPRODUCTODataGridViewTextBoxColumn
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Name = "CODPRODUCTODataGridViewTextBoxColumn"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Visible = False
        '
        'DESCODIGO2DataGridViewTextBoxColumn
        '
        Me.DESCODIGO2DataGridViewTextBoxColumn.DataPropertyName = "DESCODIGO2"
        Me.DESCODIGO2DataGridViewTextBoxColumn.HeaderText = "DESCODIGO2"
        Me.DESCODIGO2DataGridViewTextBoxColumn.Name = "DESCODIGO2DataGridViewTextBoxColumn"
        Me.DESCODIGO2DataGridViewTextBoxColumn.Visible = False
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        Me.CODUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn
        '
        Me.CODEMPRESADataGridViewTextBoxColumn.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.Name = "CODEMPRESADataGridViewTextBoxColumn"
        Me.CODEMPRESADataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.Visible = False
        '
        'PRECIODataGridViewTextBoxColumn
        '
        Me.PRECIODataGridViewTextBoxColumn.DataPropertyName = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.HeaderText = "PRECIO"
        Me.PRECIODataGridViewTextBoxColumn.Name = "PRECIODataGridViewTextBoxColumn"
        Me.PRECIODataGridViewTextBoxColumn.Visible = False
        '
        'CODMONEDADataGridViewTextBoxColumn
        '
        Me.CODMONEDADataGridViewTextBoxColumn.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.Name = "CODMONEDADataGridViewTextBoxColumn"
        Me.CODMONEDADataGridViewTextBoxColumn.Visible = False
        '
        'Producto
        '
        Me.Producto.DataPropertyName = "PRODUCTO"
        Me.Producto.FillWeight = 160.0!
        Me.Producto.HeaderText = "Producto"
        Me.Producto.Name = "Producto"
        Me.Producto.ReadOnly = True
        '
        'DESCODIGO1DataGridViewTextBoxColumn
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1DataGridViewTextBoxColumn.HeaderText = "Variante"
        Me.DESCODIGO1DataGridViewTextBoxColumn.Name = "DESCODIGO1DataGridViewTextBoxColumn"
        '
        'CODTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Name = "CODTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'PRECIOVENTA
        '
        Me.PRECIOVENTA.DataPropertyName = "PRECIOVENTA"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.PRECIOVENTA.DefaultCellStyle = DataGridViewCellStyle6
        Me.PRECIOVENTA.FillWeight = 70.0!
        Me.PRECIOVENTA.HeaderText = "Precio"
        Me.PRECIOVENTA.Name = "PRECIOVENTA"
        '
        'PRODUCTODataGridViewTextBoxColumn
        '
        Me.PRODUCTODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTO"
        Me.PRODUCTODataGridViewTextBoxColumn.HeaderText = "PRODUCTO"
        Me.PRODUCTODataGridViewTextBoxColumn.Name = "PRODUCTODataGridViewTextBoxColumn"
        Me.PRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.PRODUCTODataGridViewTextBoxColumn.Visible = False
        '
        'DESTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.Name = "DESTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CODSUCURSALDataGridViewTextBoxColumn
        '
        Me.CODSUCURSALDataGridViewTextBoxColumn.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.Name = "CODSUCURSALDataGridViewTextBoxColumn"
        Me.CODSUCURSALDataGridViewTextBoxColumn.Visible = False
        '
        'CODPRECIODataGridViewTextBoxColumn
        '
        Me.CODPRECIODataGridViewTextBoxColumn.DataPropertyName = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn.HeaderText = "CODPRECIO"
        Me.CODPRECIODataGridViewTextBoxColumn.Name = "CODPRECIODataGridViewTextBoxColumn"
        Me.CODPRECIODataGridViewTextBoxColumn.Visible = False
        '
        'BALANZADataGridViewTextBoxColumn
        '
        Me.BALANZADataGridViewTextBoxColumn.DataPropertyName = "BALANZA"
        Me.BALANZADataGridViewTextBoxColumn.HeaderText = "BALANZA"
        Me.BALANZADataGridViewTextBoxColumn.Name = "BALANZADataGridViewTextBoxColumn"
        Me.BALANZADataGridViewTextBoxColumn.Visible = False
        '
        'Marcar
        '
        Me.Marcar.FillWeight = 60.0!
        Me.Marcar.HeaderText = "Marcar"
        Me.Marcar.Name = "Marcar"
        '
        'Cantidad
        '
        Me.Cantidad.FillWeight = 60.0!
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        '
        'CodigodeBarraBindingSource
        '
        Me.CodigodeBarraBindingSource.DataMember = "CodigodeBarra"
        Me.CodigodeBarraBindingSource.DataSource = Me.DsProductos
        '
        'pnlCodigo
        '
        Me.pnlCodigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCodigo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlCodigo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlCodigo.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCodigo.Controls.Add(Me.Panel2)
        Me.pnlCodigo.Controls.Add(Me.Panel1)
        Me.pnlCodigo.Controls.Add(Me.rdbCodigo)
        Me.pnlCodigo.Controls.Add(Me.RadButtonImprimir)
        Me.pnlCodigo.Controls.Add(Me.ChckTodoCodigo)
        Me.pnlCodigo.Controls.Add(Me.Label1)
        Me.pnlCodigo.Controls.Add(Me.dgwCodigos)
        Me.pnlCodigo.Location = New System.Drawing.Point(0, 39)
        Me.pnlCodigo.Name = "pnlCodigo"
        Me.pnlCodigo.Size = New System.Drawing.Size(862, 625)
        Me.pnlCodigo.TabIndex = 205
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rptPers)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.rpt13x5)
        Me.Panel2.Controls.Add(Me.rpt7x3)
        Me.Panel2.Location = New System.Drawing.Point(573, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(133, 66)
        Me.Panel2.TabIndex = 432
        '
        'rptPers
        '
        Me.rptPers.AutoSize = True
        Me.rptPers.BackColor = System.Drawing.Color.Transparent
        Me.rptPers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rptPers.ForeColor = System.Drawing.Color.Black
        Me.rptPers.Location = New System.Drawing.Point(70, 45)
        Me.rptPers.Name = "rptPers"
        Me.rptPers.Size = New System.Drawing.Size(57, 20)
        Me.rptPers.TabIndex = 433
        Me.rptPers.TabStop = True
        Me.rptPers.Text = "Pers."
        Me.rptPers.UseVisualStyleBackColor = False
        Me.rptPers.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 432
        Me.Label4.Text = "Formato:"
        '
        'rpt13x5
        '
        Me.rpt13x5.AutoSize = True
        Me.rpt13x5.BackColor = System.Drawing.Color.Transparent
        Me.rpt13x5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt13x5.ForeColor = System.Drawing.Color.Black
        Me.rpt13x5.Location = New System.Drawing.Point(70, 5)
        Me.rpt13x5.Name = "rpt13x5"
        Me.rpt13x5.Size = New System.Drawing.Size(59, 20)
        Me.rpt13x5.TabIndex = 426
        Me.rpt13x5.TabStop = True
        Me.rpt13x5.Text = "13 x 5"
        Me.rpt13x5.UseVisualStyleBackColor = False
        '
        'rpt7x3
        '
        Me.rpt7x3.AutoSize = True
        Me.rpt7x3.BackColor = System.Drawing.Color.Transparent
        Me.rpt7x3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rpt7x3.ForeColor = System.Drawing.Color.Black
        Me.rpt7x3.Location = New System.Drawing.Point(70, 25)
        Me.rpt7x3.Name = "rpt7x3"
        Me.rpt7x3.Size = New System.Drawing.Size(52, 20)
        Me.rpt7x3.TabIndex = 426
        Me.rpt7x3.TabStop = True
        Me.rpt7x3.Text = "7 x 3"
        Me.rpt7x3.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.rbtEmpresa)
        Me.Panel1.Controls.Add(Me.rbtPrecio)
        Me.Panel1.Location = New System.Drawing.Point(363, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(193, 47)
        Me.Panel1.TabIndex = 431
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "Mostrar Datos:"
        '
        'rbtEmpresa
        '
        Me.rbtEmpresa.AutoSize = True
        Me.rbtEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtEmpresa.Location = New System.Drawing.Point(104, 24)
        Me.rbtEmpresa.Name = "rbtEmpresa"
        Me.rbtEmpresa.Size = New System.Drawing.Size(81, 20)
        Me.rbtEmpresa.TabIndex = 429
        Me.rbtEmpresa.TabStop = True
        Me.rbtEmpresa.Text = "Empresa"
        Me.rbtEmpresa.UseVisualStyleBackColor = True
        '
        'rbtPrecio
        '
        Me.rbtPrecio.AutoSize = True
        Me.rbtPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtPrecio.Location = New System.Drawing.Point(104, 5)
        Me.rbtPrecio.Name = "rbtPrecio"
        Me.rbtPrecio.Size = New System.Drawing.Size(65, 20)
        Me.rbtPrecio.TabIndex = 430
        Me.rbtPrecio.TabStop = True
        Me.rbtPrecio.Text = "Precio"
        Me.rbtPrecio.UseVisualStyleBackColor = True
        '
        'rdbCodigo
        '
        Me.rdbCodigo.AutoSize = True
        Me.rdbCodigo.BackColor = System.Drawing.Color.Transparent
        Me.rdbCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbCodigo.ForeColor = System.Drawing.Color.Black
        Me.rdbCodigo.Location = New System.Drawing.Point(147, 27)
        Me.rdbCodigo.Name = "rdbCodigo"
        Me.rdbCodigo.Size = New System.Drawing.Size(210, 20)
        Me.rdbCodigo.TabIndex = 428
        Me.rdbCodigo.TabStop = True
        Me.rdbCodigo.Text = "Formato Zebra (29mm x 62mm)"
        Me.rdbCodigo.UseVisualStyleBackColor = False
        Me.rdbCodigo.Visible = False
        '
        'RadButtonImprimir
        '
        Me.RadButtonImprimir.BackColor = System.Drawing.Color.DodgerBlue
        Me.RadButtonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RadButtonImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadButtonImprimir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RadButtonImprimir.Location = New System.Drawing.Point(716, 7)
        Me.RadButtonImprimir.Name = "RadButtonImprimir"
        Me.RadButtonImprimir.Size = New System.Drawing.Size(141, 41)
        Me.RadButtonImprimir.TabIndex = 425
        Me.RadButtonImprimir.Text = "Imprimir"
        Me.RadButtonImprimir.UseVisualStyleBackColor = False
        '
        'ChckTodoCodigo
        '
        Me.ChckTodoCodigo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChckTodoCodigo.BackColor = System.Drawing.Color.Transparent
        Me.ChckTodoCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChckTodoCodigo.ForeColor = System.Drawing.Color.Black
        Me.ChckTodoCodigo.Location = New System.Drawing.Point(5, 30)
        Me.ChckTodoCodigo.Name = "ChckTodoCodigo"
        Me.ChckTodoCodigo.Size = New System.Drawing.Size(127, 20)
        Me.ChckTodoCodigo.TabIndex = 208
        Me.ChckTodoCodigo.Text = "Marcar Todos"
        Me.ChckTodoCodigo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 28)
        Me.Label1.TabIndex = 427
        Me.Label1.Text = "Imprimir Codigos de Barra"
        '
        'pnlBalanza
        '
        Me.pnlBalanza.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBalanza.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBalanza.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBalanza.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlBalanza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBalanza.Controls.Add(Me.Label2)
        Me.pnlBalanza.Controls.Add(Me.BtnExportaraBalanza)
        Me.pnlBalanza.Controls.Add(Me.dgwBalanzas)
        Me.pnlBalanza.Controls.Add(Me.chbxMarcarTodoBalanza)
        Me.pnlBalanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBalanza.Location = New System.Drawing.Point(0, 39)
        Me.pnlBalanza.Name = "pnlBalanza"
        Me.pnlBalanza.Size = New System.Drawing.Size(862, 627)
        Me.pnlBalanza.TabIndex = 205
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(281, 28)
        Me.Label2.TabIndex = 428
        Me.Label2.Text = "Generar Codigos p/ Balanzas"
        '
        'BtnExportaraBalanza
        '
        Me.BtnExportaraBalanza.BackColor = System.Drawing.Color.DodgerBlue
        Me.BtnExportaraBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExportaraBalanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExportaraBalanza.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnExportaraBalanza.Location = New System.Drawing.Point(655, 6)
        Me.BtnExportaraBalanza.Name = "BtnExportaraBalanza"
        Me.BtnExportaraBalanza.Size = New System.Drawing.Size(202, 41)
        Me.BtnExportaraBalanza.TabIndex = 424
        Me.BtnExportaraBalanza.Text = "Exportar p/ Balanza"
        Me.BtnExportaraBalanza.UseVisualStyleBackColor = False
        '
        'chbxMarcarTodoBalanza
        '
        Me.chbxMarcarTodoBalanza.AutoSize = True
        Me.chbxMarcarTodoBalanza.BackColor = System.Drawing.Color.Transparent
        Me.chbxMarcarTodoBalanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxMarcarTodoBalanza.ForeColor = System.Drawing.Color.Black
        Me.chbxMarcarTodoBalanza.Location = New System.Drawing.Point(4, 30)
        Me.chbxMarcarTodoBalanza.Name = "chbxMarcarTodoBalanza"
        Me.chbxMarcarTodoBalanza.Size = New System.Drawing.Size(112, 20)
        Me.chbxMarcarTodoBalanza.TabIndex = 425
        Me.chbxMarcarTodoBalanza.Text = "Marcar Todos"
        Me.chbxMarcarTodoBalanza.UseVisualStyleBackColor = False
        '
        'pnlTools
        '
        Me.pnlTools.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlTools.BackColor = System.Drawing.Color.Tan
        Me.pnlTools.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.pnlTools.Controls.Add(Me.pbxBalanza)
        Me.pnlTools.Controls.Add(Me.pbxCodigo)
        Me.pnlTools.Controls.Add(Me.PictureBox1)
        Me.pnlTools.Controls.Add(Me.BuscaProductoTextBox)
        Me.pnlTools.Location = New System.Drawing.Point(1, 0)
        Me.pnlTools.Name = "pnlTools"
        Me.pnlTools.Size = New System.Drawing.Size(867, 40)
        Me.pnlTools.TabIndex = 215
        '
        'pbxBalanza
        '
        Me.pbxBalanza.BackColor = System.Drawing.Color.Transparent
        Me.pbxBalanza.Image = Global.ContaExpress.My.Resources.Resources.Weight
        Me.pbxBalanza.Location = New System.Drawing.Point(820, 3)
        Me.pbxBalanza.Name = "pbxBalanza"
        Me.pbxBalanza.Size = New System.Drawing.Size(35, 35)
        Me.pbxBalanza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxBalanza.TabIndex = 461
        Me.pbxBalanza.TabStop = False
        '
        'pbxCodigo
        '
        Me.pbxCodigo.BackColor = System.Drawing.Color.Transparent
        Me.pbxCodigo.Image = Global.ContaExpress.My.Resources.Resources.BarcodeActive
        Me.pbxCodigo.Location = New System.Drawing.Point(783, 3)
        Me.pbxCodigo.Name = "pbxCodigo"
        Me.pbxCodigo.Size = New System.Drawing.Size(35, 35)
        Me.pbxCodigo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCodigo.TabIndex = 461
        Me.pbxCodigo.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(3, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 29)
        Me.PictureBox1.TabIndex = 459
        Me.PictureBox1.TabStop = False
        '
        'CodigodeBarraTableAdapter
        '
        Me.CodigodeBarraTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.FAMILIATableAdapter = Nothing
        Me.TableAdapterManager.IVATableAdapter = Nothing
        Me.TableAdapterManager.LINEATableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PRODUCTOEQUIPOTableAdapter = Nothing
        Me.TableAdapterManager.PRODUCTOMARCATableAdapter = Nothing
        Me.TableAdapterManager.PROVEEDORTableAdapter = Nothing
        Me.TableAdapterManager.RUBROTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCLIENTETableAdapter = Nothing
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProductosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CodigoPesableTableAdapter
        '
        Me.CodigoPesableTableAdapter.ClearBeforeFill = True
        '
        'CodigodeBarra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(862, 662)
        Me.Controls.Add(Me.pnlTools)
        Me.Controls.Add(Me.pnlCodigo)
        Me.Controls.Add(Me.pnlBalanza)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CodigodeBarra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Codigo de Barra | Cogent SIG"
        CType(Me.dgwBalanzas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigoPesableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigodeBarraBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigo.ResumeLayout(False)
        Me.pnlCodigo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlBalanza.ResumeLayout(False)
        Me.pnlBalanza.PerformLayout()
        Me.pnlTools.ResumeLayout(False)
        Me.pnlTools.PerformLayout()
        CType(Me.pbxBalanza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents CodigodeBarraBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CodigodeBarraTableAdapter As ContaExpress.DsProductosTableAdapters.CodigodeBarraTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsProductosTableAdapters.TableAdapterManager
    Friend WithEvents BuscaProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RadThemeManager1 As Telerik.WinControls.RadThemeManager
    Friend WithEvents dgwCodigos As System.Windows.Forms.DataGridView
    Friend WithEvents dgwBalanzas As System.Windows.Forms.DataGridView
    Friend WithEvents CodigoPesableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CodigoPesableTableAdapter As ContaExpress.DsProductosTableAdapters.CodigoPesableTableAdapter
    Friend WithEvents pnlCodigo As System.Windows.Forms.Panel
    Friend WithEvents pnlBalanza As System.Windows.Forms.Panel
    Friend WithEvents pnlTools As System.Windows.Forms.Panel
    Friend WithEvents BtnExportaraBalanza As System.Windows.Forms.Button
    Friend WithEvents RadButtonImprimir As System.Windows.Forms.Button
    Friend WithEvents ChckTodoCodigo As System.Windows.Forms.CheckBox
    Friend WithEvents chbxMarcarTodoBalanza As System.Windows.Forms.CheckBox
    Friend WithEvents rpt7x3 As System.Windows.Forms.RadioButton
    Friend WithEvents rpt13x5 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESABLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMFAMILIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMLINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO2DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOVENTADataGridView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTODataGridView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCLIENTEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRECIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BALANZA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarcarBalanza As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pbxBalanza As System.Windows.Forms.PictureBox
    Friend WithEvents pbxCodigo As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbtEmpresa As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPrecio As System.Windows.Forms.RadioButton
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRECIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BALANZADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rptPers As System.Windows.Forms.RadioButton
End Class
