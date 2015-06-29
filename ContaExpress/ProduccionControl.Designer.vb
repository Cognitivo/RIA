<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProduccionControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProduccionControl))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.dgvDetalleProduccion = New System.Windows.Forms.DataGridView()
        Me.FECHAINICIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPRODCABDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADODECRIP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDPRODCAB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEVENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAFINDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCCIONCABBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvOperacion = New System.Windows.Forms.DataGridView()
        Me.PRODUCCIONDETBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.UNIDADMEDIDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.txtPlanilla = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.PRODUCCIONCABTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONCABTableAdapter()
        Me.PRODUCCIONDETTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCCIONDETTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCTOSTableAdapter()
        Me.CodCodigoDetalleProducto = New System.Windows.Forms.TextBox()
        Me.UNIDADMEDIDATableAdapter = New ContaExpress.DsProduccionTableAdapters.UNIDADMEDIDATableAdapter()
        Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UNIDADMEDIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDRELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPORELACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTOTALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCCIONDETBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(0, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(945, 50)
        Me.Panel1.TabIndex = 456
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox3.Enabled = False
        Me.PictureBox3.Image = Global.ContaExpress.My.Resources.Resources.Anull
        Me.PictureBox3.Location = New System.Drawing.Point(896, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 456
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Enabled = False
        Me.PictureBox2.Image = Global.ContaExpress.My.Resources.Resources.Approve
        Me.PictureBox2.Location = New System.Drawing.Point(850, 6)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 40)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 455
        Me.PictureBox2.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox8.BackgroundImage = CType(resources.GetObject("PictureBox8.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(0, 9)
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
        Me.EliminarPictureBox.Location = New System.Drawing.Point(288, 5)
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
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.NewOff
        Me.NuevoPictureBox.Location = New System.Drawing.Point(245, 5)
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
        Me.CancelarPictureBox.Location = New System.Drawing.Point(419, 5)
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
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.EditOff
        Me.ModificarPictureBox.Location = New System.Drawing.Point(331, 5)
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
        Me.BuscarTextBox.Location = New System.Drawing.Point(31, 9)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(208, 30)
        Me.BuscarTextBox.TabIndex = 16
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = CType(resources.GetObject("GuardarPictureBox.Image"), System.Drawing.Image)
        Me.GuardarPictureBox.Location = New System.Drawing.Point(375, 5)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(40, 40)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblEstado.Location = New System.Drawing.Point(245, 53)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(115, 32)
        Me.lblEstado.TabIndex = 455
        Me.lblEstado.Text = "Pendiente"
        Me.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Location = New System.Drawing.Point(185, 55)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(54, 28)
        Me.btnAgregar.TabIndex = 457
        Me.btnAgregar.Text = "Filtrar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"2000", "2001", "2002", "2003", "2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cmbAño.Location = New System.Drawing.Point(107, 56)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(72, 26)
        Me.cmbAño.TabIndex = 471
        '
        'CmbMes
        '
        Me.CmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.CmbMes.Location = New System.Drawing.Point(3, 56)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(99, 26)
        Me.CmbMes.TabIndex = 470
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
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvDetalleProduccion.ColumnHeadersHeight = 35
        Me.dgvDetalleProduccion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvDetalleProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAINICIODataGridViewTextBoxColumn, Me.IDPRODCABDataGridViewTextBoxColumn, Me.ESTADODECRIP, Me.ESTADODataGridViewTextBoxColumn, Me.DESUSUARIO, Me.IDPRODCAB, Me.DESCRIPRODUCTO, Me.CANTIDAD, Me.CODIGO, Me.DataGridViewTextBoxColumn1, Me.DESCRIPCIONDataGridViewTextBoxColumn, Me.CODEVENTODataGridViewTextBoxColumn, Me.FECHAFINDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn})
        Me.dgvDetalleProduccion.DataSource = Me.PRODUCCIONCABBindingSource
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalleProduccion.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvDetalleProduccion.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvDetalleProduccion.Location = New System.Drawing.Point(0, 87)
        Me.dgvDetalleProduccion.MultiSelect = False
        Me.dgvDetalleProduccion.Name = "dgvDetalleProduccion"
        Me.dgvDetalleProduccion.ReadOnly = True
        Me.dgvDetalleProduccion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalleProduccion.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDetalleProduccion.RowHeadersVisible = False
        Me.dgvDetalleProduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvDetalleProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalleProduccion.Size = New System.Drawing.Size(239, 570)
        Me.dgvDetalleProduccion.TabIndex = 469
        '
        'FECHAINICIODataGridViewTextBoxColumn
        '
        Me.FECHAINICIODataGridViewTextBoxColumn.DataPropertyName = "FECHAINICIO"
        Me.FECHAINICIODataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHAINICIODataGridViewTextBoxColumn.Name = "FECHAINICIODataGridViewTextBoxColumn"
        Me.FECHAINICIODataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAINICIODataGridViewTextBoxColumn.Width = 90
        '
        'IDPRODCABDataGridViewTextBoxColumn
        '
        Me.IDPRODCABDataGridViewTextBoxColumn.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCABDataGridViewTextBoxColumn.HeaderText = "Plantilla"
        Me.IDPRODCABDataGridViewTextBoxColumn.Name = "IDPRODCABDataGridViewTextBoxColumn"
        Me.IDPRODCABDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDPRODCABDataGridViewTextBoxColumn.Width = 60
        '
        'ESTADODECRIP
        '
        Me.ESTADODECRIP.DataPropertyName = "ESTADODECRIP"
        Me.ESTADODECRIP.HeaderText = "Estado"
        Me.ESTADODECRIP.Name = "ESTADODECRIP"
        Me.ESTADODECRIP.ReadOnly = True
        '
        'ESTADODataGridViewTextBoxColumn
        '
        Me.ESTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.HeaderText = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.Name = "ESTADODataGridViewTextBoxColumn"
        Me.ESTADODataGridViewTextBoxColumn.ReadOnly = True
        Me.ESTADODataGridViewTextBoxColumn.Visible = False
        '
        'DESUSUARIO
        '
        Me.DESUSUARIO.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIO.HeaderText = "DESUSUARIO"
        Me.DESUSUARIO.Name = "DESUSUARIO"
        Me.DESUSUARIO.ReadOnly = True
        Me.DESUSUARIO.Visible = False
        '
        'IDPRODCAB
        '
        Me.IDPRODCAB.DataPropertyName = "IDPRODCAB"
        Me.IDPRODCAB.HeaderText = "IDPRODCAB"
        Me.IDPRODCAB.Name = "IDPRODCAB"
        Me.IDPRODCAB.ReadOnly = True
        Me.IDPRODCAB.Visible = False
        '
        'DESCRIPRODUCTO
        '
        Me.DESCRIPRODUCTO.DataPropertyName = "DESCRIPRODUCTO"
        Me.DESCRIPRODUCTO.HeaderText = "DESCRIPRODUCTO"
        Me.DESCRIPRODUCTO.Name = "DESCRIPRODUCTO"
        Me.DESCRIPRODUCTO.ReadOnly = True
        Me.DESCRIPRODUCTO.Visible = False
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD.HeaderText = "CANTIDAD"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Visible = False
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "CODIGO"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        Me.CODIGO.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "DESUSUARIO"
        Me.DataGridViewTextBoxColumn1.HeaderText = "DESUSUARIO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DESCRIPCIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Name = "DESCRIPCIONDataGridViewTextBoxColumn"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODEVENTODataGridViewTextBoxColumn
        '
        Me.CODEVENTODataGridViewTextBoxColumn.DataPropertyName = "CODEVENTO"
        Me.CODEVENTODataGridViewTextBoxColumn.HeaderText = "CODEVENTO"
        Me.CODEVENTODataGridViewTextBoxColumn.Name = "CODEVENTODataGridViewTextBoxColumn"
        Me.CODEVENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODEVENTODataGridViewTextBoxColumn.Visible = False
        '
        'FECHAFINDataGridViewTextBoxColumn
        '
        Me.FECHAFINDataGridViewTextBoxColumn.DataPropertyName = "FECHAFIN"
        Me.FECHAFINDataGridViewTextBoxColumn.HeaderText = "FECHAFIN"
        Me.FECHAFINDataGridViewTextBoxColumn.Name = "FECHAFINDataGridViewTextBoxColumn"
        Me.FECHAFINDataGridViewTextBoxColumn.ReadOnly = True
        Me.FECHAFINDataGridViewTextBoxColumn.Visible = False
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        Me.CODUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn.Visible = False
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
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel3.Controls.Add(Me.dgvOperacion)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(940, 657)
        Me.Panel3.TabIndex = 473
        '
        'dgvOperacion
        '
        Me.dgvOperacion.AllowUserToAddRows = False
        Me.dgvOperacion.AllowUserToDeleteRows = False
        Me.dgvOperacion.AllowUserToResizeColumns = False
        Me.dgvOperacion.AllowUserToResizeRows = False
        Me.dgvOperacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOperacion.AutoGenerateColumns = False
        Me.dgvOperacion.ColumnHeadersHeight = 35
        Me.dgvOperacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESCRIPTIPORELACIONDataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.UNIDADMEDIDA, Me.IDRELACIONDataGridViewTextBoxColumn, Me.CODTIPORELACIONDataGridViewTextBoxColumn, Me.COSTODataGridViewTextBoxColumn, Me.SUBTOTALDataGridViewTextBoxColumn})
        Me.dgvOperacion.DataSource = Me.PRODUCCIONDETBindingSource
        Me.dgvOperacion.Location = New System.Drawing.Point(244, 235)
        Me.dgvOperacion.Name = "dgvOperacion"
        Me.dgvOperacion.ReadOnly = True
        Me.dgvOperacion.RowHeadersVisible = False
        Me.dgvOperacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvOperacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOperacion.Size = New System.Drawing.Size(692, 250)
        Me.dgvOperacion.TabIndex = 0
        '
        'PRODUCCIONDETBindingSource
        '
        Me.PRODUCCIONDETBindingSource.DataMember = "PRODUCCIONDET"
        Me.PRODUCCIONDETBindingSource.DataSource = Me.DsProduccion
        '
        'UNIDADMEDIDABindingSource
        '
        Me.UNIDADMEDIDABindingSource.DataMember = "UNIDADMEDIDA"
        Me.UNIDADMEDIDABindingSource.DataSource = Me.DsProduccion
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProduccion
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dtpFecha)
        Me.Panel2.Controls.Add(Me.txtProducto)
        Me.Panel2.Controls.Add(Me.txtcantidad)
        Me.Panel2.Controls.Add(Me.txtPlanilla)
        Me.Panel2.Controls.Add(Me.lblUsuario)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.txtCodigo)
        Me.Panel2.Location = New System.Drawing.Point(244, 87)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(692, 140)
        Me.Panel2.TabIndex = 472
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(411, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Usuario :"
        '
        'dtpFecha
        '
        Me.dtpFecha.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "FECHAINICIO", True))
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(89, 41)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(151, 26)
        Me.dtpFecha.TabIndex = 3
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "DESCRIPRODUCTO", True))
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProducto.Location = New System.Drawing.Point(243, 73)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(432, 26)
        Me.txtProducto.TabIndex = 2
        '
        'txtcantidad
        '
        Me.txtcantidad.BackColor = System.Drawing.Color.Gainsboro
        Me.txtcantidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcantidad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "CANTIDAD", True))
        Me.txtcantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcantidad.Location = New System.Drawing.Point(89, 104)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(151, 26)
        Me.txtcantidad.TabIndex = 2
        '
        'txtPlanilla
        '
        Me.txtPlanilla.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlanilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlanilla.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "IDPRODCAB", True))
        Me.txtPlanilla.Enabled = False
        Me.txtPlanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanilla.Location = New System.Drawing.Point(89, 10)
        Me.txtPlanilla.Name = "txtPlanilla"
        Me.txtPlanilla.Size = New System.Drawing.Size(151, 26)
        Me.txtPlanilla.TabIndex = 17
        '
        'lblUsuario
        '
        Me.lblUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "DESUSUARIO", True))
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(471, 12)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(218, 20)
        Me.lblUsuario.TabIndex = 16
        Me.lblUsuario.Text = "Label10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(17, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Producto:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblFecha.Location = New System.Drawing.Point(32, 47)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(55, 17)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(19, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Cantidad:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Planilla Nº :"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCCIONCABBindingSource, "CODIGO", True))
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(89, 73)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(151, 26)
        Me.txtCodigo.TabIndex = 1
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
        Me.DESPRODUCTODataGridViewTextBoxColumn.Width = 200
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "Consumo"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADDataGridViewTextBoxColumn.Width = 50
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
        Me.COSTODataGridViewTextBoxColumn.HeaderText = "Costo Unitario"
        Me.COSTODataGridViewTextBoxColumn.Name = "COSTODataGridViewTextBoxColumn"
        Me.COSTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'SUBTOTALDataGridViewTextBoxColumn
        '
        Me.SUBTOTALDataGridViewTextBoxColumn.DataPropertyName = "SUBTOTAL"
        Me.SUBTOTALDataGridViewTextBoxColumn.HeaderText = "Costo Real"
        Me.SUBTOTALDataGridViewTextBoxColumn.Name = "SUBTOTALDataGridViewTextBoxColumn"
        Me.SUBTOTALDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProduccionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.ClientSize = New System.Drawing.Size(940, 657)
        Me.Controls.Add(Me.cmbAño)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.dgvDetalleProduccion)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CodCodigoDetalleProducto)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Panel3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ProduccionControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de Produccion - Pos Express"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalleProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONCABBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCCIONDETBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents CmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents dgvDetalleProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvOperacion As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtcantidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPlanilla As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
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
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPRODCABDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODECRIP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPRODCAB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEVENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAFINDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DESCRIPTIPORELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UNIDADMEDIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDRELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPORELACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTOTALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
