<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMCategoriaProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMCategoriaProveedor))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtBuscaProveedor = New System.Windows.Forms.TextBox()
        Me.btnCancelar = New System.Windows.Forms.PictureBox()
        Me.BtnGuardar = New System.Windows.Forms.PictureBox()
        Me.btnNuevo = New System.Windows.Forms.PictureBox()
        Me.BtnEliminar = New System.Windows.Forms.PictureBox()
        Me.BtnModificar = New System.Windows.Forms.PictureBox()
        Me.dgvCategoriaProveedor = New System.Windows.Forms.DataGridView()
        Me.CODCATEGORIAPROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCATEGORIAPROVEEDOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORIAPROVEEDORBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCategoriaProveedor = New ContaExpress.DsCategoriaProveedor()
        Me.txtCategorizacion = New System.Windows.Forms.TextBox()
        Me.CATEGORIAPROVEEDORTableAdapter = New ContaExpress.DsCategoriaProveedorTableAdapters.CATEGORIAPROVEEDORTableAdapter()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnModificar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCategoriaProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CATEGORIAPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCategoriaProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.txtBuscaProveedor)
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Controls.Add(Me.BtnGuardar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Controls.Add(Me.BtnEliminar)
        Me.Panel2.Controls.Add(Me.BtnModificar)
        Me.Panel2.Location = New System.Drawing.Point(1, -1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 40)
        Me.Panel2.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(2, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox1.TabIndex = 457
        Me.PictureBox1.TabStop = False
        '
        'txtBuscaProveedor
        '
        Me.txtBuscaProveedor.BackColor = System.Drawing.Color.Tan
        Me.txtBuscaProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscaProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtBuscaProveedor.Location = New System.Drawing.Point(30, 6)
        Me.txtBuscaProveedor.Name = "txtBuscaProveedor"
        Me.txtBuscaProveedor.Size = New System.Drawing.Size(149, 27)
        Me.txtBuscaProveedor.TabIndex = 456
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.btnCancelar.Location = New System.Drawing.Point(338, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(35, 33)
        Me.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCancelar.TabIndex = 17
        Me.btnCancelar.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.BtnGuardar.Location = New System.Drawing.Point(300, 4)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(35, 33)
        Me.BtnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnGuardar.TabIndex = 16
        Me.BtnGuardar.TabStop = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevo.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.btnNuevo.Location = New System.Drawing.Point(186, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 33)
        Me.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnNuevo.TabIndex = 13
        Me.btnNuevo.TabStop = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.BtnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnEliminar.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.BtnEliminar.Location = New System.Drawing.Point(224, 4)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(35, 33)
        Me.BtnEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnEliminar.TabIndex = 15
        Me.BtnEliminar.TabStop = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.Transparent
        Me.BtnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnModificar.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.BtnModificar.Location = New System.Drawing.Point(262, 4)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(35, 33)
        Me.BtnModificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnModificar.TabIndex = 14
        Me.BtnModificar.TabStop = False
        '
        'dgvCategoriaProveedor
        '
        Me.dgvCategoriaProveedor.AllowUserToAddRows = False
        Me.dgvCategoriaProveedor.AllowUserToDeleteRows = False
        Me.dgvCategoriaProveedor.AutoGenerateColumns = False
        Me.dgvCategoriaProveedor.ColumnHeadersHeight = 30
        Me.dgvCategoriaProveedor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCATEGORIAPROVEEDOR, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn, Me.DESCATEGORIAPROVEEDOR, Me.FECGRADataGridViewTextBoxColumn})
        Me.dgvCategoriaProveedor.DataSource = Me.CATEGORIAPROVEEDORBindingSource
        Me.dgvCategoriaProveedor.Location = New System.Drawing.Point(-1, 38)
        Me.dgvCategoriaProveedor.Name = "dgvCategoriaProveedor"
        Me.dgvCategoriaProveedor.ReadOnly = True
        Me.dgvCategoriaProveedor.RowHeadersVisible = False
        Me.dgvCategoriaProveedor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCategoriaProveedor.Size = New System.Drawing.Size(178, 399)
        Me.dgvCategoriaProveedor.TabIndex = 0
        '
        'CODCATEGORIAPROVEEDOR
        '
        Me.CODCATEGORIAPROVEEDOR.DataPropertyName = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.HeaderText = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.Name = "CODCATEGORIAPROVEEDOR"
        Me.CODCATEGORIAPROVEEDOR.ReadOnly = True
        Me.CODCATEGORIAPROVEEDOR.Visible = False
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
        'NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn
        '
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn.DataPropertyName = "NUMCATEGORIAPROVEEDOR"
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn.HeaderText = "NUMCATEGORIAPROVEEDOR"
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn.Name = "NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn"
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn.Visible = False
        '
        'DESCATEGORIAPROVEEDOR
        '
        Me.DESCATEGORIAPROVEEDOR.DataPropertyName = "DESCATEGORIAPROVEEDOR"
        Me.DESCATEGORIAPROVEEDOR.HeaderText = "Categorias de Proveedores"
        Me.DESCATEGORIAPROVEEDOR.Name = "DESCATEGORIAPROVEEDOR"
        Me.DESCATEGORIAPROVEEDOR.ReadOnly = True
        Me.DESCATEGORIAPROVEEDOR.Width = 200
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'CATEGORIAPROVEEDORBindingSource
        '
        Me.CATEGORIAPROVEEDORBindingSource.DataMember = "CATEGORIAPROVEEDOR"
        Me.CATEGORIAPROVEEDORBindingSource.DataSource = Me.DsCategoriaProveedor
        '
        'DsCategoriaProveedor
        '
        Me.DsCategoriaProveedor.DataSetName = "DsCategoriaProveedor"
        Me.DsCategoriaProveedor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCategorizacion
        '
        Me.txtCategorizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCategorizacion.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCategorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCategorizacion.Location = New System.Drawing.Point(198, 194)
        Me.txtCategorizacion.Name = "txtCategorizacion"
        Me.txtCategorizacion.Size = New System.Drawing.Size(304, 27)
        Me.txtCategorizacion.TabIndex = 6
        '
        'CATEGORIAPROVEEDORTableAdapter
        '
        Me.CATEGORIAPROVEEDORTableAdapter.ClearBeforeFill = True
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.BackColor = System.Drawing.Color.Transparent
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblCategoria.Location = New System.Drawing.Point(194, 169)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(64, 22)
        Me.lblCategoria.TabIndex = 7
        Me.lblCategoria.Text = "Label1"
        '
        'ABMCategoriaProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(546, 434)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.dgvCategoriaProveedor)
        Me.Controls.Add(Me.txtCategorizacion)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(562, 472)
        Me.MinimumSize = New System.Drawing.Size(562, 472)
        Me.Name = "ABMCategoriaProveedor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categoria Proveedor | Cogent SIG"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnModificar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCategoriaProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CATEGORIAPROVEEDORBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCategoriaProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvCategoriaProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents txtCategorizacion As System.Windows.Forms.TextBox
    Friend WithEvents DsCategoriaProveedor As ContaExpress.DsCategoriaProveedor
    Friend WithEvents CATEGORIAPROVEEDORBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CATEGORIAPROVEEDORTableAdapter As ContaExpress.DsCategoriaProveedorTableAdapters.CATEGORIAPROVEEDORTableAdapter
    Friend WithEvents btnNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents BtnModificar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents CODCATEGORIAPROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMCATEGORIAPROVEEDORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCATEGORIAPROVEEDOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscaProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
End Class
