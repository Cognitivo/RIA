<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ComprasModificarCuotas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprasModificarCuotas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BuscarCompraTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.lblProvName = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvProveedor = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTotalDiferencia = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotalAjustes = New System.Windows.Forms.Label()
        Me.tbxMonto = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.dtpFechaVto = New System.Windows.Forms.DateTimePicker()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.lblVerModulo = New Telerik.WinControls.UI.RadLabel()
        Me.dgvFacturas = New System.Windows.Forms.DataGridView()
        Me.MODALIDADPAGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTotalImporte = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvCuotas = New System.Windows.Forms.DataGridView()
        Me.NVONROCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCOMPRACUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AJUSTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnFiltrarCuentas = New System.Windows.Forms.Button()
        Me.btAplicarCambios = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.TextBoxCodProducto = New Telerik.WinControls.UI.RadTextBox()
        Me.TextBoxCodCodigo = New Telerik.WinControls.UI.RadTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CODPROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProveedorBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsAppCompras = New ContaExpress.DsAppCompras()
        Me.CODCOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHACOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPROVEEDORCOMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComprasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NUMEROCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAVCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTECUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOCUOTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAGADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CuotasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ComprasTableAdapter = New ContaExpress.DsAppComprasTableAdapters.COMPRASTableAdapter()
        Me.FacturapagarTableAdapter = New ContaExpress.DsAppComprasTableAdapters.FACTURAPAGARTableAdapter()
        Me.ProveedorTableAdapter = New ContaExpress.DsAppComprasTableAdapters.PROVEEDORTableAdapter()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblProvName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelProducto.SuspendLayout()
        CType(Me.lblVerModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProveedorBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsAppCompras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ComprasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CuotasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.BuscarCompraTextBox)
        Me.Panel1.Controls.Add(Me.PictureBox14)
        Me.Panel1.Controls.Add(Me.lblProvName)
        Me.Panel1.Controls.Add(Me.RadLabel16)
        Me.Panel1.Location = New System.Drawing.Point(-3, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1039, 40)
        Me.Panel1.TabIndex = 42
        '
        'BuscarCompraTextBox
        '
        Me.BuscarCompraTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarCompraTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarCompraTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarCompraTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarCompraTextBox.Location = New System.Drawing.Point(35, 5)
        Me.BuscarCompraTextBox.Name = "BuscarCompraTextBox"
        Me.BuscarCompraTextBox.Size = New System.Drawing.Size(196, 30)
        Me.BuscarCompraTextBox.TabIndex = 460
        '
        'PictureBox14
        '
        Me.PictureBox14.BackColor = System.Drawing.Color.Tan
        Me.PictureBox14.BackgroundImage = CType(resources.GetObject("PictureBox14.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox14.Location = New System.Drawing.Point(7, 5)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox14.TabIndex = 461
        Me.PictureBox14.TabStop = False
        '
        'lblProvName
        '
        Me.lblProvName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProvName.AutoSize = False
        Me.lblProvName.BackColor = System.Drawing.Color.Transparent
        Me.lblProvName.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblProvName.ForeColor = System.Drawing.Color.Black
        Me.lblProvName.Location = New System.Drawing.Point(342, 9)
        Me.lblProvName.Name = "lblProvName"
        '
        '
        '
        Me.lblProvName.RootElement.ForeColor = System.Drawing.Color.Black
        Me.lblProvName.Size = New System.Drawing.Size(499, 26)
        Me.lblProvName.TabIndex = 459
        Me.lblProvName.Text = "lblProvName"
        '
        'RadLabel16
        '
        Me.RadLabel16.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel16.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Location = New System.Drawing.Point(234, 9)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RadLabel16.Size = New System.Drawing.Size(110, 26)
        Me.RadLabel16.TabIndex = 458
        Me.RadLabel16.Text = "Proveedor :"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Location = New System.Drawing.Point(-1, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TableLayoutPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1037, 597)
        Me.SplitContainer1.SplitterDistance = 228
        Me.SplitContainer1.TabIndex = 43
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.dgvProveedor, 0, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(-1, -1)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(229, 597)
        Me.TableLayoutPanel2.TabIndex = 3
        '
        'dgvProveedor
        '
        Me.dgvProveedor.AllowUserToAddRows = False
        Me.dgvProveedor.AllowUserToDeleteRows = False
        Me.dgvProveedor.AllowUserToResizeColumns = False
        Me.dgvProveedor.AllowUserToResizeRows = False
        Me.dgvProveedor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvProveedor.AutoGenerateColumns = False
        Me.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProveedor.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProveedor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProveedor.ColumnHeadersHeight = 35
        Me.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPROVEEDOR, Me.NOMBRE})
        Me.dgvProveedor.DataSource = Me.ProveedorBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProveedor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProveedor.Location = New System.Drawing.Point(3, 3)
        Me.dgvProveedor.MultiSelect = False
        Me.dgvProveedor.Name = "dgvProveedor"
        Me.dgvProveedor.ReadOnly = True
        Me.dgvProveedor.RowHeadersVisible = False
        Me.dgvProveedor.RowHeadersWidth = 187
        Me.dgvProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvProveedor.Size = New System.Drawing.Size(223, 591)
        Me.dgvProveedor.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelProducto, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(-1, -1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(805, 597)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PanelProducto
        '
        Me.PanelProducto.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelProducto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelProducto.BackColor = System.Drawing.Color.LightGray
        Me.PanelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelProducto.Controls.Add(Me.Label7)
        Me.PanelProducto.Controls.Add(Me.Label6)
        Me.PanelProducto.Controls.Add(Me.Label1)
        Me.PanelProducto.Controls.Add(Me.lblTotalDiferencia)
        Me.PanelProducto.Controls.Add(Me.Label5)
        Me.PanelProducto.Controls.Add(Me.Label4)
        Me.PanelProducto.Controls.Add(Me.lblTotalAjustes)
        Me.PanelProducto.Controls.Add(Me.tbxMonto)
        Me.PanelProducto.Controls.Add(Me.dtpFechaVto)
        Me.PanelProducto.Controls.Add(Me.btnEliminar)
        Me.PanelProducto.Controls.Add(Me.btnNuevo)
        Me.PanelProducto.Controls.Add(Me.lblVerModulo)
        Me.PanelProducto.Controls.Add(Me.dgvFacturas)
        Me.PanelProducto.Controls.Add(Me.lblTotalImporte)
        Me.PanelProducto.Controls.Add(Me.Label2)
        Me.PanelProducto.Controls.Add(Me.Label3)
        Me.PanelProducto.Controls.Add(Me.dgvCuotas)
        Me.PanelProducto.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.PanelProducto.Location = New System.Drawing.Point(3, 83)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(799, 511)
        Me.PanelProducto.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 20)
        Me.Label7.TabIndex = 557
        Me.Label7.Text = "Detalle de Cuotas"
        Me.ToolTip1.SetToolTip(Me.Label7, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(277, 486)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(516, 13)
        Me.Label6.TabIndex = 556
        Me.Label6.Text = "OBS : Doble Click sobre las celdas ""Nuevo Monto"" y ""Vencimiento"" de la Grilla de " & _
    "Cuotas si desea Editarlos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(632, 433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 555
        Me.Label1.Text = "Diferencia"
        '
        'lblTotalDiferencia
        '
        Me.lblTotalDiferencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalDiferencia.BackColor = System.Drawing.Color.Khaki
        Me.lblTotalDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalDiferencia.ForeColor = System.Drawing.Color.Black
        Me.lblTotalDiferencia.Location = New System.Drawing.Point(632, 453)
        Me.lblTotalDiferencia.Name = "lblTotalDiferencia"
        Me.lblTotalDiferencia.Size = New System.Drawing.Size(161, 25)
        Me.lblTotalDiferencia.TabIndex = 554
        Me.lblTotalDiferencia.Text = "0"
        Me.lblTotalDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(456, 433)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 16)
        Me.Label5.TabIndex = 553
        Me.Label5.Text = "Total Ajustado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 433)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 552
        Me.Label4.Text = "Total Factura"
        '
        'lblTotalAjustes
        '
        Me.lblTotalAjustes.AccessibleDescription = ""
        Me.lblTotalAjustes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAjustes.BackColor = System.Drawing.Color.White
        Me.lblTotalAjustes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAjustes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalAjustes.ForeColor = System.Drawing.Color.Black
        Me.lblTotalAjustes.Location = New System.Drawing.Point(457, 453)
        Me.lblTotalAjustes.Name = "lblTotalAjustes"
        Me.lblTotalAjustes.Size = New System.Drawing.Size(161, 25)
        Me.lblTotalAjustes.TabIndex = 551
        Me.lblTotalAjustes.Text = "0"
        Me.lblTotalAjustes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxMonto
        '
        Me.tbxMonto.AllowDrop = True
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.SizeInPoints = 12.0!
        Me.tbxMonto.Appearance = Appearance2
        Me.tbxMonto.AutoSize = False
        Me.tbxMonto.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxMonto.CausesValidation = False
        Me.tbxMonto.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxMonto.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.tbxMonto.Location = New System.Drawing.Point(547, 13)
        Me.tbxMonto.Name = "tbxMonto"
        Me.tbxMonto.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxMonto.Size = New System.Drawing.Size(128, 26)
        Me.tbxMonto.TabIndex = 548
        Me.ToolTip1.SetToolTip(Me.tbxMonto, "Nuevo Monto a insertar para la Nueva Cuota")
        '
        'dtpFechaVto
        '
        Me.dtpFechaVto.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaVto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaVto.Location = New System.Drawing.Point(362, 13)
        Me.dtpFechaVto.Name = "dtpFechaVto"
        Me.dtpFechaVto.Size = New System.Drawing.Size(128, 26)
        Me.dtpFechaVto.TabIndex = 547
        Me.ToolTip1.SetToolTip(Me.dtpFechaVto, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'btnEliminar
        '
        Me.btnEliminar.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminar.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEliminar.Location = New System.Drawing.Point(738, 12)
        Me.btnEliminar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 28)
        Me.btnEliminar.TabIndex = 546
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNuevo.BackColor = System.Drawing.Color.LightSlateGray
        Me.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnNuevo.Location = New System.Drawing.Point(681, 12)
        Me.btnNuevo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(55, 28)
        Me.btnNuevo.TabIndex = 545
        Me.btnNuevo.Text = "Agregar"
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'lblVerModulo
        '
        Me.lblVerModulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblVerModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerModulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVerModulo.Location = New System.Drawing.Point(4, 3)
        Me.lblVerModulo.Name = "lblVerModulo"
        '
        '
        '
        Me.lblVerModulo.RootElement.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVerModulo.Size = New System.Drawing.Size(91, 16)
        Me.lblVerModulo.TabIndex = 240
        Me.lblVerModulo.Text = "Ver en Compras"
        '
        'dgvFacturas
        '
        Me.dgvFacturas.AllowUserToAddRows = False
        Me.dgvFacturas.AllowUserToDeleteRows = False
        Me.dgvFacturas.AllowUserToResizeRows = False
        Me.dgvFacturas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvFacturas.AutoGenerateColumns = False
        Me.dgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvFacturas.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFacturas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFacturas.ColumnHeadersHeight = 35
        Me.dgvFacturas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCOMPRA, Me.MODALIDADPAGO, Me.FECHACOMPRA, Me.NUMCOMPRA, Me.DESMONEDA, Me.CODPROVEEDORCOMP})
        Me.dgvFacturas.DataSource = Me.ComprasBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFacturas.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFacturas.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvFacturas.Location = New System.Drawing.Point(2, 23)
        Me.dgvFacturas.MultiSelect = False
        Me.dgvFacturas.Name = "dgvFacturas"
        Me.dgvFacturas.ReadOnly = True
        Me.dgvFacturas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFacturas.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvFacturas.RowHeadersVisible = False
        Me.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFacturas.Size = New System.Drawing.Size(271, 482)
        Me.dgvFacturas.TabIndex = 239
        '
        'MODALIDADPAGO
        '
        Me.MODALIDADPAGO.DataPropertyName = "MODALIDADPAGO"
        Me.MODALIDADPAGO.HeaderText = "MODALIDADPAGO"
        Me.MODALIDADPAGO.Name = "MODALIDADPAGO"
        Me.MODALIDADPAGO.ReadOnly = True
        Me.MODALIDADPAGO.Visible = False
        '
        'DESMONEDA
        '
        Me.DESMONEDA.DataPropertyName = "DESMONEDA"
        Me.DESMONEDA.FillWeight = 60.0!
        Me.DESMONEDA.HeaderText = "Moneda"
        Me.DESMONEDA.Name = "DESMONEDA"
        Me.DESMONEDA.ReadOnly = True
        '
        'lblTotalImporte
        '
        Me.lblTotalImporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalImporte.BackColor = System.Drawing.Color.White
        Me.lblTotalImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalImporte.ForeColor = System.Drawing.Color.Black
        Me.lblTotalImporte.Location = New System.Drawing.Point(284, 453)
        Me.lblTotalImporte.Name = "lblTotalImporte"
        Me.lblTotalImporte.Size = New System.Drawing.Size(161, 25)
        Me.lblTotalImporte.TabIndex = 542
        Me.lblTotalImporte.Text = "0"
        Me.lblTotalImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 38)
        Me.Label2.TabIndex = 549
        Me.Label2.Text = "Nueva Fecha Vto:"
        Me.ToolTip1.SetToolTip(Me.Label2, "Nueva Fecha de Vto. a insertar para la Nueva Cuota")
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(498, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 38)
        Me.Label3.TabIndex = 550
        Me.Label3.Text = "Nuevo Monto:"
        Me.ToolTip1.SetToolTip(Me.Label3, "Nuevo Monto a insertar para la Nueva Cuota")
        '
        'dgvCuotas
        '
        Me.dgvCuotas.AllowUserToAddRows = False
        Me.dgvCuotas.AllowUserToDeleteRows = False
        Me.dgvCuotas.AllowUserToResizeRows = False
        Me.dgvCuotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCuotas.AutoGenerateColumns = False
        Me.dgvCuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCuotas.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuotas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvCuotas.ColumnHeadersHeight = 35
        Me.dgvCuotas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMEROCUOTA, Me.NVONROCUOTA, Me.EstadoFila, Me.CODCOMPRACUOTA, Me.FECHAVCTO, Me.IMPORTECUOTA, Me.SALDOCUOTA, Me.PAGADO, Me.AJUSTE})
        Me.dgvCuotas.DataSource = Me.CuotasBindingSource
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuotas.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgvCuotas.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvCuotas.Location = New System.Drawing.Point(279, 76)
        Me.dgvCuotas.MultiSelect = False
        Me.dgvCuotas.Name = "dgvCuotas"
        Me.dgvCuotas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuotas.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvCuotas.RowHeadersVisible = False
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCuotas.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvCuotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuotas.ShowCellErrors = False
        Me.dgvCuotas.ShowCellToolTips = False
        Me.dgvCuotas.ShowRowErrors = False
        Me.dgvCuotas.Size = New System.Drawing.Size(513, 346)
        Me.dgvCuotas.TabIndex = 241
        Me.ToolTip1.SetToolTip(Me.dgvCuotas, "Doble Click sobre los campos ""Nuevo Monto"" y ""Vencimiento"" si desea Editarlos")
        '
        'NVONROCUOTA
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NVONROCUOTA.DefaultCellStyle = DataGridViewCellStyle10
        Me.NVONROCUOTA.FillWeight = 50.0!
        Me.NVONROCUOTA.HeaderText = "Nro."
        Me.NVONROCUOTA.Name = "NVONROCUOTA"
        Me.NVONROCUOTA.ReadOnly = True
        '
        'EstadoFila
        '
        Me.EstadoFila.HeaderText = "EstadoFila"
        Me.EstadoFila.Name = "EstadoFila"
        Me.EstadoFila.Visible = False
        '
        'CODCOMPRACUOTA
        '
        Me.CODCOMPRACUOTA.DataPropertyName = "CODCOMPRA"
        Me.CODCOMPRACUOTA.HeaderText = "CODCOMPRA"
        Me.CODCOMPRACUOTA.Name = "CODCOMPRACUOTA"
        Me.CODCOMPRACUOTA.ReadOnly = True
        Me.CODCOMPRACUOTA.Visible = False
        '
        'AJUSTE
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.AJUSTE.DefaultCellStyle = DataGridViewCellStyle13
        Me.AJUSTE.HeaderText = "Nuevo Monto"
        Me.AJUSTE.Name = "AJUSTE"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 74)
        Me.Panel2.TabIndex = 2
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 7
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.34498!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.65502!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 133.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpFechaDesde, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.dtpFechaHasta, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnFiltrarCuentas, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btAplicarCambios, 6, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnCancelar, 5, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(-1, 5)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.30769!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.69231!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(800, 65)
        Me.TableLayoutPanel3.TabIndex = 546
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 541
        Me.Label11.Text = "Fecha Desde:"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(3, 29)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(114, 27)
        Me.dtpFechaDesde.TabIndex = 542
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(123, 29)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(117, 27)
        Me.dtpFechaHasta.TabIndex = 543
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(123, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 13)
        Me.Label12.TabIndex = 540
        Me.Label12.Text = "Fecha Hasta:"
        '
        'btnFiltrarCuentas
        '
        Me.btnFiltrarCuentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarCuentas.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnFiltrarCuentas.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFiltrarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrarCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnFiltrarCuentas.Location = New System.Drawing.Point(246, 29)
        Me.btnFiltrarCuentas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFiltrarCuentas.Name = "btnFiltrarCuentas"
        Me.btnFiltrarCuentas.Size = New System.Drawing.Size(69, 26)
        Me.btnFiltrarCuentas.TabIndex = 544
        Me.btnFiltrarCuentas.Text = "Filtrar"
        Me.btnFiltrarCuentas.UseVisualStyleBackColor = False
        '
        'btAplicarCambios
        '
        Me.btAplicarCambios.BackColor = System.Drawing.Color.Tan
        Me.btAplicarCambios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btAplicarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAplicarCambios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btAplicarCambios.Image = Global.ContaExpress.My.Resources.Resources.ApproveActive
        Me.btAplicarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btAplicarCambios.Location = New System.Drawing.Point(622, 23)
        Me.btAplicarCambios.Name = "btAplicarCambios"
        Me.btAplicarCambios.Size = New System.Drawing.Size(175, 39)
        Me.btAplicarCambios.TabIndex = 547
        Me.btAplicarCambios.Text = "Aplicar Cambios"
        Me.btAplicarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btAplicarCambios.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Tan
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancel
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(499, 23)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(117, 39)
        Me.btnCancelar.TabIndex = 548
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = False
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
        'CODPROVEEDOR
        '
        Me.CODPROVEEDOR.DataPropertyName = "CODPROVEEDOR"
        Me.CODPROVEEDOR.HeaderText = "CODPROVEEDOR"
        Me.CODPROVEEDOR.Name = "CODPROVEEDOR"
        Me.CODPROVEEDOR.ReadOnly = True
        Me.CODPROVEEDOR.Visible = False
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.HeaderText = "Proveedor"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'ProveedorBindingSource
        '
        Me.ProveedorBindingSource.DataMember = "PROVEEDOR"
        Me.ProveedorBindingSource.DataSource = Me.DsAppCompras
        '
        'DsAppCompras
        '
        Me.DsAppCompras.DataSetName = "DsAppCompras"
        Me.DsAppCompras.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CODCOMPRA
        '
        Me.CODCOMPRA.DataPropertyName = "CODCOMPRA"
        Me.CODCOMPRA.HeaderText = "CODCOMPRA"
        Me.CODCOMPRA.Name = "CODCOMPRA"
        Me.CODCOMPRA.ReadOnly = True
        Me.CODCOMPRA.Visible = False
        '
        'FECHACOMPRA
        '
        Me.FECHACOMPRA.DataPropertyName = "FECHACOMPRA"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.FECHACOMPRA.DefaultCellStyle = DataGridViewCellStyle4
        Me.FECHACOMPRA.FillWeight = 40.0!
        Me.FECHACOMPRA.HeaderText = "Fecha"
        Me.FECHACOMPRA.Name = "FECHACOMPRA"
        Me.FECHACOMPRA.ReadOnly = True
        '
        'NUMCOMPRA
        '
        Me.NUMCOMPRA.DataPropertyName = "NUMCOMPRA"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.NUMCOMPRA.DefaultCellStyle = DataGridViewCellStyle5
        Me.NUMCOMPRA.FillWeight = 90.0!
        Me.NUMCOMPRA.HeaderText = "Nro. Factura"
        Me.NUMCOMPRA.Name = "NUMCOMPRA"
        Me.NUMCOMPRA.ReadOnly = True
        '
        'CODPROVEEDORCOMP
        '
        Me.CODPROVEEDORCOMP.DataPropertyName = "CODPROVEEDOR"
        Me.CODPROVEEDORCOMP.HeaderText = "CODPROVEEDOR"
        Me.CODPROVEEDORCOMP.Name = "CODPROVEEDORCOMP"
        Me.CODPROVEEDORCOMP.ReadOnly = True
        Me.CODPROVEEDORCOMP.Visible = False
        '
        'ComprasBindingSource
        '
        Me.ComprasBindingSource.DataMember = "COMPRAS"
        Me.ComprasBindingSource.DataSource = Me.DsAppCompras
        '
        'NUMEROCUOTA
        '
        Me.NUMEROCUOTA.DataPropertyName = "NUMEROCUOTA"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NUMEROCUOTA.DefaultCellStyle = DataGridViewCellStyle9
        Me.NUMEROCUOTA.FillWeight = 20.0!
        Me.NUMEROCUOTA.HeaderText = "Nro."
        Me.NUMEROCUOTA.Name = "NUMEROCUOTA"
        Me.NUMEROCUOTA.ReadOnly = True
        Me.NUMEROCUOTA.Visible = False
        '
        'FECHAVCTO
        '
        Me.FECHAVCTO.DataPropertyName = "FECHAVCTO"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "d"
        Me.FECHAVCTO.DefaultCellStyle = DataGridViewCellStyle11
        Me.FECHAVCTO.FillWeight = 70.0!
        Me.FECHAVCTO.HeaderText = "Vencimiento"
        Me.FECHAVCTO.Name = "FECHAVCTO"
        '
        'IMPORTECUOTA
        '
        Me.IMPORTECUOTA.DataPropertyName = "IMPORTECUOTA"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.IMPORTECUOTA.DefaultCellStyle = DataGridViewCellStyle12
        Me.IMPORTECUOTA.HeaderText = "Importe"
        Me.IMPORTECUOTA.Name = "IMPORTECUOTA"
        Me.IMPORTECUOTA.ReadOnly = True
        '
        'SALDOCUOTA
        '
        Me.SALDOCUOTA.DataPropertyName = "SALDOCUOTA"
        Me.SALDOCUOTA.HeaderText = "SALDOCUOTA"
        Me.SALDOCUOTA.Name = "SALDOCUOTA"
        Me.SALDOCUOTA.Visible = False
        '
        'PAGADO
        '
        Me.PAGADO.DataPropertyName = "PAGADO"
        Me.PAGADO.HeaderText = "PAGADO"
        Me.PAGADO.Name = "PAGADO"
        Me.PAGADO.Visible = False
        '
        'CuotasBindingSource
        '
        Me.CuotasBindingSource.DataMember = "FACTURAPAGAR"
        Me.CuotasBindingSource.DataSource = Me.DsAppCompras
        '
        'ComprasTableAdapter
        '
        Me.ComprasTableAdapter.ClearBeforeFill = True
        '
        'FacturapagarTableAdapter
        '
        Me.FacturapagarTableAdapter.ClearBeforeFill = True
        '
        'ProveedorTableAdapter
        '
        Me.ProveedorTableAdapter.ClearBeforeFill = True
        '
        'ComprasModificarCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 631)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ComprasModificarCuotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refinanciar Cuotas de Proveedores | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblProvName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.dgvProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelProducto.ResumeLayout(False)
        Me.PanelProducto.PerformLayout()
        CType(Me.lblVerModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFacturas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.TextBoxCodProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxCodCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProveedorBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsAppCompras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ComprasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CuotasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblProvName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelProducto As System.Windows.Forms.Panel
    Friend WithEvents dgvFacturas As System.Windows.Forms.DataGridView
    Friend WithEvents TextBoxCodProducto As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TextBoxCodCodigo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblVerModulo As Telerik.WinControls.UI.RadLabel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnFiltrarCuentas As System.Windows.Forms.Button
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvCuotas As System.Windows.Forms.DataGridView
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DsAppCompras As ContaExpress.DsAppCompras
    Friend WithEvents ComprasTableAdapter As ContaExpress.DsAppComprasTableAdapters.COMPRASTableAdapter
    Friend WithEvents FacturapagarTableAdapter As ContaExpress.DsAppComprasTableAdapters.FACTURAPAGARTableAdapter
    Friend WithEvents ProveedorTableAdapter As ContaExpress.DsAppComprasTableAdapters.PROVEEDORTableAdapter
    Friend WithEvents ProveedorBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CuotasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODPROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComprasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btAplicarCambios As System.Windows.Forms.Button
    Friend WithEvents lblTotalImporte As System.Windows.Forms.Label
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnNuevo As System.Windows.Forms.Button
    Friend WithEvents dtpFechaVto As System.Windows.Forms.DateTimePicker
    Friend WithEvents tbxMonto As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTotalAjustes As System.Windows.Forms.Label
    Friend WithEvents NUMEROCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NVONROCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoFila As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCOMPRACUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAVCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTECUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOCUOTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AJUSTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BuscarCompraTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTotalDiferencia As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CODCOMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODALIDADPAGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHACOMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCOMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPROVEEDORCOMP As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
