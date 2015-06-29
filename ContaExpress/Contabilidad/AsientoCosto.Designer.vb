<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AsientoCosto
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsientoCosto))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCambiarModulo = New System.Windows.Forms.Label()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btFiltrar = New System.Windows.Forms.Button()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.dgvVentasDetalle = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btAsentarCosto = New System.Windows.Forms.Button()
        Me.dgwResultado = New System.Windows.Forms.DataGridView()
        Me.NroAsiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NroCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Debe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Haber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodCuenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGenerarAsiento = New System.Windows.Forms.Button()
        Me.dgwPlantillaCosto = New System.Windows.Forms.DataGridView()
        Me.CODPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PanelVentas = New System.Windows.Forms.Panel()
        Me.PanelDevolucion = New System.Windows.Forms.Panel()
        Me.dgvDevolucionDet = New System.Windows.Forms.DataGridView()
        Me.FECHADEVOLUCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMDEVOLUCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDEVUELTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEVOLDET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTASDETALLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCosteo = New ContaExpress.DsCosteo()
        Me.CODIGODEV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTOPROMEDIODET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACDEVOLUCIONDETALLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Debe1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Haber1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PLANTILLACOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.VENTASDETALLETableAdapter = New ContaExpress.DsCosteoTableAdapters.VENTASDETALLETableAdapter()
        Me.PLANTILLACOSTOTableAdapter = New ContaExpress.DsCosteoTableAdapters.PLANTILLACOSTOTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsCosteoTableAdapters.TableAdapterManager()
        Me.ACDEVOLUCIONDETALLETableAdapter = New ContaExpress.DsCosteoTableAdapters.ACDEVOLUCIONDETALLETableAdapter()
        Me.VentaDetalleID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADVENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTOPROMEDIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUBTOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVentasDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwPlantillaCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVentas.SuspendLayout()
        Me.PanelDevolucion.SuspendLayout()
        CType(Me.dgvDevolucionDet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENTASDETALLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCosteo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ACDEVOLUCIONDETALLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLANTILLACOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.Panel1.Controls.Add(Me.lblCambiarModulo)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnGenerarAsiento)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btFiltrar)
        Me.Panel1.Controls.Add(Me.dtpFechaHasta)
        Me.Panel1.Controls.Add(Me.dtpFechaDesde)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1081, 697)
        Me.Panel1.TabIndex = 1
        '
        'lblCambiarModulo
        '
        Me.lblCambiarModulo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCambiarModulo.AutoSize = True
        Me.lblCambiarModulo.BackColor = System.Drawing.Color.Transparent
        Me.lblCambiarModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambiarModulo.Location = New System.Drawing.Point(353, 11)
        Me.lblCambiarModulo.Name = "lblCambiarModulo"
        Me.lblCambiarModulo.Size = New System.Drawing.Size(192, 18)
        Me.lblCambiarModulo.TabIndex = 544
        Me.lblCambiarModulo.Text = "Cambiar a Devoluciones"
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(40, 3)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(300, 35)
        Me.BuscarTextBox.TabIndex = 542
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(6, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 35)
        Me.PictureBox1.TabIndex = 543
        Me.PictureBox1.TabStop = False
        '
        'btFiltrar
        '
        Me.btFiltrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFiltrar.BackColor = System.Drawing.Color.Tan
        Me.btFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btFiltrar.Location = New System.Drawing.Point(1016, 7)
        Me.btFiltrar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btFiltrar.Name = "btFiltrar"
        Me.btFiltrar.Size = New System.Drawing.Size(58, 26)
        Me.btFiltrar.TabIndex = 541
        Me.btFiltrar.Text = "Filtrar"
        Me.btFiltrar.UseVisualStyleBackColor = False
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaHasta.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(878, 7)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(130, 26)
        Me.dtpFechaHasta.TabIndex = 459
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaDesde.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(737, 7)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(130, 26)
        Me.dtpFechaDesde.TabIndex = 458
        '
        'dgvVentasDetalle
        '
        Me.dgvVentasDetalle.AllowUserToAddRows = False
        Me.dgvVentasDetalle.AllowUserToDeleteRows = False
        Me.dgvVentasDetalle.AllowUserToResizeColumns = False
        Me.dgvVentasDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVentasDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVentasDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvVentasDetalle.AutoGenerateColumns = False
        Me.dgvVentasDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVentasDetalle.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvVentasDetalle.ColumnHeadersHeight = 35
        Me.dgvVentasDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VentaDetalleID, Me.FECHAVENTA, Me.NUMVENTADataGridViewTextBoxColumn, Me.CODIGODataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.CANTIDADVENTADataGridViewTextBoxColumn, Me.COSTOPROMEDIO, Me.SUBTOTAL})
        Me.dgvVentasDetalle.DataSource = Me.VENTASDETALLEBindingSource
        Me.dgvVentasDetalle.Location = New System.Drawing.Point(0, 0)
        Me.dgvVentasDetalle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvVentasDetalle.Name = "dgvVentasDetalle"
        Me.dgvVentasDetalle.ReadOnly = True
        Me.dgvVentasDetalle.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvVentasDetalle.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvVentasDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVentasDetalle.Size = New System.Drawing.Size(1083, 376)
        Me.dgvVentasDetalle.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(-1, 469)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(158, 29)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Resultados :"
        '
        'btAsentarCosto
        '
        Me.btAsentarCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btAsentarCosto.BackColor = System.Drawing.Color.Tan
        Me.btAsentarCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAsentarCosto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btAsentarCosto.Location = New System.Drawing.Point(860, 611)
        Me.btAsentarCosto.Name = "btAsentarCosto"
        Me.btAsentarCosto.Size = New System.Drawing.Size(209, 66)
        Me.btAsentarCosto.TabIndex = 4
        Me.btAsentarCosto.Text = "Asentar >>"
        Me.btAsentarCosto.UseVisualStyleBackColor = False
        '
        'dgwResultado
        '
        Me.dgwResultado.AllowUserToAddRows = False
        Me.dgwResultado.AllowUserToDeleteRows = False
        Me.dgwResultado.AllowUserToResizeColumns = False
        Me.dgwResultado.AllowUserToResizeRows = False
        Me.dgwResultado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwResultado.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgwResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwResultado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NroAsiento, Me.Fecha, Me.NroCuenta, Me.PlanCuenta, Me.Debe, Me.Haber, Me.CodCuenta})
        Me.dgwResultado.Location = New System.Drawing.Point(0, 453)
        Me.dgwResultado.Name = "dgwResultado"
        Me.dgwResultado.ReadOnly = True
        Me.dgwResultado.RowHeadersVisible = False
        Me.dgwResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwResultado.Size = New System.Drawing.Size(834, 244)
        Me.dgwResultado.TabIndex = 5
        '
        'NroAsiento
        '
        Me.NroAsiento.HeaderText = "Nro Asiento"
        Me.NroAsiento.Name = "NroAsiento"
        Me.NroAsiento.ReadOnly = True
        '
        'Fecha
        '
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'NroCuenta
        '
        Me.NroCuenta.HeaderText = "Nro Cuenta"
        Me.NroCuenta.Name = "NroCuenta"
        Me.NroCuenta.ReadOnly = True
        '
        'PlanCuenta
        '
        Me.PlanCuenta.HeaderText = "Plan de Cuenta"
        Me.PlanCuenta.Name = "PlanCuenta"
        Me.PlanCuenta.ReadOnly = True
        '
        'Debe
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.Debe.DefaultCellStyle = DataGridViewCellStyle7
        Me.Debe.HeaderText = "Debe"
        Me.Debe.Name = "Debe"
        Me.Debe.ReadOnly = True
        '
        'Haber
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N0"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Haber.DefaultCellStyle = DataGridViewCellStyle8
        Me.Haber.HeaderText = "Haber"
        Me.Haber.Name = "Haber"
        Me.Haber.ReadOnly = True
        '
        'CodCuenta
        '
        Me.CodCuenta.HeaderText = "CodCuenta"
        Me.CodCuenta.Name = "CodCuenta"
        Me.CodCuenta.ReadOnly = True
        Me.CodCuenta.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(835, 500)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 103)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Al oprimir Asentar, el sistema automaticamente asentara en base al resultado most" & _
    "rado aqui. Tambien las ventas se marcaran como costeado para no volver aparecer " & _
    "en esta lista"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGenerarAsiento
        '
        Me.btnGenerarAsiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarAsiento.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarAsiento.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnGenerarAsiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarAsiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnGenerarAsiento.Location = New System.Drawing.Point(5, 418)
        Me.btnGenerarAsiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnGenerarAsiento.Name = "btnGenerarAsiento"
        Me.btnGenerarAsiento.Size = New System.Drawing.Size(134, 33)
        Me.btnGenerarAsiento.TabIndex = 542
        Me.btnGenerarAsiento.Text = "Generar"
        Me.btnGenerarAsiento.UseVisualStyleBackColor = False
        '
        'dgwPlantillaCosto
        '
        Me.dgwPlantillaCosto.AllowUserToAddRows = False
        Me.dgwPlantillaCosto.AllowUserToDeleteRows = False
        Me.dgwPlantillaCosto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwPlantillaCosto.AutoGenerateColumns = False
        Me.dgwPlantillaCosto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwPlantillaCosto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Debe1, Me.Haber1, Me.CODPLANCUENTA, Me.NUMPLANCUENTA, Me.DESPLANCUENTA})
        Me.dgwPlantillaCosto.DataSource = Me.PLANTILLACOSTOBindingSource
        Me.dgwPlantillaCosto.Location = New System.Drawing.Point(290, 546)
        Me.dgwPlantillaCosto.Name = "dgwPlantillaCosto"
        Me.dgwPlantillaCosto.ReadOnly = True
        Me.dgwPlantillaCosto.RowHeadersVisible = False
        Me.dgwPlantillaCosto.Size = New System.Drawing.Size(409, 73)
        Me.dgwPlantillaCosto.TabIndex = 542
        '
        'CODPLANCUENTA
        '
        Me.CODPLANCUENTA.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTA.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTA.Name = "CODPLANCUENTA"
        Me.CODPLANCUENTA.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label3.Location = New System.Drawing.Point(142, 419)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 32)
        Me.Label3.TabIndex = 543
        Me.Label3.Text = "Los Asientos de Costos se Generan agrupados por Dias"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelVentas
        '
        Me.PanelVentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelVentas.BackColor = System.Drawing.Color.Transparent
        Me.PanelVentas.Controls.Add(Me.dgvVentasDetalle)
        Me.PanelVentas.Location = New System.Drawing.Point(-1, 40)
        Me.PanelVentas.Name = "PanelVentas"
        Me.PanelVentas.Size = New System.Drawing.Size(1083, 376)
        Me.PanelVentas.TabIndex = 544
        '
        'PanelDevolucion
        '
        Me.PanelDevolucion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelDevolucion.BackColor = System.Drawing.Color.Transparent
        Me.PanelDevolucion.Controls.Add(Me.dgvDevolucionDet)
        Me.PanelDevolucion.Location = New System.Drawing.Point(-1, 40)
        Me.PanelDevolucion.Name = "PanelDevolucion"
        Me.PanelDevolucion.Size = New System.Drawing.Size(1082, 376)
        Me.PanelDevolucion.TabIndex = 545
        '
        'dgvDevolucionDet
        '
        Me.dgvDevolucionDet.AllowUserToAddRows = False
        Me.dgvDevolucionDet.AllowUserToDeleteRows = False
        Me.dgvDevolucionDet.AllowUserToResizeColumns = False
        Me.dgvDevolucionDet.AllowUserToResizeRows = False
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDevolucionDet.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvDevolucionDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDevolucionDet.AutoGenerateColumns = False
        Me.dgvDevolucionDet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDevolucionDet.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvDevolucionDet.ColumnHeadersHeight = 35
        Me.dgvDevolucionDet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHADEVOLUCION, Me.NUMDEVOLUCION, Me.CODIGODEV, Me.DESPRODUCTODET, Me.COSTOPROMEDIODET, Me.CANTIDADDEVUELTA, Me.CODDEVOLDET})
        Me.dgvDevolucionDet.DataSource = Me.ACDEVOLUCIONDETALLEBindingSource
        Me.dgvDevolucionDet.Location = New System.Drawing.Point(1, 0)
        Me.dgvDevolucionDet.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvDevolucionDet.Name = "dgvDevolucionDet"
        Me.dgvDevolucionDet.ReadOnly = True
        Me.dgvDevolucionDet.RowHeadersVisible = False
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvDevolucionDet.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvDevolucionDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDevolucionDet.Size = New System.Drawing.Size(1082, 376)
        Me.dgvDevolucionDet.TabIndex = 3
        '
        'FECHADEVOLUCION
        '
        Me.FECHADEVOLUCION.DataPropertyName = "FECHADEVOLUCION"
        Me.FECHADEVOLUCION.HeaderText = "Fecha"
        Me.FECHADEVOLUCION.Name = "FECHADEVOLUCION"
        Me.FECHADEVOLUCION.ReadOnly = True
        '
        'NUMDEVOLUCION
        '
        Me.NUMDEVOLUCION.DataPropertyName = "NUMDEVOLUCION"
        Me.NUMDEVOLUCION.HeaderText = "Nro. Devolucion"
        Me.NUMDEVOLUCION.Name = "NUMDEVOLUCION"
        Me.NUMDEVOLUCION.ReadOnly = True
        '
        'CANTIDADDEVUELTA
        '
        Me.CANTIDADDEVUELTA.DataPropertyName = "CANTIDADDEVUELTA"
        Me.CANTIDADDEVUELTA.HeaderText = "Cantidad"
        Me.CANTIDADDEVUELTA.Name = "CANTIDADDEVUELTA"
        Me.CANTIDADDEVUELTA.ReadOnly = True
        '
        'CODDEVOLDET
        '
        Me.CODDEVOLDET.DataPropertyName = "CODDEVOLDET"
        Me.CODDEVOLDET.HeaderText = "VentaDetalleID"
        Me.CODDEVOLDET.Name = "CODDEVOLDET"
        Me.CODDEVOLDET.ReadOnly = True
        Me.CODDEVOLDET.Visible = False
        '
        'VENTASDETALLEBindingSource
        '
        Me.VENTASDETALLEBindingSource.DataMember = "VENTASDETALLE"
        Me.VENTASDETALLEBindingSource.DataSource = Me.DsCosteo
        '
        'DsCosteo
        '
        Me.DsCosteo.DataSetName = "DsCosteo"
        Me.DsCosteo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CODIGODEV
        '
        Me.CODIGODEV.DataPropertyName = "CODIGO"
        Me.CODIGODEV.HeaderText = "Codigo"
        Me.CODIGODEV.Name = "CODIGODEV"
        Me.CODIGODEV.ReadOnly = True
        '
        'DESPRODUCTODET
        '
        Me.DESPRODUCTODET.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODET.HeaderText = "Producto"
        Me.DESPRODUCTODET.Name = "DESPRODUCTODET"
        Me.DESPRODUCTODET.ReadOnly = True
        '
        'COSTOPROMEDIODET
        '
        Me.COSTOPROMEDIODET.DataPropertyName = "COSTOPROMEDIO"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.COSTOPROMEDIODET.DefaultCellStyle = DataGridViewCellStyle10
        Me.COSTOPROMEDIODET.HeaderText = "Costo (Fifo) * Cantidad"
        Me.COSTOPROMEDIODET.Name = "COSTOPROMEDIODET"
        Me.COSTOPROMEDIODET.ReadOnly = True
        '
        'ACDEVOLUCIONDETALLEBindingSource
        '
        Me.ACDEVOLUCIONDETALLEBindingSource.DataMember = "ACDEVOLUCIONDETALLE"
        Me.ACDEVOLUCIONDETALLEBindingSource.DataSource = Me.DsCosteo
        '
        'Debe1
        '
        Me.Debe1.DataPropertyName = "Debe"
        Me.Debe1.HeaderText = "Debe"
        Me.Debe1.Name = "Debe1"
        Me.Debe1.ReadOnly = True
        '
        'Haber1
        '
        Me.Haber1.DataPropertyName = "Haber"
        Me.Haber1.HeaderText = "Haber"
        Me.Haber1.Name = "Haber1"
        Me.Haber1.ReadOnly = True
        '
        'NUMPLANCUENTA
        '
        Me.NUMPLANCUENTA.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.HeaderText = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.Name = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.ReadOnly = True
        '
        'DESPLANCUENTA
        '
        Me.DESPLANCUENTA.DataPropertyName = "DESPLANCUENTA"
        Me.DESPLANCUENTA.HeaderText = "DESPLANCUENTA"
        Me.DESPLANCUENTA.Name = "DESPLANCUENTA"
        Me.DESPLANCUENTA.ReadOnly = True
        '
        'PLANTILLACOSTOBindingSource
        '
        Me.PLANTILLACOSTOBindingSource.DataMember = "PLANTILLACOSTO"
        Me.PLANTILLACOSTOBindingSource.DataSource = Me.DsCosteo
        '
        'VENTASDETALLETableAdapter
        '
        Me.VENTASDETALLETableAdapter.ClearBeforeFill = True
        '
        'PLANTILLACOSTOTableAdapter
        '
        Me.PLANTILLACOSTOTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsCosteoTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VENTASTableAdapter = Nothing
        '
        'ACDEVOLUCIONDETALLETableAdapter
        '
        Me.ACDEVOLUCIONDETALLETableAdapter.ClearBeforeFill = True
        '
        'VentaDetalleID
        '
        Me.VentaDetalleID.DataPropertyName = "VentaDetalleID"
        Me.VentaDetalleID.HeaderText = "VentaDetalleID"
        Me.VentaDetalleID.Name = "VentaDetalleID"
        Me.VentaDetalleID.ReadOnly = True
        Me.VentaDetalleID.Visible = False
        '
        'FECHAVENTA
        '
        Me.FECHAVENTA.DataPropertyName = "FECHAVENTA"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHAVENTA.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHAVENTA.FillWeight = 80.0!
        Me.FECHAVENTA.HeaderText = "Fecha"
        Me.FECHAVENTA.Name = "FECHAVENTA"
        Me.FECHAVENTA.ReadOnly = True
        '
        'NUMVENTADataGridViewTextBoxColumn
        '
        Me.NUMVENTADataGridViewTextBoxColumn.DataPropertyName = "NUMVENTA"
        Me.NUMVENTADataGridViewTextBoxColumn.HeaderText = "Nro Factura"
        Me.NUMVENTADataGridViewTextBoxColumn.Name = "NUMVENTADataGridViewTextBoxColumn"
        Me.NUMVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigo"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.FillWeight = 200.0!
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Producto"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CANTIDADVENTADataGridViewTextBoxColumn
        '
        Me.CANTIDADVENTADataGridViewTextBoxColumn.DataPropertyName = "CANTIDADVENTA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CANTIDADVENTADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CANTIDADVENTADataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.CANTIDADVENTADataGridViewTextBoxColumn.HeaderText = "Cantidad"
        Me.CANTIDADVENTADataGridViewTextBoxColumn.Name = "CANTIDADVENTADataGridViewTextBoxColumn"
        Me.CANTIDADVENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'COSTOPROMEDIO
        '
        Me.COSTOPROMEDIO.DataPropertyName = "COSTOPROMEDIO"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.COSTOPROMEDIO.DefaultCellStyle = DataGridViewCellStyle4
        Me.COSTOPROMEDIO.HeaderText = "Costo (Fifo)"
        Me.COSTOPROMEDIO.Name = "COSTOPROMEDIO"
        Me.COSTOPROMEDIO.ReadOnly = True
        '
        'SUBTOTAL
        '
        Me.SUBTOTAL.DataPropertyName = "SUBTOTAL"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.SUBTOTAL.DefaultCellStyle = DataGridViewCellStyle5
        Me.SUBTOTAL.HeaderText = "Costo (Fifo) * Cantidad"
        Me.SUBTOTAL.Name = "SUBTOTAL"
        Me.SUBTOTAL.ReadOnly = True
        '
        'AsientoCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(1081, 697)
        Me.Controls.Add(Me.PanelVentas)
        Me.Controls.Add(Me.PanelDevolucion)
        Me.Controls.Add(Me.dgwResultado)
        Me.Controls.Add(Me.btAsentarCosto)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgwPlantillaCosto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AsientoCosto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asientos de Costo  | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVentasDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwPlantillaCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVentas.ResumeLayout(False)
        Me.PanelDevolucion.ResumeLayout(False)
        CType(Me.dgvDevolucionDet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENTASDETALLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCosteo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ACDEVOLUCIONDETALLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLANTILLACOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvVentasDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents btFiltrar As System.Windows.Forms.Button
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents VENTASDETALLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCosteo As ContaExpress.DsCosteo
    Friend WithEvents VENTASDETALLETableAdapter As ContaExpress.DsCosteoTableAdapters.VENTASDETALLETableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btAsentarCosto As System.Windows.Forms.Button
    Friend WithEvents dgwResultado As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGenerarAsiento As System.Windows.Forms.Button
    Friend WithEvents PLANTILLACOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PLANTILLACOSTOTableAdapter As ContaExpress.DsCosteoTableAdapters.PLANTILLACOSTOTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsCosteoTableAdapters.TableAdapterManager
    Friend WithEvents dgwPlantillaCosto As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NroAsiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NroCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Haber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodCuenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Debe1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Haber1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelVentas As System.Windows.Forms.Panel
    Friend WithEvents PanelDevolucion As System.Windows.Forms.Panel
    Friend WithEvents dgvDevolucionDet As System.Windows.Forms.DataGridView
    Friend WithEvents ACDEVOLUCIONDETALLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ACDEVOLUCIONDETALLETableAdapter As ContaExpress.DsCosteoTableAdapters.ACDEVOLUCIONDETALLETableAdapter
    Friend WithEvents FECHADEVOLUCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMDEVOLUCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODEV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTOPROMEDIODET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDEVUELTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEVOLDET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCambiarModulo As System.Windows.Forms.Label
    Friend WithEvents VentaDetalleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADVENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTOPROMEDIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUBTOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
