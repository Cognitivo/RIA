<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMCategorias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMCategorias))
        Me.dgvCategorias = New System.Windows.Forms.DataGridView()
        Me.CODFAMILIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMFAMILIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFAMILIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAMILIABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCategorizacion = New ContaExpress.DsCategorizacion()
        Me.dgvLinea = New System.Windows.Forms.DataGridView()
        Me.CODLINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODFAMILIADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMLINEADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESLINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFAMILIADataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LINEABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tlpCategorizacion = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvRubro = New System.Windows.Forms.DataGridView()
        Me.CODRUBRO1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODLINEADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMRUBRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESRUBRO2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESLINEADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCancelar = New System.Windows.Forms.Label()
        Me.lblModificar = New System.Windows.Forms.Label()
        Me.lblEliminar = New System.Windows.Forms.Label()
        Me.lblGuardar = New System.Windows.Forms.Label()
        Me.lblNuevo = New System.Windows.Forms.Label()
        Me.txtCategorizacion = New System.Windows.Forms.TextBox()
        Me.lblCategorizacion = New System.Windows.Forms.Label()
        Me.FAMILIATableAdapter = New ContaExpress.DsCategorizacionTableAdapters.FAMILIATableAdapter()
        Me.LINEATableAdapter = New ContaExpress.DsCategorizacionTableAdapters.LINEATableAdapter()
        Me.RUBROTableAdapter = New ContaExpress.DsCategorizacionTableAdapters.RUBROTableAdapter()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.CODRUBRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvCategorias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FAMILIABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCategorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LINEABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpCategorizacion.SuspendLayout()
        CType(Me.dgvRubro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RUBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvCategorias
        '
        Me.dgvCategorias.AllowUserToAddRows = False
        Me.dgvCategorias.AllowUserToDeleteRows = False
        Me.dgvCategorias.AllowUserToResizeColumns = False
        Me.dgvCategorias.AllowUserToResizeRows = False
        Me.dgvCategorias.AutoGenerateColumns = False
        Me.dgvCategorias.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvCategorias.CausesValidation = False
        Me.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCategorias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODFAMILIA, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMFAMILIADataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn, Me.DESFAMILIA})
        Me.dgvCategorias.DataSource = Me.FAMILIABindingSource
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCategorias.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCategorias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCategorias.EnableHeadersVisualStyles = False
        Me.dgvCategorias.Location = New System.Drawing.Point(3, 3)
        Me.dgvCategorias.Name = "dgvCategorias"
        Me.dgvCategorias.ReadOnly = True
        Me.dgvCategorias.RowHeadersVisible = False
        Me.dgvCategorias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCategorias.Size = New System.Drawing.Size(200, 315)
        Me.dgvCategorias.TabIndex = 0
        '
        'CODFAMILIA
        '
        Me.CODFAMILIA.DataPropertyName = "CODFAMILIA"
        Me.CODFAMILIA.HeaderText = "CODFAMILIA"
        Me.CODFAMILIA.MinimumWidth = 2
        Me.CODFAMILIA.Name = "CODFAMILIA"
        Me.CODFAMILIA.ReadOnly = True
        Me.CODFAMILIA.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CODFAMILIA.Width = 2
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
        'NUMFAMILIADataGridViewTextBoxColumn
        '
        Me.NUMFAMILIADataGridViewTextBoxColumn.DataPropertyName = "NUMFAMILIA"
        Me.NUMFAMILIADataGridViewTextBoxColumn.HeaderText = "NUMFAMILIA"
        Me.NUMFAMILIADataGridViewTextBoxColumn.Name = "NUMFAMILIADataGridViewTextBoxColumn"
        Me.NUMFAMILIADataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMFAMILIADataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'DESFAMILIA
        '
        Me.DESFAMILIA.DataPropertyName = "DESFAMILIA"
        Me.DESFAMILIA.HeaderText = "FAMILIA"
        Me.DESFAMILIA.Name = "DESFAMILIA"
        Me.DESFAMILIA.ReadOnly = True
        Me.DESFAMILIA.Width = 400
        '
        'FAMILIABindingSource
        '
        Me.FAMILIABindingSource.DataMember = "FAMILIA"
        Me.FAMILIABindingSource.DataSource = Me.DsCategorizacion
        '
        'DsCategorizacion
        '
        Me.DsCategorizacion.DataSetName = "DsCategorizacion"
        Me.DsCategorizacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgvLinea
        '
        Me.dgvLinea.AllowUserToAddRows = False
        Me.dgvLinea.AllowUserToDeleteRows = False
        Me.dgvLinea.AllowUserToResizeColumns = False
        Me.dgvLinea.AllowUserToResizeRows = False
        Me.dgvLinea.AutoGenerateColumns = False
        Me.dgvLinea.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvLinea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLinea.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODLINEA, Me.CODFAMILIADataGridViewTextBoxColumn1, Me.CODUSUARIODataGridViewTextBoxColumn1, Me.CODEMPRESADataGridViewTextBoxColumn1, Me.NUMLINEADataGridViewTextBoxColumn, Me.DESLINEA, Me.FECGRADataGridViewTextBoxColumn1, Me.DESFAMILIADataGridViewTextBoxColumn1})
        Me.dgvLinea.DataSource = Me.LINEABindingSource
        Me.dgvLinea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLinea.EnableHeadersVisualStyles = False
        Me.dgvLinea.Location = New System.Drawing.Point(209, 3)
        Me.dgvLinea.Name = "dgvLinea"
        Me.dgvLinea.ReadOnly = True
        Me.dgvLinea.RowHeadersVisible = False
        Me.dgvLinea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvLinea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLinea.Size = New System.Drawing.Size(200, 315)
        Me.dgvLinea.TabIndex = 0
        '
        'CODLINEA
        '
        Me.CODLINEA.DataPropertyName = "CODLINEA"
        Me.CODLINEA.HeaderText = "CODLINEA"
        Me.CODLINEA.MinimumWidth = 2
        Me.CODLINEA.Name = "CODLINEA"
        Me.CODLINEA.ReadOnly = True
        Me.CODLINEA.Width = 2
        '
        'CODFAMILIADataGridViewTextBoxColumn1
        '
        Me.CODFAMILIADataGridViewTextBoxColumn1.DataPropertyName = "CODFAMILIA"
        Me.CODFAMILIADataGridViewTextBoxColumn1.HeaderText = "CODFAMILIA"
        Me.CODFAMILIADataGridViewTextBoxColumn1.Name = "CODFAMILIADataGridViewTextBoxColumn1"
        Me.CODFAMILIADataGridViewTextBoxColumn1.ReadOnly = True
        Me.CODFAMILIADataGridViewTextBoxColumn1.Visible = False
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
        'NUMLINEADataGridViewTextBoxColumn
        '
        Me.NUMLINEADataGridViewTextBoxColumn.DataPropertyName = "NUMLINEA"
        Me.NUMLINEADataGridViewTextBoxColumn.HeaderText = "NUMLINEA"
        Me.NUMLINEADataGridViewTextBoxColumn.Name = "NUMLINEADataGridViewTextBoxColumn"
        Me.NUMLINEADataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMLINEADataGridViewTextBoxColumn.Visible = False
        '
        'DESLINEA
        '
        Me.DESLINEA.DataPropertyName = "DESLINEA"
        Me.DESLINEA.HeaderText = "LINEA"
        Me.DESLINEA.Name = "DESLINEA"
        Me.DESLINEA.ReadOnly = True
        Me.DESLINEA.Width = 400
        '
        'FECGRADataGridViewTextBoxColumn1
        '
        Me.FECGRADataGridViewTextBoxColumn1.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn1.Name = "FECGRADataGridViewTextBoxColumn1"
        Me.FECGRADataGridViewTextBoxColumn1.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn1.Visible = False
        '
        'DESFAMILIADataGridViewTextBoxColumn1
        '
        Me.DESFAMILIADataGridViewTextBoxColumn1.DataPropertyName = "DESFAMILIA"
        Me.DESFAMILIADataGridViewTextBoxColumn1.HeaderText = "DESFAMILIA"
        Me.DESFAMILIADataGridViewTextBoxColumn1.Name = "DESFAMILIADataGridViewTextBoxColumn1"
        Me.DESFAMILIADataGridViewTextBoxColumn1.ReadOnly = True
        Me.DESFAMILIADataGridViewTextBoxColumn1.Visible = False
        '
        'LINEABindingSource
        '
        Me.LINEABindingSource.DataMember = "LINEA"
        Me.LINEABindingSource.DataSource = Me.DsCategorizacion
        '
        'tlpCategorizacion
        '
        Me.tlpCategorizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpCategorizacion.BackColor = System.Drawing.Color.LightGray
        Me.tlpCategorizacion.ColumnCount = 3
        Me.tlpCategorizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332!))
        Me.tlpCategorizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpCategorizacion.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334!))
        Me.tlpCategorizacion.Controls.Add(Me.dgvCategorias, 0, 0)
        Me.tlpCategorizacion.Controls.Add(Me.dgvLinea, 1, 0)
        Me.tlpCategorizacion.Controls.Add(Me.dgvRubro, 2, 0)
        Me.tlpCategorizacion.Location = New System.Drawing.Point(10, 51)
        Me.tlpCategorizacion.Name = "tlpCategorizacion"
        Me.tlpCategorizacion.RowCount = 1
        Me.tlpCategorizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpCategorizacion.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 321.0!))
        Me.tlpCategorizacion.Size = New System.Drawing.Size(619, 321)
        Me.tlpCategorizacion.TabIndex = 1
        '
        'dgvRubro
        '
        Me.dgvRubro.AllowUserToAddRows = False
        Me.dgvRubro.AllowUserToDeleteRows = False
        Me.dgvRubro.AllowUserToResizeColumns = False
        Me.dgvRubro.AllowUserToResizeRows = False
        Me.dgvRubro.AutoGenerateColumns = False
        Me.dgvRubro.BackgroundColor = System.Drawing.Color.DarkGray
        Me.dgvRubro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRubro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODRUBRO1, Me.CODLINEADataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn2, Me.CODEMPRESADataGridViewTextBoxColumn2, Me.NUMRUBRODataGridViewTextBoxColumn, Me.DESRUBRO2, Me.DESLINEADataGridViewTextBoxColumn})
        Me.dgvRubro.DataSource = Me.RUBROBindingSource
        Me.dgvRubro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRubro.EnableHeadersVisualStyles = False
        Me.dgvRubro.Location = New System.Drawing.Point(415, 3)
        Me.dgvRubro.Name = "dgvRubro"
        Me.dgvRubro.ReadOnly = True
        Me.dgvRubro.RowHeadersVisible = False
        Me.dgvRubro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvRubro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRubro.Size = New System.Drawing.Size(201, 315)
        Me.dgvRubro.TabIndex = 0
        '
        'CODRUBRO1
        '
        Me.CODRUBRO1.DataPropertyName = "CODRUBRO"
        Me.CODRUBRO1.HeaderText = "CODRUBRO"
        Me.CODRUBRO1.MinimumWidth = 2
        Me.CODRUBRO1.Name = "CODRUBRO1"
        Me.CODRUBRO1.ReadOnly = True
        Me.CODRUBRO1.Width = 2
        '
        'CODLINEADataGridViewTextBoxColumn
        '
        Me.CODLINEADataGridViewTextBoxColumn.DataPropertyName = "CODLINEA"
        Me.CODLINEADataGridViewTextBoxColumn.HeaderText = "CODLINEA"
        Me.CODLINEADataGridViewTextBoxColumn.Name = "CODLINEADataGridViewTextBoxColumn"
        Me.CODLINEADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODLINEADataGridViewTextBoxColumn.Visible = False
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
        'NUMRUBRODataGridViewTextBoxColumn
        '
        Me.NUMRUBRODataGridViewTextBoxColumn.DataPropertyName = "NUMRUBRO"
        Me.NUMRUBRODataGridViewTextBoxColumn.HeaderText = "NUMRUBRO"
        Me.NUMRUBRODataGridViewTextBoxColumn.Name = "NUMRUBRODataGridViewTextBoxColumn"
        Me.NUMRUBRODataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMRUBRODataGridViewTextBoxColumn.Visible = False
        '
        'DESRUBRO2
        '
        Me.DESRUBRO2.DataPropertyName = "DESRUBRO"
        Me.DESRUBRO2.HeaderText = "RUBRO"
        Me.DESRUBRO2.Name = "DESRUBRO2"
        Me.DESRUBRO2.ReadOnly = True
        Me.DESRUBRO2.Width = 400
        '
        'DESLINEADataGridViewTextBoxColumn
        '
        Me.DESLINEADataGridViewTextBoxColumn.DataPropertyName = "DESLINEA"
        Me.DESLINEADataGridViewTextBoxColumn.HeaderText = "DESLINEA"
        Me.DESLINEADataGridViewTextBoxColumn.Name = "DESLINEADataGridViewTextBoxColumn"
        Me.DESLINEADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESLINEADataGridViewTextBoxColumn.Visible = False
        '
        'RUBROBindingSource
        '
        Me.RUBROBindingSource.DataMember = "RUBRO"
        Me.RUBROBindingSource.DataSource = Me.DsCategorizacion
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Silver
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.lblCancelar)
        Me.Panel1.Controls.Add(Me.lblModificar)
        Me.Panel1.Controls.Add(Me.lblEliminar)
        Me.Panel1.Controls.Add(Me.lblGuardar)
        Me.Panel1.Controls.Add(Me.lblNuevo)
        Me.Panel1.Controls.Add(Me.txtCategorizacion)
        Me.Panel1.Location = New System.Drawing.Point(10, 376)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 61)
        Me.Panel1.TabIndex = 2
        '
        'lblCancelar
        '
        Me.lblCancelar.AutoSize = True
        Me.lblCancelar.BackColor = System.Drawing.Color.Silver
        Me.lblCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblCancelar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCancelar.Location = New System.Drawing.Point(345, 5)
        Me.lblCancelar.Name = "lblCancelar"
        Me.lblCancelar.Size = New System.Drawing.Size(70, 16)
        Me.lblCancelar.TabIndex = 7
        Me.lblCancelar.Text = "Cancelar"
        '
        'lblModificar
        '
        Me.lblModificar.AutoSize = True
        Me.lblModificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblModificar.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblModificar.Location = New System.Drawing.Point(69, 5)
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
        Me.lblEliminar.Location = New System.Drawing.Point(124, 5)
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
        Me.lblGuardar.Location = New System.Drawing.Point(275, 5)
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
        Me.lblNuevo.Location = New System.Drawing.Point(10, 5)
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Size = New System.Drawing.Size(53, 16)
        Me.lblNuevo.TabIndex = 3
        Me.lblNuevo.Text = "Nuevo"
        '
        'txtCategorizacion
        '
        Me.txtCategorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategorizacion.Location = New System.Drawing.Point(13, 27)
        Me.txtCategorizacion.Name = "txtCategorizacion"
        Me.txtCategorizacion.Size = New System.Drawing.Size(424, 27)
        Me.txtCategorizacion.TabIndex = 0
        '
        'lblCategorizacion
        '
        Me.lblCategorizacion.AutoSize = True
        Me.lblCategorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblCategorizacion.Location = New System.Drawing.Point(10, 10)
        Me.lblCategorizacion.Name = "lblCategorizacion"
        Me.lblCategorizacion.Size = New System.Drawing.Size(147, 22)
        Me.lblCategorizacion.TabIndex = 1
        Me.lblCategorizacion.Text = "lblCategorizacion"
        '
        'FAMILIATableAdapter
        '
        Me.FAMILIATableAdapter.ClearBeforeFill = True
        '
        'LINEATableAdapter
        '
        Me.LINEATableAdapter.ClearBeforeFill = True
        '
        'RUBROTableAdapter
        '
        Me.RUBROTableAdapter.ClearBeforeFill = True
        '
        'pnlHeader
        '
        Me.pnlHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHeader.BackColor = System.Drawing.Color.DarkGray
        Me.pnlHeader.Controls.Add(Me.lblCategorizacion)
        Me.pnlHeader.Location = New System.Drawing.Point(13, 7)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(612, 41)
        Me.pnlHeader.TabIndex = 3
        '
        'CODRUBRO
        '
        Me.CODRUBRO.DataPropertyName = "CODRUBRO"
        Me.CODRUBRO.HeaderText = "CODRUBRO"
        Me.CODRUBRO.Name = "CODRUBRO"
        Me.CODRUBRO.Visible = False
        '
        'ABMCategorias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(643, 445)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tlpCategorizacion)
        Me.Controls.Add(Me.pnlHeader)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(659, 483)
        Me.MinimumSize = New System.Drawing.Size(659, 483)
        Me.Name = "ABMCategorias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categorias  | Cogent SIG"
        CType(Me.dgvCategorias,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.FAMILIABindingSource,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DsCategorizacion,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvLinea,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.LINEABindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.tlpCategorizacion.ResumeLayout(false)
        CType(Me.dgvRubro,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RUBROBindingSource,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.pnlHeader.ResumeLayout(false)
        Me.pnlHeader.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents dgvLinea As System.Windows.Forms.DataGridView
    Friend WithEvents tlpCategorizacion As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dgvRubro As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCategorizacion As System.Windows.Forms.Label
    Friend WithEvents txtCategorizacion As System.Windows.Forms.TextBox
    Friend WithEvents DsCategorizacion As ContaExpress.DsCategorizacion
    Friend WithEvents FAMILIABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FAMILIATableAdapter As ContaExpress.DsCategorizacionTableAdapters.FAMILIATableAdapter
    Friend WithEvents LINEABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LINEATableAdapter As ContaExpress.DsCategorizacionTableAdapters.LINEATableAdapter
    Friend WithEvents RUBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RUBROTableAdapter As ContaExpress.DsCategorizacionTableAdapters.RUBROTableAdapter
    Friend WithEvents lblNuevo As System.Windows.Forms.Label
    Friend WithEvents lblGuardar As System.Windows.Forms.Label
    Friend WithEvents lblEliminar As System.Windows.Forms.Label
    Friend WithEvents lblModificar As System.Windows.Forms.Label
    Friend WithEvents lblCancelar As System.Windows.Forms.Label
    Friend WithEvents DESRUBRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents DESRUBRO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODRUBRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvCategorias As System.Windows.Forms.DataGridView
    Friend WithEvents CODFAMILIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMFAMILIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFAMILIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODLINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODFAMILIADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMLINEADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESLINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFAMILIADataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODRUBRO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODLINEADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMRUBRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESRUBRO2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESLINEADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
