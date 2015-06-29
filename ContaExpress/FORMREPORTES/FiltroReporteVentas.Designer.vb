<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroReporteVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroReporteVentas))
        Dim CheckBoxProperties1 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties2 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties3 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties4 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties5 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties6 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties7 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties8 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties9 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties10 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
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
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.ProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRVFacturacion = New ContaExpress.DsRVFacturacion()
        Me.cbxRubro = New System.Windows.Forms.ComboBox()
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsReporteVentas = New ContaExpress.DsReporteVentas()
        Me.cbxLinea = New System.Windows.Forms.ComboBox()
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCategoria = New System.Windows.Forms.ComboBox()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTipoComp = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.ZONABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbCiudad = New System.Windows.Forms.ComboBox()
        Me.CIUDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblPos1 = New System.Windows.Forms.Label()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAyudaCodProd = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblPos3 = New System.Windows.Forms.Label()
        Me.lblPos4 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.EventLog1 = New System.Diagnostics.EventLog()
        Me.chbxMatricial = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.BtnAsteriscoCliente = New System.Windows.Forms.PictureBox()
        Me.pbxRangoCli = New System.Windows.Forms.PictureBox()
        Me.chbxCodCliente = New System.Windows.Forms.CheckBox()
        Me.tbxcodCliente = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbxNuevaVent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pbxCerrarFiltros = New System.Windows.Forms.PictureBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.pnlOtrasOpciones = New System.Windows.Forms.Panel()
        Me.rbSinAgrup = New System.Windows.Forms.RadioButton()
        Me.rbAgrupFamillia = New System.Windows.Forms.RadioButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.pnlCuenta = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlTipo = New System.Windows.Forms.Panel()
        Me.cmbTipo = New PresentationControls.CheckBoxComboBox()
        Me.pnlSucursal = New System.Windows.Forms.Panel()
        Me.cmbSucursal = New PresentationControls.CheckBoxComboBox()
        Me.lblPos7 = New System.Windows.Forms.Label()
        Me.pnlListaPrecio = New System.Windows.Forms.Panel()
        Me.cmbListaPrecio = New PresentationControls.CheckBoxComboBox()
        Me.pnlRelacionado = New System.Windows.Forms.Panel()
        Me.cmbRelacionado = New PresentationControls.CheckBoxComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlCategCliente = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCategCliente = New PresentationControls.CheckBoxComboBox()
        Me.pnlIVA = New System.Windows.Forms.Panel()
        Me.rbIVANO = New System.Windows.Forms.RadioButton()
        Me.rbIVASI = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlFactCobr = New System.Windows.Forms.Panel()
        Me.rbPorCobr = New System.Windows.Forms.RadioButton()
        Me.rbPorFact = New System.Windows.Forms.RadioButton()
        Me.pnlNumFactura = New System.Windows.Forms.Panel()
        Me.txtNumVenta = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pnlTipoCobro = New System.Windows.Forms.Panel()
        Me.cmbTipoCobro = New System.Windows.Forms.ComboBox()
        Me.TIPOFORMACOBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.pnlEstado = New System.Windows.Forms.Panel()
        Me.cmbEstado = New PresentationControls.CheckBoxComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.pbxRangoProd = New System.Windows.Forms.PictureBox()
        Me.lblPos5 = New System.Windows.Forms.Label()
        Me.chbxCodProducto = New System.Windows.Forms.CheckBox()
        Me.BtnAsteriscoProducto = New System.Windows.Forms.PictureBox()
        Me.tbxcodProd = New System.Windows.Forms.TextBox()
        Me.pnlVendedor = New System.Windows.Forms.Panel()
        Me.cmbVendedor = New PresentationControls.CheckBoxComboBox()
        Me.pnlComprobante = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbComprobante = New PresentationControls.CheckBoxComboBox()
        Me.pnlMoneda = New System.Windows.Forms.Panel()
        Me.lblPos6 = New System.Windows.Forms.Label()
        Me.pnlfechas = New System.Windows.Forms.Panel()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.pnlIngresoStock = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbIngresoStock = New PresentationControls.CheckBoxComboBox()
        Me.pnlCategorias = New System.Windows.Forms.Panel()
        Me.pnlVisualizardatos = New System.Windows.Forms.Panel()
        Me.rbtSinNumFac = New System.Windows.Forms.RadioButton()
        Me.rbtConNroFac = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.pnlDetalleEnvio = New System.Windows.Forms.Panel()
        Me.rbtSinDetalleProducto = New System.Windows.Forms.RadioButton()
        Me.rbtConDetalleProducto = New System.Windows.Forms.RadioButton()
        Me.pnlAnulados = New System.Windows.Forms.Panel()
        Me.rbtsinanuladas = New System.Windows.Forms.RadioButton()
        Me.rbtConanuladas = New System.Windows.Forms.RadioButton()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.pnlVisualizar = New System.Windows.Forms.Panel()
        Me.rbtConGrafico = New System.Windows.Forms.RadioButton()
        Me.rbtSinGrafico = New System.Windows.Forms.RadioButton()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.pnlIntervalo = New System.Windows.Forms.Panel()
        Me.rbtnAño = New System.Windows.Forms.RadioButton()
        Me.rbtnSemestre = New System.Windows.Forms.RadioButton()
        Me.rbtnMes = New System.Windows.Forms.RadioButton()
        Me.rbtnQuincena = New System.Windows.Forms.RadioButton()
        Me.rbtnSemana = New System.Windows.Forms.RadioButton()
        Me.rbtDia = New System.Windows.Forms.RadioButton()
        Me.rbtnHora = New System.Windows.Forms.RadioButton()
        Me.pnlIntervaloActivo = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlLocalidad = New System.Windows.Forms.Panel()
        Me.cmbZona1 = New PresentationControls.CheckBoxComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.VentasTipoPagoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRVEstadisticas = New ContaExpress.DsRVEstadisticas()
        Me.btnFiltros = New System.Windows.Forms.Button()
        Me.GroupBoxCliente = New Telerik.WinControls.UI.RadGroupBox()
        Me.GridViewClientes = New System.Windows.Forms.DataGridView()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCLIENTE1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREFANTASIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtBuscaCliente = New System.Windows.Forms.TextBox()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ttipNumCliente = New System.Windows.Forms.ToolTip(Me.components)
        Me.ttipCodProducto = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DsCategorizacion = New ContaExpress.DsCategorizacion()
        Me.DsRVEnvios = New ContaExpress.DsRVEnvios()
        Me.RvEnviosPorZonaProductoTableAdapter = New ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorZonaProductoTableAdapter()
        Me.RvEnviosPorClienteTableAdapter = New ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorClienteTableAdapter()
        Me.RvEnviosPorClienteProductoTableAdapter = New ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorClienteProductoTableAdapter()
        Me.RvCobrosClientesTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesTableAdapter()
        Me.RvCobrosClientesTableAdapter1 = New ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesTableAdapter()
        Me.DsRVCobros = New ContaExpress.DsRVCobros()
        Me.RvFacturasXReciboTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVFacturasXReciboTableAdapter()
        Me.RvPendientesCobroTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVPendientesCobroTableAdapter()
        Me.RvchdiF_NCREDTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVCHDIF_NCREDTableAdapter()
        Me.RvPendienteCobroDifTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVPendienteCobroDifTableAdapter()
        Me.RvRankingClientesTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVRankingClientesTableAdapter()
        Me.RvRankingProductosTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVRankingProductosTableAdapter()
        Me.RvVentasCompletoTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVVentasCompletoTableAdapter()
        Me.DsRVCaja = New ContaExpress.DsRVCaja()
        Me.RvDiarioCajaTableAdapter = New ContaExpress.DsRVCajaTableAdapters.RVDiarioCajaTableAdapter()
        Me.RvTotalTableAdapter = New ContaExpress.DsRVCajaTableAdapters.RVTotalTableAdapter()
        Me.RvCajaIvaTableAdapter = New ContaExpress.DsRVCajaTableAdapters.RVCajaIvaTableAdapter()
        Me.RvAperturaCierreTableAdapter = New ContaExpress.DsRVCajaTableAdapters.RVAperturaCierreTableAdapter()
        Me.RvComprobantesPorProductoResumTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVComprobantesPorProductoResumTableAdapter()
        Me.DsRVComprobantes = New ContaExpress.DsRVComprobantes()
        Me.RvcclientesTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVCCLIENTESTableAdapter()
        Me.RvVentasPorProductoComparativoMesAnhoTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPorProductoComparativoMesAnhoTableAdapter()
        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPorClienteComparativoMesAnhoTableAdapter()
        Me.DsSettingFO = New ContaExpress.DsSettingFO()
        Me.RVIVADetalladoTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVIVADETALLADOTableAdapter()
        Me.RvCobrosClientesNCTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesNCTableAdapter()
        Me.DsRVComisiones = New ContaExpress.DsRVComisiones()
        Me.ComisionVendedorTableAdapter = New ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobranzaTableAdapter()
        Me.ComisionVendedorFacturacionTableAdapter = New ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorFacturacionTableAdapter()
        Me.ComisionVendedorCobrDetTableAdapter = New ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobrDetTableAdapter()
        Me.RvVentasPorZONATableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVVentasPorZONATableAdapter()
        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPrecioVentaVsCostoPorProductoTableAdapter()
        Me.RvComprobantesPorProductoPorFechaTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVComprobantesPorProductoPorFechaTableAdapter()
        Me.RvNotasCreditoPendienteTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVNotasCreditoPendienteTableAdapter()
        Me.RvComprPorVendPorProductoTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVComprPorVendPorProductoTableAdapter()
        Me.RvClientesAtrasadosTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVCLIENTESATRASADOSTableAdapter()
        Me.RvFacturasACobrarTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVFACTURASACOBRARTableAdapter()
        Me.RvRecibosClienteDetTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVRecibosClienteDetTableAdapter()
        Me.RVAnalisisDeSaldoTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.RVANALISISDESALDOTableAdapter()
        Me.RvComprobantePorProductoPorClienteTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVComprobantePorProductoPorClienteTableAdapter()
        Me.DsRVNotasCredito = New ContaExpress.DsRVNotasCredito()
        Me.RvNotasDeCreditoTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVNotasDeCreditoTableAdapter()
        Me.RvNotasDeCreditoPorProdTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVNotasDeCreditoPorProdTableAdapter()
        Me.RvncclientesTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVNCCLIENTESTableAdapter()
        Me.RvivancventasTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVIVANCVENTASTableAdapter()
        Me.RvncPorProductoResumTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVNCPorProductoResumTableAdapter()
        Me.RvincidenciancsobrevtaTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVINCIDENCIANCSOBREVTATableAdapter()
        Me.RVVentasPorZonatipoTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVVENTASPORZONATIPOTableAdapter()
        Me.RVVentasPorZonaPromedioTableAdapter = New ContaExpress.DsRVComprobantesTableAdapters.RVVENTASPORZONAPROMEDIOTableAdapter()
        Me.ComisionVendedorCobranzaTipoVentaTableAdapter = New ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobranzaTipoVentaTableAdapter()
        Me.CODIGOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENDEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPOCLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VentasProductoDetallladoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasProductoDetallladoTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsReporteVentasTableAdapters.TableAdapterManager()
        Me.VentasPorTipoPagoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasPorTipoPagoTableAdapter()
        Me.VentasPorVendedorTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasPorVendedorTableAdapter()
        Me.ListaClientesTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.ListaClientesTableAdapter()
        Me.VentasProductosMasVendidosTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasProductosMasVendidosTableAdapter()
        Me.FacturaACobrarTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.FacturaACobrarTableAdapter()
        Me.PedidoPendientePorZonaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PedidoPendientePorZonaTableAdapter()
        Me.PedidoPendientePorClienteTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PedidoPendientePorClienteTableAdapter()
        Me.DiarioCajaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.DiarioCajaTableAdapter()
        Me.EnvioPorZonaArticuloTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.EnvioPorZonaArticuloTableAdapter()
        Me.CategoriasMasVendidasTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CategoriasMasVendidasTableAdapter()
        Me.VentaProductoFechaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentaProductoFechaTableAdapter()
        Me.CategoriasPorMesTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CategoriasPorMesTableAdapter()
        Me.VentasPorSucursalTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasPorSucursalTableAdapter()
        Me.VentasPorTipoClienteTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasPorTipoClienteTableAdapter()
        Me.GastosPorProductoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.GastosPorProductoTableAdapter()
        Me.IngresosPorProductoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.IngresosPorProductoTableAdapter()
        Me.GastosUltimaCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.GastosUltimaCompraTableAdapter()
        Me.StockTotaldeProductosTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.StockTotaldeProductosTableAdapter()
        Me.VentaMovimientoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentaMovimientoTableAdapter()
        Me.CostoFijoCantidadVentaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CostoFijoCantidadVentaTableAdapter()
        Me.CostoFijoSumaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CostoFijoSumaTableAdapter()
        Me.CostoFijoDesglosadoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CostoFijoDesglosadoTableAdapter()
        Me.CantidadVentaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CantidadVentaTableAdapter()
        Me.VentasListaPrecioTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasListaPrecioTableAdapter()
        Me.STOCKDEPOSITOTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.STOCKDEPOSITOTableAdapter()
        Me.VENTASDETALLETableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VENTASDETALLETableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.MONEDATableAdapter()
        Me.CAJATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CAJATableAdapter()
        Me.TIPOCLIENTETableAdapter = New ContaExpress.DsReporteVentasTableAdapters.TIPOCLIENTETableAdapter()
        Me.PAISTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PAISTableAdapter()
        Me.CIUDADTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CIUDADTableAdapter()
        Me.ZONATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.ZONATableAdapter()
        Me.CLIENTESTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CLIENTESTableAdapter()
        Me.VENDEDORTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VENDEDORTableAdapter()
        Me.FAMILIATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.FAMILIATableAdapter()
        Me.LINEATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.LINEATableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.RUBROTableAdapter()
        Me.CODIGOSTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CODIGOSTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.SUCURSALTableAdapter()
        Me.VentasResumenTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasResumenTableAdapter()
        Me.VentasDetalladoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasDetalladoTableAdapter()
        Me.PRODUCTOSLISTAPRECIOTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PRODUCTOSLISTAPRECIOTableAdapter()
        Me.UtilidadClienteCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.UtilidadClienteCompraTableAdapter()
        Me.UtilidadClienteVentasTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.UtilidadClienteVentasTableAdapter()
        Me.PromedioCantidadCompradaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PromedioCantidadCompradaTableAdapter()
        Me.PromedioGs_CompradoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PromedioGs_CompradoTableAdapter()
        Me.AperturasCajaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.AperturasCajaTableAdapter()
        Me.CierreCajaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CierreCajaTableAdapter()
        Me.VENTASFORMACOBROTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VENTASFORMACOBROTableAdapter()
        Me.AjusteTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.AjusteTableAdapter()
        Me.VentasIvaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.VentasIvaTableAdapter()
        Me.PRODUCTOSMENOSVENDIDOSTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PRODUCTOSMENOSVENDIDOSTableAdapter()
        Me.DiasDesdeUltimaVentaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.DiasDesdeUltimaVentaTableAdapter()
        Me.DiasUltimaCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.DiasUltimaCompraTableAdapter()
        Me.CantidadUltimaCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.CantidadUltimaCompraTableAdapter()
        Me.StockUltimaCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.StockUltimaCompraTableAdapter()
        Me.UltimaCompraDiasTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.UltimaCompraDiasTableAdapter()
        Me.TotalMovimientosVentaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.TotalMovimientosVentaTableAdapter()
        Me.AperturaCierreTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.AperturaCierreTableAdapter()
        Me.IVATableAdapter = New ContaExpress.DsReporteVentasTableAdapters.IVATableAdapter()
        Me.AjusteEntradaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.AjusteEntradaTableAdapter()
        Me.AjusteSalidaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.AjusteSalidaTableAdapter()
        Me.TotalMovimientosCompraTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.TotalMovimientosCompraTableAdapter()
        Me.CategoriaClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RventascategoriaclienteTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.RVENTASCATEGORIACLIENTETableAdapter()
        Me.ListaClientesporlistaPrecioTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.ListaClientesporlistaPrecioTableAdapter()
        Me.NotaCreditoDetalladoTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.NotaCreditoDetalladoTableAdapter()
        Me.LibroVentasLeyTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.LibroVentasLeyTableAdapter()
        Me.PorcentajedeventaTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.PorcentajedeventaTableAdapter()
        Me.ListadereciboTableAdapter = New ContaExpress.DsReporteVentasTableAdapters.ListadereciboTableAdapter()
        Me.RvnclibroivaTableAdapter = New ContaExpress.DsRVNotasCreditoTableAdapters.RVNCLIBROIVATableAdapter()
        Me.RVTipoComprobanteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RvPendientePorZonaClienteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorZonaClienteTableAdapter()
        Me.RvPendientePorZonaProductoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorZonaProductoTableAdapter()
        Me.RvPendientePorClienteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorClienteTableAdapter()
        Me.RVTipoComprobanteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVTipoComprobanteTableAdapter()
        Me.RvComprobantesTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesTableAdapter()
        Me.RvVentasPorVendedorTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVVentasPorVendedorTableAdapter()
        Me.RVProductosTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVProductosTableAdapter()
        Me.RvclientesTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVCLIENTESTableAdapter()
        Me.RvPendientePorClienteProductoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorClienteProductoTableAdapter()
        Me.RvVentasResumenTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVVentasResumenTableAdapter()
        Me.RvMovimientosClienteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVMovimientosClienteTableAdapter()
        Me.RvComprobantesResumidoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesResumidoTableAdapter()
        Me.RvComprobantesAgrupCliTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesAgrupCliTableAdapter()
        Me.RvventasporclientesTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVVENTASPORCLIENTESTableAdapter()
        Me.RvListaPresupuestoTableAdapter1 = New ContaExpress.DsRVFacturacionTableAdapters.RVListaPresupuestoTableAdapter()
        Me.RvComprobantesPendNuevoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesPendNuevoTableAdapter()
        Me.RvUtilidadVentasTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.RVUtilidadVentasTableAdapter()
        Me.DsRVEstadisticasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RVUtilidadVentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NumVentaTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.NumVentaTableAdapter()
        Me.VentasDetXClienteTableAdapter = New ContaExpress.DsRVEstadisticasTableAdapters.VentasDetXClienteTableAdapter()
        Me.RvPresupuestoDetalladoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVPresupuestoDetalladoTableAdapter()
        Me.VentasTipoPagoTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.VentasTipoPagoTableAdapter()
        Me.TIPOFORMACOBROTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.TIPOFORMACOBROTableAdapter()
        Me.DsRVComisiones1 = New ContaExpress.DsRVComisiones()
        Me.DsProyeccionCobros = New ContaExpress.DsProyeccionCobros()
        Me.DsProyeccionCobrosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProyeccionCobrosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ProyeccionCobrosTableAdapter = New ContaExpress.DsProyeccionCobrosTableAdapters.ProyeccionCobrosTableAdapter()
        Me.EMPRESABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EMPRESATableAdapter = New ContaExpress.DsProyeccionCobrosTableAdapters.EMPRESATableAdapter()
        Me.DsRVClientes = New ContaExpress.DsRVClientes()
        Me.RvListaClientesTableAdapter = New ContaExpress.DsRVClientesTableAdapters.RVListaClientesTableAdapter()
        Me.RvHistoricoClienteTableAdapter1 = New ContaExpress.DsRVClientesTableAdapters.RVHistoricoClienteTableAdapter()
        Me.DataTable1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PendCobroDetalladoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PendCobroDetalladoTableAdapter = New ContaExpress.DsRVCobrosTableAdapters.PendCobroDetalladoTableAdapter()
        Me.ComisionNotasCreditoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComisionNotasCreditoTableAdapter = New ContaExpress.DsRVComisionesTableAdapters.ComisionNotasCreditoTableAdapter()
        Me.FacturacionPorVendedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFacturacionPorVendedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFacturacionPorVendedor = New ContaExpress.dsFacturacionPorVendedor()
        Me.FacturacionPorVendedorTableAdapter = New ContaExpress.dsFacturacionPorVendedorTableAdapters.FacturacionPorVendedorTableAdapter()
        Me.DsTotalMovimientoHistoricoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MovimientoHistoricoTotalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MovClienteTOTALESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MovClienteTOTALESTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.MovClienteTOTALESTableAdapter()
        Me.DsContaBalanceGeneral173 = New ContaExpress.DsContaBalanceGeneral173()
        Me.MovimientoRemisionesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MovimientoRemisionesTableAdapter = New ContaExpress.DsContaBalanceGeneral173TableAdapters.MovimientoRemisionesTableAdapter()
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsReporteVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlSinFiltro.SuspendLayout()
        Me.pnlCliente.SuspendLayout()
        CType(Me.BtnAsteriscoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRangoCli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOtrasOpciones.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlCuenta.SuspendLayout()
        Me.pnlTipo.SuspendLayout()
        Me.pnlSucursal.SuspendLayout()
        Me.pnlListaPrecio.SuspendLayout()
        Me.pnlRelacionado.SuspendLayout()
        Me.pnlCategCliente.SuspendLayout()
        Me.pnlIVA.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlFactCobr.SuspendLayout()
        Me.pnlNumFactura.SuspendLayout()
        Me.pnlTipoCobro.SuspendLayout()
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEstado.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVendedor.SuspendLayout()
        Me.pnlComprobante.SuspendLayout()
        Me.pnlMoneda.SuspendLayout()
        Me.pnlfechas.SuspendLayout()
        Me.pnlIngresoStock.SuspendLayout()
        Me.pnlCategorias.SuspendLayout()
        Me.pnlVisualizardatos.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlDetalleEnvio.SuspendLayout()
        Me.pnlAnulados.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlVisualizar.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlIntervalo.SuspendLayout()
        Me.pnlIntervaloActivo.SuspendLayout()
        Me.pnlLocalidad.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VentasTipoPagoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVEstadisticas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupBoxCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCliente.SuspendLayout()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Remision.ContentPanel.SuspendLayout()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DsCategorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVCobros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVComisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVNotasCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CategoriaClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RVTipoComprobanteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVEstadisticasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RVUtilidadVentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVComisiones1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProyeccionCobros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProyeccionCobrosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProyeccionCobrosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PendCobroDetalladoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComisionNotasCreditoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturacionPorVendedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFacturacionPorVendedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFacturacionPorVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsTotalMovimientoHistoricoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MovimientoHistoricoTotalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MovClienteTOTALESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsContaBalanceGeneral173, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MovimientoRemisionesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProducto
        '
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbProducto.DataSource = Me.ProductosBindingSource
        Me.cmbProducto.DisplayMember = "Descripcion"
        Me.cmbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(98, 3)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(386, 32)
        Me.cmbProducto.TabIndex = 3
        Me.cmbProducto.ValueMember = "CODPRODUCTO"
        '
        'ProductosBindingSource
        '
        Me.ProductosBindingSource.DataMember = "RVProductos"
        Me.ProductosBindingSource.DataSource = Me.DsRVFacturacion
        '
        'DsRVFacturacion
        '
        Me.DsRVFacturacion.DataSetName = "DsRVFacturacion"
        Me.DsRVFacturacion.EnforceConstraints = False
        Me.DsRVFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxRubro
        '
        Me.cbxRubro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxRubro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxRubro.DataSource = Me.RUBROBindingSource
        Me.cbxRubro.DisplayMember = "DESRUBRO"
        Me.cbxRubro.DropDownWidth = 250
        Me.cbxRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRubro.FormattingEnabled = True
        Me.cbxRubro.Location = New System.Drawing.Point(389, 3)
        Me.cbxRubro.Name = "cbxRubro"
        Me.cbxRubro.Size = New System.Drawing.Size(148, 33)
        Me.cbxRubro.TabIndex = 2
        Me.cbxRubro.ValueMember = "CODRUBRO"
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "RUBRO"
        Me.RUBROBindingSource.DataSource = Me.DsReporteVentas
        '
        'DsReporteVentas
        '
        Me.DsReporteVentas.DataSetName = "DsReporteVentas"
        Me.DsReporteVentas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxLinea
        '
        Me.cbxLinea.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxLinea.BackColor = System.Drawing.Color.GhostWhite
        Me.cbxLinea.DataSource = Me.LINEABindingSource
        Me.cbxLinea.DisplayMember = "DESLINEA"
        Me.cbxLinea.DropDownWidth = 250
        Me.cbxLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLinea.FormattingEnabled = True
        Me.cbxLinea.Location = New System.Drawing.Point(237, 3)
        Me.cbxLinea.Name = "cbxLinea"
        Me.cbxLinea.Size = New System.Drawing.Size(104, 33)
        Me.cbxLinea.TabIndex = 1
        Me.cbxLinea.ValueMember = "CODLINEA"
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "LINEA"
        Me.LINEABindingSource.DataSource = Me.DsReporteVentas
        '
        'cbxCategoria
        '
        Me.cbxCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCategoria.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxCategoria.DataSource = Me.FAMILIABindingSource
        Me.cbxCategoria.DisplayMember = "DESFAMILIA"
        Me.cbxCategoria.DropDownWidth = 250
        Me.cbxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCategoria.FormattingEnabled = True
        Me.cbxCategoria.Location = New System.Drawing.Point(59, 4)
        Me.cbxCategoria.Name = "cbxCategoria"
        Me.cbxCategoria.Size = New System.Drawing.Size(120, 33)
        Me.cbxCategoria.TabIndex = 0
        Me.cbxCategoria.ValueMember = "CODFAMILIA"
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DsReporteVentas
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(343, 7)
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
        Me.Label4.Location = New System.Drawing.Point(193, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Linea"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Familia"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoComp
        '
        Me.lblTipoComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComp.ForeColor = System.Drawing.Color.Black
        Me.lblTipoComp.Location = New System.Drawing.Point(3, 7)
        Me.lblTipoComp.Name = "lblTipoComp"
        Me.lblTipoComp.Size = New System.Drawing.Size(89, 25)
        Me.lblTipoComp.TabIndex = 3
        Me.lblTipoComp.Text = "Tipo"
        Me.lblTipoComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(368, 6)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
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
        Me.dtpFechaDesde.Location = New System.Drawing.Point(98, 6)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'lblFechaH
        '
        Me.lblFechaH.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFechaH.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaH.ForeColor = System.Drawing.Color.Black
        Me.lblFechaH.Location = New System.Drawing.Point(284, 11)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(82, 20)
        Me.lblFechaH.TabIndex = 7
        Me.lblFechaH.Text = "Hasta Fecha"
        '
        'cmbCliente
        '
        Me.cmbCliente.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbCliente.DataSource = Me.CLIENTESBindingSource
        Me.cmbCliente.DisplayMember = "NOMBRE"
        Me.cmbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(98, 4)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(386, 33)
        Me.cmbCliente.TabIndex = 7
        Me.cmbCliente.ValueMember = "CODCLIENTE"
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsReporteVentas
        '
        'cmbPais
        '
        Me.cmbPais.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPais.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPais.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbPais.DataSource = Me.PAISBindingSource
        Me.cmbPais.DisplayMember = "DESPAIS"
        Me.cmbPais.DropDownWidth = 300
        Me.cmbPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(98, 3)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(88, 33)
        Me.cmbPais.TabIndex = 4
        Me.cmbPais.ValueMember = "CODPAIS"
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsReporteVentas
        '
        'cmbZona
        '
        Me.cmbZona.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbZona.DataSource = Me.ZONABindingSource
        Me.cmbZona.DisplayMember = "DESZONA"
        Me.cmbZona.DropDownWidth = 300
        Me.cmbZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(389, 3)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(148, 33)
        Me.cmbZona.TabIndex = 6
        Me.cmbZona.ValueMember = "CODZONA"
        '
        'ZONABindingSource
        '
        Me.ZONABindingSource.DataMember = "ZONA"
        Me.ZONABindingSource.DataSource = Me.DsReporteVentas
        '
        'cmbCiudad
        '
        Me.cmbCiudad.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbCiudad.DataSource = Me.CIUDADBindingSource
        Me.cmbCiudad.DisplayMember = "DESCIUDAD"
        Me.cmbCiudad.DropDownWidth = 300
        Me.cmbCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudad.FormattingEnabled = True
        Me.cmbCiudad.Location = New System.Drawing.Point(235, 3)
        Me.cmbCiudad.Name = "cmbCiudad"
        Me.cmbCiudad.Size = New System.Drawing.Size(105, 33)
        Me.cmbCiudad.TabIndex = 5
        Me.cmbCiudad.ValueMember = "CODCIUDAD"
        '
        'CIUDADBindingSource
        '
        Me.CIUDADBindingSource.DataMember = "CIUDAD"
        Me.CIUDADBindingSource.DataSource = Me.DsReporteVentas
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(348, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(35, 25)
        Me.Label23.TabIndex = 17
        Me.Label23.Text = "Zona"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(186, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 25)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Ciudad"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(3, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 25)
        Me.Label15.TabIndex = 14
        Me.Label15.Text = "Departamento"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPos1
        '
        Me.lblPos1.BackColor = System.Drawing.Color.Transparent
        Me.lblPos1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos1.ForeColor = System.Drawing.Color.Black
        Me.lblPos1.Location = New System.Drawing.Point(3, 8)
        Me.lblPos1.Name = "lblPos1"
        Me.lblPos1.Size = New System.Drawing.Size(89, 25)
        Me.lblPos1.TabIndex = 15
        Me.lblPos1.Text = "Cliente"
        Me.lblPos1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCaja
        '
        Me.cmbCaja.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbCaja.DataSource = Me.CAJABindingSource
        Me.cmbCaja.DisplayMember = "NUMEROCAJA"
        Me.cmbCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.Location = New System.Drawing.Point(98, 3)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(440, 33)
        Me.cmbCaja.TabIndex = 1
        Me.cmbCaja.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsReporteVentas
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbMoneda.DataSource = Me.MONEDABindingSource
        Me.cmbMoneda.DisplayMember = "DESMONEDA"
        Me.cmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(98, 5)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(440, 33)
        Me.cmbMoneda.TabIndex = 0
        Me.cmbMoneda.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsReporteVentas
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
        'lblAyudaCodProd
        '
        Me.lblAyudaCodProd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAyudaCodProd.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyudaCodProd.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblAyudaCodProd.Location = New System.Drawing.Point(20, 352)
        Me.lblAyudaCodProd.Name = "lblAyudaCodProd"
        Me.lblAyudaCodProd.Size = New System.Drawing.Size(59, 25)
        Me.lblAyudaCodProd.TabIndex = 8
        Me.lblAyudaCodProd.Text = "Cargue los productos que desea ver separando los por un coma: Ej: H15, H16, J39"
        Me.lblAyudaCodProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAyudaCodProd.Visible = False
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label20.Location = New System.Drawing.Point(3, 578)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(559, 22)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Nota: Si quiere ver Todos los Datos, simplemente inserte ""%"" en el campo correspo" & _
    "ndiente"
        '
        'lblPos3
        '
        Me.lblPos3.BackColor = System.Drawing.Color.Transparent
        Me.lblPos3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPos3.Location = New System.Drawing.Point(3, 8)
        Me.lblPos3.Name = "lblPos3"
        Me.lblPos3.Size = New System.Drawing.Size(89, 25)
        Me.lblPos3.TabIndex = 13
        Me.lblPos3.Text = "Lista de Precio"
        Me.lblPos3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPos4
        '
        Me.lblPos4.BackColor = System.Drawing.Color.Transparent
        Me.lblPos4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos4.ForeColor = System.Drawing.Color.Black
        Me.lblPos4.Location = New System.Drawing.Point(3, 8)
        Me.lblPos4.Name = "lblPos4"
        Me.lblPos4.Size = New System.Drawing.Size(89, 25)
        Me.lblPos4.TabIndex = 12
        Me.lblPos4.Text = "Vendedor/a"
        Me.lblPos4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'EventLog1
        '
        Me.EventLog1.SynchronizingObject = Me
        '
        'chbxMatricial
        '
        Me.chbxMatricial.BackColor = System.Drawing.Color.Transparent
        Me.chbxMatricial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbxMatricial.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxMatricial.ForeColor = System.Drawing.Color.Black
        Me.chbxMatricial.Image = Global.ContaExpress.My.Resources.Resources.Matricial
        Me.chbxMatricial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbxMatricial.Location = New System.Drawing.Point(225, 10)
        Me.chbxMatricial.Name = "chbxMatricial"
        Me.chbxMatricial.Size = New System.Drawing.Size(123, 20)
        Me.chbxMatricial.TabIndex = 461
        Me.chbxMatricial.Text = "Formato Matricial"
        Me.chbxMatricial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbxMatricial.UseVisualStyleBackColor = False
        Me.chbxMatricial.Visible = False
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
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlFiltros.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.pnlSinFiltro)
        Me.pnlFiltros.Controls.Add(Me.pnlCliente)
        Me.pnlFiltros.Controls.Add(Me.Label20)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Controls.Add(Me.chbxNuevaVent)
        Me.pnlFiltros.Controls.Add(Me.chbxMatricial)
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.lblAyudaCodProd)
        Me.pnlFiltros.Controls.Add(Me.pbxCerrarFiltros)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Controls.Add(Me.pnlOtrasOpciones)
        Me.pnlFiltros.Controls.Add(Me.pnlCuenta)
        Me.pnlFiltros.Controls.Add(Me.pnlTipo)
        Me.pnlFiltros.Controls.Add(Me.pnlSucursal)
        Me.pnlFiltros.Controls.Add(Me.pnlListaPrecio)
        Me.pnlFiltros.Controls.Add(Me.pnlRelacionado)
        Me.pnlFiltros.Controls.Add(Me.pnlCategCliente)
        Me.pnlFiltros.Controls.Add(Me.pnlIVA)
        Me.pnlFiltros.Controls.Add(Me.pnlNumFactura)
        Me.pnlFiltros.Controls.Add(Me.pnlTipoCobro)
        Me.pnlFiltros.Controls.Add(Me.pnlEstado)
        Me.pnlFiltros.Controls.Add(Me.pnlProducto)
        Me.pnlFiltros.Controls.Add(Me.pnlVendedor)
        Me.pnlFiltros.Controls.Add(Me.pnlComprobante)
        Me.pnlFiltros.Controls.Add(Me.pnlMoneda)
        Me.pnlFiltros.Controls.Add(Me.pnlfechas)
        Me.pnlFiltros.Controls.Add(Me.pnlIngresoStock)
        Me.pnlFiltros.Controls.Add(Me.pnlCategorias)
        Me.pnlFiltros.Controls.Add(Me.pnlVisualizardatos)
        Me.pnlFiltros.Controls.Add(Me.pnlAnulados)
        Me.pnlFiltros.Controls.Add(Me.pnlVisualizar)
        Me.pnlFiltros.Controls.Add(Me.pnlIntervalo)
        Me.pnlFiltros.Controls.Add(Me.pnlLocalidad)
        Me.pnlFiltros.Controls.Add(Me.cmbZona1)
        Me.pnlFiltros.Controls.Add(Me.PictureBox1)
        Me.pnlFiltros.Location = New System.Drawing.Point(254, 1)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(560, 654)
        Me.pnlFiltros.TabIndex = 466
        '
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(4, 31)
        Me.pnlSinFiltro.Name = "pnlSinFiltro"
        Me.pnlSinFiltro.Size = New System.Drawing.Size(545, 174)
        Me.pnlSinFiltro.TabIndex = 474
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(70, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(413, 22)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Este Reporte no requiere de Filtros Especiales!"
        '
        'pnlCliente
        '
        Me.pnlCliente.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlCliente.Controls.Add(Me.BtnAsteriscoCliente)
        Me.pnlCliente.Controls.Add(Me.lblPos1)
        Me.pnlCliente.Controls.Add(Me.pbxRangoCli)
        Me.pnlCliente.Controls.Add(Me.chbxCodCliente)
        Me.pnlCliente.Controls.Add(Me.cmbCliente)
        Me.pnlCliente.Controls.Add(Me.tbxcodCliente)
        Me.pnlCliente.Location = New System.Drawing.Point(1, 312)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(543, 39)
        Me.pnlCliente.TabIndex = 480
        '
        'BtnAsteriscoCliente
        '
        Me.BtnAsteriscoCliente.BackColor = System.Drawing.Color.Transparent
        Me.BtnAsteriscoCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAsteriscoCliente.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.BtnAsteriscoCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAsteriscoCliente.Location = New System.Drawing.Point(490, 11)
        Me.BtnAsteriscoCliente.Name = "BtnAsteriscoCliente"
        Me.BtnAsteriscoCliente.Size = New System.Drawing.Size(24, 23)
        Me.BtnAsteriscoCliente.TabIndex = 469
        Me.BtnAsteriscoCliente.TabStop = False
        '
        'pbxRangoCli
        '
        Me.pbxRangoCli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxRangoCli.Image = CType(resources.GetObject("pbxRangoCli.Image"), System.Drawing.Image)
        Me.pbxRangoCli.Location = New System.Drawing.Point(516, 11)
        Me.pbxRangoCli.Name = "pbxRangoCli"
        Me.pbxRangoCli.Size = New System.Drawing.Size(21, 22)
        Me.pbxRangoCli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRangoCli.TabIndex = 501
        Me.pbxRangoCli.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbxRangoCli, "Presione aqui para búsqueda por Rango o Lista")
        '
        'chbxCodCliente
        '
        Me.chbxCodCliente.AutoSize = True
        Me.chbxCodCliente.BackColor = System.Drawing.Color.Transparent
        Me.chbxCodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCodCliente.ForeColor = System.Drawing.Color.Gainsboro
        Me.chbxCodCliente.Location = New System.Drawing.Point(519, 16)
        Me.chbxCodCliente.Name = "chbxCodCliente"
        Me.chbxCodCliente.Size = New System.Drawing.Size(15, 14)
        Me.chbxCodCliente.TabIndex = 470
        Me.chbxCodCliente.UseVisualStyleBackColor = False
        '
        'tbxcodCliente
        '
        Me.tbxcodCliente.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbxcodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxcodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxcodCliente.Location = New System.Drawing.Point(98, 4)
        Me.tbxcodCliente.Multiline = True
        Me.tbxcodCliente.Name = "tbxcodCliente"
        Me.tbxcodCliente.Size = New System.Drawing.Size(386, 33)
        Me.tbxcodCliente.TabIndex = 29
        Me.ttipNumCliente.SetToolTip(Me.tbxcodCliente, resources.GetString("tbxcodCliente.ToolTip"))
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
        Me.btnGenerar.Location = New System.Drawing.Point(309, 603)
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
        Me.pnlOtrasOpciones.Controls.Add(Me.rbSinAgrup)
        Me.pnlOtrasOpciones.Controls.Add(Me.rbAgrupFamillia)
        Me.pnlOtrasOpciones.Controls.Add(Me.Panel4)
        Me.pnlOtrasOpciones.Location = New System.Drawing.Point(4, 245)
        Me.pnlOtrasOpciones.Name = "pnlOtrasOpciones"
        Me.pnlOtrasOpciones.Size = New System.Drawing.Size(551, 69)
        Me.pnlOtrasOpciones.TabIndex = 489
        '
        'rbSinAgrup
        '
        Me.rbSinAgrup.AutoSize = True
        Me.rbSinAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinAgrup.Location = New System.Drawing.Point(216, 38)
        Me.rbSinAgrup.Name = "rbSinAgrup"
        Me.rbSinAgrup.Size = New System.Drawing.Size(96, 20)
        Me.rbSinAgrup.TabIndex = 1
        Me.rbSinAgrup.Text = "Sin Agrupar"
        Me.rbSinAgrup.UseVisualStyleBackColor = True
        '
        'rbAgrupFamillia
        '
        Me.rbAgrupFamillia.AutoSize = True
        Me.rbAgrupFamillia.Checked = True
        Me.rbAgrupFamillia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAgrupFamillia.Location = New System.Drawing.Point(35, 37)
        Me.rbAgrupFamillia.Name = "rbAgrupFamillia"
        Me.rbAgrupFamillia.Size = New System.Drawing.Size(145, 20)
        Me.rbAgrupFamillia.TabIndex = 1
        Me.rbAgrupFamillia.TabStop = True
        Me.rbAgrupFamillia.Text = "Agrupar Por Familia"
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
        Me.Label19.Location = New System.Drawing.Point(6, 2)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 21)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Otras opciones"
        '
        'pnlCuenta
        '
        Me.pnlCuenta.BackgroundImage = CType(resources.GetObject("pnlCuenta.BackgroundImage"), System.Drawing.Image)
        Me.pnlCuenta.Controls.Add(Me.Label6)
        Me.pnlCuenta.Controls.Add(Me.cmbCaja)
        Me.pnlCuenta.Location = New System.Drawing.Point(3, 72)
        Me.pnlCuenta.Name = "pnlCuenta"
        Me.pnlCuenta.Size = New System.Drawing.Size(543, 39)
        Me.pnlCuenta.TabIndex = 485
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(3, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 25)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Cuenta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlTipo
        '
        Me.pnlTipo.BackColor = System.Drawing.Color.Transparent
        Me.pnlTipo.Controls.Add(Me.lblTipoComp)
        Me.pnlTipo.Controls.Add(Me.cmbTipo)
        Me.pnlTipo.Location = New System.Drawing.Point(3, 132)
        Me.pnlTipo.Name = "pnlTipo"
        Me.pnlTipo.Size = New System.Drawing.Size(543, 39)
        Me.pnlTipo.TabIndex = 483
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTipo.CheckBoxProperties = CheckBoxProperties1
        Me.cmbTipo.DisplayMemberSingleItem = ""
        Me.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(98, 3)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(440, 33)
        Me.cmbTipo.TabIndex = 488
        '
        'pnlSucursal
        '
        Me.pnlSucursal.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlSucursal.Controls.Add(Me.cmbSucursal)
        Me.pnlSucursal.Controls.Add(Me.lblPos7)
        Me.pnlSucursal.Location = New System.Drawing.Point(5, 437)
        Me.pnlSucursal.Name = "pnlSucursal"
        Me.pnlSucursal.Size = New System.Drawing.Size(543, 39)
        Me.pnlSucursal.TabIndex = 483
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
        Me.lblPos7.Text = "Sucursal"
        Me.lblPos7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlListaPrecio
        '
        Me.pnlListaPrecio.BackgroundImage = CType(resources.GetObject("pnlListaPrecio.BackgroundImage"), System.Drawing.Image)
        Me.pnlListaPrecio.Controls.Add(Me.lblPos3)
        Me.pnlListaPrecio.Controls.Add(Me.cmbListaPrecio)
        Me.pnlListaPrecio.Location = New System.Drawing.Point(3, 381)
        Me.pnlListaPrecio.Name = "pnlListaPrecio"
        Me.pnlListaPrecio.Size = New System.Drawing.Size(543, 39)
        Me.pnlListaPrecio.TabIndex = 481
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbListaPrecio.CheckBoxProperties = CheckBoxProperties3
        Me.cmbListaPrecio.DisplayMemberSingleItem = ""
        Me.cmbListaPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbListaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio.FormattingEnabled = True
        Me.cmbListaPrecio.Location = New System.Drawing.Point(98, 3)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(440, 33)
        Me.cmbListaPrecio.TabIndex = 490
        '
        'pnlRelacionado
        '
        Me.pnlRelacionado.BackgroundImage = CType(resources.GetObject("pnlRelacionado.BackgroundImage"), System.Drawing.Image)
        Me.pnlRelacionado.Controls.Add(Me.cmbRelacionado)
        Me.pnlRelacionado.Controls.Add(Me.Label17)
        Me.pnlRelacionado.Location = New System.Drawing.Point(4, 293)
        Me.pnlRelacionado.Name = "pnlRelacionado"
        Me.pnlRelacionado.Size = New System.Drawing.Size(543, 39)
        Me.pnlRelacionado.TabIndex = 491
        '
        'cmbRelacionado
        '
        Me.cmbRelacionado.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbRelacionado.CheckBoxProperties = CheckBoxProperties4
        Me.cmbRelacionado.DisplayMemberSingleItem = ""
        Me.cmbRelacionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRelacionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRelacionado.FormattingEnabled = True
        Me.cmbRelacionado.Location = New System.Drawing.Point(98, 3)
        Me.cmbRelacionado.Name = "cmbRelacionado"
        Me.cmbRelacionado.Size = New System.Drawing.Size(440, 33)
        Me.cmbRelacionado.TabIndex = 489
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(3, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 25)
        Me.Label17.TabIndex = 30
        Me.Label17.Text = "Relacionar"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlCategCliente
        '
        Me.pnlCategCliente.BackgroundImage = CType(resources.GetObject("pnlCategCliente.BackgroundImage"), System.Drawing.Image)
        Me.pnlCategCliente.Controls.Add(Me.Label9)
        Me.pnlCategCliente.Controls.Add(Me.cmbCategCliente)
        Me.pnlCategCliente.Location = New System.Drawing.Point(3, 34)
        Me.pnlCategCliente.Name = "pnlCategCliente"
        Me.pnlCategCliente.Size = New System.Drawing.Size(543, 39)
        Me.pnlCategCliente.TabIndex = 486
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(3, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 25)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Categ. Cliente"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCategCliente
        '
        Me.cmbCategCliente.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbCategCliente.CheckBoxProperties = CheckBoxProperties5
        Me.cmbCategCliente.DisplayMemberSingleItem = ""
        Me.cmbCategCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCategCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategCliente.FormattingEnabled = True
        Me.cmbCategCliente.Location = New System.Drawing.Point(98, 3)
        Me.cmbCategCliente.Name = "cmbCategCliente"
        Me.cmbCategCliente.Size = New System.Drawing.Size(440, 33)
        Me.cmbCategCliente.TabIndex = 487
        '
        'pnlIVA
        '
        Me.pnlIVA.BackColor = System.Drawing.Color.Silver
        Me.pnlIVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIVA.Controls.Add(Me.rbIVANO)
        Me.pnlIVA.Controls.Add(Me.rbIVASI)
        Me.pnlIVA.Controls.Add(Me.Panel3)
        Me.pnlIVA.Controls.Add(Me.pnlFactCobr)
        Me.pnlIVA.Location = New System.Drawing.Point(4, 415)
        Me.pnlIVA.Name = "pnlIVA"
        Me.pnlIVA.Size = New System.Drawing.Size(551, 62)
        Me.pnlIVA.TabIndex = 490
        '
        'rbIVANO
        '
        Me.rbIVANO.AutoSize = True
        Me.rbIVANO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIVANO.Location = New System.Drawing.Point(117, 30)
        Me.rbIVANO.Name = "rbIVANO"
        Me.rbIVANO.Size = New System.Drawing.Size(69, 20)
        Me.rbIVANO.TabIndex = 1
        Me.rbIVANO.TabStop = True
        Me.rbIVANO.Text = "Sin IVA"
        Me.rbIVANO.UseVisualStyleBackColor = True
        '
        'rbIVASI
        '
        Me.rbIVASI.AutoSize = True
        Me.rbIVASI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbIVASI.Location = New System.Drawing.Point(12, 30)
        Me.rbIVASI.Name = "rbIVASI"
        Me.rbIVASI.Size = New System.Drawing.Size(74, 20)
        Me.rbIVASI.TabIndex = 1
        Me.rbIVASI.TabStop = True
        Me.rbIVASI.Text = "Con IVA"
        Me.rbIVASI.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.Tan
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Location = New System.Drawing.Point(-2, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(554, 25)
        Me.Panel3.TabIndex = 12
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 21)
        Me.Label10.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(6, 2)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(109, 21)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Mostrar Totales"
        '
        'pnlFactCobr
        '
        Me.pnlFactCobr.Controls.Add(Me.rbPorCobr)
        Me.pnlFactCobr.Controls.Add(Me.rbPorFact)
        Me.pnlFactCobr.Location = New System.Drawing.Point(270, 29)
        Me.pnlFactCobr.Name = "pnlFactCobr"
        Me.pnlFactCobr.Size = New System.Drawing.Size(277, 24)
        Me.pnlFactCobr.TabIndex = 13
        Me.pnlFactCobr.Visible = False
        '
        'rbPorCobr
        '
        Me.rbPorCobr.AutoSize = True
        Me.rbPorCobr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorCobr.Location = New System.Drawing.Point(157, 3)
        Me.rbPorCobr.Name = "rbPorCobr"
        Me.rbPorCobr.Size = New System.Drawing.Size(108, 20)
        Me.rbPorCobr.TabIndex = 1
        Me.rbPorCobr.TabStop = True
        Me.rbPorCobr.Text = "Por Cobranza"
        Me.rbPorCobr.UseVisualStyleBackColor = True
        '
        'rbPorFact
        '
        Me.rbPorFact.AutoSize = True
        Me.rbPorFact.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPorFact.Location = New System.Drawing.Point(12, 2)
        Me.rbPorFact.Name = "rbPorFact"
        Me.rbPorFact.Size = New System.Drawing.Size(120, 20)
        Me.rbPorFact.TabIndex = 0
        Me.rbPorFact.TabStop = True
        Me.rbPorFact.Text = "Por Facturación"
        Me.rbPorFact.UseVisualStyleBackColor = True
        '
        'pnlNumFactura
        '
        Me.pnlNumFactura.BackgroundImage = CType(resources.GetObject("pnlNumFactura.BackgroundImage"), System.Drawing.Image)
        Me.pnlNumFactura.Controls.Add(Me.txtNumVenta)
        Me.pnlNumFactura.Controls.Add(Me.Label31)
        Me.pnlNumFactura.Location = New System.Drawing.Point(4, 515)
        Me.pnlNumFactura.Name = "pnlNumFactura"
        Me.pnlNumFactura.Size = New System.Drawing.Size(543, 39)
        Me.pnlNumFactura.TabIndex = 479
        '
        'txtNumVenta
        '
        Me.txtNumVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.txtNumVenta.Location = New System.Drawing.Point(109, 5)
        Me.txtNumVenta.Name = "txtNumVenta"
        Me.txtNumVenta.Size = New System.Drawing.Size(422, 30)
        Me.txtNumVenta.TabIndex = 4
        '
        'Label31
        '
        Me.Label31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(3, 7)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(108, 25)
        Me.Label31.TabIndex = 3
        Me.Label31.Text = "Nro. de Factura:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTipoCobro
        '
        Me.pnlTipoCobro.BackColor = System.Drawing.Color.Transparent
        Me.pnlTipoCobro.Controls.Add(Me.cmbTipoCobro)
        Me.pnlTipoCobro.Controls.Add(Me.Label29)
        Me.pnlTipoCobro.Location = New System.Drawing.Point(3, 75)
        Me.pnlTipoCobro.Name = "pnlTipoCobro"
        Me.pnlTipoCobro.Size = New System.Drawing.Size(543, 39)
        Me.pnlTipoCobro.TabIndex = 489
        '
        'cmbTipoCobro
        '
        Me.cmbTipoCobro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbTipoCobro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbTipoCobro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTipoCobro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbTipoCobro.DataSource = Me.TIPOFORMACOBROBindingSource
        Me.cmbTipoCobro.DisplayMember = "DESFORCOBRO"
        Me.cmbTipoCobro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoCobro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.cmbTipoCobro.FormattingEnabled = True
        Me.cmbTipoCobro.Location = New System.Drawing.Point(96, 3)
        Me.cmbTipoCobro.Name = "cmbTipoCobro"
        Me.cmbTipoCobro.Size = New System.Drawing.Size(431, 33)
        Me.cmbTipoCobro.TabIndex = 4
        Me.cmbTipoCobro.ValueMember = "CODFORCOBRO"
        '
        'TIPOFORMACOBROBindingSource
        '
        Me.TIPOFORMACOBROBindingSource.DataMember = "TIPOFORMACOBRO"
        Me.TIPOFORMACOBROBindingSource.DataSource = Me.DsRVFacturacion
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(3, 7)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(89, 25)
        Me.Label29.TabIndex = 3
        Me.Label29.Text = "Tipo Cobro"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlEstado
        '
        Me.pnlEstado.BackgroundImage = CType(resources.GetObject("pnlEstado.BackgroundImage"), System.Drawing.Image)
        Me.pnlEstado.Controls.Add(Me.cmbEstado)
        Me.pnlEstado.Controls.Add(Me.Label14)
        Me.pnlEstado.Location = New System.Drawing.Point(10, 54)
        Me.pnlEstado.Name = "pnlEstado"
        Me.pnlEstado.Size = New System.Drawing.Size(543, 39)
        Me.pnlEstado.TabIndex = 486
        '
        'cmbEstado
        '
        Me.cmbEstado.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbEstado.CheckBoxProperties = CheckBoxProperties6
        Me.cmbEstado.DisplayMemberSingleItem = ""
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(98, 3)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(440, 33)
        Me.cmbEstado.TabIndex = 489
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(3, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 25)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Estado"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.pnlProducto.Location = New System.Drawing.Point(4, 171)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(543, 39)
        Me.pnlProducto.TabIndex = 483
        '
        'pbxRangoProd
        '
        Me.pbxRangoProd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxRangoProd.Image = CType(resources.GetObject("pbxRangoProd.Image"), System.Drawing.Image)
        Me.pbxRangoProd.Location = New System.Drawing.Point(515, 6)
        Me.pbxRangoProd.Name = "pbxRangoProd"
        Me.pbxRangoProd.Size = New System.Drawing.Size(21, 22)
        Me.pbxRangoProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRangoProd.TabIndex = 500
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
        Me.chbxCodProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCodProducto.ForeColor = System.Drawing.Color.Gainsboro
        Me.chbxCodProducto.Location = New System.Drawing.Point(519, 13)
        Me.chbxCodProducto.Name = "chbxCodProducto"
        Me.chbxCodProducto.Size = New System.Drawing.Size(15, 14)
        Me.chbxCodProducto.TabIndex = 20
        Me.chbxCodProducto.UseVisualStyleBackColor = False
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
        Me.tbxcodProd.Size = New System.Drawing.Size(386, 33)
        Me.tbxcodProd.TabIndex = 21
        Me.ttipCodProducto.SetToolTip(Me.tbxcodProd, resources.GetString("tbxcodProd.ToolTip"))
        '
        'pnlVendedor
        '
        Me.pnlVendedor.BackgroundImage = CType(resources.GetObject("pnlVendedor.BackgroundImage"), System.Drawing.Image)
        Me.pnlVendedor.Controls.Add(Me.cmbVendedor)
        Me.pnlVendedor.Controls.Add(Me.lblPos4)
        Me.pnlVendedor.ForeColor = System.Drawing.Color.DarkOrange
        Me.pnlVendedor.Location = New System.Drawing.Point(3, 200)
        Me.pnlVendedor.Name = "pnlVendedor"
        Me.pnlVendedor.Size = New System.Drawing.Size(543, 39)
        Me.pnlVendedor.TabIndex = 483
        '
        'cmbVendedor
        '
        Me.cmbVendedor.BackColor = System.Drawing.Color.GhostWhite
        CheckBoxProperties7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbVendedor.CheckBoxProperties = CheckBoxProperties7
        Me.cmbVendedor.DisplayMemberSingleItem = "DESCATEGORIACLIENTE"
        Me.cmbVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendedor.FormattingEnabled = True
        Me.cmbVendedor.Location = New System.Drawing.Point(98, 3)
        Me.cmbVendedor.Name = "cmbVendedor"
        Me.cmbVendedor.Size = New System.Drawing.Size(440, 33)
        Me.cmbVendedor.TabIndex = 18
        '
        'pnlComprobante
        '
        Me.pnlComprobante.BackColor = System.Drawing.Color.Transparent
        Me.pnlComprobante.BackgroundImage = CType(resources.GetObject("pnlComprobante.BackgroundImage"), System.Drawing.Image)
        Me.pnlComprobante.Controls.Add(Me.Label1)
        Me.pnlComprobante.Controls.Add(Me.cmbComprobante)
        Me.pnlComprobante.Location = New System.Drawing.Point(3, 142)
        Me.pnlComprobante.Name = "pnlComprobante"
        Me.pnlComprobante.Size = New System.Drawing.Size(543, 39)
        Me.pnlComprobante.TabIndex = 484
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 25)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Comprobante"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbComprobante
        '
        Me.cmbComprobante.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbComprobante.CheckBoxProperties = CheckBoxProperties8
        Me.cmbComprobante.DisplayMemberSingleItem = ""
        Me.cmbComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobante.FormattingEnabled = True
        Me.cmbComprobante.Location = New System.Drawing.Point(98, 3)
        Me.cmbComprobante.Name = "cmbComprobante"
        Me.cmbComprobante.Size = New System.Drawing.Size(440, 33)
        Me.cmbComprobante.TabIndex = 491
        '
        'pnlMoneda
        '
        Me.pnlMoneda.BackColor = System.Drawing.Color.Transparent
        Me.pnlMoneda.Controls.Add(Me.cmbMoneda)
        Me.pnlMoneda.Controls.Add(Me.lblPos6)
        Me.pnlMoneda.Location = New System.Drawing.Point(4, 140)
        Me.pnlMoneda.Name = "pnlMoneda"
        Me.pnlMoneda.Size = New System.Drawing.Size(543, 39)
        Me.pnlMoneda.TabIndex = 482
        '
        'lblPos6
        '
        Me.lblPos6.BackColor = System.Drawing.Color.Transparent
        Me.lblPos6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblPos6.Location = New System.Drawing.Point(3, 8)
        Me.lblPos6.Name = "lblPos6"
        Me.lblPos6.Size = New System.Drawing.Size(89, 25)
        Me.lblPos6.TabIndex = 28
        Me.lblPos6.Text = "Moneda"
        Me.lblPos6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlfechas
        '
        Me.pnlfechas.BackgroundImage = CType(resources.GetObject("pnlfechas.BackgroundImage"), System.Drawing.Image)
        Me.pnlfechas.Controls.Add(Me.dtpFechaHasta)
        Me.pnlfechas.Controls.Add(Me.lblFechaH)
        Me.pnlfechas.Controls.Add(Me.lblFechaD)
        Me.pnlfechas.Controls.Add(Me.dtpFechaDesde)
        Me.pnlfechas.Location = New System.Drawing.Point(4, 208)
        Me.pnlfechas.Name = "pnlfechas"
        Me.pnlfechas.Size = New System.Drawing.Size(543, 39)
        Me.pnlfechas.TabIndex = 479
        '
        'lblFechaD
        '
        Me.lblFechaD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFechaD.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaD.ForeColor = System.Drawing.Color.Black
        Me.lblFechaD.Location = New System.Drawing.Point(12, 11)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(80, 15)
        Me.lblFechaD.TabIndex = 19
        Me.lblFechaD.Text = "Desde Fecha"
        '
        'pnlIngresoStock
        '
        Me.pnlIngresoStock.BackColor = System.Drawing.Color.Transparent
        Me.pnlIngresoStock.Controls.Add(Me.Label8)
        Me.pnlIngresoStock.Controls.Add(Me.cmbIngresoStock)
        Me.pnlIngresoStock.Location = New System.Drawing.Point(8, 290)
        Me.pnlIngresoStock.Name = "pnlIngresoStock"
        Me.pnlIngresoStock.Size = New System.Drawing.Size(543, 39)
        Me.pnlIngresoStock.TabIndex = 492
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(3, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 25)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Stock"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbIngresoStock
        '
        Me.cmbIngresoStock.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbIngresoStock.CheckBoxProperties = CheckBoxProperties9
        Me.cmbIngresoStock.DisplayMemberSingleItem = ""
        Me.cmbIngresoStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIngresoStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIngresoStock.FormattingEnabled = True
        Me.cmbIngresoStock.Items.AddRange(New Object() {"Con Ingreso a Stock", "Sin Ingreso a Stock"})
        Me.cmbIngresoStock.Location = New System.Drawing.Point(98, 3)
        Me.cmbIngresoStock.Name = "cmbIngresoStock"
        Me.cmbIngresoStock.Size = New System.Drawing.Size(440, 33)
        Me.cmbIngresoStock.TabIndex = 488
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
        Me.pnlCategorias.Location = New System.Drawing.Point(4, 267)
        Me.pnlCategorias.Name = "pnlCategorias"
        Me.pnlCategorias.Size = New System.Drawing.Size(543, 39)
        Me.pnlCategorias.TabIndex = 478
        '
        'pnlVisualizardatos
        '
        Me.pnlVisualizardatos.BackColor = System.Drawing.Color.Silver
        Me.pnlVisualizardatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVisualizardatos.Controls.Add(Me.rbtSinNumFac)
        Me.pnlVisualizardatos.Controls.Add(Me.rbtConNroFac)
        Me.pnlVisualizardatos.Controls.Add(Me.Panel6)
        Me.pnlVisualizardatos.Controls.Add(Me.pnlDetalleEnvio)
        Me.pnlVisualizardatos.Location = New System.Drawing.Point(3, 472)
        Me.pnlVisualizardatos.Name = "pnlVisualizardatos"
        Me.pnlVisualizardatos.Size = New System.Drawing.Size(551, 69)
        Me.pnlVisualizardatos.TabIndex = 493
        '
        'rbtSinNumFac
        '
        Me.rbtSinNumFac.AutoSize = True
        Me.rbtSinNumFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSinNumFac.Location = New System.Drawing.Point(147, 37)
        Me.rbtSinNumFac.Name = "rbtSinNumFac"
        Me.rbtSinNumFac.Size = New System.Drawing.Size(124, 20)
        Me.rbtSinNumFac.TabIndex = 13
        Me.rbtSinNumFac.Text = "Sin Num Factura"
        Me.rbtSinNumFac.UseVisualStyleBackColor = True
        '
        'rbtConNroFac
        '
        Me.rbtConNroFac.AutoSize = True
        Me.rbtConNroFac.Checked = True
        Me.rbtConNroFac.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConNroFac.Location = New System.Drawing.Point(4, 37)
        Me.rbtConNroFac.Name = "rbtConNroFac"
        Me.rbtConNroFac.Size = New System.Drawing.Size(129, 20)
        Me.rbtConNroFac.TabIndex = 1
        Me.rbtConNroFac.TabStop = True
        Me.rbtConNroFac.Text = "Con Num Factura"
        Me.rbtConNroFac.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel6.BackColor = System.Drawing.Color.Tan
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label24)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Location = New System.Drawing.Point(-2, -1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(554, 25)
        Me.Panel6.TabIndex = 12
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.White
        Me.Label24.Location = New System.Drawing.Point(5, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 21)
        Me.Label24.TabIndex = 7
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(6, 2)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(141, 21)
        Me.Label26.TabIndex = 0
        Me.Label26.Text = "Visualizar los Datos "
        '
        'pnlDetalleEnvio
        '
        Me.pnlDetalleEnvio.Controls.Add(Me.rbtSinDetalleProducto)
        Me.pnlDetalleEnvio.Controls.Add(Me.rbtConDetalleProducto)
        Me.pnlDetalleEnvio.Location = New System.Drawing.Point(279, 27)
        Me.pnlDetalleEnvio.Name = "pnlDetalleEnvio"
        Me.pnlDetalleEnvio.Size = New System.Drawing.Size(268, 36)
        Me.pnlDetalleEnvio.TabIndex = 14
        Me.pnlDetalleEnvio.Visible = False
        '
        'rbtSinDetalleProducto
        '
        Me.rbtSinDetalleProducto.AutoSize = True
        Me.rbtSinDetalleProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSinDetalleProducto.Location = New System.Drawing.Point(157, 9)
        Me.rbtSinDetalleProducto.Name = "rbtSinDetalleProducto"
        Me.rbtSinDetalleProducto.Size = New System.Drawing.Size(91, 20)
        Me.rbtSinDetalleProducto.TabIndex = 1
        Me.rbtSinDetalleProducto.Text = "Sin Detalle"
        Me.rbtSinDetalleProducto.UseVisualStyleBackColor = True
        '
        'rbtConDetalleProducto
        '
        Me.rbtConDetalleProducto.AutoSize = True
        Me.rbtConDetalleProducto.Checked = True
        Me.rbtConDetalleProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConDetalleProducto.Location = New System.Drawing.Point(12, 8)
        Me.rbtConDetalleProducto.Name = "rbtConDetalleProducto"
        Me.rbtConDetalleProducto.Size = New System.Drawing.Size(96, 20)
        Me.rbtConDetalleProducto.TabIndex = 0
        Me.rbtConDetalleProducto.TabStop = True
        Me.rbtConDetalleProducto.Text = "Con Detalle"
        Me.rbtConDetalleProducto.UseVisualStyleBackColor = True
        '
        'pnlAnulados
        '
        Me.pnlAnulados.BackColor = System.Drawing.Color.Silver
        Me.pnlAnulados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAnulados.Controls.Add(Me.rbtsinanuladas)
        Me.pnlAnulados.Controls.Add(Me.rbtConanuladas)
        Me.pnlAnulados.Controls.Add(Me.Panel8)
        Me.pnlAnulados.Location = New System.Drawing.Point(2, 454)
        Me.pnlAnulados.Name = "pnlAnulados"
        Me.pnlAnulados.Size = New System.Drawing.Size(551, 69)
        Me.pnlAnulados.TabIndex = 494
        '
        'rbtsinanuladas
        '
        Me.rbtsinanuladas.AutoSize = True
        Me.rbtsinanuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtsinanuladas.Location = New System.Drawing.Point(270, 36)
        Me.rbtsinanuladas.Name = "rbtsinanuladas"
        Me.rbtsinanuladas.Size = New System.Drawing.Size(155, 20)
        Me.rbtsinanuladas.TabIndex = 13
        Me.rbtsinanuladas.Text = "Sin facturas Anuladas"
        Me.rbtsinanuladas.UseVisualStyleBackColor = True
        '
        'rbtConanuladas
        '
        Me.rbtConanuladas.AutoSize = True
        Me.rbtConanuladas.Checked = True
        Me.rbtConanuladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConanuladas.Location = New System.Drawing.Point(11, 36)
        Me.rbtConanuladas.Name = "rbtConanuladas"
        Me.rbtConanuladas.Size = New System.Drawing.Size(160, 20)
        Me.rbtConanuladas.TabIndex = 1
        Me.rbtConanuladas.TabStop = True
        Me.rbtConanuladas.Text = "Con facturas Anuladas"
        Me.rbtConanuladas.UseVisualStyleBackColor = True
        '
        'Panel8
        '
        Me.Panel8.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel8.BackColor = System.Drawing.Color.Tan
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label27)
        Me.Panel8.Controls.Add(Me.Label28)
        Me.Panel8.Location = New System.Drawing.Point(-2, -1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(554, 25)
        Me.Panel8.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(5, 3)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(0, 21)
        Me.Label27.TabIndex = 7
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(6, -2)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(137, 21)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Visualizar los Datos"
        '
        'pnlVisualizar
        '
        Me.pnlVisualizar.BackColor = System.Drawing.Color.Silver
        Me.pnlVisualizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVisualizar.Controls.Add(Me.rbtConGrafico)
        Me.pnlVisualizar.Controls.Add(Me.rbtSinGrafico)
        Me.pnlVisualizar.Controls.Add(Me.Panel5)
        Me.pnlVisualizar.Location = New System.Drawing.Point(3, 498)
        Me.pnlVisualizar.Name = "pnlVisualizar"
        Me.pnlVisualizar.Size = New System.Drawing.Size(551, 69)
        Me.pnlVisualizar.TabIndex = 14
        '
        'rbtConGrafico
        '
        Me.rbtConGrafico.AutoSize = True
        Me.rbtConGrafico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtConGrafico.Location = New System.Drawing.Point(117, 37)
        Me.rbtConGrafico.Name = "rbtConGrafico"
        Me.rbtConGrafico.Size = New System.Drawing.Size(96, 20)
        Me.rbtConGrafico.TabIndex = 13
        Me.rbtConGrafico.TabStop = True
        Me.rbtConGrafico.Text = "Con Gráfico"
        Me.rbtConGrafico.UseVisualStyleBackColor = True
        '
        'rbtSinGrafico
        '
        Me.rbtSinGrafico.AutoSize = True
        Me.rbtSinGrafico.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtSinGrafico.Location = New System.Drawing.Point(4, 37)
        Me.rbtSinGrafico.Name = "rbtSinGrafico"
        Me.rbtSinGrafico.Size = New System.Drawing.Size(91, 20)
        Me.rbtSinGrafico.TabIndex = 1
        Me.rbtSinGrafico.TabStop = True
        Me.rbtSinGrafico.Text = "Sin Gráfico"
        Me.rbtSinGrafico.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Controls.Add(Me.Label21)
        Me.Panel5.Location = New System.Drawing.Point(-2, -1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(554, 25)
        Me.Panel5.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(5, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 21)
        Me.Label11.TabIndex = 7
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(6, 2)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(141, 21)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "Visualizar los Datos "
        '
        'pnlIntervalo
        '
        Me.pnlIntervalo.BackColor = System.Drawing.Color.Silver
        Me.pnlIntervalo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIntervalo.Controls.Add(Me.rbtnAño)
        Me.pnlIntervalo.Controls.Add(Me.rbtnSemestre)
        Me.pnlIntervalo.Controls.Add(Me.rbtnMes)
        Me.pnlIntervalo.Controls.Add(Me.rbtnQuincena)
        Me.pnlIntervalo.Controls.Add(Me.rbtnSemana)
        Me.pnlIntervalo.Controls.Add(Me.rbtDia)
        Me.pnlIntervalo.Controls.Add(Me.rbtnHora)
        Me.pnlIntervalo.Controls.Add(Me.pnlIntervaloActivo)
        Me.pnlIntervalo.Location = New System.Drawing.Point(4, 348)
        Me.pnlIntervalo.Name = "pnlIntervalo"
        Me.pnlIntervalo.Size = New System.Drawing.Size(551, 69)
        Me.pnlIntervalo.TabIndex = 6
        '
        'rbtnAño
        '
        Me.rbtnAño.AutoSize = True
        Me.rbtnAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAño.Location = New System.Drawing.Point(475, 37)
        Me.rbtnAño.Name = "rbtnAño"
        Me.rbtnAño.Size = New System.Drawing.Size(50, 20)
        Me.rbtnAño.TabIndex = 3
        Me.rbtnAño.TabStop = True
        Me.rbtnAño.Text = "Año"
        Me.rbtnAño.UseVisualStyleBackColor = True
        '
        'rbtnSemestre
        '
        Me.rbtnSemestre.AutoSize = True
        Me.rbtnSemestre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSemestre.Location = New System.Drawing.Point(379, 37)
        Me.rbtnSemestre.Name = "rbtnSemestre"
        Me.rbtnSemestre.Size = New System.Drawing.Size(84, 20)
        Me.rbtnSemestre.TabIndex = 3
        Me.rbtnSemestre.TabStop = True
        Me.rbtnSemestre.Text = "Semestre"
        Me.rbtnSemestre.UseVisualStyleBackColor = True
        '
        'rbtnMes
        '
        Me.rbtnMes.AutoSize = True
        Me.rbtnMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnMes.Location = New System.Drawing.Point(315, 37)
        Me.rbtnMes.Name = "rbtnMes"
        Me.rbtnMes.Size = New System.Drawing.Size(52, 20)
        Me.rbtnMes.TabIndex = 3
        Me.rbtnMes.TabStop = True
        Me.rbtnMes.Text = "Mes"
        Me.rbtnMes.UseVisualStyleBackColor = True
        '
        'rbtnQuincena
        '
        Me.rbtnQuincena.AutoSize = True
        Me.rbtnQuincena.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnQuincena.Location = New System.Drawing.Point(220, 37)
        Me.rbtnQuincena.Name = "rbtnQuincena"
        Me.rbtnQuincena.Size = New System.Drawing.Size(83, 20)
        Me.rbtnQuincena.TabIndex = 2
        Me.rbtnQuincena.TabStop = True
        Me.rbtnQuincena.Text = "Quincena"
        Me.rbtnQuincena.UseVisualStyleBackColor = True
        '
        'rbtnSemana
        '
        Me.rbtnSemana.AutoSize = True
        Me.rbtnSemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSemana.Location = New System.Drawing.Point(131, 37)
        Me.rbtnSemana.Name = "rbtnSemana"
        Me.rbtnSemana.Size = New System.Drawing.Size(77, 20)
        Me.rbtnSemana.TabIndex = 1
        Me.rbtnSemana.TabStop = True
        Me.rbtnSemana.Text = "Semana"
        Me.rbtnSemana.UseVisualStyleBackColor = True
        '
        'rbtDia
        '
        Me.rbtDia.AutoSize = True
        Me.rbtDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtDia.Location = New System.Drawing.Point(72, 37)
        Me.rbtDia.Name = "rbtDia"
        Me.rbtDia.Size = New System.Drawing.Size(47, 20)
        Me.rbtDia.TabIndex = 1
        Me.rbtDia.TabStop = True
        Me.rbtDia.Text = "Día"
        Me.rbtDia.UseVisualStyleBackColor = True
        '
        'rbtnHora
        '
        Me.rbtnHora.AutoSize = True
        Me.rbtnHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnHora.Location = New System.Drawing.Point(4, 37)
        Me.rbtnHora.Name = "rbtnHora"
        Me.rbtnHora.Size = New System.Drawing.Size(56, 20)
        Me.rbtnHora.TabIndex = 1
        Me.rbtnHora.TabStop = True
        Me.rbtnHora.Text = "Hora"
        Me.rbtnHora.UseVisualStyleBackColor = True
        '
        'pnlIntervaloActivo
        '
        Me.pnlIntervaloActivo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlIntervaloActivo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlIntervaloActivo.BackColor = System.Drawing.Color.Tan
        Me.pnlIntervaloActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIntervaloActivo.Controls.Add(Me.Label25)
        Me.pnlIntervaloActivo.Controls.Add(Me.Label12)
        Me.pnlIntervaloActivo.Location = New System.Drawing.Point(-2, -1)
        Me.pnlIntervaloActivo.Name = "pnlIntervaloActivo"
        Me.pnlIntervaloActivo.Size = New System.Drawing.Size(554, 25)
        Me.pnlIntervaloActivo.TabIndex = 12
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.White
        Me.Label25.Location = New System.Drawing.Point(5, 3)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 21)
        Me.Label25.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(6, 2)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(224, 21)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Agrupar los datos por Intervalos"
        '
        'pnlLocalidad
        '
        Me.pnlLocalidad.BackgroundImage = CType(resources.GetObject("pnlLocalidad.BackgroundImage"), System.Drawing.Image)
        Me.pnlLocalidad.Controls.Add(Me.cmbZona)
        Me.pnlLocalidad.Controls.Add(Me.Label23)
        Me.pnlLocalidad.Controls.Add(Me.cmbCiudad)
        Me.pnlLocalidad.Controls.Add(Me.Label15)
        Me.pnlLocalidad.Controls.Add(Me.Label16)
        Me.pnlLocalidad.Controls.Add(Me.cmbPais)
        Me.pnlLocalidad.Location = New System.Drawing.Point(3, 252)
        Me.pnlLocalidad.Name = "pnlLocalidad"
        Me.pnlLocalidad.Size = New System.Drawing.Size(543, 39)
        Me.pnlLocalidad.TabIndex = 477
        '
        'cmbZona1
        '
        Me.cmbZona1.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbZona1.CheckBoxProperties = CheckBoxProperties10
        Me.cmbZona1.DisplayMemberSingleItem = ""
        Me.cmbZona1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbZona1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZona1.FormattingEnabled = True
        Me.cmbZona1.Location = New System.Drawing.Point(350, 607)
        Me.cmbZona1.Name = "cmbZona1"
        Me.cmbZona1.Size = New System.Drawing.Size(50, 33)
        Me.cmbZona1.TabIndex = 489
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(460, 616)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 22)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'VentasTipoPagoBindingSource
        '
        Me.VentasTipoPagoBindingSource.DataMember = "VentasTipoPago"
        Me.VentasTipoPagoBindingSource.DataSource = Me.DsRVFacturacion
        '
        'DsRVEstadisticas
        '
        Me.DsRVEstadisticas.DataSetName = "DsRVEstadisticas"
        Me.DsRVEstadisticas.EnforceConstraints = False
        Me.DsRVEstadisticas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'GroupBoxCliente
        '
        Me.GroupBoxCliente.Controls.Add(Me.GridViewClientes)
        Me.GroupBoxCliente.Controls.Add(Me.TxtBuscaCliente)
        Me.GroupBoxCliente.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.GroupBoxCliente.FooterImageIndex = -1
        Me.GroupBoxCliente.FooterImageKey = ""
        Me.GroupBoxCliente.HeaderImageIndex = -1
        Me.GroupBoxCliente.HeaderImageKey = ""
        Me.GroupBoxCliente.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxCliente.HeaderText = "Búsqueda de Clientes"
        Me.GroupBoxCliente.Location = New System.Drawing.Point(37, 62)
        Me.GroupBoxCliente.Name = "GroupBoxCliente"
        Me.GroupBoxCliente.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.GroupBoxCliente.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.GroupBoxCliente.RootElement.AngleTransform = 0.0!
        Me.GroupBoxCliente.RootElement.FlipText = False
        Me.GroupBoxCliente.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.GroupBoxCliente.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.GroupBoxCliente.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.GroupBoxCliente.RootElement.Text = Nothing
        Me.GroupBoxCliente.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.GroupBoxCliente.Size = New System.Drawing.Size(565, 593)
        Me.GroupBoxCliente.TabIndex = 488
        Me.GroupBoxCliente.Text = "Búsqueda de Clientes"
        Me.GroupBoxCliente.ThemeName = "Breeze"
        Me.GroupBoxCliente.Visible = False
        CType(Me.GroupBoxCliente.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.DimGray
        '
        'GridViewClientes
        '
        Me.GridViewClientes.AllowUserToAddRows = False
        Me.GridViewClientes.AllowUserToDeleteRows = False
        Me.GridViewClientes.AllowUserToOrderColumns = True
        Me.GridViewClientes.AllowUserToResizeRows = False
        Me.GridViewClientes.AutoGenerateColumns = False
        Me.GridViewClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridViewClientes.ColumnHeadersHeight = 30
        Me.GridViewClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCLIENTEDataGridViewTextBoxColumn, Me.NUMCLIENTE1DataGridViewTextBoxColumn, Me.RUCDataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn, Me.NOMBREFANTASIADataGridViewTextBoxColumn})
        Me.GridViewClientes.DataSource = Me.CLIENTESBindingSource
        Me.GridViewClientes.Location = New System.Drawing.Point(9, 66)
        Me.GridViewClientes.Name = "GridViewClientes"
        Me.GridViewClientes.ReadOnly = True
        Me.GridViewClientes.RowHeadersVisible = False
        Me.GridViewClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GridViewClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewClientes.ShowCellErrors = False
        Me.GridViewClientes.ShowCellToolTips = False
        Me.GridViewClientes.ShowEditingIcon = False
        Me.GridViewClientes.ShowRowErrors = False
        Me.GridViewClientes.Size = New System.Drawing.Size(546, 514)
        Me.GridViewClientes.TabIndex = 490
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'NUMCLIENTE1DataGridViewTextBoxColumn
        '
        Me.NUMCLIENTE1DataGridViewTextBoxColumn.DataPropertyName = "NUMCLIENTE1"
        Me.NUMCLIENTE1DataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.NUMCLIENTE1DataGridViewTextBoxColumn.HeaderText = "Nro de Cliente"
        Me.NUMCLIENTE1DataGridViewTextBoxColumn.Name = "NUMCLIENTE1DataGridViewTextBoxColumn"
        Me.NUMCLIENTE1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'RUCDataGridViewTextBoxColumn
        '
        Me.RUCDataGridViewTextBoxColumn.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.RUCDataGridViewTextBoxColumn.HeaderText = "RUC"
        Me.RUCDataGridViewTextBoxColumn.Name = "RUCDataGridViewTextBoxColumn"
        Me.RUCDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.FillWeight = 120.0!
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Nombre"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NOMBREFANTASIADataGridViewTextBoxColumn
        '
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.DataPropertyName = "NOMBREFANTASIA"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.FillWeight = 120.0!
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.HeaderText = "Nomb. Fantasia"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.Name = "NOMBREFANTASIADataGridViewTextBoxColumn"
        Me.NOMBREFANTASIADataGridViewTextBoxColumn.ReadOnly = True
        '
        'TxtBuscaCliente
        '
        Me.TxtBuscaCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBuscaCliente.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.TxtBuscaCliente.Location = New System.Drawing.Point(10, 27)
        Me.TxtBuscaCliente.Name = "TxtBuscaCliente"
        Me.TxtBuscaCliente.Size = New System.Drawing.Size(545, 30)
        Me.TxtBuscaCliente.TabIndex = 376
        Me.TxtBuscaCliente.Text = "Buscar..."
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
        Me.ProductosGroupBox.Location = New System.Drawing.Point(440, 58)
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
        Me.ProductosGridView.AutoGenerateColumns = False
        Me.ProductosGridView.ColumnHeadersHeight = 30
        Me.ProductosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DescripcionDataGridViewTextBoxColumn})
        Me.ProductosGridView.DataSource = Me.ProductosBindingSource
        Me.ProductosGridView.Location = New System.Drawing.Point(10, 55)
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.Size = New System.Drawing.Size(548, 461)
        Me.ProductosGridView.TabIndex = 378
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.Width = 150
        '
        'DescripcionDataGridViewTextBoxColumn
        '
        Me.DescripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion"
        Me.DescripcionDataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DescripcionDataGridViewTextBoxColumn.Name = "DescripcionDataGridViewTextBoxColumn"
        Me.DescripcionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescripcionDataGridViewTextBoxColumn.Width = 380
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
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).ZIndex = 925
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBoxCliente)
        Me.SplitContainer1.Size = New System.Drawing.Size(1079, 655)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 491
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.DisplayStatusBar = False
        Me.CrystalReportViewer.DisplayToolbar = False
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGotoPageButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowPageNavigateButtons = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(815, 655)
        Me.CrystalReportViewer.TabIndex = 489
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'ttipNumCliente
        '
        Me.ttipNumCliente.AutomaticDelay = 50
        Me.ttipNumCliente.AutoPopDelay = 50000
        Me.ttipNumCliente.InitialDelay = 50
        Me.ttipNumCliente.ReshowDelay = 10
        Me.ttipNumCliente.ToolTipTitle = "Filtro por Nro. Cliente"
        '
        'ttipCodProducto
        '
        Me.ttipCodProducto.AutomaticDelay = 50
        Me.ttipCodProducto.AutoPopDelay = 50000
        Me.ttipCodProducto.InitialDelay = 50
        Me.ttipCodProducto.ReshowDelay = 10
        Me.ttipCodProducto.ToolTipTitle = "Filtro por Código"
        '
        'DsCategorizacion
        '
        Me.DsCategorizacion.DataSetName = "DsCategorizacion"
        Me.DsCategorizacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsRVEnvios
        '
        Me.DsRVEnvios.DataSetName = "DsRVEnvios"
        Me.DsRVEnvios.EnforceConstraints = False
        Me.DsRVEnvios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvEnviosPorZonaProductoTableAdapter
        '
        Me.RvEnviosPorZonaProductoTableAdapter.ClearBeforeFill = True
        '
        'RvEnviosPorClienteTableAdapter
        '
        Me.RvEnviosPorClienteTableAdapter.ClearBeforeFill = True
        '
        'RvEnviosPorClienteProductoTableAdapter
        '
        Me.RvEnviosPorClienteProductoTableAdapter.ClearBeforeFill = True
        '
        'RvCobrosClientesTableAdapter
        '
        Me.RvCobrosClientesTableAdapter.ClearBeforeFill = True
        '
        'RvCobrosClientesTableAdapter1
        '
        Me.RvCobrosClientesTableAdapter1.ClearBeforeFill = True
        '
        'DsRVCobros
        '
        Me.DsRVCobros.DataSetName = "DsRVCobros"
        Me.DsRVCobros.EnforceConstraints = False
        Me.DsRVCobros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvFacturasXReciboTableAdapter
        '
        Me.RvFacturasXReciboTableAdapter.ClearBeforeFill = True
        '
        'RvPendientesCobroTableAdapter
        '
        Me.RvPendientesCobroTableAdapter.ClearBeforeFill = True
        '
        'RvchdiF_NCREDTableAdapter
        '
        Me.RvchdiF_NCREDTableAdapter.ClearBeforeFill = True
        '
        'RvPendienteCobroDifTableAdapter
        '
        Me.RvPendienteCobroDifTableAdapter.ClearBeforeFill = True
        '
        'RvRankingClientesTableAdapter
        '
        Me.RvRankingClientesTableAdapter.ClearBeforeFill = True
        '
        'RvRankingProductosTableAdapter
        '
        Me.RvRankingProductosTableAdapter.ClearBeforeFill = True
        '
        'RvVentasCompletoTableAdapter
        '
        Me.RvVentasCompletoTableAdapter.ClearBeforeFill = True
        '
        'DsRVCaja
        '
        Me.DsRVCaja.DataSetName = "DsRVCaja"
        Me.DsRVCaja.EnforceConstraints = False
        Me.DsRVCaja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvDiarioCajaTableAdapter
        '
        Me.RvDiarioCajaTableAdapter.ClearBeforeFill = True
        '
        'RvTotalTableAdapter
        '
        Me.RvTotalTableAdapter.ClearBeforeFill = True
        '
        'RvCajaIvaTableAdapter
        '
        Me.RvCajaIvaTableAdapter.ClearBeforeFill = True
        '
        'RvAperturaCierreTableAdapter
        '
        Me.RvAperturaCierreTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantesPorProductoResumTableAdapter
        '
        Me.RvComprobantesPorProductoResumTableAdapter.ClearBeforeFill = True
        '
        'DsRVComprobantes
        '
        Me.DsRVComprobantes.DataSetName = "DsRVComprobantes"
        Me.DsRVComprobantes.EnforceConstraints = False
        Me.DsRVComprobantes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvcclientesTableAdapter
        '
        Me.RvcclientesTableAdapter.ClearBeforeFill = True
        '
        'RvVentasPorProductoComparativoMesAnhoTableAdapter
        '
        Me.RvVentasPorProductoComparativoMesAnhoTableAdapter.ClearBeforeFill = True
        '
        'RvVentasPorClienteComparativoMesAnhoTableAdapter
        '
        Me.RvVentasPorClienteComparativoMesAnhoTableAdapter.ClearBeforeFill = True
        '
        'DsSettingFO
        '
        Me.DsSettingFO.DataSetName = "DsSettingFO"
        Me.DsSettingFO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RVIVADetalladoTableAdapter
        '
        Me.RVIVADetalladoTableAdapter.ClearBeforeFill = True
        '
        'RvCobrosClientesNCTableAdapter
        '
        Me.RvCobrosClientesNCTableAdapter.ClearBeforeFill = True
        '
        'DsRVComisiones
        '
        Me.DsRVComisiones.DataSetName = "DsRVComisiones"
        Me.DsRVComisiones.EnforceConstraints = False
        Me.DsRVComisiones.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ComisionVendedorTableAdapter
        '
        Me.ComisionVendedorTableAdapter.ClearBeforeFill = True
        '
        'ComisionVendedorFacturacionTableAdapter
        '
        Me.ComisionVendedorFacturacionTableAdapter.ClearBeforeFill = True
        '
        'ComisionVendedorCobrDetTableAdapter
        '
        Me.ComisionVendedorCobrDetTableAdapter.ClearBeforeFill = True
        '
        'RvVentasPorZONATableAdapter
        '
        Me.RvVentasPorZONATableAdapter.ClearBeforeFill = True
        '
        'RvVentasPrecioVentaVsCostoPorProductoTableAdapter
        '
        Me.RvVentasPrecioVentaVsCostoPorProductoTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantesPorProductoPorFechaTableAdapter
        '
        Me.RvComprobantesPorProductoPorFechaTableAdapter.ClearBeforeFill = True
        '
        'RvNotasCreditoPendienteTableAdapter
        '
        Me.RvNotasCreditoPendienteTableAdapter.ClearBeforeFill = True
        '
        'RvComprPorVendPorProductoTableAdapter
        '
        Me.RvComprPorVendPorProductoTableAdapter.ClearBeforeFill = True
        '
        'RvClientesAtrasadosTableAdapter
        '
        Me.RvClientesAtrasadosTableAdapter.ClearBeforeFill = True
        '
        'RvFacturasACobrarTableAdapter
        '
        Me.RvFacturasACobrarTableAdapter.ClearBeforeFill = True
        '
        'RvRecibosClienteDetTableAdapter
        '
        Me.RvRecibosClienteDetTableAdapter.ClearBeforeFill = True
        '
        'RVAnalisisDeSaldoTableAdapter
        '
        Me.RVAnalisisDeSaldoTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantePorProductoPorClienteTableAdapter
        '
        Me.RvComprobantePorProductoPorClienteTableAdapter.ClearBeforeFill = True
        '
        'DsRVNotasCredito
        '
        Me.DsRVNotasCredito.DataSetName = "DsRVNotasCredito"
        Me.DsRVNotasCredito.EnforceConstraints = False
        Me.DsRVNotasCredito.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvNotasDeCreditoTableAdapter
        '
        Me.RvNotasDeCreditoTableAdapter.ClearBeforeFill = True
        '
        'RvNotasDeCreditoPorProdTableAdapter
        '
        Me.RvNotasDeCreditoPorProdTableAdapter.ClearBeforeFill = True
        '
        'RvncclientesTableAdapter
        '
        Me.RvncclientesTableAdapter.ClearBeforeFill = True
        '
        'RvivancventasTableAdapter
        '
        Me.RvivancventasTableAdapter.ClearBeforeFill = True
        '
        'RvncPorProductoResumTableAdapter
        '
        Me.RvncPorProductoResumTableAdapter.ClearBeforeFill = True
        '
        'RvincidenciancsobrevtaTableAdapter
        '
        Me.RvincidenciancsobrevtaTableAdapter.ClearBeforeFill = True
        '
        'RVVentasPorZonatipoTableAdapter
        '
        Me.RVVentasPorZonatipoTableAdapter.ClearBeforeFill = True
        '
        'RVVentasPorZonaPromedioTableAdapter
        '
        Me.RVVentasPorZonaPromedioTableAdapter.ClearBeforeFill = True
        '
        'ComisionVendedorCobranzaTipoVentaTableAdapter
        '
        Me.ComisionVendedorCobranzaTipoVentaTableAdapter.ClearBeforeFill = True
        '
        'CODIGOSBindingSource
        '
        Me.CODIGOSBindingSource.DataMember = "CODIGOS"
        Me.CODIGOSBindingSource.DataSource = Me.DsReporteVentas
        '
        'VENDEDORBindingSource
        '
        Me.VENDEDORBindingSource.DataMember = "VENDEDOR"
        Me.VENDEDORBindingSource.DataSource = Me.DsReporteVentas
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsReporteVentas
        '
        'TIPOCLIENTEBindingSource
        '
        Me.TIPOCLIENTEBindingSource.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource.DataSource = Me.DsReporteVentas
        '
        'VentasProductoDetallladoTableAdapter
        '
        Me.VentasProductoDetallladoTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AperturasCajaTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CAJATableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.DEPARTAMENTOTableAdapter = Nothing
        Me.TableAdapterManager.FAMILIATableAdapter = Nothing
        Me.TableAdapterManager.IVATableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PAISTableAdapter = Nothing
        Me.TableAdapterManager.RVENTASCATEGORIACLIENTETableAdapter = Nothing
        Me.TableAdapterManager.STOCKDEPOSITOTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCLIENTETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsReporteVentasTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VENDEDORTableAdapter = Nothing
        Me.TableAdapterManager.VENTASTableAdapter = Nothing
        '
        'VentasPorTipoPagoTableAdapter
        '
        Me.VentasPorTipoPagoTableAdapter.ClearBeforeFill = True
        '
        'VentasPorVendedorTableAdapter
        '
        Me.VentasPorVendedorTableAdapter.ClearBeforeFill = True
        '
        'ListaClientesTableAdapter
        '
        Me.ListaClientesTableAdapter.ClearBeforeFill = True
        '
        'VentasProductosMasVendidosTableAdapter
        '
        Me.VentasProductosMasVendidosTableAdapter.ClearBeforeFill = True
        '
        'FacturaACobrarTableAdapter
        '
        Me.FacturaACobrarTableAdapter.ClearBeforeFill = True
        '
        'PedidoPendientePorZonaTableAdapter
        '
        Me.PedidoPendientePorZonaTableAdapter.ClearBeforeFill = True
        '
        'PedidoPendientePorClienteTableAdapter
        '
        Me.PedidoPendientePorClienteTableAdapter.ClearBeforeFill = True
        '
        'DiarioCajaTableAdapter
        '
        Me.DiarioCajaTableAdapter.ClearBeforeFill = True
        '
        'EnvioPorZonaArticuloTableAdapter
        '
        Me.EnvioPorZonaArticuloTableAdapter.ClearBeforeFill = True
        '
        'CategoriasMasVendidasTableAdapter
        '
        Me.CategoriasMasVendidasTableAdapter.ClearBeforeFill = True
        '
        'VentaProductoFechaTableAdapter
        '
        Me.VentaProductoFechaTableAdapter.ClearBeforeFill = True
        '
        'CategoriasPorMesTableAdapter
        '
        Me.CategoriasPorMesTableAdapter.ClearBeforeFill = True
        '
        'VentasPorSucursalTableAdapter
        '
        Me.VentasPorSucursalTableAdapter.ClearBeforeFill = True
        '
        'VentasPorTipoClienteTableAdapter
        '
        Me.VentasPorTipoClienteTableAdapter.ClearBeforeFill = True
        '
        'GastosPorProductoTableAdapter
        '
        Me.GastosPorProductoTableAdapter.ClearBeforeFill = True
        '
        'IngresosPorProductoTableAdapter
        '
        Me.IngresosPorProductoTableAdapter.ClearBeforeFill = True
        '
        'GastosUltimaCompraTableAdapter
        '
        Me.GastosUltimaCompraTableAdapter.ClearBeforeFill = True
        '
        'StockTotaldeProductosTableAdapter
        '
        Me.StockTotaldeProductosTableAdapter.ClearBeforeFill = True
        '
        'VentaMovimientoTableAdapter
        '
        Me.VentaMovimientoTableAdapter.ClearBeforeFill = True
        '
        'CostoFijoCantidadVentaTableAdapter
        '
        Me.CostoFijoCantidadVentaTableAdapter.ClearBeforeFill = True
        '
        'CostoFijoSumaTableAdapter
        '
        Me.CostoFijoSumaTableAdapter.ClearBeforeFill = True
        '
        'CostoFijoDesglosadoTableAdapter
        '
        Me.CostoFijoDesglosadoTableAdapter.ClearBeforeFill = True
        '
        'CantidadVentaTableAdapter
        '
        Me.CantidadVentaTableAdapter.ClearBeforeFill = True
        '
        'VentasListaPrecioTableAdapter
        '
        Me.VentasListaPrecioTableAdapter.ClearBeforeFill = True
        '
        'STOCKDEPOSITOTableAdapter
        '
        Me.STOCKDEPOSITOTableAdapter.ClearBeforeFill = True
        '
        'VENTASDETALLETableAdapter
        '
        Me.VENTASDETALLETableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'TIPOCLIENTETableAdapter
        '
        Me.TIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'PAISTableAdapter
        '
        Me.PAISTableAdapter.ClearBeforeFill = True
        '
        'CIUDADTableAdapter
        '
        Me.CIUDADTableAdapter.ClearBeforeFill = True
        '
        'ZONATableAdapter
        '
        Me.ZONATableAdapter.ClearBeforeFill = True
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'VENDEDORTableAdapter
        '
        Me.VENDEDORTableAdapter.ClearBeforeFill = True
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
        'CODIGOSTableAdapter
        '
        Me.CODIGOSTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'VentasResumenTableAdapter
        '
        Me.VentasResumenTableAdapter.ClearBeforeFill = True
        '
        'VentasDetalladoTableAdapter
        '
        Me.VentasDetalladoTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSLISTAPRECIOTableAdapter
        '
        Me.PRODUCTOSLISTAPRECIOTableAdapter.ClearBeforeFill = True
        '
        'UtilidadClienteCompraTableAdapter
        '
        Me.UtilidadClienteCompraTableAdapter.ClearBeforeFill = True
        '
        'UtilidadClienteVentasTableAdapter
        '
        Me.UtilidadClienteVentasTableAdapter.ClearBeforeFill = True
        '
        'PromedioCantidadCompradaTableAdapter
        '
        Me.PromedioCantidadCompradaTableAdapter.ClearBeforeFill = True
        '
        'PromedioGs_CompradoTableAdapter
        '
        Me.PromedioGs_CompradoTableAdapter.ClearBeforeFill = True
        '
        'AperturasCajaTableAdapter
        '
        Me.AperturasCajaTableAdapter.ClearBeforeFill = True
        '
        'CierreCajaTableAdapter
        '
        Me.CierreCajaTableAdapter.ClearBeforeFill = True
        '
        'VENTASFORMACOBROTableAdapter
        '
        Me.VENTASFORMACOBROTableAdapter.ClearBeforeFill = True
        '
        'AjusteTableAdapter
        '
        Me.AjusteTableAdapter.ClearBeforeFill = True
        '
        'VentasIvaTableAdapter
        '
        Me.VentasIvaTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSMENOSVENDIDOSTableAdapter
        '
        Me.PRODUCTOSMENOSVENDIDOSTableAdapter.ClearBeforeFill = True
        '
        'DiasDesdeUltimaVentaTableAdapter
        '
        Me.DiasDesdeUltimaVentaTableAdapter.ClearBeforeFill = True
        '
        'DiasUltimaCompraTableAdapter
        '
        Me.DiasUltimaCompraTableAdapter.ClearBeforeFill = True
        '
        'CantidadUltimaCompraTableAdapter
        '
        Me.CantidadUltimaCompraTableAdapter.ClearBeforeFill = True
        '
        'StockUltimaCompraTableAdapter
        '
        Me.StockUltimaCompraTableAdapter.ClearBeforeFill = True
        '
        'UltimaCompraDiasTableAdapter
        '
        Me.UltimaCompraDiasTableAdapter.ClearBeforeFill = True
        '
        'TotalMovimientosVentaTableAdapter
        '
        Me.TotalMovimientosVentaTableAdapter.ClearBeforeFill = True
        '
        'AperturaCierreTableAdapter
        '
        Me.AperturaCierreTableAdapter.ClearBeforeFill = True
        '
        'IVATableAdapter
        '
        Me.IVATableAdapter.ClearBeforeFill = True
        '
        'AjusteEntradaTableAdapter
        '
        Me.AjusteEntradaTableAdapter.ClearBeforeFill = True
        '
        'AjusteSalidaTableAdapter
        '
        Me.AjusteSalidaTableAdapter.ClearBeforeFill = True
        '
        'TotalMovimientosCompraTableAdapter
        '
        Me.TotalMovimientosCompraTableAdapter.ClearBeforeFill = True
        '
        'CategoriaClienteBindingSource
        '
        Me.CategoriaClienteBindingSource.DataMember = "RVENTASCATEGORIACLIENTE"
        Me.CategoriaClienteBindingSource.DataSource = Me.DsReporteVentas
        '
        'RventascategoriaclienteTableAdapter
        '
        Me.RventascategoriaclienteTableAdapter.ClearBeforeFill = True
        '
        'ListaClientesporlistaPrecioTableAdapter
        '
        Me.ListaClientesporlistaPrecioTableAdapter.ClearBeforeFill = True
        '
        'NotaCreditoDetalladoTableAdapter
        '
        Me.NotaCreditoDetalladoTableAdapter.ClearBeforeFill = True
        '
        'LibroVentasLeyTableAdapter
        '
        Me.LibroVentasLeyTableAdapter.ClearBeforeFill = True
        '
        'PorcentajedeventaTableAdapter
        '
        Me.PorcentajedeventaTableAdapter.ClearBeforeFill = True
        '
        'ListadereciboTableAdapter
        '
        Me.ListadereciboTableAdapter.ClearBeforeFill = True
        '
        'RvnclibroivaTableAdapter
        '
        Me.RvnclibroivaTableAdapter.ClearBeforeFill = True
        '
        'RVTipoComprobanteBindingSource
        '
        Me.RVTipoComprobanteBindingSource.DataMember = "RVTipoComprobante"
        Me.RVTipoComprobanteBindingSource.DataSource = Me.DsRVFacturacion
        '
        'RvPendientePorZonaClienteTableAdapter
        '
        Me.RvPendientePorZonaClienteTableAdapter.ClearBeforeFill = True
        '
        'RvPendientePorZonaProductoTableAdapter
        '
        Me.RvPendientePorZonaProductoTableAdapter.ClearBeforeFill = True
        '
        'RvPendientePorClienteTableAdapter
        '
        Me.RvPendientePorClienteTableAdapter.ClearBeforeFill = True
        '
        'RVTipoComprobanteTableAdapter
        '
        Me.RVTipoComprobanteTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantesTableAdapter
        '
        Me.RvComprobantesTableAdapter.ClearBeforeFill = True
        '
        'RvVentasPorVendedorTableAdapter
        '
        Me.RvVentasPorVendedorTableAdapter.ClearBeforeFill = True
        '
        'RVProductosTableAdapter
        '
        Me.RVProductosTableAdapter.ClearBeforeFill = True
        '
        'RvclientesTableAdapter
        '
        Me.RvclientesTableAdapter.ClearBeforeFill = True
        '
        'RvPendientePorClienteProductoTableAdapter
        '
        Me.RvPendientePorClienteProductoTableAdapter.ClearBeforeFill = True
        '
        'RvVentasResumenTableAdapter
        '
        Me.RvVentasResumenTableAdapter.ClearBeforeFill = True
        '
        'RvMovimientosClienteTableAdapter
        '
        Me.RvMovimientosClienteTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantesResumidoTableAdapter
        '
        Me.RvComprobantesResumidoTableAdapter.ClearBeforeFill = True
        '
        'RvComprobantesAgrupCliTableAdapter
        '
        Me.RvComprobantesAgrupCliTableAdapter.ClearBeforeFill = True
        '
        'RvventasporclientesTableAdapter
        '
        Me.RvventasporclientesTableAdapter.ClearBeforeFill = True
        '
        'RvListaPresupuestoTableAdapter1
        '
        Me.RvListaPresupuestoTableAdapter1.ClearBeforeFill = True
        '
        'RvComprobantesPendNuevoTableAdapter
        '
        Me.RvComprobantesPendNuevoTableAdapter.ClearBeforeFill = True
        '
        'RvUtilidadVentasTableAdapter
        '
        Me.RvUtilidadVentasTableAdapter.ClearBeforeFill = True
        '
        'DsRVEstadisticasBindingSource
        '
        Me.DsRVEstadisticasBindingSource.DataSource = Me.DsRVEstadisticas
        Me.DsRVEstadisticasBindingSource.Position = 0
        '
        'RVUtilidadVentasBindingSource
        '
        Me.RVUtilidadVentasBindingSource.DataMember = "RVUtilidadVentas"
        Me.RVUtilidadVentasBindingSource.DataSource = Me.DsRVEstadisticasBindingSource
        '
        'NumVentaTableAdapter
        '
        Me.NumVentaTableAdapter.ClearBeforeFill = True
        '
        'VentasDetXClienteTableAdapter
        '
        Me.VentasDetXClienteTableAdapter.ClearBeforeFill = True
        '
        'RvPresupuestoDetalladoTableAdapter
        '
        Me.RvPresupuestoDetalladoTableAdapter.ClearBeforeFill = True
        '
        'VentasTipoPagoTableAdapter
        '
        Me.VentasTipoPagoTableAdapter.ClearBeforeFill = True
        '
        'TIPOFORMACOBROTableAdapter
        '
        Me.TIPOFORMACOBROTableAdapter.ClearBeforeFill = True
        '
        'DsRVComisiones1
        '
        Me.DsRVComisiones1.DataSetName = "DsRVComisiones"
        Me.DsRVComisiones1.EnforceConstraints = False
        Me.DsRVComisiones1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsProyeccionCobros
        '
        Me.DsProyeccionCobros.DataSetName = "DsProyeccionCobros"
        Me.DsProyeccionCobros.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsProyeccionCobrosBindingSource
        '
        Me.DsProyeccionCobrosBindingSource.DataSource = Me.DsProyeccionCobros
        Me.DsProyeccionCobrosBindingSource.Position = 0
        '
        'ProyeccionCobrosBindingSource
        '
        Me.ProyeccionCobrosBindingSource.DataMember = "ProyeccionCobros"
        Me.ProyeccionCobrosBindingSource.DataSource = Me.DsProyeccionCobrosBindingSource
        '
        'ProyeccionCobrosTableAdapter
        '
        Me.ProyeccionCobrosTableAdapter.ClearBeforeFill = True
        '
        'EMPRESABindingSource
        '
        Me.EMPRESABindingSource.DataMember = "EMPRESA"
        Me.EMPRESABindingSource.DataSource = Me.DsProyeccionCobrosBindingSource
        '
        'EMPRESATableAdapter
        '
        Me.EMPRESATableAdapter.ClearBeforeFill = True
        '
        'DsRVClientes
        '
        Me.DsRVClientes.DataSetName = "DsRVClientes"
        Me.DsRVClientes.EnforceConstraints = False
        Me.DsRVClientes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RvListaClientesTableAdapter
        '
        Me.RvListaClientesTableAdapter.ClearBeforeFill = True
        '
        'RvHistoricoClienteTableAdapter1
        '
        Me.RvHistoricoClienteTableAdapter1.ClearBeforeFill = True
        '
        'DataTable1BindingSource
        '
        Me.DataTable1BindingSource.DataMember = "DataTable1"
        '
        'PendCobroDetalladoBindingSource
        '
        Me.PendCobroDetalladoBindingSource.DataMember = "PendCobroDetallado"
        Me.PendCobroDetalladoBindingSource.DataSource = Me.DsRVCobros
        '
        'PendCobroDetalladoTableAdapter
        '
        Me.PendCobroDetalladoTableAdapter.ClearBeforeFill = True
        '
        'ComisionNotasCreditoBindingSource
        '
        Me.ComisionNotasCreditoBindingSource.DataMember = "ComisionNotasCredito"
        Me.ComisionNotasCreditoBindingSource.DataSource = Me.DsRVComisiones
        '
        'ComisionNotasCreditoTableAdapter
        '
        Me.ComisionNotasCreditoTableAdapter.ClearBeforeFill = True
        '
        'FacturacionPorVendedorBindingSource
        '
        Me.FacturacionPorVendedorBindingSource.DataMember = "FacturacionPorVendedor"
        Me.FacturacionPorVendedorBindingSource.DataSource = Me.DsFacturacionPorVendedorBindingSource
        '
        'DsFacturacionPorVendedorBindingSource
        '
        Me.DsFacturacionPorVendedorBindingSource.DataSource = Me.DsFacturacionPorVendedor
        Me.DsFacturacionPorVendedorBindingSource.Position = 0
        '
        'DsFacturacionPorVendedor
        '
        Me.DsFacturacionPorVendedor.DataSetName = "dsFacturacionPorVendedor"
        Me.DsFacturacionPorVendedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FacturacionPorVendedorTableAdapter
        '
        Me.FacturacionPorVendedorTableAdapter.ClearBeforeFill = True
        '
        'MovClienteTOTALESBindingSource
        '
        Me.MovClienteTOTALESBindingSource.DataMember = "MovClienteTOTALES"
        Me.MovClienteTOTALESBindingSource.DataSource = Me.DsRVFacturacion
        '
        'MovClienteTOTALESTableAdapter
        '
        Me.MovClienteTOTALESTableAdapter.ClearBeforeFill = True
        '
        'DsContaBalanceGeneral173
        '
        Me.DsContaBalanceGeneral173.DataSetName = "DsContaBalanceGeneral173"
        Me.DsContaBalanceGeneral173.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'MovimientoRemisionesBindingSource
        '
        Me.MovimientoRemisionesBindingSource.DataMember = "MovimientoRemisiones"
        Me.MovimientoRemisionesBindingSource.DataSource = Me.DsContaBalanceGeneral173
        '
        'MovimientoRemisionesTableAdapter
        '
        Me.MovimientoRemisionesTableAdapter.ClearBeforeFill = True
        '
        'FiltroReporteVentas
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
        Me.Name = "FiltroReporteVentas"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ventas  | Cogent SIG"
        CType(Me.ProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsReporteVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventLog1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        CType(Me.BtnAsteriscoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRangoCli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOtrasOpciones.ResumeLayout(False)
        Me.pnlOtrasOpciones.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnlCuenta.ResumeLayout(False)
        Me.pnlTipo.ResumeLayout(False)
        Me.pnlSucursal.ResumeLayout(False)
        Me.pnlListaPrecio.ResumeLayout(False)
        Me.pnlRelacionado.ResumeLayout(False)
        Me.pnlCategCliente.ResumeLayout(False)
        Me.pnlIVA.ResumeLayout(False)
        Me.pnlIVA.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlFactCobr.ResumeLayout(False)
        Me.pnlFactCobr.PerformLayout()
        Me.pnlNumFactura.ResumeLayout(False)
        Me.pnlNumFactura.PerformLayout()
        Me.pnlTipoCobro.ResumeLayout(False)
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEstado.ResumeLayout(False)
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        CType(Me.pbxRangoProd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAsteriscoProducto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVendedor.ResumeLayout(False)
        Me.pnlComprobante.ResumeLayout(False)
        Me.pnlMoneda.ResumeLayout(False)
        Me.pnlfechas.ResumeLayout(False)
        Me.pnlIngresoStock.ResumeLayout(False)
        Me.pnlCategorias.ResumeLayout(False)
        Me.pnlVisualizardatos.ResumeLayout(False)
        Me.pnlVisualizardatos.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.pnlDetalleEnvio.ResumeLayout(False)
        Me.pnlDetalleEnvio.PerformLayout()
        Me.pnlAnulados.ResumeLayout(False)
        Me.pnlAnulados.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.pnlVisualizar.ResumeLayout(False)
        Me.pnlVisualizar.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlIntervalo.ResumeLayout(False)
        Me.pnlIntervalo.PerformLayout()
        Me.pnlIntervaloActivo.ResumeLayout(False)
        Me.pnlIntervaloActivo.PerformLayout()
        Me.pnlLocalidad.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VentasTipoPagoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVEstadisticas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupBoxCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCliente.ResumeLayout(False)
        Me.GroupBoxCliente.PerformLayout()
        CType(Me.GridViewClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Remision.ContentPanel.ResumeLayout(False)
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DsCategorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVCobros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVComisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVNotasCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CategoriaClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RVTipoComprobanteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVEstadisticasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RVUtilidadVentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVComisiones1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProyeccionCobros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProyeccionCobrosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProyeccionCobrosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataTable1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PendCobroDetalladoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComisionNotasCreditoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturacionPorVendedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFacturacionPorVendedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFacturacionPorVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsTotalMovimientoHistoricoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MovimientoHistoricoTotalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MovClienteTOTALESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsContaBalanceGeneral173, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MovimientoRemisionesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DsReporteVentas As ContaExpress.DsReporteVentas
    Friend WithEvents VentasProductoDetallladoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasProductoDetallladoTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsReporteVentasTableAdapters.TableAdapterManager
    Friend WithEvents VentasPorTipoPagoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasPorTipoPagoTableAdapter
    Friend WithEvents cbxCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
    Friend WithEvents VentasPorVendedorTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasPorVendedorTableAdapter
    Friend WithEvents ListaClientesTableAdapter As ContaExpress.DsReporteVentasTableAdapters.ListaClientesTableAdapter
    Friend WithEvents VentasProductosMasVendidosTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasProductosMasVendidosTableAdapter
    Friend WithEvents FacturaACobrarTableAdapter As ContaExpress.DsReporteVentasTableAdapters.FacturaACobrarTableAdapter
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
    Friend WithEvents PedidoPendientePorZonaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PedidoPendientePorZonaTableAdapter
    Friend WithEvents PedidoPendientePorClienteTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PedidoPendientePorClienteTableAdapter
    Friend WithEvents DiarioCajaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.DiarioCajaTableAdapter
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents EnvioPorZonaArticuloTableAdapter As ContaExpress.DsReporteVentasTableAdapters.EnvioPorZonaArticuloTableAdapter
    Friend WithEvents DIARIORESUMENCAJATableAdapter As ContaExpress.DsReporteVentasTableAdapters.DIARIORESUMENCAJATableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRubro As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLinea As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoComp As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DsCategorizacion As ContaExpress.DsCategorizacion
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents CategoriasMasVendidasTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CategoriasMasVendidasTableAdapter
    Friend WithEvents VentaProductoFechaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentaProductoFechaTableAdapter
    Friend WithEvents CategoriasPorMesTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CategoriasPorMesTableAdapter
    Friend WithEvents VentasPorSucursalTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasPorSucursalTableAdapter
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents VentasPorTipoClienteTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasPorTipoClienteTableAdapter
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblReporteDescrip As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblAyudaCodProd As System.Windows.Forms.Label
    Friend WithEvents lblPos4 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblPos1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GastosPorProductoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.GastosPorProductoTableAdapter
    Friend WithEvents IngresosPorProductoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.IngresosPorProductoTableAdapter
    Friend WithEvents GastosUltimaCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.GastosUltimaCompraTableAdapter
    Friend WithEvents StockTotaldeProductosTableAdapter As ContaExpress.DsReporteVentasTableAdapters.StockTotaldeProductosTableAdapter
    Friend WithEvents lblPos3 As System.Windows.Forms.Label
    Friend WithEvents EventLog1 As System.Diagnostics.EventLog
    Friend WithEvents VentaMovimientoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentaMovimientoTableAdapter
    Friend WithEvents CostoFijoCantidadVentaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CostoFijoCantidadVentaTableAdapter
    Friend WithEvents CostoFijoSumaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CostoFijoSumaTableAdapter
    Friend WithEvents CostoFijoDesglosadoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CostoFijoDesglosadoTableAdapter
    Friend WithEvents CantidadVentaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CantidadVentaTableAdapter
    Friend WithEvents VentasListaPrecioTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasListaPrecioTableAdapter
    Friend WithEvents STOCKDEPOSITOTableAdapter As ContaExpress.DsReporteVentasTableAdapters.STOCKDEPOSITOTableAdapter
    Friend WithEvents VENTASDETALLETableAdapter As ContaExpress.DsReporteVentasTableAdapters.VENTASDETALLETableAdapter
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsReporteVentasTableAdapters.MONEDATableAdapter
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsReporteVentasTableAdapters.CAJATableAdapter
    Friend WithEvents TIPOCLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsReporteVentasTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PAISTableAdapter
    Friend WithEvents CIUDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CIUDADTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CIUDADTableAdapter
    Friend WithEvents ZONABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZONATableAdapter As ContaExpress.DsReporteVentasTableAdapters.ZONATableAdapter
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CLIENTESTableAdapter
    Friend WithEvents VENDEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENDEDORTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VENDEDORTableAdapter
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DsReporteVentasTableAdapters.FAMILIATableAdapter
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEATableAdapter As ContaExpress.DsReporteVentasTableAdapters.LINEATableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUBROTableAdapter As ContaExpress.DsReporteVentasTableAdapters.RUBROTableAdapter
    Friend WithEvents CODIGOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGOSTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CODIGOSTableAdapter
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsReporteVentasTableAdapters.SUCURSALTableAdapter
    Friend WithEvents VentasResumenTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasResumenTableAdapter
    Friend WithEvents VentasDetalladoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasDetalladoTableAdapter
    Friend WithEvents PRODUCTOSLISTAPRECIOTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PRODUCTOSLISTAPRECIOTableAdapter
    Friend WithEvents UtilidadClienteCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.UtilidadClienteCompraTableAdapter
    Friend WithEvents UtilidadClienteVentasTableAdapter As ContaExpress.DsReporteVentasTableAdapters.UtilidadClienteVentasTableAdapter
    Friend WithEvents PromedioCantidadCompradaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PromedioCantidadCompradaTableAdapter
    Friend WithEvents PromedioGs_CompradoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PromedioGs_CompradoTableAdapter
    Friend WithEvents AperturasCajaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.AperturasCajaTableAdapter
    Friend WithEvents CierreCajaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CierreCajaTableAdapter
    Friend WithEvents VENTASFORMACOBROTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VENTASFORMACOBROTableAdapter
    Friend WithEvents AjusteTableAdapter As ContaExpress.DsReporteVentasTableAdapters.AjusteTableAdapter
    Friend WithEvents VentasIvaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.VentasIvaTableAdapter
    Friend WithEvents PRODUCTOSMENOSVENDIDOSTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PRODUCTOSMENOSVENDIDOSTableAdapter
    Friend WithEvents DiasDesdeUltimaVentaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.DiasDesdeUltimaVentaTableAdapter
    Friend WithEvents DiasUltimaCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.DiasUltimaCompraTableAdapter
    Friend WithEvents CantidadUltimaCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CantidadUltimaCompraTableAdapter
    Friend WithEvents StockUltimaCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.StockUltimaCompraTableAdapter
    Friend WithEvents UltimaCompraDiasTableAdapter As ContaExpress.DsReporteVentasTableAdapters.UltimaCompraDiasTableAdapter
    Friend WithEvents TotalMovimientosVentaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.TotalMovimientosVentaTableAdapter
    Friend WithEvents AperturaCierreTableAdapter As ContaExpress.DsReporteVentasTableAdapters.AperturaCierreTableAdapter
    Friend WithEvents IVATableAdapter As ContaExpress.DsReporteVentasTableAdapters.IVATableAdapter
    Friend WithEvents AjusteEntradaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.AjusteEntradaTableAdapter
    Friend WithEvents AjusteSalidaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.AjusteSalidaTableAdapter
    Friend WithEvents DsRVClientes As ContaExpress.DsRVClientes
    Friend WithEvents RvPendientePorZonaClienteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorZonaClienteTableAdapter
    Friend WithEvents RvPendientePorZonaProductoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorZonaProductoTableAdapter
    Friend WithEvents RvPendientePorClienteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorClienteTableAdapter
    Friend WithEvents RvListaClientesTableAdapter As ContaExpress.DsRVClientesTableAdapters.RVListaClientesTableAdapter
    Friend WithEvents RVTipoComprobanteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RVTipoComprobanteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVTipoComprobanteTableAdapter
    Friend WithEvents DsRVFacturacion As ContaExpress.DsRVFacturacion
    Friend WithEvents RvComprobantesTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesTableAdapter
    Friend WithEvents RvVentasPorVendedorTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVVentasPorVendedorTableAdapter
    Friend WithEvents ProductosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RVProductosTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVProductosTableAdapter
    Friend WithEvents DsRVNotasCredito As ContaExpress.DsRVNotasCredito
    Friend WithEvents RvNotasDeCreditoTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVNotasDeCreditoTableAdapter
    Friend WithEvents RvCobrosClientesTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesTableAdapter
    Friend WithEvents RvclientesTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVCLIENTESTableAdapter
    Friend WithEvents RvPendientePorClienteProductoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVPendientePorClienteProductoTableAdapter
    Friend WithEvents RvCobrosClientesTableAdapter1 As ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesTableAdapter
    Friend WithEvents DsRVCobros As ContaExpress.DsRVCobros
    Friend WithEvents RvFacturasXReciboTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVFacturasXReciboTableAdapter
    Friend WithEvents RvPendientesCobroTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVPendientesCobroTableAdapter
    Friend WithEvents DsRVEnvios As ContaExpress.DsRVEnvios
    Friend WithEvents RvEnviosPorZonaProductoTableAdapter As ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorZonaProductoTableAdapter
    Friend WithEvents RvEnviosPorClienteTableAdapter As ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorClienteTableAdapter
    Friend WithEvents chbxMatricial As System.Windows.Forms.CheckBox
    Friend WithEvents RvEnviosPorClienteProductoTableAdapter As ContaExpress.DsRVEnviosTableAdapters.RVEnviosPorClienteProductoTableAdapter
    Friend WithEvents RvchdiF_NCREDTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVCHDIF_NCREDTableAdapter
    Friend WithEvents RvPendienteCobroDifTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVPendienteCobroDifTableAdapter
    Friend WithEvents RvVentasResumenTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVVentasResumenTableAdapter
    Friend WithEvents RvMovimientosClienteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVMovimientosClienteTableAdapter
    Friend WithEvents RvRankingClientesTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVRankingClientesTableAdapter
    Friend WithEvents DsRVEstadisticas As ContaExpress.DsRVEstadisticas
    Friend WithEvents RvRankingProductosTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVRankingProductosTableAdapter
    Friend WithEvents RvVentasCompletoTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVVentasCompletoTableAdapter
    Friend WithEvents TotalMovimientosCompraTableAdapter As ContaExpress.DsReporteVentasTableAdapters.TotalMovimientosCompraTableAdapter
    Friend WithEvents DsRVCaja As ContaExpress.DsRVCaja
    Friend WithEvents RvDiarioCajaTableAdapter As ContaExpress.DsRVCajaTableAdapters.RVDiarioCajaTableAdapter
    Friend WithEvents RvTotalTableAdapter As ContaExpress.DsRVCajaTableAdapters.RVTotalTableAdapter
    Friend WithEvents RvCajaIvaTableAdapter As ContaExpress.DsRVCajaTableAdapters.RVCajaIvaTableAdapter
    Friend WithEvents RvAperturaCierreTableAdapter As ContaExpress.DsRVCajaTableAdapters.RVAperturaCierreTableAdapter
    Friend WithEvents CompraMovimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pbxCerrarFiltros As System.Windows.Forms.PictureBox
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents chbxCodProducto As System.Windows.Forms.CheckBox
    Friend WithEvents tbxcodProd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPos5 As System.Windows.Forms.Label
    Friend WithEvents lblPos6 As System.Windows.Forms.Label
    Friend WithEvents lblPos7 As System.Windows.Forms.Label
    Friend WithEvents tbxcodCliente As System.Windows.Forms.TextBox
    Friend WithEvents BtnAsteriscoCliente As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAsteriscoProducto As System.Windows.Forms.PictureBox
    Friend WithEvents chbxCodCliente As System.Windows.Forms.CheckBox
    Friend WithEvents pnlIntervalo As System.Windows.Forms.Panel
    Friend WithEvents rbtnAño As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSemestre As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnQuincena As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSemana As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDia As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnHora As System.Windows.Forms.RadioButton
    Friend WithEvents pnlIntervaloActivo As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlSinFiltro As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chbxNuevaVent As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlLocalidad As System.Windows.Forms.Panel
    Friend WithEvents pnlCategorias As System.Windows.Forms.Panel
    Friend WithEvents pnlfechas As System.Windows.Forms.Panel
    Friend WithEvents pnlCuenta As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlComprobante As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlVendedor As System.Windows.Forms.Panel
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents pnlSucursal As System.Windows.Forms.Panel
    Friend WithEvents pnlTipo As System.Windows.Forms.Panel
    Friend WithEvents pnlMoneda As System.Windows.Forms.Panel
    Friend WithEvents pnlListaPrecio As System.Windows.Forms.Panel
    Friend WithEvents pnlCliente As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnFiltros As System.Windows.Forms.Button
    Friend WithEvents GroupBoxCliente As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TxtBuscaCliente As System.Windows.Forms.TextBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents ProductosGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TabBuscador As Telerik.WinControls.UI.RadTabStrip
    Friend WithEvents Producto As Telerik.WinControls.UI.TabItem
    Friend WithEvents Remision As Telerik.WinControls.UI.TabItem
    Friend WithEvents RadGridViewDetalleRemisiones As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BuscarProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProductosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GridViewClientes As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvListaReportes As System.Windows.Forms.DataGridView
    Friend WithEvents TITULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALABRASCLAVE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ttipNumCliente As System.Windows.Forms.ToolTip
    Friend WithEvents ttipCodProducto As System.Windows.Forms.ToolTip
    Friend WithEvents RvComprobantesResumidoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesResumidoTableAdapter
    Friend WithEvents RvComprobantesPorProductoResumTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVComprobantesPorProductoResumTableAdapter
    Friend WithEvents DsRVComprobantes As ContaExpress.DsRVComprobantes
    Friend WithEvents RvNotasDeCreditoPorProdTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVNotasDeCreditoPorProdTableAdapter
    Friend WithEvents RvncclientesTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVNCCLIENTESTableAdapter
    Friend WithEvents RvcclientesTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVCCLIENTESTableAdapter
    Friend WithEvents RvVentasPorProductoComparativoMesAnhoTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPorProductoComparativoMesAnhoTableAdapter
    Friend WithEvents RvVentasPorClienteComparativoMesAnhoTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPorClienteComparativoMesAnhoTableAdapter
    Friend WithEvents pnlCategCliente As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RventascategoriaclienteTableAdapter As ContaExpress.DsReporteVentasTableAdapters.RVENTASCATEGORIACLIENTETableAdapter
    Friend WithEvents CategoriaClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSettingFO As ContaExpress.DsSettingFO
    Friend WithEvents cmbVendedor As PresentationControls.CheckBoxComboBox
    Friend WithEvents RVIVADetalladoTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVIVADETALLADOTableAdapter
    Friend WithEvents RvivancventasTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVIVANCVENTASTableAdapter
    Friend WithEvents cmbZona1 As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbTipo As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbCategCliente As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbComprobante As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbListaPrecio As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbSucursal As PresentationControls.CheckBoxComboBox
    Friend WithEvents RvCobrosClientesNCTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVCobrosClientesNCTableAdapter
    Friend WithEvents RvComprobantesAgrupCliTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesAgrupCliTableAdapter
    Friend WithEvents DsRVComisiones As ContaExpress.DsRVComisiones
    Friend WithEvents ComisionVendedorTableAdapter As ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobranzaTableAdapter
    Friend WithEvents pnlIVA As System.Windows.Forms.Panel
    Friend WithEvents rbIVANO As System.Windows.Forms.RadioButton
    Friend WithEvents rbIVASI As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlFactCobr As System.Windows.Forms.Panel
    Friend WithEvents rbPorCobr As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorFact As System.Windows.Forms.RadioButton
    Friend WithEvents ComisionVendedorFacturacionTableAdapter As ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorFacturacionTableAdapter
    Friend WithEvents ComisionVendedorCobrDetTableAdapter As ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobrDetTableAdapter
    Friend WithEvents RvVentasPorZONATableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVVentasPorZONATableAdapter
    Friend WithEvents RvVentasPrecioVentaVsCostoPorProductoTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVVentasPrecioVentaVsCostoPorProductoTableAdapter
    Friend WithEvents RvComprobantesPorProductoPorFechaTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVComprobantesPorProductoPorFechaTableAdapter
    Friend WithEvents pnlEstado As System.Windows.Forms.Panel
    Friend WithEvents cmbEstado As PresentationControls.CheckBoxComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlRelacionado As System.Windows.Forms.Panel
    Friend WithEvents cmbRelacionado As PresentationControls.CheckBoxComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlOtrasOpciones As System.Windows.Forms.Panel
    Friend WithEvents rbSinAgrup As System.Windows.Forms.RadioButton
    Friend WithEvents rbAgrupFamillia As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents RvNotasCreditoPendienteTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVNotasCreditoPendienteTableAdapter
    Friend WithEvents RvComprPorVendPorProductoTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVComprPorVendPorProductoTableAdapter
    Friend WithEvents pbxRangoCli As System.Windows.Forms.PictureBox
    Friend WithEvents pbxRangoProd As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RvClientesAtrasadosTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVCLIENTESATRASADOSTableAdapter
    Friend WithEvents RvFacturasACobrarTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVFACTURASACOBRARTableAdapter
    Friend WithEvents RvRecibosClienteDetTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVRecibosClienteDetTableAdapter
    Friend WithEvents RVAnalisisDeSaldoTableAdapter As ContaExpress.DsRVCobrosTableAdapters.RVANALISISDESALDOTableAdapter
    Friend WithEvents RvComprobantePorProductoPorClienteTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVComprobantePorProductoPorClienteTableAdapter
    Friend WithEvents RvncPorProductoResumTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVNCPorProductoResumTableAdapter
    Friend WithEvents RvventasporclientesTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVVENTASPORCLIENTESTableAdapter
    Friend WithEvents RvincidenciancsobrevtaTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVINCIDENCIANCSOBREVTATableAdapter
    Friend WithEvents RVVentasPorZonatipoTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVVENTASPORZONATIPOTableAdapter
    Friend WithEvents RVVentasPorZonaPromedioTableAdapter As ContaExpress.DsRVComprobantesTableAdapters.RVVENTASPORZONAPROMEDIOTableAdapter
    Friend WithEvents pnlIngresoStock As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbIngresoStock As PresentationControls.CheckBoxComboBox
    Friend WithEvents pnlVisualizar As System.Windows.Forms.Panel
    Friend WithEvents rbtConGrafico As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSinGrafico As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ListaClientesporlistaPrecioTableAdapter As ContaExpress.DsReporteVentasTableAdapters.ListaClientesporlistaPrecioTableAdapter
    Friend WithEvents NotaCreditoDetalladoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.NotaCreditoDetalladoTableAdapter
    Friend WithEvents pnlVisualizardatos As System.Windows.Forms.Panel
    Friend WithEvents rbtSinNumFac As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConNroFac As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents LibroVentasLeyTableAdapter As ContaExpress.DsReporteVentasTableAdapters.LibroVentasLeyTableAdapter
    Friend WithEvents PorcentajedeventaTableAdapter As ContaExpress.DsReporteVentasTableAdapters.PorcentajedeventaTableAdapter
    Friend WithEvents ListadereciboTableAdapter As ContaExpress.DsReporteVentasTableAdapters.ListadereciboTableAdapter
    Friend WithEvents ComisionVendedorCobranzaTipoVentaTableAdapter As ContaExpress.DsRVComisionesTableAdapters.ComisionVendedorCobranzaTipoVentaTableAdapter
    Friend WithEvents RvnclibroivaTableAdapter As ContaExpress.DsRVNotasCreditoTableAdapters.RVNCLIBROIVATableAdapter
    Friend WithEvents pnlDetalleEnvio As System.Windows.Forms.Panel
    Friend WithEvents rbtSinDetalleProducto As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConDetalleProducto As System.Windows.Forms.RadioButton
    Friend WithEvents RvHistoricoClienteTableAdapter1 As ContaExpress.DsRVClientesTableAdapters.RVHistoricoClienteTableAdapter
    Friend WithEvents RvListaPresupuestoTableAdapter1 As ContaExpress.DsRVFacturacionTableAdapters.RVListaPresupuestoTableAdapter
    Friend WithEvents pnlAnulados As System.Windows.Forms.Panel
    Friend WithEvents rbtsinanuladas As System.Windows.Forms.RadioButton
    Friend WithEvents rbtConanuladas As System.Windows.Forms.RadioButton
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents LibroIvaTicketTableAdapter As ContaExpress.DsInfContabilidadTableAdapters.LibroIvaTicketTableAdapter
    Friend WithEvents RvComprobantesPendNuevoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVComprobantesPendNuevoTableAdapter
    Friend WithEvents pnlNumFactura As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents RvUtilidadVentasTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.RVUtilidadVentasTableAdapter
    Friend WithEvents RVUtilidadVentasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRVEstadisticasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NumVentaTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.NumVentaTableAdapter
    Friend WithEvents txtNumVenta As System.Windows.Forms.TextBox
    Friend WithEvents VentasDetXClienteTableAdapter As ContaExpress.DsRVEstadisticasTableAdapters.VentasDetXClienteTableAdapter
    Friend WithEvents RvPresupuestoDetalladoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVPresupuestoDetalladoTableAdapter
    Friend WithEvents pnlTipoCobro As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents VentasTipoPagoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VentasTipoPagoTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.VentasTipoPagoTableAdapter
    Friend WithEvents TIPOFORMACOBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOFORMACOBROTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.TIPOFORMACOBROTableAdapter
    Friend WithEvents cmbTipoCobro As System.Windows.Forms.ComboBox
    Friend WithEvents DsComisiones1 As ContaExpress.DsComisiones
    Friend WithEvents LiquidacionvendTableAdapter As ContaExpress.DsComisionesTableAdapters.LIQUIDACIONVENDTableAdapter
    Friend WithEvents VentascaidasTableAdapter As ContaExpress.DsComisionesTableAdapters.VENTASCAIDASTableAdapter
    Friend WithEvents CompSaldoClientes As ContaExpress.CompSaldoClientes
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable1TableAdapter As ContaExpress.CompSaldoClientesTableAdapters.DataTable1TableAdapter
    Friend WithEvents TableAdapterManager1 As ContaExpress.CompSaldoClientesTableAdapters.TableAdapterManager
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCLIENTE1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREFANTASIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsRVComisiones1 As ContaExpress.DsRVComisiones
    Friend WithEvents DsProyeccionCobros As ContaExpress.DsProyeccionCobros
    Friend WithEvents DsProyeccionCobrosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProyeccionCobrosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ProyeccionCobrosTableAdapter As ContaExpress.DsProyeccionCobrosTableAdapters.ProyeccionCobrosTableAdapter
    Friend WithEvents EMPRESABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EMPRESATableAdapter As ContaExpress.DsProyeccionCobrosTableAdapters.EMPRESATableAdapter
    Friend WithEvents PendCobroDetalladoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PendCobroDetalladoTableAdapter As ContaExpress.DsRVCobrosTableAdapters.PendCobroDetalladoTableAdapter
    Friend WithEvents ComisionNotasCreditoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComisionNotasCreditoTableAdapter As ContaExpress.DsRVComisionesTableAdapters.ComisionNotasCreditoTableAdapter
    Friend WithEvents DsFacturacionPorVendedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsFacturacionPorVendedor As ContaExpress.dsFacturacionPorVendedor
    Friend WithEvents FacturacionPorVendedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FacturacionPorVendedorTableAdapter As ContaExpress.dsFacturacionPorVendedorTableAdapters.FacturacionPorVendedorTableAdapter
    Friend WithEvents DsTotalMovimientoHistoricoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MovimientoHistoricoTotalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MovClienteTOTALESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MovClienteTOTALESTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.MovClienteTOTALESTableAdapter
    Friend WithEvents DsContaBalanceGeneral173 As ContaExpress.DsContaBalanceGeneral173
    Friend WithEvents MovimientoRemisionesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MovimientoRemisionesTableAdapter As ContaExpress.DsContaBalanceGeneral173TableAdapters.MovimientoRemisionesTableAdapter
    'Friend WithEvents CompraMovimientoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CompraMovimientoTableAdapter
End Class
