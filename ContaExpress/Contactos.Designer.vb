<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Contactos
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvContacto = New System.Windows.Forms.DataGridView()
        Me.CODCONTACTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCONTACTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APELLIDODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCEDULADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELEFONODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CELULARDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DEPARTAMENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONTACTOSBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsContactos = New ContaExpress.dsContactos()
        Me.CONTACTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsContactosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.tbxCel = New System.Windows.Forms.TextBox()
        Me.tbxTel = New System.Windows.Forms.TextBox()
        Me.tbxContacto = New System.Windows.Forms.TextBox()
        Me.tbxEmail = New System.Windows.Forms.TextBox()
        Me.pbxVerCliente = New System.Windows.Forms.PictureBox()
        Me.cbxCliente = New System.Windows.Forms.ComboBox()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCliente = New ContaExpress.DsCliente()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbxVerShpr = New System.Windows.Forms.PictureBox()
        Me.cbxShpr = New System.Windows.Forms.ComboBox()
        Me.SHPRCNEEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSHPRCNEE = New ContaExpress.dsSHPRCNEE()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pbxVerProv = New System.Windows.Forms.PictureBox()
        Me.cbxProv = New System.Windows.Forms.ComboBox()
        Me.PROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProveedores = New ContaExpress.DsProveedores()
        Me.rbtCliente = New System.Windows.Forms.RadioButton()
        Me.rbtShpr = New System.Windows.Forms.RadioButton()
        Me.rbtProv = New System.Windows.Forms.RadioButton()
        Me.CONTACTOSTableAdapter = New ContaExpress.dsContactosTableAdapters.CONTACTOSTableAdapter()
        Me.CLIENTESTableAdapter = New ContaExpress.DsClienteTableAdapters.CLIENTESTableAdapter()
        Me.SHPRCNEETableAdapter = New ContaExpress.dsSHPRCNEETableAdapters.SHPRCNEETableAdapter()
        Me.PROVEEDORTableAdapter = New ContaExpress.DsProveedoresTableAdapters.PROVEEDORTableAdapter()
        CType(Me.dgvContacto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONTACTOSBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsContactos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CONTACTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsContactosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxVerCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxVerShpr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHPRCNEEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSHPRCNEE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxVerProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvContacto
        '
        Me.dgvContacto.AllowUserToAddRows = False
        Me.dgvContacto.AllowUserToDeleteRows = False
        Me.dgvContacto.AllowUserToOrderColumns = True
        Me.dgvContacto.AllowUserToResizeRows = False
        Me.dgvContacto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvContacto.AutoGenerateColumns = False
        Me.dgvContacto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvContacto.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContacto.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvContacto.ColumnHeadersHeight = 35
        Me.dgvContacto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCONTACTODataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMCONTACTODataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn, Me.APELLIDODataGridViewTextBoxColumn, Me.NUMCEDULADataGridViewTextBoxColumn, Me.RUCDataGridViewTextBoxColumn, Me.DIRECCIONDataGridViewTextBoxColumn, Me.TELEFONODataGridViewTextBoxColumn, Me.CELULARDataGridViewTextBoxColumn, Me.EMAILDataGridViewTextBoxColumn, Me.CODCLIENTEDataGridViewTextBoxColumn, Me.DEPARTAMENTODataGridViewTextBoxColumn})
        Me.dgvContacto.DataSource = Me.CONTACTOSBindingSource1
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvContacto.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvContacto.GridColor = System.Drawing.Color.Lavender
        Me.dgvContacto.Location = New System.Drawing.Point(6, 46)
        Me.dgvContacto.Name = "dgvContacto"
        Me.dgvContacto.ReadOnly = True
        Me.dgvContacto.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvContacto.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvContacto.RowHeadersVisible = False
        Me.dgvContacto.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvContacto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvContacto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContacto.Size = New System.Drawing.Size(227, 483)
        Me.dgvContacto.TabIndex = 483
        '
        'CODCONTACTODataGridViewTextBoxColumn
        '
        Me.CODCONTACTODataGridViewTextBoxColumn.DataPropertyName = "CODCONTACTO"
        Me.CODCONTACTODataGridViewTextBoxColumn.HeaderText = "CODCONTACTO"
        Me.CODCONTACTODataGridViewTextBoxColumn.Name = "CODCONTACTODataGridViewTextBoxColumn"
        Me.CODCONTACTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCONTACTODataGridViewTextBoxColumn.Visible = False
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
        'NUMCONTACTODataGridViewTextBoxColumn
        '
        Me.NUMCONTACTODataGridViewTextBoxColumn.DataPropertyName = "NUMCONTACTO"
        Me.NUMCONTACTODataGridViewTextBoxColumn.HeaderText = "NUMCONTACTO"
        Me.NUMCONTACTODataGridViewTextBoxColumn.Name = "NUMCONTACTODataGridViewTextBoxColumn"
        Me.NUMCONTACTODataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMCONTACTODataGridViewTextBoxColumn.Visible = False
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Nombre del Contacto"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
        '
        'APELLIDODataGridViewTextBoxColumn
        '
        Me.APELLIDODataGridViewTextBoxColumn.DataPropertyName = "APELLIDO"
        Me.APELLIDODataGridViewTextBoxColumn.HeaderText = "APELLIDO"
        Me.APELLIDODataGridViewTextBoxColumn.Name = "APELLIDODataGridViewTextBoxColumn"
        Me.APELLIDODataGridViewTextBoxColumn.ReadOnly = True
        Me.APELLIDODataGridViewTextBoxColumn.Visible = False
        '
        'NUMCEDULADataGridViewTextBoxColumn
        '
        Me.NUMCEDULADataGridViewTextBoxColumn.DataPropertyName = "NUMCEDULA"
        Me.NUMCEDULADataGridViewTextBoxColumn.HeaderText = "NUMCEDULA"
        Me.NUMCEDULADataGridViewTextBoxColumn.Name = "NUMCEDULADataGridViewTextBoxColumn"
        Me.NUMCEDULADataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMCEDULADataGridViewTextBoxColumn.Visible = False
        '
        'RUCDataGridViewTextBoxColumn
        '
        Me.RUCDataGridViewTextBoxColumn.DataPropertyName = "RUC"
        Me.RUCDataGridViewTextBoxColumn.HeaderText = "RUC"
        Me.RUCDataGridViewTextBoxColumn.Name = "RUCDataGridViewTextBoxColumn"
        Me.RUCDataGridViewTextBoxColumn.ReadOnly = True
        Me.RUCDataGridViewTextBoxColumn.Visible = False
        '
        'DIRECCIONDataGridViewTextBoxColumn
        '
        Me.DIRECCIONDataGridViewTextBoxColumn.DataPropertyName = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.HeaderText = "DIRECCION"
        Me.DIRECCIONDataGridViewTextBoxColumn.Name = "DIRECCIONDataGridViewTextBoxColumn"
        Me.DIRECCIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.DIRECCIONDataGridViewTextBoxColumn.Visible = False
        '
        'TELEFONODataGridViewTextBoxColumn
        '
        Me.TELEFONODataGridViewTextBoxColumn.DataPropertyName = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.HeaderText = "TELEFONO"
        Me.TELEFONODataGridViewTextBoxColumn.Name = "TELEFONODataGridViewTextBoxColumn"
        Me.TELEFONODataGridViewTextBoxColumn.ReadOnly = True
        Me.TELEFONODataGridViewTextBoxColumn.Visible = False
        '
        'CELULARDataGridViewTextBoxColumn
        '
        Me.CELULARDataGridViewTextBoxColumn.DataPropertyName = "CELULAR"
        Me.CELULARDataGridViewTextBoxColumn.HeaderText = "CELULAR"
        Me.CELULARDataGridViewTextBoxColumn.Name = "CELULARDataGridViewTextBoxColumn"
        Me.CELULARDataGridViewTextBoxColumn.ReadOnly = True
        Me.CELULARDataGridViewTextBoxColumn.Visible = False
        '
        'EMAILDataGridViewTextBoxColumn
        '
        Me.EMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.Name = "EMAILDataGridViewTextBoxColumn"
        Me.EMAILDataGridViewTextBoxColumn.ReadOnly = True
        Me.EMAILDataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'DEPARTAMENTODataGridViewTextBoxColumn
        '
        Me.DEPARTAMENTODataGridViewTextBoxColumn.DataPropertyName = "DEPARTAMENTO"
        Me.DEPARTAMENTODataGridViewTextBoxColumn.HeaderText = "DEPARTAMENTO"
        Me.DEPARTAMENTODataGridViewTextBoxColumn.Name = "DEPARTAMENTODataGridViewTextBoxColumn"
        Me.DEPARTAMENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.DEPARTAMENTODataGridViewTextBoxColumn.Visible = False
        '
        'CONTACTOSBindingSource1
        '
        Me.CONTACTOSBindingSource1.DataMember = "CONTACTOS"
        Me.CONTACTOSBindingSource1.DataSource = Me.DsContactos
        '
        'DsContactos
        '
        Me.DsContactos.DataSetName = "dsContactos"
        Me.DsContactos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CONTACTOSBindingSource
        '
        Me.CONTACTOSBindingSource.DataMember = "CONTACTOS"
        Me.CONTACTOSBindingSource.DataSource = Me.DsContactosBindingSource
        '
        'DsContactosBindingSource
        '
        Me.DsContactosBindingSource.DataSource = Me.DsContactos
        Me.DsContactosBindingSource.Position = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pbxNuevaFicha)
        Me.Panel1.Controls.Add(Me.pbxModificarFicha)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 40)
        Me.Panel1.TabIndex = 482
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(364, 2)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(35, 35)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 7
        Me.pbxCancelar.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.pbxGuardar.InitialImage = Nothing
        Me.pbxGuardar.Location = New System.Drawing.Point(329, 2)
        Me.pbxGuardar.Name = "pbxGuardar"
        Me.pbxGuardar.Size = New System.Drawing.Size(35, 35)
        Me.pbxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGuardar.TabIndex = 6
        Me.pbxGuardar.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 398
        Me.PictureBox1.TabStop = False
        '
        'pbxNuevaFicha
        '
        Me.pbxNuevaFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevaFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevaFicha.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevaFicha.InitialImage = Nothing
        Me.pbxNuevaFicha.Location = New System.Drawing.Point(224, 2)
        Me.pbxNuevaFicha.Name = "pbxNuevaFicha"
        Me.pbxNuevaFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxNuevaFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuevaFicha.TabIndex = 3
        Me.pbxNuevaFicha.TabStop = False
        '
        'pbxModificarFicha
        '
        Me.pbxModificarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxModificarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxModificarFicha.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.pbxModificarFicha.InitialImage = Nothing
        Me.pbxModificarFicha.Location = New System.Drawing.Point(294, 2)
        Me.pbxModificarFicha.Name = "pbxModificarFicha"
        Me.pbxModificarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxModificarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxModificarFicha.TabIndex = 5
        Me.pbxModificarFicha.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.CausesValidation = False
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.BuscarTextBox.Location = New System.Drawing.Point(35, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(179, 31)
        Me.BuscarTextBox.TabIndex = 391
        '
        'pbxEliminarFicha
        '
        Me.pbxEliminarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxEliminarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEliminarFicha.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.pbxEliminarFicha.InitialImage = Nothing
        Me.pbxEliminarFicha.Location = New System.Drawing.Point(259, 2)
        Me.pbxEliminarFicha.Name = "pbxEliminarFicha"
        Me.pbxEliminarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxEliminarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEliminarFicha.TabIndex = 4
        Me.pbxEliminarFicha.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Enabled = False
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(297, 155)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 495
        Me.Label18.Text = "Contacto:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(293, 285)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 16)
        Me.Label11.TabIndex = 488
        Me.Label11.Text = "Direccion:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(308, 253)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 489
        Me.Label5.Text = "Celular:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(296, 221)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 490
        Me.Label4.Text = "Telefono:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(239, 188)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 491
        Me.Label1.Text = "Correo Electronico:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDireccion
        '
        Me.txtDireccion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(365, 280)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(317, 27)
        Me.txtDireccion.TabIndex = 492
        '
        'tbxCel
        '
        Me.tbxCel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCel.Location = New System.Drawing.Point(365, 248)
        Me.tbxCel.Name = "tbxCel"
        Me.tbxCel.Size = New System.Drawing.Size(317, 27)
        Me.tbxCel.TabIndex = 487
        '
        'tbxTel
        '
        Me.tbxTel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTel.Location = New System.Drawing.Point(365, 216)
        Me.tbxTel.Name = "tbxTel"
        Me.tbxTel.Size = New System.Drawing.Size(317, 27)
        Me.tbxTel.TabIndex = 486
        '
        'tbxContacto
        '
        Me.tbxContacto.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxContacto.Location = New System.Drawing.Point(365, 150)
        Me.tbxContacto.Name = "tbxContacto"
        Me.tbxContacto.Size = New System.Drawing.Size(317, 27)
        Me.tbxContacto.TabIndex = 484
        '
        'tbxEmail
        '
        Me.tbxEmail.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEmail.Location = New System.Drawing.Point(365, 183)
        Me.tbxEmail.Name = "tbxEmail"
        Me.tbxEmail.Size = New System.Drawing.Size(317, 27)
        Me.tbxEmail.TabIndex = 485
        '
        'pbxVerCliente
        '
        Me.pbxVerCliente.BackColor = System.Drawing.Color.Transparent
        Me.pbxVerCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbxVerCliente.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxVerCliente.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.pbxVerCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxVerCliente.Location = New System.Drawing.Point(658, 332)
        Me.pbxVerCliente.Name = "pbxVerCliente"
        Me.pbxVerCliente.Size = New System.Drawing.Size(24, 26)
        Me.pbxVerCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxVerCliente.TabIndex = 564
        Me.pbxVerCliente.TabStop = False
        '
        'cbxCliente
        '
        Me.cbxCliente.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxCliente.CausesValidation = False
        Me.cbxCliente.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CONTACTOSBindingSource1, "CODCLIEN", True))
        Me.cbxCliente.DataSource = Me.CLIENTESBindingSource
        Me.cbxCliente.DisplayMember = "NOMBRE"
        Me.cbxCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCliente.ForeColor = System.Drawing.Color.Black
        Me.cbxCliente.FormattingEnabled = True
        Me.cbxCliente.Location = New System.Drawing.Point(365, 332)
        Me.cbxCliente.Name = "cbxCliente"
        Me.cbxCliente.Size = New System.Drawing.Size(287, 28)
        Me.cbxCliente.TabIndex = 563
        Me.cbxCliente.ValueMember = "CODCLIENTE"
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsCliente
        '
        'DsCliente
        '
        Me.DsCliente.DataSetName = "DsCliente"
        Me.DsCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(309, 338)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 565
        Me.Label2.Text = "Cliente:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(286, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 568
        Me.Label3.Text = "Shpr/Cnee:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbxVerShpr
        '
        Me.pbxVerShpr.BackColor = System.Drawing.Color.Transparent
        Me.pbxVerShpr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbxVerShpr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxVerShpr.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.pbxVerShpr.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxVerShpr.Location = New System.Drawing.Point(658, 366)
        Me.pbxVerShpr.Name = "pbxVerShpr"
        Me.pbxVerShpr.Size = New System.Drawing.Size(24, 26)
        Me.pbxVerShpr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxVerShpr.TabIndex = 567
        Me.pbxVerShpr.TabStop = False
        '
        'cbxShpr
        '
        Me.cbxShpr.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxShpr.CausesValidation = False
        Me.cbxShpr.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CONTACTOSBindingSource1, "CODSHPR", True))
        Me.cbxShpr.DataSource = Me.SHPRCNEEBindingSource
        Me.cbxShpr.DisplayMember = "NOMBRE"
        Me.cbxShpr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxShpr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxShpr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxShpr.ForeColor = System.Drawing.Color.Black
        Me.cbxShpr.FormattingEnabled = True
        Me.cbxShpr.Location = New System.Drawing.Point(365, 366)
        Me.cbxShpr.Name = "cbxShpr"
        Me.cbxShpr.Size = New System.Drawing.Size(287, 28)
        Me.cbxShpr.TabIndex = 566
        Me.cbxShpr.ValueMember = "ID"
        '
        'SHPRCNEEBindingSource
        '
        Me.SHPRCNEEBindingSource.DataMember = "SHPRCNEE"
        Me.SHPRCNEEBindingSource.DataSource = Me.DsSHPRCNEE
        '
        'DsSHPRCNEE
        '
        Me.DsSHPRCNEE.DataSetName = "dsSHPRCNEE"
        Me.DsSHPRCNEE.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(239, 406)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 16)
        Me.Label6.TabIndex = 571
        Me.Label6.Text = "Proveedor/Agente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pbxVerProv
        '
        Me.pbxVerProv.BackColor = System.Drawing.Color.Transparent
        Me.pbxVerProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbxVerProv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxVerProv.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.pbxVerProv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxVerProv.Location = New System.Drawing.Point(658, 400)
        Me.pbxVerProv.Name = "pbxVerProv"
        Me.pbxVerProv.Size = New System.Drawing.Size(24, 26)
        Me.pbxVerProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxVerProv.TabIndex = 570
        Me.pbxVerProv.TabStop = False
        '
        'cbxProv
        '
        Me.cbxProv.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxProv.CausesValidation = False
        Me.cbxProv.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CONTACTOSBindingSource1, "CODPROV", True))
        Me.cbxProv.DataSource = Me.PROVEEDORBindingSource
        Me.cbxProv.DisplayMember = "NOMBRE"
        Me.cbxProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProv.ForeColor = System.Drawing.Color.Black
        Me.cbxProv.FormattingEnabled = True
        Me.cbxProv.Location = New System.Drawing.Point(365, 400)
        Me.cbxProv.Name = "cbxProv"
        Me.cbxProv.Size = New System.Drawing.Size(287, 28)
        Me.cbxProv.TabIndex = 569
        Me.cbxProv.ValueMember = "CODPROVEEDOR"
        '
        'PROVEEDORBindingSource
        '
        Me.PROVEEDORBindingSource.DataMember = "PROVEEDOR"
        Me.PROVEEDORBindingSource.DataSource = Me.DsProveedores
        '
        'DsProveedores
        '
        Me.DsProveedores.DataSetName = "DsProveedores"
        Me.DsProveedores.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'rbtCliente
        '
        Me.rbtCliente.AutoSize = True
        Me.rbtCliente.Checked = True
        Me.rbtCliente.Location = New System.Drawing.Point(688, 340)
        Me.rbtCliente.Name = "rbtCliente"
        Me.rbtCliente.Size = New System.Drawing.Size(14, 13)
        Me.rbtCliente.TabIndex = 572
        Me.rbtCliente.TabStop = True
        Me.rbtCliente.UseVisualStyleBackColor = True
        '
        'rbtShpr
        '
        Me.rbtShpr.AutoSize = True
        Me.rbtShpr.Location = New System.Drawing.Point(689, 374)
        Me.rbtShpr.Name = "rbtShpr"
        Me.rbtShpr.Size = New System.Drawing.Size(14, 13)
        Me.rbtShpr.TabIndex = 573
        Me.rbtShpr.TabStop = True
        Me.rbtShpr.UseVisualStyleBackColor = True
        '
        'rbtProv
        '
        Me.rbtProv.AutoSize = True
        Me.rbtProv.Location = New System.Drawing.Point(688, 408)
        Me.rbtProv.Name = "rbtProv"
        Me.rbtProv.Size = New System.Drawing.Size(14, 13)
        Me.rbtProv.TabIndex = 574
        Me.rbtProv.TabStop = True
        Me.rbtProv.UseVisualStyleBackColor = True
        '
        'CONTACTOSTableAdapter
        '
        Me.CONTACTOSTableAdapter.ClearBeforeFill = True
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'SHPRCNEETableAdapter
        '
        Me.SHPRCNEETableAdapter.ClearBeforeFill = True
        '
        'PROVEEDORTableAdapter
        '
        Me.PROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'Contactos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 541)
        Me.Controls.Add(Me.rbtProv)
        Me.Controls.Add(Me.rbtShpr)
        Me.Controls.Add(Me.rbtCliente)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pbxVerProv)
        Me.Controls.Add(Me.cbxProv)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pbxVerShpr)
        Me.Controls.Add(Me.cbxShpr)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbxVerCliente)
        Me.Controls.Add(Me.cbxCliente)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.tbxCel)
        Me.Controls.Add(Me.tbxTel)
        Me.Controls.Add(Me.tbxContacto)
        Me.Controls.Add(Me.tbxEmail)
        Me.Controls.Add(Me.dgvContacto)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Contactos"
        Me.Text = "Contactos"
        CType(Me.dgvContacto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONTACTOSBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsContactos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CONTACTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsContactosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxVerCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxVerShpr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHPRCNEEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSHPRCNEE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxVerProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvContacto As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents tbxCel As System.Windows.Forms.TextBox
    Friend WithEvents tbxTel As System.Windows.Forms.TextBox
    Friend WithEvents tbxContacto As System.Windows.Forms.TextBox
    Friend WithEvents tbxEmail As System.Windows.Forms.TextBox
    Friend WithEvents DsContactosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsContactos As ContaExpress.dsContactos
    Friend WithEvents CONTACTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CONTACTOSTableAdapter As ContaExpress.dsContactosTableAdapters.CONTACTOSTableAdapter
    Friend WithEvents CODCONTACTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCONTACTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCEDULADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CELULARDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEPARTAMENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONTACTOSBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents pbxVerCliente As System.Windows.Forms.PictureBox
    Friend WithEvents cbxCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pbxVerShpr As System.Windows.Forms.PictureBox
    Friend WithEvents cbxShpr As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pbxVerProv As System.Windows.Forms.PictureBox
    Friend WithEvents cbxProv As System.Windows.Forms.ComboBox
    Friend WithEvents rbtCliente As System.Windows.Forms.RadioButton
    Friend WithEvents rbtShpr As System.Windows.Forms.RadioButton
    Friend WithEvents rbtProv As System.Windows.Forms.RadioButton
    Friend WithEvents DsCliente As ContaExpress.DsCliente
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsClienteTableAdapters.CLIENTESTableAdapter
    Friend WithEvents DsSHPRCNEE As ContaExpress.dsSHPRCNEE
    Friend WithEvents SHPRCNEEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SHPRCNEETableAdapter As ContaExpress.dsSHPRCNEETableAdapters.SHPRCNEETableAdapter
    Friend WithEvents DsProveedores As ContaExpress.DsProveedores
    Friend WithEvents PROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PROVEEDORTableAdapter As ContaExpress.DsProveedoresTableAdapters.PROVEEDORTableAdapter
End Class
