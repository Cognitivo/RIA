<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMCaja
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMCaja))
        Me.DESEMPRESALabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbxContabilidad = New System.Windows.Forms.CheckBox()
        Me.txtNumeroCaja = New Telerik.WinControls.UI.RadTextBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettingFO = New ContaExpress.DsSettingFO()
        Me.cboSucursal = New Telerik.WinControls.UI.RadComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettingFOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtNumCaja = New System.Windows.Forms.TextBox()
        Me.COBRADORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.grdBuscador = New Telerik.WinControls.UI.RadGridView()
        Me.Cobrador1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.USUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadButtonCaja = New Telerik.WinControls.UI.RadButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelNroCobrador = New System.Windows.Forms.Label()
        Me.CAJATableAdapter = New ContaExpress.DsSettingFOTableAdapters.CAJATableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.DsSettingFOTableAdapters.SUCURSALTableAdapter()
        Me.COBRADORTableAdapter = New ContaExpress.DsSettingFOTableAdapters.COBRADORTableAdapter()
        Me.USUARIOTableAdapter = New ContaExpress.DsSettingFOTableAdapters.USUARIOTableAdapter()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnGenerarApertura = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.txtNumeroCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COBRADORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Cobrador1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButtonCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DESEMPRESALabel
        '
        Me.DESEMPRESALabel.AutoSize = True
        Me.DESEMPRESALabel.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.DESEMPRESALabel.Location = New System.Drawing.Point(16, 23)
        Me.DESEMPRESALabel.Name = "DESEMPRESALabel"
        Me.DESEMPRESALabel.Size = New System.Drawing.Size(90, 16)
        Me.DESEMPRESALabel.TabIndex = 366
        Me.DESEMPRESALabel.Text = "Descripcion :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(34, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 370
        Me.Label2.Text = "Sucursal :"
        '
        'cbxContabilidad
        '
        Me.cbxContabilidad.AutoSize = True
        Me.cbxContabilidad.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cbxContabilidad.Location = New System.Drawing.Point(111, 49)
        Me.cbxContabilidad.Name = "cbxContabilidad"
        Me.cbxContabilidad.Size = New System.Drawing.Size(112, 20)
        Me.cbxContabilidad.TabIndex = 372
        Me.cbxContabilidad.Text = "Uso Contable"
        Me.cbxContabilidad.UseVisualStyleBackColor = True
        '
        'txtNumeroCaja
        '
        Me.txtNumeroCaja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CAJABindingSource, "NUMEROCAJA", True))
        Me.txtNumeroCaja.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtNumeroCaja.Location = New System.Drawing.Point(109, 16)
        Me.txtNumeroCaja.Name = "txtNumeroCaja"
        Me.txtNumeroCaja.Size = New System.Drawing.Size(250, 26)
        Me.txtNumeroCaja.TabIndex = 0
        Me.txtNumeroCaja.TabStop = False
        Me.txtNumeroCaja.ThemeName = "Breeze"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsSettingFO
        '
        'DsSettingFO
        '
        Me.DsSettingFO.DataSetName = "DsSettingFO"
        Me.DsSettingFO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cboSucursal
        '
        Me.cboSucursal.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.CAJABindingSource, "CODSUCURSAL", True))
        Me.cboSucursal.DataSource = Me.SUCURSALBindingSource
        Me.cboSucursal.DisplayMember = "DESSUCURSAL"
        Me.cboSucursal.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cboSucursal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboSucursal.Location = New System.Drawing.Point(108, 76)
        Me.cboSucursal.Name = "cboSucursal"
        '
        '
        '
        Me.cboSucursal.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.cboSucursal.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.cboSucursal.Size = New System.Drawing.Size(250, 26)
        Me.cboSucursal.TabIndex = 1
        Me.cboSucursal.TabStop = False
        Me.cboSucursal.ThemeName = "Breeze"
        Me.cboSucursal.ValueMember = "CODSUCURSAL"
        CType(Me.cboSucursal.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Arial", 12.0!)
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsSettingFOBindingSource
        '
        'DsSettingFOBindingSource
        '
        Me.DsSettingFOBindingSource.DataSource = Me.DsSettingFO
        Me.DsSettingFOBindingSource.Position = 0
        '
        'txtNumCaja
        '
        Me.txtNumCaja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CAJABindingSource, "NUMCAJA", True))
        Me.txtNumCaja.Location = New System.Drawing.Point(169, 19)
        Me.txtNumCaja.Name = "txtNumCaja"
        Me.txtNumCaja.Size = New System.Drawing.Size(52, 20)
        Me.txtNumCaja.TabIndex = 371
        '
        'COBRADORBindingSource
        '
        Me.COBRADORBindingSource.DataMember = "COBRADOR"
        Me.COBRADORBindingSource.DataSource = Me.DsSettingFO
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Tan
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.CausesValidation = False
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtBuscar.Location = New System.Drawing.Point(33, 5)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(164, 31)
        Me.txtBuscar.TabIndex = 395
        '
        'grdBuscador
        '
        Me.grdBuscador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdBuscador.BackColor = System.Drawing.Color.LightGray
        Me.grdBuscador.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdBuscador.EnableAlternatingRowColor = True
        Me.grdBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdBuscador.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdBuscador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdBuscador.Location = New System.Drawing.Point(2, 41)
        '
        '
        '
        Me.grdBuscador.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdBuscador.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldName = "NUMCAJA"
        GridViewDecimalColumn1.HeaderText = "NUMCAJA"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "NUMCAJA"
        GridViewTextBoxColumn1.FieldName = "NUMEROCAJA"
        GridViewTextBoxColumn1.HeaderText = "Descripcion"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.UniqueName = "NUMEROCAJA"
        GridViewTextBoxColumn1.Width = 180
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldName = "CODSUCURSAL"
        GridViewDecimalColumn2.HeaderText = "CODSUCURSAL"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODSUCURSAL"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldName = "CODCOBRADOR"
        GridViewDecimalColumn3.HeaderText = "CODCOBRADOR"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODCOBRADOR"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldName = "CODUSUARIO"
        GridViewDecimalColumn4.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn5.DataType = GetType(Decimal)
        GridViewDecimalColumn5.FieldName = "CODEMPRESA"
        GridViewDecimalColumn5.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "CODEMPRESA"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldName = "CONTABILIDAD"
        GridViewDecimalColumn6.HeaderText = "CONTABILIDAD"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "CONTABILIDAD"
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.grdBuscador.MasterGridViewTemplate.DataSource = Me.CAJABindingSource
        Me.grdBuscador.MasterGridViewTemplate.EnableFiltering = True
        Me.grdBuscador.MasterGridViewTemplate.EnableGrouping = False
        Me.grdBuscador.MasterGridViewTemplate.ShowFilteringRow = False
        Me.grdBuscador.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.grdBuscador.Name = "grdBuscador"
        Me.grdBuscador.ReadOnly = True
        Me.grdBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdBuscador.ShowGroupPanel = False
        Me.grdBuscador.Size = New System.Drawing.Size(199, 328)
        Me.grdBuscador.TabIndex = 396
        Me.grdBuscador.ThemeName = "ControlDefault"
        '
        'Cobrador1BindingSource
        '
        Me.Cobrador1BindingSource.DataMember = "COBRADOR"
        Me.Cobrador1BindingSource.DataSource = Me.DsSettingFO
        '
        'USUARIOBindingSource
        '
        Me.USUARIOBindingSource.DataMember = "USUARIO"
        Me.USUARIOBindingSource.DataSource = Me.DsSettingFO
        '
        'RadButtonCaja
        '
        Me.RadButtonCaja.Location = New System.Drawing.Point(332, 9)
        Me.RadButtonCaja.Name = "RadButtonCaja"
        Me.RadButtonCaja.Size = New System.Drawing.Size(75, 23)
        Me.RadButtonCaja.TabIndex = 399
        Me.RadButtonCaja.Text = "Caja"
        Me.RadButtonCaja.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.pbxModificarFicha)
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.pbxNuevaFicha)
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 40)
        Me.Panel1.TabIndex = 354
        '
        'pbxModificarFicha
        '
        Me.pbxModificarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxModificarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxModificarFicha.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.pbxModificarFicha.InitialImage = Nothing
        Me.pbxModificarFicha.Location = New System.Drawing.Point(274, 2)
        Me.pbxModificarFicha.Name = "pbxModificarFicha"
        Me.pbxModificarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxModificarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxModificarFicha.TabIndex = 5
        Me.pbxModificarFicha.TabStop = False
        '
        'pbxNuevaFicha
        '
        Me.pbxNuevaFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevaFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevaFicha.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevaFicha.InitialImage = Nothing
        Me.pbxNuevaFicha.Location = New System.Drawing.Point(201, 2)
        Me.pbxNuevaFicha.Name = "pbxNuevaFicha"
        Me.pbxNuevaFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxNuevaFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuevaFicha.TabIndex = 3
        Me.pbxNuevaFicha.TabStop = False
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(348, 2)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(35, 35)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 7
        Me.pbxCancelar.TabStop = False
        '
        'pbxEliminarFicha
        '
        Me.pbxEliminarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxEliminarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEliminarFicha.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.pbxEliminarFicha.InitialImage = Nothing
        Me.pbxEliminarFicha.Location = New System.Drawing.Point(238, 2)
        Me.pbxEliminarFicha.Name = "pbxEliminarFicha"
        Me.pbxEliminarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxEliminarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEliminarFicha.TabIndex = 4
        Me.pbxEliminarFicha.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.pbxGuardar.InitialImage = Nothing
        Me.pbxGuardar.Location = New System.Drawing.Point(311, 2)
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
        Me.PictureBox1.Location = New System.Drawing.Point(3, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 396
        Me.PictureBox1.TabStop = False
        '
        'LabelNroCobrador
        '
        Me.LabelNroCobrador.AutoSize = True
        Me.LabelNroCobrador.BackColor = System.Drawing.Color.Transparent
        Me.LabelNroCobrador.Location = New System.Drawing.Point(602, 43)
        Me.LabelNroCobrador.Name = "LabelNroCobrador"
        Me.LabelNroCobrador.Size = New System.Drawing.Size(93, 13)
        Me.LabelNroCobrador.TabIndex = 401
        Me.LabelNroCobrador.Text = "LabelNroCobrador"
        Me.LabelNroCobrador.Visible = False
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'COBRADORTableAdapter
        '
        Me.COBRADORTableAdapter.ClearBeforeFill = True
        '
        'USUARIOTableAdapter
        '
        Me.USUARIOTableAdapter.ClearBeforeFill = True
        '
        'Panel2
        '
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtNumeroCaja)
        Me.Panel2.Controls.Add(Me.txtNumCaja)
        Me.Panel2.Controls.Add(Me.cbxContabilidad)
        Me.Panel2.Controls.Add(Me.DESEMPRESALabel)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cboSucursal)
        Me.Panel2.Location = New System.Drawing.Point(213, 154)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(470, 122)
        Me.Panel2.TabIndex = 400
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(241, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(442, 77)
        Me.Label1.TabIndex = 401
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox2.Location = New System.Drawing.Point(207, 67)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 402
        Me.PictureBox2.TabStop = False
        '
        'btnGenerarApertura
        '
        Me.btnGenerarApertura.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarApertura.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnGenerarApertura.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnGenerarApertura.Location = New System.Drawing.Point(215, 294)
        Me.btnGenerarApertura.Name = "btnGenerarApertura"
        Me.btnGenerarApertura.Size = New System.Drawing.Size(162, 45)
        Me.btnGenerarApertura.TabIndex = 403
        Me.btnGenerarApertura.Text = "Generar Aperturas Automaticas"
        Me.btnGenerarApertura.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(379, 295)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(304, 45)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Genera una Apertura de Forma Automatica para las Cuentas Bancarias. Usted puede c" & _
    "on esta accion empezar a realizar los Pagos/Cobros en dichas Cuentas"
        '
        'ABMCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(695, 373)
        Me.Controls.Add(Me.LabelNroCobrador)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnGenerarApertura)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.grdBuscador)
        Me.Controls.Add(Me.RadButtonCaja)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "ABMCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas  | Cogent SIG"
        CType(Me.txtNumeroCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COBRADORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Cobrador1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButtonCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents txtNumeroCaja As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents grdBuscador As Telerik.WinControls.UI.RadGridView
    Friend WithEvents cboSucursal As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents DsSettingFO As ContaExpress.DsSettingFO
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsSettingFOTableAdapters.CAJATableAdapter
    Friend WithEvents DsSettingFOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsSettingFOTableAdapters.SUCURSALTableAdapter
    Friend WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents COBRADORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COBRADORTableAdapter As ContaExpress.DsSettingFOTableAdapters.COBRADORTableAdapter
    Friend WithEvents RadButtonCaja As Telerik.WinControls.UI.RadButton
    Friend WithEvents Cobrador1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USUARIOTableAdapter As ContaExpress.DsSettingFOTableAdapters.USUARIOTableAdapter
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents txtNumCaja As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cbxContabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNroCobrador As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents btnGenerarApertura As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
