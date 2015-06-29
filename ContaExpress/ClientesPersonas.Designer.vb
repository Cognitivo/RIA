<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesPersonas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesPersonas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCliente = New ContaExpress.DsCliente()
        Me.pnlDatosCliente = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbledad = New System.Windows.Forms.Label()
        Me.pbxAgregarCiudad = New System.Windows.Forms.PictureBox()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxZona = New System.Windows.Forms.ComboBox()
        Me.ZONABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCiudad = New System.Windows.Forms.ComboBox()
        Me.CIUDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblRuc = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.tbxCellular = New System.Windows.Forms.TextBox()
        Me.tbxTel = New System.Windows.Forms.TextBox()
        Me.tbxEmail = New System.Windows.Forms.TextBox()
        Me.tbxRUC = New System.Windows.Forms.TextBox()
        Me.txtNombreClienteR = New System.Windows.Forms.TextBox()
        Me.txtIdClienteR = New System.Windows.Forms.TextBox()
        Me.VENDEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPOCLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CATEGORIACLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.pbxLink = New System.Windows.Forms.PictureBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.dgvClientes = New System.Windows.Forms.DataGridView()
        Me.TIPORELACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSTOMFIELD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODZONADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCOBRADORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENDEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCEDULADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CELULARDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAXDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WEBDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LIMCREDITODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINGRESODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PORCENTAJEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBSERVACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONDICIONVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRENVIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMEROTOLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHANACIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTORIZADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPAISDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMBRADOFACTURADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMBRADORETENCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEXODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROVEEDORIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAIL1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCIUDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTEEXENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERSONAJURIDICADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MATRIZDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTIVOANULADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxImprimir = New System.Windows.Forms.PictureBox()
        Me.pbxMostrarOBS = New System.Windows.Forms.PictureBox()
        Me.pbxClienteFinanzas = New System.Windows.Forms.PictureBox()
        Me.pbxDatosCliente = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.pnlObservacion = New System.Windows.Forms.Panel()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.btnCerrarOBS = New Telerik.WinControls.UI.RadButton()
        Me.txtObservacion = New Telerik.WinControls.UI.RadTextBox()
        Me.txtNroCliente = New System.Windows.Forms.TextBox()
        Me.DataGridViewTextBoxColumn54 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn55 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn56 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn57 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn58 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn59 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn60 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn61 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn62 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn63 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn64 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn65 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn66 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn67 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn68 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn69 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn70 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CLIENTESRELACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxCodCliente = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tbxVencimiento = New System.Windows.Forms.TextBox()
        Me.cbxTipoVenta = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MOVIMIENTOCUENTACLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.pnlFinanzas = New System.Windows.Forms.Panel()
        Me.GridViewCuentaCliente = New System.Windows.Forms.DataGridView()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROCOMPROBANTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCOBRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NRORECIBO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCOMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.tbxLimiteCredito = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblClienteEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbarClientes = New System.Windows.Forms.ToolStripProgressBar()
        Me.CLIENTESFILTROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.CLIENTESTableAdapter = New ContaExpress.DsClienteTableAdapters.CLIENTESTableAdapter()
        Me.TIPOCLIENTETableAdapter = New ContaExpress.DsClienteTableAdapters.TIPOCLIENTETableAdapter()
        Me.VENDEDORTableAdapter = New ContaExpress.DsClienteTableAdapters.VENDEDORTableAdapter()
        Me.CIUDADTableAdapter = New ContaExpress.DsClienteTableAdapters.CIUDADTableAdapter()
        Me.ZONATableAdapter = New ContaExpress.DsClienteTableAdapters.ZONATableAdapter()
        Me.CATEGORIACLIENTETableAdapter = New ContaExpress.DsClienteTableAdapters.CATEGORIACLIENTETableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsClienteTableAdapters.TableAdapterManager()
        Me.MOVIMIENTOCUENTACLIENTETableAdapter = New ContaExpress.DsClienteTableAdapters.MOVIMIENTOCUENTACLIENTETableAdapter()
        Me.CLIENTESRELACIONTableAdapter = New ContaExpress.DsClienteTableAdapters.CLIENTESRELACIONTableAdapter()
        Me.CLIENTESFILTROTableAdapter = New ContaExpress.DsClienteTableAdapters.CLIENTESFILTROTableAdapter()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PAISTableAdapter = New ContaExpress.DsClienteTableAdapters.PAISTableAdapter()
        Me.DsRVFacturacion = New ContaExpress.DsRVFacturacion()
        Me.RVMovimientosClienteBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RVMovimientosClienteTableAdapter = New ContaExpress.DsRVFacturacionTableAdapters.RVMovimientosClienteTableAdapter()
        Me.Label12 = New System.Windows.Forms.Label()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosCliente.SuspendLayout()
        CType(Me.pbxAgregarCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CATEGORIACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxMostrarOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxClienteFinanzas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDatosCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlObservacion.SuspendLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCerrarOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESRELACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MOVIMIENTOCUENTACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFinanzas.SuspendLayout()
        CType(Me.GridViewCuentaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.CLIENTESFILTROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RVMovimientosClienteBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsClienteBindingSource
        '
        'DsClienteBindingSource
        '
        Me.DsClienteBindingSource.DataSource = Me.DsCliente
        Me.DsClienteBindingSource.Position = 0
        '
        'DsCliente
        '
        Me.DsCliente.DataSetName = "DsCliente"
        Me.DsCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnlDatosCliente
        '
        Me.pnlDatosCliente.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDatosCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDatosCliente.BackColor = System.Drawing.Color.LightGray
        Me.pnlDatosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDatosCliente.Controls.Add(Me.Label2)
        Me.pnlDatosCliente.Controls.Add(Me.lbledad)
        Me.pnlDatosCliente.Controls.Add(Me.pbxAgregarCiudad)
        Me.pnlDatosCliente.Controls.Add(Me.cmbSexo)
        Me.pnlDatosCliente.Controls.Add(Me.Label19)
        Me.pnlDatosCliente.Controls.Add(Me.dtpFechaNac)
        Me.pnlDatosCliente.Controls.Add(Me.Label9)
        Me.pnlDatosCliente.Controls.Add(Me.cbxZona)
        Me.pnlDatosCliente.Controls.Add(Me.cbxCiudad)
        Me.pnlDatosCliente.Controls.Add(Me.lblRuc)
        Me.pnlDatosCliente.Controls.Add(Me.Label11)
        Me.pnlDatosCliente.Controls.Add(Me.Label5)
        Me.pnlDatosCliente.Controls.Add(Me.Label4)
        Me.pnlDatosCliente.Controls.Add(Me.Label1)
        Me.pnlDatosCliente.Controls.Add(Me.txtDireccion)
        Me.pnlDatosCliente.Controls.Add(Me.tbxCellular)
        Me.pnlDatosCliente.Controls.Add(Me.tbxTel)
        Me.pnlDatosCliente.Controls.Add(Me.tbxEmail)
        Me.pnlDatosCliente.Controls.Add(Me.tbxRUC)
        Me.pnlDatosCliente.Controls.Add(Me.txtNombreClienteR)
        Me.pnlDatosCliente.Controls.Add(Me.txtIdClienteR)
        Me.pnlDatosCliente.Location = New System.Drawing.Point(229, 160)
        Me.pnlDatosCliente.Name = "pnlDatosCliente"
        Me.pnlDatosCliente.Size = New System.Drawing.Size(562, 480)
        Me.pnlDatosCliente.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(439, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 467
        Me.Label2.Text = "años"
        Me.Label2.Visible = False
        '
        'lbledad
        '
        Me.lbledad.AutoSize = True
        Me.lbledad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbledad.Location = New System.Drawing.Point(404, 61)
        Me.lbledad.Name = "lbledad"
        Me.lbledad.Size = New System.Drawing.Size(0, 20)
        Me.lbledad.TabIndex = 466
        Me.lbledad.Visible = False
        '
        'pbxAgregarCiudad
        '
        Me.pbxAgregarCiudad.BackColor = System.Drawing.Color.LightGray
        Me.pbxAgregarCiudad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarCiudad.Image = CType(resources.GetObject("pbxAgregarCiudad.Image"), System.Drawing.Image)
        Me.pbxAgregarCiudad.Location = New System.Drawing.Point(483, 394)
        Me.pbxAgregarCiudad.Name = "pbxAgregarCiudad"
        Me.pbxAgregarCiudad.Size = New System.Drawing.Size(26, 26)
        Me.pbxAgregarCiudad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxAgregarCiudad.TabIndex = 465
        Me.pbxAgregarCiudad.TabStop = False
        Me.ToolTip1.SetToolTip(Me.pbxAgregarCiudad, "Esto abrira la Ventana Ciudad/Zona para cargar nuevos datos")
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.Color.White
        Me.cmbSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSexo.ForeColor = System.Drawing.Color.Black
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.cmbSexo.Location = New System.Drawing.Point(161, 138)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(317, 28)
        Me.cmbSexo.TabIndex = 440
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Enabled = False
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(112, 144)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(42, 16)
        Me.Label19.TabIndex = 439
        Me.Label19.Text = "Sexo:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNac.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaNac.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "FECHANACIMIENTO", True))
        Me.dtpFechaNac.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNac.Location = New System.Drawing.Point(161, 85)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(317, 27)
        Me.dtpFechaNac.TabIndex = 438
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(15, 91)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 16)
        Me.Label9.TabIndex = 437
        Me.Label9.Text = "Fecha de Nacimiento:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxZona
        '
        Me.cbxZona.BackColor = System.Drawing.Color.White
        Me.cbxZona.CausesValidation = False
        Me.cbxZona.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "CODZONA", True))
        Me.cbxZona.DataSource = Me.ZONABindingSource
        Me.cbxZona.DisplayMember = "DESZONA"
        Me.cbxZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxZona.ForeColor = System.Drawing.Color.Black
        Me.cbxZona.FormattingEnabled = True
        Me.cbxZona.Location = New System.Drawing.Point(330, 393)
        Me.cbxZona.Name = "cbxZona"
        Me.cbxZona.Size = New System.Drawing.Size(148, 28)
        Me.cbxZona.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.cbxZona, "La Zona donde vive o trabaja este Cliente")
        Me.cbxZona.ValueMember = "CODZONA"
        '
        'ZONABindingSource
        '
        Me.ZONABindingSource.DataMember = "ZONA"
        Me.ZONABindingSource.DataSource = Me.DsClienteBindingSource
        '
        'cbxCiudad
        '
        Me.cbxCiudad.BackColor = System.Drawing.Color.White
        Me.cbxCiudad.CausesValidation = False
        Me.cbxCiudad.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "CODCIUDAD", True))
        Me.cbxCiudad.DataSource = Me.CIUDADBindingSource
        Me.cbxCiudad.DisplayMember = "DESCIUDAD"
        Me.cbxCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCiudad.ForeColor = System.Drawing.Color.Black
        Me.cbxCiudad.FormattingEnabled = True
        Me.cbxCiudad.Location = New System.Drawing.Point(161, 393)
        Me.cbxCiudad.Name = "cbxCiudad"
        Me.cbxCiudad.Size = New System.Drawing.Size(166, 28)
        Me.cbxCiudad.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.cbxCiudad, "La Ciudad donde vive/trabaj este Cliente")
        Me.cbxCiudad.ValueMember = "CODCIUDAD"
        '
        'CIUDADBindingSource
        '
        Me.CIUDADBindingSource.DataMember = "CIUDAD"
        Me.CIUDADBindingSource.DataSource = Me.DsClienteBindingSource
        '
        'lblRuc
        '
        Me.lblRuc.AutoSize = True
        Me.lblRuc.Enabled = False
        Me.lblRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblRuc.ForeColor = System.Drawing.Color.Black
        Me.lblRuc.Location = New System.Drawing.Point(98, 21)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.Size(57, 16)
        Me.lblRuc.TabIndex = 0
        Me.lblRuc.Text = "C.I. Nro.:"
        Me.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(86, 349)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Direccion:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(101, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Celular:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(89, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Telefono:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(32, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Correo Electronico:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.Color.White
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "DIRECCION", True))
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(161, 344)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(317, 27)
        Me.txtDireccion.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtDireccion, "Direccion del Cliente")
        '
        'tbxCellular
        '
        Me.tbxCellular.BackColor = System.Drawing.Color.White
        Me.tbxCellular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCellular.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "CELULAR", True))
        Me.tbxCellular.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCellular.Location = New System.Drawing.Point(161, 290)
        Me.tbxCellular.Name = "tbxCellular"
        Me.tbxCellular.Size = New System.Drawing.Size(317, 27)
        Me.tbxCellular.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.tbxCellular, "El Nro del Cellular")
        '
        'tbxTel
        '
        Me.tbxTel.BackColor = System.Drawing.Color.White
        Me.tbxTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "TELEFONO", True))
        Me.tbxTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTel.Location = New System.Drawing.Point(161, 242)
        Me.tbxTel.Name = "tbxTel"
        Me.tbxTel.Size = New System.Drawing.Size(317, 27)
        Me.tbxTel.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.tbxTel, "Nro de Telefono del Cliente")
        '
        'tbxEmail
        '
        Me.tbxEmail.BackColor = System.Drawing.Color.White
        Me.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "EMAIL", True))
        Me.tbxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEmail.Location = New System.Drawing.Point(161, 195)
        Me.tbxEmail.Name = "tbxEmail"
        Me.tbxEmail.Size = New System.Drawing.Size(317, 27)
        Me.tbxEmail.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.tbxEmail, "Correo Electronico para ser utilizado con el Modulo de Marketing")
        '
        'tbxRUC
        '
        Me.tbxRUC.BackColor = System.Drawing.Color.White
        Me.tbxRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRUC.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "RUC", True))
        Me.tbxRUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxRUC.Location = New System.Drawing.Point(161, 16)
        Me.tbxRUC.Name = "tbxRUC"
        Me.tbxRUC.Size = New System.Drawing.Size(317, 27)
        Me.tbxRUC.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.tbxRUC, "El RUC o Nro de Cedula del Cliente")
        '
        'txtNombreClienteR
        '
        Me.txtNombreClienteR.BackColor = System.Drawing.Color.Gainsboro
        Me.txtNombreClienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreClienteR.Enabled = False
        Me.txtNombreClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtNombreClienteR.Location = New System.Drawing.Point(232, 16)
        Me.txtNombreClienteR.Name = "txtNombreClienteR"
        Me.txtNombreClienteR.Size = New System.Drawing.Size(246, 27)
        Me.txtNombreClienteR.TabIndex = 16
        '
        'txtIdClienteR
        '
        Me.txtIdClienteR.BackColor = System.Drawing.Color.Gainsboro
        Me.txtIdClienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdClienteR.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "RELACION", True))
        Me.txtIdClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtIdClienteR.Location = New System.Drawing.Point(161, 16)
        Me.txtIdClienteR.Name = "txtIdClienteR"
        Me.txtIdClienteR.Size = New System.Drawing.Size(73, 27)
        Me.txtIdClienteR.TabIndex = 14
        '
        'VENDEDORBindingSource
        '
        Me.VENDEDORBindingSource.DataMember = "VENDEDOR"
        Me.VENDEDORBindingSource.DataSource = Me.DsClienteBindingSource
        '
        'TIPOCLIENTEBindingSource
        '
        Me.TIPOCLIENTEBindingSource.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource.DataSource = Me.DsClienteBindingSource
        '
        'CATEGORIACLIENTEBindingSource
        '
        Me.CATEGORIACLIENTEBindingSource.DataMember = "CATEGORIACLIENTE"
        Me.CATEGORIACLIENTEBindingSource.DataSource = Me.DsCliente
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NOMBRE", True))
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblNombre.Location = New System.Drawing.Point(307, 46)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(471, 38)
        Me.lblNombre.TabIndex = 28
        Me.lblNombre.Text = "Client Label"
        '
        'pbxLink
        '
        Me.pbxLink.BackColor = System.Drawing.Color.Transparent
        Me.pbxLink.BackgroundImage = CType(resources.GetObject("pbxLink.BackgroundImage"), System.Drawing.Image)
        Me.pbxLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbxLink.Location = New System.Drawing.Point(227, 50)
        Me.pbxLink.Name = "pbxLink"
        Me.pbxLink.Size = New System.Drawing.Size(79, 30)
        Me.pbxLink.TabIndex = 4
        Me.pbxLink.TabStop = False
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NOMBRE", True))
        Me.txtCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(312, 51)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(398, 30)
        Me.txtCliente.TabIndex = 0
        Me.txtCliente.Visible = False
        Me.txtCliente.WordWrap = False
        '
        'dgvClientes
        '
        Me.dgvClientes.AllowUserToAddRows = False
        Me.dgvClientes.AllowUserToDeleteRows = False
        Me.dgvClientes.AllowUserToResizeColumns = False
        Me.dgvClientes.AllowUserToResizeRows = False
        Me.dgvClientes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvClientes.AutoGenerateColumns = False
        Me.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvClientes.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClientes.ColumnHeadersHeight = 35
        Me.dgvClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TIPORELACION, Me.NUMCLIENTE, Me.RELACION, Me.CUSTOMFIELD, Me.CODCLIENTEDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.CODZONADataGridViewTextBoxColumn, Me.CODCOBRADORDataGridViewTextBoxColumn, Me.CODVENDEDORDataGridViewTextBoxColumn, Me.CODTIPOCLIENTEDataGridViewTextBoxColumn, Me.CLIENTEDataGridViewTextBoxColumn, Me.NUMCEDULADataGridViewTextBoxColumn, Me.RUCDataGridViewTextBoxColumn1, Me.DIRECCIONDataGridViewTextBoxColumn, Me.TELEFONODataGridViewTextBoxColumn, Me.CELULARDataGridViewTextBoxColumn, Me.FAXDataGridViewTextBoxColumn, Me.EMAILDataGridViewTextBoxColumn, Me.WEBDataGridViewTextBoxColumn, Me.LIMCREDITODataGridViewTextBoxColumn, Me.FECHAINGRESODataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn, Me.PORCENTAJEDataGridViewTextBoxColumn, Me.OBSERVACIONDataGridViewTextBoxColumn, Me.DIASVENCIMIENTODataGridViewTextBoxColumn, Me.CONDICIONVENTADataGridViewTextBoxColumn, Me.DIRENVIODataGridViewTextBoxColumn, Me.CODIGOCOMISIONDataGridViewTextBoxColumn, Me.NUMEROTOLDataGridViewTextBoxColumn, Me.CODSUCURSALDataGridViewTextBoxColumn, Me.FECHANACIMIENTODataGridViewTextBoxColumn, Me.AUTORIZADODataGridViewTextBoxColumn, Me.FECAUTORIZACIONDataGridViewTextBoxColumn, Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn, Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn, Me.IMAGENCLIENTEDataGridViewTextBoxColumn, Me.CODPAISDataGridViewTextBoxColumn, Me.EMPPRESACLIENTEDataGridViewTextBoxColumn, Me.TIMBRADOFACTURADataGridViewTextBoxColumn, Me.TIMBRADORETENCIONDataGridViewTextBoxColumn, Me.SEXODataGridViewTextBoxColumn, Me.PROVEEDORIDDataGridViewTextBoxColumn, Me.TELEFONO1DataGridViewTextBoxColumn, Me.EMAIL1DataGridViewTextBoxColumn, Me.CODCIUDADDataGridViewTextBoxColumn, Me.CLIENTEEXENTODataGridViewTextBoxColumn, Me.PERSONAJURIDICADataGridViewTextBoxColumn, Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn, Me.TIPOVENTADataGridViewTextBoxColumn, Me.MATRIZDataGridViewTextBoxColumn, Me.DVDataGridViewTextBoxColumn, Me.CODDEPOSITO, Me.MOTIVOANULADO})
        Me.dgvClientes.DataSource = Me.CLIENTESBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClientes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvClientes.Location = New System.Drawing.Point(2, 40)
        Me.dgvClientes.MultiSelect = False
        Me.dgvClientes.Name = "dgvClientes"
        Me.dgvClientes.ReadOnly = True
        Me.dgvClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClientes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvClientes.RowHeadersVisible = False
        Me.dgvClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientes.Size = New System.Drawing.Size(221, 601)
        Me.dgvClientes.TabIndex = 453
        '
        'TIPORELACION
        '
        Me.TIPORELACION.DataPropertyName = "TIPORELACION"
        Me.TIPORELACION.HeaderText = "TIPORELACION"
        Me.TIPORELACION.Name = "TIPORELACION"
        Me.TIPORELACION.ReadOnly = True
        Me.TIPORELACION.Visible = False
        '
        'NUMCLIENTE
        '
        Me.NUMCLIENTE.DataPropertyName = "NUMCLIENTE1"
        Me.NUMCLIENTE.HeaderText = "Nro. Cliente"
        Me.NUMCLIENTE.Name = "NUMCLIENTE"
        Me.NUMCLIENTE.ReadOnly = True
        Me.NUMCLIENTE.Visible = False
        '
        'RELACION
        '
        Me.RELACION.DataPropertyName = "RELACION"
        Me.RELACION.HeaderText = "RELACION"
        Me.RELACION.Name = "RELACION"
        Me.RELACION.ReadOnly = True
        Me.RELACION.Visible = False
        '
        'CUSTOMFIELD
        '
        Me.CUSTOMFIELD.DataPropertyName = "CUSTOMFIELD"
        Me.CUSTOMFIELD.HeaderText = "CUSTOMFIELD"
        Me.CUSTOMFIELD.Name = "CUSTOMFIELD"
        Me.CUSTOMFIELD.ReadOnly = True
        Me.CUSTOMFIELD.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
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
        'CODCOBRADORDataGridViewTextBoxColumn
        '
        Me.CODCOBRADORDataGridViewTextBoxColumn.DataPropertyName = "CODCOBRADOR"
        Me.CODCOBRADORDataGridViewTextBoxColumn.HeaderText = "CODCOBRADOR"
        Me.CODCOBRADORDataGridViewTextBoxColumn.Name = "CODCOBRADORDataGridViewTextBoxColumn"
        Me.CODCOBRADORDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCOBRADORDataGridViewTextBoxColumn.Visible = False
        '
        'CODVENDEDORDataGridViewTextBoxColumn
        '
        Me.CODVENDEDORDataGridViewTextBoxColumn.DataPropertyName = "CODVENDEDOR"
        Me.CODVENDEDORDataGridViewTextBoxColumn.HeaderText = "CODVENDEDOR"
        Me.CODVENDEDORDataGridViewTextBoxColumn.Name = "CODVENDEDORDataGridViewTextBoxColumn"
        Me.CODVENDEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODVENDEDORDataGridViewTextBoxColumn.Visible = False
        '
        'CODTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Name = "CODTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CLIENTEDataGridViewTextBoxColumn
        '
        Me.CLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CLIENTE"
        Me.CLIENTEDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.CLIENTEDataGridViewTextBoxColumn.Name = "CLIENTEDataGridViewTextBoxColumn"
        Me.CLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NUMCEDULADataGridViewTextBoxColumn
        '
        Me.NUMCEDULADataGridViewTextBoxColumn.DataPropertyName = "NUMCEDULA"
        Me.NUMCEDULADataGridViewTextBoxColumn.HeaderText = "NUMCEDULA"
        Me.NUMCEDULADataGridViewTextBoxColumn.Name = "NUMCEDULADataGridViewTextBoxColumn"
        Me.NUMCEDULADataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMCEDULADataGridViewTextBoxColumn.Visible = False
        '
        'RUCDataGridViewTextBoxColumn1
        '
        Me.RUCDataGridViewTextBoxColumn1.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn1.HeaderText = "Ruc"
        Me.RUCDataGridViewTextBoxColumn1.Name = "RUCDataGridViewTextBoxColumn1"
        Me.RUCDataGridViewTextBoxColumn1.ReadOnly = True
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
        'LIMCREDITODataGridViewTextBoxColumn
        '
        Me.LIMCREDITODataGridViewTextBoxColumn.DataPropertyName = "LIMCREDITO"
        Me.LIMCREDITODataGridViewTextBoxColumn.HeaderText = "LIMCREDITO"
        Me.LIMCREDITODataGridViewTextBoxColumn.Name = "LIMCREDITODataGridViewTextBoxColumn"
        Me.LIMCREDITODataGridViewTextBoxColumn.ReadOnly = True
        Me.LIMCREDITODataGridViewTextBoxColumn.Visible = False
        '
        'FECHAINGRESODataGridViewTextBoxColumn
        '
        Me.FECHAINGRESODataGridViewTextBoxColumn.DataPropertyName = "FECHAINGRESO"
        Me.FECHAINGRESODataGridViewTextBoxColumn.HeaderText = "FECHAINGRESO"
        Me.FECHAINGRESODataGridViewTextBoxColumn.Name = "FECHAINGRESODataGridViewTextBoxColumn"
        Me.FECHAINGRESODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAINGRESODataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'PORCENTAJEDataGridViewTextBoxColumn
        '
        Me.PORCENTAJEDataGridViewTextBoxColumn.DataPropertyName = "PORCENTAJE"
        Me.PORCENTAJEDataGridViewTextBoxColumn.HeaderText = "PORCENTAJE"
        Me.PORCENTAJEDataGridViewTextBoxColumn.Name = "PORCENTAJEDataGridViewTextBoxColumn"
        Me.PORCENTAJEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PORCENTAJEDataGridViewTextBoxColumn.Visible = False
        '
        'OBSERVACIONDataGridViewTextBoxColumn
        '
        Me.OBSERVACIONDataGridViewTextBoxColumn.DataPropertyName = "OBSERVACION"
        Me.OBSERVACIONDataGridViewTextBoxColumn.HeaderText = "OBSERVACION"
        Me.OBSERVACIONDataGridViewTextBoxColumn.Name = "OBSERVACIONDataGridViewTextBoxColumn"
        Me.OBSERVACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.OBSERVACIONDataGridViewTextBoxColumn.Visible = False
        '
        'DIASVENCIMIENTODataGridViewTextBoxColumn
        '
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn.DataPropertyName = "DIASVENCIMIENTO"
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn.HeaderText = "DIASVENCIMIENTO"
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn.Name = "DIASVENCIMIENTODataGridViewTextBoxColumn"
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DIASVENCIMIENTODataGridViewTextBoxColumn.Visible = False
        '
        'CONDICIONVENTADataGridViewTextBoxColumn
        '
        Me.CONDICIONVENTADataGridViewTextBoxColumn.DataPropertyName = "CONDICIONVENTA"
        Me.CONDICIONVENTADataGridViewTextBoxColumn.HeaderText = "CONDICIONVENTA"
        Me.CONDICIONVENTADataGridViewTextBoxColumn.Name = "CONDICIONVENTADataGridViewTextBoxColumn"
        Me.CONDICIONVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.CONDICIONVENTADataGridViewTextBoxColumn.Visible = False
        '
        'DIRENVIODataGridViewTextBoxColumn
        '
        Me.DIRENVIODataGridViewTextBoxColumn.DataPropertyName = "DIRENVIO"
        Me.DIRENVIODataGridViewTextBoxColumn.HeaderText = "DIRENVIO"
        Me.DIRENVIODataGridViewTextBoxColumn.Name = "DIRENVIODataGridViewTextBoxColumn"
        Me.DIRENVIODataGridViewTextBoxColumn.ReadOnly = True
        Me.DIRENVIODataGridViewTextBoxColumn.Visible = False
        '
        'CODIGOCOMISIONDataGridViewTextBoxColumn
        '
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn.DataPropertyName = "CODIGOCOMISION"
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn.HeaderText = "CODIGOCOMISION"
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn.Name = "CODIGOCOMISIONDataGridViewTextBoxColumn"
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODIGOCOMISIONDataGridViewTextBoxColumn.Visible = False
        '
        'NUMEROTOLDataGridViewTextBoxColumn
        '
        Me.NUMEROTOLDataGridViewTextBoxColumn.DataPropertyName = "NUMEROTOL"
        Me.NUMEROTOLDataGridViewTextBoxColumn.HeaderText = "NUMEROTOL"
        Me.NUMEROTOLDataGridViewTextBoxColumn.Name = "NUMEROTOLDataGridViewTextBoxColumn"
        Me.NUMEROTOLDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMEROTOLDataGridViewTextBoxColumn.Visible = False
        '
        'CODSUCURSALDataGridViewTextBoxColumn
        '
        Me.CODSUCURSALDataGridViewTextBoxColumn.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.Name = "CODSUCURSALDataGridViewTextBoxColumn"
        Me.CODSUCURSALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODSUCURSALDataGridViewTextBoxColumn.Visible = False
        '
        'FECHANACIMIENTODataGridViewTextBoxColumn
        '
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.DataPropertyName = "FECHANACIMIENTO"
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.HeaderText = "FECHANACIMIENTO"
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.Name = "FECHANACIMIENTODataGridViewTextBoxColumn"
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.Visible = False
        '
        'AUTORIZADODataGridViewTextBoxColumn
        '
        Me.AUTORIZADODataGridViewTextBoxColumn.DataPropertyName = "AUTORIZADO"
        Me.AUTORIZADODataGridViewTextBoxColumn.HeaderText = "AUTORIZADO"
        Me.AUTORIZADODataGridViewTextBoxColumn.Name = "AUTORIZADODataGridViewTextBoxColumn"
        Me.AUTORIZADODataGridViewTextBoxColumn.ReadOnly = True
        Me.AUTORIZADODataGridViewTextBoxColumn.Visible = False
        '
        'FECAUTORIZACIONDataGridViewTextBoxColumn
        '
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.DataPropertyName = "FECAUTORIZACION"
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.HeaderText = "FECAUTORIZACION"
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.Name = "FECAUTORIZACIONDataGridViewTextBoxColumn"
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODCATEGORIACLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCATEGORIACLIENTE"
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCATEGORIACLIENTE"
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn.Name = "CODCATEGORIACLIENTEDataGridViewTextBoxColumn"
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCATEGORIACLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIENTEPRINCIPALDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTEPRINCIPAL"
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn.HeaderText = "CODCLIENTEPRINCIPAL"
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn.Name = "CODCLIENTEPRINCIPALDataGridViewTextBoxColumn"
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEPRINCIPALDataGridViewTextBoxColumn.Visible = False
        '
        'IMAGENCLIENTEDataGridViewTextBoxColumn
        '
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "IMAGENCLIENTE"
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn.HeaderText = "IMAGENCLIENTE"
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn.Name = "IMAGENCLIENTEDataGridViewTextBoxColumn"
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.IMAGENCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CODPAISDataGridViewTextBoxColumn
        '
        Me.CODPAISDataGridViewTextBoxColumn.DataPropertyName = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.HeaderText = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.Name = "CODPAISDataGridViewTextBoxColumn"
        Me.CODPAISDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPAISDataGridViewTextBoxColumn.Visible = False
        '
        'EMPPRESACLIENTEDataGridViewTextBoxColumn
        '
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn.DataPropertyName = "EMPPRESACLIENTE"
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn.HeaderText = "EMPPRESACLIENTE"
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn.Name = "EMPPRESACLIENTEDataGridViewTextBoxColumn"
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.EMPPRESACLIENTEDataGridViewTextBoxColumn.Visible = False
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
        'SEXODataGridViewTextBoxColumn
        '
        Me.SEXODataGridViewTextBoxColumn.DataPropertyName = "SEXO"
        Me.SEXODataGridViewTextBoxColumn.HeaderText = "SEXO"
        Me.SEXODataGridViewTextBoxColumn.Name = "SEXODataGridViewTextBoxColumn"
        Me.SEXODataGridViewTextBoxColumn.ReadOnly = True
        Me.SEXODataGridViewTextBoxColumn.Visible = False
        '
        'PROVEEDORIDDataGridViewTextBoxColumn
        '
        Me.PROVEEDORIDDataGridViewTextBoxColumn.DataPropertyName = "PROVEEDOR_ID"
        Me.PROVEEDORIDDataGridViewTextBoxColumn.HeaderText = "PROVEEDOR_ID"
        Me.PROVEEDORIDDataGridViewTextBoxColumn.Name = "PROVEEDORIDDataGridViewTextBoxColumn"
        Me.PROVEEDORIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.PROVEEDORIDDataGridViewTextBoxColumn.Visible = False
        '
        'TELEFONO1DataGridViewTextBoxColumn
        '
        Me.TELEFONO1DataGridViewTextBoxColumn.DataPropertyName = "TELEFONO1"
        Me.TELEFONO1DataGridViewTextBoxColumn.HeaderText = "TELEFONO1"
        Me.TELEFONO1DataGridViewTextBoxColumn.Name = "TELEFONO1DataGridViewTextBoxColumn"
        Me.TELEFONO1DataGridViewTextBoxColumn.ReadOnly = True
        Me.TELEFONO1DataGridViewTextBoxColumn.Visible = False
        '
        'EMAIL1DataGridViewTextBoxColumn
        '
        Me.EMAIL1DataGridViewTextBoxColumn.DataPropertyName = "EMAIL1"
        Me.EMAIL1DataGridViewTextBoxColumn.HeaderText = "EMAIL1"
        Me.EMAIL1DataGridViewTextBoxColumn.Name = "EMAIL1DataGridViewTextBoxColumn"
        Me.EMAIL1DataGridViewTextBoxColumn.ReadOnly = True
        Me.EMAIL1DataGridViewTextBoxColumn.Visible = False
        '
        'CODCIUDADDataGridViewTextBoxColumn
        '
        Me.CODCIUDADDataGridViewTextBoxColumn.DataPropertyName = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.HeaderText = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.Name = "CODCIUDADDataGridViewTextBoxColumn"
        Me.CODCIUDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCIUDADDataGridViewTextBoxColumn.Visible = False
        '
        'CLIENTEEXENTODataGridViewTextBoxColumn
        '
        Me.CLIENTEEXENTODataGridViewTextBoxColumn.DataPropertyName = "CLIENTEEXENTO"
        Me.CLIENTEEXENTODataGridViewTextBoxColumn.HeaderText = "CLIENTEEXENTO"
        Me.CLIENTEEXENTODataGridViewTextBoxColumn.Name = "CLIENTEEXENTODataGridViewTextBoxColumn"
        Me.CLIENTEEXENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CLIENTEEXENTODataGridViewTextBoxColumn.Visible = False
        '
        'PERSONAJURIDICADataGridViewTextBoxColumn
        '
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.DataPropertyName = "PERSONAJURIDICA"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.HeaderText = "PERSONAJURIDICA"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.Name = "PERSONAJURIDICADataGridViewTextBoxColumn"
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.ReadOnly = True
        Me.PERSONAJURIDICADataGridViewTextBoxColumn.Visible = False
        '
        'NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn
        '
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NUMPROVEEDORPARACLIENTE"
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn.HeaderText = "NUMPROVEEDORPARACLIENTE"
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn.Name = "NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn"
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'TIPOVENTADataGridViewTextBoxColumn
        '
        Me.TIPOVENTADataGridViewTextBoxColumn.DataPropertyName = "TIPOVENTA"
        Me.TIPOVENTADataGridViewTextBoxColumn.HeaderText = "TIPOVENTA"
        Me.TIPOVENTADataGridViewTextBoxColumn.Name = "TIPOVENTADataGridViewTextBoxColumn"
        Me.TIPOVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.TIPOVENTADataGridViewTextBoxColumn.Visible = False
        '
        'MATRIZDataGridViewTextBoxColumn
        '
        Me.MATRIZDataGridViewTextBoxColumn.DataPropertyName = "MATRIZ"
        Me.MATRIZDataGridViewTextBoxColumn.HeaderText = "MATRIZ"
        Me.MATRIZDataGridViewTextBoxColumn.Name = "MATRIZDataGridViewTextBoxColumn"
        Me.MATRIZDataGridViewTextBoxColumn.ReadOnly = True
        Me.MATRIZDataGridViewTextBoxColumn.Visible = False
        '
        'DVDataGridViewTextBoxColumn
        '
        Me.DVDataGridViewTextBoxColumn.DataPropertyName = "DV"
        Me.DVDataGridViewTextBoxColumn.HeaderText = "DV"
        Me.DVDataGridViewTextBoxColumn.Name = "DVDataGridViewTextBoxColumn"
        Me.DVDataGridViewTextBoxColumn.ReadOnly = True
        Me.DVDataGridViewTextBoxColumn.Visible = False
        '
        'CODDEPOSITO
        '
        Me.CODDEPOSITO.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITO.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITO.Name = "CODDEPOSITO"
        Me.CODDEPOSITO.ReadOnly = True
        Me.CODDEPOSITO.Visible = False
        '
        'MOTIVOANULADO
        '
        Me.MOTIVOANULADO.DataPropertyName = "MOTIVOANULADO"
        Me.MOTIVOANULADO.HeaderText = "MOTIVOANULADO"
        Me.MOTIVOANULADO.Name = "MOTIVOANULADO"
        Me.MOTIVOANULADO.ReadOnly = True
        Me.MOTIVOANULADO.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.pbxImprimir)
        Me.Panel1.Controls.Add(Me.pbxMostrarOBS)
        Me.Panel1.Controls.Add(Me.pbxClienteFinanzas)
        Me.Panel1.Controls.Add(Me.pbxDatosCliente)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 40)
        Me.Panel1.TabIndex = 454
        '
        'pbxImprimir
        '
        Me.pbxImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxImprimir.BackColor = System.Drawing.Color.Transparent
        Me.pbxImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxImprimir.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.pbxImprimir.Location = New System.Drawing.Point(680, 4)
        Me.pbxImprimir.Name = "pbxImprimir"
        Me.pbxImprimir.Size = New System.Drawing.Size(35, 33)
        Me.pbxImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxImprimir.TabIndex = 466
        Me.pbxImprimir.TabStop = False
        '
        'pbxMostrarOBS
        '
        Me.pbxMostrarOBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxMostrarOBS.BackColor = System.Drawing.Color.Transparent
        Me.pbxMostrarOBS.Image = Global.ContaExpress.My.Resources.Resources.Display
        Me.pbxMostrarOBS.Location = New System.Drawing.Point(718, 4)
        Me.pbxMostrarOBS.Name = "pbxMostrarOBS"
        Me.pbxMostrarOBS.Size = New System.Drawing.Size(35, 33)
        Me.pbxMostrarOBS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxMostrarOBS.TabIndex = 465
        Me.pbxMostrarOBS.TabStop = False
        '
        'pbxClienteFinanzas
        '
        Me.pbxClienteFinanzas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxClienteFinanzas.BackColor = System.Drawing.Color.Transparent
        Me.pbxClienteFinanzas.Image = Global.ContaExpress.My.Resources.Resources.Financial
        Me.pbxClienteFinanzas.Location = New System.Drawing.Point(755, 4)
        Me.pbxClienteFinanzas.Name = "pbxClienteFinanzas"
        Me.pbxClienteFinanzas.Size = New System.Drawing.Size(35, 33)
        Me.pbxClienteFinanzas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxClienteFinanzas.TabIndex = 458
        Me.pbxClienteFinanzas.TabStop = False
        Me.pbxClienteFinanzas.Visible = False
        '
        'pbxDatosCliente
        '
        Me.pbxDatosCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxDatosCliente.BackColor = System.Drawing.Color.Transparent
        Me.pbxDatosCliente.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.pbxDatosCliente.Location = New System.Drawing.Point(755, 4)
        Me.pbxDatosCliente.Name = "pbxDatosCliente"
        Me.pbxDatosCliente.Size = New System.Drawing.Size(35, 33)
        Me.pbxDatosCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDatosCliente.TabIndex = 458
        Me.pbxDatosCliente.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(3, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 454
        Me.PictureBox8.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(266, 4)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(231, 4)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(371, 4)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(301, 4)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(31, 5)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(193, 30)
        Me.BuscarTextBox.TabIndex = 16
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(336, 4)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'pnlObservacion
        '
        Me.pnlObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlObservacion.BackColor = System.Drawing.Color.LightGray
        Me.pnlObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlObservacion.Controls.Add(Me.RadLabel14)
        Me.pnlObservacion.Controls.Add(Me.RadLabel16)
        Me.pnlObservacion.Controls.Add(Me.btnCerrarOBS)
        Me.pnlObservacion.Controls.Add(Me.txtObservacion)
        Me.pnlObservacion.Location = New System.Drawing.Point(432, 40)
        Me.pnlObservacion.Name = "pnlObservacion"
        Me.pnlObservacion.Size = New System.Drawing.Size(359, 174)
        Me.pnlObservacion.TabIndex = 468
        Me.pnlObservacion.Visible = False
        '
        'RadLabel14
        '
        Me.RadLabel14.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel14.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.RadLabel14.ForeColor = System.Drawing.Color.Black
        Me.RadLabel14.Location = New System.Drawing.Point(8, 3)
        Me.RadLabel14.Name = "RadLabel14"
        '
        '
        '
        Me.RadLabel14.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel14.Size = New System.Drawing.Size(117, 31)
        Me.RadLabel14.TabIndex = 426
        Me.RadLabel14.Text = "Observación"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.Location = New System.Drawing.Point(9, 155)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.Size = New System.Drawing.Size(89, 16)
        Me.RadLabel16.TabIndex = 428
        Me.RadLabel16.Text = "ESC - Para Salir"
        '
        'btnCerrarOBS
        '
        Me.btnCerrarOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarOBS.Location = New System.Drawing.Point(287, 4)
        Me.btnCerrarOBS.Name = "btnCerrarOBS"
        Me.btnCerrarOBS.Size = New System.Drawing.Size(62, 26)
        Me.btnCerrarOBS.TabIndex = 427
        Me.btnCerrarOBS.Text = "Cerrar"
        '
        'txtObservacion
        '
        Me.txtObservacion.BackColor = System.Drawing.Color.White
        Me.txtObservacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "OBSERVACION", True))
        Me.txtObservacion.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtObservacion.Location = New System.Drawing.Point(8, 36)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        '
        '
        '
        Me.txtObservacion.RootElement.StretchVertically = True
        Me.txtObservacion.Size = New System.Drawing.Size(340, 116)
        Me.txtObservacion.TabIndex = 14
        Me.txtObservacion.TabStop = False
        Me.txtObservacion.ThemeName = "ControlDefault"
        CType(Me.txtObservacion.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).StretchVertically = True
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).StretchVertically = True
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(239, Byte), Integer))
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'txtNroCliente
        '
        Me.txtNroCliente.BackColor = System.Drawing.Color.White
        Me.txtNroCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NUMCLIENTE1", True))
        Me.txtNroCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtNroCliente.Location = New System.Drawing.Point(390, 105)
        Me.txtNroCliente.Name = "txtNroCliente"
        Me.txtNroCliente.Size = New System.Drawing.Size(319, 27)
        Me.txtNroCliente.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtNroCliente, "Elija un Numero para poder localizarlo con mayor rapidez, caso contrario se asign" & _
        "ara automaticamente")
        '
        'DataGridViewTextBoxColumn54
        '
        Me.DataGridViewTextBoxColumn54.DataPropertyName = "CODIGOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn54.HeaderText = "CODIGOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn54.Name = "DataGridViewTextBoxColumn54"
        '
        'DataGridViewTextBoxColumn55
        '
        Me.DataGridViewTextBoxColumn55.DataPropertyName = "CODVENTA"
        Me.DataGridViewTextBoxColumn55.HeaderText = "CODVENTA"
        Me.DataGridViewTextBoxColumn55.Name = "DataGridViewTextBoxColumn55"
        '
        'DataGridViewTextBoxColumn56
        '
        Me.DataGridViewTextBoxColumn56.DataPropertyName = "CODCLIENTE"
        Me.DataGridViewTextBoxColumn56.HeaderText = "CODCLIENTE"
        Me.DataGridViewTextBoxColumn56.Name = "DataGridViewTextBoxColumn56"
        '
        'DataGridViewTextBoxColumn57
        '
        Me.DataGridViewTextBoxColumn57.DataPropertyName = "NUMFACTURA"
        Me.DataGridViewTextBoxColumn57.HeaderText = "NUMFACTURA"
        Me.DataGridViewTextBoxColumn57.Name = "DataGridViewTextBoxColumn57"
        '
        'DataGridViewTextBoxColumn58
        '
        Me.DataGridViewTextBoxColumn58.DataPropertyName = "CONCEPTO"
        Me.DataGridViewTextBoxColumn58.HeaderText = "CONCEPTO"
        Me.DataGridViewTextBoxColumn58.Name = "DataGridViewTextBoxColumn58"
        '
        'DataGridViewTextBoxColumn59
        '
        Me.DataGridViewTextBoxColumn59.DataPropertyName = "CODEMPRESA"
        Me.DataGridViewTextBoxColumn59.HeaderText = "CODEMPRESA"
        Me.DataGridViewTextBoxColumn59.Name = "DataGridViewTextBoxColumn59"
        '
        'DataGridViewTextBoxColumn60
        '
        Me.DataGridViewTextBoxColumn60.DataPropertyName = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn60.HeaderText = "CODUSUARIO"
        Me.DataGridViewTextBoxColumn60.Name = "DataGridViewTextBoxColumn60"
        '
        'DataGridViewTextBoxColumn61
        '
        Me.DataGridViewTextBoxColumn61.DataPropertyName = "FECHA"
        Me.DataGridViewTextBoxColumn61.HeaderText = "FECHA"
        Me.DataGridViewTextBoxColumn61.Name = "DataGridViewTextBoxColumn61"
        '
        'DataGridViewTextBoxColumn62
        '
        Me.DataGridViewTextBoxColumn62.DataPropertyName = "IMPORTE"
        Me.DataGridViewTextBoxColumn62.HeaderText = "IMPORTE"
        Me.DataGridViewTextBoxColumn62.Name = "DataGridViewTextBoxColumn62"
        '
        'DataGridViewTextBoxColumn63
        '
        Me.DataGridViewTextBoxColumn63.DataPropertyName = "CODMONEDA"
        Me.DataGridViewTextBoxColumn63.HeaderText = "CODMONEDA"
        Me.DataGridViewTextBoxColumn63.Name = "DataGridViewTextBoxColumn63"
        '
        'DataGridViewTextBoxColumn64
        '
        Me.DataGridViewTextBoxColumn64.DataPropertyName = "COTIZACION1"
        Me.DataGridViewTextBoxColumn64.HeaderText = "COTIZACION1"
        Me.DataGridViewTextBoxColumn64.Name = "DataGridViewTextBoxColumn64"
        '
        'DataGridViewTextBoxColumn65
        '
        Me.DataGridViewTextBoxColumn65.DataPropertyName = "COTIZACION2"
        Me.DataGridViewTextBoxColumn65.HeaderText = "COTIZACION2"
        Me.DataGridViewTextBoxColumn65.Name = "DataGridViewTextBoxColumn65"
        '
        'DataGridViewTextBoxColumn66
        '
        Me.DataGridViewTextBoxColumn66.DataPropertyName = "DESTIPOVENTACOBRO"
        Me.DataGridViewTextBoxColumn66.HeaderText = "DESTIPOVENTACOBRO"
        Me.DataGridViewTextBoxColumn66.Name = "DataGridViewTextBoxColumn66"
        '
        'DataGridViewTextBoxColumn67
        '
        Me.DataGridViewTextBoxColumn67.DataPropertyName = "TIPOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn67.HeaderText = "TIPOMOVIMIENTO"
        Me.DataGridViewTextBoxColumn67.Name = "DataGridViewTextBoxColumn67"
        '
        'DataGridViewTextBoxColumn68
        '
        Me.DataGridViewTextBoxColumn68.DataPropertyName = "FORMACOBRO"
        Me.DataGridViewTextBoxColumn68.HeaderText = "FORMACOBRO"
        Me.DataGridViewTextBoxColumn68.Name = "DataGridViewTextBoxColumn68"
        '
        'DataGridViewTextBoxColumn69
        '
        Me.DataGridViewTextBoxColumn69.DataPropertyName = "NRO_CH_TAR"
        Me.DataGridViewTextBoxColumn69.HeaderText = "NRO_CH_TAR"
        Me.DataGridViewTextBoxColumn69.Name = "DataGridViewTextBoxColumn69"
        '
        'DataGridViewTextBoxColumn70
        '
        Me.DataGridViewTextBoxColumn70.DataPropertyName = "DESMONEDA"
        Me.DataGridViewTextBoxColumn70.HeaderText = "DESMONEDA"
        Me.DataGridViewTextBoxColumn70.Name = "DataGridViewTextBoxColumn70"
        '
        'CLIENTESRELACIONBindingSource
        '
        Me.CLIENTESRELACIONBindingSource.DataMember = "CLIENTESRELACION"
        Me.CLIENTESRELACIONBindingSource.DataSource = Me.DsCliente
        '
        'tbxCodCliente
        '
        Me.tbxCodCliente.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.tbxCodCliente.BackColor = System.Drawing.SystemColors.Menu
        Me.tbxCodCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "CODCLIENTE", True))
        Me.tbxCodCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCodCliente.Location = New System.Drawing.Point(140, 86)
        Me.tbxCodCliente.Name = "tbxCodCliente"
        Me.tbxCodCliente.Size = New System.Drawing.Size(50, 27)
        Me.tbxCodCliente.TabIndex = 458
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(344, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(100, 20)
        Me.Label14.TabIndex = 455
        Me.Label14.Text = "Saldo Deudor:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxVencimiento
        '
        Me.tbxVencimiento.BackColor = System.Drawing.Color.White
        Me.tbxVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxVencimiento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "DIASVENCIMIENTO", True))
        Me.tbxVencimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxVencimiento.Location = New System.Drawing.Point(175, 32)
        Me.tbxVencimiento.Name = "tbxVencimiento"
        Me.tbxVencimiento.Size = New System.Drawing.Size(69, 27)
        Me.tbxVencimiento.TabIndex = 0
        '
        'cbxTipoVenta
        '
        Me.cbxTipoVenta.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbxTipoVenta.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbxTipoVenta.BackColor = System.Drawing.Color.White
        Me.cbxTipoVenta.DisplayMember = "CODTIPOCLIENTE"
        Me.cbxTipoVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cbxTipoVenta.FormattingEnabled = True
        Me.cbxTipoVenta.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cbxTipoVenta.Location = New System.Drawing.Point(175, 98)
        Me.cbxTipoVenta.Name = "cbxTipoVenta"
        Me.cbxTipoVenta.Size = New System.Drawing.Size(268, 26)
        Me.cbxTipoVenta.TabIndex = 2
        Me.cbxTipoVenta.ValueMember = "CODTIPOCLIENTE"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(32, 40)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(141, 16)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Generar Cuotas Cada:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(62, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 16)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Limite de Crédito:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(76, 105)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 16)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Tipo de Venta:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(246, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 16)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "Días"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MOVIMIENTOCUENTACLIENTEBindingSource
        '
        Me.MOVIMIENTOCUENTACLIENTEBindingSource.DataMember = "MOVIMIENTOCUENTACLIENTE"
        Me.MOVIMIENTOCUENTACLIENTEBindingSource.DataSource = Me.DsCliente
        '
        'LblSaldo
        '
        Me.LblSaldo.AutoSize = True
        Me.LblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblSaldo.ForeColor = System.Drawing.Color.Maroon
        Me.LblSaldo.Location = New System.Drawing.Point(450, 142)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(99, 17)
        Me.LblSaldo.TabIndex = 456
        Me.LblSaldo.Text = "Saldo Actual"
        Me.LblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlFinanzas
        '
        Me.pnlFinanzas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlFinanzas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlFinanzas.BackColor = System.Drawing.Color.LightGray
        Me.pnlFinanzas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFinanzas.Controls.Add(Me.GridViewCuentaCliente)
        Me.pnlFinanzas.Controls.Add(Me.Label15)
        Me.pnlFinanzas.Controls.Add(Me.LblSaldo)
        Me.pnlFinanzas.Controls.Add(Me.Label13)
        Me.pnlFinanzas.Controls.Add(Me.Label17)
        Me.pnlFinanzas.Controls.Add(Me.Label20)
        Me.pnlFinanzas.Controls.Add(Me.Label21)
        Me.pnlFinanzas.Controls.Add(Me.cbxTipoVenta)
        Me.pnlFinanzas.Controls.Add(Me.tbxVencimiento)
        Me.pnlFinanzas.Controls.Add(Me.Label14)
        Me.pnlFinanzas.Controls.Add(Me.Label16)
        Me.pnlFinanzas.Controls.Add(Me.tbxLimiteCredito)
        Me.pnlFinanzas.Location = New System.Drawing.Point(229, 161)
        Me.pnlFinanzas.Name = "pnlFinanzas"
        Me.pnlFinanzas.Size = New System.Drawing.Size(562, 480)
        Me.pnlFinanzas.TabIndex = 3
        '
        'GridViewCuentaCliente
        '
        Me.GridViewCuentaCliente.AllowUserToAddRows = False
        Me.GridViewCuentaCliente.AllowUserToDeleteRows = False
        Me.GridViewCuentaCliente.AllowUserToResizeColumns = False
        Me.GridViewCuentaCliente.AllowUserToResizeRows = False
        Me.GridViewCuentaCliente.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCuentaCliente.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.GridViewCuentaCliente.ColumnHeadersHeight = 35
        Me.GridViewCuentaCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHA, Me.NROCOMPROBANTE, Me.TIPO, Me.TOTAL, Me.SALDO, Me.DESTIPOCOBRO, Me.NRORECIBO, Me.CODCOMP})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewCuentaCliente.DefaultCellStyle = DataGridViewCellStyle11
        Me.GridViewCuentaCliente.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GridViewCuentaCliente.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.GridViewCuentaCliente.Location = New System.Drawing.Point(0, 166)
        Me.GridViewCuentaCliente.MultiSelect = False
        Me.GridViewCuentaCliente.Name = "GridViewCuentaCliente"
        Me.GridViewCuentaCliente.ReadOnly = True
        Me.GridViewCuentaCliente.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewCuentaCliente.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.GridViewCuentaCliente.RowHeadersVisible = False
        Me.GridViewCuentaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewCuentaCliente.Size = New System.Drawing.Size(560, 312)
        Me.GridViewCuentaCliente.TabIndex = 468
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.FECHA.DefaultCellStyle = DataGridViewCellStyle5
        Me.FECHA.HeaderText = "Fecha"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Width = 75
        '
        'NROCOMPROBANTE
        '
        Me.NROCOMPROBANTE.DataPropertyName = "NROCOMPROBANTE"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NROCOMPROBANTE.DefaultCellStyle = DataGridViewCellStyle6
        Me.NROCOMPROBANTE.HeaderText = "Nro. Comprobante"
        Me.NROCOMPROBANTE.Name = "NROCOMPROBANTE"
        Me.NROCOMPROBANTE.ReadOnly = True
        '
        'TIPO
        '
        Me.TIPO.DataPropertyName = "TIPO"
        Me.TIPO.HeaderText = "Tipo"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.ReadOnly = True
        Me.TIPO.Width = 80
        '
        'TOTAL
        '
        Me.TOTAL.DataPropertyName = "TOTAL"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TOTAL.DefaultCellStyle = DataGridViewCellStyle7
        Me.TOTAL.HeaderText = "Total"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.ReadOnly = True
        '
        'SALDO
        '
        Me.SALDO.DataPropertyName = "SALDO"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.SALDO.DefaultCellStyle = DataGridViewCellStyle8
        Me.SALDO.HeaderText = "Saldo"
        Me.SALDO.Name = "SALDO"
        Me.SALDO.ReadOnly = True
        '
        'DESTIPOCOBRO
        '
        Me.DESTIPOCOBRO.DataPropertyName = "DESTIPOCOBRO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DESTIPOCOBRO.DefaultCellStyle = DataGridViewCellStyle9
        Me.DESTIPOCOBRO.HeaderText = "Tipo Cobro"
        Me.DESTIPOCOBRO.Name = "DESTIPOCOBRO"
        Me.DESTIPOCOBRO.ReadOnly = True
        '
        'NRORECIBO
        '
        Me.NRORECIBO.DataPropertyName = "NRORECIBO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NRORECIBO.DefaultCellStyle = DataGridViewCellStyle10
        Me.NRORECIBO.HeaderText = "Nro. Recibo"
        Me.NRORECIBO.Name = "NRORECIBO"
        Me.NRORECIBO.ReadOnly = True
        '
        'CODCOMP
        '
        Me.CODCOMP.DataPropertyName = "CODCOMP"
        Me.CODCOMP.HeaderText = "CODCOMP"
        Me.CODCOMP.Name = "CODCOMP"
        Me.CODCOMP.ReadOnly = True
        Me.CODCOMP.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label15.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label15.Location = New System.Drawing.Point(4, 1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 28)
        Me.Label15.TabIndex = 457
        Me.Label15.Text = "Finanzas"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label16.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label16.Location = New System.Drawing.Point(4, 133)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(153, 28)
        Me.Label16.TabIndex = 458
        Me.Label16.Text = "Historial de Pago"
        '
        'tbxLimiteCredito
        '
        Me.tbxLimiteCredito.AllowDrop = True
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.Name = "Microsoft Sans Serif"
        Appearance3.FontData.SizeInPoints = 13.0!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.tbxLimiteCredito.Appearance = Appearance3
        Me.tbxLimiteCredito.AutoSize = False
        Me.tbxLimiteCredito.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxLimiteCredito.CausesValidation = False
        Me.tbxLimiteCredito.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "LIMCREDITO", True))
        Me.tbxLimiteCredito.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxLimiteCredito.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxLimiteCredito.Location = New System.Drawing.Point(175, 65)
        Me.tbxLimiteCredito.Name = "tbxLimiteCredito"
        Me.tbxLimiteCredito.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxLimiteCredito.Size = New System.Drawing.Size(268, 27)
        Me.tbxLimiteCredito.TabIndex = 467
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1, Me.lblClienteEstado, Me.pbarClientes})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 646)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(797, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 14
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.DimGray
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(503, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'lblClienteEstado
        '
        Me.lblClienteEstado.BackColor = System.Drawing.Color.Transparent
        Me.lblClienteEstado.Name = "lblClienteEstado"
        Me.lblClienteEstado.Size = New System.Drawing.Size(120, 17)
        Me.lblClienteEstado.Text = "Clientes - Pos Express"
        '
        'pbarClientes
        '
        Me.pbarClientes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pbarClientes.Name = "pbarClientes"
        Me.pbarClientes.Size = New System.Drawing.Size(100, 16)
        Me.pbarClientes.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'CLIENTESFILTROBindingSource
        '
        Me.CLIENTESFILTROBindingSource.DataMember = "CLIENTESFILTRO"
        Me.CLIENTESFILTROBindingSource.DataSource = Me.DsCliente
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'TIPOCLIENTETableAdapter
        '
        Me.TIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'VENDEDORTableAdapter
        '
        Me.VENDEDORTableAdapter.ClearBeforeFill = True
        '
        'CIUDADTableAdapter
        '
        Me.CIUDADTableAdapter.ClearBeforeFill = True
        '
        'ZONATableAdapter
        '
        Me.ZONATableAdapter.ClearBeforeFill = True
        '
        'CATEGORIACLIENTETableAdapter
        '
        Me.CATEGORIACLIENTETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANCOTableAdapter = Nothing
        Me.TableAdapterManager.CATEGORIACLIENTETableAdapter = Me.CATEGORIACLIENTETableAdapter
        Me.TableAdapterManager.CIUDADTableAdapter = Me.CIUDADTableAdapter
        Me.TableAdapterManager.ClienteAdherenteTableAdapter = Nothing
        Me.TableAdapterManager.CLIENTESFILTROTableAdapter = Nothing
        Me.TableAdapterManager.CLIENTESRELACIONTableAdapter = Nothing
        Me.TableAdapterManager.CLIENTESTableAdapter = Me.CLIENTESTableAdapter
        Me.TableAdapterManager.CONTACTOSTableAdapter = Nothing
        Me.TableAdapterManager.PAISTableAdapter = Nothing
        Me.TableAdapterManager.PLANESTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCLIENTETableAdapter = Me.TIPOCLIENTETableAdapter
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsClienteTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VENDEDORTableAdapter = Me.VENDEDORTableAdapter
        Me.TableAdapterManager.ZONATableAdapter = Me.ZONATableAdapter
        '
        'MOVIMIENTOCUENTACLIENTETableAdapter
        '
        Me.MOVIMIENTOCUENTACLIENTETableAdapter.ClearBeforeFill = True
        '
        'CLIENTESRELACIONTableAdapter
        '
        Me.CLIENTESRELACIONTableAdapter.ClearBeforeFill = True
        '
        'CLIENTESFILTROTableAdapter
        '
        Me.CLIENTESFILTROTableAdapter.ClearBeforeFill = True
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsCliente
        '
        'PAISTableAdapter
        '
        Me.PAISTableAdapter.ClearBeforeFill = True
        '
        'DsRVFacturacion
        '
        Me.DsRVFacturacion.DataSetName = "DsRVFacturacion"
        Me.DsRVFacturacion.EnforceConstraints = False
        Me.DsRVFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RVMovimientosClienteBindingSource
        '
        Me.RVMovimientosClienteBindingSource.DataMember = "RVMovimientosCliente"
        Me.RVMovimientosClienteBindingSource.DataSource = Me.DsRVFacturacion
        '
        'RVMovimientosClienteTableAdapter
        '
        Me.RVMovimientosClienteTableAdapter.ClearBeforeFill = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.DimGray
        Me.Label12.Location = New System.Drawing.Point(306, 106)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 16)
        Me.Label12.TabIndex = 472
        Me.Label12.Text = "Nro Cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ClientesPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.Disable
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(797, 668)
        Me.Controls.Add(Me.pnlObservacion)
        Me.Controls.Add(Me.pnlDatosCliente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtNroCliente)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvClientes)
        Me.Controls.Add(Me.pbxLink)
        Me.Controls.Add(Me.tbxCodCliente)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.pnlFinanzas)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(785, 659)
        Me.Name = "ClientesPersonas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes Personas  | Cogent SIG"
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosCliente.ResumeLayout(False)
        Me.pnlDatosCliente.PerformLayout()
        CType(Me.pbxAgregarCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CATEGORIACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxMostrarOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxClienteFinanzas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDatosCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlObservacion.ResumeLayout(False)
        Me.pnlObservacion.PerformLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCerrarOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESRELACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MOVIMIENTOCUENTACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFinanzas.ResumeLayout(False)
        Me.pnlFinanzas.PerformLayout()
        CType(Me.GridViewCuentaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.CLIENTESFILTROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsRVFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RVMovimientosClienteBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCliente As ContaExpress.DsCliente
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsClienteTableAdapters.CLIENTESTableAdapter
    Friend WithEvents pnlDatosCliente As System.Windows.Forms.Panel
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents tbxRUC As System.Windows.Forms.TextBox
    Friend WithEvents tbxEmail As System.Windows.Forms.TextBox
    Friend WithEvents tbxCellular As System.Windows.Forms.TextBox
    Friend WithEvents tbxTel As System.Windows.Forms.TextBox
    Friend WithEvents pbxLink As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents TIPOCLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsClienteTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents VENDEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENDEDORTableAdapter As ContaExpress.DsClienteTableAdapters.VENDEDORTableAdapter
    Friend WithEvents cbxZona As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents CIUDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CIUDADTableAdapter As ContaExpress.DsClienteTableAdapters.CIUDADTableAdapter
    Friend WithEvents ZONABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZONATableAdapter As ContaExpress.DsClienteTableAdapters.ZONATableAdapter
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents dgvClientes As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NOMBREDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNroCliente As System.Windows.Forms.TextBox
    Friend WithEvents CATEGORIACLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CATEGORIACLIENTETableAdapter As ContaExpress.DsClienteTableAdapters.CATEGORIACLIENTETableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsClienteTableAdapters.TableAdapterManager
    Friend WithEvents DataGridViewTextBoxColumn54 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn55 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn56 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn57 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn58 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn59 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn60 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn61 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn62 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn63 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn64 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn65 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn66 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn67 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn68 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn69 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn70 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClienteOP As System.Windows.Forms.Label
    Friend WithEvents MOVIMIENTOCUENTACLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MOVIMIENTOCUENTACLIENTETableAdapter As ContaExpress.DsClienteTableAdapters.MOVIMIENTOCUENTACLIENTETableAdapter
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tbxCodCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblRuc As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbxVencimiento As System.Windows.Forms.TextBox
    Friend WithEvents cbxTipoVenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents pnlFinanzas As System.Windows.Forms.Panel
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents pbarClientes As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblClienteEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbxLimiteCredito As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents CLIENTESRELACIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESRELACIONTableAdapter As ContaExpress.DsClienteTableAdapters.CLIENTESRELACIONTableAdapter
    Friend WithEvents txtNombreClienteR As System.Windows.Forms.TextBox
    Friend WithEvents txtIdClienteR As System.Windows.Forms.TextBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents CLIENTESFILTROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESFILTROTableAdapter As ContaExpress.DsClienteTableAdapters.CLIENTESFILTROTableAdapter
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.DsClienteTableAdapters.PAISTableAdapter
    Friend WithEvents pnlObservacion As System.Windows.Forms.Panel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnCerrarOBS As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtObservacion As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents NUMCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbSexo As System.Windows.Forms.ComboBox
    Friend WithEvents TIPORELACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RELACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMFIELD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODZONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCOBRADORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENDEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCEDULADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CELULARDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAXDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WEBDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LIMCREDITODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINGRESODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORCENTAJEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIASVENCIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONDICIONVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRENVIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOCOMISIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMEROTOLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHANACIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTORIZADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECAUTORIZACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCATEGORIACLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEPRINCIPALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMAGENCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPAISDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMPPRESACLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMBRADOFACTURADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMBRADORETENCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEXODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROVEEDORIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENTEEXENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERSONAJURIDICADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPROVEEDORPARACLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MATRIZDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTIVOANULADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbxAgregarCiudad As System.Windows.Forms.PictureBox
    Friend WithEvents pbxMostrarOBS As System.Windows.Forms.PictureBox
    Friend WithEvents pbxClienteFinanzas As System.Windows.Forms.PictureBox
    Friend WithEvents pbxDatosCliente As System.Windows.Forms.PictureBox
    Friend WithEvents RVMovimientosClienteBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsRVFacturacion As ContaExpress.DsRVFacturacion
    Friend WithEvents RVMovimientosClienteTableAdapter As ContaExpress.DsRVFacturacionTableAdapters.RVMovimientosClienteTableAdapter
    Friend WithEvents GridViewCuentaCliente As System.Windows.Forms.DataGridView
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROCOMPROBANTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCOBRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NRORECIBO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCOMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbledad As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pbxImprimir As System.Windows.Forms.PictureBox
End Class
