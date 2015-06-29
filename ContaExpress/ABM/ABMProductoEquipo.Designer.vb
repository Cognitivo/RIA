<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMProductoEquipo
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
        Me.PRODUCTOEQUIPOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tbxDesEquipo = New Telerik.WinControls.UI.RadTextBox()
        Me.DESEMPRESALabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.PRODUCTOEQUIPOTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOEQUIPOTableAdapter()
        Me.dgvEquipo = New System.Windows.Forms.DataGridView()
        Me.IDEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESEQUIPO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PRODUCTOEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tbxDesEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEquipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PRODUCTOEQUIPOBindingSource
        '
        Me.PRODUCTOEQUIPOBindingSource.DataMember = "PRODUCTOEQUIPO"
        Me.PRODUCTOEQUIPOBindingSource.DataSource = Me.DsProductos
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.tbxDesEquipo)
        Me.Panel2.Controls.Add(Me.DESEMPRESALabel)
        Me.Panel2.Location = New System.Drawing.Point(242, 133)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(424, 54)
        Me.Panel2.TabIndex = 410
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
        'DESEMPRESALabel
        '
        Me.DESEMPRESALabel.AutoSize = True
        Me.DESEMPRESALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DESEMPRESALabel.Location = New System.Drawing.Point(42, 19)
        Me.DESEMPRESALabel.Name = "DESEMPRESALabel"
        Me.DESEMPRESALabel.Size = New System.Drawing.Size(75, 15)
        Me.DESEMPRESALabel.TabIndex = 366
        Me.DESEMPRESALabel.Text = "Descripción:"
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
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Location = New System.Drawing.Point(-1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 40)
        Me.Panel1.TabIndex = 409
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
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Tan
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.CausesValidation = False
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.txtBuscar.Location = New System.Drawing.Point(35, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(179, 31)
        Me.txtBuscar.TabIndex = 391
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
        'PRODUCTOEQUIPOTableAdapter
        '
        Me.PRODUCTOEQUIPOTableAdapter.ClearBeforeFill = True
        '
        'dgvEquipo
        '
        Me.dgvEquipo.AllowUserToAddRows = False
        Me.dgvEquipo.AllowUserToDeleteRows = False
        Me.dgvEquipo.AllowUserToOrderColumns = True
        Me.dgvEquipo.AllowUserToResizeRows = False
        Me.dgvEquipo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvEquipo.AutoGenerateColumns = False
        Me.dgvEquipo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEquipo.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEquipo.ColumnHeadersHeight = 35
        Me.dgvEquipo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDEQUIPO, Me.DESEQUIPO})
        Me.dgvEquipo.DataSource = Me.PRODUCTOEQUIPOBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEquipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEquipo.GridColor = System.Drawing.Color.Lavender
        Me.dgvEquipo.Location = New System.Drawing.Point(4, 47)
        Me.dgvEquipo.Name = "dgvEquipo"
        Me.dgvEquipo.ReadOnly = True
        Me.dgvEquipo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEquipo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvEquipo.RowHeadersVisible = False
        Me.dgvEquipo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvEquipo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEquipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEquipo.Size = New System.Drawing.Size(209, 301)
        Me.dgvEquipo.TabIndex = 423
        '
        'IDEQUIPO
        '
        Me.IDEQUIPO.DataPropertyName = "IDEQUIPO"
        Me.IDEQUIPO.HeaderText = "IDEQUIPO"
        Me.IDEQUIPO.Name = "IDEQUIPO"
        Me.IDEQUIPO.ReadOnly = True
        Me.IDEQUIPO.Visible = False
        '
        'DESEQUIPO
        '
        Me.DESEQUIPO.DataPropertyName = "DESEQUIPO"
        Me.DESEQUIPO.HeaderText = "Equipo"
        Me.DESEQUIPO.Name = "DESEQUIPO"
        Me.DESEQUIPO.ReadOnly = True
        '
        'ABMProductoEquipo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(706, 350)
        Me.Controls.Add(Me.dgvEquipo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ABMProductoEquipo"
        Me.Text = "ABMProductoEquipo"
        CType(Me.PRODUCTOEQUIPOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.tbxDesEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEquipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tbxDesEquipo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents PRODUCTOEQUIPOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOEQUIPOTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOEQUIPOTableAdapter
    Friend WithEvents dgvEquipo As System.Windows.Forms.DataGridView
    Friend WithEvents IDEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESEQUIPO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
