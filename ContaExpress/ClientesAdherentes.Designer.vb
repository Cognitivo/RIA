<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClientesAdherentes
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
        Dim NUMCLIENTELabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientesAdherentes))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgwClientes = New System.Windows.Forms.DataGridView()
        Me.NUMCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTORIZADOCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsClientesAdherentes = New ContaExpress.dsClientesAdherentes()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.pbxRefresh = New System.Windows.Forms.Button()
        Me.pnlDatosCliente = New System.Windows.Forms.Panel()
        Me.pnlBaja = New System.Windows.Forms.Panel()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.dtpFechaBaja = New System.Windows.Forms.DateTimePicker()
        Me.pnlObservacion = New System.Windows.Forms.Panel()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.btnCerrarOBS = New Telerik.WinControls.UI.RadButton()
        Me.txtObservacion = New Telerik.WinControls.UI.RadTextBox()
        Me.cbxSexoAdherente = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.pbxPlanes = New System.Windows.Forms.PictureBox()
        Me.pbxBanco = New System.Windows.Forms.PictureBox()
        Me.pbxVendedor = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbxTotalMontoCuota = New System.Windows.Forms.TextBox()
        Me.btnAgregarAdh = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbxMontoAdherente = New System.Windows.Forms.TextBox()
        Me.tbxParentesco = New System.Windows.Forms.TextBox()
        Me.dtpFechaNacAdhe = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtRucAdherente = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dgwAdherentes = New System.Windows.Forms.DataGridView()
        Me.CODCLIENTEDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINGRESODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHANACIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DVDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSTOMFIELDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LIMCREDITODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SEXO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTORIZADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoGrilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ADHERENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbxSeccion = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbxEmpresa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbxTelEmpresa = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbxDirEmpresa = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxBanco = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxNroTarjeta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxTelefono = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.tbxDireccion = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbxMonto = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cbxPlan = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbxVendedor = New System.Windows.Forms.ComboBox()
        Me.VENDEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pbxNacionalidad = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbxEdad = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpFechaNac = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbxRuc = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.LblInfoDV = New Telerik.WinControls.UI.RadLabel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cbxNacionalidad = New System.Windows.Forms.ComboBox()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxCliente = New System.Windows.Forms.TextBox()
        Me.lblRelacionado = New System.Windows.Forms.Label()
        Me.tbxNroRegistro = New System.Windows.Forms.TextBox()
        Me.tbxAdherentes = New System.Windows.Forms.TextBox()
        Me.cbxSexo = New System.Windows.Forms.ComboBox()
        Me.pnlimprimirCarnet = New System.Windows.Forms.Panel()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chbTodos = New System.Windows.Forms.CheckBox()
        Me.btnCerrarImprimir = New System.Windows.Forms.Button()
        Me.btImprimirMultiples = New System.Windows.Forms.Button()
        Me.dgwClientesCarnet = New System.Windows.Forms.DataGridView()
        Me.CODCLIENTEDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FILLCLIENTESCARNETBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxMostrarOBS = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxImprimir = New System.Windows.Forms.PictureBox()
        Me.PictureBoxActivo = New System.Windows.Forms.PictureBox()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.CLIENTESTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.CLIENTESTableAdapter()
        Me.VENDEDORTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.VENDEDORTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.PRODUCTOSTableAdapter()
        Me.CAJATableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.CAJATableAdapter()
        Me.PAISTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.PAISTableAdapter()
        Me.ADHERENTESTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.ADHERENTESTableAdapter()
        Me.CarnetTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.CARNETTableAdapter()
        Me.FILLCLIENTESCARNETTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.FILLCLIENTESCARNETTableAdapter()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsVentasPlus = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsNuevo = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsEditar = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmImprimirCarnet = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmsImprimirMultiples = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsVer = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsCampoDeObservacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarComentarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidaciónSemanalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlReporteLiquidacion = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cbxVendedorInforme = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.btnCerrarInforme = New System.Windows.Forms.Button()
        Me.btnVerInforme = New System.Windows.Forms.Button()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.LiquidacionsemanalTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.LIQUIDACIONSEMANALTableAdapter()
        Me.VentascaidasliquidacionTableAdapter = New ContaExpress.dsClientesAdherentesTableAdapters.VENTASCAIDASLIQUIDACIONTableAdapter()
        NUMCLIENTELabel = New System.Windows.Forms.Label()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgwClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsClientesAdherentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosCliente.SuspendLayout()
        Me.pnlBaja.SuspendLayout()
        Me.pnlObservacion.SuspendLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCerrarOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPlanes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwAdherentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ADHERENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblInfoDV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlimprimirCarnet.SuspendLayout()
        CType(Me.dgwClientesCarnet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FILLCLIENTESCARNETBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxMostrarOBS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlReporteLiquidacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'NUMCLIENTELabel
        '
        NUMCLIENTELabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        NUMCLIENTELabel.AutoSize = True
        NUMCLIENTELabel.Font = New System.Drawing.Font("Arial", 8.25!)
        NUMCLIENTELabel.Location = New System.Drawing.Point(8, 611)
        NUMCLIENTELabel.Name = "NUMCLIENTELabel"
        NUMCLIENTELabel.Size = New System.Drawing.Size(407, 14)
        NUMCLIENTELabel.TabIndex = 547
        NUMCLIENTELabel.Text = "Para indicar que un Adherente ya uso el servicio presione la Tecla SUPR o DELETE." & _
    ""
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgwClientes)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.pbxRefresh)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDatosCliente)
        Me.SplitContainer1.Size = New System.Drawing.Size(1022, 675)
        Me.SplitContainer1.SplitterDistance = 248
        Me.SplitContainer1.TabIndex = 0
        '
        'dgwClientes
        '
        Me.dgwClientes.AllowUserToAddRows = False
        Me.dgwClientes.AllowUserToDeleteRows = False
        Me.dgwClientes.AllowUserToOrderColumns = True
        Me.dgwClientes.AllowUserToResizeColumns = False
        Me.dgwClientes.AllowUserToResizeRows = False
        Me.dgwClientes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwClientes.AutoGenerateColumns = False
        Me.dgwClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwClientes.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwClientes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwClientes.ColumnHeadersHeight = 35
        Me.dgwClientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMCLIENTEDataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn, Me.colSexo, Me.CODCLIENTEDataGridViewTextBoxColumn, Me.AUTORIZADOCLIENTE})
        Me.dgwClientes.DataSource = Me.CLIENTESBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwClientes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgwClientes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwClientes.Location = New System.Drawing.Point(0, 63)
        Me.dgwClientes.MultiSelect = False
        Me.dgwClientes.Name = "dgwClientes"
        Me.dgwClientes.ReadOnly = True
        Me.dgwClientes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwClientes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwClientes.RowHeadersVisible = False
        Me.dgwClientes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwClientes.Size = New System.Drawing.Size(248, 609)
        Me.dgwClientes.TabIndex = 458
        '
        'NUMCLIENTEDataGridViewTextBoxColumn
        '
        Me.NUMCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NUMCLIENTE"
        Me.NUMCLIENTEDataGridViewTextBoxColumn.FillWeight = 70.0!
        Me.NUMCLIENTEDataGridViewTextBoxColumn.HeaderText = "Nro Registro"
        Me.NUMCLIENTEDataGridViewTextBoxColumn.Name = "NUMCLIENTEDataGridViewTextBoxColumn"
        Me.NUMCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.FillWeight = 130.0!
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
        '
        'colSexo
        '
        Me.colSexo.DataPropertyName = "SEXO"
        Me.colSexo.HeaderText = "SEXO"
        Me.colSexo.Name = "colSexo"
        Me.colSexo.ReadOnly = True
        Me.colSexo.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'AUTORIZADOCLIENTE
        '
        Me.AUTORIZADOCLIENTE.DataPropertyName = "AUTORIZADO"
        Me.AUTORIZADOCLIENTE.HeaderText = "AUTORIZADO"
        Me.AUTORIZADOCLIENTE.Name = "AUTORIZADOCLIENTE"
        Me.AUTORIZADOCLIENTE.ReadOnly = True
        Me.AUTORIZADOCLIENTE.Visible = False
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'DsClientesAdherentes
        '
        Me.DsClientesAdherentes.DataSetName = "dsClientesAdherentes"
        Me.DsClientesAdherentes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(34, 0)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(213, 35)
        Me.BuscarTextBox.TabIndex = 455
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox8.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(35, 35)
        Me.PictureBox8.TabIndex = 457
        Me.PictureBox8.TabStop = False
        '
        'pbxRefresh
        '
        Me.pbxRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxRefresh.BackColor = System.Drawing.Color.RoyalBlue
        Me.pbxRefresh.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.pbxRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.pbxRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.pbxRefresh.ForeColor = System.Drawing.Color.White
        Me.pbxRefresh.Image = Global.ContaExpress.My.Resources.Resources.Reload1
        Me.pbxRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.pbxRefresh.Location = New System.Drawing.Point(-3, 34)
        Me.pbxRefresh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbxRefresh.Name = "pbxRefresh"
        Me.pbxRefresh.Size = New System.Drawing.Size(253, 31)
        Me.pbxRefresh.TabIndex = 465
        Me.pbxRefresh.Text = "REFRESH"
        Me.pbxRefresh.UseVisualStyleBackColor = False
        '
        'pnlDatosCliente
        '
        Me.pnlDatosCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlDatosCliente.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDatosCliente.BackColor = System.Drawing.Color.LightGray
        Me.pnlDatosCliente.Controls.Add(Me.pnlimprimirCarnet)
        Me.pnlDatosCliente.Controls.Add(Me.pnlBaja)
        Me.pnlDatosCliente.Controls.Add(Me.pnlObservacion)
        Me.pnlDatosCliente.Controls.Add(Me.cbxSexoAdherente)
        Me.pnlDatosCliente.Controls.Add(Me.Label36)
        Me.pnlDatosCliente.Controls.Add(Me.Label35)
        Me.pnlDatosCliente.Controls.Add(NUMCLIENTELabel)
        Me.pnlDatosCliente.Controls.Add(Me.pbxPlanes)
        Me.pnlDatosCliente.Controls.Add(Me.pbxBanco)
        Me.pnlDatosCliente.Controls.Add(Me.pbxVendedor)
        Me.pnlDatosCliente.Controls.Add(Me.Label25)
        Me.pnlDatosCliente.Controls.Add(Me.tbxTotalMontoCuota)
        Me.pnlDatosCliente.Controls.Add(Me.btnAgregarAdh)
        Me.pnlDatosCliente.Controls.Add(Me.Label24)
        Me.pnlDatosCliente.Controls.Add(Me.Label23)
        Me.pnlDatosCliente.Controls.Add(Me.Label22)
        Me.pnlDatosCliente.Controls.Add(Me.tbxMontoAdherente)
        Me.pnlDatosCliente.Controls.Add(Me.tbxParentesco)
        Me.pnlDatosCliente.Controls.Add(Me.dtpFechaNacAdhe)
        Me.pnlDatosCliente.Controls.Add(Me.Label21)
        Me.pnlDatosCliente.Controls.Add(Me.txtRucAdherente)
        Me.pnlDatosCliente.Controls.Add(Me.Label20)
        Me.pnlDatosCliente.Controls.Add(Me.dgwAdherentes)
        Me.pnlDatosCliente.Controls.Add(Me.Label11)
        Me.pnlDatosCliente.Controls.Add(Me.Label8)
        Me.pnlDatosCliente.Controls.Add(Me.tbxSeccion)
        Me.pnlDatosCliente.Controls.Add(Me.Label10)
        Me.pnlDatosCliente.Controls.Add(Me.tbxEmpresa)
        Me.pnlDatosCliente.Controls.Add(Me.Label5)
        Me.pnlDatosCliente.Controls.Add(Me.tbxTelEmpresa)
        Me.pnlDatosCliente.Controls.Add(Me.Label7)
        Me.pnlDatosCliente.Controls.Add(Me.tbxDirEmpresa)
        Me.pnlDatosCliente.Controls.Add(Me.Label4)
        Me.pnlDatosCliente.Controls.Add(Me.cbxBanco)
        Me.pnlDatosCliente.Controls.Add(Me.Label3)
        Me.pnlDatosCliente.Controls.Add(Me.tbxNroTarjeta)
        Me.pnlDatosCliente.Controls.Add(Me.Label1)
        Me.pnlDatosCliente.Controls.Add(Me.tbxTelefono)
        Me.pnlDatosCliente.Controls.Add(Me.Label19)
        Me.pnlDatosCliente.Controls.Add(Me.tbxDireccion)
        Me.pnlDatosCliente.Controls.Add(Me.Label17)
        Me.pnlDatosCliente.Controls.Add(Me.tbxMonto)
        Me.pnlDatosCliente.Controls.Add(Me.Label16)
        Me.pnlDatosCliente.Controls.Add(Me.cbxPlan)
        Me.pnlDatosCliente.Controls.Add(Me.Label15)
        Me.pnlDatosCliente.Controls.Add(Me.cbxVendedor)
        Me.pnlDatosCliente.Controls.Add(Me.pbxNacionalidad)
        Me.pnlDatosCliente.Controls.Add(Me.Label14)
        Me.pnlDatosCliente.Controls.Add(Me.Label13)
        Me.pnlDatosCliente.Controls.Add(Me.tbxEdad)
        Me.pnlDatosCliente.Controls.Add(Me.Label12)
        Me.pnlDatosCliente.Controls.Add(Me.dtpFechaNac)
        Me.pnlDatosCliente.Controls.Add(Me.Label9)
        Me.pnlDatosCliente.Controls.Add(Me.tbxRuc)
        Me.pnlDatosCliente.Controls.Add(Me.Label6)
        Me.pnlDatosCliente.Controls.Add(Me.dtpFechaInicio)
        Me.pnlDatosCliente.Controls.Add(Me.LblInfoDV)
        Me.pnlDatosCliente.Controls.Add(Me.Label18)
        Me.pnlDatosCliente.Controls.Add(Me.cbxNacionalidad)
        Me.pnlDatosCliente.Controls.Add(Me.Label2)
        Me.pnlDatosCliente.Controls.Add(Me.tbxCliente)
        Me.pnlDatosCliente.Controls.Add(Me.lblRelacionado)
        Me.pnlDatosCliente.Controls.Add(Me.tbxNroRegistro)
        Me.pnlDatosCliente.Controls.Add(Me.tbxAdherentes)
        Me.pnlDatosCliente.Controls.Add(Me.cbxSexo)
        Me.pnlDatosCliente.Location = New System.Drawing.Point(0, 33)
        Me.pnlDatosCliente.Name = "pnlDatosCliente"
        Me.pnlDatosCliente.Size = New System.Drawing.Size(771, 642)
        Me.pnlDatosCliente.TabIndex = 457
        '
        'pnlBaja
        '
        Me.pnlBaja.BackColor = System.Drawing.Color.Maroon
        Me.pnlBaja.Controls.Add(Me.txtComentario)
        Me.pnlBaja.Controls.Add(Me.Label27)
        Me.pnlBaja.Controls.Add(Me.Label26)
        Me.pnlBaja.Controls.Add(Me.dtpFechaBaja)
        Me.pnlBaja.Location = New System.Drawing.Point(520, 5)
        Me.pnlBaja.Name = "pnlBaja"
        Me.pnlBaja.Size = New System.Drawing.Size(243, 242)
        Me.pnlBaja.TabIndex = 548
        Me.pnlBaja.Visible = False
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "OBSERVACION", True))
        Me.txtComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtComentario.Location = New System.Drawing.Point(8, 97)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(227, 133)
        Me.txtComentario.TabIndex = 468
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(7, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(48, 16)
        Me.Label27.TabIndex = 467
        Me.Label27.Text = "Motivo"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label26.ForeColor = System.Drawing.Color.White
        Me.Label26.Location = New System.Drawing.Point(5, 10)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(94, 16)
        Me.Label26.TabIndex = 466
        Me.Label26.Text = "Fecha  de Alta"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaBaja
        '
        Me.dtpFechaBaja.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaBaja.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CLIENTESBindingSource, "FECAUTORIZACION", True))
        Me.dtpFechaBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBaja.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBaja.Location = New System.Drawing.Point(5, 32)
        Me.dtpFechaBaja.Name = "dtpFechaBaja"
        Me.dtpFechaBaja.Size = New System.Drawing.Size(230, 27)
        Me.dtpFechaBaja.TabIndex = 465
        Me.dtpFechaBaja.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'pnlObservacion
        '
        Me.pnlObservacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlObservacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.pnlObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlObservacion.Controls.Add(Me.RadLabel14)
        Me.pnlObservacion.Controls.Add(Me.RadLabel16)
        Me.pnlObservacion.Controls.Add(Me.btnCerrarOBS)
        Me.pnlObservacion.Controls.Add(Me.txtObservacion)
        Me.pnlObservacion.Location = New System.Drawing.Point(405, 5)
        Me.pnlObservacion.Name = "pnlObservacion"
        Me.pnlObservacion.Size = New System.Drawing.Size(359, 175)
        Me.pnlObservacion.TabIndex = 551
        Me.pnlObservacion.Visible = False
        '
        'RadLabel14
        '
        Me.RadLabel14.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel14.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.RadLabel14.ForeColor = System.Drawing.Color.White
        Me.RadLabel14.Location = New System.Drawing.Point(8, 1)
        Me.RadLabel14.Name = "RadLabel14"
        '
        '
        '
        Me.RadLabel14.RootElement.ForeColor = System.Drawing.Color.White
        Me.RadLabel14.Size = New System.Drawing.Size(117, 31)
        Me.RadLabel14.TabIndex = 426
        Me.RadLabel14.Text = "Observación"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.ForeColor = System.Drawing.Color.White
        Me.RadLabel16.Location = New System.Drawing.Point(9, 154)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.White
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
        Me.txtObservacion.Location = New System.Drawing.Point(8, 34)
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
        CType(Me.txtObservacion.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.White
        '
        'cbxSexoAdherente
        '
        Me.cbxSexoAdherente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxSexoAdherente.CausesValidation = False
        Me.cbxSexoAdherente.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "CODVENDEDOR", True))
        Me.cbxSexoAdherente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSexoAdherente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSexoAdherente.FormattingEnabled = True
        Me.cbxSexoAdherente.Location = New System.Drawing.Point(656, 382)
        Me.cbxSexoAdherente.Name = "cbxSexoAdherente"
        Me.cbxSexoAdherente.Size = New System.Drawing.Size(47, 28)
        Me.cbxSexoAdherente.TabIndex = 551
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label36.ForeColor = System.Drawing.Color.Black
        Me.Label36.Location = New System.Drawing.Point(656, 361)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(39, 16)
        Me.Label36.TabIndex = 553
        Me.Label36.Text = "Sexo"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label35.ForeColor = System.Drawing.Color.Black
        Me.Label35.Location = New System.Drawing.Point(57, 185)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(42, 16)
        Me.Label35.TabIndex = 551
        Me.Label35.Text = "Sexo:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbxPlanes
        '
        Me.pbxPlanes.BackColor = System.Drawing.Color.Transparent
        Me.pbxPlanes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxPlanes.Image = CType(resources.GetObject("pbxPlanes.Image"), System.Drawing.Image)
        Me.pbxPlanes.Location = New System.Drawing.Point(571, 181)
        Me.pbxPlanes.Name = "pbxPlanes"
        Me.pbxPlanes.Size = New System.Drawing.Size(26, 26)
        Me.pbxPlanes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPlanes.TabIndex = 546
        Me.pbxPlanes.TabStop = False
        '
        'pbxBanco
        '
        Me.pbxBanco.BackColor = System.Drawing.Color.Transparent
        Me.pbxBanco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxBanco.Image = CType(resources.GetObject("pbxBanco.Image"), System.Drawing.Image)
        Me.pbxBanco.Location = New System.Drawing.Point(732, 214)
        Me.pbxBanco.Name = "pbxBanco"
        Me.pbxBanco.Size = New System.Drawing.Size(26, 26)
        Me.pbxBanco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxBanco.TabIndex = 545
        Me.pbxBanco.TabStop = False
        '
        'pbxVendedor
        '
        Me.pbxVendedor.BackColor = System.Drawing.Color.Transparent
        Me.pbxVendedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxVendedor.Image = CType(resources.GetObject("pbxVendedor.Image"), System.Drawing.Image)
        Me.pbxVendedor.Location = New System.Drawing.Point(255, 214)
        Me.pbxVendedor.Name = "pbxVendedor"
        Me.pbxVendedor.Size = New System.Drawing.Size(26, 26)
        Me.pbxVendedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxVendedor.TabIndex = 544
        Me.pbxVendedor.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Enabled = False
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(511, 611)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 16)
        Me.Label25.TabIndex = 543
        Me.Label25.Text = "Total Cuota :"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxTotalMontoCuota
        '
        Me.tbxTotalMontoCuota.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxTotalMontoCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTotalMontoCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.tbxTotalMontoCuota.Location = New System.Drawing.Point(599, 604)
        Me.tbxTotalMontoCuota.Name = "tbxTotalMontoCuota"
        Me.tbxTotalMontoCuota.ReadOnly = True
        Me.tbxTotalMontoCuota.Size = New System.Drawing.Size(164, 32)
        Me.tbxTotalMontoCuota.TabIndex = 542
        Me.tbxTotalMontoCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAgregarAdh
        '
        Me.btnAgregarAdh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregarAdh.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnAgregarAdh.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnAgregarAdh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarAdh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnAgregarAdh.Location = New System.Drawing.Point(704, 382)
        Me.btnAgregarAdh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnAgregarAdh.Name = "btnAgregarAdh"
        Me.btnAgregarAdh.Size = New System.Drawing.Size(60, 29)
        Me.btnAgregarAdh.TabIndex = 22
        Me.btnAgregarAdh.Text = "Agregar"
        Me.btnAgregarAdh.UseVisualStyleBackColor = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label24.ForeColor = System.Drawing.Color.Black
        Me.Label24.Location = New System.Drawing.Point(571, 362)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(45, 16)
        Me.Label24.TabIndex = 511
        Me.Label24.Text = "Monto"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(490, 362)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 16)
        Me.Label23.TabIndex = 510
        Me.Label23.Text = "Parentesco"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(385, 362)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 16)
        Me.Label22.TabIndex = 509
        Me.Label22.Text = "Fecha Nac"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMontoAdherente
        '
        Me.tbxMontoAdherente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxMontoAdherente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMontoAdherente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxMontoAdherente.Location = New System.Drawing.Point(570, 383)
        Me.tbxMontoAdherente.Name = "tbxMontoAdherente"
        Me.tbxMontoAdherente.Size = New System.Drawing.Size(83, 27)
        Me.tbxMontoAdherente.TabIndex = 21
        '
        'tbxParentesco
        '
        Me.tbxParentesco.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxParentesco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxParentesco.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxParentesco.Location = New System.Drawing.Point(490, 383)
        Me.tbxParentesco.Name = "tbxParentesco"
        Me.tbxParentesco.Size = New System.Drawing.Size(78, 27)
        Me.tbxParentesco.TabIndex = 20
        '
        'dtpFechaNacAdhe
        '
        Me.dtpFechaNacAdhe.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNacAdhe.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaNacAdhe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNacAdhe.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNacAdhe.Location = New System.Drawing.Point(385, 383)
        Me.dtpFechaNacAdhe.Name = "dtpFechaNacAdhe"
        Me.dtpFechaNacAdhe.Size = New System.Drawing.Size(103, 27)
        Me.dtpFechaNacAdhe.TabIndex = 19
        Me.dtpFechaNacAdhe.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label21.ForeColor = System.Drawing.Color.Black
        Me.Label21.Location = New System.Drawing.Point(276, 362)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 16)
        Me.Label21.TabIndex = 505
        Me.Label21.Text = "R.U.C/C.I :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRucAdherente
        '
        Me.txtRucAdherente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtRucAdherente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRucAdherente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtRucAdherente.Location = New System.Drawing.Point(276, 383)
        Me.txtRucAdherente.Name = "txtRucAdherente"
        Me.txtRucAdherente.Size = New System.Drawing.Size(105, 27)
        Me.txtRucAdherente.TabIndex = 18
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(8, 362)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 16)
        Me.Label20.TabIndex = 503
        Me.Label20.Text = "Adherente"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgwAdherentes
        '
        Me.dgwAdherentes.AllowUserToAddRows = False
        Me.dgwAdherentes.AllowUserToDeleteRows = False
        Me.dgwAdherentes.AllowUserToOrderColumns = True
        Me.dgwAdherentes.AllowUserToResizeColumns = False
        Me.dgwAdherentes.AllowUserToResizeRows = False
        Me.dgwAdherentes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwAdherentes.AutoGenerateColumns = False
        Me.dgwAdherentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwAdherentes.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwAdherentes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgwAdherentes.ColumnHeadersHeight = 35
        Me.dgwAdherentes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCLIENTEDataGridViewTextBoxColumn1, Me.FECHAINGRESODataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn1, Me.RUCDataGridViewTextBoxColumn, Me.FECHANACIMIENTODataGridViewTextBoxColumn, Me.DVDataGridViewTextBoxColumn, Me.CUSTOMFIELDDataGridViewTextBoxColumn, Me.LIMCREDITODataGridViewTextBoxColumn, Me.SEXO, Me.FECAUTORIZACIONDataGridViewTextBoxColumn, Me.AUTORIZADO, Me.EstadoGrilla})
        Me.dgwAdherentes.DataSource = Me.ADHERENTESBindingSource
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwAdherentes.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgwAdherentes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwAdherentes.Location = New System.Drawing.Point(8, 415)
        Me.dgwAdherentes.MultiSelect = False
        Me.dgwAdherentes.Name = "dgwAdherentes"
        Me.dgwAdherentes.ReadOnly = True
        Me.dgwAdherentes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwAdherentes.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgwAdherentes.RowHeadersVisible = False
        Me.dgwAdherentes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwAdherentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwAdherentes.Size = New System.Drawing.Size(755, 186)
        Me.dgwAdherentes.TabIndex = 501
        '
        'CODCLIENTEDataGridViewTextBoxColumn1
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn1.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.Name = "CODCLIENTEDataGridViewTextBoxColumn1"
        Me.CODCLIENTEDataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn1.Visible = False
        '
        'FECHAINGRESODataGridViewTextBoxColumn
        '
        Me.FECHAINGRESODataGridViewTextBoxColumn.DataPropertyName = "FECHAINGRESO"
        DataGridViewCellStyle8.Format = "d"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.FECHAINGRESODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.FECHAINGRESODataGridViewTextBoxColumn.FillWeight = 87.95172!
        Me.FECHAINGRESODataGridViewTextBoxColumn.HeaderText = "Fecha Ingreso"
        Me.FECHAINGRESODataGridViewTextBoxColumn.Name = "FECHAINGRESODataGridViewTextBoxColumn"
        Me.FECHAINGRESODataGridViewTextBoxColumn.ReadOnly = True
        '
        'NOMBREDataGridViewTextBoxColumn1
        '
        Me.NOMBREDataGridViewTextBoxColumn1.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn1.FillWeight = 175.9034!
        Me.NOMBREDataGridViewTextBoxColumn1.HeaderText = "Adherentes"
        Me.NOMBREDataGridViewTextBoxColumn1.Name = "NOMBREDataGridViewTextBoxColumn1"
        Me.NOMBREDataGridViewTextBoxColumn1.ReadOnly = True
        '
        'RUCDataGridViewTextBoxColumn
        '
        Me.RUCDataGridViewTextBoxColumn.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn.FillWeight = 82.7781!
        Me.RUCDataGridViewTextBoxColumn.HeaderText = "RUC/CI"
        Me.RUCDataGridViewTextBoxColumn.Name = "RUCDataGridViewTextBoxColumn"
        Me.RUCDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHANACIMIENTODataGridViewTextBoxColumn
        '
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.DataPropertyName = "FECHANACIMIENTO"
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle9
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.FillWeight = 87.95172!
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.HeaderText = "Fecha Nac"
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.Name = "FECHANACIMIENTODataGridViewTextBoxColumn"
        Me.FECHANACIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DVDataGridViewTextBoxColumn
        '
        Me.DVDataGridViewTextBoxColumn.DataPropertyName = "DV"
        Me.DVDataGridViewTextBoxColumn.FillWeight = 62.08357!
        Me.DVDataGridViewTextBoxColumn.HeaderText = "Edad"
        Me.DVDataGridViewTextBoxColumn.Name = "DVDataGridViewTextBoxColumn"
        Me.DVDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CUSTOMFIELDDataGridViewTextBoxColumn
        '
        Me.CUSTOMFIELDDataGridViewTextBoxColumn.DataPropertyName = "CUSTOMFIELD"
        Me.CUSTOMFIELDDataGridViewTextBoxColumn.FillWeight = 103.4726!
        Me.CUSTOMFIELDDataGridViewTextBoxColumn.HeaderText = "Parentesco"
        Me.CUSTOMFIELDDataGridViewTextBoxColumn.Name = "CUSTOMFIELDDataGridViewTextBoxColumn"
        Me.CUSTOMFIELDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LIMCREDITODataGridViewTextBoxColumn
        '
        Me.LIMCREDITODataGridViewTextBoxColumn.DataPropertyName = "LIMCREDITO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.LIMCREDITODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle10
        Me.LIMCREDITODataGridViewTextBoxColumn.FillWeight = 93.12536!
        Me.LIMCREDITODataGridViewTextBoxColumn.HeaderText = "Monto"
        Me.LIMCREDITODataGridViewTextBoxColumn.Name = "LIMCREDITODataGridViewTextBoxColumn"
        Me.LIMCREDITODataGridViewTextBoxColumn.ReadOnly = True
        '
        'SEXO
        '
        Me.SEXO.DataPropertyName = "SEXO"
        Me.SEXO.FillWeight = 73.78172!
        Me.SEXO.HeaderText = "Sexo"
        Me.SEXO.Name = "SEXO"
        Me.SEXO.ReadOnly = True
        '
        'FECAUTORIZACIONDataGridViewTextBoxColumn
        '
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.DataPropertyName = "FECAUTORIZACION"
        DataGridViewCellStyle11.Format = "d"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle11
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.FillWeight = 87.95172!
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.HeaderText = "Fecha Utilizado"
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.Name = "FECAUTORIZACIONDataGridViewTextBoxColumn"
        Me.FECAUTORIZACIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AUTORIZADO
        '
        Me.AUTORIZADO.DataPropertyName = "AUTORIZADO"
        Me.AUTORIZADO.HeaderText = "Habilitado"
        Me.AUTORIZADO.Name = "AUTORIZADO"
        Me.AUTORIZADO.ReadOnly = True
        Me.AUTORIZADO.Visible = False
        '
        'EstadoGrilla
        '
        Me.EstadoGrilla.HeaderText = "EstadoGrilla"
        Me.EstadoGrilla.Name = "EstadoGrilla"
        Me.EstadoGrilla.ReadOnly = True
        Me.EstadoGrilla.Visible = False
        '
        'ADHERENTESBindingSource
        '
        Me.ADHERENTESBindingSource.DataMember = "ADHERENTES"
        Me.ADHERENTESBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label11.Location = New System.Drawing.Point(3, 327)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(212, 28)
        Me.Label11.TabIndex = 500
        Me.Label11.Text = "Datos del Adherentes"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(558, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 16)
        Me.Label8.TabIndex = 499
        Me.Label8.Text = "Sección :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxSeccion
        '
        Me.tbxSeccion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxSeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxSeccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NUMEROTOL", True))
        Me.tbxSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxSeccion.Location = New System.Drawing.Point(623, 248)
        Me.tbxSeccion.Name = "tbxSeccion"
        Me.tbxSeccion.Size = New System.Drawing.Size(141, 27)
        Me.tbxSeccion.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(32, 253)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 16)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "Empresa:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxEmpresa
        '
        Me.tbxEmpresa.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmpresa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "EMPPRESACLIENTE", True))
        Me.tbxEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEmpresa.Location = New System.Drawing.Point(103, 248)
        Me.tbxEmpresa.Name = "tbxEmpresa"
        Me.tbxEmpresa.Size = New System.Drawing.Size(444, 27)
        Me.tbxEmpresa.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(553, 286)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 16)
        Me.Label5.TabIndex = 495
        Me.Label5.Text = "Telefono :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxTelEmpresa
        '
        Me.tbxTelEmpresa.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxTelEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTelEmpresa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "TELEFONO1", True))
        Me.tbxTelEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTelEmpresa.Location = New System.Drawing.Point(623, 281)
        Me.tbxTelEmpresa.Name = "tbxTelEmpresa"
        Me.tbxTelEmpresa.Size = New System.Drawing.Size(141, 27)
        Me.tbxTelEmpresa.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(30, 287)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 493
        Me.Label7.Text = "Direccion:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxDirEmpresa
        '
        Me.tbxDirEmpresa.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxDirEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDirEmpresa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "DIRENVIO", True))
        Me.tbxDirEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxDirEmpresa.Location = New System.Drawing.Point(103, 282)
        Me.tbxDirEmpresa.Name = "tbxDirEmpresa"
        Me.tbxDirEmpresa.Size = New System.Drawing.Size(446, 27)
        Me.tbxDirEmpresa.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(518, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 16)
        Me.Label4.TabIndex = 491
        Me.Label4.Text = "Banco:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxBanco
        '
        Me.cbxBanco.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxBanco.CausesValidation = False
        Me.cbxBanco.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "SEPSA", True))
        Me.cbxBanco.DataSource = Me.CAJABindingSource
        Me.cbxBanco.DisplayMember = "NUMEROCAJA"
        Me.cbxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxBanco.FormattingEnabled = True
        Me.cbxBanco.Location = New System.Drawing.Point(571, 213)
        Me.cbxBanco.Name = "cbxBanco"
        Me.cbxBanco.Size = New System.Drawing.Size(159, 28)
        Me.cbxBanco.TabIndex = 12
        Me.cbxBanco.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsClientesAdherentes
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(280, 219)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 16)
        Me.Label3.TabIndex = 489
        Me.Label3.Text = "Nro Tarjeta:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxNroTarjeta
        '
        Me.tbxNroTarjeta.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxNroTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroTarjeta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "CUSTOMFIELD", True))
        Me.tbxNroTarjeta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxNroTarjeta.Location = New System.Drawing.Point(359, 214)
        Me.tbxNroTarjeta.Name = "tbxNroTarjeta"
        Me.tbxNroTarjeta.Size = New System.Drawing.Size(155, 27)
        Me.tbxNroTarjeta.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(557, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 487
        Me.Label1.Text = "Telefono :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxTelefono
        '
        Me.tbxTelefono.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTelefono.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "TELEFONO", True))
        Me.tbxTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTelefono.Location = New System.Drawing.Point(628, 111)
        Me.tbxTelefono.Name = "tbxTelefono"
        Me.tbxTelefono.Size = New System.Drawing.Size(132, 27)
        Me.tbxTelefono.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(30, 116)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(68, 16)
        Me.Label19.TabIndex = 485
        Me.Label19.Text = "Direccion:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxDireccion
        '
        Me.tbxDireccion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDireccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "DIRECCION", True))
        Me.tbxDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxDireccion.Location = New System.Drawing.Point(103, 111)
        Me.tbxDireccion.Name = "tbxDireccion"
        Me.tbxDireccion.Size = New System.Drawing.Size(446, 27)
        Me.tbxDireccion.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(602, 185)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 16)
        Me.Label17.TabIndex = 483
        Me.Label17.Text = "Monto:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMonto
        '
        Me.tbxMonto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMonto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "LIMCREDITO", True))
        Me.tbxMonto.Enabled = False
        Me.tbxMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxMonto.Location = New System.Drawing.Point(651, 180)
        Me.tbxMonto.Name = "tbxMonto"
        Me.tbxMonto.Size = New System.Drawing.Size(108, 27)
        Me.tbxMonto.TabIndex = 482
        Me.tbxMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(317, 185)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(38, 16)
        Me.Label16.TabIndex = 481
        Me.Label16.Text = "Plan:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxPlan
        '
        Me.cbxPlan.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxPlan.CausesValidation = False
        Me.cbxPlan.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "PROVEEDOR_ID", True))
        Me.cbxPlan.DataSource = Me.PRODUCTOSBindingSource
        Me.cbxPlan.DisplayMember = "DESPRODUCTO"
        Me.cbxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPlan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPlan.FormattingEnabled = True
        Me.cbxPlan.Location = New System.Drawing.Point(360, 179)
        Me.cbxPlan.Name = "cbxPlan"
        Me.cbxPlan.Size = New System.Drawing.Size(208, 28)
        Me.cbxPlan.TabIndex = 10
        Me.cbxPlan.ValueMember = "CODPRODUCTO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(27, 221)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 16)
        Me.Label15.TabIndex = 479
        Me.Label15.Text = "Vendedor:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxVendedor
        '
        Me.cbxVendedor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxVendedor.CausesValidation = False
        Me.cbxVendedor.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "CODVENDEDOR", True))
        Me.cbxVendedor.DataSource = Me.VENDEDORBindingSource
        Me.cbxVendedor.DisplayMember = "DESVENDEDOR"
        Me.cbxVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVendedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVendedor.FormattingEnabled = True
        Me.cbxVendedor.Location = New System.Drawing.Point(103, 215)
        Me.cbxVendedor.Name = "cbxVendedor"
        Me.cbxVendedor.Size = New System.Drawing.Size(149, 28)
        Me.cbxVendedor.TabIndex = 9
        Me.cbxVendedor.ValueMember = "CODVENDEDOR"
        '
        'VENDEDORBindingSource
        '
        Me.VENDEDORBindingSource.DataMember = "VENDEDOR"
        Me.VENDEDORBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'pbxNacionalidad
        '
        Me.pbxNacionalidad.BackColor = System.Drawing.Color.Transparent
        Me.pbxNacionalidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxNacionalidad.Image = CType(resources.GetObject("pbxNacionalidad.Image"), System.Drawing.Image)
        Me.pbxNacionalidad.Location = New System.Drawing.Point(733, 145)
        Me.pbxNacionalidad.Name = "pbxNacionalidad"
        Me.pbxNacionalidad.Size = New System.Drawing.Size(26, 26)
        Me.pbxNacionalidad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNacionalidad.TabIndex = 477
        Me.pbxNacionalidad.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(441, 150)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 16)
        Me.Label14.TabIndex = 476
        Me.Label14.Text = "Nacionalidad :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(306, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 16)
        Me.Label13.TabIndex = 475
        Me.Label13.Text = "Edad :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxEdad
        '
        Me.tbxEdad.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxEdad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEdad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "DV", True))
        Me.tbxEdad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEdad.Location = New System.Drawing.Point(360, 145)
        Me.tbxEdad.Name = "tbxEdad"
        Me.tbxEdad.ReadOnly = True
        Me.tbxEdad.Size = New System.Drawing.Size(77, 27)
        Me.tbxEdad.TabIndex = 474
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(18, 150)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 473
        Me.Label12.Text = "Fecha Nac.:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaNac
        '
        Me.dtpFechaNac.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNac.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaNac.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CLIENTESBindingSource, "FECHANACIMIENTO", True))
        Me.dtpFechaNac.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNac.Location = New System.Drawing.Point(103, 145)
        Me.dtpFechaNac.Name = "dtpFechaNac"
        Me.dtpFechaNac.Size = New System.Drawing.Size(197, 27)
        Me.dtpFechaNac.TabIndex = 7
        Me.dtpFechaNac.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(557, 82)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 16)
        Me.Label9.TabIndex = 466
        Me.Label9.Text = "R.U.C/C.I :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxRuc
        '
        Me.tbxRuc.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRuc.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "RUC", True))
        Me.tbxRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxRuc.Location = New System.Drawing.Point(627, 77)
        Me.tbxRuc.Name = "tbxRuc"
        Me.tbxRuc.Size = New System.Drawing.Size(132, 27)
        Me.tbxRuc.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(271, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 16)
        Me.Label6.TabIndex = 464
        Me.Label6.Text = "Fecha Ingreso :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaInicio.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CLIENTESBindingSource, "FECHAINGRESO", True))
        Me.dtpFechaInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(377, 43)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(170, 27)
        Me.dtpFechaInicio.TabIndex = 2
        Me.dtpFechaInicio.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'LblInfoDV
        '
        Me.LblInfoDV.AutoSize = False
        Me.LblInfoDV.BackColor = System.Drawing.Color.Transparent
        Me.LblInfoDV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.LblInfoDV.ForeColor = System.Drawing.Color.Maroon
        Me.LblInfoDV.Location = New System.Drawing.Point(628, 57)
        Me.LblInfoDV.Name = "LblInfoDV"
        '
        '
        '
        Me.LblInfoDV.RootElement.ForeColor = System.Drawing.Color.Maroon
        Me.LblInfoDV.Size = New System.Drawing.Size(118, 18)
        Me.LblInfoDV.TabIndex = 462
        Me.LblInfoDV.Text = "Presione * para DV"
        Me.LblInfoDV.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblInfoDV.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(3, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(95, 16)
        Me.Label18.TabIndex = 17
        Me.Label18.Text = "Cliente Nomb.:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxNacionalidad
        '
        Me.cbxNacionalidad.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxNacionalidad.CausesValidation = False
        Me.cbxNacionalidad.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CLIENTESBindingSource, "CODPAIS", True))
        Me.cbxNacionalidad.DataSource = Me.PAISBindingSource
        Me.cbxNacionalidad.DisplayMember = "DESPAIS"
        Me.cbxNacionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxNacionalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxNacionalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxNacionalidad.ForeColor = System.Drawing.Color.Black
        Me.cbxNacionalidad.FormattingEnabled = True
        Me.cbxNacionalidad.Location = New System.Drawing.Point(540, 144)
        Me.cbxNacionalidad.Name = "cbxNacionalidad"
        Me.cbxNacionalidad.Size = New System.Drawing.Size(188, 28)
        Me.cbxNacionalidad.TabIndex = 8
        Me.cbxNacionalidad.ValueMember = "CODPAIS"
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(4, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(164, 28)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Datos del Titular"
        '
        'tbxCliente
        '
        Me.tbxCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NOMBRE", True))
        Me.tbxCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCliente.Location = New System.Drawing.Point(103, 77)
        Me.tbxCliente.Name = "tbxCliente"
        Me.tbxCliente.Size = New System.Drawing.Size(444, 27)
        Me.tbxCliente.TabIndex = 3
        '
        'lblRelacionado
        '
        Me.lblRelacionado.AutoSize = True
        Me.lblRelacionado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblRelacionado.ForeColor = System.Drawing.Color.Black
        Me.lblRelacionado.Location = New System.Drawing.Point(11, 48)
        Me.lblRelacionado.Name = "lblRelacionado"
        Me.lblRelacionado.Size = New System.Drawing.Size(87, 16)
        Me.lblRelacionado.TabIndex = 15
        Me.lblRelacionado.Text = "Registro Nro:"
        Me.lblRelacionado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxNroRegistro
        '
        Me.tbxNroRegistro.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxNroRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroRegistro.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CLIENTESBindingSource, "NUMCLIENTE", True))
        Me.tbxNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxNroRegistro.Location = New System.Drawing.Point(103, 43)
        Me.tbxNroRegistro.Name = "tbxNroRegistro"
        Me.tbxNroRegistro.Size = New System.Drawing.Size(138, 27)
        Me.tbxNroRegistro.TabIndex = 1
        '
        'tbxAdherentes
        '
        Me.tbxAdherentes.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxAdherentes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxAdherentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxAdherentes.Location = New System.Drawing.Point(9, 383)
        Me.tbxAdherentes.Name = "tbxAdherentes"
        Me.tbxAdherentes.Size = New System.Drawing.Size(265, 27)
        Me.tbxAdherentes.TabIndex = 17
        '
        'cbxSexo
        '
        Me.cbxSexo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxSexo.CausesValidation = False
        Me.cbxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSexo.FormattingEnabled = True
        Me.cbxSexo.Location = New System.Drawing.Point(104, 181)
        Me.cbxSexo.Name = "cbxSexo"
        Me.cbxSexo.Size = New System.Drawing.Size(180, 28)
        Me.cbxSexo.TabIndex = 550
        '
        'pnlimprimirCarnet
        '
        Me.pnlimprimirCarnet.BackColor = System.Drawing.Color.DimGray
        Me.pnlimprimirCarnet.Controls.Add(Me.Label28)
        Me.pnlimprimirCarnet.Controls.Add(Me.chbTodos)
        Me.pnlimprimirCarnet.Controls.Add(Me.btnCerrarImprimir)
        Me.pnlimprimirCarnet.Controls.Add(Me.btImprimirMultiples)
        Me.pnlimprimirCarnet.Controls.Add(Me.Label29)
        Me.pnlimprimirCarnet.Controls.Add(Me.dgwClientesCarnet)
        Me.pnlimprimirCarnet.Location = New System.Drawing.Point(56, 65)
        Me.pnlimprimirCarnet.Name = "pnlimprimirCarnet"
        Me.pnlimprimirCarnet.Size = New System.Drawing.Size(625, 431)
        Me.pnlimprimirCarnet.TabIndex = 549
        Me.pnlimprimirCarnet.Visible = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(9, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(158, 28)
        Me.Label28.TabIndex = 460
        Me.Label28.Text = "Imprimir Carnet"
        '
        'chbTodos
        '
        Me.chbTodos.AutoSize = True
        Me.chbTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.chbTodos.Location = New System.Drawing.Point(505, 33)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(112, 20)
        Me.chbTodos.TabIndex = 466
        Me.chbTodos.Text = "Marcar Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'btnCerrarImprimir
        '
        Me.btnCerrarImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarImprimir.BackColor = System.Drawing.Color.Silver
        Me.btnCerrarImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCerrarImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnCerrarImprimir.ForeColor = System.Drawing.Color.Black
        Me.btnCerrarImprimir.Location = New System.Drawing.Point(371, 391)
        Me.btnCerrarImprimir.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCerrarImprimir.Name = "btnCerrarImprimir"
        Me.btnCerrarImprimir.Size = New System.Drawing.Size(72, 34)
        Me.btnCerrarImprimir.TabIndex = 465
        Me.btnCerrarImprimir.Text = "Cerrar"
        Me.btnCerrarImprimir.UseVisualStyleBackColor = False
        '
        'btImprimirMultiples
        '
        Me.btImprimirMultiples.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btImprimirMultiples.BackColor = System.Drawing.Color.RoyalBlue
        Me.btImprimirMultiples.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btImprimirMultiples.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btImprimirMultiples.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btImprimirMultiples.ForeColor = System.Drawing.Color.White
        Me.btImprimirMultiples.Location = New System.Drawing.Point(449, 391)
        Me.btImprimirMultiples.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btImprimirMultiples.Name = "btImprimirMultiples"
        Me.btImprimirMultiples.Size = New System.Drawing.Size(168, 34)
        Me.btImprimirMultiples.TabIndex = 464
        Me.btImprimirMultiples.Text = "Imprimir"
        Me.btImprimirMultiples.UseVisualStyleBackColor = False
        '
        'dgwClientesCarnet
        '
        Me.dgwClientesCarnet.AllowUserToAddRows = False
        Me.dgwClientesCarnet.AllowUserToDeleteRows = False
        Me.dgwClientesCarnet.AllowUserToResizeColumns = False
        Me.dgwClientesCarnet.AllowUserToResizeRows = False
        Me.dgwClientesCarnet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwClientesCarnet.AutoGenerateColumns = False
        Me.dgwClientesCarnet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwClientesCarnet.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwClientesCarnet.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgwClientesCarnet.ColumnHeadersHeight = 35
        Me.dgwClientesCarnet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCLIENTEDataGridViewTextBoxColumn2, Me.RUCDataGridViewTextBoxColumn1, Me.NOMBREDataGridViewTextBoxColumn2, Me.marcar})
        Me.dgwClientesCarnet.DataSource = Me.FILLCLIENTESCARNETBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwClientesCarnet.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgwClientesCarnet.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwClientesCarnet.Location = New System.Drawing.Point(7, 59)
        Me.dgwClientesCarnet.MultiSelect = False
        Me.dgwClientesCarnet.Name = "dgwClientesCarnet"
        Me.dgwClientesCarnet.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwClientesCarnet.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgwClientesCarnet.RowHeadersVisible = False
        Me.dgwClientesCarnet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwClientesCarnet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwClientesCarnet.Size = New System.Drawing.Size(610, 327)
        Me.dgwClientesCarnet.TabIndex = 459
        '
        'CODCLIENTEDataGridViewTextBoxColumn2
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn2.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn2.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn2.Name = "CODCLIENTEDataGridViewTextBoxColumn2"
        Me.CODCLIENTEDataGridViewTextBoxColumn2.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn2.Visible = False
        '
        'RUCDataGridViewTextBoxColumn1
        '
        Me.RUCDataGridViewTextBoxColumn1.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn1.HeaderText = "RUC"
        Me.RUCDataGridViewTextBoxColumn1.Name = "RUCDataGridViewTextBoxColumn1"
        '
        'NOMBREDataGridViewTextBoxColumn2
        '
        Me.NOMBREDataGridViewTextBoxColumn2.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn2.FillWeight = 210.0!
        Me.NOMBREDataGridViewTextBoxColumn2.HeaderText = "Cliente"
        Me.NOMBREDataGridViewTextBoxColumn2.Name = "NOMBREDataGridViewTextBoxColumn2"
        '
        'marcar
        '
        Me.marcar.FillWeight = 70.0!
        Me.marcar.HeaderText = "Marcar"
        Me.marcar.Name = "marcar"
        '
        'FILLCLIENTESCARNETBindingSource
        '
        Me.FILLCLIENTESCARNETBindingSource.DataMember = "FILLCLIENTESCARNET"
        Me.FILLCLIENTESCARNETBindingSource.DataSource = Me.DsClientesAdherentes
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label29.ForeColor = System.Drawing.Color.Black
        Me.Label29.Location = New System.Drawing.Point(10, 33)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(323, 16)
        Me.Label29.TabIndex = 461
        Me.Label29.Text = "Seleccione los clientes que desea imprimir su Carnet"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pbxMostrarOBS)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.pbxImprimir)
        Me.Panel1.Controls.Add(Me.PictureBoxActivo)
        Me.Panel1.Controls.Add(Me.lblActivo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 35)
        Me.Panel1.TabIndex = 456
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.printMultiple
        Me.PictureBox1.Location = New System.Drawing.Point(583, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 485
        Me.PictureBox1.TabStop = False
        '
        'pbxMostrarOBS
        '
        Me.pbxMostrarOBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxMostrarOBS.BackColor = System.Drawing.Color.Transparent
        Me.pbxMostrarOBS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxMostrarOBS.Image = Global.ContaExpress.My.Resources.Resources.Display
        Me.pbxMostrarOBS.Location = New System.Drawing.Point(653, 0)
        Me.pbxMostrarOBS.Name = "pbxMostrarOBS"
        Me.pbxMostrarOBS.Size = New System.Drawing.Size(35, 33)
        Me.pbxMostrarOBS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxMostrarOBS.TabIndex = 484
        Me.pbxMostrarOBS.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(140, 0)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(105, 0)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(70, 0)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(35, 0)
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
        Me.NuevoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'pbxImprimir
        '
        Me.pbxImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxImprimir.BackColor = System.Drawing.Color.Transparent
        Me.pbxImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxImprimir.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.pbxImprimir.Location = New System.Drawing.Point(618, 0)
        Me.pbxImprimir.Name = "pbxImprimir"
        Me.pbxImprimir.Size = New System.Drawing.Size(35, 33)
        Me.pbxImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxImprimir.TabIndex = 458
        Me.pbxImprimir.TabStop = False
        '
        'PictureBoxActivo
        '
        Me.PictureBoxActivo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxActivo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxActivo.Image = Global.ContaExpress.My.Resources.Resources.AbiertoActive
        Me.PictureBoxActivo.Location = New System.Drawing.Point(688, 0)
        Me.PictureBoxActivo.Name = "PictureBoxActivo"
        Me.PictureBoxActivo.Size = New System.Drawing.Size(35, 33)
        Me.PictureBoxActivo.TabIndex = 470
        Me.PictureBoxActivo.TabStop = False
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.BackColor = System.Drawing.Color.Transparent
        Me.lblActivo.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblActivo.Location = New System.Drawing.Point(722, 11)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(37, 13)
        Me.lblActivo.TabIndex = 471
        Me.lblActivo.Text = "Activo"
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'VENDEDORTableAdapter
        '
        Me.VENDEDORTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'PAISTableAdapter
        '
        Me.PAISTableAdapter.ClearBeforeFill = True
        '
        'ADHERENTESTableAdapter
        '
        Me.ADHERENTESTableAdapter.ClearBeforeFill = True
        '
        'CarnetTableAdapter
        '
        Me.CarnetTableAdapter.ClearBeforeFill = True
        '
        'FILLCLIENTESCARNETTableAdapter
        '
        Me.FILLCLIENTESCARNETTableAdapter.ClearBeforeFill = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsVentasPlus, Me.tsmImprimir, Me.tsVer, Me.ReportesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1022, 24)
        Me.MenuStrip1.TabIndex = 477
        Me.MenuStrip1.Text = "MenuStrip2"
        '
        'tsVentasPlus
        '
        Me.tsVentasPlus.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsNuevo, Me.tsEditar, Me.tsGuardar, Me.ToolStripSeparator5, Me.tsEliminar, Me.ToolStripSeparator6})
        Me.tsVentasPlus.ForeColor = System.Drawing.Color.Black
        Me.tsVentasPlus.Name = "tsVentasPlus"
        Me.tsVentasPlus.Size = New System.Drawing.Size(61, 20)
        Me.tsVentasPlus.Text = "Clientes"
        '
        'tsNuevo
        '
        Me.tsNuevo.Image = Global.ContaExpress.My.Resources.Resources.NewOff
        Me.tsNuevo.Name = "tsNuevo"
        Me.tsNuevo.Size = New System.Drawing.Size(199, 22)
        Me.tsNuevo.Text = "Nuevo                          F5"
        '
        'tsEditar
        '
        Me.tsEditar.Image = Global.ContaExpress.My.Resources.Resources.EditOff
        Me.tsEditar.Name = "tsEditar"
        Me.tsEditar.Size = New System.Drawing.Size(199, 22)
        Me.tsEditar.Text = "Editar                           F6"
        '
        'tsGuardar
        '
        Me.tsGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.tsGuardar.Name = "tsGuardar"
        Me.tsGuardar.Size = New System.Drawing.Size(199, 22)
        Me.tsGuardar.Tag = "F2"
        Me.tsGuardar.Text = "Guardar                       F7"
        Me.tsGuardar.ToolTipText = "F2"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(196, 6)
        '
        'tsEliminar
        '
        Me.tsEliminar.Image = Global.ContaExpress.My.Resources.Resources.DeleteOff
        Me.tsEliminar.Name = "tsEliminar"
        Me.tsEliminar.Size = New System.Drawing.Size(199, 22)
        Me.tsEliminar.Text = "Eliminar                      "
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(196, 6)
        '
        'tsmImprimir
        '
        Me.tsmImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmImprimirCarnet, Me.tmsImprimirMultiples})
        Me.tsmImprimir.Name = "tsmImprimir"
        Me.tsmImprimir.Size = New System.Drawing.Size(65, 20)
        Me.tsmImprimir.Text = "Imprimir"
        '
        'tsmImprimirCarnet
        '
        Me.tsmImprimirCarnet.Image = Global.ContaExpress.My.Resources.Resources.PrintOff
        Me.tsmImprimirCarnet.Name = "tsmImprimirCarnet"
        Me.tsmImprimirCarnet.Size = New System.Drawing.Size(263, 22)
        Me.tsmImprimirCarnet.Text = "Imprimir un Carnet"
        '
        'tmsImprimirMultiples
        '
        Me.tmsImprimirMultiples.Image = Global.ContaExpress.My.Resources.Resources.printMultiple
        Me.tmsImprimirMultiples.Name = "tmsImprimirMultiples"
        Me.tmsImprimirMultiples.Size = New System.Drawing.Size(263, 22)
        Me.tmsImprimirMultiples.Text = "Imprimir Multiples Carnets            F8"
        '
        'tsVer
        '
        Me.tsVer.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCampoDeObservacion, Me.AgregarComentarioToolStripMenuItem})
        Me.tsVer.ForeColor = System.Drawing.Color.Black
        Me.tsVer.Name = "tsVer"
        Me.tsVer.Size = New System.Drawing.Size(36, 20)
        Me.tsVer.Text = "Ver"
        '
        'tsCampoDeObservacion
        '
        Me.tsCampoDeObservacion.Image = Global.ContaExpress.My.Resources.Resources.DisplayOff
        Me.tsCampoDeObservacion.Name = "tsCampoDeObservacion"
        Me.tsCampoDeObservacion.Size = New System.Drawing.Size(182, 22)
        Me.tsCampoDeObservacion.Text = "Comentario de Alta"
        '
        'AgregarComentarioToolStripMenuItem
        '
        Me.AgregarComentarioToolStripMenuItem.Name = "AgregarComentarioToolStripMenuItem"
        Me.AgregarComentarioToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.AgregarComentarioToolStripMenuItem.Text = "Agregar Comentario"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LiquidaciónSemanalToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'LiquidaciónSemanalToolStripMenuItem
        '
        Me.LiquidaciónSemanalToolStripMenuItem.Image = Global.ContaExpress.My.Resources.Resources.Credit
        Me.LiquidaciónSemanalToolStripMenuItem.Name = "LiquidaciónSemanalToolStripMenuItem"
        Me.LiquidaciónSemanalToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.LiquidaciónSemanalToolStripMenuItem.Text = "Liquidación Semanal           F9"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 701)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.ShowItemToolTips = True
        Me.StatusStrip1.Size = New System.Drawing.Size(1022, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 478
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(950, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "F5 - Nuevo / F6 - Editar / F7 - Guardar / F8 - Imprimir Multiples / F9 - Ver Liqu" & _
    "idación Semanal"
        '
        'pnlReporteLiquidacion
        '
        Me.pnlReporteLiquidacion.BackColor = System.Drawing.Color.DimGray
        Me.pnlReporteLiquidacion.Controls.Add(Me.Label34)
        Me.pnlReporteLiquidacion.Controls.Add(Me.dtpFechaHasta)
        Me.pnlReporteLiquidacion.Controls.Add(Me.Label32)
        Me.pnlReporteLiquidacion.Controls.Add(Me.cbxVendedorInforme)
        Me.pnlReporteLiquidacion.Controls.Add(Me.Label33)
        Me.pnlReporteLiquidacion.Controls.Add(Me.dtpFechaDesde)
        Me.pnlReporteLiquidacion.Controls.Add(Me.btnCerrarInforme)
        Me.pnlReporteLiquidacion.Controls.Add(Me.btnVerInforme)
        Me.pnlReporteLiquidacion.Controls.Add(Me.Label31)
        Me.pnlReporteLiquidacion.Controls.Add(Me.Label30)
        Me.pnlReporteLiquidacion.Location = New System.Drawing.Point(358, 233)
        Me.pnlReporteLiquidacion.Name = "pnlReporteLiquidacion"
        Me.pnlReporteLiquidacion.Size = New System.Drawing.Size(537, 251)
        Me.pnlReporteLiquidacion.TabIndex = 550
        Me.pnlReporteLiquidacion.Visible = False
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label34.ForeColor = System.Drawing.Color.Black
        Me.Label34.Location = New System.Drawing.Point(274, 139)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(88, 16)
        Me.Label34.TabIndex = 485
        Me.Label34.Text = "Fecha Hasta:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaHasta.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CLIENTESBindingSource, "FECHANACIMIENTO", True))
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(365, 134)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(135, 27)
        Me.dtpFechaHasta.TabIndex = 484
        Me.dtpFechaHasta.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label32.ForeColor = System.Drawing.Color.Black
        Me.Label32.Location = New System.Drawing.Point(48, 90)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(71, 16)
        Me.Label32.TabIndex = 483
        Me.Label32.Text = "Vendedor:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxVendedorInforme
        '
        Me.cbxVendedorInforme.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxVendedorInforme.CausesValidation = False
        Me.cbxVendedorInforme.DataSource = Me.VENDEDORBindingSource
        Me.cbxVendedorInforme.DisplayMember = "DESVENDEDOR"
        Me.cbxVendedorInforme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVendedorInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVendedorInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVendedorInforme.FormattingEnabled = True
        Me.cbxVendedorInforme.Location = New System.Drawing.Point(124, 84)
        Me.cbxVendedorInforme.Name = "cbxVendedorInforme"
        Me.cbxVendedorInforme.Size = New System.Drawing.Size(375, 28)
        Me.cbxVendedorInforme.TabIndex = 481
        Me.cbxVendedorInforme.ValueMember = "CODVENDEDOR"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label33.ForeColor = System.Drawing.Color.Black
        Me.Label33.Location = New System.Drawing.Point(30, 139)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(93, 16)
        Me.Label33.TabIndex = 482
        Me.Label33.Text = "Fecha Desde:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaDesde.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.CLIENTESBindingSource, "FECHANACIMIENTO", True))
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(127, 134)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(135, 27)
        Me.dtpFechaDesde.TabIndex = 480
        Me.dtpFechaDesde.Value = New Date(2014, 6, 19, 0, 0, 0, 0)
        '
        'btnCerrarInforme
        '
        Me.btnCerrarInforme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarInforme.BackColor = System.Drawing.Color.Silver
        Me.btnCerrarInforme.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCerrarInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnCerrarInforme.ForeColor = System.Drawing.Color.Black
        Me.btnCerrarInforme.Location = New System.Drawing.Point(277, 202)
        Me.btnCerrarInforme.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCerrarInforme.Name = "btnCerrarInforme"
        Me.btnCerrarInforme.Size = New System.Drawing.Size(72, 34)
        Me.btnCerrarInforme.TabIndex = 465
        Me.btnCerrarInforme.Text = "Cerrar"
        Me.btnCerrarInforme.UseVisualStyleBackColor = False
        '
        'btnVerInforme
        '
        Me.btnVerInforme.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVerInforme.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnVerInforme.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnVerInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnVerInforme.ForeColor = System.Drawing.Color.White
        Me.btnVerInforme.Location = New System.Drawing.Point(354, 202)
        Me.btnVerInforme.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnVerInforme.Name = "btnVerInforme"
        Me.btnVerInforme.Size = New System.Drawing.Size(168, 34)
        Me.btnVerInforme.TabIndex = 464
        Me.btnVerInforme.Text = "Ver Informe"
        Me.btnVerInforme.UseVisualStyleBackColor = False
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(9, 5)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(314, 28)
        Me.Label31.TabIndex = 460
        Me.Label31.Text = "Liquidacion Semanal de Haberes"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label30.ForeColor = System.Drawing.Color.Black
        Me.Label30.Location = New System.Drawing.Point(10, 34)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(369, 16)
        Me.Label30.TabIndex = 461
        Me.Label30.Text = "Seleccione los datos correspondientes para general informe"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LiquidacionsemanalTableAdapter
        '
        Me.LiquidacionsemanalTableAdapter.ClearBeforeFill = True
        '
        'VentascaidasliquidacionTableAdapter
        '
        Me.VentascaidasliquidacionTableAdapter.ClearBeforeFill = True
        '
        'ClientesAdherentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 723)
        Me.Controls.Add(Me.pnlReporteLiquidacion)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ClientesAdherentes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes / Adherentes"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgwClientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsClientesAdherentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosCliente.ResumeLayout(False)
        Me.pnlDatosCliente.PerformLayout()
        Me.pnlBaja.ResumeLayout(False)
        Me.pnlBaja.PerformLayout()
        Me.pnlObservacion.ResumeLayout(False)
        Me.pnlObservacion.PerformLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCerrarOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPlanes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxBanco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwAdherentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ADHERENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblInfoDV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlimprimirCarnet.ResumeLayout(False)
        Me.pnlimprimirCarnet.PerformLayout()
        CType(Me.dgwClientesCarnet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FILLCLIENTESCARNETBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxMostrarOBS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxActivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlReporteLiquidacion.ResumeLayout(False)
        Me.pnlReporteLiquidacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pbxImprimir As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pnlDatosCliente As System.Windows.Forms.Panel
    Friend WithEvents LblInfoDV As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbxNacionalidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblRelacionado As System.Windows.Forms.Label
    Friend WithEvents tbxNroRegistro As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbxRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbxMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbxPlan As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbxVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents pbxNacionalidad As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbxEdad As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaNac As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBoxActivo As System.Windows.Forms.PictureBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents pbxMostrarOBS As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbxNroTarjeta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents dgwClientes As System.Windows.Forms.DataGridView
    Friend WithEvents DsClientesAdherentes As ContaExpress.dsClientesAdherentes
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.CLIENTESTableAdapter
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbxMontoAdherente As System.Windows.Forms.TextBox
    Friend WithEvents tbxParentesco As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaNacAdhe As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtRucAdherente As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbxAdherentes As System.Windows.Forms.TextBox
    Friend WithEvents dgwAdherentes As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbxSeccion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbxEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxTelEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbxDirEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents tbxTotalMontoCuota As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarAdh As System.Windows.Forms.Button
    Friend WithEvents pbxVendedor As System.Windows.Forms.PictureBox
    Friend WithEvents pbxBanco As System.Windows.Forms.PictureBox
    Friend WithEvents VENDEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENDEDORTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.VENDEDORTableAdapter
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents pbxPlanes As System.Windows.Forms.PictureBox
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.CAJATableAdapter
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.PAISTableAdapter
    Friend WithEvents ADHERENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ADHERENTESTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.ADHERENTESTableAdapter
    Friend WithEvents CarnetTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.CARNETTableAdapter
    Friend WithEvents pnlBaja As System.Windows.Forms.Panel
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaBaja As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlimprimirCarnet As System.Windows.Forms.Panel
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents dgwClientesCarnet As System.Windows.Forms.DataGridView
    Friend WithEvents btImprimirMultiples As System.Windows.Forms.Button
    Friend WithEvents FILLCLIENTESCARNETBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FILLCLIENTESCARNETTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.FILLCLIENTESCARNETTableAdapter
    Friend WithEvents btnCerrarImprimir As System.Windows.Forms.Button
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chbTodos As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsVentasPlus As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsNuevo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsEditar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsGuardar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsVer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsCampoDeObservacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsmImprimirCarnet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmsImprimirMultiples As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquidaciónSemanalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlReporteLiquidacion As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cbxVendedorInforme As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCerrarInforme As System.Windows.Forms.Button
    Friend WithEvents btnVerInforme As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents LiquidacionsemanalTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.LIQUIDACIONSEMANALTableAdapter
    Friend WithEvents VentascaidasliquidacionTableAdapter As ContaExpress.dsClientesAdherentesTableAdapters.VENTASCAIDASLIQUIDACIONTableAdapter
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cbxSexo As System.Windows.Forms.ComboBox
    Friend WithEvents NUMCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTORIZADOCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cbxSexoAdherente As System.Windows.Forms.ComboBox
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINGRESODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHANACIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DVDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMFIELDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LIMCREDITODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEXO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECAUTORIZACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTORIZADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoGrilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlObservacion As System.Windows.Forms.Panel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnCerrarOBS As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtObservacion As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents AgregarComentarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbxRefresh As System.Windows.Forms.Button

End Class
