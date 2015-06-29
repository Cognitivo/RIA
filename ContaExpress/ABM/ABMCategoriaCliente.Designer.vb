<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMCategoriaCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMCategoriaCliente))
        Me.dgvCategoriaCliente = New System.Windows.Forms.DataGridView()
        Me.CODCATEGORIACLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCATEGORIACLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CATEGORIACLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCategoriaCliente = New ContaExpress.DsCategoriaCliente()
        Me.CATEGORIACLIENTETableAdapter = New ContaExpress.DsCategoriaClienteTableAdapters.CATEGORIACLIENTETableAdapter()
        Me.txtCategorizacion = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.txtbuscacliente = New System.Windows.Forms.TextBox()
        Me.btnNuevo = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.PictureBox()
        Me.BtnModificar = New System.Windows.Forms.PictureBox()
        Me.BtnGuardar = New System.Windows.Forms.PictureBox()
        Me.BtnEliminar = New System.Windows.Forms.PictureBox()
        Me.lblCategoria = New System.Windows.Forms.Label()
        CType(Me.dgvCategoriaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CATEGORIACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCategoriaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnModificar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCategoriaCliente
        '
        Me.dgvCategoriaCliente.AllowUserToAddRows = False
        Me.dgvCategoriaCliente.AllowUserToDeleteRows = False
        Me.dgvCategoriaCliente.AllowUserToResizeRows = False
        Me.dgvCategoriaCliente.AutoGenerateColumns = False
        Me.dgvCategoriaCliente.ColumnHeadersHeight = 30
        Me.dgvCategoriaCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCATEGORIACLIENTE, Me.DESCATEGORIACLIENTE, Me.FECGRADataGridViewTextBoxColumn})
        Me.dgvCategoriaCliente.DataSource = Me.CATEGORIACLIENTEBindingSource
        Me.dgvCategoriaCliente.Location = New System.Drawing.Point(-1, 38)
        Me.dgvCategoriaCliente.Name = "dgvCategoriaCliente"
        Me.dgvCategoriaCliente.ReadOnly = True
        Me.dgvCategoriaCliente.RowHeadersVisible = False
        Me.dgvCategoriaCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCategoriaCliente.Size = New System.Drawing.Size(163, 399)
        Me.dgvCategoriaCliente.TabIndex = 0
        '
        'CODCATEGORIACLIENTE
        '
        Me.CODCATEGORIACLIENTE.DataPropertyName = "CODCATEGORIACLIENTE"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CODCATEGORIACLIENTE.DefaultCellStyle = DataGridViewCellStyle1
        Me.CODCATEGORIACLIENTE.HeaderText = "Categorias de Clientes"
        Me.CODCATEGORIACLIENTE.Name = "CODCATEGORIACLIENTE"
        Me.CODCATEGORIACLIENTE.ReadOnly = True
        Me.CODCATEGORIACLIENTE.Visible = False
        '
        'DESCATEGORIACLIENTE
        '
        Me.DESCATEGORIACLIENTE.DataPropertyName = "DESCATEGORIACLIENTE"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.DESCATEGORIACLIENTE.DefaultCellStyle = DataGridViewCellStyle2
        Me.DESCATEGORIACLIENTE.HeaderText = "Categorias de Clientes"
        Me.DESCATEGORIACLIENTE.Name = "DESCATEGORIACLIENTE"
        Me.DESCATEGORIACLIENTE.ReadOnly = True
        Me.DESCATEGORIACLIENTE.Width = 200
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'CATEGORIACLIENTEBindingSource
        '
        Me.CATEGORIACLIENTEBindingSource.DataMember = "CATEGORIACLIENTE"
        Me.CATEGORIACLIENTEBindingSource.DataSource = Me.DsCategoriaCliente
        '
        'DsCategoriaCliente
        '
        Me.DsCategoriaCliente.DataSetName = "DsCategoriaCliente"
        Me.DsCategoriaCliente.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CATEGORIACLIENTETableAdapter
        '
        Me.CATEGORIACLIENTETableAdapter.ClearBeforeFill = True
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
        Me.txtCategorizacion.Size = New System.Drawing.Size(310, 27)
        Me.txtCategorizacion.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel2.Controls.Add(Me.PictureBox8)
        Me.Panel2.Controls.Add(Me.txtbuscacliente)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Controls.Add(Me.btnCancelar)
        Me.Panel2.Controls.Add(Me.BtnModificar)
        Me.Panel2.Controls.Add(Me.BtnGuardar)
        Me.Panel2.Controls.Add(Me.BtnEliminar)
        Me.Panel2.Location = New System.Drawing.Point(-1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(550, 39)
        Me.Panel2.TabIndex = 4
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 27)
        Me.PictureBox8.TabIndex = 455
        Me.PictureBox8.TabStop = False
        '
        'txtbuscacliente
        '
        Me.txtbuscacliente.BackColor = System.Drawing.Color.Tan
        Me.txtbuscacliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtbuscacliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtbuscacliente.Location = New System.Drawing.Point(32, 5)
        Me.txtbuscacliente.Name = "txtbuscacliente"
        Me.txtbuscacliente.Size = New System.Drawing.Size(133, 27)
        Me.txtbuscacliente.TabIndex = 6
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevo.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.btnNuevo.Location = New System.Drawing.Point(173, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 33)
        Me.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnNuevo.TabIndex = 22
        Me.btnNuevo.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Transparent
        Me.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCancelar.Enabled = False
        Me.btnCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.btnCancelar.Location = New System.Drawing.Point(325, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(35, 33)
        Me.btnCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCancelar.TabIndex = 21
        Me.btnCancelar.TabStop = False
        '
        'BtnModificar
        '
        Me.BtnModificar.BackColor = System.Drawing.Color.Transparent
        Me.BtnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnModificar.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.BtnModificar.Location = New System.Drawing.Point(249, 3)
        Me.BtnModificar.Name = "BtnModificar"
        Me.BtnModificar.Size = New System.Drawing.Size(35, 33)
        Me.BtnModificar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnModificar.TabIndex = 18
        Me.BtnModificar.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.BackColor = System.Drawing.Color.Transparent
        Me.BtnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnGuardar.Enabled = False
        Me.BtnGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.BtnGuardar.Location = New System.Drawing.Point(287, 3)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(35, 33)
        Me.BtnGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnGuardar.TabIndex = 20
        Me.BtnGuardar.TabStop = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.Transparent
        Me.BtnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnEliminar.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.BtnEliminar.Location = New System.Drawing.Point(211, 3)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(35, 33)
        Me.BtnEliminar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BtnEliminar.TabIndex = 19
        Me.BtnEliminar.TabStop = False
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.BackColor = System.Drawing.Color.Transparent
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.lblCategoria.Location = New System.Drawing.Point(194, 169)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(64, 22)
        Me.lblCategoria.TabIndex = 8
        Me.lblCategoria.Text = "Label1"
        '
        'ABMCategoriaCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(546, 434)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.dgvCategoriaCliente)
        Me.Controls.Add(Me.txtCategorizacion)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(562, 472)
        Me.MinimumSize = New System.Drawing.Size(562, 472)
        Me.Name = "ABMCategoriaCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Categoria Cliente | Cogent SIG"
        CType(Me.dgvCategoriaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CATEGORIACLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCategoriaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnModificar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCategoriaCliente As System.Windows.Forms.DataGridView
    Friend WithEvents DsCategoriaCliente As ContaExpress.DsCategoriaCliente
    Friend WithEvents CATEGORIACLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CATEGORIACLIENTETableAdapter As ContaExpress.DsCategoriaClienteTableAdapters.CATEGORIACLIENTETableAdapter
    Friend WithEvents txtCategorizacion As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtbuscacliente As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnModificar As System.Windows.Forms.PictureBox
    Friend WithEvents btnNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents CODCATEGORIACLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCATEGORIACLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
End Class
