<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class Dashboard
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend WithEvents AreaPanel As System.Windows.Forms.Panel
    Friend WithEvents DsDashboard As ContaExpress.DsDashboard
    Friend WithEvents EmailingPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents InventarioPanel As System.Windows.Forms.Panel
    Friend WithEvents InventPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents MarketingPanel As System.Windows.Forms.Panel
    Friend WithEvents NOTAY10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelMarketing As System.Windows.Forms.Panel
    Friend WithEvents PanelSettingGral As System.Windows.Forms.Panel
    Friend WithEvents PanelUsuarios As System.Windows.Forms.Panel
    Friend WithEvents PanelVentas As System.Windows.Forms.Panel
    Friend WithEvents PbxProveedor As System.Windows.Forms.PictureBox
    Friend WithEvents PctBoxConfirmaPagos As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxAjuste As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxAuditoria As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCaja As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCliente As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCobros As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCombo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCompras As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxDevoluciones As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxFacturacionPlus As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxFacturacionSimple As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxInventario As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxProductoI As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxReporteCompra As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxReporteVenta As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxUsuario As System.Windows.Forms.PictureBox
    Friend WithEvents RadPanelInventario As System.Windows.Forms.Panel
    Friend WithEvents RadPanelProduccion As System.Windows.Forms.Panel
    Friend WithEvents RadPanelUsuarios As System.Windows.Forms.Panel
    Friend WithEvents RadPanelVentas As System.Windows.Forms.Panel
    Friend WithEvents RadWaitingBar1 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents USUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UsuarioLabel As System.Windows.Forms.Label
    Friend WithEvents USUARIOTableAdapter As ContaExpress.DsDashboardTableAdapters.USUARIOTableAdapter

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

#End Region 'Fields

