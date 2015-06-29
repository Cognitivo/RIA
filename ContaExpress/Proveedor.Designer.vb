<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Proveedor
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Proveedor))
        Me.PROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProveedores = New ContaExpress.DsProveedores()
        Me.CodProvTextBox = New System.Windows.Forms.TextBox()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.CENTROCOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CATEGORIAPROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PROVEEDORTableAdapter = New ContaExpress.DsProveedoresTableAdapters.PROVEEDORTableAdapter()
        Me.CENTROCOSTOTableAdapter = New ContaExpress.DsProveedoresTableAdapters.CENTROCOSTOTableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DsProveedoresTableAdapters.MONEDATableAdapter()
        Me.CATEGORIAPROVEEDORTableAdapter = New ContaExpress.DsProveedoresTableAdapters.CATEGORIAPROVEEDORTableAdapter()
        Me.BtnGuardarP1 = New Telerik.WinControls.UI.RadButton()
        Me.BtnNuevoP1 = New Telerik.WinControls.UI.RadButton()
        Me.NumProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.NombreProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.ProveedorGridView = New System.Windows.Forms.DataGridView()
        Me.NUMPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIASLOGISTICA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIASVENCIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAVTOTIMBRADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAPAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCCINDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODZONADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CELULARDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAXDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WEBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObservacionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImagenDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MASCARADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCENTRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAJURIDICADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTEIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RucProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.TimbradoTextBox = New System.Windows.Forms.TextBox()
        Me.DireccionProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.TelefonoProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.pnlProveedor = New System.Windows.Forms.Panel()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAddPais = New System.Windows.Forms.PictureBox()
        Me.btnIrLink = New System.Windows.Forms.PictureBox()
        Me.txtGMaps = New System.Windows.Forms.TextBox()
        Me.tbxCodPostal = New System.Windows.Forms.TextBox()
        Me.btnVerContacto = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.tbxContacto = New System.Windows.Forms.TextBox()
        Me.cmbPais = New System.Windows.Forms.ComboBox()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCliente = New ContaExpress.DsCliente()
        Me.cbxZona = New System.Windows.Forms.ComboBox()
        Me.ZONABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCiudad = New System.Windows.Forms.ComboBox()
        Me.CIUDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxRepresentanteLegal = New System.Windows.Forms.TextBox()
        Me.Cuotas = New System.Windows.Forms.Label()
        Me.tbxCantCuotas = New System.Windows.Forms.TextBox()
        Me.dtpVtoTimbrado = New System.Windows.Forms.DateTimePicker()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.pbxAgregarCentroCosto = New System.Windows.Forms.PictureBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbxDiasVto = New System.Windows.Forms.TextBox()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.tbxEmailGral = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chbxExterior = New System.Windows.Forms.CheckBox()
        Me.MonedaComboBox = New System.Windows.Forms.ComboBox()
        Me.CentroCostoComboBox = New System.Windows.Forms.ComboBox()
        Me.CategoriaComboBox = New System.Windows.Forms.ComboBox()
        Me.CategoriaTextBox = New System.Windows.Forms.TextBox()
        Me.lblMensajeError = New Telerik.WinControls.UI.RadLabel()
        Me.pnlContacto = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbxTelContacto = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tbxMail2Contacto = New System.Windows.Forms.TextBox()
        Me.tbxMail1Contacto = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.lblNombreContacto = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.tbxCelContacto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtNomCont2 = New System.Windows.Forms.TextBox()
        Me.txtEmailCont2 = New System.Windows.Forms.TextBox()
        Me.txtDirCont2 = New System.Windows.Forms.TextBox()
        Me.txtTelCont2 = New System.Windows.Forms.TextBox()
        Me.pbxLink = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tbxProveedorEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barProveedor = New System.Windows.Forms.ToolStripProgressBar()
        Me.txtTelCont1 = New System.Windows.Forms.TextBox()
        Me.txtDirCont1 = New System.Windows.Forms.TextBox()
        Me.txtEmailCont1 = New System.Windows.Forms.TextBox()
        Me.txtNomCont1 = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.PanelContacto = New System.Windows.Forms.Panel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.lblFormaPago = New System.Windows.Forms.Label()
        Me.PictureBoxActivo = New System.Windows.Forms.PictureBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarProveedorTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxDatosContacto = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PAISTableAdapter = New ContaExpress.DsClienteTableAdapters.PAISTableAdapter()
        Me.CIUDADTableAdapter = New ContaExpress.DsClienteTableAdapters.CIUDADTableAdapter()
        Me.ZONATableAdapter = New ContaExpress.DsClienteTableAdapters.ZONATableAdapter()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CATEGORIAPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGuardarP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnNuevoP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProveedorGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProveedor.SuspendLayout()
        CType(Me.btnAddPais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnIrLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnVerContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarCentroCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensajeError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContacto.SuspendLayout()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.PanelContacto.SuspendLayout()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxDatosContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PROVEEDORBindingSource
        '
        Me.PROVEEDORBindingSource.DataMember = "PROVEEDOR"
        Me.PROVEEDORBindingSource.DataSource = Me.DsProveedores
        '
        'DsProveedores
        '
        Me.DsProveedores.DataSetName = "DsProveedores"
        Me.DsProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CodProvTextBox
        '
        Me.CodProvTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.CodProvTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CODPROVEEDOR", True))
        Me.CodProvTextBox.Location = New System.Drawing.Point(180, 177)
        Me.CodProvTextBox.Name = "CodProvTextBox"
        Me.CodProvTextBox.ReadOnly = True
        Me.CodProvTextBox.Size = New System.Drawing.Size(24, 20)
        Me.CodProvTextBox.TabIndex = 289
        '
        'CENTROCOSTOBindingSource
        '
        Me.CENTROCOSTOBindingSource.DataMember = "CENTROCOSTO"
        Me.CENTROCOSTOBindingSource.DataSource = Me.DsProveedores
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsProveedores
        '
        'CATEGORIAPROVEEDORBindingSource
        '
        Me.CATEGORIAPROVEEDORBindingSource.DataMember = "CATEGORIAPROVEEDOR"
        Me.CATEGORIAPROVEEDORBindingSource.DataSource = Me.DsProveedores
        '
        'PROVEEDORTableAdapter
        '
        Me.PROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'CENTROCOSTOTableAdapter
        '
        Me.CENTROCOSTOTableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'CATEGORIAPROVEEDORTableAdapter
        '
        Me.CATEGORIAPROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'BtnGuardarP1
        '
        Me.BtnGuardarP1.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardarP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnGuardarP1.ForeColor = System.Drawing.Color.Transparent
        Me.BtnGuardarP1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnGuardarP1.Location = New System.Drawing.Point(493, 398)
        Me.BtnGuardarP1.Name = "BtnGuardarP1"
        '
        '
        '
        Me.BtnGuardarP1.RootElement.ForeColor = System.Drawing.Color.Transparent
        Me.BtnGuardarP1.Size = New System.Drawing.Size(28, 27)
        Me.BtnGuardarP1.TabIndex = 423
        Me.BtnGuardarP1.Text = " G"
        '
        'BtnNuevoP1
        '
        Me.BtnNuevoP1.BackColor = System.Drawing.Color.Transparent
        Me.BtnNuevoP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnNuevoP1.ForeColor = System.Drawing.Color.Transparent
        Me.BtnNuevoP1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.BtnNuevoP1.Location = New System.Drawing.Point(461, 398)
        Me.BtnNuevoP1.Name = "BtnNuevoP1"
        '
        '
        '
        Me.BtnNuevoP1.RootElement.ForeColor = System.Drawing.Color.Transparent
        Me.BtnNuevoP1.Size = New System.Drawing.Size(30, 27)
        Me.BtnNuevoP1.TabIndex = 422
        Me.BtnNuevoP1.Text = " N"
        CType(Me.BtnNuevoP1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        CType(Me.BtnNuevoP1.GetChildAt(0), Telerik.WinControls.UI.RadButtonElement).Text = " N"
        CType(Me.BtnNuevoP1.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.FromArgb(CType(CType(211, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(244, Byte), Integer))
        '
        'NumProveedorTextBox
        '
        Me.NumProveedorTextBox.BackColor = System.Drawing.Color.White
        Me.NumProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "NUMPROVEEDOR", True))
        Me.NumProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumProveedorTextBox.Location = New System.Drawing.Point(465, 80)
        Me.NumProveedorTextBox.Name = "NumProveedorTextBox"
        Me.NumProveedorTextBox.Size = New System.Drawing.Size(271, 27)
        Me.NumProveedorTextBox.TabIndex = 1
        '
        'NombreProveedorTextBox
        '
        Me.NombreProveedorTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.NombreProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NombreProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "NOMBRE", True))
        Me.NombreProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NombreProveedorTextBox.Location = New System.Drawing.Point(391, 46)
        Me.NombreProveedorTextBox.Name = "NombreProveedorTextBox"
        Me.NombreProveedorTextBox.Size = New System.Drawing.Size(345, 29)
        Me.NombreProveedorTextBox.TabIndex = 0
        '
        'ProveedorGridView
        '
        Me.ProveedorGridView.AllowUserToAddRows = False
        Me.ProveedorGridView.AllowUserToDeleteRows = False
        Me.ProveedorGridView.AllowUserToOrderColumns = True
        Me.ProveedorGridView.AllowUserToResizeRows = False
        Me.ProveedorGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProveedorGridView.AutoGenerateColumns = False
        Me.ProveedorGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ProveedorGridView.BackgroundColor = System.Drawing.Color.Lavender
        Me.ProveedorGridView.ColumnHeadersHeight = 35
        Me.ProveedorGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMPROVEEDORDataGridViewTextBoxColumn, Me.DIASLOGISTICA, Me.DIASVENCIMIENTO, Me.FECHAVTOTIMBRADO, Me.CODPROVEEDORDataGridViewTextBoxColumn, Me.FORMAPAGO, Me.NOMBRE, Me.RUCCINDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.CODZONADataGridViewTextBoxColumn, Me.APELLIDODataGridViewTextBoxColumn, Me.DIRECCIONDataGridViewTextBoxColumn, Me.TELEFONODataGridViewTextBoxColumn, Me.CELULARDataGridViewTextBoxColumn, Me.FAXDataGridViewTextBoxColumn, Me.EMAILDataGridViewTextBoxColumn, Me.WEBDataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn, Me.ObservacionDataGridViewTextBoxColumn, Me.ImagenDataGridViewTextBoxColumn, Me.TIMBRADOFACTURADataGridViewTextBoxColumn, Me.TIMBRADORETENCIONDataGridViewTextBoxColumn, Me.MASCARADataGridViewTextBoxColumn, Me.PROVEEDORDataGridViewTextBoxColumn, Me.CODCENTRODataGridViewTextBoxColumn, Me.PERSONAJURIDICADataGridViewTextBoxColumn, Me.CLIENTEIDDataGridViewTextBoxColumn, Me.CODMONEDADataGridViewTextBoxColumn, Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn, Me.ESTADO})
        Me.ProveedorGridView.DataSource = Me.PROVEEDORBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProveedorGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProveedorGridView.Location = New System.Drawing.Point(-1, 36)
        Me.ProveedorGridView.Name = "ProveedorGridView"
        Me.ProveedorGridView.ReadOnly = True
        Me.ProveedorGridView.RowHeadersVisible = False
        Me.ProveedorGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ProveedorGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProveedorGridView.Size = New System.Drawing.Size(296, 638)
        Me.ProveedorGridView.TabIndex = 427
        '
        'NUMPROVEEDORDataGridViewTextBoxColumn
        '
        Me.NUMPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "NUMPROVEEDOR"
        Me.NUMPROVEEDORDataGridViewTextBoxColumn.FillWeight = 35.0!
        Me.NUMPROVEEDORDataGridViewTextBoxColumn.HeaderText = "Nro. "
        Me.NUMPROVEEDORDataGridViewTextBoxColumn.Name = "NUMPROVEEDORDataGridViewTextBoxColumn"
        Me.NUMPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DIASLOGISTICA
        '
        Me.DIASLOGISTICA.DataPropertyName = "DIASLOGISTICA"
        Me.DIASLOGISTICA.HeaderText = "DIASLOGISTICA"
        Me.DIASLOGISTICA.Name = "DIASLOGISTICA"
        Me.DIASLOGISTICA.ReadOnly = True
        Me.DIASLOGISTICA.Visible = False
        '
        'DIASVENCIMIENTO
        '
        Me.DIASVENCIMIENTO.DataPropertyName = "DIASVENCIMIENTO"
        Me.DIASVENCIMIENTO.HeaderText = "DIASVENCIMIENTO"
        Me.DIASVENCIMIENTO.Name = "DIASVENCIMIENTO"
        Me.DIASVENCIMIENTO.ReadOnly = True
        Me.DIASVENCIMIENTO.Visible = False
        '
        'FECHAVTOTIMBRADO
        '
        Me.FECHAVTOTIMBRADO.DataPropertyName = "FECHAVTOTIMBRADO"
        Me.FECHAVTOTIMBRADO.HeaderText = "FECHAVTOTIMBRADO"
        Me.FECHAVTOTIMBRADO.Name = "FECHAVTOTIMBRADO"
        Me.FECHAVTOTIMBRADO.ReadOnly = True
        Me.FECHAVTOTIMBRADO.Visible = False
        '
        'CODPROVEEDORDataGridViewTextBoxColumn
        '
        Me.CODPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "CODPROVEEDOR"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.HeaderText = "CODPROVEEDOR"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.Name = "CODPROVEEDORDataGridViewTextBoxColumn"
        Me.CODPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPROVEEDORDataGridViewTextBoxColumn.Visible = False
        '
        'FORMAPAGO
        '
        Me.FORMAPAGO.DataPropertyName = "FORMAPAGO"
        Me.FORMAPAGO.HeaderText = "FORMAPAGO"
        Me.FORMAPAGO.Name = "FORMAPAGO"
        Me.FORMAPAGO.ReadOnly = True
        Me.FORMAPAGO.Visible = False
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.FillWeight = 150.0!
        Me.NOMBRE.HeaderText = "Proveedor"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'RUCCINDataGridViewTextBoxColumn
        '
        Me.RUCCINDataGridViewTextBoxColumn.DataPropertyName = "RUC_CIN"
        Me.RUCCINDataGridViewTextBoxColumn.FillWeight = 75.0!
        Me.RUCCINDataGridViewTextBoxColumn.HeaderText = "Ruc"
        Me.RUCCINDataGridViewTextBoxColumn.Name = "RUCCINDataGridViewTextBoxColumn"
        Me.RUCCINDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        Me.CODUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn
        '
        Me.CODEMPRESADataGridViewTextBoxColumn.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.Name = "CODEMPRESADataGridViewTextBoxColumn"
        Me.CODEMPRESADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn.Visible = False
        '
        'CODZONADataGridViewTextBoxColumn
        '
        Me.CODZONADataGridViewTextBoxColumn.DataPropertyName = "CODZONA"
        Me.CODZONADataGridViewTextBoxColumn.HeaderText = "CODZONA"
        Me.CODZONADataGridViewTextBoxColumn.Name = "CODZONADataGridViewTextBoxColumn"
        Me.CODZONADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODZONADataGridViewTextBoxColumn.Visible = False
        '
        'APELLIDODataGridViewTextBoxColumn
        '
        Me.APELLIDODataGridViewTextBoxColumn.DataPropertyName = "APELLIDO"
        Me.APELLIDODataGridViewTextBoxColumn.HeaderText = "APELLIDO"
        Me.APELLIDODataGridViewTextBoxColumn.Name = "APELLIDODataGridViewTextBoxColumn"
        Me.APELLIDODataGridViewTextBoxColumn.ReadOnly = True
        Me.APELLIDODataGridViewTextBoxColumn.Visible = False
        '
        'DIRECCIONDataGridViewTextBoxColumn
        '
        Me.DIRECCIONDataGridViewTextBoxColumn.DataPropertyName = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.HeaderText = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.Name = "DIRECCIONDataGridViewTextBoxColumn"
        Me.DIRECCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DIRECCIONDataGridViewTextBoxColumn.Visible = False
        '
        'TELEFONODataGridViewTextBoxColumn
        '
        Me.TELEFONODataGridViewTextBoxColumn.DataPropertyName = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.HeaderText = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.Name = "TELEFONODataGridViewTextBoxColumn"
        Me.TELEFONODataGridViewTextBoxColumn.ReadOnly = True
        Me.TELEFONODataGridViewTextBoxColumn.Visible = False
        '
        'CELULARDataGridViewTextBoxColumn
        '
        Me.CELULARDataGridViewTextBoxColumn.DataPropertyName = "CELULAR"
        Me.CELULARDataGridViewTextBoxColumn.HeaderText = "CELULAR"
        Me.CELULARDataGridViewTextBoxColumn.Name = "CELULARDataGridViewTextBoxColumn"
        Me.CELULARDataGridViewTextBoxColumn.ReadOnly = True
        Me.CELULARDataGridViewTextBoxColumn.Visible = False
        '
        'FAXDataGridViewTextBoxColumn
        '
        Me.FAXDataGridViewTextBoxColumn.DataPropertyName = "FAX"
        Me.FAXDataGridViewTextBoxColumn.HeaderText = "FAX"
        Me.FAXDataGridViewTextBoxColumn.Name = "FAXDataGridViewTextBoxColumn"
        Me.FAXDataGridViewTextBoxColumn.ReadOnly = True
        Me.FAXDataGridViewTextBoxColumn.Visible = False
        '
        'EMAILDataGridViewTextBoxColumn
        '
        Me.EMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.Name = "EMAILDataGridViewTextBoxColumn"
        Me.EMAILDataGridViewTextBoxColumn.ReadOnly = True
        Me.EMAILDataGridViewTextBoxColumn.Visible = False
        '
        'WEBDataGridViewTextBoxColumn
        '
        Me.WEBDataGridViewTextBoxColumn.DataPropertyName = "WEB"
        Me.WEBDataGridViewTextBoxColumn.HeaderText = "WEB"
        Me.WEBDataGridViewTextBoxColumn.Name = "WEBDataGridViewTextBoxColumn"
        Me.WEBDataGridViewTextBoxColumn.ReadOnly = True
        Me.WEBDataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'ObservacionDataGridViewTextBoxColumn
        '
        Me.ObservacionDataGridViewTextBoxColumn.DataPropertyName = "observacion"
        Me.ObservacionDataGridViewTextBoxColumn.HeaderText = "observacion"
        Me.ObservacionDataGridViewTextBoxColumn.Name = "ObservacionDataGridViewTextBoxColumn"
        Me.ObservacionDataGridViewTextBoxColumn.ReadOnly = True
        Me.ObservacionDataGridViewTextBoxColumn.Visible = False
        '
        'ImagenDataGridViewTextBoxColumn
        '
        Me.ImagenDataGridViewTextBoxColumn.DataPropertyName = "Imagen"
        Me.ImagenDataGridViewTextBoxColumn.HeaderText = "Imagen"
        Me.ImagenDataGridViewTextBoxColumn.Name = "ImagenDataGridViewTextBoxColumn"
        Me.ImagenDataGridViewTextBoxColumn.ReadOnly = True
        Me.ImagenDataGridViewTextBoxColumn.Visible = False
        '
        'TIMBRADOFACTURADataGridViewTextBoxColumn
        '
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn.DataPropertyName = "TIMBRADOFACTURA"
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn.HeaderText = "TIMBRADOFACTURA"
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn.Name = "TIMBRADOFACTURADataGridViewTextBoxColumn"
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn.ReadOnly = True
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn.Visible = False
        '
        'TIMBRADORETENCIONDataGridViewTextBoxColumn
        '
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn.DataPropertyName = "TIMBRADORETENCION"
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn.HeaderText = "TIMBRADORETENCION"
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn.Name = "TIMBRADORETENCIONDataGridViewTextBoxColumn"
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn.Visible = False
        '
        'MASCARADataGridViewTextBoxColumn
        '
        Me.MASCARADataGridViewTextBoxColumn.DataPropertyName = "MASCARA"
        Me.MASCARADataGridViewTextBoxColumn.HeaderText = "MASCARA"
        Me.MASCARADataGridViewTextBoxColumn.Name = "MASCARADataGridViewTextBoxColumn"
        Me.MASCARADataGridViewTextBoxColumn.ReadOnly = True
        Me.MASCARADataGridViewTextBoxColumn.Visible = False
        '
        'PROVEEDORDataGridViewTextBoxColumn
        '
        Me.PROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "PROVEEDOR"
        Me.PROVEEDORDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR"
        Me.PROVEEDORDataGridViewTextBoxColumn.Name = "PROVEEDORDataGridViewTextBoxColumn"
        Me.PROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROVEEDORDataGridViewTextBoxColumn.Visible = False
        '
        'CODCENTRODataGridViewTextBoxColumn
        '
        Me.CODCENTRODataGridViewTextBoxColumn.DataPropertyName = "CODCENTRO"
        Me.CODCENTRODataGridViewTextBoxColumn.HeaderText = "CODCENTRO"
        Me.CODCENTRODataGridViewTextBoxColumn.Name = "CODCENTRODataGridViewTextBoxColumn"
        Me.CODCENTRODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCENTRODataGridViewTextBoxColumn.Visible = False
        '
        'PERSONAJURIDICADataGridViewTextBoxColumn
        '
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.DataPropertyName = "PERSONAJURIDICA"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.HeaderText = "PERSONAJURIDICA"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.Name = "PERSONAJURIDICADataGridViewTextBoxColumn"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.ReadOnly = True
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.Visible = False
        '
        'CLIENTEIDDataGridViewTextBoxColumn
        '
        Me.CLIENTEIDDataGridViewTextBoxColumn.DataPropertyName = "CLIENTE_ID"
        Me.CLIENTEIDDataGridViewTextBoxColumn.HeaderText = "CLIENTE_ID"
        Me.CLIENTEIDDataGridViewTextBoxColumn.Name = "CLIENTEIDDataGridViewTextBoxColumn"
        Me.CLIENTEIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.CLIENTEIDDataGridViewTextBoxColumn.Visible = False
        '
        'CODMONEDADataGridViewTextBoxColumn
        '
        Me.CODMONEDADataGridViewTextBoxColumn.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.Name = "CODMONEDADataGridViewTextBoxColumn"
        Me.CODMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMONEDADataGridViewTextBoxColumn.Visible = False
        '
        'CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn
        '
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn.HeaderText = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn.Name = "CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn"
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'RucProveedorTextBox
        '
        Me.RucProveedorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.RucProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RucProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "RUC_CIN", True))
        Me.RucProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RucProveedorTextBox.Location = New System.Drawing.Point(161, 28)
        Me.RucProveedorTextBox.Name = "RucProveedorTextBox"
        Me.RucProveedorTextBox.Size = New System.Drawing.Size(291, 24)
        Me.RucProveedorTextBox.TabIndex = 1
        '
        'TimbradoTextBox
        '
        Me.TimbradoTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TimbradoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TimbradoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "TIMBRADOFACTURA", True))
        Me.TimbradoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimbradoTextBox.Location = New System.Drawing.Point(161, 53)
        Me.TimbradoTextBox.Name = "TimbradoTextBox"
        Me.TimbradoTextBox.Size = New System.Drawing.Size(291, 24)
        Me.TimbradoTextBox.TabIndex = 2
        '
        'DireccionProveedorTextBox
        '
        Me.DireccionProveedorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.DireccionProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DireccionProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "DIRECCION", True))
        Me.DireccionProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DireccionProveedorTextBox.Location = New System.Drawing.Point(161, 204)
        Me.DireccionProveedorTextBox.Name = "DireccionProveedorTextBox"
        Me.DireccionProveedorTextBox.Size = New System.Drawing.Size(291, 24)
        Me.DireccionProveedorTextBox.TabIndex = 3
        '
        'TelefonoProveedorTextBox
        '
        Me.TelefonoProveedorTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TelefonoProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TelefonoProveedorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "TELEFONO", True))
        Me.TelefonoProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TelefonoProveedorTextBox.Location = New System.Drawing.Point(161, 153)
        Me.TelefonoProveedorTextBox.Name = "TelefonoProveedorTextBox"
        Me.TelefonoProveedorTextBox.Size = New System.Drawing.Size(291, 24)
        Me.TelefonoProveedorTextBox.TabIndex = 4
        '
        'pnlProveedor
        '
        Me.pnlProveedor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlProveedor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlProveedor.BackColor = System.Drawing.Color.LightGray
        Me.pnlProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProveedor.Controls.Add(Me.txtGMaps)
        Me.pnlProveedor.Controls.Add(Me.tbxCodPostal)
        Me.pnlProveedor.Controls.Add(Me.tbxContacto)
        Me.pnlProveedor.Controls.Add(Me.cmbPais)
        Me.pnlProveedor.Controls.Add(Me.cbxZona)
        Me.pnlProveedor.Controls.Add(Me.cbxCiudad)
        Me.pnlProveedor.Controls.Add(Me.tbxRepresentanteLegal)
        Me.pnlProveedor.Controls.Add(Me.Label33)
        Me.pnlProveedor.Controls.Add(Me.Label19)
        Me.pnlProveedor.Controls.Add(Me.Label16)
        Me.pnlProveedor.Controls.Add(Me.Label26)
        Me.pnlProveedor.Controls.Add(Me.Label25)
        Me.pnlProveedor.Controls.Add(Me.Label15)
        Me.pnlProveedor.Controls.Add(Me.Label12)
        Me.pnlProveedor.Controls.Add(Me.Label5)
        Me.pnlProveedor.Controls.Add(Me.Label4)
        Me.pnlProveedor.Controls.Add(Me.btnAddPais)
        Me.pnlProveedor.Controls.Add(Me.btnIrLink)
        Me.pnlProveedor.Controls.Add(Me.btnVerContacto)
        Me.pnlProveedor.Controls.Add(Me.BtnGuardarP1)
        Me.pnlProveedor.Controls.Add(Me.BtnNuevoP1)
        Me.pnlProveedor.Controls.Add(Me.Cuotas)
        Me.pnlProveedor.Controls.Add(Me.tbxCantCuotas)
        Me.pnlProveedor.Controls.Add(Me.dtpVtoTimbrado)
        Me.pnlProveedor.Controls.Add(Me.Label14)
        Me.pnlProveedor.Controls.Add(Me.Label23)
        Me.pnlProveedor.Controls.Add(Me.pbxAgregarCentroCosto)
        Me.pnlProveedor.Controls.Add(Me.Label24)
        Me.pnlProveedor.Controls.Add(Me.tbxDiasVto)
        Me.pnlProveedor.Controls.Add(Me.cmbFormaPago)
        Me.pnlProveedor.Controls.Add(Me.tbxEmailGral)
        Me.pnlProveedor.Controls.Add(Me.Label10)
        Me.pnlProveedor.Controls.Add(Me.Label9)
        Me.pnlProveedor.Controls.Add(Me.Label11)
        Me.pnlProveedor.Controls.Add(Me.Label8)
        Me.pnlProveedor.Controls.Add(Me.Label7)
        Me.pnlProveedor.Controls.Add(Me.Label6)
        Me.pnlProveedor.Controls.Add(Me.Label3)
        Me.pnlProveedor.Controls.Add(Me.Label2)
        Me.pnlProveedor.Controls.Add(Me.chbxExterior)
        Me.pnlProveedor.Controls.Add(Me.MonedaComboBox)
        Me.pnlProveedor.Controls.Add(Me.RucProveedorTextBox)
        Me.pnlProveedor.Controls.Add(Me.CentroCostoComboBox)
        Me.pnlProveedor.Controls.Add(Me.DireccionProveedorTextBox)
        Me.pnlProveedor.Controls.Add(Me.TelefonoProveedorTextBox)
        Me.pnlProveedor.Controls.Add(Me.TimbradoTextBox)
        Me.pnlProveedor.Controls.Add(Me.CategoriaComboBox)
        Me.pnlProveedor.Controls.Add(Me.CategoriaTextBox)
        Me.pnlProveedor.Controls.Add(Me.lblMensajeError)
        Me.pnlProveedor.Location = New System.Drawing.Point(303, 116)
        Me.pnlProveedor.Name = "pnlProveedor"
        Me.pnlProveedor.Size = New System.Drawing.Size(530, 558)
        Me.pnlProveedor.TabIndex = 2
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Enabled = False
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(83, 316)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(74, 16)
        Me.Label33.TabIndex = 497
        Me.Label33.Text = "Cod.Postal"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(118, 234)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 16)
        Me.Label19.TabIndex = 489
        Me.Label19.Text = "Link:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(56, 290)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(103, 16)
        Me.Label16.TabIndex = 483
        Me.Label16.Text = "Ciudad y Barrio:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Enabled = False
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(116, 263)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 16)
        Me.Label26.TabIndex = 484
        Me.Label26.Text = "Pais:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Enabled = False
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(22, 108)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(137, 16)
        Me.Label25.TabIndex = 479
        Me.Label25.Text = "Representante Legal:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(114, 185)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 16)
        Me.Label12.TabIndex = 469
        Me.Label12.Text = "Email:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(94, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 16)
        Me.Label5.TabIndex = 463
        Me.Label5.Text = "Telefono:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(91, 212)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 463
        Me.Label4.Text = "Direccion:"
        '
        'btnAddPais
        '
        Me.btnAddPais.BackColor = System.Drawing.Color.LightGray
        Me.btnAddPais.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddPais.Image = CType(resources.GetObject("btnAddPais.Image"), System.Drawing.Image)
        Me.btnAddPais.Location = New System.Drawing.Point(461, 270)
        Me.btnAddPais.Name = "btnAddPais"
        Me.btnAddPais.Size = New System.Drawing.Size(26, 26)
        Me.btnAddPais.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnAddPais.TabIndex = 487
        Me.btnAddPais.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnAddPais, "Esto abrira la Ventana Ciudad/Zona para cargar nuevos datos")
        '
        'btnIrLink
        '
        Me.btnIrLink.BackColor = System.Drawing.Color.LightGray
        Me.btnIrLink.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIrLink.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.btnIrLink.Location = New System.Drawing.Point(461, 229)
        Me.btnIrLink.Name = "btnIrLink"
        Me.btnIrLink.Size = New System.Drawing.Size(26, 24)
        Me.btnIrLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnIrLink.TabIndex = 492
        Me.btnIrLink.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnIrLink, "Esto abrira la Ventana Ciudad/Zona para cargar nuevos datos")
        '
        'txtGMaps
        '
        Me.txtGMaps.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtGMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGMaps.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "LINKMAPS", True))
        Me.txtGMaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGMaps.Location = New System.Drawing.Point(161, 229)
        Me.txtGMaps.Name = "txtGMaps"
        Me.txtGMaps.Size = New System.Drawing.Size(291, 24)
        Me.txtGMaps.TabIndex = 490
        Me.ToolTip1.SetToolTip(Me.txtGMaps, "Direccion del Cliente en Google Maps")
        '
        'tbxCodPostal
        '
        Me.tbxCodPostal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCodPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodPostal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CODIGOPOSTAL", True))
        Me.tbxCodPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.tbxCodPostal.Location = New System.Drawing.Point(162, 312)
        Me.tbxCodPostal.Name = "tbxCodPostal"
        Me.tbxCodPostal.Size = New System.Drawing.Size(290, 24)
        Me.tbxCodPostal.TabIndex = 498
        Me.ToolTip1.SetToolTip(Me.tbxCodPostal, "Direccion del Cliente en Google Maps")
        '
        'btnVerContacto
        '
        Me.btnVerContacto.BackColor = System.Drawing.Color.Transparent
        Me.btnVerContacto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVerContacto.Image = CType(resources.GetObject("btnVerContacto.Image"), System.Drawing.Image)
        Me.btnVerContacto.Location = New System.Drawing.Point(461, 126)
        Me.btnVerContacto.Name = "btnVerContacto"
        Me.btnVerContacto.Size = New System.Drawing.Size(26, 26)
        Me.btnVerContacto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnVerContacto.TabIndex = 495
        Me.btnVerContacto.TabStop = False
        Me.ToolTip1.SetToolTip(Me.btnVerContacto, "Esto abrira el Panel de Información del contacto para agregar datos del mismo")
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Enabled = False
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(95, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 494
        Me.Label15.Text = "Contacto:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxContacto
        '
        Me.tbxContacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxContacto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CONTACTO1", True))
        Me.tbxContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.tbxContacto.Location = New System.Drawing.Point(161, 128)
        Me.tbxContacto.Name = "tbxContacto"
        Me.tbxContacto.Size = New System.Drawing.Size(291, 24)
        Me.tbxContacto.TabIndex = 493
        Me.ToolTip1.SetToolTip(Me.tbxContacto, "Aqui ingrese el nombre del contacto")
        '
        'cmbPais
        '
        Me.cmbPais.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbPais.CausesValidation = False
        Me.cmbPais.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PAISBindingSource, "DESPAIS", True))
        Me.cmbPais.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODPAIS", True))
        Me.cmbPais.DataSource = Me.PAISBindingSource
        Me.cmbPais.DisplayMember = "DESPAIS"
        Me.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPais.ForeColor = System.Drawing.Color.Black
        Me.cmbPais.FormattingEnabled = True
        Me.cmbPais.Location = New System.Drawing.Point(162, 256)
        Me.cmbPais.Name = "cmbPais"
        Me.cmbPais.Size = New System.Drawing.Size(290, 26)
        Me.cmbPais.TabIndex = 485
        Me.ToolTip1.SetToolTip(Me.cmbPais, "La Ciudad donde vive/trabaj este Cliente")
        Me.cmbPais.ValueMember = "CODPAIS"
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsCliente
        '
        'DsCliente
        '
        Me.DsCliente.DataSetName = "DsCliente"
        Me.DsCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxZona
        '
        Me.cbxZona.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxZona.CausesValidation = False
        Me.cbxZona.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ZONABindingSource, "DESZONA", True))
        Me.cbxZona.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODZONA", True))
        Me.cbxZona.DataSource = Me.ZONABindingSource
        Me.cbxZona.DisplayMember = "DESZONA"
        Me.cbxZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxZona.ForeColor = System.Drawing.Color.Black
        Me.cbxZona.FormattingEnabled = True
        Me.cbxZona.Location = New System.Drawing.Point(311, 284)
        Me.cbxZona.Name = "cbxZona"
        Me.cbxZona.Size = New System.Drawing.Size(141, 26)
        Me.cbxZona.TabIndex = 482
        Me.ToolTip1.SetToolTip(Me.cbxZona, "La Zona donde vive o trabaja este Cliente")
        Me.cbxZona.ValueMember = "CODZONA"
        '
        'ZONABindingSource
        '
        Me.ZONABindingSource.DataMember = "ZONA"
        Me.ZONABindingSource.DataSource = Me.DsCliente
        '
        'cbxCiudad
        '
        Me.cbxCiudad.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxCiudad.CausesValidation = False
        Me.cbxCiudad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CIUDADBindingSource, "DESCIUDAD", True))
        Me.cbxCiudad.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.CIUDADBindingSource, "DESCIUDAD", True))
        Me.cbxCiudad.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODCIUDAD", True))
        Me.cbxCiudad.DataSource = Me.CIUDADBindingSource
        Me.cbxCiudad.DisplayMember = "DESCIUDAD"
        Me.cbxCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCiudad.ForeColor = System.Drawing.Color.Black
        Me.cbxCiudad.FormattingEnabled = True
        Me.cbxCiudad.Location = New System.Drawing.Point(162, 284)
        Me.cbxCiudad.Name = "cbxCiudad"
        Me.cbxCiudad.Size = New System.Drawing.Size(143, 26)
        Me.cbxCiudad.TabIndex = 481
        Me.ToolTip1.SetToolTip(Me.cbxCiudad, "La Ciudad donde vive/trabaj este Cliente")
        Me.cbxCiudad.ValueMember = "CODCIUDAD"
        '
        'CIUDADBindingSource
        '
        Me.CIUDADBindingSource.DataMember = "CIUDAD"
        Me.CIUDADBindingSource.DataSource = Me.DsCliente
        '
        'tbxRepresentanteLegal
        '
        Me.tbxRepresentanteLegal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxRepresentanteLegal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRepresentanteLegal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "REPRESENTANTELEGAL", True))
        Me.tbxRepresentanteLegal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRepresentanteLegal.Location = New System.Drawing.Point(161, 103)
        Me.tbxRepresentanteLegal.Name = "tbxRepresentanteLegal"
        Me.tbxRepresentanteLegal.Size = New System.Drawing.Size(291, 24)
        Me.tbxRepresentanteLegal.TabIndex = 480
        '
        'Cuotas
        '
        Me.Cuotas.AutoSize = True
        Me.Cuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cuotas.ForeColor = System.Drawing.Color.Black
        Me.Cuotas.Location = New System.Drawing.Point(244, 532)
        Me.Cuotas.Name = "Cuotas"
        Me.Cuotas.Size = New System.Drawing.Size(65, 16)
        Me.Cuotas.TabIndex = 477
        Me.Cuotas.Text = "cuotas,  a"
        Me.Cuotas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbxCantCuotas
        '
        Me.tbxCantCuotas.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCantCuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantCuotas.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CANTCUOTAS", True))
        Me.tbxCantCuotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCantCuotas.Location = New System.Drawing.Point(160, 527)
        Me.tbxCantCuotas.Name = "tbxCantCuotas"
        Me.tbxCantCuotas.Size = New System.Drawing.Size(77, 24)
        Me.tbxCantCuotas.TabIndex = 476
        Me.ToolTip1.SetToolTip(Me.tbxCantCuotas, "Cantidad de Cuotas")
        '
        'dtpVtoTimbrado
        '
        Me.dtpVtoTimbrado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "FECHAVTOTIMBRADO", True))
        Me.dtpVtoTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpVtoTimbrado.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVtoTimbrado.Location = New System.Drawing.Point(161, 78)
        Me.dtpVtoTimbrado.Name = "dtpVtoTimbrado"
        Me.dtpVtoTimbrado.Size = New System.Drawing.Size(291, 24)
        Me.dtpVtoTimbrado.TabIndex = 475
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(63, 86)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(96, 16)
        Me.Label14.TabIndex = 474
        Me.Label14.Text = "Vto. Timbrado:"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(401, 531)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(36, 16)
        Me.Label23.TabIndex = 473
        Me.Label23.Text = "Días"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label23.Visible = False
        '
        'pbxAgregarCentroCosto
        '
        Me.pbxAgregarCentroCosto.BackColor = System.Drawing.Color.Transparent
        Me.pbxAgregarCentroCosto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarCentroCosto.Image = Global.ContaExpress.My.Resources.Resources.CreateActive
        Me.pbxAgregarCentroCosto.Location = New System.Drawing.Point(461, 430)
        Me.pbxAgregarCentroCosto.Name = "pbxAgregarCentroCosto"
        Me.pbxAgregarCentroCosto.Size = New System.Drawing.Size(26, 26)
        Me.pbxAgregarCentroCosto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxAgregarCentroCosto.TabIndex = 462
        Me.pbxAgregarCentroCosto.TabStop = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(97, 532)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 16)
        Me.Label24.TabIndex = 472
        Me.Label24.Text = "Generar:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxDiasVto
        '
        Me.tbxDiasVto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxDiasVto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDiasVto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "DIASVENCIMIENTO", True))
        Me.tbxDiasVto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDiasVto.Location = New System.Drawing.Point(321, 527)
        Me.tbxDiasVto.Name = "tbxDiasVto"
        Me.tbxDiasVto.Size = New System.Drawing.Size(74, 24)
        Me.tbxDiasVto.TabIndex = 471
        Me.ToolTip1.SetToolTip(Me.tbxDiasVto, "Cada cuantos días se generará el Vto. de cada cuota")
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbFormaPago.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFormaPago.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cmbFormaPago.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.FormattingEnabled = True
        Me.cmbFormaPago.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cmbFormaPago.Location = New System.Drawing.Point(161, 495)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(291, 26)
        Me.cmbFormaPago.TabIndex = 8
        '
        'tbxEmailGral
        '
        Me.tbxEmailGral.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxEmailGral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmailGral.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "EMAIL", True))
        Me.tbxEmailGral.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxEmailGral.Location = New System.Drawing.Point(161, 178)
        Me.tbxEmailGral.Name = "tbxEmailGral"
        Me.tbxEmailGral.Size = New System.Drawing.Size(291, 24)
        Me.tbxEmailGral.TabIndex = 468
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(3, 370)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 28)
        Me.Label10.TabIndex = 467
        Me.Label10.Text = "Características"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label9.Location = New System.Drawing.Point(5, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 28)
        Me.Label9.TabIndex = 466
        Me.Label9.Text = "Info General"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(72, 501)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 16)
        Me.Label11.TabIndex = 465
        Me.Label11.Text = "Forma Pago:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(62, 470)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 465
        Me.Label8.Text = "Moneda Pred.:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(51, 437)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 16)
        Me.Label7.TabIndex = 464
        Me.Label7.Text = "Centro de Costo:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(88, 401)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 463
        Me.Label6.Text = "Categoria:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 463
        Me.Label3.Text = "Timbrado:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(91, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 463
        Me.Label2.Text = "C.I. / RUC:"
        '
        'chbxExterior
        '
        Me.chbxExterior.BackColor = System.Drawing.Color.Transparent
        Me.chbxExterior.Cursor = System.Windows.Forms.Cursors.Hand
        Me.chbxExterior.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.chbxExterior.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.chbxExterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chbxExterior.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxExterior.Location = New System.Drawing.Point(164, -3)
        Me.chbxExterior.Name = "chbxExterior"
        Me.chbxExterior.Size = New System.Drawing.Size(268, 26)
        Me.chbxExterior.TabIndex = 421
        Me.chbxExterior.Text = "Proveedor del Exterior"
        Me.chbxExterior.UseVisualStyleBackColor = False
        '
        'MonedaComboBox
        '
        Me.MonedaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.MonedaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.MonedaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MonedaComboBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.MonedaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODMONEDA", True))
        Me.MonedaComboBox.DataSource = Me.MONEDABindingSource
        Me.MonedaComboBox.DisplayMember = "DESMONEDA"
        Me.MonedaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MonedaComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonedaComboBox.FormattingEnabled = True
        Me.MonedaComboBox.Location = New System.Drawing.Point(161, 463)
        Me.MonedaComboBox.Name = "MonedaComboBox"
        Me.MonedaComboBox.Size = New System.Drawing.Size(291, 26)
        Me.MonedaComboBox.TabIndex = 7
        Me.MonedaComboBox.ValueMember = "CODMONEDA"
        '
        'CentroCostoComboBox
        '
        Me.CentroCostoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CentroCostoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CentroCostoComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CentroCostoComboBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CentroCostoComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODCENTRO", True))
        Me.CentroCostoComboBox.DataSource = Me.CENTROCOSTOBindingSource
        Me.CentroCostoComboBox.DisplayMember = "DESCENTRO"
        Me.CentroCostoComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CentroCostoComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CentroCostoComboBox.FormattingEnabled = True
        Me.CentroCostoComboBox.Location = New System.Drawing.Point(161, 430)
        Me.CentroCostoComboBox.Name = "CentroCostoComboBox"
        Me.CentroCostoComboBox.Size = New System.Drawing.Size(291, 26)
        Me.CentroCostoComboBox.TabIndex = 6
        Me.CentroCostoComboBox.ValueMember = "CODCENTRO"
        '
        'CategoriaComboBox
        '
        Me.CategoriaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CategoriaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CategoriaComboBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CategoriaComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PROVEEDORBindingSource, "CODCATEGORIAPROVEEDOR", True))
        Me.CategoriaComboBox.DataSource = Me.CATEGORIAPROVEEDORBindingSource
        Me.CategoriaComboBox.DisplayMember = "DESCATEGORIAPROVEEDOR"
        Me.CategoriaComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CategoriaComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoriaComboBox.FormattingEnabled = True
        Me.CategoriaComboBox.Location = New System.Drawing.Point(161, 398)
        Me.CategoriaComboBox.Name = "CategoriaComboBox"
        Me.CategoriaComboBox.Size = New System.Drawing.Size(291, 26)
        Me.CategoriaComboBox.TabIndex = 5
        Me.CategoriaComboBox.ValueMember = "CODCATEGORIAPROVEEDOR"
        '
        'CategoriaTextBox
        '
        Me.CategoriaTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CategoriaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CategoriaTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CategoriaTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoriaTextBox.Location = New System.Drawing.Point(161, 398)
        Me.CategoriaTextBox.Name = "CategoriaTextBox"
        Me.CategoriaTextBox.Size = New System.Drawing.Size(271, 27)
        Me.CategoriaTextBox.TabIndex = 3
        '
        'lblMensajeError
        '
        Me.lblMensajeError.BackColor = System.Drawing.Color.Transparent
        Me.lblMensajeError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblMensajeError.ForeColor = System.Drawing.Color.Maroon
        Me.lblMensajeError.Location = New System.Drawing.Point(176, 49)
        Me.lblMensajeError.Name = "lblMensajeError"
        '
        '
        '
        Me.lblMensajeError.RootElement.ForeColor = System.Drawing.Color.Maroon
        Me.lblMensajeError.Size = New System.Drawing.Size(256, 17)
        Me.lblMensajeError.TabIndex = 478
        Me.lblMensajeError.Text = "El RUC Ingresado ya se Encuentra Asignado "
        Me.lblMensajeError.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensajeError.Visible = False
        '
        'pnlContacto
        '
        Me.pnlContacto.BackColor = System.Drawing.Color.Orange
        Me.pnlContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContacto.Controls.Add(Me.Label17)
        Me.pnlContacto.Controls.Add(Me.tbxTelContacto)
        Me.pnlContacto.Controls.Add(Me.Label27)
        Me.pnlContacto.Controls.Add(Me.tbxMail2Contacto)
        Me.pnlContacto.Controls.Add(Me.tbxMail1Contacto)
        Me.pnlContacto.Controls.Add(Me.Label28)
        Me.pnlContacto.Controls.Add(Me.lblNombreContacto)
        Me.pnlContacto.Controls.Add(Me.Label29)
        Me.pnlContacto.Controls.Add(Me.tbxCelContacto)
        Me.pnlContacto.Location = New System.Drawing.Point(301, 315)
        Me.pnlContacto.Name = "pnlContacto"
        Me.pnlContacto.Size = New System.Drawing.Size(513, 169)
        Me.pnlContacto.TabIndex = 496
        Me.pnlContacto.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(100, 130)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 16)
        Me.Label17.TabIndex = 475
        Me.Label17.Text = "Celular:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxTelContacto
        '
        Me.tbxTelContacto.AccessibleName = "tbxTelefonoContacto"
        Me.tbxTelContacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxTelContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTelContacto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "TELEFONOCONTACTO", True))
        Me.tbxTelContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTelContacto.Location = New System.Drawing.Point(159, 96)
        Me.tbxTelContacto.Name = "tbxTelContacto"
        Me.tbxTelContacto.Size = New System.Drawing.Size(317, 27)
        Me.tbxTelContacto.TabIndex = 474
        Me.ToolTip1.SetToolTip(Me.tbxTelContacto, "Aqui guarde un correo electrónico General de la Empresa.")
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Enabled = False
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.Black
        Me.Label27.Location = New System.Drawing.Point(88, 101)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(65, 16)
        Me.Label27.TabIndex = 473
        Me.Label27.Text = "Telefono:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMail2Contacto
        '
        Me.tbxMail2Contacto.AccessibleName = "tbxCorreo2Contacto"
        Me.tbxMail2Contacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxMail2Contacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMail2Contacto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CORREO2CONTACTO", True))
        Me.tbxMail2Contacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxMail2Contacto.Location = New System.Drawing.Point(159, 67)
        Me.tbxMail2Contacto.Name = "tbxMail2Contacto"
        Me.tbxMail2Contacto.Size = New System.Drawing.Size(317, 27)
        Me.tbxMail2Contacto.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.tbxMail2Contacto, "Aqui guarde un correo electrónico General de la Empresa.")
        '
        'tbxMail1Contacto
        '
        Me.tbxMail1Contacto.AccessibleName = "tbxCorreoContacto"
        Me.tbxMail1Contacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxMail1Contacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMail1Contacto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CORREO1CONTACTO", True))
        Me.tbxMail1Contacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxMail1Contacto.Location = New System.Drawing.Point(159, 38)
        Me.tbxMail1Contacto.Name = "tbxMail1Contacto"
        Me.tbxMail1Contacto.Size = New System.Drawing.Size(317, 27)
        Me.tbxMail1Contacto.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.tbxMail1Contacto, "Aqui guarde un correo electrónico General de la Empresa.")
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Enabled = False
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(31, 43)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(122, 16)
        Me.Label28.TabIndex = 5
        Me.Label28.Text = "Correo Electronico:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNombreContacto
        '
        Me.lblNombreContacto.AutoSize = True
        Me.lblNombreContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreContacto.Location = New System.Drawing.Point(177, 12)
        Me.lblNombreContacto.Name = "lblNombreContacto"
        Me.lblNombreContacto.Size = New System.Drawing.Size(145, 20)
        Me.lblNombreContacto.TabIndex = 2
        Me.lblNombreContacto.Text = "lblNombreContacto"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label29.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label29.Location = New System.Drawing.Point(14, 6)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(165, 28)
        Me.Label29.TabIndex = 1
        Me.Label29.Text = "Info de Contacto -"
        '
        'tbxCelContacto
        '
        Me.tbxCelContacto.AccessibleName = "tbxCelularContacto"
        Me.tbxCelContacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCelContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCelContacto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CELULARCONTACTO", True))
        Me.tbxCelContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCelContacto.Location = New System.Drawing.Point(159, 125)
        Me.tbxCelContacto.Name = "tbxCelContacto"
        Me.tbxCelContacto.Size = New System.Drawing.Size(317, 27)
        Me.tbxCelContacto.TabIndex = 476
        Me.ToolTip1.SetToolTip(Me.tbxCelContacto, "Presione ESC para volver al panel de Clientes")
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(4, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 28)
        Me.Label13.TabIndex = 466
        Me.Label13.Text = "Info Contacto 2"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(37, 338)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(45, 16)
        Me.Label22.TabIndex = 463
        Me.Label22.Text = "Email:"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(50, 276)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(32, 16)
        Me.Label18.TabIndex = 463
        Me.Label18.Text = "Rol:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(17, 307)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 16)
        Me.Label20.TabIndex = 463
        Me.Label20.Text = "Telefono:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(22, 245)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 16)
        Me.Label21.TabIndex = 463
        Me.Label21.Text = "Nombre:"
        '
        'txtNomCont2
        '
        Me.txtNomCont2.BackColor = System.Drawing.Color.White
        Me.txtNomCont2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCont2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CONTACTO2", True))
        Me.txtNomCont2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCont2.Location = New System.Drawing.Point(86, 239)
        Me.txtNomCont2.Name = "txtNomCont2"
        Me.txtNomCont2.Size = New System.Drawing.Size(271, 27)
        Me.txtNomCont2.TabIndex = 15
        '
        'txtEmailCont2
        '
        Me.txtEmailCont2.BackColor = System.Drawing.Color.White
        Me.txtEmailCont2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailCont2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "EMAILCONT2", True))
        Me.txtEmailCont2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailCont2.Location = New System.Drawing.Point(86, 332)
        Me.txtEmailCont2.Name = "txtEmailCont2"
        Me.txtEmailCont2.Size = New System.Drawing.Size(271, 27)
        Me.txtEmailCont2.TabIndex = 19
        '
        'txtDirCont2
        '
        Me.txtDirCont2.BackColor = System.Drawing.Color.White
        Me.txtDirCont2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirCont2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "DIRECCIONCONT2", True))
        Me.txtDirCont2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirCont2.Location = New System.Drawing.Point(86, 270)
        Me.txtDirCont2.Name = "txtDirCont2"
        Me.txtDirCont2.Size = New System.Drawing.Size(271, 27)
        Me.txtDirCont2.TabIndex = 18
        '
        'txtTelCont2
        '
        Me.txtTelCont2.BackColor = System.Drawing.Color.White
        Me.txtTelCont2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelCont2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "TELCONT2", True))
        Me.txtTelCont2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCont2.Location = New System.Drawing.Point(86, 301)
        Me.txtTelCont2.Name = "txtTelCont2"
        Me.txtTelCont2.Size = New System.Drawing.Size(271, 27)
        Me.txtTelCont2.TabIndex = 16
        '
        'pbxLink
        '
        Me.pbxLink.BackColor = System.Drawing.Color.Transparent
        Me.pbxLink.BackgroundImage = CType(resources.GetObject("pbxLink.BackgroundImage"), System.Drawing.Image)
        Me.pbxLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbxLink.Location = New System.Drawing.Point(301, 45)
        Me.pbxLink.Name = "pbxLink"
        Me.pbxLink.Size = New System.Drawing.Size(79, 30)
        Me.pbxLink.TabIndex = 428
        Me.pbxLink.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(363, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 422
        Me.Label1.Text = "Nro Proveedor:"
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "NOMBRE", True))
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 20.25!)
        Me.lblNombre.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblNombre.Location = New System.Drawing.Point(384, 42)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(441, 37)
        Me.lblNombre.TabIndex = 463
        Me.lblNombre.Text = "lblNombre"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Tan
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.tbxProveedorEstado, Me.barProveedor})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 678)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(837, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 464
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(602, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'tbxProveedorEstado
        '
        Me.tbxProveedorEstado.BackColor = System.Drawing.Color.Transparent
        Me.tbxProveedorEstado.Name = "tbxProveedorEstado"
        Me.tbxProveedorEstado.Size = New System.Drawing.Size(61, 17)
        Me.tbxProveedorEstado.Text = "Proveedor"
        '
        'barProveedor
        '
        Me.barProveedor.Name = "barProveedor"
        Me.barProveedor.Size = New System.Drawing.Size(100, 16)
        Me.barProveedor.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'txtTelCont1
        '
        Me.txtTelCont1.BackColor = System.Drawing.Color.White
        Me.txtTelCont1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTelCont1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "TELCONT1", True))
        Me.txtTelCont1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelCont1.Location = New System.Drawing.Point(86, 121)
        Me.txtTelCont1.Name = "txtTelCont1"
        Me.txtTelCont1.Size = New System.Drawing.Size(271, 27)
        Me.txtTelCont1.TabIndex = 11
        '
        'txtDirCont1
        '
        Me.txtDirCont1.BackColor = System.Drawing.Color.White
        Me.txtDirCont1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDirCont1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "DIRECCIONCONT1", True))
        Me.txtDirCont1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirCont1.Location = New System.Drawing.Point(86, 89)
        Me.txtDirCont1.Name = "txtDirCont1"
        Me.txtDirCont1.Size = New System.Drawing.Size(271, 27)
        Me.txtDirCont1.TabIndex = 13
        '
        'txtEmailCont1
        '
        Me.txtEmailCont1.BackColor = System.Drawing.Color.White
        Me.txtEmailCont1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmailCont1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "EMAILCONT1", True))
        Me.txtEmailCont1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmailCont1.Location = New System.Drawing.Point(86, 153)
        Me.txtEmailCont1.Name = "txtEmailCont1"
        Me.txtEmailCont1.Size = New System.Drawing.Size(271, 27)
        Me.txtEmailCont1.TabIndex = 14
        '
        'txtNomCont1
        '
        Me.txtNomCont1.BackColor = System.Drawing.Color.White
        Me.txtNomCont1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNomCont1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "CONTACTO1", True))
        Me.txtNomCont1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomCont1.Location = New System.Drawing.Point(86, 57)
        Me.txtNomCont1.Name = "txtNomCont1"
        Me.txtNomCont1.Size = New System.Drawing.Size(271, 27)
        Me.txtNomCont1.TabIndex = 10
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(22, 63)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(60, 16)
        Me.Label35.TabIndex = 463
        Me.Label35.Text = "Nombre:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(17, 127)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(65, 16)
        Me.Label34.TabIndex = 463
        Me.Label34.Text = "Telefono:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(50, 95)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(32, 16)
        Me.Label32.TabIndex = 463
        Me.Label32.Text = "Rol:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(37, 159)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(45, 16)
        Me.Label31.TabIndex = 463
        Me.Label31.Text = "Email:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(4, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(138, 28)
        Me.Label30.TabIndex = 466
        Me.Label30.Text = "Info Contacto 1"
        '
        'PanelContacto
        '
        Me.PanelContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelContacto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelContacto.BackColor = System.Drawing.Color.LightGray
        Me.PanelContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelContacto.Controls.Add(Me.RadLabel16)
        Me.PanelContacto.Controls.Add(Me.Label13)
        Me.PanelContacto.Controls.Add(Me.Label22)
        Me.PanelContacto.Controls.Add(Me.Label30)
        Me.PanelContacto.Controls.Add(Me.Label18)
        Me.PanelContacto.Controls.Add(Me.Label31)
        Me.PanelContacto.Controls.Add(Me.Label32)
        Me.PanelContacto.Controls.Add(Me.Label20)
        Me.PanelContacto.Controls.Add(Me.Label34)
        Me.PanelContacto.Controls.Add(Me.Label21)
        Me.PanelContacto.Controls.Add(Me.Label35)
        Me.PanelContacto.Controls.Add(Me.txtNomCont2)
        Me.PanelContacto.Controls.Add(Me.txtNomCont1)
        Me.PanelContacto.Controls.Add(Me.txtEmailCont1)
        Me.PanelContacto.Controls.Add(Me.txtEmailCont2)
        Me.PanelContacto.Controls.Add(Me.txtDirCont1)
        Me.PanelContacto.Controls.Add(Me.txtDirCont2)
        Me.PanelContacto.Controls.Add(Me.txtTelCont1)
        Me.PanelContacto.Controls.Add(Me.txtTelCont2)
        Me.PanelContacto.Location = New System.Drawing.Point(303, 116)
        Me.PanelContacto.Name = "PanelContacto"
        Me.PanelContacto.Size = New System.Drawing.Size(459, 559)
        Me.PanelContacto.TabIndex = 478
        Me.PanelContacto.Visible = False
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.Location = New System.Drawing.Point(366, 395)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.Size = New System.Drawing.Size(89, 16)
        Me.RadLabel16.TabIndex = 468
        Me.RadLabel16.Text = "ESC - Para Salir"
        '
        'lblFormaPago
        '
        Me.lblFormaPago.AutoSize = True
        Me.lblFormaPago.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PROVEEDORBindingSource, "FORMAPAGO", True))
        Me.lblFormaPago.Location = New System.Drawing.Point(159, 506)
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Size = New System.Drawing.Size(45, 13)
        Me.lblFormaPago.TabIndex = 479
        Me.lblFormaPago.Text = "Label14"
        '
        'PictureBoxActivo
        '
        Me.PictureBoxActivo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxActivo.Image = Global.ContaExpress.My.Resources.Resources.AbiertoActive
        Me.PictureBoxActivo.Location = New System.Drawing.Point(738, 76)
        Me.PictureBoxActivo.Name = "PictureBoxActivo"
        Me.PictureBoxActivo.Size = New System.Drawing.Size(32, 35)
        Me.PictureBoxActivo.TabIndex = 480
        Me.PictureBoxActivo.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.BackColor = System.Drawing.Color.Transparent
        Me.lblActivo.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblActivo.Location = New System.Drawing.Point(770, 87)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 481
        Me.lblActivo.Text = "Activo"
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(450, 1)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(376, 1)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(339, 1)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'BuscarProveedorTextBox
        '
        Me.BuscarProveedorTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarProveedorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarProveedorTextBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BuscarProveedorTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarProveedorTextBox.Location = New System.Drawing.Point(30, 5)
        Me.BuscarProveedorTextBox.Name = "BuscarProveedorTextBox"
        Me.BuscarProveedorTextBox.Size = New System.Drawing.Size(264, 30)
        Me.BuscarProveedorTextBox.TabIndex = 426
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(413, 1)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(302, 1)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(2, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 455
        Me.PictureBox8.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbxDatosContacto)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.BuscarProveedorTextBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 40)
        Me.Panel1.TabIndex = 13
        '
        'pbxDatosContacto
        '
        Me.pbxDatosContacto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxDatosContacto.BackColor = System.Drawing.Color.Transparent
        Me.pbxDatosContacto.Image = Global.ContaExpress.My.Resources.Resources.User
        Me.pbxDatosContacto.Location = New System.Drawing.Point(797, 1)
        Me.pbxDatosContacto.Name = "pbxDatosContacto"
        Me.pbxDatosContacto.Size = New System.Drawing.Size(35, 35)
        Me.pbxDatosContacto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDatosContacto.TabIndex = 459
        Me.pbxDatosContacto.TabStop = False
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
        'Proveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(837, 700)
        Me.Controls.Add(Me.pnlProveedor)
        Me.Controls.Add(Me.PictureBoxActivo)
        Me.Controls.Add(Me.lblActivo)
        Me.Controls.Add(Me.ProveedorGridView)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbxLink)
        Me.Controls.Add(Me.NumProveedorTextBox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CodProvTextBox)
        Me.Controls.Add(Me.NombreProveedorTextBox)
        Me.Controls.Add(Me.lblFormaPago)
        Me.Controls.Add(Me.PanelContacto)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.pnlContacto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Proveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proveedor  | Cogent SIG"
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CATEGORIAPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGuardarP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnNuevoP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProveedorGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProveedor.ResumeLayout(False)
        Me.pnlProveedor.PerformLayout()
        CType(Me.btnAddPais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnIrLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnVerContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarCentroCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensajeError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContacto.ResumeLayout(False)
        Me.pnlContacto.PerformLayout()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.PanelContacto.ResumeLayout(False)
        Me.PanelContacto.PerformLayout()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxDatosContacto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CodProvTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DsProveedores As ContaExpress.DsProveedores
    Friend WithEvents PROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROVEEDORTableAdapter As ContaExpress.DsProveedoresTableAdapters.PROVEEDORTableAdapter
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents CENTROCOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CENTROCOSTOTableAdapter As ContaExpress.DsProveedoresTableAdapters.CENTROCOSTOTableAdapter
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsProveedoresTableAdapters.MONEDATableAdapter
    Friend WithEvents CATEGORIAPROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CATEGORIAPROVEEDORTableAdapter As ContaExpress.DsProveedoresTableAdapters.CATEGORIAPROVEEDORTableAdapter
    Friend WithEvents BtnGuardarP1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnNuevoP1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents NumProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NombreProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProveedorGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RucProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TimbradoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DireccionProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TelefonoProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pnlProveedor As System.Windows.Forms.Panel
    Friend WithEvents CentroCostoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MonedaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CategoriaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CategoriaTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pbxLink As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAgregarCentroCosto As System.Windows.Forms.PictureBox
    Friend WithEvents chbxExterior As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbxProveedorEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barProveedor As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtNomCont2 As System.Windows.Forms.TextBox
    Friend WithEvents txtDirCont2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCont2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtEmailCont2 As System.Windows.Forms.TextBox
    Friend WithEvents txtTelCont1 As System.Windows.Forms.TextBox
    Friend WithEvents txtDirCont1 As System.Windows.Forms.TextBox
    Friend WithEvents txtEmailCont1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNomCont1 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents PanelContacto As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbxEmailGral As System.Windows.Forms.TextBox
    Friend WithEvents lblFormaPago As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBoxActivo As System.Windows.Forms.PictureBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarProveedorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxDatosContacto As System.Windows.Forms.PictureBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbxDiasVto As System.Windows.Forms.TextBox
    Friend WithEvents dtpVtoTimbrado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cuotas As System.Windows.Forms.Label
    Friend WithEvents tbxCantCuotas As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents NUMPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIASLOGISTICA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIASVENCIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAVTOTIMBRADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAPAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCCINDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODZONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CELULARDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAXDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WEBDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ObservacionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImagenDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMBRADOFACTURADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMBRADORETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MASCARADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCENTRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAJURIDICADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTEIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCATEGORIAPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMensajeError As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tbxRepresentanteLegal As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cmbPais As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbxZona As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddPais As System.Windows.Forms.PictureBox
    Friend WithEvents DsCliente As ContaExpress.DsCliente
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.DsClienteTableAdapters.PAISTableAdapter
    Friend WithEvents CIUDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CIUDADTableAdapter As ContaExpress.DsClienteTableAdapters.CIUDADTableAdapter
    Friend WithEvents ZONABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZONATableAdapter As ContaExpress.DsClienteTableAdapters.ZONATableAdapter
    Friend WithEvents txtGMaps As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnIrLink As System.Windows.Forms.PictureBox
    Friend WithEvents btnVerContacto As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbxContacto As System.Windows.Forms.TextBox
    Friend WithEvents pnlContacto As System.Windows.Forms.Panel
    Friend WithEvents tbxCelContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbxTelContacto As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tbxMail2Contacto As System.Windows.Forms.TextBox
    Friend WithEvents tbxMail1Contacto As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents lblNombreContacto As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents tbxCodPostal As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
End Class
