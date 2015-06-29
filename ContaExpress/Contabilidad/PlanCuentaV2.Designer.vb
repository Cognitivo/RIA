<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanCuentaV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlanCuentaV2))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.pbxEliminar = New System.Windows.Forms.PictureBox()
        Me.pbxNuevo = New System.Windows.Forms.PictureBox()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxEditar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.dgvCuentas = New System.Windows.Forms.DataGridView()
        Me.PlancuentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPlantillasConta = New ContaExpress.DsPlantillasConta()
        Me.pnlContable = New System.Windows.Forms.Panel()
        Me.cbxResultado = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxTipoCuenta = New System.Windows.Forms.ComboBox()
        Me.cbxSaldoEsperado = New System.Windows.Forms.ComboBox()
        Me.cbxImputable = New System.Windows.Forms.ComboBox()
        Me.tbxNivel = New System.Windows.Forms.TextBox()
        Me.pnlIntegracion = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbxCliente = New System.Windows.Forms.ComboBox()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxProveedor = New System.Windows.Forms.ComboBox()
        Me.PROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.rbtRetencion = New System.Windows.Forms.RadioButton()
        Me.cbxRetencion = New System.Windows.Forms.ComboBox()
        Me.rbtAnticipo = New System.Windows.Forms.RadioButton()
        Me.cbxAnticipo = New System.Windows.Forms.ComboBox()
        Me.lblErrorRegla = New System.Windows.Forms.Label()
        Me.cbxMovVentas = New System.Windows.Forms.ComboBox()
        Me.rbtnVenta11 = New System.Windows.Forms.RadioButton()
        Me.rbtnMovimientoGen8 = New System.Windows.Forms.RadioButton()
        Me.rbtnMonetario7 = New System.Windows.Forms.RadioButton()
        Me.rbtnProveedorGen4 = New System.Windows.Forms.RadioButton()
        Me.rbtnProducto6 = New System.Windows.Forms.RadioButton()
        Me.rbtnProveedor3 = New System.Windows.Forms.RadioButton()
        Me.rbtnClienteGen2 = New System.Windows.Forms.RadioButton()
        Me.rbtnIVA5 = New System.Windows.Forms.RadioButton()
        Me.rbtnCliente1 = New System.Windows.Forms.RadioButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbxMonetario = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxProducto = New System.Windows.Forms.ComboBox()
        Me.CENTROCOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxIVA = New System.Windows.Forms.ComboBox()
        Me.tbxDescripcionCuenta = New System.Windows.Forms.TextBox()
        Me.tbxNroCuenta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PlancuentasTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter()
        Me.CLIENTESTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.CLIENTESTableAdapter()
        Me.PROVEEDORTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.PROVEEDORTableAdapter()
        Me.CENTROCOSTOTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.CENTROCOSTOTableAdapter()
        Me.CAJATableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.CAJATableAdapter()
        Me.tbxCodPlanCuenta = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.NUMPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPLANCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPLANCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVELCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASENTABLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTAMADREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReglaGrilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REGLAFK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SALDOESPERADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RESULTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEditar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlContable.SuspendLayout()
        Me.pnlIntegracion.SuspendLayout()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.pbxEliminar)
        Me.Panel1.Controls.Add(Me.pbxNuevo)
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.pbxEditar)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(855, 42)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.TabIndex = 462
        Me.PictureBox1.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(32, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(261, 30)
        Me.BuscarTextBox.TabIndex = 461
        Me.BuscarTextBox.Text = "Buscar..."
        '
        'pbxEliminar
        '
        Me.pbxEliminar.BackColor = System.Drawing.Color.Transparent
        Me.pbxEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEliminar.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.pbxEliminar.Location = New System.Drawing.Point(338, 3)
        Me.pbxEliminar.Name = "pbxEliminar"
        Me.pbxEliminar.Size = New System.Drawing.Size(32, 33)
        Me.pbxEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxEliminar.TabIndex = 6
        Me.pbxEliminar.TabStop = False
        '
        'pbxNuevo
        '
        Me.pbxNuevo.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevo.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevo.Location = New System.Drawing.Point(303, 3)
        Me.pbxNuevo.Name = "pbxNuevo"
        Me.pbxNuevo.Size = New System.Drawing.Size(32, 33)
        Me.pbxNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxNuevo.TabIndex = 5
        Me.pbxNuevo.TabStop = False
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.Enabled = False
        Me.pbxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.Location = New System.Drawing.Point(443, 3)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(32, 33)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxCancelar.TabIndex = 9
        Me.pbxCancelar.TabStop = False
        '
        'pbxEditar
        '
        Me.pbxEditar.BackColor = System.Drawing.Color.Transparent
        Me.pbxEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEditar.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.pbxEditar.Location = New System.Drawing.Point(373, 3)
        Me.pbxEditar.Name = "pbxEditar"
        Me.pbxEditar.Size = New System.Drawing.Size(32, 33)
        Me.pbxEditar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxEditar.TabIndex = 7
        Me.pbxEditar.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.Enabled = False
        Me.pbxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.pbxGuardar.Location = New System.Drawing.Point(408, 3)
        Me.pbxGuardar.Name = "pbxGuardar"
        Me.pbxGuardar.Size = New System.Drawing.Size(32, 33)
        Me.pbxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxGuardar.TabIndex = 8
        Me.pbxGuardar.TabStop = False
        '
        'dgvCuentas
        '
        Me.dgvCuentas.AllowUserToAddRows = False
        Me.dgvCuentas.AllowUserToDeleteRows = False
        Me.dgvCuentas.AllowUserToResizeColumns = False
        Me.dgvCuentas.AllowUserToResizeRows = False
        Me.dgvCuentas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvCuentas.AutoGenerateColumns = False
        Me.dgvCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCuentas.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCuentas.ColumnHeadersHeight = 35
        Me.dgvCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMPLANCUENTA, Me.DESPLANCUENTADataGridViewTextBoxColumn, Me.DESTIPOCUENTA, Me.CODPLANCUENTADataGridViewTextBoxColumn, Me.TIPOCUENTA, Me.NIVELCUENTADataGridViewTextBoxColumn, Me.ASENTABLE, Me.FECGRADataGridViewTextBoxColumn, Me.CODMONEDADataGridViewTextBoxColumn, Me.DESTIPOCUENTADataGridViewTextBoxColumn, Me.CUENTAMADREDataGridViewTextBoxColumn, Me.ReglaGrilla, Me.REGLAFK, Me.SALDOESPERADO, Me.RESULTADO})
        Me.dgvCuentas.DataSource = Me.PlancuentasBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCuentas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCuentas.Location = New System.Drawing.Point(-1, 40)
        Me.dgvCuentas.Name = "dgvCuentas"
        Me.dgvCuentas.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCuentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCuentas.RowHeadersVisible = False
        Me.dgvCuentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCuentas.Size = New System.Drawing.Size(294, 616)
        Me.dgvCuentas.TabIndex = 1
        '
        'PlancuentasBindingSource
        '
        Me.PlancuentasBindingSource.DataMember = "plancuentas"
        Me.PlancuentasBindingSource.DataSource = Me.DsPlantillasConta
        '
        'DsPlantillasConta
        '
        Me.DsPlantillasConta.DataSetName = "DsPlantillasConta"
        Me.DsPlantillasConta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnlContable
        '
        Me.pnlContable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlContable.BackColor = System.Drawing.Color.LightGray
        Me.pnlContable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlContable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlContable.Controls.Add(Me.cbxResultado)
        Me.pnlContable.Controls.Add(Me.Label15)
        Me.pnlContable.Controls.Add(Me.Label5)
        Me.pnlContable.Controls.Add(Me.Label12)
        Me.pnlContable.Controls.Add(Me.Label4)
        Me.pnlContable.Controls.Add(Me.Label3)
        Me.pnlContable.Controls.Add(Me.Label2)
        Me.pnlContable.Controls.Add(Me.cbxTipoCuenta)
        Me.pnlContable.Controls.Add(Me.cbxSaldoEsperado)
        Me.pnlContable.Controls.Add(Me.cbxImputable)
        Me.pnlContable.Controls.Add(Me.tbxNivel)
        Me.pnlContable.Location = New System.Drawing.Point(303, 125)
        Me.pnlContable.Name = "pnlContable"
        Me.pnlContable.Size = New System.Drawing.Size(544, 178)
        Me.pnlContable.TabIndex = 2
        '
        'cbxResultado
        '
        Me.cbxResultado.BackColor = System.Drawing.Color.White
        Me.cbxResultado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "DESTIPOCUENTA", True))
        Me.cbxResultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxResultado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxResultado.FormattingEnabled = True
        Me.cbxResultado.Items.AddRange(New Object() {"Pérdida del Ejercicio", "Ganancia del Ejercicio"})
        Me.cbxResultado.Location = New System.Drawing.Point(162, 136)
        Me.cbxResultado.Name = "cbxResultado"
        Me.cbxResultado.Size = New System.Drawing.Size(217, 28)
        Me.cbxResultado.TabIndex = 8
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(9, 142)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 16)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Resultado de Ejercicio:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label5.Location = New System.Drawing.Point(4, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(152, 20)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Detalles Contable"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(230, 71)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 16)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Tipo Cuenta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(49, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Saldo Esperado:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(89, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Imputable:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nivel:"
        '
        'cbxTipoCuenta
        '
        Me.cbxTipoCuenta.BackColor = System.Drawing.Color.White
        Me.cbxTipoCuenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "DESTIPOCUENTA", True))
        Me.cbxTipoCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipoCuenta.FormattingEnabled = True
        Me.cbxTipoCuenta.Items.AddRange(New Object() {"Ingreso", "Egreso", "Pasivo", "Activo", "Patrimonio Neto", "Regularizadora del Activo"})
        Me.cbxTipoCuenta.Location = New System.Drawing.Point(313, 65)
        Me.cbxTipoCuenta.Name = "cbxTipoCuenta"
        Me.cbxTipoCuenta.Size = New System.Drawing.Size(217, 28)
        Me.cbxTipoCuenta.TabIndex = 5
        '
        'cbxSaldoEsperado
        '
        Me.cbxSaldoEsperado.BackColor = System.Drawing.Color.White
        Me.cbxSaldoEsperado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxSaldoEsperado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSaldoEsperado.FormattingEnabled = True
        Me.cbxSaldoEsperado.Items.AddRange(New Object() {"Deudor", "Acreedor"})
        Me.cbxSaldoEsperado.Location = New System.Drawing.Point(162, 100)
        Me.cbxSaldoEsperado.Name = "cbxSaldoEsperado"
        Me.cbxSaldoEsperado.Size = New System.Drawing.Size(368, 28)
        Me.cbxSaldoEsperado.TabIndex = 6
        '
        'cbxImputable
        '
        Me.cbxImputable.BackColor = System.Drawing.Color.White
        Me.cbxImputable.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "ASENTABLE", True))
        Me.cbxImputable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxImputable.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxImputable.FormattingEnabled = True
        Me.cbxImputable.Items.AddRange(New Object() {"Si", "No"})
        Me.cbxImputable.Location = New System.Drawing.Point(162, 65)
        Me.cbxImputable.Name = "cbxImputable"
        Me.cbxImputable.Size = New System.Drawing.Size(64, 28)
        Me.cbxImputable.TabIndex = 4
        '
        'tbxNivel
        '
        Me.tbxNivel.BackColor = System.Drawing.Color.White
        Me.tbxNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNivel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "NIVELCUENTA", True))
        Me.tbxNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNivel.Location = New System.Drawing.Point(162, 34)
        Me.tbxNivel.Name = "tbxNivel"
        Me.tbxNivel.Size = New System.Drawing.Size(368, 26)
        Me.tbxNivel.TabIndex = 3
        '
        'pnlIntegracion
        '
        Me.pnlIntegracion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlIntegracion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlIntegracion.BackColor = System.Drawing.Color.LightGray
        Me.pnlIntegracion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlIntegracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlIntegracion.Controls.Add(Me.Label14)
        Me.pnlIntegracion.Controls.Add(Me.Label13)
        Me.pnlIntegracion.Controls.Add(Me.Label9)
        Me.pnlIntegracion.Controls.Add(Me.cbxCliente)
        Me.pnlIntegracion.Controls.Add(Me.cbxProveedor)
        Me.pnlIntegracion.Controls.Add(Me.rbtRetencion)
        Me.pnlIntegracion.Controls.Add(Me.cbxRetencion)
        Me.pnlIntegracion.Controls.Add(Me.rbtAnticipo)
        Me.pnlIntegracion.Controls.Add(Me.cbxAnticipo)
        Me.pnlIntegracion.Controls.Add(Me.lblErrorRegla)
        Me.pnlIntegracion.Controls.Add(Me.cbxMovVentas)
        Me.pnlIntegracion.Controls.Add(Me.rbtnVenta11)
        Me.pnlIntegracion.Controls.Add(Me.rbtnMovimientoGen8)
        Me.pnlIntegracion.Controls.Add(Me.rbtnMonetario7)
        Me.pnlIntegracion.Controls.Add(Me.rbtnProveedorGen4)
        Me.pnlIntegracion.Controls.Add(Me.rbtnProducto6)
        Me.pnlIntegracion.Controls.Add(Me.rbtnProveedor3)
        Me.pnlIntegracion.Controls.Add(Me.rbtnClienteGen2)
        Me.pnlIntegracion.Controls.Add(Me.rbtnIVA5)
        Me.pnlIntegracion.Controls.Add(Me.rbtnCliente1)
        Me.pnlIntegracion.Controls.Add(Me.Label11)
        Me.pnlIntegracion.Controls.Add(Me.Label10)
        Me.pnlIntegracion.Controls.Add(Me.Label8)
        Me.pnlIntegracion.Controls.Add(Me.Label7)
        Me.pnlIntegracion.Controls.Add(Me.cbxMonetario)
        Me.pnlIntegracion.Controls.Add(Me.cbxProducto)
        Me.pnlIntegracion.Controls.Add(Me.Label6)
        Me.pnlIntegracion.Controls.Add(Me.cbxIVA)
        Me.pnlIntegracion.Location = New System.Drawing.Point(303, 308)
        Me.pnlIntegracion.Name = "pnlIntegracion"
        Me.pnlIntegracion.Size = New System.Drawing.Size(544, 348)
        Me.pnlIntegracion.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(21, 311)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Retencion de IVA:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 269)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 16)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Anticipo de Dinero:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 143)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 16)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Movimiento de IVA :"
        '
        'cbxCliente
        '
        Me.cbxCliente.BackColor = System.Drawing.Color.White
        Me.cbxCliente.DataSource = Me.CLIENTESBindingSource
        Me.cbxCliente.DisplayMember = "NOMBRE"
        Me.cbxCliente.Enabled = False
        Me.cbxCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCliente.FormattingEnabled = True
        Me.cbxCliente.Location = New System.Drawing.Point(324, 53)
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(207, 28)
        Me.cbxCliente.TabIndex = 8
        Me.cbxCliente.ValueMember = "CODCLIENTE"
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsPlantillasConta
        '
        'cbxProveedor
        '
        Me.cbxProveedor.BackColor = System.Drawing.Color.White
        Me.cbxProveedor.DataSource = Me.PROVEEDORBindingSource
        Me.cbxProveedor.DisplayMember = "NOMBRE"
        Me.cbxProveedor.Enabled = False
        Me.cbxProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProveedor.FormattingEnabled = True
        Me.cbxProveedor.Location = New System.Drawing.Point(324, 95)
        Me.cbxProveedor.Name = "cbxProveedor"
        Me.cbxProveedor.Size = New System.Drawing.Size(207, 28)
        Me.cbxProveedor.TabIndex = 11
        Me.cbxProveedor.ValueMember = "CODPROVEEDOR"
        '
        'PROVEEDORBindingSource
        '
        Me.PROVEEDORBindingSource.DataMember = "PROVEEDOR"
        Me.PROVEEDORBindingSource.DataSource = Me.DsPlantillasConta
        '
        'rbtRetencion
        '
        Me.rbtRetencion.AutoSize = True
        Me.rbtRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtRetencion.Location = New System.Drawing.Point(142, 313)
        Me.rbtRetencion.Name = "rbtRetencion"
        Me.rbtRetencion.Size = New System.Drawing.Size(14, 13)
        Me.rbtRetencion.TabIndex = 25
        Me.rbtRetencion.TabStop = True
        Me.rbtRetencion.UseVisualStyleBackColor = True
        '
        'cbxRetencion
        '
        Me.cbxRetencion.BackColor = System.Drawing.Color.White
        Me.cbxRetencion.Enabled = False
        Me.cbxRetencion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxRetencion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxRetencion.FormattingEnabled = True
        Me.cbxRetencion.Items.AddRange(New Object() {"Ventas", "Compras"})
        Me.cbxRetencion.Location = New System.Drawing.Point(162, 305)
        Me.cbxRetencion.Name = "cbxRetencion"
        Me.cbxRetencion.Size = New System.Drawing.Size(369, 28)
        Me.cbxRetencion.TabIndex = 26
        '
        'rbtAnticipo
        '
        Me.rbtAnticipo.AutoSize = True
        Me.rbtAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtAnticipo.Location = New System.Drawing.Point(142, 271)
        Me.rbtAnticipo.Name = "rbtAnticipo"
        Me.rbtAnticipo.Size = New System.Drawing.Size(14, 13)
        Me.rbtAnticipo.TabIndex = 22
        Me.rbtAnticipo.TabStop = True
        Me.rbtAnticipo.UseVisualStyleBackColor = True
        '
        'cbxAnticipo
        '
        Me.cbxAnticipo.BackColor = System.Drawing.Color.White
        Me.cbxAnticipo.Enabled = False
        Me.cbxAnticipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxAnticipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAnticipo.FormattingEnabled = True
        Me.cbxAnticipo.Items.AddRange(New Object() {"Clientes", "Proveedores"})
        Me.cbxAnticipo.Location = New System.Drawing.Point(162, 263)
        Me.cbxAnticipo.Name = "cbxAnticipo"
        Me.cbxAnticipo.Size = New System.Drawing.Size(369, 28)
        Me.cbxAnticipo.TabIndex = 23
        '
        'lblErrorRegla
        '
        Me.lblErrorRegla.AutoSize = True
        Me.lblErrorRegla.BackColor = System.Drawing.Color.LightGray
        Me.lblErrorRegla.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorRegla.ForeColor = System.Drawing.Color.Maroon
        Me.lblErrorRegla.Location = New System.Drawing.Point(390, 12)
        Me.lblErrorRegla.Name = "lblErrorRegla"
        Me.lblErrorRegla.Size = New System.Drawing.Size(141, 16)
        Me.lblErrorRegla.TabIndex = 4
        Me.lblErrorRegla.Text = "Seleccione una Regla"
        Me.lblErrorRegla.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblErrorRegla.Visible = False
        '
        'cbxMovVentas
        '
        Me.cbxMovVentas.BackColor = System.Drawing.Color.White
        Me.cbxMovVentas.Enabled = False
        Me.cbxMovVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMovVentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMovVentas.FormattingEnabled = True
        Me.cbxMovVentas.Items.AddRange(New Object() {"Servicio", "Producto", "Costo de Venta"})
        Me.cbxMovVentas.Location = New System.Drawing.Point(324, 179)
        Me.cbxMovVentas.Name = "cbxMovVentas"
        Me.cbxMovVentas.Size = New System.Drawing.Size(207, 28)
        Me.cbxMovVentas.TabIndex = 20
        '
        'rbtnVenta11
        '
        Me.rbtnVenta11.AutoSize = True
        Me.rbtnVenta11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnVenta11.Location = New System.Drawing.Point(142, 183)
        Me.rbtnVenta11.Name = "rbtnVenta11"
        Me.rbtnVenta11.Size = New System.Drawing.Size(70, 21)
        Me.rbtnVenta11.TabIndex = 19
        Me.rbtnVenta11.TabStop = True
        Me.rbtnVenta11.Text = "Ventas"
        Me.rbtnVenta11.UseVisualStyleBackColor = True
        '
        'rbtnMovimientoGen8
        '
        Me.rbtnMovimientoGen8.AutoSize = True
        Me.rbtnMovimientoGen8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnMovimientoGen8.Location = New System.Drawing.Point(142, 225)
        Me.rbtnMovimientoGen8.Name = "rbtnMovimientoGen8"
        Me.rbtnMovimientoGen8.Size = New System.Drawing.Size(84, 21)
        Me.rbtnMovimientoGen8.TabIndex = 17
        Me.rbtnMovimientoGen8.TabStop = True
        Me.rbtnMovimientoGen8.Text = "Generico"
        Me.rbtnMovimientoGen8.UseVisualStyleBackColor = True
        '
        'rbtnMonetario7
        '
        Me.rbtnMonetario7.AutoSize = True
        Me.rbtnMonetario7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnMonetario7.Location = New System.Drawing.Point(232, 227)
        Me.rbtnMonetario7.Name = "rbtnMonetario7"
        Me.rbtnMonetario7.Size = New System.Drawing.Size(90, 21)
        Me.rbtnMonetario7.TabIndex = 16
        Me.rbtnMonetario7.TabStop = True
        Me.rbtnMonetario7.Text = "Especifico"
        Me.rbtnMonetario7.UseVisualStyleBackColor = True
        '
        'rbtnProveedorGen4
        '
        Me.rbtnProveedorGen4.AutoSize = True
        Me.rbtnProveedorGen4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnProveedorGen4.Location = New System.Drawing.Point(142, 99)
        Me.rbtnProveedorGen4.Name = "rbtnProveedorGen4"
        Me.rbtnProveedorGen4.Size = New System.Drawing.Size(84, 21)
        Me.rbtnProveedorGen4.TabIndex = 10
        Me.rbtnProveedorGen4.TabStop = True
        Me.rbtnProveedorGen4.Text = "Generico"
        Me.rbtnProveedorGen4.UseVisualStyleBackColor = True
        '
        'rbtnProducto6
        '
        Me.rbtnProducto6.AutoSize = True
        Me.rbtnProducto6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnProducto6.Location = New System.Drawing.Point(232, 183)
        Me.rbtnProducto6.Name = "rbtnProducto6"
        Me.rbtnProducto6.Size = New System.Drawing.Size(82, 21)
        Me.rbtnProducto6.TabIndex = 14
        Me.rbtnProducto6.TabStop = True
        Me.rbtnProducto6.Text = "Compras"
        Me.rbtnProducto6.UseVisualStyleBackColor = True
        '
        'rbtnProveedor3
        '
        Me.rbtnProveedor3.AutoSize = True
        Me.rbtnProveedor3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnProveedor3.Location = New System.Drawing.Point(232, 99)
        Me.rbtnProveedor3.Name = "rbtnProveedor3"
        Me.rbtnProveedor3.Size = New System.Drawing.Size(90, 21)
        Me.rbtnProveedor3.TabIndex = 9
        Me.rbtnProveedor3.TabStop = True
        Me.rbtnProveedor3.Text = "Especifico"
        Me.rbtnProveedor3.UseVisualStyleBackColor = True
        '
        'rbtnClienteGen2
        '
        Me.rbtnClienteGen2.AutoSize = True
        Me.rbtnClienteGen2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnClienteGen2.Location = New System.Drawing.Point(142, 57)
        Me.rbtnClienteGen2.Name = "rbtnClienteGen2"
        Me.rbtnClienteGen2.Size = New System.Drawing.Size(84, 21)
        Me.rbtnClienteGen2.TabIndex = 7
        Me.rbtnClienteGen2.TabStop = True
        Me.rbtnClienteGen2.Text = "Generico"
        Me.rbtnClienteGen2.UseVisualStyleBackColor = True
        '
        'rbtnIVA5
        '
        Me.rbtnIVA5.AutoSize = True
        Me.rbtnIVA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnIVA5.Location = New System.Drawing.Point(142, 145)
        Me.rbtnIVA5.Name = "rbtnIVA5"
        Me.rbtnIVA5.Size = New System.Drawing.Size(14, 13)
        Me.rbtnIVA5.TabIndex = 12
        Me.rbtnIVA5.TabStop = True
        Me.rbtnIVA5.UseVisualStyleBackColor = True
        '
        'rbtnCliente1
        '
        Me.rbtnCliente1.AutoSize = True
        Me.rbtnCliente1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.rbtnCliente1.Location = New System.Drawing.Point(232, 57)
        Me.rbtnCliente1.Name = "rbtnCliente1"
        Me.rbtnCliente1.Size = New System.Drawing.Size(90, 21)
        Me.rbtnCliente1.TabIndex = 6
        Me.rbtnCliente1.TabStop = True
        Me.rbtnCliente1.Text = "Especifico"
        Me.rbtnCliente1.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(65, 227)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Monetario:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Producto o Servicio:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(61, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Proveedor:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(84, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Cliente:"
        '
        'cbxMonetario
        '
        Me.cbxMonetario.BackColor = System.Drawing.Color.White
        Me.cbxMonetario.DataSource = Me.CAJABindingSource
        Me.cbxMonetario.DisplayMember = "NUMEROCAJA"
        Me.cbxMonetario.Enabled = False
        Me.cbxMonetario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMonetario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxMonetario.FormattingEnabled = True
        Me.cbxMonetario.Location = New System.Drawing.Point(324, 225)
        Me.cbxMonetario.Name = "cbxMonetario"
        Me.cbxMonetario.Size = New System.Drawing.Size(207, 28)
        Me.cbxMonetario.TabIndex = 18
        Me.cbxMonetario.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsPlantillasConta
        '
        'cbxProducto
        '
        Me.cbxProducto.BackColor = System.Drawing.Color.White
        Me.cbxProducto.DataSource = Me.CENTROCOSTOBindingSource
        Me.cbxProducto.DisplayMember = "DESCENTRO"
        Me.cbxProducto.Enabled = False
        Me.cbxProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProducto.FormattingEnabled = True
        Me.cbxProducto.Location = New System.Drawing.Point(324, 179)
        Me.cbxProducto.Name = "cbxProducto"
        Me.cbxProducto.Size = New System.Drawing.Size(207, 28)
        Me.cbxProducto.TabIndex = 15
        Me.cbxProducto.ValueMember = "CODCENTRO"
        '
        'CENTROCOSTOBindingSource
        '
        Me.CENTROCOSTOBindingSource.DataMember = "CENTROCOSTO"
        Me.CENTROCOSTOBindingSource.DataSource = Me.DsPlantillasConta
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label6.Location = New System.Drawing.Point(4, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(238, 20)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Integracion con Pos Express"
        '
        'cbxIVA
        '
        Me.cbxIVA.BackColor = System.Drawing.Color.White
        Me.cbxIVA.Enabled = False
        Me.cbxIVA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxIVA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxIVA.FormattingEnabled = True
        Me.cbxIVA.Items.AddRange(New Object() {"I.V.A 5%", "I.V.A 10%", "Exento"})
        Me.cbxIVA.Location = New System.Drawing.Point(163, 137)
        Me.cbxIVA.Name = "cbxIVA"
        Me.cbxIVA.Size = New System.Drawing.Size(367, 28)
        Me.cbxIVA.TabIndex = 13
        '
        'tbxDescripcionCuenta
        '
        Me.tbxDescripcionCuenta.BackColor = System.Drawing.Color.White
        Me.tbxDescripcionCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDescripcionCuenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "DESPLANCUENTA", True))
        Me.tbxDescripcionCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDescripcionCuenta.Location = New System.Drawing.Point(304, 53)
        Me.tbxDescripcionCuenta.Name = "tbxDescripcionCuenta"
        Me.tbxDescripcionCuenta.Size = New System.Drawing.Size(531, 29)
        Me.tbxDescripcionCuenta.TabIndex = 1
        '
        'tbxNroCuenta
        '
        Me.tbxNroCuenta.BackColor = System.Drawing.Color.White
        Me.tbxNroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroCuenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "NUMPLANCUENTA", True))
        Me.tbxNroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNroCuenta.Location = New System.Drawing.Point(466, 91)
        Me.tbxNroCuenta.Name = "tbxNroCuenta"
        Me.tbxNroCuenta.Size = New System.Drawing.Size(368, 26)
        Me.tbxNroCuenta.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(337, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Cuenta Fiscal:"
        '
        'PlancuentasTableAdapter
        '
        Me.PlancuentasTableAdapter.ClearBeforeFill = True
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'PROVEEDORTableAdapter
        '
        Me.PROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'CENTROCOSTOTableAdapter
        '
        Me.CENTROCOSTOTableAdapter.ClearBeforeFill = True
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'tbxCodPlanCuenta
        '
        Me.tbxCodPlanCuenta.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxCodPlanCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodPlanCuenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PlancuentasBindingSource, "CODPLANCUENTA", True))
        Me.tbxCodPlanCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodPlanCuenta.Location = New System.Drawing.Point(228, 99)
        Me.tbxCodPlanCuenta.Name = "tbxCodPlanCuenta"
        Me.tbxCodPlanCuenta.Size = New System.Drawing.Size(23, 26)
        Me.tbxCodPlanCuenta.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 659)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(853, 22)
        Me.StatusStrip1.TabIndex = 3335
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
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(781, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "F5 - Nuevo / F6 - Editar / F7 - Guardar / F8 - Cancelar "
        '
        'NUMPLANCUENTA
        '
        Me.NUMPLANCUENTA.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.FillWeight = 80.0!
        Me.NUMPLANCUENTA.HeaderText = "Numero"
        Me.NUMPLANCUENTA.Name = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.ReadOnly = True
        '
        'DESPLANCUENTADataGridViewTextBoxColumn
        '
        Me.DESPLANCUENTADataGridViewTextBoxColumn.DataPropertyName = "DESPLANCUENTA"
        Me.DESPLANCUENTADataGridViewTextBoxColumn.FillWeight = 120.0!
        Me.DESPLANCUENTADataGridViewTextBoxColumn.HeaderText = "Descripcion"
        Me.DESPLANCUENTADataGridViewTextBoxColumn.Name = "DESPLANCUENTADataGridViewTextBoxColumn"
        Me.DESPLANCUENTADataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESTIPOCUENTA
        '
        Me.DESTIPOCUENTA.DataPropertyName = "DESTIPOCUENTA"
        Me.DESTIPOCUENTA.HeaderText = "DESTIPOCUENTA"
        Me.DESTIPOCUENTA.Name = "DESTIPOCUENTA"
        Me.DESTIPOCUENTA.ReadOnly = True
        Me.DESTIPOCUENTA.Visible = False
        '
        'CODPLANCUENTADataGridViewTextBoxColumn
        '
        Me.CODPLANCUENTADataGridViewTextBoxColumn.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTADataGridViewTextBoxColumn.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTADataGridViewTextBoxColumn.Name = "CODPLANCUENTADataGridViewTextBoxColumn"
        Me.CODPLANCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPLANCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'TIPOCUENTA
        '
        Me.TIPOCUENTA.DataPropertyName = "TIPOCUENTA"
        Me.TIPOCUENTA.HeaderText = "TIPOCUENTA"
        Me.TIPOCUENTA.Name = "TIPOCUENTA"
        Me.TIPOCUENTA.ReadOnly = True
        Me.TIPOCUENTA.Visible = False
        '
        'NIVELCUENTADataGridViewTextBoxColumn
        '
        Me.NIVELCUENTADataGridViewTextBoxColumn.DataPropertyName = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.HeaderText = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.Name = "NIVELCUENTADataGridViewTextBoxColumn"
        Me.NIVELCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.NIVELCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'ASENTABLE
        '
        Me.ASENTABLE.DataPropertyName = "ASENTABLE"
        Me.ASENTABLE.HeaderText = "ASENTABLE"
        Me.ASENTABLE.Name = "ASENTABLE"
        Me.ASENTABLE.ReadOnly = True
        Me.ASENTABLE.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'CODMONEDADataGridViewTextBoxColumn
        '
        Me.CODMONEDADataGridViewTextBoxColumn.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.Name = "CODMONEDADataGridViewTextBoxColumn"
        Me.CODMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMONEDADataGridViewTextBoxColumn.Visible = False
        '
        'DESTIPOCUENTADataGridViewTextBoxColumn
        '
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.DataPropertyName = "DESTIPOCUENTA"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.HeaderText = "DESTIPOCUENTA"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.Name = "DESTIPOCUENTADataGridViewTextBoxColumn"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'CUENTAMADREDataGridViewTextBoxColumn
        '
        Me.CUENTAMADREDataGridViewTextBoxColumn.DataPropertyName = "CUENTAMADRE"
        Me.CUENTAMADREDataGridViewTextBoxColumn.HeaderText = "CUENTAMADRE"
        Me.CUENTAMADREDataGridViewTextBoxColumn.Name = "CUENTAMADREDataGridViewTextBoxColumn"
        Me.CUENTAMADREDataGridViewTextBoxColumn.ReadOnly = True
        Me.CUENTAMADREDataGridViewTextBoxColumn.Visible = False
        '
        'ReglaGrilla
        '
        Me.ReglaGrilla.DataPropertyName = "REGLA"
        Me.ReglaGrilla.HeaderText = "REGLA"
        Me.ReglaGrilla.Name = "ReglaGrilla"
        Me.ReglaGrilla.ReadOnly = True
        Me.ReglaGrilla.Visible = False
        '
        'REGLAFK
        '
        Me.REGLAFK.DataPropertyName = "REGLAFK"
        Me.REGLAFK.HeaderText = "REGLAFK"
        Me.REGLAFK.Name = "REGLAFK"
        Me.REGLAFK.ReadOnly = True
        Me.REGLAFK.Visible = False
        '
        'SALDOESPERADO
        '
        Me.SALDOESPERADO.DataPropertyName = "SALDOESPERADO"
        Me.SALDOESPERADO.HeaderText = "SALDOESPERADO"
        Me.SALDOESPERADO.Name = "SALDOESPERADO"
        Me.SALDOESPERADO.ReadOnly = True
        Me.SALDOESPERADO.Visible = False
        '
        'RESULTADO
        '
        Me.RESULTADO.DataPropertyName = "RESULTADO"
        Me.RESULTADO.HeaderText = "RESULTADO"
        Me.RESULTADO.Name = "RESULTADO"
        Me.RESULTADO.ReadOnly = True
        Me.RESULTADO.Visible = False
        '
        'PlanCuentaV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(853, 681)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxNroCuenta)
        Me.Controls.Add(Me.tbxDescripcionCuenta)
        Me.Controls.Add(Me.pnlIntegracion)
        Me.Controls.Add(Me.pnlContable)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgvCuentas)
        Me.Controls.Add(Me.tbxCodPlanCuenta)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "PlanCuentaV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Plan de Cuentas  | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEditar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlContable.ResumeLayout(False)
        Me.pnlContable.PerformLayout()
        Me.pnlIntegracion.ResumeLayout(False)
        Me.pnlIntegracion.PerformLayout()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvCuentas As System.Windows.Forms.DataGridView
    Friend WithEvents pnlContable As System.Windows.Forms.Panel
    Friend WithEvents pnlIntegracion As System.Windows.Forms.Panel
    Friend WithEvents tbxDescripcionCuenta As System.Windows.Forms.TextBox
    Friend WithEvents tbxNroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxSaldoEsperado As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbxMonetario As System.Windows.Forms.ComboBox
    Friend WithEvents cbxProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cbxIVA As System.Windows.Forms.ComboBox
    Friend WithEvents cbxProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pbxEliminar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEditar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents DsPlantillasConta As ContaExpress.DsPlantillasConta
    Friend WithEvents PlancuentasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlancuentasTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter
    Friend WithEvents REGLADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REGLAFKDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbtnProveedorGen4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnProveedor3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnClienteGen2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnCliente1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMovimientoGen8 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMonetario7 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnProducto6 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnIVA5 As System.Windows.Forms.RadioButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lblErrorRegla As System.Windows.Forms.Label
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.CLIENTESTableAdapter
    Friend WithEvents PROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROVEEDORTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.PROVEEDORTableAdapter
    Friend WithEvents CENTROCOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CENTROCOSTOTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.CENTROCOSTOTableAdapter
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsPlantillasContaTableAdapters.CAJATableAdapter
    Friend WithEvents tbxCodPlanCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rbtnVenta11 As System.Windows.Forms.RadioButton
    Friend WithEvents cbxMovVentas As System.Windows.Forms.ComboBox
    Friend WithEvents rbtAnticipo As System.Windows.Forms.RadioButton
    Friend WithEvents cbxAnticipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbxImputable As System.Windows.Forms.ComboBox
    Friend WithEvents tbxNivel As System.Windows.Forms.TextBox
    Friend WithEvents rbtRetencion As System.Windows.Forms.RadioButton
    Friend WithEvents cbxRetencion As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxResultado As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NUMPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPLANCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPLANCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVELCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASENTABLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTAMADREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReglaGrilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REGLAFK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SALDOESPERADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RESULTADO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
