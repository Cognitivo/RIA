<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class ABMBanco
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend  WithEvents AUDITORIATABLASBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents AUDITORIATABLASTableAdapter As ContaExpress.dsFacturacionTableAdapters.AUDITORIATABLASTableAdapter
    Friend  WithEvents BANCOBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents BANCOTableAdapter As ContaExpress.dsFacturacionTableAdapters.BANCOTableAdapter
    Friend  WithEvents btnEliminarBanco As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnEliminarCuenta As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnEliminarInstrumento As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnGuardarBanco As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnGuardarCuenta As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnGuardarInstrumento As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnInstrumentoVerClave As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnModificarBanco As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnModificarCuenta As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnModificarInstrumento As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnNuevoBanco As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnNuevoCuenta As Telerik.WinControls.UI.RadButton
    Friend  WithEvents btnNuevoInstrumento As Telerik.WinControls.UI.RadButton
    Friend  WithEvents cboCuentaMoneda As Telerik.WinControls.UI.RadComboBox
    Friend  WithEvents cboInstrumentoStatus As Telerik.WinControls.UI.RadComboBox
    Friend  WithEvents cboTipoCuenta As Telerik.WinControls.UI.RadComboBox
    Friend  WithEvents chkCuentaSobregiro As Telerik.WinControls.UI.RadCheckBox
    Friend  WithEvents CUENTABANCARIABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents CUENTABANCARIATableAdapter As ContaExpress.dsFacturacionTableAdapters.CUENTABANCARIATableAdapter
    Friend  WithEvents DsFacturacion As ContaExpress.dsFacturacion
    Friend  WithEvents grdBanco As Telerik.WinControls.UI.RadGridView
    Friend  WithEvents grdCuenta As Telerik.WinControls.UI.RadGridView
    Friend  WithEvents grdInstrumento As Telerik.WinControls.UI.RadGridView
    Friend  WithEvents INSTRUMENTOBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents INSTRUMENTOTableAdapter As ContaExpress.dsFacturacionTableAdapters.INSTRUMENTOTableAdapter
    Friend  WithEvents Label1 As System.Windows.Forms.Label
    Friend  WithEvents Label11 As System.Windows.Forms.Label
    Friend  WithEvents Label12 As System.Windows.Forms.Label
    Friend  WithEvents Label13 As System.Windows.Forms.Label
    Friend  WithEvents Label14 As System.Windows.Forms.Label
    Friend  WithEvents Label15 As System.Windows.Forms.Label
    Friend  WithEvents Label18 As System.Windows.Forms.Label
    Friend  WithEvents Label19 As System.Windows.Forms.Label
    Friend  WithEvents Label2 As System.Windows.Forms.Label
    Friend  WithEvents Label20 As System.Windows.Forms.Label
    Friend  WithEvents Label21 As System.Windows.Forms.Label
    Friend  WithEvents Label22 As System.Windows.Forms.Label
    Friend  WithEvents Label25 As System.Windows.Forms.Label
    Friend  WithEvents Label3 As System.Windows.Forms.Label
    Friend  WithEvents Label4 As System.Windows.Forms.Label
    Friend  WithEvents Label5 As System.Windows.Forms.Label
    Friend  WithEvents Label6 As System.Windows.Forms.Label
    Friend  WithEvents Label7 As System.Windows.Forms.Label
    Friend  WithEvents Label9 As System.Windows.Forms.Label
    Friend  WithEvents lbcancelar As System.Windows.Forms.Label
    Friend  WithEvents lbeliminar As System.Windows.Forms.Label
    Friend  WithEvents lbguardar As System.Windows.Forms.Label
    Friend  WithEvents lbnuevo As System.Windows.Forms.Label
    Friend  WithEvents lb_mensaje As System.Windows.Forms.Label
    Friend  WithEvents MONEDASINFILTROBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents MONEDASINFILTROTableAdapter As ContaExpress.dsFacturacionTableAdapters.MONEDASINFILTROTableAdapter
    Friend  WithEvents Panel3 As System.Windows.Forms.Panel
    Friend  WithEvents Panel5 As System.Windows.Forms.Panel
    Friend  WithEvents pbxAbierto As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxCancelarGris As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxCerrado As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend  WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend  WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend  WithEvents RadContextMenuManager1 As Telerik.WinControls.UI.RadContextMenuManager
    Friend  WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox3 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox5 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadPanel1 As Telerik.WinControls.UI.RadPanel
    Friend  WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend  WithEvents RadPanel3 As Telerik.WinControls.UI.RadPanel
    Friend  WithEvents TableAdapterManager As ContaExpress.dsFacturacionTableAdapters.TableAdapterManager
    Friend  WithEvents TextBoxEstatus As System.Windows.Forms.TextBox
    Friend  WithEvents TIPOCUENTABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents TIPOCUENTATableAdapter As ContaExpress.dsFacturacionTableAdapters.TIPOCUENTATableAdapter
    Friend  WithEvents txtBanco As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBancoAgente As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBancoDireccion As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBancoEmail As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBancoSucursal As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBancoTelefono As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtBuscarBanco As System.Windows.Forms.TextBox
    Friend  WithEvents txtBuscarCuenta As System.Windows.Forms.TextBox
    Friend  WithEvents txtBuscarInstrumento As System.Windows.Forms.TextBox
    Friend  WithEvents txtCodBanco As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtCodInstrumento As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtCuentaDescripcion As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtCuentaInteres As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend  WithEvents txtCuentaLimite As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend  WithEvents txtInstrumentoClave As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtInstrumentoDescripcion As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtInstrumentoFirma As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtInstrumentoStatus As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtInstrumentoTipo As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtInstrumentoUsuario As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNumCuenta As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents VENTASFORMACOBROTableAdapter As ContaExpress.dsFacturacionTableAdapters.VENTASFORMACOBROTableAdapter

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    #End Region 'Fields

    #Region "Methods"

    'Form overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridSortField1 As Telerik.WinControls.UI.GridSortField = New Telerik.WinControls.UI.GridSortField()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn8 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn9 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn10 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn11 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn12 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn13 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn2 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn14 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn3 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn15 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn16 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMBanco))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.grdBanco = New Telerik.WinControls.UI.RadGridView()
        Me.BANCOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFacturacion = New ContaExpress.dsFacturacion()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtBuscarInstrumento = New System.Windows.Forms.TextBox()
        Me.txtBuscarCuenta = New System.Windows.Forms.TextBox()
        Me.txtBuscarBanco = New System.Windows.Forms.TextBox()
        Me.RadGroupBox5 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdInstrumento = New Telerik.WinControls.UI.RadGridView()
        Me.INSTRUMENTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CUENTABANCARIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.grdCuenta = New Telerik.WinControls.UI.RadGridView()
        Me.RadGroupBox3 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnNuevoInstrumento = New Telerik.WinControls.UI.RadButton()
        Me.btnNuevoCuenta = New Telerik.WinControls.UI.RadButton()
        Me.btnNuevoBanco = New Telerik.WinControls.UI.RadButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.btnGuardarCuenta = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel3 = New Telerik.WinControls.UI.RadPanel()
        Me.cboInstrumentoStatus = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.TextBoxEstatus = New System.Windows.Forms.TextBox()
        Me.btnEliminarInstrumento = New Telerik.WinControls.UI.RadButton()
        Me.btnInstrumentoVerClave = New Telerik.WinControls.UI.RadButton()
        Me.txtInstrumentoTipo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInstrumentoDescripcion = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInstrumentoUsuario = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInstrumentoFirma = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInstrumentoClave = New Telerik.WinControls.UI.RadTextBox()
        Me.btnGuardarInstrumento = New Telerik.WinControls.UI.RadButton()
        Me.btnModificarInstrumento = New Telerik.WinControls.UI.RadButton()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.txtCuentaLimite = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.txtCuentaInteres = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.cboTipoCuenta = New Telerik.WinControls.UI.RadComboBox()
        Me.TIPOCUENTABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnEliminarCuenta = New Telerik.WinControls.UI.RadButton()
        Me.cboCuentaMoneda = New Telerik.WinControls.UI.RadComboBox()
        Me.MONEDASINFILTROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnModificarCuenta = New Telerik.WinControls.UI.RadButton()
        Me.txtNumCuenta = New Telerik.WinControls.UI.RadTextBox()
        Me.chkCuentaSobregiro = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtCuentaDescripcion = New Telerik.WinControls.UI.RadTextBox()
        Me.RadPanel1 = New Telerik.WinControls.UI.RadPanel()
        Me.btnEliminarBanco = New Telerik.WinControls.UI.RadButton()
        Me.txtBancoDireccion = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBancoEmail = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBancoTelefono = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBancoSucursal = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBancoAgente = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBanco = New Telerik.WinControls.UI.RadTextBox()
        Me.btnGuardarBanco = New Telerik.WinControls.UI.RadButton()
        Me.btnModificarBanco = New Telerik.WinControls.UI.RadButton()
        Me.RadContextMenuManager1 = New Telerik.WinControls.UI.RadContextMenuManager()
        Me.txtCodBanco = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodInstrumento = New Telerik.WinControls.UI.RadTextBox()
        Me.txtInstrumentoStatus = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxCerrado = New System.Windows.Forms.PictureBox()
        Me.pbxAbierto = New System.Windows.Forms.PictureBox()
        Me.pbxCancelarGris = New System.Windows.Forms.PictureBox()
        Me.BANCOTableAdapter = New ContaExpress.dsFacturacionTableAdapters.BANCOTableAdapter()
        Me.CUENTABANCARIATableAdapter = New ContaExpress.dsFacturacionTableAdapters.CUENTABANCARIATableAdapter()
        Me.INSTRUMENTOTableAdapter = New ContaExpress.dsFacturacionTableAdapters.INSTRUMENTOTableAdapter()
        Me.VENTASFORMACOBROTableAdapter = New ContaExpress.dsFacturacionTableAdapters.VENTASFORMACOBROTableAdapter()
        Me.TIPOCUENTATableAdapter = New ContaExpress.dsFacturacionTableAdapters.TIPOCUENTATableAdapter()
        Me.MONEDASINFILTROTableAdapter = New ContaExpress.dsFacturacionTableAdapters.MONEDASINFILTROTableAdapter()
        Me.AUDITORIATABLASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AUDITORIATABLASTableAdapter = New ContaExpress.dsFacturacionTableAdapters.AUDITORIATABLASTableAdapter()
        Me.TableAdapterManager = New ContaExpress.dsFacturacionTableAdapters.TableAdapterManager()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lb_mensaje = New System.Windows.Forms.Label()
        Me.lbguardar = New System.Windows.Forms.Label()
        Me.lbcancelar = New System.Windows.Forms.Label()
        Me.lbnuevo = New System.Windows.Forms.Label()
        Me.lbeliminar = New System.Windows.Forms.Label()
        CType(Me.grdBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BANCOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox5.SuspendLayout()
        CType(Me.grdInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.INSTRUMENTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUENTABANCARIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.grdCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox3.SuspendLayout()
        CType(Me.btnNuevoInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNuevoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNuevoBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.btnGuardarCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel3.SuspendLayout()
        CType(Me.cboInstrumentoStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminarInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnInstrumentoVerClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoTipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoClave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardarInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnModificarInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel2.SuspendLayout()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCUENTABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEliminarCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuentaMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDASINFILTROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnModificarCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkCuentaSobregiro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel1.SuspendLayout()
        CType(Me.btnEliminarBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBancoAgente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGuardarBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnModificarBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodInstrumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstrumentoStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCerrado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAbierto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelarGris, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Lavender
        Me.Label1.Location = New System.Drawing.Point(15, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 381
        Me.Label1.Text = "Banco:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Lavender
        Me.Label2.Location = New System.Drawing.Point(5, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 14)
        Me.Label2.TabIndex = 383
        Me.Label2.Text = "Sucursal:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Lavender
        Me.Label3.Location = New System.Drawing.Point(12, 102)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 14)
        Me.Label3.TabIndex = 383
        Me.Label3.Text = "Agente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Lavender
        Me.Label4.Location = New System.Drawing.Point(4, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 383
        Me.Label4.Text = "Teléfono:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Lavender
        Me.Label5.Location = New System.Drawing.Point(21, 145)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 14)
        Me.Label5.TabIndex = 383
        Me.Label5.Text = "Email:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Lavender
        Me.Label7.Location = New System.Drawing.Point(1, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 14)
        Me.Label7.TabIndex = 383
        Me.Label7.Text = "Dirección:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Lavender
        Me.Label9.Location = New System.Drawing.Point(3, 60)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 14)
        Me.Label9.TabIndex = 381
        Me.Label9.Text = "Descripción:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Lavender
        Me.Label11.Location = New System.Drawing.Point(1, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 14)
        Me.Label11.TabIndex = 383
        Me.Label11.Text = "Tipo Cuenta:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Lavender
        Me.Label12.Location = New System.Drawing.Point(20, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 14)
        Me.Label12.TabIndex = 383
        Me.Label12.Text = "Moneda:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Lavender
        Me.Label13.Location = New System.Drawing.Point(10, 121)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 14)
        Me.Label13.TabIndex = 383
        Me.Label13.Text = "Sobregiro:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Lavender
        Me.Label14.Location = New System.Drawing.Point(24, 163)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 14)
        Me.Label14.TabIndex = 383
        Me.Label14.Text = "Interes:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Lavender
        Me.Label15.Location = New System.Drawing.Point(30, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 14)
        Me.Label15.TabIndex = 383
        Me.Label15.Text = "Límite:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Lavender
        Me.Label18.Location = New System.Drawing.Point(2, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 14)
        Me.Label18.TabIndex = 381
        Me.Label18.Text = "Descripción:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Lavender
        Me.Label19.Location = New System.Drawing.Point(37, 60)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(30, 14)
        Me.Label19.TabIndex = 383
        Me.Label19.Text = "Tipo:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Lavender
        Me.Label20.Location = New System.Drawing.Point(22, 102)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(47, 14)
        Me.Label20.TabIndex = 383
        Me.Label20.Text = "Usuario:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Lavender
        Me.Label21.Location = New System.Drawing.Point(33, 124)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 14)
        Me.Label21.TabIndex = 383
        Me.Label21.Text = "Firma:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Lavender
        Me.Label22.Location = New System.Drawing.Point(4, 145)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 14)
        Me.Label22.TabIndex = 383
        Me.Label22.Text = "Clave (PIN):"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Lavender
        Me.Label25.Location = New System.Drawing.Point(28, 82)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(41, 14)
        Me.Label25.TabIndex = 383
        Me.Label25.Text = "Status:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Lavender
        Me.Label6.Location = New System.Drawing.Point(5, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 14)
        Me.Label6.TabIndex = 381
        Me.Label6.Text = "Cuenta Nro:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdBanco
        '
        Me.grdBanco.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBanco.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdBanco.EnableAlternatingRowColor = True
        Me.grdBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdBanco.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdBanco.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdBanco.Location = New System.Drawing.Point(3, 18)
        '
        '
        '
        Me.grdBanco.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdBanco.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODBANCO"
        GridViewDecimalColumn1.FieldName = "CODBANCO"
        GridViewDecimalColumn1.HeaderText = "CODBANCO"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODBANCO"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn2.FieldName = "CODUSUARIO"
        GridViewDecimalColumn2.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn3.FieldName = "CODEMPRESA"
        GridViewDecimalColumn3.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODEMPRESA"
        GridViewTextBoxColumn1.FieldAlias = "NUMBANCO"
        GridViewTextBoxColumn1.FieldName = "NUMBANCO"
        GridViewTextBoxColumn1.HeaderText = "NUMBANCO"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.UniqueName = "NUMBANCO"
        GridViewTextBoxColumn2.FieldAlias = "DESBANCO"
        GridViewTextBoxColumn2.FieldName = "DESBANCO"
        GridViewTextBoxColumn2.HeaderText = "DESBANCO"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending
        GridViewTextBoxColumn2.UniqueName = "DESBANCO"
        GridViewTextBoxColumn2.Width = 195
        GridViewTextBoxColumn3.FieldAlias = "DIRECCION"
        GridViewTextBoxColumn3.FieldName = "DIRECCION"
        GridViewTextBoxColumn3.HeaderText = "DIRECCION"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.UniqueName = "DIRECCION"
        GridViewTextBoxColumn4.FieldAlias = "TELEFONO"
        GridViewTextBoxColumn4.FieldName = "TELEFONO"
        GridViewTextBoxColumn4.HeaderText = "TELEFONO"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.UniqueName = "TELEFONO"
        GridViewTextBoxColumn5.FieldAlias = "WEB"
        GridViewTextBoxColumn5.FieldName = "WEB"
        GridViewTextBoxColumn5.HeaderText = "WEB"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.IsVisible = False
        GridViewTextBoxColumn5.UniqueName = "WEB"
        GridViewTextBoxColumn6.FieldAlias = "EMAIL"
        GridViewTextBoxColumn6.FieldName = "EMAIL"
        GridViewTextBoxColumn6.HeaderText = "EMAIL"
        GridViewTextBoxColumn6.IsAutoGenerated = True
        GridViewTextBoxColumn6.IsVisible = False
        GridViewTextBoxColumn6.UniqueName = "EMAIL"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn4)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn5)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn6)
        Me.grdBanco.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.grdBanco.MasterGridViewTemplate.DataSource = Me.BANCOBindingSource
        Me.grdBanco.MasterGridViewTemplate.EnableFiltering = True
        Me.grdBanco.MasterGridViewTemplate.EnableGrouping = False
        Me.grdBanco.MasterGridViewTemplate.ShowColumnHeaders = False
        Me.grdBanco.MasterGridViewTemplate.ShowFilteringRow = False
        Me.grdBanco.MasterGridViewTemplate.ShowRowHeaderColumn = False
        GridSortField1.FieldAlias = "DESBANCO"
        GridSortField1.FieldName = "DESBANCO"
        GridSortField1.SortOrder = Telerik.WinControls.UI.RadSortOrder.Descending
        Me.grdBanco.MasterGridViewTemplate.SortExpressions.Add(GridSortField1)
        Me.grdBanco.Name = "grdBanco"
        Me.grdBanco.ReadOnly = True
        Me.grdBanco.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdBanco.ShowGroupPanel = False
        Me.grdBanco.Size = New System.Drawing.Size(199, 131)
        Me.grdBanco.TabIndex = 359
        '
        'BANCOBindingSource
        '
        Me.BANCOBindingSource.DataMember = "BANCO"
        Me.BANCOBindingSource.DataSource = Me.DsFacturacion
        '
        'DsFacturacion
        '
        Me.DsFacturacion.DataSetName = "dsFacturacion"
        Me.DsFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox2.Controls.Add(Me.txtBuscarInstrumento)
        Me.RadGroupBox2.Controls.Add(Me.txtBuscarCuenta)
        Me.RadGroupBox2.Controls.Add(Me.txtBuscarBanco)
        Me.RadGroupBox2.Controls.Add(Me.RadGroupBox5)
        Me.RadGroupBox2.Controls.Add(Me.RadGroupBox4)
        Me.RadGroupBox2.Controls.Add(Me.RadGroupBox3)
        Me.RadGroupBox2.Controls.Add(Me.btnNuevoInstrumento)
        Me.RadGroupBox2.Controls.Add(Me.btnNuevoCuenta)
        Me.RadGroupBox2.Controls.Add(Me.btnNuevoBanco)
        Me.RadGroupBox2.Controls.Add(Me.PictureBox1)
        Me.RadGroupBox2.Controls.Add(Me.PictureBox2)
        Me.RadGroupBox2.Controls.Add(Me.PictureBox3)
        Me.RadGroupBox2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = "Listado"
        Me.RadGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox2.Location = New System.Drawing.Point(12, 97)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(679, 211)
        Me.RadGroupBox2.TabIndex = 394
        Me.RadGroupBox2.Text = "Listado"
        Me.RadGroupBox2.ThemeName = "Breeze"
        CType(Me.RadGroupBox2.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'txtBuscarInstrumento
        '
        Me.txtBuscarInstrumento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscarInstrumento.CausesValidation = False
        Me.txtBuscarInstrumento.Location = New System.Drawing.Point(487, 33)
        Me.txtBuscarInstrumento.Name = "txtBuscarInstrumento"
        Me.txtBuscarInstrumento.Size = New System.Drawing.Size(119, 13)
        Me.txtBuscarInstrumento.TabIndex = 401
        Me.txtBuscarInstrumento.Text = "Buscar..."
        '
        'txtBuscarCuenta
        '
        Me.txtBuscarCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscarCuenta.CausesValidation = False
        Me.txtBuscarCuenta.Location = New System.Drawing.Point(269, 33)
        Me.txtBuscarCuenta.Name = "txtBuscarCuenta"
        Me.txtBuscarCuenta.Size = New System.Drawing.Size(119, 13)
        Me.txtBuscarCuenta.TabIndex = 401
        Me.txtBuscarCuenta.Text = "Buscar..."
        '
        'txtBuscarBanco
        '
        Me.txtBuscarBanco.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscarBanco.CausesValidation = False
        Me.txtBuscarBanco.Location = New System.Drawing.Point(42, 33)
        Me.txtBuscarBanco.Name = "txtBuscarBanco"
        Me.txtBuscarBanco.Size = New System.Drawing.Size(119, 13)
        Me.txtBuscarBanco.TabIndex = 401
        Me.txtBuscarBanco.Text = "Buscar..."
        '
        'RadGroupBox5
        '
        Me.RadGroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox5.Controls.Add(Me.grdInstrumento)
        Me.RadGroupBox5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox5.FooterImageIndex = -1
        Me.RadGroupBox5.FooterImageKey = ""
        Me.RadGroupBox5.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox5.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox5.HeaderImageIndex = -1
        Me.RadGroupBox5.HeaderImageKey = ""
        Me.RadGroupBox5.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox5.HeaderText = "Instrumento"
        Me.RadGroupBox5.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox5.Location = New System.Drawing.Point(458, 56)
        Me.RadGroupBox5.Name = "RadGroupBox5"
        Me.RadGroupBox5.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox5.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox5.Size = New System.Drawing.Size(206, 152)
        Me.RadGroupBox5.TabIndex = 398
        Me.RadGroupBox5.Text = "Instrumento"
        Me.RadGroupBox5.ThemeName = "Breeze"
        CType(Me.RadGroupBox5.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox5.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox5.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox5.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'grdInstrumento
        '
        Me.grdInstrumento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdInstrumento.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdInstrumento.EnableAlternatingRowColor = True
        Me.grdInstrumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdInstrumento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdInstrumento.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdInstrumento.Location = New System.Drawing.Point(3, 18)
        '
        '
        '
        Me.grdInstrumento.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdInstrumento.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn4.DataType = GetType(Integer)
        GridViewDecimalColumn4.FieldAlias = "CODINSTRUMENTO"
        GridViewDecimalColumn4.FieldName = "CODINSTRUMENTO"
        GridViewDecimalColumn4.HeaderText = "CODINSTRUMENTO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODINSTRUMENTO"
        GridViewTextBoxColumn7.FieldAlias = "NUMCUENTA"
        GridViewTextBoxColumn7.FieldName = "NUMCUENTA"
        GridViewTextBoxColumn7.HeaderText = "NUMCUENTA"
        GridViewTextBoxColumn7.IsAutoGenerated = True
        GridViewTextBoxColumn7.IsVisible = False
        GridViewTextBoxColumn7.UniqueName = "NUMCUENTA"
        GridViewDecimalColumn5.DataType = GetType(Decimal)
        GridViewDecimalColumn5.FieldAlias = "CODBANCO"
        GridViewDecimalColumn5.FieldName = "CODBANCO"
        GridViewDecimalColumn5.HeaderText = "CODBANCO"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "CODBANCO"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn6.FieldName = "CODUSUARIO"
        GridViewDecimalColumn6.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn7.DataType = GetType(Decimal)
        GridViewDecimalColumn7.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn7.FieldName = "CODEMPRESA"
        GridViewDecimalColumn7.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.UniqueName = "CODEMPRESA"
        GridViewTextBoxColumn8.FieldAlias = "DESCRIPCION"
        GridViewTextBoxColumn8.FieldName = "DESCRIPCION"
        GridViewTextBoxColumn8.HeaderText = "DESCRIPCION"
        GridViewTextBoxColumn8.IsAutoGenerated = True
        GridViewTextBoxColumn8.UniqueName = "DESCRIPCION"
        GridViewTextBoxColumn8.Width = 195
        GridViewTextBoxColumn9.FieldAlias = "TIPOINTRUMENTO"
        GridViewTextBoxColumn9.FieldName = "TIPOINTRUMENTO"
        GridViewTextBoxColumn9.HeaderText = "TIPOINTRUMENTO"
        GridViewTextBoxColumn9.IsAutoGenerated = True
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.UniqueName = "TIPOINTRUMENTO"
        GridViewDecimalColumn8.DataType = GetType(Integer)
        GridViewDecimalColumn8.FieldAlias = "STATUS"
        GridViewDecimalColumn8.FieldName = "STATUS"
        GridViewDecimalColumn8.HeaderText = "STATUS"
        GridViewDecimalColumn8.IsAutoGenerated = True
        GridViewDecimalColumn8.IsVisible = False
        GridViewDecimalColumn8.UniqueName = "STATUS"
        GridViewTextBoxColumn10.FieldAlias = "USUARIO"
        GridViewTextBoxColumn10.FieldName = "USUARIO"
        GridViewTextBoxColumn10.HeaderText = "USUARIO"
        GridViewTextBoxColumn10.IsAutoGenerated = True
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.UniqueName = "USUARIO"
        GridViewTextBoxColumn11.FieldAlias = "FIRMA"
        GridViewTextBoxColumn11.FieldName = "FIRMA"
        GridViewTextBoxColumn11.HeaderText = "FIRMA"
        GridViewTextBoxColumn11.IsAutoGenerated = True
        GridViewTextBoxColumn11.IsVisible = False
        GridViewTextBoxColumn11.UniqueName = "FIRMA"
        GridViewTextBoxColumn12.FieldAlias = "CLAVE"
        GridViewTextBoxColumn12.FieldName = "CLAVE"
        GridViewTextBoxColumn12.HeaderText = "CLAVE"
        GridViewTextBoxColumn12.IsAutoGenerated = True
        GridViewTextBoxColumn12.IsVisible = False
        GridViewTextBoxColumn12.UniqueName = "CLAVE"
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn7)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn7)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn8)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn9)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn8)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn10)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn11)
        Me.grdInstrumento.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn12)
        Me.grdInstrumento.MasterGridViewTemplate.DataSource = Me.INSTRUMENTOBindingSource
        Me.grdInstrumento.MasterGridViewTemplate.EnableFiltering = True
        Me.grdInstrumento.MasterGridViewTemplate.EnableGrouping = False
        Me.grdInstrumento.MasterGridViewTemplate.ShowColumnHeaders = False
        Me.grdInstrumento.MasterGridViewTemplate.ShowFilteringRow = False
        Me.grdInstrumento.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.grdInstrumento.Name = "grdInstrumento"
        Me.grdInstrumento.ReadOnly = True
        Me.grdInstrumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdInstrumento.ShowGroupPanel = False
        Me.grdInstrumento.Size = New System.Drawing.Size(200, 131)
        Me.grdInstrumento.TabIndex = 359
        '
        'INSTRUMENTOBindingSource
        '
        Me.INSTRUMENTOBindingSource.DataMember = "FK_INSTRUMENTO_CUENTABANCARIA"
        Me.INSTRUMENTOBindingSource.DataSource = Me.CUENTABANCARIABindingSource
        '
        'CUENTABANCARIABindingSource
        '
        Me.CUENTABANCARIABindingSource.DataMember = "FK_CUENTABANCARIA_BANCO"
        Me.CUENTABANCARIABindingSource.DataSource = Me.BANCOBindingSource
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox4.Controls.Add(Me.grdCuenta)
        Me.RadGroupBox4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox4.FooterImageIndex = -1
        Me.RadGroupBox4.FooterImageKey = ""
        Me.RadGroupBox4.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox4.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox4.HeaderImageIndex = -1
        Me.RadGroupBox4.HeaderImageKey = ""
        Me.RadGroupBox4.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox4.HeaderText = "Cuenta"
        Me.RadGroupBox4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox4.Location = New System.Drawing.Point(236, 56)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox4.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox4.Size = New System.Drawing.Size(206, 152)
        Me.RadGroupBox4.TabIndex = 397
        Me.RadGroupBox4.Text = "Cuenta"
        Me.RadGroupBox4.ThemeName = "Breeze"
        CType(Me.RadGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'grdCuenta
        '
        Me.grdCuenta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdCuenta.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdCuenta.EnableAlternatingRowColor = True
        Me.grdCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdCuenta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCuenta.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdCuenta.Location = New System.Drawing.Point(3, 18)
        '
        '
        '
        Me.grdCuenta.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdCuenta.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn13.FieldAlias = "NUMCUENTA"
        GridViewTextBoxColumn13.FieldName = "NUMCUENTA"
        GridViewTextBoxColumn13.HeaderText = "NUMCUENTA"
        GridViewTextBoxColumn13.IsAutoGenerated = True
        GridViewTextBoxColumn13.IsVisible = False
        GridViewTextBoxColumn13.UniqueName = "NUMCUENTA"
        GridViewDecimalColumn9.DataType = GetType(Decimal)
        GridViewDecimalColumn9.FieldAlias = "CODTIPOCUENTA"
        GridViewDecimalColumn9.FieldName = "CODTIPOCUENTA"
        GridViewDecimalColumn9.HeaderText = "CODTIPOCUENTA"
        GridViewDecimalColumn9.IsAutoGenerated = True
        GridViewDecimalColumn9.IsVisible = False
        GridViewDecimalColumn9.UniqueName = "CODTIPOCUENTA"
        GridViewDecimalColumn10.DataType = GetType(Decimal)
        GridViewDecimalColumn10.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn10.FieldName = "CODUSUARIO"
        GridViewDecimalColumn10.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn10.IsAutoGenerated = True
        GridViewDecimalColumn10.IsVisible = False
        GridViewDecimalColumn10.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn11.DataType = GetType(Decimal)
        GridViewDecimalColumn11.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn11.FieldName = "CODEMPRESA"
        GridViewDecimalColumn11.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn11.IsAutoGenerated = True
        GridViewDecimalColumn11.IsVisible = False
        GridViewDecimalColumn11.UniqueName = "CODEMPRESA"
        GridViewDecimalColumn12.DataType = GetType(Decimal)
        GridViewDecimalColumn12.FieldAlias = "CODMONEDA"
        GridViewDecimalColumn12.FieldName = "CODMONEDA"
        GridViewDecimalColumn12.HeaderText = "CODMONEDA"
        GridViewDecimalColumn12.IsAutoGenerated = True
        GridViewDecimalColumn12.IsVisible = False
        GridViewDecimalColumn12.UniqueName = "CODMONEDA"
        GridViewDecimalColumn13.DataType = GetType(Decimal)
        GridViewDecimalColumn13.FieldAlias = "CODBANCO"
        GridViewDecimalColumn13.FieldName = "CODBANCO"
        GridViewDecimalColumn13.HeaderText = "CODBANCO"
        GridViewDecimalColumn13.IsAutoGenerated = True
        GridViewDecimalColumn13.IsVisible = False
        GridViewDecimalColumn13.UniqueName = "CODBANCO"
        GridViewTextBoxColumn14.FieldAlias = "DESCRIPCION"
        GridViewTextBoxColumn14.FieldName = "DESCRIPCION"
        GridViewTextBoxColumn14.HeaderText = "DESCRIPCION"
        GridViewTextBoxColumn14.IsAutoGenerated = True
        GridViewTextBoxColumn14.UniqueName = "DESCRIPCION"
        GridViewTextBoxColumn14.Width = 195
        GridViewDateTimeColumn2.DataType = GetType(Date)
        GridViewDateTimeColumn2.FieldAlias = "FECHAAPERTURA"
        GridViewDateTimeColumn2.FieldName = "FECHAAPERTURA"
        GridViewDateTimeColumn2.HeaderText = "FECHAAPERTURA"
        GridViewDateTimeColumn2.IsAutoGenerated = True
        GridViewDateTimeColumn2.IsVisible = False
        GridViewDateTimeColumn2.UniqueName = "FECHAAPERTURA"
        GridViewDecimalColumn14.DataType = GetType(Decimal)
        GridViewDecimalColumn14.FieldAlias = "LIMITECREDITO"
        GridViewDecimalColumn14.FieldName = "LIMITECREDITO"
        GridViewDecimalColumn14.HeaderText = "LIMITECREDITO"
        GridViewDecimalColumn14.IsAutoGenerated = True
        GridViewDecimalColumn14.IsVisible = False
        GridViewDecimalColumn14.UniqueName = "LIMITECREDITO"
        GridViewDateTimeColumn3.DataType = GetType(Date)
        GridViewDateTimeColumn3.FieldAlias = "FECGRA"
        GridViewDateTimeColumn3.FieldName = "FECGRA"
        GridViewDateTimeColumn3.HeaderText = "FECGRA"
        GridViewDateTimeColumn3.IsAutoGenerated = True
        GridViewDateTimeColumn3.IsVisible = False
        GridViewDateTimeColumn3.UniqueName = "FECGRA"
        GridViewDecimalColumn15.DataType = GetType(Integer)
        GridViewDecimalColumn15.FieldAlias = "SOBREGIRO"
        GridViewDecimalColumn15.FieldName = "SOBREGIRO"
        GridViewDecimalColumn15.HeaderText = "SOBREGIRO"
        GridViewDecimalColumn15.IsAutoGenerated = True
        GridViewDecimalColumn15.IsVisible = False
        GridViewDecimalColumn15.UniqueName = "SOBREGIRO"
        GridViewDecimalColumn16.DataType = GetType(Decimal)
        GridViewDecimalColumn16.FieldAlias = "INTERES"
        GridViewDecimalColumn16.FieldName = "INTERES"
        GridViewDecimalColumn16.HeaderText = "INTERES"
        GridViewDecimalColumn16.IsAutoGenerated = True
        GridViewDecimalColumn16.IsVisible = False
        GridViewDecimalColumn16.UniqueName = "INTERES"
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn13)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn9)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn10)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn11)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn12)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn13)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn14)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn2)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn14)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn3)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn15)
        Me.grdCuenta.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn16)
        Me.grdCuenta.MasterGridViewTemplate.DataSource = Me.CUENTABANCARIABindingSource
        Me.grdCuenta.MasterGridViewTemplate.EnableFiltering = True
        Me.grdCuenta.MasterGridViewTemplate.EnableGrouping = False
        Me.grdCuenta.MasterGridViewTemplate.ShowColumnHeaders = False
        Me.grdCuenta.MasterGridViewTemplate.ShowFilteringRow = False
        Me.grdCuenta.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.grdCuenta.Name = "grdCuenta"
        Me.grdCuenta.ReadOnly = True
        Me.grdCuenta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdCuenta.ShowGroupPanel = False
        Me.grdCuenta.Size = New System.Drawing.Size(200, 131)
        Me.grdCuenta.TabIndex = 359
        '
        'RadGroupBox3
        '
        Me.RadGroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox3.Controls.Add(Me.grdBanco)
        Me.RadGroupBox3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox3.FooterImageIndex = -1
        Me.RadGroupBox3.FooterImageKey = ""
        Me.RadGroupBox3.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox3.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office
        Me.RadGroupBox3.HeaderImageIndex = -1
        Me.RadGroupBox3.HeaderImageKey = ""
        Me.RadGroupBox3.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox3.HeaderText = "Banco"
        Me.RadGroupBox3.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox3.Location = New System.Drawing.Point(14, 56)
        Me.RadGroupBox3.Name = "RadGroupBox3"
        Me.RadGroupBox3.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox3.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox3.Size = New System.Drawing.Size(206, 152)
        Me.RadGroupBox3.TabIndex = 396
        Me.RadGroupBox3.Text = "Banco"
        Me.RadGroupBox3.ThemeName = "Breeze"
        CType(Me.RadGroupBox3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox3.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'btnNuevoInstrumento
        '
        Me.btnNuevoInstrumento.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoInstrumento.Location = New System.Drawing.Point(616, 25)
        Me.btnNuevoInstrumento.Name = "btnNuevoInstrumento"
        Me.btnNuevoInstrumento.Size = New System.Drawing.Size(48, 29)
        Me.btnNuevoInstrumento.TabIndex = 386
        Me.btnNuevoInstrumento.Text = "Nuevo"
        Me.btnNuevoInstrumento.ThemeName = "ControlDefault"
        '
        'btnNuevoCuenta
        '
        Me.btnNuevoCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoCuenta.Location = New System.Drawing.Point(394, 25)
        Me.btnNuevoCuenta.Name = "btnNuevoCuenta"
        Me.btnNuevoCuenta.Size = New System.Drawing.Size(48, 29)
        Me.btnNuevoCuenta.TabIndex = 386
        Me.btnNuevoCuenta.Text = "Nuevo"
        Me.btnNuevoCuenta.ThemeName = "ControlDefault"
        '
        'btnNuevoBanco
        '
        Me.btnNuevoBanco.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevoBanco.Location = New System.Drawing.Point(172, 25)
        Me.btnNuevoBanco.Name = "btnNuevoBanco"
        Me.btnNuevoBanco.Size = New System.Drawing.Size(48, 29)
        Me.btnNuevoBanco.TabIndex = 384
        Me.btnNuevoBanco.Text = "Nuevo"
        Me.btnNuevoBanco.ThemeName = "ControlDefault"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Location = New System.Drawing.Point(14, 25)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(157, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 404
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Location = New System.Drawing.Point(236, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(157, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 405
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Location = New System.Drawing.Point(458, 25)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(157, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 406
        Me.PictureBox3.TabStop = False
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.btnGuardarCuenta)
        Me.RadGroupBox1.Controls.Add(Me.RadPanel3)
        Me.RadGroupBox1.Controls.Add(Me.RadPanel2)
        Me.RadGroupBox1.Controls.Add(Me.RadPanel1)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Datos"
        Me.RadGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox1.Location = New System.Drawing.Point(12, 314)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(679, 218)
        Me.RadGroupBox1.TabIndex = 395
        Me.RadGroupBox1.Text = "Datos"
        Me.RadGroupBox1.ThemeName = "Breeze"
        CType(Me.RadGroupBox1.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'btnGuardarCuenta
        '
        Me.btnGuardarCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarCuenta.Location = New System.Drawing.Point(309, 31)
        Me.btnGuardarCuenta.Name = "btnGuardarCuenta"
        Me.btnGuardarCuenta.Size = New System.Drawing.Size(61, 23)
        Me.btnGuardarCuenta.TabIndex = 0
        Me.btnGuardarCuenta.Text = "Guardar"
        Me.btnGuardarCuenta.ThemeName = "ControlDefault"
        '
        'RadPanel3
        '
        Me.RadPanel3.BackColor = System.Drawing.Color.Silver
        Me.RadPanel3.Controls.Add(Me.cboInstrumentoStatus)
        Me.RadPanel3.Controls.Add(Me.TextBoxEstatus)
        Me.RadPanel3.Controls.Add(Me.btnEliminarInstrumento)
        Me.RadPanel3.Controls.Add(Me.btnInstrumentoVerClave)
        Me.RadPanel3.Controls.Add(Me.Label25)
        Me.RadPanel3.Controls.Add(Me.txtInstrumentoTipo)
        Me.RadPanel3.Controls.Add(Me.txtInstrumentoDescripcion)
        Me.RadPanel3.Controls.Add(Me.Label18)
        Me.RadPanel3.Controls.Add(Me.txtInstrumentoUsuario)
        Me.RadPanel3.Controls.Add(Me.Label22)
        Me.RadPanel3.Controls.Add(Me.txtInstrumentoFirma)
        Me.RadPanel3.Controls.Add(Me.Label21)
        Me.RadPanel3.Controls.Add(Me.txtInstrumentoClave)
        Me.RadPanel3.Controls.Add(Me.Label20)
        Me.RadPanel3.Controls.Add(Me.Label19)
        Me.RadPanel3.Controls.Add(Me.btnGuardarInstrumento)
        Me.RadPanel3.Controls.Add(Me.btnModificarInstrumento)
        Me.RadPanel3.Location = New System.Drawing.Point(453, 24)
        Me.RadPanel3.Name = "RadPanel3"
        Me.RadPanel3.Size = New System.Drawing.Size(216, 187)
        Me.RadPanel3.TabIndex = 1
        Me.RadPanel3.ThemeName = "Breeze"
        CType(Me.RadPanel3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.Lavender
        CType(Me.RadPanel3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Lavender
        CType(Me.RadPanel3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Lavender
        CType(Me.RadPanel3.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Lavender
        '
        'cboInstrumentoStatus
        '
        Me.cboInstrumentoStatus.CausesValidation = False
        Me.cboInstrumentoStatus.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.INSTRUMENTOBindingSource, "STATUS", True))
        Me.cboInstrumentoStatus.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboInstrumentoStatus.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboInstrumentoStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboInstrumentoStatus.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2})
        Me.cboInstrumentoStatus.Location = New System.Drawing.Point(68, 78)
        Me.cboInstrumentoStatus.Name = "cboInstrumentoStatus"
        '
        '
        '
        Me.cboInstrumentoStatus.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.cboInstrumentoStatus.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboInstrumentoStatus.Size = New System.Drawing.Size(143, 20)
        Me.cboInstrumentoStatus.TabIndex = 2
        Me.cboInstrumentoStatus.TabStop = False
        Me.cboInstrumentoStatus.ThemeName = "Breeze"
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Activo"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "Inactivo"
        '
        'TextBoxEstatus
        '
        Me.TextBoxEstatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "STATUS", True))
        Me.TextBoxEstatus.Location = New System.Drawing.Point(111, 78)
        Me.TextBoxEstatus.Name = "TextBoxEstatus"
        Me.TextBoxEstatus.Size = New System.Drawing.Size(35, 20)
        Me.TextBoxEstatus.TabIndex = 389
        '
        'btnEliminarInstrumento
        '
        Me.btnEliminarInstrumento.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarInstrumento.Location = New System.Drawing.Point(12, 7)
        Me.btnEliminarInstrumento.Name = "btnEliminarInstrumento"
        Me.btnEliminarInstrumento.Size = New System.Drawing.Size(61, 23)
        Me.btnEliminarInstrumento.TabIndex = 387
        Me.btnEliminarInstrumento.Text = "Eliminar"
        Me.btnEliminarInstrumento.ThemeName = "ControlDefault"
        '
        'btnInstrumentoVerClave
        '
        Me.btnInstrumentoVerClave.BackColor = System.Drawing.Color.Transparent
        Me.btnInstrumentoVerClave.Location = New System.Drawing.Point(152, 141)
        Me.btnInstrumentoVerClave.Name = "btnInstrumentoVerClave"
        Me.btnInstrumentoVerClave.Size = New System.Drawing.Size(55, 20)
        Me.btnInstrumentoVerClave.TabIndex = 388
        Me.btnInstrumentoVerClave.Text = "Ver"
        Me.btnInstrumentoVerClave.ThemeName = "ControlDefault"
        '
        'txtInstrumentoTipo
        '
        Me.txtInstrumentoTipo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "TIPOINTRUMENTO", True))
        Me.txtInstrumentoTipo.Location = New System.Drawing.Point(68, 57)
        Me.txtInstrumentoTipo.MaxLength = 50
        Me.txtInstrumentoTipo.Name = "txtInstrumentoTipo"
        Me.txtInstrumentoTipo.Size = New System.Drawing.Size(143, 20)
        Me.txtInstrumentoTipo.TabIndex = 1
        Me.txtInstrumentoTipo.TabStop = False
        Me.txtInstrumentoTipo.ThemeName = "Breeze"
        '
        'txtInstrumentoDescripcion
        '
        Me.txtInstrumentoDescripcion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "DESCRIPCION", True))
        Me.txtInstrumentoDescripcion.Location = New System.Drawing.Point(68, 36)
        Me.txtInstrumentoDescripcion.MaxLength = 50
        Me.txtInstrumentoDescripcion.Name = "txtInstrumentoDescripcion"
        Me.txtInstrumentoDescripcion.Size = New System.Drawing.Size(143, 20)
        Me.txtInstrumentoDescripcion.TabIndex = 0
        Me.txtInstrumentoDescripcion.TabStop = False
        Me.txtInstrumentoDescripcion.ThemeName = "Breeze"
        '
        'txtInstrumentoUsuario
        '
        Me.txtInstrumentoUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "USUARIO", True))
        Me.txtInstrumentoUsuario.Location = New System.Drawing.Point(68, 99)
        Me.txtInstrumentoUsuario.MaxLength = 50
        Me.txtInstrumentoUsuario.Name = "txtInstrumentoUsuario"
        Me.txtInstrumentoUsuario.Size = New System.Drawing.Size(143, 20)
        Me.txtInstrumentoUsuario.TabIndex = 3
        Me.txtInstrumentoUsuario.TabStop = False
        Me.txtInstrumentoUsuario.ThemeName = "Breeze"
        '
        'txtInstrumentoFirma
        '
        Me.txtInstrumentoFirma.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "FIRMA", True))
        Me.txtInstrumentoFirma.Location = New System.Drawing.Point(68, 120)
        Me.txtInstrumentoFirma.MaxLength = 50
        Me.txtInstrumentoFirma.Name = "txtInstrumentoFirma"
        Me.txtInstrumentoFirma.Size = New System.Drawing.Size(143, 20)
        Me.txtInstrumentoFirma.TabIndex = 4
        Me.txtInstrumentoFirma.TabStop = False
        Me.txtInstrumentoFirma.ThemeName = "Breeze"
        '
        'txtInstrumentoClave
        '
        Me.txtInstrumentoClave.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "CLAVE", True))
        Me.txtInstrumentoClave.Location = New System.Drawing.Point(68, 141)
        Me.txtInstrumentoClave.MaxLength = 8
        Me.txtInstrumentoClave.Name = "txtInstrumentoClave"
        Me.txtInstrumentoClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtInstrumentoClave.Size = New System.Drawing.Size(79, 20)
        Me.txtInstrumentoClave.TabIndex = 5
        Me.txtInstrumentoClave.TabStop = False
        Me.txtInstrumentoClave.ThemeName = "Breeze"
        '
        'btnGuardarInstrumento
        '
        Me.btnGuardarInstrumento.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarInstrumento.Location = New System.Drawing.Point(85, 7)
        Me.btnGuardarInstrumento.Name = "btnGuardarInstrumento"
        Me.btnGuardarInstrumento.Size = New System.Drawing.Size(61, 23)
        Me.btnGuardarInstrumento.TabIndex = 385
        Me.btnGuardarInstrumento.Text = "Guardar"
        Me.btnGuardarInstrumento.ThemeName = "ControlDefault"
        '
        'btnModificarInstrumento
        '
        Me.btnModificarInstrumento.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarInstrumento.Location = New System.Drawing.Point(152, 7)
        Me.btnModificarInstrumento.Name = "btnModificarInstrumento"
        Me.btnModificarInstrumento.Size = New System.Drawing.Size(61, 23)
        Me.btnModificarInstrumento.TabIndex = 6
        Me.btnModificarInstrumento.Text = "Modificar"
        Me.btnModificarInstrumento.ThemeName = "ControlDefault"
        '
        'RadPanel2
        '
        Me.RadPanel2.BackColor = System.Drawing.Color.Silver
        Me.RadPanel2.Controls.Add(Me.txtCuentaLimite)
        Me.RadPanel2.Controls.Add(Me.txtCuentaInteres)
        Me.RadPanel2.Controls.Add(Me.cboTipoCuenta)
        Me.RadPanel2.Controls.Add(Me.btnEliminarCuenta)
        Me.RadPanel2.Controls.Add(Me.cboCuentaMoneda)
        Me.RadPanel2.Controls.Add(Me.btnModificarCuenta)
        Me.RadPanel2.Controls.Add(Me.txtNumCuenta)
        Me.RadPanel2.Controls.Add(Me.chkCuentaSobregiro)
        Me.RadPanel2.Controls.Add(Me.txtCuentaDescripcion)
        Me.RadPanel2.Controls.Add(Me.Label15)
        Me.RadPanel2.Controls.Add(Me.Label6)
        Me.RadPanel2.Controls.Add(Me.Label9)
        Me.RadPanel2.Controls.Add(Me.Label14)
        Me.RadPanel2.Controls.Add(Me.Label13)
        Me.RadPanel2.Controls.Add(Me.Label12)
        Me.RadPanel2.Controls.Add(Me.Label11)
        Me.RadPanel2.Location = New System.Drawing.Point(231, 24)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(216, 187)
        Me.RadPanel2.TabIndex = 1
        Me.RadPanel2.ThemeName = "Breeze"
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.Lavender
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Lavender
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Lavender
        CType(Me.RadPanel2.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.Lavender
        '
        'txtCuentaLimite
        '
        Me.txtCuentaLimite.AllowDrop = True
        Me.txtCuentaLimite.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtCuentaLimite.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUENTABANCARIABindingSource, "LIMITECREDITO", True))
        Me.txtCuentaLimite.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtCuentaLimite.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.txtCuentaLimite.Location = New System.Drawing.Point(69, 137)
        Me.txtCuentaLimite.Name = "txtCuentaLimite"
        Me.txtCuentaLimite.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCuentaLimite.Size = New System.Drawing.Size(93, 20)
        Me.txtCuentaLimite.TabIndex = 5
        '
        'txtCuentaInteres
        '
        Me.txtCuentaInteres.AllowDrop = True
        Appearance1.TextHAlignAsString = "Right"
        Me.txtCuentaInteres.Appearance = Appearance1
        Me.txtCuentaInteres.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtCuentaInteres.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUENTABANCARIABindingSource, "INTERES", True))
        Me.txtCuentaInteres.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtCuentaInteres.InputMask = "nnn.nn"
        Me.txtCuentaInteres.Location = New System.Drawing.Point(68, 161)
        Me.txtCuentaInteres.Name = "txtCuentaInteres"
        Me.txtCuentaInteres.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtCuentaInteres.Size = New System.Drawing.Size(94, 20)
        Me.txtCuentaInteres.TabIndex = 6
        '
        'cboTipoCuenta
        '
        Me.cboTipoCuenta.CausesValidation = False
        Me.cboTipoCuenta.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CUENTABANCARIABindingSource, "CODTIPOCUENTA", True))
        Me.cboTipoCuenta.DataSource = Me.TIPOCUENTABindingSource
        Me.cboTipoCuenta.DisplayMember = "DESTIPOCUENTA"
        Me.cboTipoCuenta.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboTipoCuenta.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboTipoCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboTipoCuenta.Location = New System.Drawing.Point(69, 78)
        Me.cboTipoCuenta.Name = "cboTipoCuenta"
        '
        '
        '
        Me.cboTipoCuenta.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.cboTipoCuenta.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboTipoCuenta.RootElement.StretchVertically = True
        Me.cboTipoCuenta.Size = New System.Drawing.Size(143, 20)
        Me.cboTipoCuenta.TabIndex = 2
        Me.cboTipoCuenta.TabStop = False
        Me.cboTipoCuenta.ThemeName = "Breeze"
        Me.cboTipoCuenta.ValueMember = "CODTIPOCUENTA"
        '
        'TIPOCUENTABindingSource
        '
        Me.TIPOCUENTABindingSource.DataMember = "TIPOCUENTA"
        Me.TIPOCUENTABindingSource.DataSource = Me.DsFacturacion
        '
        'btnEliminarCuenta
        '
        Me.btnEliminarCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarCuenta.Location = New System.Drawing.Point(13, 7)
        Me.btnEliminarCuenta.Name = "btnEliminarCuenta"
        Me.btnEliminarCuenta.Size = New System.Drawing.Size(61, 23)
        Me.btnEliminarCuenta.TabIndex = 387
        Me.btnEliminarCuenta.Text = "Eliminar"
        Me.btnEliminarCuenta.ThemeName = "ControlDefault"
        '
        'cboCuentaMoneda
        '
        Me.cboCuentaMoneda.CausesValidation = False
        Me.cboCuentaMoneda.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CUENTABANCARIABindingSource, "CODMONEDA", True))
        Me.cboCuentaMoneda.DataSource = Me.MONEDASINFILTROBindingSource
        Me.cboCuentaMoneda.DisplayMember = "DESMONEDA"
        Me.cboCuentaMoneda.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cboCuentaMoneda.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboCuentaMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboCuentaMoneda.Location = New System.Drawing.Point(69, 99)
        Me.cboCuentaMoneda.Name = "cboCuentaMoneda"
        '
        '
        '
        Me.cboCuentaMoneda.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.cboCuentaMoneda.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboCuentaMoneda.RootElement.StretchVertically = True
        Me.cboCuentaMoneda.Size = New System.Drawing.Size(143, 20)
        Me.cboCuentaMoneda.TabIndex = 3
        Me.cboCuentaMoneda.TabStop = False
        Me.cboCuentaMoneda.ThemeName = "Breeze"
        Me.cboCuentaMoneda.ValueMember = "CODMONEDA"
        '
        'MONEDASINFILTROBindingSource
        '
        Me.MONEDASINFILTROBindingSource.DataMember = "MONEDASINFILTRO"
        Me.MONEDASINFILTROBindingSource.DataSource = Me.DsFacturacion
        '
        'btnModificarCuenta
        '
        Me.btnModificarCuenta.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarCuenta.Location = New System.Drawing.Point(146, 7)
        Me.btnModificarCuenta.Name = "btnModificarCuenta"
        Me.btnModificarCuenta.Size = New System.Drawing.Size(61, 23)
        Me.btnModificarCuenta.TabIndex = 388
        Me.btnModificarCuenta.Text = "Modificar"
        Me.btnModificarCuenta.ThemeName = "ControlDefault"
        '
        'txtNumCuenta
        '
        Me.txtNumCuenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUENTABANCARIABindingSource, "NUMCUENTA", True))
        Me.txtNumCuenta.Location = New System.Drawing.Point(69, 36)
        Me.txtNumCuenta.MaxLength = 50
        Me.txtNumCuenta.Name = "txtNumCuenta"
        Me.txtNumCuenta.Size = New System.Drawing.Size(143, 20)
        Me.txtNumCuenta.TabIndex = 0
        Me.txtNumCuenta.TabStop = False
        Me.txtNumCuenta.ThemeName = "Breeze"
        '
        'chkCuentaSobregiro
        '
        Me.chkCuentaSobregiro.BackColor = System.Drawing.Color.Lavender
        Me.chkCuentaSobregiro.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CUENTABANCARIABindingSource, "SOBREGIRO", True))
        Me.chkCuentaSobregiro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.chkCuentaSobregiro.Location = New System.Drawing.Point(69, 121)
        Me.chkCuentaSobregiro.Name = "chkCuentaSobregiro"
        '
        '
        '
        Me.chkCuentaSobregiro.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.chkCuentaSobregiro.Size = New System.Drawing.Size(69, 18)
        Me.chkCuentaSobregiro.TabIndex = 4
        Me.chkCuentaSobregiro.Text = "Permitir"
        '
        'txtCuentaDescripcion
        '
        Me.txtCuentaDescripcion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CUENTABANCARIABindingSource, "DESCRIPCION", True))
        Me.txtCuentaDescripcion.Location = New System.Drawing.Point(69, 57)
        Me.txtCuentaDescripcion.MaxLength = 60
        Me.txtCuentaDescripcion.Name = "txtCuentaDescripcion"
        Me.txtCuentaDescripcion.Size = New System.Drawing.Size(143, 20)
        Me.txtCuentaDescripcion.TabIndex = 1
        Me.txtCuentaDescripcion.TabStop = False
        Me.txtCuentaDescripcion.ThemeName = "Breeze"
        '
        'RadPanel1
        '
        Me.RadPanel1.BackColor = System.Drawing.Color.Silver
        Me.RadPanel1.Controls.Add(Me.btnEliminarBanco)
        Me.RadPanel1.Controls.Add(Me.Label7)
        Me.RadPanel1.Controls.Add(Me.txtBancoDireccion)
        Me.RadPanel1.Controls.Add(Me.Label5)
        Me.RadPanel1.Controls.Add(Me.Label4)
        Me.RadPanel1.Controls.Add(Me.Label3)
        Me.RadPanel1.Controls.Add(Me.Label2)
        Me.RadPanel1.Controls.Add(Me.txtBancoEmail)
        Me.RadPanel1.Controls.Add(Me.txtBancoTelefono)
        Me.RadPanel1.Controls.Add(Me.txtBancoSucursal)
        Me.RadPanel1.Controls.Add(Me.txtBancoAgente)
        Me.RadPanel1.Controls.Add(Me.txtBanco)
        Me.RadPanel1.Controls.Add(Me.Label1)
        Me.RadPanel1.Controls.Add(Me.btnGuardarBanco)
        Me.RadPanel1.Controls.Add(Me.btnModificarBanco)
        Me.RadPanel1.Location = New System.Drawing.Point(9, 24)
        Me.RadPanel1.Name = "RadPanel1"
        Me.RadPanel1.Size = New System.Drawing.Size(216, 187)
        Me.RadPanel1.TabIndex = 0
        Me.RadPanel1.ThemeName = "Breeze"
        CType(Me.RadPanel1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.Lavender
        CType(Me.RadPanel1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Lavender
        CType(Me.RadPanel1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Lavender
        CType(Me.RadPanel1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(250, Byte), Integer))
        '
        'btnEliminarBanco
        '
        Me.btnEliminarBanco.BackColor = System.Drawing.Color.Transparent
        Me.btnEliminarBanco.Location = New System.Drawing.Point(13, 7)
        Me.btnEliminarBanco.Name = "btnEliminarBanco"
        Me.btnEliminarBanco.Size = New System.Drawing.Size(61, 23)
        Me.btnEliminarBanco.TabIndex = 384
        Me.btnEliminarBanco.Text = "Eliminar"
        Me.btnEliminarBanco.ThemeName = "ControlDefault"
        '
        'txtBancoDireccion
        '
        Me.txtBancoDireccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "DIRECCION", True))
        Me.txtBancoDireccion.Location = New System.Drawing.Point(56, 78)
        Me.txtBancoDireccion.MaxLength = 80
        Me.txtBancoDireccion.Name = "txtBancoDireccion"
        Me.txtBancoDireccion.Size = New System.Drawing.Size(153, 20)
        Me.txtBancoDireccion.TabIndex = 2
        Me.txtBancoDireccion.TabStop = False
        Me.txtBancoDireccion.ThemeName = "Breeze"
        '
        'txtBancoEmail
        '
        Me.txtBancoEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "EMAIL", True))
        Me.txtBancoEmail.Location = New System.Drawing.Point(56, 141)
        Me.txtBancoEmail.MaxLength = 50
        Me.txtBancoEmail.Name = "txtBancoEmail"
        Me.txtBancoEmail.Size = New System.Drawing.Size(153, 20)
        Me.txtBancoEmail.TabIndex = 5
        Me.txtBancoEmail.TabStop = False
        Me.txtBancoEmail.ThemeName = "Breeze"
        '
        'txtBancoTelefono
        '
        Me.txtBancoTelefono.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "TELEFONO", True))
        Me.txtBancoTelefono.Location = New System.Drawing.Point(56, 120)
        Me.txtBancoTelefono.MaxLength = 50
        Me.txtBancoTelefono.Name = "txtBancoTelefono"
        Me.txtBancoTelefono.Size = New System.Drawing.Size(153, 20)
        Me.txtBancoTelefono.TabIndex = 4
        Me.txtBancoTelefono.TabStop = False
        Me.txtBancoTelefono.ThemeName = "Breeze"
        '
        'txtBancoSucursal
        '
        Me.txtBancoSucursal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "SUCURSAL", True))
        Me.txtBancoSucursal.Location = New System.Drawing.Point(56, 57)
        Me.txtBancoSucursal.MaxLength = 50
        Me.txtBancoSucursal.Name = "txtBancoSucursal"
        Me.txtBancoSucursal.Size = New System.Drawing.Size(153, 20)
        Me.txtBancoSucursal.TabIndex = 1
        Me.txtBancoSucursal.TabStop = False
        Me.txtBancoSucursal.ThemeName = "Breeze"
        '
        'txtBancoAgente
        '
        Me.txtBancoAgente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "AGENTE", True))
        Me.txtBancoAgente.Location = New System.Drawing.Point(56, 99)
        Me.txtBancoAgente.MaxLength = 50
        Me.txtBancoAgente.Name = "txtBancoAgente"
        Me.txtBancoAgente.Size = New System.Drawing.Size(153, 20)
        Me.txtBancoAgente.TabIndex = 3
        Me.txtBancoAgente.TabStop = False
        Me.txtBancoAgente.ThemeName = "Breeze"
        '
        'txtBanco
        '
        Me.txtBanco.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "DESBANCO", True))
        Me.txtBanco.Location = New System.Drawing.Point(56, 36)
        Me.txtBanco.MaxLength = 100
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(153, 20)
        Me.txtBanco.TabIndex = 0
        Me.txtBanco.TabStop = False
        Me.txtBanco.ThemeName = "Breeze"
        '
        'btnGuardarBanco
        '
        Me.btnGuardarBanco.BackColor = System.Drawing.Color.Transparent
        Me.btnGuardarBanco.Location = New System.Drawing.Point(81, 7)
        Me.btnGuardarBanco.Name = "btnGuardarBanco"
        Me.btnGuardarBanco.Size = New System.Drawing.Size(61, 23)
        Me.btnGuardarBanco.TabIndex = 7
        Me.btnGuardarBanco.Text = "Guardar"
        Me.btnGuardarBanco.ThemeName = "ControlDefault"
        '
        'btnModificarBanco
        '
        Me.btnModificarBanco.BackColor = System.Drawing.Color.Transparent
        Me.btnModificarBanco.Location = New System.Drawing.Point(151, 7)
        Me.btnModificarBanco.Name = "btnModificarBanco"
        Me.btnModificarBanco.Size = New System.Drawing.Size(61, 23)
        Me.btnModificarBanco.TabIndex = 384
        Me.btnModificarBanco.Text = "Modificar"
        Me.btnModificarBanco.ThemeName = "ControlDefault"
        '
        'txtCodBanco
        '
        Me.txtCodBanco.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BANCOBindingSource, "CODBANCO", True))
        Me.txtCodBanco.Location = New System.Drawing.Point(628, 7)
        Me.txtCodBanco.Name = "txtCodBanco"
        Me.txtCodBanco.Size = New System.Drawing.Size(67, 20)
        Me.txtCodBanco.TabIndex = 380
        Me.txtCodBanco.TabStop = False
        '
        'txtCodInstrumento
        '
        Me.txtCodInstrumento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "CODINSTRUMENTO", True))
        Me.txtCodInstrumento.Location = New System.Drawing.Point(628, 33)
        Me.txtCodInstrumento.Name = "txtCodInstrumento"
        Me.txtCodInstrumento.Size = New System.Drawing.Size(67, 20)
        Me.txtCodInstrumento.TabIndex = 380
        Me.txtCodInstrumento.TabStop = False
        '
        'txtInstrumentoStatus
        '
        Me.txtInstrumentoStatus.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.INSTRUMENTOBindingSource, "STATUS", True))
        Me.txtInstrumentoStatus.Location = New System.Drawing.Point(628, 59)
        Me.txtInstrumentoStatus.Name = "txtInstrumentoStatus"
        Me.txtInstrumentoStatus.Size = New System.Drawing.Size(67, 20)
        Me.txtInstrumentoStatus.TabIndex = 380
        Me.txtInstrumentoStatus.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.header_pos_express
        Me.Panel5.Controls.Add(Me.pbxCancelar)
        Me.Panel5.Controls.Add(Me.pbxCancelarGris)
        Me.Panel5.Controls.Add(Me.pbxCerrado)
        Me.Panel5.Controls.Add(Me.pbxAbierto)
        Me.Panel5.Location = New System.Drawing.Point(-1, -1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(707, 90)
        Me.Panel5.TabIndex = 360
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackgroundImage = Global.ContaExpress.My.Resources.Resources.cancelar
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(10, 6)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(83, 79)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 348
        Me.pbxCancelar.TabStop = False
        '
        'pbxCerrado
        '
        Me.pbxCerrado.BackColor = System.Drawing.Color.Transparent
        Me.pbxCerrado.BackgroundImage = Global.ContaExpress.My.Resources.Resources.planilla_bloqueada
        Me.pbxCerrado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCerrado.Location = New System.Drawing.Point(613, 6)
        Me.pbxCerrado.Name = "pbxCerrado"
        Me.pbxCerrado.Size = New System.Drawing.Size(83, 79)
        Me.pbxCerrado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCerrado.TabIndex = 351
        Me.pbxCerrado.TabStop = False
        '
        'pbxAbierto
        '
        Me.pbxAbierto.BackgroundImage = Global.ContaExpress.My.Resources.Resources.planilla_editable
        Me.pbxAbierto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxAbierto.Location = New System.Drawing.Point(613, 6)
        Me.pbxAbierto.Name = "pbxAbierto"
        Me.pbxAbierto.Size = New System.Drawing.Size(83, 79)
        Me.pbxAbierto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxAbierto.TabIndex = 352
        Me.pbxAbierto.TabStop = False
        Me.pbxAbierto.Visible = False
        '
        'pbxCancelarGris
        '
        Me.pbxCancelarGris.BackgroundImage = Global.ContaExpress.My.Resources.Resources.cancelargris
        Me.pbxCancelarGris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelarGris.InitialImage = Nothing
        Me.pbxCancelarGris.Location = New System.Drawing.Point(10, 6)
        Me.pbxCancelarGris.Name = "pbxCancelarGris"
        Me.pbxCancelarGris.Size = New System.Drawing.Size(83, 79)
        Me.pbxCancelarGris.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelarGris.TabIndex = 349
        Me.pbxCancelarGris.TabStop = False
        '
        'BANCOTableAdapter
        '
        Me.BANCOTableAdapter.ClearBeforeFill = True
        '
        'CUENTABANCARIATableAdapter
        '
        Me.CUENTABANCARIATableAdapter.ClearBeforeFill = True
        '
        'INSTRUMENTOTableAdapter
        '
        Me.INSTRUMENTOTableAdapter.ClearBeforeFill = True
        '
        'VENTASFORMACOBROTableAdapter
        '
        Me.VENTASFORMACOBROTableAdapter.ClearBeforeFill = True
        '
        'TIPOCUENTATableAdapter
        '
        Me.TIPOCUENTATableAdapter.ClearBeforeFill = True
        '
        'MONEDASINFILTROTableAdapter
        '
        Me.MONEDASINFILTROTableAdapter.ClearBeforeFill = True
        '
        'AUDITORIATABLASBindingSource
        '
        Me.AUDITORIATABLASBindingSource.DataMember = "AUDITORIATABLAS"
        Me.AUDITORIATABLASBindingSource.DataSource = Me.DsFacturacion
        '
        'AUDITORIATABLASTableAdapter
        '
        Me.AUDITORIATABLASTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AUDITORIAMOVIMIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.AUDITORIATABLASTableAdapter = Me.AUDITORIATABLASTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANCOTableAdapter = Me.BANCOTableAdapter
        Me.TableAdapterManager.CIUDADTableAdapter = Nothing
        Me.TableAdapterManager.CLIENTESTableAdapter = Nothing
        Me.TableAdapterManager.COMBODETALLETableAdapter = Nothing
        Me.TableAdapterManager.COMBOTableAdapter = Nothing
        'Me.TableAdapterManager.COTIZACIONTableAdapter = Nothing
        Me.TableAdapterManager.CUENTABANCARIATableAdapter = Me.CUENTABANCARIATableAdapter
        Me.TableAdapterManager.CUOTAVENTATableAdapter = Nothing
        Me.TableAdapterManager.DEPARTAMENTOTableAdapter = Nothing
        Me.TableAdapterManager.DEVOLUCIONDETALLETableAdapter = Nothing
        Me.TableAdapterManager.DEVOLUCIONTableAdapter = Nothing
        Me.TableAdapterManager.DIRECCIONESFILTROTableAdapter = Nothing
        Me.TableAdapterManager.DIRECCIONESTableAdapter = Nothing
        Me.TableAdapterManager.EMPRESATableAdapter = Nothing
        Me.TableAdapterManager.EMPRESATRANSPORTETableAdapter = Nothing
        Me.TableAdapterManager.ENCARGADOTableAdapter = Nothing
        Me.TableAdapterManager.INSTRUMENTOTableAdapter = Me.INSTRUMENTOTableAdapter
        Me.TableAdapterManager.MONEDASINFILTROTableAdapter = Me.MONEDASINFILTROTableAdapter
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PAISTableAdapter = Nothing
        Me.TableAdapterManager.PCTableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOENVIODETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOENVIOTableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTAPAGODETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTASDETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTASTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCHEQUETableAdapter = Nothing
        Me.TableAdapterManager.TIPOCOMPROBANTE_VENTATableAdapter = Nothing
        Me.TableAdapterManager.TIPOCOMPROBANTETableAdapter = Nothing
        Me.TableAdapterManager.TIPOCUENTATableAdapter = Me.TIPOCUENTATableAdapter
        Me.TableAdapterManager.TIPOTARJETATableAdapter = Nothing
        Me.TableAdapterManager.TIPOTRANSPORTETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.dsFacturacionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VENTASASRTableAdapter = Nothing
        Me.TableAdapterManager.VENTASDETALLETableAdapter = Nothing
        Me.TableAdapterManager.VENTASENVIOSDETALLESTableAdapter = Nothing
        Me.TableAdapterManager.VENTASENVIOSTableAdapter = Nothing
        Me.TableAdapterManager.VENTASFORMACOBROTableAdapter = Me.VENTASFORMACOBROTableAdapter
        Me.TableAdapterManager.VENTASOTTableAdapter = Nothing
        Me.TableAdapterManager.VENTASPRESUPUESTOTableAdapter = Nothing
        Me.TableAdapterManager.VENTASTableAdapter = Nothing
        Me.TableAdapterManager.ZONATableAdapter = Nothing
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Silver
        Me.Panel3.Controls.Add(Me.lb_mensaje)
        Me.Panel3.Controls.Add(Me.lbguardar)
        Me.Panel3.Controls.Add(Me.lbcancelar)
        Me.Panel3.Controls.Add(Me.lbnuevo)
        Me.Panel3.Controls.Add(Me.lbeliminar)
        Me.Panel3.Location = New System.Drawing.Point(-1, 538)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(707, 28)
        Me.Panel3.TabIndex = 2
        '
        'lb_mensaje
        '
        Me.lb_mensaje.BackColor = System.Drawing.Color.Silver
        Me.lb_mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_mensaje.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lb_mensaje.Location = New System.Drawing.Point(3, 11)
        Me.lb_mensaje.Name = "lb_mensaje"
        Me.lb_mensaje.Size = New System.Drawing.Size(337, 13)
        Me.lb_mensaje.TabIndex = 372
        Me.lb_mensaje.Text = "//"
        '
        'lbguardar
        '
        Me.lbguardar.AutoSize = True
        Me.lbguardar.BackColor = System.Drawing.Color.Silver
        Me.lbguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbguardar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbguardar.Location = New System.Drawing.Point(342, 7)
        Me.lbguardar.Name = "lbguardar"
        Me.lbguardar.Size = New System.Drawing.Size(93, 13)
        Me.lbguardar.TabIndex = 2
        Me.lbguardar.Text = "Guardar: CTRL+G"
        '
        'lbcancelar
        '
        Me.lbcancelar.AutoSize = True
        Me.lbcancelar.BackColor = System.Drawing.Color.Silver
        Me.lbcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbcancelar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbcancelar.Location = New System.Drawing.Point(598, 7)
        Me.lbcancelar.Name = "lbcancelar"
        Me.lbcancelar.Size = New System.Drawing.Size(76, 13)
        Me.lbcancelar.TabIndex = 5
        Me.lbcancelar.Text = "Cancelar: ESC"
        '
        'lbnuevo
        '
        Me.lbnuevo.AutoSize = True
        Me.lbnuevo.BackColor = System.Drawing.Color.Silver
        Me.lbnuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbnuevo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbnuevo.Location = New System.Drawing.Point(343, 7)
        Me.lbnuevo.Name = "lbnuevo"
        Me.lbnuevo.Size = New System.Drawing.Size(93, 13)
        Me.lbnuevo.TabIndex = 1
        Me.lbnuevo.Text = "Nuevo: CTRL + N"
        '
        'lbeliminar
        '
        Me.lbeliminar.AutoSize = True
        Me.lbeliminar.BackColor = System.Drawing.Color.Silver
        Me.lbeliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbeliminar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lbeliminar.Location = New System.Drawing.Point(444, 7)
        Me.lbeliminar.Name = "lbeliminar"
        Me.lbeliminar.Size = New System.Drawing.Size(139, 13)
        Me.lbeliminar.TabIndex = 3
        Me.lbeliminar.Text = "Eliminar: CTRL+BackSpace"
        '
        'ABMBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(706, 568)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.txtInstrumentoStatus)
        Me.Controls.Add(Me.txtCodInstrumento)
        Me.Controls.Add(Me.txtCodBanco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "ABMBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Banco > Cuenta > Instrumento"
        CType(Me.grdBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BANCOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        CType(Me.RadGroupBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox5.ResumeLayout(False)
        CType(Me.grdInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.INSTRUMENTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUENTABANCARIABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        CType(Me.grdCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox3.ResumeLayout(False)
        CType(Me.btnNuevoInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNuevoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNuevoBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        CType(Me.btnGuardarCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel3.ResumeLayout(False)
        Me.RadPanel3.PerformLayout()
        CType(Me.cboInstrumentoStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminarInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnInstrumentoVerClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoTipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoClave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardarInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnModificarInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel2.ResumeLayout(False)
        Me.RadPanel2.PerformLayout()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCUENTABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEliminarCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuentaMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDASINFILTROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnModificarCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkCuentaSobregiro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel1.ResumeLayout(False)
        Me.RadPanel1.PerformLayout()
        CType(Me.btnEliminarBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBancoDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBancoEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBancoTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBancoSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBancoAgente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGuardarBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnModificarBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodInstrumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstrumentoStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCerrado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAbierto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelarGris, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    #End Region 'Methods

End Class