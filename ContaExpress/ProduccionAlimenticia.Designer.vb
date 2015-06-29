<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProduccionAlimenticia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProduccionAlimenticia))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.dgvDetalleProduccion = New System.Windows.Forms.DataGridView()
        Me.FECHAINICIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPRODCABDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCCIONCABBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlProduccionCab = New System.Windows.Forms.Panel()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.cbxDeposito = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDescripProduccion = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.pnlCargaProduccion = New System.Windows.Forms.Panel()
        Me.tabMateriales = New System.Windows.Forms.TabControl()
        Me.tabMatCompartidos = New System.Windows.Forms.TabPage()
        Me.cmbCategoria = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCantidadConsumo = New System.Windows.Forms.TextBox()
        Me.txtCodigoItem = New System.Windows.Forms.TextBox()
        Me.dgvOperacion = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCodCodigoOperacionDetalle = New System.Windows.Forms.TextBox()
        Me.tabMatSeparados = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtPesoProducto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAliminarProducto = New System.Windows.Forms.Button()
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PESODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMEDIDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPRODCABDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCCIONDETPRODUCTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCantidadProducto = New System.Windows.Forms.TextBox()
        Me.txtDescripProducto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCodigoProducto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.PRODUCCIONCABTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONCABTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsProduccionTableAdapters.SUCURSALTableAdapter()
        Me.txtPlanilla = New System.Windows.Forms.TextBox()
        Me.PRODUCCIONDETPRODUCTOTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETPRODUCTOTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.btnAprobarProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAnularProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProduccionCab.SuspendLayout()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCargaProduccion.SuspendLayout()
        Me.tabMateriales.SuspendLayout()
        Me.tabMatCompartidos.SuspendLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONDETPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Location = New System.Drawing.Point(0, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 58)
        Me.Panel1.TabIndex = 457
        '
        'btnAprobarProduccion
        '
        Me.btnAprobarProduccion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAprobarProduccion.BackColor = System.Drawing.Color.Black
        Me.btnAprobarProduccion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAprobarProduccion.Image = Global.ContaExpress.My.Resources.Resources.ApproveOff
        Me.btnAprobarProduccion.Location = New System.Drawing.Point(849, 11)
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
        Me.btnAnularProduccion.Location = New System.Drawing.Point(893, 11)
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
        Me.EliminarPictureBox.Location = New System.Drawing.Point(290, 11)
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
        Me.NuevoPictureBox.Location = New System.Drawing.Point(247, 11)
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
        Me.CancelarPictureBox.Location = New System.Drawing.Point(421, 11)
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
        Me.ModificarPictureBox.Location = New System.Drawing.Point(333, 11)
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
        Me.GuardarPictureBox.Location = New System.Drawing.Point(377, 11)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cmbAño.Location = New System.Drawing.Point(108, 59)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(72, 26)
        Me.cmbAño.TabIndex = 475
        '
        'CmbMes
        '
        Me.CmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.CmbMes.Location = New System.Drawing.Point(4, 59)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(99, 26)
        Me.CmbMes.TabIndex = 474
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetalleProduccion.ColumnHeadersHeight = 35
        Me.dgvDetalleProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetalleProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAINICIODataGridViewTextBoxColumn, Me.DESCRIPCIONDataGridViewTextBoxColumn, Me.IDPRODCABDataGridViewTextBoxColumn})
        Me.dgvDetalleProduccion.DataSource = Me.PRODUCCIONCABBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleProduccion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetalleProduccion.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvDetalleProduccion.Location = New System.Drawing.Point(3, 89)
        Me.dgvDetalleProduccion.MultiSelect = False
        Me.dgvDetalleProduccion.Name = "dgvDetalleProduccion"
        Me.dgvDetalleProduccion.ReadOnly = True
        Me.dgvDetalleProduccion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalleProduccion.RowHeadersVisible = False
        Me.dgvDetalleProduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetalleProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleProduccion.ShowCellErrors = False
        Me.dgvDetalleProduccion.ShowRowErrors = False
        Me.dgvDetalleProduccion.Size = New System.Drawing.Size(235, 576)
        Me.dgvDetalleProduccion.TabIndex = 473
        '
        'FECHAINICIODataGridViewTextBoxColumn
        '
        Me.FECHAINICIODataGridViewTextBoxColumn.DataPropertyName = "FECHAINICIO"
        Me.FECHAINICIODataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHAINICIODataGridViewTextBoxColumn.Name = "FECHAINICIODataGridViewTextBoxColumn"
        Me.FECHAINICIODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAINICIODataGridViewTextBoxColumn.Width = 80
        '
        'DESCRIPCIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Name = "DESCRIPCIONDataGridViewTextBoxColumn"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Width = 140
        '
        'IDPRODCABDataGridViewTextBoxColumn
        '
        Me.IDPRODCABDataGridViewTextBoxColumn.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn.HeaderText = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn.Name = "IDPRODCABDataGridViewTextBoxColumn"
        Me.IDPRODCABDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDPRODCABDataGridViewTextBoxColumn.Visible = False
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
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Location = New System.Drawing.Point(185, 58)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(54, 28)
        Me.btnAgregar.TabIndex = 472
        Me.btnAgregar.Text = "Filtrar"
        Me.btnAgregar.UseVisualStyleBackColor = False
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
        Me.pnlProduccionCab.Location = New System.Drawing.Point(242, 59)
        Me.pnlProduccionCab.Name = "pnlProduccionCab"
        Me.pnlProduccionCab.Size = New System.Drawing.Size(692, 137)
        Me.pnlProduccionCab.TabIndex = 479
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "NOMBRE", True))
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
        Me.cbxDeposito.TabIndex = 2
        Me.cbxDeposito.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsProduccion
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
        Me.dtpFecha.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblFecha.Location = New System.Drawing.Point(478, 110)
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
        Me.txtDescripProduccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "DESCRIPCION", True))
        Me.txtDescripProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripProduccion.Location = New System.Drawing.Point(99, 39)
        Me.txtDescripProduccion.Name = "txtDescripProduccion"
        Me.txtDescripProduccion.Size = New System.Drawing.Size(577, 26)
        Me.txtDescripProduccion.TabIndex = 1
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
        Me.TextBox5.Enabled = False
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(224, -29)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(42, 26)
        Me.TextBox5.TabIndex = 475
        '
        'pnlCargaProduccion
        '
        Me.pnlCargaProduccion.BackColor = System.Drawing.SystemColors.GrayText
        Me.pnlCargaProduccion.Controls.Add(Me.tabMateriales)
        Me.pnlCargaProduccion.Controls.Add(Me.Label13)
        Me.pnlCargaProduccion.Controls.Add(Me.txtPesoProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.Label4)
        Me.pnlCargaProduccion.Controls.Add(Me.btnAliminarProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.btnAgregarProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.DataGridView1)
        Me.pnlCargaProduccion.Controls.Add(Me.txtCantidadProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.txtDescripProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.Label5)
        Me.pnlCargaProduccion.Controls.Add(Me.Label12)
        Me.pnlCargaProduccion.Controls.Add(Me.txtCodigoProducto)
        Me.pnlCargaProduccion.Controls.Add(Me.Label1)
        Me.pnlCargaProduccion.Controls.Add(Me.txtEstado)
        Me.pnlCargaProduccion.Location = New System.Drawing.Point(241, 201)
        Me.pnlCargaProduccion.Name = "pnlCargaProduccion"
        Me.pnlCargaProduccion.Size = New System.Drawing.Size(694, 465)
        Me.pnlCargaProduccion.TabIndex = 478
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
        Me.tabMateriales.Size = New System.Drawing.Size(673, 244)
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
        Me.tabMatCompartidos.Size = New System.Drawing.Size(665, 216)
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
        Me.cmbCategoria.TabIndex = 8
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
        Me.txtDescripcion.TabIndex = 10
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
        Me.txtCantidadConsumo.TabIndex = 11
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
        Me.txtCodigoItem.TabIndex = 9
        '
        'dgvOperacion
        '
        Me.dgvOperacion.AllowUserToAddRows = False
        Me.dgvOperacion.AllowUserToDeleteRows = False
        Me.dgvOperacion.AllowUserToResizeColumns = False
        Me.dgvOperacion.AllowUserToResizeRows = False
        Me.dgvOperacion.ColumnHeadersHeight = 25
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
        Me.Button4.TabIndex = 12
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
        Me.tabMatSeparados.Size = New System.Drawing.Size(665, 216)
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
        'txtPesoProducto
        '
        Me.txtPesoProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPesoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPesoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoProducto.Location = New System.Drawing.Point(540, 51)
        Me.txtPesoProducto.Name = "txtPesoProducto"
        Me.txtPesoProducto.Size = New System.Drawing.Size(82, 29)
        Me.txtPesoProducto.TabIndex = 7
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
        'btnAliminarProducto
        '
        Me.btnAliminarProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAliminarProducto.Location = New System.Drawing.Point(626, 57)
        Me.btnAliminarProducto.Name = "btnAliminarProducto"
        Me.btnAliminarProducto.Size = New System.Drawing.Size(55, 21)
        Me.btnAliminarProducto.TabIndex = 486
        Me.btnAliminarProducto.Text = "Eliminar"
        Me.btnAliminarProducto.UseVisualStyleBackColor = False
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAgregarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregarProducto.Location = New System.Drawing.Point(626, 32)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(55, 24)
        Me.btnAgregarProducto.TabIndex = 8
        Me.btnAgregarProducto.Text = "Agregar"
        Me.btnAgregarProducto.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeight = 25
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DESCRIPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.PESODataGridViewTextBoxColumn, Me.DESMEDIDADataGridViewTextBoxColumn, Me.CODCODIGODataGridViewTextBoxColumn, Me.IDPRODCABDataGridViewTextBoxColumn1})
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
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigó"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODIGODataGridViewTextBoxColumn.Width = 140
        '
        'DESCRIPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESCRIPRODUCTO"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.HeaderText = "Descripción"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.Name = "DESCRIPRODUCTODataGridViewTextBoxColumn"
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPRODUCTODataGridViewTextBoxColumn.Width = 250
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "Cantidad"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 80
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
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCODIGODataGridViewTextBoxColumn.Visible = False
        '
        'IDPRODCABDataGridViewTextBoxColumn1
        '
        Me.IDPRODCABDataGridViewTextBoxColumn1.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn1.HeaderText = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn1.Name = "IDPRODCABDataGridViewTextBoxColumn1"
        Me.IDPRODCABDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IDPRODCABDataGridViewTextBoxColumn1.Visible = False
        '
        'PRODUCCIONDETPRODUCTOBindingSource
        '
        Me.PRODUCCIONDETPRODUCTOBindingSource.DataMember = "PRODUCCIONDETPRODUCTO"
        Me.PRODUCCIONDETPRODUCTOBindingSource.DataSource = Me.DsProduccion
        '
        'txtCantidadProducto
        '
        Me.txtCantidadProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCantidadProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCantidadProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadProducto.Location = New System.Drawing.Point(456, 51)
        Me.txtCantidadProducto.Name = "txtCantidadProducto"
        Me.txtCantidadProducto.Size = New System.Drawing.Size(82, 29)
        Me.txtCantidadProducto.TabIndex = 6
        '
        'txtDescripProducto
        '
        Me.txtDescripProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDescripProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripProducto.Enabled = False
        Me.txtDescripProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripProducto.Location = New System.Drawing.Point(151, 51)
        Me.txtDescripProducto.Name = "txtDescripProducto"
        Me.txtDescripProducto.Size = New System.Drawing.Size(303, 29)
        Me.txtDescripProducto.TabIndex = 5
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
        'txtCodigoProducto
        '
        Me.txtCodigoProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoProducto.Location = New System.Drawing.Point(10, 51)
        Me.txtCodigoProducto.Name = "txtCodigoProducto"
        Me.txtCodigoProducto.Size = New System.Drawing.Size(140, 29)
        Me.txtCodigoProducto.TabIndex = 4
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
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(224, -29)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(42, 26)
        Me.txtEstado.TabIndex = 475
        '
        'PRODUCCIONCABTableAdapter
        '
        Me.PRODUCCIONCABTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'txtPlanilla
        '
        Me.txtPlanilla.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlanilla.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "IDPRODCAB", True))
        Me.txtPlanilla.Enabled = False
        Me.txtPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanilla.Location = New System.Drawing.Point(445, 162)
        Me.txtPlanilla.Name = "txtPlanilla"
        Me.txtPlanilla.Size = New System.Drawing.Size(55, 26)
        Me.txtPlanilla.TabIndex = 481
        '
        'PRODUCCIONDETPRODUCTOTableAdapter
        '
        Me.PRODUCCIONDETPRODUCTOTableAdapter.ClearBeforeFill = True
        '
        'ProduccionAlimenticia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(941, 671)
        Me.Controls.Add(Me.pnlProduccionCab)
        Me.Controls.Add(Me.pnlCargaProduccion)
        Me.Controls.Add(Me.cmbAño)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.dgvDetalleProduccion)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPlanilla)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ProduccionAlimenticia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produccion Alimenticia"
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
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProduccionCab.ResumeLayout(False)
        Me.pnlProduccionCab.PerformLayout()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCargaProduccion.ResumeLayout(False)
        Me.pnlCargaProduccion.PerformLayout()
        Me.tabMateriales.ResumeLayout(False)
        Me.tabMatCompartidos.ResumeLayout(False)
        Me.tabMatCompartidos.PerformLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONDETPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAprobarProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents btnAnularProduccion As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDetalleProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents pnlProduccionCab As System.Windows.Forms.Panel
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents cbxDeposito As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDescripProduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents pnlCargaProduccion As System.Windows.Forms.Panel
    Friend WithEvents tabMateriales As System.Windows.Forms.TabControl
    Friend WithEvents tabMatCompartidos As System.Windows.Forms.TabPage
    Friend WithEvents cmbCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidadConsumo As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoItem As System.Windows.Forms.TextBox
    Friend WithEvents dgvOperacion As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCodCodigoOperacionDetalle As System.Windows.Forms.TextBox
    Friend WithEvents tabMatSeparados As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtPesoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAliminarProducto As System.Windows.Forms.Button
    Friend WithEvents btnAgregarProducto As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCantidadProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCCIONCABBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents PRODUCCIONCABTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCCIONCABTableAdapter
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPRODCABDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsProduccionTableAdapters.SUCURSALTableAdapter
    Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents PRODUCCIONDETPRODUCTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCCIONDETPRODUCTOTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETPRODUCTOTableAdapter
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PESODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMEDIDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPRODCABDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
