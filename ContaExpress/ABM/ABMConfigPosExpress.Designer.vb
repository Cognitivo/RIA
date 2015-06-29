<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMConfigPosExpress
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMConfigPosExpress))
        Me.dgwModulo = New System.Windows.Forms.DataGridView()
        Me.MODULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULOID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsConfigPEX = New ContaExpress.DsConfigPEX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.lblModuloName = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadLbConfig13 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig13 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig12 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig12 = New System.Windows.Forms.ComboBox()
        Me.cbxConfig1 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig11 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig11 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig10 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig10 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig9 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig8 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig9 = New System.Windows.Forms.ComboBox()
        Me.cbxConfig8 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig7 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig7 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig6 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig5 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig6 = New System.Windows.Forms.ComboBox()
        Me.cbxConfig5 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig4 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig4 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig3 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxConfig3 = New System.Windows.Forms.ComboBox()
        Me.RadLbConfig2 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLbConfig1 = New Telerik.WinControls.UI.RadLabel()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.cbxConfig2 = New System.Windows.Forms.ComboBox()
        Me.tbxCustomField = New System.Windows.Forms.TextBox()
        Me.lblAjuste = New System.Windows.Forms.Label()
        Me.tbxMesesAjuste = New System.Windows.Forms.TextBox()
        Me.lblMensajeRestrinccion = New Telerik.WinControls.UI.RadLabel()
        Me.MODULOTableAdapter = New ContaExpress.DsConfigPEXTableAdapters.MODULOTableAdapter()
        CType(Me.dgwModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MODULOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsConfigPEX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblModuloName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.RadLbConfig13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLbConfig1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensajeRestrinccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgwModulo
        '
        Me.dgwModulo.AllowUserToAddRows = False
        Me.dgwModulo.AllowUserToDeleteRows = False
        Me.dgwModulo.AllowUserToResizeColumns = False
        Me.dgwModulo.AllowUserToResizeRows = False
        Me.dgwModulo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgwModulo.AutoGenerateColumns = False
        Me.dgwModulo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwModulo.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwModulo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwModulo.ColumnHeadersHeight = 35
        Me.dgwModulo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MODULO, Me.MODULOID})
        Me.dgwModulo.DataSource = Me.MODULOBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgwModulo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgwModulo.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgwModulo.Location = New System.Drawing.Point(-1, 37)
        Me.dgwModulo.MultiSelect = False
        Me.dgwModulo.Name = "dgwModulo"
        Me.dgwModulo.ReadOnly = True
        Me.dgwModulo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwModulo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwModulo.RowHeadersVisible = False
        Me.dgwModulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgwModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwModulo.Size = New System.Drawing.Size(240, 500)
        Me.dgwModulo.TabIndex = 422
        '
        'MODULO
        '
        Me.MODULO.DataPropertyName = "MODULO"
        Me.MODULO.HeaderText = "Modulo"
        Me.MODULO.Name = "MODULO"
        Me.MODULO.ReadOnly = True
        '
        'MODULOID
        '
        Me.MODULOID.DataPropertyName = "MODULO_ID"
        Me.MODULOID.HeaderText = "MODULO_ID"
        Me.MODULOID.Name = "MODULOID"
        Me.MODULOID.ReadOnly = True
        Me.MODULOID.Visible = False
        '
        'MODULOBindingSource
        '
        Me.MODULOBindingSource.DataMember = "MODULO"
        Me.MODULOBindingSource.DataSource = Me.DsConfigPEX
        '
        'DsConfigPEX
        '
        Me.DsConfigPEX.DataSetName = "DsConfigPEX"
        Me.DsConfigPEX.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.PictureBox8)
        Me.Panel1.Controls.Add(Me.lblModuloName)
        Me.Panel1.Controls.Add(Me.RadLabel7)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(853, 40)
        Me.Panel1.TabIndex = 457
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(4, 6)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 454
        Me.PictureBox8.TabStop = False
        '
        'lblModuloName
        '
        Me.lblModuloName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblModuloName.BackColor = System.Drawing.Color.Transparent
        Me.lblModuloName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "MODULO", True))
        Me.lblModuloName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.lblModuloName.ForeColor = System.Drawing.Color.Black
        Me.lblModuloName.Location = New System.Drawing.Point(698, 8)
        Me.lblModuloName.Name = "lblModuloName"
        '
        '
        '
        Me.lblModuloName.RootElement.ForeColor = System.Drawing.Color.Black
        Me.lblModuloName.Size = New System.Drawing.Size(123, 25)
        Me.lblModuloName.TabIndex = 479
        Me.lblModuloName.Text = "ModuloName"
        '
        'RadLabel7
        '
        Me.RadLabel7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel7.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel7.Location = New System.Drawing.Point(639, 13)
        Me.RadLabel7.Name = "RadLabel7"
        Me.RadLabel7.Size = New System.Drawing.Size(58, 18)
        Me.RadLabel7.TabIndex = 478
        Me.RadLabel7.Text = "Modulo :"
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.DeleteOff
        Me.EliminarPictureBox.Location = New System.Drawing.Point(280, 5)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.NewOff
        Me.NuevoPictureBox.Location = New System.Drawing.Point(245, 5)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(387, 5)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(315, 5)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.CausesValidation = False
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(32, 6)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(208, 30)
        Me.BuscarTextBox.TabIndex = 16
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(351, 5)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.RadLbConfig13)
        Me.Panel2.Controls.Add(Me.cbxConfig13)
        Me.Panel2.Controls.Add(Me.RadLbConfig12)
        Me.Panel2.Controls.Add(Me.cbxConfig12)
        Me.Panel2.Controls.Add(Me.cbxConfig1)
        Me.Panel2.Controls.Add(Me.RadLbConfig11)
        Me.Panel2.Controls.Add(Me.cbxConfig11)
        Me.Panel2.Controls.Add(Me.RadLbConfig10)
        Me.Panel2.Controls.Add(Me.cbxConfig10)
        Me.Panel2.Controls.Add(Me.RadLbConfig9)
        Me.Panel2.Controls.Add(Me.RadLbConfig8)
        Me.Panel2.Controls.Add(Me.cbxConfig9)
        Me.Panel2.Controls.Add(Me.cbxConfig8)
        Me.Panel2.Controls.Add(Me.RadLbConfig7)
        Me.Panel2.Controls.Add(Me.cbxConfig7)
        Me.Panel2.Controls.Add(Me.RadLbConfig6)
        Me.Panel2.Controls.Add(Me.RadLbConfig5)
        Me.Panel2.Controls.Add(Me.cbxConfig6)
        Me.Panel2.Controls.Add(Me.cbxConfig5)
        Me.Panel2.Controls.Add(Me.RadLbConfig4)
        Me.Panel2.Controls.Add(Me.cbxConfig4)
        Me.Panel2.Controls.Add(Me.RadLbConfig3)
        Me.Panel2.Controls.Add(Me.cbxConfig3)
        Me.Panel2.Controls.Add(Me.RadLbConfig2)
        Me.Panel2.Controls.Add(Me.RadLbConfig1)
        Me.Panel2.Controls.Add(Me.txtEstado)
        Me.Panel2.Controls.Add(Me.cbxConfig2)
        Me.Panel2.Controls.Add(Me.tbxCustomField)
        Me.Panel2.Controls.Add(Me.lblAjuste)
        Me.Panel2.Controls.Add(Me.tbxMesesAjuste)
        Me.Panel2.Location = New System.Drawing.Point(245, 73)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(591, 460)
        Me.Panel2.TabIndex = 473
        '
        'RadLbConfig13
        '
        Me.RadLbConfig13.AutoSize = False
        Me.RadLbConfig13.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig13.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig13.Location = New System.Drawing.Point(9, 420)
        Me.RadLbConfig13.Name = "RadLbConfig13"
        '
        '
        '
        Me.RadLbConfig13.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig13.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig13.TabIndex = 506
        Me.RadLbConfig13.Text = "Configuración 13:"
        Me.RadLbConfig13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig13
        '
        Me.cbxConfig13.BackColor = System.Drawing.Color.White
        Me.cbxConfig13.CausesValidation = False
        Me.cbxConfig13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG13", True))
        Me.cbxConfig13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig13.FormattingEnabled = True
        Me.cbxConfig13.Location = New System.Drawing.Point(256, 417)
        Me.cbxConfig13.Name = "cbxConfig13"
        Me.cbxConfig13.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig13.TabIndex = 505
        '
        'RadLbConfig12
        '
        Me.RadLbConfig12.AutoSize = False
        Me.RadLbConfig12.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig12.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig12.Location = New System.Drawing.Point(9, 386)
        Me.RadLbConfig12.Name = "RadLbConfig12"
        '
        '
        '
        Me.RadLbConfig12.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig12.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig12.TabIndex = 504
        Me.RadLbConfig12.Text = "Configuración 12:"
        Me.RadLbConfig12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig12
        '
        Me.cbxConfig12.BackColor = System.Drawing.Color.White
        Me.cbxConfig12.CausesValidation = False
        Me.cbxConfig12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG12", True))
        Me.cbxConfig12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig12.FormattingEnabled = True
        Me.cbxConfig12.Location = New System.Drawing.Point(256, 383)
        Me.cbxConfig12.Name = "cbxConfig12"
        Me.cbxConfig12.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig12.TabIndex = 503
        '
        'cbxConfig1
        '
        Me.cbxConfig1.BackColor = System.Drawing.Color.White
        Me.cbxConfig1.CausesValidation = False
        Me.cbxConfig1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG1", True))
        Me.cbxConfig1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig1.FormattingEnabled = True
        Me.cbxConfig1.Location = New System.Drawing.Point(256, 8)
        Me.cbxConfig1.Name = "cbxConfig1"
        Me.cbxConfig1.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig1.TabIndex = 1
        '
        'RadLbConfig11
        '
        Me.RadLbConfig11.AutoSize = False
        Me.RadLbConfig11.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig11.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig11.Location = New System.Drawing.Point(9, 352)
        Me.RadLbConfig11.Name = "RadLbConfig11"
        '
        '
        '
        Me.RadLbConfig11.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig11.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig11.TabIndex = 502
        Me.RadLbConfig11.Text = "Configuración 11:"
        Me.RadLbConfig11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig11
        '
        Me.cbxConfig11.BackColor = System.Drawing.Color.White
        Me.cbxConfig11.CausesValidation = False
        Me.cbxConfig11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG11", True))
        Me.cbxConfig11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig11.FormattingEnabled = True
        Me.cbxConfig11.Location = New System.Drawing.Point(256, 349)
        Me.cbxConfig11.Name = "cbxConfig11"
        Me.cbxConfig11.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig11.TabIndex = 501
        '
        'RadLbConfig10
        '
        Me.RadLbConfig10.AutoSize = False
        Me.RadLbConfig10.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig10.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig10.Location = New System.Drawing.Point(9, 318)
        Me.RadLbConfig10.Name = "RadLbConfig10"
        '
        '
        '
        Me.RadLbConfig10.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig10.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig10.TabIndex = 498
        Me.RadLbConfig10.Text = "Configuración 10:"
        Me.RadLbConfig10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig10
        '
        Me.cbxConfig10.BackColor = System.Drawing.Color.White
        Me.cbxConfig10.CausesValidation = False
        Me.cbxConfig10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG10", True))
        Me.cbxConfig10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig10.FormattingEnabled = True
        Me.cbxConfig10.Location = New System.Drawing.Point(256, 314)
        Me.cbxConfig10.Name = "cbxConfig10"
        Me.cbxConfig10.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig10.TabIndex = 497
        '
        'RadLbConfig9
        '
        Me.RadLbConfig9.AutoSize = False
        Me.RadLbConfig9.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig9.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig9.Location = New System.Drawing.Point(9, 284)
        Me.RadLbConfig9.Name = "RadLbConfig9"
        '
        '
        '
        Me.RadLbConfig9.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig9.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig9.TabIndex = 496
        Me.RadLbConfig9.Text = "Configuración 9:"
        Me.RadLbConfig9.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig8
        '
        Me.RadLbConfig8.AutoSize = False
        Me.RadLbConfig8.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig8.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig8.Location = New System.Drawing.Point(9, 250)
        Me.RadLbConfig8.Name = "RadLbConfig8"
        '
        '
        '
        Me.RadLbConfig8.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig8.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig8.TabIndex = 495
        Me.RadLbConfig8.Text = "Configuración 8:"
        Me.RadLbConfig8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig9
        '
        Me.cbxConfig9.BackColor = System.Drawing.Color.White
        Me.cbxConfig9.CausesValidation = False
        Me.cbxConfig9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG9", True))
        Me.cbxConfig9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig9.FormattingEnabled = True
        Me.cbxConfig9.Location = New System.Drawing.Point(256, 280)
        Me.cbxConfig9.Name = "cbxConfig9"
        Me.cbxConfig9.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig9.TabIndex = 494
        '
        'cbxConfig8
        '
        Me.cbxConfig8.BackColor = System.Drawing.Color.White
        Me.cbxConfig8.CausesValidation = False
        Me.cbxConfig8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG8", True))
        Me.cbxConfig8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig8.FormattingEnabled = True
        Me.cbxConfig8.Location = New System.Drawing.Point(256, 246)
        Me.cbxConfig8.Name = "cbxConfig8"
        Me.cbxConfig8.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig8.TabIndex = 493
        '
        'RadLbConfig7
        '
        Me.RadLbConfig7.AutoSize = False
        Me.RadLbConfig7.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig7.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig7.Location = New System.Drawing.Point(9, 216)
        Me.RadLbConfig7.Name = "RadLbConfig7"
        '
        '
        '
        Me.RadLbConfig7.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig7.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig7.TabIndex = 491
        Me.RadLbConfig7.Text = "Configuración 7:"
        Me.RadLbConfig7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig7
        '
        Me.cbxConfig7.BackColor = System.Drawing.Color.White
        Me.cbxConfig7.CausesValidation = False
        Me.cbxConfig7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG7", True))
        Me.cbxConfig7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig7.FormattingEnabled = True
        Me.cbxConfig7.Location = New System.Drawing.Point(256, 212)
        Me.cbxConfig7.Name = "cbxConfig7"
        Me.cbxConfig7.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig7.TabIndex = 490
        '
        'RadLbConfig6
        '
        Me.RadLbConfig6.AutoSize = False
        Me.RadLbConfig6.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig6.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig6.Location = New System.Drawing.Point(9, 182)
        Me.RadLbConfig6.Name = "RadLbConfig6"
        '
        '
        '
        Me.RadLbConfig6.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig6.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig6.TabIndex = 489
        Me.RadLbConfig6.Text = "Configuración 6:"
        Me.RadLbConfig6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig5
        '
        Me.RadLbConfig5.AutoSize = False
        Me.RadLbConfig5.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig5.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig5.Location = New System.Drawing.Point(9, 148)
        Me.RadLbConfig5.Name = "RadLbConfig5"
        '
        '
        '
        Me.RadLbConfig5.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig5.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig5.TabIndex = 487
        Me.RadLbConfig5.Text = "Configuración 5:"
        Me.RadLbConfig5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig6
        '
        Me.cbxConfig6.BackColor = System.Drawing.Color.White
        Me.cbxConfig6.CausesValidation = False
        Me.cbxConfig6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG6", True))
        Me.cbxConfig6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig6.FormattingEnabled = True
        Me.cbxConfig6.Location = New System.Drawing.Point(256, 178)
        Me.cbxConfig6.Name = "cbxConfig6"
        Me.cbxConfig6.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig6.TabIndex = 488
        '
        'cbxConfig5
        '
        Me.cbxConfig5.BackColor = System.Drawing.Color.White
        Me.cbxConfig5.CausesValidation = False
        Me.cbxConfig5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG5", True))
        Me.cbxConfig5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig5.FormattingEnabled = True
        Me.cbxConfig5.Location = New System.Drawing.Point(256, 144)
        Me.cbxConfig5.Name = "cbxConfig5"
        Me.cbxConfig5.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig5.TabIndex = 486
        '
        'RadLbConfig4
        '
        Me.RadLbConfig4.AutoSize = False
        Me.RadLbConfig4.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig4.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig4.Location = New System.Drawing.Point(9, 114)
        Me.RadLbConfig4.Name = "RadLbConfig4"
        '
        '
        '
        Me.RadLbConfig4.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig4.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig4.TabIndex = 485
        Me.RadLbConfig4.Text = "Configuración 4:"
        Me.RadLbConfig4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig4
        '
        Me.cbxConfig4.BackColor = System.Drawing.Color.White
        Me.cbxConfig4.CausesValidation = False
        Me.cbxConfig4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG4", True))
        Me.cbxConfig4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig4.FormattingEnabled = True
        Me.cbxConfig4.Location = New System.Drawing.Point(256, 110)
        Me.cbxConfig4.Name = "cbxConfig4"
        Me.cbxConfig4.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig4.TabIndex = 4
        '
        'RadLbConfig3
        '
        Me.RadLbConfig3.AutoSize = False
        Me.RadLbConfig3.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig3.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig3.Location = New System.Drawing.Point(9, 80)
        Me.RadLbConfig3.Name = "RadLbConfig3"
        '
        '
        '
        Me.RadLbConfig3.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig3.Size = New System.Drawing.Size(237, 20)
        Me.RadLbConfig3.TabIndex = 483
        Me.RadLbConfig3.Text = "Configuración 3:"
        Me.RadLbConfig3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxConfig3
        '
        Me.cbxConfig3.BackColor = System.Drawing.Color.White
        Me.cbxConfig3.CausesValidation = False
        Me.cbxConfig3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG3", True))
        Me.cbxConfig3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig3.FormattingEnabled = True
        Me.cbxConfig3.Location = New System.Drawing.Point(256, 76)
        Me.cbxConfig3.Name = "cbxConfig3"
        Me.cbxConfig3.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig3.TabIndex = 3
        '
        'RadLbConfig2
        '
        Me.RadLbConfig2.AutoSize = False
        Me.RadLbConfig2.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig2.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig2.Location = New System.Drawing.Point(10, 46)
        Me.RadLbConfig2.Name = "RadLbConfig2"
        '
        '
        '
        Me.RadLbConfig2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig2.Size = New System.Drawing.Size(236, 20)
        Me.RadLbConfig2.TabIndex = 481
        Me.RadLbConfig2.Text = "Configuración 2:"
        Me.RadLbConfig2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLbConfig1
        '
        Me.RadLbConfig1.AutoSize = False
        Me.RadLbConfig1.BackColor = System.Drawing.Color.Transparent
        Me.RadLbConfig1.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig1.Location = New System.Drawing.Point(9, 11)
        Me.RadLbConfig1.Name = "RadLbConfig1"
        '
        '
        '
        Me.RadLbConfig1.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.RadLbConfig1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLbConfig1.Size = New System.Drawing.Size(237, 23)
        Me.RadLbConfig1.TabIndex = 479
        Me.RadLbConfig1.Text = "Configuración 1:"
        Me.RadLbConfig1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
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
        'cbxConfig2
        '
        Me.cbxConfig2.BackColor = System.Drawing.Color.White
        Me.cbxConfig2.CausesValidation = False
        Me.cbxConfig2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG2", True))
        Me.cbxConfig2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxConfig2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxConfig2.FormattingEnabled = True
        Me.cbxConfig2.Location = New System.Drawing.Point(256, 42)
        Me.cbxConfig2.Name = "cbxConfig2"
        Me.cbxConfig2.Size = New System.Drawing.Size(322, 28)
        Me.cbxConfig2.TabIndex = 2
        '
        'tbxCustomField
        '
        Me.tbxCustomField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCustomField.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG2", True))
        Me.tbxCustomField.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxCustomField.Location = New System.Drawing.Point(256, 42)
        Me.tbxCustomField.Multiline = True
        Me.tbxCustomField.Name = "tbxCustomField"
        Me.tbxCustomField.Size = New System.Drawing.Size(322, 28)
        Me.tbxCustomField.TabIndex = 488
        Me.tbxCustomField.Visible = False
        '
        'lblAjuste
        '
        Me.lblAjuste.AutoSize = True
        Me.lblAjuste.Location = New System.Drawing.Point(317, 15)
        Me.lblAjuste.Name = "lblAjuste"
        Me.lblAjuste.Size = New System.Drawing.Size(63, 13)
        Me.lblAjuste.TabIndex = 500
        Me.lblAjuste.Text = "meses atras"
        Me.lblAjuste.Visible = False
        '
        'tbxMesesAjuste
        '
        Me.tbxMesesAjuste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMesesAjuste.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MODULOBindingSource, "CONFIG1", True))
        Me.tbxMesesAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxMesesAjuste.Location = New System.Drawing.Point(256, 8)
        Me.tbxMesesAjuste.Multiline = True
        Me.tbxMesesAjuste.Name = "tbxMesesAjuste"
        Me.tbxMesesAjuste.Size = New System.Drawing.Size(55, 28)
        Me.tbxMesesAjuste.TabIndex = 499
        Me.tbxMesesAjuste.Visible = False
        '
        'lblMensajeRestrinccion
        '
        Me.lblMensajeRestrinccion.AutoSize = False
        Me.lblMensajeRestrinccion.BackColor = System.Drawing.Color.Transparent
        Me.lblMensajeRestrinccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.lblMensajeRestrinccion.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMensajeRestrinccion.Location = New System.Drawing.Point(245, 45)
        Me.lblMensajeRestrinccion.Name = "lblMensajeRestrinccion"
        '
        '
        '
        Me.lblMensajeRestrinccion.RootElement.Alignment = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMensajeRestrinccion.RootElement.ForeColor = System.Drawing.Color.DarkRed
        Me.lblMensajeRestrinccion.Size = New System.Drawing.Size(591, 21)
        Me.lblMensajeRestrinccion.TabIndex = 492
        Me.lblMensajeRestrinccion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMensajeRestrinccion.Visible = False
        '
        'MODULOTableAdapter
        '
        Me.MODULOTableAdapter.ClearBeforeFill = True
        '
        'ABMConfigPosExpress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(841, 538)
        Me.Controls.Add(Me.lblMensajeRestrinccion)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgwModulo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ABMConfigPosExpress"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración del Sistema  | Cogent SIG"
        CType(Me.dgwModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MODULOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsConfigPEX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblModuloName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.RadLbConfig13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLbConfig1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensajeRestrinccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgwModulo As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents DsConfigPEX As ContaExpress.DsConfigPEX
    Friend WithEvents MODULOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MODULOTableAdapter As ContaExpress.DsConfigPEXTableAdapters.MODULOTableAdapter
    Friend WithEvents RadLbConfig4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig4 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig3 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig2 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig1 As System.Windows.Forms.ComboBox
    Friend WithEvents MODULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODULOID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadLbConfig5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig5 As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCustomField As System.Windows.Forms.TextBox
    Friend WithEvents RadLbConfig6 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig6 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig7 As System.Windows.Forms.ComboBox
    Friend WithEvents lblMensajeRestrinccion As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig9 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig9 As System.Windows.Forms.ComboBox
    Friend WithEvents cbxConfig8 As System.Windows.Forms.ComboBox
    Friend WithEvents lblModuloName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLbConfig10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig10 As System.Windows.Forms.ComboBox
    Friend WithEvents lblAjuste As System.Windows.Forms.Label
    Friend WithEvents tbxMesesAjuste As System.Windows.Forms.TextBox
    Friend WithEvents RadLbConfig11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig11 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig13 As System.Windows.Forms.ComboBox
    Friend WithEvents RadLbConfig12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxConfig12 As System.Windows.Forms.ComboBox
End Class
