<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCompras))
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pendientes por Proveedor")
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras Pendientes", New System.Windows.Forms.TreeNode() {TreeNode31})
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos por Sucursal")
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos por Centro de Costos")
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos por Centro de Costos Detallado")
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos Total Lineal")
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gastos Total Mensual")
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estadisticas de Gastos", New System.Windows.Forms.TreeNode() {TreeNode33, TreeNode34, TreeNode35, TreeNode36, TreeNode37})
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras por Productos")
        Dim TreeNode40 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Precios de Ultima Compra")
        Dim TreeNode41 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Costo Promedio por Producto")
        Dim TreeNode42 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Costo Promedio por Producto Det.")
        Dim TreeNode43 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Listado de Ordenes de Compra")
        Dim TreeNode44 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estadisticas de Compras", New System.Windows.Forms.TreeNode() {TreeNode39, TreeNode40, TreeNode41, TreeNode42, TreeNode43})
        Dim TreeNode45 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Analisis de Saldos")
        Dim TreeNode46 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Estado Cuenta Proveedor")
        Dim TreeNode47 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobantes Pendientes")
        Dim TreeNode48 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Facturas a Pagar")
        Dim TreeNode49 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Facturas Por Recibo")
        Dim TreeNode50 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Retenciones")
        Dim TreeNode51 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recibos Por Factura")
        Dim TreeNode52 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recibos Proveedor")
        Dim TreeNode53 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Recibos Proveedor Detallado")
        Dim TreeNode54 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reportes de Pagos", New System.Windows.Forms.TreeNode() {TreeNode45, TreeNode46, TreeNode47, TreeNode48, TreeNode49, TreeNode50, TreeNode51, TreeNode52, TreeNode53})
        Dim TreeNode55 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Proveedores")
        Dim TreeNode56 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reportes Auxiliares", New System.Windows.Forms.TreeNode() {TreeNode55})
        Dim TreeNode57 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Precio de Compra por Producto Por Prov.")
        Dim TreeNode58 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Libro Iva Compras -  125/91")
        Dim TreeNode59 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Libro Iva Notas de Crédito - 125/91")
        Dim TreeNode60 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras Aprobadas", New System.Windows.Forms.TreeNode() {TreeNode57, TreeNode58, TreeNode59})
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSReporteCompras1 = New ContaExpress.DSReporteCompras()
        Me.cbxRubro = New System.Windows.Forms.ComboBox()
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxLinea = New System.Windows.Forms.ComboBox()
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCategoria = New System.Windows.Forms.ComboBox()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chbxCodigosProductos = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbxCodigosProductos = New System.Windows.Forms.TextBox()
        Me.pnlFecha = New System.Windows.Forms.Panel()
        Me.pnlFechaPeriodo = New System.Windows.Forms.Panel()
        Me.cmbHasta = New System.Windows.Forms.ComboBox()
        Me.cmbDesde = New System.Windows.Forms.ComboBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Mes = New System.Windows.Forms.Label()
        Me.pnlFechaActivo = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlProveedor = New System.Windows.Forms.Panel()
        Me.pbxRangoProv = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.PROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxcodProv = New System.Windows.Forms.TextBox()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbMoneda = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlIntervalo = New System.Windows.Forms.Panel()
        Me.lblIva = New System.Windows.Forms.Label()
        Me.pnlOtrasOpciones = New System.Windows.Forms.Panel()
        Me.pnlIva = New System.Windows.Forms.Panel()
        Me.rbSinIva = New System.Windows.Forms.RadioButton()
        Me.rbConIva = New System.Windows.Forms.RadioButton()
        Me.rbSinAgrup = New System.Windows.Forms.RadioButton()
        Me.rbAgrupFamillia = New System.Windows.Forms.RadioButton()
        Me.rbtnAño = New System.Windows.Forms.RadioButton()
        Me.rbtnSemestre = New System.Windows.Forms.RadioButton()
        Me.rbtnMes = New System.Windows.Forms.RadioButton()
        Me.rbtnQuincena = New System.Windows.Forms.RadioButton()
        Me.rbtnsemana = New System.Windows.Forms.RadioButton()
        Me.rbtndia = New System.Windows.Forms.RadioButton()
        Me.pnlIntervaloActivo = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblAgrupacion = New System.Windows.Forms.Label()
        Me.btnFiltroProd = New System.Windows.Forms.Button()
        Me.btnFiltroEmpresa = New System.Windows.Forms.Button()
        Me.btnFiltroProveedor = New System.Windows.Forms.Button()
        Me.btnFiltroFinanciero = New System.Windows.Forms.Button()
        Me.pnlProductos = New System.Windows.Forms.Panel()
        Me.lblAyudaCodProd = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.pnlFinanciero = New System.Windows.Forms.Panel()
        Me.cmbComprobante = New System.Windows.Forms.ComboBox()
        Me.RCTIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRCPagos = New ContaExpress.DsRCPagos()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlEmpresa = New System.Windows.Forms.Panel()
        Me.cmbtipo = New System.Windows.Forms.ComboBox()
        Me.LblTipo = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cbxCdC = New System.Windows.Forms.ComboBox()
        Me.CENTROCOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbtipo2 = New System.Windows.Forms.ComboBox()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.treeReportesVentas = New System.Windows.Forms.TreeView()
        Me.chbxMatricial = New System.Windows.Forms.CheckBox()
        Me.RcchdifTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCCHDIFTableAdapter()
        Me.RcPendientePagoDifTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCPendientePagoDifTableAdapter()
        Me.RcNotasCreditoTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCNotasCreditoTableAdapter()
        Me.RcFacturasXReciboTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCFacturasXReciboTableAdapter()
        Me.RcPagosProveedorTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCPagosProveedorTableAdapter()
        Me.RcMovimientosProveedorTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCMovimientosProveedorTableAdapter()
        Me.RCIVANCREDITOComprasTableAdapter = New ContaExpress.DsRCNCreditoTableAdapters.RCIVANCREDITOCOMPRASTableAdapter()
        Me.DsRCNCredito = New ContaExpress.DsRCNCredito()
        Me.RCOMPRASLISTATableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCCOMPRASLISTATableAdapter()
        Me.RCTIPOCOMPROBANTETableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCTIPOCOMPROBANTETableAdapter()
        Me.RcRetencionesTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCRetencionesTableAdapter()
        Me.RcProductosPorProveedorTableAdapter = New ContaExpress.DsRCComprasTableAdapters.RCProductosPorProveedorTableAdapter()
        Me.DsRCCompras = New ContaExpress.DsRCCompras()
        Me.RCFacturasAPagarTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCFACTURASAPAGARTableAdapter()
        Me.RCRecibosProveedorDetTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCRECIBOSPROVEEDORDETTableAdapter()
        Me.RcAnalisisdeSaldosTableAdapter = New ContaExpress.DsRCPagosTableAdapters.RCAnalisisdeSaldosTableAdapter()
        Me.DSReporteCompras = New ContaExpress.DSReporteCompras()
        Me.CdC_LinealBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CdC_LinealTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CdC_LinealTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DSReporteComprasTableAdapters.TableAdapterManager()
        Me.COMPRASDETALLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.COMPRASDETALLETableAdapter = New ContaExpress.DSReporteComprasTableAdapters.COMPRASDETALLETableAdapter()
        Me.TotalStockActualBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TotalStockActualTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.TotalStockActualTableAdapter()
        Me.FAMILIATableAdapter = New ContaExpress.DSReporteComprasTableAdapters.FAMILIATableAdapter()
        Me.LINEATableAdapter = New ContaExpress.DSReporteComprasTableAdapters.LINEATableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.RUBROTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.PRODUCTOSTableAdapter()
        Me.ComprasPorProductoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasPorProductoTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasPorProductoTableAdapter()
        Me.ComprasPorSucursalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasPorSucursalTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasPorSucursalTableAdapter()
        Me.CENTROCOSTOTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CENTROCOSTOTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.SUCURSALTableAdapter()
        Me.ComprasPendienteProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasPendienteProveedorTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasPendienteProveedorTableAdapter()
        Me.PROVEEDORTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.PROVEEDORTableAdapter()
        Me.ListaProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListaProveedorTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ListaProveedorTableAdapter()
        Me.ComprasPorCategoriaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasPorCategoriaTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasPorCategoriaTableAdapter()
        Me.CompraDiarioCajaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CompraDiarioCajaTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CompraDiarioCajaTableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DSReporteComprasTableAdapters.MONEDATableAdapter()
        Me.CAJATableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CAJATableAdapter()
        Me.DiarioCajaResumenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DiarioCajaResumenTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.DiarioCajaResumenTableAdapter()
        Me.FacturaAPagarBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FacturaAPagarTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.FacturaAPagarTableAdapter()
        Me.GastosPorProductoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GastosPorProductoTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.GastosPorProductoTableAdapter()
        Me.UltimaCompraDiasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltimaCompraDiasTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter()
        Me.ComprasCOGsPromedioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasCOGsPromedioTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasCOGsPromedioTableAdapter()
        Me.COGSDetalladoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.COGSDetalladoTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.COGSDetalladoTableAdapter()
        Me.CostoFijoCAntidadVentaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CostoFijoCAntidadVentaTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CostoFijoCAntidadVentaTableAdapter()
        Me.COSTOFIJOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.COSTOFIJOTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.COSTOFIJOTableAdapter()
        Me.ListaPrecioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListaPrecioTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ListaPrecioTableAdapter()
        Me.CuentaCorrienteProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CuentaCorrienteProveedorTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.CuentaCorrienteProveedorTableAdapter()
        Me.ComprasAprobadasTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.ComprasAprobadasTableAdapter()
        Me.RCIVAComprasTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.RCIVACOMPRASTableAdapter()
        Me.RcivaleyTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.RCIVALEYTableAdapter()
        Me.RcivancleyTableAdapter = New ContaExpress.DSReporteComprasTableAdapters.RCIVANCLEYTableAdapter()
        Me.ListaOrdenCompraTableAdapter1 = New ContaExpress.DSReporteComprasTableAdapters.ListaOrdenCompraTableAdapter()
        Me.CentroDetalladoTableAdapter = New ContaExpress.DsDetalleCentroTableAdapters.CentroDetalladoTableAdapter()
        Me.DsDetalleCentro = New ContaExpress.DsDetalleCentro()
        Me.LibroivacomprA_RCTableAdapter = New ContaExpress.DsRCComprasTableAdapters.LIBROIVACOMPRA_RCTableAdapter()
        Me.DsProveedores = New ContaExpress.DsProveedores()
        Me.ListaProvBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ListaProvTableAdapter = New ContaExpress.DsProveedoresTableAdapters.ListaProvTableAdapter()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSReporteCompras1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFecha.SuspendLayout()
        Me.pnlFechaPeriodo.SuspendLayout()
        Me.pnlFechaActivo.SuspendLayout()
        Me.pnlProveedor.SuspendLayout()
        CType(Me.pbxRangoProv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIntervalo.SuspendLayout()
        Me.pnlOtrasOpciones.SuspendLayout()
        Me.pnlIva.SuspendLayout()
        Me.pnlIntervaloActivo.SuspendLayout()
        Me.pnlProductos.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlSinFiltro.SuspendLayout()
        Me.pnlFinanciero.SuspendLayout()
        CType(Me.RCTIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRCPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlEmpresa.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRCNCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRCCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSReporteCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdC_LinealBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COMPRASDETALLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalStockActualBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasPorProductoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasPorSucursalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasPendienteProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListaProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasPorCategoriaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompraDiarioCajaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiarioCajaResumenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturaAPagarBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GastosPorProductoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltimaCompraDiasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasCOGsPromedioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COGSDetalladoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CostoFijoCAntidadVentaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COSTOFIJOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListaPrecioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CuentaCorrienteProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsDetalleCentro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListaProvBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbProducto
        '
        Me.cmbProducto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmbProducto.DataSource = Me.PRODUCTOSBindingSource
        Me.cmbProducto.DisplayMember = "DESPRODUCTO"
        Me.cmbProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(47, 132)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(433, 32)
        Me.cmbProducto.TabIndex = 3
        Me.cmbProducto.ValueMember = "CODPRODUCTO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DSReporteCompras1
        '
        'DSReporteCompras1
        '
        Me.DSReporteCompras1.DataSetName = "DSReporteCompras"
        Me.DSReporteCompras1.EnforceConstraints = False
        Me.DSReporteCompras1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxRubro
        '
        Me.cbxRubro.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxRubro.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxRubro.DataSource = Me.RUBROBindingSource
        Me.cbxRubro.DisplayMember = "DESRUBRO"
        Me.cbxRubro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRubro.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRubro.FormattingEnabled = True
        Me.cbxRubro.Location = New System.Drawing.Point(340, 70)
        Me.cbxRubro.Name = "cbxRubro"
        Me.cbxRubro.Size = New System.Drawing.Size(140, 33)
        Me.cbxRubro.TabIndex = 2
        Me.cbxRubro.ValueMember = "CODRUBRO"
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "RUBRO"
        Me.RUBROBindingSource.DataSource = Me.DSReporteCompras1
        '
        'cbxLinea
        '
        Me.cbxLinea.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxLinea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxLinea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxLinea.BackColor = System.Drawing.Color.GhostWhite
        Me.cbxLinea.DataSource = Me.LINEABindingSource
        Me.cbxLinea.DisplayMember = "DESLINEA"
        Me.cbxLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxLinea.FormattingEnabled = True
        Me.cbxLinea.Location = New System.Drawing.Point(194, 70)
        Me.cbxLinea.Name = "cbxLinea"
        Me.cbxLinea.Size = New System.Drawing.Size(140, 33)
        Me.cbxLinea.TabIndex = 1
        Me.cbxLinea.ValueMember = "CODLINEA"
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "LINEA"
        Me.LINEABindingSource.DataSource = Me.DSReporteCompras1
        '
        'cbxCategoria
        '
        Me.cbxCategoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbxCategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxCategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxCategoria.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxCategoria.DataSource = Me.FAMILIABindingSource
        Me.cbxCategoria.DisplayMember = "DESFAMILIA"
        Me.cbxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCategoria.FormattingEnabled = True
        Me.cbxCategoria.Location = New System.Drawing.Point(48, 70)
        Me.cbxCategoria.Name = "cbxCategoria"
        Me.cbxCategoria.Size = New System.Drawing.Size(140, 33)
        Me.cbxCategoria.TabIndex = 0
        Me.cbxCategoria.ValueMember = "CODFAMILIA"
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DSReporteCompras1
        '
        'chbxCodigosProductos
        '
        Me.chbxCodigosProductos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chbxCodigosProductos.AutoSize = True
        Me.chbxCodigosProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCodigosProductos.ForeColor = System.Drawing.Color.Gainsboro
        Me.chbxCodigosProductos.Location = New System.Drawing.Point(48, 172)
        Me.chbxCodigosProductos.Name = "chbxCodigosProductos"
        Me.chbxCodigosProductos.Size = New System.Drawing.Size(247, 20)
        Me.chbxCodigosProductos.TabIndex = 4
        Me.chbxCodigosProductos.Text = "Selecionar los Productos por Codigo"
        Me.chbxCodigosProductos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(343, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Rubro"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(197, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Linea"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(49, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Familia"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(50, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Productos"
        '
        'tbxCodigosProductos
        '
        Me.tbxCodigosProductos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCodigosProductos.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbxCodigosProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodigosProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodigosProductos.Location = New System.Drawing.Point(47, 53)
        Me.tbxCodigosProductos.Multiline = True
        Me.tbxCodigosProductos.Name = "tbxCodigosProductos"
        Me.tbxCodigosProductos.Size = New System.Drawing.Size(434, 112)
        Me.tbxCodigosProductos.TabIndex = 2
        Me.tbxCodigosProductos.Visible = False
        '
        'pnlFecha
        '
        Me.pnlFecha.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFecha.BackColor = System.Drawing.Color.DimGray
        Me.pnlFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFecha.Controls.Add(Me.pnlFechaPeriodo)
        Me.pnlFecha.Controls.Add(Me.pnlFechaActivo)
        Me.pnlFecha.Controls.Add(Me.dtpFechaHasta)
        Me.pnlFecha.Controls.Add(Me.dtpFechaDesde)
        Me.pnlFecha.Controls.Add(Me.Label7)
        Me.pnlFecha.Controls.Add(Me.Label11)
        Me.pnlFecha.Location = New System.Drawing.Point(306, 353)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Size = New System.Drawing.Size(526, 78)
        Me.pnlFecha.TabIndex = 4
        '
        'pnlFechaPeriodo
        '
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbHasta)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbDesde)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbAño)
        Me.pnlFechaPeriodo.Controls.Add(Me.cmbMes)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label23)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label19)
        Me.pnlFechaPeriodo.Controls.Add(Me.Label26)
        Me.pnlFechaPeriodo.Controls.Add(Me.Mes)
        Me.pnlFechaPeriodo.Location = New System.Drawing.Point(-11, 22)
        Me.pnlFechaPeriodo.Name = "pnlFechaPeriodo"
        Me.pnlFechaPeriodo.Size = New System.Drawing.Size(545, 54)
        Me.pnlFechaPeriodo.TabIndex = 497
        '
        'cmbHasta
        '
        Me.cmbHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbHasta.FormattingEnabled = True
        Me.cmbHasta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbHasta.Location = New System.Drawing.Point(462, 21)
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
        Me.cmbDesde.Location = New System.Drawing.Point(391, 21)
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
        Me.cmbAño.Location = New System.Drawing.Point(187, 21)
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
        Me.cmbMes.Location = New System.Drawing.Point(33, 21)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(138, 28)
        Me.cmbMes.TabIndex = 3
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label23.Location = New System.Drawing.Point(459, 3)
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
        Me.Label19.Location = New System.Drawing.Point(388, 3)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 15)
        Me.Label19.TabIndex = 9
        Me.Label19.Text = "Desde"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(186, 3)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(28, 15)
        Me.Label26.TabIndex = 6
        Me.Label26.Text = "Año"
        '
        'Mes
        '
        Me.Mes.AutoSize = True
        Me.Mes.BackColor = System.Drawing.Color.Transparent
        Me.Mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mes.Location = New System.Drawing.Point(30, 3)
        Me.Mes.Name = "Mes"
        Me.Mes.Size = New System.Drawing.Size(31, 15)
        Me.Mes.TabIndex = 7
        Me.Mes.Text = "Mes"
        '
        'pnlFechaActivo
        '
        Me.pnlFechaActivo.BackColor = System.Drawing.Color.DimGray
        Me.pnlFechaActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFechaActivo.Controls.Add(Me.Label9)
        Me.pnlFechaActivo.Controls.Add(Me.Label24)
        Me.pnlFechaActivo.Location = New System.Drawing.Point(-2, -1)
        Me.pnlFechaActivo.Name = "pnlFechaActivo"
        Me.pnlFechaActivo.Size = New System.Drawing.Size(529, 25)
        Me.pnlFechaActivo.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(0, -1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 21)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Filtro de Fecha"
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
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(277, 42)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(128, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
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
        Me.dtpFechaDesde.Location = New System.Drawing.Point(137, 42)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(128, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(134, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Desde"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(276, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 15)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Hasta"
        '
        'pnlProveedor
        '
        Me.pnlProveedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlProveedor.BackColor = System.Drawing.Color.DimGray
        Me.pnlProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProveedor.Controls.Add(Me.pbxRangoProv)
        Me.pnlProveedor.Controls.Add(Me.Panel3)
        Me.pnlProveedor.Controls.Add(Me.Label14)
        Me.pnlProveedor.Controls.Add(Me.cmbProveedor)
        Me.pnlProveedor.Controls.Add(Me.tbxcodProv)
        Me.pnlProveedor.Location = New System.Drawing.Point(307, 129)
        Me.pnlProveedor.Name = "pnlProveedor"
        Me.pnlProveedor.Size = New System.Drawing.Size(527, 197)
        Me.pnlProveedor.TabIndex = 3
        '
        'pbxRangoProv
        '
        Me.pbxRangoProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxRangoProv.Image = CType(resources.GetObject("pbxRangoProv.Image"), System.Drawing.Image)
        Me.pbxRangoProv.Location = New System.Drawing.Point(486, 90)
        Me.pbxRangoProv.Name = "pbxRangoProv"
        Me.pbxRangoProv.Size = New System.Drawing.Size(21, 22)
        Me.pbxRangoProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxRangoProv.TabIndex = 502
        Me.pbxRangoProv.TabStop = False
        Me.pbxRangoProv.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Crimson
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Location = New System.Drawing.Point(-1, -1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(529, 30)
        Me.Panel3.TabIndex = 9
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(5, 3)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(240, 21)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Filtro de Localidades y Proveedor"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(47, 68)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 15)
        Me.Label14.TabIndex = 15
        Me.Label14.Text = "Proveedor"
        '
        'cmbProveedor
        '
        Me.cmbProveedor.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cmbProveedor.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbProveedor.DataSource = Me.PROVEEDORBindingSource
        Me.cmbProveedor.DisplayMember = "NOMBRE"
        Me.cmbProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.cmbProveedor.FormattingEnabled = True
        Me.cmbProveedor.Location = New System.Drawing.Point(43, 85)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(434, 33)
        Me.cmbProveedor.TabIndex = 7
        Me.cmbProveedor.ValueMember = "CODPROVEEDOR"
        '
        'PROVEEDORBindingSource
        '
        Me.PROVEEDORBindingSource.DataMember = "PROVEEDOR"
        Me.PROVEEDORBindingSource.DataSource = Me.DSReporteCompras1
        '
        'tbxcodProv
        '
        Me.tbxcodProv.BackColor = System.Drawing.Color.LightSteelBlue
        Me.tbxcodProv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxcodProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxcodProv.Location = New System.Drawing.Point(41, 85)
        Me.tbxcodProv.Multiline = True
        Me.tbxcodProv.Name = "tbxcodProv"
        Me.tbxcodProv.Size = New System.Drawing.Size(436, 33)
        Me.tbxcodProv.TabIndex = 30
        '
        'cmbCaja
        '
        Me.cmbCaja.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbCaja.DataSource = Me.CAJABindingSource
        Me.cmbCaja.DisplayMember = "NUMEROCAJA"
        Me.cmbCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.Location = New System.Drawing.Point(47, 103)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(434, 33)
        Me.cmbCaja.TabIndex = 1
        Me.cmbCaja.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DSReporteCompras1
        '
        'cmbMoneda
        '
        Me.cmbMoneda.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbMoneda.DataSource = Me.MONEDABindingSource
        Me.cmbMoneda.DisplayMember = "DESMONEDA"
        Me.cmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMoneda.FormattingEnabled = True
        Me.cmbMoneda.Location = New System.Drawing.Point(47, 48)
        Me.cmbMoneda.Name = "cmbMoneda"
        Me.cmbMoneda.Size = New System.Drawing.Size(434, 33)
        Me.cmbMoneda.TabIndex = 0
        Me.cmbMoneda.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DSReporteCompras1
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbSucursal.DataSource = Me.SUCURSALBindingSource
        Me.cmbSucursal.DisplayMember = "DESSUCURSAL"
        Me.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(47, 99)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(434, 33)
        Me.cmbSucursal.TabIndex = 2
        Me.cmbSucursal.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DSReporteCompras1
        '
        'btnGenerar
        '
        Me.btnGenerar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenerar.BackColor = System.Drawing.Color.GreenYellow
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGenerar.Location = New System.Drawing.Point(559, 516)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(275, 42)
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(301, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Filtros para:"
        '
        'pnlIntervalo
        '
        Me.pnlIntervalo.BackColor = System.Drawing.Color.DimGray
        Me.pnlIntervalo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIntervalo.Controls.Add(Me.lblIva)
        Me.pnlIntervalo.Controls.Add(Me.pnlOtrasOpciones)
        Me.pnlIntervalo.Controls.Add(Me.rbtnAño)
        Me.pnlIntervalo.Controls.Add(Me.rbtnSemestre)
        Me.pnlIntervalo.Controls.Add(Me.rbtnMes)
        Me.pnlIntervalo.Controls.Add(Me.rbtnQuincena)
        Me.pnlIntervalo.Controls.Add(Me.rbtnsemana)
        Me.pnlIntervalo.Controls.Add(Me.rbtndia)
        Me.pnlIntervalo.Controls.Add(Me.pnlIntervaloActivo)
        Me.pnlIntervalo.Location = New System.Drawing.Point(306, 441)
        Me.pnlIntervalo.Name = "pnlIntervalo"
        Me.pnlIntervalo.Size = New System.Drawing.Size(526, 69)
        Me.pnlIntervalo.TabIndex = 5
        '
        'lblIva
        '
        Me.lblIva.BackColor = System.Drawing.Color.Gainsboro
        Me.lblIva.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.lblIva.ForeColor = System.Drawing.Color.Black
        Me.lblIva.Location = New System.Drawing.Point(276, 0)
        Me.lblIva.Name = "lblIva"
        Me.lblIva.Size = New System.Drawing.Size(260, 24)
        Me.lblIva.TabIndex = 14
        Me.lblIva.Text = "Mostrar Datos"
        Me.lblIva.Visible = False
        '
        'pnlOtrasOpciones
        '
        Me.pnlOtrasOpciones.Controls.Add(Me.pnlIva)
        Me.pnlOtrasOpciones.Controls.Add(Me.rbSinAgrup)
        Me.pnlOtrasOpciones.Controls.Add(Me.rbAgrupFamillia)
        Me.pnlOtrasOpciones.Location = New System.Drawing.Point(22, 29)
        Me.pnlOtrasOpciones.Name = "pnlOtrasOpciones"
        Me.pnlOtrasOpciones.Size = New System.Drawing.Size(499, 33)
        Me.pnlOtrasOpciones.TabIndex = 13
        '
        'pnlIva
        '
        Me.pnlIva.Controls.Add(Me.rbSinIva)
        Me.pnlIva.Controls.Add(Me.rbConIva)
        Me.pnlIva.Location = New System.Drawing.Point(250, 0)
        Me.pnlIva.Name = "pnlIva"
        Me.pnlIva.Size = New System.Drawing.Size(248, 33)
        Me.pnlIva.TabIndex = 4
        '
        'rbSinIva
        '
        Me.rbSinIva.AutoSize = True
        Me.rbSinIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinIva.Location = New System.Drawing.Point(163, 8)
        Me.rbSinIva.Name = "rbSinIva"
        Me.rbSinIva.Size = New System.Drawing.Size(69, 20)
        Me.rbSinIva.TabIndex = 5
        Me.rbSinIva.TabStop = True
        Me.rbSinIva.Text = "Sin IVA"
        Me.rbSinIva.UseVisualStyleBackColor = True
        '
        'rbConIva
        '
        Me.rbConIva.AutoSize = True
        Me.rbConIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConIva.Location = New System.Drawing.Point(38, 8)
        Me.rbConIva.Name = "rbConIva"
        Me.rbConIva.Size = New System.Drawing.Size(71, 20)
        Me.rbConIva.TabIndex = 4
        Me.rbConIva.TabStop = True
        Me.rbConIva.Text = "Con Iva"
        Me.rbConIva.UseVisualStyleBackColor = True
        '
        'rbSinAgrup
        '
        Me.rbSinAgrup.AutoSize = True
        Me.rbSinAgrup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSinAgrup.Location = New System.Drawing.Point(154, 8)
        Me.rbSinAgrup.Name = "rbSinAgrup"
        Me.rbSinAgrup.Size = New System.Drawing.Size(87, 20)
        Me.rbSinAgrup.TabIndex = 3
        Me.rbSinAgrup.TabStop = True
        Me.rbSinAgrup.Text = "Sin Agrup."
        Me.rbSinAgrup.UseVisualStyleBackColor = True
        '
        'rbAgrupFamillia
        '
        Me.rbAgrupFamillia.AutoSize = True
        Me.rbAgrupFamillia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAgrupFamillia.Location = New System.Drawing.Point(19, 8)
        Me.rbAgrupFamillia.Name = "rbAgrupFamillia"
        Me.rbAgrupFamillia.Size = New System.Drawing.Size(94, 20)
        Me.rbAgrupFamillia.TabIndex = 2
        Me.rbAgrupFamillia.TabStop = True
        Me.rbAgrupFamillia.Text = "Por Familia"
        Me.rbAgrupFamillia.UseVisualStyleBackColor = True
        '
        'rbtnAño
        '
        Me.rbtnAño.AutoSize = True
        Me.rbtnAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAño.Location = New System.Drawing.Point(432, 37)
        Me.rbtnAño.Name = "rbtnAño"
        Me.rbtnAño.Size = New System.Drawing.Size(57, 20)
        Me.rbtnAño.TabIndex = 3
        Me.rbtnAño.TabStop = True
        Me.rbtnAño.Text = "Anho"
        Me.rbtnAño.UseVisualStyleBackColor = True
        '
        'rbtnSemestre
        '
        Me.rbtnSemestre.AutoSize = True
        Me.rbtnSemestre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSemestre.Location = New System.Drawing.Point(344, 37)
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
        Me.rbtnMes.Location = New System.Drawing.Point(288, 37)
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
        Me.rbtnQuincena.Location = New System.Drawing.Point(201, 37)
        Me.rbtnQuincena.Name = "rbtnQuincena"
        Me.rbtnQuincena.Size = New System.Drawing.Size(83, 20)
        Me.rbtnQuincena.TabIndex = 2
        Me.rbtnQuincena.TabStop = True
        Me.rbtnQuincena.Text = "Quincena"
        Me.rbtnQuincena.UseVisualStyleBackColor = True
        '
        'rbtnsemana
        '
        Me.rbtnsemana.AutoSize = True
        Me.rbtnsemana.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnsemana.Location = New System.Drawing.Point(120, 37)
        Me.rbtnsemana.Name = "rbtnsemana"
        Me.rbtnsemana.Size = New System.Drawing.Size(77, 20)
        Me.rbtnsemana.TabIndex = 1
        Me.rbtnsemana.TabStop = True
        Me.rbtnsemana.Text = "Semana"
        Me.rbtnsemana.UseVisualStyleBackColor = True
        '
        'rbtndia
        '
        Me.rbtndia.AutoSize = True
        Me.rbtndia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtndia.Location = New System.Drawing.Point(69, 37)
        Me.rbtndia.Name = "rbtndia"
        Me.rbtndia.Size = New System.Drawing.Size(47, 20)
        Me.rbtndia.TabIndex = 1
        Me.rbtndia.TabStop = True
        Me.rbtndia.Text = "Dia"
        Me.rbtndia.UseVisualStyleBackColor = True
        '
        'pnlIntervaloActivo
        '
        Me.pnlIntervaloActivo.BackColor = System.Drawing.Color.DimGray
        Me.pnlIntervaloActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIntervaloActivo.Controls.Add(Me.Label25)
        Me.pnlIntervaloActivo.Controls.Add(Me.lblAgrupacion)
        Me.pnlIntervaloActivo.Location = New System.Drawing.Point(-2, -1)
        Me.pnlIntervaloActivo.Name = "pnlIntervaloActivo"
        Me.pnlIntervaloActivo.Size = New System.Drawing.Size(248, 25)
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
        'lblAgrupacion
        '
        Me.lblAgrupacion.AutoSize = True
        Me.lblAgrupacion.BackColor = System.Drawing.Color.Transparent
        Me.lblAgrupacion.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.lblAgrupacion.ForeColor = System.Drawing.Color.Black
        Me.lblAgrupacion.Location = New System.Drawing.Point(0, -1)
        Me.lblAgrupacion.Name = "lblAgrupacion"
        Me.lblAgrupacion.Size = New System.Drawing.Size(224, 21)
        Me.lblAgrupacion.TabIndex = 0
        Me.lblAgrupacion.Text = "Agrupar los datos por Intervalos"
        '
        'btnFiltroProd
        '
        Me.btnFiltroProd.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFiltroProd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltroProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltroProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltroProd.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFiltroProd.Location = New System.Drawing.Point(306, 93)
        Me.btnFiltroProd.Name = "btnFiltroProd"
        Me.btnFiltroProd.Size = New System.Drawing.Size(126, 30)
        Me.btnFiltroProd.TabIndex = 7
        Me.btnFiltroProd.Text = "Productos"
        Me.btnFiltroProd.UseVisualStyleBackColor = False
        '
        'btnFiltroEmpresa
        '
        Me.btnFiltroEmpresa.BackColor = System.Drawing.Color.YellowGreen
        Me.btnFiltroEmpresa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltroEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltroEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltroEmpresa.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFiltroEmpresa.Location = New System.Drawing.Point(705, 93)
        Me.btnFiltroEmpresa.Name = "btnFiltroEmpresa"
        Me.btnFiltroEmpresa.Size = New System.Drawing.Size(126, 30)
        Me.btnFiltroEmpresa.TabIndex = 7
        Me.btnFiltroEmpresa.Text = "Empresa"
        Me.btnFiltroEmpresa.UseVisualStyleBackColor = False
        '
        'btnFiltroProveedor
        '
        Me.btnFiltroProveedor.BackColor = System.Drawing.Color.Crimson
        Me.btnFiltroProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltroProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltroProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltroProveedor.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFiltroProveedor.Location = New System.Drawing.Point(439, 93)
        Me.btnFiltroProveedor.Name = "btnFiltroProveedor"
        Me.btnFiltroProveedor.Size = New System.Drawing.Size(126, 30)
        Me.btnFiltroProveedor.TabIndex = 7
        Me.btnFiltroProveedor.Text = "Proveedor"
        Me.btnFiltroProveedor.UseVisualStyleBackColor = False
        '
        'btnFiltroFinanciero
        '
        Me.btnFiltroFinanciero.BackColor = System.Drawing.Color.DarkOrange
        Me.btnFiltroFinanciero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltroFinanciero.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltroFinanciero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltroFinanciero.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFiltroFinanciero.Location = New System.Drawing.Point(572, 93)
        Me.btnFiltroFinanciero.Name = "btnFiltroFinanciero"
        Me.btnFiltroFinanciero.Size = New System.Drawing.Size(126, 30)
        Me.btnFiltroFinanciero.TabIndex = 7
        Me.btnFiltroFinanciero.Text = "Financiero"
        Me.btnFiltroFinanciero.UseVisualStyleBackColor = False
        '
        'pnlProductos
        '
        Me.pnlProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlProductos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlProductos.BackColor = System.Drawing.Color.DimGray
        Me.pnlProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProductos.Controls.Add(Me.tbxCodigosProductos)
        Me.pnlProductos.Controls.Add(Me.lblAyudaCodProd)
        Me.pnlProductos.Controls.Add(Me.Panel5)
        Me.pnlProductos.Controls.Add(Me.chbxCodigosProductos)
        Me.pnlProductos.Controls.Add(Me.cmbProducto)
        Me.pnlProductos.Controls.Add(Me.cbxCategoria)
        Me.pnlProductos.Controls.Add(Me.cbxRubro)
        Me.pnlProductos.Controls.Add(Me.cbxLinea)
        Me.pnlProductos.Controls.Add(Me.Label3)
        Me.pnlProductos.Controls.Add(Me.Label4)
        Me.pnlProductos.Controls.Add(Me.Label5)
        Me.pnlProductos.Controls.Add(Me.Label6)
        Me.pnlProductos.Location = New System.Drawing.Point(306, 129)
        Me.pnlProductos.Name = "pnlProductos"
        Me.pnlProductos.Size = New System.Drawing.Size(527, 197)
        Me.pnlProductos.TabIndex = 3
        '
        'lblAyudaCodProd
        '
        Me.lblAyudaCodProd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblAyudaCodProd.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyudaCodProd.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblAyudaCodProd.Location = New System.Drawing.Point(200, 69)
        Me.lblAyudaCodProd.Name = "lblAyudaCodProd"
        Me.lblAyudaCodProd.Size = New System.Drawing.Size(148, 79)
        Me.lblAyudaCodProd.TabIndex = 8
        Me.lblAyudaCodProd.Text = "Cargue los productos que desea ver separando los por un coma: Ej: H15, H16, J39"
        Me.lblAyudaCodProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblAyudaCodProd.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.Highlight
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Location = New System.Drawing.Point(-2, -1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(529, 30)
        Me.Panel5.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(231, 21)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Filtro de Categorias y Productos"
        '
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.DimGray
        Me.pnlSinFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(306, 129)
        Me.pnlSinFiltro.Name = "pnlSinFiltro"
        Me.pnlSinFiltro.Size = New System.Drawing.Size(527, 197)
        Me.pnlSinFiltro.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(46, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(413, 22)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Este Reporte no requiere de Filtros Especiales!"
        '
        'pnlFinanciero
        '
        Me.pnlFinanciero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFinanciero.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFinanciero.BackColor = System.Drawing.Color.DimGray
        Me.pnlFinanciero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFinanciero.Controls.Add(Me.cmbComprobante)
        Me.pnlFinanciero.Controls.Add(Me.Label16)
        Me.pnlFinanciero.Controls.Add(Me.cmbCaja)
        Me.pnlFinanciero.Controls.Add(Me.cmbMoneda)
        Me.pnlFinanciero.Controls.Add(Me.Panel2)
        Me.pnlFinanciero.Controls.Add(Me.Label1)
        Me.pnlFinanciero.Controls.Add(Me.Label13)
        Me.pnlFinanciero.Location = New System.Drawing.Point(306, 129)
        Me.pnlFinanciero.Name = "pnlFinanciero"
        Me.pnlFinanciero.Size = New System.Drawing.Size(527, 197)
        Me.pnlFinanciero.TabIndex = 8
        '
        'cmbComprobante
        '
        Me.cmbComprobante.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbComprobante.DataSource = Me.RCTIPOCOMPROBANTEBindingSource
        Me.cmbComprobante.DisplayMember = "DESCOMPROBANTE"
        Me.cmbComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobante.FormattingEnabled = True
        Me.cmbComprobante.Location = New System.Drawing.Point(46, 157)
        Me.cmbComprobante.Name = "cmbComprobante"
        Me.cmbComprobante.Size = New System.Drawing.Size(434, 33)
        Me.cmbComprobante.TabIndex = 16
        Me.cmbComprobante.ValueMember = "CODCOMPROBANTE"
        '
        'RCTIPOCOMPROBANTEBindingSource
        '
        Me.RCTIPOCOMPROBANTEBindingSource.DataMember = "RCTIPOCOMPROBANTE"
        Me.RCTIPOCOMPROBANTEBindingSource.DataSource = Me.DsRCPagos
        '
        'DsRCPagos
        '
        Me.DsRCPagos.DataSetName = "DsRCPagos"
        Me.DsRCPagos.EnforceConstraints = False
        Me.DsRCPagos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(49, 140)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 15)
        Me.Label16.TabIndex = 17
        Me.Label16.Text = "Comprobante"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(-2, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(529, 30)
        Me.Panel2.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(5, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 21)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Filtro Financiero"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Cuenta"
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(49, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 15)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Moneda"
        '
        'pnlEmpresa
        '
        Me.pnlEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEmpresa.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlEmpresa.BackColor = System.Drawing.Color.DimGray
        Me.pnlEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEmpresa.Controls.Add(Me.cmbtipo)
        Me.pnlEmpresa.Controls.Add(Me.LblTipo)
        Me.pnlEmpresa.Controls.Add(Me.Panel6)
        Me.pnlEmpresa.Controls.Add(Me.cbxCdC)
        Me.pnlEmpresa.Controls.Add(Me.Label15)
        Me.pnlEmpresa.Controls.Add(Me.cmbSucursal)
        Me.pnlEmpresa.Controls.Add(Me.Label21)
        Me.pnlEmpresa.Controls.Add(Me.cmbtipo2)
        Me.pnlEmpresa.Location = New System.Drawing.Point(306, 129)
        Me.pnlEmpresa.Name = "pnlEmpresa"
        Me.pnlEmpresa.Size = New System.Drawing.Size(527, 197)
        Me.pnlEmpresa.TabIndex = 9
        '
        'cmbtipo
        '
        Me.cmbtipo.BackColor = System.Drawing.Color.GhostWhite
        Me.cmbtipo.Enabled = False
        Me.cmbtipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbtipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtipo.FormattingEnabled = True
        Me.cmbtipo.Location = New System.Drawing.Point(47, 151)
        Me.cmbtipo.Name = "cmbtipo"
        Me.cmbtipo.Size = New System.Drawing.Size(434, 33)
        Me.cmbtipo.TabIndex = 16
        '
        'LblTipo
        '
        Me.LblTipo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LblTipo.AutoSize = True
        Me.LblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTipo.ForeColor = System.Drawing.Color.Black
        Me.LblTipo.Location = New System.Drawing.Point(51, 134)
        Me.LblTipo.Name = "LblTipo"
        Me.LblTipo.Size = New System.Drawing.Size(31, 15)
        Me.LblTipo.TabIndex = 17
        Me.LblTipo.Text = "Tipo"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.YellowGreen
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Location = New System.Drawing.Point(-2, -1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(529, 30)
        Me.Panel6.TabIndex = 11
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(5, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(154, 21)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "Filtros de la Empresa"
        '
        'cbxCdC
        '
        Me.cbxCdC.BackColor = System.Drawing.Color.GhostWhite
        Me.cbxCdC.DataSource = Me.CENTROCOSTOBindingSource
        Me.cbxCdC.DisplayMember = "DESCENTRO"
        Me.cbxCdC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCdC.FormattingEnabled = True
        Me.cbxCdC.Location = New System.Drawing.Point(47, 48)
        Me.cbxCdC.Name = "cbxCdC"
        Me.cbxCdC.Size = New System.Drawing.Size(434, 33)
        Me.cbxCdC.TabIndex = 2
        Me.cbxCdC.ValueMember = "CODCENTRO"
        '
        'CENTROCOSTOBindingSource
        '
        Me.CENTROCOSTOBindingSource.DataMember = "CENTROCOSTO"
        Me.CENTROCOSTOBindingSource.DataSource = Me.DSReporteCompras1
        '
        'Label15
        '
        Me.Label15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(51, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(94, 15)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Centro de Costo"
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(51, 82)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(55, 15)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Sucursal"
        '
        'cmbtipo2
        '
        Me.cmbtipo2.FormattingEnabled = True
        Me.cmbtipo2.Location = New System.Drawing.Point(431, 151)
        Me.cmbtipo2.Name = "cmbtipo2"
        Me.cmbtipo2.Size = New System.Drawing.Size(28, 21)
        Me.cmbtipo2.TabIndex = 18
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblReporte.Location = New System.Drawing.Point(402, 6)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(106, 28)
        Me.lblReporte.TabIndex = 4
        Me.lblReporte.Text = "lblReporte"
        '
        'lblReporteDescrip
        '
        Me.lblReporteDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteDescrip.ForeColor = System.Drawing.Color.DarkGray
        Me.lblReporteDescrip.Location = New System.Drawing.Point(304, 37)
        Me.lblReporteDescrip.Name = "lblReporteDescrip"
        Me.lblReporteDescrip.Size = New System.Drawing.Size(528, 49)
        Me.lblReporteDescrip.TabIndex = 9
        Me.lblReporteDescrip.Text = "lblReporteDescrip"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label20.Location = New System.Drawing.Point(304, 331)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(501, 15)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Nota: Si quiere ver Todos los Datos, simplemente inserte ""%"" en el campo correspo" & _
    "ndiente"
        '
        'treeReportesVentas
        '
        Me.treeReportesVentas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.treeReportesVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.treeReportesVentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.treeReportesVentas.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeReportesVentas.ForeColor = System.Drawing.Color.Gainsboro
        Me.treeReportesVentas.FullRowSelect = True
        Me.treeReportesVentas.HotTracking = True
        Me.treeReportesVentas.LineColor = System.Drawing.Color.DimGray
        Me.treeReportesVentas.Location = New System.Drawing.Point(0, 2)
        Me.treeReportesVentas.Name = "treeReportesVentas"
        TreeNode31.Name = "rptPendienteProveedor"
        TreeNode31.Text = "Pendientes por Proveedor"
        TreeNode32.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode32.Name = "Node0"
        TreeNode32.Text = "Compras Pendientes"
        TreeNode33.Name = "rptCompraSucursal"
        TreeNode33.Text = "Gastos por Sucursal"
        TreeNode34.Name = "rptGastosporCentroCosto"
        TreeNode34.Text = "Gastos por Centro de Costos"
        TreeNode35.Name = "rptDetalleporCentroCosto"
        TreeNode35.Text = "Gastos por Centro de Costos Detallado"
        TreeNode36.Name = "rptGastosCdCTotalRTLineal"
        TreeNode36.Text = "Gastos Total Lineal"
        TreeNode37.Name = "rptGastosCdCTotalRTMensual"
        TreeNode37.Text = "Gastos Total Mensual"
        TreeNode38.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode38.Name = "Node3"
        TreeNode38.Text = "Estadisticas de Gastos"
        TreeNode39.Name = "frmCompraProducto"
        TreeNode39.Text = "Compras por Productos"
        TreeNode40.Name = "rptCostosUltimaCompra"
        TreeNode40.Text = "Precios de Ultima Compra"
        TreeNode41.Name = "rptComprasCostoPromedio"
        TreeNode41.Text = "Costo Promedio por Producto"
        TreeNode42.Name = "rptCOGSDetallado"
        TreeNode42.Text = "Costo Promedio por Producto Det."
        TreeNode43.Name = "rptListadoOC"
        TreeNode43.Text = "Listado de Ordenes de Compra"
        TreeNode44.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode44.Name = "Node0"
        TreeNode44.Text = "Estadisticas de Compras"
        TreeNode45.Name = "rptAnalisisSaldo"
        TreeNode45.Text = "Analisis de Saldos"
        TreeNode46.Name = "rptEstadoCuenta"
        TreeNode46.Text = "Estado Cuenta Proveedor"
        TreeNode47.Name = "rptPendientesPago"
        TreeNode47.Text = "Comprobantes Pendientes"
        TreeNode48.Name = "rptFacturasPagar"
        TreeNode48.Text = "Facturas a Pagar"
        TreeNode49.Name = "rptFacturasXRecibo"
        TreeNode49.Text = "Facturas Por Recibo"
        TreeNode50.Name = "rptRetenciones"
        TreeNode50.Text = "Lista de Retenciones"
        TreeNode51.Name = "rptRecibosXFactura"
        TreeNode51.Text = "Recibos Por Factura"
        TreeNode52.Name = "rptRecibosProveedor"
        TreeNode52.Text = "Recibos Proveedor"
        TreeNode53.Name = "rptRecibosProveedorDet"
        TreeNode53.Text = "Recibos Proveedor Detallado"
        TreeNode54.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode54.Name = "Node14"
        TreeNode54.Text = "Reportes de Pagos"
        TreeNode55.Name = "rptListaProveedor"
        TreeNode55.Text = "Lista de Proveedores"
        TreeNode56.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode56.Name = "Node19"
        TreeNode56.Text = "Reportes Auxiliares"
        TreeNode57.Name = "rptComprasPorProveedor"
        TreeNode57.Text = "Precio de Compra por Producto Por Prov."
        TreeNode58.Name = "rptLibroCompraLEY"
        TreeNode58.Text = "Libro Iva Compras -  125/91"
        TreeNode59.Name = "NotasCreditoLey"
        TreeNode59.Text = "Libro Iva Notas de Crédito - 125/91"
        TreeNode60.ForeColor = System.Drawing.Color.DarkOrange
        TreeNode60.Name = "rptComprasAprob"
        TreeNode60.Text = "Compras Aprobadas"
        Me.treeReportesVentas.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode32, TreeNode38, TreeNode44, TreeNode54, TreeNode56, TreeNode60})
        Me.treeReportesVentas.Size = New System.Drawing.Size(300, 572)
        Me.treeReportesVentas.TabIndex = 12
        '
        'chbxMatricial
        '
        Me.chbxMatricial.AutoSize = True
        Me.chbxMatricial.ForeColor = System.Drawing.Color.Gainsboro
        Me.chbxMatricial.Location = New System.Drawing.Point(733, 74)
        Me.chbxMatricial.Name = "chbxMatricial"
        Me.chbxMatricial.Size = New System.Drawing.Size(106, 17)
        Me.chbxMatricial.TabIndex = 13
        Me.chbxMatricial.Text = "Formato Matricial"
        Me.chbxMatricial.UseVisualStyleBackColor = True
        '
        'RcchdifTableAdapter
        '
        Me.RcchdifTableAdapter.ClearBeforeFill = True
        '
        'RcPendientePagoDifTableAdapter
        '
        Me.RcPendientePagoDifTableAdapter.ClearBeforeFill = True
        '
        'RcNotasCreditoTableAdapter
        '
        Me.RcNotasCreditoTableAdapter.ClearBeforeFill = True
        '
        'RcFacturasXReciboTableAdapter
        '
        Me.RcFacturasXReciboTableAdapter.ClearBeforeFill = True
        '
        'RcPagosProveedorTableAdapter
        '
        Me.RcPagosProveedorTableAdapter.ClearBeforeFill = True
        '
        'RcMovimientosProveedorTableAdapter
        '
        Me.RcMovimientosProveedorTableAdapter.ClearBeforeFill = True
        '
        'RCIVANCREDITOComprasTableAdapter
        '
        Me.RCIVANCREDITOComprasTableAdapter.ClearBeforeFill = True
        '
        'DsRCNCredito
        '
        Me.DsRCNCredito.DataSetName = "DsRCNCredito"
        Me.DsRCNCredito.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RCOMPRASLISTATableAdapter
        '
        Me.RCOMPRASLISTATableAdapter.ClearBeforeFill = True
        '
        'RCTIPOCOMPROBANTETableAdapter
        '
        Me.RCTIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'RcRetencionesTableAdapter
        '
        Me.RcRetencionesTableAdapter.ClearBeforeFill = True
        '
        'RcProductosPorProveedorTableAdapter
        '
        Me.RcProductosPorProveedorTableAdapter.ClearBeforeFill = True
        '
        'DsRCCompras
        '
        Me.DsRCCompras.DataSetName = "DsRCCompras"
        Me.DsRCCompras.EnforceConstraints = False
        Me.DsRCCompras.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RCFacturasAPagarTableAdapter
        '
        Me.RCFacturasAPagarTableAdapter.ClearBeforeFill = True
        '
        'RCRecibosProveedorDetTableAdapter
        '
        Me.RCRecibosProveedorDetTableAdapter.ClearBeforeFill = True
        '
        'RcAnalisisdeSaldosTableAdapter
        '
        Me.RcAnalisisdeSaldosTableAdapter.ClearBeforeFill = True
        '
        'DSReporteCompras
        '
        Me.DSReporteCompras.DataSetName = "DSReporteCompras"
        Me.DSReporteCompras.EnforceConstraints = False
        Me.DSReporteCompras.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CdC_LinealBindingSource
        '
        Me.CdC_LinealBindingSource.DataMember = "CdC Lineal"
        Me.CdC_LinealBindingSource.DataSource = Me.DSReporteCompras
        '
        'CdC_LinealTableAdapter
        '
        Me.CdC_LinealTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CAJATableAdapter = Nothing
        Me.TableAdapterManager.CENTROCOSTOTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.FAMILIATableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.movimientosTableAdapter = Nothing
        Me.TableAdapterManager.PRODUCTOSTableAdapter = Nothing
        Me.TableAdapterManager.PROVEEDORTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DSReporteComprasTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'COMPRASDETALLEBindingSource
        '
        Me.COMPRASDETALLEBindingSource.DataMember = "COMPRASDETALLE"
        Me.COMPRASDETALLEBindingSource.DataSource = Me.DSReporteCompras
        '
        'COMPRASDETALLETableAdapter
        '
        Me.COMPRASDETALLETableAdapter.ClearBeforeFill = True
        '
        'TotalStockActualBindingSource
        '
        Me.TotalStockActualBindingSource.DataMember = "TotalStockActual"
        Me.TotalStockActualBindingSource.DataSource = Me.DSReporteCompras
        '
        'TotalStockActualTableAdapter
        '
        Me.TotalStockActualTableAdapter.ClearBeforeFill = True
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
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'ComprasPorProductoBindingSource
        '
        Me.ComprasPorProductoBindingSource.DataMember = "ComprasPorProducto"
        Me.ComprasPorProductoBindingSource.DataSource = Me.DSReporteCompras
        '
        'ComprasPorProductoTableAdapter
        '
        Me.ComprasPorProductoTableAdapter.ClearBeforeFill = True
        '
        'ComprasPorSucursalBindingSource
        '
        Me.ComprasPorSucursalBindingSource.DataMember = "ComprasPorSucursal"
        Me.ComprasPorSucursalBindingSource.DataSource = Me.DSReporteCompras
        '
        'ComprasPorSucursalTableAdapter
        '
        Me.ComprasPorSucursalTableAdapter.ClearBeforeFill = True
        '
        'CENTROCOSTOTableAdapter
        '
        Me.CENTROCOSTOTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'ComprasPendienteProveedorBindingSource
        '
        Me.ComprasPendienteProveedorBindingSource.DataMember = "ComprasPendienteProveedor"
        Me.ComprasPendienteProveedorBindingSource.DataSource = Me.DSReporteCompras
        '
        'ComprasPendienteProveedorTableAdapter
        '
        Me.ComprasPendienteProveedorTableAdapter.ClearBeforeFill = True
        '
        'PROVEEDORTableAdapter
        '
        Me.PROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'ListaProveedorBindingSource
        '
        Me.ListaProveedorBindingSource.DataMember = "ListaProveedor"
        Me.ListaProveedorBindingSource.DataSource = Me.DSReporteCompras
        '
        'ListaProveedorTableAdapter
        '
        Me.ListaProveedorTableAdapter.ClearBeforeFill = True
        '
        'ComprasPorCategoriaBindingSource
        '
        Me.ComprasPorCategoriaBindingSource.DataMember = "ComprasPorCategoria"
        Me.ComprasPorCategoriaBindingSource.DataSource = Me.DSReporteCompras
        '
        'ComprasPorCategoriaTableAdapter
        '
        Me.ComprasPorCategoriaTableAdapter.ClearBeforeFill = True
        '
        'CompraDiarioCajaBindingSource
        '
        Me.CompraDiarioCajaBindingSource.DataMember = "CompraDiarioCaja"
        Me.CompraDiarioCajaBindingSource.DataSource = Me.DSReporteCompras
        '
        'CompraDiarioCajaTableAdapter
        '
        Me.CompraDiarioCajaTableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'DiarioCajaResumenBindingSource
        '
        Me.DiarioCajaResumenBindingSource.DataMember = "DiarioCajaResumen"
        Me.DiarioCajaResumenBindingSource.DataSource = Me.DSReporteCompras
        '
        'DiarioCajaResumenTableAdapter
        '
        Me.DiarioCajaResumenTableAdapter.ClearBeforeFill = True
        '
        'FacturaAPagarBindingSource
        '
        Me.FacturaAPagarBindingSource.DataMember = "FacturaAPagar"
        Me.FacturaAPagarBindingSource.DataSource = Me.DSReporteCompras
        '
        'FacturaAPagarTableAdapter
        '
        Me.FacturaAPagarTableAdapter.ClearBeforeFill = True
        '
        'GastosPorProductoBindingSource
        '
        Me.GastosPorProductoBindingSource.DataMember = "GastosPorProducto"
        Me.GastosPorProductoBindingSource.DataSource = Me.DSReporteCompras
        '
        'GastosPorProductoTableAdapter
        '
        Me.GastosPorProductoTableAdapter.ClearBeforeFill = True
        '
        'UltimaCompraDiasBindingSource
        '
        Me.UltimaCompraDiasBindingSource.DataMember = "UltimaCompraDias"
        Me.UltimaCompraDiasBindingSource.DataSource = Me.DSReporteCompras
        '
        'UltimaCompraDiasTableAdapter
        '
        Me.UltimaCompraDiasTableAdapter.ClearBeforeFill = True
        '
        'ComprasCOGsPromedioBindingSource
        '
        Me.ComprasCOGsPromedioBindingSource.DataSource = Me.DSReporteCompras
        Me.ComprasCOGsPromedioBindingSource.Position = 0
        '
        'ComprasCOGsPromedioTableAdapter
        '
        Me.ComprasCOGsPromedioTableAdapter.ClearBeforeFill = True
        '
        'COGSDetalladoBindingSource
        '
        Me.COGSDetalladoBindingSource.DataMember = "COGSDetallado"
        Me.COGSDetalladoBindingSource.DataSource = Me.DSReporteCompras
        '
        'COGSDetalladoTableAdapter
        '
        Me.COGSDetalladoTableAdapter.ClearBeforeFill = True
        '
        'CostoFijoCAntidadVentaBindingSource
        '
        Me.CostoFijoCAntidadVentaBindingSource.DataMember = "CostoFijoCAntidadVenta"
        Me.CostoFijoCAntidadVentaBindingSource.DataSource = Me.DSReporteCompras
        '
        'CostoFijoCAntidadVentaTableAdapter
        '
        Me.CostoFijoCAntidadVentaTableAdapter.ClearBeforeFill = True
        '
        'COSTOFIJOBindingSource
        '
        Me.COSTOFIJOBindingSource.DataMember = "COSTOFIJO"
        Me.COSTOFIJOBindingSource.DataSource = Me.DSReporteCompras
        '
        'COSTOFIJOTableAdapter
        '
        Me.COSTOFIJOTableAdapter.ClearBeforeFill = True
        '
        'ListaPrecioBindingSource
        '
        Me.ListaPrecioBindingSource.DataMember = "ListaPrecio"
        Me.ListaPrecioBindingSource.DataSource = Me.DSReporteCompras
        '
        'ListaPrecioTableAdapter
        '
        Me.ListaPrecioTableAdapter.ClearBeforeFill = True
        '
        'CuentaCorrienteProveedorBindingSource
        '
        Me.CuentaCorrienteProveedorBindingSource.DataMember = "CuentaCorrienteProveedor"
        Me.CuentaCorrienteProveedorBindingSource.DataSource = Me.DSReporteCompras
        '
        'CuentaCorrienteProveedorTableAdapter
        '
        Me.CuentaCorrienteProveedorTableAdapter.ClearBeforeFill = True
        '
        'ComprasAprobadasTableAdapter
        '
        Me.ComprasAprobadasTableAdapter.ClearBeforeFill = True
        '
        'RCIVAComprasTableAdapter
        '
        Me.RCIVAComprasTableAdapter.ClearBeforeFill = True
        '
        'RcivaleyTableAdapter
        '
        Me.RcivaleyTableAdapter.ClearBeforeFill = True
        '
        'RcivancleyTableAdapter
        '
        Me.RcivancleyTableAdapter.ClearBeforeFill = True
        '
        'ListaOrdenCompraTableAdapter1
        '
        Me.ListaOrdenCompraTableAdapter1.ClearBeforeFill = True
        '
        'CentroDetalladoTableAdapter
        '
        Me.CentroDetalladoTableAdapter.ClearBeforeFill = True
        '
        'DsDetalleCentro
        '
        Me.DsDetalleCentro.DataSetName = "DsDetalleCentro"
        Me.DsDetalleCentro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LibroivacomprA_RCTableAdapter
        '
        Me.LibroivacomprA_RCTableAdapter.ClearBeforeFill = True
        '
        'DsProveedores
        '
        Me.DsProveedores.DataSetName = "DsProveedores"
        Me.DsProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListaProvBindingSource
        '
        Me.ListaProvBindingSource.DataMember = "ListaProv"
        Me.ListaProvBindingSource.DataSource = Me.DsProveedores
        '
        'ListaProvTableAdapter
        '
        Me.ListaProvTableAdapter.ClearBeforeFill = True
        '
        'ReporteCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(842, 569)
        Me.Controls.Add(Me.chbxMatricial)
        Me.Controls.Add(Me.btnFiltroEmpresa)
        Me.Controls.Add(Me.btnFiltroProd)
        Me.Controls.Add(Me.treeReportesVentas)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnFiltroFinanciero)
        Me.Controls.Add(Me.btnFiltroProveedor)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.pnlFecha)
        Me.Controls.Add(Me.pnlIntervalo)
        Me.Controls.Add(Me.lblReporteDescrip)
        Me.Controls.Add(Me.pnlProveedor)
        Me.Controls.Add(Me.pnlSinFiltro)
        Me.Controls.Add(Me.pnlProductos)
        Me.Controls.Add(Me.pnlEmpresa)
        Me.Controls.Add(Me.pnlFinanciero)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ReporteCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Compras - Pos Express"
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSReporteCompras1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFecha.ResumeLayout(False)
        Me.pnlFecha.PerformLayout()
        Me.pnlFechaPeriodo.ResumeLayout(False)
        Me.pnlFechaPeriodo.PerformLayout()
        Me.pnlFechaActivo.ResumeLayout(False)
        Me.pnlFechaActivo.PerformLayout()
        Me.pnlProveedor.ResumeLayout(False)
        Me.pnlProveedor.PerformLayout()
        CType(Me.pbxRangoProv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIntervalo.ResumeLayout(False)
        Me.pnlIntervalo.PerformLayout()
        Me.pnlOtrasOpciones.ResumeLayout(False)
        Me.pnlOtrasOpciones.PerformLayout()
        Me.pnlIva.ResumeLayout(False)
        Me.pnlIva.PerformLayout()
        Me.pnlIntervaloActivo.ResumeLayout(False)
        Me.pnlIntervaloActivo.PerformLayout()
        Me.pnlProductos.ResumeLayout(False)
        Me.pnlProductos.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        Me.pnlFinanciero.ResumeLayout(False)
        Me.pnlFinanciero.PerformLayout()
        CType(Me.RCTIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRCPagos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pnlEmpresa.ResumeLayout(False)
        Me.pnlEmpresa.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRCNCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRCCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSReporteCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdC_LinealBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COMPRASDETALLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalStockActualBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasPorProductoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasPorSucursalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasPendienteProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListaProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasPorCategoriaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompraDiarioCajaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiarioCajaResumenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturaAPagarBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GastosPorProductoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltimaCompraDiasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasCOGsPromedioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COGSDetalladoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CostoFijoCAntidadVentaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COSTOFIJOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListaPrecioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CuentaCorrienteProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsDetalleCentro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListaProvBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlFecha As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlProveedor As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents cbxCategoria As System.Windows.Forms.ComboBox
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
    Friend WithEvents cmbMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents DIARIORESUMENCAJATableAdapter As ContaExpress.DsReporteVentasTableAdapters.DIARIORESUMENCAJATableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxCodigosProductos As System.Windows.Forms.TextBox
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRubro As System.Windows.Forms.ComboBox
    Friend WithEvents cbxLinea As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chbxCodigosProductos As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents pnlIntervalo As System.Windows.Forms.Panel
    Friend WithEvents lblAgrupacion As System.Windows.Forms.Label
    Friend WithEvents btnFiltroProd As System.Windows.Forms.Button
    Friend WithEvents btnFiltroEmpresa As System.Windows.Forms.Button
    Friend WithEvents btnFiltroProveedor As System.Windows.Forms.Button
    Friend WithEvents btnFiltroFinanciero As System.Windows.Forms.Button
    Friend WithEvents pnlProductos As System.Windows.Forms.Panel
    Friend WithEvents pnlFinanciero As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlEmpresa As System.Windows.Forms.Panel
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblReporteDescrip As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblAyudaCodProd As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbtnAño As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSemestre As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnQuincena As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnsemana As System.Windows.Forms.RadioButton
    Friend WithEvents rbtndia As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents pnlSinFiltro As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents pnlFechaActivo As System.Windows.Forms.Panel
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pnlIntervaloActivo As System.Windows.Forms.Panel
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents treeReportesVentas As System.Windows.Forms.TreeView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxCdC As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DSReporteCompras As ContaExpress.DSReporteCompras
    Friend WithEvents CdC_LinealBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CdC_LinealTableAdapter As ContaExpress.DSReporteComprasTableAdapters.CdC_LinealTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DSReporteComprasTableAdapters.TableAdapterManager
    Friend WithEvents COMPRASDETALLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COMPRASDETALLETableAdapter As ContaExpress.DSReporteComprasTableAdapters.COMPRASDETALLETableAdapter
    Friend WithEvents TotalStockActualBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TotalStockActualTableAdapter As ContaExpress.DSReporteComprasTableAdapters.TotalStockActualTableAdapter
    Friend WithEvents DSReporteCompras1 As ContaExpress.DSReporteCompras
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DSReporteComprasTableAdapters.FAMILIATableAdapter
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEATableAdapter As ContaExpress.DSReporteComprasTableAdapters.LINEATableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUBROTableAdapter As ContaExpress.DSReporteComprasTableAdapters.RUBROTableAdapter
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DSReporteComprasTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents ComprasPorProductoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComprasPorProductoTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasPorProductoTableAdapter
    Friend WithEvents ComprasPorSucursalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComprasPorSucursalTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasPorSucursalTableAdapter
    Friend WithEvents CENTROCOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CENTROCOSTOTableAdapter As ContaExpress.DSReporteComprasTableAdapters.CENTROCOSTOTableAdapter
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DSReporteComprasTableAdapters.SUCURSALTableAdapter
    Friend WithEvents ComprasPendienteProveedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComprasPendienteProveedorTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasPendienteProveedorTableAdapter
    Friend WithEvents PROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROVEEDORTableAdapter As ContaExpress.DSReporteComprasTableAdapters.PROVEEDORTableAdapter
    Friend WithEvents ListaProveedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListaProveedorTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ListaProveedorTableAdapter
    Friend WithEvents ComprasPorCategoriaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComprasPorCategoriaTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasPorCategoriaTableAdapter
    Friend WithEvents CompraDiarioCajaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CompraDiarioCajaTableAdapter As ContaExpress.DSReporteComprasTableAdapters.CompraDiarioCajaTableAdapter
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DSReporteComprasTableAdapters.MONEDATableAdapter
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DSReporteComprasTableAdapters.CAJATableAdapter
    Friend WithEvents DiarioCajaResumenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DiarioCajaResumenTableAdapter As ContaExpress.DSReporteComprasTableAdapters.DiarioCajaResumenTableAdapter
    Friend WithEvents FacturaAPagarBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FacturaAPagarTableAdapter As ContaExpress.DSReporteComprasTableAdapters.FacturaAPagarTableAdapter
    Friend WithEvents GastosPorProductoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GastosPorProductoTableAdapter As ContaExpress.DSReporteComprasTableAdapters.GastosPorProductoTableAdapter
    Friend WithEvents UltimaCompraDiasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UltimaCompraDiasTableAdapter As ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter
    Friend WithEvents ComprasCOGsPromedioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ComprasCOGsPromedioTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasCOGsPromedioTableAdapter
    Friend WithEvents COGSDetalladoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COGSDetalladoTableAdapter As ContaExpress.DSReporteComprasTableAdapters.COGSDetalladoTableAdapter
    Friend WithEvents CostoFijoCAntidadVentaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CostoFijoCAntidadVentaTableAdapter As ContaExpress.DSReporteComprasTableAdapters.CostoFijoCAntidadVentaTableAdapter
    Friend WithEvents COSTOFIJOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COSTOFIJOTableAdapter As ContaExpress.DSReporteComprasTableAdapters.COSTOFIJOTableAdapter
    Friend WithEvents ListaPrecioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListaPrecioTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ListaPrecioTableAdapter
    Friend WithEvents CuentaCorrienteProveedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CuentaCorrienteProveedorTableAdapter As ContaExpress.DSReporteComprasTableAdapters.CuentaCorrienteProveedorTableAdapter
    Friend WithEvents cmbtipo As System.Windows.Forms.ComboBox
    Friend WithEvents LblTipo As System.Windows.Forms.Label
    Friend WithEvents ComprasAprobadasTableAdapter As ContaExpress.DSReporteComprasTableAdapters.ComprasAprobadasTableAdapter
    Friend WithEvents cmbtipo2 As System.Windows.Forms.ComboBox
    Friend WithEvents RcchdifTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCCHDIFTableAdapter
    Friend WithEvents RcPendientePagoDifTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCPendientePagoDifTableAdapter
    Friend WithEvents DsRCPagos As ContaExpress.DsRCPagos
    Friend WithEvents chbxMatricial As System.Windows.Forms.CheckBox
    Friend WithEvents RcNotasCreditoTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCNotasCreditoTableAdapter
    Friend WithEvents RcFacturasXReciboTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCFacturasXReciboTableAdapter
    Friend WithEvents RcPagosProveedorTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCPagosProveedorTableAdapter
    Friend WithEvents RcMovimientosProveedorTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCMovimientosProveedorTableAdapter
    Friend WithEvents RCIVAComprasTableAdapter As ContaExpress.DSReporteComprasTableAdapters.RCIVACOMPRASTableAdapter
    Friend WithEvents RCIVANCREDITOComprasTableAdapter As ContaExpress.DsRCNCreditoTableAdapters.RCIVANCREDITOCOMPRASTableAdapter
    Friend WithEvents DsRCNCredito As ContaExpress.DsRCNCredito
    Friend WithEvents RCOMPRASLISTATableAdapter As ContaExpress.DsRCPagosTableAdapters.RCCOMPRASLISTATableAdapter
    Friend WithEvents cmbComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents RCTIPOCOMPROBANTETableAdapter As ContaExpress.DsRCPagosTableAdapters.RCTIPOCOMPROBANTETableAdapter
    Friend WithEvents RCTIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RcRetencionesTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCRetencionesTableAdapter
    Friend WithEvents RcivaleyTableAdapter As ContaExpress.DSReporteComprasTableAdapters.RCIVALEYTableAdapter
    Friend WithEvents pnlFechaPeriodo As System.Windows.Forms.Panel
    Friend WithEvents cmbHasta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDesde As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Mes As System.Windows.Forms.Label
    Friend WithEvents pnlOtrasOpciones As System.Windows.Forms.Panel
    Friend WithEvents rbSinAgrup As System.Windows.Forms.RadioButton
    Friend WithEvents rbAgrupFamillia As System.Windows.Forms.RadioButton
    Friend WithEvents RcProductosPorProveedorTableAdapter As ContaExpress.DsRCComprasTableAdapters.RCProductosPorProveedorTableAdapter
    Friend WithEvents DsRCCompras As ContaExpress.DsRCCompras
    Friend WithEvents RcivancleyTableAdapter As ContaExpress.DSReporteComprasTableAdapters.RCIVANCLEYTableAdapter
    Friend WithEvents RCFacturasAPagarTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCFACTURASAPAGARTableAdapter
    Friend WithEvents RCRecibosProveedorDetTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCRECIBOSPROVEEDORDETTableAdapter
    Friend WithEvents RcAnalisisdeSaldosTableAdapter As ContaExpress.DsRCPagosTableAdapters.RCAnalisisdeSaldosTableAdapter
    Friend WithEvents lblIva As System.Windows.Forms.Label
    Friend WithEvents pnlIva As System.Windows.Forms.Panel
    Friend WithEvents rbSinIva As System.Windows.Forms.RadioButton
    Friend WithEvents rbConIva As System.Windows.Forms.RadioButton
    Friend WithEvents ListaOrdenCompraTableAdapter1 As ContaExpress.DSReporteComprasTableAdapters.ListaOrdenCompraTableAdapter
    Friend WithEvents CentroDetalladoTableAdapter As ContaExpress.DsDetalleCentroTableAdapters.CentroDetalladoTableAdapter
    Friend WithEvents DsDetalleCentro As ContaExpress.DsDetalleCentro
    Friend WithEvents LibroivacomprA_RCTableAdapter As ContaExpress.DsRCComprasTableAdapters.LIBROIVACOMPRA_RCTableAdapter
    Friend WithEvents tbxcodProv As System.Windows.Forms.TextBox
    Friend WithEvents pbxRangoProv As System.Windows.Forms.PictureBox
    Friend WithEvents DsProveedores As ContaExpress.DsProveedores
    Friend WithEvents ListaProvBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ListaProvTableAdapter As ContaExpress.DsProveedoresTableAdapters.ListaProvTableAdapter
End Class
