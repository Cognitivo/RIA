<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class Producto
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend WithEvents BarcodeString As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents BuscaProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodCategoriaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CODCOLORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodProveedorTextBox As System.Windows.Forms.TextBox
    Friend  WithEvents CodSubcategoriaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents FAMILIATableAdapter As ContaExpress.DsProductosTableAdapters.FAMILIATableAdapter
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEATableAdapter As ContaExpress.DsProductosTableAdapters.LINEATableAdapter
    Friend WithEvents NumericCode As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelPrincipal As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxCancelar As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBoxCodigo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxEliminar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxModifica As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBoxNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter
    Friend  WithEvents PROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents PROVEEDORTableAdapter As ContaExpress.DsProductosTableAdapters.PROVEEDORTableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents RUBROTableAdapter As ContaExpress.DsProductosTableAdapters.RUBROTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsProductosTableAdapters.TableAdapterManager
    Friend WithEvents TIPOCLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsProductosTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents UNIDADMEDIDABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents UNIDADMEDIDATableAdapter As ContaExpress.DsProductosTableAdapters.UNIDADMEDIDATableAdapter

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    #End Region 'Fields

    #Region "Methods"

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode> _
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
    <System.Diagnostics.DebuggerStepThrough> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Producto))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPOCLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UNIDADMEDIDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CodProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.PROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CodCategoriaTextBox = New System.Windows.Forms.TextBox()
        Me.CodSubcategoriaTextBox = New System.Windows.Forms.TextBox()
        Me.PanelPrincipal = New System.Windows.Forms.Panel()
        Me.lblCalculo = New System.Windows.Forms.Label()
        Me.CbxMoneda = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbxCant = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TipoClieComboBox = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PrecioTxtMoneda = New System.Windows.Forms.TextBox()
        Me.PreciosGridView = New System.Windows.Forms.DataGridView()
        Me.CODTIPOCLIENTE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRECIO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCLIENTE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOVENTA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoPrecio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtPesable = New Telerik.WinControls.UI.RadTextBox()
        Me.pbxAgregarListaPrecio = New System.Windows.Forms.PictureBox()
        Me.TxtVencimiento = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtCodFamilia = New System.Windows.Forms.TextBox()
        Me.pnlCodigoBarra = New System.Windows.Forms.Panel()
        Me.AgregarCodigoButton = New Telerik.WinControls.UI.RadButton()
        Me.ModificarCodigoButton = New Telerik.WinControls.UI.RadButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CodigoBarraTextBox = New System.Windows.Forms.TextBox()
        Me.CodigosTradicionalGridView = New System.Windows.Forms.DataGridView()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DesCodigoTextBox = New System.Windows.Forms.TextBox()
        Me.GenerarCodButton = New Telerik.WinControls.UI.RadButton()
        Me.BarcodeString = New Telerik.WinControls.UI.RadTextBox()
        Me.EliminarCodigoButton = New Telerik.WinControls.UI.RadButton()
        Me.CancelarCodigoButton = New Telerik.WinControls.UI.RadButton()
        Me.NumericCode = New System.Windows.Forms.TextBox()
        Me.ElimPrecioButton = New Telerik.WinControls.UI.RadButton()
        Me.AgregarPrecioButton = New Telerik.WinControls.UI.RadButton()
        Me.txtxcaja = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.PanelDetalles = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UbicacionTextBox = New System.Windows.Forms.TextBox()
        Me.pbxAgregarEquipo = New System.Windows.Forms.PictureBox()
        Me.pbxAgregarMarca = New System.Windows.Forms.PictureBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cbxMarca = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOMARCABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblCantCaracteres = New System.Windows.Forms.Label()
        Me.TabEspecBal = New System.Windows.Forms.TabControl()
        Me.TabEspec = New System.Windows.Forms.TabPage()
        Me.tbxEspecificaciones = New System.Windows.Forms.TextBox()
        Me.TabBalanza = New System.Windows.Forms.TabPage()
        Me.CmbPesable = New System.Windows.Forms.ComboBox()
        Me.CmbVencimiento = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChckBalanza = New System.Windows.Forms.CheckBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.EquipoDataGridView = New System.Windows.Forms.DataGridView()
        Me.DESEQUIPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOEQUIPORELBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEquipoRelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEquipoRel = New ContaExpress.DsEquipoRel()
        Me.AddEquipo = New Telerik.WinControls.UI.RadButton()
        Me.cbxEquipo = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOEQUIPOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DelEquipo = New Telerik.WinControls.UI.RadButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxProveedor = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pbxAgregarMedida = New System.Windows.Forms.PictureBox()
        Me.StockMinimoTextBox = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TipoProductoComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TipoIVAComboBox = New System.Windows.Forms.ComboBox()
        Me.IVABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MedidaComboBox = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StockMaximoTextBox = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.lblAyudaEditarCod = New System.Windows.Forms.Label()
        Me.lblAyudaCant = New System.Windows.Forms.Label()
        Me.DsProductos1 = New ContaExpress.DsProductos()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BuscaProductoTextBox = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.PictureBoxCodigo = New System.Windows.Forms.PictureBox()
        Me.PictureBoxStockInicial = New System.Windows.Forms.PictureBox()
        Me.pbxAgregarCategoriaProducto = New System.Windows.Forms.PictureBox()
        Me.pbxEnPromocion = New System.Windows.Forms.PictureBox()
        Me.PictureBoxActivo = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBoxNuevo = New System.Windows.Forms.PictureBox()
        Me.PictureBoxEliminar = New System.Windows.Forms.PictureBox()
        Me.PictureBoxModifica = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCancelar = New System.Windows.Forms.PictureBox()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter()
        Me.LINEATableAdapter = New ContaExpress.DsProductosTableAdapters.LINEATableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DsProductosTableAdapters.RUBROTableAdapter()
        Me.PROVEEDORTableAdapter = New ContaExpress.DsProductosTableAdapters.PROVEEDORTableAdapter()
        Me.TIPOCLIENTETableAdapter = New ContaExpress.DsProductosTableAdapters.TIPOCLIENTETableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsProductosTableAdapters.TableAdapterManager()
        Me.FAMILIATableAdapter = New ContaExpress.DsProductosTableAdapters.FAMILIATableAdapter()
        Me.IVATableAdapter = New ContaExpress.DsProductosTableAdapters.IVATableAdapter()
        Me.UNIDADMEDIDATableAdapter = New ContaExpress.DsProductosTableAdapters.UNIDADMEDIDATableAdapter()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.SERVICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMARCA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESPECIFICACIONES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMAGENPRODUCTO = New System.Windows.Forms.DataGridViewImageColumn()
        Me.CODCODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODVARIAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODRUBRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODFAMILIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODLINEADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIVADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKMINIMODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKMAXIMODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESABLEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENCIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BALANZADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROMOCION = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CODPRODUCTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTODataGridView = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODESTADOPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDESCUENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRECIOTableAdapter = New ContaExpress.DsProductosTableAdapters.PRECIOTableAdapter()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barProductos = New System.Windows.Forms.ToolStripProgressBar()
        Me.CODIGOSTableAdapter = New ContaExpress.DsProductosTableAdapters.CODIGOSTableAdapter()
        Me.PanelCabecera = New System.Windows.Forms.Panel()
        Me.tbxIdLinea = New System.Windows.Forms.TextBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.pbxSinImagen = New System.Windows.Forms.PictureBox()
        Me.pbxImagen = New System.Windows.Forms.PictureBox()
        Me.CategoriaComboBox = New System.Windows.Forms.ComboBox()
        Me.LineaComboBox = New System.Windows.Forms.ComboBox()
        Me.MarcaComboBox = New System.Windows.Forms.ComboBox()
        Me.tbxIdMarca = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbxIdFamilia = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.pbxLink = New System.Windows.Forms.PictureBox()
        Me.DesProductoTextBox = New System.Windows.Forms.TextBox()
        Me.pnlCostoProducto = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbTipoCosto = New System.Windows.Forms.ComboBox()
        Me.lblSinIva = New System.Windows.Forms.Label()
        Me.lblUltimoCosto = New System.Windows.Forms.Label()
        Me.lblTituloUltMov = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPorcGanancia = New System.Windows.Forms.TextBox()
        Me.lblPrecioVenta = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblCosto = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MONEDATableAdapter = New ContaExpress.DsProductosTableAdapters.MONEDATableAdapter()
        Me.PRODUCTOMARCATableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOMARCATableAdapter()
        Me.PRODUCTOEQUIPOTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOEQUIPOTableAdapter()
        Me.PRODUCTO_EQUIPO_RELTableAdapter = New ContaExpress.DsEquipoRelTableAdapters.PRODUCTO_EQUIPO_RELTableAdapter()
        Me.PRODUCTOEQUIPORELSIMPLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRODUCTO_EQUIPO_REL_SIMPLETableAdapter = New ContaExpress.DsEquipoRelTableAdapters.PRODUCTO_EQUIPO_REL_SIMPLETableAdapter()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPrincipal.SuspendLayout()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PreciosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRECIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPesable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarListaPrecio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCodigoBarra.SuspendLayout()
        CType(Me.AgregarCodigoButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarCodigoButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigosTradicionalGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GenerarCodButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarcodeString, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarCodigoButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarCodigoButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ElimPrecioButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AgregarPrecioButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetalles.SuspendLayout()
        CType(Me.pbxAgregarEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarMarca, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOMARCABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabEspecBal.SuspendLayout()
        Me.TabEspec.SuspendLayout()
        Me.TabBalanza.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.EquipoDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOEQUIPORELBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEquipoRelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEquipoRel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AddEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DelEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IVABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxStockInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarCategoriaProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEnPromocion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxModifica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PanelCabecera.SuspendLayout()
        CType(Me.pbxSinImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCostoProducto.SuspendLayout()
        CType(Me.PRODUCTOEQUIPORELSIMPLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.EnforceConstraints = False
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProductos
        '
        'TIPOCLIENTEBindingSource
        '
        Me.TIPOCLIENTEBindingSource.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource.DataSource = Me.DsProductos
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "FK_RUBRO_RELATIONS_LINEA"
        Me.RUBROBindingSource.DataSource = Me.LINEABindingSource
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "FK_LINEA_RELATIONS_FAMILIA"
        Me.LINEABindingSource.DataSource = Me.FAMILIABindingSource
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DsProductos
        '
        'UNIDADMEDIDABindingSource
        '
        Me.UNIDADMEDIDABindingSource.DataMember = "UNIDADMEDIDA"
        Me.UNIDADMEDIDABindingSource.DataSource = Me.DsProductos
        '
        'CodProveedorTextBox
        '
        Me.CodProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CODPROVEEDOR", True))
        resources.ApplyResources(Me.CodProveedorTextBox, "CodProveedorTextBox")
        Me.CodProveedorTextBox.Name = "CodProveedorTextBox"
        '
        'PROVEEDORBindingSource
        '
        Me.PROVEEDORBindingSource.DataMember = "PROVEEDOR"
        Me.PROVEEDORBindingSource.DataSource = Me.DsProductos
        '
        'CodCategoriaTextBox
        '
        Me.CodCategoriaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.LINEABindingSource, "CODLINEA", True))
        resources.ApplyResources(Me.CodCategoriaTextBox, "CodCategoriaTextBox")
        Me.CodCategoriaTextBox.Name = "CodCategoriaTextBox"
        '
        'CodSubcategoriaTextBox
        '
        Me.CodSubcategoriaTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RUBROBindingSource, "CODRUBRO", True))
        resources.ApplyResources(Me.CodSubcategoriaTextBox, "CodSubcategoriaTextBox")
        Me.CodSubcategoriaTextBox.Name = "CodSubcategoriaTextBox"
        '
        'PanelPrincipal
        '
        resources.ApplyResources(Me.PanelPrincipal, "PanelPrincipal")
        Me.PanelPrincipal.BackColor = System.Drawing.Color.LightGray
        Me.PanelPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPrincipal.Controls.Add(Me.lblCalculo)
        Me.PanelPrincipal.Controls.Add(Me.CbxMoneda)
        Me.PanelPrincipal.Controls.Add(Me.Label30)
        Me.PanelPrincipal.Controls.Add(Me.Label32)
        Me.PanelPrincipal.Controls.Add(Me.Label21)
        Me.PanelPrincipal.Controls.Add(Me.tbxCant)
        Me.PanelPrincipal.Controls.Add(Me.Label9)
        Me.PanelPrincipal.Controls.Add(Me.TipoClieComboBox)
        Me.PanelPrincipal.Controls.Add(Me.Label16)
        Me.PanelPrincipal.Controls.Add(Me.Label15)
        Me.PanelPrincipal.Controls.Add(Me.PrecioTxtMoneda)
        Me.PanelPrincipal.Controls.Add(Me.PreciosGridView)
        Me.PanelPrincipal.Controls.Add(Me.TxtPesable)
        Me.PanelPrincipal.Controls.Add(Me.pbxAgregarListaPrecio)
        Me.PanelPrincipal.Controls.Add(Me.TxtVencimiento)
        Me.PanelPrincipal.Controls.Add(Me.TxtCodFamilia)
        Me.PanelPrincipal.Controls.Add(Me.pnlCodigoBarra)
        Me.PanelPrincipal.Controls.Add(Me.NumericCode)
        Me.PanelPrincipal.Controls.Add(Me.ElimPrecioButton)
        Me.PanelPrincipal.Controls.Add(Me.AgregarPrecioButton)
        Me.PanelPrincipal.Controls.Add(Me.txtxcaja)
        Me.PanelPrincipal.Controls.Add(Me.PanelDetalles)
        Me.PanelPrincipal.Controls.Add(Me.lblAyudaEditarCod)
        Me.PanelPrincipal.Controls.Add(Me.lblAyudaCant)
        Me.PanelPrincipal.Name = "PanelPrincipal"
        '
        'lblCalculo
        '
        resources.ApplyResources(Me.lblCalculo, "lblCalculo")
        Me.lblCalculo.ForeColor = System.Drawing.Color.DarkRed
        Me.lblCalculo.Name = "lblCalculo"
        '
        'CbxMoneda
        '
        Me.CbxMoneda.BackColor = System.Drawing.Color.White
        Me.CbxMoneda.DataSource = Me.MONEDABindingSource
        Me.CbxMoneda.DisplayMember = "DESMONEDA"
        Me.CbxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxMoneda.DropDownWidth = 150
        resources.ApplyResources(Me.CbxMoneda, "CbxMoneda")
        Me.CbxMoneda.FormattingEnabled = True
        Me.CbxMoneda.Name = "CbxMoneda"
        Me.CbxMoneda.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsProductos
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.DarkGray
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Name = "Label30"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkGray
        Me.Label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Name = "Label21"
        '
        'tbxCant
        '
        Me.tbxCant.BackColor = System.Drawing.Color.White
        Me.tbxCant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.tbxCant, "tbxCant")
        Me.tbxCant.Name = "tbxCant"
        Me.ToolTip.SetToolTip(Me.tbxCant, resources.GetString("tbxCant.ToolTip"))
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Name = "Label9"
        '
        'TipoClieComboBox
        '
        Me.TipoClieComboBox.BackColor = System.Drawing.Color.White
        Me.TipoClieComboBox.DataSource = Me.TIPOCLIENTEBindingSource
        Me.TipoClieComboBox.DisplayMember = "DESTIPOCLIENTE"
        Me.TipoClieComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.TipoClieComboBox.DropDownWidth = 150
        resources.ApplyResources(Me.TipoClieComboBox, "TipoClieComboBox")
        Me.TipoClieComboBox.FormattingEnabled = True
        Me.TipoClieComboBox.Name = "TipoClieComboBox"
        Me.TipoClieComboBox.ValueMember = "CODTIPOCLIENTE"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.BackColor = System.Drawing.Color.LightGray
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Name = "Label15"
        '
        'PrecioTxtMoneda
        '
        Me.PrecioTxtMoneda.BackColor = System.Drawing.Color.White
        Me.PrecioTxtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.PrecioTxtMoneda, "PrecioTxtMoneda")
        Me.PrecioTxtMoneda.Name = "PrecioTxtMoneda"
        '
        'PreciosGridView
        '
        Me.PreciosGridView.AllowUserToAddRows = False
        Me.PreciosGridView.AllowUserToDeleteRows = False
        Me.PreciosGridView.AllowUserToOrderColumns = True
        Me.PreciosGridView.AllowUserToResizeRows = False
        resources.ApplyResources(Me.PreciosGridView, "PreciosGridView")
        Me.PreciosGridView.AutoGenerateColumns = False
        Me.PreciosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.PreciosGridView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PreciosGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.PreciosGridView.ColumnHeadersVisible = False
        Me.PreciosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODTIPOCLIENTE1, Me.CODPRODUCTO1, Me.CODMONEDA1, Me.CODPRECIO1, Me.DESTIPOCLIENTE1, Me.DESMONEDA1, Me.PRECIOVENTA1, Me.FECGRA, Me.EstadoPrecio, Me.CANTIDAD})
        Me.PreciosGridView.DataSource = Me.PRECIOBindingSource
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PreciosGridView.DefaultCellStyle = DataGridViewCellStyle16
        Me.PreciosGridView.Name = "PreciosGridView"
        Me.PreciosGridView.ReadOnly = True
        Me.PreciosGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PreciosGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.PreciosGridView.RowHeadersVisible = False
        Me.PreciosGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.PreciosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'CODTIPOCLIENTE1
        '
        Me.CODTIPOCLIENTE1.DataPropertyName = "CODTIPOCLIENTE"
        resources.ApplyResources(Me.CODTIPOCLIENTE1, "CODTIPOCLIENTE1")
        Me.CODTIPOCLIENTE1.Name = "CODTIPOCLIENTE1"
        Me.CODTIPOCLIENTE1.ReadOnly = True
        '
        'CODPRODUCTO1
        '
        Me.CODPRODUCTO1.DataPropertyName = "CODPRODUCTO"
        resources.ApplyResources(Me.CODPRODUCTO1, "CODPRODUCTO1")
        Me.CODPRODUCTO1.Name = "CODPRODUCTO1"
        Me.CODPRODUCTO1.ReadOnly = True
        '
        'CODMONEDA1
        '
        Me.CODMONEDA1.DataPropertyName = "CODMONEDA"
        resources.ApplyResources(Me.CODMONEDA1, "CODMONEDA1")
        Me.CODMONEDA1.Name = "CODMONEDA1"
        Me.CODMONEDA1.ReadOnly = True
        '
        'CODPRECIO1
        '
        Me.CODPRECIO1.DataPropertyName = "CODPRECIO"
        resources.ApplyResources(Me.CODPRECIO1, "CODPRECIO1")
        Me.CODPRECIO1.Name = "CODPRECIO1"
        Me.CODPRECIO1.ReadOnly = True
        '
        'DESTIPOCLIENTE1
        '
        Me.DESTIPOCLIENTE1.DataPropertyName = "DESTIPOCLIENTE"
        resources.ApplyResources(Me.DESTIPOCLIENTE1, "DESTIPOCLIENTE1")
        Me.DESTIPOCLIENTE1.Name = "DESTIPOCLIENTE1"
        Me.DESTIPOCLIENTE1.ReadOnly = True
        '
        'DESMONEDA1
        '
        Me.DESMONEDA1.DataPropertyName = "DESMONEDA"
        resources.ApplyResources(Me.DESMONEDA1, "DESMONEDA1")
        Me.DESMONEDA1.Name = "DESMONEDA1"
        Me.DESMONEDA1.ReadOnly = True
        '
        'PRECIOVENTA1
        '
        Me.PRECIOVENTA1.DataPropertyName = "PRECIOVENTA"
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.PRECIOVENTA1.DefaultCellStyle = DataGridViewCellStyle14
        resources.ApplyResources(Me.PRECIOVENTA1, "PRECIOVENTA1")
        Me.PRECIOVENTA1.Name = "PRECIOVENTA1"
        Me.PRECIOVENTA1.ReadOnly = True
        '
        'FECGRA
        '
        Me.FECGRA.DataPropertyName = "FECGRA"
        DataGridViewCellStyle15.Format = "d"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.FECGRA.DefaultCellStyle = DataGridViewCellStyle15
        resources.ApplyResources(Me.FECGRA, "FECGRA")
        Me.FECGRA.Name = "FECGRA"
        Me.FECGRA.ReadOnly = True
        '
        'EstadoPrecio
        '
        resources.ApplyResources(Me.EstadoPrecio, "EstadoPrecio")
        Me.EstadoPrecio.Name = "EstadoPrecio"
        Me.EstadoPrecio.ReadOnly = True
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        resources.ApplyResources(Me.CANTIDAD, "CANTIDAD")
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        '
        'PRECIOBindingSource
        '
        Me.PRECIOBindingSource.DataMember = "PRECIO"
        Me.PRECIOBindingSource.DataSource = Me.DsProductos
        '
        'TxtPesable
        '
        Me.TxtPesable.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "PESABLE", True))
        resources.ApplyResources(Me.TxtPesable, "TxtPesable")
        Me.TxtPesable.Name = "TxtPesable"
        '
        '
        '
        Me.TxtPesable.RootElement.Alignment = CType(resources.GetObject("TxtPesable.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.TxtPesable.RootElement.AngleTransform = CType(resources.GetObject("TxtPesable.RootElement.AngleTransform"), Single)
        Me.TxtPesable.RootElement.FlipText = CType(resources.GetObject("TxtPesable.RootElement.FlipText"), Boolean)
        Me.TxtPesable.RootElement.Margin = CType(resources.GetObject("TxtPesable.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.TxtPesable.RootElement.Padding = CType(resources.GetObject("TxtPesable.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.TxtPesable.RootElement.StringAlignment = CType(resources.GetObject("TxtPesable.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.TxtPesable.RootElement.Text = resources.GetString("TxtPesable.RootElement.Text")
        Me.TxtPesable.RootElement.TextOrientation = CType(resources.GetObject("TxtPesable.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.TxtPesable.TabStop = False
        Me.TxtPesable.ThemeName = "Breeze"
        CType(Me.TxtPesable.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = resources.GetString("resource.Text")
        CType(Me.TxtPesable.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'pbxAgregarListaPrecio
        '
        Me.pbxAgregarListaPrecio.BackColor = System.Drawing.Color.Transparent
        Me.pbxAgregarListaPrecio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarListaPrecio.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        resources.ApplyResources(Me.pbxAgregarListaPrecio, "pbxAgregarListaPrecio")
        Me.pbxAgregarListaPrecio.Name = "pbxAgregarListaPrecio"
        Me.pbxAgregarListaPrecio.TabStop = False
        '
        'TxtVencimiento
        '
        Me.TxtVencimiento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "VENCIMIENTO", True))
        resources.ApplyResources(Me.TxtVencimiento, "TxtVencimiento")
        Me.TxtVencimiento.Name = "TxtVencimiento"
        '
        '
        '
        Me.TxtVencimiento.RootElement.Alignment = CType(resources.GetObject("TxtVencimiento.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.TxtVencimiento.RootElement.AngleTransform = CType(resources.GetObject("TxtVencimiento.RootElement.AngleTransform"), Single)
        Me.TxtVencimiento.RootElement.FlipText = CType(resources.GetObject("TxtVencimiento.RootElement.FlipText"), Boolean)
        Me.TxtVencimiento.RootElement.Margin = CType(resources.GetObject("TxtVencimiento.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.TxtVencimiento.RootElement.Padding = CType(resources.GetObject("TxtVencimiento.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.TxtVencimiento.RootElement.StringAlignment = CType(resources.GetObject("TxtVencimiento.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.TxtVencimiento.RootElement.Text = resources.GetString("TxtVencimiento.RootElement.Text")
        Me.TxtVencimiento.RootElement.TextOrientation = CType(resources.GetObject("TxtVencimiento.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.TxtVencimiento.TabStop = False
        Me.TxtVencimiento.ThemeName = "Breeze"
        CType(Me.TxtVencimiento.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = resources.GetString("resource.Text1")
        CType(Me.TxtVencimiento.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'TxtCodFamilia
        '
        Me.TxtCodFamilia.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.TxtCodFamilia, "TxtCodFamilia")
        Me.TxtCodFamilia.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.TxtCodFamilia.Name = "TxtCodFamilia"
        '
        'pnlCodigoBarra
        '
        resources.ApplyResources(Me.pnlCodigoBarra, "pnlCodigoBarra")
        Me.pnlCodigoBarra.BackColor = System.Drawing.Color.Gray
        Me.pnlCodigoBarra.Controls.Add(Me.AgregarCodigoButton)
        Me.pnlCodigoBarra.Controls.Add(Me.ModificarCodigoButton)
        Me.pnlCodigoBarra.Controls.Add(Me.Label8)
        Me.pnlCodigoBarra.Controls.Add(Me.CodigoBarraTextBox)
        Me.pnlCodigoBarra.Controls.Add(Me.CodigosTradicionalGridView)
        Me.pnlCodigoBarra.Controls.Add(Me.Label5)
        Me.pnlCodigoBarra.Controls.Add(Me.DesCodigoTextBox)
        Me.pnlCodigoBarra.Controls.Add(Me.GenerarCodButton)
        Me.pnlCodigoBarra.Controls.Add(Me.BarcodeString)
        Me.pnlCodigoBarra.Controls.Add(Me.EliminarCodigoButton)
        Me.pnlCodigoBarra.Controls.Add(Me.CancelarCodigoButton)
        Me.pnlCodigoBarra.Name = "pnlCodigoBarra"
        '
        'AgregarCodigoButton
        '
        Me.AgregarCodigoButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.AgregarCodigoButton, "AgregarCodigoButton")
        Me.AgregarCodigoButton.Name = "AgregarCodigoButton"
        '
        '
        '
        Me.AgregarCodigoButton.RootElement.Alignment = CType(resources.GetObject("AgregarCodigoButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.AgregarCodigoButton.RootElement.AngleTransform = CType(resources.GetObject("AgregarCodigoButton.RootElement.AngleTransform"), Single)
        Me.AgregarCodigoButton.RootElement.FlipText = CType(resources.GetObject("AgregarCodigoButton.RootElement.FlipText"), Boolean)
        Me.AgregarCodigoButton.RootElement.Margin = CType(resources.GetObject("AgregarCodigoButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.AgregarCodigoButton.RootElement.Padding = CType(resources.GetObject("AgregarCodigoButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.AgregarCodigoButton.RootElement.StringAlignment = CType(resources.GetObject("AgregarCodigoButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.AgregarCodigoButton.RootElement.Text = resources.GetString("AgregarCodigoButton.RootElement.Text")
        Me.AgregarCodigoButton.RootElement.TextOrientation = CType(resources.GetObject("AgregarCodigoButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'ModificarCodigoButton
        '
        Me.ModificarCodigoButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.ModificarCodigoButton, "ModificarCodigoButton")
        Me.ModificarCodigoButton.Name = "ModificarCodigoButton"
        '
        '
        '
        Me.ModificarCodigoButton.RootElement.Alignment = CType(resources.GetObject("ModificarCodigoButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.ModificarCodigoButton.RootElement.AngleTransform = CType(resources.GetObject("ModificarCodigoButton.RootElement.AngleTransform"), Single)
        Me.ModificarCodigoButton.RootElement.FlipText = CType(resources.GetObject("ModificarCodigoButton.RootElement.FlipText"), Boolean)
        Me.ModificarCodigoButton.RootElement.Margin = CType(resources.GetObject("ModificarCodigoButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.ModificarCodigoButton.RootElement.Padding = CType(resources.GetObject("ModificarCodigoButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.ModificarCodigoButton.RootElement.StringAlignment = CType(resources.GetObject("ModificarCodigoButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.ModificarCodigoButton.RootElement.Text = resources.GetString("ModificarCodigoButton.RootElement.Text")
        Me.ModificarCodigoButton.RootElement.TextOrientation = CType(resources.GetObject("ModificarCodigoButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Name = "Label8"
        '
        'CodigoBarraTextBox
        '
        Me.CodigoBarraTextBox.BackColor = System.Drawing.Color.White
        Me.CodigoBarraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.CodigoBarraTextBox, "CodigoBarraTextBox")
        Me.CodigoBarraTextBox.Name = "CodigoBarraTextBox"
        '
        'CodigosTradicionalGridView
        '
        Me.CodigosTradicionalGridView.AllowUserToAddRows = False
        Me.CodigosTradicionalGridView.AllowUserToDeleteRows = False
        Me.CodigosTradicionalGridView.AllowUserToOrderColumns = True
        Me.CodigosTradicionalGridView.AllowUserToResizeRows = False
        resources.ApplyResources(Me.CodigosTradicionalGridView, "CodigosTradicionalGridView")
        Me.CodigosTradicionalGridView.AutoGenerateColumns = False
        Me.CodigosTradicionalGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.CodigosTradicionalGridView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodigosTradicionalGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.CodigosTradicionalGridView.ColumnHeadersVisible = False
        Me.CodigosTradicionalGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCODIGODataGridViewTextBoxColumn, Me.CODIGODataGridViewTextBoxColumn, Me.DESCODIGO1DataGridViewTextBoxColumn, Me.EstadoCodigo})
        Me.CodigosTradicionalGridView.DataSource = Me.CODIGOSBindingSource
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CodigosTradicionalGridView.DefaultCellStyle = DataGridViewCellStyle19
        Me.CodigosTradicionalGridView.Name = "CodigosTradicionalGridView"
        Me.CodigosTradicionalGridView.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CodigosTradicionalGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.CodigosTradicionalGridView.RowHeadersVisible = False
        Me.CodigosTradicionalGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.CodigosTradicionalGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        resources.ApplyResources(Me.CODCODIGODataGridViewTextBoxColumn, "CODCODIGODataGridViewTextBoxColumn")
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        resources.ApplyResources(Me.CODIGODataGridViewTextBoxColumn, "CODIGODataGridViewTextBoxColumn")
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESCODIGO1DataGridViewTextBoxColumn
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn.DataPropertyName = "DESCODIGO1"
        resources.ApplyResources(Me.DESCODIGO1DataGridViewTextBoxColumn, "DESCODIGO1DataGridViewTextBoxColumn")
        Me.DESCODIGO1DataGridViewTextBoxColumn.Name = "DESCODIGO1DataGridViewTextBoxColumn"
        Me.DESCODIGO1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'EstadoCodigo
        '
        resources.ApplyResources(Me.EstadoCodigo, "EstadoCodigo")
        Me.EstadoCodigo.Name = "EstadoCodigo"
        Me.EstadoCodigo.ReadOnly = True
        '
        'CODIGOSBindingSource
        '
        Me.CODIGOSBindingSource.DataMember = "CODIGOS"
        Me.CODIGOSBindingSource.DataSource = Me.DsProductos
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkGray
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Name = "Label5"
        '
        'DesCodigoTextBox
        '
        Me.DesCodigoTextBox.BackColor = System.Drawing.Color.White
        Me.DesCodigoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.DesCodigoTextBox, "DesCodigoTextBox")
        Me.DesCodigoTextBox.Name = "DesCodigoTextBox"
        '
        'GenerarCodButton
        '
        Me.GenerarCodButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.GenerarCodButton, "GenerarCodButton")
        Me.GenerarCodButton.Name = "GenerarCodButton"
        '
        '
        '
        Me.GenerarCodButton.RootElement.Alignment = CType(resources.GetObject("GenerarCodButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.GenerarCodButton.RootElement.AngleTransform = CType(resources.GetObject("GenerarCodButton.RootElement.AngleTransform"), Single)
        Me.GenerarCodButton.RootElement.FlipText = CType(resources.GetObject("GenerarCodButton.RootElement.FlipText"), Boolean)
        Me.GenerarCodButton.RootElement.Margin = CType(resources.GetObject("GenerarCodButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.GenerarCodButton.RootElement.Padding = CType(resources.GetObject("GenerarCodButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.GenerarCodButton.RootElement.StringAlignment = CType(resources.GetObject("GenerarCodButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.GenerarCodButton.RootElement.Text = resources.GetString("GenerarCodButton.RootElement.Text")
        Me.GenerarCodButton.RootElement.TextOrientation = CType(resources.GetObject("GenerarCodButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'BarcodeString
        '
        Me.BarcodeString.AcceptsTab = True
        resources.ApplyResources(Me.BarcodeString, "BarcodeString")
        Me.BarcodeString.Name = "BarcodeString"
        '
        '
        '
        Me.BarcodeString.RootElement.Alignment = CType(resources.GetObject("BarcodeString.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.BarcodeString.RootElement.AngleTransform = CType(resources.GetObject("BarcodeString.RootElement.AngleTransform"), Single)
        Me.BarcodeString.RootElement.FlipText = CType(resources.GetObject("BarcodeString.RootElement.FlipText"), Boolean)
        Me.BarcodeString.RootElement.Margin = CType(resources.GetObject("BarcodeString.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.BarcodeString.RootElement.Padding = CType(resources.GetObject("BarcodeString.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.BarcodeString.RootElement.StringAlignment = CType(resources.GetObject("BarcodeString.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.BarcodeString.RootElement.Text = resources.GetString("BarcodeString.RootElement.Text")
        Me.BarcodeString.RootElement.TextOrientation = CType(resources.GetObject("BarcodeString.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.BarcodeString.TabStop = False
        Me.BarcodeString.ThemeName = "Breeze"
        CType(Me.BarcodeString.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'EliminarCodigoButton
        '
        Me.EliminarCodigoButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.EliminarCodigoButton, "EliminarCodigoButton")
        Me.EliminarCodigoButton.Name = "EliminarCodigoButton"
        '
        '
        '
        Me.EliminarCodigoButton.RootElement.Alignment = CType(resources.GetObject("EliminarCodigoButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.EliminarCodigoButton.RootElement.AngleTransform = CType(resources.GetObject("EliminarCodigoButton.RootElement.AngleTransform"), Single)
        Me.EliminarCodigoButton.RootElement.FlipText = CType(resources.GetObject("EliminarCodigoButton.RootElement.FlipText"), Boolean)
        Me.EliminarCodigoButton.RootElement.Margin = CType(resources.GetObject("EliminarCodigoButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.EliminarCodigoButton.RootElement.Padding = CType(resources.GetObject("EliminarCodigoButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.EliminarCodigoButton.RootElement.StringAlignment = CType(resources.GetObject("EliminarCodigoButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.EliminarCodigoButton.RootElement.Text = resources.GetString("EliminarCodigoButton.RootElement.Text")
        Me.EliminarCodigoButton.RootElement.TextOrientation = CType(resources.GetObject("EliminarCodigoButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'CancelarCodigoButton
        '
        Me.CancelarCodigoButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.CancelarCodigoButton, "CancelarCodigoButton")
        Me.CancelarCodigoButton.Name = "CancelarCodigoButton"
        '
        '
        '
        Me.CancelarCodigoButton.RootElement.Alignment = CType(resources.GetObject("CancelarCodigoButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.CancelarCodigoButton.RootElement.AngleTransform = CType(resources.GetObject("CancelarCodigoButton.RootElement.AngleTransform"), Single)
        Me.CancelarCodigoButton.RootElement.FlipText = CType(resources.GetObject("CancelarCodigoButton.RootElement.FlipText"), Boolean)
        Me.CancelarCodigoButton.RootElement.Margin = CType(resources.GetObject("CancelarCodigoButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.CancelarCodigoButton.RootElement.Padding = CType(resources.GetObject("CancelarCodigoButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.CancelarCodigoButton.RootElement.StringAlignment = CType(resources.GetObject("CancelarCodigoButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.CancelarCodigoButton.RootElement.Text = resources.GetString("CancelarCodigoButton.RootElement.Text")
        Me.CancelarCodigoButton.RootElement.TextOrientation = CType(resources.GetObject("CancelarCodigoButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'NumericCode
        '
        resources.ApplyResources(Me.NumericCode, "NumericCode")
        Me.NumericCode.Name = "NumericCode"
        '
        'ElimPrecioButton
        '
        Me.ElimPrecioButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.ElimPrecioButton, "ElimPrecioButton")
        Me.ElimPrecioButton.Name = "ElimPrecioButton"
        '
        '
        '
        Me.ElimPrecioButton.RootElement.Alignment = CType(resources.GetObject("ElimPrecioButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.ElimPrecioButton.RootElement.AngleTransform = CType(resources.GetObject("ElimPrecioButton.RootElement.AngleTransform"), Single)
        Me.ElimPrecioButton.RootElement.FlipText = CType(resources.GetObject("ElimPrecioButton.RootElement.FlipText"), Boolean)
        Me.ElimPrecioButton.RootElement.Margin = CType(resources.GetObject("ElimPrecioButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.ElimPrecioButton.RootElement.Padding = CType(resources.GetObject("ElimPrecioButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.ElimPrecioButton.RootElement.StringAlignment = CType(resources.GetObject("ElimPrecioButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.ElimPrecioButton.RootElement.Text = resources.GetString("ElimPrecioButton.RootElement.Text")
        Me.ElimPrecioButton.RootElement.TextOrientation = CType(resources.GetObject("ElimPrecioButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'AgregarPrecioButton
        '
        Me.AgregarPrecioButton.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.AgregarPrecioButton, "AgregarPrecioButton")
        Me.AgregarPrecioButton.Name = "AgregarPrecioButton"
        '
        '
        '
        Me.AgregarPrecioButton.RootElement.Alignment = CType(resources.GetObject("AgregarPrecioButton.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.AgregarPrecioButton.RootElement.AngleTransform = CType(resources.GetObject("AgregarPrecioButton.RootElement.AngleTransform"), Single)
        Me.AgregarPrecioButton.RootElement.FlipText = CType(resources.GetObject("AgregarPrecioButton.RootElement.FlipText"), Boolean)
        Me.AgregarPrecioButton.RootElement.Margin = CType(resources.GetObject("AgregarPrecioButton.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.AgregarPrecioButton.RootElement.Padding = CType(resources.GetObject("AgregarPrecioButton.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.AgregarPrecioButton.RootElement.StringAlignment = CType(resources.GetObject("AgregarPrecioButton.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.AgregarPrecioButton.RootElement.Text = resources.GetString("AgregarPrecioButton.RootElement.Text")
        Me.AgregarPrecioButton.RootElement.TextOrientation = CType(resources.GetObject("AgregarPrecioButton.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'txtxcaja
        '
        resources.ApplyResources(Me.txtxcaja, "txtxcaja")
        Appearance6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance6.BorderColor = System.Drawing.Color.CornflowerBlue
        resources.ApplyResources(Appearance6.FontData, "Appearance6.FontData")
        resources.ApplyResources(Appearance6, "Appearance6")
        Appearance6.ForceApplyResources = "FontData|"
        Me.txtxcaja.Appearance = Appearance6
        Me.txtxcaja.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtxcaja.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007
        Me.txtxcaja.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtxcaja.ImageTransparentColor = System.Drawing.Color.LightGray
        Me.txtxcaja.InputMask = "nnn,nnn,nnn"
        Me.txtxcaja.Name = "txtxcaja"
        Me.txtxcaja.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtxcaja.ReadOnly = True
        Me.txtxcaja.SelectedTextBackColor = System.Drawing.Color.Silver
        Me.txtxcaja.SelectedTextForeColor = System.Drawing.Color.Silver
        '
        'PanelDetalles
        '
        Me.PanelDetalles.Controls.Add(Me.Label1)
        Me.PanelDetalles.Controls.Add(Me.UbicacionTextBox)
        Me.PanelDetalles.Controls.Add(Me.pbxAgregarEquipo)
        Me.PanelDetalles.Controls.Add(Me.pbxAgregarMarca)
        Me.PanelDetalles.Controls.Add(Me.Label33)
        Me.PanelDetalles.Controls.Add(Me.cbxMarca)
        Me.PanelDetalles.Controls.Add(Me.lblCantCaracteres)
        Me.PanelDetalles.Controls.Add(Me.TabEspecBal)
        Me.PanelDetalles.Controls.Add(Me.Label14)
        Me.PanelDetalles.Controls.Add(Me.cbxProveedor)
        Me.PanelDetalles.Controls.Add(Me.Label20)
        Me.PanelDetalles.Controls.Add(Me.pbxAgregarMedida)
        Me.PanelDetalles.Controls.Add(Me.StockMinimoTextBox)
        Me.PanelDetalles.Controls.Add(Me.Label12)
        Me.PanelDetalles.Controls.Add(Me.TipoProductoComboBox)
        Me.PanelDetalles.Controls.Add(Me.Label2)
        Me.PanelDetalles.Controls.Add(Me.Label11)
        Me.PanelDetalles.Controls.Add(Me.TipoIVAComboBox)
        Me.PanelDetalles.Controls.Add(Me.Label3)
        Me.PanelDetalles.Controls.Add(Me.MedidaComboBox)
        Me.PanelDetalles.Controls.Add(Me.Label4)
        Me.PanelDetalles.Controls.Add(Me.StockMaximoTextBox)
        resources.ApplyResources(Me.PanelDetalles, "PanelDetalles")
        Me.PanelDetalles.Name = "PanelDetalles"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'UbicacionTextBox
        '
        Me.UbicacionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UbicacionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "UBICACION", True))
        resources.ApplyResources(Me.UbicacionTextBox, "UbicacionTextBox")
        Me.UbicacionTextBox.Name = "UbicacionTextBox"
        '
        'pbxAgregarEquipo
        '
        Me.pbxAgregarEquipo.BackColor = System.Drawing.Color.LightGray
        Me.pbxAgregarEquipo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarEquipo.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        resources.ApplyResources(Me.pbxAgregarEquipo, "pbxAgregarEquipo")
        Me.pbxAgregarEquipo.Name = "pbxAgregarEquipo"
        Me.pbxAgregarEquipo.TabStop = False
        Me.ToolTip.SetToolTip(Me.pbxAgregarEquipo, resources.GetString("pbxAgregarEquipo.ToolTip"))
        '
        'pbxAgregarMarca
        '
        Me.pbxAgregarMarca.BackColor = System.Drawing.Color.LightGray
        Me.pbxAgregarMarca.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarMarca.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        resources.ApplyResources(Me.pbxAgregarMarca, "pbxAgregarMarca")
        Me.pbxAgregarMarca.Name = "pbxAgregarMarca"
        Me.pbxAgregarMarca.TabStop = False
        Me.ToolTip.SetToolTip(Me.pbxAgregarMarca, resources.GetString("pbxAgregarMarca.ToolTip"))
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Name = "Label33"
        '
        'cbxMarca
        '
        Me.cbxMarca.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxMarca.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "IDMARCA", True))
        Me.cbxMarca.DataSource = Me.PRODUCTOMARCABindingSource
        Me.cbxMarca.DisplayMember = "DESMARCA"
        Me.cbxMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbxMarca, "cbxMarca")
        Me.cbxMarca.FormattingEnabled = True
        Me.cbxMarca.Name = "cbxMarca"
        Me.cbxMarca.ValueMember = "IDMARCA"
        '
        'PRODUCTOMARCABindingSource
        '
        Me.PRODUCTOMARCABindingSource.DataMember = "PRODUCTOMARCA"
        Me.PRODUCTOMARCABindingSource.DataSource = Me.DsProductos
        '
        'lblCantCaracteres
        '
        resources.ApplyResources(Me.lblCantCaracteres, "lblCantCaracteres")
        Me.lblCantCaracteres.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCantCaracteres.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblCantCaracteres.Name = "lblCantCaracteres"
        '
        'TabEspecBal
        '
        resources.ApplyResources(Me.TabEspecBal, "TabEspecBal")
        Me.TabEspecBal.Controls.Add(Me.TabEspec)
        Me.TabEspecBal.Controls.Add(Me.TabBalanza)
        Me.TabEspecBal.Controls.Add(Me.TabPage1)
        Me.TabEspecBal.Name = "TabEspecBal"
        Me.TabEspecBal.SelectedIndex = 0
        '
        'TabEspec
        '
        Me.TabEspec.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.TabEspec, "TabEspec")
        Me.TabEspec.Controls.Add(Me.tbxEspecificaciones)
        Me.TabEspec.ForeColor = System.Drawing.Color.Black
        Me.TabEspec.Name = "TabEspec"
        '
        'tbxEspecificaciones
        '
        resources.ApplyResources(Me.tbxEspecificaciones, "tbxEspecificaciones")
        Me.tbxEspecificaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEspecificaciones.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "ESPECIFICACIONES", True))
        Me.tbxEspecificaciones.Name = "tbxEspecificaciones"
        '
        'TabBalanza
        '
        Me.TabBalanza.BackColor = System.Drawing.Color.LightGray
        Me.TabBalanza.Controls.Add(Me.CmbPesable)
        Me.TabBalanza.Controls.Add(Me.CmbVencimiento)
        Me.TabBalanza.Controls.Add(Me.Label7)
        Me.TabBalanza.Controls.Add(Me.Label10)
        Me.TabBalanza.Controls.Add(Me.Label6)
        Me.TabBalanza.Controls.Add(Me.ChckBalanza)
        resources.ApplyResources(Me.TabBalanza, "TabBalanza")
        Me.TabBalanza.ForeColor = System.Drawing.Color.Black
        Me.TabBalanza.Name = "TabBalanza"
        '
        'CmbPesable
        '
        Me.CmbPesable.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CmbPesable.DisplayMember = "DESMEDIDA"
        Me.CmbPesable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.CmbPesable, "CmbPesable")
        Me.CmbPesable.FormattingEnabled = True
        Me.CmbPesable.Items.AddRange(New Object() {resources.GetString("CmbPesable.Items"), resources.GetString("CmbPesable.Items1")})
        Me.CmbPesable.Name = "CmbPesable"
        Me.CmbPesable.ValueMember = "CODMEDIDA"
        '
        'CmbVencimiento
        '
        Me.CmbVencimiento.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CmbVencimiento.DisplayMember = "DESMEDIDA"
        Me.CmbVencimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.CmbVencimiento, "CmbVencimiento")
        Me.CmbVencimiento.FormattingEnabled = True
        Me.CmbVencimiento.Items.AddRange(New Object() {resources.GetString("CmbVencimiento.Items"), resources.GetString("CmbVencimiento.Items1")})
        Me.CmbVencimiento.Name = "CmbVencimiento"
        Me.CmbVencimiento.ValueMember = "CODMEDIDA"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label7.Name = "Label7"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Name = "Label10"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Name = "Label6"
        '
        'ChckBalanza
        '
        resources.ApplyResources(Me.ChckBalanza, "ChckBalanza")
        Me.ChckBalanza.Name = "ChckBalanza"
        Me.ChckBalanza.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.EquipoDataGridView)
        Me.TabPage1.Controls.Add(Me.AddEquipo)
        Me.TabPage1.Controls.Add(Me.cbxEquipo)
        Me.TabPage1.Controls.Add(Me.DelEquipo)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'EquipoDataGridView
        '
        Me.EquipoDataGridView.AllowUserToAddRows = False
        Me.EquipoDataGridView.AllowUserToDeleteRows = False
        Me.EquipoDataGridView.AllowUserToOrderColumns = True
        Me.EquipoDataGridView.AllowUserToResizeColumns = False
        Me.EquipoDataGridView.AllowUserToResizeRows = False
        Me.EquipoDataGridView.AutoGenerateColumns = False
        Me.EquipoDataGridView.BackgroundColor = System.Drawing.Color.White
        resources.ApplyResources(Me.EquipoDataGridView, "EquipoDataGridView")
        Me.EquipoDataGridView.ColumnHeadersVisible = False
        Me.EquipoDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESEQUIPODataGridViewTextBoxColumn, Me.ID})
        Me.EquipoDataGridView.DataSource = Me.PRODUCTOEQUIPORELBindingSource
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Segoe UI", 11.25!)
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EquipoDataGridView.DefaultCellStyle = DataGridViewCellStyle21
        Me.EquipoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.EquipoDataGridView.MultiSelect = False
        Me.EquipoDataGridView.Name = "EquipoDataGridView"
        Me.EquipoDataGridView.ReadOnly = True
        Me.EquipoDataGridView.RowHeadersVisible = False
        Me.EquipoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.EquipoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DESEQUIPODataGridViewTextBoxColumn
        '
        Me.DESEQUIPODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DESEQUIPODataGridViewTextBoxColumn.DataPropertyName = "DESEQUIPO"
        resources.ApplyResources(Me.DESEQUIPODataGridViewTextBoxColumn, "DESEQUIPODataGridViewTextBoxColumn")
        Me.DESEQUIPODataGridViewTextBoxColumn.Name = "DESEQUIPODataGridViewTextBoxColumn"
        Me.DESEQUIPODataGridViewTextBoxColumn.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'PRODUCTOEQUIPORELBindingSource
        '
        Me.PRODUCTOEQUIPORELBindingSource.DataMember = "PRODUCTO_EQUIPO_REL"
        Me.PRODUCTOEQUIPORELBindingSource.DataSource = Me.DsEquipoRelBindingSource
        '
        'DsEquipoRelBindingSource
        '
        Me.DsEquipoRelBindingSource.DataSource = Me.DsEquipoRel
        Me.DsEquipoRelBindingSource.Position = 0
        '
        'DsEquipoRel
        '
        Me.DsEquipoRel.DataSetName = "DsEquipoRel"
        Me.DsEquipoRel.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AddEquipo
        '
        Me.AddEquipo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.AddEquipo, "AddEquipo")
        Me.AddEquipo.Name = "AddEquipo"
        '
        '
        '
        Me.AddEquipo.RootElement.Alignment = CType(resources.GetObject("AddEquipo.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.AddEquipo.RootElement.AngleTransform = CType(resources.GetObject("AddEquipo.RootElement.AngleTransform"), Single)
        Me.AddEquipo.RootElement.FlipText = CType(resources.GetObject("AddEquipo.RootElement.FlipText"), Boolean)
        Me.AddEquipo.RootElement.Margin = CType(resources.GetObject("AddEquipo.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.AddEquipo.RootElement.Padding = CType(resources.GetObject("AddEquipo.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.AddEquipo.RootElement.StringAlignment = CType(resources.GetObject("AddEquipo.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.AddEquipo.RootElement.Text = resources.GetString("AddEquipo.RootElement.Text")
        Me.AddEquipo.RootElement.TextOrientation = CType(resources.GetObject("AddEquipo.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'cbxEquipo
        '
        Me.cbxEquipo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxEquipo.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "IDEQUIPO", True))
        Me.cbxEquipo.DataSource = Me.PRODUCTOEQUIPOBindingSource
        Me.cbxEquipo.DisplayMember = "DESEQUIPO"
        Me.cbxEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbxEquipo, "cbxEquipo")
        Me.cbxEquipo.FormattingEnabled = True
        Me.cbxEquipo.Name = "cbxEquipo"
        Me.cbxEquipo.ValueMember = "IDEQUIPO"
        '
        'PRODUCTOEQUIPOBindingSource
        '
        Me.PRODUCTOEQUIPOBindingSource.DataMember = "PRODUCTOEQUIPO"
        Me.PRODUCTOEQUIPOBindingSource.DataSource = Me.DsProductos
        '
        'DelEquipo
        '
        Me.DelEquipo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.DelEquipo, "DelEquipo")
        Me.DelEquipo.Name = "DelEquipo"
        '
        '
        '
        Me.DelEquipo.RootElement.Alignment = CType(resources.GetObject("DelEquipo.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.DelEquipo.RootElement.AngleTransform = CType(resources.GetObject("DelEquipo.RootElement.AngleTransform"), Single)
        Me.DelEquipo.RootElement.FlipText = CType(resources.GetObject("DelEquipo.RootElement.FlipText"), Boolean)
        Me.DelEquipo.RootElement.Margin = CType(resources.GetObject("DelEquipo.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.DelEquipo.RootElement.Padding = CType(resources.GetObject("DelEquipo.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.DelEquipo.RootElement.StringAlignment = CType(resources.GetObject("DelEquipo.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.DelEquipo.RootElement.Text = resources.GetString("DelEquipo.RootElement.Text")
        Me.DelEquipo.RootElement.TextOrientation = CType(resources.GetObject("DelEquipo.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.LightGray
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Name = "Label14"
        '
        'cbxProveedor
        '
        Me.cbxProveedor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxProveedor.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODPROVEEDOR", True))
        Me.cbxProveedor.DataSource = Me.PROVEEDORBindingSource
        Me.cbxProveedor.DisplayMember = "NOMBRE"
        Me.cbxProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbxProveedor, "cbxProveedor")
        Me.cbxProveedor.FormattingEnabled = True
        Me.cbxProveedor.Name = "cbxProveedor"
        Me.cbxProveedor.ValueMember = "CODPROVEEDOR"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Name = "Label20"
        '
        'pbxAgregarMedida
        '
        Me.pbxAgregarMedida.BackColor = System.Drawing.Color.LightGray
        Me.pbxAgregarMedida.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarMedida.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        resources.ApplyResources(Me.pbxAgregarMedida, "pbxAgregarMedida")
        Me.pbxAgregarMedida.Name = "pbxAgregarMedida"
        Me.pbxAgregarMedida.TabStop = False
        Me.ToolTip.SetToolTip(Me.pbxAgregarMedida, resources.GetString("pbxAgregarMedida.ToolTip"))
        '
        'StockMinimoTextBox
        '
        Appearance1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance1.BorderColor = System.Drawing.Color.CornflowerBlue
        resources.ApplyResources(Appearance1.FontData, "Appearance1.FontData")
        resources.ApplyResources(Appearance1, "Appearance1")
        Appearance1.ForceApplyResources = "FontData|"
        Me.StockMinimoTextBox.Appearance = Appearance1
        Me.StockMinimoTextBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.StockMinimoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "STOCKMINIMO", True))
        Me.StockMinimoTextBox.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.StockMinimoTextBox.InputMask = "n,nnn,nnn,nnn.nn"
        resources.ApplyResources(Me.StockMinimoTextBox, "StockMinimoTextBox")
        Me.StockMinimoTextBox.Name = "StockMinimoTextBox"
        Me.StockMinimoTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.StockMinimoTextBox.SelectedTextBackColor = System.Drawing.Color.LightSteelBlue
        Me.StockMinimoTextBox.SelectedTextForeColor = System.Drawing.Color.Honeydew
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Name = "Label12"
        '
        'TipoProductoComboBox
        '
        Me.TipoProductoComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TipoProductoComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "SERVICIO", True))
        Me.TipoProductoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.TipoProductoComboBox, "TipoProductoComboBox")
        Me.TipoProductoComboBox.FormattingEnabled = True
        Me.TipoProductoComboBox.Items.AddRange(New Object() {resources.GetString("TipoProductoComboBox.Items"), resources.GetString("TipoProductoComboBox.Items1"), resources.GetString("TipoProductoComboBox.Items2"), resources.GetString("TipoProductoComboBox.Items3"), resources.GetString("TipoProductoComboBox.Items4"), resources.GetString("TipoProductoComboBox.Items5")})
        Me.TipoProductoComboBox.Name = "TipoProductoComboBox"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Name = "Label11"
        '
        'TipoIVAComboBox
        '
        Me.TipoIVAComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TipoIVAComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODIVA", True))
        Me.TipoIVAComboBox.DataSource = Me.IVABindingSource
        Me.TipoIVAComboBox.DisplayMember = "DESIVA"
        Me.TipoIVAComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.TipoIVAComboBox, "TipoIVAComboBox")
        Me.TipoIVAComboBox.FormattingEnabled = True
        Me.TipoIVAComboBox.Name = "TipoIVAComboBox"
        Me.TipoIVAComboBox.ValueMember = "CODIVA"
        '
        'IVABindingSource
        '
        Me.IVABindingSource.DataMember = "IVA"
        Me.IVABindingSource.DataSource = Me.DsProductos
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Name = "Label3"
        '
        'MedidaComboBox
        '
        Me.MedidaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MedidaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODMEDIDA", True))
        Me.MedidaComboBox.DataSource = Me.UNIDADMEDIDABindingSource
        Me.MedidaComboBox.DisplayMember = "DESMEDIDA"
        Me.MedidaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.MedidaComboBox, "MedidaComboBox")
        Me.MedidaComboBox.FormattingEnabled = True
        Me.MedidaComboBox.Name = "MedidaComboBox"
        Me.MedidaComboBox.ValueMember = "CODMEDIDA"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Name = "Label4"
        '
        'StockMaximoTextBox
        '
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.BorderColor = System.Drawing.Color.CornflowerBlue
        resources.ApplyResources(Appearance2.FontData, "Appearance2.FontData")
        resources.ApplyResources(Appearance2, "Appearance2")
        Appearance2.ForceApplyResources = "FontData|"
        Me.StockMaximoTextBox.Appearance = Appearance2
        Me.StockMaximoTextBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.StockMaximoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "STOCKMAXIMO", True))
        Me.StockMaximoTextBox.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.StockMaximoTextBox.InputMask = "n,nnn,nnn,nnn.nn"
        resources.ApplyResources(Me.StockMaximoTextBox, "StockMaximoTextBox")
        Me.StockMaximoTextBox.Name = "StockMaximoTextBox"
        Me.StockMaximoTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.StockMaximoTextBox.SelectedTextBackColor = System.Drawing.Color.LightSteelBlue
        Me.StockMaximoTextBox.SelectedTextForeColor = System.Drawing.Color.Honeydew
        '
        'lblAyudaEditarCod
        '
        resources.ApplyResources(Me.lblAyudaEditarCod, "lblAyudaEditarCod")
        Me.lblAyudaEditarCod.Name = "lblAyudaEditarCod"
        '
        'lblAyudaCant
        '
        Me.lblAyudaCant.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblAyudaCant, "lblAyudaCant")
        Me.lblAyudaCant.Name = "lblAyudaCant"
        '
        'DsProductos1
        '
        Me.DsProductos1.DataSetName = "DsProductos"
        Me.DsProductos1.EnforceConstraints = False
        Me.DsProductos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.BackColor = System.Drawing.Color.LightGray
        Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label13.Name = "Label13"
        '
        'BuscaProductoTextBox
        '
        Me.BuscaProductoTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscaProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.BuscaProductoTextBox, "BuscaProductoTextBox")
        Me.BuscaProductoTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscaProductoTextBox.Name = "BuscaProductoTextBox"
        '
        'PictureBoxCodigo
        '
        Me.PictureBoxCodigo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxCodigo, "PictureBoxCodigo")
        Me.PictureBoxCodigo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxCodigo.Image = Global.ContaExpress.My.Resources.Resources.Barcode
        Me.PictureBoxCodigo.Name = "PictureBoxCodigo"
        Me.PictureBoxCodigo.TabStop = False
        Me.ToolTip.SetToolTip(Me.PictureBoxCodigo, resources.GetString("PictureBoxCodigo.ToolTip"))
        '
        'PictureBoxStockInicial
        '
        Me.PictureBoxStockInicial.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxStockInicial, "PictureBoxStockInicial")
        Me.PictureBoxStockInicial.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxStockInicial.Image = Global.ContaExpress.My.Resources.Resources.Stock
        Me.PictureBoxStockInicial.Name = "PictureBoxStockInicial"
        Me.PictureBoxStockInicial.TabStop = False
        Me.ToolTip.SetToolTip(Me.PictureBoxStockInicial, resources.GetString("PictureBoxStockInicial.ToolTip"))
        '
        'pbxAgregarCategoriaProducto
        '
        Me.pbxAgregarCategoriaProducto.BackColor = System.Drawing.Color.Transparent
        Me.pbxAgregarCategoriaProducto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarCategoriaProducto.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        resources.ApplyResources(Me.pbxAgregarCategoriaProducto, "pbxAgregarCategoriaProducto")
        Me.pbxAgregarCategoriaProducto.Name = "pbxAgregarCategoriaProducto"
        Me.pbxAgregarCategoriaProducto.TabStop = False
        Me.ToolTip.SetToolTip(Me.pbxAgregarCategoriaProducto, resources.GetString("pbxAgregarCategoriaProducto.ToolTip"))
        '
        'pbxEnPromocion
        '
        Me.pbxEnPromocion.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pbxEnPromocion, "pbxEnPromocion")
        Me.pbxEnPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEnPromocion.Image = Global.ContaExpress.My.Resources.Resources.star___copia
        Me.pbxEnPromocion.Name = "pbxEnPromocion"
        Me.pbxEnPromocion.TabStop = False
        Me.ToolTip.SetToolTip(Me.pbxEnPromocion, resources.GetString("pbxEnPromocion.ToolTip"))
        '
        'PictureBoxActivo
        '
        Me.PictureBoxActivo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxActivo, "PictureBoxActivo")
        Me.PictureBoxActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxActivo.Image = Global.ContaExpress.My.Resources.Resources.AbiertoActive
        Me.PictureBoxActivo.Name = "PictureBoxActivo"
        Me.PictureBoxActivo.TabStop = False
        Me.ToolTip.SetToolTip(Me.PictureBoxActivo, resources.GetString("PictureBoxActivo.ToolTip"))
        '
        'Panel1
        '
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.PictureBoxStockInicial)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBoxCodigo)
        Me.Panel1.Controls.Add(Me.PictureBoxGuardar)
        Me.Panel1.Controls.Add(Me.PictureBoxNuevo)
        Me.Panel1.Controls.Add(Me.PictureBoxEliminar)
        Me.Panel1.Controls.Add(Me.PictureBoxModifica)
        Me.Panel1.Controls.Add(Me.PictureBoxCancelar)
        Me.Panel1.Controls.Add(Me.BuscaProductoTextBox)
        Me.Panel1.Name = "Panel1"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxGuardar
        '
        Me.PictureBoxGuardar.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxGuardar, "PictureBoxGuardar")
        Me.PictureBoxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.PictureBoxGuardar.Name = "PictureBoxGuardar"
        Me.PictureBoxGuardar.TabStop = False
        '
        'PictureBoxNuevo
        '
        Me.PictureBoxNuevo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxNuevo, "PictureBoxNuevo")
        Me.PictureBoxNuevo.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.PictureBoxNuevo.Name = "PictureBoxNuevo"
        Me.PictureBoxNuevo.TabStop = False
        '
        'PictureBoxEliminar
        '
        Me.PictureBoxEliminar.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxEliminar, "PictureBoxEliminar")
        Me.PictureBoxEliminar.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.PictureBoxEliminar.Name = "PictureBoxEliminar"
        Me.PictureBoxEliminar.TabStop = False
        '
        'PictureBoxModifica
        '
        Me.PictureBoxModifica.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxModifica, "PictureBoxModifica")
        Me.PictureBoxModifica.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.PictureBoxModifica.Name = "PictureBoxModifica"
        Me.PictureBoxModifica.TabStop = False
        '
        'PictureBoxCancelar
        '
        Me.PictureBoxCancelar.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.PictureBoxCancelar, "PictureBoxCancelar")
        Me.PictureBoxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.PictureBoxCancelar.Name = "PictureBoxCancelar"
        Me.PictureBoxCancelar.TabStop = False
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'LINEATableAdapter
        '
        Me.LINEATableAdapter.ClearBeforeFill = True
        '
        'RUBROTableAdapter
        '
        Me.RUBROTableAdapter.ClearBeforeFill = True
        '
        'PROVEEDORTableAdapter
        '
        Me.PROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'TIPOCLIENTETableAdapter
        '
        Me.TIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.FAMILIATableAdapter = Me.FAMILIATableAdapter
        Me.TableAdapterManager.IVATableAdapter = Me.IVATableAdapter
        Me.TableAdapterManager.LINEATableAdapter = Me.LINEATableAdapter
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PRODUCTOEQUIPOTableAdapter = Nothing
        Me.TableAdapterManager.PRODUCTOMARCATableAdapter = Nothing
        Me.TableAdapterManager.PROVEEDORTableAdapter = Me.PROVEEDORTableAdapter
        Me.TableAdapterManager.RUBROTableAdapter = Me.RUBROTableAdapter
        Me.TableAdapterManager.TIPOCLIENTETableAdapter = Me.TIPOCLIENTETableAdapter
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Me.UNIDADMEDIDATableAdapter
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProductosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'FAMILIATableAdapter
        '
        Me.FAMILIATableAdapter.ClearBeforeFill = True
        '
        'IVATableAdapter
        '
        Me.IVATableAdapter.ClearBeforeFill = True
        '
        'UNIDADMEDIDATableAdapter
        '
        Me.UNIDADMEDIDATableAdapter.ClearBeforeFill = True
        '
        'ProductosGridView
        '
        Me.ProductosGridView.AllowUserToAddRows = False
        Me.ProductosGridView.AllowUserToDeleteRows = False
        Me.ProductosGridView.AllowUserToOrderColumns = True
        Me.ProductosGridView.AllowUserToResizeRows = False
        resources.ApplyResources(Me.ProductosGridView, "ProductosGridView")
        Me.ProductosGridView.AutoGenerateColumns = False
        Me.ProductosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ProductosGridView.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductosGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.ProductosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SERVICIO, Me.DESMARCA, Me.DESEQUIPO, Me.ESPECIFICACIONES, Me.IMAGENPRODUCTO, Me.CODCODIGO, Me.PRODVARIAN, Me.CODRUBRODataGridViewTextBoxColumn, Me.CODFAMILIADataGridViewTextBoxColumn, Me.CODLINEADataGridViewTextBoxColumn, Me.CODIVADataGridViewTextBoxColumn, Me.CODMEDIDADataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn1, Me.CODPROVEEDORDataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn1, Me.STOCKMINIMODataGridViewTextBoxColumn, Me.STOCKMAXIMODataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn1, Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn, Me.ESTADODataGridViewTextBoxColumn, Me.PRODUCTODataGridViewTextBoxColumn, Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn, Me.PESABLEDataGridViewTextBoxColumn, Me.VENCIMIENTODataGridViewTextBoxColumn, Me.BALANZADataGridViewTextBoxColumn, Me.CODIGO, Me.DESCODIGO1DataGridViewTextBoxColumn1, Me.PROMOCION, Me.CODPRODUCTO2})
        Me.ProductosGridView.DataSource = Me.PRODUCTOSBindingSource
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductosGridView.DefaultCellStyle = DataGridViewCellStyle23
        Me.ProductosGridView.GridColor = System.Drawing.Color.Lavender
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.ReadOnly = True
        Me.ProductosGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductosGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'SERVICIO
        '
        Me.SERVICIO.DataPropertyName = "SERVICIO"
        resources.ApplyResources(Me.SERVICIO, "SERVICIO")
        Me.SERVICIO.Name = "SERVICIO"
        Me.SERVICIO.ReadOnly = True
        '
        'DESMARCA
        '
        Me.DESMARCA.DataPropertyName = "IDMARCA"
        resources.ApplyResources(Me.DESMARCA, "DESMARCA")
        Me.DESMARCA.Name = "DESMARCA"
        Me.DESMARCA.ReadOnly = True
        '
        'DESEQUIPO
        '
        Me.DESEQUIPO.DataPropertyName = "IDEQUIPO"
        resources.ApplyResources(Me.DESEQUIPO, "DESEQUIPO")
        Me.DESEQUIPO.Name = "DESEQUIPO"
        Me.DESEQUIPO.ReadOnly = True
        '
        'ESPECIFICACIONES
        '
        Me.ESPECIFICACIONES.DataPropertyName = "ESPECIFICACIONES"
        resources.ApplyResources(Me.ESPECIFICACIONES, "ESPECIFICACIONES")
        Me.ESPECIFICACIONES.Name = "ESPECIFICACIONES"
        Me.ESPECIFICACIONES.ReadOnly = True
        '
        'IMAGENPRODUCTO
        '
        Me.IMAGENPRODUCTO.DataPropertyName = "IMAGENPRODUCTO"
        resources.ApplyResources(Me.IMAGENPRODUCTO, "IMAGENPRODUCTO")
        Me.IMAGENPRODUCTO.Name = "IMAGENPRODUCTO"
        Me.IMAGENPRODUCTO.ReadOnly = True
        '
        'CODCODIGO
        '
        Me.CODCODIGO.DataPropertyName = "CODCODIGO"
        resources.ApplyResources(Me.CODCODIGO, "CODCODIGO")
        Me.CODCODIGO.Name = "CODCODIGO"
        Me.CODCODIGO.ReadOnly = True
        '
        'PRODVARIAN
        '
        Me.PRODVARIAN.DataPropertyName = "DESPRODUCTO"
        Me.PRODVARIAN.FillWeight = 120.0!
        resources.ApplyResources(Me.PRODVARIAN, "PRODVARIAN")
        Me.PRODVARIAN.Name = "PRODVARIAN"
        Me.PRODVARIAN.ReadOnly = True
        '
        'CODRUBRODataGridViewTextBoxColumn
        '
        Me.CODRUBRODataGridViewTextBoxColumn.DataPropertyName = "CODRUBRO"
        resources.ApplyResources(Me.CODRUBRODataGridViewTextBoxColumn, "CODRUBRODataGridViewTextBoxColumn")
        Me.CODRUBRODataGridViewTextBoxColumn.Name = "CODRUBRODataGridViewTextBoxColumn"
        Me.CODRUBRODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODFAMILIADataGridViewTextBoxColumn
        '
        Me.CODFAMILIADataGridViewTextBoxColumn.DataPropertyName = "CODFAMILIA"
        resources.ApplyResources(Me.CODFAMILIADataGridViewTextBoxColumn, "CODFAMILIADataGridViewTextBoxColumn")
        Me.CODFAMILIADataGridViewTextBoxColumn.Name = "CODFAMILIADataGridViewTextBoxColumn"
        Me.CODFAMILIADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODLINEADataGridViewTextBoxColumn
        '
        Me.CODLINEADataGridViewTextBoxColumn.DataPropertyName = "CODLINEA"
        resources.ApplyResources(Me.CODLINEADataGridViewTextBoxColumn, "CODLINEADataGridViewTextBoxColumn")
        Me.CODLINEADataGridViewTextBoxColumn.Name = "CODLINEADataGridViewTextBoxColumn"
        Me.CODLINEADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODIVADataGridViewTextBoxColumn
        '
        Me.CODIVADataGridViewTextBoxColumn.DataPropertyName = "CODIVA"
        resources.ApplyResources(Me.CODIVADataGridViewTextBoxColumn, "CODIVADataGridViewTextBoxColumn")
        Me.CODIVADataGridViewTextBoxColumn.Name = "CODIVADataGridViewTextBoxColumn"
        Me.CODIVADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODMEDIDADataGridViewTextBoxColumn
        '
        Me.CODMEDIDADataGridViewTextBoxColumn.DataPropertyName = "CODMEDIDA"
        resources.ApplyResources(Me.CODMEDIDADataGridViewTextBoxColumn, "CODMEDIDADataGridViewTextBoxColumn")
        Me.CODMEDIDADataGridViewTextBoxColumn.Name = "CODMEDIDADataGridViewTextBoxColumn"
        Me.CODMEDIDADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODUSUARIODataGridViewTextBoxColumn1
        '
        Me.CODUSUARIODataGridViewTextBoxColumn1.DataPropertyName = "CODUSUARIO"
        resources.ApplyResources(Me.CODUSUARIODataGridViewTextBoxColumn1, "CODUSUARIODataGridViewTextBoxColumn1")
        Me.CODUSUARIODataGridViewTextBoxColumn1.Name = "CODUSUARIODataGridViewTextBoxColumn1"
        Me.CODUSUARIODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CODPROVEEDORDataGridViewTextBoxColumn
        '
        Me.CODPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "CODPROVEEDOR"
        resources.ApplyResources(Me.CODPROVEEDORDataGridViewTextBoxColumn, "CODPROVEEDORDataGridViewTextBoxColumn")
        Me.CODPROVEEDORDataGridViewTextBoxColumn.Name = "CODPROVEEDORDataGridViewTextBoxColumn"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn1
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "DESPRODUCTO"
        resources.ApplyResources(Me.DESPRODUCTODataGridViewTextBoxColumn1, "DESPRODUCTODataGridViewTextBoxColumn1")
        Me.DESPRODUCTODataGridViewTextBoxColumn1.Name = "DESPRODUCTODataGridViewTextBoxColumn1"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'STOCKMINIMODataGridViewTextBoxColumn
        '
        Me.STOCKMINIMODataGridViewTextBoxColumn.DataPropertyName = "STOCKMINIMO"
        resources.ApplyResources(Me.STOCKMINIMODataGridViewTextBoxColumn, "STOCKMINIMODataGridViewTextBoxColumn")
        Me.STOCKMINIMODataGridViewTextBoxColumn.Name = "STOCKMINIMODataGridViewTextBoxColumn"
        Me.STOCKMINIMODataGridViewTextBoxColumn.ReadOnly = True
        '
        'STOCKMAXIMODataGridViewTextBoxColumn
        '
        Me.STOCKMAXIMODataGridViewTextBoxColumn.DataPropertyName = "STOCKMAXIMO"
        resources.ApplyResources(Me.STOCKMAXIMODataGridViewTextBoxColumn, "STOCKMAXIMODataGridViewTextBoxColumn")
        Me.STOCKMAXIMODataGridViewTextBoxColumn.Name = "STOCKMAXIMODataGridViewTextBoxColumn"
        Me.STOCKMAXIMODataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECGRADataGridViewTextBoxColumn1
        '
        Me.FECGRADataGridViewTextBoxColumn1.DataPropertyName = "FECGRA"
        resources.ApplyResources(Me.FECGRADataGridViewTextBoxColumn1, "FECGRADataGridViewTextBoxColumn1")
        Me.FECGRADataGridViewTextBoxColumn1.Name = "FECGRADataGridViewTextBoxColumn1"
        Me.FECGRADataGridViewTextBoxColumn1.ReadOnly = True
        '
        'FECHAULTIMACOMPRADataGridViewTextBoxColumn
        '
        Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn.DataPropertyName = "FECHAULTIMACOMPRA"
        resources.ApplyResources(Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn, "FECHAULTIMACOMPRADataGridViewTextBoxColumn")
        Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn.Name = "FECHAULTIMACOMPRADataGridViewTextBoxColumn"
        Me.FECHAULTIMACOMPRADataGridViewTextBoxColumn.ReadOnly = True
        '
        'ESTADODataGridViewTextBoxColumn
        '
        Me.ESTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO"
        resources.ApplyResources(Me.ESTADODataGridViewTextBoxColumn, "ESTADODataGridViewTextBoxColumn")
        Me.ESTADODataGridViewTextBoxColumn.Name = "ESTADODataGridViewTextBoxColumn"
        Me.ESTADODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODUCTODataGridViewTextBoxColumn
        '
        Me.PRODUCTODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTO"
        resources.ApplyResources(Me.PRODUCTODataGridViewTextBoxColumn, "PRODUCTODataGridViewTextBoxColumn")
        Me.PRODUCTODataGridViewTextBoxColumn.Name = "PRODUCTODataGridViewTextBoxColumn"
        Me.PRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODUCTOPRODUCIDODataGridViewTextBoxColumn
        '
        Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn.DataPropertyName = "PRODUCTOPRODUCIDO"
        resources.ApplyResources(Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn, "PRODUCTOPRODUCIDODataGridViewTextBoxColumn")
        Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn.Name = "PRODUCTOPRODUCIDODataGridViewTextBoxColumn"
        Me.PRODUCTOPRODUCIDODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PESABLEDataGridViewTextBoxColumn
        '
        Me.PESABLEDataGridViewTextBoxColumn.DataPropertyName = "PESABLE"
        resources.ApplyResources(Me.PESABLEDataGridViewTextBoxColumn, "PESABLEDataGridViewTextBoxColumn")
        Me.PESABLEDataGridViewTextBoxColumn.Name = "PESABLEDataGridViewTextBoxColumn"
        Me.PESABLEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VENCIMIENTODataGridViewTextBoxColumn
        '
        Me.VENCIMIENTODataGridViewTextBoxColumn.DataPropertyName = "VENCIMIENTO"
        resources.ApplyResources(Me.VENCIMIENTODataGridViewTextBoxColumn, "VENCIMIENTODataGridViewTextBoxColumn")
        Me.VENCIMIENTODataGridViewTextBoxColumn.Name = "VENCIMIENTODataGridViewTextBoxColumn"
        Me.VENCIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'BALANZADataGridViewTextBoxColumn
        '
        Me.BALANZADataGridViewTextBoxColumn.DataPropertyName = "BALANZA"
        resources.ApplyResources(Me.BALANZADataGridViewTextBoxColumn, "BALANZADataGridViewTextBoxColumn")
        Me.BALANZADataGridViewTextBoxColumn.Name = "BALANZADataGridViewTextBoxColumn"
        Me.BALANZADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.FillWeight = 80.0!
        resources.ApplyResources(Me.CODIGO, "CODIGO")
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'DESCODIGO1DataGridViewTextBoxColumn1
        '
        Me.DESCODIGO1DataGridViewTextBoxColumn1.DataPropertyName = "DESCODIGO1"
        resources.ApplyResources(Me.DESCODIGO1DataGridViewTextBoxColumn1, "DESCODIGO1DataGridViewTextBoxColumn1")
        Me.DESCODIGO1DataGridViewTextBoxColumn1.Name = "DESCODIGO1DataGridViewTextBoxColumn1"
        Me.DESCODIGO1DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'PROMOCION
        '
        Me.PROMOCION.DataPropertyName = "PROMOCION"
        resources.ApplyResources(Me.PROMOCION, "PROMOCION")
        Me.PROMOCION.Name = "PROMOCION"
        Me.PROMOCION.ReadOnly = True
        '
        'CODPRODUCTO2
        '
        Me.CODPRODUCTO2.DataPropertyName = "CODPRODUCTO"
        resources.ApplyResources(Me.CODPRODUCTO2, "CODPRODUCTO2")
        Me.CODPRODUCTO2.Name = "CODPRODUCTO2"
        Me.CODPRODUCTO2.ReadOnly = True
        '
        'CODPRODUCTODataGridView
        '
        Me.CODPRODUCTODataGridView.DataPropertyName = "CODPRODUCTO"
        resources.ApplyResources(Me.CODPRODUCTODataGridView, "CODPRODUCTODataGridView")
        Me.CODPRODUCTODataGridView.Name = "CODPRODUCTODataGridView"
        '
        'CODMONEDA
        '
        Me.CODMONEDA.DataPropertyName = "CODMONEDA"
        resources.ApplyResources(Me.CODMONEDA, "CODMONEDA")
        Me.CODMONEDA.Name = "CODMONEDA"
        '
        'CODESTADOPRODUCTO
        '
        Me.CODESTADOPRODUCTO.DataPropertyName = "CODESTADOPRODUCTO"
        resources.ApplyResources(Me.CODESTADOPRODUCTO, "CODESTADOPRODUCTO")
        Me.CODESTADOPRODUCTO.Name = "CODESTADOPRODUCTO"
        '
        'CODDESCUENTO
        '
        Me.CODDESCUENTO.DataPropertyName = "CODDESCUENTO"
        resources.ApplyResources(Me.CODDESCUENTO, "CODDESCUENTO")
        Me.CODDESCUENTO.Name = "CODDESCUENTO"
        '
        'CODUSUARIO
        '
        Me.CODUSUARIO.DataPropertyName = "CODUSUARIO"
        resources.ApplyResources(Me.CODUSUARIO, "CODUSUARIO")
        Me.CODUSUARIO.Name = "CODUSUARIO"
        '
        'CODEMPRESA
        '
        Me.CODEMPRESA.DataPropertyName = "CODEMPRESA"
        resources.ApplyResources(Me.CODEMPRESA, "CODEMPRESA")
        Me.CODEMPRESA.Name = "CODEMPRESA"
        '
        'PRECIOTableAdapter
        '
        Me.PRECIOTableAdapter.ClearBeforeFill = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.barProductos})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.SizingGrip = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel1.IsLink = True
        Me.ToolStripStatusLabel1.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.Spring = True
        '
        'barProductos
        '
        Me.barProductos.Name = "barProductos"
        resources.ApplyResources(Me.barProductos, "barProductos")
        '
        'CODIGOSTableAdapter
        '
        Me.CODIGOSTableAdapter.ClearBeforeFill = True
        '
        'PanelCabecera
        '
        Me.PanelCabecera.BackColor = System.Drawing.Color.Transparent
        Me.PanelCabecera.Controls.Add(Me.tbxIdLinea)
        Me.PanelCabecera.Controls.Add(Me.lblActivo)
        Me.PanelCabecera.Controls.Add(Me.pbxSinImagen)
        Me.PanelCabecera.Controls.Add(Me.pbxImagen)
        Me.PanelCabecera.Controls.Add(Me.pbxEnPromocion)
        Me.PanelCabecera.Controls.Add(Me.CategoriaComboBox)
        Me.PanelCabecera.Controls.Add(Me.LineaComboBox)
        Me.PanelCabecera.Controls.Add(Me.MarcaComboBox)
        Me.PanelCabecera.Controls.Add(Me.tbxIdMarca)
        Me.PanelCabecera.Controls.Add(Me.Label19)
        Me.PanelCabecera.Controls.Add(Me.tbxIdFamilia)
        Me.PanelCabecera.Controls.Add(Me.Label17)
        Me.PanelCabecera.Controls.Add(Me.Label18)
        Me.PanelCabecera.Controls.Add(Me.pbxAgregarCategoriaProducto)
        Me.PanelCabecera.Controls.Add(Me.pbxLink)
        Me.PanelCabecera.Controls.Add(Me.DesProductoTextBox)
        Me.PanelCabecera.Controls.Add(Me.PictureBoxActivo)
        resources.ApplyResources(Me.PanelCabecera, "PanelCabecera")
        Me.PanelCabecera.Name = "PanelCabecera"
        '
        'tbxIdLinea
        '
        Me.tbxIdLinea.BackColor = System.Drawing.Color.LightGray
        Me.tbxIdLinea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIdLinea.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "CODRUBRO", True))
        resources.ApplyResources(Me.tbxIdLinea, "tbxIdLinea")
        Me.tbxIdLinea.ForeColor = System.Drawing.Color.White
        Me.tbxIdLinea.Name = "tbxIdLinea"
        Me.tbxIdLinea.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.BackColor = System.Drawing.Color.Transparent
        Me.lblActivo.ForeColor = System.Drawing.Color.OrangeRed
        resources.ApplyResources(Me.lblActivo, "lblActivo")
        Me.lblActivo.Name = "lblActivo"
        '
        'pbxSinImagen
        '
        resources.ApplyResources(Me.pbxSinImagen, "pbxSinImagen")
        Me.pbxSinImagen.Image = Global.ContaExpress.My.Resources.Resources.No_Tiene_Imagen
        Me.pbxSinImagen.Name = "pbxSinImagen"
        Me.pbxSinImagen.TabStop = False
        '
        'pbxImagen
        '
        Me.pbxImagen.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.PRODUCTOSBindingSource, "IMAGENPRODUCTO", True))
        resources.ApplyResources(Me.pbxImagen, "pbxImagen")
        Me.pbxImagen.Image = Global.ContaExpress.My.Resources.Resources.No_Tiene_Imagen
        Me.pbxImagen.Name = "pbxImagen"
        Me.pbxImagen.TabStop = False
        '
        'CategoriaComboBox
        '
        Me.CategoriaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CategoriaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CategoriaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CategoriaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODFAMILIA", True))
        Me.CategoriaComboBox.DataSource = Me.FAMILIABindingSource
        Me.CategoriaComboBox.DisplayMember = "DESFAMILIA"
        resources.ApplyResources(Me.CategoriaComboBox, "CategoriaComboBox")
        Me.CategoriaComboBox.FormattingEnabled = True
        Me.CategoriaComboBox.Name = "CategoriaComboBox"
        Me.CategoriaComboBox.ValueMember = "CODFAMILIA"
        '
        'LineaComboBox
        '
        Me.LineaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.LineaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.LineaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.LineaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODRUBRO", True))
        Me.LineaComboBox.DataSource = Me.RUBROBindingSource
        Me.LineaComboBox.DisplayMember = "DESRUBRO"
        resources.ApplyResources(Me.LineaComboBox, "LineaComboBox")
        Me.LineaComboBox.FormattingEnabled = True
        Me.LineaComboBox.Name = "LineaComboBox"
        Me.LineaComboBox.ValueMember = "CODRUBRO"
        '
        'MarcaComboBox
        '
        Me.MarcaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.MarcaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.MarcaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MarcaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODLINEA", True))
        Me.MarcaComboBox.DataSource = Me.LINEABindingSource
        Me.MarcaComboBox.DisplayMember = "DESLINEA"
        resources.ApplyResources(Me.MarcaComboBox, "MarcaComboBox")
        Me.MarcaComboBox.FormattingEnabled = True
        Me.MarcaComboBox.Name = "MarcaComboBox"
        Me.MarcaComboBox.ValueMember = "CODLINEA"
        '
        'tbxIdMarca
        '
        Me.tbxIdMarca.BackColor = System.Drawing.Color.LightGray
        Me.tbxIdMarca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIdMarca.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "CODLINEA", True))
        resources.ApplyResources(Me.tbxIdMarca, "tbxIdMarca")
        Me.tbxIdMarca.ForeColor = System.Drawing.Color.White
        Me.tbxIdMarca.Name = "tbxIdMarca"
        Me.tbxIdMarca.TabStop = False
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label19.Name = "Label19"
        '
        'tbxIdFamilia
        '
        Me.tbxIdFamilia.BackColor = System.Drawing.Color.LightGray
        Me.tbxIdFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIdFamilia.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "CODFAMILIA", True))
        resources.ApplyResources(Me.tbxIdFamilia, "tbxIdFamilia")
        Me.tbxIdFamilia.ForeColor = System.Drawing.Color.White
        Me.tbxIdFamilia.Name = "tbxIdFamilia"
        Me.tbxIdFamilia.TabStop = False
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label17.Name = "Label17"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label18.Name = "Label18"
        '
        'pbxLink
        '
        Me.pbxLink.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.pbxLink, "pbxLink")
        Me.pbxLink.Name = "pbxLink"
        Me.pbxLink.TabStop = False
        '
        'DesProductoTextBox
        '
        Me.DesProductoTextBox.AcceptsReturn = True
        Me.DesProductoTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DesProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesProductoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSBindingSource, "DESPRODUCTO", True))
        resources.ApplyResources(Me.DesProductoTextBox, "DesProductoTextBox")
        Me.DesProductoTextBox.Name = "DesProductoTextBox"
        '
        'pnlCostoProducto
        '
        resources.ApplyResources(Me.pnlCostoProducto, "pnlCostoProducto")
        Me.pnlCostoProducto.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.pnlCostoProducto.BackgroundImage = Global.ContaExpress.My.Resources.Resources.background_linen
        Me.pnlCostoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCostoProducto.Controls.Add(Me.Label31)
        Me.pnlCostoProducto.Controls.Add(Me.cmbTipoCosto)
        Me.pnlCostoProducto.Controls.Add(Me.lblSinIva)
        Me.pnlCostoProducto.Controls.Add(Me.lblUltimoCosto)
        Me.pnlCostoProducto.Controls.Add(Me.lblTituloUltMov)
        Me.pnlCostoProducto.Controls.Add(Me.Label29)
        Me.pnlCostoProducto.Controls.Add(Me.Label24)
        Me.pnlCostoProducto.Controls.Add(Me.Label28)
        Me.pnlCostoProducto.Controls.Add(Me.Label27)
        Me.pnlCostoProducto.Controls.Add(Me.txtPorcGanancia)
        Me.pnlCostoProducto.Controls.Add(Me.lblPrecioVenta)
        Me.pnlCostoProducto.Controls.Add(Me.Label25)
        Me.pnlCostoProducto.Controls.Add(Me.Label26)
        Me.pnlCostoProducto.Controls.Add(Me.lblCosto)
        Me.pnlCostoProducto.Controls.Add(Me.Label23)
        Me.pnlCostoProducto.Controls.Add(Me.Label22)
        Me.pnlCostoProducto.Name = "pnlCostoProducto"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label31.Name = "Label31"
        '
        'cmbTipoCosto
        '
        Me.cmbTipoCosto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbTipoCosto.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSBindingSource, "CODMEDIDA", True))
        Me.cmbTipoCosto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbTipoCosto, "cmbTipoCosto")
        Me.cmbTipoCosto.FormattingEnabled = True
        Me.cmbTipoCosto.Name = "cmbTipoCosto"
        '
        'lblSinIva
        '
        Me.lblSinIva.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.lblSinIva, "lblSinIva")
        Me.lblSinIva.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblSinIva.Name = "lblSinIva"
        '
        'lblUltimoCosto
        '
        resources.ApplyResources(Me.lblUltimoCosto, "lblUltimoCosto")
        Me.lblUltimoCosto.BackColor = System.Drawing.Color.Transparent
        Me.lblUltimoCosto.ForeColor = System.Drawing.Color.White
        Me.lblUltimoCosto.Name = "lblUltimoCosto"
        '
        'lblTituloUltMov
        '
        resources.ApplyResources(Me.lblTituloUltMov, "lblTituloUltMov")
        Me.lblTituloUltMov.BackColor = System.Drawing.Color.Transparent
        Me.lblTituloUltMov.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblTituloUltMov.Name = "lblTituloUltMov"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label29.Name = "Label29"
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label24.Name = "Label24"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label28.Name = "Label28"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label27.Name = "Label27"
        '
        'txtPorcGanancia
        '
        Me.txtPorcGanancia.AcceptsReturn = True
        Me.txtPorcGanancia.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtPorcGanancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtPorcGanancia, "txtPorcGanancia")
        Me.txtPorcGanancia.Name = "txtPorcGanancia"
        '
        'lblPrecioVenta
        '
        resources.ApplyResources(Me.lblPrecioVenta, "lblPrecioVenta")
        Me.lblPrecioVenta.BackColor = System.Drawing.Color.Transparent
        Me.lblPrecioVenta.ForeColor = System.Drawing.Color.White
        Me.lblPrecioVenta.Name = "lblPrecioVenta"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label25.Name = "Label25"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label26.Name = "Label26"
        '
        'lblCosto
        '
        resources.ApplyResources(Me.lblCosto, "lblCosto")
        Me.lblCosto.BackColor = System.Drawing.Color.Transparent
        Me.lblCosto.ForeColor = System.Drawing.Color.White
        Me.lblCosto.Name = "lblCosto"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label23.Name = "Label23"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label22.Name = "Label22"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOMARCATableAdapter
        '
        Me.PRODUCTOMARCATableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOEQUIPOTableAdapter
        '
        Me.PRODUCTOEQUIPOTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTO_EQUIPO_RELTableAdapter
        '
        Me.PRODUCTO_EQUIPO_RELTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOEQUIPORELSIMPLEBindingSource
        '
        Me.PRODUCTOEQUIPORELSIMPLEBindingSource.DataMember = "PRODUCTO_EQUIPO_REL_SIMPLE"
        Me.PRODUCTOEQUIPORELSIMPLEBindingSource.DataSource = Me.DsEquipoRelBindingSource
        '
        'PRODUCTO_EQUIPO_REL_SIMPLETableAdapter
        '
        Me.PRODUCTO_EQUIPO_REL_SIMPLETableAdapter.ClearBeforeFill = True
        '
        'Producto
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ProductosGridView)
        Me.Controls.Add(Me.CodProveedorTextBox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CodSubcategoriaTextBox)
        Me.Controls.Add(Me.CodCategoriaTextBox)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PanelCabecera)
        Me.Controls.Add(Me.PanelPrincipal)
        Me.Controls.Add(Me.pnlCostoProducto)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "Producto"
        Me.Opacity = 0.0R
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelPrincipal.PerformLayout()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PreciosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRECIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPesable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarListaPrecio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCodigoBarra.ResumeLayout(False)
        Me.pnlCodigoBarra.PerformLayout()
        CType(Me.AgregarCodigoButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarCodigoButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigosTradicionalGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GenerarCodButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarcodeString, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarCodigoButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarCodigoButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ElimPrecioButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AgregarPrecioButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetalles.ResumeLayout(False)
        Me.PanelDetalles.PerformLayout()
        CType(Me.pbxAgregarEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarMarca, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOMARCABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabEspecBal.ResumeLayout(False)
        Me.TabEspec.ResumeLayout(False)
        Me.TabEspec.PerformLayout()
        Me.TabBalanza.ResumeLayout(False)
        Me.TabBalanza.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.EquipoDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOEQUIPORELBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEquipoRelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEquipoRel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AddEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DelEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IVABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxStockInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarCategoriaProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEnPromocion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxModifica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PanelCabecera.ResumeLayout(False)
        Me.PanelCabecera.PerformLayout()
        CType(Me.pbxSinImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCostoProducto.ResumeLayout(False)
        Me.pnlCostoProducto.PerformLayout()
        CType(Me.PRODUCTOEQUIPORELSIMPLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtCodFamilia As System.Windows.Forms.TextBox
    Friend WithEvents TxtPesable As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TxtVencimiento As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents ProductosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CODPRODUCTODataGridView As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODESTADOPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDESCUENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCodigoBarra As System.Windows.Forms.Panel
    Friend WithEvents CodigosTradicionalGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DesCodigoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents CodigoBarraTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GenerarCodButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EliminarCodigoButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents ElimPrecioButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents AgregarPrecioButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents TipoClieComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PreciosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents PrecioTxtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents PRECIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRECIOTableAdapter As ContaExpress.DsProductosTableAdapters.PRECIOTableAdapter
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CancelarCodigoButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents ModificarCodigoButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents pbxAgregarListaPrecio As System.Windows.Forms.PictureBox
    Friend WithEvents IVABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IVATableAdapter As ContaExpress.DsProductosTableAdapters.IVATableAdapter


    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barProductos As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxStockInicial As System.Windows.Forms.PictureBox
    Friend WithEvents DsProductos1 As ContaExpress.DsProductos
    Friend WithEvents CODIGOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGOSTableAdapter As ContaExpress.DsProductosTableAdapters.CODIGOSTableAdapter
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AgregarCodigoButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents PanelDetalles As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents pbxAgregarMedida As System.Windows.Forms.PictureBox
    Friend WithEvents StockMinimoTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TipoProductoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TipoIVAComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MedidaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents StockMaximoTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents PanelCabecera As System.Windows.Forms.Panel
    Friend WithEvents tbxIdLinea As System.Windows.Forms.TextBox
    Friend WithEvents CategoriaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LineaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MarcaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents tbxIdMarca As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbxIdFamilia As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents pbxAgregarCategoriaProducto As System.Windows.Forms.PictureBox
    Friend WithEvents pbxLink As System.Windows.Forms.PictureBox
    Friend WithEvents DesProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pbxEnPromocion As System.Windows.Forms.PictureBox
    Friend WithEvents CODPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbxImagen As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCostoProducto As System.Windows.Forms.Panel
    Friend WithEvents lblTituloUltMov As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtPorcGanancia As System.Windows.Forms.TextBox
    Friend WithEvents lblPrecioVenta As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblCosto As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents lblUltimoCosto As System.Windows.Forms.Label
    Friend WithEvents TabEspecBal As System.Windows.Forms.TabControl
    Friend WithEvents TabEspec As System.Windows.Forms.TabPage
    Friend WithEvents tbxEspecificaciones As System.Windows.Forms.TextBox
    Friend WithEvents TabBalanza As System.Windows.Forms.TabPage
    Friend WithEvents CmbPesable As System.Windows.Forms.ComboBox
    Friend WithEvents CmbVencimiento As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChckBalanza As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pbxSinImagen As System.Windows.Forms.PictureBox
    Friend WithEvents lblCantCaracteres As System.Windows.Forms.Label
    Friend WithEvents PictureBoxActivo As System.Windows.Forms.PictureBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblSinIva As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoCosto As System.Windows.Forms.ComboBox
    Friend WithEvents lblAyudaEditarCod As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbxCant As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents lblAyudaCant As System.Windows.Forms.Label
    Friend WithEvents txtxcaja As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents CbxMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsProductosTableAdapters.MONEDATableAdapter
    Friend WithEvents CODTIPOCLIENTE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRECIO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCLIENTE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRECIOVENTA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoPrecio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cbxMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cbxEquipo As System.Windows.Forms.ComboBox
    Friend WithEvents PRODUCTOMARCABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOMARCATableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOMARCATableAdapter
    Friend WithEvents PRODUCTOEQUIPOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOEQUIPOTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOEQUIPOTableAdapter
    Friend WithEvents pbxAgregarEquipo As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAgregarMarca As System.Windows.Forms.PictureBox
    Friend WithEvents SERVICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMARCA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESPECIFICACIONES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMAGENPRODUCTO As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents CODCODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODVARIAN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODRUBRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODFAMILIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODLINEADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIVADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMEDIDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKMINIMODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKMAXIMODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAULTIMACOMPRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTOPRODUCIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESABLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENCIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BALANZADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROMOCION As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CODPRODUCTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents EquipoDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DsEquipoRelBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsEquipoRel As ContaExpress.DsEquipoRel
    Friend WithEvents AddEquipo As Telerik.WinControls.UI.RadButton
    Friend WithEvents DelEquipo As Telerik.WinControls.UI.RadButton
    Friend WithEvents PRODUCTOEQUIPORELBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTO_EQUIPO_RELTableAdapter As ContaExpress.DsEquipoRelTableAdapters.PRODUCTO_EQUIPO_RELTableAdapter
    Friend WithEvents IDPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTOEQUIPORELSIMPLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTO_EQUIPO_REL_SIMPLETableAdapter As ContaExpress.DsEquipoRelTableAdapters.PRODUCTO_EQUIPO_REL_SIMPLETableAdapter
    Friend WithEvents DESEQUIPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UbicacionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCalculo As System.Windows.Forms.Label

    #End Region 'Methods

End Class