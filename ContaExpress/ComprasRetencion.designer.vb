<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprasRetencion
    Inherits System.Windows.Forms.Form

#Region "Fields"

    'Friend WithEvents CantidadComTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents CantidadComTextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents CodCodigoCTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents CodCompraTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents CodMonedaComTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ComprasSimpleGridView As Telerik.WinControls.UI.RadGridView
    'Friend WithEvents CostoComTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents CostoComTextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents DetalleCompra1GridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents EstadoTextBox As System.Windows.Forms.TextBox
    'Friend WithEvents Iva10TextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents Iva10TextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents Iva5TextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents Iva5TextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents MateriaPrimaGridView1 As Telerik.WinControls.UI.RadGridView
    'Friend WithEvents NroFacturaMaskedEditBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents NroFacturaMaskedEditBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents PorcentajeIvaCompraMaskedEdit As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents ProdGridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents RadGroupBoxProveedor As Telerik.WinControls.UI.RadGroupBox
    ' Friend WithEvents TIPOPAGOTableAdapter As ContaExpress.DsPagosTableAdapters.TIPOPAGOTableAdapter
    'Friend WithEvents TotalExentaTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents TotalExentaTextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents TotalGravTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents TotalGravTextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents TotalTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    'Friend WithEvents TotalTextBox1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents TxtBuscaProveedor As System.Windows.Forms.TextBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents UltraPopupControlContainer2 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents UltraPopupControlContainer3 As Infragistics.Win.Misc.UltraPopupControlContainer

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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn8 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn9 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn10 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn11 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn12 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn13 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn14 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn15 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn16 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprasRetencion))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ComprasSimpleGridView = New Telerik.WinControls.UI.RadGridView()
        Me.MateriaPrimaGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBoxProveedor = New Telerik.WinControls.UI.RadGroupBox()
        Me.dgvProveedor = New System.Windows.Forms.DataGridView()
        Me.CODMONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCATEGORIAPROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCENTROPROV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtBuscaProveedor = New System.Windows.Forms.TextBox()
        Me.ProductosTabItem = New Telerik.WinControls.UI.TabItem()
        Me.ProdGridView = New Telerik.WinControls.UI.RadGridView()
        Me.CodMonedaComTextBox = New System.Windows.Forms.TextBox()
        Me.CodCompraTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.EstadoTextBox = New System.Windows.Forms.TextBox()
        Me.DetalleCompra1GridView = New Telerik.WinControls.UI.RadGridView()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPorcRetIVA = New System.Windows.Forms.Label()
        Me.EMPRESABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsRetencionCompra = New ContaExpress.DsRetencionCompra()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblPorcRetRENTA = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblRetIVA = New System.Windows.Forms.Label()
        Me.lblRetRENTA = New System.Windows.Forms.Label()
        Me.lblTotalRetencion = New System.Windows.Forms.Label()
        Me.RETENCIONCOMPRABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxTotalSinIva = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxTotalIva = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxTotalTransaccion = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.PanelBotonera = New System.Windows.Forms.Panel()
        Me.ImprimirRetRentaPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarRetencionTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBoxMotivoAnulacion = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.ModalidadPagoFacturaTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.ComprasSimpleGridView1 = New System.Windows.Forms.DataGridView()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMRETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODRETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHARETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTERETIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTALRETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPORETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODRANGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.PbxProveedor = New Telerik.WinControls.UI.RadButton()
        Me.IvaIncluidoComboBox = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pbxBuscarProveedor = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TipoCompComboBox = New System.Windows.Forms.ComboBox()
        Me.RETCOMPTIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.FechaFactTextBox = New System.Windows.Forms.DateTimePicker()
        Me.ProvFactComboBox = New System.Windows.Forms.ComboBox()
        Me.RETCOMPPROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbxDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxMetodo = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PanelAnular = New System.Windows.Forms.Panel()
        Me.TextBoxAnulacionConcepto = New System.Windows.Forms.RichTextBox()
        Me.BtnCerrarAnular = New Telerik.WinControls.UI.RadButton()
        Me.BtnAnular = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.tbxCodCompras = New System.Windows.Forms.TextBox()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblComprasEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.PORCENTAJEIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIVA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lblDGVCant = New System.Windows.Forms.Label()
        Me.CmbAño = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem13 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem14 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem15 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem16 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem17 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem18 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem19 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem20 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem21 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem22 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem23 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.CmbMes = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem3 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem4 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem5 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem6 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem7 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem8 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem9 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem10 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem11 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem12 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.BtnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.tbxNroRetencion = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.tsRetencionCompra = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsNuevaRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAdministrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsQuemarProximo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsModificarNroRetencion = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReImprimirAutoF = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltrar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFechaEspecifica = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltroFechaE = New System.Windows.Forms.ToolStripTextBox()
        Me.tsRangoDeFechas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltroRDesde = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltroRHasta = New System.Windows.Forms.ToolStripTextBox()
        Me.tsPorProveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.PorNroClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltroNroProv = New System.Windows.Forms.ToolStripTextBox()
        Me.PorNombreClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsFiltroNomProv = New System.Windows.Forms.ToolStripTextBox()
        Me.tsAplicarFiltros = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsLimpiarFiltros = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsVentanaDePagos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsReportarProblemas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAyudaOnline = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.lblProximoNro = New Telerik.WinControls.UI.RadLabel()
        Me.RETENCIONCOMPRATableAdapter = New ContaExpress.DsRetencionCompraTableAdapters.RETENCIONCOMPRATableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsRetencionCompraTableAdapters.TableAdapterManager()
        Me.RETCOMPTIPOCOMPROBANTETableAdapter = New ContaExpress.DsRetencionCompraTableAdapters.RETCOMPTIPOCOMPROBANTETableAdapter()
        Me.RETCOMPPROVEEDORTableAdapter = New ContaExpress.DsRetencionCompraTableAdapters.RETCOMPPROVEEDORTableAdapter()
        Me.EMPRESATableAdapter = New ContaExpress.DsRetencionCompraTableAdapters.EMPRESATableAdapter()
        Me.LblEstado = New Telerik.WinControls.UI.RadLabel()
        CType(Me.ComprasSimpleGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasSimpleGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MateriaPrimaGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MateriaPrimaGridView1.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBoxProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBoxProveedor.SuspendLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProdGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodCompraTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetalleCompra1GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DetalleCompra1GridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRetencionCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RETENCIONCOMPRABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBotonera.SuspendLayout()
        CType(Me.ImprimirRetRentaPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxMotivoAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModalidadPagoFacturaTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasSimpleGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PbxProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBuscarProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RETCOMPTIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RETCOMPPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.PanelAnular.SuspendLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAnular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.lblProximoNro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComprasSimpleGridView
        '
        Me.ComprasSimpleGridView.BackColor = System.Drawing.Color.White
        Me.ComprasSimpleGridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComprasSimpleGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ComprasSimpleGridView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ComprasSimpleGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ComprasSimpleGridView.Location = New System.Drawing.Point(6, 173)
        '
        '
        '
        Me.ComprasSimpleGridView.MasterGridViewTemplate.AllowAddNewRow = False
        Me.ComprasSimpleGridView.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.FieldAlias = "PROVEEDOR"
        GridViewTextBoxColumn1.FieldName = "PROVEEDOR"
        GridViewTextBoxColumn1.HeaderText = "Proveedor"
        GridViewTextBoxColumn1.UniqueName = "PROVEEDOR"
        GridViewTextBoxColumn1.Width = 200
        Me.ComprasSimpleGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.ComprasSimpleGridView.MasterGridViewTemplate.EnableFiltering = True
        Me.ComprasSimpleGridView.MasterGridViewTemplate.EnableGrouping = False
        Me.ComprasSimpleGridView.MasterGridViewTemplate.EnableSorting = False
        Me.ComprasSimpleGridView.MasterGridViewTemplate.ShowFilteringRow = False
        Me.ComprasSimpleGridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.ComprasSimpleGridView.Name = "ComprasSimpleGridView"
        Me.ComprasSimpleGridView.ReadOnly = True
        Me.ComprasSimpleGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComprasSimpleGridView.ShowGroupPanel = False
        Me.ComprasSimpleGridView.Size = New System.Drawing.Size(205, 379)
        Me.ComprasSimpleGridView.TabIndex = 2
        Me.ComprasSimpleGridView.ThemeName = "Aqua"
        '
        'MateriaPrimaGridView1
        '
        Me.MateriaPrimaGridView1.BackColor = System.Drawing.Color.White
        Me.MateriaPrimaGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.MateriaPrimaGridView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.MateriaPrimaGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MateriaPrimaGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MateriaPrimaGridView1.Location = New System.Drawing.Point(8, 49)
        '
        '
        '
        Me.MateriaPrimaGridView1.MasterGridViewTemplate.AllowAddNewRow = False
        Me.MateriaPrimaGridView1.MasterGridViewTemplate.EnableFiltering = True
        Me.MateriaPrimaGridView1.MasterGridViewTemplate.EnableGrouping = False
        Me.MateriaPrimaGridView1.MasterGridViewTemplate.ShowFilteringRow = False
        Me.MateriaPrimaGridView1.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.MateriaPrimaGridView1.Name = "MateriaPrimaGridView1"
        Me.MateriaPrimaGridView1.ReadOnly = True
        Me.MateriaPrimaGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MateriaPrimaGridView1.ShowGroupPanel = False
        Me.MateriaPrimaGridView1.Size = New System.Drawing.Size(432, 419)
        Me.MateriaPrimaGridView1.TabIndex = 183
        '
        'RadGroupBoxProveedor
        '
        Me.RadGroupBoxProveedor.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBoxProveedor.Controls.Add(Me.dgvProveedor)
        Me.RadGroupBoxProveedor.Controls.Add(Me.TxtBuscaProveedor)
        Me.RadGroupBoxProveedor.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBoxProveedor.FooterImageIndex = -1
        Me.RadGroupBoxProveedor.FooterImageKey = ""
        Me.RadGroupBoxProveedor.ForeColor = System.Drawing.Color.Black
        Me.RadGroupBoxProveedor.HeaderImageIndex = -1
        Me.RadGroupBoxProveedor.HeaderImageKey = ""
        Me.RadGroupBoxProveedor.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBoxProveedor.HeaderText = "Buscador: Proveedores"
        Me.RadGroupBoxProveedor.Location = New System.Drawing.Point(250, 37)
        Me.RadGroupBoxProveedor.Name = "RadGroupBoxProveedor"
        Me.RadGroupBoxProveedor.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBoxProveedor.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadGroupBoxProveedor.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBoxProveedor.Size = New System.Drawing.Size(404, 474)
        Me.RadGroupBoxProveedor.TabIndex = 232
        Me.RadGroupBoxProveedor.Text = "Buscador: Proveedores"
        Me.RadGroupBoxProveedor.ThemeName = "Breeze"
        Me.RadGroupBoxProveedor.Visible = False
        CType(Me.RadGroupBoxProveedor.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.DimGray
        '
        'dgvProveedor
        '
        Me.dgvProveedor.AllowUserToAddRows = False
        Me.dgvProveedor.AllowUserToDeleteRows = False
        Me.dgvProveedor.AllowUserToResizeColumns = False
        Me.dgvProveedor.AllowUserToResizeRows = False
        Me.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProveedor.BackgroundColor = System.Drawing.Color.White
        Me.dgvProveedor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.dgvProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODMONEDA, Me.CODCATEGORIAPROVEEDOR, Me.CODCENTROPROV})
        Me.dgvProveedor.EnableHeadersVisualStyles = False
        Me.dgvProveedor.Location = New System.Drawing.Point(12, 57)
        Me.dgvProveedor.Name = "dgvProveedor"
        Me.dgvProveedor.ReadOnly = True
        Me.dgvProveedor.RowHeadersVisible = False
        Me.dgvProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProveedor.Size = New System.Drawing.Size(379, 408)
        Me.dgvProveedor.TabIndex = 236
        '
        'CODMONEDA
        '
        Me.CODMONEDA.DataPropertyName = "CODMONEDA"
        Me.CODMONEDA.HeaderText = "CODMONEDA"
        Me.CODMONEDA.Name = "CODMONEDA"
        Me.CODMONEDA.ReadOnly = True
        Me.CODMONEDA.Visible = False
        '
        'CODCATEGORIAPROVEEDOR
        '
        Me.CODCATEGORIAPROVEEDOR.DataPropertyName = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.HeaderText = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.Name = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.ReadOnly = True
        Me.CODCATEGORIAPROVEEDOR.Visible = False
        '
        'CODCENTROPROV
        '
        Me.CODCENTROPROV.DataPropertyName = "CODCENTRO"
        Me.CODCENTROPROV.HeaderText = "CODCENTRO"
        Me.CODCENTROPROV.Name = "CODCENTROPROV"
        Me.CODCENTROPROV.ReadOnly = True
        Me.CODCENTROPROV.Visible = False
        '
        'TxtBuscaProveedor
        '
        Me.TxtBuscaProveedor.BackColor = System.Drawing.Color.Silver
        Me.TxtBuscaProveedor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuscaProveedor.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.TxtBuscaProveedor.Location = New System.Drawing.Point(13, 26)
        Me.TxtBuscaProveedor.Name = "TxtBuscaProveedor"
        Me.TxtBuscaProveedor.Size = New System.Drawing.Size(372, 25)
        Me.TxtBuscaProveedor.TabIndex = 234
        Me.TxtBuscaProveedor.Text = "Buscar..."
        '
        'ProductosTabItem
        '
        Me.ProductosTabItem.Alignment = System.Drawing.ContentAlignment.BottomLeft
        '
        'ProductosTabItem.ContentPanel
        '
        Me.ProductosTabItem.ContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ProductosTabItem.ContentPanel.CausesValidation = True
        Me.ProductosTabItem.ContentPanel.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ProductosTabItem.ContentPanel.ForeColor = System.Drawing.Color.Black
        Me.ProductosTabItem.ContentPanel.Location = New System.Drawing.Point(1, 35)
        Me.ProductosTabItem.ContentPanel.Size = New System.Drawing.Size(518, 452)
        Me.ProductosTabItem.IsSelected = True
        Me.ProductosTabItem.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.ProductosTabItem.Name = "ProductosTabItem"
        Me.ProductosTabItem.StretchHorizontally = False
        Me.ProductosTabItem.Text = "Productos"
        '
        'ProdGridView
        '
        Me.ProdGridView.BackColor = System.Drawing.Color.White
        Me.ProdGridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.ProdGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ProdGridView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProdGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ProdGridView.Location = New System.Drawing.Point(9, 37)
        '
        '
        '
        Me.ProdGridView.MasterGridViewTemplate.AllowAddNewRow = False
        Me.ProdGridView.MasterGridViewTemplate.EnableGrouping = False
        Me.ProdGridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.ProdGridView.Name = "ProdGridView"
        Me.ProdGridView.ReadOnly = True
        Me.ProdGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ProdGridView.ShowGroupPanel = False
        Me.ProdGridView.Size = New System.Drawing.Size(473, 375)
        Me.ProdGridView.TabIndex = 1
        '
        'CodMonedaComTextBox
        '
        Me.CodMonedaComTextBox.Location = New System.Drawing.Point(150, 626)
        Me.CodMonedaComTextBox.Name = "CodMonedaComTextBox"
        Me.CodMonedaComTextBox.Size = New System.Drawing.Size(23, 20)
        Me.CodMonedaComTextBox.TabIndex = 211
        '
        'CodCompraTextBox
        '
        Me.CodCompraTextBox.CausesValidation = False
        Me.CodCompraTextBox.Location = New System.Drawing.Point(108, 624)
        Me.CodCompraTextBox.Name = "CodCompraTextBox"
        Me.CodCompraTextBox.ReadOnly = True
        Me.CodCompraTextBox.Size = New System.Drawing.Size(36, 20)
        Me.CodCompraTextBox.TabIndex = 205
        Me.CodCompraTextBox.TabStop = False
        '
        'EstadoTextBox
        '
        Me.EstadoTextBox.CausesValidation = False
        Me.EstadoTextBox.Location = New System.Drawing.Point(179, 624)
        Me.EstadoTextBox.Name = "EstadoTextBox"
        Me.EstadoTextBox.ReadOnly = True
        Me.EstadoTextBox.Size = New System.Drawing.Size(23, 20)
        Me.EstadoTextBox.TabIndex = 207
        '
        'DetalleCompra1GridView
        '
        Me.DetalleCompra1GridView.AllowDrop = True
        Me.DetalleCompra1GridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DetalleCompra1GridView.BackColor = System.Drawing.Color.White
        Me.DetalleCompra1GridView.CausesValidation = False
        Me.DetalleCompra1GridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.DetalleCompra1GridView.EnableCustomDrawing = True
        Me.DetalleCompra1GridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DetalleCompra1GridView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DetalleCompra1GridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DetalleCompra1GridView.Location = New System.Drawing.Point(4, 85)
        '
        '
        '
        Me.DetalleCompra1GridView.MasterGridViewTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn2.FieldAlias = "CentroCosto"
        GridViewTextBoxColumn2.HeaderText = "Centro de costo"
        GridViewTextBoxColumn2.UniqueName = "CentroCosto"
        GridViewTextBoxColumn2.Width = 165
        GridViewTextBoxColumn3.FieldAlias = "DESPRODUCTO"
        GridViewTextBoxColumn3.FieldName = "DESPRODUCTO"
        GridViewTextBoxColumn3.HeaderText = "Producto"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.UniqueName = "DESPRODUCTO"
        GridViewTextBoxColumn3.Width = 150
        GridViewTextBoxColumn4.FieldAlias = "CANTIDAD2"
        GridViewTextBoxColumn4.HeaderText = "Cantidad"
        GridViewTextBoxColumn4.UniqueName = "CANTIDAD2"
        GridViewTextBoxColumn4.Width = 75
        GridViewTextBoxColumn5.FieldAlias = "Costo2"
        GridViewTextBoxColumn5.HeaderText = "Costo"
        GridViewTextBoxColumn5.UniqueName = "Costo2"
        GridViewTextBoxColumn5.Width = 80
        GridViewTextBoxColumn6.FieldAlias = "Iva5"
        GridViewTextBoxColumn6.HeaderText = "5%"
        GridViewTextBoxColumn6.UniqueName = "Iva5"
        GridViewTextBoxColumn6.Width = 75
        GridViewTextBoxColumn7.FieldAlias = "Iva10"
        GridViewTextBoxColumn7.HeaderText = "10%"
        GridViewTextBoxColumn7.UniqueName = "Iva10"
        GridViewTextBoxColumn7.Width = 75
        GridViewTextBoxColumn8.FieldAlias = "Subtotal"
        GridViewTextBoxColumn8.HeaderText = "Subtotal"
        GridViewTextBoxColumn8.UniqueName = "Subtotal"
        GridViewTextBoxColumn8.Width = 90
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODCOMPRA"
        GridViewDecimalColumn1.FieldName = "CODCOMPRA"
        GridViewDecimalColumn1.HeaderText = "CODCOMPRA"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODCOMPRA"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "LINEANROCOMPRA"
        GridViewDecimalColumn2.FieldName = "LINEANROCOMPRA"
        GridViewDecimalColumn2.HeaderText = "LINEANROCOMPRA"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "LINEANROCOMPRA"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODPRODUCTO"
        GridViewDecimalColumn3.FieldName = "CODPRODUCTO"
        GridViewDecimalColumn3.HeaderText = "CODPRODUCTO"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODPRODUCTO"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODCODIGO"
        GridViewDecimalColumn4.FieldName = "CODCODIGO"
        GridViewDecimalColumn4.HeaderText = "CODCODIGO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODCODIGO"
        GridViewDecimalColumn5.DataType = GetType(Decimal)
        GridViewDecimalColumn5.FieldAlias = "CANTIDADCOMPRA"
        GridViewDecimalColumn5.FieldName = "CANTIDADCOMPRA"
        GridViewDecimalColumn5.HeaderText = "CANTIDADCOMPRA"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "CANTIDADCOMPRA"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldAlias = "COSTOPROMEDIO"
        GridViewDecimalColumn6.FieldName = "COSTOPROMEDIO"
        GridViewDecimalColumn6.HeaderText = "COSTOPROMEDIO"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "COSTOPROMEDIO"
        GridViewDecimalColumn7.DataType = GetType(Decimal)
        GridViewDecimalColumn7.FieldAlias = "COSTOUNITARIO"
        GridViewDecimalColumn7.FieldName = "COSTOUNITARIO"
        GridViewDecimalColumn7.HeaderText = "COSTOUNITARIO"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.UniqueName = "COSTOUNITARIO"
        GridViewDecimalColumn8.DataType = GetType(Decimal)
        GridViewDecimalColumn8.FieldAlias = "IVA"
        GridViewDecimalColumn8.FieldName = "IVA"
        GridViewDecimalColumn8.HeaderText = "IVA"
        GridViewDecimalColumn8.IsAutoGenerated = True
        GridViewDecimalColumn8.IsVisible = False
        GridViewDecimalColumn8.UniqueName = "IVA"
        GridViewDecimalColumn9.DataType = GetType(Decimal)
        GridViewDecimalColumn9.FieldAlias = "FACTORPROMEDIO"
        GridViewDecimalColumn9.FieldName = "FACTORPROMEDIO"
        GridViewDecimalColumn9.HeaderText = "FACTORPROMEDIO"
        GridViewDecimalColumn9.IsAutoGenerated = True
        GridViewDecimalColumn9.IsVisible = False
        GridViewDecimalColumn9.UniqueName = "FACTORPROMEDIO"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        GridViewDecimalColumn10.DataType = GetType(Decimal)
        GridViewDecimalColumn10.FieldAlias = "COSTOBRUTO"
        GridViewDecimalColumn10.FieldName = "COSTOBRUTO"
        GridViewDecimalColumn10.HeaderText = "COSTOBRUTO"
        GridViewDecimalColumn10.IsAutoGenerated = True
        GridViewDecimalColumn10.IsVisible = False
        GridViewDecimalColumn10.UniqueName = "COSTOBRUTO"
        GridViewTextBoxColumn9.FieldAlias = "ORDENFABRICACION"
        GridViewTextBoxColumn9.FieldName = "ORDENFABRICACION"
        GridViewTextBoxColumn9.HeaderText = "ORDENFABRICACION"
        GridViewTextBoxColumn9.IsAutoGenerated = True
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.UniqueName = "ORDENFABRICACION"
        GridViewDecimalColumn11.DataType = GetType(Decimal)
        GridViewDecimalColumn11.FieldAlias = "COSTOPROMEDIOMAESTRO"
        GridViewDecimalColumn11.FieldName = "COSTOPROMEDIOMAESTRO"
        GridViewDecimalColumn11.HeaderText = "COSTOPROMEDIOMAESTRO"
        GridViewDecimalColumn11.IsAutoGenerated = True
        GridViewDecimalColumn11.IsVisible = False
        GridViewDecimalColumn11.UniqueName = "COSTOPROMEDIOMAESTRO"
        GridViewDecimalColumn12.DataType = GetType(Decimal)
        GridViewDecimalColumn12.FieldAlias = "COSTOPPMAESTRO"
        GridViewDecimalColumn12.FieldName = "COSTOPPMAESTRO"
        GridViewDecimalColumn12.HeaderText = "COSTOPPMAESTRO"
        GridViewDecimalColumn12.IsAutoGenerated = True
        GridViewDecimalColumn12.IsVisible = False
        GridViewDecimalColumn12.UniqueName = "COSTOPPMAESTRO"
        GridViewDecimalColumn13.DataType = GetType(Decimal)
        GridViewDecimalColumn13.FieldAlias = "PRECIOMAY"
        GridViewDecimalColumn13.FieldName = "PRECIOMAY"
        GridViewDecimalColumn13.HeaderText = "PRECIOMAY"
        GridViewDecimalColumn13.IsAutoGenerated = True
        GridViewDecimalColumn13.IsVisible = False
        GridViewDecimalColumn13.UniqueName = "PRECIOMAY"
        GridViewDecimalColumn14.DataType = GetType(Decimal)
        GridViewDecimalColumn14.FieldAlias = "PRECIOMIN"
        GridViewDecimalColumn14.FieldName = "PRECIOMIN"
        GridViewDecimalColumn14.HeaderText = "PRECIOMIN"
        GridViewDecimalColumn14.IsAutoGenerated = True
        GridViewDecimalColumn14.IsVisible = False
        GridViewDecimalColumn14.UniqueName = "PRECIOMIN"
        GridViewDecimalColumn15.DataType = GetType(Decimal)
        GridViewDecimalColumn15.FieldAlias = "LINEANUMERO"
        GridViewDecimalColumn15.FieldName = "LINEANUMERO"
        GridViewDecimalColumn15.HeaderText = "LINEANUMERO"
        GridViewDecimalColumn15.IsAutoGenerated = True
        GridViewDecimalColumn15.IsVisible = False
        GridViewDecimalColumn15.UniqueName = "LINEANUMERO"
        GridViewDecimalColumn16.DataType = GetType(Decimal)
        GridViewDecimalColumn16.FieldAlias = "CODCENTRO"
        GridViewDecimalColumn16.FieldName = "CODCENTRO"
        GridViewDecimalColumn16.HeaderText = "CODCENTRO"
        GridViewDecimalColumn16.IsAutoGenerated = True
        GridViewDecimalColumn16.IsVisible = False
        GridViewDecimalColumn16.UniqueName = "CODCENTRO"
        GridViewTextBoxColumn10.FieldAlias = "TIPOIVA"
        GridViewTextBoxColumn10.FieldName = "TIPOIVA"
        GridViewTextBoxColumn10.HeaderText = "TIPOIVA"
        GridViewTextBoxColumn10.IsAutoGenerated = True
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.UniqueName = "TIPOIVA"
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn4)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn5)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn6)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn7)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn8)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn7)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn8)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn9)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn10)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn9)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn11)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn12)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn13)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn14)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn15)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn16)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn10)
        Me.DetalleCompra1GridView.MasterGridViewTemplate.EnableGrouping = False
        Me.DetalleCompra1GridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.DetalleCompra1GridView.Name = "DetalleCompra1GridView"
        Me.DetalleCompra1GridView.ReadOnly = True
        Me.DetalleCompra1GridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DetalleCompra1GridView.ShowGroupPanel = False
        Me.DetalleCompra1GridView.Size = New System.Drawing.Size(558, 139)
        Me.DetalleCompra1GridView.TabIndex = 9
        Me.DetalleCompra1GridView.ThemeName = "Aqua"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.AutoScroll = True
        Me.pnlDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetalle.BackColor = System.Drawing.Color.LightGray
        Me.pnlDetalle.Controls.Add(Me.TableLayoutPanel4)
        Me.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetalle.Location = New System.Drawing.Point(3, 188)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(757, 275)
        Me.pnlDetalle.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 6
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.95238!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.056803!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.21438!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.18257!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label17, 0, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.Label12, 0, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.Label10, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.Label9, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.Label8, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label7, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.lblPorcRetIVA, 3, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.Label13, 3, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.lblPorcRetRENTA, 4, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.Label15, 4, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.lblRetIVA, 3, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.lblRetRENTA, 4, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.lblTotalRetencion, 4, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.tbxTotalSinIva, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.tbxTotalIva, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.tbxTotalTransaccion, 1, 3)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 9
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.332361!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.84047!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.00778!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.06226!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.39689!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.84047!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.22957!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.28794!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(757, 275)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label17.Location = New System.Drawing.Point(21, 210)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(170, 47)
        Me.Label17.TabIndex = 4581129
        Me.Label17.Text = "Importe Total de la Retención:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(86, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(105, 34)
        Me.Label12.TabIndex = 4581123
        Me.Label12.Text = "Importe Retenido:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(11, 143)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(180, 33)
        Me.Label10.TabIndex = 4581122
        Me.Label10.Text = "Porcentaje de la Retención (%):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(3, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(188, 16)
        Me.Label9.TabIndex = 4581121
        Me.Label9.Text = "IMPUESTOS RETENIDOS"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(3, 91)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(188, 15)
        Me.Label8.TabIndex = 4581120
        Me.Label8.Text = "Valor Total de la Transacción:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(3, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 15)
        Me.Label7.TabIndex = 4581119
        Me.Label7.Text = "IVA Incluido en la Transacción:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(3, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(188, 33)
        Me.Label3.TabIndex = 4581118
        Me.Label3.Text = "Valor de la Transacción SIN IVA:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPorcRetIVA
        '
        Me.lblPorcRetIVA.AutoSize = True
        Me.lblPorcRetIVA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "PORRETENCIO", True))
        Me.lblPorcRetIVA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPorcRetIVA.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblPorcRetIVA.Location = New System.Drawing.Point(502, 143)
        Me.lblPorcRetIVA.Name = "lblPorcRetIVA"
        Me.lblPorcRetIVA.Size = New System.Drawing.Size(104, 33)
        Me.lblPorcRetIVA.TabIndex = 4581128
        Me.lblPorcRetIVA.Text = "30%"
        Me.lblPorcRetIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EMPRESABindingSource
        '
        Me.EMPRESABindingSource.DataMember = "EMPRESA"
        Me.EMPRESABindingSource.DataSource = Me.DsRetencionCompra
        '
        'DsRetencionCompra
        '
        Me.DsRetencionCompra.DataSetName = "DsRetencionCompra"
        Me.DsRetencionCompra.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label13.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(502, 127)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(104, 16)
        Me.Label13.TabIndex = 4581124
        Me.Label13.Text = "IVA"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPorcRetRENTA
        '
        Me.lblPorcRetRENTA.AutoSize = True
        Me.lblPorcRetRENTA.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "PORCRETRENTA", True))
        Me.lblPorcRetRENTA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPorcRetRENTA.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblPorcRetRENTA.Location = New System.Drawing.Point(612, 143)
        Me.lblPorcRetRENTA.Name = "lblPorcRetRENTA"
        Me.lblPorcRetRENTA.Size = New System.Drawing.Size(111, 33)
        Me.lblPorcRetRENTA.TabIndex = 4581127
        Me.lblPorcRetRENTA.Text = "4.5%"
        Me.lblPorcRetRENTA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label15.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(612, 127)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 16)
        Me.Label15.TabIndex = 4581126
        Me.Label15.Text = "RENTA"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRetIVA
        '
        Me.lblRetIVA.AutoSize = True
        Me.lblRetIVA.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblRetIVA.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblRetIVA.Location = New System.Drawing.Point(502, 194)
        Me.lblRetIVA.Name = "lblRetIVA"
        Me.lblRetIVA.Size = New System.Drawing.Size(104, 16)
        Me.lblRetIVA.TabIndex = 4581133
        Me.lblRetIVA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRetRENTA
        '
        Me.lblRetRENTA.AutoSize = True
        Me.lblRetRENTA.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblRetRENTA.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblRetRENTA.Location = New System.Drawing.Point(612, 194)
        Me.lblRetRENTA.Name = "lblRetRENTA"
        Me.lblRetRENTA.Size = New System.Drawing.Size(111, 16)
        Me.lblRetRENTA.TabIndex = 4581134
        Me.lblRetRENTA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalRetencion
        '
        Me.lblTotalRetencion.AutoSize = True
        Me.lblTotalRetencion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RETENCIONCOMPRABindingSource, "TOTALRETENCION", True))
        Me.lblTotalRetencion.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblTotalRetencion.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalRetencion.Location = New System.Drawing.Point(612, 210)
        Me.lblTotalRetencion.Name = "lblTotalRetencion"
        Me.lblTotalRetencion.Size = New System.Drawing.Size(108, 47)
        Me.lblTotalRetencion.TabIndex = 4581135
        Me.lblTotalRetencion.Text = "lblTotalRet"
        Me.lblTotalRetencion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RETENCIONCOMPRABindingSource
        '
        Me.RETENCIONCOMPRABindingSource.DataMember = "RETENCIONCOMPRA"
        Me.RETENCIONCOMPRABindingSource.DataSource = Me.DsRetencionCompra
        '
        'tbxTotalSinIva
        '
        Me.tbxTotalSinIva.AllowDrop = True
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.FontData.SizeInPoints = 12.0!
        Me.tbxTotalSinIva.Appearance = Appearance3
        Me.tbxTotalSinIva.AutoSize = False
        Me.tbxTotalSinIva.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalSinIva.CausesValidation = False
        Me.tbxTotalSinIva.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RETENCIONCOMPRABindingSource, "IMPORTERETSINIVA", True))
        Me.tbxTotalSinIva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxTotalSinIva.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalSinIva.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalSinIva.Location = New System.Drawing.Point(197, 9)
        Me.tbxTotalSinIva.Name = "tbxTotalSinIva"
        Me.tbxTotalSinIva.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalSinIva.Size = New System.Drawing.Size(292, 27)
        Me.tbxTotalSinIva.TabIndex = 4581137
        '
        'tbxTotalIva
        '
        Me.tbxTotalIva.AllowDrop = True
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.SizeInPoints = 12.0!
        Me.tbxTotalIva.Appearance = Appearance2
        Me.tbxTotalIva.AutoSize = False
        Me.tbxTotalIva.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalIva.CausesValidation = False
        Me.tbxTotalIva.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RETENCIONCOMPRABindingSource, "IMPORTERETIVA", True))
        Me.tbxTotalIva.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxTotalIva.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalIva.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalIva.Location = New System.Drawing.Point(197, 42)
        Me.tbxTotalIva.Name = "tbxTotalIva"
        Me.tbxTotalIva.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalIva.Size = New System.Drawing.Size(292, 30)
        Me.tbxTotalIva.TabIndex = 4581138
        '
        'tbxTotalTransaccion
        '
        Me.tbxTotalTransaccion.AllowDrop = True
        Appearance1.BackColor = System.Drawing.Color.White
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.FontData.SizeInPoints = 12.0!
        Me.tbxTotalTransaccion.Appearance = Appearance1
        Me.tbxTotalTransaccion.AutoSize = False
        Me.tbxTotalTransaccion.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalTransaccion.CausesValidation = False
        Me.tbxTotalTransaccion.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.RETENCIONCOMPRABindingSource, "IMPORTERETTOTAL", True))
        Me.tbxTotalTransaccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxTotalTransaccion.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalTransaccion.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalTransaccion.Location = New System.Drawing.Point(197, 78)
        Me.tbxTotalTransaccion.Name = "tbxTotalTransaccion"
        Me.tbxTotalTransaccion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalTransaccion.Size = New System.Drawing.Size(292, 25)
        Me.tbxTotalTransaccion.TabIndex = 4581139
        '
        'PanelBotonera
        '
        Me.PanelBotonera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelBotonera.BackColor = System.Drawing.Color.Tan
        Me.PanelBotonera.BackgroundImage = CType(resources.GetObject("PanelBotonera.BackgroundImage"), System.Drawing.Image)
        Me.PanelBotonera.Controls.Add(Me.ImprimirRetRentaPictureBox)
        Me.PanelBotonera.Controls.Add(Me.BuscarRetencionTextBox)
        Me.PanelBotonera.Controls.Add(Me.PictureBoxMotivoAnulacion)
        Me.PanelBotonera.Controls.Add(Me.NuevoPictureBox)
        Me.PanelBotonera.Controls.Add(Me.EliminarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.ModificarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.CancelarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.GuardarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.PictureBox14)
        Me.PanelBotonera.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelBotonera.Location = New System.Drawing.Point(0, 24)
        Me.PanelBotonera.Name = "PanelBotonera"
        Me.PanelBotonera.Size = New System.Drawing.Size(1017, 40)
        Me.PanelBotonera.TabIndex = 447
        '
        'ImprimirRetRentaPictureBox
        '
        Me.ImprimirRetRentaPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ImprimirRetRentaPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ImprimirRetRentaPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ImprimirRetRentaPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.ImprimirRetRentaPictureBox.Location = New System.Drawing.Point(942, 2)
        Me.ImprimirRetRentaPictureBox.Name = "ImprimirRetRentaPictureBox"
        Me.ImprimirRetRentaPictureBox.Size = New System.Drawing.Size(33, 37)
        Me.ImprimirRetRentaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ImprimirRetRentaPictureBox.TabIndex = 480
        Me.ImprimirRetRentaPictureBox.TabStop = False
        '
        'BuscarRetencionTextBox
        '
        Me.BuscarRetencionTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarRetencionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarRetencionTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarRetencionTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarRetencionTextBox.Location = New System.Drawing.Point(33, 5)
        Me.BuscarRetencionTextBox.Name = "BuscarRetencionTextBox"
        Me.BuscarRetencionTextBox.Size = New System.Drawing.Size(208, 30)
        Me.BuscarRetencionTextBox.TabIndex = 0
        '
        'PictureBoxMotivoAnulacion
        '
        Me.PictureBoxMotivoAnulacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxMotivoAnulacion.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxMotivoAnulacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxMotivoAnulacion.Image = Global.ContaExpress.My.Resources.Resources.Anull
        Me.PictureBoxMotivoAnulacion.Location = New System.Drawing.Point(979, 2)
        Me.PictureBoxMotivoAnulacion.Name = "PictureBoxMotivoAnulacion"
        Me.PictureBoxMotivoAnulacion.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxMotivoAnulacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxMotivoAnulacion.TabIndex = 72
        Me.PictureBoxMotivoAnulacion.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(248, 2)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.DeleteOff
        Me.EliminarPictureBox.Location = New System.Drawing.Point(285, 2)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.EditOff
        Me.ModificarPictureBox.Location = New System.Drawing.Point(322, 2)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = CType(resources.GetObject("CancelarPictureBox.Image"), System.Drawing.Image)
        Me.CancelarPictureBox.Location = New System.Drawing.Point(396, 2)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = CType(resources.GetObject("GuardarPictureBox.Image"), System.Drawing.Image)
        Me.GuardarPictureBox.Location = New System.Drawing.Point(359, 2)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'PictureBox14
        '
        Me.PictureBox14.BackColor = System.Drawing.Color.Tan
        Me.PictureBox14.BackgroundImage = CType(resources.GetObject("PictureBox14.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox14.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox14.TabIndex = 453
        Me.PictureBox14.TabStop = False
        '
        'ModalidadPagoFacturaTextBox
        '
        Me.ModalidadPagoFacturaTextBox.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModalidadPagoFacturaTextBox.ForeColor = System.Drawing.Color.Black
        Me.ModalidadPagoFacturaTextBox.Location = New System.Drawing.Point(117, 276)
        Me.ModalidadPagoFacturaTextBox.Multiline = True
        Me.ModalidadPagoFacturaTextBox.Name = "ModalidadPagoFacturaTextBox"
        '
        '
        '
        Me.ModalidadPagoFacturaTextBox.RootElement.ForeColor = System.Drawing.Color.Black
        Me.ModalidadPagoFacturaTextBox.RootElement.StretchVertically = True
        Me.ModalidadPagoFacturaTextBox.Size = New System.Drawing.Size(35, 22)
        Me.ModalidadPagoFacturaTextBox.TabIndex = 456
        Me.ModalidadPagoFacturaTextBox.TabStop = False
        Me.ModalidadPagoFacturaTextBox.ThemeName = "Breeze"
        CType(Me.ModalidadPagoFacturaTextBox.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).StretchVertically = True
        CType(Me.ModalidadPagoFacturaTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(917, 35)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(100, 20)
        Me.txtEstado.TabIndex = 454
        '
        'ComprasSimpleGridView1
        '
        Me.ComprasSimpleGridView1.AllowUserToAddRows = False
        Me.ComprasSimpleGridView1.AllowUserToDeleteRows = False
        Me.ComprasSimpleGridView1.AllowUserToResizeColumns = False
        Me.ComprasSimpleGridView1.AllowUserToResizeRows = False
        Me.ComprasSimpleGridView1.AutoGenerateColumns = False
        Me.ComprasSimpleGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ComprasSimpleGridView1.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComprasSimpleGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ComprasSimpleGridView1.ColumnHeadersHeight = 35
        Me.ComprasSimpleGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.ComprasSimpleGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOMBRE, Me.NUMRETENCIONDataGridViewTextBoxColumn, Me.CODRETENCIONDataGridViewTextBoxColumn, Me.CODPROVEEDORDataGridViewTextBoxColumn, Me.FECHARETENCIONDataGridViewTextBoxColumn, Me.ESTADO, Me.DESCRIPCIONRETDataGridViewTextBoxColumn, Me.IMPORTERETTOTALDataGridViewTextBoxColumn, Me.IMPORTERETSINIVADataGridViewTextBoxColumn, Me.IMPORTERETIVADataGridViewTextBoxColumn, Me.TOTALRETENCIONDataGridViewTextBoxColumn, Me.TIPORETENCIONDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODRANGODataGridViewTextBoxColumn})
        Me.ComprasSimpleGridView1.DataSource = Me.RETENCIONCOMPRABindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ComprasSimpleGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.ComprasSimpleGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComprasSimpleGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.ComprasSimpleGridView1.Location = New System.Drawing.Point(3, 3)
        Me.ComprasSimpleGridView1.MultiSelect = False
        Me.ComprasSimpleGridView1.Name = "ComprasSimpleGridView1"
        Me.ComprasSimpleGridView1.ReadOnly = True
        Me.ComprasSimpleGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ComprasSimpleGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ComprasSimpleGridView1.RowHeadersVisible = False
        Me.ComprasSimpleGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ComprasSimpleGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ComprasSimpleGridView1.Size = New System.Drawing.Size(240, 474)
        Me.ComprasSimpleGridView1.TabIndex = 2
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.HeaderText = "Proveedor"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'NUMRETENCIONDataGridViewTextBoxColumn
        '
        Me.NUMRETENCIONDataGridViewTextBoxColumn.DataPropertyName = "NUMRETENCION"
        Me.NUMRETENCIONDataGridViewTextBoxColumn.HeaderText = "Nro. Retención"
        Me.NUMRETENCIONDataGridViewTextBoxColumn.Name = "NUMRETENCIONDataGridViewTextBoxColumn"
        Me.NUMRETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODRETENCIONDataGridViewTextBoxColumn
        '
        Me.CODRETENCIONDataGridViewTextBoxColumn.DataPropertyName = "CODRETENCION"
        Me.CODRETENCIONDataGridViewTextBoxColumn.HeaderText = "CODRETENCION"
        Me.CODRETENCIONDataGridViewTextBoxColumn.Name = "CODRETENCIONDataGridViewTextBoxColumn"
        Me.CODRETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODRETENCIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODPROVEEDORDataGridViewTextBoxColumn
        '
        Me.CODPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "CODPROVEEDOR"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.HeaderText = "CODPROVEEDOR"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.Name = "CODPROVEEDORDataGridViewTextBoxColumn"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPROVEEDORDataGridViewTextBoxColumn.Visible = False
        '
        'FECHARETENCIONDataGridViewTextBoxColumn
        '
        Me.FECHARETENCIONDataGridViewTextBoxColumn.DataPropertyName = "FECHARETENCION"
        Me.FECHARETENCIONDataGridViewTextBoxColumn.HeaderText = "FECHARETENCION"
        Me.FECHARETENCIONDataGridViewTextBoxColumn.Name = "FECHARETENCIONDataGridViewTextBoxColumn"
        Me.FECHARETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHARETENCIONDataGridViewTextBoxColumn.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'DESCRIPCIONRETDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCIONRET"
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn.HeaderText = "DESCRIPCIONRET"
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn.Name = "DESCRIPCIONRETDataGridViewTextBoxColumn"
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPCIONRETDataGridViewTextBoxColumn.Visible = False
        '
        'IMPORTERETTOTALDataGridViewTextBoxColumn
        '
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn.DataPropertyName = "IMPORTERETTOTAL"
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn.HeaderText = "IMPORTERETTOTAL"
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn.Name = "IMPORTERETTOTALDataGridViewTextBoxColumn"
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn.ReadOnly = True
        Me.IMPORTERETTOTALDataGridViewTextBoxColumn.Visible = False
        '
        'IMPORTERETSINIVADataGridViewTextBoxColumn
        '
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn.DataPropertyName = "IMPORTERETSINIVA"
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn.HeaderText = "IMPORTERETSINIVA"
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn.Name = "IMPORTERETSINIVADataGridViewTextBoxColumn"
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn.ReadOnly = True
        Me.IMPORTERETSINIVADataGridViewTextBoxColumn.Visible = False
        '
        'IMPORTERETIVADataGridViewTextBoxColumn
        '
        Me.IMPORTERETIVADataGridViewTextBoxColumn.DataPropertyName = "IMPORTERETIVA"
        Me.IMPORTERETIVADataGridViewTextBoxColumn.HeaderText = "IMPORTERETIVA"
        Me.IMPORTERETIVADataGridViewTextBoxColumn.Name = "IMPORTERETIVADataGridViewTextBoxColumn"
        Me.IMPORTERETIVADataGridViewTextBoxColumn.ReadOnly = True
        Me.IMPORTERETIVADataGridViewTextBoxColumn.Visible = False
        '
        'TOTALRETENCIONDataGridViewTextBoxColumn
        '
        Me.TOTALRETENCIONDataGridViewTextBoxColumn.DataPropertyName = "TOTALRETENCION"
        Me.TOTALRETENCIONDataGridViewTextBoxColumn.HeaderText = "TOTALRETENCION"
        Me.TOTALRETENCIONDataGridViewTextBoxColumn.Name = "TOTALRETENCIONDataGridViewTextBoxColumn"
        Me.TOTALRETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.TOTALRETENCIONDataGridViewTextBoxColumn.Visible = False
        '
        'TIPORETENCIONDataGridViewTextBoxColumn
        '
        Me.TIPORETENCIONDataGridViewTextBoxColumn.DataPropertyName = "TIPORETENCION"
        Me.TIPORETENCIONDataGridViewTextBoxColumn.HeaderText = "TIPORETENCION"
        Me.TIPORETENCIONDataGridViewTextBoxColumn.Name = "TIPORETENCIONDataGridViewTextBoxColumn"
        Me.TIPORETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.TIPORETENCIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        Me.CODUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'CODRANGODataGridViewTextBoxColumn
        '
        Me.CODRANGODataGridViewTextBoxColumn.DataPropertyName = "CODRANGO"
        Me.CODRANGODataGridViewTextBoxColumn.HeaderText = "CODRANGO"
        Me.CODRANGODataGridViewTextBoxColumn.Name = "CODRANGODataGridViewTextBoxColumn"
        Me.CODRANGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODRANGODataGridViewTextBoxColumn.Visible = False
        '
        'pnlCabecera
        '
        Me.pnlCabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlCabecera.BackColor = System.Drawing.Color.Transparent
        Me.pnlCabecera.Controls.Add(Me.TableLayoutPanel1)
        Me.pnlCabecera.Controls.Add(Me.cbxMetodo)
        Me.pnlCabecera.Controls.Add(Me.Label11)
        Me.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCabecera.Location = New System.Drawing.Point(3, 3)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(757, 179)
        Me.pnlCabecera.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AllowDrop = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.LightGray
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.24664!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.59563!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.40437!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(757, 179)
        Me.TableLayoutPanel1.TabIndex = 492
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 5
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.51328!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.48672!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.PbxProveedor, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IvaIncluidoComboBox, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.pbxBuscarProveedor, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TipoCompComboBox, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.FechaFactTextBox, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ProvFactComboBox, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 0, 3)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 4
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.47059!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.54745!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.81752!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.81752!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(751, 132)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'PbxProveedor
        '
        Me.PbxProveedor.AllowDrop = True
        Me.PbxProveedor.BackColor = System.Drawing.Color.Transparent
        Me.PbxProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PbxProveedor.Location = New System.Drawing.Point(585, 3)
        Me.PbxProveedor.Name = "PbxProveedor"
        Me.PbxProveedor.Size = New System.Drawing.Size(20, 26)
        Me.PbxProveedor.TabIndex = 4581100
        Me.PbxProveedor.Text = "+"
        '
        'IvaIncluidoComboBox
        '
        Me.IvaIncluidoComboBox.BackColor = System.Drawing.Color.White
        Me.IvaIncluidoComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IvaIncluidoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.IvaIncluidoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IvaIncluidoComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.IvaIncluidoComboBox.FormattingEnabled = True
        Me.IvaIncluidoComboBox.Items.AddRange(New Object() {"Iva", "Renta"})
        Me.IvaIncluidoComboBox.Location = New System.Drawing.Point(194, 70)
        Me.IvaIncluidoComboBox.Name = "IvaIncluidoComboBox"
        Me.IvaIncluidoComboBox.Size = New System.Drawing.Size(358, 26)
        Me.IvaIncluidoComboBox.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(95, 67)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 32)
        Me.Label5.TabIndex = 461
        Me.Label5.Text = "Tipo Retención:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbxBuscarProveedor
        '
        Me.pbxBuscarProveedor.BackColor = System.Drawing.Color.Transparent
        Me.pbxBuscarProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxBuscarProveedor.Image = CType(resources.GetObject("pbxBuscarProveedor.Image"), System.Drawing.Image)
        Me.pbxBuscarProveedor.Location = New System.Drawing.Point(558, 3)
        Me.pbxBuscarProveedor.Name = "pbxBuscarProveedor"
        Me.pbxBuscarProveedor.Size = New System.Drawing.Size(21, 26)
        Me.pbxBuscarProveedor.TabIndex = 472
        Me.pbxBuscarProveedor.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(122, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 34)
        Me.Label2.TabIndex = 461
        Me.Label2.Text = "Proveedor:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TipoCompComboBox
        '
        Me.TipoCompComboBox.BackColor = System.Drawing.Color.White
        Me.TipoCompComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.RETENCIONCOMPRABindingSource, "CODRANGO", True))
        Me.TipoCompComboBox.DataSource = Me.RETCOMPTIPOCOMPROBANTEBindingSource
        Me.TipoCompComboBox.DisplayMember = "DESCOMPROBANTE"
        Me.TipoCompComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TipoCompComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.TipoCompComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.TipoCompComboBox.FormattingEnabled = True
        Me.TipoCompComboBox.Location = New System.Drawing.Point(194, 102)
        Me.TipoCompComboBox.Name = "TipoCompComboBox"
        Me.TipoCompComboBox.Size = New System.Drawing.Size(358, 26)
        Me.TipoCompComboBox.TabIndex = 4
        Me.TipoCompComboBox.ValueMember = "CODCOMPROBANTE"
        '
        'RETCOMPTIPOCOMPROBANTEBindingSource
        '
        Me.RETCOMPTIPOCOMPROBANTEBindingSource.DataMember = "RETCOMPTIPOCOMPROBANTE"
        Me.RETCOMPTIPOCOMPROBANTEBindingSource.DataSource = Me.DsRetencionCompra
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(144, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 33)
        Me.Label4.TabIndex = 461
        Me.Label4.Text = "Fecha:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FechaFactTextBox
        '
        Me.FechaFactTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RETENCIONCOMPRABindingSource, "FECHARETENCION", True))
        Me.FechaFactTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FechaFactTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FechaFactTextBox.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaFactTextBox.Location = New System.Drawing.Point(194, 37)
        Me.FechaFactTextBox.Name = "FechaFactTextBox"
        Me.FechaFactTextBox.Size = New System.Drawing.Size(358, 26)
        Me.FechaFactTextBox.TabIndex = 2
        '
        'ProvFactComboBox
        '
        Me.ProvFactComboBox.BackColor = System.Drawing.Color.White
        Me.ProvFactComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.RETENCIONCOMPRABindingSource, "CODPROVEEDOR", True))
        Me.ProvFactComboBox.DataSource = Me.RETCOMPPROVEEDORBindingSource
        Me.ProvFactComboBox.DisplayMember = "NOMBRE"
        Me.ProvFactComboBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProvFactComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ProvFactComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ProvFactComboBox.FormattingEnabled = True
        Me.ProvFactComboBox.Location = New System.Drawing.Point(194, 3)
        Me.ProvFactComboBox.Name = "ProvFactComboBox"
        Me.ProvFactComboBox.Size = New System.Drawing.Size(358, 28)
        Me.ProvFactComboBox.TabIndex = 0
        Me.ProvFactComboBox.ValueMember = "CODPROVEEDOR"
        '
        'RETCOMPPROVEEDORBindingSource
        '
        Me.RETCOMPPROVEEDORBindingSource.DataMember = "RETCOMPPROVEEDOR"
        Me.RETCOMPPROVEEDORBindingSource.DataSource = Me.DsRetencionCompra
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(75, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 33)
        Me.Label6.TabIndex = 461
        Me.Label6.Text = "Tipo Comprobante:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.56591!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.43409!))
        Me.TableLayoutPanel3.Controls.Add(Me.tbxDescripcion, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 141)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(751, 35)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'tbxDescripcion
        '
        Me.tbxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDescripcion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RETENCIONCOMPRABindingSource, "DESCRIPCIONRET", True))
        Me.tbxDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbxDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDescripcion.Location = New System.Drawing.Point(194, 3)
        Me.tbxDescripcion.Name = "tbxDescripcion"
        Me.tbxDescripcion.Size = New System.Drawing.Size(554, 26)
        Me.tbxDescripcion.TabIndex = 4581118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(95, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 35)
        Me.Label1.TabIndex = 4581117
        Me.Label1.Text = "Comprobantes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxMetodo
        '
        Me.cbxMetodo.BackColor = System.Drawing.Color.White
        Me.cbxMetodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMetodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cbxMetodo.FormattingEnabled = True
        Me.cbxMetodo.Items.AddRange(New Object() {"Simplificado"})
        Me.cbxMetodo.Location = New System.Drawing.Point(566, 184)
        Me.cbxMetodo.Name = "cbxMetodo"
        Me.cbxMetodo.Size = New System.Drawing.Size(242, 26)
        Me.cbxMetodo.TabIndex = 9
        Me.cbxMetodo.Text = "Simplificado"
        Me.cbxMetodo.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(511, 190)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 14)
        Me.Label11.TabIndex = 466
        Me.Label11.Text = "Metodo:"
        Me.Label11.Visible = False
        '
        'PanelAnular
        '
        Me.PanelAnular.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelAnular.BackColor = System.Drawing.Color.Maroon
        Me.PanelAnular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAnular.Controls.Add(Me.TextBoxAnulacionConcepto)
        Me.PanelAnular.Controls.Add(Me.BtnCerrarAnular)
        Me.PanelAnular.Controls.Add(Me.BtnAnular)
        Me.PanelAnular.Controls.Add(Me.RadLabel1)
        Me.PanelAnular.Location = New System.Drawing.Point(640, 0)
        Me.PanelAnular.Name = "PanelAnular"
        Me.PanelAnular.Size = New System.Drawing.Size(372, 173)
        Me.PanelAnular.TabIndex = 468
        '
        'TextBoxAnulacionConcepto
        '
        Me.TextBoxAnulacionConcepto.BackColor = System.Drawing.Color.White
        Me.TextBoxAnulacionConcepto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxAnulacionConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBoxAnulacionConcepto.Location = New System.Drawing.Point(9, 35)
        Me.TextBoxAnulacionConcepto.Name = "TextBoxAnulacionConcepto"
        Me.TextBoxAnulacionConcepto.Size = New System.Drawing.Size(354, 130)
        Me.TextBoxAnulacionConcepto.TabIndex = 454
        Me.TextBoxAnulacionConcepto.Text = ""
        '
        'BtnCerrarAnular
        '
        Me.BtnCerrarAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarAnular.Location = New System.Drawing.Point(301, 5)
        Me.BtnCerrarAnular.Name = "BtnCerrarAnular"
        Me.BtnCerrarAnular.Size = New System.Drawing.Size(62, 26)
        Me.BtnCerrarAnular.TabIndex = 427
        Me.BtnCerrarAnular.Text = "Cerrar"
        '
        'BtnAnular
        '
        Me.BtnAnular.DisplayStyle = Telerik.WinControls.DisplayStyle.Text
        Me.BtnAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnular.Location = New System.Drawing.Point(207, 5)
        Me.BtnAnular.Name = "BtnAnular"
        Me.BtnAnular.Size = New System.Drawing.Size(89, 26)
        Me.BtnAnular.TabIndex = 428
        Me.BtnAnular.Text = "Anular"
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.RadLabel1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadLabel1.Location = New System.Drawing.Point(3, 3)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadLabel1.Size = New System.Drawing.Size(188, 31)
        Me.RadLabel1.TabIndex = 426
        Me.RadLabel1.Text = "Motivo de Anulación"
        '
        'tbxCodCompras
        '
        Me.tbxCodCompras.Location = New System.Drawing.Point(811, 35)
        Me.tbxCodCompras.Name = "tbxCodCompras"
        Me.tbxCodCompras.Size = New System.Drawing.Size(100, 20)
        Me.tbxCodCompras.TabIndex = 469
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Image = CType(resources.GetObject("ToolStripStatusLabel1.Image"), System.Drawing.Image)
        Me.ToolStripStatusLabel1.IsLink = True
        Me.ToolStripStatusLabel1.LinkColor = System.Drawing.Color.DimGray
        Me.ToolStripStatusLabel1.LinkVisited = True
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel1.Text = "Ayuda"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(707, 17)
        Me.ToolStripStatusLabel2.Spring = True
        '
        'lblComprasEstado
        '
        Me.lblComprasEstado.Name = "lblComprasEstado"
        Me.lblComprasEstado.Size = New System.Drawing.Size(151, 17)
        Me.lblComprasEstado.Text = "Compras Plus - Pos Express"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'PORCENTAJEIVADataGridViewTextBoxColumn
        '
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.DataPropertyName = "PORCENTAJEIVA"
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.HeaderText = "PORCENTAJEIVA"
        Me.PORCENTAJEIVADataGridViewTextBoxColumn.Name = "PORCENTAJEIVADataGridViewTextBoxColumn"
        '
        'DESCODIGO1DataGridViewTextBoxColumn
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1DataGridViewTextBoxColumn.HeaderText = "Variable"
        Me.DESCODIGO1DataGridViewTextBoxColumn.Name = "DESCODIGO1DataGridViewTextBoxColumn"
        Me.DESCODIGO1DataGridViewTextBoxColumn.Width = 70
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Width = 200
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigo"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        '
        'CODPRODUCTODataGridViewTextBoxColumn
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Name = "CODPRODUCTODataGridViewTextBoxColumn"
        '
        'CODIVA
        '
        Me.CODIVA.DataPropertyName = "CODIVA"
        Me.CODIVA.HeaderText = "CODIVA"
        Me.CODIVA.Name = "CODIVA"
        Me.CODIVA.Visible = False
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 64)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblDGVCant)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbAño)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbMes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnFiltro)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel10)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ModalidadPagoFacturaTextBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel9)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PanelAnular)
        Me.SplitContainer1.Panel2.Controls.Add(Me.RadGroupBoxProveedor)
        Me.SplitContainer1.Size = New System.Drawing.Size(1017, 515)
        Me.SplitContainer1.SplitterDistance = 240
        Me.SplitContainer1.TabIndex = 4581114
        '
        'lblDGVCant
        '
        Me.lblDGVCant.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDGVCant.BackColor = System.Drawing.Color.Transparent
        Me.lblDGVCant.ForeColor = System.Drawing.Color.DimGray
        Me.lblDGVCant.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDGVCant.Location = New System.Drawing.Point(-1, 31)
        Me.lblDGVCant.Name = "lblDGVCant"
        Me.lblDGVCant.Size = New System.Drawing.Size(235, 14)
        Me.lblDGVCant.TabIndex = 4581121
        Me.lblDGVCant.Text = "lblDGVCant"
        Me.lblDGVCant.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CmbAño
        '
        Me.CmbAño.AutoSize = False
        Me.CmbAño.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem13, Me.RadComboBoxItem14, Me.RadComboBoxItem15, Me.RadComboBoxItem16, Me.RadComboBoxItem17, Me.RadComboBoxItem18, Me.RadComboBoxItem19, Me.RadComboBoxItem20, Me.RadComboBoxItem21, Me.RadComboBoxItem22, Me.RadComboBoxItem23})
        Me.CmbAño.Location = New System.Drawing.Point(94, 2)
        Me.CmbAño.Name = "CmbAño"
        '
        '
        '
        Me.CmbAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbAño.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.RootElement.StretchVertically = True
        Me.CmbAño.Size = New System.Drawing.Size(70, 26)
        Me.CmbAño.TabIndex = 4581119
        Me.CmbAño.TabStop = False
        Me.CmbAño.ThemeName = "Breeze"
        CType(Me.CmbAño.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Silver
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.Silver
        '
        'RadComboBoxItem13
        '
        Me.RadComboBoxItem13.Name = "RadComboBoxItem13"
        Me.RadComboBoxItem13.Text = "2010"
        '
        'RadComboBoxItem14
        '
        Me.RadComboBoxItem14.Name = "RadComboBoxItem14"
        Me.RadComboBoxItem14.Text = "2011"
        '
        'RadComboBoxItem15
        '
        Me.RadComboBoxItem15.Name = "RadComboBoxItem15"
        Me.RadComboBoxItem15.Text = "2012"
        '
        'RadComboBoxItem16
        '
        Me.RadComboBoxItem16.Name = "RadComboBoxItem16"
        Me.RadComboBoxItem16.Text = "2013"
        '
        'RadComboBoxItem17
        '
        Me.RadComboBoxItem17.Name = "RadComboBoxItem17"
        Me.RadComboBoxItem17.Text = "2014"
        '
        'RadComboBoxItem18
        '
        Me.RadComboBoxItem18.Name = "RadComboBoxItem18"
        Me.RadComboBoxItem18.Text = "2015"
        '
        'RadComboBoxItem19
        '
        Me.RadComboBoxItem19.Name = "RadComboBoxItem19"
        Me.RadComboBoxItem19.Text = "2016"
        '
        'RadComboBoxItem20
        '
        Me.RadComboBoxItem20.Name = "RadComboBoxItem20"
        Me.RadComboBoxItem20.Text = "2017"
        '
        'RadComboBoxItem21
        '
        Me.RadComboBoxItem21.Name = "RadComboBoxItem21"
        Me.RadComboBoxItem21.Text = "2018"
        '
        'RadComboBoxItem22
        '
        Me.RadComboBoxItem22.Name = "RadComboBoxItem22"
        Me.RadComboBoxItem22.Text = "2019"
        '
        'RadComboBoxItem23
        '
        Me.RadComboBoxItem23.Name = "RadComboBoxItem23"
        Me.RadComboBoxItem23.Text = "2020"
        '
        'CmbMes
        '
        Me.CmbMes.AutoSize = False
        Me.CmbMes.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbMes.ForeColor = System.Drawing.Color.Black
        Me.CmbMes.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2, Me.RadComboBoxItem3, Me.RadComboBoxItem4, Me.RadComboBoxItem5, Me.RadComboBoxItem6, Me.RadComboBoxItem7, Me.RadComboBoxItem8, Me.RadComboBoxItem9, Me.RadComboBoxItem10, Me.RadComboBoxItem11, Me.RadComboBoxItem12})
        Me.CmbMes.Location = New System.Drawing.Point(1, 2)
        Me.CmbMes.Name = "CmbMes"
        '
        '
        '
        Me.CmbMes.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbMes.RootElement.ForeColor = System.Drawing.Color.Black
        Me.CmbMes.RootElement.StretchVertically = True
        Me.CmbMes.Size = New System.Drawing.Size(85, 26)
        Me.CmbMes.TabIndex = 4581118
        Me.CmbMes.TabStop = False
        Me.CmbMes.ThemeName = "Breeze"
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Silver
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.Silver
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Enero"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "Febrero"
        '
        'RadComboBoxItem3
        '
        Me.RadComboBoxItem3.Name = "RadComboBoxItem3"
        Me.RadComboBoxItem3.Text = "Marzo"
        '
        'RadComboBoxItem4
        '
        Me.RadComboBoxItem4.Name = "RadComboBoxItem4"
        Me.RadComboBoxItem4.Text = "Abril"
        '
        'RadComboBoxItem5
        '
        Me.RadComboBoxItem5.Name = "RadComboBoxItem5"
        Me.RadComboBoxItem5.Text = "Mayo"
        '
        'RadComboBoxItem6
        '
        Me.RadComboBoxItem6.Name = "RadComboBoxItem6"
        Me.RadComboBoxItem6.Text = "Junio"
        '
        'RadComboBoxItem7
        '
        Me.RadComboBoxItem7.Name = "RadComboBoxItem7"
        Me.RadComboBoxItem7.Text = "Julio"
        '
        'RadComboBoxItem8
        '
        Me.RadComboBoxItem8.Name = "RadComboBoxItem8"
        Me.RadComboBoxItem8.Text = "Agosto"
        '
        'RadComboBoxItem9
        '
        Me.RadComboBoxItem9.Name = "RadComboBoxItem9"
        Me.RadComboBoxItem9.Text = "Septiembre"
        '
        'RadComboBoxItem10
        '
        Me.RadComboBoxItem10.Name = "RadComboBoxItem10"
        Me.RadComboBoxItem10.Text = "Octubre"
        '
        'RadComboBoxItem11
        '
        Me.RadComboBoxItem11.Name = "RadComboBoxItem11"
        Me.RadComboBoxItem11.Text = "Noviembre"
        '
        'RadComboBoxItem12
        '
        Me.RadComboBoxItem12.Name = "RadComboBoxItem12"
        Me.RadComboBoxItem12.Text = "Diciembre"
        '
        'BtnFiltro
        '
        Me.BtnFiltro.AllowDrop = True
        Me.BtnFiltro.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFiltro.Location = New System.Drawing.Point(169, 2)
        Me.BtnFiltro.Name = "BtnFiltro"
        Me.BtnFiltro.Size = New System.Drawing.Size(61, 26)
        Me.BtnFiltro.TabIndex = 4581120
        Me.BtnFiltro.Text = "Filtrar"
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.Lavender
        Me.TableLayoutPanel10.ColumnCount = 1
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel10.Controls.Add(Me.ComprasSimpleGridView1, 0, 0)
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(-5, 45)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 1
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.23301!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 480.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 480.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 480.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(246, 480)
        Me.TableLayoutPanel10.TabIndex = 4581117
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel9.BackgroundImage = CType(resources.GetObject("TableLayoutPanel9.BackgroundImage"), System.Drawing.Image)
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.TableLayoutPanel13, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 2
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.632094!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.3679!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(769, 511)
        Me.TableLayoutPanel9.TabIndex = 4581115
        '
        'TableLayoutPanel13
        '
        Me.TableLayoutPanel13.AutoScroll = True
        Me.TableLayoutPanel13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel13.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel13.ColumnCount = 3
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.1414!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel13.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223.0!))
        Me.TableLayoutPanel13.Controls.Add(Me.LblEstado, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.RadLabel7, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.tbxNroRetencion, 2, 0)
        Me.TableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel13.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        Me.TableLayoutPanel13.RowCount = 1
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel13.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33.0!))
        Me.TableLayoutPanel13.Size = New System.Drawing.Size(763, 33)
        Me.TableLayoutPanel13.TabIndex = 0
        '
        'RadLabel7
        '
        Me.RadLabel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.RadLabel7.Location = New System.Drawing.Point(446, 12)
        Me.RadLabel7.Name = "RadLabel7"
        '
        '
        '
        Me.RadLabel7.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel7.RootElement.AngleTransform = 0.0!
        Me.RadLabel7.RootElement.FlipText = False
        Me.RadLabel7.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel7.RootElement.Text = Nothing
        Me.RadLabel7.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel7.Size = New System.Drawing.Size(89, 18)
        Me.RadLabel7.TabIndex = 467
        Me.RadLabel7.Text = "Nº Retención:"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxNroRetencion
        '
        Me.tbxNroRetencion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbxNroRetencion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroRetencion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RETENCIONCOMPRABindingSource, "NUMRETENCION", True))
        Me.tbxNroRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNroRetencion.Location = New System.Drawing.Point(543, 4)
        Me.tbxNroRetencion.Name = "tbxNroRetencion"
        Me.tbxNroRetencion.Size = New System.Drawing.Size(217, 26)
        Me.tbxNroRetencion.TabIndex = 4581118
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.pnlCabecera, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.pnlDetalle, 0, 1)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 42)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.91416!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.08584!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(763, 466)
        Me.TableLayoutPanel6.TabIndex = 457
        '
        'tsRetencionCompra
        '
        Me.tsRetencionCompra.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNuevaRetencion, Me.ToolStripSeparator1, Me.tsAnular, Me.CancelarToolStripMenuItem})
        Me.tsRetencionCompra.ForeColor = System.Drawing.Color.Black
        Me.tsRetencionCompra.Name = "tsRetencionCompra"
        Me.tsRetencionCompra.Size = New System.Drawing.Size(123, 20)
        Me.tsRetencionCompra.Text = "Retención Compras"
        '
        'tsNuevaRetencion
        '
        Me.tsNuevaRetencion.Image = CType(resources.GetObject("tsNuevaRetencion.Image"), System.Drawing.Image)
        Me.tsNuevaRetencion.Name = "tsNuevaRetencion"
        Me.tsNuevaRetencion.Size = New System.Drawing.Size(164, 22)
        Me.tsNuevaRetencion.Text = "Nueva Retención"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        'tsAnular
        '
        Me.tsAnular.Image = CType(resources.GetObject("tsAnular.Image"), System.Drawing.Image)
        Me.tsAnular.Name = "tsAnular"
        Me.tsAnular.Size = New System.Drawing.Size(164, 22)
        Me.tsAnular.Text = "Anular"
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Enabled = False
        Me.CancelarToolStripMenuItem.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'tsAdministrar
        '
        Me.tsAdministrar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsQuemarProximo, Me.tsModificarNroRetencion, Me.tsReImprimirAutoF})
        Me.tsAdministrar.ForeColor = System.Drawing.Color.Black
        Me.tsAdministrar.Name = "tsAdministrar"
        Me.tsAdministrar.Size = New System.Drawing.Size(81, 20)
        Me.tsAdministrar.Text = "Administrar"
        '
        'tsQuemarProximo
        '
        Me.tsQuemarProximo.Name = "tsQuemarProximo"
        Me.tsQuemarProximo.Size = New System.Drawing.Size(207, 22)
        Me.tsQuemarProximo.Text = "Quemar Proximo Nro"
        '
        'tsModificarNroRetencion
        '
        Me.tsModificarNroRetencion.Name = "tsModificarNroRetencion"
        Me.tsModificarNroRetencion.Size = New System.Drawing.Size(207, 22)
        Me.tsModificarNroRetencion.Text = "Modificar Nro. Retención"
        '
        'tsReImprimirAutoF
        '
        Me.tsReImprimirAutoF.Name = "tsReImprimirAutoF"
        Me.tsReImprimirAutoF.Size = New System.Drawing.Size(207, 22)
        Me.tsReImprimirAutoF.Text = "ReImprimir Retención"
        '
        'tsFiltrar
        '
        Me.tsFiltrar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFechaEspecifica, Me.tsRangoDeFechas, Me.tsPorProveedor, Me.tsAplicarFiltros, Me.tsLimpiarFiltros})
        Me.tsFiltrar.ForeColor = System.Drawing.Color.Black
        Me.tsFiltrar.Name = "tsFiltrar"
        Me.tsFiltrar.Size = New System.Drawing.Size(49, 20)
        Me.tsFiltrar.Text = "Filtrar"
        '
        'tsFechaEspecifica
        '
        Me.tsFechaEspecifica.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFiltroFechaE})
        Me.tsFechaEspecifica.Name = "tsFechaEspecifica"
        Me.tsFechaEspecifica.Size = New System.Drawing.Size(163, 22)
        Me.tsFechaEspecifica.Text = "Fecha Específica"
        '
        'tsFiltroFechaE
        '
        Me.tsFiltroFechaE.MaxLength = 0
        Me.tsFiltroFechaE.Name = "tsFiltroFechaE"
        Me.tsFiltroFechaE.Size = New System.Drawing.Size(121, 23)
        '
        'tsRangoDeFechas
        '
        Me.tsRangoDeFechas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1, Me.tsFiltroRDesde, Me.ToolStripTextBox2, Me.tsFiltroRHasta})
        Me.tsRangoDeFechas.Name = "tsRangoDeFechas"
        Me.tsRangoDeFechas.Size = New System.Drawing.Size(163, 22)
        Me.tsRangoDeFechas.Text = "Rango de Fechas"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripTextBox1.Enabled = False
        Me.ToolStripTextBox1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripTextBox1.Text = "Fecha Desde:"
        '
        'tsFiltroRDesde
        '
        Me.tsFiltroRDesde.Name = "tsFiltroRDesde"
        Me.tsFiltroRDesde.Size = New System.Drawing.Size(100, 23)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStripTextBox2.Enabled = False
        Me.ToolStripTextBox2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(160, 22)
        Me.ToolStripTextBox2.Text = "Fecha Hasta:"
        '
        'tsFiltroRHasta
        '
        Me.tsFiltroRHasta.Name = "tsFiltroRHasta"
        Me.tsFiltroRHasta.Size = New System.Drawing.Size(100, 23)
        '
        'tsPorProveedor
        '
        Me.tsPorProveedor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PorNroClienteToolStripMenuItem, Me.tsFiltroNroProv, Me.PorNombreClienteToolStripMenuItem, Me.tsFiltroNomProv})
        Me.tsPorProveedor.Name = "tsPorProveedor"
        Me.tsPorProveedor.Size = New System.Drawing.Size(163, 22)
        Me.tsPorProveedor.Text = "Por Proveedor"
        '
        'PorNroClienteToolStripMenuItem
        '
        Me.PorNroClienteToolStripMenuItem.Enabled = False
        Me.PorNroClienteToolStripMenuItem.Name = "PorNroClienteToolStripMenuItem"
        Me.PorNroClienteToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.PorNroClienteToolStripMenuItem.Text = "Por Nro. Proveedor"
        '
        'tsFiltroNroProv
        '
        Me.tsFiltroNroProv.MaxLength = 0
        Me.tsFiltroNroProv.Name = "tsFiltroNroProv"
        Me.tsFiltroNroProv.Size = New System.Drawing.Size(121, 23)
        '
        'PorNombreClienteToolStripMenuItem
        '
        Me.PorNombreClienteToolStripMenuItem.Enabled = False
        Me.PorNombreClienteToolStripMenuItem.Name = "PorNombreClienteToolStripMenuItem"
        Me.PorNombreClienteToolStripMenuItem.Size = New System.Drawing.Size(310, 22)
        Me.PorNombreClienteToolStripMenuItem.Text = "Por Nombre Proveedor"
        '
        'tsFiltroNomProv
        '
        Me.tsFiltroNomProv.AutoSize = False
        Me.tsFiltroNomProv.Name = "tsFiltroNomProv"
        Me.tsFiltroNomProv.Size = New System.Drawing.Size(250, 23)
        '
        'tsAplicarFiltros
        '
        Me.tsAplicarFiltros.Name = "tsAplicarFiltros"
        Me.tsAplicarFiltros.Size = New System.Drawing.Size(163, 22)
        Me.tsAplicarFiltros.Text = "Aplicar Filtros"
        '
        'tsLimpiarFiltros
        '
        Me.tsLimpiarFiltros.Name = "tsLimpiarFiltros"
        Me.tsLimpiarFiltros.Size = New System.Drawing.Size(163, 22)
        Me.tsLimpiarFiltros.Text = "Limpiar Filtros"
        '
        'tsVer
        '
        Me.tsVer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsVentanaDePagos})
        Me.tsVer.ForeColor = System.Drawing.Color.Black
        Me.tsVer.Name = "tsVer"
        Me.tsVer.Size = New System.Drawing.Size(36, 20)
        Me.tsVer.Text = "Ver"
        '
        'tsVentanaDePagos
        '
        Me.tsVentanaDePagos.Image = CType(resources.GetObject("tsVentanaDePagos.Image"), System.Drawing.Image)
        Me.tsVentanaDePagos.Name = "tsVentanaDePagos"
        Me.tsVentanaDePagos.Size = New System.Drawing.Size(168, 22)
        Me.tsVentanaDePagos.Text = "Ventana de Pagos"
        '
        'tsAyuda
        '
        Me.tsAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsReportarProblemas, Me.ToolStripSeparator4, Me.tsAyudaOnline})
        Me.tsAyuda.ForeColor = System.Drawing.Color.Black
        Me.tsAyuda.Name = "tsAyuda"
        Me.tsAyuda.Size = New System.Drawing.Size(53, 20)
        Me.tsAyuda.Text = "Ayuda"
        '
        'tsReportarProblemas
        '
        Me.tsReportarProblemas.Name = "tsReportarProblemas"
        Me.tsReportarProblemas.Size = New System.Drawing.Size(178, 22)
        Me.tsReportarProblemas.Text = "Reportar Problemas"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(175, 6)
        '
        'tsAyudaOnline
        '
        Me.tsAyudaOnline.Image = CType(resources.GetObject("tsAyudaOnline.Image"), System.Drawing.Image)
        Me.tsAyudaOnline.Name = "tsAyudaOnline"
        Me.tsAyudaOnline.Size = New System.Drawing.Size(178, 22)
        Me.tsAyudaOnline.Text = "Ayuda Online"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip1.BackgroundImage = CType(resources.GetObject("MenuStrip1.BackgroundImage"), System.Drawing.Image)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRetencionCompra, Me.tsAdministrar, Me.tsFiltrar, Me.tsVer, Me.tsAyuda})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1017, 24)
        Me.MenuStrip1.TabIndex = 4581112
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'lblProximoNro
        '
        Me.lblProximoNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProximoNro.AutoSize = False
        Me.lblProximoNro.BackColor = System.Drawing.Color.Transparent
        Me.lblProximoNro.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.lblProximoNro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProximoNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblProximoNro.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblProximoNro.Location = New System.Drawing.Point(685, 1)
        Me.lblProximoNro.Name = "lblProximoNro"
        '
        '
        '
        Me.lblProximoNro.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.lblProximoNro.RootElement.AngleTransform = 0.0!
        Me.lblProximoNro.RootElement.FlipText = False
        Me.lblProximoNro.RootElement.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblProximoNro.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.lblProximoNro.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.lblProximoNro.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.lblProximoNro.RootElement.Text = Nothing
        Me.lblProximoNro.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.lblProximoNro.Size = New System.Drawing.Size(329, 23)
        Me.lblProximoNro.TabIndex = 4581115
        Me.lblProximoNro.Text = "Próximo Nro de Retención XXX.XXX.XXXXXXXX"
        Me.lblProximoNro.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RETENCIONCOMPRATableAdapter
        '
        Me.RETENCIONCOMPRATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.RETCOMPPROVEEDORTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsRetencionCompraTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'RETCOMPTIPOCOMPROBANTETableAdapter
        '
        Me.RETCOMPTIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'RETCOMPPROVEEDORTableAdapter
        '
        Me.RETCOMPPROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'EMPRESATableAdapter
        '
        Me.EMPRESATableAdapter.ClearBeforeFill = True
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = False
        Me.LblEstado.BackColor = System.Drawing.Color.Transparent
        Me.LblEstado.Font = New System.Drawing.Font("Courier New", 21.75!)
        Me.LblEstado.ForeColor = System.Drawing.Color.Green
        Me.LblEstado.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEstado.Location = New System.Drawing.Point(3, 3)
        Me.LblEstado.Name = "LblEstado"
        '
        '
        '
        Me.LblEstado.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.LblEstado.RootElement.AngleTransform = 0.0!
        Me.LblEstado.RootElement.FlipText = False
        Me.LblEstado.RootElement.ForeColor = System.Drawing.Color.Green
        Me.LblEstado.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.LblEstado.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.LblEstado.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.LblEstado.RootElement.Text = Nothing
        Me.LblEstado.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.LblEstado.Size = New System.Drawing.Size(437, 27)
        Me.LblEstado.TabIndex = 4581119
        Me.LblEstado.Text = "ESTADO"
        Me.LblEstado.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComprasRetencion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(1017, 579)
        Me.Controls.Add(Me.lblProximoNro)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PanelBotonera)
        Me.Controls.Add(Me.EstadoTextBox)
        Me.Controls.Add(Me.CodMonedaComTextBox)
        Me.Controls.Add(Me.CodCompraTextBox)
        Me.Controls.Add(Me.tbxCodCompras)
        Me.Controls.Add(Me.txtEstado)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ComprasRetencion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Administrar Retenciónes de Compras  | Cogent SIG"
        CType(Me.ComprasSimpleGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasSimpleGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MateriaPrimaGridView1.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MateriaPrimaGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBoxProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBoxProveedor.ResumeLayout(False)
        Me.RadGroupBoxProveedor.PerformLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProdGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodCompraTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetalleCompra1GridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DetalleCompra1GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRetencionCompra, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RETENCIONCOMPRABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBotonera.ResumeLayout(False)
        Me.PanelBotonera.PerformLayout()
        CType(Me.ImprimirRetRentaPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxMotivoAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModalidadPagoFacturaTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasSimpleGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.PbxProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBuscarProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RETCOMPTIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RETCOMPPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.PanelAnular.ResumeLayout(False)
        Me.PanelAnular.PerformLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAnular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel13.ResumeLayout(False)
        Me.TableLayoutPanel13.PerformLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.lblProximoNro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotonera As System.Windows.Forms.Panel
    Friend WithEvents BuscarRetencionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBoxMotivoAnulacion As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ComprasSimpleGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ModalidadPagoFacturaTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelAnular As System.Windows.Forms.Panel
    Friend WithEvents BtnAnular As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnCerrarAnular As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TextBoxAnulacionConcepto As System.Windows.Forms.RichTextBox
    'Friend WithEvents CodProductoCTextBox As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodCompras As System.Windows.Forms.TextBox
    Friend WithEvents IvaIncluidoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProvFactComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ProductosTabItem As Telerik.WinControls.UI.TabItem
    Friend WithEvents TxtTotalGravada10 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents TxtTotalGravada5 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TxtCantCuotas As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cbxMetodo As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblComprasEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents FechaFactTextBox As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORCENTAJEIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIVA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents CODMONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCATEGORIAPROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCENTROPROV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CachedVentasVendedor1 As Reportes.CachedVentasVendedorPorCliente
    Friend WithEvents pbxBuscarProveedor As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents CmbAño As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents CmbMes As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents BtnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblDGVCant As System.Windows.Forms.Label
    Friend WithEvents RadComboBoxItem13 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem14 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem15 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem16 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem17 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem18 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem19 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem20 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem21 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem22 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem23 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem3 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem4 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem5 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem6 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem7 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem8 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem9 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem10 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem11 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem12 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents PbxProveedor As Telerik.WinControls.UI.RadButton
    Friend WithEvents tsRetencionCompra As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsNuevaRetencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAnular As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAdministrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsModificarNroRetencion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReImprimirAutoF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltrar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFechaEspecifica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltroFechaE As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsRangoDeFechas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltroRDesde As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltroRHasta As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsPorProveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PorNroClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltroNroProv As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents PorNombreClienteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsFiltroNomProv As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents tsAplicarFiltros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsLimpiarFiltros As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsVentanaDePagos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsReportarProblemas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsAyudaOnline As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TipoCompComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents lblProximoNro As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPorcRetIVA As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblPorcRetRENTA As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblRetIVA As System.Windows.Forms.Label
    Friend WithEvents lblRetRENTA As System.Windows.Forms.Label
    Friend WithEvents lblTotalRetencion As System.Windows.Forms.Label
    Friend WithEvents tbxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents DsRetencionCompra As ContaExpress.DsRetencionCompra
    Friend WithEvents RETENCIONCOMPRABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RETENCIONCOMPRATableAdapter As ContaExpress.DsRetencionCompraTableAdapters.RETENCIONCOMPRATableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsRetencionCompraTableAdapters.TableAdapterManager
    Friend WithEvents RETCOMPTIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RETCOMPTIPOCOMPROBANTETableAdapter As ContaExpress.DsRetencionCompraTableAdapters.RETCOMPTIPOCOMPROBANTETableAdapter
    Friend WithEvents RETCOMPPROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RETCOMPPROVEEDORTableAdapter As ContaExpress.DsRetencionCompraTableAdapters.RETCOMPPROVEEDORTableAdapter
    Friend WithEvents EMPRESABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EMPRESATableAdapter As ContaExpress.DsRetencionCompraTableAdapters.EMPRESATableAdapter
    Friend WithEvents tbxNroRetencion As System.Windows.Forms.TextBox
    Friend WithEvents ImprimirRetRentaPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents tbxTotalSinIva As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tbxTotalIva As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tbxTotalTransaccion As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tsQuemarProximo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMRETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODRETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHARETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONRETDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTERETTOTALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTERETSINIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTERETIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTALRETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPORETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODRANGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblEstado As Telerik.WinControls.UI.RadLabel

#End Region 'Methods

End Class

