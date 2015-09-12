<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroReporteInventario
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
        Dim CheckBoxProperties1 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroReporteInventario))
        Dim CheckBoxProperties2 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
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
        Dim CheckBoxProperties3 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.chbxMatricial = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlOtrasOpciones = New System.Windows.Forms.Panel()
        Me.rbSinAgrup = New System.Windows.Forms.RadioButton()
        Me.rbAgrupFamillia = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblOtrasOpc = New System.Windows.Forms.Label()
        Me.pnlListaPrecio = New System.Windows.Forms.Panel()
        Me.cmbListaPrecio = New PresentationControls.CheckBoxComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlTransferencias = New System.Windows.Forms.Panel()
        Me.cmbDepDestino = New System.Windows.Forms.ComboBox()
        Me.SUCURSALDBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsReporteProductoNW = New ContaExpress.DSReporteProductoNW()
        Me.cmbDepOrigen = New System.Windows.Forms.ComboBox()
        Me.SUCURSALOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.pbxRangoProd = New System.Windows.Forms.PictureBox()
        Me.lblPos5 = New System.Windows.Forms.Label()
        Me.chbxCodProducto = New System.Windows.Forms.CheckBox()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRVFiltroInventario = New ContaExpress.dsRVFiltroInventario()
        Me.BtnAsteriscoProducto = New System.Windows.Forms.PictureBox()
        Me.tbxcodProd = New System.Windows.Forms.TextBox()
        Me.pnlCategorias = New System.Windows.Forms.Panel()
        Me.cbxRubro = New System.Windows.Forms.ComboBox()
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxCategoria = New System.Windows.Forms.ComboBox()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxLinea = New System.Windows.Forms.ComboBox()
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlDeposito = New System.Windows.Forms.Panel()
        Me.cmbSucursal = New PresentationControls.CheckBoxComboBox()
        Me.lblPos7 = New System.Windows.Forms.Label()
        Me.pnlfechas = New System.Windows.Forms.Panel()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblHastaF = New System.Windows.Forms.Label()
        Me.lblFDesde = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbxNuevaVent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbxCerrarFiltros = New System.Windows.Forms.PictureBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlEstadoStock = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rbEstadosEsp = New System.Windows.Forms.RadioButton()
        Me.pnlEstadosEsp = New System.Windows.Forms.Panel()
        Me.chbxConStock = New System.Windows.Forms.CheckBox()
        Me.chbxStock0 = New System.Windows.Forms.CheckBox()
        Me.chbxStockNeg = New System.Windows.Forms.CheckBox()
        Me.chbxCosto0Neg = New System.Windows.Forms.CheckBox()
        Me.rbEstadoTodos = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnFiltros = New System.Windows.Forms.Button()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabBuscador = New Telerik.WinControls.UI.RadTabStrip()
        Me.Producto = New Telerik.WinControls.UI.TabItem()
        Me.Remision = New Telerik.WinControls.UI.TabItem()
        Me.RadGridViewDetalleRemisiones = New Telerik.WinControls.UI.RadGridView()
        Me.BuscarProductoTextBox = New System.Windows.Forms.TextBox()
        Me.dgvListaReportes = New System.Windows.Forms.DataGridView()
        Me.TITULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALABRASCLAVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.cmbFamilia = New PresentationControls.CheckBoxComboBox()
        Me.gbxProductos = New Telerik.WinControls.UI.RadGroupBox()
        Me.GridViewClientes = New System.Windows.Forms.DataGridView()
        Me.TxtBuscaCliente = New System.Windows.Forms.TextBox()
        Me.RvfistockaunafechaTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RVFISTOCKAUNAFECHATableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.SUCURSALTableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.RUBROTableAdapter()
        Me.LineaTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.LineaTableAdapter()
        Me.FAMILIATableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.FAMILIATableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.PRODUCTOSTableAdapter()
        Me.DsRITransferencias = New ContaExpress.DsRITransferencias()
        Me.RiTransferenciaTableAdapter = New ContaExpress.DsRITransferenciasTableAdapters.RITransferenciaTableAdapter()
        Me.PrecionwTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.PRECIONWTableAdapter()
        Me.CostopromedionwTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.COSTOPROMEDIONWTableAdapter()
        Me.CostopromedionwsucTableAdapter = New ContaExpress.DSReporteProductoNWTableAdapters.COSTOPROMEDIONWSUCTableAdapter()
        Me.RimovproductoporfechaTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIMOVPRODUCTOPORFECHATableAdapter()
        Me.RimovproductoxrangofechaTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIMOVPRODUCTOXRANGOFECHATableAdapter()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.RiProductosTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIProductosTableAdapter()
        Me.RiStockActualTableAdapter1 = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockActualTableAdapter()
        Me.RiStockMinimoTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockMinimoTableAdapter()
        Me.RiOrdenPorCategoriaTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIOrdenPorCategoriaTableAdapter()
        Me.RiStockDepositoTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockDepositoTableAdapter()
        Me.RiCostoPromedioTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RICostoPromedioTableAdapter()
        Me.RiPrecioTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIPrecioTableAdapter()
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.ImprfifoTableAdapter = New ContaExpress.DsProduccionTableAdapters.IMPRFIFOTableAdapter()
        Me.StockactualfifoTableAdapter = New ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter()
        Me.StockactualfifoTableAdapter1 = New ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter()
        Me.RiListadoCostoTableAdapter = New ContaExpress.dsRVFiltroInventarioTableAdapters.RIListadoCostoTableAdapter()
        Me.DsRIProductos = New ContaExpress.DsRIProductos()
        Me.RistockvalorizadoTableAdapter = New ContaExpress.DsRIProductosTableAdapters.RISTOCKVALORIZADOTableAdapter()
        Me.RiListaProductoTableAdapter = New ContaExpress.DsRIProductosTableAdapters.RIListaProductoTableAdapter()
        Me.RICatalogoPrecioTableAdapter = New ContaExpress.DsRIProductosTableAdapters.RICatalogoPrecioTableAdapter()
        Me.RITIPOCLIENTETableAdapter = New ContaExpress.DsRIProductosTableAdapters.RITIPOCLIENTETableAdapter()
        Me.RiprodstockaunafechaTableAdapter = New ContaExpress.DsRIProductosTableAdapters.RIPRODSTOCKAUNAFECHATableAdapter()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.CachedaVentasAprobadas1 = New Reportes.CachedaVentasAprobadas()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlOtrasOpciones.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlListaPrecio.SuspendLayout()
        Me.pnlTransferencias.SuspendLayout()
        CType(Me.SUCURSALDBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReporteProductoNW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProducto.SuspendLayout()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVFiltroInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCategorias.SuspendLayout()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDeposito.SuspendLayout()
        Me.pnlfechas.SuspendLayout()
        Me.pnlSinFiltro.SuspendLayout()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstadoStock.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlEstadosEsp.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabBuscador.SuspendLayout()
        Me.Remision.ContentPanel.SuspendLayout()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gbxProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxProductos.SuspendLayout()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRITransferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRIProductos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label20.Location = New System.Drawing.Point(5, 425)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(559, 22)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Nota: Si quiere ver Todos los Datos, simplemente inserte ""%"" en el campo correspo" & _
    "ndiente"
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
        'chbxMatricial
        '
        Me.chbxMatricial.BackColor = System.Drawing.Color.Transparent
        Me.chbxMatricial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbxMatricial.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxMatricial.ForeColor = System.Drawing.Color.Black
        Me.chbxMatricial.Image = Global.ContaExpress.My.Resources.Resources.Matricial
        Me.chbxMatricial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbxMatricial.Location = New System.Drawing.Point(243, 13)
        Me.chbxMatricial.Name = "chbxMatricial"
        Me.chbxMatricial.Size = New System.Drawing.Size(124, 17)
        Me.chbxMatricial.TabIndex = 461
        Me.chbxMatricial.Text = "Formato Matricial"
        Me.chbxMatricial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbxMatricial.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Tan
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBig
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
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
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.DisplayStatusBar = False
        Me.CrystalReportViewer.DisplayToolbar = False
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGotoPageButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowPageNavigateButtons = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(815, 655)
        Me.CrystalReportViewer.TabIndex = 462
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlFiltros.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.pnlOtrasOpciones)
        Me.pnlFiltros.Controls.Add(Me.pnlListaPrecio)
        Me.pnlFiltros.Controls.Add(Me.pnlTransferencias)
        Me.pnlFiltros.Controls.Add(Me.pnlProducto)
        Me.pnlFiltros.Controls.Add(Me.pnlCategorias)
        Me.pnlFiltros.Controls.Add(Me.pnlDeposito)
        Me.pnlFiltros.Controls.Add(Me.pnlfechas)
        Me.pnlFiltros.Controls.Add(Me.pnlSinFiltro)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Controls.Add(Me.chbxNuevaVent)
        Me.pnlFiltros.Controls.Add(Me.chbxMatricial)
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.Label20)
        Me.pnlFiltros.Controls.Add(Me.pbxCerrarFiltros)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Controls.Add(Me.pnlEstadoStock)
        Me.pnlFiltros.Location = New System.Drawing.Point(254, 1)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(560, 503)
        Me.pnlFiltros.TabIndex = 466
        '
        'pnlOtrasOpciones
        '
        Me.pnlOtrasOpciones.BackColor = System.Drawing.Color.Silver
        Me.pnlOtrasOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOtrasOpciones.Controls.Add(Me.rbSinAgrup)
        Me.pnlOtrasOpciones.Controls.Add(Me.rbAgrupFamillia)
        Me.pnlOtrasOpciones.Controls.Add(Me.Panel4)
        Me.pnlOtrasOpciones.Location = New System.Drawing.Point(4, 216)
        Me.pnlOtrasOpciones.Name = "pnlOtrasOpciones"
        Me.pnlOtrasOpciones.Size = New System.Drawing.Size(551, 69)
        Me.pnlOtrasOpciones.TabIndex = 497
        '
        'rbSinAgrup
        '
        Me.rbSinAgrup.AutoSize = True
        Me.rbSinAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinAgrup.Location = New System.Drawing.Point(236, 35)
        Me.rbSinAgrup.Name = "rbSinAgrup"
        Me.rbSinAgrup.Size = New System.Drawing.Size(95, 20)
        Me.rbSinAgrup.TabIndex = 1
        Me.rbSinAgrup.TabStop = True
        Me.rbSinAgrup.Text = "No Agrupar"
        Me.rbSinAgrup.UseVisualStyleBackColor = True
        '
        'rbAgrupFamillia
        '
        Me.rbAgrupFamillia.AutoSize = True
        Me.rbAgrupFamillia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAgrupFamillia.Location = New System.Drawing.Point(29, 35)
        Me.rbAgrupFamillia.Name = "rbAgrupFamillia"
        Me.rbAgrupFamillia.Size = New System.Drawing.Size(144, 20)
        Me.rbAgrupFamillia.TabIndex = 1
        Me.rbAgrupFamillia.TabStop = True
        Me.rbAgrupFamillia.Text = "Agrupar por Familia"
        Me.rbAgrupFamillia.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel4.BackColor = System.Drawing.Color.Tan
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.lblOtrasOpc)
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
        'lblOtrasOpc
        '
        Me.lblOtrasOpc.AutoSize = True
        Me.lblOtrasOpc.BackColor = System.Drawing.Color.Transparent
        Me.lblOtrasOpc.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.lblOtrasOpc.ForeColor = System.Drawing.Color.Black
        Me.lblOtrasOpc.Location = New System.Drawing.Point(6, 2)
        Me.lblOtrasOpc.Name = "lblOtrasOpc"
        Me.lblOtrasOpc.Size = New System.Drawing.Size(110, 21)
        Me.lblOtrasOpc.TabIndex = 0
        Me.lblOtrasOpc.Text = "Otras opciones"
        '
        'pnlListaPrecio
        '
        Me.pnlListaPrecio.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlListaPrecio.Controls.Add(Me.cmbListaPrecio)
        Me.pnlListaPrecio.Controls.Add(Me.Label8)
        Me.pnlListaPrecio.Location = New System.Drawing.Point(4, 316)
        Me.pnlListaPrecio.Name = "pnlListaPrecio"
        Me.pnlListaPrecio.Size = New System.Drawing.Size(545, 39)
        Me.pnlListaPrecio.TabIndex = 485
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbListaPrecio.CheckBoxProperties = CheckBoxProperties1
        Me.cmbListaPrecio.DisplayMemberSingleItem = ""
        Me.cmbListaPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbListaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio.FormattingEnabled = True
        Me.cmbListaPrecio.Location = New System.Drawing.Point(98, 3)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(440, 33)
        Me.cmbListaPrecio.TabIndex = 491
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 25)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Lista de Precio"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTransferencias
        '
        Me.pnlTransferencias.BackgroundImage = CType(resources.GetObject("pnlTransferencias.BackgroundImage"), System.Drawing.Image)
        Me.pnlTransferencias.Controls.Add(Me.cmbDepDestino)
        Me.pnlTransferencias.Controls.Add(Me.cmbDepOrigen)
        Me.pnlTransferencias.Controls.Add(Me.Label1)
        Me.pnlTransferencias.Controls.Add(Me.Label6)
        Me.pnlTransferencias.Location = New System.Drawing.Point(6, 226)
        Me.pnlTransferencias.Name = "pnlTransferencias"
        Me.pnlTransferencias.Size = New System.Drawing.Size(545, 39)
        Me.pnlTransferencias.TabIndex = 496
        '
        'cmbDepDestino
        '
        Me.cmbDepDestino.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDepDestino.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDepDestino.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDepDestino.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbDepDestino.DataSource = Me.SUCURSALDBindingSource
        Me.cmbDepDestino.DisplayMember = "DESSUCURSAL"
        Me.cmbDepDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDepDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepDestino.FormattingEnabled = True
        Me.cmbDepDestino.Location = New System.Drawing.Point(369, 3)
        Me.cmbDepDestino.Name = "cmbDepDestino"
        Me.cmbDepDestino.Size = New System.Drawing.Size(163, 33)
        Me.cmbDepDestino.TabIndex = 21
        Me.cmbDepDestino.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALDBindingSource
        '
        Me.SUCURSALDBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALDBindingSource.DataSource = Me.DsReporteProductoNW
        '
        'DsReporteProductoNW
        '
        Me.DsReporteProductoNW.DataSetName = "DSReporteProductoNW"
        Me.DsReporteProductoNW.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmbDepOrigen
        '
        Me.cmbDepOrigen.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbDepOrigen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDepOrigen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDepOrigen.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbDepOrigen.DataSource = Me.SUCURSALOBindingSource
        Me.cmbDepOrigen.DisplayMember = "DESSUCURSAL"
        Me.cmbDepOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDepOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepOrigen.FormattingEnabled = True
        Me.cmbDepOrigen.Location = New System.Drawing.Point(95, 3)
        Me.cmbDepOrigen.Name = "cmbDepOrigen"
        Me.cmbDepOrigen.Size = New System.Drawing.Size(175, 33)
        Me.cmbDepOrigen.TabIndex = 20
        Me.cmbDepOrigen.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALOBindingSource
        '
        Me.SUCURSALOBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALOBindingSource.DataSource = Me.DsReporteProductoNW
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(286, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Dep. Destino"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(13, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Dep. Origen"
        '
        'pnlProducto
        '
        Me.pnlProducto.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlProducto.Controls.Add(Me.pbxRangoProd)
        Me.pnlProducto.Controls.Add(Me.lblPos5)
        Me.pnlProducto.Controls.Add(Me.chbxCodProducto)
        Me.pnlProducto.Controls.Add(Me.cmbProducto)
        Me.pnlProducto.Controls.Add(Me.BtnAsteriscoProducto)
        Me.pnlProducto.Controls.Add(Me.tbxcodProd)
        Me.pnlProducto.Location = New System.Drawing.Point(2, 65)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(545, 39)
        Me.pnlProducto.TabIndex = 484
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
        Me.ToolTip1.SetToolTip(Me.pbxRangoProd, "Presione aqui para búsqueda por Rango o Lista")
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
        Me.cmbProducto.DataSource = Me.PRODUCTOSBindingSource
        Me.cmbProducto.DisplayMember = "Descripcion"
        Me.cmbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(98, 3)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(386, 32)
        Me.cmbProducto.TabIndex = 3
        Me.cmbProducto.ValueMember = "CODCODIGO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "RIProductos"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsRVFiltroInventario
        '
        'DsRVFiltroInventario
        '
        Me.DsRVFiltroInventario.DataSetName = "dsRVFiltroInventario"
        Me.DsRVFiltroInventario.EnforceConstraints = False
        Me.DsRVFiltroInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'pnlCategorias
        '
        Me.pnlCategorias.BackgroundImage = CType(resources.GetObject("pnlCategorias.BackgroundImage"), System.Drawing.Image)
        Me.pnlCategorias.Controls.Add(Me.cbxRubro)
        Me.pnlCategorias.Controls.Add(Me.Label5)
        Me.pnlCategorias.Controls.Add(Me.Label4)
        Me.pnlCategorias.Controls.Add(Me.cbxCategoria)
        Me.pnlCategorias.Controls.Add(Me.cbxLinea)
        Me.pnlCategorias.Controls.Add(Me.Label3)
        Me.pnlCategorias.Location = New System.Drawing.Point(2, 125)
        Me.pnlCategorias.Name = "pnlCategorias"
        Me.pnlCategorias.Size = New System.Drawing.Size(544, 39)
        Me.pnlCategorias.TabIndex = 485
        '
        'cbxRubro
        '
        Me.cbxRubro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxRubro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxRubro.DataSource = Me.RUBROBindingSource
        Me.cbxRubro.DisplayMember = "DESRUBRO"
        Me.cbxRubro.DropDownWidth = 170
        Me.cbxRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRubro.FormattingEnabled = True
        Me.cbxRubro.Location = New System.Drawing.Point(411, 3)
        Me.cbxRubro.Name = "cbxRubro"
        Me.cbxRubro.Size = New System.Drawing.Size(132, 33)
        Me.cbxRubro.TabIndex = 2
        Me.cbxRubro.ValueMember = "CODRUBRO"
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "RUBRO"
        Me.RUBROBindingSource.DataSource = Me.DsReporteProductoNW
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(365, 7)
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
        Me.Label4.Location = New System.Drawing.Point(188, 7)
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
        Me.FAMILIABindingSource.DataSource = Me.DsReporteProductoNW
        '
        'cbxLinea
        '
        Me.cbxLinea.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxLinea.BackColor = System.Drawing.Color.GhostWhite
        Me.cbxLinea.DataSource = Me.LINEABindingSource
        Me.cbxLinea.DisplayMember = "DESLINEA"
        Me.cbxLinea.DropDownWidth = 170
        Me.cbxLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLinea.FormattingEnabled = True
        Me.cbxLinea.Location = New System.Drawing.Point(232, 3)
        Me.cbxLinea.Name = "cbxLinea"
        Me.cbxLinea.Size = New System.Drawing.Size(132, 33)
        Me.cbxLinea.TabIndex = 1
        Me.cbxLinea.ValueMember = "CODLINEA"
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "Linea"
        Me.LINEABindingSource.DataSource = Me.DsReporteProductoNW
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
        'pnlDeposito
        '
        Me.pnlDeposito.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlDeposito.Controls.Add(Me.cmbSucursal)
        Me.pnlDeposito.Controls.Add(Me.lblPos7)
        Me.pnlDeposito.Location = New System.Drawing.Point(4, 271)
        Me.pnlDeposito.Name = "pnlDeposito"
        Me.pnlDeposito.Size = New System.Drawing.Size(545, 39)
        Me.pnlDeposito.TabIndex = 486
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSucursal.CheckBoxProperties = CheckBoxProperties2
        Me.cmbSucursal.DisplayMemberSingleItem = ""
        Me.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(98, 3)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(440, 33)
        Me.cmbSucursal.TabIndex = 490
        '
        'lblPos7
        '
        Me.lblPos7.BackColor = System.Drawing.Color.Transparent
        Me.lblPos7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos7.ForeColor = System.Drawing.Color.Black
        Me.lblPos7.Location = New System.Drawing.Point(3, 7)
        Me.lblPos7.Name = "lblPos7"
        Me.lblPos7.Size = New System.Drawing.Size(89, 25)
        Me.lblPos7.TabIndex = 27
        Me.lblPos7.Text = "Deposito"
        Me.lblPos7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlfechas
        '
        Me.pnlfechas.BackgroundImage = CType(resources.GetObject("pnlfechas.BackgroundImage"), System.Drawing.Image)
        Me.pnlfechas.Controls.Add(Me.dtpFechaHasta)
        Me.pnlfechas.Controls.Add(Me.lblHastaF)
        Me.pnlfechas.Controls.Add(Me.lblFDesde)
        Me.pnlfechas.Controls.Add(Me.dtpFechaDesde)
        Me.pnlfechas.Location = New System.Drawing.Point(7, 170)
        Me.pnlfechas.Name = "pnlfechas"
        Me.pnlfechas.Size = New System.Drawing.Size(545, 39)
        Me.pnlfechas.TabIndex = 495
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(369, 6)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'lblHastaF
        '
        Me.lblHastaF.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblHastaF.BackColor = System.Drawing.Color.Transparent
        Me.lblHastaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHastaF.ForeColor = System.Drawing.Color.Black
        Me.lblHastaF.Location = New System.Drawing.Point(285, 11)
        Me.lblHastaF.Name = "lblHastaF"
        Me.lblHastaF.Size = New System.Drawing.Size(82, 20)
        Me.lblHastaF.TabIndex = 7
        Me.lblHastaF.Text = "Hasta Fecha"
        '
        'lblFDesde
        '
        Me.lblFDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFDesde.BackColor = System.Drawing.Color.Transparent
        Me.lblFDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFDesde.ForeColor = System.Drawing.Color.Black
        Me.lblFDesde.Location = New System.Drawing.Point(13, 11)
        Me.lblFDesde.Name = "lblFDesde"
        Me.lblFDesde.Size = New System.Drawing.Size(80, 15)
        Me.lblFDesde.TabIndex = 19
        Me.lblFDesde.Text = "Desde Fecha"
        Me.lblFDesde.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue
        Me.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(99, 6)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(6, 42)
        Me.pnlSinFiltro.Name = "pnlSinFiltro"
        Me.pnlSinFiltro.Size = New System.Drawing.Size(545, 384)
        Me.pnlSinFiltro.TabIndex = 474
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(70, 184)
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
        Me.chbxNuevaVent.AutoSize = True
        Me.chbxNuevaVent.BackColor = System.Drawing.Color.Transparent
        Me.chbxNuevaVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbxNuevaVent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxNuevaVent.ForeColor = System.Drawing.Color.Black
        Me.chbxNuevaVent.Location = New System.Drawing.Point(375, 13)
        Me.chbxNuevaVent.Name = "chbxNuevaVent"
        Me.chbxNuevaVent.Size = New System.Drawing.Size(138, 17)
        Me.chbxNuevaVent.TabIndex = 475
        Me.chbxNuevaVent.Text = "Abrir en Ventana Nueva"
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
        'pbxCerrarFiltros
        '
        Me.pbxCerrarFiltros.BackColor = System.Drawing.Color.Transparent
        Me.pbxCerrarFiltros.Image = Global.ContaExpress.My.Resources.Resources.cerrar
        Me.pbxCerrarFiltros.Location = New System.Drawing.Point(516, 0)
        Me.pbxCerrarFiltros.Name = "pbxCerrarFiltros"
        Me.pbxCerrarFiltros.Size = New System.Drawing.Size(40, 36)
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
        Me.btnGenerar.Location = New System.Drawing.Point(309, 452)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(246, 42)
        Me.btnGenerar.TabIndex = 486
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'pnlEstadoStock
        '
        Me.pnlEstadoStock.BackColor = System.Drawing.Color.Silver
        Me.pnlEstadoStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEstadoStock.Controls.Add(Me.Panel5)
        Me.pnlEstadoStock.Controls.Add(Me.Panel3)
        Me.pnlEstadoStock.Location = New System.Drawing.Point(4, 290)
        Me.pnlEstadoStock.Name = "pnlEstadoStock"
        Me.pnlEstadoStock.Size = New System.Drawing.Size(551, 76)
        Me.pnlEstadoStock.TabIndex = 498
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.rbEstadosEsp)
        Me.Panel5.Controls.Add(Me.pnlEstadosEsp)
        Me.Panel5.Controls.Add(Me.chbxCosto0Neg)
        Me.Panel5.Controls.Add(Me.rbEstadoTodos)
        Me.Panel5.Location = New System.Drawing.Point(5, 25)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(529, 50)
        Me.Panel5.TabIndex = 16
        '
        'rbEstadosEsp
        '
        Me.rbEstadosEsp.AutoSize = True
        Me.rbEstadosEsp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEstadosEsp.Location = New System.Drawing.Point(6, 26)
        Me.rbEstadosEsp.Name = "rbEstadosEsp"
        Me.rbEstadosEsp.Size = New System.Drawing.Size(76, 20)
        Me.rbEstadosEsp.TabIndex = 14
        Me.rbEstadosEsp.TabStop = True
        Me.rbEstadosEsp.Text = "Estados"
        Me.rbEstadosEsp.UseVisualStyleBackColor = True
        '
        'pnlEstadosEsp
        '
        Me.pnlEstadosEsp.Controls.Add(Me.chbxConStock)
        Me.pnlEstadosEsp.Controls.Add(Me.chbxStock0)
        Me.pnlEstadosEsp.Controls.Add(Me.chbxStockNeg)
        Me.pnlEstadosEsp.Location = New System.Drawing.Point(83, 22)
        Me.pnlEstadosEsp.Name = "pnlEstadosEsp"
        Me.pnlEstadosEsp.Size = New System.Drawing.Size(409, 26)
        Me.pnlEstadosEsp.TabIndex = 3
        Me.pnlEstadosEsp.Visible = False
        '
        'chbxConStock
        '
        Me.chbxConStock.AutoSize = True
        Me.chbxConStock.BackColor = System.Drawing.Color.Transparent
        Me.chbxConStock.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxConStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxConStock.Location = New System.Drawing.Point(25, 4)
        Me.chbxConStock.Name = "chbxConStock"
        Me.chbxConStock.Size = New System.Drawing.Size(86, 20)
        Me.chbxConStock.TabIndex = 17
        Me.chbxConStock.Text = "Con Stock"
        Me.chbxConStock.UseVisualStyleBackColor = False
        '
        'chbxStock0
        '
        Me.chbxStock0.AutoSize = True
        Me.chbxStock0.BackColor = System.Drawing.Color.Transparent
        Me.chbxStock0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxStock0.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxStock0.Location = New System.Drawing.Point(167, 4)
        Me.chbxStock0.Name = "chbxStock0"
        Me.chbxStock0.Size = New System.Drawing.Size(69, 20)
        Me.chbxStock0.TabIndex = 16
        Me.chbxStock0.Text = "Stock 0"
        Me.chbxStock0.UseVisualStyleBackColor = False
        '
        'chbxStockNeg
        '
        Me.chbxStockNeg.AutoSize = True
        Me.chbxStockNeg.BackColor = System.Drawing.Color.Transparent
        Me.chbxStockNeg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxStockNeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxStockNeg.Location = New System.Drawing.Point(310, 4)
        Me.chbxStockNeg.Name = "chbxStockNeg"
        Me.chbxStockNeg.Size = New System.Drawing.Size(87, 20)
        Me.chbxStockNeg.TabIndex = 15
        Me.chbxStockNeg.Text = "Negativos"
        Me.chbxStockNeg.UseVisualStyleBackColor = False
        '
        'chbxCosto0Neg
        '
        Me.chbxCosto0Neg.AutoSize = True
        Me.chbxCosto0Neg.BackColor = System.Drawing.Color.Transparent
        Me.chbxCosto0Neg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxCosto0Neg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCosto0Neg.Location = New System.Drawing.Point(108, 4)
        Me.chbxCosto0Neg.Name = "chbxCosto0Neg"
        Me.chbxCosto0Neg.Size = New System.Drawing.Size(178, 20)
        Me.chbxCosto0Neg.TabIndex = 13
        Me.chbxCosto0Neg.Text = "Costo 0 si Stock Negativo"
        Me.chbxCosto0Neg.UseVisualStyleBackColor = False
        '
        'rbEstadoTodos
        '
        Me.rbEstadoTodos.AutoSize = True
        Me.rbEstadoTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEstadoTodos.Location = New System.Drawing.Point(5, 3)
        Me.rbEstadoTodos.Name = "rbEstadoTodos"
        Me.rbEstadoTodos.Size = New System.Drawing.Size(66, 20)
        Me.rbEstadoTodos.TabIndex = 2
        Me.rbEstadoTodos.TabStop = True
        Me.rbEstadoTodos.Text = "Todos"
        Me.rbEstadoTodos.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.Tan
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(-2, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(554, 25)
        Me.Panel3.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(5, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 21)
        Me.Label9.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(116, 21)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Mostrar Estados"
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
        Me.ProductosGroupBox.Location = New System.Drawing.Point(430, 34)
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
        Me.ProductosGroupBox.ThemeName = "Breeze"
        Me.ProductosGroupBox.Visible = False
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = "Búsqueda de Productos"
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductosGridView
        '
        Me.ProductosGridView.AllowDrop = True
        Me.ProductosGridView.AllowUserToAddRows = False
        Me.ProductosGridView.AllowUserToDeleteRows = False
        Me.ProductosGridView.AllowUserToResizeColumns = False
        Me.ProductosGridView.AllowUserToResizeRows = False
        Me.ProductosGridView.AutoGenerateColumns = False
        Me.ProductosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ProductosGridView.ColumnHeadersHeight = 30
        Me.ProductosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DescripcionDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn4, Me.CODPRODUCTODataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19})
        Me.ProductosGridView.DataSource = Me.PRODUCTOSBindingSource
        Me.ProductosGridView.Location = New System.Drawing.Point(10, 55)
        Me.ProductosGridView.MultiSelect = False
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.ReadOnly = True
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.ShowCellErrors = False
        Me.ProductosGridView.ShowEditingIcon = False
        Me.ProductosGridView.ShowRowErrors = False
        Me.ProductosGridView.Size = New System.Drawing.Size(548, 461)
        Me.ProductosGridView.StandardTab = True
        Me.ProductosGridView.TabIndex = 378
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 30.0!
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DescripcionDataGridViewTextBoxColumn
        '
        Me.DescripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion"
        Me.DescripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion"
        Me.DescripcionDataGridViewTextBoxColumn.Name = "DescripcionDataGridViewTextBoxColumn"
        Me.DescripcionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DESRUBRO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "DESRUBRO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESLINEA"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESLINEA"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'CODPRODUCTODataGridViewTextBoxColumn
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Name = "CODPRODUCTODataGridViewTextBoxColumn"
        Me.CODPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODUCTODataGridViewTextBoxColumn.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "DESFAMILIA"
        Me.DataGridViewTextBoxColumn18.HeaderText = "DESFAMILIA"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.ReadOnly = True
        Me.DataGridViewTextBoxColumn18.Visible = False
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "CODCODIGO"
        Me.DataGridViewTextBoxColumn19.HeaderText = "CODCODIGO"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.ReadOnly = True
        Me.DataGridViewTextBoxColumn19.Visible = False
        '
        'TabBuscador
        '
        Me.TabBuscador.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.TabBuscador.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.TabBuscador.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabBuscador.Items.AddRange(New Telerik.WinControls.RadItem() {Me.Producto, Me.Remision})
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
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).ZIndex = 791
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).ZIndex = 8
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).MinSize = New System.Drawing.Size(0, 7)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor2 = System.Drawing.Color.GhostWhite
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.GhostWhite
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
        'dgvListaReportes
        '
        Me.dgvListaReportes.AllowUserToDeleteRows = False
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
        Me.dgvListaReportes.Size = New System.Drawing.Size(260, 655)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.CrystalReportViewer)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmbFamilia)
        Me.SplitContainer1.Size = New System.Drawing.Size(1079, 655)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 491
        '
        'cmbFamilia
        '
        Me.cmbFamilia.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbFamilia.CheckBoxProperties = CheckBoxProperties3
        Me.cmbFamilia.DisplayMemberSingleItem = ""
        Me.cmbFamilia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFamilia.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFamilia.FormattingEnabled = True
        Me.cmbFamilia.Location = New System.Drawing.Point(23, 195)
        Me.cmbFamilia.Name = "cmbFamilia"
        Me.cmbFamilia.Size = New System.Drawing.Size(202, 33)
        Me.cmbFamilia.TabIndex = 491
        Me.cmbFamilia.Visible = False
        '
        'gbxProductos
        '
        Me.gbxProductos.Controls.Add(Me.GridViewClientes)
        Me.gbxProductos.Controls.Add(Me.TxtBuscaCliente)
        Me.gbxProductos.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.gbxProductos.FooterImageIndex = -1
        Me.gbxProductos.FooterImageKey = ""
        Me.gbxProductos.HeaderImageIndex = -1
        Me.gbxProductos.HeaderImageKey = ""
        Me.gbxProductos.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.gbxProductos.HeaderText = ""
        Me.gbxProductos.Location = New System.Drawing.Point(303, 98)
        Me.gbxProductos.Name = "gbxProductos"
        Me.gbxProductos.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.gbxProductos.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.gbxProductos.RootElement.AngleTransform = 0.0!
        Me.gbxProductos.RootElement.FlipText = False
        Me.gbxProductos.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.gbxProductos.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.gbxProductos.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.gbxProductos.RootElement.Text = Nothing
        Me.gbxProductos.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.gbxProductos.Size = New System.Drawing.Size(565, 593)
        Me.gbxProductos.TabIndex = 492
        Me.gbxProductos.ThemeName = "Breeze"
        Me.gbxProductos.Visible = False
        CType(Me.gbxProductos.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.DimGray
        '
        'GridViewClientes
        '
        Me.GridViewClientes.AllowDrop = True
        Me.GridViewClientes.AllowUserToAddRows = False
        Me.GridViewClientes.AllowUserToDeleteRows = False
        Me.GridViewClientes.AllowUserToResizeRows = False
        Me.GridViewClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewClientes.ColumnHeadersHeight = 30
        Me.GridViewClientes.Location = New System.Drawing.Point(10, 45)
        Me.GridViewClientes.Name = "GridViewClientes"
        Me.GridViewClientes.ReadOnly = True
        Me.GridViewClientes.RowHeadersVisible = False
        Me.GridViewClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GridViewClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewClientes.ShowCellErrors = False
        Me.GridViewClientes.ShowCellToolTips = False
        Me.GridViewClientes.ShowEditingIcon = False
        Me.GridViewClientes.ShowRowErrors = False
        Me.GridViewClientes.Size = New System.Drawing.Size(546, 538)
        Me.GridViewClientes.TabIndex = 490
        '
        'TxtBuscaCliente
        '
        Me.TxtBuscaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBuscaCliente.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.TxtBuscaCliente.Location = New System.Drawing.Point(11, 12)
        Me.TxtBuscaCliente.Name = "TxtBuscaCliente"
        Me.TxtBuscaCliente.Size = New System.Drawing.Size(545, 30)
        Me.TxtBuscaCliente.TabIndex = 376
        Me.TxtBuscaCliente.Text = "Buscar..."
        '
        'RvfistockaunafechaTableAdapter
        '
        Me.RvfistockaunafechaTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'RUBROTableAdapter
        '
        Me.RUBROTableAdapter.ClearBeforeFill = True
        '
        'LineaTableAdapter
        '
        Me.LineaTableAdapter.ClearBeforeFill = True
        '
        'FAMILIATableAdapter
        '
        Me.FAMILIATableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'DsRITransferencias
        '
        Me.DsRITransferencias.DataSetName = "DsRITransferencias"
        Me.DsRITransferencias.EnforceConstraints = False
        Me.DsRITransferencias.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RiTransferenciaTableAdapter
        '
        Me.RiTransferenciaTableAdapter.ClearBeforeFill = True
        '
        'PrecionwTableAdapter
        '
        Me.PrecionwTableAdapter.ClearBeforeFill = True
        '
        'CostopromedionwTableAdapter
        '
        Me.CostopromedionwTableAdapter.ClearBeforeFill = True
        '
        'CostopromedionwsucTableAdapter
        '
        Me.CostopromedionwsucTableAdapter.ClearBeforeFill = True
        '
        'RimovproductoporfechaTableAdapter
        '
        Me.RimovproductoporfechaTableAdapter.ClearBeforeFill = True
        '
        'RimovproductoxrangofechaTableAdapter
        '
        Me.RimovproductoxrangofechaTableAdapter.ClearBeforeFill = True
        '
        'RiProductosTableAdapter
        '
        Me.RiProductosTableAdapter.ClearBeforeFill = True
        '
        'RiStockActualTableAdapter1
        '
        Me.RiStockActualTableAdapter1.ClearBeforeFill = True
        '
        'RiStockMinimoTableAdapter
        '
        Me.RiStockMinimoTableAdapter.ClearBeforeFill = True
        '
        'RiOrdenPorCategoriaTableAdapter
        '
        Me.RiOrdenPorCategoriaTableAdapter.ClearBeforeFill = True
        '
        'RiStockDepositoTableAdapter
        '
        Me.RiStockDepositoTableAdapter.ClearBeforeFill = True
        '
        'RiCostoPromedioTableAdapter
        '
        Me.RiCostoPromedioTableAdapter.ClearBeforeFill = True
        '
        'RiPrecioTableAdapter
        '
        Me.RiPrecioTableAdapter.ClearBeforeFill = True
        '
        'DsProduccion
        '
        Me.DsProduccion.DataSetName = "DsProduccion"
        Me.DsProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ImprfifoTableAdapter
        '
        Me.ImprfifoTableAdapter.ClearBeforeFill = True
        '
        'StockactualfifoTableAdapter
        '
        Me.StockactualfifoTableAdapter.ClearBeforeFill = True
        '
        'StockactualfifoTableAdapter1
        '
        Me.StockactualfifoTableAdapter1.ClearBeforeFill = True
        '
        'RiListadoCostoTableAdapter
        '
        Me.RiListadoCostoTableAdapter.ClearBeforeFill = True
        '
        'DsRIProductos
        '
        Me.DsRIProductos.DataSetName = "DsRIProductos"
        Me.DsRIProductos.EnforceConstraints = False
        Me.DsRIProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RistockvalorizadoTableAdapter
        '
        Me.RistockvalorizadoTableAdapter.ClearBeforeFill = True
        '
        'RiListaProductoTableAdapter
        '
        Me.RiListaProductoTableAdapter.ClearBeforeFill = True
        '
        'RICatalogoPrecioTableAdapter
        '
        Me.RICatalogoPrecioTableAdapter.ClearBeforeFill = True
        '
        'RITIPOCLIENTETableAdapter
        '
        Me.RITIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'RiprodstockaunafechaTableAdapter
        '
        Me.RiprodstockaunafechaTableAdapter.ClearBeforeFill = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'FiltroReporteInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1081, 698)
        Me.Controls.Add(Me.btnFiltros)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblReporteDescrip)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbxProductos)
        Me.Controls.Add(Me.ProductosGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximumSize = New System.Drawing.Size(5000, 900)
        Me.MinimumSize = New System.Drawing.Size(863, 676)
        Me.Name = "FiltroReporteInventario"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Inventario  | Cogent SIG"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.pnlOtrasOpciones.ResumeLayout(False)
        Me.pnlOtrasOpciones.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlListaPrecio.ResumeLayout(False)
        Me.pnlTransferencias.ResumeLayout(False)
        CType(Me.SUCURSALDBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReporteProductoNW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVFiltroInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCategorias.ResumeLayout(False)
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDeposito.ResumeLayout(False)
        Me.pnlfechas.ResumeLayout(False)
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstadoStock.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlEstadosEsp.ResumeLayout(False)
        Me.pnlEstadosEsp.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabBuscador.ResumeLayout(False)
        Me.Remision.ContentPanel.ResumeLayout(False)
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gbxProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxProductos.ResumeLayout(False)
        Me.gbxProductos.PerformLayout()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRITransferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRIProductos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents chbxMatricial As System.Windows.Forms.CheckBox
    Friend WithEvents CompraMovimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pbxCerrarFiltros As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chbxNuevaVent As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
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
    Friend WithEvents pnlSinFiltro As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents pnlfechas As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHastaF As System.Windows.Forms.Label
    Friend WithEvents lblFDesde As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents lblPos5 As System.Windows.Forms.Label
    Friend WithEvents chbxCodProducto As System.Windows.Forms.CheckBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents BtnAsteriscoProducto As System.Windows.Forms.PictureBox
    Friend WithEvents tbxcodProd As System.Windows.Forms.TextBox
    Friend WithEvents pnlCategorias As System.Windows.Forms.Panel
    Friend WithEvents cbxRubro As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlDeposito As System.Windows.Forms.Panel
    Friend WithEvents cmbSucursal As PresentationControls.CheckBoxComboBox
    Friend WithEvents lblPos7 As System.Windows.Forms.Label
    Friend WithEvents DsRVFiltroInventario As ContaExpress.dsRVFiltroInventario
    Friend WithEvents gbxProductos As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents GridViewClientes As System.Windows.Forms.DataGridView
    Friend WithEvents DESRUBRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESLINEADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFAMILIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtBuscaCliente As System.Windows.Forms.TextBox
    Friend WithEvents RvfistockaunafechaTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RVFISTOCKAUNAFECHATableAdapter
    Friend WithEvents SUCURSALOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsReporteProductoNW As ContaExpress.DSReporteProductoNW
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.SUCURSALTableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUBROTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.RUBROTableAdapter
    Friend WithEvents LineaTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.LineaTableAdapter
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.FAMILIATableAdapter
    Friend WithEvents pnlTransferencias As System.Windows.Forms.Panel
    Friend WithEvents cmbDepDestino As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDepOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents DsRIProductos As ContaExpress.DsRIProductos
    Friend WithEvents DsRITransferencias As ContaExpress.DsRITransferencias
    Friend WithEvents RistockvalorizadoTableAdapter As ContaExpress.DsRIProductosTableAdapters.RISTOCKVALORIZADOTableAdapter
    Friend WithEvents RiTransferenciaTableAdapter As ContaExpress.DsRITransferenciasTableAdapters.RITransferenciaTableAdapter
    Friend WithEvents RiListaProductoTableAdapter As ContaExpress.DsRIProductosTableAdapters.RIListaProductoTableAdapter
    Friend WithEvents PrecionwTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.PRECIONWTableAdapter
    Friend WithEvents CostopromedionwTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.COSTOPROMEDIONWTableAdapter
    Friend WithEvents CostopromedionwsucTableAdapter As ContaExpress.DSReporteProductoNWTableAdapters.COSTOPROMEDIONWSUCTableAdapter
    Friend WithEvents SUCURSALDBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RimovproductoporfechaTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIMOVPRODUCTOPORFECHATableAdapter
    Friend WithEvents RimovproductoxrangofechaTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIMOVPRODUCTOXRANGOFECHATableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents RiProductosTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIProductosTableAdapter
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RiStockActualTableAdapter1 As ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockActualTableAdapter
    Friend WithEvents RiStockMinimoTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockMinimoTableAdapter
    Friend WithEvents RiOrdenPorCategoriaTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIOrdenPorCategoriaTableAdapter
    Friend WithEvents RiStockDepositoTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIStockDepositoTableAdapter
    Friend WithEvents RiCostoPromedioTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RICostoPromedioTableAdapter
    Friend WithEvents RiPrecioTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIPrecioTableAdapter
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents ImprfifoTableAdapter As ContaExpress.DsProduccionTableAdapters.IMPRFIFOTableAdapter
    Friend WithEvents StockactualfifoTableAdapter As ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter
    Friend WithEvents StockactualfifoTableAdapter1 As ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter
    Friend WithEvents RICatalogoPrecioTableAdapter As ContaExpress.DsRIProductosTableAdapters.RICatalogoPrecioTableAdapter
    Friend WithEvents pnlListaPrecio As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents RITIPOCLIENTETableAdapter As ContaExpress.DsRIProductosTableAdapters.RITIPOCLIENTETableAdapter
    Friend WithEvents cmbListaPrecio As PresentationControls.CheckBoxComboBox
    Friend WithEvents RiListadoCostoTableAdapter As ContaExpress.dsRVFiltroInventarioTableAdapters.RIListadoCostoTableAdapter
    Friend WithEvents pnlOtrasOpciones As System.Windows.Forms.Panel
    Friend WithEvents rbSinAgrup As System.Windows.Forms.RadioButton
    Friend WithEvents rbAgrupFamillia As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblOtrasOpc As System.Windows.Forms.Label
    Friend WithEvents pnlEstadoStock As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pnlEstadosEsp As System.Windows.Forms.Panel
    Friend WithEvents chbxConStock As System.Windows.Forms.CheckBox
    Friend WithEvents chbxStock0 As System.Windows.Forms.CheckBox
    Friend WithEvents chbxStockNeg As System.Windows.Forms.CheckBox
    Friend WithEvents chbxCosto0Neg As System.Windows.Forms.CheckBox
    Friend WithEvents rbEstadoTodos As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents rbEstadosEsp As System.Windows.Forms.RadioButton
    Friend WithEvents RiprodstockaunafechaTableAdapter As ContaExpress.DsRIProductosTableAdapters.RIPRODSTOCKAUNAFECHATableAdapter
    Friend WithEvents pbxRangoProd As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents CachedaVentasAprobadas1 As Reportes.CachedaVentasAprobadas
    Friend WithEvents cmbFamilia As PresentationControls.CheckBoxComboBox
    'Friend WithEvents CompraMovimientoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CompraMovimientoTableAdapter
End Class
