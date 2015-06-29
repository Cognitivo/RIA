<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Envios
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Envios))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rbnFaltanEnviar = New System.Windows.Forms.RadioButton()
        Me.rbnEnviados = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvFacturasSaldoEnvio = New System.Windows.Forms.DataGridView()
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FacturasSaldoEnvioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEnvios = New ContaExpress.DsEnvios()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvEnviosXFactura = New System.Windows.Forms.DataGridView()
        Me.FECHAENVIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VEHICULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHAPA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chofer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROENVIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODENVIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnviosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlNroFactura = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.tbxRemNroFactura = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbDeposito = New System.Windows.Forms.ComboBox()
        Me.DEPOSITOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNroEnvio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxNombreCliente = New System.Windows.Forms.TextBox()
        Me.TxtNumCliente = New System.Windows.Forms.TextBox()
        Me.dgvEnvioDetalle = New System.Windows.Forms.DataGridView()
        Me.NUMVENTADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Enviado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODENVIODETDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODENVIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ENVIAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnviosDetalleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaVto = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblProximoNro = New Telerik.WinControls.UI.RadLabel()
        Me.LblEstado = New Telerik.WinControls.UI.RadLabel()
        Me.PRODUCTOENVIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TextBoxCodProducto = New Telerik.WinControls.UI.RadTextBox()
        Me.TextBoxCodCodigo = New Telerik.WinControls.UI.RadTextBox()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.pnlEditBusc = New System.Windows.Forms.Panel()
        Me.pbxReimprimir = New System.Windows.Forms.PictureBox()
        Me.pbxDatosChofer = New System.Windows.Forms.PictureBox()
        Me.PictureBoxMotivoAnulacion = New System.Windows.Forms.PictureBox()
        Me.ConfirmarPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.FACTURASCONSALDOENVIOTableAdapter = New ContaExpress.DsEnviosTableAdapters.FACTURASCONSALDOENVIOTableAdapter()
        Me.ENVIOSTableAdapter = New ContaExpress.DsEnviosTableAdapters.ENVIOSTableAdapter()
        Me.ENVIOSDETALLETableAdapter = New ContaExpress.DsEnviosTableAdapters.ENVIOSDETALLETableAdapter()
        Me.DEPOSITOTableAdapter = New ContaExpress.DsEnviosTableAdapters.DEPOSITOTableAdapter()
        Me.VENTASTableAdapter = New ContaExpress.DsEnviosTableAdapters.VENTASTableAdapter()
        Me.ProductoenvioTableAdapter = New ContaExpress.DsEnviosTableAdapters.PRODUCTOENVIOTableAdapter()
        Me.pnlChofer = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.txtConductor = New System.Windows.Forms.TextBox()
        Me.txtNroChapa = New System.Windows.Forms.TextBox()
        Me.txtVehiculo = New System.Windows.Forms.TextBox()
        Me.txtRucChofer = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnCerrarAnular = New Telerik.WinControls.UI.RadButton()
        Me.btnEnviar = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvFacturasSaldoEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FacturasSaldoEnvioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEnvios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.dgvEnviosXFactura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnviosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNroFactura.SuspendLayout()
        CType(Me.DEPOSITOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEnvioDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EnviosDetalleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.lblProximoNro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOENVIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonera.SuspendLayout()
        Me.pnlEditBusc.SuspendLayout()
        CType(Me.pbxReimprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDatosChofer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxMotivoAnulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConfirmarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlChofer.SuspendLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(-2, 34)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbnEnviados)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbnFaltanEnviar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1020, 597)
        Me.SplitContainer1.SplitterDistance = 225
        Me.SplitContainer1.TabIndex = 43
        '
        'rbnFaltanEnviar
        '
        Me.rbnFaltanEnviar.AutoSize = True
        Me.rbnFaltanEnviar.Checked = True
        Me.rbnFaltanEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbnFaltanEnviar.Location = New System.Drawing.Point(9, 10)
        Me.rbnFaltanEnviar.Name = "rbnFaltanEnviar"
        Me.rbnFaltanEnviar.Size = New System.Drawing.Size(109, 21)
        Me.rbnFaltanEnviar.TabIndex = 5
        Me.rbnFaltanEnviar.TabStop = True
        Me.rbnFaltanEnviar.Text = "Faltan Enviar"
        Me.rbnFaltanEnviar.UseVisualStyleBackColor = True
        '
        'rbnEnviados
        '
        Me.rbnEnviados.AutoSize = True
        Me.rbnEnviados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbnEnviados.Location = New System.Drawing.Point(136, 10)
        Me.rbnEnviados.Name = "rbnEnviados"
        Me.rbnEnviados.Size = New System.Drawing.Size(84, 21)
        Me.rbnEnviados.TabIndex = 4
        Me.rbnEnviados.Text = "Enviados"
        Me.rbnEnviados.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvFacturasSaldoEnvio, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(-1, 37)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 556.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 556.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 556.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(226, 556)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'dgvFacturasSaldoEnvio
        '
        Me.dgvFacturasSaldoEnvio.AllowUserToAddRows = False
        Me.dgvFacturasSaldoEnvio.AllowUserToDeleteRows = False
        Me.dgvFacturasSaldoEnvio.AllowUserToResizeColumns = False
        Me.dgvFacturasSaldoEnvio.AllowUserToResizeRows = False
        Me.dgvFacturasSaldoEnvio.AutoGenerateColumns = False
        Me.dgvFacturasSaldoEnvio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFacturasSaldoEnvio.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFacturasSaldoEnvio.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFacturasSaldoEnvio.ColumnHeadersHeight = 35
        Me.dgvFacturasSaldoEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvFacturasSaldoEnvio.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOMBRECLIENTEDataGridViewTextBoxColumn, Me.NUMVENTADataGridViewTextBoxColumn, Me.CODVENTADataGridViewTextBoxColumn, Me.RUCCLIENTE, Me.CODCLIENTE})
        Me.dgvFacturasSaldoEnvio.DataSource = Me.FacturasSaldoEnvioBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturasSaldoEnvio.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvFacturasSaldoEnvio.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvFacturasSaldoEnvio.GridColor = System.Drawing.SystemColors.Control
        Me.dgvFacturasSaldoEnvio.Location = New System.Drawing.Point(3, 3)
        Me.dgvFacturasSaldoEnvio.MultiSelect = False
        Me.dgvFacturasSaldoEnvio.Name = "dgvFacturasSaldoEnvio"
        Me.dgvFacturasSaldoEnvio.ReadOnly = True
        Me.dgvFacturasSaldoEnvio.RowHeadersVisible = False
        Me.dgvFacturasSaldoEnvio.RowHeadersWidth = 187
        Me.dgvFacturasSaldoEnvio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvFacturasSaldoEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturasSaldoEnvio.Size = New System.Drawing.Size(220, 550)
        Me.dgvFacturasSaldoEnvio.TabIndex = 2
        '
        'NOMBRECLIENTEDataGridViewTextBoxColumn
        '
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NOMBRECLIENTE"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.HeaderText = "Cliente"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.Name = "NOMBRECLIENTEDataGridViewTextBoxColumn"
        Me.NOMBRECLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'NUMVENTADataGridViewTextBoxColumn
        '
        Me.NUMVENTADataGridViewTextBoxColumn.DataPropertyName = "NUMVENTA"
        Me.NUMVENTADataGridViewTextBoxColumn.HeaderText = "Nro. Venta"
        Me.NUMVENTADataGridViewTextBoxColumn.Name = "NUMVENTADataGridViewTextBoxColumn"
        Me.NUMVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODVENTADataGridViewTextBoxColumn
        '
        Me.CODVENTADataGridViewTextBoxColumn.DataPropertyName = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.HeaderText = "CODVENTA"
        Me.CODVENTADataGridViewTextBoxColumn.Name = "CODVENTADataGridViewTextBoxColumn"
        Me.CODVENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODVENTADataGridViewTextBoxColumn.Visible = False
        '
        'RUCCLIENTE
        '
        Me.RUCCLIENTE.DataPropertyName = "RUCCLIENTE"
        Me.RUCCLIENTE.HeaderText = "RUCCLIENTE"
        Me.RUCCLIENTE.Name = "RUCCLIENTE"
        Me.RUCCLIENTE.ReadOnly = True
        Me.RUCCLIENTE.Visible = False
        '
        'CODCLIENTE
        '
        Me.CODCLIENTE.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTE.HeaderText = "CODCLIENTE"
        Me.CODCLIENTE.Name = "CODCLIENTE"
        Me.CODCLIENTE.ReadOnly = True
        Me.CODCLIENTE.Visible = False
        '
        'FacturasSaldoEnvioBindingSource
        '
        Me.FacturasSaldoEnvioBindingSource.DataMember = "FACTURASCONSALDOENVIO"
        Me.FacturasSaldoEnvioBindingSource.DataSource = Me.DsEnvios
        '
        'DsEnvios
        '
        Me.DsEnvios.DataSetName = "DsEnvios"
        Me.DsEnvios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TableLayoutPanel4)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitContainer2.Panel2.Controls.Add(Me.pnlNroFactura)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel2.Controls.Add(Me.cmbDeposito)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.txtNroEnvio)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.tbxNombreCliente)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TxtNumCliente)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dgvEnvioDetalle)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.dtpFechaVto)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(789, 595)
        Me.SplitContainer2.SplitterDistance = 203
        Me.SplitContainer2.TabIndex = 557
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.Silver
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.dgvEnviosXFactura, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 595.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(203, 595)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'dgvEnviosXFactura
        '
        Me.dgvEnviosXFactura.AllowUserToAddRows = False
        Me.dgvEnviosXFactura.AllowUserToDeleteRows = False
        Me.dgvEnviosXFactura.AllowUserToResizeRows = False
        Me.dgvEnviosXFactura.AutoGenerateColumns = False
        Me.dgvEnviosXFactura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEnviosXFactura.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnviosXFactura.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEnviosXFactura.ColumnHeadersHeight = 35
        Me.dgvEnviosXFactura.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAENVIODataGridViewTextBoxColumn, Me.RUC, Me.VEHICULO, Me.CHAPA, Me.DIRECCION, Me.Chofer, Me.NROENVIODataGridViewTextBoxColumn, Me.CODENVIODataGridViewTextBoxColumn, Me.CODCLIENTEDataGridViewTextBoxColumn, Me.CODDEPOSITODataGridViewTextBoxColumn, Me.ESTADO})
        Me.dgvEnviosXFactura.DataSource = Me.EnviosBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnviosXFactura.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvEnviosXFactura.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEnviosXFactura.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvEnviosXFactura.Location = New System.Drawing.Point(3, 3)
        Me.dgvEnviosXFactura.MultiSelect = False
        Me.dgvEnviosXFactura.Name = "dgvEnviosXFactura"
        Me.dgvEnviosXFactura.ReadOnly = True
        Me.dgvEnviosXFactura.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnviosXFactura.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEnviosXFactura.RowHeadersVisible = False
        Me.dgvEnviosXFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEnviosXFactura.Size = New System.Drawing.Size(197, 589)
        Me.dgvEnviosXFactura.TabIndex = 239
        '
        'FECHAENVIODataGridViewTextBoxColumn
        '
        Me.FECHAENVIODataGridViewTextBoxColumn.DataPropertyName = "FECHAENVIO"
        Me.FECHAENVIODataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHAENVIODataGridViewTextBoxColumn.Name = "FECHAENVIODataGridViewTextBoxColumn"
        Me.FECHAENVIODataGridViewTextBoxColumn.ReadOnly = True
        '
        'RUC
        '
        Me.RUC.DataPropertyName = "RUC"
        Me.RUC.HeaderText = "RUC"
        Me.RUC.Name = "RUC"
        Me.RUC.ReadOnly = True
        Me.RUC.Visible = False
        '
        'VEHICULO
        '
        Me.VEHICULO.DataPropertyName = "VEHICULO"
        Me.VEHICULO.HeaderText = "VEHICULO"
        Me.VEHICULO.Name = "VEHICULO"
        Me.VEHICULO.ReadOnly = True
        Me.VEHICULO.Visible = False
        '
        'CHAPA
        '
        Me.CHAPA.DataPropertyName = "CHAPA"
        Me.CHAPA.HeaderText = "CHAPA"
        Me.CHAPA.Name = "CHAPA"
        Me.CHAPA.ReadOnly = True
        Me.CHAPA.Visible = False
        '
        'DIRECCION
        '
        Me.DIRECCION.DataPropertyName = "DIRECCION"
        Me.DIRECCION.HeaderText = "DIRECCION"
        Me.DIRECCION.Name = "DIRECCION"
        Me.DIRECCION.ReadOnly = True
        Me.DIRECCION.Visible = False
        '
        'Chofer
        '
        Me.Chofer.DataPropertyName = "Expr1"
        Me.Chofer.HeaderText = "Chofer"
        Me.Chofer.Name = "Chofer"
        Me.Chofer.ReadOnly = True
        Me.Chofer.Visible = False
        '
        'NROENVIODataGridViewTextBoxColumn
        '
        Me.NROENVIODataGridViewTextBoxColumn.DataPropertyName = "NROENVIO"
        Me.NROENVIODataGridViewTextBoxColumn.HeaderText = "Nro. Envío"
        Me.NROENVIODataGridViewTextBoxColumn.Name = "NROENVIODataGridViewTextBoxColumn"
        Me.NROENVIODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODENVIODataGridViewTextBoxColumn
        '
        Me.CODENVIODataGridViewTextBoxColumn.DataPropertyName = "CODENVIO"
        Me.CODENVIODataGridViewTextBoxColumn.HeaderText = "CODENVIO"
        Me.CODENVIODataGridViewTextBoxColumn.Name = "CODENVIODataGridViewTextBoxColumn"
        Me.CODENVIODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODENVIODataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CODDEPOSITODataGridViewTextBoxColumn
        '
        Me.CODDEPOSITODataGridViewTextBoxColumn.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.Name = "CODDEPOSITODataGridViewTextBoxColumn"
        Me.CODDEPOSITODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODDEPOSITODataGridViewTextBoxColumn.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'EnviosBindingSource
        '
        Me.EnviosBindingSource.DataMember = "ENVIOS"
        Me.EnviosBindingSource.DataSource = Me.DsEnvios
        '
        'pnlNroFactura
        '
        Me.pnlNroFactura.BackColor = System.Drawing.Color.Orange
        Me.pnlNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlNroFactura.Controls.Add(Me.Label7)
        Me.pnlNroFactura.Controls.Add(Me.btnContinuar)
        Me.pnlNroFactura.Controls.Add(Me.tbxRemNroFactura)
        Me.pnlNroFactura.Controls.Add(Me.Label6)
        Me.pnlNroFactura.Location = New System.Drawing.Point(154, 50)
        Me.pnlNroFactura.Name = "pnlNroFactura"
        Me.pnlNroFactura.Size = New System.Drawing.Size(423, 78)
        Me.pnlNroFactura.TabIndex = 572
        Me.pnlNroFactura.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Nro de Factura:"
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnContinuar.Location = New System.Drawing.Point(307, 37)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(108, 23)
        Me.btnContinuar.TabIndex = 2
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'tbxRemNroFactura
        '
        Me.tbxRemNroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRemNroFactura.Location = New System.Drawing.Point(115, 39)
        Me.tbxRemNroFactura.Name = "tbxRemNroFactura"
        Me.tbxRemNroFactura.Size = New System.Drawing.Size(186, 20)
        Me.tbxRemNroFactura.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, CType(0, Byte), True)
        Me.Label6.Location = New System.Drawing.Point(-2, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(423, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ingrese el Número de factura, caso no desee presione continuar."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(7, 552)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(576, 43)
        Me.Label8.TabIndex = 571
        Me.Label8.Text = "OBS : Para editar el stock a Enviar, doble sobre el campo Enviar.  Sino desea env" & _
    "iar una " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "determinada mercaderia introducir 0 (Cero)"
        '
        'cmbDeposito
        '
        Me.cmbDeposito.CausesValidation = False
        Me.cmbDeposito.DataSource = Me.DEPOSITOBindingSource
        Me.cmbDeposito.DisplayMember = "DESSUCURSAL"
        Me.cmbDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.cmbDeposito.FormattingEnabled = True
        Me.cmbDeposito.Location = New System.Drawing.Point(100, 164)
        Me.cmbDeposito.Name = "cmbDeposito"
        Me.cmbDeposito.Size = New System.Drawing.Size(470, 28)
        Me.cmbDeposito.TabIndex = 566
        Me.cmbDeposito.ValueMember = "CODSUCURSAL"
        '
        'DEPOSITOBindingSource
        '
        Me.DEPOSITOBindingSource.DataMember = "DEPOSITO"
        Me.DEPOSITOBindingSource.DataSource = Me.DsEnvios
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 555
        Me.Label4.Text = "Nro. Remisión:"
        '
        'txtNroEnvio
        '
        Me.txtNroEnvio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNroEnvio.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtNroEnvio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroEnvio.CausesValidation = False
        Me.txtNroEnvio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "NROENVIO", True))
        Me.txtNroEnvio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtNroEnvio.Location = New System.Drawing.Point(100, 93)
        Me.txtNroEnvio.Name = "txtNroEnvio"
        Me.txtNroEnvio.ReadOnly = True
        Me.txtNroEnvio.Size = New System.Drawing.Size(188, 27)
        Me.txtNroEnvio.TabIndex = 554
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 553
        Me.Label1.Text = "Cliente:"
        '
        'tbxNombreCliente
        '
        Me.tbxNombreCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNombreCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNombreCliente.CausesValidation = False
        Me.tbxNombreCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FacturasSaldoEnvioBindingSource, "NOMBRECLIENTE", True))
        Me.tbxNombreCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.tbxNombreCliente.Location = New System.Drawing.Point(196, 57)
        Me.tbxNombreCliente.Multiline = True
        Me.tbxNombreCliente.Name = "tbxNombreCliente"
        Me.tbxNombreCliente.ReadOnly = True
        Me.tbxNombreCliente.Size = New System.Drawing.Size(374, 27)
        Me.tbxNombreCliente.TabIndex = 552
        '
        'TxtNumCliente
        '
        Me.TxtNumCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtNumCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtNumCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumCliente.CausesValidation = False
        Me.TxtNumCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FacturasSaldoEnvioBindingSource, "RUCCLIENTE", True))
        Me.TxtNumCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.TxtNumCliente.Location = New System.Drawing.Point(101, 57)
        Me.TxtNumCliente.Multiline = True
        Me.TxtNumCliente.Name = "TxtNumCliente"
        Me.TxtNumCliente.ReadOnly = True
        Me.TxtNumCliente.Size = New System.Drawing.Size(94, 27)
        Me.TxtNumCliente.TabIndex = 551
        '
        'dgvEnvioDetalle
        '
        Me.dgvEnvioDetalle.AllowUserToAddRows = False
        Me.dgvEnvioDetalle.AllowUserToDeleteRows = False
        Me.dgvEnvioDetalle.AllowUserToResizeRows = False
        Me.dgvEnvioDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEnvioDetalle.AutoGenerateColumns = False
        Me.dgvEnvioDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEnvioDetalle.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvioDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvEnvioDetalle.ColumnHeadersHeight = 35
        Me.dgvEnvioDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMVENTADataGridViewTextBoxColumn1, Me.CODIGODataGridViewTextBoxColumn, Me.PRODUCTODataGridViewTextBoxColumn1, Me.Enviado, Me.CODENVIODETDataGridViewTextBoxColumn, Me.CODENVIODataGridViewTextBoxColumn1, Me.CODCODIGODataGridViewTextBoxColumn1, Me.SALDO, Me.STOCK, Me.ENVIAR})
        Me.dgvEnvioDetalle.DataSource = Me.EnviosDetalleBindingSource
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEnvioDetalle.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgvEnvioDetalle.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvEnvioDetalle.Location = New System.Drawing.Point(5, 205)
        Me.dgvEnvioDetalle.MultiSelect = False
        Me.dgvEnvioDetalle.Name = "dgvEnvioDetalle"
        Me.dgvEnvioDetalle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEnvioDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvEnvioDetalle.RowHeadersVisible = False
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.dgvEnvioDetalle.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvEnvioDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEnvioDetalle.Size = New System.Drawing.Size(569, 345)
        Me.dgvEnvioDetalle.TabIndex = 241
        '
        'NUMVENTADataGridViewTextBoxColumn1
        '
        Me.NUMVENTADataGridViewTextBoxColumn1.DataPropertyName = "NUMVENTA1"
        Me.NUMVENTADataGridViewTextBoxColumn1.FillWeight = 60.0!
        Me.NUMVENTADataGridViewTextBoxColumn1.HeaderText = "Fact"
        Me.NUMVENTADataGridViewTextBoxColumn1.Name = "NUMVENTADataGridViewTextBoxColumn1"
        Me.NUMVENTADataGridViewTextBoxColumn1.ReadOnly = True
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 90.0!
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODUCTODataGridViewTextBoxColumn1
        '
        Me.PRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "PRODUCTO"
        Me.PRODUCTODataGridViewTextBoxColumn1.FillWeight = 200.0!
        Me.PRODUCTODataGridViewTextBoxColumn1.HeaderText = "Producto"
        Me.PRODUCTODataGridViewTextBoxColumn1.Name = "PRODUCTODataGridViewTextBoxColumn1"
        Me.PRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Enviado
        '
        Me.Enviado.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Enviado.DefaultCellStyle = DataGridViewCellStyle7
        Me.Enviado.HeaderText = "Enviado"
        Me.Enviado.Name = "Enviado"
        Me.Enviado.ReadOnly = True
        '
        'CODENVIODETDataGridViewTextBoxColumn
        '
        Me.CODENVIODETDataGridViewTextBoxColumn.DataPropertyName = "CODENVIODET"
        Me.CODENVIODETDataGridViewTextBoxColumn.HeaderText = "CODENVIODET"
        Me.CODENVIODETDataGridViewTextBoxColumn.Name = "CODENVIODETDataGridViewTextBoxColumn"
        Me.CODENVIODETDataGridViewTextBoxColumn.Visible = False
        '
        'CODENVIODataGridViewTextBoxColumn1
        '
        Me.CODENVIODataGridViewTextBoxColumn1.DataPropertyName = "CODENVIO"
        DataGridViewCellStyle8.NullValue = "1"
        Me.CODENVIODataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle8
        Me.CODENVIODataGridViewTextBoxColumn1.HeaderText = "CODENVIO"
        Me.CODENVIODataGridViewTextBoxColumn1.Name = "CODENVIODataGridViewTextBoxColumn1"
        Me.CODENVIODataGridViewTextBoxColumn1.Visible = False
        '
        'CODCODIGODataGridViewTextBoxColumn1
        '
        Me.CODCODIGODataGridViewTextBoxColumn1.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.Name = "CODCODIGODataGridViewTextBoxColumn1"
        Me.CODCODIGODataGridViewTextBoxColumn1.Visible = False
        '
        'SALDO
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.SALDO.DefaultCellStyle = DataGridViewCellStyle9
        Me.SALDO.FillWeight = 60.0!
        Me.SALDO.HeaderText = "Saldo"
        Me.SALDO.Name = "SALDO"
        Me.SALDO.ReadOnly = True
        '
        'STOCK
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.STOCK.DefaultCellStyle = DataGridViewCellStyle10
        Me.STOCK.FillWeight = 60.0!
        Me.STOCK.HeaderText = "Stock"
        Me.STOCK.Name = "STOCK"
        Me.STOCK.ReadOnly = True
        '
        'ENVIAR
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.ENVIAR.DefaultCellStyle = DataGridViewCellStyle11
        Me.ENVIAR.FillWeight = 60.0!
        Me.ENVIAR.HeaderText = "Enviar"
        Me.ENVIAR.Name = "ENVIAR"
        '
        'EnviosDetalleBindingSource
        '
        Me.EnviosDetalleBindingSource.DataMember = "ENVIOSDETALLE"
        Me.EnviosDetalleBindingSource.DataSource = Me.DsEnvios
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 16)
        Me.Label3.TabIndex = 550
        Me.Label3.Text = "Depósito:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 549
        Me.Label2.Text = "Fecha Vto:"
        '
        'dtpFechaVto
        '
        Me.dtpFechaVto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "FECHAENVIO", True))
        Me.dtpFechaVto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVto.Location = New System.Drawing.Point(100, 129)
        Me.dtpFechaVto.Name = "dtpFechaVto"
        Me.dtpFechaVto.Size = New System.Drawing.Size(188, 26)
        Me.dtpFechaVto.TabIndex = 547
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.Panel1.Controls.Add(Me.lblProximoNro)
        Me.Panel1.Controls.Add(Me.LblEstado)
        Me.Panel1.Location = New System.Drawing.Point(-2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(585, 38)
        Me.Panel1.TabIndex = 570
        '
        'lblProximoNro
        '
        Me.lblProximoNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProximoNro.AutoSize = False
        Me.lblProximoNro.BackColor = System.Drawing.Color.Transparent
        Me.lblProximoNro.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblProximoNro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblProximoNro.ForeColor = System.Drawing.Color.RoyalBlue
        Me.lblProximoNro.Location = New System.Drawing.Point(316, 8)
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
        Me.lblProximoNro.Size = New System.Drawing.Size(263, 23)
        Me.lblProximoNro.TabIndex = 466
        Me.lblProximoNro.Text = "Próximo Nro : XXX.XXX.XXXXXXXX"
        Me.lblProximoNro.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblProximoNro.TextWrap = False
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = False
        Me.LblEstado.BackColor = System.Drawing.Color.Transparent
        Me.LblEstado.Font = New System.Drawing.Font("Courier New", 21.75!)
        Me.LblEstado.ForeColor = System.Drawing.Color.Green
        Me.LblEstado.ImageAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.LblEstado.Location = New System.Drawing.Point(5, 5)
        Me.LblEstado.Name = "LblEstado"
        '
        '
        '
        Me.LblEstado.RootElement.ForeColor = System.Drawing.Color.Green
        Me.LblEstado.Size = New System.Drawing.Size(348, 29)
        Me.LblEstado.TabIndex = 452
        Me.LblEstado.Text = "lblEstado"
        Me.LblEstado.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRODUCTOENVIOBindingSource
        '
        Me.PRODUCTOENVIOBindingSource.DataMember = "PRODUCTOENVIO"
        Me.PRODUCTOENVIOBindingSource.DataSource = Me.DsEnvios
        '
        'VENTASBindingSource
        '
        Me.VENTASBindingSource.DataMember = "VENTAS"
        Me.VENTASBindingSource.DataSource = Me.DsEnvios
        '
        'TextBoxCodProducto
        '
        Me.TextBoxCodProducto.Location = New System.Drawing.Point(306, 22)
        Me.TextBoxCodProducto.Name = "TextBoxCodProducto"
        Me.TextBoxCodProducto.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodProducto.TabIndex = 186
        Me.TextBoxCodProducto.TabStop = False
        '
        'TextBoxCodCodigo
        '
        Me.TextBoxCodCodigo.Location = New System.Drawing.Point(342, 22)
        Me.TextBoxCodCodigo.Name = "TextBoxCodCodigo"
        Me.TextBoxCodCodigo.Size = New System.Drawing.Size(30, 20)
        Me.TextBoxCodCodigo.TabIndex = 187
        Me.TextBoxCodCodigo.TabStop = False
        '
        'pnlBotonera
        '
        Me.pnlBotonera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBotonera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBotonera.BackColor = System.Drawing.Color.Black
        Me.pnlBotonera.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.pnlBotonera.Controls.Add(Me.pnlEditBusc)
        Me.pnlBotonera.Location = New System.Drawing.Point(-1, -1)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(1016, 40)
        Me.pnlBotonera.TabIndex = 458
        '
        'pnlEditBusc
        '
        Me.pnlEditBusc.BackColor = System.Drawing.Color.Transparent
        Me.pnlEditBusc.Controls.Add(Me.pbxReimprimir)
        Me.pnlEditBusc.Controls.Add(Me.pbxDatosChofer)
        Me.pnlEditBusc.Controls.Add(Me.PictureBoxMotivoAnulacion)
        Me.pnlEditBusc.Controls.Add(Me.ConfirmarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.PictureBox8)
        Me.pnlEditBusc.Controls.Add(Me.EliminarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.NuevoPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.CancelarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.ModificarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.BuscarTextBox)
        Me.pnlEditBusc.Controls.Add(Me.GuardarPictureBox)
        Me.pnlEditBusc.Location = New System.Drawing.Point(-3, 1)
        Me.pnlEditBusc.Name = "pnlEditBusc"
        Me.pnlEditBusc.Size = New System.Drawing.Size(1052, 38)
        Me.pnlEditBusc.TabIndex = 509
        '
        'pbxReimprimir
        '
        Me.pbxReimprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxReimprimir.BackColor = System.Drawing.Color.Transparent
        Me.pbxReimprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxReimprimir.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.pbxReimprimir.Location = New System.Drawing.Point(876, 2)
        Me.pbxReimprimir.Name = "pbxReimprimir"
        Me.pbxReimprimir.Size = New System.Drawing.Size(35, 35)
        Me.pbxReimprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxReimprimir.TabIndex = 575
        Me.pbxReimprimir.TabStop = False
        '
        'pbxDatosChofer
        '
        Me.pbxDatosChofer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxDatosChofer.BackColor = System.Drawing.Color.Transparent
        Me.pbxDatosChofer.Image = Global.ContaExpress.My.Resources.Resources.Display
        Me.pbxDatosChofer.Location = New System.Drawing.Point(913, 2)
        Me.pbxDatosChofer.Name = "pbxDatosChofer"
        Me.pbxDatosChofer.Size = New System.Drawing.Size(35, 35)
        Me.pbxDatosChofer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDatosChofer.TabIndex = 470
        Me.pbxDatosChofer.TabStop = False
        '
        'PictureBoxMotivoAnulacion
        '
        Me.PictureBoxMotivoAnulacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBoxMotivoAnulacion.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxMotivoAnulacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxMotivoAnulacion.Image = Global.ContaExpress.My.Resources.Resources.AnullOff
        Me.PictureBoxMotivoAnulacion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxMotivoAnulacion.Location = New System.Drawing.Point(983, 2)
        Me.PictureBoxMotivoAnulacion.Name = "PictureBoxMotivoAnulacion"
        Me.PictureBoxMotivoAnulacion.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxMotivoAnulacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxMotivoAnulacion.TabIndex = 574
        Me.PictureBoxMotivoAnulacion.TabStop = False
        '
        'ConfirmarPictureBox
        '
        Me.ConfirmarPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ConfirmarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ConfirmarPictureBox.Enabled = False
        Me.ConfirmarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.ApproveOff
        Me.ConfirmarPictureBox.Location = New System.Drawing.Point(949, 2)
        Me.ConfirmarPictureBox.Name = "ConfirmarPictureBox"
        Me.ConfirmarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ConfirmarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ConfirmarPictureBox.TabIndex = 573
        Me.ConfirmarPictureBox.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(8, 4)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 461
        Me.PictureBox8.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(270, 3)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 456
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(235, 3)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 455
        Me.NuevoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(377, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 459
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(305, 3)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 457
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.CausesValidation = False
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(36, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(193, 30)
        Me.BuscarTextBox.TabIndex = 460
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(341, 3)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 458
        Me.GuardarPictureBox.TabStop = False
        '
        'FACTURASCONSALDOENVIOTableAdapter
        '
        Me.FACTURASCONSALDOENVIOTableAdapter.ClearBeforeFill = True
        '
        'ENVIOSTableAdapter
        '
        Me.ENVIOSTableAdapter.ClearBeforeFill = True
        '
        'ENVIOSDETALLETableAdapter
        '
        Me.ENVIOSDETALLETableAdapter.ClearBeforeFill = True
        '
        'DEPOSITOTableAdapter
        '
        Me.DEPOSITOTableAdapter.ClearBeforeFill = True
        '
        'VENTASTableAdapter
        '
        Me.VENTASTableAdapter.ClearBeforeFill = True
        '
        'ProductoenvioTableAdapter
        '
        Me.ProductoenvioTableAdapter.ClearBeforeFill = True
        '
        'pnlChofer
        '
        Me.pnlChofer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlChofer.BackColor = System.Drawing.Color.DimGray
        Me.pnlChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlChofer.Controls.Add(Me.Label5)
        Me.pnlChofer.Controls.Add(Me.txtDireccion)
        Me.pnlChofer.Controls.Add(Me.txtConductor)
        Me.pnlChofer.Controls.Add(Me.txtNroChapa)
        Me.pnlChofer.Controls.Add(Me.txtVehiculo)
        Me.pnlChofer.Controls.Add(Me.txtRucChofer)
        Me.pnlChofer.Controls.Add(Me.Label13)
        Me.pnlChofer.Controls.Add(Me.Label12)
        Me.pnlChofer.Controls.Add(Me.Label11)
        Me.pnlChofer.Controls.Add(Me.Label10)
        Me.pnlChofer.Controls.Add(Me.Label9)
        Me.pnlChofer.Controls.Add(Me.BtnCerrarAnular)
        Me.pnlChofer.Controls.Add(Me.btnEnviar)
        Me.pnlChofer.Controls.Add(Me.RadLabel1)
        Me.pnlChofer.Location = New System.Drawing.Point(540, 38)
        Me.pnlChofer.Name = "pnlChofer"
        Me.pnlChofer.Size = New System.Drawing.Size(476, 249)
        Me.pnlChofer.TabIndex = 469
        Me.pnlChofer.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(310, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(151, 16)
        Me.Label5.TabIndex = 571
        Me.Label5.Text = "Presione ESC para salir"
        '
        'txtDireccion
        '
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "DIRECCION", True))
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtDireccion.Location = New System.Drawing.Point(165, 196)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(298, 27)
        Me.txtDireccion.TabIndex = 570
        '
        'txtConductor
        '
        Me.txtConductor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConductor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "Expr1", True))
        Me.txtConductor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtConductor.Location = New System.Drawing.Point(165, 159)
        Me.txtConductor.Name = "txtConductor"
        Me.txtConductor.Size = New System.Drawing.Size(298, 27)
        Me.txtConductor.TabIndex = 569
        '
        'txtNroChapa
        '
        Me.txtNroChapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroChapa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "CHAPA", True))
        Me.txtNroChapa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtNroChapa.Location = New System.Drawing.Point(165, 120)
        Me.txtNroChapa.Name = "txtNroChapa"
        Me.txtNroChapa.Size = New System.Drawing.Size(298, 27)
        Me.txtNroChapa.TabIndex = 568
        '
        'txtVehiculo
        '
        Me.txtVehiculo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVehiculo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "VEHICULO", True))
        Me.txtVehiculo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtVehiculo.Location = New System.Drawing.Point(165, 85)
        Me.txtVehiculo.Name = "txtVehiculo"
        Me.txtVehiculo.Size = New System.Drawing.Size(298, 27)
        Me.txtVehiculo.TabIndex = 567
        '
        'txtRucChofer
        '
        Me.txtRucChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRucChofer.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EnviosBindingSource, "RUC", True))
        Me.txtRucChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.txtRucChofer.Location = New System.Drawing.Point(165, 50)
        Me.txtRucChofer.Name = "txtRucChofer"
        Me.txtRucChofer.Size = New System.Drawing.Size(298, 27)
        Me.txtRucChofer.TabIndex = 566
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(9, 201)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(154, 16)
        Me.Label13.TabIndex = 565
        Me.Label13.Text = "Dirección del Conductor:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(84, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(79, 16)
        Me.Label12.TabIndex = 563
        Me.Label12.Text = "Nro. Chapa:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(100, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 16)
        Me.Label11.TabIndex = 561
        Me.Label11.Text = "Vehiculo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(146, 16)
        Me.Label10.TabIndex = 559
        Me.Label10.Text = "Nombre del Conductor:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(91, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 557
        Me.Label9.Text = "C.I. o RUC:"
        '
        'BtnCerrarAnular
        '
        Me.BtnCerrarAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarAnular.Location = New System.Drawing.Point(407, 8)
        Me.BtnCerrarAnular.Name = "BtnCerrarAnular"
        Me.BtnCerrarAnular.Size = New System.Drawing.Size(62, 30)
        Me.BtnCerrarAnular.TabIndex = 427
        Me.BtnCerrarAnular.Text = "Cerrar"
        '
        'btnEnviar
        '
        Me.btnEnviar.DisplayStyle = Telerik.WinControls.DisplayStyle.Text
        Me.btnEnviar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnviar.Location = New System.Drawing.Point(260, 8)
        Me.btnEnviar.Name = "btnEnviar"
        Me.btnEnviar.Size = New System.Drawing.Size(142, 30)
        Me.btnEnviar.TabIndex = 428
        Me.btnEnviar.Text = "Aprobar e Imprimir"
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
        Me.RadLabel1.Size = New System.Drawing.Size(155, 31)
        Me.RadLabel1.TabIndex = 426
        Me.RadLabel1.Text = "Datos del Chofer"
        '
        'Envios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1015, 631)
        Me.Controls.Add(Me.pnlBotonera)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.pnlChofer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Envios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Envios - Nota de Remisión | Cogent SIG"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvFacturasSaldoEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FacturasSaldoEnvioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEnvios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.dgvEnviosXFactura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnviosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNroFactura.ResumeLayout(False)
        Me.pnlNroFactura.PerformLayout()
        CType(Me.DEPOSITOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEnvioDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EnviosDetalleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.lblProximoNro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOENVIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlEditBusc.ResumeLayout(False)
        Me.pnlEditBusc.PerformLayout()
        CType(Me.pbxReimprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDatosChofer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxMotivoAnulacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConfirmarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlChofer.ResumeLayout(False)
        Me.pnlChofer.PerformLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvFacturasSaldoEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents TextBoxCodProducto As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TextBoxCodCodigo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvEnvioDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaVto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents pnlEditBusc As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNroEnvio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxNombreCliente As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumCliente As System.Windows.Forms.TextBox
    'Friend WithEvents txtCantidad As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents FacturasSaldoEnvioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsEnvios As ContaExpress.DsEnvios
    Friend WithEvents FACTURASCONSALDOENVIOTableAdapter As ContaExpress.DsEnviosTableAdapters.FACTURASCONSALDOENVIOTableAdapter
    Friend WithEvents EnviosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ENVIOSTableAdapter As ContaExpress.DsEnviosTableAdapters.ENVIOSTableAdapter
    Friend WithEvents EnviosDetalleBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ENVIOSDETALLETableAdapter As ContaExpress.DsEnviosTableAdapters.ENVIOSDETALLETableAdapter
    Friend WithEvents cmbDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DEPOSITOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DEPOSITOTableAdapter As ContaExpress.DsEnviosTableAdapters.DEPOSITOTableAdapter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NOMBRECLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LblEstado As Telerik.WinControls.UI.RadLabel
    Friend WithEvents PictureBoxMotivoAnulacion As System.Windows.Forms.PictureBox
    Friend WithEvents ConfirmarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents dgvEnviosXFactura As System.Windows.Forms.DataGridView
    Friend WithEvents VENTASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENTASTableAdapter As ContaExpress.DsEnviosTableAdapters.VENTASTableAdapter
    Friend WithEvents ProductoenvioTableAdapter As ContaExpress.DsEnviosTableAdapters.PRODUCTOENVIOTableAdapter
    Friend WithEvents PRODUCTOENVIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents pnlChofer As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrarAnular As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnEnviar As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtRucChofer As System.Windows.Forms.TextBox
    Friend WithEvents txtVehiculo As System.Windows.Forms.TextBox
    Friend WithEvents txtNroChapa As System.Windows.Forms.TextBox
    Friend WithEvents txtConductor As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents pbxDatosChofer As System.Windows.Forms.PictureBox
    Friend WithEvents pbxReimprimir As System.Windows.Forms.PictureBox
    Friend WithEvents FECHAENVIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VEHICULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CHAPA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chofer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROENVIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODENVIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENTADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Enviado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODENVIODETDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODENVIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ENVIAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbnFaltanEnviar As System.Windows.Forms.RadioButton
    Friend WithEvents rbnEnviados As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblProximoNro As Telerik.WinControls.UI.RadLabel
    Friend WithEvents pnlNroFactura As System.Windows.Forms.Panel
    Friend WithEvents tbxRemNroFactura As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    'Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
End Class
