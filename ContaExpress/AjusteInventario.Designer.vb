<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjusteInventario
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
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjusteInventario))
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInventario = New ContaExpress.DsInventario()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.dtpFechaAjuste = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigoAjuste = New System.Windows.Forms.TextBox()
        Me.tbxConceptoAjuste = New System.Windows.Forms.TextBox()
        Me.tbxProducto = New System.Windows.Forms.TextBox()
        Me.BtnProducto = New Telerik.WinControls.UI.RadButton()
        Me.ComboBoxProductos = New System.Windows.Forms.ComboBox()
        Me.CantidadProdTxt = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.TextBoxCodCodigo = New Telerik.WinControls.UI.RadTextBox()
        Me.TextBoxCodProducto = New Telerik.WinControls.UI.RadTextBox()
        Me.BtnGuardar = New Telerik.WinControls.UI.RadButton()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.FECHAMTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDA3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMOVIMIENTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROMOVIMIENTO3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOVPRODUCTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel6 = New Telerik.WinControls.UI.RadLabel()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.BuscarProductoTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.RadGridView1 = New Telerik.WinControls.UI.RadGridView()
        Me.CODIGOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxTransferencia = New System.Windows.Forms.PictureBox()
        Me.PictureBoxProducto = New System.Windows.Forms.PictureBox()
        Me.cbxTodos = New System.Windows.Forms.CheckBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PanelTransferencia = New System.Windows.Forms.Panel()
        Me.txtCodigo = New Telerik.WinControls.UI.RadTextBox()
        Me.RadTextBox2 = New Telerik.WinControls.UI.RadTextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.CodModID = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtConceptoTransf = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtProductoTransf = New Telerik.WinControls.UI.RadTextBox()
        Me.CmbSucursalDestino = New System.Windows.Forms.ComboBox()
        Me.SUCURSALDestinoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CmbSucursalOrigen = New System.Windows.Forms.ComboBox()
        Me.SUCURSALOrigenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BtnGuardarTransf = New Telerik.WinControls.UI.RadButton()
        Me.TxtCantidadTransferido = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.dgvTransferencias = New System.Windows.Forms.DataGridView()
        Me.FECHAMTOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMOVIMIENTOSTRINGTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO1TR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSALTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMOVIMIENTOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROMOVIMIENTOTR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TransferenciaMovimientoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TxtCodCodigoTransf = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtCodProductoTransf = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.DsInventarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.buscarAjuste = New System.Windows.Forms.TextBox()
        Me.FKMOVIMIENTOSRELATIONSCODIGOS1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOMOVIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMOVIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOMOVIEMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMOVIEMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn35 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn36 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsInventarioTableAdapters.TableAdapterManager()
        Me.CODIGOSTableAdapter = New ContaExpress.DsInventarioTableAdapters.CODIGOSTableAdapter()
        Me.MOVPRODUCTOSTableAdapter = New ContaExpress.DsInventarioTableAdapters.MOVPRODUCTOSTableAdapter()
        Me.MOVIMIENTOPRODUCTOTableAdapter1 = New ContaExpress.DsInventarioTableAdapters.MOVIMIENTOPRODUCTOTableAdapter()
        Me.lbxPanel = New System.Windows.Forms.Label()
        Me.TransferenciaMovimientoTableAdapter = New ContaExpress.DsInventarioTableAdapters.TransferenciaMovimientoTableAdapter()
        Me.dgvDeposito = New System.Windows.Forms.DataGridView()
        Me.CODSUCURSALDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMSUCURSALDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSALDataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblClienteEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.btnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.chkMovimientos = New System.Windows.Forms.CheckBox()
        Me.chkTransacciones = New System.Windows.Forms.CheckBox()
        Me.chkAjustes = New System.Windows.Forms.CheckBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Fecha2 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Fecha1 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NROMOVIMIENTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCODIGO12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESA2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDMOVIMIENTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMOVIMIENTO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.STOCKDEPOSITOTableAdapter = New ContaExpress.DsInventarioTableAdapters.STOCKDEPOSITOTableAdapter()
        Me.DsInventario1 = New ContaExpress.DsInventario()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelProducto.SuspendLayout()
        CType(Me.BtnProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MOVPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridView1.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxTransferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTransferencia.SuspendLayout()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.txtCodigo.SuspendLayout()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodModID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtConceptoTransf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProductoTransf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALDestinoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALOrigenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGuardarTransf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransferenciaMovimientoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodCodigoTransf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodProductoTransf, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FKMOVIMIENTOSRELATIONSCODIGOS1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        CType(Me.btnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsInventario
        '
        'DsInventario
        '
        Me.DsInventario.DataSetName = "DsInventario"
        Me.DsInventario.EnforceConstraints = False
        Me.DsInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PanelProducto
        '
        Me.PanelProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelProducto.BackColor = System.Drawing.Color.LightGray
        Me.PanelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelProducto.Controls.Add(Me.dtpFechaAjuste)
        Me.PanelProducto.Controls.Add(Me.Label2)
        Me.PanelProducto.Controls.Add(Me.txtCodigoAjuste)
        Me.PanelProducto.Controls.Add(Me.tbxConceptoAjuste)
        Me.PanelProducto.Controls.Add(Me.tbxProducto)
        Me.PanelProducto.Controls.Add(Me.BtnProducto)
        Me.PanelProducto.Controls.Add(Me.ComboBoxProductos)
        Me.PanelProducto.Controls.Add(Me.CantidadProdTxt)
        Me.PanelProducto.Controls.Add(Me.TextBoxCodCodigo)
        Me.PanelProducto.Controls.Add(Me.TextBoxCodProducto)
        Me.PanelProducto.Controls.Add(Me.BtnGuardar)
        Me.PanelProducto.Controls.Add(Me.DataGridView3)
        Me.PanelProducto.Controls.Add(Me.RadLabel4)
        Me.PanelProducto.Controls.Add(Me.RadLabel1)
        Me.PanelProducto.Controls.Add(Me.RadLabel2)
        Me.PanelProducto.Controls.Add(Me.RadLabel5)
        Me.PanelProducto.Controls.Add(Me.RadLabel6)
        Me.PanelProducto.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PanelProducto.Location = New System.Drawing.Point(209, 75)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(730, 502)
        Me.PanelProducto.TabIndex = 0
        '
        'dtpFechaAjuste
        '
        Me.dtpFechaAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.dtpFechaAjuste.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaAjuste.Location = New System.Drawing.Point(8, 72)
        Me.dtpFechaAjuste.Name = "dtpFechaAjuste"
        Me.dtpFechaAjuste.Size = New System.Drawing.Size(121, 27)
        Me.dtpFechaAjuste.TabIndex = 77778
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 77779
        Me.Label2.Text = "Fecha"
        '
        'txtCodigoAjuste
        '
        Me.txtCodigoAjuste.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCodigoAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAjuste.Location = New System.Drawing.Point(4, 20)
        Me.txtCodigoAjuste.Name = "txtCodigoAjuste"
        Me.txtCodigoAjuste.Size = New System.Drawing.Size(125, 27)
        Me.txtCodigoAjuste.TabIndex = 1
        '
        'tbxConceptoAjuste
        '
        Me.tbxConceptoAjuste.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxConceptoAjuste.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxConceptoAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxConceptoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxConceptoAjuste.Location = New System.Drawing.Point(136, 72)
        Me.tbxConceptoAjuste.Name = "tbxConceptoAjuste"
        Me.tbxConceptoAjuste.Size = New System.Drawing.Size(376, 27)
        Me.tbxConceptoAjuste.TabIndex = 4
        '
        'tbxProducto
        '
        Me.tbxProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxProducto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxProducto.Location = New System.Drawing.Point(131, 20)
        Me.tbxProducto.Name = "tbxProducto"
        Me.tbxProducto.Size = New System.Drawing.Size(436, 27)
        Me.tbxProducto.TabIndex = 2
        '
        'BtnProducto
        '
        Me.BtnProducto.AllowDrop = True
        Me.BtnProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnProducto.BackColor = System.Drawing.Color.Transparent
        Me.BtnProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProducto.Location = New System.Drawing.Point(569, 20)
        Me.BtnProducto.Name = "BtnProducto"
        Me.BtnProducto.Size = New System.Drawing.Size(20, 27)
        Me.BtnProducto.TabIndex = 77777
        Me.BtnProducto.Text = "*"
        Me.BtnProducto.TextAlignment = System.Drawing.ContentAlignment.BottomCenter
        '
        'ComboBoxProductos
        '
        Me.ComboBoxProductos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxProductos.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ComboBoxProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBoxProductos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxProductos.FormattingEnabled = True
        Me.ComboBoxProductos.Items.AddRange(New Object() {"En Más", "En Menos"})
        Me.ComboBoxProductos.Location = New System.Drawing.Point(593, 21)
        Me.ComboBoxProductos.Name = "ComboBoxProductos"
        Me.ComboBoxProductos.Size = New System.Drawing.Size(129, 26)
        Me.ComboBoxProductos.TabIndex = 3
        '
        'CantidadProdTxt
        '
        Me.CantidadProdTxt.AllowDrop = True
        Me.CantidadProdTxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance3.FontData.SizeInPoints = 12.0!
        Me.CantidadProdTxt.Appearance = Appearance3
        Me.CantidadProdTxt.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.CantidadProdTxt.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.CantidadProdTxt.InputMask = "nnn,nnn.nn"
        Me.CantidadProdTxt.Location = New System.Drawing.Point(516, 72)
        Me.CantidadProdTxt.Name = "CantidadProdTxt"
        Me.CantidadProdTxt.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.CantidadProdTxt.Size = New System.Drawing.Size(84, 26)
        Me.CantidadProdTxt.TabIndex = 5
        '
        'TextBoxCodCodigo
        '
        Me.TextBoxCodCodigo.Location = New System.Drawing.Point(342, 22)
        Me.TextBoxCodCodigo.Name = "TextBoxCodCodigo"
        Me.TextBoxCodCodigo.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodCodigo.TabIndex = 187
        Me.TextBoxCodCodigo.TabStop = False
        '
        'TextBoxCodProducto
        '
        Me.TextBoxCodProducto.Location = New System.Drawing.Point(306, 22)
        Me.TextBoxCodProducto.Name = "TextBoxCodProducto"
        Me.TextBoxCodProducto.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodProducto.TabIndex = 186
        Me.TextBoxCodProducto.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Location = New System.Drawing.Point(608, 71)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(107, 28)
        Me.BtnGuardar.TabIndex = 6
        Me.BtnGuardar.Text = "Guardar"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AllowUserToResizeRows = False
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView3.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView3.ColumnHeadersHeight = 35
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAMTO3, Me.CODIGO3, Me.DESPRODUCTO3, Me.DESCODIGO13, Me.CONCEPTO3, Me.CANTIDAD3, Me.DESMEDIDA3, Me.DESUSUARIO3, Me.CODUSUARIO3, Me.PRODUCTO3, Me.CODMOVIMIENTO3, Me.CODCODIGO3, Me.CODDEPOSITO3, Me.NROMOVIMIENTO3})
        Me.DataGridView3.DataSource = Me.MOVPRODUCTOBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView3.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView3.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.DataGridView3.Location = New System.Drawing.Point(2, 106)
        Me.DataGridView3.MultiSelect = False
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView3.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView3.RowHeadersVisible = False
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(723, 392)
        Me.DataGridView3.TabIndex = 239
        '
        'FECHAMTO3
        '
        Me.FECHAMTO3.DataPropertyName = "FECHAMTO"
        Me.FECHAMTO3.HeaderText = "Fecha"
        Me.FECHAMTO3.Name = "FECHAMTO3"
        Me.FECHAMTO3.ReadOnly = True
        '
        'CODIGO3
        '
        Me.CODIGO3.DataPropertyName = "CODIGO"
        Me.CODIGO3.HeaderText = "Código"
        Me.CODIGO3.Name = "CODIGO3"
        Me.CODIGO3.ReadOnly = True
        '
        'DESPRODUCTO3
        '
        Me.DESPRODUCTO3.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTO3.HeaderText = "Producto"
        Me.DESPRODUCTO3.Name = "DESPRODUCTO3"
        Me.DESPRODUCTO3.ReadOnly = True
        '
        'DESCODIGO13
        '
        Me.DESCODIGO13.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO13.HeaderText = "Variante"
        Me.DESCODIGO13.Name = "DESCODIGO13"
        Me.DESCODIGO13.ReadOnly = True
        '
        'CONCEPTO3
        '
        Me.CONCEPTO3.DataPropertyName = "CONCEPTO"
        Me.CONCEPTO3.HeaderText = "Concepto"
        Me.CONCEPTO3.Name = "CONCEPTO3"
        Me.CONCEPTO3.ReadOnly = True
        '
        'CANTIDAD3
        '
        Me.CANTIDAD3.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD3.HeaderText = "Cant."
        Me.CANTIDAD3.Name = "CANTIDAD3"
        Me.CANTIDAD3.ReadOnly = True
        '
        'DESMEDIDA3
        '
        Me.DESMEDIDA3.DataPropertyName = "DESMEDIDA"
        Me.DESMEDIDA3.HeaderText = "U. M."
        Me.DESMEDIDA3.Name = "DESMEDIDA3"
        Me.DESMEDIDA3.ReadOnly = True
        '
        'DESUSUARIO3
        '
        Me.DESUSUARIO3.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIO3.HeaderText = "Usuario"
        Me.DESUSUARIO3.Name = "DESUSUARIO3"
        Me.DESUSUARIO3.ReadOnly = True
        '
        'CODUSUARIO3
        '
        Me.CODUSUARIO3.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIO3.HeaderText = "CODUSUARIO"
        Me.CODUSUARIO3.Name = "CODUSUARIO3"
        Me.CODUSUARIO3.ReadOnly = True
        Me.CODUSUARIO3.Visible = False
        '
        'PRODUCTO3
        '
        Me.PRODUCTO3.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO3.HeaderText = "PRODUCTO"
        Me.PRODUCTO3.Name = "PRODUCTO3"
        Me.PRODUCTO3.ReadOnly = True
        Me.PRODUCTO3.Visible = False
        '
        'CODMOVIMIENTO3
        '
        Me.CODMOVIMIENTO3.DataPropertyName = "CODMOVIMIENTO"
        Me.CODMOVIMIENTO3.HeaderText = "CODMOVIMIENTO"
        Me.CODMOVIMIENTO3.Name = "CODMOVIMIENTO3"
        Me.CODMOVIMIENTO3.ReadOnly = True
        Me.CODMOVIMIENTO3.Visible = False
        '
        'CODCODIGO3
        '
        Me.CODCODIGO3.DataPropertyName = "CODCODIGO"
        Me.CODCODIGO3.HeaderText = "CODCODIGO"
        Me.CODCODIGO3.Name = "CODCODIGO3"
        Me.CODCODIGO3.ReadOnly = True
        Me.CODCODIGO3.Visible = False
        '
        'CODDEPOSITO3
        '
        Me.CODDEPOSITO3.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITO3.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITO3.Name = "CODDEPOSITO3"
        Me.CODDEPOSITO3.ReadOnly = True
        Me.CODDEPOSITO3.Visible = False
        '
        'NROMOVIMIENTO3
        '
        Me.NROMOVIMIENTO3.DataPropertyName = "NROMOVIMIENTO"
        Me.NROMOVIMIENTO3.HeaderText = "NROMOVIMIENTO"
        Me.NROMOVIMIENTO3.Name = "NROMOVIMIENTO3"
        Me.NROMOVIMIENTO3.ReadOnly = True
        Me.NROMOVIMIENTO3.Visible = False
        '
        'MOVPRODUCTOBindingSource
        '
        Me.MOVPRODUCTOBindingSource.DataMember = "MOVPRODUCTOS"
        Me.MOVPRODUCTOBindingSource.DataSource = Me.DsInventario
        '
        'RadLabel4
        '
        Me.RadLabel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel4.ForeColor = System.Drawing.Color.Black
        Me.RadLabel4.Location = New System.Drawing.Point(129, 5)
        Me.RadLabel4.Name = "RadLabel4"
        '
        '
        '
        Me.RadLabel4.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel4.Size = New System.Drawing.Size(52, 16)
        Me.RadLabel4.TabIndex = 181
        Me.RadLabel4.Text = "Producto"
        '
        'RadLabel1
        '
        Me.RadLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel1.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Location = New System.Drawing.Point(133, 57)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Size = New System.Drawing.Size(55, 16)
        Me.RadLabel1.TabIndex = 183
        Me.RadLabel1.Text = "Concepto"
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(593, 2)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Size = New System.Drawing.Size(82, 16)
        Me.RadLabel2.TabIndex = 185
        Me.RadLabel2.Text = "Ajuste en (+)(-)"
        '
        'RadLabel5
        '
        Me.RadLabel5.ForeColor = System.Drawing.Color.Black
        Me.RadLabel5.Location = New System.Drawing.Point(1, 3)
        Me.RadLabel5.Name = "RadLabel5"
        '
        '
        '
        Me.RadLabel5.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel5.Size = New System.Drawing.Size(42, 16)
        Me.RadLabel5.TabIndex = 241
        Me.RadLabel5.Text = "Código"
        '
        'RadLabel6
        '
        Me.RadLabel6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel6.ForeColor = System.Drawing.Color.Black
        Me.RadLabel6.Location = New System.Drawing.Point(515, 56)
        Me.RadLabel6.Name = "RadLabel6"
        '
        '
        '
        Me.RadLabel6.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel6.Size = New System.Drawing.Size(52, 16)
        Me.RadLabel6.TabIndex = 182
        Me.RadLabel6.Text = "Cantidad"
        '
        'ProductosGroupBox
        '
        Me.ProductosGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.ProductosGroupBox.Controls.Add(Me.BuscarProductoTextBox)
        Me.ProductosGroupBox.Controls.Add(Me.PictureBox14)
        Me.ProductosGroupBox.Controls.Add(Me.RadGridView1)
        Me.ProductosGroupBox.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ProductosGroupBox.FooterImageIndex = -1
        Me.ProductosGroupBox.FooterImageKey = ""
        Me.ProductosGroupBox.HeaderImageIndex = -1
        Me.ProductosGroupBox.HeaderImageKey = ""
        Me.ProductosGroupBox.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.HeaderText = "Buscar: Productos "
        Me.ProductosGroupBox.Location = New System.Drawing.Point(949, 110)
        Me.ProductosGroupBox.Name = "ProductosGroupBox"
        Me.ProductosGroupBox.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.ProductosGroupBox.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.ProductosGroupBox.Size = New System.Drawing.Size(406, 436)
        Me.ProductosGroupBox.TabIndex = 46
        Me.ProductosGroupBox.Text = "Buscar: Productos "
        Me.ProductosGroupBox.ThemeName = "Breeze"
        Me.ProductosGroupBox.Visible = False
        '
        'BuscarProductoTextBox
        '
        Me.BuscarProductoTextBox.BackColor = System.Drawing.Color.DimGray
        Me.BuscarProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarProductoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarProductoTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarProductoTextBox.Location = New System.Drawing.Point(38, 25)
        Me.BuscarProductoTextBox.Name = "BuscarProductoTextBox"
        Me.BuscarProductoTextBox.Size = New System.Drawing.Size(360, 30)
        Me.BuscarProductoTextBox.TabIndex = 454
        Me.BuscarProductoTextBox.Text = "Buscar..."
        '
        'PictureBox14
        '
        Me.PictureBox14.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox14.BackgroundImage = CType(resources.GetObject("PictureBox14.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox14.Location = New System.Drawing.Point(7, 25)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox14.TabIndex = 455
        Me.PictureBox14.TabStop = False
        '
        'RadGridView1
        '
        Me.RadGridView1.BackColor = System.Drawing.Color.Lavender
        Me.RadGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RadGridView1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridView1.Location = New System.Drawing.Point(7, 59)
        '
        '
        '
        Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODCODIGO"
        GridViewDecimalColumn1.FieldName = "CODCODIGO"
        GridViewDecimalColumn1.HeaderText = "CODCODIGO"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODCODIGO"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "CODPRODUCTO"
        GridViewDecimalColumn2.FieldName = "CODPRODUCTO"
        GridViewDecimalColumn2.HeaderText = "CODPRODUCTO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODPRODUCTO"
        GridViewTextBoxColumn1.FieldAlias = "DESCODIGO1"
        GridViewTextBoxColumn1.FieldName = "DESCODIGO1"
        GridViewTextBoxColumn1.HeaderText = "DESCODIGO1"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.UniqueName = "DESCODIGO1"
        GridViewTextBoxColumn2.FieldAlias = "DESCODIGO2"
        GridViewTextBoxColumn2.FieldName = "DESCODIGO2"
        GridViewTextBoxColumn2.HeaderText = "DESCODIGO2"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.UniqueName = "DESCODIGO2"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn3.FieldName = "CODUSUARIO"
        GridViewDecimalColumn3.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn4.FieldName = "CODEMPRESA"
        GridViewDecimalColumn4.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODEMPRESA"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        GridViewTextBoxColumn3.FieldAlias = "CODIGO"
        GridViewTextBoxColumn3.FieldName = "CODIGO"
        GridViewTextBoxColumn3.HeaderText = "Código"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.UniqueName = "CODIGO"
        GridViewTextBoxColumn3.Width = 100
        GridViewTextBoxColumn4.FieldAlias = "DESPRODUCTO"
        GridViewTextBoxColumn4.FieldName = "DESPRODUCTO"
        GridViewTextBoxColumn4.HeaderText = "DESPRODUCTO"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.UniqueName = "DESPRODUCTO"
        GridViewTextBoxColumn5.FieldAlias = "PRODUCTO"
        GridViewTextBoxColumn5.FieldName = "PRODUCTO"
        GridViewTextBoxColumn5.HeaderText = "Producto"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.ReadOnly = True
        GridViewTextBoxColumn5.UniqueName = "PRODUCTO"
        GridViewTextBoxColumn5.Width = 270
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn4)
        Me.RadGridView1.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn5)
        Me.RadGridView1.MasterGridViewTemplate.DataSource = Me.CODIGOSBindingSource
        Me.RadGridView1.MasterGridViewTemplate.EnableFiltering = True
        Me.RadGridView1.MasterGridViewTemplate.ShowFilteringRow = False
        Me.RadGridView1.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.RadGridView1.Name = "RadGridView1"
        Me.RadGridView1.ReadOnly = True
        Me.RadGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RadGridView1.ShowGroupPanel = False
        Me.RadGridView1.Size = New System.Drawing.Size(391, 369)
        Me.RadGridView1.TabIndex = 378
        '
        'CODIGOSBindingSource
        '
        Me.CODIGOSBindingSource.DataMember = "CODIGOS"
        Me.CODIGOSBindingSource.DataSource = Me.DsInventario
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.ProductosGroupBox
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.RadLabel7)
        Me.Panel1.Controls.Add(Me.RadLabel16)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBoxTransferencia)
        Me.Panel1.Controls.Add(Me.PictureBoxProducto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(941, 40)
        Me.Panel1.TabIndex = 41
        '
        'RadLabel7
        '
        Me.RadLabel7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel7.AutoSize = False
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.RadLabel7.ForeColor = System.Drawing.Color.Black
        Me.RadLabel7.Location = New System.Drawing.Point(96, 7)
        Me.RadLabel7.Name = "RadLabel7"
        '
        '
        '
        Me.RadLabel7.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel7.Size = New System.Drawing.Size(404, 26)
        Me.RadLabel7.TabIndex = 463
        Me.RadLabel7.Text = "Local"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Location = New System.Drawing.Point(2, 7)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Size = New System.Drawing.Size(97, 26)
        Me.RadLabel16.TabIndex = 462
        Me.RadLabel16.Text = "Deposito :"
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Image = Global.ContaExpress.My.Resources.Resources.Create
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(902, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 461
        Me.PictureBox3.TabStop = False
        '
        'PictureBoxTransferencia
        '
        Me.PictureBoxTransferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxTransferencia.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxTransferencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxTransferencia.Image = Global.ContaExpress.My.Resources.Resources.Transfer
        Me.PictureBoxTransferencia.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxTransferencia.Location = New System.Drawing.Point(865, 2)
        Me.PictureBoxTransferencia.Name = "PictureBoxTransferencia"
        Me.PictureBoxTransferencia.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxTransferencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxTransferencia.TabIndex = 73
        Me.PictureBoxTransferencia.TabStop = False
        '
        'PictureBoxProducto
        '
        Me.PictureBoxProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxProducto.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxProducto.Image = Global.ContaExpress.My.Resources.Resources.StockActive
        Me.PictureBoxProducto.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxProducto.Location = New System.Drawing.Point(828, 2)
        Me.PictureBoxProducto.Name = "PictureBoxProducto"
        Me.PictureBoxProducto.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxProducto.TabIndex = 71
        Me.PictureBoxProducto.TabStop = False
        '
        'cbxTodos
        '
        Me.cbxTodos.AutoSize = True
        Me.cbxTodos.BackColor = System.Drawing.Color.Lavender
        Me.cbxTodos.ForeColor = System.Drawing.Color.Black
        Me.cbxTodos.Location = New System.Drawing.Point(1, 43)
        Me.cbxTodos.Name = "cbxTodos"
        Me.cbxTodos.Size = New System.Drawing.Size(155, 17)
        Me.cbxTodos.TabIndex = 460
        Me.cbxTodos.Text = "Ver Sucursales y Depositos"
        Me.cbxTodos.UseVisualStyleBackColor = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(690, 42)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(248, 30)
        Me.BuscarTextBox.TabIndex = 458
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Search
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(664, 42)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
        Me.PictureBox2.TabIndex = 459
        Me.PictureBox2.TabStop = False
        '
        'PanelTransferencia
        '
        Me.PanelTransferencia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelTransferencia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelTransferencia.BackColor = System.Drawing.Color.LightGray
        Me.PanelTransferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelTransferencia.Controls.Add(Me.txtCodigo)
        Me.PanelTransferencia.Controls.Add(Me.dtpFecha)
        Me.PanelTransferencia.Controls.Add(Me.CodModID)
        Me.PanelTransferencia.Controls.Add(Me.TxtConceptoTransf)
        Me.PanelTransferencia.Controls.Add(Me.TxtProductoTransf)
        Me.PanelTransferencia.Controls.Add(Me.CmbSucursalDestino)
        Me.PanelTransferencia.Controls.Add(Me.CmbSucursalOrigen)
        Me.PanelTransferencia.Controls.Add(Me.BtnGuardarTransf)
        Me.PanelTransferencia.Controls.Add(Me.TxtCantidadTransferido)
        Me.PanelTransferencia.Controls.Add(Me.dgvTransferencias)
        Me.PanelTransferencia.Controls.Add(Me.TxtCodCodigoTransf)
        Me.PanelTransferencia.Controls.Add(Me.TxtCodProductoTransf)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel3)
        Me.PanelTransferencia.Controls.Add(Me.Label1)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel15)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel13)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel9)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel11)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel10)
        Me.PanelTransferencia.Controls.Add(Me.RadLabel12)
        Me.PanelTransferencia.Location = New System.Drawing.Point(209, 75)
        Me.PanelTransferencia.Name = "PanelTransferencia"
        Me.PanelTransferencia.Size = New System.Drawing.Size(730, 502)
        Me.PanelTransferencia.TabIndex = 48
        '
        'txtCodigo
        '
        Me.txtCodigo.Controls.Add(Me.RadTextBox2)
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtCodigo.Location = New System.Drawing.Point(7, 76)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(122, 26)
        Me.txtCodigo.TabIndex = 5
        Me.txtCodigo.TabStop = False
        Me.txtCodigo.ThemeName = "Breeze"
        CType(Me.txtCodigo.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'RadTextBox2
        '
        Me.RadTextBox2.Location = New System.Drawing.Point(26, 50)
        Me.RadTextBox2.Name = "RadTextBox2"
        Me.RadTextBox2.Size = New System.Drawing.Size(35, 26)
        Me.RadTextBox2.TabIndex = 187
        Me.RadTextBox2.TabStop = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(488, 25)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(122, 27)
        Me.dtpFecha.TabIndex = 3
        '
        'CodModID
        '
        Me.CodModID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CodModID.BackColor = System.Drawing.Color.White
        Me.CodModID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CodModID.Location = New System.Drawing.Point(616, 26)
        Me.CodModID.Name = "CodModID"
        Me.CodModID.Size = New System.Drawing.Size(98, 26)
        Me.CodModID.TabIndex = 4
        Me.CodModID.TabStop = False
        Me.CodModID.ThemeName = "Breeze"
        CType(Me.CodModID.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = ""
        CType(Me.CodModID.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'TxtConceptoTransf
        '
        Me.TxtConceptoTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtConceptoTransf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtConceptoTransf.Location = New System.Drawing.Point(385, 76)
        Me.TxtConceptoTransf.Name = "TxtConceptoTransf"
        Me.TxtConceptoTransf.Size = New System.Drawing.Size(219, 26)
        Me.TxtConceptoTransf.TabIndex = 7
        Me.TxtConceptoTransf.TabStop = False
        Me.TxtConceptoTransf.ThemeName = "Breeze"
        CType(Me.TxtConceptoTransf.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).Text = ""
        CType(Me.TxtConceptoTransf.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'TxtProductoTransf
        '
        Me.TxtProductoTransf.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtProductoTransf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtProductoTransf.Location = New System.Drawing.Point(133, 76)
        Me.TxtProductoTransf.Name = "TxtProductoTransf"
        Me.TxtProductoTransf.Size = New System.Drawing.Size(249, 26)
        Me.TxtProductoTransf.TabIndex = 6
        Me.TxtProductoTransf.TabStop = False
        Me.TxtProductoTransf.ThemeName = "Breeze"
        CType(Me.TxtProductoTransf.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'CmbSucursalDestino
        '
        Me.CmbSucursalDestino.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbSucursalDestino.DataSource = Me.SUCURSALDestinoBindingSource
        Me.CmbSucursalDestino.DisplayMember = "DESSUCURSAL"
        Me.CmbSucursalDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursalDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSucursalDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.CmbSucursalDestino.FormattingEnabled = True
        Me.CmbSucursalDestino.Location = New System.Drawing.Point(248, 26)
        Me.CmbSucursalDestino.Name = "CmbSucursalDestino"
        Me.CmbSucursalDestino.Size = New System.Drawing.Size(235, 26)
        Me.CmbSucursalDestino.TabIndex = 2
        Me.CmbSucursalDestino.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALDestinoBindingSource
        '
        Me.SUCURSALDestinoBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALDestinoBindingSource.DataSource = Me.DsInventario
        '
        'CmbSucursalOrigen
        '
        Me.CmbSucursalOrigen.DataSource = Me.SUCURSALOrigenBindingSource
        Me.CmbSucursalOrigen.DisplayMember = "DESSUCURSAL"
        Me.CmbSucursalOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSucursalOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbSucursalOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.CmbSucursalOrigen.FormattingEnabled = True
        Me.CmbSucursalOrigen.Location = New System.Drawing.Point(5, 26)
        Me.CmbSucursalOrigen.Name = "CmbSucursalOrigen"
        Me.CmbSucursalOrigen.Size = New System.Drawing.Size(235, 26)
        Me.CmbSucursalOrigen.TabIndex = 1
        Me.CmbSucursalOrigen.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALOrigenBindingSource
        '
        Me.SUCURSALOrigenBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALOrigenBindingSource.DataSource = Me.DsInventario
        '
        'BtnGuardarTransf
        '
        Me.BtnGuardarTransf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardarTransf.Location = New System.Drawing.Point(665, 76)
        Me.BtnGuardarTransf.Name = "BtnGuardarTransf"
        Me.BtnGuardarTransf.Size = New System.Drawing.Size(58, 26)
        Me.BtnGuardarTransf.TabIndex = 9
        Me.BtnGuardarTransf.Text = "Guardar"
        '
        'TxtCantidadTransferido
        '
        Me.TxtCantidadTransferido.AllowDrop = True
        Me.TxtCantidadTransferido.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance1.FontData.SizeInPoints = 12.0!
        Appearance1.TextHAlignAsString = "Right"
        Me.TxtCantidadTransferido.Appearance = Appearance1
        Me.TxtCantidadTransferido.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TxtCantidadTransferido.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TxtCantidadTransferido.InputMask = "nnn,nnn.nn"
        Me.TxtCantidadTransferido.Location = New System.Drawing.Point(606, 76)
        Me.TxtCantidadTransferido.Name = "TxtCantidadTransferido"
        Me.TxtCantidadTransferido.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCantidadTransferido.Size = New System.Drawing.Size(56, 26)
        Me.TxtCantidadTransferido.TabIndex = 8
        '
        'dgvTransferencias
        '
        Me.dgvTransferencias.AllowUserToAddRows = False
        Me.dgvTransferencias.AllowUserToDeleteRows = False
        Me.dgvTransferencias.AllowUserToResizeRows = False
        Me.dgvTransferencias.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTransferencias.AutoGenerateColumns = False
        Me.dgvTransferencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTransferencias.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransferencias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTransferencias.ColumnHeadersHeight = 35
        Me.dgvTransferencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAMTOTR, Me.IDMOVIMIENTOSTRINGTR, Me.CODIGOTR, Me.DESPRODUCTOTR, Me.DESCODIGO1TR, Me.CONCEPTOTR, Me.CANTIDADTR, Me.DESSUCURSALTR, Me.DESUSUARIOTR, Me.CODMOVIMIENTOTR, Me.CODDEPOSITOTR, Me.NROMOVIMIENTOTR})
        Me.dgvTransferencias.DataSource = Me.TransferenciaMovimientoBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTransferencias.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvTransferencias.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvTransferencias.Location = New System.Drawing.Point(2, 107)
        Me.dgvTransferencias.MultiSelect = False
        Me.dgvTransferencias.Name = "dgvTransferencias"
        Me.dgvTransferencias.ReadOnly = True
        Me.dgvTransferencias.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTransferencias.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvTransferencias.RowHeadersVisible = False
        Me.dgvTransferencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTransferencias.Size = New System.Drawing.Size(723, 390)
        Me.dgvTransferencias.TabIndex = 241
        '
        'FECHAMTOTR
        '
        Me.FECHAMTOTR.DataPropertyName = "FECHAMTO"
        Me.FECHAMTOTR.HeaderText = "Fecha"
        Me.FECHAMTOTR.Name = "FECHAMTOTR"
        Me.FECHAMTOTR.ReadOnly = True
        '
        'IDMOVIMIENTOSTRINGTR
        '
        Me.IDMOVIMIENTOSTRINGTR.DataPropertyName = "IDMOVIMIENTOSTRING"
        Me.IDMOVIMIENTOSTRINGTR.HeaderText = "Cod. Mov."
        Me.IDMOVIMIENTOSTRINGTR.Name = "IDMOVIMIENTOSTRINGTR"
        Me.IDMOVIMIENTOSTRINGTR.ReadOnly = True
        '
        'CODIGOTR
        '
        Me.CODIGOTR.DataPropertyName = "CODIGO"
        Me.CODIGOTR.HeaderText = "Código"
        Me.CODIGOTR.Name = "CODIGOTR"
        Me.CODIGOTR.ReadOnly = True
        '
        'DESPRODUCTOTR
        '
        Me.DESPRODUCTOTR.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTOTR.HeaderText = "Producto"
        Me.DESPRODUCTOTR.Name = "DESPRODUCTOTR"
        Me.DESPRODUCTOTR.ReadOnly = True
        '
        'DESCODIGO1TR
        '
        Me.DESCODIGO1TR.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO1TR.HeaderText = "Variante"
        Me.DESCODIGO1TR.Name = "DESCODIGO1TR"
        Me.DESCODIGO1TR.ReadOnly = True
        '
        'CONCEPTOTR
        '
        Me.CONCEPTOTR.DataPropertyName = "CONCEPTO"
        Me.CONCEPTOTR.HeaderText = "Concepto"
        Me.CONCEPTOTR.Name = "CONCEPTOTR"
        Me.CONCEPTOTR.ReadOnly = True
        '
        'CANTIDADTR
        '
        Me.CANTIDADTR.DataPropertyName = "CANTIDAD"
        Me.CANTIDADTR.HeaderText = "Cantidad"
        Me.CANTIDADTR.Name = "CANTIDADTR"
        Me.CANTIDADTR.ReadOnly = True
        '
        'DESSUCURSALTR
        '
        Me.DESSUCURSALTR.DataPropertyName = "DESSUCURSAL"
        Me.DESSUCURSALTR.HeaderText = "Depósito"
        Me.DESSUCURSALTR.Name = "DESSUCURSALTR"
        Me.DESSUCURSALTR.ReadOnly = True
        '
        'DESUSUARIOTR
        '
        Me.DESUSUARIOTR.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIOTR.HeaderText = "Usuario"
        Me.DESUSUARIOTR.Name = "DESUSUARIOTR"
        Me.DESUSUARIOTR.ReadOnly = True
        '
        'CODMOVIMIENTOTR
        '
        Me.CODMOVIMIENTOTR.DataPropertyName = "CODMOVIMIENTO"
        Me.CODMOVIMIENTOTR.HeaderText = "CODMOVIMIENTO"
        Me.CODMOVIMIENTOTR.Name = "CODMOVIMIENTOTR"
        Me.CODMOVIMIENTOTR.ReadOnly = True
        Me.CODMOVIMIENTOTR.Visible = False
        '
        'CODDEPOSITOTR
        '
        Me.CODDEPOSITOTR.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITOTR.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITOTR.Name = "CODDEPOSITOTR"
        Me.CODDEPOSITOTR.ReadOnly = True
        Me.CODDEPOSITOTR.Visible = False
        '
        'NROMOVIMIENTOTR
        '
        Me.NROMOVIMIENTOTR.DataPropertyName = "NROMOVIMIENTO"
        Me.NROMOVIMIENTOTR.HeaderText = "NROMOVIMIENTO"
        Me.NROMOVIMIENTOTR.Name = "NROMOVIMIENTOTR"
        Me.NROMOVIMIENTOTR.ReadOnly = True
        Me.NROMOVIMIENTOTR.Visible = False
        '
        'TransferenciaMovimientoBindingSource
        '
        Me.TransferenciaMovimientoBindingSource.DataMember = "TransferenciaMovimiento"
        Me.TransferenciaMovimientoBindingSource.DataSource = Me.DsInventario
        '
        'TxtCodCodigoTransf
        '
        Me.TxtCodCodigoTransf.Location = New System.Drawing.Point(575, 126)
        Me.TxtCodCodigoTransf.Name = "TxtCodCodigoTransf"
        Me.TxtCodCodigoTransf.Size = New System.Drawing.Size(35, 20)
        Me.TxtCodCodigoTransf.TabIndex = 187
        Me.TxtCodCodigoTransf.TabStop = False
        '
        'TxtCodProductoTransf
        '
        Me.TxtCodProductoTransf.Location = New System.Drawing.Point(628, 126)
        Me.TxtCodProductoTransf.Name = "TxtCodProductoTransf"
        Me.TxtCodProductoTransf.Size = New System.Drawing.Size(30, 20)
        Me.TxtCodProductoTransf.TabIndex = 186
        Me.TxtCodProductoTransf.TabStop = False
        '
        'RadLabel3
        '
        Me.RadLabel3.ForeColor = System.Drawing.Color.Black
        Me.RadLabel3.Location = New System.Drawing.Point(5, 61)
        Me.RadLabel3.Name = "RadLabel3"
        '
        '
        '
        Me.RadLabel3.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel3.Size = New System.Drawing.Size(42, 16)
        Me.RadLabel3.TabIndex = 245
        Me.RadLabel3.Text = "Código"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(490, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 243
        Me.Label1.Text = "Fecha"
        '
        'RadLabel15
        '
        Me.RadLabel15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel15.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.Location = New System.Drawing.Point(619, 11)
        Me.RadLabel15.Name = "RadLabel15"
        '
        '
        '
        Me.RadLabel15.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.Size = New System.Drawing.Size(55, 16)
        Me.RadLabel15.TabIndex = 240
        Me.RadLabel15.Text = "Cod Mov."
        '
        'RadLabel13
        '
        Me.RadLabel13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel13.ForeColor = System.Drawing.Color.Black
        Me.RadLabel13.Location = New System.Drawing.Point(249, 10)
        Me.RadLabel13.Name = "RadLabel13"
        '
        '
        '
        Me.RadLabel13.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel13.Size = New System.Drawing.Size(92, 16)
        Me.RadLabel13.TabIndex = 236
        Me.RadLabel13.Text = "Sucursal Destino"
        '
        'RadLabel9
        '
        Me.RadLabel9.ForeColor = System.Drawing.Color.Black
        Me.RadLabel9.Location = New System.Drawing.Point(8, 11)
        Me.RadLabel9.Name = "RadLabel9"
        '
        '
        '
        Me.RadLabel9.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel9.Size = New System.Drawing.Size(87, 16)
        Me.RadLabel9.TabIndex = 235
        Me.RadLabel9.Text = "Sucursal Origen"
        '
        'RadLabel11
        '
        Me.RadLabel11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel11.ForeColor = System.Drawing.Color.Black
        Me.RadLabel11.Location = New System.Drawing.Point(605, 60)
        Me.RadLabel11.Name = "RadLabel11"
        '
        '
        '
        Me.RadLabel11.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel11.Size = New System.Drawing.Size(30, 16)
        Me.RadLabel11.TabIndex = 182
        Me.RadLabel11.Text = "Cant"
        '
        'RadLabel10
        '
        Me.RadLabel10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel10.ForeColor = System.Drawing.Color.Black
        Me.RadLabel10.Location = New System.Drawing.Point(387, 59)
        Me.RadLabel10.Name = "RadLabel10"
        '
        '
        '
        Me.RadLabel10.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel10.Size = New System.Drawing.Size(55, 16)
        Me.RadLabel10.TabIndex = 183
        Me.RadLabel10.Text = "Concepto"
        '
        'RadLabel12
        '
        Me.RadLabel12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel12.ForeColor = System.Drawing.Color.Black
        Me.RadLabel12.Location = New System.Drawing.Point(131, 61)
        Me.RadLabel12.Name = "RadLabel12"
        '
        '
        '
        Me.RadLabel12.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel12.Size = New System.Drawing.Size(52, 16)
        Me.RadLabel12.TabIndex = 181
        Me.RadLabel12.Text = "Producto"
        '
        'DsInventarioBindingSource
        '
        Me.DsInventarioBindingSource.DataSource = Me.DsInventario
        Me.DsInventarioBindingSource.Position = 0
        '
        'buscarAjuste
        '
        Me.buscarAjuste.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buscarAjuste.BackColor = System.Drawing.Color.Gainsboro
        Me.buscarAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.buscarAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscarAjuste.ForeColor = System.Drawing.Color.Black
        Me.buscarAjuste.Location = New System.Drawing.Point(696, 42)
        Me.buscarAjuste.Name = "buscarAjuste"
        Me.buscarAjuste.Size = New System.Drawing.Size(243, 30)
        Me.buscarAjuste.TabIndex = 463
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CODIGOMOVIEMIENTO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODIGOMOVIEMIENTO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CANTIDAD"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DESMEDIDA
        '
        Me.DESMEDIDA.DataPropertyName = "DESMEDIDA"
        Me.DESMEDIDA.HeaderText = "U.M"
        Me.DESMEDIDA.Name = "DESMEDIDA"
        '
        'CONCEPTO
        '
        Me.CONCEPTO.DataPropertyName = "CONCEPTO"
        Me.CONCEPTO.HeaderText = "Concepto"
        Me.CONCEPTO.Name = "CONCEPTO"
        '
        'TIPOMOVIMIENTO
        '
        Me.TIPOMOVIMIENTO.DataPropertyName = "TIPOMOVIMIENTO"
        Me.TIPOMOVIMIENTO.HeaderText = "Tipo Mov."
        Me.TIPOMOVIMIENTO.Name = "TIPOMOVIMIENTO"
        '
        'FECHAMTO
        '
        Me.FECHAMTO.DataPropertyName = "FECHAMTO"
        Me.FECHAMTO.HeaderText = "Fecha"
        Me.FECHAMTO.Name = "FECHAMTO"
        '
        'DESUSUARIO
        '
        Me.DESUSUARIO.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIO.HeaderText = "Usuario"
        Me.DESUSUARIO.Name = "DESUSUARIO"
        '
        'CODUSUARIO
        '
        Me.CODUSUARIO.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIO.HeaderText = "CODUSUARIO"
        Me.CODUSUARIO.Name = "CODUSUARIO"
        Me.CODUSUARIO.Visible = False
        '
        'CODSUCURSAL
        '
        Me.CODSUCURSAL.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSAL.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSAL.Name = "CODSUCURSAL"
        Me.CODSUCURSAL.Visible = False
        '
        'CODPRODUCTO
        '
        Me.CODPRODUCTO.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTO.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTO.Name = "CODPRODUCTO"
        Me.CODPRODUCTO.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CODIGOMOVIEMIENTO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODIGOMOVIEMIENTO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'IDMOVIMIENTO
        '
        Me.IDMOVIMIENTO.DataPropertyName = "CODIGOMOVIEMIENTO"
        Me.IDMOVIMIENTO.HeaderText = "Cod Movimiento"
        Me.IDMOVIMIENTO.Name = "IDMOVIMIENTO"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CANTIDAD"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Cantidad"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "DESMEDIDA"
        Me.DataGridViewTextBoxColumn5.HeaderText = "U.M"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "TIPOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Tipo Mov."
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "FECHAMTO"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "DESUSUARIO"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Usuario"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn10.HeaderText = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Visible = False
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "CODSUCURSAL"
        Me.DataGridViewTextBoxColumn11.HeaderText = "CODSUCURSAL"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Visible = False
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "CODPRODUCTO"
        Me.DataGridViewTextBoxColumn12.HeaderText = "CODPRODUCTO"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'CODCODIGO
        '
        Me.CODCODIGO.DataPropertyName = "CODCODIGO"
        Me.CODCODIGO.HeaderText = "CODCODIGO"
        Me.CODCODIGO.Name = "CODCODIGO"
        Me.CODCODIGO.Visible = False
        '
        'CODIGOMOVIEMIENTO
        '
        Me.CODIGOMOVIEMIENTO.DataPropertyName = "CODIGOMOVIEMIENTO"
        Me.CODIGOMOVIEMIENTO.HeaderText = "CODIGOMOVIEMIENTO"
        Me.CODIGOMOVIEMIENTO.Name = "CODIGOMOVIEMIENTO"
        Me.CODIGOMOVIEMIENTO.Visible = False
        '
        'IDMOVIEMIENTO
        '
        Me.IDMOVIEMIENTO.HeaderText = "Cod Movimiento"
        Me.IDMOVIEMIENTO.Name = "IDMOVIEMIENTO"
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD.HeaderText = "Cantidad"
        Me.CANTIDAD.Name = "CANTIDAD"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "DESMEDIDA"
        Me.DataGridViewTextBoxColumn30.HeaderText = "U.M"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn31.HeaderText = "Concepto"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "TIPOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn32.HeaderText = "Tipo Mov."
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "FECHAMTO"
        Me.DataGridViewTextBoxColumn33.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "DESUSUARIO"
        Me.DataGridViewTextBoxColumn34.HeaderText = "Usuario"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn37.HeaderText = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.Visible = False
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "CODSUCURSAL"
        Me.DataGridViewTextBoxColumn38.HeaderText = "CODSUCURSAL"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        Me.DataGridViewTextBoxColumn38.Visible = False
        '
        'DataGridViewTextBoxColumn35
        '
        Me.DataGridViewTextBoxColumn35.DataPropertyName = "CODPRODUCTO"
        Me.DataGridViewTextBoxColumn35.HeaderText = "CODPRODUCTO"
        Me.DataGridViewTextBoxColumn35.Name = "DataGridViewTextBoxColumn35"
        Me.DataGridViewTextBoxColumn35.Visible = False
        '
        'DataGridViewTextBoxColumn36
        '
        Me.DataGridViewTextBoxColumn36.DataPropertyName = "CODCODIGO"
        Me.DataGridViewTextBoxColumn36.HeaderText = "CODCODIGO"
        Me.DataGridViewTextBoxColumn36.Name = "DataGridViewTextBoxColumn36"
        Me.DataGridViewTextBoxColumn36.Visible = False
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AJUSTEDETALLETableAdapter = Nothing
        Me.TableAdapterManager.AJUSTETableAdapter = Nothing
        Me.TableAdapterManager.AUDITORIATABLASTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CONCEPTOTableAdapter = Nothing
        Me.TableAdapterManager.LINEATableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.RUBROTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Me.SUCURSALTableAdapter
        Me.TableAdapterManager.TIPOCOMPROBANTETableAdapter = Nothing
        Me.TableAdapterManager.TRANFERENCIATableAdapter = Nothing
        Me.TableAdapterManager.TRANSFERENCIASDETALLETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsInventarioTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CODIGOSTableAdapter
        '
        Me.CODIGOSTableAdapter.ClearBeforeFill = True
        '
        'MOVPRODUCTOSTableAdapter
        '
        Me.MOVPRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'MOVIMIENTOPRODUCTOTableAdapter1
        '
        Me.MOVIMIENTOPRODUCTOTableAdapter1.ClearBeforeFill = True
        '
        'lbxPanel
        '
        Me.lbxPanel.AutoSize = True
        Me.lbxPanel.BackColor = System.Drawing.Color.Transparent
        Me.lbxPanel.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxPanel.ForeColor = System.Drawing.Color.OrangeRed
        Me.lbxPanel.Location = New System.Drawing.Point(210, 43)
        Me.lbxPanel.Name = "lbxPanel"
        Me.lbxPanel.Size = New System.Drawing.Size(199, 28)
        Me.lbxPanel.TabIndex = 461
        Me.lbxPanel.Text = "Ajuste de Inventario"
        '
        'TransferenciaMovimientoTableAdapter
        '
        Me.TransferenciaMovimientoTableAdapter.ClearBeforeFill = True
        '
        'dgvDeposito
        '
        Me.dgvDeposito.AllowUserToAddRows = False
        Me.dgvDeposito.AllowUserToDeleteRows = False
        Me.dgvDeposito.AllowUserToResizeColumns = False
        Me.dgvDeposito.AllowUserToResizeRows = False
        Me.dgvDeposito.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDeposito.AutoGenerateColumns = False
        Me.dgvDeposito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDeposito.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvDeposito.ColumnHeadersHeight = 30
        Me.dgvDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDeposito.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODSUCURSALDataGridViewTextBoxColumn3, Me.NUMSUCURSALDataGridViewTextBoxColumn2, Me.DESSUCURSALDataGridViewTextBoxColumn3, Me.TIPOSUCURSALDataGridViewTextBoxColumn2})
        Me.dgvDeposito.DataSource = Me.SUCURSALBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDeposito.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDeposito.Location = New System.Drawing.Point(0, 61)
        Me.dgvDeposito.Name = "dgvDeposito"
        Me.dgvDeposito.ReadOnly = True
        Me.dgvDeposito.RowHeadersVisible = False
        Me.dgvDeposito.Size = New System.Drawing.Size(206, 518)
        Me.dgvDeposito.TabIndex = 462
        '
        'CODSUCURSALDataGridViewTextBoxColumn3
        '
        Me.CODSUCURSALDataGridViewTextBoxColumn3.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn3.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn3.Name = "CODSUCURSALDataGridViewTextBoxColumn3"
        Me.CODSUCURSALDataGridViewTextBoxColumn3.ReadOnly = True
        Me.CODSUCURSALDataGridViewTextBoxColumn3.Visible = False
        '
        'NUMSUCURSALDataGridViewTextBoxColumn2
        '
        Me.NUMSUCURSALDataGridViewTextBoxColumn2.DataPropertyName = "NUMSUCURSAL"
        Me.NUMSUCURSALDataGridViewTextBoxColumn2.HeaderText = "NUMSUCURSAL"
        Me.NUMSUCURSALDataGridViewTextBoxColumn2.Name = "NUMSUCURSALDataGridViewTextBoxColumn2"
        Me.NUMSUCURSALDataGridViewTextBoxColumn2.ReadOnly = True
        Me.NUMSUCURSALDataGridViewTextBoxColumn2.Visible = False
        '
        'DESSUCURSALDataGridViewTextBoxColumn3
        '
        Me.DESSUCURSALDataGridViewTextBoxColumn3.DataPropertyName = "DESSUCURSAL"
        Me.DESSUCURSALDataGridViewTextBoxColumn3.HeaderText = "Depósito"
        Me.DESSUCURSALDataGridViewTextBoxColumn3.Name = "DESSUCURSALDataGridViewTextBoxColumn3"
        Me.DESSUCURSALDataGridViewTextBoxColumn3.ReadOnly = True
        '
        'TIPOSUCURSALDataGridViewTextBoxColumn2
        '
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2.DataPropertyName = "TIPOSUCURSAL"
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2.HeaderText = "TIPOSUCURSAL"
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2.Name = "TIPOSUCURSALDataGridViewTextBoxColumn2"
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2.ReadOnly = True
        Me.TIPOSUCURSALDataGridViewTextBoxColumn2.Visible = False
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.lblClienteEstado})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 579)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(941, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 465
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel2.IsLink = True
        Me.ToolStripStatusLabel2.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel2.Text = "Ayuda"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(724, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "F6 - Elimina un Movimiento"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClienteEstado
        '
        Me.lblClienteEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteEstado.Name = "lblClienteEstado"
        Me.lblClienteEstado.Size = New System.Drawing.Size(145, 17)
        Me.lblClienteEstado.Text = "Movimiento de Productos"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFiltros.BackColor = System.Drawing.Color.LightGray
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.btnFiltro)
        Me.pnlFiltros.Controls.Add(Me.chkMovimientos)
        Me.pnlFiltros.Controls.Add(Me.chkTransacciones)
        Me.pnlFiltros.Controls.Add(Me.chkAjustes)
        Me.pnlFiltros.Controls.Add(Me.PictureBox4)
        Me.pnlFiltros.Controls.Add(Me.Fecha2)
        Me.pnlFiltros.Controls.Add(Me.Label4)
        Me.pnlFiltros.Controls.Add(Me.Fecha1)
        Me.pnlFiltros.Controls.Add(Me.Label3)
        Me.pnlFiltros.Controls.Add(Me.TextBox2)
        Me.pnlFiltros.Controls.Add(Me.DataGridView1)
        Me.pnlFiltros.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.pnlFiltros.Location = New System.Drawing.Point(209, 75)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(730, 502)
        Me.pnlFiltros.TabIndex = 466
        '
        'btnFiltro
        '
        Me.btnFiltro.Location = New System.Drawing.Point(625, 28)
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Size = New System.Drawing.Size(90, 26)
        Me.btnFiltro.TabIndex = 77786
        Me.btnFiltro.Text = "Filtrar"
        '
        'chkMovimientos
        '
        Me.chkMovimientos.AutoSize = True
        Me.chkMovimientos.BackColor = System.Drawing.Color.Transparent
        Me.chkMovimientos.ForeColor = System.Drawing.Color.Black
        Me.chkMovimientos.Location = New System.Drawing.Point(510, 33)
        Me.chkMovimientos.Name = "chkMovimientos"
        Me.chkMovimientos.Size = New System.Drawing.Size(104, 17)
        Me.chkMovimientos.TabIndex = 77785
        Me.chkMovimientos.Text = "Ver Movimientos"
        Me.chkMovimientos.UseVisualStyleBackColor = False
        '
        'chkTransacciones
        '
        Me.chkTransacciones.AutoSize = True
        Me.chkTransacciones.BackColor = System.Drawing.Color.Transparent
        Me.chkTransacciones.ForeColor = System.Drawing.Color.Black
        Me.chkTransacciones.Location = New System.Drawing.Point(384, 33)
        Me.chkTransacciones.Name = "chkTransacciones"
        Me.chkTransacciones.Size = New System.Drawing.Size(115, 17)
        Me.chkTransacciones.TabIndex = 77784
        Me.chkTransacciones.Text = "Ver Transferencias"
        Me.chkTransacciones.UseVisualStyleBackColor = False
        '
        'chkAjustes
        '
        Me.chkAjustes.AutoSize = True
        Me.chkAjustes.BackColor = System.Drawing.Color.Transparent
        Me.chkAjustes.ForeColor = System.Drawing.Color.Black
        Me.chkAjustes.Location = New System.Drawing.Point(294, 33)
        Me.chkAjustes.Name = "chkAjustes"
        Me.chkAjustes.Size = New System.Drawing.Size(79, 17)
        Me.chkAjustes.TabIndex = 77783
        Me.chkAjustes.Text = "Ver Ajustes"
        Me.chkAjustes.UseVisualStyleBackColor = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.White
        Me.PictureBox4.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Search
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(6, 63)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(27, 27)
        Me.PictureBox4.TabIndex = 77782
        Me.PictureBox4.TabStop = False
        '
        'Fecha2
        '
        Me.Fecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Fecha2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha2.Location = New System.Drawing.Point(151, 28)
        Me.Fecha2.Name = "Fecha2"
        Me.Fecha2.Size = New System.Drawing.Size(132, 27)
        Me.Fecha2.TabIndex = 77780
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(150, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 77781
        Me.Label4.Text = "Hasta"
        '
        'Fecha1
        '
        Me.Fecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.Fecha1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Fecha1.Location = New System.Drawing.Point(8, 28)
        Me.Fecha1.Name = "Fecha1"
        Me.Fecha1.Size = New System.Drawing.Size(132, 27)
        Me.Fecha1.TabIndex = 77778
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 77779
        Me.Label3.Text = "Desde"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(32, 63)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(682, 27)
        Me.TextBox2.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.ColumnHeadersHeight = 35
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NROMOVIMIENTO2, Me.FECHAMTO2, Me.CODIGO2, Me.PRODUCTO2, Me.DESCODIGO12, Me.CONCEPTO2, Me.CANTIDAD2, Me.DESMEDIDA2, Me.DESUSUARIO2, Me.CODUSUARIO2, Me.CODEMPRESA2, Me.DESPRODUCTO2, Me.IDMOVIMIENTO2, Me.CODMOVIMIENTO2, Me.CODCODIGO2, Me.CODDEPOSITO2})
        Me.DataGridView1.DataSource = Me.MOVPRODUCTOBindingSource
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.DataGridView1.Location = New System.Drawing.Point(4, 96)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(723, 398)
        Me.DataGridView1.TabIndex = 239
        '
        'NROMOVIMIENTO2
        '
        Me.NROMOVIMIENTO2.DataPropertyName = "NROMOVIMIENTO"
        Me.NROMOVIMIENTO2.HeaderText = "Cod. Mov."
        Me.NROMOVIMIENTO2.Name = "NROMOVIMIENTO2"
        Me.NROMOVIMIENTO2.ReadOnly = True
        '
        'FECHAMTO2
        '
        Me.FECHAMTO2.DataPropertyName = "FECHAMTO"
        Me.FECHAMTO2.HeaderText = "Fecha"
        Me.FECHAMTO2.Name = "FECHAMTO2"
        Me.FECHAMTO2.ReadOnly = True
        '
        'CODIGO2
        '
        Me.CODIGO2.DataPropertyName = "CODIGO"
        Me.CODIGO2.HeaderText = "Código"
        Me.CODIGO2.Name = "CODIGO2"
        Me.CODIGO2.ReadOnly = True
        '
        'PRODUCTO2
        '
        Me.PRODUCTO2.DataPropertyName = "PRODUCTO"
        Me.PRODUCTO2.HeaderText = "Producto"
        Me.PRODUCTO2.Name = "PRODUCTO2"
        Me.PRODUCTO2.ReadOnly = True
        '
        'DESCODIGO12
        '
        Me.DESCODIGO12.DataPropertyName = "DESCODIGO1"
        Me.DESCODIGO12.HeaderText = "Variante"
        Me.DESCODIGO12.Name = "DESCODIGO12"
        Me.DESCODIGO12.ReadOnly = True
        '
        'CONCEPTO2
        '
        Me.CONCEPTO2.DataPropertyName = "CONCEPTO"
        Me.CONCEPTO2.HeaderText = "Concepto"
        Me.CONCEPTO2.Name = "CONCEPTO2"
        Me.CONCEPTO2.ReadOnly = True
        '
        'CANTIDAD2
        '
        Me.CANTIDAD2.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD2.HeaderText = "Cant."
        Me.CANTIDAD2.Name = "CANTIDAD2"
        Me.CANTIDAD2.ReadOnly = True
        '
        'DESMEDIDA2
        '
        Me.DESMEDIDA2.DataPropertyName = "DESMEDIDA"
        Me.DESMEDIDA2.HeaderText = "U. M."
        Me.DESMEDIDA2.Name = "DESMEDIDA2"
        Me.DESMEDIDA2.ReadOnly = True
        '
        'DESUSUARIO2
        '
        Me.DESUSUARIO2.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIO2.HeaderText = "Usuario"
        Me.DESUSUARIO2.Name = "DESUSUARIO2"
        Me.DESUSUARIO2.ReadOnly = True
        '
        'CODUSUARIO2
        '
        Me.CODUSUARIO2.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIO2.HeaderText = "CODUSUARIO"
        Me.CODUSUARIO2.Name = "CODUSUARIO2"
        Me.CODUSUARIO2.ReadOnly = True
        Me.CODUSUARIO2.Visible = False
        '
        'CODEMPRESA2
        '
        Me.CODEMPRESA2.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESA2.HeaderText = "CODEMPRESA"
        Me.CODEMPRESA2.Name = "CODEMPRESA2"
        Me.CODEMPRESA2.ReadOnly = True
        Me.CODEMPRESA2.Visible = False
        '
        'DESPRODUCTO2
        '
        Me.DESPRODUCTO2.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTO2.HeaderText = "DESPRODUCTO"
        Me.DESPRODUCTO2.Name = "DESPRODUCTO2"
        Me.DESPRODUCTO2.ReadOnly = True
        Me.DESPRODUCTO2.Visible = False
        '
        'IDMOVIMIENTO2
        '
        Me.IDMOVIMIENTO2.DataPropertyName = "IDMOVIMIENTO"
        Me.IDMOVIMIENTO2.HeaderText = "IDMOVIMIENTO"
        Me.IDMOVIMIENTO2.Name = "IDMOVIMIENTO2"
        Me.IDMOVIMIENTO2.ReadOnly = True
        Me.IDMOVIMIENTO2.Visible = False
        '
        'CODMOVIMIENTO2
        '
        Me.CODMOVIMIENTO2.DataPropertyName = "CODMOVIMIENTO"
        Me.CODMOVIMIENTO2.HeaderText = "CODMOVIMIENTO"
        Me.CODMOVIMIENTO2.Name = "CODMOVIMIENTO2"
        Me.CODMOVIMIENTO2.ReadOnly = True
        Me.CODMOVIMIENTO2.Visible = False
        '
        'CODCODIGO2
        '
        Me.CODCODIGO2.DataPropertyName = "CODCODIGO"
        Me.CODCODIGO2.HeaderText = "CODCODIGO"
        Me.CODCODIGO2.Name = "CODCODIGO2"
        Me.CODCODIGO2.ReadOnly = True
        Me.CODCODIGO2.Visible = False
        '
        'CODDEPOSITO2
        '
        Me.CODDEPOSITO2.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITO2.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITO2.Name = "CODDEPOSITO2"
        Me.CODDEPOSITO2.ReadOnly = True
        Me.CODDEPOSITO2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Lavender
        Me.Panel2.Location = New System.Drawing.Point(-3, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(209, 67)
        Me.Panel2.TabIndex = 545
        '
        'STOCKDEPOSITOTableAdapter
        '
        Me.STOCKDEPOSITOTableAdapter.ClearBeforeFill = True
        '
        'DsInventario1
        '
        Me.DsInventario1.DataSetName = "DsInventario"
        Me.DsInventario1.EnforceConstraints = False
        Me.DsInventario1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AjusteInventario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(941, 601)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cbxTodos)
        Me.Controls.Add(Me.ProductosGroupBox)
        Me.Controls.Add(Me.lbxPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvDeposito)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.buscarAjuste)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelProducto)
        Me.Controls.Add(Me.PanelTransferencia)
        Me.Controls.Add(Me.pnlFiltros)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(800, 600)
        Me.Name = "AjusteInventario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimientos  | Cogent SIG"
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelProducto.ResumeLayout(False)
        Me.PanelProducto.PerformLayout()
        CType(Me.BtnProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MOVPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxTransferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTransferencia.ResumeLayout(False)
        Me.PanelTransferencia.PerformLayout()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.txtCodigo.ResumeLayout(False)
        Me.txtCodigo.PerformLayout()
        CType(Me.RadTextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodModID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtConceptoTransf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProductoTransf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALDestinoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALOrigenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGuardarTransf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransferenciaMovimientoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodCodigoTransf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodProductoTransf, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FKMOVIMIENTOSRELATIONSCODIGOS1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        CType(Me.btnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBoxProducto As System.Windows.Forms.PictureBox
    Friend WithEvents PanelProducto As System.Windows.Forms.Panel
    Friend WithEvents DsInventario As ContaExpress.DsInventario
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsInventarioTableAdapters.TableAdapterManager
    Friend WithEvents BtnGuardar As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents ProductosGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TextBoxCodCodigo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TextBoxCodProducto As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents CantidadProdTxt As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents CODIGOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGOSTableAdapter As ContaExpress.DsInventarioTableAdapters.CODIGOSTableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents TextBoxProductos As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadGridView1 As Telerik.WinControls.UI.RadGridView
    Friend WithEvents ComboBoxProductos As System.Windows.Forms.ComboBox

    Friend WithEvents BtnProducto As Telerik.WinControls.UI.RadButton
    Friend WithEvents PictureBoxTransferencia As System.Windows.Forms.PictureBox
    Friend WithEvents PanelTransferencia As System.Windows.Forms.Panel
    Friend WithEvents CmbSucursalOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents TxtProductoTransf As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TxtCantidadTransferido As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents TxtCodCodigoTransf As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TxtCodProductoTransf As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TxtConceptoTransf As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents BtnGuardarTransf As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents CmbSucursalDestino As System.Windows.Forms.ComboBox
    Friend WithEvents SUCURSALOrigenBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALDestinoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MOVPRODUCTOSTableAdapter As ContaExpress.DsInventarioTableAdapters.MOVPRODUCTOSTableAdapter
    Friend WithEvents CodModID As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents FKMOVIMIENTOSRELATIONSCODIGOS1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOMOVIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOVIMIENTOPRODUCTOTableAdapter1 As ContaExpress.DsInventarioTableAdapters.MOVIMIENTOPRODUCTOTableAdapter
    Friend WithEvents dgvTransferencias As System.Windows.Forms.DataGridView
    Friend WithEvents CODIGOMOVIEMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIEMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn35 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn36 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents cbxTodos As System.Windows.Forms.CheckBox
    Friend WithEvents lbxPanel As System.Windows.Forms.Label
    Friend WithEvents DsInventarioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransferenciaMovimientoTableAdapter As ContaExpress.DsInventarioTableAdapters.TransferenciaMovimientoTableAdapter
    Friend WithEvents TIPOMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDeposito As System.Windows.Forms.DataGridView
    Friend WithEvents BuscarProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents tbxProducto As System.Windows.Forms.TextBox
    Friend WithEvents tbxConceptoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents buscarAjuste As System.Windows.Forms.TextBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadTextBox2 As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtCodigoAjuste As System.Windows.Forms.TextBox
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblClienteEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpFechaAjuste As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents Fecha1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Fecha2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents chkMovimientos As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransacciones As System.Windows.Forms.CheckBox
    Friend WithEvents chkAjustes As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CODIGOMOVIEMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOMOVIEMIENTODataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCOMPROVANTEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTO1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESA1DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOMOVIEMIENTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCOMPROVANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESA1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKDEPOSITOTableAdapter As ContaExpress.DsInventarioTableAdapters.STOCKDEPOSITOTableAdapter
    Friend WithEvents MOVPRODUCTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransferenciaMovimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMSUCURSALDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSALDataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOSUCURSALDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROMOVIMIENTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDA2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESA2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMOVIMIENTO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDA3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMOVIMIENTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROMOVIMIENTO3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMTOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDMOVIMIENTOSTRINGTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCODIGO1TR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSALTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMOVIMIENTOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROMOVIMIENTOTR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsInventario1 As ContaExpress.DsInventario
End Class
