<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMRangoComprobante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMRangoComprobante))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgwPc = New System.Windows.Forms.DataGridView()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettings = New ContaExpress.DsSettings()
        Me.dgwSucursal = New System.Windows.Forms.DataGridView()
        Me.CODSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.dgwDetPc = New System.Windows.Forms.DataGridView()
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RANGO1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RANGO2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ULTIMODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RANDOIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IPDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RANGOPCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtImprimir = New System.Windows.Forms.TextBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.pnlDetPc = New System.Windows.Forms.Panel()
        Me.txtNroDigitos = New System.Windows.Forms.TextBox()
        Me.txtActual = New System.Windows.Forms.TextBox()
        Me.txtHasta = New System.Windows.Forms.TextBox()
        Me.txtDesde = New System.Windows.Forms.TextBox()
        Me.txtTimbrado = New System.Windows.Forms.TextBox()
        Me.dtpFechaValidez = New System.Windows.Forms.DateTimePicker()
        Me.cbxEstado = New System.Windows.Forms.ComboBox()
        Me.cbxImpresora = New System.Windows.Forms.ComboBox()
        Me.cbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.TIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ChckImprimir = New System.Windows.Forms.CheckBox()
        Me.lblNumeracion = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelMaquina = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelSucursal = New System.Windows.Forms.Label()
        Me.SUCURSALTableAdapter = New ContaExpress.DsSettingsTableAdapters.SUCURSALTableAdapter()
        Me.PCTableAdapter = New ContaExpress.DsSettingsTableAdapters.PCTableAdapter()
        Me.RANGOPCTableAdapter = New ContaExpress.DsSettingsTableAdapters.RANGOPCTableAdapter()
        Me.object_cf24c8e9_9b40_4226_8033_46147602fc4e = New Telerik.WinControls.RootRadElement()
        Me.TIPOCOMPROBANTETableAdapter = New ContaExpress.DsSettingsTableAdapters.TIPOCOMPROBANTETableAdapter()
        Me.AUDITORIATABLASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AUDITORIATABLASTableAdapter = New ContaExpress.DsSettingsTableAdapters.AUDITORIATABLASTableAdapter()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgwPc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwDetPc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RANGOPCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetPc.SuspendLayout()
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.SplitContainer1.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgwPc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgwSucursal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LblEstado)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgwDetPc)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtImprimir)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtEstado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitContainer1.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetPc)
        Me.SplitContainer1.Size = New System.Drawing.Size(916, 496)
        Me.SplitContainer1.SplitterDistance = 244
        Me.SplitContainer1.TabIndex = 473
        '
        'dgwPc
        '
        Me.dgwPc.AllowUserToAddRows = False
        Me.dgwPc.AllowUserToDeleteRows = False
        Me.dgwPc.AllowUserToResizeColumns = False
        Me.dgwPc.AllowUserToResizeRows = False
        Me.dgwPc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwPc.AutoGenerateColumns = False
        Me.dgwPc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwPc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwPc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IP, Me.DESCRIPCIONDataGridViewTextBoxColumn})
        Me.dgwPc.DataSource = Me.PCBindingSource
        Me.dgwPc.Location = New System.Drawing.Point(264, 66)
        Me.dgwPc.Name = "dgwPc"
        Me.dgwPc.ReadOnly = True
        Me.dgwPc.RowHeadersVisible = False
        Me.dgwPc.Size = New System.Drawing.Size(247, 169)
        Me.dgwPc.TabIndex = 477
        '
        'IP
        '
        Me.IP.DataPropertyName = "IP"
        Me.IP.HeaderText = "IP"
        Me.IP.Name = "IP"
        Me.IP.ReadOnly = True
        Me.IP.Visible = False
        '
        'DESCRIPCIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Maquinas"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Name = "DESCRIPCIONDataGridViewTextBoxColumn"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PCBindingSource
        '
        Me.PCBindingSource.DataMember = "PC"
        Me.PCBindingSource.DataSource = Me.DsSettings
        '
        'DsSettings
        '
        Me.DsSettings.DataSetName = "DsSettings"
        Me.DsSettings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dgwSucursal
        '
        Me.dgwSucursal.AllowUserToAddRows = False
        Me.dgwSucursal.AllowUserToDeleteRows = False
        Me.dgwSucursal.AllowUserToResizeColumns = False
        Me.dgwSucursal.AllowUserToResizeRows = False
        Me.dgwSucursal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwSucursal.AutoGenerateColumns = False
        Me.dgwSucursal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwSucursal.CausesValidation = False
        Me.dgwSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwSucursal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODSUCURSAL, Me.DESSUCURSAL})
        Me.dgwSucursal.DataSource = Me.SUCURSALBindingSource
        Me.dgwSucursal.Location = New System.Drawing.Point(11, 66)
        Me.dgwSucursal.Name = "dgwSucursal"
        Me.dgwSucursal.ReadOnly = True
        Me.dgwSucursal.RowHeadersVisible = False
        Me.dgwSucursal.Size = New System.Drawing.Size(247, 169)
        Me.dgwSucursal.TabIndex = 476
        '
        'CODSUCURSAL
        '
        Me.CODSUCURSAL.DataPropertyName = "CODSUCURSAL"
        Me.CODSUCURSAL.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSAL.Name = "CODSUCURSAL"
        Me.CODSUCURSAL.ReadOnly = True
        Me.CODSUCURSAL.Visible = False
        '
        'DESSUCURSAL
        '
        Me.DESSUCURSAL.DataPropertyName = "DESSUCURSAL"
        Me.DESSUCURSAL.HeaderText = "Sucursales"
        Me.DESSUCURSAL.Name = "DESSUCURSAL"
        Me.DESSUCURSAL.ReadOnly = True
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsSettings
        '
        'LblEstado
        '
        Me.LblEstado.BackColor = System.Drawing.Color.Transparent
        Me.LblEstado.Font = New System.Drawing.Font("Arial", 14.0!)
        Me.LblEstado.Location = New System.Drawing.Point(757, 39)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(142, 23)
        Me.LblEstado.TabIndex = 475
        Me.LblEstado.Text = "Desactivado"
        Me.LblEstado.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.CancelarPictureBox)
        Me.Panel5.Controls.Add(Me.GuardarPictureBox)
        Me.Panel5.Controls.Add(Me.ModificarPictureBox)
        Me.Panel5.Controls.Add(Me.EliminarPictureBox)
        Me.Panel5.Controls.Add(Me.NuevoPictureBox)
        Me.Panel5.Location = New System.Drawing.Point(-1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(918, 35)
        Me.Panel5.TabIndex = 471
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CancelarPictureBox.Location = New System.Drawing.Point(131, 0)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GuardarPictureBox.Location = New System.Drawing.Point(99, 0)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ModificarPictureBox.Location = New System.Drawing.Point(67, 0)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EliminarPictureBox.Location = New System.Drawing.Point(35, 0)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NuevoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.NuevoPictureBox.Image = CType(resources.GetObject("NuevoPictureBox.Image"), System.Drawing.Image)
        Me.NuevoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NuevoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'dgwDetPc
        '
        Me.dgwDetPc.AllowUserToAddRows = False
        Me.dgwDetPc.AllowUserToDeleteRows = False
        Me.dgwDetPc.AllowUserToResizeColumns = False
        Me.dgwDetPc.AllowUserToResizeRows = False
        Me.dgwDetPc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwDetPc.AutoGenerateColumns = False
        Me.dgwDetPc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwDetPc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwDetPc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESCOMPROBANTEDataGridViewTextBoxColumn, Me.RANGO1DataGridViewTextBoxColumn, Me.RANGO2DataGridViewTextBoxColumn, Me.ULTIMODataGridViewTextBoxColumn, Me.RANDOIDDataGridViewTextBoxColumn, Me.IPDataGridViewTextBoxColumn1})
        Me.dgwDetPc.DataSource = Me.RANGOPCBindingSource
        Me.dgwDetPc.Location = New System.Drawing.Point(517, 66)
        Me.dgwDetPc.Name = "dgwDetPc"
        Me.dgwDetPc.ReadOnly = True
        Me.dgwDetPc.RowHeadersVisible = False
        Me.dgwDetPc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwDetPc.Size = New System.Drawing.Size(386, 169)
        Me.dgwDetPc.TabIndex = 478
        '
        'DESCOMPROBANTEDataGridViewTextBoxColumn
        '
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "DESCOMPROBANTE"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.HeaderText = "Comprobante"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.Name = "DESCOMPROBANTEDataGridViewTextBoxColumn"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RANGO1DataGridViewTextBoxColumn
        '
        Me.RANGO1DataGridViewTextBoxColumn.DataPropertyName = "RANGO1"
        Me.RANGO1DataGridViewTextBoxColumn.HeaderText = "Desde"
        Me.RANGO1DataGridViewTextBoxColumn.Name = "RANGO1DataGridViewTextBoxColumn"
        Me.RANGO1DataGridViewTextBoxColumn.ReadOnly = True
        '
        'RANGO2DataGridViewTextBoxColumn
        '
        Me.RANGO2DataGridViewTextBoxColumn.DataPropertyName = "RANGO2"
        Me.RANGO2DataGridViewTextBoxColumn.HeaderText = "Hasta"
        Me.RANGO2DataGridViewTextBoxColumn.Name = "RANGO2DataGridViewTextBoxColumn"
        Me.RANGO2DataGridViewTextBoxColumn.ReadOnly = True
        '
        'ULTIMODataGridViewTextBoxColumn
        '
        Me.ULTIMODataGridViewTextBoxColumn.DataPropertyName = "ULTIMO"
        Me.ULTIMODataGridViewTextBoxColumn.HeaderText = "Ultimo"
        Me.ULTIMODataGridViewTextBoxColumn.Name = "ULTIMODataGridViewTextBoxColumn"
        Me.ULTIMODataGridViewTextBoxColumn.ReadOnly = True
        '
        'RANDOIDDataGridViewTextBoxColumn
        '
        Me.RANDOIDDataGridViewTextBoxColumn.DataPropertyName = "RANDOID"
        Me.RANDOIDDataGridViewTextBoxColumn.HeaderText = "RANDOID"
        Me.RANDOIDDataGridViewTextBoxColumn.Name = "RANDOIDDataGridViewTextBoxColumn"
        Me.RANDOIDDataGridViewTextBoxColumn.ReadOnly = True
        Me.RANDOIDDataGridViewTextBoxColumn.Visible = False
        '
        'IPDataGridViewTextBoxColumn1
        '
        Me.IPDataGridViewTextBoxColumn1.DataPropertyName = "IP"
        Me.IPDataGridViewTextBoxColumn1.HeaderText = "IP"
        Me.IPDataGridViewTextBoxColumn1.Name = "IPDataGridViewTextBoxColumn1"
        Me.IPDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IPDataGridViewTextBoxColumn1.Visible = False
        '
        'RANGOPCBindingSource
        '
        Me.RANGOPCBindingSource.DataMember = "RANGOPC"
        Me.RANGOPCBindingSource.DataSource = Me.DsSettings
        '
        'txtImprimir
        '
        Me.txtImprimir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "IMPRIMIR", True))
        Me.txtImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtImprimir.Location = New System.Drawing.Point(750, 4)
        Me.txtImprimir.Name = "txtImprimir"
        Me.txtImprimir.Size = New System.Drawing.Size(23, 26)
        Me.txtImprimir.TabIndex = 480
        '
        'txtEstado
        '
        Me.txtEstado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "ACTIVO", True))
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtEstado.Location = New System.Drawing.Point(721, 4)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(23, 26)
        Me.txtEstado.TabIndex = 479
        '
        'pnlDetPc
        '
        Me.pnlDetPc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetPc.Controls.Add(Me.txtNroDigitos)
        Me.pnlDetPc.Controls.Add(Me.txtActual)
        Me.pnlDetPc.Controls.Add(Me.txtHasta)
        Me.pnlDetPc.Controls.Add(Me.txtDesde)
        Me.pnlDetPc.Controls.Add(Me.txtTimbrado)
        Me.pnlDetPc.Controls.Add(Me.dtpFechaValidez)
        Me.pnlDetPc.Controls.Add(Me.cbxEstado)
        Me.pnlDetPc.Controls.Add(Me.cbxImpresora)
        Me.pnlDetPc.Controls.Add(Me.cbxTipoComprobante)
        Me.pnlDetPc.Controls.Add(Me.Label9)
        Me.pnlDetPc.Controls.Add(Me.ChckImprimir)
        Me.pnlDetPc.Controls.Add(Me.lblNumeracion)
        Me.pnlDetPc.Controls.Add(Me.Label15)
        Me.pnlDetPc.Controls.Add(Me.Label14)
        Me.pnlDetPc.Controls.Add(Me.Label8)
        Me.pnlDetPc.Controls.Add(Me.Label5)
        Me.pnlDetPc.Controls.Add(Me.Label6)
        Me.pnlDetPc.Controls.Add(Me.Label13)
        Me.pnlDetPc.Controls.Add(Me.Label7)
        Me.pnlDetPc.Controls.Add(Me.Label10)
        Me.pnlDetPc.Controls.Add(Me.Label11)
        Me.pnlDetPc.Controls.Add(Me.Label4)
        Me.pnlDetPc.Controls.Add(Me.Label3)
        Me.pnlDetPc.Controls.Add(Me.LabelMaquina)
        Me.pnlDetPc.Controls.Add(Me.Panel1)
        Me.pnlDetPc.Controls.Add(Me.LabelSucursal)
        Me.pnlDetPc.Location = New System.Drawing.Point(14, 6)
        Me.pnlDetPc.Name = "pnlDetPc"
        Me.pnlDetPc.Size = New System.Drawing.Size(887, 233)
        Me.pnlDetPc.TabIndex = 477
        '
        'txtNroDigitos
        '
        Me.txtNroDigitos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNroDigitos.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "NRODIGITOS", True))
        Me.txtNroDigitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNroDigitos.Location = New System.Drawing.Point(582, 128)
        Me.txtNroDigitos.Name = "txtNroDigitos"
        Me.txtNroDigitos.Size = New System.Drawing.Size(235, 26)
        Me.txtNroDigitos.TabIndex = 260
        '
        'txtActual
        '
        Me.txtActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtActual.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "ULTIMO", True))
        Me.txtActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtActual.Location = New System.Drawing.Point(582, 98)
        Me.txtActual.Name = "txtActual"
        Me.txtActual.Size = New System.Drawing.Size(235, 26)
        Me.txtActual.TabIndex = 260
        '
        'txtHasta
        '
        Me.txtHasta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "RANGO2", True))
        Me.txtHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtHasta.Location = New System.Drawing.Point(123, 156)
        Me.txtHasta.Name = "txtHasta"
        Me.txtHasta.Size = New System.Drawing.Size(264, 26)
        Me.txtHasta.TabIndex = 260
        '
        'txtDesde
        '
        Me.txtDesde.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "RANGO1", True))
        Me.txtDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDesde.Location = New System.Drawing.Point(123, 126)
        Me.txtDesde.Name = "txtDesde"
        Me.txtDesde.Size = New System.Drawing.Size(264, 26)
        Me.txtDesde.TabIndex = 260
        '
        'txtTimbrado
        '
        Me.txtTimbrado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "TIMBRADO", True))
        Me.txtTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtTimbrado.Location = New System.Drawing.Point(123, 96)
        Me.txtTimbrado.Name = "txtTimbrado"
        Me.txtTimbrado.Size = New System.Drawing.Size(264, 26)
        Me.txtTimbrado.TabIndex = 260
        '
        'dtpFechaValidez
        '
        Me.dtpFechaValidez.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaValidez.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "FECHAVALIDEZ", True))
        Me.dtpFechaValidez.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaValidez.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaValidez.Location = New System.Drawing.Point(582, 67)
        Me.dtpFechaValidez.Name = "dtpFechaValidez"
        Me.dtpFechaValidez.Size = New System.Drawing.Size(235, 26)
        Me.dtpFechaValidez.TabIndex = 259
        '
        'cbxEstado
        '
        Me.cbxEstado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxEstado.FormattingEnabled = True
        Me.cbxEstado.Items.AddRange(New Object() {"Activo", "Pendiente", "Desactivado"})
        Me.cbxEstado.Location = New System.Drawing.Point(582, 157)
        Me.cbxEstado.Name = "cbxEstado"
        Me.cbxEstado.Size = New System.Drawing.Size(235, 28)
        Me.cbxEstado.TabIndex = 257
        '
        'cbxImpresora
        '
        Me.cbxImpresora.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "IMPRESORA", True))
        Me.cbxImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxImpresora.FormattingEnabled = True
        Me.cbxImpresora.Location = New System.Drawing.Point(123, 185)
        Me.cbxImpresora.Name = "cbxImpresora"
        Me.cbxImpresora.Size = New System.Drawing.Size(264, 28)
        Me.cbxImpresora.TabIndex = 258
        '
        'cbxTipoComprobante
        '
        Me.cbxTipoComprobante.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.RANGOPCBindingSource, "CODCOMPROBANTE", True))
        Me.cbxTipoComprobante.DataSource = Me.TIPOCOMPROBANTEBindingSource
        Me.cbxTipoComprobante.DisplayMember = "DESCOMPROBANTE"
        Me.cbxTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxTipoComprobante.FormattingEnabled = True
        Me.cbxTipoComprobante.Location = New System.Drawing.Point(123, 64)
        Me.cbxTipoComprobante.Name = "cbxTipoComprobante"
        Me.cbxTipoComprobante.Size = New System.Drawing.Size(264, 28)
        Me.cbxTipoComprobante.TabIndex = 257
        Me.cbxTipoComprobante.ValueMember = "CODCOMPROBANTE"
        '
        'TIPOCOMPROBANTEBindingSource
        '
        Me.TIPOCOMPROBANTEBindingSource.DataMember = "TIPOCOMPROBANTE"
        Me.TIPOCOMPROBANTEBindingSource.DataSource = Me.DsSettings
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(535, 165)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 256
        Me.Label9.Text = "Estado:"
        '
        'ChckImprimir
        '
        Me.ChckImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChckImprimir.AutoSize = True
        Me.ChckImprimir.BackColor = System.Drawing.Color.Transparent
        Me.ChckImprimir.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChckImprimir.Location = New System.Drawing.Point(533, 193)
        Me.ChckImprimir.Name = "ChckImprimir"
        Me.ChckImprimir.Size = New System.Drawing.Size(64, 17)
        Me.ChckImprimir.TabIndex = 246
        Me.ChckImprimir.Text = "Imprimir:"
        Me.ChckImprimir.UseVisualStyleBackColor = False
        '
        'lblNumeracion
        '
        Me.lblNumeracion.AutoSize = True
        Me.lblNumeracion.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeracion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.RANGOPCBindingSource, "Numeracion", True))
        Me.lblNumeracion.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeracion.Location = New System.Drawing.Point(723, 15)
        Me.lblNumeracion.Name = "lblNumeracion"
        Me.lblNumeracion.Size = New System.Drawing.Size(135, 18)
        Me.lblNumeracion.TabIndex = 255
        Me.lblNumeracion.Text = "001-001-1234567"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(615, 15)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 18)
        Me.Label15.TabIndex = 254
        Me.Label15.Text = "Numeración :"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(514, 135)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 13)
        Me.Label14.TabIndex = 253
        Me.Label14.Text = "Nro Dígitos:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(62, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Timbrado:"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(518, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Actual Nro:"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(501, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "Fecha Validez:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(60, 193)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 13)
        Me.Label13.TabIndex = 241
        Me.Label13.Text = "Impresora:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(58, 163)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 249
        Me.Label7.Text = "Hasta Nro:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(55, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 13)
        Me.Label10.TabIndex = 248
        Me.Label10.Text = "Desde Nro:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(43, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 13)
        Me.Label11.TabIndex = 247
        Me.Label11.Text = "Comprobante:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(302, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 18)
        Me.Label4.TabIndex = 245
        Me.Label4.Text = "Máquina:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 18)
        Me.Label3.TabIndex = 244
        Me.Label3.Text = "Sucursal:"
        '
        'LabelMaquina
        '
        Me.LabelMaquina.BackColor = System.Drawing.Color.Transparent
        Me.LabelMaquina.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PCBindingSource, "NOMBRE", True))
        Me.LabelMaquina.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMaquina.Location = New System.Drawing.Point(382, 13)
        Me.LabelMaquina.Name = "LabelMaquina"
        Me.LabelMaquina.Size = New System.Drawing.Size(225, 23)
        Me.LabelMaquina.TabIndex = 243
        Me.LabelMaquina.Text = "Label1Maquina"
        Me.LabelMaquina.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(13, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(860, 2)
        Me.Panel1.TabIndex = 242
        '
        'LabelSucursal
        '
        Me.LabelSucursal.BackColor = System.Drawing.Color.Transparent
        Me.LabelSucursal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SUCURSALBindingSource, "DESSUCURSAL", True))
        Me.LabelSucursal.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSucursal.Location = New System.Drawing.Point(90, 13)
        Me.LabelSucursal.Name = "LabelSucursal"
        Me.LabelSucursal.Size = New System.Drawing.Size(204, 23)
        Me.LabelSucursal.TabIndex = 240
        Me.LabelSucursal.Text = "Label1Sucursal"
        Me.LabelSucursal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'PCTableAdapter
        '
        Me.PCTableAdapter.ClearBeforeFill = True
        '
        'RANGOPCTableAdapter
        '
        Me.RANGOPCTableAdapter.ClearBeforeFill = True
        '
        'object_cf24c8e9_9b40_4226_8033_46147602fc4e
        '
        Me.object_cf24c8e9_9b40_4226_8033_46147602fc4e.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.object_cf24c8e9_9b40_4226_8033_46147602fc4e.Name = "object_cf24c8e9_9b40_4226_8033_46147602fc4e"
        Me.object_cf24c8e9_9b40_4226_8033_46147602fc4e.StretchHorizontally = True
        Me.object_cf24c8e9_9b40_4226_8033_46147602fc4e.StretchVertically = True
        '
        'TIPOCOMPROBANTETableAdapter
        '
        Me.TIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'AUDITORIATABLASBindingSource
        '
        Me.AUDITORIATABLASBindingSource.DataMember = "AUDITORIATABLAS"
        Me.AUDITORIATABLASBindingSource.DataSource = Me.DsSettings
        '
        'AUDITORIATABLASTableAdapter
        '
        Me.AUDITORIATABLASTableAdapter.ClearBeforeFill = True
        '
        'ABMRangoComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 496)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ABMRangoComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rango de Comprobante  | Cogent SIG"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgwPc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwDetPc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RANGOPCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetPc.ResumeLayout(False)
        Me.pnlDetPc.PerformLayout()
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LblEstado As System.Windows.Forms.Label
    Friend WithEvents dgwSucursal As System.Windows.Forms.DataGridView
    Friend WithEvents dgwDetPc As System.Windows.Forms.DataGridView
    Friend WithEvents dgwPc As System.Windows.Forms.DataGridView
    Friend WithEvents DsSettings As ContaExpress.DsSettings
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsSettingsTableAdapters.SUCURSALTableAdapter
    Friend WithEvents PCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PCTableAdapter As ContaExpress.DsSettingsTableAdapters.PCTableAdapter
    Friend WithEvents CODSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RANGOPCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RANGOPCTableAdapter As ContaExpress.DsSettingsTableAdapters.RANGOPCTableAdapter
    Friend WithEvents DESCOMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RANGO1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RANGO2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ULTIMODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RANDOIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IPDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlDetPc As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ChckImprimir As System.Windows.Forms.CheckBox
    Friend WithEvents lblNumeracion As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelMaquina As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelSucursal As System.Windows.Forms.Label
    Friend WithEvents txtNroDigitos As System.Windows.Forms.TextBox
    Friend WithEvents txtActual As System.Windows.Forms.TextBox
    Friend WithEvents txtHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaValidez As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxEstado As System.Windows.Forms.ComboBox
    Friend WithEvents cbxImpresora As System.Windows.Forms.ComboBox
    Friend WithEvents cbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents object_cf24c8e9_9b40_4226_8033_46147602fc4e As Telerik.WinControls.RootRadElement
    Friend WithEvents TIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCOMPROBANTETableAdapter As ContaExpress.DsSettingsTableAdapters.TIPOCOMPROBANTETableAdapter
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtImprimir As System.Windows.Forms.TextBox
    Friend WithEvents AUDITORIATABLASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AUDITORIATABLASTableAdapter As ContaExpress.DsSettingsTableAdapters.AUDITORIATABLASTableAdapter
End Class
