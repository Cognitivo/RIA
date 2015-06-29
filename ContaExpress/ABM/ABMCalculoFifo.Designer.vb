<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMCalculoFifo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMCalculoFifo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelNroCobrador = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCalcularFifo = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.TxtCodigoProd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlProducto = New System.Windows.Forms.Panel()
        Me.BuscarProductoTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.dgwProductos = New System.Windows.Forms.DataGridView()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.UltimaCompraDiasTableAdapter1 = New ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter()
        Me.ScriptCostoLifoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ScriptCostoLifoTableAdapter = New ContaExpress.DsProduccionTableAdapters.ScriptCostoLifoTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsProduccionTableAdapters.TableAdapterManager()
        Me.IMPRFIFOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.IMPRFIFOTableAdapter = New ContaExpress.DsProduccionTableAdapters.IMPRFIFOTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProduccionTableAdapters.PRODUCTOSTableAdapter()
        Me.STOCKACTUALFIFOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.STOCKACTUALFIFOTableAdapter = New ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter()
        Me.AjustesHistoricoStockTableAdapter = New ContaExpress.DsProduccionTableAdapters.AjustesHistoricoStockTableAdapter()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlProducto.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScriptCostoLifoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IMPRFIFOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKACTUALFIFOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.LabelNroCobrador)
        Me.Panel1.Location = New System.Drawing.Point(-2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 41)
        Me.Panel1.TabIndex = 355
        '
        'LabelNroCobrador
        '
        Me.LabelNroCobrador.AutoSize = True
        Me.LabelNroCobrador.Location = New System.Drawing.Point(591, 13)
        Me.LabelNroCobrador.Name = "LabelNroCobrador"
        Me.LabelNroCobrador.Size = New System.Drawing.Size(93, 13)
        Me.LabelNroCobrador.TabIndex = 401
        Me.LabelNroCobrador.Text = "LabelNroCobrador"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 67)
        Me.Label1.TabIndex = 402
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'btnCalcularFifo
        '
        Me.btnCalcularFifo.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCalcularFifo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcularFifo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnCalcularFifo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCalcularFifo.Location = New System.Drawing.Point(67, 137)
        Me.btnCalcularFifo.Name = "btnCalcularFifo"
        Me.btnCalcularFifo.Size = New System.Drawing.Size(315, 86)
        Me.btnCalcularFifo.TabIndex = 403
        Me.btnCalcularFifo.Text = "Calcular Costos"
        Me.btnCalcularFifo.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnImprimir)
        Me.GroupBox1.Controls.Add(Me.txtProducto)
        Me.GroupBox1.Controls.Add(Me.TxtCodigoProd)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 238)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 136)
        Me.GroupBox1.TabIndex = 404
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imprimir"
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnImprimir.Location = New System.Drawing.Point(325, 99)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(101, 31)
        Me.btnImprimir.TabIndex = 406
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'txtProducto
        '
        Me.txtProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtProducto.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtProducto.CausesValidation = False
        Me.txtProducto.Enabled = False
        Me.txtProducto.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtProducto.Location = New System.Drawing.Point(127, 64)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.Size = New System.Drawing.Size(303, 26)
        Me.txtProducto.TabIndex = 405
        '
        'TxtCodigoProd
        '
        Me.TxtCodigoProd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCodigoProd.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TxtCodigoProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCodigoProd.CausesValidation = False
        Me.TxtCodigoProd.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.TxtCodigoProd.Location = New System.Drawing.Point(5, 64)
        Me.TxtCodigoProd.Name = "TxtCodigoProd"
        Me.TxtCodigoProd.Size = New System.Drawing.Size(123, 26)
        Me.TxtCodigoProd.TabIndex = 404
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(2, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(427, 26)
        Me.Label2.TabIndex = 403
        Me.Label2.Text = "Seleccione un Producto para Visualizar los Moviemientos del Producto para el Calc" & _
    "ulo del Costo FIFO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlProducto
        '
        Me.pnlProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlProducto.Controls.Add(Me.BuscarProductoTextBox)
        Me.pnlProducto.Controls.Add(Me.PictureBox2)
        Me.pnlProducto.Controls.Add(Me.dgwProductos)
        Me.pnlProducto.Location = New System.Drawing.Point(456, 35)
        Me.pnlProducto.Name = "pnlProducto"
        Me.pnlProducto.Size = New System.Drawing.Size(434, 348)
        Me.pnlProducto.TabIndex = 405
        Me.pnlProducto.Visible = False
        '
        'BuscarProductoTextBox
        '
        Me.BuscarProductoTextBox.BackColor = System.Drawing.Color.DimGray
        Me.BuscarProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarProductoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarProductoTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarProductoTextBox.Location = New System.Drawing.Point(34, 4)
        Me.BuscarProductoTextBox.Name = "BuscarProductoTextBox"
        Me.BuscarProductoTextBox.Size = New System.Drawing.Size(393, 30)
        Me.BuscarProductoTextBox.TabIndex = 456
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DimGray
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Search
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.TabIndex = 457
        Me.PictureBox2.TabStop = False
        '
        'dgwProductos
        '
        Me.dgwProductos.AllowUserToAddRows = False
        Me.dgwProductos.AllowUserToDeleteRows = False
        Me.dgwProductos.AllowUserToResizeColumns = False
        Me.dgwProductos.AllowUserToResizeRows = False
        Me.dgwProductos.AutoGenerateColumns = False
        Me.dgwProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.CODCODIGODataGridViewTextBoxColumn})
        Me.dgwProductos.DataSource = Me.PRODUCTOSBindingSource
        Me.dgwProductos.Location = New System.Drawing.Point(5, 37)
        Me.dgwProductos.Name = "dgwProductos"
        Me.dgwProductos.ReadOnly = True
        Me.dgwProductos.RowHeadersVisible = False
        Me.dgwProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwProductos.ShowCellErrors = False
        Me.dgwProductos.ShowCellToolTips = False
        Me.dgwProductos.Size = New System.Drawing.Size(424, 304)
        Me.dgwProductos.TabIndex = 0
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 70.0!
        Me.CODIGODataGridViewTextBoxColumn.HeaderText = "Codigo"
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.FillWeight = 180.0!
        Me.DESPRODUCTODataGridViewTextBoxColumn.HeaderText = "Descripcion"
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODCODIGODataGridViewTextBoxColumn
        '
        Me.CODCODIGODataGridViewTextBoxColumn.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn.Name = "CODCODIGODataGridViewTextBoxColumn"
        Me.CODCODIGODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODCODIGODataGridViewTextBoxColumn.Visible = False
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProduccion
        '
        'DsProduccion
        '
        Me.DsProduccion.DataSetName = "DsProduccion"
        Me.DsProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.pnlProducto
        '
        'UltimaCompraDiasTableAdapter1
        '
        Me.UltimaCompraDiasTableAdapter1.ClearBeforeFill = True
        '
        'ScriptCostoLifoBindingSource
        '
        Me.ScriptCostoLifoBindingSource.DataMember = "ScriptCostoLifo"
        Me.ScriptCostoLifoBindingSource.DataSource = Me.DsProduccion
        '
        'ScriptCostoLifoTableAdapter
        '
        Me.ScriptCostoLifoTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProduccionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'IMPRFIFOBindingSource
        '
        Me.IMPRFIFOBindingSource.DataMember = "IMPRFIFO"
        Me.IMPRFIFOBindingSource.DataSource = Me.DsProduccion
        '
        'IMPRFIFOTableAdapter
        '
        Me.IMPRFIFOTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'STOCKACTUALFIFOBindingSource
        '
        Me.STOCKACTUALFIFOBindingSource.DataMember = "STOCKACTUALFIFO"
        Me.STOCKACTUALFIFOBindingSource.DataSource = Me.DsProduccion
        '
        'STOCKACTUALFIFOTableAdapter
        '
        Me.STOCKACTUALFIFOTableAdapter.ClearBeforeFill = True
        '
        'AjustesHistoricoStockTableAdapter
        '
        Me.AjustesHistoricoStockTableAdapter.ClearBeforeFill = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox1.Location = New System.Drawing.Point(6, 51)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 406
        Me.PictureBox1.TabStop = False
        '
        'ABMCalculoFifo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(449, 387)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCalcularFifo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlProducto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ABMCalculoFifo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Costo Fifo | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlProducto.ResumeLayout(False)
        Me.pnlProducto.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScriptCostoLifoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IMPRFIFOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKACTUALFIFOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelNroCobrador As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCalcularFifo As System.Windows.Forms.Button
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents ScriptCostoLifoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ScriptCostoLifoTableAdapter As ContaExpress.DsProduccionTableAdapters.ScriptCostoLifoTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsProduccionTableAdapters.TableAdapterManager
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodigoProd As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents IMPRFIFOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents IMPRFIFOTableAdapter As ContaExpress.DsProduccionTableAdapters.IMPRFIFOTableAdapter
    Friend WithEvents pnlProducto As System.Windows.Forms.Panel
    Friend WithEvents dgwProductos As System.Windows.Forms.DataGridView
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProduccionTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BuscarProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents UltimaCompraDiasTableAdapter1 As ContaExpress.DSReporteComprasTableAdapters.UltimaCompraDiasTableAdapter
    Friend WithEvents STOCKACTUALFIFOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents STOCKACTUALFIFOTableAdapter As ContaExpress.DsProduccionTableAdapters.STOCKACTUALFIFOTableAdapter
    Friend WithEvents AjustesHistoricoStockTableAdapter As ContaExpress.DsProduccionTableAdapters.AjustesHistoricoStockTableAdapter
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
