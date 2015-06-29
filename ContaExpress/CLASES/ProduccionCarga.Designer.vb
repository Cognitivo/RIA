<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProduccionCarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProduccionCarga))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAprobarProduccion = New System.Windows.Forms.PictureBox()
        Me.btnAnularProduccion = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.PRODUCCIONCABBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.UNIDADMEDIDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRODUCCIONDETBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlProductos = New System.Windows.Forms.Panel()
        Me.btnCerrarPanel = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtBuscarProducto = New System.Windows.Forms.TextBox()
        Me.dgvProducto = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SERVICIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRODUCCIONCABTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONCABTableAdapter()
        Me.PRODUCCIONDETTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCTOSTableAdapter()
        Me.CodCodigoDetalleProducto = New System.Windows.Forms.TextBox()
        Me.UNIDADMEDIDATableAdapter = New ContaExpress.DsProduccionTableAdapters.UNIDADMEDIDATableAdapter()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.pnlCargaProduccion = New System.Windows.Forms.Panel()
        Me.tabMateriales = New System.Windows.Forms.TabControl()
        Me.tabMatCompartidos = New System.Windows.Forms.TabPage()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCantidadConsumo = New System.Windows.Forms.TextBox()
        Me.txtCodigoItem = New System.Windows.Forms.TextBox()
        Me.dgvOperacion = New System.Windows.Forms.DataGridView()
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIDADMEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDRELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPORELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTOTALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADOGRILLA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodCodigoOperacionDetalle = New System.Windows.Forms.TextBox()
        Me.tabMatSeparados = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPRODCABDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCCIONDETPRODUCTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduccion1 = New ContaExpress.DsProduccion()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.SUCURSALTableAdapter = New ContaExpress.DsProduccionTableAdapters.SUCURSALTableAdapter()
        Me.pnlMotivoAnulacion = New System.Windows.Forms.Panel()
        Me.txtMotivoAnulacion = New System.Windows.Forms.RichTextBox()
        Me.BtnCerrarAnular = New Telerik.WinControls.UI.RadButton()
        Me.BtnAnular = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.TableAdapterManager = New ContaExpress.DsProduccionTableAdapters.TableAdapterManager()
        Me.pnlProduccionCab = New System.Windows.Forms.Panel()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.cbxDeposito = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripProduccion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.txtPlanilla = New System.Windows.Forms.TextBox()
        Me.PRODUCCIONDETPRODUCTOTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETPRODUCTOTableAdapter()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.IDPRODCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINICIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvDetalleProduccion = New System.Windows.Forms.DataGridView()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        CType(Me.btnAprobarProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAnularProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONDETBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProductos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCargaProduccion.SuspendLayout()
        Me.tabMateriales.SuspendLayout()
        Me.tabMatCompartidos.SuspendLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONDETPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMotivoAnulacion.SuspendLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnAnular, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProduccionCab.SuspendLayout()
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.btnAprobarProduccion)
        Me.Panel1.Controls.Add(Me.btnAnularProduccion)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(0, -4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1093, 58)
        Me.Panel1.TabIndex = 456
        '
        'btnAprobarProduccion
        '
        Me.btnAprobarProduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAprobarProduccion.BackColor = System.Drawing.Color.Black
        Me.btnAprobarProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAprobarProduccion.Image = Global.ContaExpress.My.Resources.Resources.ApproveOff
        Me.btnAprobarProduccion.Location = New System.Drawing.Point(844, 11)
        Me.btnAprobarProduccion.Name = "btnAprobarProduccion"
        Me.btnAprobarProduccion.Size = New System.Drawing.Size(40, 40)
        Me.btnAprobarProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAprobarProduccion.TabIndex = 455
        Me.btnAprobarProduccion.TabStop = False
        '
        'btnAnularProduccion
        '
        Me.btnAnularProduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnularProduccion.BackColor = System.Drawing.Color.Black
        Me.btnAnularProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAnularProduccion.Image = Global.ContaExpress.My.Resources.Resources.AnullOff
        Me.btnAnularProduccion.Location = New System.Drawing.Point(888, 11)
        Me.btnAnularProduccion.Name = "btnAnularProduccion"
        Me.btnAnularProduccion.Size = New System.Drawing.Size(40, 40)
        Me.btnAnularProduccion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAnularProduccion.TabIndex = 456
        Me.btnAnularProduccion.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox8.BackgroundImage = CType(resources.GetObject("PictureBox8.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(4, 16)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 454
        Me.PictureBox8.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarPictureBox.Image = CType(resources.GetObject("EliminarPictureBox.Image"), System.Drawing.Image)
        Me.EliminarPictureBox.Location = New System.Drawing.Point(297, 11)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoPictureBox.Image = CType(resources.GetObject("NuevoPictureBox.Image"), System.Drawing.Image)
        Me.NuevoPictureBox.Location = New System.Drawing.Point(254, 11)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = CType(resources.GetObject("CancelarPictureBox.Image"), System.Drawing.Image)
        Me.CancelarPictureBox.Location = New System.Drawing.Point(428, 11)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarPictureBox.Image = CType(resources.GetObject("ModificarPictureBox.Image"), System.Drawing.Image)
        Me.ModificarPictureBox.Location = New System.Drawing.Point(340, 11)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.DimGray
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(35, 16)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(203, 30)
        Me.BuscarTextBox.TabIndex = 16
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = CType(resources.GetObject("GuardarPictureBox.Image"), System.Drawing.Image)
        Me.GuardarPictureBox.Location = New System.Drawing.Point(384, 11)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'PRODUCCIONCABBindingSource
        '
        Me.PRODUCCIONCABBindingSource.DataMember = "PRODUCCIONCAB"
        Me.PRODUCCIONCABBindingSource.DataSource = Me.DsProduccion
        '
        'DsProduccion
        '
        Me.DsProduccion.DataSetName = "DsProduccion"
        Me.DsProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UNIDADMEDIDABindingSource
        '
        Me.UNIDADMEDIDABindingSource.DataMember = "UNIDADMEDIDA"
        Me.UNIDADMEDIDABindingSource.DataSource = Me.DsProduccion
        '
        'PRODUCCIONDETBindingSource
        '
        Me.PRODUCCIONDETBindingSource.DataMember = "PRODUCCIONDET"
        Me.PRODUCCIONDETBindingSource.DataSource = Me.DsProduccion
        '
        'pnlProductos
        '
        Me.pnlProductos.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.pnlProductos.Controls.Add(Me.btnCerrarPanel)
        Me.pnlProductos.Controls.Add(Me.PictureBox1)
        Me.pnlProductos.Controls.Add(Me.txtBuscarProducto)
        Me.pnlProductos.Controls.Add(Me.dgvProducto)
        Me.pnlProductos.Location = New System.Drawing.Point(542, 219)
        Me.pnlProductos.Name = "pnlProductos"
        Me.pnlProductos.Size = New System.Drawing.Size(323, 386)
        Me.pnlProductos.TabIndex = 466
        Me.pnlProductos.Visible = False
        '
        'btnCerrarPanel
        '
        Me.btnCerrarPanel.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCerrarPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrarPanel.Location = New System.Drawing.Point(290, 12)
        Me.btnCerrarPanel.Name = "btnCerrarPanel"
        Me.btnCerrarPanel.Size = New System.Drawing.Size(19, 28)
        Me.btnCerrarPanel.TabIndex = 458
        Me.btnCerrarPanel.Text = "X"
        Me.btnCerrarPanel.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(12, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.TabIndex = 456
        Me.PictureBox1.TabStop = False
        '
        'txtBuscarProducto
        '
        Me.txtBuscarProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtBuscarProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarProducto.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarProducto.Location = New System.Drawing.Point(42, 11)
        Me.txtBuscarProducto.Name = "txtBuscarProducto"
        Me.txtBuscarProducto.Size = New System.Drawing.Size(245, 30)
        Me.txtBuscarProducto.TabIndex = 455
        '
        'dgvProducto
        '
        Me.dgvProducto.AllowUserToAddRows = False
        Me.dgvProducto.AllowUserToDeleteRows = False
        Me.dgvProducto.AllowUserToResizeColumns = False
        Me.dgvProducto.AllowUserToResizeRows = False
        Me.dgvProducto.AutoGenerateColumns = False
        Me.dgvProducto.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvProducto.ColumnHeadersHeight = 28
        Me.dgvProducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.CODCODIGO, Me.DESPRODUCTODataGridViewTextBoxColumn1, Me.SERVICIODataGridViewTextBoxColumn, Me.CODPRODUCTODataGridViewTextBoxColumn, Me.DESMEDIDA})
        Me.dgvProducto.DataSource = Me.PRODUCTOSBindingSource
        Me.dgvProducto.Location = New System.Drawing.Point(12, 44)
        Me.dgvProducto.Name = "dgvProducto"
        Me.dgvProducto.ReadOnly = True
        Me.dgvProducto.RowHeadersVisible = False
        Me.dgvProducto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProducto.Size = New System.Drawing.Size(300, 332)
        Me.dgvProducto.TabIndex = 0
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODCODIGO
        '
        Me.CODCODIGO.DataPropertyName = "CODCODIGO"
        Me.CODCODIGO.HeaderText = "CODCODIGO"
        Me.CODCODIGO.Name = "CODCODIGO"
        Me.CODCODIGO.ReadOnly = True
        Me.CODCODIGO.Visible = False
        '
        'DESPRODUCTODataGridViewTextBoxColumn1
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.HeaderText = "Descripcion"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.Name = "DESPRODUCTODataGridViewTextBoxColumn1"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        Me.DESPRODUCTODataGridViewTextBoxColumn1.Width = 180
        '
        'SERVICIODataGridViewTextBoxColumn
        '
        Me.SERVICIODataGridViewTextBoxColumn.DataPropertyName = "SERVICIO"
        Me.SERVICIODataGridViewTextBoxColumn.HeaderText = "SERVICIO"
        Me.SERVICIODataGridViewTextBoxColumn.Name = "SERVICIODataGridViewTextBoxColumn"
        Me.SERVICIODataGridViewTextBoxColumn.ReadOnly = True
        Me.SERVICIODataGridViewTextBoxColumn.Visible = False
        '
        'CODPRODUCTODataGridViewTextBoxColumn
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Name = "CODPRODUCTODataGridViewTextBoxColumn"
        Me.CODPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODUCTODataGridViewTextBoxColumn.Visible = False
        '
        'DESMEDIDA
        '
        Me.DESMEDIDA.DataPropertyName = "DESMEDIDA"
        Me.DESMEDIDA.HeaderText = "DESMEDIDA"
        Me.DESMEDIDA.Name = "DESMEDIDA"
        Me.DESMEDIDA.ReadOnly = True
        Me.DESMEDIDA.Visible = False
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProduccion
        '
        'PRODUCCIONCABTableAdapter
        '
        Me.PRODUCCIONCABTableAdapter.ClearBeforeFill = True
        '
        'PRODUCCIONDETTableAdapter
        '
        Me.PRODUCCIONDETTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'CodCodigoDetalleProducto
        '
        Me.CodCodigoDetalleProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.CodCodigoDetalleProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CodCodigoDetalleProducto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "CODCODIGO", True))
        Me.CodCodigoDetalleProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodCodigoDetalleProducto.Location = New System.Drawing.Point(856, 96)
        Me.CodCodigoDetalleProducto.Name = "CodCodigoDetalleProducto"
        Me.CodCodigoDetalleProducto.Size = New System.Drawing.Size(54, 26)
        Me.CodCodigoDetalleProducto.TabIndex = 474
        '
        'UNIDADMEDIDATableAdapter
        '
        Me.UNIDADMEDIDATableAdapter.ClearBeforeFill = True
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsProduccion
        '
        'pnlCargaProduccion
        '
        Me.pnlCargaProduccion.BackColor = System.Drawing.SystemColors.GrayText
        Me.pnlCargaProduccion.Controls.Add(Me.tabMateriales)
        Me.pnlCargaProduccion.Controls.Add(Me.Label13)
        Me.pnlCargaProduccion.Controls.Add(Me.TextBox6)
        Me.pnlCargaProduccion.Controls.Add(Me.Label4)
        Me.pnlCargaProduccion.Controls.Add(Me.Button1)
        Me.pnlCargaProduccion.Controls.Add(Me.Button2)
        Me.pnlCargaProduccion.Controls.Add(Me.DataGridView1)
        Me.pnlCargaProduccion.Controls.Add(Me.TextBox2)
        Me.pnlCargaProduccion.Controls.Add(Me.TextBox3)
        Me.pnlCargaProduccion.Controls.Add(Me.Label5)
        Me.pnlCargaProduccion.Controls.Add(Me.Label12)
        Me.pnlCargaProduccion.Controls.Add(Me.TextBox4)
        Me.pnlCargaProduccion.Controls.Add(Me.Label1)
        Me.pnlCargaProduccion.Controls.Add(Me.txtEstado)
        Me.pnlCargaProduccion.Location = New System.Drawing.Point(245, 202)
        Me.pnlCargaProduccion.Name = "pnlCargaProduccion"
        Me.pnlCargaProduccion.Size = New System.Drawing.Size(692, 465)
        Me.pnlCargaProduccion.TabIndex = 472
        '
        'tabMateriales
        '
        Me.tabMateriales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabMateriales.Controls.Add(Me.tabMatCompartidos)
        Me.tabMateriales.Controls.Add(Me.tabMatSeparados)
        Me.tabMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.tabMateriales.Location = New System.Drawing.Point(11, 216)
        Me.tabMateriales.Name = "tabMateriales"
        Me.tabMateriales.SelectedIndex = 0
        Me.tabMateriales.Size = New System.Drawing.Size(671, 244)
        Me.tabMateriales.TabIndex = 490
        '
        'tabMatCompartidos
        '
        Me.tabMatCompartidos.BackColor = System.Drawing.Color.Transparent
        Me.tabMatCompartidos.Controls.Add(Me.cmbCategoria)
        Me.tabMatCompartidos.Controls.Add(Me.txtDescripcion)
        Me.tabMatCompartidos.Controls.Add(Me.txtCantidadConsumo)
        Me.tabMatCompartidos.Controls.Add(Me.txtCodigoItem)
        Me.tabMatCompartidos.Controls.Add(Me.dgvOperacion)
        Me.tabMatCompartidos.Controls.Add(Me.Label2)
        Me.tabMatCompartidos.Controls.Add(Me.Label14)
        Me.tabMatCompartidos.Controls.Add(Me.Button3)
        Me.tabMatCompartidos.Controls.Add(Me.Button4)
        Me.tabMatCompartidos.Controls.Add(Me.Label8)
        Me.tabMatCompartidos.Controls.Add(Me.Label6)
        Me.tabMatCompartidos.Controls.Add(Me.txtCodCodigoOperacionDetalle)
        Me.tabMatCompartidos.Location = New System.Drawing.Point(4, 24)
        Me.tabMatCompartidos.Name = "tabMatCompartidos"
        Me.tabMatCompartidos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMatCompartidos.Size = New System.Drawing.Size(663, 216)
        Me.tabMatCompartidos.TabIndex = 0
        Me.tabMatCompartidos.Text = "Materiales Compartidos"
        '
        'cmbCategoria
        '
        Me.cmbCategoria.BackColor = System.Drawing.Color.Gainsboro
        Me.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cmbCategoria.FormattingEnabled = True
        Me.cmbCategoria.Items.AddRange(New Object() {"Producto", "Servicio", "Producto Producido", "Materia Prima"})
        Me.cmbCategoria.Location = New System.Drawing.Point(6, 22)
        Me.cmbCategoria.Name = "cmbCategoria"
        Me.cmbCategoria.Size = New System.Drawing.Size(157, 24)
        Me.cmbCategoria.TabIndex = 468
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtDescripcion.Location = New System.Drawing.Point(278, 22)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(236, 25)
        Me.txtDescripcion.TabIndex = 481
        '
        'txtCantidadConsumo
        '
        Me.txtCantidadConsumo.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCantidadConsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadConsumo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCantidadConsumo.Location = New System.Drawing.Point(516, 22)
        Me.txtCantidadConsumo.Multiline = True
        Me.txtCantidadConsumo.Name = "txtCantidadConsumo"
        Me.txtCantidadConsumo.Size = New System.Drawing.Size(83, 25)
        Me.txtCantidadConsumo.TabIndex = 479
        '
        'txtCodigoItem
        '
        Me.txtCodigoItem.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigoItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtCodigoItem.Location = New System.Drawing.Point(167, 22)
        Me.txtCodigoItem.Multiline = True
        Me.txtCodigoItem.Name = "txtCodigoItem"
        Me.txtCodigoItem.Size = New System.Drawing.Size(109, 25)
        Me.txtCodigoItem.TabIndex = 476
        '
        'dgvOperacion
        '
        Me.dgvOperacion.AllowUserToAddRows = False
        Me.dgvOperacion.AllowUserToDeleteRows = False
        Me.dgvOperacion.AllowUserToResizeColumns = False
        Me.dgvOperacion.AllowUserToResizeRows = False
        Me.dgvOperacion.AutoGenerateColumns = False
        Me.dgvOperacion.ColumnHeadersHeight = 25
        Me.dgvOperacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.UNIDADMEDIDA, Me.IDRELACIONDataGridViewTextBoxColumn, Me.CODTIPORELACIONDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.SUBTOTALDataGridViewTextBoxColumn, Me.ESTADOGRILLA})
        Me.dgvOperacion.DataSource = Me.PRODUCCIONDETBindingSource
        Me.dgvOperacion.Location = New System.Drawing.Point(6, 52)
        Me.dgvOperacion.Name = "dgvOperacion"
        Me.dgvOperacion.ReadOnly = True
        Me.dgvOperacion.RowHeadersVisible = False
        Me.dgvOperacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvOperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacion.ShowCellErrors = False
        Me.dgvOperacion.ShowRowErrors = False
        Me.dgvOperacion.Size = New System.Drawing.Size(652, 158)
        Me.dgvOperacion.TabIndex = 491
        '
        'DESCRIPTIPORELACIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPTIPORELACION"
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn.HeaderText = "Categoria"
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn.Name = "DESCRIPTIPORELACIONDataGridViewTextBoxColumn"
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn.Width = 140
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Item"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DESPRODUCTODataGridViewTextBoxColumn.Width = 350
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "Consumo"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 80
        '
        'UNIDADMEDIDA
        '
        Me.UNIDADMEDIDA.DataPropertyName = "UNIDADMEDIDA"
        Me.UNIDADMEDIDA.HeaderText = "Medida"
        Me.UNIDADMEDIDA.Name = "UNIDADMEDIDA"
        Me.UNIDADMEDIDA.ReadOnly = True
        Me.UNIDADMEDIDA.Width = 65
        '
        'IDRELACIONDataGridViewTextBoxColumn
        '
        Me.IDRELACIONDataGridViewTextBoxColumn.DataPropertyName = "IDRELACION"
        Me.IDRELACIONDataGridViewTextBoxColumn.HeaderText = "IDRELACION"
        Me.IDRELACIONDataGridViewTextBoxColumn.Name = "IDRELACIONDataGridViewTextBoxColumn"
        Me.IDRELACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDRELACIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODTIPORELACIONDataGridViewTextBoxColumn
        '
        Me.CODTIPORELACIONDataGridViewTextBoxColumn.DataPropertyName = "CODTIPORELACION"
        Me.CODTIPORELACIONDataGridViewTextBoxColumn.HeaderText = "CODTIPORELACION"
        Me.CODTIPORELACIONDataGridViewTextBoxColumn.Name = "CODTIPORELACIONDataGridViewTextBoxColumn"
        Me.CODTIPORELACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODTIPORELACIONDataGridViewTextBoxColumn.Visible = False
        '
        'COSTODataGridViewTextBoxColumn
        '
        Me.COSTODataGridViewTextBoxColumn.DataPropertyName = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "COSTO"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.ReadOnly = True
        Me.COSTODataGridViewTextBoxColumn.Visible = False
        '
        'SUBTOTALDataGridViewTextBoxColumn
        '
        Me.SUBTOTALDataGridViewTextBoxColumn.DataPropertyName = "SUBTOTAL"
        Me.SUBTOTALDataGridViewTextBoxColumn.HeaderText = "SUBTOTAL"
        Me.SUBTOTALDataGridViewTextBoxColumn.Name = "SUBTOTALDataGridViewTextBoxColumn"
        Me.SUBTOTALDataGridViewTextBoxColumn.ReadOnly = True
        Me.SUBTOTALDataGridViewTextBoxColumn.Visible = False
        '
        'ESTADOGRILLA
        '
        Me.ESTADOGRILLA.HeaderText = "ESTADOGRILLA"
        Me.ESTADOGRILLA.Name = "ESTADOGRILLA"
        Me.ESTADOGRILLA.ReadOnly = True
        Me.ESTADOGRILLA.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(10, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 490
        Me.Label2.Text = "Categoria"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label14.Location = New System.Drawing.Point(278, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 17)
        Me.Label14.TabIndex = 489
        Me.Label14.Text = "Descripción"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gainsboro
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button3.Location = New System.Drawing.Point(604, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(55, 21)
        Me.Button3.TabIndex = 488
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Button4.Location = New System.Drawing.Point(604, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(55, 24)
        Me.Button4.TabIndex = 487
        Me.Button4.Text = "Agregar"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(515, 3)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 17)
        Me.Label8.TabIndex = 480
        Me.Label8.Text = "Consumo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(168, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 477
        Me.Label6.Text = "Código"
        '
        'txtCodCodigoOperacionDetalle
        '
        Me.txtCodCodigoOperacionDetalle.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodCodigoOperacionDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodCodigoOperacionDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.txtCodCodigoOperacionDetalle.Location = New System.Drawing.Point(224, 24)
        Me.txtCodCodigoOperacionDetalle.Name = "txtCodCodigoOperacionDetalle"
        Me.txtCodCodigoOperacionDetalle.Size = New System.Drawing.Size(37, 20)
        Me.txtCodCodigoOperacionDetalle.TabIndex = 478
        '
        'tabMatSeparados
        '
        Me.tabMatSeparados.BackColor = System.Drawing.Color.Gainsboro
        Me.tabMatSeparados.Location = New System.Drawing.Point(4, 24)
        Me.tabMatSeparados.Name = "tabMatSeparados"
        Me.tabMatSeparados.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMatSeparados.Size = New System.Drawing.Size(663, 216)
        Me.tabMatSeparados.TabIndex = 1
        Me.tabMatSeparados.Text = "Materiales Separados"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label13.Location = New System.Drawing.Point(150, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 17)
        Me.Label13.TabIndex = 489
        Me.Label13.Text = "Descripción"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(540, 51)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(82, 29)
        Me.TextBox6.TabIndex = 487
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(540, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 17)
        Me.Label4.TabIndex = 488
        Me.Label4.Text = "Peso"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(626, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 21)
        Me.Button1.TabIndex = 486
        Me.Button1.Text = "Eliminar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gainsboro
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(626, 32)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 24)
        Me.Button2.TabIndex = 483
        Me.Button2.Text = "Agregar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeight = 25
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCODIGODataGridViewTextBoxColumn, Me.IDPRODCABDataGridViewTextBoxColumn, Me.CODIGODataGridViewTextBoxColumn1, Me.DESCRIPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn1, Me.PESODataGridViewTextBoxColumn, Me.DESMEDIDADataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.PRODUCCIONDETPRODUCTOBindingSource
        Me.DataGridView1.Location = New System.Drawing.Point(10, 81)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.ShowCellErrors = False
        Me.DataGridView1.ShowRowErrors = False
        Me.DataGridView1.Size = New System.Drawing.Size(672, 130)
        Me.DataGridView1.TabIndex = 478
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCODIGODataGridViewTextBoxColumn.Visible = False
        '
        'IDPRODCABDataGridViewTextBoxColumn
        '
        Me.IDPRODCABDataGridViewTextBoxColumn.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn.HeaderText = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn.Name = "IDPRODCABDataGridViewTextBoxColumn"
        Me.IDPRODCABDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDPRODCABDataGridViewTextBoxColumn.Visible = False
        '
        'CODIGODataGridViewTextBoxColumn1
        '
        Me.CODIGODataGridViewTextBoxColumn1.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn1.HeaderText = "Código"
        Me.CODIGODataGridViewTextBoxColumn1.Name = "CODIGODataGridViewTextBoxColumn1"
        Me.CODIGODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DESCRIPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESCRIPRODUCTO"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.Name = "DESCRIPRODUCTODataGridViewTextBoxColumn"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.Width = 300
        '
        'CANTIDADDataGridViewTextBoxColumn1
        '
        Me.CANTIDADDataGridViewTextBoxColumn1.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn1.HeaderText = "Cantidad"
        Me.CANTIDADDataGridViewTextBoxColumn1.Name = "CANTIDADDataGridViewTextBoxColumn1"
        Me.CANTIDADDataGridViewTextBoxColumn1.ReadOnly = True
        Me.CANTIDADDataGridViewTextBoxColumn1.Width = 80
        '
        'PESODataGridViewTextBoxColumn
        '
        Me.PESODataGridViewTextBoxColumn.DataPropertyName = "PESO"
        Me.PESODataGridViewTextBoxColumn.HeaderText = "Peso"
        Me.PESODataGridViewTextBoxColumn.Name = "PESODataGridViewTextBoxColumn"
        Me.PESODataGridViewTextBoxColumn.ReadOnly = True
        Me.PESODataGridViewTextBoxColumn.Width = 80
        '
        'DESMEDIDADataGridViewTextBoxColumn
        '
        Me.DESMEDIDADataGridViewTextBoxColumn.DataPropertyName = "DESMEDIDA"
        Me.DESMEDIDADataGridViewTextBoxColumn.HeaderText = "Medida"
        Me.DESMEDIDADataGridViewTextBoxColumn.Name = "DESMEDIDADataGridViewTextBoxColumn"
        Me.DESMEDIDADataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRODUCCIONDETPRODUCTOBindingSource
        '
        Me.PRODUCCIONDETPRODUCTOBindingSource.DataMember = "PRODUCCIONDETPRODUCTO"
        Me.PRODUCCIONDETPRODUCTOBindingSource.DataSource = Me.DsProduccion1
        '
        'DsProduccion1
        '
        Me.DsProduccion1.DataSetName = "DsProduccion"
        Me.DsProduccion1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(456, 51)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(82, 29)
        Me.TextBox2.TabIndex = 481
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(151, 51)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(303, 29)
        Me.TextBox3.TabIndex = 480
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(457, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 17)
        Me.Label5.TabIndex = 485
        Me.Label5.Text = "Cantidad"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label12.Location = New System.Drawing.Point(10, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 17)
        Me.Label12.TabIndex = 484
        Me.Label12.Text = "Código"
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(10, 51)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(140, 29)
        Me.TextBox4.TabIndex = 479
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(195, 24)
        Me.Label1.TabIndex = 477
        Me.Label1.Text = "Cargar de Producción"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "ESTADO", True))
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(224, -29)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(42, 26)
        Me.txtEstado.TabIndex = 475
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'pnlMotivoAnulacion
        '
        Me.pnlMotivoAnulacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMotivoAnulacion.BackColor = System.Drawing.Color.Maroon
        Me.pnlMotivoAnulacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMotivoAnulacion.Controls.Add(Me.txtMotivoAnulacion)
        Me.pnlMotivoAnulacion.Controls.Add(Me.BtnCerrarAnular)
        Me.pnlMotivoAnulacion.Controls.Add(Me.BtnAnular)
        Me.pnlMotivoAnulacion.Controls.Add(Me.RadLabel1)
        Me.pnlMotivoAnulacion.Location = New System.Drawing.Point(563, 63)
        Me.pnlMotivoAnulacion.Name = "pnlMotivoAnulacion"
        Me.pnlMotivoAnulacion.Size = New System.Drawing.Size(372, 166)
        Me.pnlMotivoAnulacion.TabIndex = 476
        Me.pnlMotivoAnulacion.Visible = False
        '
        'txtMotivoAnulacion
        '
        Me.txtMotivoAnulacion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtMotivoAnulacion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMotivoAnulacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "MOTIVOANULADO", True))
        Me.txtMotivoAnulacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtMotivoAnulacion.Location = New System.Drawing.Point(9, 35)
        Me.txtMotivoAnulacion.Name = "txtMotivoAnulacion"
        Me.txtMotivoAnulacion.Size = New System.Drawing.Size(354, 121)
        Me.txtMotivoAnulacion.TabIndex = 454
        Me.txtMotivoAnulacion.Text = ""
        '
        'BtnCerrarAnular
        '
        Me.BtnCerrarAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrarAnular.Location = New System.Drawing.Point(301, 6)
        Me.BtnCerrarAnular.Name = "BtnCerrarAnular"
        Me.BtnCerrarAnular.Size = New System.Drawing.Size(62, 26)
        Me.BtnCerrarAnular.TabIndex = 427
        Me.BtnCerrarAnular.Text = "Cerrar"
        '
        'BtnAnular
        '
        Me.BtnAnular.DisplayStyle = Telerik.WinControls.DisplayStyle.Text
        Me.BtnAnular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAnular.Location = New System.Drawing.Point(207, 6)
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
        Me.RadLabel1.Location = New System.Drawing.Point(4, 2)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.RadLabel1.Size = New System.Drawing.Size(188, 31)
        Me.RadLabel1.TabIndex = 426
        Me.RadLabel1.Text = "Motivo de Anulación"
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.SUCURSALTableAdapter = Me.SUCURSALTableAdapter
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Me.UNIDADMEDIDATableAdapter
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProduccionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'pnlProduccionCab
        '
        Me.pnlProduccionCab.BackColor = System.Drawing.SystemColors.GrayText
        Me.pnlProduccionCab.Controls.Add(Me.lblUsuario)
        Me.pnlProduccionCab.Controls.Add(Me.cbxDeposito)
        Me.pnlProduccionCab.Controls.Add(Me.Label7)
        Me.pnlProduccionCab.Controls.Add(Me.Label11)
        Me.pnlProduccionCab.Controls.Add(Me.dtpFecha)
        Me.pnlProduccionCab.Controls.Add(Me.lblFecha)
        Me.pnlProduccionCab.Controls.Add(Me.Label3)
        Me.pnlProduccionCab.Controls.Add(Me.Label10)
        Me.pnlProduccionCab.Controls.Add(Me.txtDescripProduccion)
        Me.pnlProduccionCab.Controls.Add(Me.Label9)
        Me.pnlProduccionCab.Controls.Add(Me.TextBox5)
        Me.pnlProduccionCab.Location = New System.Drawing.Point(246, 60)
        Me.pnlProduccionCab.Name = "pnlProduccionCab"
        Me.pnlProduccionCab.Size = New System.Drawing.Size(692, 140)
        Me.pnlProduccionCab.TabIndex = 477
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblUsuario.Location = New System.Drawing.Point(101, 113)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(131, 17)
        Me.lblUsuario.TabIndex = 486
        Me.lblUsuario.Text = "Nombre de Usuario"
        '
        'cbxDeposito
        '
        Me.cbxDeposito.BackColor = System.Drawing.Color.Gainsboro
        Me.cbxDeposito.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCCIONCABBindingSource, "CODSUCURSAL", True))
        Me.cbxDeposito.DataSource = Me.SUCURSALBindingSource
        Me.cbxDeposito.DisplayMember = "DESSUCURSAL"
        Me.cbxDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDeposito.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cbxDeposito.FormattingEnabled = True
        Me.cbxDeposito.Location = New System.Drawing.Point(101, 73)
        Me.cbxDeposito.Name = "cbxDeposito"
        Me.cbxDeposito.Size = New System.Drawing.Size(351, 26)
        Me.cbxDeposito.TabIndex = 484
        Me.cbxDeposito.ValueMember = "CODSUCURSAL"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label7.Location = New System.Drawing.Point(23, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 17)
        Me.Label7.TabIndex = 485
        Me.Label7.Text = "Deposito :"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(409, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(267, 24)
        Me.Label11.TabIndex = 483
        Me.Label11.Text = "Pendiente"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "FECHAINICIO", True))
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(539, 103)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(142, 26)
        Me.dtpFecha.TabIndex = 481
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblFecha.Location = New System.Drawing.Point(438, 68)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(59, 17)
        Me.lblFecha.TabIndex = 482
        Me.lblFecha.Text = "Fecha  :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(30, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 480
        Me.Label3.Text = "Usuario :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label10.Location = New System.Drawing.Point(7, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 17)
        Me.Label10.TabIndex = 478
        Me.Label10.Text = "Descripción:"
        '
        'txtDescripProduccion
        '
        Me.txtDescripProduccion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDescripProduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripProduccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "CODIGO", True))
        Me.txtDescripProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripProduccion.Location = New System.Drawing.Point(99, 39)
        Me.txtDescripProduccion.Name = "txtDescripProduccion"
        Me.txtDescripProduccion.Size = New System.Drawing.Size(577, 26)
        Me.txtDescripProduccion.TabIndex = 477
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(4, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(278, 24)
        Me.Label9.TabIndex = 476
        Me.Label9.Text = "Datos Generales de Producción"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.Color.Gainsboro
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "ESTADO", True))
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(224, -29)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(42, 26)
        Me.TextBox5.TabIndex = 475
        '
        'txtPlanilla
        '
        Me.txtPlanilla.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlanilla.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "IDPRODCAB", True))
        Me.txtPlanilla.Enabled = False
        Me.txtPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanilla.Location = New System.Drawing.Point(757, 151)
        Me.txtPlanilla.Name = "txtPlanilla"
        Me.txtPlanilla.Size = New System.Drawing.Size(55, 26)
        Me.txtPlanilla.TabIndex = 480
        '
        'PRODUCCIONDETPRODUCTOTableAdapter
        '
        Me.PRODUCCIONDETPRODUCTOTableAdapter.ClearBeforeFill = True
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Location = New System.Drawing.Point(186, 57)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(54, 28)
        Me.btnAgregar.TabIndex = 457
        Me.btnAgregar.Text = "Filtrar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'IDPRODCAB
        '
        Me.IDPRODCAB.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCAB.HeaderText = "IDPRODCAB"
        Me.IDPRODCAB.Name = "IDPRODCAB"
        Me.IDPRODCAB.ReadOnly = True
        Me.IDPRODCAB.Visible = False
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.HeaderText = "Descripción"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        Me.DESCRIPCION.Width = 140
        '
        'FECHAINICIODataGridViewTextBoxColumn
        '
        Me.FECHAINICIODataGridViewTextBoxColumn.DataPropertyName = "FECHAINICIO"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FECHAINICIODataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.FECHAINICIODataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHAINICIODataGridViewTextBoxColumn.Name = "FECHAINICIODataGridViewTextBoxColumn"
        Me.FECHAINICIODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAINICIODataGridViewTextBoxColumn.Width = 80
        '
        'dgvDetalleProduccion
        '
        Me.dgvDetalleProduccion.AllowUserToAddRows = False
        Me.dgvDetalleProduccion.AllowUserToDeleteRows = False
        Me.dgvDetalleProduccion.AllowUserToResizeColumns = False
        Me.dgvDetalleProduccion.AllowUserToResizeRows = False
        Me.dgvDetalleProduccion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvDetalleProduccion.AutoGenerateColumns = False
        Me.dgvDetalleProduccion.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvDetalleProduccion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetalleProduccion.ColumnHeadersHeight = 35
        Me.dgvDetalleProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetalleProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAINICIODataGridViewTextBoxColumn, Me.DESCRIPCION, Me.IDPRODCAB})
        Me.dgvDetalleProduccion.DataSource = Me.PRODUCCIONCABBindingSource
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleProduccion.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalleProduccion.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvDetalleProduccion.Location = New System.Drawing.Point(4, 88)
        Me.dgvDetalleProduccion.MultiSelect = False
        Me.dgvDetalleProduccion.Name = "dgvDetalleProduccion"
        Me.dgvDetalleProduccion.ReadOnly = True
        Me.dgvDetalleProduccion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalleProduccion.RowHeadersVisible = False
        Me.dgvDetalleProduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetalleProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleProduccion.ShowCellErrors = False
        Me.dgvDetalleProduccion.ShowRowErrors = False
        Me.dgvDetalleProduccion.Size = New System.Drawing.Size(235, 581)
        Me.dgvDetalleProduccion.TabIndex = 469
        '
        'CmbMes
        '
        Me.CmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.CmbMes.Location = New System.Drawing.Point(5, 58)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(99, 26)
        Me.CmbMes.TabIndex = 470
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cmbAño.Location = New System.Drawing.Point(109, 58)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(72, 26)
        Me.cmbAño.TabIndex = 471
        '
        'ProduccionCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(942, 673)
        Me.Controls.Add(Me.pnlCargaProduccion)
        Me.Controls.Add(Me.cmbAño)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.txtPlanilla)
        Me.Controls.Add(Me.dgvDetalleProduccion)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CodCodigoDetalleProducto)
        Me.Controls.Add(Me.pnlProductos)
        Me.Controls.Add(Me.pnlMotivoAnulacion)
        Me.Controls.Add(Me.pnlProduccionCab)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ProduccionCarga"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Producción Alimenticia"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.btnAprobarProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAnularProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONDETBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProductos.ResumeLayout(False)
        Me.pnlProductos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCargaProduccion.ResumeLayout(False)
        Me.pnlCargaProduccion.PerformLayout()
        Me.tabMateriales.ResumeLayout(False)
        Me.tabMatCompartidos.ResumeLayout(False)
        Me.tabMatCompartidos.PerformLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONDETPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMotivoAnulacion.ResumeLayout(False)
        Me.pnlMotivoAnulacion.PerformLayout()
        CType(Me.BtnCerrarAnular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnAnular, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProduccionCab.ResumeLayout(False)
        Me.pnlProduccionCab.PerformLayout()
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pnlProductos As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscarProducto As System.Windows.Forms.TextBox
    Friend WithEvents dgvProducto As System.Windows.Forms.DataGridView
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents PRODUCCIONCABBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCCIONCABTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCCIONCABTableAdapter
    Friend WithEvents PRODUCCIONDETBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCCIONDETTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETTableAdapter
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents CodCodigoDetalleProducto As System.Windows.Forms.TextBox
    Friend WithEvents UNIDADMEDIDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents UNIDADMEDIDATableAdapter As ContaExpress.DsProduccionTableAdapters.UNIDADMEDIDATableAdapter
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SERVICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCerrarPanel As System.Windows.Forms.Button
    Friend WithEvents btnAprobarProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents btnAnularProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCargaProduccion As System.Windows.Forms.Panel
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsProduccionTableAdapters.SUCURSALTableAdapter
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents pnlMotivoAnulacion As System.Windows.Forms.Panel
    Friend WithEvents txtMotivoAnulacion As System.Windows.Forms.RichTextBox
    Friend WithEvents BtnCerrarAnular As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnAnular As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TableAdapterManager As ContaExpress.DsProduccionTableAdapters.TableAdapterManager
    Friend WithEvents pnlProduccionCab As System.Windows.Forms.Panel
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents cbxDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescripProduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub ProduccionCarga_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents tabMateriales As System.Windows.Forms.TabControl
    Friend WithEvents tabMatCompartidos As System.Windows.Forms.TabPage
    Friend WithEvents tabMatSeparados As System.Windows.Forms.TabPage
    Friend WithEvents DsProduccion1 As ContaExpress.DsProduccion
    Friend WithEvents PRODUCCIONDETPRODUCTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCCIONDETPRODUCTOTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETPRODUCTOTableAdapter
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPRODCABDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadConsumo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoItem As System.Windows.Forms.TextBox
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtCodCodigoOperacionDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label

    Private Sub Label14_Click(sender As System.Object, e As System.EventArgs) Handles Label14.Click

    End Sub
    Friend WithEvents dgvOperacion As System.Windows.Forms.DataGridView
    Friend WithEvents DESCRIPTIPORELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDADMEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDRELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPORELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTOTALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADOGRILLA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents IDPRODCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvDetalleProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
End Class
