<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMPaisV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMPaisV2))
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblLocalidad = New System.Windows.Forms.Label()
        Me.tlplocalizacion = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPais = New System.Windows.Forms.DataGridView()
        Me.CODPAIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPAISDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPAIS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIORIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsLocalidad = New ContaExpress.DsLocalidad()
        Me.dgvCiudad = New System.Windows.Forms.DataGridView()
        Me.CODCIUDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCIUDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCIUDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIORIDADDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPAISDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CIUDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dgvZona = New System.Windows.Forms.DataGridView()
        Me.CODZONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCIUDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMZONADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESZONA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZONABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.cbxPrioridadCiudad = New System.Windows.Forms.CheckBox()
        Me.lblModificar = New System.Windows.Forms.Label()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.txtLocalidad = New System.Windows.Forms.TextBox()
        Me.PAISTableAdapter = New ContaExpress.DsLocalidadTableAdapters.PAISTableAdapter()
        Me.CIUDADTableAdapter = New ContaExpress.DsLocalidadTableAdapters.CIUDADTableAdapter()
        Me.ZONATableAdapter = New ContaExpress.DsLocalidadTableAdapters.ZONATableAdapter()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.tbxBuscarCiudad = New System.Windows.Forms.TextBox()
        Me.tbxBuscarPais = New System.Windows.Forms.TextBox()
        Me.tbxBuscarZona = New System.Windows.Forms.TextBox()
        Me.pnlHeader.SuspendLayout()
        Me.tlplocalizacion.SuspendLayout()
        CType(Me.dgvPais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCiudad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvZona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BackColor = System.Drawing.Color.DarkGray
        Me.pnlHeader.Controls.Add(Me.lblLocalidad)
        Me.pnlHeader.Location = New System.Drawing.Point(221, 12)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(407, 41)
        Me.pnlHeader.TabIndex = 4
        '
        'lblLocalidad
        '
        Me.lblLocalidad.AutoSize = True
        Me.lblLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblLocalidad.Location = New System.Drawing.Point(6, 7)
        Me.lblLocalidad.Name = "lblLocalidad"
        Me.lblLocalidad.Size = New System.Drawing.Size(105, 22)
        Me.lblLocalidad.TabIndex = 1
        Me.lblLocalidad.Text = "lblLocalidad"
        '
        'tlplocalizacion
        '
        Me.tlplocalizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlplocalizacion.BackColor = System.Drawing.Color.LightGray
        Me.tlplocalizacion.ColumnCount = 3
        Me.tlplocalizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.tlplocalizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlplocalizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlplocalizacion.Controls.Add(Me.dgvPais, 0, 0)
        Me.tlplocalizacion.Controls.Add(Me.dgvCiudad, 1, 0)
        Me.tlplocalizacion.Controls.Add(Me.dgvZona, 2, 0)
        Me.tlplocalizacion.Location = New System.Drawing.Point(12, 57)
        Me.tlplocalizacion.Name = "tlplocalizacion"
        Me.tlplocalizacion.RowCount = 1
        Me.tlplocalizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlplocalizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 305.0!))
        Me.tlplocalizacion.Size = New System.Drawing.Size(619, 305)
        Me.tlplocalizacion.TabIndex = 5
        '
        'dgvPais
        '
        Me.dgvPais.AllowUserToAddRows = False
        Me.dgvPais.AllowUserToDeleteRows = False
        Me.dgvPais.AllowUserToResizeColumns = False
        Me.dgvPais.AllowUserToResizeRows = False
        Me.dgvPais.AutoGenerateColumns = False
        Me.dgvPais.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvPais.CausesValidation = False
        Me.dgvPais.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPais.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPAIS, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMPAISDataGridViewTextBoxColumn, Me.DESPAIS, Me.PRIORIDADDataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn})
        Me.dgvPais.DataSource = Me.PAISBindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPais.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPais.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPais.EnableHeadersVisualStyles = False
        Me.dgvPais.Location = New System.Drawing.Point(3, 3)
        Me.dgvPais.Name = "dgvPais"
        Me.dgvPais.ReadOnly = True
        Me.dgvPais.RowHeadersVisible = False
        Me.dgvPais.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPais.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPais.Size = New System.Drawing.Size(200, 299)
        Me.dgvPais.TabIndex = 0
        '
        'CODPAIS
        '
        Me.CODPAIS.DataPropertyName = "CODPAIS"
        Me.CODPAIS.HeaderText = "CODPAIS"
        Me.CODPAIS.MinimumWidth = 2
        Me.CODPAIS.Name = "CODPAIS"
        Me.CODPAIS.ReadOnly = True
        Me.CODPAIS.Visible = False
        Me.CODPAIS.Width = 2
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
        'NUMPAISDataGridViewTextBoxColumn
        '
        Me.NUMPAISDataGridViewTextBoxColumn.DataPropertyName = "NUMPAIS"
        Me.NUMPAISDataGridViewTextBoxColumn.HeaderText = "NUMPAIS"
        Me.NUMPAISDataGridViewTextBoxColumn.Name = "NUMPAISDataGridViewTextBoxColumn"
        Me.NUMPAISDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMPAISDataGridViewTextBoxColumn.Visible = False
        '
        'DESPAIS
        '
        Me.DESPAIS.DataPropertyName = "DESPAIS"
        Me.DESPAIS.HeaderText = "País/Departamento"
        Me.DESPAIS.Name = "DESPAIS"
        Me.DESPAIS.ReadOnly = True
        Me.DESPAIS.Width = 400
        '
        'PRIORIDADDataGridViewTextBoxColumn
        '
        Me.PRIORIDADDataGridViewTextBoxColumn.DataPropertyName = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.HeaderText = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.Name = "PRIORIDADDataGridViewTextBoxColumn"
        Me.PRIORIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.PRIORIDADDataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsLocalidad
        '
        'DsLocalidad
        '
        Me.DsLocalidad.DataSetName = "DsLocalidad"
        Me.DsLocalidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvCiudad
        '
        Me.dgvCiudad.AllowUserToAddRows = False
        Me.dgvCiudad.AllowUserToDeleteRows = False
        Me.dgvCiudad.AllowUserToResizeColumns = False
        Me.dgvCiudad.AllowUserToResizeRows = False
        Me.dgvCiudad.AutoGenerateColumns = False
        Me.dgvCiudad.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvCiudad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCiudad.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCIUDAD, Me.CODUSUARIODataGridViewTextBoxColumn1, Me.CODEMPRESADataGridViewTextBoxColumn1, Me.CODDEPARTAMENTODataGridViewTextBoxColumn, Me.NUMCIUDADDataGridViewTextBoxColumn, Me.DESCIUDAD, Me.PRIORIDADDataGridViewTextBoxColumn1, Me.FECGRADataGridViewTextBoxColumn1, Me.CODPAISDataGridViewTextBoxColumn})
        Me.dgvCiudad.DataSource = Me.CIUDADBindingSource
        Me.dgvCiudad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCiudad.EnableHeadersVisualStyles = False
        Me.dgvCiudad.Location = New System.Drawing.Point(209, 3)
        Me.dgvCiudad.Name = "dgvCiudad"
        Me.dgvCiudad.ReadOnly = True
        Me.dgvCiudad.RowHeadersVisible = False
        Me.dgvCiudad.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCiudad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCiudad.Size = New System.Drawing.Size(200, 299)
        Me.dgvCiudad.TabIndex = 0
        '
        'CODCIUDAD
        '
        Me.CODCIUDAD.DataPropertyName = "CODCIUDAD"
        Me.CODCIUDAD.HeaderText = "CIUDAD"
        Me.CODCIUDAD.MinimumWidth = 2
        Me.CODCIUDAD.Name = "CODCIUDAD"
        Me.CODCIUDAD.ReadOnly = True
        Me.CODCIUDAD.Visible = False
        Me.CODCIUDAD.Width = 2
        '
        'CODUSUARIODataGridViewTextBoxColumn1
        '
        Me.CODUSUARIODataGridViewTextBoxColumn1.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn1.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn1.Name = "CODUSUARIODataGridViewTextBoxColumn1"
        Me.CODUSUARIODataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn1.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn1
        '
        Me.CODEMPRESADataGridViewTextBoxColumn1.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn1.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn1.Name = "CODEMPRESADataGridViewTextBoxColumn1"
        Me.CODEMPRESADataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn1.Visible = False
        '
        'CODDEPARTAMENTODataGridViewTextBoxColumn
        '
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn.DataPropertyName = "CODDEPARTAMENTO"
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn.HeaderText = "CODDEPARTAMENTO"
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn.Name = "CODDEPARTAMENTODataGridViewTextBoxColumn"
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODDEPARTAMENTODataGridViewTextBoxColumn.Visible = False
        '
        'NUMCIUDADDataGridViewTextBoxColumn
        '
        Me.NUMCIUDADDataGridViewTextBoxColumn.DataPropertyName = "NUMCIUDAD"
        Me.NUMCIUDADDataGridViewTextBoxColumn.HeaderText = "NUMCIUDAD"
        Me.NUMCIUDADDataGridViewTextBoxColumn.Name = "NUMCIUDADDataGridViewTextBoxColumn"
        Me.NUMCIUDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMCIUDADDataGridViewTextBoxColumn.Visible = False
        '
        'DESCIUDAD
        '
        Me.DESCIUDAD.DataPropertyName = "DESCIUDAD"
        Me.DESCIUDAD.HeaderText = "Ciudad"
        Me.DESCIUDAD.Name = "DESCIUDAD"
        Me.DESCIUDAD.ReadOnly = True
        Me.DESCIUDAD.Width = 400
        '
        'PRIORIDADDataGridViewTextBoxColumn1
        '
        Me.PRIORIDADDataGridViewTextBoxColumn1.DataPropertyName = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn1.HeaderText = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn1.Name = "PRIORIDADDataGridViewTextBoxColumn1"
        Me.PRIORIDADDataGridViewTextBoxColumn1.ReadOnly = True
        Me.PRIORIDADDataGridViewTextBoxColumn1.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn1
        '
        Me.FECGRADataGridViewTextBoxColumn1.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.Name = "FECGRADataGridViewTextBoxColumn1"
        Me.FECGRADataGridViewTextBoxColumn1.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn1.Visible = False
        '
        'CODPAISDataGridViewTextBoxColumn
        '
        Me.CODPAISDataGridViewTextBoxColumn.DataPropertyName = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.HeaderText = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.Name = "CODPAISDataGridViewTextBoxColumn"
        Me.CODPAISDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPAISDataGridViewTextBoxColumn.Visible = False
        '
        'CIUDADBindingSource
        '
        Me.CIUDADBindingSource.DataMember = "CIUDAD"
        Me.CIUDADBindingSource.DataSource = Me.DsLocalidad
        '
        'dgvZona
        '
        Me.dgvZona.AllowUserToAddRows = False
        Me.dgvZona.AllowUserToDeleteRows = False
        Me.dgvZona.AllowUserToResizeColumns = False
        Me.dgvZona.AllowUserToResizeRows = False
        Me.dgvZona.AutoGenerateColumns = False
        Me.dgvZona.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvZona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvZona.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODZONA, Me.CODSUCURSALDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn2, Me.CODEMPRESADataGridViewTextBoxColumn2, Me.CODCIUDADDataGridViewTextBoxColumn, Me.NUMZONADataGridViewTextBoxColumn, Me.DESZONA, Me.FECGRADataGridViewTextBoxColumn2})
        Me.dgvZona.DataSource = Me.ZONABindingSource
        Me.dgvZona.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvZona.EnableHeadersVisualStyles = False
        Me.dgvZona.Location = New System.Drawing.Point(415, 3)
        Me.dgvZona.Name = "dgvZona"
        Me.dgvZona.ReadOnly = True
        Me.dgvZona.RowHeadersVisible = False
        Me.dgvZona.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvZona.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvZona.Size = New System.Drawing.Size(201, 299)
        Me.dgvZona.TabIndex = 0
        '
        'CODZONA
        '
        Me.CODZONA.DataPropertyName = "CODZONA"
        Me.CODZONA.HeaderText = "CODZONA"
        Me.CODZONA.MinimumWidth = 2
        Me.CODZONA.Name = "CODZONA"
        Me.CODZONA.ReadOnly = True
        Me.CODZONA.Visible = False
        Me.CODZONA.Width = 2
        '
        'CODSUCURSALDataGridViewTextBoxColumn
        '
        Me.CODSUCURSALDataGridViewTextBoxColumn.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSALDataGridViewTextBoxColumn.Name = "CODSUCURSALDataGridViewTextBoxColumn"
        Me.CODSUCURSALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODSUCURSALDataGridViewTextBoxColumn.Visible = False
        '
        'CODUSUARIODataGridViewTextBoxColumn2
        '
        Me.CODUSUARIODataGridViewTextBoxColumn2.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn2.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn2.Name = "CODUSUARIODataGridViewTextBoxColumn2"
        Me.CODUSUARIODataGridViewTextBoxColumn2.ReadOnly = True
        Me.CODUSUARIODataGridViewTextBoxColumn2.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn2
        '
        Me.CODEMPRESADataGridViewTextBoxColumn2.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn2.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn2.Name = "CODEMPRESADataGridViewTextBoxColumn2"
        Me.CODEMPRESADataGridViewTextBoxColumn2.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn2.Visible = False
        '
        'CODCIUDADDataGridViewTextBoxColumn
        '
        Me.CODCIUDADDataGridViewTextBoxColumn.DataPropertyName = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.HeaderText = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.Name = "CODCIUDADDataGridViewTextBoxColumn"
        Me.CODCIUDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCIUDADDataGridViewTextBoxColumn.Visible = False
        '
        'NUMZONADataGridViewTextBoxColumn
        '
        Me.NUMZONADataGridViewTextBoxColumn.DataPropertyName = "NUMZONA"
        Me.NUMZONADataGridViewTextBoxColumn.HeaderText = "NUMZONA"
        Me.NUMZONADataGridViewTextBoxColumn.Name = "NUMZONADataGridViewTextBoxColumn"
        Me.NUMZONADataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMZONADataGridViewTextBoxColumn.Visible = False
        '
        'DESZONA
        '
        Me.DESZONA.DataPropertyName = "DESZONA"
        Me.DESZONA.HeaderText = "Zona"
        Me.DESZONA.Name = "DESZONA"
        Me.DESZONA.ReadOnly = True
        Me.DESZONA.Width = 400
        '
        'FECGRADataGridViewTextBoxColumn2
        '
        Me.FECGRADataGridViewTextBoxColumn2.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn2.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn2.Name = "FECGRADataGridViewTextBoxColumn2"
        Me.FECGRADataGridViewTextBoxColumn2.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn2.Visible = False
        '
        'ZONABindingSource
        '
        Me.ZONABindingSource.DataMember = "ZONA"
        Me.ZONABindingSource.DataSource = Me.DsLocalidad
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.cbxPrioridadCiudad)
        Me.Panel1.Controls.Add(Me.lblModificar)
        Me.Panel1.Controls.Add(Me.lblEliminar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.lblNuevo)
        Me.Panel1.Controls.Add(Me.txtLocalidad)
        Me.Panel1.Location = New System.Drawing.Point(14, 367)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(614, 69)
        Me.Panel1.TabIndex = 6
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.BackColor = System.Drawing.Color.Silver
        Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCancelar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCancelar.Location = New System.Drawing.Point(341, 12)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(70, 16)
        Me.lblCancelar.TabIndex = 7
        Me.lblCancelar.Text = "Cancelar"
        '
        'cbxPrioridadCiudad
        '
        Me.cbxPrioridadCiudad.AutoSize = True
        Me.cbxPrioridadCiudad.Location = New System.Drawing.Point(439, 41)
        Me.cbxPrioridadCiudad.Name = "cbxPrioridadCiudad"
        Me.cbxPrioridadCiudad.Size = New System.Drawing.Size(118, 17)
        Me.cbxPrioridadCiudad.TabIndex = 8
        Me.cbxPrioridadCiudad.Text = "Ciudad de Prioridad"
        Me.cbxPrioridadCiudad.UseVisualStyleBackColor = True
        '
        'lblModificar
        '
        Me.lblModificar.AutoSize = True
        Me.lblModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblModificar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblModificar.Location = New System.Drawing.Point(65, 12)
        Me.lblModificar.Name = "lblModificar"
        Me.lblModificar.Size = New System.Drawing.Size(49, 16)
        Me.lblModificar.TabIndex = 6
        Me.lblModificar.Text = "Editar"
        '
        'lblEliminar
        '
        Me.lblEliminar.AutoSize = True
        Me.lblEliminar.BackColor = System.Drawing.Color.Silver
        Me.lblEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblEliminar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblEliminar.Location = New System.Drawing.Point(120, 12)
        Me.lblEliminar.Name = "lblEliminar"
        Me.lblEliminar.Size = New System.Drawing.Size(64, 16)
        Me.lblEliminar.TabIndex = 5
        Me.lblEliminar.Text = "Eliminar"
        '
        'lblGuardar
        '
        Me.lblGuardar.AutoSize = True
        Me.lblGuardar.BackColor = System.Drawing.Color.Silver
        Me.lblGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblGuardar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblGuardar.Location = New System.Drawing.Point(271, 12)
        Me.lblGuardar.Name = "lblGuardar"
        Me.lblGuardar.Size = New System.Drawing.Size(64, 16)
        Me.lblGuardar.TabIndex = 4
        Me.lblGuardar.Text = "Guardar"
        '
        'lblNuevo
        '
        Me.lblNuevo.AutoSize = True
        Me.lblNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNuevo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblNuevo.Location = New System.Drawing.Point(6, 12)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(53, 16)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Nuevo"
        '
        'txtLocalidad
        '
        Me.txtLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocalidad.Location = New System.Drawing.Point(9, 34)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(424, 27)
        Me.txtLocalidad.TabIndex = 0
        '
        'PAISTableAdapter
        '
        Me.PAISTableAdapter.ClearBeforeFill = True
        '
        'CIUDADTableAdapter
        '
        Me.CIUDADTableAdapter.ClearBeforeFill = True
        '
        'ZONATableAdapter
        '
        Me.ZONATableAdapter.ClearBeforeFill = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.Controls.Add(Me.PictureBox8)
        Me.Panel2.Controls.Add(Me.tbxBuscarCiudad)
        Me.Panel2.Controls.Add(Me.tbxBuscarPais)
        Me.Panel2.Controls.Add(Me.tbxBuscarZona)
        Me.Panel2.Location = New System.Drawing.Point(14, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 41)
        Me.Panel2.TabIndex = 10
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox8.TabIndex = 455
        Me.PictureBox8.TabStop = False
        '
        'tbxBuscarCiudad
        '
        Me.tbxBuscarCiudad.BackColor = System.Drawing.Color.Tan
        Me.tbxBuscarCiudad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscarCiudad.ForeColor = System.Drawing.Color.Black
        Me.tbxBuscarCiudad.Location = New System.Drawing.Point(35, 5)
        Me.tbxBuscarCiudad.Name = "tbxBuscarCiudad"
        Me.tbxBuscarCiudad.Size = New System.Drawing.Size(154, 30)
        Me.tbxBuscarCiudad.TabIndex = 458
        '
        'tbxBuscarPais
        '
        Me.tbxBuscarPais.BackColor = System.Drawing.Color.Tan
        Me.tbxBuscarPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscarPais.ForeColor = System.Drawing.Color.Black
        Me.tbxBuscarPais.Location = New System.Drawing.Point(35, 5)
        Me.tbxBuscarPais.Name = "tbxBuscarPais"
        Me.tbxBuscarPais.Size = New System.Drawing.Size(154, 30)
        Me.tbxBuscarPais.TabIndex = 456
        '
        'tbxBuscarZona
        '
        Me.tbxBuscarZona.BackColor = System.Drawing.Color.Tan
        Me.tbxBuscarZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscarZona.ForeColor = System.Drawing.Color.Black
        Me.tbxBuscarZona.Location = New System.Drawing.Point(35, 5)
        Me.tbxBuscarZona.Name = "tbxBuscarZona"
        Me.tbxBuscarZona.Size = New System.Drawing.Size(154, 30)
        Me.tbxBuscarZona.TabIndex = 457
        '
        'ABMPaisV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(643, 445)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tlplocalizacion)
        Me.Controls.Add(Me.pnlHeader)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(659, 483)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(659, 483)
        Me.Name = "ABMPaisV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Localidad  | Cogent SIG"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.tlplocalizacion.ResumeLayout(False)
        CType(Me.dgvPais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCiudad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvZona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblLocalidad As System.Windows.Forms.Label
    Friend WithEvents tlplocalizacion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvPais As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCiudad As System.Windows.Forms.DataGridView
    Friend WithEvents dgvZona As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents lblModificar As System.Windows.Forms.Label
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents txtLocalidad As System.Windows.Forms.TextBox
    Friend WithEvents DsLocalidad As ContaExpress.DsLocalidad
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.DsLocalidadTableAdapters.PAISTableAdapter
    Friend WithEvents CIUDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CIUDADTableAdapter As ContaExpress.DsLocalidadTableAdapters.CIUDADTableAdapter
    Friend WithEvents ZONABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZONATableAdapter As ContaExpress.DsLocalidadTableAdapters.ZONATableAdapter
    Friend WithEvents cbxPrioridadCiudad As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxBuscarPais As System.Windows.Forms.TextBox
    Friend WithEvents tbxBuscarZona As System.Windows.Forms.TextBox
    Friend WithEvents tbxBuscarCiudad As System.Windows.Forms.TextBox
    Friend WithEvents CODPAIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPAISDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPAIS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIORIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCIUDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPARTAMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCIUDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIORIDADDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPAISDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODZONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMZONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESZONA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
