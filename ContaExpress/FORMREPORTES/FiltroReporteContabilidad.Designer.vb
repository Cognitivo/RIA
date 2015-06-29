<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroReporteContabilidad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroReporteContabilidad))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.chbxMatricial = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbxBuscarPermiso = New System.Windows.Forms.TextBox()
        Me.chbxTodos = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgvCuenta = New System.Windows.Forms.DataGridView()
        Me.NUMPLANCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPLANCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ver = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CODPLANCUENTA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVELCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASENTABLEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlancuentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInfContabilidad = New ContaExpress.DsInfContabilidad()
        Me.pnlCaja = New System.Windows.Forms.Panel()
        Me.cbxCaja = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCaja = New ContaExpress.DsCaja()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlSucursal = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlLocalizacion = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.tbxLocalizacion = New System.Windows.Forms.TextBox()
        Me.pnlTipoReporte = New System.Windows.Forms.Panel()
        Me.rbtnRectificativa = New System.Windows.Forms.RadioButton()
        Me.rbtnOriginal = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPeriodoFiscal = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPeriodoFiscal = New System.Windows.Forms.ComboBox()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbxNuevaVent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbxCerrarFiltros = New System.Windows.Forms.PictureBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pnlComprobante = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.cmbComprobante = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlfechas = New System.Windows.Forms.Panel()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.pnlRegistrosAsentados = New System.Windows.Forms.Panel()
        Me.rbtAsentadosNO = New System.Windows.Forms.RadioButton()
        Me.rbtAsentadosSI = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlFechaPeriodo = New System.Windows.Forms.Panel()
        Me.cmbHasta = New System.Windows.Forms.ComboBox()
        Me.cmbDesde = New System.Windows.Forms.ComboBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Mes = New System.Windows.Forms.Label()
        Me.pnlFacturasAnuladas = New System.Windows.Forms.Panel()
        Me.rbnAnuladasNO = New System.Windows.Forms.RadioButton()
        Me.rbnAnuladasSI = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnFiltros = New System.Windows.Forms.Button()
        Me.DsRVFacturacion = New ContaExpress.DsRVFacturacion()
        Me.RvTipoComprobanteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVTipoComprobanteTableAdapter()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CAJATableAdapter = New ContaExpress.DsCajaTableAdapters.CAJATableAdapter()
        Me.CAJABindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PeriodofiscalTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.periodofiscalTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.SUCURSALTableAdapter()
        Me.PlanCuentasRepTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.PlanCuentasRepTableAdapter()
        Me.BalanceGeneralTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.BalanceGeneralTableAdapter()
        Me.BalanceSaldoTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.BalanceSaldoTableAdapter()
        Me.BalanceSumaTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.BalanceSumaTableAdapter()
        Me.CuadroResultadosTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.CuadroResultadosTableAdapter()
        Me.LibroIvaVentasTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.LibroIvaVentasTableAdapter()
        Me.LibroIvaComprasTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.LibroIvaComprasTableAdapter()
        Me.BALANCESUMAYSALDOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BALANCESUMAYSALDOTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.BALANCESUMAYSALDOTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsInfContabilidadTableAdapters.TableAdapterManager()
        Me.PlancuentasTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.plancuentasTableAdapter()
        Me.SaldoAnteriorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SaldoAnteriorTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.SaldoAnteriorTableAdapter()
        Me.HISTORICOLIBROMAYOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HISTORICOLIBROMAYOTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.HISTORICOLIBROMAYOTableAdapter()
        Me.LibrioDiarioTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.LibrioDiarioTableAdapter()
        Me.LibroIvaTicketTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.LibroIvaTicketTableAdapter()
        Me.RetencionesIVATableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.RetencionesIVATableAdapter()
        Me.RetencionrentaTableAdapter = New ContaExpress.DsPagosFacutasTableAdapters.RETENCIONRENTATableAdapter()
        Me.RetencionesRentaTableAdapter = New ContaExpress.DsInfContabilidadTableAdapters.RetencionesRentaTableAdapter()
        Me.BalanceGeneralRes173BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalanceGeneralRes173TableAdapter1 = New ContaExpress.DsInfContabilidadTableAdapters.BalanceGeneralRes173TableAdapter1()
        Me.DsCalculoResultado = New ContaExpress.DsCalculoResultado()
        Me.CalculoResultadoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CalculoResultadoTableAdapter = New ContaExpress.DsCalculoResultadoTableAdapters.CalculoResultadoTableAdapter()
        Me.DsContaBalanceGeneral173 = New ContaExpress.DsContaBalanceGeneral173()
        Me.DsContaBalanceGeneral173BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalanceGeneral173BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BalanceGeneral173TableAdapter = New ContaExpress.DsContaBalanceGeneral173TableAdapters.BalanceGeneral173TableAdapter()
        Me.SaldoBalanceGeneral173BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SaldoBalanceGeneral173TableAdapter = New ContaExpress.DsContaBalanceGeneral173TableAdapters.SaldoBalanceGeneral173TableAdapter()
        Me.EstadosDeResultados49BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EstadosDeResultados49TableAdapter = New ContaExpress.DsContaBalanceGeneral173TableAdapters.EstadosDeResultados49TableAdapter()
        Me.SaldoEstadosDeResultados49BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SaldoEstadosDeResultados49TableAdapter = New ContaExpress.DsContaBalanceGeneral173TableAdapters.SaldoEstadosDeResultados49TableAdapter()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInfContabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCaja.SuspendLayout()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSucursal.SuspendLayout()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLocalizacion.SuspendLayout()
        Me.pnlTipoReporte.SuspendLayout()
        Me.pnlPeriodoFiscal.SuspendLayout()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSinFiltro.SuspendLayout()
        Me.pnlComprobante.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlfechas.SuspendLayout()
        Me.pnlRegistrosAsentados.SuspendLayout()
        Me.pnlFechaPeriodo.SuspendLayout()
        Me.pnlFacturasAnuladas.SuspendLayout()
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
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BALANCESUMAYSALDOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoAnteriorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HISTORICOLIBROMAYOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalanceGeneralRes173BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCalculoResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CalculoResultadoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsContaBalanceGeneral173, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsContaBalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoBalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EstadosDeResultados49BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SaldoEstadosDeResultados49BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.chbxMatricial.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Search
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(4, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.TabIndex = 460
        Me.PictureBox2.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.DimGray
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(34, 7)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(227, 30)
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
        Me.pnlFiltros.Controls.Add(Me.Panel2)
        Me.pnlFiltros.Controls.Add(Me.pnlCaja)
        Me.pnlFiltros.Controls.Add(Me.pnlSucursal)
        Me.pnlFiltros.Controls.Add(Me.pnlLocalizacion)
        Me.pnlFiltros.Controls.Add(Me.pnlTipoReporte)
        Me.pnlFiltros.Controls.Add(Me.pnlPeriodoFiscal)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Controls.Add(Me.chbxNuevaVent)
        Me.pnlFiltros.Controls.Add(Me.chbxMatricial)
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.Label20)
        Me.pnlFiltros.Controls.Add(Me.pbxCerrarFiltros)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Controls.Add(Me.pnlSinFiltro)
        Me.pnlFiltros.Controls.Add(Me.pnlComprobante)
        Me.pnlFiltros.Controls.Add(Me.pnlfechas)
        Me.pnlFiltros.Controls.Add(Me.pnlRegistrosAsentados)
        Me.pnlFiltros.Controls.Add(Me.pnlFechaPeriodo)
        Me.pnlFiltros.Controls.Add(Me.pnlFacturasAnuladas)
        Me.pnlFiltros.Location = New System.Drawing.Point(254, 1)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(560, 503)
        Me.pnlFiltros.TabIndex = 466
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.tbxBuscarPermiso)
        Me.Panel2.Controls.Add(Me.chbxTodos)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.dgvCuenta)
        Me.Panel2.Location = New System.Drawing.Point(8, 138)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(547, 248)
        Me.Panel2.TabIndex = 503
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(340, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.TabIndex = 463
        Me.PictureBox1.TabStop = False
        '
        'tbxBuscarPermiso
        '
        Me.tbxBuscarPermiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxBuscarPermiso.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxBuscarPermiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarPermiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscarPermiso.Location = New System.Drawing.Point(361, 10)
        Me.tbxBuscarPermiso.Name = "tbxBuscarPermiso"
        Me.tbxBuscarPermiso.Size = New System.Drawing.Size(181, 22)
        Me.tbxBuscarPermiso.TabIndex = 462
        '
        'chbxTodos
        '
        Me.chbxTodos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chbxTodos.AutoSize = True
        Me.chbxTodos.BackColor = System.Drawing.Color.Transparent
        Me.chbxTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.chbxTodos.ForeColor = System.Drawing.Color.Black
        Me.chbxTodos.Location = New System.Drawing.Point(212, 12)
        Me.chbxTodos.Name = "chbxTodos"
        Me.chbxTodos.Size = New System.Drawing.Size(122, 19)
        Me.chbxTodos.TabIndex = 460
        Me.chbxTodos.Text = "Selecionar Todos"
        Me.chbxTodos.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(6, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 15)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Cuentas"
        '
        'dgvCuenta
        '
        Me.dgvCuenta.AllowUserToAddRows = False
        Me.dgvCuenta.AllowUserToDeleteRows = False
        Me.dgvCuenta.AutoGenerateColumns = False
        Me.dgvCuenta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMPLANCUENTADataGridViewTextBoxColumn, Me.DESPLANCUENTADataGridViewTextBoxColumn, Me.Ver, Me.CODPLANCUENTA1, Me.TIPOCUENTADataGridViewTextBoxColumn, Me.NIVELCUENTADataGridViewTextBoxColumn, Me.ASENTABLEDataGridViewTextBoxColumn})
        Me.dgvCuenta.DataSource = Me.PlancuentasBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuenta.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCuenta.Location = New System.Drawing.Point(5, 38)
        Me.dgvCuenta.Name = "dgvCuenta"
        Me.dgvCuenta.RowHeadersVisible = False
        Me.dgvCuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuenta.Size = New System.Drawing.Size(536, 203)
        Me.dgvCuenta.TabIndex = 461
        '
        'NUMPLANCUENTADataGridViewTextBoxColumn
        '
        Me.NUMPLANCUENTADataGridViewTextBoxColumn.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTADataGridViewTextBoxColumn.HeaderText = "Cuenta Nro"
        Me.NUMPLANCUENTADataGridViewTextBoxColumn.Name = "NUMPLANCUENTADataGridViewTextBoxColumn"
        '
        'DESPLANCUENTADataGridViewTextBoxColumn
        '
        Me.DESPLANCUENTADataGridViewTextBoxColumn.DataPropertyName = "DESPLANCUENTA"
        Me.DESPLANCUENTADataGridViewTextBoxColumn.FillWeight = 220.0!
        Me.DESPLANCUENTADataGridViewTextBoxColumn.HeaderText = "Descripcion"
        Me.DESPLANCUENTADataGridViewTextBoxColumn.Name = "DESPLANCUENTADataGridViewTextBoxColumn"
        '
        'Ver
        '
        Me.Ver.FillWeight = 60.0!
        Me.Ver.HeaderText = "Seleccionar"
        Me.Ver.Name = "Ver"
        '
        'CODPLANCUENTA1
        '
        Me.CODPLANCUENTA1.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTA1.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTA1.Name = "CODPLANCUENTA1"
        Me.CODPLANCUENTA1.Visible = False
        '
        'TIPOCUENTADataGridViewTextBoxColumn
        '
        Me.TIPOCUENTADataGridViewTextBoxColumn.DataPropertyName = "TIPOCUENTA"
        Me.TIPOCUENTADataGridViewTextBoxColumn.HeaderText = "TIPOCUENTA"
        Me.TIPOCUENTADataGridViewTextBoxColumn.Name = "TIPOCUENTADataGridViewTextBoxColumn"
        Me.TIPOCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'NIVELCUENTADataGridViewTextBoxColumn
        '
        Me.NIVELCUENTADataGridViewTextBoxColumn.DataPropertyName = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.HeaderText = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.Name = "NIVELCUENTADataGridViewTextBoxColumn"
        Me.NIVELCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'ASENTABLEDataGridViewTextBoxColumn
        '
        Me.ASENTABLEDataGridViewTextBoxColumn.DataPropertyName = "ASENTABLE"
        Me.ASENTABLEDataGridViewTextBoxColumn.HeaderText = "ASENTABLE"
        Me.ASENTABLEDataGridViewTextBoxColumn.Name = "ASENTABLEDataGridViewTextBoxColumn"
        Me.ASENTABLEDataGridViewTextBoxColumn.Visible = False
        '
        'PlancuentasBindingSource
        '
        Me.PlancuentasBindingSource.DataMember = "plancuentas"
        Me.PlancuentasBindingSource.DataSource = Me.DsInfContabilidad
        '
        'DsInfContabilidad
        '
        Me.DsInfContabilidad.DataSetName = "DsInfContabilidad"
        Me.DsInfContabilidad.EnforceConstraints = False
        Me.DsInfContabilidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnlCaja
        '
        Me.pnlCaja.BackgroundImage = CType(resources.GetObject("pnlCaja.BackgroundImage"), System.Drawing.Image)
        Me.pnlCaja.Controls.Add(Me.cbxCaja)
        Me.pnlCaja.Controls.Add(Me.Label14)
        Me.pnlCaja.Location = New System.Drawing.Point(7, 307)
        Me.pnlCaja.Name = "pnlCaja"
        Me.pnlCaja.Size = New System.Drawing.Size(545, 39)
        Me.pnlCaja.TabIndex = 505
        '
        'cbxCaja
        '
        Me.cbxCaja.DataSource = Me.CAJABindingSource
        Me.cbxCaja.DisplayMember = "NUMEROCAJA"
        Me.cbxCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.cbxCaja.FormattingEnabled = True
        Me.cbxCaja.Location = New System.Drawing.Point(99, 5)
        Me.cbxCaja.Name = "cbxCaja"
        Me.cbxCaja.Size = New System.Drawing.Size(411, 33)
        Me.cbxCaja.TabIndex = 33
        Me.cbxCaja.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsCaja
        '
        'DsCaja
        '
        Me.DsCaja.DataSetName = "DsCaja"
        Me.DsCaja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(3, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 25)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Caja:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlSucursal
        '
        Me.pnlSucursal.BackgroundImage = CType(resources.GetObject("pnlSucursal.BackgroundImage"), System.Drawing.Image)
        Me.pnlSucursal.Controls.Add(Me.Label9)
        Me.pnlSucursal.Controls.Add(Me.cmbSucursal)
        Me.pnlSucursal.Location = New System.Drawing.Point(7, 35)
        Me.pnlSucursal.Name = "pnlSucursal"
        Me.pnlSucursal.Size = New System.Drawing.Size(545, 39)
        Me.pnlSucursal.TabIndex = 502
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(3, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 25)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Sucursal"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbSucursal.DataSource = Me.SUCURSALBindingSource
        Me.cmbSucursal.DisplayMember = "DESSUCURSAL"
        Me.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(98, 3)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(440, 33)
        Me.cmbSucursal.TabIndex = 1
        Me.cmbSucursal.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsInfContabilidad
        '
        'pnlLocalizacion
        '
        Me.pnlLocalizacion.BackgroundImage = CType(resources.GetObject("pnlLocalizacion.BackgroundImage"), System.Drawing.Image)
        Me.pnlLocalizacion.Controls.Add(Me.Label12)
        Me.pnlLocalizacion.Controls.Add(Me.btnBuscar)
        Me.pnlLocalizacion.Controls.Add(Me.tbxLocalizacion)
        Me.pnlLocalizacion.Location = New System.Drawing.Point(7, 339)
        Me.pnlLocalizacion.Name = "pnlLocalizacion"
        Me.pnlLocalizacion.Size = New System.Drawing.Size(545, 68)
        Me.pnlLocalizacion.TabIndex = 499
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(9, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(256, 15)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "Localizacion Donde sera Guardado el Archivo"
        '
        'btnBuscar
        '
        Me.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscar.BackColor = System.Drawing.Color.GreenYellow
        Me.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnBuscar.Location = New System.Drawing.Point(462, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 32)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'tbxLocalizacion
        '
        Me.tbxLocalizacion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxLocalizacion.BackColor = System.Drawing.Color.White
        Me.tbxLocalizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxLocalizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.tbxLocalizacion.Location = New System.Drawing.Point(6, 29)
        Me.tbxLocalizacion.Multiline = True
        Me.tbxLocalizacion.Name = "tbxLocalizacion"
        Me.tbxLocalizacion.Size = New System.Drawing.Size(449, 31)
        Me.tbxLocalizacion.TabIndex = 16
        '
        'pnlTipoReporte
        '
        Me.pnlTipoReporte.BackgroundImage = CType(resources.GetObject("pnlTipoReporte.BackgroundImage"), System.Drawing.Image)
        Me.pnlTipoReporte.Controls.Add(Me.rbtnRectificativa)
        Me.pnlTipoReporte.Controls.Add(Me.rbtnOriginal)
        Me.pnlTipoReporte.Controls.Add(Me.Label1)
        Me.pnlTipoReporte.Location = New System.Drawing.Point(7, 82)
        Me.pnlTipoReporte.Name = "pnlTipoReporte"
        Me.pnlTipoReporte.Size = New System.Drawing.Size(546, 39)
        Me.pnlTipoReporte.TabIndex = 497
        '
        'rbtnRectificativa
        '
        Me.rbtnRectificativa.AutoSize = True
        Me.rbtnRectificativa.BackColor = System.Drawing.Color.Transparent
        Me.rbtnRectificativa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnRectificativa.ForeColor = System.Drawing.Color.Black
        Me.rbtnRectificativa.Location = New System.Drawing.Point(372, 10)
        Me.rbtnRectificativa.Name = "rbtnRectificativa"
        Me.rbtnRectificativa.Size = New System.Drawing.Size(102, 21)
        Me.rbtnRectificativa.TabIndex = 32
        Me.rbtnRectificativa.Text = "Rectificativa"
        Me.rbtnRectificativa.UseVisualStyleBackColor = False
        '
        'rbtnOriginal
        '
        Me.rbtnOriginal.AutoSize = True
        Me.rbtnOriginal.BackColor = System.Drawing.Color.Transparent
        Me.rbtnOriginal.Checked = True
        Me.rbtnOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnOriginal.ForeColor = System.Drawing.Color.Black
        Me.rbtnOriginal.Location = New System.Drawing.Point(204, 10)
        Me.rbtnOriginal.Name = "rbtnOriginal"
        Me.rbtnOriginal.Size = New System.Drawing.Size(75, 21)
        Me.rbtnOriginal.TabIndex = 31
        Me.rbtnOriginal.TabStop = True
        Me.rbtnOriginal.Text = "Original"
        Me.rbtnOriginal.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(92, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 25)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Tipo de Reporte"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPeriodoFiscal
        '
        Me.pnlPeriodoFiscal.BackgroundImage = CType(resources.GetObject("pnlPeriodoFiscal.BackgroundImage"), System.Drawing.Image)
        Me.pnlPeriodoFiscal.Controls.Add(Me.Label6)
        Me.pnlPeriodoFiscal.Controls.Add(Me.cmbPeriodoFiscal)
        Me.pnlPeriodoFiscal.Location = New System.Drawing.Point(7, 35)
        Me.pnlPeriodoFiscal.Name = "pnlPeriodoFiscal"
        Me.pnlPeriodoFiscal.Size = New System.Drawing.Size(545, 39)
        Me.pnlPeriodoFiscal.TabIndex = 485
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 25)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Periodo Fiscal"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPeriodoFiscal
        '
        Me.cmbPeriodoFiscal.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbPeriodoFiscal.DataSource = Me.PeriodofiscalBindingSource
        Me.cmbPeriodoFiscal.DisplayMember = "DESEJERCICIO"
        Me.cmbPeriodoFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPeriodoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodoFiscal.FormattingEnabled = True
        Me.cmbPeriodoFiscal.Location = New System.Drawing.Point(98, 3)
        Me.cmbPeriodoFiscal.Name = "cmbPeriodoFiscal"
        Me.cmbPeriodoFiscal.Size = New System.Drawing.Size(440, 33)
        Me.cmbPeriodoFiscal.TabIndex = 1
        Me.cmbPeriodoFiscal.ValueMember = "CODPERIODOFISCAL"
        '
        'PeriodofiscalBindingSource
        '
        Me.PeriodofiscalBindingSource.DataMember = "periodofiscal"
        Me.PeriodofiscalBindingSource.DataSource = Me.DsInfContabilidad
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
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(7, 35)
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
        'pnlComprobante
        '
        Me.pnlComprobante.BackgroundImage = CType(resources.GetObject("pnlComprobante.BackgroundImage"), System.Drawing.Image)
        Me.pnlComprobante.Controls.Add(Me.PictureBox3)
        Me.pnlComprobante.Controls.Add(Me.cmbComprobante)
        Me.pnlComprobante.Controls.Add(Me.Label13)
        Me.pnlComprobante.Location = New System.Drawing.Point(7, 181)
        Me.pnlComprobante.Name = "pnlComprobante"
        Me.pnlComprobante.Size = New System.Drawing.Size(545, 39)
        Me.pnlComprobante.TabIndex = 504
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(521, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(24, 30)
        Me.PictureBox3.TabIndex = 32
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "1 = Factura " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2 = Nota de Débito " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3 = Nota de Crédito " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4 = Despacho  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5 = Auto" & _
        " factura " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7= Pasaje aéreo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8= Factura del exterior")
        '
        'cmbComprobante
        '
        Me.cmbComprobante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbComprobante.BackColor = System.Drawing.Color.White
        Me.cmbComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cmbComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.cmbComprobante.Location = New System.Drawing.Point(93, 4)
        Me.cmbComprobante.Multiline = True
        Me.cmbComprobante.Name = "cmbComprobante"
        Me.cmbComprobante.Size = New System.Drawing.Size(426, 31)
        Me.cmbComprobante.TabIndex = 31
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(3, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 25)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Comprobantes"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlfechas
        '
        Me.pnlfechas.BackgroundImage = CType(resources.GetObject("pnlfechas.BackgroundImage"), System.Drawing.Image)
        Me.pnlfechas.Controls.Add(Me.dtpFechaHasta)
        Me.pnlfechas.Controls.Add(Me.Label11)
        Me.pnlfechas.Controls.Add(Me.Label8)
        Me.pnlfechas.Controls.Add(Me.dtpFechaDesde)
        Me.pnlfechas.Location = New System.Drawing.Point(7, 225)
        Me.pnlfechas.Name = "pnlfechas"
        Me.pnlfechas.Size = New System.Drawing.Size(545, 39)
        Me.pnlfechas.TabIndex = 495
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
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
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(285, 11)
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
        Me.Label8.Location = New System.Drawing.Point(13, 11)
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
        Me.dtpFechaDesde.Location = New System.Drawing.Point(99, 6)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'pnlRegistrosAsentados
        '
        Me.pnlRegistrosAsentados.BackgroundImage = CType(resources.GetObject("pnlRegistrosAsentados.BackgroundImage"), System.Drawing.Image)
        Me.pnlRegistrosAsentados.Controls.Add(Me.rbtAsentadosNO)
        Me.pnlRegistrosAsentados.Controls.Add(Me.rbtAsentadosSI)
        Me.pnlRegistrosAsentados.Controls.Add(Me.Label5)
        Me.pnlRegistrosAsentados.Location = New System.Drawing.Point(7, 177)
        Me.pnlRegistrosAsentados.Name = "pnlRegistrosAsentados"
        Me.pnlRegistrosAsentados.Size = New System.Drawing.Size(545, 39)
        Me.pnlRegistrosAsentados.TabIndex = 501
        '
        'rbtAsentadosNO
        '
        Me.rbtAsentadosNO.AutoSize = True
        Me.rbtAsentadosNO.BackColor = System.Drawing.Color.Transparent
        Me.rbtAsentadosNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtAsentadosNO.Location = New System.Drawing.Point(372, 10)
        Me.rbtAsentadosNO.Name = "rbtAsentadosNO"
        Me.rbtAsentadosNO.Size = New System.Drawing.Size(44, 21)
        Me.rbtAsentadosNO.TabIndex = 32
        Me.rbtAsentadosNO.Text = "No"
        Me.rbtAsentadosNO.UseVisualStyleBackColor = False
        '
        'rbtAsentadosSI
        '
        Me.rbtAsentadosSI.AutoSize = True
        Me.rbtAsentadosSI.BackColor = System.Drawing.Color.Transparent
        Me.rbtAsentadosSI.Checked = True
        Me.rbtAsentadosSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtAsentadosSI.Location = New System.Drawing.Point(204, 10)
        Me.rbtAsentadosSI.Name = "rbtAsentadosSI"
        Me.rbtAsentadosSI.Size = New System.Drawing.Size(38, 21)
        Me.rbtAsentadosSI.TabIndex = 31
        Me.rbtAsentadosSI.TabStop = True
        Me.rbtAsentadosSI.Text = "Si"
        Me.rbtAsentadosSI.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(10, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(177, 25)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Datos con Registros Acentados"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlFechaPeriodo
        '
        Me.pnlFechaPeriodo.BackgroundImage = CType(resources.GetObject("pnlFechaPeriodo.BackgroundImage"), System.Drawing.Image)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbHasta)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbDesde)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbAño)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbMes)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label23)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label19)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label4)
        Me.pnlFechaPeriodo.Controls.Add(Me.Mes)
        Me.pnlFechaPeriodo.Location = New System.Drawing.Point(7, 274)
        Me.pnlFechaPeriodo.Name = "pnlFechaPeriodo"
        Me.pnlFechaPeriodo.Size = New System.Drawing.Size(545, 54)
        Me.pnlFechaPeriodo.TabIndex = 496
        '
        'cmbHasta
        '
        Me.cmbHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbHasta.FormattingEnabled = True
        Me.cmbHasta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbHasta.Location = New System.Drawing.Point(465, 21)
        Me.cmbHasta.Name = "cmbHasta"
        Me.cmbHasta.Size = New System.Drawing.Size(45, 28)
        Me.cmbHasta.TabIndex = 4
        '
        'cmbDesde
        '
        Me.cmbDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbDesde.FormattingEnabled = True
        Me.cmbDesde.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbDesde.Location = New System.Drawing.Point(394, 21)
        Me.cmbDesde.Name = "cmbDesde"
        Me.cmbDesde.Size = New System.Drawing.Size(45, 28)
        Me.cmbDesde.TabIndex = 5
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997", "1998", "1999", "2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAño.Location = New System.Drawing.Point(171, 21)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(138, 28)
        Me.cmbAño.TabIndex = 2
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.White
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(17, 21)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(138, 28)
        Me.cmbMes.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(462, 3)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 15)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Hasta"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label19.Location = New System.Drawing.Point(391, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 15)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Desde"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(170, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Año"
        '
        'Mes
        '
        Me.Mes.AutoSize = True
        Me.Mes.BackColor = System.Drawing.Color.Transparent
        Me.Mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mes.Location = New System.Drawing.Point(14, 3)
        Me.Mes.Name = "Mes"
        Me.Mes.Size = New System.Drawing.Size(31, 15)
        Me.Mes.TabIndex = 7
        Me.Mes.Text = "Mes"
        '
        'pnlFacturasAnuladas
        '
        Me.pnlFacturasAnuladas.BackgroundImage = CType(resources.GetObject("pnlFacturasAnuladas.BackgroundImage"), System.Drawing.Image)
        Me.pnlFacturasAnuladas.Controls.Add(Me.rbnAnuladasNO)
        Me.pnlFacturasAnuladas.Controls.Add(Me.rbnAnuladasSI)
        Me.pnlFacturasAnuladas.Controls.Add(Me.Label3)
        Me.pnlFacturasAnuladas.Location = New System.Drawing.Point(7, 130)
        Me.pnlFacturasAnuladas.Name = "pnlFacturasAnuladas"
        Me.pnlFacturasAnuladas.Size = New System.Drawing.Size(545, 39)
        Me.pnlFacturasAnuladas.TabIndex = 500
        '
        'rbnAnuladasNO
        '
        Me.rbnAnuladasNO.AutoSize = True
        Me.rbnAnuladasNO.BackColor = System.Drawing.Color.Transparent
        Me.rbnAnuladasNO.Checked = True
        Me.rbnAnuladasNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbnAnuladasNO.Location = New System.Drawing.Point(372, 10)
        Me.rbnAnuladasNO.Name = "rbnAnuladasNO"
        Me.rbnAnuladasNO.Size = New System.Drawing.Size(44, 21)
        Me.rbnAnuladasNO.TabIndex = 32
        Me.rbnAnuladasNO.TabStop = True
        Me.rbnAnuladasNO.Text = "No"
        Me.rbnAnuladasNO.UseVisualStyleBackColor = False
        '
        'rbnAnuladasSI
        '
        Me.rbnAnuladasSI.AutoSize = True
        Me.rbnAnuladasSI.BackColor = System.Drawing.Color.Transparent
        Me.rbnAnuladasSI.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbnAnuladasSI.Location = New System.Drawing.Point(204, 10)
        Me.rbnAnuladasSI.Name = "rbnAnuladasSI"
        Me.rbnAnuladasSI.Size = New System.Drawing.Size(38, 21)
        Me.rbnAnuladasSI.TabIndex = 31
        Me.rbnAnuladasSI.Text = "Si"
        Me.rbnAnuladasSI.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(43, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 25)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Incluir Facturas Anuladas"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.ProductosGridView.ColumnHeadersHeight = 30
        Me.ProductosGridView.Location = New System.Drawing.Point(10, 55)
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.Size = New System.Drawing.Size(548, 461)
        Me.ProductosGridView.TabIndex = 378
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
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).ZIndex = 777
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListaReportes.ColumnHeadersHeight = 35
        Me.dgvListaReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TITULO, Me.REFERENCIA, Me.PALABRASCLAVE})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListaReportes.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvListaReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListaReportes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvListaReportes.Location = New System.Drawing.Point(0, 0)
        Me.dgvListaReportes.MultiSelect = False
        Me.dgvListaReportes.Name = "dgvListaReportes"
        Me.dgvListaReportes.ReadOnly = True
        Me.dgvListaReportes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
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
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlFiltros)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CrystalReportViewer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1079, 655)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 491
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
        'DsRVFacturacion
        '
        Me.DsRVFacturacion.DataSetName = "DsRVFacturacion"
        Me.DsRVFacturacion.EnforceConstraints = False
        Me.DsRVFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvTipoComprobanteTableAdapter
        '
        Me.RvTipoComprobanteTableAdapter.ClearBeforeFill = True
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'CAJABindingSource1
        '
        Me.CAJABindingSource1.DataMember = "CAJA"
        Me.CAJABindingSource1.DataSource = Me.DsCaja
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'PlanCuentasRepTableAdapter
        '
        Me.PlanCuentasRepTableAdapter.ClearBeforeFill = True
        '
        'BalanceGeneralTableAdapter
        '
        Me.BalanceGeneralTableAdapter.ClearBeforeFill = True
        '
        'BalanceSaldoTableAdapter
        '
        Me.BalanceSaldoTableAdapter.ClearBeforeFill = True
        '
        'BalanceSumaTableAdapter
        '
        Me.BalanceSumaTableAdapter.ClearBeforeFill = True
        '
        'CuadroResultadosTableAdapter
        '
        Me.CuadroResultadosTableAdapter.ClearBeforeFill = True
        '
        'LibroIvaVentasTableAdapter
        '
        Me.LibroIvaVentasTableAdapter.ClearBeforeFill = True
        '
        'LibroIvaComprasTableAdapter
        '
        Me.LibroIvaComprasTableAdapter.ClearBeforeFill = True
        '
        'BALANCESUMAYSALDOBindingSource
        '
        Me.BALANCESUMAYSALDOBindingSource.DataSource = Me.DsInfContabilidad
        Me.BALANCESUMAYSALDOBindingSource.Position = 0
        '
        'BALANCESUMAYSALDOTableAdapter
        '
        Me.BALANCESUMAYSALDOTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.periodofiscalTableAdapter = Nothing
        Me.TableAdapterManager.PlanCuentasRepTableAdapter = Nothing
        Me.TableAdapterManager.plancuentasTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsInfContabilidadTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PlancuentasTableAdapter
        '
        Me.PlancuentasTableAdapter.ClearBeforeFill = True
        '
        'SaldoAnteriorBindingSource
        '
        Me.SaldoAnteriorBindingSource.DataMember = "SaldoAnterior"
        Me.SaldoAnteriorBindingSource.DataSource = Me.DsInfContabilidad
        '
        'SaldoAnteriorTableAdapter
        '
        Me.SaldoAnteriorTableAdapter.ClearBeforeFill = True
        '
        'HISTORICOLIBROMAYOBindingSource
        '
        Me.HISTORICOLIBROMAYOBindingSource.DataMember = "HISTORICOLIBROMAYO"
        Me.HISTORICOLIBROMAYOBindingSource.DataSource = Me.DsInfContabilidad
        '
        'HISTORICOLIBROMAYOTableAdapter
        '
        Me.HISTORICOLIBROMAYOTableAdapter.ClearBeforeFill = True
        '
        'LibrioDiarioTableAdapter
        '
        Me.LibrioDiarioTableAdapter.ClearBeforeFill = True
        '
        'LibroIvaTicketTableAdapter
        '
        Me.LibroIvaTicketTableAdapter.ClearBeforeFill = True
        '
        'RetencionesIVATableAdapter
        '
        Me.RetencionesIVATableAdapter.ClearBeforeFill = True
        '
        'RetencionrentaTableAdapter
        '
        Me.RetencionrentaTableAdapter.ClearBeforeFill = True
        '
        'RetencionesRentaTableAdapter
        '
        Me.RetencionesRentaTableAdapter.ClearBeforeFill = True
        '
        'BalanceGeneralRes173BindingSource
        '
        Me.BalanceGeneralRes173BindingSource.DataMember = "BalanceGeneralRes173"
        Me.BalanceGeneralRes173BindingSource.DataSource = Me.DsInfContabilidad
        '
        'BalanceGeneralRes173TableAdapter1
        '
        Me.BalanceGeneralRes173TableAdapter1.ClearBeforeFill = True
        '
        'DsCalculoResultado
        '
        Me.DsCalculoResultado.DataSetName = "DsCalculoResultado"
        Me.DsCalculoResultado.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CalculoResultadoBindingSource
        '
        Me.CalculoResultadoBindingSource.DataMember = "CalculoResultado"
        Me.CalculoResultadoBindingSource.DataSource = Me.DsCalculoResultado
        '
        'CalculoResultadoTableAdapter
        '
        Me.CalculoResultadoTableAdapter.ClearBeforeFill = True
        '
        'DsContaBalanceGeneral173
        '
        Me.DsContaBalanceGeneral173.DataSetName = "DsContaBalanceGeneral173"
        Me.DsContaBalanceGeneral173.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsContaBalanceGeneral173BindingSource
        '
        Me.DsContaBalanceGeneral173BindingSource.DataSource = Me.DsContaBalanceGeneral173
        Me.DsContaBalanceGeneral173BindingSource.Position = 0
        '
        'BalanceGeneral173BindingSource
        '
        Me.BalanceGeneral173BindingSource.DataMember = "BalanceGeneral173"
        Me.BalanceGeneral173BindingSource.DataSource = Me.DsContaBalanceGeneral173BindingSource
        '
        'BalanceGeneral173TableAdapter
        '
        Me.BalanceGeneral173TableAdapter.ClearBeforeFill = True
        '
        'SaldoBalanceGeneral173BindingSource
        '
        Me.SaldoBalanceGeneral173BindingSource.DataMember = "SaldoBalanceGeneral173"
        Me.SaldoBalanceGeneral173BindingSource.DataSource = Me.DsContaBalanceGeneral173
        '
        'SaldoBalanceGeneral173TableAdapter
        '
        Me.SaldoBalanceGeneral173TableAdapter.ClearBeforeFill = True
        '
        'EstadosDeResultados49BindingSource
        '
        Me.EstadosDeResultados49BindingSource.DataMember = "EstadosDeResultados49"
        Me.EstadosDeResultados49BindingSource.DataSource = Me.DsContaBalanceGeneral173BindingSource
        '
        'EstadosDeResultados49TableAdapter
        '
        Me.EstadosDeResultados49TableAdapter.ClearBeforeFill = True
        '
        'SaldoEstadosDeResultados49BindingSource
        '
        Me.SaldoEstadosDeResultados49BindingSource.DataMember = "SaldoEstadosDeResultados49"
        Me.SaldoEstadosDeResultados49BindingSource.DataSource = Me.DsContaBalanceGeneral173BindingSource
        '
        'SaldoEstadosDeResultados49TableAdapter
        '
        Me.SaldoEstadosDeResultados49TableAdapter.ClearBeforeFill = True
        '
        'FiltroReporteContabilidad
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
        Me.Controls.Add(Me.ProductosGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(5000, 900)
        Me.MinimumSize = New System.Drawing.Size(863, 676)
        Me.Name = "FiltroReporteContabilidad"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Contabilidad  | Cogent SIG"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInfContabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCaja.ResumeLayout(False)
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSucursal.ResumeLayout(False)
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLocalizacion.ResumeLayout(False)
        Me.pnlLocalizacion.PerformLayout()
        Me.pnlTipoReporte.ResumeLayout(False)
        Me.pnlTipoReporte.PerformLayout()
        Me.pnlPeriodoFiscal.ResumeLayout(False)
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        Me.pnlComprobante.ResumeLayout(False)
        Me.pnlComprobante.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlfechas.ResumeLayout(False)
        Me.pnlRegistrosAsentados.ResumeLayout(False)
        Me.pnlRegistrosAsentados.PerformLayout()
        Me.pnlFechaPeriodo.ResumeLayout(False)
        Me.pnlFechaPeriodo.PerformLayout()
        Me.pnlFacturasAnuladas.ResumeLayout(False)
        Me.pnlFacturasAnuladas.PerformLayout()
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
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BALANCESUMAYSALDOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoAnteriorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HISTORICOLIBROMAYOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalanceGeneralRes173BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCalculoResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CalculoResultadoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsContaBalanceGeneral173, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsContaBalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoBalanceGeneral173BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EstadosDeResultados49BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SaldoEstadosDeResultados49BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pnlPeriodoFiscal As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodoFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents pnlTipoReporte As System.Windows.Forms.Panel
    Friend WithEvents rbtnRectificativa As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnOriginal As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlFechaPeriodo As System.Windows.Forms.Panel
    Friend WithEvents cmbHasta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesde As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Mes As System.Windows.Forms.Label
    Friend WithEvents pnlfechas As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlLocalizacion As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents tbxLocalizacion As System.Windows.Forms.TextBox
    Friend WithEvents DsInfContabilidad As ContaExpress.DsInfContabilidad
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.periodofiscalTableAdapter
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents pnlRegistrosAsentados As System.Windows.Forms.Panel
    Friend WithEvents rbtAsentadosNO As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAsentadosSI As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlFacturasAnuladas As System.Windows.Forms.Panel
    Friend WithEvents rbnAnuladasNO As System.Windows.Forms.RadioButton
    Friend WithEvents rbnAnuladasSI As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlSucursal As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.SUCURSALTableAdapter
    Friend WithEvents PlanCuentasRepTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.PlanCuentasRepTableAdapter
    Friend WithEvents BalanceGeneralTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.BalanceGeneralTableAdapter
    Friend WithEvents BalanceGeneralRes173TableAdapter As ContaExpress.DsInfContabilidadTableAdapters.BalanceGeneralRes173TableAdapter1
    Friend WithEvents BalanceSaldoTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.BalanceSaldoTableAdapter
    Friend WithEvents BalanceSumaTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.BalanceSumaTableAdapter
    Friend WithEvents CuadroResultadosTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.CuadroResultadosTableAdapter
    Friend WithEvents LibroIvaVentasTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.LibroIvaVentasTableAdapter
    Friend WithEvents LibroIvaComprasTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.LibroIvaComprasTableAdapter
    Friend WithEvents BALANCESUMAYSALDOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BALANCESUMAYSALDOTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.BALANCESUMAYSALDOTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsInfContabilidadTableAdapters.TableAdapterManager
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxBuscarPermiso As System.Windows.Forms.TextBox
    Friend WithEvents dgvCuenta As System.Windows.Forms.DataGridView
    Friend WithEvents chbxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents PlancuentasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlancuentasTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.plancuentasTableAdapter
    Friend WithEvents SaldoAnteriorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaldoAnteriorTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.SaldoAnteriorTableAdapter
    Friend WithEvents btnFiltros As System.Windows.Forms.Button
    Friend WithEvents NUMPLANCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPLANCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ver As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CODPLANCUENTA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVELCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASENTABLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HISTORICOLIBROMAYOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HISTORICOLIBROMAYOTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.HISTORICOLIBROMAYOTableAdapter
    Friend WithEvents LibrioDiarioTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.LibrioDiarioTableAdapter
    Friend WithEvents pnlComprobante As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DsRVFacturacion As ContaExpress.DsRVFacturacion
    Friend WithEvents RvTipoComprobanteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVTipoComprobanteTableAdapter
    Friend WithEvents cmbComprobante As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LibroIvaTicketTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.LibroIvaTicketTableAdapter
    Friend WithEvents pnlCaja As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxCaja As System.Windows.Forms.ComboBox
    Friend WithEvents DsCaja As ContaExpress.DsCaja
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsCajaTableAdapters.CAJATableAdapter
    Friend WithEvents CAJABindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents RetencionesIVATableAdapter As ContaExpress.DsInfContabilidadTableAdapters.RetencionesIVATableAdapter
    Friend WithEvents RetencionrentaTableAdapter As ContaExpress.DsPagosFacutasTableAdapters.RETENCIONRENTATableAdapter
    Friend WithEvents RetencionesRentaTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.RetencionesRentaTableAdapter
    Friend WithEvents BalanceGeneralRes173BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BalanceGeneralRes173TableAdapter1 As ContaExpress.DsInfContabilidadTableAdapters.BalanceGeneralRes173TableAdapter1
    Friend WithEvents DsCalculoResultado As ContaExpress.DsCalculoResultado
    Friend WithEvents CalculoResultadoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CalculoResultadoTableAdapter As ContaExpress.DsCalculoResultadoTableAdapters.CalculoResultadoTableAdapter
    Friend WithEvents DsContaBalanceGeneral173 As ContaExpress.DsContaBalanceGeneral173
    Friend WithEvents DsContaBalanceGeneral173BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BalanceGeneral173BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BalanceGeneral173TableAdapter As ContaExpress.DsContaBalanceGeneral173TableAdapters.BalanceGeneral173TableAdapter
    Friend WithEvents SaldoBalanceGeneral173BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaldoBalanceGeneral173TableAdapter As ContaExpress.DsContaBalanceGeneral173TableAdapters.SaldoBalanceGeneral173TableAdapter
    Friend WithEvents EstadosDeResultados49BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EstadosDeResultados49TableAdapter As ContaExpress.DsContaBalanceGeneral173TableAdapters.EstadosDeResultados49TableAdapter
    Friend WithEvents SaldoEstadosDeResultados49BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SaldoEstadosDeResultados49TableAdapter As ContaExpress.DsContaBalanceGeneral173TableAdapters.SaldoEstadosDeResultados49TableAdapter
End Class
