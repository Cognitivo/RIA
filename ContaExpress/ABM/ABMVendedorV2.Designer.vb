<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMVendedorV2
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
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMVendedorV2))
        Me.dgvVendedor = New System.Windows.Forms.DataGridView()
        Me.CODVENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMVENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESVENDEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIOV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CELULAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEDULA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMISIONPOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.VENDEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCentroDeCosto = New ContaExpress.DsCentroDeCosto()
        Me.pnlBotonera = New System.Windows.Forms.Panel()
        Me.pnlEditBusc = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.pbxDatos = New System.Windows.Forms.PictureBox()
        Me.pbxTransferCli = New System.Windows.Forms.PictureBox()
        Me.gbxUsuario = New System.Windows.Forms.GroupBox()
        Me.TxtBuscaUsuario = New System.Windows.Forms.TextBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.NOMBREUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PanelDatos = New System.Windows.Forms.Panel()
        Me.tbxUsuario = New System.Windows.Forms.ComboBox()
        Me.tbxComBase = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.BtnAsterisco = New System.Windows.Forms.PictureBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbxCelular = New System.Windows.Forms.TextBox()
        Me.tbxEmail = New System.Windows.Forms.TextBox()
        Me.tbxCedula = New System.Windows.Forms.TextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.tbxNroVend = New System.Windows.Forms.TextBox()
        Me.RadLbConfig7 = New Telerik.WinControls.UI.RadLabel()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig2 = New Telerik.WinControls.UI.RadLabel()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.tbxNombre = New System.Windows.Forms.TextBox()
        Me.pnlTransfer = New System.Windows.Forms.Panel()
        Me.btnTransferir = New System.Windows.Forms.Button()
        Me.pnlPorZona = New System.Windows.Forms.Panel()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.ZONABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbVendedorAZona = New System.Windows.Forms.ComboBox()
        Me.VENDEDOR4BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlPorVendedor = New System.Windows.Forms.Panel()
        Me.cmbVendedorDe = New System.Windows.Forms.ComboBox()
        Me.VENDEDOR2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbVendedorA = New System.Windows.Forms.ComboBox()
        Me.VENDEDOR3BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbPorVendedor = New System.Windows.Forms.RadioButton()
        Me.rbPorZona = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.USUARIOTableAdapter = New ContaExpress.DsCentroDeCostoTableAdapters.USUARIOTableAdapter()
        Me.VENDEDORTableAdapter = New ContaExpress.DsCentroDeCostoTableAdapters.VENDEDORTableAdapter()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.SplitVendedor = New System.Windows.Forms.SplitContainer()
        Me.ZONATableAdapter = New ContaExpress.DsCentroDeCostoTableAdapters.ZONATableAdapter()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgvVendedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCentroDeCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBotonera.SuspendLayout()
        Me.pnlEditBusc.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxTransferCli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxUsuario.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDatos.SuspendLayout()
        CType(Me.BtnAsterisco, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTransfer.SuspendLayout()
        Me.pnlPorZona.SuspendLayout()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDOR4BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPorVendedor.SuspendLayout()
        CType(Me.VENDEDOR2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.VENDEDOR3BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitVendedor.Panel1.SuspendLayout()
        Me.SplitVendedor.Panel2.SuspendLayout()
        Me.SplitVendedor.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvVendedor
        '
        Me.dgvVendedor.AllowUserToAddRows = False
        Me.dgvVendedor.AllowUserToDeleteRows = False
        Me.dgvVendedor.AllowUserToResizeColumns = False
        Me.dgvVendedor.AllowUserToResizeRows = False
        Me.dgvVendedor.AutoGenerateColumns = False
        Me.dgvVendedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVendedor.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVendedor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVendedor.ColumnHeadersHeight = 28
        Me.dgvVendedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODVENDEDOR, Me.NUMVENDEDOR, Me.DESVENDEDOR, Me.CODUSUARIOV, Me.CELULAR, Me.CEDULA, Me.EMAIL, Me.COMISIONPOR, Me.ESTADO})
        Me.dgvVendedor.DataSource = Me.VENDEDORBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVendedor.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVendedor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVendedor.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvVendedor.Location = New System.Drawing.Point(0, 0)
        Me.dgvVendedor.MultiSelect = False
        Me.dgvVendedor.Name = "dgvVendedor"
        Me.dgvVendedor.ReadOnly = True
        Me.dgvVendedor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVendedor.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVendedor.RowHeadersVisible = False
        Me.dgvVendedor.RowHeadersWidth = 35
        Me.dgvVendedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVendedor.Size = New System.Drawing.Size(249, 463)
        Me.dgvVendedor.TabIndex = 422
        '
        'CODVENDEDOR
        '
        Me.CODVENDEDOR.DataPropertyName = "CODVENDEDOR"
        Me.CODVENDEDOR.HeaderText = "CODVENDEDOR"
        Me.CODVENDEDOR.Name = "CODVENDEDOR"
        Me.CODVENDEDOR.ReadOnly = True
        Me.CODVENDEDOR.Visible = False
        '
        'NUMVENDEDOR
        '
        Me.NUMVENDEDOR.DataPropertyName = "NUMVENDEDOR"
        Me.NUMVENDEDOR.FillWeight = 40.0!
        Me.NUMVENDEDOR.HeaderText = "Nro."
        Me.NUMVENDEDOR.Name = "NUMVENDEDOR"
        Me.NUMVENDEDOR.ReadOnly = True
        '
        'DESVENDEDOR
        '
        Me.DESVENDEDOR.DataPropertyName = "DESVENDEDOR"
        Me.DESVENDEDOR.FillWeight = 200.0!
        Me.DESVENDEDOR.HeaderText = "Vendedor"
        Me.DESVENDEDOR.Name = "DESVENDEDOR"
        Me.DESVENDEDOR.ReadOnly = True
        '
        'CODUSUARIOV
        '
        Me.CODUSUARIOV.DataPropertyName = "USUARIO"
        Me.CODUSUARIOV.HeaderText = "USUARIO"
        Me.CODUSUARIOV.Name = "CODUSUARIOV"
        Me.CODUSUARIOV.ReadOnly = True
        Me.CODUSUARIOV.Visible = False
        '
        'CELULAR
        '
        Me.CELULAR.DataPropertyName = "CELULAR"
        Me.CELULAR.HeaderText = "CELULAR"
        Me.CELULAR.Name = "CELULAR"
        Me.CELULAR.ReadOnly = True
        Me.CELULAR.Visible = False
        '
        'CEDULA
        '
        Me.CEDULA.DataPropertyName = "CEDULA"
        Me.CEDULA.HeaderText = "CEDULA"
        Me.CEDULA.Name = "CEDULA"
        Me.CEDULA.ReadOnly = True
        Me.CEDULA.Visible = False
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "EMAIL"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        Me.EMAIL.Visible = False
        '
        'COMISIONPOR
        '
        Me.COMISIONPOR.DataPropertyName = "COMISIONPOR"
        Me.COMISIONPOR.HeaderText = "COMISIONPOR"
        Me.COMISIONPOR.Name = "COMISIONPOR"
        Me.COMISIONPOR.ReadOnly = True
        Me.COMISIONPOR.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'VENDEDORBindingSource
        '
        Me.VENDEDORBindingSource.DataMember = "VENDEDOR"
        Me.VENDEDORBindingSource.DataSource = Me.DsCentroDeCosto
        '
        'DsCentroDeCosto
        '
        Me.DsCentroDeCosto.DataSetName = "DsCentroDeCosto"
        Me.DsCentroDeCosto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pnlBotonera
        '
        Me.pnlBotonera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBotonera.BackColor = System.Drawing.Color.Black
        Me.pnlBotonera.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.pnlBotonera.Controls.Add(Me.pnlEditBusc)
        Me.pnlBotonera.Controls.Add(Me.pbxDatos)
        Me.pnlBotonera.Controls.Add(Me.pbxTransferCli)
        Me.pnlBotonera.Location = New System.Drawing.Point(0, -2)
        Me.pnlBotonera.Name = "pnlBotonera"
        Me.pnlBotonera.Size = New System.Drawing.Size(747, 40)
        Me.pnlBotonera.TabIndex = 457
        '
        'pnlEditBusc
        '
        Me.pnlEditBusc.BackColor = System.Drawing.Color.Transparent
        Me.pnlEditBusc.Controls.Add(Me.PictureBox8)
        Me.pnlEditBusc.Controls.Add(Me.EliminarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.NuevoPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.CancelarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.ModificarPictureBox)
        Me.pnlEditBusc.Controls.Add(Me.BuscarTextBox)
        Me.pnlEditBusc.Controls.Add(Me.GuardarPictureBox)
        Me.pnlEditBusc.Location = New System.Drawing.Point(-3, 1)
        Me.pnlEditBusc.Name = "pnlEditBusc"
        Me.pnlEditBusc.Size = New System.Drawing.Size(453, 38)
        Me.pnlEditBusc.TabIndex = 509
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 461
        Me.PictureBox8.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(295, 3)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 456
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(260, 3)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 455
        Me.NuevoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(402, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 459
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(330, 3)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 457
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.CausesValidation = False
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(33, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(219, 30)
        Me.BuscarTextBox.TabIndex = 460
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(366, 3)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 458
        Me.GuardarPictureBox.TabStop = False
        '
        'pbxDatos
        '
        Me.pbxDatos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxDatos.BackColor = System.Drawing.Color.Transparent
        Me.pbxDatos.Image = Global.ContaExpress.My.Resources.Resources.User
        Me.pbxDatos.Location = New System.Drawing.Point(670, 5)
        Me.pbxDatos.Name = "pbxDatos"
        Me.pbxDatos.Size = New System.Drawing.Size(35, 33)
        Me.pbxDatos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDatos.TabIndex = 508
        Me.pbxDatos.TabStop = False
        '
        'pbxTransferCli
        '
        Me.pbxTransferCli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxTransferCli.BackColor = System.Drawing.Color.Transparent
        Me.pbxTransferCli.Image = Global.ContaExpress.My.Resources.Resources.AjusteCaja
        Me.pbxTransferCli.Location = New System.Drawing.Point(709, 5)
        Me.pbxTransferCli.Name = "pbxTransferCli"
        Me.pbxTransferCli.Size = New System.Drawing.Size(35, 33)
        Me.pbxTransferCli.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxTransferCli.TabIndex = 507
        Me.pbxTransferCli.TabStop = False
        '
        'gbxUsuario
        '
        Me.gbxUsuario.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.gbxUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.gbxUsuario.Controls.Add(Me.TxtBuscaUsuario)
        Me.gbxUsuario.Controls.Add(Me.dgvUsuarios)
        Me.gbxUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxUsuario.Location = New System.Drawing.Point(12, 49)
        Me.gbxUsuario.Name = "gbxUsuario"
        Me.gbxUsuario.Size = New System.Drawing.Size(293, 368)
        Me.gbxUsuario.TabIndex = 99999
        Me.gbxUsuario.TabStop = False
        Me.gbxUsuario.Text = "Buscador de Usuario"
        '
        'TxtBuscaUsuario
        '
        Me.TxtBuscaUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBuscaUsuario.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.TxtBuscaUsuario.Location = New System.Drawing.Point(8, 20)
        Me.TxtBuscaUsuario.Name = "TxtBuscaUsuario"
        Me.TxtBuscaUsuario.Size = New System.Drawing.Size(281, 30)
        Me.TxtBuscaUsuario.TabIndex = 998
        Me.TxtBuscaUsuario.Text = "Buscar..."
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AutoGenerateColumns = False
        Me.dgvUsuarios.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvUsuarios.ColumnHeadersHeight = 35
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOMBREUSUARIO, Me.CODUSUARIO, Me.DESUSUARIO})
        Me.dgvUsuarios.DataSource = Me.USUARIOBindingSource
        Me.dgvUsuarios.Location = New System.Drawing.Point(8, 55)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersVisible = False
        Me.dgvUsuarios.Size = New System.Drawing.Size(278, 307)
        Me.dgvUsuarios.TabIndex = 999
        Me.dgvUsuarios.TabStop = False
        '
        'NOMBREUSUARIO
        '
        Me.NOMBREUSUARIO.DataPropertyName = "NOMBRE"
        Me.NOMBREUSUARIO.HeaderText = "Nombre"
        Me.NOMBREUSUARIO.Name = "NOMBREUSUARIO"
        Me.NOMBREUSUARIO.ReadOnly = True
        Me.NOMBREUSUARIO.Width = 250
        '
        'CODUSUARIO
        '
        Me.CODUSUARIO.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIO.HeaderText = "CODUSUARIO"
        Me.CODUSUARIO.Name = "CODUSUARIO"
        Me.CODUSUARIO.ReadOnly = True
        Me.CODUSUARIO.Visible = False
        '
        'DESUSUARIO
        '
        Me.DESUSUARIO.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIO.HeaderText = "DESUSUARIO"
        Me.DESUSUARIO.Name = "DESUSUARIO"
        Me.DESUSUARIO.ReadOnly = True
        Me.DESUSUARIO.Visible = False
        '
        'USUARIOBindingSource
        '
        Me.USUARIOBindingSource.DataMember = "USUARIO"
        Me.USUARIOBindingSource.DataSource = Me.DsCentroDeCosto
        '
        'PanelDatos
        '
        Me.PanelDatos.BackColor = System.Drawing.Color.LightGray
        Me.PanelDatos.Controls.Add(Me.tbxUsuario)
        Me.PanelDatos.Controls.Add(Me.tbxComBase)
        Me.PanelDatos.Controls.Add(Me.BtnAsterisco)
        Me.PanelDatos.Controls.Add(Me.RadLabel2)
        Me.PanelDatos.Controls.Add(Me.Label3)
        Me.PanelDatos.Controls.Add(Me.tbxCelular)
        Me.PanelDatos.Controls.Add(Me.tbxEmail)
        Me.PanelDatos.Controls.Add(Me.tbxCedula)
        Me.PanelDatos.Controls.Add(Me.RadLabel1)
        Me.PanelDatos.Controls.Add(Me.tbxNroVend)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig7)
        Me.PanelDatos.Controls.Add(Me.cmbEstado)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig6)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig5)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig4)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig3)
        Me.PanelDatos.Controls.Add(Me.RadLbConfig2)
        Me.PanelDatos.Controls.Add(Me.txtEstado)
        Me.PanelDatos.Controls.Add(Me.lblNombre)
        Me.PanelDatos.Controls.Add(Me.tbxNombre)
        Me.PanelDatos.DataBindings.Add(New System.Windows.Forms.Binding("Tag", Me.VENDEDORBindingSource, "COMISIONPOR", True))
        Me.PanelDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDatos.Location = New System.Drawing.Point(0, 0)
        Me.PanelDatos.Name = "PanelDatos"
        Me.PanelDatos.Size = New System.Drawing.Size(494, 463)
        Me.PanelDatos.TabIndex = 473
        '
        'tbxUsuario
        '
        Me.tbxUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxUsuario.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.VENDEDORBindingSource, "CODUSUARIO", True))
        Me.tbxUsuario.DataSource = Me.USUARIOBindingSource
        Me.tbxUsuario.DisplayMember = "DESUSUARIO"
        Me.tbxUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbxUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxUsuario.FormattingEnabled = True
        Me.tbxUsuario.Location = New System.Drawing.Point(125, 139)
        Me.tbxUsuario.Name = "tbxUsuario"
        Me.tbxUsuario.Size = New System.Drawing.Size(298, 28)
        Me.tbxUsuario.TabIndex = 2
        Me.tbxUsuario.ValueMember = "CODUSUARIO"
        '
        'tbxComBase
        '
        Me.tbxComBase.AllowDrop = True
        Appearance5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "False"
        Appearance5.FontData.SizeInPoints = 12.0!
        Appearance5.TextHAlignAsString = "Right"
        Me.tbxComBase.Appearance = Appearance5
        Me.tbxComBase.AutoSize = False
        Me.tbxComBase.CausesValidation = False
        Me.tbxComBase.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.VENDEDORBindingSource, "COMISIONPOR", True))
        Me.tbxComBase.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxComBase.InputMask = "nnn.nn"
        Me.tbxComBase.Location = New System.Drawing.Point(125, 391)
        Me.tbxComBase.Name = "tbxComBase"
        Me.tbxComBase.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxComBase.Size = New System.Drawing.Size(75, 26)
        Me.tbxComBase.TabIndex = 7
        '
        'BtnAsterisco
        '
        Me.BtnAsterisco.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnAsterisco.BackColor = System.Drawing.Color.Transparent
        Me.BtnAsterisco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAsterisco.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.BtnAsterisco.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BtnAsterisco.Location = New System.Drawing.Point(429, 142)
        Me.BtnAsterisco.Name = "BtnAsterisco"
        Me.BtnAsterisco.Size = New System.Drawing.Size(24, 23)
        Me.BtnAsterisco.TabIndex = 506
        Me.BtnAsterisco.TabStop = False
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(202, 393)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Size = New System.Drawing.Size(22, 22)
        Me.RadLabel2.TabIndex = 504
        Me.RadLabel2.Text = "%"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label3.Location = New System.Drawing.Point(23, 355)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 28)
        Me.Label3.TabIndex = 502
        Me.Label3.Text = "Comisión"
        '
        'tbxCelular
        '
        Me.tbxCelular.AcceptsTab = True
        Me.tbxCelular.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCelular.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "CELULAR", True))
        Me.tbxCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCelular.Location = New System.Drawing.Point(125, 184)
        Me.tbxCelular.Name = "tbxCelular"
        Me.tbxCelular.Size = New System.Drawing.Size(328, 26)
        Me.tbxCelular.TabIndex = 3
        '
        'tbxEmail
        '
        Me.tbxEmail.AcceptsTab = True
        Me.tbxEmail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "EMAIL", True))
        Me.tbxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxEmail.Location = New System.Drawing.Point(125, 228)
        Me.tbxEmail.Name = "tbxEmail"
        Me.tbxEmail.Size = New System.Drawing.Size(328, 26)
        Me.tbxEmail.TabIndex = 4
        '
        'tbxCedula
        '
        Me.tbxCedula.AcceptsTab = True
        Me.tbxCedula.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxCedula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCedula.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "CEDULA", True))
        Me.tbxCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCedula.Location = New System.Drawing.Point(125, 272)
        Me.tbxCedula.Name = "tbxCedula"
        Me.tbxCedula.Size = New System.Drawing.Size(328, 26)
        Me.tbxCedula.TabIndex = 5
        '
        'RadLabel1
        '
        Me.RadLabel1.AutoSize = False
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Location = New System.Drawing.Point(23, 99)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Size = New System.Drawing.Size(100, 20)
        Me.RadLabel1.TabIndex = 492
        Me.RadLabel1.Text = "Nro. Vendedor:"
        Me.RadLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxNroVend
        '
        Me.tbxNroVend.AcceptsTab = True
        Me.tbxNroVend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNroVend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroVend.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "NUMVENDEDOR", True))
        Me.tbxNroVend.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNroVend.Location = New System.Drawing.Point(125, 96)
        Me.tbxNroVend.Name = "tbxNroVend"
        Me.tbxNroVend.Size = New System.Drawing.Size(328, 26)
        Me.tbxNroVend.TabIndex = 1
        '
        'RadLbConfig7
        '
        Me.RadLbConfig7.AutoSize = False
        Me.RadLbConfig7.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig7.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig7.Location = New System.Drawing.Point(22, 318)
        Me.RadLbConfig7.Name = "RadLbConfig7"
        '
        '
        '
        Me.RadLbConfig7.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig7.Size = New System.Drawing.Size(101, 20)
        Me.RadLbConfig7.TabIndex = 491
        Me.RadLbConfig7.Text = "Estado:"
        Me.RadLbConfig7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.BackColor = System.Drawing.Color.White
        Me.cmbEstado.CausesValidation = False
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstado.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Inactivo", "Activo"})
        Me.cmbEstado.Location = New System.Drawing.Point(125, 315)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(119, 25)
        Me.cmbEstado.TabIndex = 6
        '
        'RadLbConfig6
        '
        Me.RadLbConfig6.AutoSize = False
        Me.RadLbConfig6.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig6.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig6.Location = New System.Drawing.Point(22, 394)
        Me.RadLbConfig6.Name = "RadLbConfig6"
        '
        '
        '
        Me.RadLbConfig6.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig6.Size = New System.Drawing.Size(101, 20)
        Me.RadLbConfig6.TabIndex = 489
        Me.RadLbConfig6.Text = "Base:"
        Me.RadLbConfig6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig5
        '
        Me.RadLbConfig5.AutoSize = False
        Me.RadLbConfig5.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig5.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig5.Location = New System.Drawing.Point(22, 275)
        Me.RadLbConfig5.Name = "RadLbConfig5"
        '
        '
        '
        Me.RadLbConfig5.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig5.Size = New System.Drawing.Size(101, 20)
        Me.RadLbConfig5.TabIndex = 487
        Me.RadLbConfig5.Text = "CI Nº:"
        Me.RadLbConfig5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig4
        '
        Me.RadLbConfig4.AutoSize = False
        Me.RadLbConfig4.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig4.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig4.Location = New System.Drawing.Point(22, 231)
        Me.RadLbConfig4.Name = "RadLbConfig4"
        '
        '
        '
        Me.RadLbConfig4.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig4.Size = New System.Drawing.Size(101, 20)
        Me.RadLbConfig4.TabIndex = 485
        Me.RadLbConfig4.Text = "Email:"
        Me.RadLbConfig4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig3
        '
        Me.RadLbConfig3.AutoSize = False
        Me.RadLbConfig3.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig3.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig3.Location = New System.Drawing.Point(22, 187)
        Me.RadLbConfig3.Name = "RadLbConfig3"
        '
        '
        '
        Me.RadLbConfig3.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig3.Size = New System.Drawing.Size(101, 20)
        Me.RadLbConfig3.TabIndex = 483
        Me.RadLbConfig3.Text = "Celular:"
        Me.RadLbConfig3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig2
        '
        Me.RadLbConfig2.AutoSize = False
        Me.RadLbConfig2.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLbConfig2.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig2.Location = New System.Drawing.Point(23, 143)
        Me.RadLbConfig2.Name = "RadLbConfig2"
        '
        '
        '
        Me.RadLbConfig2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig2.Size = New System.Drawing.Size(100, 20)
        Me.RadLbConfig2.TabIndex = 481
        Me.RadLbConfig2.Text = "Usuario:"
        Me.RadLbConfig2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.Color.Gainsboro
        Me.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(224, -29)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(42, 26)
        Me.txtEstado.TabIndex = 475
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "DESVENDEDOR", True))
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblNombre.Location = New System.Drawing.Point(23, 39)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(430, 36)
        Me.lblNombre.TabIndex = 501
        Me.lblNombre.Text = "Vendedor Lbl"
        '
        'tbxNombre
        '
        Me.tbxNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.VENDEDORBindingSource, "DESVENDEDOR", True))
        Me.tbxNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNombre.Location = New System.Drawing.Point(23, 46)
        Me.tbxNombre.Name = "tbxNombre"
        Me.tbxNombre.Size = New System.Drawing.Size(430, 29)
        Me.tbxNombre.TabIndex = 0
        '
        'pnlTransfer
        '
        Me.pnlTransfer.BackColor = System.Drawing.Color.LightGray
        Me.pnlTransfer.Controls.Add(Me.btnTransferir)
        Me.pnlTransfer.Controls.Add(Me.pnlPorZona)
        Me.pnlTransfer.Controls.Add(Me.pnlPorVendedor)
        Me.pnlTransfer.Controls.Add(Me.rbPorVendedor)
        Me.pnlTransfer.Controls.Add(Me.rbPorZona)
        Me.pnlTransfer.Controls.Add(Me.Label1)
        Me.pnlTransfer.Location = New System.Drawing.Point(-1, 36)
        Me.pnlTransfer.Name = "pnlTransfer"
        Me.pnlTransfer.Size = New System.Drawing.Size(749, 465)
        Me.pnlTransfer.TabIndex = 1000
        '
        'btnTransferir
        '
        Me.btnTransferir.BackColor = System.Drawing.Color.DarkOrange
        Me.btnTransferir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTransferir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransferir.Location = New System.Drawing.Point(535, 414)
        Me.btnTransferir.Name = "btnTransferir"
        Me.btnTransferir.Size = New System.Drawing.Size(192, 33)
        Me.btnTransferir.TabIndex = 475
        Me.btnTransferir.Text = "Transferir"
        Me.btnTransferir.UseVisualStyleBackColor = False
        '
        'pnlPorZona
        '
        Me.pnlPorZona.Controls.Add(Me.cmbZona)
        Me.pnlPorZona.Controls.Add(Me.cmbVendedorAZona)
        Me.pnlPorZona.Controls.Add(Me.Label5)
        Me.pnlPorZona.Controls.Add(Me.Label6)
        Me.pnlPorZona.Location = New System.Drawing.Point(19, 273)
        Me.pnlPorZona.Name = "pnlPorZona"
        Me.pnlPorZona.Size = New System.Drawing.Size(708, 124)
        Me.pnlPorZona.TabIndex = 475
        '
        'cmbZona
        '
        Me.cmbZona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbZona.BackColor = System.Drawing.Color.White
        Me.cmbZona.CausesValidation = False
        Me.cmbZona.DataSource = Me.ZONABindingSource
        Me.cmbZona.DisplayMember = "DESZONA"
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbZona.FormattingEnabled = True
        Me.cmbZona.Location = New System.Drawing.Point(23, 48)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(273, 28)
        Me.cmbZona.TabIndex = 473
        Me.cmbZona.ValueMember = "CODZONA"
        '
        'ZONABindingSource
        '
        Me.ZONABindingSource.DataMember = "ZONA"
        Me.ZONABindingSource.DataSource = Me.DsCentroDeCosto
        '
        'cmbVendedorAZona
        '
        Me.cmbVendedorAZona.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVendedorAZona.BackColor = System.Drawing.Color.White
        Me.cmbVendedorAZona.CausesValidation = False
        Me.cmbVendedorAZona.DataSource = Me.VENDEDOR4BindingSource
        Me.cmbVendedorAZona.DisplayMember = "DESVENDEDOR"
        Me.cmbVendedorAZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedorAZona.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedorAZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbVendedorAZona.FormattingEnabled = True
        Me.cmbVendedorAZona.Location = New System.Drawing.Point(415, 48)
        Me.cmbVendedorAZona.Name = "cmbVendedorAZona"
        Me.cmbVendedorAZona.Size = New System.Drawing.Size(254, 28)
        Me.cmbVendedorAZona.TabIndex = 7
        Me.cmbVendedorAZona.ValueMember = "CODVENDEDOR"
        '
        'VENDEDOR4BindingSource
        '
        Me.VENDEDOR4BindingSource.AllowNew = False
        Me.VENDEDOR4BindingSource.DataMember = "VENDEDOR"
        Me.VENDEDOR4BindingSource.DataSource = Me.DsCentroDeCosto
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(415, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(148, 17)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Transferir a Vendedor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label6.Location = New System.Drawing.Point(23, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 17)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "De Zona"
        '
        'pnlPorVendedor
        '
        Me.pnlPorVendedor.Controls.Add(Me.cmbVendedorDe)
        Me.pnlPorVendedor.Controls.Add(Me.cmbVendedorA)
        Me.pnlPorVendedor.Controls.Add(Me.Label4)
        Me.pnlPorVendedor.Controls.Add(Me.Label2)
        Me.pnlPorVendedor.Location = New System.Drawing.Point(19, 99)
        Me.pnlPorVendedor.Name = "pnlPorVendedor"
        Me.pnlPorVendedor.Size = New System.Drawing.Size(708, 126)
        Me.pnlPorVendedor.TabIndex = 2
        '
        'cmbVendedorDe
        '
        Me.cmbVendedorDe.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVendedorDe.BackColor = System.Drawing.Color.White
        Me.cmbVendedorDe.CausesValidation = False
        Me.cmbVendedorDe.DataSource = Me.VENDEDOR2BindingSource
        Me.cmbVendedorDe.DisplayMember = "DESVENDEDOR"
        Me.cmbVendedorDe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedorDe.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedorDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbVendedorDe.FormattingEnabled = True
        Me.cmbVendedorDe.Location = New System.Drawing.Point(19, 48)
        Me.cmbVendedorDe.Name = "cmbVendedorDe"
        Me.cmbVendedorDe.Size = New System.Drawing.Size(273, 28)
        Me.cmbVendedorDe.TabIndex = 473
        Me.cmbVendedorDe.ValueMember = "CODVENDEDOR"
        '
        'VENDEDOR2BindingSource
        '
        Me.VENDEDOR2BindingSource.AllowNew = False
        Me.VENDEDOR2BindingSource.DataMember = "VENDEDOR"
        Me.VENDEDOR2BindingSource.DataSource = Me.DsCentroDeCosto
        '
        'cmbVendedorA
        '
        Me.cmbVendedorA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbVendedorA.BackColor = System.Drawing.Color.White
        Me.cmbVendedorA.CausesValidation = False
        Me.cmbVendedorA.DataSource = Me.VENDEDOR3BindingSource
        Me.cmbVendedorA.DisplayMember = "DESVENDEDOR"
        Me.cmbVendedorA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVendedorA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbVendedorA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbVendedorA.FormattingEnabled = True
        Me.cmbVendedorA.Location = New System.Drawing.Point(415, 48)
        Me.cmbVendedorA.Name = "cmbVendedorA"
        Me.cmbVendedorA.Size = New System.Drawing.Size(254, 28)
        Me.cmbVendedorA.TabIndex = 7
        Me.cmbVendedorA.ValueMember = "CODVENDEDOR"
        '
        'VENDEDOR3BindingSource
        '
        Me.VENDEDOR3BindingSource.AllowNew = False
        Me.VENDEDOR3BindingSource.DataMember = "VENDEDOR"
        Me.VENDEDOR3BindingSource.DataSource = Me.DsCentroDeCosto
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(415, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 17)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Transferir a Vendedor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(19, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "De Vendedor"
        '
        'rbPorVendedor
        '
        Me.rbPorVendedor.AutoSize = True
        Me.rbPorVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rbPorVendedor.Location = New System.Drawing.Point(21, 73)
        Me.rbPorVendedor.Name = "rbPorVendedor"
        Me.rbPorVendedor.Size = New System.Drawing.Size(125, 24)
        Me.rbPorVendedor.TabIndex = 0
        Me.rbPorVendedor.TabStop = True
        Me.rbPorVendedor.Text = "Por Vendedor"
        Me.rbPorVendedor.UseVisualStyleBackColor = True
        '
        'rbPorZona
        '
        Me.rbPorZona.AutoSize = True
        Me.rbPorZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rbPorZona.Location = New System.Drawing.Point(21, 247)
        Me.rbPorZona.Name = "rbPorZona"
        Me.rbPorZona.Size = New System.Drawing.Size(92, 24)
        Me.rbPorZona.TabIndex = 1
        Me.rbPorZona.TabStop = True
        Me.rbPorZona.Text = "Por Zona"
        Me.rbPorZona.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transferencia de Clientes"
        '
        'USUARIOTableAdapter
        '
        Me.USUARIOTableAdapter.ClearBeforeFill = True
        '
        'VENDEDORTableAdapter
        '
        Me.VENDEDORTableAdapter.ClearBeforeFill = True
        '
        'SplitVendedor
        '
        Me.SplitVendedor.BackColor = System.Drawing.Color.Gainsboro
        Me.SplitVendedor.Location = New System.Drawing.Point(0, 36)
        Me.SplitVendedor.Name = "SplitVendedor"
        '
        'SplitVendedor.Panel1
        '
        Me.SplitVendedor.Panel1.Controls.Add(Me.dgvVendedor)
        Me.SplitVendedor.Panel1.Controls.Add(Me.gbxUsuario)
        '
        'SplitVendedor.Panel2
        '
        Me.SplitVendedor.Panel2.Controls.Add(Me.PanelDatos)
        Me.SplitVendedor.Size = New System.Drawing.Size(747, 463)
        Me.SplitVendedor.SplitterDistance = 249
        Me.SplitVendedor.TabIndex = 474
        '
        'ZONATableAdapter
        '
        Me.ZONATableAdapter.ClearBeforeFill = True
        '
        'ABMVendedorV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(747, 500)
        Me.Controls.Add(Me.pnlBotonera)
        Me.Controls.Add(Me.SplitVendedor)
        Me.Controls.Add(Me.pnlTransfer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ABMVendedorV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vendedor  | Cogent SIG"
        CType(Me.dgvVendedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCentroDeCosto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBotonera.ResumeLayout(False)
        Me.pnlEditBusc.ResumeLayout(False)
        Me.pnlEditBusc.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxTransferCli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxUsuario.ResumeLayout(False)
        Me.gbxUsuario.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDatos.ResumeLayout(False)
        Me.PanelDatos.PerformLayout()
        CType(Me.BtnAsterisco, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTransfer.ResumeLayout(False)
        Me.pnlTransfer.PerformLayout()
        Me.pnlPorZona.ResumeLayout(False)
        Me.pnlPorZona.PerformLayout()
        CType(Me.ZONABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDOR4BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPorVendedor.ResumeLayout(False)
        Me.pnlPorVendedor.PerformLayout()
        CType(Me.VENDEDOR2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.VENDEDOR3BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitVendedor.Panel1.ResumeLayout(False)
        Me.SplitVendedor.Panel2.ResumeLayout(False)
        Me.SplitVendedor.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvVendedor As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBotonera As System.Windows.Forms.Panel
    Friend WithEvents PanelDatos As System.Windows.Forms.Panel
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents RadLbConfig4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents VENDEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCentroDeCosto As ContaExpress.DsCentroDeCosto
    Friend WithEvents USUARIOTableAdapter As ContaExpress.DsCentroDeCostoTableAdapters.USUARIOTableAdapter
    Friend WithEvents VENDEDORTableAdapter As ContaExpress.DsCentroDeCostoTableAdapters.VENDEDORTableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents USUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tbxNroVend As System.Windows.Forms.TextBox
    Friend WithEvents tbxCelular As System.Windows.Forms.TextBox
    Friend WithEvents tbxEmail As System.Windows.Forms.TextBox
    Friend WithEvents tbxCedula As System.Windows.Forms.TextBox
    Friend WithEvents tbxNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents SplitVendedor As System.Windows.Forms.SplitContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents BtnAsterisco As System.Windows.Forms.PictureBox
    Friend WithEvents gbxUsuario As System.Windows.Forms.GroupBox
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents NOMBREUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TxtBuscaUsuario As System.Windows.Forms.TextBox
    Friend WithEvents tbxComBase As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents CODVENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMVENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESVENDEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIOV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CELULAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEDULA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMISIONPOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tbxUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents pnlTransfer As System.Windows.Forms.Panel
    Friend WithEvents rbPorZona As System.Windows.Forms.RadioButton
    Friend WithEvents rbPorVendedor As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbxTransferCli As System.Windows.Forms.PictureBox
    Friend WithEvents pnlPorVendedor As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbVendedorA As System.Windows.Forms.ComboBox
    Friend WithEvents VENDEDOR2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents VENDEDOR3BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmbVendedorDe As System.Windows.Forms.ComboBox
    Friend WithEvents pnlPorZona As System.Windows.Forms.Panel
    Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVendedorAZona As System.Windows.Forms.ComboBox
    Friend WithEvents VENDEDOR4BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ZONABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ZONATableAdapter As ContaExpress.DsCentroDeCostoTableAdapters.ZONATableAdapter
    Friend WithEvents btnTransferir As System.Windows.Forms.Button
    Friend WithEvents pbxDatos As System.Windows.Forms.PictureBox
    Friend WithEvents pnlEditBusc As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