#Region "Methods"

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelLink = New System.Windows.Forms.Panel()
        Me.PanelContabalidadAbajo = New System.Windows.Forms.Panel()
        Me.PanelMarketing = New System.Windows.Forms.Panel()
        Me.RadPanelProduccion = New System.Windows.Forms.Panel()
        Me.RadPanelUsuarios = New System.Windows.Forms.Panel()
        Me.RadPanelVentas = New System.Windows.Forms.Panel()
        Me.RadPanelInventario = New System.Windows.Forms.Panel()
        Me.RadPanelCompras = New System.Windows.Forms.Panel()
        Me.PanelSettingGral = New System.Windows.Forms.Panel()
        Me.bt_ayuda = New System.Windows.Forms.Panel()
        Me.UsuarioLabel = New System.Windows.Forms.Label()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsDashboard = New ContaExpress.DsDashboard()
        Me.SUCURSALBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.PCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.USUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.USUARIOTableAdapter = New ContaExpress.DsDashboardTableAdapters.USUARIOTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsDashboardTableAdapters.SUCURSALTableAdapter()
        Me.DETPCTableAdapter = New ContaExpress.DsDashboardTableAdapters.DETPCTableAdapter()
        Me.InventarioPanel = New System.Windows.Forms.Panel()
        Me.pbxCombosKit = New System.Windows.Forms.PictureBox()
        Me.pbxTranferencias = New System.Windows.Forms.PictureBox()
        Me.pbxUtilidadesStock = New System.Windows.Forms.PictureBox()
        Me.pbxAjusteStock = New System.Windows.Forms.PictureBox()
        Me.PictureBoxInventario = New System.Windows.Forms.PictureBox()
        Me.PictureBoxAjuste = New System.Windows.Forms.PictureBox()
        Me.PictureBoxProductoI = New System.Windows.Forms.PictureBox()
        Me.InventPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxCodigos = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCombo = New System.Windows.Forms.PictureBox()
        Me.PanelUsuarios = New System.Windows.Forms.Panel()
        Me.btnReporteAuditoria = New System.Windows.Forms.PictureBox()
        Me.PictureBoxAuditoria = New System.Windows.Forms.PictureBox()
        Me.PictureBoxUsuario = New System.Windows.Forms.PictureBox()
        Me.PanelContabilidad = New System.Windows.Forms.Panel()
        Me.btnUtilidadesContabilidad = New System.Windows.Forms.PictureBox()
        Me.PbxAsientosCostos = New System.Windows.Forms.PictureBox()
        Me.PbxPlanillaContable = New System.Windows.Forms.PictureBox()
        Me.PbxRegistrarAsientos = New System.Windows.Forms.PictureBox()
        Me.PbxReporteContabilidad = New System.Windows.Forms.PictureBox()
        Me.PbxLibroVenta = New System.Windows.Forms.PictureBox()
        Me.PbxLibroCompra = New System.Windows.Forms.PictureBox()
        Me.PbxPeriodoFiscal = New System.Windows.Forms.PictureBox()
        Me.PbxPlanCuenta = New System.Windows.Forms.PictureBox()
        Me.PanelVentas = New System.Windows.Forms.Panel()
        Me.btnUtilVentas = New System.Windows.Forms.PictureBox()
        Me.btnPagares = New System.Windows.Forms.PictureBox()
        Me.PictureBoxEnviomercaderia = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCobros = New System.Windows.Forms.PictureBox()
        Me.PictureBoxDevoluciones = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCliente = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCaja = New System.Windows.Forms.PictureBox()
        Me.PictureBoxReporteVenta = New System.Windows.Forms.PictureBox()
        Me.PictureBoxFacturacionSimple = New System.Windows.Forms.PictureBox()
        Me.PictureBoxFacturacionPlus = New System.Windows.Forms.PictureBox()
        Me.AreaPanel = New System.Windows.Forms.Panel()
        Me.btnCheques = New System.Windows.Forms.PictureBox()
        Me.pbxNotaDebito = New System.Windows.Forms.PictureBox()
        Me.pbxUtilidades = New System.Windows.Forms.PictureBox()
        Me.pbxDevolucionCompras = New System.Windows.Forms.PictureBox()
        Me.PbxProveedor = New System.Windows.Forms.PictureBox()
        Me.PctBoxConfirmaPagos = New System.Windows.Forms.PictureBox()
        Me.PictureBoxReporteCompra = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCompras = New System.Windows.Forms.PictureBox()
        Me.MarketingPanel = New System.Windows.Forms.Panel()
        Me.ClientesMktPictureBox = New System.Windows.Forms.PictureBox()
        Me.EmailingPictureBox = New System.Windows.Forms.PictureBox()
        Me.Cmb_Maquina = New System.Windows.Forms.ComboBox()
        Me.Cmb_Sucursal = New System.Windows.Forms.ComboBox()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.pnlCambioSucursal = New System.Windows.Forms.Panel()
        Me.btnCerrarCambioSuc = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbCaja = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCajaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCaja = New ContaExpress.DsCaja()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CAJATableAdapter = New ContaExpress.DsCajaTableAdapters.CAJATableAdapter()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.VerificarModulosActivos = New System.Windows.Forms.Timer(Me.components)
        Me.UltimaCompraDiasTableAdapter1 = New ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.Background = New System.Windows.Forms.Panel()
        Me.PanelProyectos = New System.Windows.Forms.Panel()
        Me.PanelBancosAbajo = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.pbxSucursal = New System.Windows.Forms.PictureBox()
        Me.PanelBancos = New System.Windows.Forms.Panel()
        Me.btnMovBancario = New System.Windows.Forms.PictureBox()
        Me.btnFlujodeCaja = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ProduccionPictureBox = New System.Windows.Forms.PictureBox()
        Me.FraccionamientoPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxEtiquetas = New System.Windows.Forms.PictureBox()
        Me.ConsumoInternoPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxCombos = New System.Windows.Forms.PictureBox()
        Me.PictureBoxReporteProduccion = New System.Windows.Forms.PictureBox()
        Me.pbxAjustes = New System.Windows.Forms.PictureBox()
        Me.ProduccionPanelMenu = New System.Windows.Forms.Panel()
        Me.pbxPlanilladeProduccion = New System.Windows.Forms.PictureBox()
        Me.pbxEtiquetasProduccion = New System.Windows.Forms.PictureBox()
        Me.pbxPlanillaProduccion = New System.Windows.Forms.PictureBox()
        Me.pbxRecetas = New System.Windows.Forms.PictureBox()
        Me.PictureBoxOrdenProduccion = New System.Windows.Forms.PictureBox()
        Me.ProyectosCentral = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxEventos = New System.Windows.Forms.PictureBox()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsDashboard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.InventarioPanel.SuspendLayout()
        CType(Me.pbxCombosKit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTranferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxUtilidadesStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAjusteStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxProductoI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InventPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUsuarios.SuspendLayout()
        CType(Me.btnReporteAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContabilidad.SuspendLayout()
        CType(Me.btnUtilidadesContabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxAsientosCostos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxPlanillaContable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxRegistrarAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxReporteContabilidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxLibroVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxLibroCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxPeriodoFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxPlanCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVentas.SuspendLayout()
        CType(Me.btnUtilVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPagares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxEnviomercaderia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCobros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxDevoluciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxReporteVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxFacturacionSimple, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxFacturacionPlus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AreaPanel.SuspendLayout()
        CType(Me.btnCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNotaDebito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxUtilidades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDevolucionCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PbxProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PctBoxConfirmaPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxReporteCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MarketingPanel.SuspendLayout()
        CType(Me.ClientesMktPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmailingPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCambioSucursal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCajaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Background.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBancos.SuspendLayout()
        CType(Me.btnMovBancario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnFlujodeCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProduccionPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FraccionamientoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEtiquetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConsumoInternoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCombos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxReporteProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAjustes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProduccionPanelMenu.SuspendLayout()
        CType(Me.pbxPlanilladeProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEtiquetasProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPlanillaProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxRecetas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxOrdenProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProyectosCentral.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelLink
        '
        Me.PanelLink.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelLink.BackColor = System.Drawing.Color.Transparent
        Me.PanelLink.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Link_Normal_
        Me.PanelLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelLink.Location = New System.Drawing.Point(817, 644)
        Me.PanelLink.Name = "PanelLink"
        Me.PanelLink.Size = New System.Drawing.Size(50, 50)
        Me.PanelLink.TabIndex = 58
        '
        'PanelContabalidadAbajo
        '
        Me.PanelContabalidadAbajo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelContabalidadAbajo.BackColor = System.Drawing.Color.Transparent
        Me.PanelContabalidadAbajo.BackgroundImage = CType(resources.GetObject("PanelContabalidadAbajo.BackgroundImage"), System.Drawing.Image)
        Me.PanelContabalidadAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelContabalidadAbajo.Location = New System.Drawing.Point(517, 644)
        Me.PanelContabalidadAbajo.Name = "PanelContabalidadAbajo"
        Me.PanelContabalidadAbajo.Size = New System.Drawing.Size(50, 50)
        Me.PanelContabalidadAbajo.TabIndex = 135
        '
        'PanelMarketing
        '
        Me.PanelMarketing.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelMarketing.BackColor = System.Drawing.Color.Transparent
        Me.PanelMarketing.BackgroundImage = CType(resources.GetObject("PanelMarketing.BackgroundImage"), System.Drawing.Image)
        Me.PanelMarketing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelMarketing.Location = New System.Drawing.Point(717, 644)
        Me.PanelMarketing.Name = "PanelMarketing"
        Me.PanelMarketing.Size = New System.Drawing.Size(50, 50)
        Me.PanelMarketing.TabIndex = 134
        '
        'RadPanelProduccion
        '
        Me.RadPanelProduccion.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RadPanelProduccion.BackColor = System.Drawing.Color.Transparent
        Me.RadPanelProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.PRODUCCION
        Me.RadPanelProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadPanelProduccion.Location = New System.Drawing.Point(617, 644)
        Me.RadPanelProduccion.Name = "RadPanelProduccion"
        Me.RadPanelProduccion.Size = New System.Drawing.Size(50, 50)
        Me.RadPanelProduccion.TabIndex = 3
        '
        'RadPanelUsuarios
        '
        Me.RadPanelUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RadPanelUsuarios.BackColor = System.Drawing.Color.Transparent
        Me.RadPanelUsuarios.BackgroundImage = CType(resources.GetObject("RadPanelUsuarios.BackgroundImage"), System.Drawing.Image)
        Me.RadPanelUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadPanelUsuarios.Location = New System.Drawing.Point(467, 644)
        Me.RadPanelUsuarios.Name = "RadPanelUsuarios"
        Me.RadPanelUsuarios.Size = New System.Drawing.Size(50, 50)
        Me.RadPanelUsuarios.TabIndex = 4
        '
        'RadPanelVentas
        '
        Me.RadPanelVentas.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RadPanelVentas.BackColor = System.Drawing.Color.Transparent
        Me.RadPanelVentas.BackgroundImage = CType(resources.GetObject("RadPanelVentas.BackgroundImage"), System.Drawing.Image)
        Me.RadPanelVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadPanelVentas.Location = New System.Drawing.Point(367, 644)
        Me.RadPanelVentas.Name = "RadPanelVentas"
        Me.RadPanelVentas.Size = New System.Drawing.Size(50, 50)
        Me.RadPanelVentas.TabIndex = 1
        '
        'RadPanelInventario
        '
        Me.RadPanelInventario.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RadPanelInventario.BackColor = System.Drawing.Color.Transparent
        Me.RadPanelInventario.BackgroundImage = CType(resources.GetObject("RadPanelInventario.BackgroundImage"), System.Drawing.Image)
        Me.RadPanelInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadPanelInventario.Location = New System.Drawing.Point(417, 644)
        Me.RadPanelInventario.Name = "RadPanelInventario"
        Me.RadPanelInventario.Size = New System.Drawing.Size(50, 50)
        Me.RadPanelInventario.TabIndex = 2
        '
        'RadPanelCompras
        '
        Me.RadPanelCompras.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.RadPanelCompras.BackColor = System.Drawing.Color.Transparent
        Me.RadPanelCompras.BackgroundImage = CType(resources.GetObject("RadPanelCompras.BackgroundImage"), System.Drawing.Image)
        Me.RadPanelCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RadPanelCompras.Location = New System.Drawing.Point(317, 644)
        Me.RadPanelCompras.Name = "RadPanelCompras"
        Me.RadPanelCompras.Size = New System.Drawing.Size(50, 50)
        Me.RadPanelCompras.TabIndex = 2
        '
        'PanelSettingGral
        '
        Me.PanelSettingGral.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelSettingGral.BackColor = System.Drawing.Color.Transparent
        Me.PanelSettingGral.BackgroundImage = CType(resources.GetObject("PanelSettingGral.BackgroundImage"), System.Drawing.Image)
        Me.PanelSettingGral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelSettingGral.Location = New System.Drawing.Point(767, 644)
        Me.PanelSettingGral.Name = "PanelSettingGral"
        Me.PanelSettingGral.Size = New System.Drawing.Size(50, 50)
        Me.PanelSettingGral.TabIndex = 57
        '
        'bt_ayuda
        '
        Me.bt_ayuda.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bt_ayuda.BackColor = System.Drawing.Color.Transparent
        Me.bt_ayuda.BackgroundImage = Global.ContaExpress.My.Resources.Resources.help
        Me.bt_ayuda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_ayuda.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_ayuda.Location = New System.Drawing.Point(1161, 669)
        Me.bt_ayuda.Name = "bt_ayuda"
        Me.bt_ayuda.Size = New System.Drawing.Size(24, 24)
        Me.bt_ayuda.TabIndex = 136
        '
        'UsuarioLabel
        '
        Me.UsuarioLabel.BackColor = System.Drawing.Color.Transparent
        Me.UsuarioLabel.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.UsuarioLabel.ForeColor = System.Drawing.Color.OrangeRed
        Me.UsuarioLabel.Location = New System.Drawing.Point(33, 8)
        Me.UsuarioLabel.Name = "UsuarioLabel"
        Me.UsuarioLabel.Size = New System.Drawing.Size(358, 21)
        Me.UsuarioLabel.TabIndex = 66
        Me.UsuarioLabel.Text = "Usuario"
        Me.UsuarioLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsDashboard
        '
        'DsDashboard
        '
        Me.DsDashboard.DataSetName = "DsDashboard"
        Me.DsDashboard.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SUCURSALBindingSource1
        '
        Me.SUCURSALBindingSource1.DataSource = Me.SUCURSALBindingSource
        '
        'PCBindingSource
        '
        Me.PCBindingSource.DataMember = "DETPC"
        Me.PCBindingSource.DataSource = Me.DsDashboard
        '
        'USUARIOBindingSource
        '
        Me.USUARIOBindingSource.DataMember = "USUARIO"
        Me.USUARIOBindingSource.DataSource = Me.DsDashboard
        '
        'USUARIOTableAdapter
        '
        Me.USUARIOTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'DETPCTableAdapter
        '
        Me.DETPCTableAdapter.ClearBeforeFill = True
        '
        'InventarioPanel
        '
        Me.InventarioPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InventarioPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.InventarioPanel.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.InventarioPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.InventarioPanel.Controls.Add(Me.pbxCombosKit)
        Me.InventarioPanel.Controls.Add(Me.pbxTranferencias)
        Me.InventarioPanel.Controls.Add(Me.pbxUtilidadesStock)
        Me.InventarioPanel.Controls.Add(Me.pbxAjusteStock)
        Me.InventarioPanel.Controls.Add(Me.PictureBoxInventario)
        Me.InventarioPanel.Controls.Add(Me.PictureBoxAjuste)
        Me.InventarioPanel.Controls.Add(Me.PictureBoxProductoI)
        Me.InventarioPanel.Controls.Add(Me.InventPictureBox)
        Me.InventarioPanel.Controls.Add(Me.pbxCodigos)
        Me.InventarioPanel.Controls.Add(Me.PictureBoxCombo)
        Me.InventarioPanel.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.InventarioPanel.Location = New System.Drawing.Point(225, 204)
        Me.InventarioPanel.Name = "InventarioPanel"
        Me.InventarioPanel.Size = New System.Drawing.Size(783, 281)
        Me.InventarioPanel.TabIndex = 42
        '
        'pbxCombosKit
        '
        Me.pbxCombosKit.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxCombosKit.BackColor = System.Drawing.Color.Transparent
        Me.pbxCombosKit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCombosKit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxCombosKit.Image = Global.ContaExpress.My.Resources.Resources.KITCOMBO
        Me.pbxCombosKit.Location = New System.Drawing.Point(168, 13)
        Me.pbxCombosKit.Name = "pbxCombosKit"
        Me.pbxCombosKit.Size = New System.Drawing.Size(146, 125)
        Me.pbxCombosKit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCombosKit.TabIndex = 76
        Me.pbxCombosKit.TabStop = False
        '
        'pbxTranferencias
        '
        Me.pbxTranferencias.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxTranferencias.BackColor = System.Drawing.Color.Transparent
        Me.pbxTranferencias.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnTransferencias
        Me.pbxTranferencias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxTranferencias.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxTranferencias.Location = New System.Drawing.Point(473, 142)
        Me.pbxTranferencias.Name = "pbxTranferencias"
        Me.pbxTranferencias.Size = New System.Drawing.Size(146, 125)
        Me.pbxTranferencias.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxTranferencias.TabIndex = 75
        Me.pbxTranferencias.TabStop = False
        '
        'pbxUtilidadesStock
        '
        Me.pbxUtilidadesStock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxUtilidadesStock.BackColor = System.Drawing.Color.Transparent
        Me.pbxUtilidadesStock.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnUtilidades
        Me.pbxUtilidadesStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxUtilidadesStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxUtilidadesStock.Location = New System.Drawing.Point(626, 142)
        Me.pbxUtilidadesStock.Name = "pbxUtilidadesStock"
        Me.pbxUtilidadesStock.Size = New System.Drawing.Size(146, 125)
        Me.pbxUtilidadesStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxUtilidadesStock.TabIndex = 74
        Me.pbxUtilidadesStock.TabStop = False
        '
        'pbxAjusteStock
        '
        Me.pbxAjusteStock.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxAjusteStock.BackColor = System.Drawing.Color.Transparent
        Me.pbxAjusteStock.BackgroundImage = Global.ContaExpress.My.Resources.Resources.AjusteStock
        Me.pbxAjusteStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxAjusteStock.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAjusteStock.Location = New System.Drawing.Point(166, 142)
        Me.pbxAjusteStock.Name = "pbxAjusteStock"
        Me.pbxAjusteStock.Size = New System.Drawing.Size(146, 125)
        Me.pbxAjusteStock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAjusteStock.TabIndex = 56
        Me.pbxAjusteStock.TabStop = False
        '
        'PictureBoxInventario
        '
        Me.PictureBoxInventario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxInventario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxInventario.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PictureBoxInventario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxInventario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxInventario.Location = New System.Drawing.Point(626, 13)
        Me.PictureBoxInventario.Name = "PictureBoxInventario"
        Me.PictureBoxInventario.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxInventario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxInventario.TabIndex = 55
        Me.PictureBoxInventario.TabStop = False
        '
        'PictureBoxAjuste
        '
        Me.PictureBoxAjuste.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxAjuste.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxAjuste.BackgroundImage = Global.ContaExpress.My.Resources.Resources.movimiento
        Me.PictureBoxAjuste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxAjuste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxAjuste.Location = New System.Drawing.Point(320, 142)
        Me.PictureBoxAjuste.Name = "PictureBoxAjuste"
        Me.PictureBoxAjuste.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxAjuste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxAjuste.TabIndex = 54
        Me.PictureBoxAjuste.TabStop = False
        '
        'PictureBoxProductoI
        '
        Me.PictureBoxProductoI.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxProductoI.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxProductoI.BackgroundImage = Global.ContaExpress.My.Resources.Resources.producto
        Me.PictureBoxProductoI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxProductoI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxProductoI.Location = New System.Drawing.Point(14, 13)
        Me.PictureBoxProductoI.Name = "PictureBoxProductoI"
        Me.PictureBoxProductoI.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxProductoI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxProductoI.TabIndex = 7
        Me.PictureBoxProductoI.TabStop = False
        '
        'InventPictureBox
        '
        Me.InventPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.InventPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.InventPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources._inventario
        Me.InventPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InventPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InventPictureBox.Location = New System.Drawing.Point(14, 142)
        Me.InventPictureBox.Name = "InventPictureBox"
        Me.InventPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.InventPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InventPictureBox.TabIndex = 5
        Me.InventPictureBox.TabStop = False
        '
        'pbxCodigos
        '
        Me.pbxCodigos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxCodigos.BackColor = System.Drawing.Color.Transparent
        Me.pbxCodigos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCodigos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxCodigos.Image = Global.ContaExpress.My.Resources.Resources.CODIGOS
        Me.pbxCodigos.Location = New System.Drawing.Point(320, 13)
        Me.pbxCodigos.Name = "pbxCodigos"
        Me.pbxCodigos.Size = New System.Drawing.Size(146, 125)
        Me.pbxCodigos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCodigos.TabIndex = 52
        Me.pbxCodigos.TabStop = False
        '
        'PictureBoxCombo
        '
        Me.PictureBoxCombo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxCombo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCombo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCombo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxCombo.Image = Global.ContaExpress.My.Resources.Resources.PRECIOS
        Me.PictureBoxCombo.Location = New System.Drawing.Point(474, 13)
        Me.PictureBoxCombo.Name = "PictureBoxCombo"
        Me.PictureBoxCombo.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxCombo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCombo.TabIndex = 52
        Me.PictureBoxCombo.TabStop = False
        '
        'PanelUsuarios
        '
        Me.PanelUsuarios.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelUsuarios.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.PanelUsuarios.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.PanelUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelUsuarios.Controls.Add(Me.btnReporteAuditoria)
        Me.PanelUsuarios.Controls.Add(Me.PictureBoxAuditoria)
        Me.PanelUsuarios.Controls.Add(Me.PictureBoxUsuario)
        Me.PanelUsuarios.Location = New System.Drawing.Point(225, 204)
        Me.PanelUsuarios.Name = "PanelUsuarios"
        Me.PanelUsuarios.Size = New System.Drawing.Size(783, 281)
        Me.PanelUsuarios.TabIndex = 53
        '
        'btnReporteAuditoria
        '
        Me.btnReporteAuditoria.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnReporteAuditoria.BackColor = System.Drawing.Color.Transparent
        Me.btnReporteAuditoria.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.btnReporteAuditoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnReporteAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReporteAuditoria.Location = New System.Drawing.Point(625, 13)
        Me.btnReporteAuditoria.Name = "btnReporteAuditoria"
        Me.btnReporteAuditoria.Size = New System.Drawing.Size(146, 125)
        Me.btnReporteAuditoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnReporteAuditoria.TabIndex = 63
        Me.btnReporteAuditoria.TabStop = False
        '
        'PictureBoxAuditoria
        '
        Me.PictureBoxAuditoria.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxAuditoria.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxAuditoria.BackgroundImage = Global.ContaExpress.My.Resources.Resources.auditoria
        Me.PictureBoxAuditoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxAuditoria.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxAuditoria.Location = New System.Drawing.Point(14, 142)
        Me.PictureBoxAuditoria.Name = "PictureBoxAuditoria"
        Me.PictureBoxAuditoria.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxAuditoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxAuditoria.TabIndex = 62
        Me.PictureBoxAuditoria.TabStop = False
        '
        'PictureBoxUsuario
        '
        Me.PictureBoxUsuario.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxUsuario.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxUsuario.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Usuarios
        Me.PictureBoxUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxUsuario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxUsuario.Location = New System.Drawing.Point(14, 13)
        Me.PictureBoxUsuario.Name = "PictureBoxUsuario"
        Me.PictureBoxUsuario.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxUsuario.TabIndex = 39
        Me.PictureBoxUsuario.TabStop = False
        '
        'PanelContabilidad
        '
        Me.PanelContabilidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelContabilidad.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.PanelContabilidad.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.PanelContabilidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelContabilidad.Controls.Add(Me.btnUtilidadesContabilidad)
        Me.PanelContabilidad.Controls.Add(Me.PbxAsientosCostos)
        Me.PanelContabilidad.Controls.Add(Me.PbxPlanillaContable)
        Me.PanelContabilidad.Controls.Add(Me.PbxRegistrarAsientos)
        Me.PanelContabilidad.Controls.Add(Me.PbxReporteContabilidad)
        Me.PanelContabilidad.Controls.Add(Me.PbxLibroVenta)
        Me.PanelContabilidad.Controls.Add(Me.PbxLibroCompra)
        Me.PanelContabilidad.Controls.Add(Me.PbxPeriodoFiscal)
        Me.PanelContabilidad.Controls.Add(Me.PbxPlanCuenta)
        Me.PanelContabilidad.Location = New System.Drawing.Point(225, 204)
        Me.PanelContabilidad.Name = "PanelContabilidad"
        Me.PanelContabilidad.Size = New System.Drawing.Size(783, 281)
        Me.PanelContabilidad.TabIndex = 72
        '
        'btnUtilidadesContabilidad
        '
        Me.btnUtilidadesContabilidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUtilidadesContabilidad.BackColor = System.Drawing.Color.Transparent
        Me.btnUtilidadesContabilidad.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnUtilidadesInactivo
        Me.btnUtilidadesContabilidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUtilidadesContabilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUtilidadesContabilidad.Location = New System.Drawing.Point(624, 144)
        Me.btnUtilidadesContabilidad.Name = "btnUtilidadesContabilidad"
        Me.btnUtilidadesContabilidad.Size = New System.Drawing.Size(146, 125)
        Me.btnUtilidadesContabilidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnUtilidadesContabilidad.TabIndex = 467
        Me.btnUtilidadesContabilidad.TabStop = False
        '
        'PbxAsientosCostos
        '
        Me.PbxAsientosCostos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxAsientosCostos.BackColor = System.Drawing.Color.Transparent
        Me.PbxAsientosCostos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.enconstruccion
        Me.PbxAsientosCostos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxAsientosCostos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxAsientosCostos.Image = Global.ContaExpress.My.Resources.Resources.asientocostoInactivo
        Me.PbxAsientosCostos.Location = New System.Drawing.Point(470, 12)
        Me.PbxAsientosCostos.Name = "PbxAsientosCostos"
        Me.PbxAsientosCostos.Size = New System.Drawing.Size(146, 125)
        Me.PbxAsientosCostos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxAsientosCostos.TabIndex = 466
        Me.PbxAsientosCostos.TabStop = False
        '
        'PbxPlanillaContable
        '
        Me.PbxPlanillaContable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxPlanillaContable.BackColor = System.Drawing.Color.Transparent
        Me.PbxPlanillaContable.BackgroundImage = Global.ContaExpress.My.Resources.Resources.planillaContableInactivo
        Me.PbxPlanillaContable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxPlanillaContable.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxPlanillaContable.Location = New System.Drawing.Point(318, 12)
        Me.PbxPlanillaContable.Name = "PbxPlanillaContable"
        Me.PbxPlanillaContable.Size = New System.Drawing.Size(146, 125)
        Me.PbxPlanillaContable.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxPlanillaContable.TabIndex = 464
        Me.PbxPlanillaContable.TabStop = False
        '
        'PbxRegistrarAsientos
        '
        Me.PbxRegistrarAsientos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxRegistrarAsientos.BackColor = System.Drawing.Color.Transparent
        Me.PbxRegistrarAsientos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.ASIENTOSINACTIVO
        Me.PbxRegistrarAsientos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxRegistrarAsientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxRegistrarAsientos.Location = New System.Drawing.Point(470, 144)
        Me.PbxRegistrarAsientos.Name = "PbxRegistrarAsientos"
        Me.PbxRegistrarAsientos.Size = New System.Drawing.Size(146, 125)
        Me.PbxRegistrarAsientos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxRegistrarAsientos.TabIndex = 46
        Me.PbxRegistrarAsientos.TabStop = False
        '
        'PbxReporteContabilidad
        '
        Me.PbxReporteContabilidad.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxReporteContabilidad.BackColor = System.Drawing.Color.Transparent
        Me.PbxReporteContabilidad.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PbxReporteContabilidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxReporteContabilidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxReporteContabilidad.Location = New System.Drawing.Point(622, 12)
        Me.PbxReporteContabilidad.Name = "PbxReporteContabilidad"
        Me.PbxReporteContabilidad.Size = New System.Drawing.Size(146, 125)
        Me.PbxReporteContabilidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxReporteContabilidad.TabIndex = 45
        Me.PbxReporteContabilidad.TabStop = False
        '
        'PbxLibroVenta
        '
        Me.PbxLibroVenta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxLibroVenta.BackColor = System.Drawing.Color.Transparent
        Me.PbxLibroVenta.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LibVentaInactivo
        Me.PbxLibroVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxLibroVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxLibroVenta.Location = New System.Drawing.Point(14, 144)
        Me.PbxLibroVenta.Name = "PbxLibroVenta"
        Me.PbxLibroVenta.Size = New System.Drawing.Size(146, 125)
        Me.PbxLibroVenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLibroVenta.TabIndex = 44
        Me.PbxLibroVenta.TabStop = False
        '
        'PbxLibroCompra
        '
        Me.PbxLibroCompra.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxLibroCompra.BackColor = System.Drawing.Color.Transparent
        Me.PbxLibroCompra.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LibCompraInactivo
        Me.PbxLibroCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxLibroCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxLibroCompra.Location = New System.Drawing.Point(168, 144)
        Me.PbxLibroCompra.Name = "PbxLibroCompra"
        Me.PbxLibroCompra.Size = New System.Drawing.Size(146, 125)
        Me.PbxLibroCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxLibroCompra.TabIndex = 43
        Me.PbxLibroCompra.TabStop = False
        '
        'PbxPeriodoFiscal
        '
        Me.PbxPeriodoFiscal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxPeriodoFiscal.BackColor = System.Drawing.Color.Transparent
        Me.PbxPeriodoFiscal.BackgroundImage = Global.ContaExpress.My.Resources.Resources.EjeContableInactivo
        Me.PbxPeriodoFiscal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxPeriodoFiscal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxPeriodoFiscal.Location = New System.Drawing.Point(14, 12)
        Me.PbxPeriodoFiscal.Name = "PbxPeriodoFiscal"
        Me.PbxPeriodoFiscal.Size = New System.Drawing.Size(146, 125)
        Me.PbxPeriodoFiscal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxPeriodoFiscal.TabIndex = 39
        Me.PbxPeriodoFiscal.TabStop = False
        '
        'PbxPlanCuenta
        '
        Me.PbxPlanCuenta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PbxPlanCuenta.BackColor = System.Drawing.Color.Transparent
        Me.PbxPlanCuenta.BackgroundImage = Global.ContaExpress.My.Resources.Resources.PlanCuentasInactivo
        Me.PbxPlanCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PbxPlanCuenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxPlanCuenta.Location = New System.Drawing.Point(166, 12)
        Me.PbxPlanCuenta.Name = "PbxPlanCuenta"
        Me.PbxPlanCuenta.Size = New System.Drawing.Size(146, 125)
        Me.PbxPlanCuenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxPlanCuenta.TabIndex = 40
        Me.PbxPlanCuenta.TabStop = False
        '
        'PanelVentas
        '
        Me.PanelVentas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelVentas.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.PanelVentas.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.PanelVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelVentas.Controls.Add(Me.btnUtilVentas)
        Me.PanelVentas.Controls.Add(Me.btnPagares)
        Me.PanelVentas.Controls.Add(Me.PictureBoxEnviomercaderia)
        Me.PanelVentas.Controls.Add(Me.PictureBoxCobros)
        Me.PanelVentas.Controls.Add(Me.PictureBoxDevoluciones)
        Me.PanelVentas.Controls.Add(Me.PictureBoxCliente)
        Me.PanelVentas.Controls.Add(Me.PictureBoxCaja)
        Me.PanelVentas.Controls.Add(Me.PictureBoxReporteVenta)
        Me.PanelVentas.Controls.Add(Me.PictureBoxFacturacionSimple)
        Me.PanelVentas.Controls.Add(Me.PictureBoxFacturacionPlus)
        Me.PanelVentas.Location = New System.Drawing.Point(225, 204)
        Me.PanelVentas.Name = "PanelVentas"
        Me.PanelVentas.Size = New System.Drawing.Size(783, 281)
        Me.PanelVentas.TabIndex = 55
        '
        'btnUtilVentas
        '
        Me.btnUtilVentas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUtilVentas.BackColor = System.Drawing.Color.Transparent
        Me.btnUtilVentas.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnUtilidadesInactivo
        Me.btnUtilVentas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnUtilVentas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUtilVentas.Location = New System.Drawing.Point(626, 144)
        Me.btnUtilVentas.Name = "btnUtilVentas"
        Me.btnUtilVentas.Size = New System.Drawing.Size(146, 125)
        Me.btnUtilVentas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnUtilVentas.TabIndex = 468
        Me.btnUtilVentas.TabStop = False
        '
        'btnPagares
        '
        Me.btnPagares.BackColor = System.Drawing.Color.Transparent
        Me.btnPagares.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnPagaresInactivo
        Me.btnPagares.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPagares.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPagares.Location = New System.Drawing.Point(170, 144)
        Me.btnPagares.Name = "btnPagares"
        Me.btnPagares.Size = New System.Drawing.Size(146, 125)
        Me.btnPagares.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnPagares.TabIndex = 57
        Me.btnPagares.TabStop = False
        '
        'PictureBoxEnviomercaderia
        '
        Me.PictureBoxEnviomercaderia.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxEnviomercaderia.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxEnviomercaderia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxEnviomercaderia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxEnviomercaderia.Image = Global.ContaExpress.My.Resources.Resources.envio_mercaderia_Inactivo
        Me.PictureBoxEnviomercaderia.Location = New System.Drawing.Point(17, 144)
        Me.PictureBoxEnviomercaderia.Name = "PictureBoxEnviomercaderia"
        Me.PictureBoxEnviomercaderia.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxEnviomercaderia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxEnviomercaderia.TabIndex = 56
        Me.PictureBoxEnviomercaderia.TabStop = False
        '
        'PictureBoxCobros
        '
        Me.PictureBoxCobros.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxCobros.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCobros.BackgroundImage = Global.ContaExpress.My.Resources.Resources.cobroInactivo
        Me.PictureBoxCobros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCobros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxCobros.Location = New System.Drawing.Point(322, 144)
        Me.PictureBoxCobros.Name = "PictureBoxCobros"
        Me.PictureBoxCobros.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxCobros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCobros.TabIndex = 55
        Me.PictureBoxCobros.TabStop = False
        '
        'PictureBoxDevoluciones
        '
        Me.PictureBoxDevoluciones.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxDevoluciones.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxDevoluciones.BackgroundImage = Global.ContaExpress.My.Resources.Resources.DevolucionInactivo
        Me.PictureBoxDevoluciones.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxDevoluciones.Location = New System.Drawing.Point(472, 144)
        Me.PictureBoxDevoluciones.Name = "PictureBoxDevoluciones"
        Me.PictureBoxDevoluciones.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxDevoluciones.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxDevoluciones.TabIndex = 54
        Me.PictureBoxDevoluciones.TabStop = False
        '
        'PictureBoxCliente
        '
        Me.PictureBoxCliente.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxCliente.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCliente.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Clientes
        Me.PictureBoxCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxCliente.Location = New System.Drawing.Point(472, 13)
        Me.PictureBoxCliente.Name = "PictureBoxCliente"
        Me.PictureBoxCliente.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCliente.TabIndex = 53
        Me.PictureBoxCliente.TabStop = False
        '
        'PictureBoxCaja
        '
        Me.PictureBoxCaja.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxCaja.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCaja.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Caja
        Me.PictureBoxCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxCaja.Location = New System.Drawing.Point(17, 13)
        Me.PictureBoxCaja.Name = "PictureBoxCaja"
        Me.PictureBoxCaja.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxCaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCaja.TabIndex = 48
        Me.PictureBoxCaja.TabStop = False
        '
        'PictureBoxReporteVenta
        '
        Me.PictureBoxReporteVenta.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxReporteVenta.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxReporteVenta.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PictureBoxReporteVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxReporteVenta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxReporteVenta.Location = New System.Drawing.Point(626, 13)
        Me.PictureBoxReporteVenta.Name = "PictureBoxReporteVenta"
        Me.PictureBoxReporteVenta.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxReporteVenta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxReporteVenta.TabIndex = 47
        Me.PictureBoxReporteVenta.TabStop = False
        '
        'PictureBoxFacturacionSimple
        '
        Me.PictureBoxFacturacionSimple.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxFacturacionSimple.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxFacturacionSimple.BackgroundImage = Global.ContaExpress.My.Resources.Resources.venta
        Me.PictureBoxFacturacionSimple.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxFacturacionSimple.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxFacturacionSimple.Location = New System.Drawing.Point(170, 13)
        Me.PictureBoxFacturacionSimple.Name = "PictureBoxFacturacionSimple"
        Me.PictureBoxFacturacionSimple.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxFacturacionSimple.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFacturacionSimple.TabIndex = 37
        Me.PictureBoxFacturacionSimple.TabStop = False
        '
        'PictureBoxFacturacionPlus
        '
        Me.PictureBoxFacturacionPlus.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PictureBoxFacturacionPlus.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxFacturacionPlus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxFacturacionPlus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxFacturacionPlus.Image = Global.ContaExpress.My.Resources.Resources.VentasPlusInactivo
        Me.PictureBoxFacturacionPlus.Location = New System.Drawing.Point(322, 13)
        Me.PictureBoxFacturacionPlus.Name = "PictureBoxFacturacionPlus"
        Me.PictureBoxFacturacionPlus.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxFacturacionPlus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxFacturacionPlus.TabIndex = 50
        Me.PictureBoxFacturacionPlus.TabStop = False
        '
        'AreaPanel
        '
        Me.AreaPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AreaPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.AreaPanel.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.AreaPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.AreaPanel.Controls.Add(Me.btnCheques)
        Me.AreaPanel.Controls.Add(Me.pbxNotaDebito)
        Me.AreaPanel.Controls.Add(Me.pbxUtilidades)
        Me.AreaPanel.Controls.Add(Me.pbxDevolucionCompras)
        Me.AreaPanel.Controls.Add(Me.PbxProveedor)
        Me.AreaPanel.Controls.Add(Me.PctBoxConfirmaPagos)
        Me.AreaPanel.Controls.Add(Me.PictureBoxReporteCompra)
        Me.AreaPanel.Controls.Add(Me.PictureBoxCompras)
        Me.AreaPanel.Location = New System.Drawing.Point(225, 204)
        Me.AreaPanel.Name = "AreaPanel"
        Me.AreaPanel.Size = New System.Drawing.Size(783, 281)
        Me.AreaPanel.TabIndex = 34
        '
        'btnCheques
        '
        Me.btnCheques.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCheques.BackColor = System.Drawing.Color.Transparent
        Me.btnCheques.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pbxChequesInactivos
        Me.btnCheques.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCheques.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCheques.Location = New System.Drawing.Point(168, 142)
        Me.btnCheques.Name = "btnCheques"
        Me.btnCheques.Size = New System.Drawing.Size(146, 125)
        Me.btnCheques.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCheques.TabIndex = 75
        Me.btnCheques.TabStop = False
        '
        'pbxNotaDebito
        '
        Me.pbxNotaDebito.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbxNotaDebito.BackColor = System.Drawing.Color.Transparent
        Me.pbxNotaDebito.BackgroundImage = Global.ContaExpress.My.Resources.Resources.NdebitoInactivo
        Me.pbxNotaDebito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNotaDebito.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxNotaDebito.Location = New System.Drawing.Point(472, 142)
        Me.pbxNotaDebito.Name = "pbxNotaDebito"
        Me.pbxNotaDebito.Size = New System.Drawing.Size(146, 125)
        Me.pbxNotaDebito.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxNotaDebito.TabIndex = 74
        Me.pbxNotaDebito.TabStop = False
        '
        'pbxUtilidades
        '
        Me.pbxUtilidades.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxUtilidades.BackColor = System.Drawing.Color.Transparent
        Me.pbxUtilidades.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnUtilidadesInactivo
        Me.pbxUtilidades.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxUtilidades.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxUtilidades.Location = New System.Drawing.Point(624, 142)
        Me.pbxUtilidades.Name = "pbxUtilidades"
        Me.pbxUtilidades.Size = New System.Drawing.Size(146, 125)
        Me.pbxUtilidades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxUtilidades.TabIndex = 73
        Me.pbxUtilidades.TabStop = False
        '
        'pbxDevolucionCompras
        '
        Me.pbxDevolucionCompras.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbxDevolucionCompras.BackColor = System.Drawing.Color.Transparent
        Me.pbxDevolucionCompras.BackgroundImage = Global.ContaExpress.My.Resources.Resources.DevolucionInactivo
        Me.pbxDevolucionCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxDevolucionCompras.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxDevolucionCompras.Location = New System.Drawing.Point(320, 142)
        Me.pbxDevolucionCompras.Name = "pbxDevolucionCompras"
        Me.pbxDevolucionCompras.Size = New System.Drawing.Size(146, 125)
        Me.pbxDevolucionCompras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDevolucionCompras.TabIndex = 72
        Me.pbxDevolucionCompras.TabStop = False
        '
        'PbxProveedor
        '
        Me.PbxProveedor.BackColor = System.Drawing.Color.Transparent
        Me.PbxProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PbxProveedor.Image = Global.ContaExpress.My.Resources.Resources.PROVEEDOR
        Me.PbxProveedor.Location = New System.Drawing.Point(168, 12)
        Me.PbxProveedor.Name = "PbxProveedor"
        Me.PbxProveedor.Size = New System.Drawing.Size(146, 125)
        Me.PbxProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PbxProveedor.TabIndex = 71
        Me.PbxProveedor.TabStop = False
        '
        'PctBoxConfirmaPagos
        '
        Me.PctBoxConfirmaPagos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PctBoxConfirmaPagos.BackColor = System.Drawing.Color.Transparent
        Me.PctBoxConfirmaPagos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pagos
        Me.PctBoxConfirmaPagos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PctBoxConfirmaPagos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PctBoxConfirmaPagos.Location = New System.Drawing.Point(18, 142)
        Me.PctBoxConfirmaPagos.Name = "PctBoxConfirmaPagos"
        Me.PctBoxConfirmaPagos.Size = New System.Drawing.Size(146, 125)
        Me.PctBoxConfirmaPagos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PctBoxConfirmaPagos.TabIndex = 44
        Me.PctBoxConfirmaPagos.TabStop = False
        '
        'PictureBoxReporteCompra
        '
        Me.PictureBoxReporteCompra.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxReporteCompra.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxReporteCompra.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PictureBoxReporteCompra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxReporteCompra.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxReporteCompra.Location = New System.Drawing.Point(624, 12)
        Me.PictureBoxReporteCompra.Name = "PictureBoxReporteCompra"
        Me.PictureBoxReporteCompra.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxReporteCompra.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxReporteCompra.TabIndex = 43
        Me.PictureBoxReporteCompra.TabStop = False
        '
        'PictureBoxCompras
        '
        Me.PictureBoxCompras.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxCompras.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCompras.BackgroundImage = Global.ContaExpress.My.Resources.Resources.COMPRASplusInactivo
        Me.PictureBoxCompras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCompras.Location = New System.Drawing.Point(19, 12)
        Me.PictureBoxCompras.Name = "PictureBoxCompras"
        Me.PictureBoxCompras.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxCompras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCompras.TabIndex = 40
        Me.PictureBoxCompras.TabStop = False
        '
        'MarketingPanel
        '
        Me.MarketingPanel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.MarketingPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.MarketingPanel.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.MarketingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MarketingPanel.Controls.Add(Me.ClientesMktPictureBox)
        Me.MarketingPanel.Controls.Add(Me.EmailingPictureBox)
        Me.MarketingPanel.Location = New System.Drawing.Point(225, 204)
        Me.MarketingPanel.Name = "MarketingPanel"
        Me.MarketingPanel.Size = New System.Drawing.Size(783, 281)
        Me.MarketingPanel.TabIndex = 70
        '
        'ClientesMktPictureBox
        '
        Me.ClientesMktPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ClientesMktPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ClientesMktPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Clientes
        Me.ClientesMktPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientesMktPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ClientesMktPictureBox.Location = New System.Drawing.Point(166, 13)
        Me.ClientesMktPictureBox.Name = "ClientesMktPictureBox"
        Me.ClientesMktPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.ClientesMktPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ClientesMktPictureBox.TabIndex = 54
        Me.ClientesMktPictureBox.TabStop = False
        '
        'EmailingPictureBox
        '
        Me.EmailingPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.EmailingPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EmailingPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EmailingPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EmailingPictureBox.Image = Global.ContaExpress.My.Resources.Resources.MailingInactivo
        Me.EmailingPictureBox.Location = New System.Drawing.Point(14, 13)
        Me.EmailingPictureBox.Name = "EmailingPictureBox"
        Me.EmailingPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.EmailingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EmailingPictureBox.TabIndex = 40
        Me.EmailingPictureBox.TabStop = False
        '
        'Cmb_Maquina
        '
        Me.Cmb_Maquina.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cmb_Maquina.BackColor = System.Drawing.SystemColors.Menu
        Me.Cmb_Maquina.CausesValidation = False
        Me.Cmb_Maquina.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.PCBindingSource, "IP", True))
        Me.Cmb_Maquina.DataSource = Me.PCBindingSource
        Me.Cmb_Maquina.DisplayMember = "DESCRIPCION"
        Me.Cmb_Maquina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Maquina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Maquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Maquina.ForeColor = System.Drawing.Color.DimGray
        Me.Cmb_Maquina.FormattingEnabled = True
        Me.Cmb_Maquina.Location = New System.Drawing.Point(115, 107)
        Me.Cmb_Maquina.Name = "Cmb_Maquina"
        Me.Cmb_Maquina.Size = New System.Drawing.Size(198, 28)
        Me.Cmb_Maquina.TabIndex = 455
        Me.Cmb_Maquina.ValueMember = "IP"
        '
        'Cmb_Sucursal
        '
        Me.Cmb_Sucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cmb_Sucursal.BackColor = System.Drawing.SystemColors.Menu
        Me.Cmb_Sucursal.CausesValidation = False
        Me.Cmb_Sucursal.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.SUCURSALBindingSource, "CODSUCURSAL", True))
        Me.Cmb_Sucursal.DataSource = Me.SUCURSALBindingSource
        Me.Cmb_Sucursal.DisplayMember = "DESSUCURSAL"
        Me.Cmb_Sucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Sucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Cmb_Sucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_Sucursal.ForeColor = System.Drawing.Color.DimGray
        Me.Cmb_Sucursal.FormattingEnabled = True
        Me.Cmb_Sucursal.Location = New System.Drawing.Point(115, 73)
        Me.Cmb_Sucursal.Name = "Cmb_Sucursal"
        Me.Cmb_Sucursal.Size = New System.Drawing.Size(198, 28)
        Me.Cmb_Sucursal.TabIndex = 455
        Me.Cmb_Sucursal.ValueMember = "CODSUCURSAL"
        '
        'lblUbicacion
        '
        Me.lblUbicacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUbicacion.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicacion.Font = New System.Drawing.Font("Segoe UI Light", 12.0!)
        Me.lblUbicacion.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblUbicacion.Location = New System.Drawing.Point(802, 8)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(358, 21)
        Me.lblUbicacion.TabIndex = 74
        Me.lblUbicacion.Text = "lblUbicacion"
        Me.lblUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlCambioSucursal
        '
        Me.pnlCambioSucursal.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pnlCambioSucursal.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlCambioSucursal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCambioSucursal.Controls.Add(Me.btnCerrarCambioSuc)
        Me.pnlCambioSucursal.Controls.Add(Me.Label8)
        Me.pnlCambioSucursal.Controls.Add(Me.Panel1)
        Me.pnlCambioSucursal.Controls.Add(Me.Label6)
        Me.pnlCambioSucursal.Controls.Add(Me.CmbCaja)
        Me.pnlCambioSucursal.Controls.Add(Me.Cmb_Maquina)
        Me.pnlCambioSucursal.Controls.Add(Me.Label5)
        Me.pnlCambioSucursal.Controls.Add(Me.Cmb_Sucursal)
        Me.pnlCambioSucursal.Controls.Add(Me.Label3)
        Me.pnlCambioSucursal.Location = New System.Drawing.Point(436, 175)
        Me.pnlCambioSucursal.Name = "pnlCambioSucursal"
        Me.pnlCambioSucursal.Size = New System.Drawing.Size(357, 231)
        Me.pnlCambioSucursal.TabIndex = 458
        Me.pnlCambioSucursal.Visible = False
        '
        'btnCerrarCambioSuc
        '
        Me.btnCerrarCambioSuc.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.btnCerrarCambioSuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarCambioSuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCerrarCambioSuc.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnCerrarCambioSuc.Location = New System.Drawing.Point(192, 183)
        Me.btnCerrarCambioSuc.Name = "btnCerrarCambioSuc"
        Me.btnCerrarCambioSuc.Size = New System.Drawing.Size(121, 36)
        Me.btnCerrarCambioSuc.TabIndex = 464
        Me.btnCerrarCambioSuc.Text = "Cerrar Panel"
        Me.btnCerrarCambioSuc.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(1, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(295, 13)
        Me.Label8.TabIndex = 460
        Me.Label8.Text = "Al Elegir otra opción, Pos Express automaticamente cambiara"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Gold
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(358, 48)
        Me.Panel1.TabIndex = 459
        '
        'Label7
        '
        Me.Label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(81, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(204, 28)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Cambio de Ubicación"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Silver
        Me.Label6.Location = New System.Drawing.Point(59, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 458
        Me.Label6.Text = "Cuenta:"
        '
        'CmbCaja
        '
        Me.CmbCaja.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbCaja.BackColor = System.Drawing.SystemColors.Menu
        Me.CmbCaja.CausesValidation = False
        Me.CmbCaja.DataBindings.Add(New System.Windows.Forms.Binding("SelectedItem", Me.CAJABindingSource, "NUMCAJA", True))
        Me.CmbCaja.DataSource = Me.CAJABindingSource
        Me.CmbCaja.DisplayMember = "NUMEROCAJA"
        Me.CmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbCaja.ForeColor = System.Drawing.Color.DimGray
        Me.CmbCaja.FormattingEnabled = True
        Me.CmbCaja.Location = New System.Drawing.Point(115, 142)
        Me.CmbCaja.Name = "CmbCaja"
        Me.CmbCaja.Size = New System.Drawing.Size(198, 28)
        Me.CmbCaja.TabIndex = 455
        Me.CmbCaja.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsCajaBindingSource
        '
        'DsCajaBindingSource
        '
        Me.DsCajaBindingSource.DataSource = Me.DsCaja
        Me.DsCajaBindingSource.Position = 0
        '
        'DsCaja
        '
        Me.DsCaja.DataSetName = "DsCaja"
        Me.DsCaja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Silver
        Me.Label5.Location = New System.Drawing.Point(27, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 16)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Facturar con:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Silver
        Me.Label3.Location = New System.Drawing.Point(49, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Sucursal:"
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'lblEmpresa
        '
        Me.lblEmpresa.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.lblEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEmpresa.Font = New System.Drawing.Font("Segoe UI Light", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblEmpresa.Location = New System.Drawing.Point(396, -4)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(400, 40)
        Me.lblEmpresa.TabIndex = 462
        Me.lblEmpresa.Text = "lblEmpresa"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UltimaCompraDiasTableAdapter1
        '
        Me.UltimaCompraDiasTableAdapter1.ClearBeforeFill = True
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'Background
        '
        Me.Background.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Background.BackgroundImage = Global.ContaExpress.My.Resources.Resources.BlackWood
        Me.Background.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Background.Controls.Add(Me.PanelProyectos)
        Me.Background.Controls.Add(Me.PanelBancosAbajo)
        Me.Background.Controls.Add(Me.PictureBox5)
        Me.Background.Controls.Add(Me.PictureBox4)
        Me.Background.Controls.Add(Me.pbxSucursal)
        Me.Background.Controls.Add(Me.UsuarioLabel)
        Me.Background.Controls.Add(Me.PanelLink)
        Me.Background.Controls.Add(Me.bt_ayuda)
        Me.Background.Controls.Add(Me.RadPanelCompras)
        Me.Background.Controls.Add(Me.PanelContabalidadAbajo)
        Me.Background.Controls.Add(Me.RadPanelVentas)
        Me.Background.Controls.Add(Me.PanelSettingGral)
        Me.Background.Controls.Add(Me.PanelMarketing)
        Me.Background.Controls.Add(Me.RadPanelInventario)
        Me.Background.Controls.Add(Me.RadPanelUsuarios)
        Me.Background.Controls.Add(Me.RadPanelProduccion)
        Me.Background.Controls.Add(Me.lblEmpresa)
        Me.Background.Controls.Add(Me.lblUbicacion)
        Me.Background.Location = New System.Drawing.Point(1, 0)
        Me.Background.Name = "Background"
        Me.Background.Size = New System.Drawing.Size(1192, 697)
        Me.Background.TabIndex = 468
        '
        'PanelProyectos
        '
        Me.PanelProyectos.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelProyectos.BackColor = System.Drawing.Color.Transparent
        Me.PanelProyectos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.MenuProyecto2
        Me.PanelProyectos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelProyectos.Location = New System.Drawing.Point(667, 644)
        Me.PanelProyectos.Name = "PanelProyectos"
        Me.PanelProyectos.Size = New System.Drawing.Size(50, 50)
        Me.PanelProyectos.TabIndex = 470
        '
        'PanelBancosAbajo
        '
        Me.PanelBancosAbajo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.PanelBancosAbajo.BackColor = System.Drawing.Color.Transparent
        Me.PanelBancosAbajo.BackgroundImage = Global.ContaExpress.My.Resources.Resources.bancos
        Me.PanelBancosAbajo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelBancosAbajo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PanelBancosAbajo.Location = New System.Drawing.Point(567, 645)
        Me.PanelBancosAbajo.Name = "PanelBancosAbajo"
        Me.PanelBancosAbajo.Size = New System.Drawing.Size(50, 50)
        Me.PanelBancosAbajo.TabIndex = 468
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.ContaExpress.My.Resources.Resources.User
        Me.PictureBox5.InitialImage = Nothing
        Me.PictureBox5.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 467
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.ContaExpress.My.Resources.Resources.Sucursal
        Me.PictureBox4.InitialImage = Nothing
        Me.PictureBox4.Location = New System.Drawing.Point(578, 332)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 466
        Me.PictureBox4.TabStop = False
        '
        'pbxSucursal
        '
        Me.pbxSucursal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxSucursal.BackColor = System.Drawing.Color.Transparent
        Me.pbxSucursal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxSucursal.Image = Global.ContaExpress.My.Resources.Resources.Sucursal
        Me.pbxSucursal.InitialImage = Nothing
        Me.pbxSucursal.Location = New System.Drawing.Point(1159, 5)
        Me.pbxSucursal.Name = "pbxSucursal"
        Me.pbxSucursal.Size = New System.Drawing.Size(24, 24)
        Me.pbxSucursal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxSucursal.TabIndex = 464
        Me.pbxSucursal.TabStop = False
        '
        'PanelBancos
        '
        Me.PanelBancos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelBancos.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.PanelBancos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.PanelBancos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelBancos.Controls.Add(Me.btnMovBancario)
        Me.PanelBancos.Controls.Add(Me.btnFlujodeCaja)
        Me.PanelBancos.Controls.Add(Me.Button1)
        Me.PanelBancos.Location = New System.Drawing.Point(225, 204)
        Me.PanelBancos.Name = "PanelBancos"
        Me.PanelBancos.Size = New System.Drawing.Size(783, 281)
        Me.PanelBancos.TabIndex = 470
        '
        'btnMovBancario
        '
        Me.btnMovBancario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnMovBancario.BackColor = System.Drawing.Color.Transparent
        Me.btnMovBancario.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnMovBancario
        Me.btnMovBancario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnMovBancario.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMovBancario.Location = New System.Drawing.Point(170, 13)
        Me.btnMovBancario.Name = "btnMovBancario"
        Me.btnMovBancario.Size = New System.Drawing.Size(146, 125)
        Me.btnMovBancario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnMovBancario.TabIndex = 64
        Me.btnMovBancario.TabStop = False
        '
        'btnFlujodeCaja
        '
        Me.btnFlujodeCaja.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnFlujodeCaja.BackColor = System.Drawing.Color.Transparent
        Me.btnFlujodeCaja.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnFlujoCaja
        Me.btnFlujodeCaja.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnFlujodeCaja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFlujodeCaja.Location = New System.Drawing.Point(17, 13)
        Me.btnFlujodeCaja.Name = "btnFlujodeCaja"
        Me.btnFlujodeCaja.Size = New System.Drawing.Size(146, 125)
        Me.btnFlujodeCaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnFlujodeCaja.TabIndex = 63
        Me.btnFlujodeCaja.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 56)
        Me.Button1.TabIndex = 64
        Me.Button1.Text = "Reporte de flujo de caja"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProduccionPictureBox
        '
        Me.ProduccionPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProduccionPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ProduccionPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources.EntradaSalidaProduccionInactivo
        Me.ProduccionPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ProduccionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ProduccionPictureBox.Location = New System.Drawing.Point(171, 16)
        Me.ProduccionPictureBox.Name = "ProduccionPictureBox"
        Me.ProduccionPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.ProduccionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ProduccionPictureBox.TabIndex = 4
        Me.ProduccionPictureBox.TabStop = False
        Me.ProduccionPictureBox.Visible = False
        '
        'FraccionamientoPictureBox
        '
        Me.FraccionamientoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FraccionamientoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.FraccionamientoPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources.EntradaSalidaFraccionamientoInactivo
        Me.FraccionamientoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FraccionamientoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FraccionamientoPictureBox.Location = New System.Drawing.Point(323, 16)
        Me.FraccionamientoPictureBox.Name = "FraccionamientoPictureBox"
        Me.FraccionamientoPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.FraccionamientoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.FraccionamientoPictureBox.TabIndex = 5
        Me.FraccionamientoPictureBox.TabStop = False
        Me.FraccionamientoPictureBox.Visible = False
        '
        'pbxEtiquetas
        '
        Me.pbxEtiquetas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxEtiquetas.BackColor = System.Drawing.Color.Transparent
        Me.pbxEtiquetas.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SalidaCajasyEtiquetasInactivo
        Me.pbxEtiquetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEtiquetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEtiquetas.Location = New System.Drawing.Point(19, 142)
        Me.pbxEtiquetas.Name = "pbxEtiquetas"
        Me.pbxEtiquetas.Size = New System.Drawing.Size(146, 125)
        Me.pbxEtiquetas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxEtiquetas.TabIndex = 7
        Me.pbxEtiquetas.TabStop = False
        Me.pbxEtiquetas.Visible = False
        '
        'ConsumoInternoPictureBox
        '
        Me.ConsumoInternoPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ConsumoInternoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ConsumoInternoPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources.ConsumoInternoInactivo
        Me.ConsumoInternoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ConsumoInternoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ConsumoInternoPictureBox.Location = New System.Drawing.Point(19, 16)
        Me.ConsumoInternoPictureBox.Name = "ConsumoInternoPictureBox"
        Me.ConsumoInternoPictureBox.Size = New System.Drawing.Size(146, 125)
        Me.ConsumoInternoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ConsumoInternoPictureBox.TabIndex = 8
        Me.ConsumoInternoPictureBox.TabStop = False
        Me.ConsumoInternoPictureBox.Visible = False
        '
        'pbxCombos
        '
        Me.pbxCombos.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxCombos.BackColor = System.Drawing.Color.Transparent
        Me.pbxCombos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.EntradaSalidaCombosInactivo
        Me.pbxCombos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCombos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxCombos.Location = New System.Drawing.Point(171, 142)
        Me.pbxCombos.Name = "pbxCombos"
        Me.pbxCombos.Size = New System.Drawing.Size(146, 125)
        Me.pbxCombos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCombos.TabIndex = 62
        Me.pbxCombos.TabStop = False
        Me.pbxCombos.Visible = False
        '
        'PictureBoxReporteProduccion
        '
        Me.PictureBoxReporteProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxReporteProduccion.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxReporteProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PictureBoxReporteProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxReporteProduccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxReporteProduccion.Location = New System.Drawing.Point(623, 16)
        Me.PictureBoxReporteProduccion.Name = "PictureBoxReporteProduccion"
        Me.PictureBoxReporteProduccion.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxReporteProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxReporteProduccion.TabIndex = 63
        Me.PictureBoxReporteProduccion.TabStop = False
        '
        'pbxAjustes
        '
        Me.pbxAjustes.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxAjustes.BackColor = System.Drawing.Color.Transparent
        Me.pbxAjustes.BackgroundImage = Global.ContaExpress.My.Resources.Resources.AjustedeProduccionInactivo
        Me.pbxAjustes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxAjustes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAjustes.Location = New System.Drawing.Point(323, 142)
        Me.pbxAjustes.Name = "pbxAjustes"
        Me.pbxAjustes.Size = New System.Drawing.Size(146, 125)
        Me.pbxAjustes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAjustes.TabIndex = 64
        Me.pbxAjustes.TabStop = False
        Me.pbxAjustes.Visible = False
        '
        'ProduccionPanelMenu
        '
        Me.ProduccionPanelMenu.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProduccionPanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ProduccionPanelMenu.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.ProduccionPanelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxPlanilladeProduccion)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxEtiquetasProduccion)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxPlanillaProduccion)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxRecetas)
        Me.ProduccionPanelMenu.Controls.Add(Me.PictureBoxOrdenProduccion)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxAjustes)
        Me.ProduccionPanelMenu.Controls.Add(Me.PictureBoxReporteProduccion)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxCombos)
        Me.ProduccionPanelMenu.Controls.Add(Me.ConsumoInternoPictureBox)
        Me.ProduccionPanelMenu.Controls.Add(Me.pbxEtiquetas)
        Me.ProduccionPanelMenu.Controls.Add(Me.FraccionamientoPictureBox)
        Me.ProduccionPanelMenu.Controls.Add(Me.ProduccionPictureBox)
        Me.ProduccionPanelMenu.Location = New System.Drawing.Point(225, 204)
        Me.ProduccionPanelMenu.Name = "ProduccionPanelMenu"
        Me.ProduccionPanelMenu.Size = New System.Drawing.Size(783, 281)
        Me.ProduccionPanelMenu.TabIndex = 42
        '
        'pbxPlanilladeProduccion
        '
        Me.pbxPlanilladeProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxPlanilladeProduccion.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlanilladeProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Planilla_Produccoin_Inactivo
        Me.pbxPlanilladeProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxPlanilladeProduccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxPlanilladeProduccion.Location = New System.Drawing.Point(473, 16)
        Me.pbxPlanilladeProduccion.Name = "pbxPlanilladeProduccion"
        Me.pbxPlanilladeProduccion.Size = New System.Drawing.Size(146, 125)
        Me.pbxPlanilladeProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxPlanilladeProduccion.TabIndex = 69
        Me.pbxPlanilladeProduccion.TabStop = False
        '
        'pbxEtiquetasProduccion
        '
        Me.pbxEtiquetasProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxEtiquetasProduccion.BackColor = System.Drawing.Color.Transparent
        Me.pbxEtiquetasProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.etiquetas
        Me.pbxEtiquetasProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEtiquetasProduccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEtiquetasProduccion.Location = New System.Drawing.Point(19, 142)
        Me.pbxEtiquetasProduccion.Name = "pbxEtiquetasProduccion"
        Me.pbxEtiquetasProduccion.Size = New System.Drawing.Size(146, 125)
        Me.pbxEtiquetasProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxEtiquetasProduccion.TabIndex = 68
        Me.pbxEtiquetasProduccion.TabStop = False
        '
        'pbxPlanillaProduccion
        '
        Me.pbxPlanillaProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxPlanillaProduccion.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlanillaProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.OrdenProduccion2
        Me.pbxPlanillaProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxPlanillaProduccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxPlanillaProduccion.Location = New System.Drawing.Point(323, 16)
        Me.pbxPlanillaProduccion.Name = "pbxPlanillaProduccion"
        Me.pbxPlanillaProduccion.Size = New System.Drawing.Size(146, 125)
        Me.pbxPlanillaProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxPlanillaProduccion.TabIndex = 67
        Me.pbxPlanillaProduccion.TabStop = False
        '
        'pbxRecetas
        '
        Me.pbxRecetas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.pbxRecetas.BackColor = System.Drawing.Color.Transparent
        Me.pbxRecetas.BackgroundImage = Global.ContaExpress.My.Resources.Resources.RecetasInactivo
        Me.pbxRecetas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxRecetas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxRecetas.Location = New System.Drawing.Point(19, 16)
        Me.pbxRecetas.Name = "pbxRecetas"
        Me.pbxRecetas.Size = New System.Drawing.Size(146, 125)
        Me.pbxRecetas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxRecetas.TabIndex = 66
        Me.pbxRecetas.TabStop = False
        '
        'PictureBoxOrdenProduccion
        '
        Me.PictureBoxOrdenProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBoxOrdenProduccion.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxOrdenProduccion.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnPedidoClienteInactivo
        Me.PictureBoxOrdenProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxOrdenProduccion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxOrdenProduccion.Location = New System.Drawing.Point(171, 16)
        Me.PictureBoxOrdenProduccion.Name = "PictureBoxOrdenProduccion"
        Me.PictureBoxOrdenProduccion.Size = New System.Drawing.Size(146, 125)
        Me.PictureBoxOrdenProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxOrdenProduccion.TabIndex = 65
        Me.PictureBoxOrdenProduccion.TabStop = False
        '
        'ProyectosCentral
        '
        Me.ProyectosCentral.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ProyectosCentral.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ProyectosCentral.BackgroundImage = Global.ContaExpress.My.Resources.Resources.pnlDashboard
        Me.ProyectosCentral.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ProyectosCentral.Controls.Add(Me.PictureBox1)
        Me.ProyectosCentral.Controls.Add(Me.pbxEventos)
        Me.ProyectosCentral.Location = New System.Drawing.Point(225, 204)
        Me.ProyectosCentral.Name = "ProyectosCentral"
        Me.ProyectosCentral.Size = New System.Drawing.Size(783, 281)
        Me.ProyectosCentral.TabIndex = 472
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.reportes
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(625, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(146, 125)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 63
        Me.PictureBox1.TabStop = False
        '
        'pbxEventos
        '
        Me.pbxEventos.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pbxEventos.BackColor = System.Drawing.Color.Transparent
        Me.pbxEventos.BackgroundImage = Global.ContaExpress.My.Resources.Resources.btnProyectosInactivo
        Me.pbxEventos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEventos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEventos.Location = New System.Drawing.Point(14, 13)
        Me.pbxEventos.Name = "pbxEventos"
        Me.pbxEventos.Size = New System.Drawing.Size(146, 125)
        Me.pbxEventos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxEventos.TabIndex = 39
        Me.pbxEventos.TabStop = False
        '
        'Dashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.Color.Silver
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1188, 696)
        Me.Controls.Add(Me.ProyectosCentral)
        Me.Controls.Add(Me.PanelUsuarios)
        Me.Controls.Add(Me.pnlCambioSucursal)
        Me.Controls.Add(Me.PanelVentas)
        Me.Controls.Add(Me.MarketingPanel)
        Me.Controls.Add(Me.InventarioPanel)
        Me.Controls.Add(Me.AreaPanel)
        Me.Controls.Add(Me.ProduccionPanelMenu)
        Me.Controls.Add(Me.PanelContabilidad)
        Me.Controls.Add(Me.Background)
        Me.Controls.Add(Me.PanelBancos)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DimGray
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "Dashboard"
        Me.Text = "Dashboard - Cogent SIG"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsDashboard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.InventarioPanel.ResumeLayout(False)
        CType(Me.pbxCombosKit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTranferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxUtilidadesStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAjusteStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxProductoI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InventPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCombo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUsuarios.ResumeLayout(False)
        CType(Me.btnReporteAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContabilidad.ResumeLayout(False)
        CType(Me.btnUtilidadesContabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxAsientosCostos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxPlanillaContable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxRegistrarAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxReporteContabilidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxLibroVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxLibroCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxPeriodoFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxPlanCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVentas.ResumeLayout(False)
        CType(Me.btnUtilVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPagares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxEnviomercaderia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCobros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxDevoluciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxReporteVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxFacturacionSimple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxFacturacionPlus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AreaPanel.ResumeLayout(False)
        CType(Me.btnCheques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNotaDebito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxUtilidades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDevolucionCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PbxProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PctBoxConfirmaPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxReporteCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCompras, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MarketingPanel.ResumeLayout(False)
        CType(Me.ClientesMktPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmailingPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCambioSucursal.ResumeLayout(False)
        Me.pnlCambioSucursal.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCajaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Background.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBancos.ResumeLayout(False)
        CType(Me.btnMovBancario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnFlujodeCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProduccionPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FraccionamientoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEtiquetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConsumoInternoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCombos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxReporteProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAjustes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProduccionPanelMenu.ResumeLayout(False)
        CType(Me.pbxPlanilladeProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEtiquetasProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPlanillaProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxRecetas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxOrdenProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProyectosCentral.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEventos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelContabilidad As System.Windows.Forms.Panel
    Friend WithEvents PbxPeriodoFiscal As System.Windows.Forms.PictureBox
    Friend WithEvents PanelContabalidadAbajo As System.Windows.Forms.Panel
    Friend WithEvents PbxPlanCuenta As System.Windows.Forms.PictureBox
    Friend WithEvents PbxLibroCompra As System.Windows.Forms.PictureBox
    Friend WithEvents PbxLibroVenta As System.Windows.Forms.PictureBox
    Friend WithEvents PbxReporteContabilidad As System.Windows.Forms.PictureBox
    Friend WithEvents PbxRegistrarAsientos As System.Windows.Forms.PictureBox
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsDashboardTableAdapters.SUCURSALTableAdapter
    Friend WithEvents CmbMaquina1 As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents PCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DETPCTableAdapter As ContaExpress.DsDashboardTableAdapters.DETPCTableAdapter
    Friend WithEvents CmbSucursal As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents CmbCiudad As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents Cmb_Sucursal1 As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents bt_ayuda As System.Windows.Forms.Panel
    Friend WithEvents RadPanelCompras As System.Windows.Forms.Panel
    Friend WithEvents PanelLink As System.Windows.Forms.Panel
    Friend WithEvents Cmb_Maquina As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_Sucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents pnlCambioSucursal As System.Windows.Forms.Panel
    Friend WithEvents CmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents DsCajaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCaja As ContaExpress.DsCaja
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsCajaTableAdapters.CAJATableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCambiarSucursal As Telerik.WinControls.UI.RadButton
    Friend WithEvents PbxPlanillaContable As System.Windows.Forms.PictureBox
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents btnCerrarCambioSuc As System.Windows.Forms.Button
    Friend WithEvents pbxCodigos As System.Windows.Forms.PictureBox
    Friend WithEvents VerificarModulosActivos As System.Windows.Forms.Timer
    Friend WithEvents UltimaCompraDiasTableAdapter1 As ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter
    Friend WithEvents pbxDevolucionCompras As System.Windows.Forms.PictureBox
    Friend WithEvents ClientesMktPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents Background As System.Windows.Forms.Panel
    Friend WithEvents pbxSucursal As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PbxAsientosCostos As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAjusteStock As System.Windows.Forms.PictureBox
    Friend WithEvents btnReporteAuditoria As System.Windows.Forms.PictureBox
    Friend WithEvents pbxUtilidades As System.Windows.Forms.PictureBox
    Friend WithEvents pbxUtilidadesStock As System.Windows.Forms.PictureBox
    Friend WithEvents pbxTranferencias As System.Windows.Forms.PictureBox
    Friend WithEvents btnUtilidadesContabilidad As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxEnviomercaderia As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNotaDebito As System.Windows.Forms.PictureBox
    Friend WithEvents PanelBancosAbajo As System.Windows.Forms.Panel
    Friend WithEvents PanelBancos As System.Windows.Forms.Panel
    Friend WithEvents btnFlujodeCaja As System.Windows.Forms.PictureBox
    Friend WithEvents btnMovBancario As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pbxCombosKit As System.Windows.Forms.PictureBox
    Friend WithEvents btnPagares As System.Windows.Forms.PictureBox
    Friend WithEvents PanelProyectos As System.Windows.Forms.Panel
    Friend WithEvents ProduccionPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents FraccionamientoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEtiquetas As System.Windows.Forms.PictureBox
    Friend WithEvents ConsumoInternoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbxCombos As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxReporteProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAjustes As System.Windows.Forms.PictureBox
    Friend WithEvents ProduccionPanelMenu As System.Windows.Forms.Panel
    Friend WithEvents pbxEtiquetasProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents pbxPlanillaProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents pbxRecetas As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxOrdenProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents ProyectosCentral As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEventos As System.Windows.Forms.PictureBox
    Friend WithEvents btnUtilVentas As System.Windows.Forms.PictureBox
    Friend WithEvents btnCheques As System.Windows.Forms.PictureBox
    Friend WithEvents pbxPlanilladeProduccion As System.Windows.Forms.PictureBox

#End Region 'Methods

End Class