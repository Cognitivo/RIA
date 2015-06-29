<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Eventos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Eventos))
        Me.PanelBotonera = New System.Windows.Forms.Panel()
        Me.BuscarEventosTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EventosDataGridView = New System.Windows.Forms.DataGridView()
        Me.NUMEVENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCEVENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEVENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ESTADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EVENTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEventos = New ContaExpress.DsEventos()
        Me.EVENTOTableAdapter = New ContaExpress.DsEventosTableAdapters.EVENTOTableAdapter()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.EstadoComboBox = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.DescripcionTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadThemeManager1 = New Telerik.WinControls.RadThemeManager()
        Me.CodEventoTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PanelBotonera.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventosDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EVENTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EstadoComboBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DescripcionTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodEventoTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotonera
        '
        Me.PanelBotonera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotonera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.PanelBotonera.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.PanelBotonera.Controls.Add(Me.BuscarEventosTextBox)
        Me.PanelBotonera.Controls.Add(Me.PictureBox1)
        Me.PanelBotonera.Controls.Add(Me.EliminarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.NuevoPictureBox)
        Me.PanelBotonera.Controls.Add(Me.ModificarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.GuardarPictureBox)
        Me.PanelBotonera.Controls.Add(Me.CancelarPictureBox)
        Me.PanelBotonera.Location = New System.Drawing.Point(-1, 0)
        Me.PanelBotonera.Name = "PanelBotonera"
        Me.PanelBotonera.Size = New System.Drawing.Size(588, 40)
        Me.PanelBotonera.TabIndex = 232
        '
        'BuscarEventosTextBox
        '
        Me.BuscarEventosTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarEventosTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarEventosTextBox.CausesValidation = False
        Me.BuscarEventosTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarEventosTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarEventosTextBox.Location = New System.Drawing.Point(35, 5)
        Me.BuscarEventosTextBox.Name = "BuscarEventosTextBox"
        Me.BuscarEventosTextBox.Size = New System.Drawing.Size(196, 31)
        Me.BuscarEventosTextBox.TabIndex = 397
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(5, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 398
        Me.PictureBox1.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(278, 3)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(241, 3)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(314, 3)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(351, 3)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(387, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'EventosDataGridView
        '
        Me.EventosDataGridView.AllowUserToAddRows = False
        Me.EventosDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EventosDataGridView.AutoGenerateColumns = False
        Me.EventosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.EventosDataGridView.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EventosDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.EventosDataGridView.ColumnHeadersHeight = 35
        Me.EventosDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMEVENTODataGridViewTextBoxColumn, Me.DESCEVENTODataGridViewTextBoxColumn, Me.CODEVENTODataGridViewTextBoxColumn, Me.CODCLIENTEDataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.ESTADODataGridViewTextBoxColumn})
        Me.EventosDataGridView.DataSource = Me.EVENTOBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.EventosDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.EventosDataGridView.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.EventosDataGridView.Location = New System.Drawing.Point(0, 38)
        Me.EventosDataGridView.Name = "EventosDataGridView"
        Me.EventosDataGridView.ReadOnly = True
        Me.EventosDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EventosDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.EventosDataGridView.RowHeadersVisible = False
        Me.EventosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.EventosDataGridView.Size = New System.Drawing.Size(231, 424)
        Me.EventosDataGridView.TabIndex = 4
        '
        'NUMEVENTODataGridViewTextBoxColumn
        '
        Me.NUMEVENTODataGridViewTextBoxColumn.DataPropertyName = "NUMEVENTO"
        Me.NUMEVENTODataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.NUMEVENTODataGridViewTextBoxColumn.HeaderText = "Nro"
        Me.NUMEVENTODataGridViewTextBoxColumn.Name = "NUMEVENTODataGridViewTextBoxColumn"
        Me.NUMEVENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESCEVENTODataGridViewTextBoxColumn
        '
        Me.DESCEVENTODataGridViewTextBoxColumn.DataPropertyName = "DESCEVENTO"
        Me.DESCEVENTODataGridViewTextBoxColumn.HeaderText = "Evento / Sector"
        Me.DESCEVENTODataGridViewTextBoxColumn.Name = "DESCEVENTODataGridViewTextBoxColumn"
        Me.DESCEVENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODEVENTODataGridViewTextBoxColumn
        '
        Me.CODEVENTODataGridViewTextBoxColumn.DataPropertyName = "CODEVENTO"
        Me.CODEVENTODataGridViewTextBoxColumn.HeaderText = "CODEVENTO"
        Me.CODEVENTODataGridViewTextBoxColumn.Name = "CODEVENTODataGridViewTextBoxColumn"
        Me.CODEVENTODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODEVENTODataGridViewTextBoxColumn.Visible = False
        '
        'CODCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODCLIENTE"
        Me.CODCLIENTEDataGridViewTextBoxColumn.Name = "CODCLIENTEDataGridViewTextBoxColumn"
        Me.CODCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCLIENTEDataGridViewTextBoxColumn.Visible = False
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
        'ESTADODataGridViewTextBoxColumn
        '
        Me.ESTADODataGridViewTextBoxColumn.DataPropertyName = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.HeaderText = "ESTADO"
        Me.ESTADODataGridViewTextBoxColumn.Name = "ESTADODataGridViewTextBoxColumn"
        Me.ESTADODataGridViewTextBoxColumn.ReadOnly = True
        Me.ESTADODataGridViewTextBoxColumn.Visible = False
        '
        'EVENTOBindingSource
        '
        Me.EVENTOBindingSource.DataMember = "EVENTO"
        Me.EVENTOBindingSource.DataSource = Me.DsEventos
        '
        'DsEventos
        '
        Me.DsEventos.DataSetName = "DsEventos"
        Me.DsEventos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'EVENTOTableAdapter
        '
        Me.EVENTOTableAdapter.ClearBeforeFill = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(269, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 394
        Me.Label4.Text = "Estado:"
        '
        'EstadoComboBox
        '
        Me.EstadoComboBox.BackColor = System.Drawing.Color.White
        Me.EstadoComboBox.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.EstadoComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.EstadoComboBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.EstadoComboBox.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2})
        Me.EstadoComboBox.Location = New System.Drawing.Point(325, 239)
        Me.EstadoComboBox.Name = "EstadoComboBox"
        '
        '
        '
        Me.EstadoComboBox.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.EstadoComboBox.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.EstadoComboBox.Size = New System.Drawing.Size(228, 26)
        Me.EstadoComboBox.TabIndex = 2
        Me.EstadoComboBox.TabStop = False
        Me.EstadoComboBox.ThemeName = "Breeze"
        CType(Me.EstadoComboBox.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        CType(Me.EstadoComboBox.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        CType(Me.EstadoComboBox.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EVENTOBindingSource, "ESTADO", True))
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Activo"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.EVENTOBindingSource, "ESTADO", True))
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "No Activo"
        '
        'DescripcionTextBox
        '
        Me.DescripcionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EVENTOBindingSource, "DESCEVENTO", True))
        Me.DescripcionTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DescripcionTextBox.ForeColor = System.Drawing.Color.Black
        Me.DescripcionTextBox.Location = New System.Drawing.Point(325, 200)
        Me.DescripcionTextBox.Name = "DescripcionTextBox"
        '
        '
        '
        Me.DescripcionTextBox.RootElement.ForeColor = System.Drawing.Color.Black
        Me.DescripcionTextBox.Size = New System.Drawing.Size(228, 26)
        Me.DescripcionTextBox.TabIndex = 1
        Me.DescripcionTextBox.TabStop = False
        Me.DescripcionTextBox.ThemeName = "Breeze"
        CType(Me.DescripcionTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(246, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 393
        Me.Label2.Text = "Descripción:"
        '
        'CodEventoTextBox
        '
        Me.CodEventoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EVENTOBindingSource, "CODEVENTO", True))
        Me.CodEventoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CodEventoTextBox.ForeColor = System.Drawing.Color.Black
        Me.CodEventoTextBox.Location = New System.Drawing.Point(325, 161)
        Me.CodEventoTextBox.Name = "CodEventoTextBox"
        Me.CodEventoTextBox.ReadOnly = True
        '
        '
        '
        Me.CodEventoTextBox.RootElement.ForeColor = System.Drawing.Color.Black
        Me.CodEventoTextBox.Size = New System.Drawing.Size(127, 26)
        Me.CodEventoTextBox.TabIndex = 0
        Me.CodEventoTextBox.TabStop = False
        Me.CodEventoTextBox.ThemeName = "Breeze"
        CType(Me.CodEventoTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.CornflowerBlue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 396
        Me.Label1.Text = "Nro Evento:"
        '
        'Eventos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(584, 461)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CodEventoTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.EstadoComboBox)
        Me.Controls.Add(Me.DescripcionTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelBotonera)
        Me.Controls.Add(Me.EventosDataGridView)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(600, 500)
        Me.MinimumSize = New System.Drawing.Size(600, 500)
        Me.Name = "Eventos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sector / Evento | Cogent SIG"
        Me.PanelBotonera.ResumeLayout(False)
        Me.PanelBotonera.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventosDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EVENTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEventos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EstadoComboBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DescripcionTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodEventoTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotonera As System.Windows.Forms.Panel
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EventosDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DsEventos As ContaExpress.DsEventos
    Friend WithEvents EVENTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EVENTOTableAdapter As ContaExpress.DsEventosTableAdapters.EVENTOTableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents EstadoComboBox As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents DescripcionTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BuscarEventosTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents NUMEVENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCEVENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEVENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadThemeManager1 As Telerik.WinControls.RadThemeManager
    Friend WithEvents CodEventoTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
