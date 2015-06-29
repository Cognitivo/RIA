<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroReporteProduccion
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroReporteProduccion))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.btnFiltros = New System.Windows.Forms.Button()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.CODPRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOSBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProducccionInforme = New ContaExpress.DsProducccionInforme()
        Me.TabBuscador = New Telerik.WinControls.UI.RadTabStrip()
        Me.BuscarProductoTextBox = New System.Windows.Forms.TextBox()
        Me.Producto = New Telerik.WinControls.UI.TabItem()
        Me.Remision = New Telerik.WinControls.UI.TabItem()
        Me.RadGridViewDetalleRemisiones = New Telerik.WinControls.UI.RadGridView()
        Me.dgvListaReportes = New System.Windows.Forms.DataGridView()
        Me.TITULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALABRASCLAVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.panelTipoProd = New System.Windows.Forms.Panel()
        Me.cbxFiltroTipoProd = New System.Windows.Forms.ComboBox()
        Me.TIPOPRODUCCIONBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOrdProduccion = New ContaExpress.dsOrdProduccion()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbxNuevaVent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pbxCerrarFiltros = New System.Windows.Forms.PictureBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlOtrasOpciones = New System.Windows.Forms.Panel()
        Me.rbtSalida = New System.Windows.Forms.RadioButton()
        Me.rbtEntrada = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlAgrupado = New System.Windows.Forms.Panel()
        Me.rbtAPorA = New System.Windows.Forms.RadioButton()
        Me.rbtAPorD = New System.Windows.Forms.RadioButton()
        Me.rbtAPorM = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlOrdenProd = New System.Windows.Forms.Panel()
        Me.cbxOrdenProd = New System.Windows.Forms.ComboBox()
        Me.ORDENPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlCategorias = New System.Windows.Forms.Panel()
        Me.cbxRubro = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxCategoria = New System.Windows.Forms.ComboBox()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxLinea = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.pnlTipoProd = New System.Windows.Forms.Panel()
        Me.cbxTipoProd = New System.Windows.Forms.ComboBox()
        Me.TIPOPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProducccionInformeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pbxRangoProd = New System.Windows.Forms.PictureBox()
        Me.lblPos5 = New System.Windows.Forms.Label()
        Me.chbxCodProducto = New System.Windows.Forms.CheckBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.BtnAsteriscoProducto = New System.Windows.Forms.PictureBox()
        Me.tbxcodProd = New System.Windows.Forms.TextBox()
        Me.pnlfechas = New System.Windows.Forms.Panel()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VProduccionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VProduccionTableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.VProduccionTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.PRODUCTOSTableAdapter()
        Me.VProduccionComparativoTableAdapter1 = New ContaExpress.DsProducccionInformeTableAdapters.VProduccionComparativoTableAdapter()
        Me.FAMILIATableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.FAMILIATableAdapter()
        Me.VProduccionComparativoEntradaTableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.VProduccionComparativoEntradaTableAdapter()
        Me.ORDENPRODUCCIONTableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.ORDENPRODUCCIONTableAdapter()
        Me.TIPOPRODUCCIONTableAdapter = New ContaExpress.DsProducccionInformeTableAdapters.TIPOPRODUCCIONTableAdapter()
        Me.DsProdInforme = New ContaExpress.dsProdInforme()
        Me.PLANILLAPRODUCCIONCOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PLANILLAPRODUCCIONCOSTOTableAdapter = New ContaExpress.dsProdInformeTableAdapters.PLANILLAPRODUCCIONCOSTOTableAdapter()
        Me.ORDENPRODUCCIONCOSTOTOTALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ORDENPRODUCCIONCOSTOTOTALTableAdapter = New ContaExpress.dsProdInformeTableAdapters.ORDENPRODUCCIONCOSTOTOTALTableAdapter()
        Me.IMPPRODUCTOTERMBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMPPRODUCTOTERMTableAdapter = New ContaExpress.dsOrdProduccionTableAdapters.IMPPRODUCTOTERMTableAdapter()
        Me.IMPMATERIAPRIMABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMPMATERIAPRIMATableAdapter = New ContaExpress.dsOrdProduccionTableAdapters.IMPMATERIAPRIMATableAdapter()
        Me.TIPOPRODUCCIONTableAdapter1 = New ContaExpress.dsOrdProduccionTableAdapters.TIPOPRODUCCIONTableAdapter()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProducccionInforme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Remision.ContentPanel.SuspendLayout()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.panelTipoProd.SuspendLayout()
        CType(Me.TIPOPRODUCCIONBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrdProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSinFiltro.SuspendLayout()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrasOpciones.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlAgrupado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlOrdenProd.SuspendLayout()
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorias.SuspendLayout()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducto.SuspendLayout()
        Me.pnlTipoProd.SuspendLayout()
        CType(Me.TIPOPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProducccionInformeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlfechas.SuspendLayout()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VProduccionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProdInforme, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLANILLAPRODUCCIONCOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORDENPRODUCCIONCOSTOTOTALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPPRODUCTOTERMBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPMATERIAPRIMABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(265, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Filtros para:"
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblReporte.Location = New System.Drawing.Point(368, 1)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(106, 28)
        Me.lblReporte.TabIndex = 4
        Me.lblReporte.Text = "lblReporte"
        '
        'lblReporteDescrip
        '
        Me.lblReporteDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteDescrip.ForeColor = System.Drawing.Color.DarkGray
        Me.lblReporteDescrip.Location = New System.Drawing.Point(267, 28)
        Me.lblReporteDescrip.Name = "lblReporteDescrip"
        Me.lblReporteDescrip.Size = New System.Drawing.Size(740, 21)
        Me.lblReporteDescrip.TabIndex = 9
        Me.lblReporteDescrip.Text = "lblReporteDescrip"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Tan
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBig
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(4, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.TabIndex = 460
        Me.PictureBox2.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(32, 7)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(228, 30)
        Me.BuscarTextBox.TabIndex = 459
        '
        'btnFiltros
        '
        Me.btnFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFiltros.BackColor = System.Drawing.Color.DarkOrange
        Me.btnFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltros.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnFiltros.Location = New System.Drawing.Point(977, 7)
        Me.btnFiltros.Name = "btnFiltros"
        Me.btnFiltros.Size = New System.Drawing.Size(102, 30)
        Me.btnFiltros.TabIndex = 487
        Me.btnFiltros.Text = "Filtros"
        Me.btnFiltros.UseVisualStyleBackColor = False
        '
        'ProductosGroupBox
        '
        Me.ProductosGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductosGroupBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ProductosGroupBox.Controls.Add(Me.ProductosGridView)
        Me.ProductosGroupBox.Controls.Add(Me.TabBuscador)
        Me.ProductosGroupBox.Controls.Add(Me.BuscarProductoTextBox)
        Me.ProductosGroupBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductosGroupBox.FooterImageIndex = -1
        Me.ProductosGroupBox.FooterImageKey = ""
        Me.ProductosGroupBox.HeaderImageIndex = -1
        Me.ProductosGroupBox.HeaderImageKey = ""
        Me.ProductosGroupBox.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.HeaderText = "Búsqueda de Productos"
        Me.ProductosGroupBox.Location = New System.Drawing.Point(68, 51)
        Me.ProductosGroupBox.Name = "ProductosGroupBox"
        Me.ProductosGroupBox.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.ProductosGroupBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.ProductosGroupBox.RootElement.AngleTransform = 0.0!
        Me.ProductosGroupBox.RootElement.FlipText = False
        Me.ProductosGroupBox.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.ProductosGroupBox.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.ProductosGroupBox.RootElement.Text = Nothing
        Me.ProductosGroupBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.ProductosGroupBox.Size = New System.Drawing.Size(568, 529)
        Me.ProductosGroupBox.TabIndex = 489
        Me.ProductosGroupBox.Text = "Búsqueda de Productos"
        Me.ProductosGroupBox.Visible = False
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = "Búsqueda de Productos"
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductosGridView
        '
        Me.ProductosGridView.AllowUserToAddRows = False
        Me.ProductosGridView.AllowUserToDeleteRows = False
        Me.ProductosGridView.AutoGenerateColumns = False
        Me.ProductosGridView.ColumnHeadersHeight = 30
        Me.ProductosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODUCTODataGridViewTextBoxColumn1, Me.DESPRODUCTODataGridViewTextBoxColumn})
        Me.ProductosGridView.DataSource = Me.PRODUCTOSBindingSource1
        Me.ProductosGridView.Location = New System.Drawing.Point(10, 55)
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.ReadOnly = True
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.Size = New System.Drawing.Size(548, 461)
        Me.ProductosGridView.TabIndex = 378
        '
        'CODPRODUCTODataGridViewTextBoxColumn1
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "CODIGO"
        Me.CODPRODUCTODataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.CODPRODUCTODataGridViewTextBoxColumn1.Name = "CODPRODUCTODataGridViewTextBoxColumn1"
        Me.CODPRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODPRODUCTODataGridViewTextBoxColumn1.Width = 150
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODUCTODataGridViewTextBoxColumn.Width = 400
        '
        'PRODUCTOSBindingSource1
        '
        Me.PRODUCTOSBindingSource1.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource1.DataSource = Me.DsProducccionInforme
        '
        'DsProducccionInforme
        '
        Me.DsProducccionInforme.DataSetName = "DsProducccionInforme"
        Me.DsProducccionInforme.EnforceConstraints = False
        Me.DsProducccionInforme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TabBuscador
        '
        Me.TabBuscador.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.TabBuscador.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.TabBuscador.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabBuscador.Location = New System.Drawing.Point(723, 28)
        Me.TabBuscador.Name = "TabBuscador"
        '
        '
        '
        Me.TabBuscador.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.TabBuscador.RootElement.AngleTransform = 0.0!
        Me.TabBuscador.RootElement.FlipText = False
        Me.TabBuscador.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBuscador.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.TabBuscador.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.TabBuscador.RootElement.Text = Nothing
        Me.TabBuscador.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.TabBuscador.ScrollOffsetStep = 5
        Me.TabBuscador.Size = New System.Drawing.Size(680, 554)
        Me.TabBuscador.TabIndex = 377
        Me.TabBuscador.TabScrollButtonsPosition = Telerik.WinControls.UI.TabScrollButtonsPosition.RightBottom
        Me.TabBuscador.Text = "Productos"
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).TabScrollButtonsPosition = Telerik.WinControls.UI.TabScrollButtonsPosition.RightBottom
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).StretchBaseMode = Telerik.WinControls.UI.TabBaseStretchMode.StretchToRemainingSpace
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).ForeColor = System.Drawing.Color.GhostWhite
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).ZIndex = 825
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).ZIndex = 6
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).MinSize = New System.Drawing.Size(0, 7)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor2 = System.Drawing.Color.GhostWhite
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.GhostWhite
        '
        'BuscarProductoTextBox
        '
        Me.BuscarProductoTextBox.BackColor = System.Drawing.Color.LightGray
        Me.BuscarProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BuscarProductoTextBox.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.BuscarProductoTextBox.Location = New System.Drawing.Point(10, 26)
        Me.BuscarProductoTextBox.Name = "BuscarProductoTextBox"
        Me.BuscarProductoTextBox.Size = New System.Drawing.Size(548, 25)
        Me.BuscarProductoTextBox.TabIndex = 376
        Me.BuscarProductoTextBox.Text = "Buscar..."
        '
        'Producto
        '
        Me.Producto.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.Producto.AngleTransform = 0.0!
        '
        'Producto.ContentPanel
        '
        Me.Producto.ContentPanel.BackColor = System.Drawing.Color.White
        Me.Producto.ContentPanel.CausesValidation = True
        Me.Producto.ContentPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Producto.ContentPanel.ForeColor = System.Drawing.Color.GhostWhite
        Me.Producto.ContentPanel.Location = New System.Drawing.Point(1, 29)
        Me.Producto.ContentPanel.Size = New System.Drawing.Size(678, 524)
        Me.Producto.FlipText = False
        Me.Producto.Image = Nothing
        Me.Producto.ImageIndex = -1
        Me.Producto.ImageKey = ""
        Me.Producto.IsSelected = True
        Me.Producto.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Producto.Name = "Producto"
        Me.Producto.Padding = New System.Windows.Forms.Padding(0)
        Me.Producto.RightToLeft = False
        Me.Producto.StretchHorizontally = False
        Me.Producto.StringAlignment = System.Drawing.StringAlignment.Near
        Me.Producto.Text = "Producto"
        Me.Producto.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Producto.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Remision
        '
        Me.Remision.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.Remision.AngleTransform = 0.0!
        '
        'Remision.ContentPanel
        '
        Me.Remision.ContentPanel.BackColor = System.Drawing.Color.White
        Me.Remision.ContentPanel.CausesValidation = True
        Me.Remision.ContentPanel.Controls.Add(Me.RadGridViewDetalleRemisiones)
        Me.Remision.ContentPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remision.ContentPanel.ForeColor = System.Drawing.Color.GhostWhite
        Me.Remision.ContentPanel.Location = New System.Drawing.Point(1, 29)
        Me.Remision.ContentPanel.Size = New System.Drawing.Size(678, 524)
        Me.Remision.FlipText = False
        Me.Remision.Image = Nothing
        Me.Remision.ImageIndex = -1
        Me.Remision.ImageKey = ""
        Me.Remision.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Remision.Name = "Remision"
        Me.Remision.Padding = New System.Windows.Forms.Padding(0)
        Me.Remision.RightToLeft = False
        Me.Remision.StretchHorizontally = False
        Me.Remision.StringAlignment = System.Drawing.StringAlignment.Near
        Me.Remision.Text = "Remisión"
        Me.Remision.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Remision.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.Remision.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'RadGridViewDetalleRemisiones
        '
        Me.RadGridViewDetalleRemisiones.BackColor = System.Drawing.Color.Transparent
        Me.RadGridViewDetalleRemisiones.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridViewDetalleRemisiones.EnableHotTracking = False
        Me.RadGridViewDetalleRemisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RadGridViewDetalleRemisiones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridViewDetalleRemisiones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridViewDetalleRemisiones.Location = New System.Drawing.Point(5, 12)
        '
        '
        '
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.AllowAddNewRow = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.FieldAlias = "NUMENVIO"
        GridViewTextBoxColumn1.FieldName = "NUMENVIO"
        GridViewTextBoxColumn1.HeaderText = "Nro. de Remisión"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.UniqueName = "NUMENVIO"
        GridViewTextBoxColumn1.Width = 100
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CANTIDAD"
        GridViewDecimalColumn1.FieldName = "CANTIDAD"
        GridViewDecimalColumn1.HeaderText = "Cantidad"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.UniqueName = "CANTIDAD"
        GridViewDecimalColumn1.Width = 100
        GridViewTextBoxColumn2.FieldName = "PRODUCTO"
        GridViewTextBoxColumn2.HeaderText = "Producto"
        GridViewTextBoxColumn2.UniqueName = "PRODUCTO"
        GridViewTextBoxColumn2.Width = 350
        GridViewTextBoxColumn3.FieldAlias = "PRECIO"
        GridViewTextBoxColumn3.FieldName = "PRECIO"
        GridViewTextBoxColumn3.HeaderText = "Precio"
        GridViewTextBoxColumn3.UniqueName = "PRECIO"
        GridViewTextBoxColumn3.Width = 100
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "CODPRODUCTO"
        GridViewDecimalColumn2.FieldName = "CODPRODUCTO"
        GridViewDecimalColumn2.HeaderText = "CODPRODUCTO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODPRODUCTO"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODVENTA"
        GridViewDecimalColumn3.FieldName = "CODVENTA"
        GridViewDecimalColumn3.HeaderText = "CODVENTA"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODVENTA"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODCODIGO"
        GridViewDecimalColumn4.FieldName = "CODCODIGO"
        GridViewDecimalColumn4.HeaderText = "CODCODIGO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODCODIGO"
        GridViewDecimalColumn5.DataType = GetType(Decimal)
        GridViewDecimalColumn5.FieldAlias = "CODCOMBO"
        GridViewDecimalColumn5.FieldName = "CODCOMBO"
        GridViewDecimalColumn5.HeaderText = "CODCOMBO"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "CODCOMBO"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldAlias = "CODCLIENTE"
        GridViewDecimalColumn6.FieldName = "CODCLIENTE"
        GridViewDecimalColumn6.HeaderText = "CODCLIENTE"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "CODCLIENTE"
        GridViewDecimalColumn7.DataType = GetType(Decimal)
        GridViewDecimalColumn7.FieldAlias = "CODENVIODETALLE"
        GridViewDecimalColumn7.FieldName = "CODENVIODETALLE"
        GridViewDecimalColumn7.HeaderText = "CODENVIODETALLE"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.UniqueName = "CODENVIODETALLE"
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn7)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.EnableFiltering = True
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.EnableGrouping = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.ShowFilteringRow = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.RadGridViewDetalleRemisiones.Name = "RadGridViewDetalleRemisiones"
        Me.RadGridViewDetalleRemisiones.ReadOnly = True
        Me.RadGridViewDetalleRemisiones.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.RadGridViewDetalleRemisiones.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadGridViewDetalleRemisiones.RootElement.AngleTransform = 0.0!
        Me.RadGridViewDetalleRemisiones.RootElement.FlipText = False
        Me.RadGridViewDetalleRemisiones.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadGridViewDetalleRemisiones.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadGridViewDetalleRemisiones.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadGridViewDetalleRemisiones.RootElement.Text = Nothing
        Me.RadGridViewDetalleRemisiones.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadGridViewDetalleRemisiones.ShowGroupPanel = False
        Me.RadGridViewDetalleRemisiones.Size = New System.Drawing.Size(659, 504)
        Me.RadGridViewDetalleRemisiones.TabIndex = 261
        '
        'dgvListaReportes
        '
        Me.dgvListaReportes.AllowUserToDeleteRows = False
        Me.dgvListaReportes.AllowUserToOrderColumns = True
        Me.dgvListaReportes.AllowUserToResizeColumns = False
        Me.dgvListaReportes.AllowUserToResizeRows = False
        Me.dgvListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvListaReportes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvListaReportes.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaReportes.ColumnHeadersHeight = 35
        Me.dgvListaReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TITULO, Me.REFERENCIA, Me.PALABRASCLAVE})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListaReportes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListaReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListaReportes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvListaReportes.Location = New System.Drawing.Point(0, 0)
        Me.dgvListaReportes.MultiSelect = False
        Me.dgvListaReportes.Name = "dgvListaReportes"
        Me.dgvListaReportes.ReadOnly = True
        Me.dgvListaReportes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListaReportes.RowHeadersVisible = False
        Me.dgvListaReportes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvListaReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaReportes.Size = New System.Drawing.Size(260, 645)
        Me.dgvListaReportes.TabIndex = 490
        '
        'TITULO
        '
        Me.TITULO.HeaderText = "Lista de Reportes"
        Me.TITULO.Name = "TITULO"
        Me.TITULO.ReadOnly = True
        '
        'REFERENCIA
        '
        Me.REFERENCIA.HeaderText = "REFERENCIA"
        Me.REFERENCIA.Name = "REFERENCIA"
        Me.REFERENCIA.ReadOnly = True
        Me.REFERENCIA.Visible = False
        '
        'PALABRASCLAVE
        '
        Me.PALABRASCLAVE.HeaderText = "PALABRASCLAVE"
        Me.PALABRASCLAVE.Name = "PALABRASCLAVE"
        Me.PALABRASCLAVE.ReadOnly = True
        Me.PALABRASCLAVE.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 43)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvListaReportes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlFiltros)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ProductosGroupBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CrystalReportViewer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1079, 645)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 491
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlFiltros.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.panelTipoProd)
        Me.pnlFiltros.Controls.Add(Me.pnlSinFiltro)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Controls.Add(Me.chbxNuevaVent)
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.Label20)
        Me.pnlFiltros.Controls.Add(Me.pbxCerrarFiltros)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Controls.Add(Me.pnlOtrasOpciones)
        Me.pnlFiltros.Controls.Add(Me.pnlAgrupado)
        Me.pnlFiltros.Controls.Add(Me.pnlOrdenProd)
        Me.pnlFiltros.Controls.Add(Me.pnlCategorias)
        Me.pnlFiltros.Controls.Add(Me.pnlProducto)
        Me.pnlFiltros.Controls.Add(Me.pnlfechas)
        Me.pnlFiltros.Location = New System.Drawing.Point(252, 1)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(562, 519)
        Me.pnlFiltros.TabIndex = 466
        '
        'panelTipoProd
        '
        Me.panelTipoProd.BackColor = System.Drawing.Color.Transparent
        Me.panelTipoProd.Controls.Add(Me.cbxFiltroTipoProd)
        Me.panelTipoProd.Controls.Add(Me.Label12)
        Me.panelTipoProd.Location = New System.Drawing.Point(3, 90)
        Me.panelTipoProd.Name = "panelTipoProd"
        Me.panelTipoProd.Size = New System.Drawing.Size(551, 39)
        Me.panelTipoProd.TabIndex = 505
        '
        'cbxFiltroTipoProd
        '
        Me.cbxFiltroTipoProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxFiltroTipoProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxFiltroTipoProd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxFiltroTipoProd.DataSource = Me.TIPOPRODUCCIONBindingSource1
        Me.cbxFiltroTipoProd.DisplayMember = "DESTIPO"
        Me.cbxFiltroTipoProd.DropDownHeight = 120
        Me.cbxFiltroTipoProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxFiltroTipoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxFiltroTipoProd.FormattingEnabled = True
        Me.cbxFiltroTipoProd.IntegralHeight = False
        Me.cbxFiltroTipoProd.Location = New System.Drawing.Point(157, 3)
        Me.cbxFiltroTipoProd.Name = "cbxFiltroTipoProd"
        Me.cbxFiltroTipoProd.Size = New System.Drawing.Size(311, 32)
        Me.cbxFiltroTipoProd.TabIndex = 28
        Me.cbxFiltroTipoProd.ValueMember = "ID"
        '
        'TIPOPRODUCCIONBindingSource1
        '
        Me.TIPOPRODUCCIONBindingSource1.DataMember = "TIPOPRODUCCION"
        Me.TIPOPRODUCCIONBindingSource1.DataSource = Me.DsOrdProduccion
        '
        'DsOrdProduccion
        '
        Me.DsOrdProduccion.DataSetName = "dsOrdProduccion"
        Me.DsOrdProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(3, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 25)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Tipo de Producción"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(23, 193)
        Me.pnlSinFiltro.Name = "pnlSinFiltro"
        Me.pnlSinFiltro.Size = New System.Drawing.Size(525, 96)
        Me.pnlSinFiltro.TabIndex = 494
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(71, 31)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(413, 22)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Este Reporte no requiere de Filtros Especiales!"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(573, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(442, 33)
        Me.Panel1.TabIndex = 476
        '
        'chbxNuevaVent
        '
        Me.chbxNuevaVent.BackColor = System.Drawing.Color.Transparent
        Me.chbxNuevaVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbxNuevaVent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxNuevaVent.ForeColor = System.Drawing.Color.Black
        Me.chbxNuevaVent.Image = Global.ContaExpress.My.Resources.Resources.new_window
        Me.chbxNuevaVent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbxNuevaVent.Location = New System.Drawing.Point(358, 12)
        Me.chbxNuevaVent.Name = "chbxNuevaVent"
        Me.chbxNuevaVent.Size = New System.Drawing.Size(154, 16)
        Me.chbxNuevaVent.TabIndex = 475
        Me.chbxNuevaVent.Text = "Abrir en Ventana Nueva"
        Me.chbxNuevaVent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbxNuevaVent.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label7.Location = New System.Drawing.Point(6, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 25)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Filtros:"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label20.Location = New System.Drawing.Point(3, 436)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(559, 22)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Nota: Si quiere ver Todos los Datos, simplemente inserte ""%"" en el campo correspo" & _
    "ndiente"
        '
        'pbxCerrarFiltros
        '
        Me.pbxCerrarFiltros.BackColor = System.Drawing.Color.Transparent
        Me.pbxCerrarFiltros.Image = Global.ContaExpress.My.Resources.Resources.cerrar
        Me.pbxCerrarFiltros.Location = New System.Drawing.Point(516, 0)
        Me.pbxCerrarFiltros.Name = "pbxCerrarFiltros"
        Me.pbxCerrarFiltros.Size = New System.Drawing.Size(40, 46)
        Me.pbxCerrarFiltros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxCerrarFiltros.TabIndex = 0
        Me.pbxCerrarFiltros.TabStop = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenerar.BackColor = System.Drawing.Color.GreenYellow
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGenerar.Location = New System.Drawing.Point(311, 461)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(246, 42)
        Me.btnGenerar.TabIndex = 486
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlOtrasOpciones
        '
        Me.pnlOtrasOpciones.BackColor = System.Drawing.Color.Silver
        Me.pnlOtrasOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOtrasOpciones.Controls.Add(Me.rbtSalida)
        Me.pnlOtrasOpciones.Controls.Add(Me.rbtEntrada)
        Me.pnlOtrasOpciones.Controls.Add(Me.Panel4)
        Me.pnlOtrasOpciones.Location = New System.Drawing.Point(2, 175)
        Me.pnlOtrasOpciones.Name = "pnlOtrasOpciones"
        Me.pnlOtrasOpciones.Size = New System.Drawing.Size(551, 69)
        Me.pnlOtrasOpciones.TabIndex = 491
        '
        'rbtSalida
        '
        Me.rbtSalida.AutoSize = True
        Me.rbtSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.rbtSalida.Location = New System.Drawing.Point(303, 34)
        Me.rbtSalida.Name = "rbtSalida"
        Me.rbtSalida.Size = New System.Drawing.Size(65, 20)
        Me.rbtSalida.TabIndex = 14
        Me.rbtSalida.TabStop = True
        Me.rbtSalida.Text = "Salida"
        Me.rbtSalida.UseVisualStyleBackColor = True
        '
        'rbtEntrada
        '
        Me.rbtEntrada.AutoSize = True
        Me.rbtEntrada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.rbtEntrada.Location = New System.Drawing.Point(126, 34)
        Me.rbtEntrada.Name = "rbtEntrada"
        Me.rbtEntrada.Size = New System.Drawing.Size(73, 20)
        Me.rbtEntrada.TabIndex = 13
        Me.rbtEntrada.TabStop = True
        Me.rbtEntrada.Text = "Entrada"
        Me.rbtEntrada.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.BackColor = System.Drawing.Color.Tan
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Location = New System.Drawing.Point(-2, -1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(554, 25)
        Me.Panel4.TabIndex = 12
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(5, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(0, 21)
        Me.Label18.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(6, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(85, 21)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Filtro Datos"
        '
        'pnlAgrupado
        '
        Me.pnlAgrupado.BackColor = System.Drawing.Color.Silver
        Me.pnlAgrupado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAgrupado.Controls.Add(Me.rbtAPorA)
        Me.pnlAgrupado.Controls.Add(Me.rbtAPorD)
        Me.pnlAgrupado.Controls.Add(Me.rbtAPorM)
        Me.pnlAgrupado.Controls.Add(Me.Panel3)
        Me.pnlAgrupado.Location = New System.Drawing.Point(4, 249)
        Me.pnlAgrupado.Name = "pnlAgrupado"
        Me.pnlAgrupado.Size = New System.Drawing.Size(551, 69)
        Me.pnlAgrupado.TabIndex = 492
        '
        'rbtAPorA
        '
        Me.rbtAPorA.AutoSize = True
        Me.rbtAPorA.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.rbtAPorA.Location = New System.Drawing.Point(377, 35)
        Me.rbtAPorA.Name = "rbtAPorA"
        Me.rbtAPorA.Size = New System.Drawing.Size(143, 20)
        Me.rbtAPorA.TabIndex = 15
        Me.rbtAPorA.TabStop = True
        Me.rbtAPorA.Text = "Agrupados por Año"
        Me.rbtAPorA.UseVisualStyleBackColor = True
        '
        'rbtAPorD
        '
        Me.rbtAPorD.AutoSize = True
        Me.rbtAPorD.Checked = True
        Me.rbtAPorD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.rbtAPorD.Location = New System.Drawing.Point(14, 35)
        Me.rbtAPorD.Name = "rbtAPorD"
        Me.rbtAPorD.Size = New System.Drawing.Size(140, 20)
        Me.rbtAPorD.TabIndex = 14
        Me.rbtAPorD.TabStop = True
        Me.rbtAPorD.Text = "Agrupados por Dia"
        Me.rbtAPorD.UseVisualStyleBackColor = True
        '
        'rbtAPorM
        '
        Me.rbtAPorM.AutoSize = True
        Me.rbtAPorM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.rbtAPorM.Location = New System.Drawing.Point(199, 35)
        Me.rbtAPorM.Name = "rbtAPorM"
        Me.rbtAPorM.Size = New System.Drawing.Size(145, 20)
        Me.rbtAPorM.TabIndex = 13
        Me.rbtAPorM.Text = "Agrupados por Mes"
        Me.rbtAPorM.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.Tan
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(-2, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(554, 25)
        Me.Panel3.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 21)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Visualizar Datos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 21)
        Me.Label1.TabIndex = 7
        '
        'pnlOrdenProd
        '
        Me.pnlOrdenProd.BackColor = System.Drawing.Color.Transparent
        Me.pnlOrdenProd.Controls.Add(Me.cbxOrdenProd)
        Me.pnlOrdenProd.Controls.Add(Me.Label9)
        Me.pnlOrdenProd.Location = New System.Drawing.Point(2, 133)
        Me.pnlOrdenProd.Name = "pnlOrdenProd"
        Me.pnlOrdenProd.Size = New System.Drawing.Size(551, 39)
        Me.pnlOrdenProd.TabIndex = 504
        '
        'cbxOrdenProd
        '
        Me.cbxOrdenProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxOrdenProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxOrdenProd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxOrdenProd.DataSource = Me.ORDENPRODUCCIONBindingSource
        Me.cbxOrdenProd.DisplayMember = "CODIGOLOTE"
        Me.cbxOrdenProd.DropDownHeight = 120
        Me.cbxOrdenProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxOrdenProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxOrdenProd.FormattingEnabled = True
        Me.cbxOrdenProd.IntegralHeight = False
        Me.cbxOrdenProd.Location = New System.Drawing.Point(157, 3)
        Me.cbxOrdenProd.Name = "cbxOrdenProd"
        Me.cbxOrdenProd.Size = New System.Drawing.Size(311, 32)
        Me.cbxOrdenProd.TabIndex = 28
        Me.cbxOrdenProd.ValueMember = "ID"
        '
        'ORDENPRODUCCIONBindingSource
        '
        Me.ORDENPRODUCCIONBindingSource.DataMember = "ORDENPRODUCCION"
        Me.ORDENPRODUCCIONBindingSource.DataSource = Me.DsProducccionInforme
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(3, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 25)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Orden de Producción"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlCategorias
        '
        Me.pnlCategorias.BackgroundImage = CType(resources.GetObject("pnlCategorias.BackgroundImage"), System.Drawing.Image)
        Me.pnlCategorias.Controls.Add(Me.cbxRubro)
        Me.pnlCategorias.Controls.Add(Me.Label5)
        Me.pnlCategorias.Controls.Add(Me.Label4)
        Me.pnlCategorias.Controls.Add(Me.cbxCategoria)
        Me.pnlCategorias.Controls.Add(Me.cbxLinea)
        Me.pnlCategorias.Controls.Add(Me.Label3)
        Me.pnlCategorias.Location = New System.Drawing.Point(4, 92)
        Me.pnlCategorias.Name = "pnlCategorias"
        Me.pnlCategorias.Size = New System.Drawing.Size(544, 39)
        Me.pnlCategorias.TabIndex = 486
        '
        'cbxRubro
        '
        Me.cbxRubro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxRubro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxRubro.DisplayMember = "DESRUBRO"
        Me.cbxRubro.DropDownWidth = 170
        Me.cbxRubro.Enabled = False
        Me.cbxRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRubro.FormattingEnabled = True
        Me.cbxRubro.Location = New System.Drawing.Point(381, 3)
        Me.cbxRubro.Name = "cbxRubro"
        Me.cbxRubro.Size = New System.Drawing.Size(119, 33)
        Me.cbxRubro.TabIndex = 2
        Me.cbxRubro.ValueMember = "CODRUBRO"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(338, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 25)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Rubro"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(184, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Linea"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxCategoria
        '
        Me.cbxCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCategoria.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxCategoria.DataSource = Me.FAMILIABindingSource
        Me.cbxCategoria.DisplayMember = "DESFAMILIA"
        Me.cbxCategoria.DropDownWidth = 170
        Me.cbxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCategoria.FormattingEnabled = True
        Me.cbxCategoria.Location = New System.Drawing.Point(51, 4)
        Me.cbxCategoria.Name = "cbxCategoria"
        Me.cbxCategoria.Size = New System.Drawing.Size(132, 33)
        Me.cbxCategoria.TabIndex = 0
        Me.cbxCategoria.ValueMember = "CODFAMILIA"
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DsProducccionInforme
        '
        'cbxLinea
        '
        Me.cbxLinea.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxLinea.BackColor = System.Drawing.Color.GhostWhite
        Me.cbxLinea.DisplayMember = "DESLINEA"
        Me.cbxLinea.DropDownWidth = 170
        Me.cbxLinea.Enabled = False
        Me.cbxLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLinea.FormattingEnabled = True
        Me.cbxLinea.Location = New System.Drawing.Point(230, 3)
        Me.cbxLinea.Name = "cbxLinea"
        Me.cbxLinea.Size = New System.Drawing.Size(106, 33)
        Me.cbxLinea.TabIndex = 1
        Me.cbxLinea.ValueMember = "CODLINEA"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(2, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Familia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlProducto
        '
        Me.pnlProducto.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlProducto.Controls.Add(Me.pnlTipoProd)
        Me.pnlProducto.Controls.Add(Me.pbxRangoProd)
        Me.pnlProducto.Controls.Add(Me.lblPos5)
        Me.pnlProducto.Controls.Add(Me.chbxCodProducto)
        Me.pnlProducto.Controls.Add(Me.cmbProducto)
        Me.pnlProducto.Controls.Add(Me.BtnAsteriscoProducto)
        Me.pnlProducto.Controls.Add(Me.tbxcodProd)
        Me.pnlProducto.Location = New System.Drawing.Point(2, 49)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(550, 39)
        Me.pnlProducto.TabIndex = 503
        '
        'pnlTipoProd
        '
        Me.pnlTipoProd.BackColor = System.Drawing.Color.Transparent
        Me.pnlTipoProd.Controls.Add(Me.cbxTipoProd)
        Me.pnlTipoProd.Controls.Add(Me.Label10)
        Me.pnlTipoProd.Location = New System.Drawing.Point(0, 46)
        Me.pnlTipoProd.Name = "pnlTipoProd"
        Me.pnlTipoProd.Size = New System.Drawing.Size(548, 35)
        Me.pnlTipoProd.TabIndex = 500
        '
        'cbxTipoProd
        '
        Me.cbxTipoProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxTipoProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxTipoProd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxTipoProd.DataSource = Me.TIPOPRODUCCIONBindingSource
        Me.cbxTipoProd.DisplayMember = "DESTIPO"
        Me.cbxTipoProd.DropDownHeight = 120
        Me.cbxTipoProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipoProd.FormattingEnabled = True
        Me.cbxTipoProd.IntegralHeight = False
        Me.cbxTipoProd.Location = New System.Drawing.Point(157, 2)
        Me.cbxTipoProd.Name = "cbxTipoProd"
        Me.cbxTipoProd.Size = New System.Drawing.Size(311, 32)
        Me.cbxTipoProd.TabIndex = 29
        Me.cbxTipoProd.ValueMember = "ID"
        '
        'TIPOPRODUCCIONBindingSource
        '
        Me.TIPOPRODUCCIONBindingSource.DataMember = "TIPOPRODUCCION"
        Me.TIPOPRODUCCIONBindingSource.DataSource = Me.DsProducccionInformeBindingSource
        '
        'DsProducccionInformeBindingSource
        '
        Me.DsProducccionInformeBindingSource.DataSource = Me.DsProducccionInforme
        Me.DsProducccionInformeBindingSource.Position = 0
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(3, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(148, 25)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Tipo de Producción"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbxRangoProd
        '
        Me.pbxRangoProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxRangoProd.Image = CType(resources.GetObject("pbxRangoProd.Image"), System.Drawing.Image)
        Me.pbxRangoProd.Location = New System.Drawing.Point(519, 7)
        Me.pbxRangoProd.Name = "pbxRangoProd"
        Me.pbxRangoProd.Size = New System.Drawing.Size(21, 22)
        Me.pbxRangoProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRangoProd.TabIndex = 499
        Me.pbxRangoProd.TabStop = False
        '
        'lblPos5
        '
        Me.lblPos5.BackColor = System.Drawing.Color.Transparent
        Me.lblPos5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos5.ForeColor = System.Drawing.Color.Black
        Me.lblPos5.Location = New System.Drawing.Point(3, 6)
        Me.lblPos5.Name = "lblPos5"
        Me.lblPos5.Size = New System.Drawing.Size(89, 25)
        Me.lblPos5.TabIndex = 26
        Me.lblPos5.Text = "Productos"
        Me.lblPos5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chbxCodProducto
        '
        Me.chbxCodProducto.AutoSize = True
        Me.chbxCodProducto.BackColor = System.Drawing.Color.Transparent
        Me.chbxCodProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.chbxCodProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCodProducto.ForeColor = System.Drawing.Color.Gainsboro
        Me.chbxCodProducto.Location = New System.Drawing.Point(522, 12)
        Me.chbxCodProducto.Name = "chbxCodProducto"
        Me.chbxCodProducto.Size = New System.Drawing.Size(15, 14)
        Me.chbxCodProducto.TabIndex = 20
        Me.chbxCodProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.chbxCodProducto.UseVisualStyleBackColor = False
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbProducto.DataSource = Me.PRODUCTOSBindingSource1
        Me.cmbProducto.DisplayMember = "DESPRODUCTO"
        Me.cmbProducto.DropDownHeight = 120
        Me.cmbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.IntegralHeight = False
        Me.cmbProducto.Location = New System.Drawing.Point(98, 3)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(386, 32)
        Me.cmbProducto.TabIndex = 3
        Me.cmbProducto.ValueMember = "CODCODIGO"
        '
        'BtnAsteriscoProducto
        '
        Me.BtnAsteriscoProducto.BackColor = System.Drawing.Color.Transparent
        Me.BtnAsteriscoProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAsteriscoProducto.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.BtnAsteriscoProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAsteriscoProducto.Location = New System.Drawing.Point(490, 6)
        Me.BtnAsteriscoProducto.Name = "BtnAsteriscoProducto"
        Me.BtnAsteriscoProducto.Size = New System.Drawing.Size(24, 23)
        Me.BtnAsteriscoProducto.TabIndex = 471
        Me.BtnAsteriscoProducto.TabStop = False
        '
        'tbxcodProd
        '
        Me.tbxcodProd.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbxcodProd.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxcodProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxcodProd.Location = New System.Drawing.Point(98, 3)
        Me.tbxcodProd.Multiline = True
        Me.tbxcodProd.Name = "tbxcodProd"
        Me.tbxcodProd.Size = New System.Drawing.Size(386, 32)
        Me.tbxcodProd.TabIndex = 21
        '
        'pnlfechas
        '
        Me.pnlfechas.BackgroundImage = CType(resources.GetObject("pnlfechas.BackgroundImage"), System.Drawing.Image)
        Me.pnlfechas.Controls.Add(Me.dtpFechaHasta)
        Me.pnlfechas.Controls.Add(Me.Label11)
        Me.pnlfechas.Controls.Add(Me.Label8)
        Me.pnlfechas.Controls.Add(Me.dtpFechaDesde)
        Me.pnlfechas.Location = New System.Drawing.Point(3, 135)
        Me.pnlfechas.Name = "pnlfechas"
        Me.pnlfechas.Size = New System.Drawing.Size(551, 37)
        Me.pnlfechas.TabIndex = 492
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(372, 5)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(288, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Hasta Fecha"
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Desde Fecha"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
        Me.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(102, 5)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        'Me.CrystalReportViewer.CachedPageNumberPerDoc = 10
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.DisplayStatusBar = False
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGotoPageButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(815, 645)
        Me.CrystalReportViewer.TabIndex = 462
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProducccionInforme
        '
        'VProduccionBindingSource
        '
        Me.VProduccionBindingSource.DataMember = "VProduccion"
        Me.VProduccionBindingSource.DataSource = Me.DsProducccionInforme
        '
        'VProduccionTableAdapter
        '
        Me.VProduccionTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'VProduccionComparativoTableAdapter1
        '
        Me.VProduccionComparativoTableAdapter1.ClearBeforeFill = True
        '
        'FAMILIATableAdapter
        '
        Me.FAMILIATableAdapter.ClearBeforeFill = True
        '
        'VProduccionComparativoEntradaTableAdapter
        '
        Me.VProduccionComparativoEntradaTableAdapter.ClearBeforeFill = True
        '
        'ORDENPRODUCCIONTableAdapter
        '
        Me.ORDENPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'TIPOPRODUCCIONTableAdapter
        '
        Me.TIPOPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'DsProdInforme
        '
        Me.DsProdInforme.DataSetName = "dsProdInforme"
        Me.DsProdInforme.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PLANILLAPRODUCCIONCOSTOBindingSource
        '
        Me.PLANILLAPRODUCCIONCOSTOBindingSource.DataMember = "PLANILLAPRODUCCIONCOSTO"
        Me.PLANILLAPRODUCCIONCOSTOBindingSource.DataSource = Me.DsProdInforme
        '
        'PLANILLAPRODUCCIONCOSTOTableAdapter
        '
        Me.PLANILLAPRODUCCIONCOSTOTableAdapter.ClearBeforeFill = True
        '
        'ORDENPRODUCCIONCOSTOTOTALBindingSource
        '
        Me.ORDENPRODUCCIONCOSTOTOTALBindingSource.DataMember = "ORDENPRODUCCIONCOSTOTOTAL"
        Me.ORDENPRODUCCIONCOSTOTOTALBindingSource.DataSource = Me.DsProdInforme
        '
        'ORDENPRODUCCIONCOSTOTOTALTableAdapter
        '
        Me.ORDENPRODUCCIONCOSTOTOTALTableAdapter.ClearBeforeFill = True
        '
        'IMPPRODUCTOTERMBindingSource
        '
        Me.IMPPRODUCTOTERMBindingSource.DataMember = "IMPPRODUCTOTERM"
        Me.IMPPRODUCTOTERMBindingSource.DataSource = Me.DsOrdProduccion
        '
        'IMPPRODUCTOTERMTableAdapter
        '
        Me.IMPPRODUCTOTERMTableAdapter.ClearBeforeFill = True
        '
        'IMPMATERIAPRIMABindingSource
        '
        Me.IMPMATERIAPRIMABindingSource.DataMember = "IMPMATERIAPRIMA"
        Me.IMPMATERIAPRIMABindingSource.DataSource = Me.DsOrdProduccion
        '
        'IMPMATERIAPRIMATableAdapter
        '
        Me.IMPMATERIAPRIMATableAdapter.ClearBeforeFill = True
        '
        'TIPOPRODUCCIONTableAdapter1
        '
        Me.TIPOPRODUCCIONTableAdapter1.ClearBeforeFill = True
        '
        'FiltroReporteProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1081, 688)
        Me.Controls.Add(Me.btnFiltros)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblReporteDescrip)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.Label2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(5000, 900)
        Me.MinimumSize = New System.Drawing.Size(863, 676)
        Me.Name = "FiltroReporteProduccion"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Producción  | Cogent SIG"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProducccionInforme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Remision.ContentPanel.ResumeLayout(False)
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.panelTipoProd.ResumeLayout(False)
        CType(Me.TIPOPRODUCCIONBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOrdProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrasOpciones.ResumeLayout(False)
        Me.pnlOtrasOpciones.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlAgrupado.ResumeLayout(False)
        Me.pnlAgrupado.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlOrdenProd.ResumeLayout(False)
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorias.ResumeLayout(False)
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        Me.pnlTipoProd.ResumeLayout(False)
        CType(Me.TIPOPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProducccionInformeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlfechas.ResumeLayout(False)
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VProduccionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProdInforme, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLANILLAPRODUCCIONCOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORDENPRODUCCIONCOSTOTOTALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPPRODUCTOTERMBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPMATERIAPRIMABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIARIORESUMENCAJATableAdapter As ContaExpress.DsReporteVentasTableAdapters.DIARIORESUMENCAJATableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblReporteDescrip As System.Windows.Forms.Label
    Friend WithEvents CompraMovimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnFiltros As System.Windows.Forms.Button
    Friend WithEvents ProductosGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TabBuscador As Telerik.WinControls.UI.RadTabStrip
    Friend WithEvents Producto As Telerik.WinControls.UI.TabItem
    Friend WithEvents Remision As Telerik.WinControls.UI.TabItem
    Friend WithEvents RadGridViewDetalleRemisiones As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BuscarProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProductosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents dgvListaReportes As System.Windows.Forms.DataGridView
    Friend WithEvents TITULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALABRASCLAVE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pnlfechas As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlOtrasOpciones As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chbxNuevaVent As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pbxCerrarFiltros As System.Windows.Forms.PictureBox
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents pnlSinFiltro As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DsProducccionInformeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsProducccionInforme As ContaExpress.DsProducccionInforme
    Friend WithEvents VProduccionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VProduccionTableAdapter As ContaExpress.DsProducccionInformeTableAdapters.VProduccionTableAdapter
    Friend WithEvents TipoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProducccionInformeTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents pbxRangoProd As System.Windows.Forms.PictureBox
    Friend WithEvents lblPos5 As System.Windows.Forms.Label
    Friend WithEvents chbxCodProducto As System.Windows.Forms.CheckBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAsteriscoProducto As System.Windows.Forms.PictureBox
    Friend WithEvents tbxcodProd As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents VProduccionComparativoTableAdapter1 As ContaExpress.DsProducccionInformeTableAdapters.VProduccionComparativoTableAdapter
    Friend WithEvents pnlCategorias As System.Windows.Forms.Panel
    Friend WithEvents cbxRubro As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DsProducccionInformeTableAdapters.FAMILIATableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAgrupado As System.Windows.Forms.Panel
    Friend WithEvents rbtAPorD As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAPorM As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbtAPorA As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSalida As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEntrada As System.Windows.Forms.RadioButton
    Friend WithEvents VProduccionComparativoEntradaTableAdapter As ContaExpress.DsProducccionInformeTableAdapters.VProduccionComparativoEntradaTableAdapter
    Friend WithEvents pnlOrdenProd As System.Windows.Forms.Panel
    Friend WithEvents cbxOrdenProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlTipoProd As System.Windows.Forms.Panel
    Friend WithEvents cbxTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ORDENPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ORDENPRODUCCIONTableAdapter As ContaExpress.DsProducccionInformeTableAdapters.ORDENPRODUCCIONTableAdapter
    Friend WithEvents TIPOPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOPRODUCCIONTableAdapter As ContaExpress.DsProducccionInformeTableAdapters.TIPOPRODUCCIONTableAdapter
    Friend WithEvents DsProdInforme As ContaExpress.dsProdInforme
    Friend WithEvents PLANILLAPRODUCCIONCOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PLANILLAPRODUCCIONCOSTOTableAdapter As ContaExpress.dsProdInformeTableAdapters.PLANILLAPRODUCCIONCOSTOTableAdapter
    Friend WithEvents ORDENPRODUCCIONCOSTOTOTALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ORDENPRODUCCIONCOSTOTOTALTableAdapter As ContaExpress.dsProdInformeTableAdapters.ORDENPRODUCCIONCOSTOTOTALTableAdapter
    Friend WithEvents IMPPRODUCTOTERMBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsOrdProduccion As ContaExpress.dsOrdProduccion
    Friend WithEvents IMPPRODUCTOTERMTableAdapter As ContaExpress.dsOrdProduccionTableAdapters.IMPPRODUCTOTERMTableAdapter
    Friend WithEvents IMPMATERIAPRIMABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IMPMATERIAPRIMATableAdapter As ContaExpress.dsOrdProduccionTableAdapters.IMPMATERIAPRIMATableAdapter
    Friend WithEvents panelTipoProd As System.Windows.Forms.Panel
    Friend WithEvents cbxFiltroTipoProd As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TIPOPRODUCCIONBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOPRODUCCIONTableAdapter1 As ContaExpress.dsOrdProduccionTableAdapters.TIPOPRODUCCIONTableAdapter

    'Friend WithEvents CompraMovimientoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CompraMovimientoTableAdapter
End Class
