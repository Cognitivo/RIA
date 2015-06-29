<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class ABMTipoCliente
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend  WithEvents DsSettingFO As ContaExpress.DsSettingFO
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents PRIORIDADCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TableAdapterManager As ContaExpress.DsSettingFOTableAdapters.TableAdapterManager
    Friend WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsSettingFOTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents txtCodTipoCliente As Telerik.WinControls.UI.RadTextBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    #End Region 'Fields

    #Region "Methods"

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMTipoCliente))
        Me.PRIORIDADCheckBox = New System.Windows.Forms.CheckBox()
        Me.txtCodTipoCliente = New Telerik.WinControls.UI.RadTextBox()
        Me.TIPOCLIENTEBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettingFO1 = New ContaExpress.DsSettingFO()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.tbxListaPrecio = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtProcVenta = New System.Windows.Forms.TextBox()
        Me.chbxCantMult = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TIPOCLIENTETableAdapter1 = New ContaExpress.DsSettingFOTableAdapters.TIPOCLIENTETableAdapter()
        Me.grdBuscador = New System.Windows.Forms.DataGridView()
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIORIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PORCENTAJEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.txtCodTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFO1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PRIORIDADCheckBox
        '
        Me.PRIORIDADCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PRIORIDADCheckBox.Location = New System.Drawing.Point(225, 139)
        Me.PRIORIDADCheckBox.Name = "PRIORIDADCheckBox"
        Me.PRIORIDADCheckBox.Size = New System.Drawing.Size(126, 24)
        Me.PRIORIDADCheckBox.TabIndex = 399
        Me.PRIORIDADCheckBox.Text = "Prioridad"
        Me.PRIORIDADCheckBox.UseVisualStyleBackColor = True
        '
        'txtCodTipoCliente
        '
        Me.txtCodTipoCliente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCLIENTEBindingSource1, "CODTIPOCLIENTE", True))
        Me.txtCodTipoCliente.Enabled = False
        Me.txtCodTipoCliente.Location = New System.Drawing.Point(-113, -1)
        Me.txtCodTipoCliente.Name = "txtCodTipoCliente"
        Me.txtCodTipoCliente.Size = New System.Drawing.Size(106, 20)
        Me.txtCodTipoCliente.TabIndex = 404
        Me.txtCodTipoCliente.TabStop = False
        '
        'TIPOCLIENTEBindingSource1
        '
        Me.TIPOCLIENTEBindingSource1.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource1.DataSource = Me.DsSettingFO1
        '
        'DsSettingFO1
        '
        Me.DsSettingFO1.DataSetName = "DsSettingFO"
        Me.DsSettingFO1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbxNuevaFicha)
        Me.Panel1.Controls.Add(Me.pbxModificarFicha)
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 42)
        Me.Panel1.TabIndex = 406
        '
        'pbxNuevaFicha
        '
        Me.pbxNuevaFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevaFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevaFicha.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevaFicha.InitialImage = Nothing
        Me.pbxNuevaFicha.Location = New System.Drawing.Point(173, 2)
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
        Me.pbxModificarFicha.Location = New System.Drawing.Point(243, 2)
        Me.pbxModificarFicha.Name = "pbxModificarFicha"
        Me.pbxModificarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxModificarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxModificarFicha.TabIndex = 5
        Me.pbxModificarFicha.TabStop = False
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(313, 2)
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
        Me.pbxGuardar.Location = New System.Drawing.Point(278, 2)
        Me.pbxGuardar.Name = "pbxGuardar"
        Me.pbxGuardar.Size = New System.Drawing.Size(35, 35)
        Me.pbxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGuardar.TabIndex = 6
        Me.pbxGuardar.TabStop = False
        '
        'pbxEliminarFicha
        '
        Me.pbxEliminarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxEliminarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEliminarFicha.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.pbxEliminarFicha.InitialImage = Nothing
        Me.pbxEliminarFicha.Location = New System.Drawing.Point(208, 2)
        Me.pbxEliminarFicha.Name = "pbxEliminarFicha"
        Me.pbxEliminarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxEliminarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEliminarFicha.TabIndex = 4
        Me.pbxEliminarFicha.TabStop = False
        '
        'tbxListaPrecio
        '
        Me.tbxListaPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxListaPrecio.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCLIENTEBindingSource1, "DESTIPOCLIENTE", True))
        Me.tbxListaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxListaPrecio.Location = New System.Drawing.Point(122, 40)
        Me.tbxListaPrecio.Name = "tbxListaPrecio"
        Me.tbxListaPrecio.Size = New System.Drawing.Size(244, 26)
        Me.tbxListaPrecio.TabIndex = 407
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtProcVenta)
        Me.Panel2.Controls.Add(Me.chbxCantMult)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.tbxListaPrecio)
        Me.Panel2.Controls.Add(Me.PRIORIDADCheckBox)
        Me.Panel2.Controls.Add(Me.txtCodTipoCliente)
        Me.Panel2.Location = New System.Drawing.Point(176, 88)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(391, 264)
        Me.Panel2.TabIndex = 408
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(213, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 50)
        Me.Label6.TabIndex = 428
        Me.Label6.Text = "Porcentaje que se agrega sobre el Precio de Costo que se ingresa en Productos"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(7, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 17)
        Me.Label5.TabIndex = 427
        Me.Label5.Text = "% Precio Venta:"
        '
        'txtProcVenta
        '
        Me.txtProcVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProcVenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCLIENTEBindingSource1, "PORCENTAJE", True))
        Me.txtProcVenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtProcVenta.Location = New System.Drawing.Point(122, 84)
        Me.txtProcVenta.Name = "txtProcVenta"
        Me.txtProcVenta.Size = New System.Drawing.Size(87, 26)
        Me.txtProcVenta.TabIndex = 426
        '
        'chbxCantMult
        '
        Me.chbxCantMult.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbxCantMult.Location = New System.Drawing.Point(225, 203)
        Me.chbxCantMult.Name = "chbxCantMult"
        Me.chbxCantMult.Size = New System.Drawing.Size(157, 24)
        Me.chbxCantMult.TabIndex = 424
        Me.chbxCantMult.Text = "Multiplicar Cantidad"
        Me.chbxCantMult.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(6, 184)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(215, 63)
        Me.Label12.TabIndex = 425
        Me.Label12.Text = "Marque esta opción si con esta Lista de Precio debe multiplicar la cantidad ingre" & _
    "sada desde Ventas por la cantidad asignada Por Producto en la Lista de Precio"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(215, 52)
        Me.Label4.TabIndex = 410
        Me.Label4.Text = "Prioridad solo para los Precios que sirven para cualquier cliente. Elija esta opc" & _
    "ion para la Lista con el Precio mas Alto. Ej Minorista"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(1, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(341, 13)
        Me.Label3.TabIndex = 409
        Me.Label3.Text = "Listas de Precios ayudan ofrecer diferentes Precios a distintos Clientes."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(10, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 17)
        Me.Label1.TabIndex = 408
        Me.Label1.Text = "Lista de Precio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label2.Location = New System.Drawing.Point(174, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 32)
        Me.Label2.TabIndex = 408
        Me.Label2.Text = "Lista de Precio:"
        '
        'TIPOCLIENTETableAdapter1
        '
        Me.TIPOCLIENTETableAdapter1.ClearBeforeFill = True
        '
        'grdBuscador
        '
        Me.grdBuscador.AllowUserToAddRows = False
        Me.grdBuscador.AllowUserToDeleteRows = False
        Me.grdBuscador.AutoGenerateColumns = False
        Me.grdBuscador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdBuscador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBuscador.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DESTIPOCLIENTEDataGridViewTextBoxColumn, Me.CODTIPOCLIENTEDataGridViewTextBoxColumn, Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn, Me.PRIORIDADDataGridViewTextBoxColumn, Me.PORCENTAJEDataGridViewTextBoxColumn})
        Me.grdBuscador.DataSource = Me.TIPOCLIENTEBindingSource1
        Me.grdBuscador.Location = New System.Drawing.Point(3, 45)
        Me.grdBuscador.Name = "grdBuscador"
        Me.grdBuscador.ReadOnly = True
        Me.grdBuscador.RowHeadersVisible = False
        Me.grdBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdBuscador.Size = New System.Drawing.Size(169, 307)
        Me.grdBuscador.TabIndex = 409
        '
        'DESTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "Lista de Precio"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.Name = "DESTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.DESTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Name = "CODTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'NUMTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "NUMTIPOCLIENTE"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "NUMTIPOCLIENTE"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.Name = "NUMTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'PRIORIDADDataGridViewTextBoxColumn
        '
        Me.PRIORIDADDataGridViewTextBoxColumn.DataPropertyName = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.HeaderText = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.Name = "PRIORIDADDataGridViewTextBoxColumn"
        Me.PRIORIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.PRIORIDADDataGridViewTextBoxColumn.Visible = False
        '
        'PORCENTAJEDataGridViewTextBoxColumn
        '
        Me.PORCENTAJEDataGridViewTextBoxColumn.DataPropertyName = "PORCENTAJE"
        Me.PORCENTAJEDataGridViewTextBoxColumn.HeaderText = "PORCENTAJE"
        Me.PORCENTAJEDataGridViewTextBoxColumn.Name = "PORCENTAJEDataGridViewTextBoxColumn"
        Me.PORCENTAJEDataGridViewTextBoxColumn.ReadOnly = True
        Me.PORCENTAJEDataGridViewTextBoxColumn.Visible = False
        '
        'ABMTipoCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(573, 356)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grdBuscador)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(583, 388)
        Me.Name = "ABMTipoCliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lista de Precio  | Cogent SIG"
        CType(Me.txtCodTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFO1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbxListaPrecio As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chbxCantMult As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtProcVenta As System.Windows.Forms.TextBox
    Friend WithEvents DsSettingFO1 As ContaExpress.DsSettingFO
    Friend WithEvents TIPOCLIENTEBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCLIENTETableAdapter1 As ContaExpress.DsSettingFOTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents grdBuscador As System.Windows.Forms.DataGridView
    Friend WithEvents DESTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIORIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PORCENTAJEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

    #End Region 'Methods

End Class