<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShprCnee
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
        Me.dgvShprCnee = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RUCDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIRECCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPAISDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCIUDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TELDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FAXDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPOSTALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODZONADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SHPRCNEEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSHPRCNEE = New ContaExpress.dsSHPRCNEE()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.tbxDesEquipo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblRuc = New System.Windows.Forms.Label()
        Me.tbxRUC = New System.Windows.Forms.TextBox()
        Me.txtNombreClienteR = New System.Windows.Forms.TextBox()
        Me.txtIdClienteR = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbxNombre = New System.Windows.Forms.TextBox()
        Me.tbxDireccion = New System.Windows.Forms.TextBox()
        Me.cbxPais = New System.Windows.Forms.ComboBox()
        Me.PAISBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxCiudad = New System.Windows.Forms.ComboBox()
        Me.CIUDADBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbxCodPostal = New System.Windows.Forms.TextBox()
        Me.tbxCodZona = New System.Windows.Forms.TextBox()
        Me.tbxTelefono = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxEmail = New System.Windows.Forms.TextBox()
        Me.SHPRCNEETableAdapter = New ContaExpress.dsSHPRCNEETableAdapters.SHPRCNEETableAdapter()
        Me.PAISTableAdapter = New ContaExpress.dsSHPRCNEETableAdapters.PAISTableAdapter()
        Me.CIUDADTableAdapter = New ContaExpress.dsSHPRCNEETableAdapters.CIUDADTableAdapter()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbxFax = New System.Windows.Forms.TextBox()
        CType(Me.dgvShprCnee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SHPRCNEEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSHPRCNEE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbxDesEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvShprCnee
        '
        Me.dgvShprCnee.AllowUserToAddRows = False
        Me.dgvShprCnee.AllowUserToDeleteRows = False
        Me.dgvShprCnee.AllowUserToOrderColumns = True
        Me.dgvShprCnee.AllowUserToResizeRows = False
        Me.dgvShprCnee.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvShprCnee.AutoGenerateColumns = False
        Me.dgvShprCnee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvShprCnee.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShprCnee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvShprCnee.ColumnHeadersHeight = 35
        Me.dgvShprCnee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOMBREDataGridViewTextBoxColumn, Me.RUCDataGridViewTextBoxColumn, Me.DIRECCIONDataGridViewTextBoxColumn, Me.CODPAISDataGridViewTextBoxColumn, Me.CODCIUDADDataGridViewTextBoxColumn, Me.TELDataGridViewTextBoxColumn, Me.FAXDataGridViewTextBoxColumn, Me.CODPOSTALDataGridViewTextBoxColumn, Me.EMAILDataGridViewTextBoxColumn, Me.CODZONADataGridViewTextBoxColumn})
        Me.dgvShprCnee.DataSource = Me.SHPRCNEEBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvShprCnee.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvShprCnee.GridColor = System.Drawing.Color.Lavender
        Me.dgvShprCnee.Location = New System.Drawing.Point(6, 48)
        Me.dgvShprCnee.Name = "dgvShprCnee"
        Me.dgvShprCnee.ReadOnly = True
        Me.dgvShprCnee.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvShprCnee.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvShprCnee.RowHeadersVisible = False
        Me.dgvShprCnee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvShprCnee.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvShprCnee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvShprCnee.Size = New System.Drawing.Size(209, 521)
        Me.dgvShprCnee.TabIndex = 426
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Razón Social"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
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
        'CODPAISDataGridViewTextBoxColumn
        '
        Me.CODPAISDataGridViewTextBoxColumn.DataPropertyName = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.HeaderText = "CODPAIS"
        Me.CODPAISDataGridViewTextBoxColumn.Name = "CODPAISDataGridViewTextBoxColumn"
        Me.CODPAISDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPAISDataGridViewTextBoxColumn.Visible = False
        '
        'CODCIUDADDataGridViewTextBoxColumn
        '
        Me.CODCIUDADDataGridViewTextBoxColumn.DataPropertyName = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.HeaderText = "CODCIUDAD"
        Me.CODCIUDADDataGridViewTextBoxColumn.Name = "CODCIUDADDataGridViewTextBoxColumn"
        Me.CODCIUDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCIUDADDataGridViewTextBoxColumn.Visible = False
        '
        'TELDataGridViewTextBoxColumn
        '
        Me.TELDataGridViewTextBoxColumn.DataPropertyName = "TEL"
        Me.TELDataGridViewTextBoxColumn.HeaderText = "TEL"
        Me.TELDataGridViewTextBoxColumn.Name = "TELDataGridViewTextBoxColumn"
        Me.TELDataGridViewTextBoxColumn.ReadOnly = True
        Me.TELDataGridViewTextBoxColumn.Visible = False
        '
        'FAXDataGridViewTextBoxColumn
        '
        Me.FAXDataGridViewTextBoxColumn.DataPropertyName = "FAX"
        Me.FAXDataGridViewTextBoxColumn.HeaderText = "FAX"
        Me.FAXDataGridViewTextBoxColumn.Name = "FAXDataGridViewTextBoxColumn"
        Me.FAXDataGridViewTextBoxColumn.ReadOnly = True
        Me.FAXDataGridViewTextBoxColumn.Visible = False
        '
        'CODPOSTALDataGridViewTextBoxColumn
        '
        Me.CODPOSTALDataGridViewTextBoxColumn.DataPropertyName = "CODPOSTAL"
        Me.CODPOSTALDataGridViewTextBoxColumn.HeaderText = "CODPOSTAL"
        Me.CODPOSTALDataGridViewTextBoxColumn.Name = "CODPOSTALDataGridViewTextBoxColumn"
        Me.CODPOSTALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPOSTALDataGridViewTextBoxColumn.Visible = False
        '
        'EMAILDataGridViewTextBoxColumn
        '
        Me.EMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.Name = "EMAILDataGridViewTextBoxColumn"
        Me.EMAILDataGridViewTextBoxColumn.ReadOnly = True
        Me.EMAILDataGridViewTextBoxColumn.Visible = False
        '
        'CODZONADataGridViewTextBoxColumn
        '
        Me.CODZONADataGridViewTextBoxColumn.DataPropertyName = "CODZONA"
        Me.CODZONADataGridViewTextBoxColumn.HeaderText = "CODZONA"
        Me.CODZONADataGridViewTextBoxColumn.Name = "CODZONADataGridViewTextBoxColumn"
        Me.CODZONADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODZONADataGridViewTextBoxColumn.Visible = False
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
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(754, 40)
        Me.Panel1.TabIndex = 424
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
        'tbxDesEquipo
        '
        Me.tbxDesEquipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxDesEquipo.Location = New System.Drawing.Point(127, 13)
        Me.tbxDesEquipo.MaxLength = 50
        Me.tbxDesEquipo.Name = "tbxDesEquipo"
        Me.tbxDesEquipo.Size = New System.Drawing.Size(252, 26)
        Me.tbxDesEquipo.TabIndex = 0
        Me.tbxDesEquipo.TabStop = False
        Me.tbxDesEquipo.ThemeName = "Breeze"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(300, 159)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Direccion:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRuc
        '
        Me.lblRuc.AutoSize = True
        Me.lblRuc.Enabled = False
        Me.lblRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblRuc.ForeColor = System.Drawing.Color.Black
        Me.lblRuc.Location = New System.Drawing.Point(333, 110)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.Size(35, 16)
        Me.lblRuc.TabIndex = 0
        Me.lblRuc.Text = "Ruc:"
        Me.lblRuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxRUC
        '
        Me.tbxRUC.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxRUC.Location = New System.Drawing.Point(370, 104)
        Me.tbxRUC.Name = "tbxRUC"
        Me.tbxRUC.Size = New System.Drawing.Size(317, 27)
        Me.tbxRUC.TabIndex = 0
        '
        'txtNombreClienteR
        '
        Me.txtNombreClienteR.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.txtNombreClienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombreClienteR.Enabled = False
        Me.txtNombreClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtNombreClienteR.Location = New System.Drawing.Point(441, 104)
        Me.txtNombreClienteR.Name = "txtNombreClienteR"
        Me.txtNombreClienteR.Size = New System.Drawing.Size(246, 27)
        Me.txtNombreClienteR.TabIndex = 16
        '
        'txtIdClienteR
        '
        Me.txtIdClienteR.BackColor = System.Drawing.Color.White
        Me.txtIdClienteR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdClienteR.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtIdClienteR.Location = New System.Drawing.Point(370, 104)
        Me.txtIdClienteR.Name = "txtIdClienteR"
        Me.txtIdClienteR.Size = New System.Drawing.Size(73, 27)
        Me.txtIdClienteR.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(224, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 16)
        Me.Label6.TabIndex = 429
        Me.Label6.Text = "Razón Social/Nombre:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxNombre
        '
        Me.tbxNombre.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxNombre.Location = New System.Drawing.Point(370, 56)
        Me.tbxNombre.Name = "tbxNombre"
        Me.tbxNombre.Size = New System.Drawing.Size(317, 27)
        Me.tbxNombre.TabIndex = 428
        '
        'tbxDireccion
        '
        Me.tbxDireccion.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxDireccion.Location = New System.Drawing.Point(370, 154)
        Me.tbxDireccion.Name = "tbxDireccion"
        Me.tbxDireccion.Size = New System.Drawing.Size(317, 27)
        Me.tbxDireccion.TabIndex = 463
        '
        'cbxPais
        '
        Me.cbxPais.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxPais.CausesValidation = False
        Me.cbxPais.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SHPRCNEEBindingSource, "CODPAIS", True))
        Me.cbxPais.DataSource = Me.PAISBindingSource
        Me.cbxPais.DisplayMember = "DESPAIS"
        Me.cbxPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPais.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPais.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPais.ForeColor = System.Drawing.Color.Black
        Me.cbxPais.FormattingEnabled = True
        Me.cbxPais.Location = New System.Drawing.Point(370, 199)
        Me.cbxPais.Name = "cbxPais"
        Me.cbxPais.Size = New System.Drawing.Size(166, 28)
        Me.cbxPais.TabIndex = 464
        Me.cbxPais.ValueMember = "CODPAIS"
        '
        'PAISBindingSource
        '
        Me.PAISBindingSource.DataMember = "PAIS"
        Me.PAISBindingSource.DataSource = Me.DsSHPRCNEE
        '
        'cbxCiudad
        '
        Me.cbxCiudad.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cbxCiudad.CausesValidation = False
        Me.cbxCiudad.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.SHPRCNEEBindingSource, "CODCIUDAD", True))
        Me.cbxCiudad.DataSource = Me.CIUDADBindingSource
        Me.cbxCiudad.DisplayMember = "DESCIUDAD"
        Me.cbxCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCiudad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCiudad.ForeColor = System.Drawing.Color.Black
        Me.cbxCiudad.FormattingEnabled = True
        Me.cbxCiudad.Location = New System.Drawing.Point(370, 245)
        Me.cbxCiudad.Name = "cbxCiudad"
        Me.cbxCiudad.Size = New System.Drawing.Size(166, 28)
        Me.cbxCiudad.TabIndex = 465
        Me.cbxCiudad.ValueMember = "CODCIUDAD"
        '
        'CIUDADBindingSource
        '
        Me.CIUDADBindingSource.DataMember = "CIUDAD"
        Me.CIUDADBindingSource.DataSource = Me.DsSHPRCNEE
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(332, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 16)
        Me.Label9.TabIndex = 466
        Me.Label9.Text = "Pais:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(310, 251)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 16)
        Me.Label12.TabIndex = 467
        Me.Label12.Text = "Ciudad:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxCodPostal
        '
        Me.tbxCodPostal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCodPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodPostal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCodPostal.Location = New System.Drawing.Point(370, 292)
        Me.tbxCodPostal.Name = "tbxCodPostal"
        Me.tbxCodPostal.Size = New System.Drawing.Size(317, 27)
        Me.tbxCodPostal.TabIndex = 469
        '
        'tbxCodZona
        '
        Me.tbxCodZona.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCodZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCodZona.Location = New System.Drawing.Point(370, 339)
        Me.tbxCodZona.Name = "tbxCodZona"
        Me.tbxCodZona.Size = New System.Drawing.Size(317, 27)
        Me.tbxCodZona.TabIndex = 470
        '
        'tbxTelefono
        '
        Me.tbxTelefono.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxTelefono.Location = New System.Drawing.Point(370, 386)
        Me.tbxTelefono.Name = "tbxTelefono"
        Me.tbxTelefono.Size = New System.Drawing.Size(317, 27)
        Me.tbxTelefono.TabIndex = 471
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(275, 344)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 472
        Me.Label1.Text = "Código Zona:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(299, 391)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 16)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "Teléfono:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(268, 297)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 474
        Me.Label3.Text = "Código Postal:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(319, 439)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 16)
        Me.Label4.TabIndex = 476
        Me.Label4.Text = "Email:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxEmail
        '
        Me.tbxEmail.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEmail.Location = New System.Drawing.Point(370, 434)
        Me.tbxEmail.Name = "tbxEmail"
        Me.tbxEmail.Size = New System.Drawing.Size(317, 27)
        Me.tbxEmail.TabIndex = 475
        '
        'SHPRCNEETableAdapter
        '
        Me.SHPRCNEETableAdapter.ClearBeforeFill = True
        '
        'PAISTableAdapter
        '
        Me.PAISTableAdapter.ClearBeforeFill = True
        '
        'CIUDADTableAdapter
        '
        Me.CIUDADTableAdapter.ClearBeforeFill = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(331, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 16)
        Me.Label5.TabIndex = 478
        Me.Label5.Text = "Fax:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxFax
        '
        Me.tbxFax.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxFax.Location = New System.Drawing.Point(370, 477)
        Me.tbxFax.Name = "tbxFax"
        Me.tbxFax.Size = New System.Drawing.Size(317, 27)
        Me.tbxFax.TabIndex = 477
        '
        'ShprCnee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 572)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbxFax)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbxEmail)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxTelefono)
        Me.Controls.Add(Me.tbxCodZona)
        Me.Controls.Add(Me.tbxCodPostal)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbxCiudad)
        Me.Controls.Add(Me.cbxPais)
        Me.Controls.Add(Me.tbxDireccion)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbxNombre)
        Me.Controls.Add(Me.dgvShprCnee)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbxRUC)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblRuc)
        Me.Controls.Add(Me.txtIdClienteR)
        Me.Controls.Add(Me.txtNombreClienteR)
        Me.Name = "ShprCnee"
        Me.Text = "ShprCnee"
        CType(Me.dgvShprCnee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SHPRCNEEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSHPRCNEE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbxDesEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PAISBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CIUDADBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvShprCnee As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents tbxDesEquipo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblRuc As System.Windows.Forms.Label
    Friend WithEvents tbxRUC As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreClienteR As System.Windows.Forms.TextBox
    Friend WithEvents txtIdClienteR As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbxNombre As System.Windows.Forms.TextBox
    Friend WithEvents tbxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents cbxPais As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCiudad As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbxCodPostal As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodZona As System.Windows.Forms.TextBox
    Friend WithEvents tbxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxEmail As System.Windows.Forms.TextBox
    Friend WithEvents DsSHPRCNEE As ContaExpress.dsSHPRCNEE
    Friend WithEvents SHPRCNEEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SHPRCNEETableAdapter As ContaExpress.dsSHPRCNEETableAdapters.SHPRCNEETableAdapter
    Friend WithEvents PAISBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PAISTableAdapter As ContaExpress.dsSHPRCNEETableAdapters.PAISTableAdapter
    Friend WithEvents CIUDADBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CIUDADTableAdapter As ContaExpress.dsSHPRCNEETableAdapters.CIUDADTableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbxFax As System.Windows.Forms.TextBox
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPAISDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAXDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPOSTALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODZONADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
