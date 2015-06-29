<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Producto_Serie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Producto_Serie))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBoxNuevo = New System.Windows.Forms.PictureBox()
        Me.PictureBoxEliminar = New System.Windows.Forms.PictureBox()
        Me.PictureBoxModifica = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCancelar = New System.Windows.Forms.PictureBox()
        Me.BuscaProductoTextBox = New System.Windows.Forms.TextBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdproductoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeriedesdeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SeriehastaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrefijoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SerieactualDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOSERIEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSerie1 = New ContaExpress.DsSerie()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CbxProducto = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSerie = New ContaExpress.DsSerie()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsSerieTableAdapters.PRODUCTOSTableAdapter()
        Me.PRODUCTO_SERIETableAdapter = New ContaExpress.DsSerieTableAdapters.PRODUCTO_SERIETableAdapter()
        Me.TbxDesde = New System.Windows.Forms.TextBox()
        Me.TbxHasta = New System.Windows.Forms.TextBox()
        Me.TbxActual = New System.Windows.Forms.TextBox()
        Me.TxbPrefijo = New System.Windows.Forms.TextBox()
        Me.btnAsterisco = New System.Windows.Forms.PictureBox()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.tbxBuscarProductos = New System.Windows.Forms.TextBox()
        Me.dgwProductos = New System.Windows.Forms.DataGridView()
        Me.upcProductos = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.CODPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxModifica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSERIEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSerie1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSerie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAsterisco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.dgwProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.PictureBoxGuardar)
        Me.Panel1.Controls.Add(Me.PictureBoxNuevo)
        Me.Panel1.Controls.Add(Me.PictureBoxEliminar)
        Me.Panel1.Controls.Add(Me.PictureBoxModifica)
        Me.Panel1.Controls.Add(Me.PictureBoxCancelar)
        Me.Panel1.Controls.Add(Me.BuscaProductoTextBox)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 36)
        Me.Panel1.TabIndex = 41
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(2, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 398
        Me.PictureBox1.TabStop = False
        '
        'PictureBoxGuardar
        '
        Me.PictureBoxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxGuardar.Enabled = False
        Me.PictureBoxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.PictureBoxGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxGuardar.Location = New System.Drawing.Point(410, 0)
        Me.PictureBoxGuardar.Name = "PictureBoxGuardar"
        Me.PictureBoxGuardar.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxGuardar.TabIndex = 61
        Me.PictureBoxGuardar.TabStop = False
        '
        'PictureBoxNuevo
        '
        Me.PictureBoxNuevo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxNuevo.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.PictureBoxNuevo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxNuevo.Location = New System.Drawing.Point(308, 0)
        Me.PictureBoxNuevo.Name = "PictureBoxNuevo"
        Me.PictureBoxNuevo.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxNuevo.TabIndex = 54
        Me.PictureBoxNuevo.TabStop = False
        '
        'PictureBoxEliminar
        '
        Me.PictureBoxEliminar.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxEliminar.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.PictureBoxEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxEliminar.Location = New System.Drawing.Point(342, 0)
        Me.PictureBoxEliminar.Name = "PictureBoxEliminar"
        Me.PictureBoxEliminar.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxEliminar.TabIndex = 59
        Me.PictureBoxEliminar.TabStop = False
        '
        'PictureBoxModifica
        '
        Me.PictureBoxModifica.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxModifica.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxModifica.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.PictureBoxModifica.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxModifica.Location = New System.Drawing.Point(376, 0)
        Me.PictureBoxModifica.Name = "PictureBoxModifica"
        Me.PictureBoxModifica.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxModifica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxModifica.TabIndex = 64
        Me.PictureBoxModifica.TabStop = False
        '
        'PictureBoxCancelar
        '
        Me.PictureBoxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCancelar.Enabled = False
        Me.PictureBoxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.PictureBoxCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxCancelar.Location = New System.Drawing.Point(444, 0)
        Me.PictureBoxCancelar.Name = "PictureBoxCancelar"
        Me.PictureBoxCancelar.Size = New System.Drawing.Size(35, 35)
        Me.PictureBoxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxCancelar.TabIndex = 55
        Me.PictureBoxCancelar.TabStop = False
        '
        'BuscaProductoTextBox
        '
        Me.BuscaProductoTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscaProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscaProductoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BuscaProductoTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscaProductoTextBox.Location = New System.Drawing.Point(32, 2)
        Me.BuscaProductoTextBox.Name = "BuscaProductoTextBox"
        Me.BuscaProductoTextBox.Size = New System.Drawing.Size(269, 31)
        Me.BuscaProductoTextBox.TabIndex = 200
        '
        'ProductosGridView
        '
        Me.ProductosGridView.AllowUserToAddRows = False
        Me.ProductosGridView.AllowUserToDeleteRows = False
        Me.ProductosGridView.AllowUserToResizeRows = False
        Me.ProductosGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProductosGridView.AutoGenerateColumns = False
        Me.ProductosGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.ProductosGridView.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductosGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ProductosGridView.ColumnHeadersHeight = 35
        Me.ProductosGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.IdproductoDataGridViewTextBoxColumn, Me.SeriedesdeDataGridViewTextBoxColumn, Me.SeriehastaDataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.PrefijoDataGridViewTextBoxColumn, Me.SerieactualDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn})
        Me.ProductosGridView.DataSource = Me.PRODUCTOSERIEBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ProductosGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProductosGridView.GridColor = System.Drawing.Color.Lavender
        Me.ProductosGridView.Location = New System.Drawing.Point(0, 35)
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.ReadOnly = True
        Me.ProductosGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductosGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.Size = New System.Drawing.Size(301, 337)
        Me.ProductosGridView.TabIndex = 423
        '
        'IdDataGridViewTextBoxColumn
        '
        Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
        Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
        Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
        Me.IdDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdDataGridViewTextBoxColumn.Visible = False
        '
        'IdproductoDataGridViewTextBoxColumn
        '
        Me.IdproductoDataGridViewTextBoxColumn.DataPropertyName = "Id_producto"
        Me.IdproductoDataGridViewTextBoxColumn.HeaderText = "Id_producto"
        Me.IdproductoDataGridViewTextBoxColumn.Name = "IdproductoDataGridViewTextBoxColumn"
        Me.IdproductoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdproductoDataGridViewTextBoxColumn.Visible = False
        '
        'SeriedesdeDataGridViewTextBoxColumn
        '
        Me.SeriedesdeDataGridViewTextBoxColumn.DataPropertyName = "Serie_desde"
        Me.SeriedesdeDataGridViewTextBoxColumn.HeaderText = "Serie_desde"
        Me.SeriedesdeDataGridViewTextBoxColumn.Name = "SeriedesdeDataGridViewTextBoxColumn"
        Me.SeriedesdeDataGridViewTextBoxColumn.ReadOnly = True
        Me.SeriedesdeDataGridViewTextBoxColumn.Visible = False
        '
        'SeriehastaDataGridViewTextBoxColumn
        '
        Me.SeriehastaDataGridViewTextBoxColumn.DataPropertyName = "Serie_hasta"
        Me.SeriehastaDataGridViewTextBoxColumn.HeaderText = "Serie_hasta"
        Me.SeriehastaDataGridViewTextBoxColumn.Name = "SeriehastaDataGridViewTextBoxColumn"
        Me.SeriehastaDataGridViewTextBoxColumn.ReadOnly = True
        Me.SeriehastaDataGridViewTextBoxColumn.Visible = False
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.FillWeight = 150.0!
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PrefijoDataGridViewTextBoxColumn
        '
        Me.PrefijoDataGridViewTextBoxColumn.DataPropertyName = "Prefijo"
        Me.PrefijoDataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.PrefijoDataGridViewTextBoxColumn.HeaderText = "Prefijo"
        Me.PrefijoDataGridViewTextBoxColumn.Name = "PrefijoDataGridViewTextBoxColumn"
        Me.PrefijoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SerieactualDataGridViewTextBoxColumn
        '
        Me.SerieactualDataGridViewTextBoxColumn.DataPropertyName = "Serie_actual"
        Me.SerieactualDataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.SerieactualDataGridViewTextBoxColumn.HeaderText = "Serie Actual"
        Me.SerieactualDataGridViewTextBoxColumn.Name = "SerieactualDataGridViewTextBoxColumn"
        Me.SerieactualDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EstadoDataGridViewTextBoxColumn
        '
        Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "Estado"
        Me.EstadoDataGridViewTextBoxColumn.HeaderText = "Estado"
        Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
        Me.EstadoDataGridViewTextBoxColumn.ReadOnly = True
        Me.EstadoDataGridViewTextBoxColumn.Visible = False
        '
        'PRODUCTOSERIEBindingSource
        '
        Me.PRODUCTOSERIEBindingSource.DataMember = "PRODUCTO_SERIE"
        Me.PRODUCTOSERIEBindingSource.DataSource = Me.DsSerie1
        '
        'DsSerie1
        '
        Me.DsSerie1.DataSetName = "DsSerie"
        Me.DsSerie1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(328, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 424
        Me.Label1.Text = "Producto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(306, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 425
        Me.Label2.Text = "Serie Desde:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(311, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 16)
        Me.Label3.TabIndex = 426
        Me.Label3.Text = "Serie Hasta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(310, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 427
        Me.Label4.Text = "Serie Actual:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(344, 247)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 16)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Prefijo:"
        '
        'CbxProducto
        '
        Me.CbxProducto.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.PRODUCTOSERIEBindingSource, "Id_producto", True))
        Me.CbxProducto.DataSource = Me.PRODUCTOSBindingSource
        Me.CbxProducto.DisplayMember = "DESPRODUCTO"
        Me.CbxProducto.DropDownWidth = 400
        Me.CbxProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CbxProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.CbxProducto.FormattingEnabled = True
        Me.CbxProducto.Location = New System.Drawing.Point(393, 98)
        Me.CbxProducto.Name = "CbxProducto"
        Me.CbxProducto.Size = New System.Drawing.Size(337, 28)
        Me.CbxProducto.TabIndex = 430
        Me.CbxProducto.ValueMember = "CODPRODUCTO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsSerie
        '
        'DsSerie
        '
        Me.DsSerie.DataSetName = "DsSerie"
        Me.DsSerie.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTO_SERIETableAdapter
        '
        Me.PRODUCTO_SERIETableAdapter.ClearBeforeFill = True
        '
        'TbxDesde
        '
        Me.TbxDesde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbxDesde.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSERIEBindingSource, "Serie_desde", True))
        Me.TbxDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TbxDesde.Location = New System.Drawing.Point(393, 133)
        Me.TbxDesde.Name = "TbxDesde"
        Me.TbxDesde.Size = New System.Drawing.Size(196, 27)
        Me.TbxDesde.TabIndex = 479
        '
        'TbxHasta
        '
        Me.TbxHasta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbxHasta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSERIEBindingSource, "Serie_hasta", True))
        Me.TbxHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TbxHasta.Location = New System.Drawing.Point(393, 168)
        Me.TbxHasta.Name = "TbxHasta"
        Me.TbxHasta.Size = New System.Drawing.Size(196, 27)
        Me.TbxHasta.TabIndex = 480
        '
        'TbxActual
        '
        Me.TbxActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbxActual.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSERIEBindingSource, "Serie_actual", True))
        Me.TbxActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TbxActual.Location = New System.Drawing.Point(393, 204)
        Me.TbxActual.Name = "TbxActual"
        Me.TbxActual.Size = New System.Drawing.Size(196, 27)
        Me.TbxActual.TabIndex = 481
        '
        'TxbPrefijo
        '
        Me.TxbPrefijo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxbPrefijo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PRODUCTOSERIEBindingSource, "Prefijo", True))
        Me.TxbPrefijo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.TxbPrefijo.Location = New System.Drawing.Point(393, 241)
        Me.TxbPrefijo.Name = "TxbPrefijo"
        Me.TxbPrefijo.Size = New System.Drawing.Size(196, 27)
        Me.TxbPrefijo.TabIndex = 482
        '
        'btnAsterisco
        '
        Me.btnAsterisco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAsterisco.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.btnAsterisco.Location = New System.Drawing.Point(733, 100)
        Me.btnAsterisco.Name = "btnAsterisco"
        Me.btnAsterisco.Size = New System.Drawing.Size(24, 23)
        Me.btnAsterisco.TabIndex = 483
        Me.btnAsterisco.TabStop = False
        '
        'ProductosGroupBox
        '
        Me.ProductosGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductosGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.ProductosGroupBox.Controls.Add(Me.tbxBuscarProductos)
        Me.ProductosGroupBox.Controls.Add(Me.dgwProductos)
        Me.ProductosGroupBox.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.ProductosGroupBox.FooterImageIndex = -1
        Me.ProductosGroupBox.FooterImageKey = ""
        Me.ProductosGroupBox.ForeColor = System.Drawing.Color.Black
        Me.ProductosGroupBox.HeaderImageIndex = -1
        Me.ProductosGroupBox.HeaderImageKey = ""
        Me.ProductosGroupBox.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.HeaderText = ""
        Me.ProductosGroupBox.Location = New System.Drawing.Point(768, 54)
        Me.ProductosGroupBox.Name = "ProductosGroupBox"
        Me.ProductosGroupBox.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.ProductosGroupBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.ProductosGroupBox.RootElement.AngleTransform = 0.0!
        Me.ProductosGroupBox.RootElement.FlipText = False
        Me.ProductosGroupBox.RootElement.ForeColor = System.Drawing.Color.Black
        Me.ProductosGroupBox.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.ProductosGroupBox.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.ProductosGroupBox.RootElement.Text = Nothing
        Me.ProductosGroupBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.ProductosGroupBox.Size = New System.Drawing.Size(444, 318)
        Me.ProductosGroupBox.TabIndex = 484
        Me.ProductosGroupBox.ThemeName = "Breeze"
        Me.ProductosGroupBox.Visible = False
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.DimGray
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbxBuscarProductos
        '
        Me.tbxBuscarProductos.BackColor = System.Drawing.Color.White
        Me.tbxBuscarProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarProductos.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.tbxBuscarProductos.Location = New System.Drawing.Point(6, 12)
        Me.tbxBuscarProductos.Name = "tbxBuscarProductos"
        Me.tbxBuscarProductos.Size = New System.Drawing.Size(430, 32)
        Me.tbxBuscarProductos.TabIndex = 376
        '
        'dgwProductos
        '
        Me.dgwProductos.AllowUserToAddRows = False
        Me.dgwProductos.AllowUserToDeleteRows = False
        Me.dgwProductos.AllowUserToResizeRows = False
        Me.dgwProductos.AutoGenerateColumns = False
        Me.dgwProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwProductos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgwProductos.ColumnHeadersHeight = 35
        Me.dgwProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPRODUCTODataGridViewTextBoxColumn, Me.CODIGO, Me.DESPRODUCTODataGridViewTextBoxColumn1})
        Me.dgwProductos.DataSource = Me.PRODUCTOSBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwProductos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgwProductos.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwProductos.Location = New System.Drawing.Point(6, 47)
        Me.dgwProductos.Name = "dgwProductos"
        Me.dgwProductos.ReadOnly = True
        Me.dgwProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgwProductos.RowHeadersVisible = False
        Me.dgwProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwProductos.ShowCellErrors = False
        Me.dgwProductos.ShowCellToolTips = False
        Me.dgwProductos.Size = New System.Drawing.Size(430, 264)
        Me.dgwProductos.TabIndex = 424
        '
        'upcProductos
        '
        Me.upcProductos.PopupControl = Me.ProductosGroupBox
        '
        'CODPRODUCTODataGridViewTextBoxColumn
        '
        Me.CODPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTODataGridViewTextBoxColumn.Name = "CODPRODUCTODataGridViewTextBoxColumn"
        Me.CODPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPRODUCTODataGridViewTextBoxColumn.Visible = False
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.FillWeight = 70.0!
        Me.CODIGO.HeaderText = "Codigo"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn1
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn1.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.FillWeight = 200.0!
        Me.DESPRODUCTODataGridViewTextBoxColumn1.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.Name = "DESPRODUCTODataGridViewTextBoxColumn1"
        Me.DESPRODUCTODataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Producto_Serie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 373)
        Me.Controls.Add(Me.ProductosGroupBox)
        Me.Controls.Add(Me.btnAsterisco)
        Me.Controls.Add(Me.TxbPrefijo)
        Me.Controls.Add(Me.TbxActual)
        Me.Controls.Add(Me.TbxHasta)
        Me.Controls.Add(Me.TbxDesde)
        Me.Controls.Add(Me.CbxProducto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProductosGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Producto_Serie"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nro de Serie | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxModifica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSERIEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSerie1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSerie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAsterisco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.dgwProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxEliminar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxModifica As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents BuscaProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProductosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CbxProducto As System.Windows.Forms.ComboBox
    Friend WithEvents DsSerie As ContaExpress.DsSerie
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsSerieTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents DsSerie1 As ContaExpress.DsSerie
    Friend WithEvents PRODUCTOSERIEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTO_SERIETableAdapter As ContaExpress.DsSerieTableAdapters.PRODUCTO_SERIETableAdapter
    Friend WithEvents TbxDesde As System.Windows.Forms.TextBox
    Friend WithEvents TbxHasta As System.Windows.Forms.TextBox
    Friend WithEvents TbxActual As System.Windows.Forms.TextBox
    Friend WithEvents TxbPrefijo As System.Windows.Forms.TextBox
    Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdproductoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeriedesdeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeriehastaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrefijoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SerieactualDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAsterisco As System.Windows.Forms.PictureBox
    Friend WithEvents ProductosGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents tbxBuscarProductos As System.Windows.Forms.TextBox
    Friend WithEvents dgwProductos As System.Windows.Forms.DataGridView
    Friend WithEvents upcProductos As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents CODPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
