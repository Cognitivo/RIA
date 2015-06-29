<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMTipoComprobante
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMTipoComprobante))
        Me.PanelBotoneraRango = New System.Windows.Forms.Panel()
        Me.PictureBoxNuevoR = New System.Windows.Forms.PictureBox()
        Me.PictureBoxEliminarR = New System.Windows.Forms.PictureBox()
        Me.PictureBoxModificaR = New System.Windows.Forms.PictureBox()
        Me.PictureBoxGuardarR = New System.Windows.Forms.PictureBox()
        Me.PictureBoxCancelarR = New System.Windows.Forms.PictureBox()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.tbxCodigo = New System.Windows.Forms.TextBox()
        Me.tbxComprobante = New System.Windows.Forms.TextBox()
        Me.cbxCompras = New System.Windows.Forms.CheckBox()
        Me.cbxNotaDeCredito = New System.Windows.Forms.CheckBox()
        Me.cbxCobros = New System.Windows.Forms.CheckBox()
        Me.cbxVentas = New System.Windows.Forms.CheckBox()
        Me.cbxProduccion = New System.Windows.Forms.CheckBox()
        Me.cbxNotaDeDebito = New System.Windows.Forms.CheckBox()
        Me.cbxPagos = New System.Windows.Forms.CheckBox()
        Me.cbxRetencion = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxNotaDeRemision = New System.Windows.Forms.CheckBox()
        Me.cbxPagares = New System.Windows.Forms.CheckBox()
        Me.cbxNotaDeDebitoCompra = New System.Windows.Forms.CheckBox()
        Me.cbxOrdCompra = New System.Windows.Forms.CheckBox()
        Me.cbxPresupuesto = New System.Windows.Forms.CheckBox()
        Me.chbxAutoFactura = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbtnImpresoraMatricial = New System.Windows.Forms.RadioButton()
        Me.rbtnTicket = New System.Windows.Forms.RadioButton()
        Me.gbxImpresora = New System.Windows.Forms.GroupBox()
        Me.tbxCantImpresion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxCantLineas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxTicket = New System.Windows.Forms.GroupBox()
        Me.cbxSinValorLegal = New System.Windows.Forms.RadioButton()
        Me.cbxConValorLegal = New System.Windows.Forms.RadioButton()
        Me.dgvTipoComprobante = New System.Windows.Forms.DataGridView()
        Me.pnlDatosCliente = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxNoRegCobros = New System.Windows.Forms.CheckBox()
        Me.txtIdComprobante = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxProyectos = New System.Windows.Forms.CheckBox()
        Me.TIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettings = New ContaExpress.DsSettings()
        Me.TIPOCOMPROBANTETableAdapter = New ContaExpress.DsSettingsTableAdapters.TIPOCOMPROBANTETableAdapter()
        Me.CODCOMPROBANTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NDEBITOVENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NDEBITOCOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDCOMPRA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRESUPUESTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOREGCOBRO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMPRAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VENTAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COBROS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PAGOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INVENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTACREDITO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTADEBITO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RETENCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OTROS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRODUCCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FORMAIMPRESION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORFISCAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AUTOFACTURA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.RETENCIONRENTA = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PAGARE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NREMISION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PROYECTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PanelBotoneraRango.SuspendLayout()
        CType(Me.PictureBoxNuevoR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxEliminarR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxModificaR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxGuardarR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxCancelarR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gbxImpresora.SuspendLayout()
        Me.gbxTicket.SuspendLayout()
        CType(Me.dgvTipoComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosCliente.SuspendLayout()
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelBotoneraRango
        '
        Me.PanelBotoneraRango.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBotoneraRango.BackColor = System.Drawing.Color.Black
        Me.PanelBotoneraRango.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.PanelBotoneraRango.Controls.Add(Me.PictureBoxNuevoR)
        Me.PanelBotoneraRango.Controls.Add(Me.PictureBoxEliminarR)
        Me.PanelBotoneraRango.Controls.Add(Me.PictureBoxModificaR)
        Me.PanelBotoneraRango.Controls.Add(Me.PictureBoxGuardarR)
        Me.PanelBotoneraRango.Controls.Add(Me.PictureBoxCancelarR)
        Me.PanelBotoneraRango.Location = New System.Drawing.Point(-1, 0)
        Me.PanelBotoneraRango.Name = "PanelBotoneraRango"
        Me.PanelBotoneraRango.Size = New System.Drawing.Size(781, 40)
        Me.PanelBotoneraRango.TabIndex = 215
        '
        'PictureBoxNuevoR
        '
        Me.PictureBoxNuevoR.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxNuevoR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxNuevoR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxNuevoR.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.PictureBoxNuevoR.Location = New System.Drawing.Point(225, 2)
        Me.PictureBoxNuevoR.Name = "PictureBoxNuevoR"
        Me.PictureBoxNuevoR.Size = New System.Drawing.Size(39, 35)
        Me.PictureBoxNuevoR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxNuevoR.TabIndex = 461
        Me.PictureBoxNuevoR.TabStop = False
        '
        'PictureBoxEliminarR
        '
        Me.PictureBoxEliminarR.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxEliminarR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxEliminarR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxEliminarR.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.PictureBoxEliminarR.Location = New System.Drawing.Point(263, 2)
        Me.PictureBoxEliminarR.Name = "PictureBoxEliminarR"
        Me.PictureBoxEliminarR.Size = New System.Drawing.Size(39, 35)
        Me.PictureBoxEliminarR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxEliminarR.TabIndex = 462
        Me.PictureBoxEliminarR.TabStop = False
        '
        'PictureBoxModificaR
        '
        Me.PictureBoxModificaR.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxModificaR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxModificaR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBoxModificaR.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.PictureBoxModificaR.Location = New System.Drawing.Point(301, 2)
        Me.PictureBoxModificaR.Name = "PictureBoxModificaR"
        Me.PictureBoxModificaR.Size = New System.Drawing.Size(39, 35)
        Me.PictureBoxModificaR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxModificaR.TabIndex = 465
        Me.PictureBoxModificaR.TabStop = False
        '
        'PictureBoxGuardarR
        '
        Me.PictureBoxGuardarR.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxGuardarR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxGuardarR.Enabled = False
        Me.PictureBoxGuardarR.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.PictureBoxGuardarR.Location = New System.Drawing.Point(339, 2)
        Me.PictureBoxGuardarR.Name = "PictureBoxGuardarR"
        Me.PictureBoxGuardarR.Size = New System.Drawing.Size(39, 35)
        Me.PictureBoxGuardarR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxGuardarR.TabIndex = 463
        Me.PictureBoxGuardarR.TabStop = False
        '
        'PictureBoxCancelarR
        '
        Me.PictureBoxCancelarR.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxCancelarR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBoxCancelarR.Enabled = False
        Me.PictureBoxCancelarR.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.PictureBoxCancelarR.Location = New System.Drawing.Point(377, 2)
        Me.PictureBoxCancelarR.Name = "PictureBoxCancelarR"
        Me.PictureBoxCancelarR.Size = New System.Drawing.Size(39, 35)
        Me.PictureBoxCancelarR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBoxCancelarR.TabIndex = 464
        Me.PictureBoxCancelarR.TabStop = False
        '
        'lblComprobante
        '
        Me.lblComprobante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.BackColor = System.Drawing.Color.Transparent
        Me.lblComprobante.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblComprobante.Location = New System.Drawing.Point(276, 88)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(98, 16)
        Me.lblComprobante.TabIndex = 233
        Me.lblComprobante.Text = "Comprobante:"
        '
        'lblCodigo
        '
        Me.lblCodigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.BackColor = System.Drawing.Color.Transparent
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.lblCodigo.Location = New System.Drawing.Point(317, 58)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(57, 16)
        Me.lblCodigo.TabIndex = 232
        Me.lblCodigo.Text = "Código:"
        '
        'tbxCodigo
        '
        Me.tbxCodigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCodigo.BackColor = System.Drawing.Color.White
        Me.tbxCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodigo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCOMPROBANTEBindingSource, "NUMTIPOCOMPRO", True))
        Me.tbxCodigo.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.tbxCodigo.Location = New System.Drawing.Point(375, 53)
        Me.tbxCodigo.Name = "tbxCodigo"
        Me.tbxCodigo.Size = New System.Drawing.Size(360, 26)
        Me.tbxCodigo.TabIndex = 248
        '
        'tbxComprobante
        '
        Me.tbxComprobante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxComprobante.BackColor = System.Drawing.Color.White
        Me.tbxComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxComprobante.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCOMPROBANTEBindingSource, "DESCOMPROBANTE", True))
        Me.tbxComprobante.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.tbxComprobante.Location = New System.Drawing.Point(375, 83)
        Me.tbxComprobante.Name = "tbxComprobante"
        Me.tbxComprobante.Size = New System.Drawing.Size(360, 26)
        Me.tbxComprobante.TabIndex = 249
        '
        'cbxCompras
        '
        Me.cbxCompras.AutoSize = True
        Me.cbxCompras.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCompras.Location = New System.Drawing.Point(199, 27)
        Me.cbxCompras.Name = "cbxCompras"
        Me.cbxCompras.Size = New System.Drawing.Size(98, 23)
        Me.cbxCompras.TabIndex = 252
        Me.cbxCompras.Text = "Compras"
        Me.cbxCompras.UseVisualStyleBackColor = True
        '
        'cbxNotaDeCredito
        '
        Me.cbxNotaDeCredito.AutoSize = True
        Me.cbxNotaDeCredito.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxNotaDeCredito.Location = New System.Drawing.Point(7, 140)
        Me.cbxNotaDeCredito.Name = "cbxNotaDeCredito"
        Me.cbxNotaDeCredito.Size = New System.Drawing.Size(182, 22)
        Me.cbxNotaDeCredito.TabIndex = 253
        Me.cbxNotaDeCredito.Text = "Nota de Crédito Venta"
        Me.cbxNotaDeCredito.UseVisualStyleBackColor = True
        '
        'cbxCobros
        '
        Me.cbxCobros.AutoSize = True
        Me.cbxCobros.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxCobros.Location = New System.Drawing.Point(7, 56)
        Me.cbxCobros.Name = "cbxCobros"
        Me.cbxCobros.Size = New System.Drawing.Size(79, 22)
        Me.cbxCobros.TabIndex = 254
        Me.cbxCobros.Text = "Cobros"
        Me.cbxCobros.UseVisualStyleBackColor = True
        '
        'cbxVentas
        '
        Me.cbxVentas.AutoSize = True
        Me.cbxVentas.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVentas.Location = New System.Drawing.Point(7, 27)
        Me.cbxVentas.Name = "cbxVentas"
        Me.cbxVentas.Size = New System.Drawing.Size(80, 23)
        Me.cbxVentas.TabIndex = 255
        Me.cbxVentas.Text = "Ventas"
        Me.cbxVentas.UseVisualStyleBackColor = True
        '
        'cbxProduccion
        '
        Me.cbxProduccion.AutoSize = True
        Me.cbxProduccion.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxProduccion.Location = New System.Drawing.Point(402, 56)
        Me.cbxProduccion.Name = "cbxProduccion"
        Me.cbxProduccion.Size = New System.Drawing.Size(106, 22)
        Me.cbxProduccion.TabIndex = 256
        Me.cbxProduccion.Text = "Producción"
        Me.cbxProduccion.UseVisualStyleBackColor = True
        '
        'cbxNotaDeDebito
        '
        Me.cbxNotaDeDebito.AutoSize = True
        Me.cbxNotaDeDebito.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxNotaDeDebito.Location = New System.Drawing.Point(199, 112)
        Me.cbxNotaDeDebito.Name = "cbxNotaDeDebito"
        Me.cbxNotaDeDebito.Size = New System.Drawing.Size(199, 22)
        Me.cbxNotaDeDebito.TabIndex = 257
        Me.cbxNotaDeDebito.Text = "Nota de Crédito Compra"
        Me.cbxNotaDeDebito.UseVisualStyleBackColor = True
        '
        'cbxPagos
        '
        Me.cbxPagos.AutoSize = True
        Me.cbxPagos.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxPagos.Location = New System.Drawing.Point(199, 56)
        Me.cbxPagos.Name = "cbxPagos"
        Me.cbxPagos.Size = New System.Drawing.Size(73, 22)
        Me.cbxPagos.TabIndex = 258
        Me.cbxPagos.Text = "Pagos"
        Me.cbxPagos.UseVisualStyleBackColor = True
        '
        'cbxRetencion
        '
        Me.cbxRetencion.AutoSize = True
        Me.cbxRetencion.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxRetencion.Location = New System.Drawing.Point(402, 27)
        Me.cbxRetencion.Name = "cbxRetencion"
        Me.cbxRetencion.Size = New System.Drawing.Size(125, 22)
        Me.cbxRetencion.TabIndex = 259
        Me.cbxRetencion.Text = "Retención IVA"
        Me.cbxRetencion.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox1.Controls.Add(Me.cbxProyectos)
        Me.GroupBox1.Controls.Add(Me.cbxNotaDeRemision)
        Me.GroupBox1.Controls.Add(Me.cbxPagares)
        Me.GroupBox1.Controls.Add(Me.cbxNotaDeDebitoCompra)
        Me.GroupBox1.Controls.Add(Me.cbxOrdCompra)
        Me.GroupBox1.Controls.Add(Me.cbxPresupuesto)
        Me.GroupBox1.Controls.Add(Me.chbxAutoFactura)
        Me.GroupBox1.Controls.Add(Me.cbxCompras)
        Me.GroupBox1.Controls.Add(Me.cbxRetencion)
        Me.GroupBox1.Controls.Add(Me.cbxNotaDeCredito)
        Me.GroupBox1.Controls.Add(Me.cbxNotaDeDebito)
        Me.GroupBox1.Controls.Add(Me.cbxPagos)
        Me.GroupBox1.Controls.Add(Me.cbxCobros)
        Me.GroupBox1.Controls.Add(Me.cbxVentas)
        Me.GroupBox1.Controls.Add(Me.cbxProduccion)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(7, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(534, 172)
        Me.GroupBox1.TabIndex = 260
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aplicable en:"
        '
        'cbxNotaDeRemision
        '
        Me.cbxNotaDeRemision.AutoSize = True
        Me.cbxNotaDeRemision.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxNotaDeRemision.Location = New System.Drawing.Point(7, 112)
        Me.cbxNotaDeRemision.Name = "cbxNotaDeRemision"
        Me.cbxNotaDeRemision.Size = New System.Drawing.Size(152, 22)
        Me.cbxNotaDeRemision.TabIndex = 265
        Me.cbxNotaDeRemision.Text = "Nota de Remisión"
        Me.cbxNotaDeRemision.UseVisualStyleBackColor = True
        '
        'cbxPagares
        '
        Me.cbxPagares.AutoSize = True
        Me.cbxPagares.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxPagares.Location = New System.Drawing.Point(402, 112)
        Me.cbxPagares.Name = "cbxPagares"
        Me.cbxPagares.Size = New System.Drawing.Size(79, 22)
        Me.cbxPagares.TabIndex = 264
        Me.cbxPagares.Text = "Pagare"
        Me.cbxPagares.UseVisualStyleBackColor = True
        '
        'cbxNotaDeDebitoCompra
        '
        Me.cbxNotaDeDebitoCompra.AutoSize = True
        Me.cbxNotaDeDebitoCompra.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxNotaDeDebitoCompra.Location = New System.Drawing.Point(199, 140)
        Me.cbxNotaDeDebitoCompra.Name = "cbxNotaDeDebitoCompra"
        Me.cbxNotaDeDebitoCompra.Size = New System.Drawing.Size(194, 22)
        Me.cbxNotaDeDebitoCompra.TabIndex = 263
        Me.cbxNotaDeDebitoCompra.Text = "Nota de Debito Compra"
        Me.cbxNotaDeDebitoCompra.UseVisualStyleBackColor = True
        '
        'cbxOrdCompra
        '
        Me.cbxOrdCompra.AutoSize = True
        Me.cbxOrdCompra.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxOrdCompra.Location = New System.Drawing.Point(199, 84)
        Me.cbxOrdCompra.Name = "cbxOrdCompra"
        Me.cbxOrdCompra.Size = New System.Drawing.Size(114, 22)
        Me.cbxOrdCompra.TabIndex = 262
        Me.cbxOrdCompra.Text = "Ord Compra"
        Me.cbxOrdCompra.UseVisualStyleBackColor = True
        '
        'cbxPresupuesto
        '
        Me.cbxPresupuesto.AutoSize = True
        Me.cbxPresupuesto.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxPresupuesto.Location = New System.Drawing.Point(7, 84)
        Me.cbxPresupuesto.Name = "cbxPresupuesto"
        Me.cbxPresupuesto.Size = New System.Drawing.Size(115, 22)
        Me.cbxPresupuesto.TabIndex = 261
        Me.cbxPresupuesto.Text = "Presupuesto"
        Me.cbxPresupuesto.UseVisualStyleBackColor = True
        '
        'chbxAutoFactura
        '
        Me.chbxAutoFactura.AutoSize = True
        Me.chbxAutoFactura.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.chbxAutoFactura.Location = New System.Drawing.Point(402, 84)
        Me.chbxAutoFactura.Name = "chbxAutoFactura"
        Me.chbxAutoFactura.Size = New System.Drawing.Size(106, 22)
        Me.chbxAutoFactura.TabIndex = 260
        Me.chbxAutoFactura.Text = "Autofactura"
        Me.chbxAutoFactura.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.BackColor = System.Drawing.Color.LightGray
        Me.GroupBox2.Controls.Add(Me.rbtnImpresoraMatricial)
        Me.GroupBox2.Controls.Add(Me.rbtnTicket)
        Me.GroupBox2.Controls.Add(Me.gbxImpresora)
        Me.GroupBox2.Controls.Add(Me.gbxTicket)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(7, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(531, 188)
        Me.GroupBox2.TabIndex = 261
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Formato de Impression:"
        '
        'rbtnImpresoraMatricial
        '
        Me.rbtnImpresoraMatricial.AutoSize = True
        Me.rbtnImpresoraMatricial.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnImpresoraMatricial.Location = New System.Drawing.Point(20, 108)
        Me.rbtnImpresoraMatricial.Name = "rbtnImpresoraMatricial"
        Me.rbtnImpresoraMatricial.Size = New System.Drawing.Size(104, 23)
        Me.rbtnImpresoraMatricial.TabIndex = 1
        Me.rbtnImpresoraMatricial.TabStop = True
        Me.rbtnImpresoraMatricial.Text = "Impresora"
        Me.rbtnImpresoraMatricial.UseVisualStyleBackColor = True
        '
        'rbtnTicket
        '
        Me.rbtnTicket.AutoSize = True
        Me.rbtnTicket.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnTicket.Location = New System.Drawing.Point(14, 21)
        Me.rbtnTicket.Name = "rbtnTicket"
        Me.rbtnTicket.Size = New System.Drawing.Size(73, 23)
        Me.rbtnTicket.TabIndex = 0
        Me.rbtnTicket.TabStop = True
        Me.rbtnTicket.Text = "Ticket"
        Me.rbtnTicket.UseVisualStyleBackColor = True
        '
        'gbxImpresora
        '
        Me.gbxImpresora.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxImpresora.Controls.Add(Me.tbxCantImpresion)
        Me.gbxImpresora.Controls.Add(Me.Label2)
        Me.gbxImpresora.Controls.Add(Me.tbxCantLineas)
        Me.gbxImpresora.Controls.Add(Me.Label1)
        Me.gbxImpresora.Controls.Add(Me.Label3)
        Me.gbxImpresora.Enabled = False
        Me.gbxImpresora.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbxImpresora.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxImpresora.Location = New System.Drawing.Point(21, 125)
        Me.gbxImpresora.Name = "gbxImpresora"
        Me.gbxImpresora.Size = New System.Drawing.Size(494, 56)
        Me.gbxImpresora.TabIndex = 263
        Me.gbxImpresora.TabStop = False
        '
        'tbxCantImpresion
        '
        Me.tbxCantImpresion.AcceptsReturn = True
        Me.tbxCantImpresion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCantImpresion.BackColor = System.Drawing.Color.White
        Me.tbxCantImpresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantImpresion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCOMPROBANTEBindingSource, "CANTIDADIMPRESION", True))
        Me.tbxCantImpresion.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.tbxCantImpresion.Location = New System.Drawing.Point(348, 20)
        Me.tbxCantImpresion.Name = "tbxCantImpresion"
        Me.tbxCantImpresion.Size = New System.Drawing.Size(61, 26)
        Me.tbxCantImpresion.TabIndex = 253
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(218, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 16)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Cant. de Impresion:"
        '
        'tbxCantLineas
        '
        Me.tbxCantLineas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCantLineas.BackColor = System.Drawing.Color.White
        Me.tbxCantLineas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantLineas.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCOMPROBANTEBindingSource, "NROLINEASDETALLE", True))
        Me.tbxCantLineas.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.tbxCantLineas.Location = New System.Drawing.Point(129, 20)
        Me.tbxCantLineas.Name = "tbxCantLineas"
        Me.tbxCantLineas.Size = New System.Drawing.Size(65, 26)
        Me.tbxCantLineas.TabIndex = 253
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 252
        Me.Label1.Text = "Cant. de Lineas:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(411, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 232
        Me.Label3.Text = "Por Hojas"
        '
        'gbxTicket
        '
        Me.gbxTicket.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gbxTicket.Controls.Add(Me.cbxSinValorLegal)
        Me.gbxTicket.Controls.Add(Me.cbxConValorLegal)
        Me.gbxTicket.Enabled = False
        Me.gbxTicket.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbxTicket.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxTicket.Location = New System.Drawing.Point(18, 38)
        Me.gbxTicket.Name = "gbxTicket"
        Me.gbxTicket.Size = New System.Drawing.Size(494, 56)
        Me.gbxTicket.TabIndex = 262
        Me.gbxTicket.TabStop = False
        '
        'cbxSinValorLegal
        '
        Me.cbxSinValorLegal.AutoSize = True
        Me.cbxSinValorLegal.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cbxSinValorLegal.Location = New System.Drawing.Point(226, 21)
        Me.cbxSinValorLegal.Name = "cbxSinValorLegal"
        Me.cbxSinValorLegal.Size = New System.Drawing.Size(121, 20)
        Me.cbxSinValorLegal.TabIndex = 5
        Me.cbxSinValorLegal.TabStop = True
        Me.cbxSinValorLegal.Text = "Sin Valor Legal"
        Me.cbxSinValorLegal.UseVisualStyleBackColor = True
        '
        'cbxConValorLegal
        '
        Me.cbxConValorLegal.AutoSize = True
        Me.cbxConValorLegal.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.cbxConValorLegal.Location = New System.Drawing.Point(24, 21)
        Me.cbxConValorLegal.Name = "cbxConValorLegal"
        Me.cbxConValorLegal.Size = New System.Drawing.Size(127, 20)
        Me.cbxConValorLegal.TabIndex = 4
        Me.cbxConValorLegal.TabStop = True
        Me.cbxConValorLegal.Text = "Con Valor Legal"
        Me.cbxConValorLegal.UseVisualStyleBackColor = True
        '
        'dgvTipoComprobante
        '
        Me.dgvTipoComprobante.AllowUserToAddRows = False
        Me.dgvTipoComprobante.AllowUserToDeleteRows = False
        Me.dgvTipoComprobante.AllowUserToResizeColumns = False
        Me.dgvTipoComprobante.AllowUserToResizeRows = False
        Me.dgvTipoComprobante.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvTipoComprobante.AutoGenerateColumns = False
        Me.dgvTipoComprobante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTipoComprobante.BackgroundColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoComprobante.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTipoComprobante.ColumnHeadersHeight = 35
        Me.dgvTipoComprobante.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODCOMPROBANTE, Me.NDEBITOVENTA, Me.NDEBITOCOMPRA, Me.ORDCOMPRA, Me.PRESUPUESTO, Me.NOREGCOBRO, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NUMTIPOCOMPRODataGridViewTextBoxColumn, Me.DESCOMPROBANTEDataGridViewTextBoxColumn, Me.COMPRAS, Me.VENTAS, Me.COBROS, Me.PAGOS, Me.INVENTARIO, Me.NOTACREDITO, Me.NOTADEBITO, Me.RETENCION, Me.OTROS, Me.FECGRADataGridViewTextBoxColumn, Me.PRODUCCION, Me.FORMAIMPRESION, Me.NROLINEASDETALLEDataGridViewTextBoxColumn, Me.VALORFISCAL, Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn, Me.AUTOFACTURA, Me.RETENCIONRENTA, Me.PAGARE, Me.NREMISION, Me.PROYECTO})
        Me.dgvTipoComprobante.DataSource = Me.TIPOCOMPROBANTEBindingSource
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipoComprobante.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTipoComprobante.Location = New System.Drawing.Point(0, 39)
        Me.dgvTipoComprobante.Name = "dgvTipoComprobante"
        Me.dgvTipoComprobante.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTipoComprobante.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTipoComprobante.RowHeadersVisible = False
        Me.dgvTipoComprobante.Size = New System.Drawing.Size(220, 544)
        Me.dgvTipoComprobante.TabIndex = 263
        '
        'pnlDatosCliente
        '
        Me.pnlDatosCliente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlDatosCliente.BackColor = System.Drawing.Color.LightGray
        Me.pnlDatosCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDatosCliente.Controls.Add(Me.GroupBox2)
        Me.pnlDatosCliente.Controls.Add(Me.GroupBox1)
        Me.pnlDatosCliente.Location = New System.Drawing.Point(224, 147)
        Me.pnlDatosCliente.Name = "pnlDatosCliente"
        Me.pnlDatosCliente.Size = New System.Drawing.Size(549, 395)
        Me.pnlDatosCliente.TabIndex = 264
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(224, 543)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(378, 41)
        Me.Label4.TabIndex = 403
        Me.Label4.Text = "Si Usted desea que este Tipo de Comprobante no se registre en el Historial de Fac" & _
    "turas a Cobrar marque esta opcion"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cbxNoRegCobros
        '
        Me.cbxNoRegCobros.AutoSize = True
        Me.cbxNoRegCobros.BackColor = System.Drawing.Color.Transparent
        Me.cbxNoRegCobros.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxNoRegCobros.Location = New System.Drawing.Point(610, 552)
        Me.cbxNoRegCobros.Name = "cbxNoRegCobros"
        Me.cbxNoRegCobros.Size = New System.Drawing.Size(163, 22)
        Me.cbxNoRegCobros.TabIndex = 404
        Me.cbxNoRegCobros.Text = "No Registrar Cobro"
        Me.cbxNoRegCobros.UseVisualStyleBackColor = False
        '
        'txtIdComprobante
        '
        Me.txtIdComprobante.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIdComprobante.BackColor = System.Drawing.Color.White
        Me.txtIdComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdComprobante.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.TIPOCOMPROBANTEBindingSource, "IDCOMPROBANTE", True))
        Me.txtIdComprobante.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtIdComprobante.Location = New System.Drawing.Point(376, 113)
        Me.txtIdComprobante.Name = "txtIdComprobante"
        Me.txtIdComprobante.Size = New System.Drawing.Size(61, 26)
        Me.txtIdComprobante.TabIndex = 406
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(259, 118)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 16)
        Me.Label5.TabIndex = 405
        Me.Label5.Text = "ID Comprobante:"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label6.Location = New System.Drawing.Point(436, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(338, 34)
        Me.Label6.TabIndex = 407
        Me.Label6.Text = "Este campo se utiliza para generar el Hechauka y corresponde al Codigo de Tipo de" & _
    "l Documento a ser generado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbxProyectos
        '
        Me.cbxProyectos.AutoSize = True
        Me.cbxProyectos.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cbxProyectos.Location = New System.Drawing.Point(402, 140)
        Me.cbxProyectos.Name = "cbxProyectos"
        Me.cbxProyectos.Size = New System.Drawing.Size(97, 22)
        Me.cbxProyectos.TabIndex = 266
        Me.cbxProyectos.Text = "Proyectos"
        Me.cbxProyectos.UseVisualStyleBackColor = True
        '
        'TIPOCOMPROBANTEBindingSource
        '
        Me.TIPOCOMPROBANTEBindingSource.DataMember = "TIPOCOMPROBANTE"
        Me.TIPOCOMPROBANTEBindingSource.DataSource = Me.DsSettings
        '
        'DsSettings
        '
        Me.DsSettings.DataSetName = "DsSettings"
        Me.DsSettings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TIPOCOMPROBANTETableAdapter
        '
        Me.TIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'CODCOMPROBANTE
        '
        Me.CODCOMPROBANTE.DataPropertyName = "CODCOMPROBANTE"
        Me.CODCOMPROBANTE.HeaderText = "CODCOMPROBANTE"
        Me.CODCOMPROBANTE.Name = "CODCOMPROBANTE"
        Me.CODCOMPROBANTE.ReadOnly = True
        Me.CODCOMPROBANTE.Visible = False
        '
        'NDEBITOVENTA
        '
        Me.NDEBITOVENTA.DataPropertyName = "NDEBITOVENTA"
        Me.NDEBITOVENTA.HeaderText = "NDEBITOVENTA"
        Me.NDEBITOVENTA.Name = "NDEBITOVENTA"
        Me.NDEBITOVENTA.ReadOnly = True
        Me.NDEBITOVENTA.Visible = False
        '
        'NDEBITOCOMPRA
        '
        Me.NDEBITOCOMPRA.DataPropertyName = "NDEBITOCOMPRA"
        Me.NDEBITOCOMPRA.HeaderText = "NDEBITOCOMPRA"
        Me.NDEBITOCOMPRA.Name = "NDEBITOCOMPRA"
        Me.NDEBITOCOMPRA.ReadOnly = True
        Me.NDEBITOCOMPRA.Visible = False
        '
        'ORDCOMPRA
        '
        Me.ORDCOMPRA.DataPropertyName = "ORDCOMPRA"
        Me.ORDCOMPRA.HeaderText = "ORDCOMPRA"
        Me.ORDCOMPRA.Name = "ORDCOMPRA"
        Me.ORDCOMPRA.ReadOnly = True
        Me.ORDCOMPRA.Visible = False
        '
        'PRESUPUESTO
        '
        Me.PRESUPUESTO.DataPropertyName = "PRESUPUESTO"
        Me.PRESUPUESTO.HeaderText = "PRESUPUESTO"
        Me.PRESUPUESTO.Name = "PRESUPUESTO"
        Me.PRESUPUESTO.ReadOnly = True
        Me.PRESUPUESTO.Visible = False
        '
        'NOREGCOBRO
        '
        Me.NOREGCOBRO.DataPropertyName = "NOREGCOBRO"
        Me.NOREGCOBRO.HeaderText = "NOREGCOBRO"
        Me.NOREGCOBRO.Name = "NOREGCOBRO"
        Me.NOREGCOBRO.ReadOnly = True
        Me.NOREGCOBRO.Visible = False
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
        'NUMTIPOCOMPRODataGridViewTextBoxColumn
        '
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn.DataPropertyName = "NUMTIPOCOMPRO"
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn.HeaderText = "NUMTIPOCOMPRO"
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn.Name = "NUMTIPOCOMPRODataGridViewTextBoxColumn"
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn.ReadOnly = True
        Me.NUMTIPOCOMPRODataGridViewTextBoxColumn.Visible = False
        '
        'DESCOMPROBANTEDataGridViewTextBoxColumn
        '
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.DataPropertyName = "DESCOMPROBANTE"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.HeaderText = "Comprobante"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.Name = "DESCOMPROBANTEDataGridViewTextBoxColumn"
        Me.DESCOMPROBANTEDataGridViewTextBoxColumn.ReadOnly = True
        '
        'COMPRAS
        '
        Me.COMPRAS.DataPropertyName = "COMPRAS"
        Me.COMPRAS.HeaderText = "COMPRAS"
        Me.COMPRAS.Name = "COMPRAS"
        Me.COMPRAS.ReadOnly = True
        Me.COMPRAS.Visible = False
        '
        'VENTAS
        '
        Me.VENTAS.DataPropertyName = "VENTAS"
        Me.VENTAS.HeaderText = "VENTAS"
        Me.VENTAS.Name = "VENTAS"
        Me.VENTAS.ReadOnly = True
        Me.VENTAS.Visible = False
        '
        'COBROS
        '
        Me.COBROS.DataPropertyName = "COBROS"
        Me.COBROS.HeaderText = "COBROS"
        Me.COBROS.Name = "COBROS"
        Me.COBROS.ReadOnly = True
        Me.COBROS.Visible = False
        '
        'PAGOS
        '
        Me.PAGOS.DataPropertyName = "PAGOS"
        Me.PAGOS.HeaderText = "PAGOS"
        Me.PAGOS.Name = "PAGOS"
        Me.PAGOS.ReadOnly = True
        Me.PAGOS.Visible = False
        '
        'INVENTARIO
        '
        Me.INVENTARIO.DataPropertyName = "INVENTARIO"
        Me.INVENTARIO.HeaderText = "INVENTARIO"
        Me.INVENTARIO.Name = "INVENTARIO"
        Me.INVENTARIO.ReadOnly = True
        Me.INVENTARIO.Visible = False
        '
        'NOTACREDITO
        '
        Me.NOTACREDITO.DataPropertyName = "NCREDITO"
        Me.NOTACREDITO.HeaderText = "NCREDITO"
        Me.NOTACREDITO.Name = "NOTACREDITO"
        Me.NOTACREDITO.ReadOnly = True
        Me.NOTACREDITO.Visible = False
        '
        'NOTADEBITO
        '
        Me.NOTADEBITO.DataPropertyName = "NDEBITO"
        Me.NOTADEBITO.HeaderText = "NDEBITO"
        Me.NOTADEBITO.Name = "NOTADEBITO"
        Me.NOTADEBITO.ReadOnly = True
        Me.NOTADEBITO.Visible = False
        '
        'RETENCION
        '
        Me.RETENCION.DataPropertyName = "RETENCION"
        Me.RETENCION.HeaderText = "RETENCION"
        Me.RETENCION.Name = "RETENCION"
        Me.RETENCION.ReadOnly = True
        Me.RETENCION.Visible = False
        '
        'OTROS
        '
        Me.OTROS.DataPropertyName = "OTROS"
        Me.OTROS.HeaderText = "OTROS"
        Me.OTROS.Name = "OTROS"
        Me.OTROS.ReadOnly = True
        Me.OTROS.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'PRODUCCION
        '
        Me.PRODUCCION.DataPropertyName = "PRODUCCION"
        Me.PRODUCCION.HeaderText = "PRODUCCION"
        Me.PRODUCCION.Name = "PRODUCCION"
        Me.PRODUCCION.ReadOnly = True
        Me.PRODUCCION.Visible = False
        '
        'FORMAIMPRESION
        '
        Me.FORMAIMPRESION.DataPropertyName = "FORMAIMPRESION"
        Me.FORMAIMPRESION.HeaderText = "FORMAIMPRESION"
        Me.FORMAIMPRESION.Name = "FORMAIMPRESION"
        Me.FORMAIMPRESION.ReadOnly = True
        Me.FORMAIMPRESION.Visible = False
        '
        'NROLINEASDETALLEDataGridViewTextBoxColumn
        '
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn.DataPropertyName = "NROLINEASDETALLE"
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn.HeaderText = "NROLINEASDETALLE"
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn.Name = "NROLINEASDETALLEDataGridViewTextBoxColumn"
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn.ReadOnly = True
        Me.NROLINEASDETALLEDataGridViewTextBoxColumn.Visible = False
        '
        'VALORFISCAL
        '
        Me.VALORFISCAL.DataPropertyName = "VALORFISCAL"
        Me.VALORFISCAL.HeaderText = "VALORFISCAL"
        Me.VALORFISCAL.Name = "VALORFISCAL"
        Me.VALORFISCAL.ReadOnly = True
        Me.VALORFISCAL.Visible = False
        '
        'CANTIDADIMPRESIONDataGridViewTextBoxColumn
        '
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn.DataPropertyName = "CANTIDADIMPRESION"
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn.HeaderText = "CANTIDADIMPRESION"
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn.Name = "CANTIDADIMPRESIONDataGridViewTextBoxColumn"
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.CANTIDADIMPRESIONDataGridViewTextBoxColumn.Visible = False
        '
        'AUTOFACTURA
        '
        Me.AUTOFACTURA.DataPropertyName = "AUTOFACTURA"
        Me.AUTOFACTURA.HeaderText = "AUTOFACTURA"
        Me.AUTOFACTURA.Name = "AUTOFACTURA"
        Me.AUTOFACTURA.ReadOnly = True
        Me.AUTOFACTURA.Visible = False
        '
        'RETENCIONRENTA
        '
        Me.RETENCIONRENTA.DataPropertyName = "RETENCIONRENTA"
        Me.RETENCIONRENTA.HeaderText = "RETENCIONRENTA"
        Me.RETENCIONRENTA.Name = "RETENCIONRENTA"
        Me.RETENCIONRENTA.ReadOnly = True
        Me.RETENCIONRENTA.Visible = False
        '
        'PAGARE
        '
        Me.PAGARE.DataPropertyName = "PAGARE"
        Me.PAGARE.HeaderText = "PAGARE"
        Me.PAGARE.Name = "PAGARE"
        Me.PAGARE.ReadOnly = True
        Me.PAGARE.Visible = False
        '
        'NREMISION
        '
        Me.NREMISION.DataPropertyName = "NREMISION"
        Me.NREMISION.HeaderText = "NREMISION"
        Me.NREMISION.Name = "NREMISION"
        Me.NREMISION.ReadOnly = True
        Me.NREMISION.Visible = False
        '
        'PROYECTO
        '
        Me.PROYECTO.DataPropertyName = "PROYECTO"
        Me.PROYECTO.HeaderText = "PROYECTO"
        Me.PROYECTO.Name = "PROYECTO"
        Me.PROYECTO.ReadOnly = True
        Me.PROYECTO.Visible = False
        '
        'ABMTipoComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(779, 585)
        Me.Controls.Add(Me.txtIdComprobante)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbxNoRegCobros)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCodigo)
        Me.Controls.Add(Me.dgvTipoComprobante)
        Me.Controls.Add(Me.tbxComprobante)
        Me.Controls.Add(Me.PanelBotoneraRango)
        Me.Controls.Add(Me.tbxCodigo)
        Me.Controls.Add(Me.lblComprobante)
        Me.Controls.Add(Me.pnlDatosCliente)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ABMTipoComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo Comprobante  | Cogent SIG"
        Me.PanelBotoneraRango.ResumeLayout(False)
        CType(Me.PictureBoxNuevoR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxEliminarR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxModificaR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxGuardarR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxCancelarR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbxImpresora.ResumeLayout(False)
        Me.gbxImpresora.PerformLayout()
        Me.gbxTicket.ResumeLayout(False)
        Me.gbxTicket.PerformLayout()
        CType(Me.dgvTipoComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosCliente.ResumeLayout(False)
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelBotoneraRango As System.Windows.Forms.Panel
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents tbxCodigo As System.Windows.Forms.TextBox
    Friend WithEvents tbxComprobante As System.Windows.Forms.TextBox
    Friend WithEvents cbxCompras As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNotaDeCredito As System.Windows.Forms.CheckBox
    Friend WithEvents cbxCobros As System.Windows.Forms.CheckBox
    Friend WithEvents cbxVentas As System.Windows.Forms.CheckBox
    Friend WithEvents cbxProduccion As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNotaDeDebito As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPagos As System.Windows.Forms.CheckBox
    Friend WithEvents cbxRetencion As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnTicket As System.Windows.Forms.RadioButton
    Friend WithEvents dgvTipoComprobante As System.Windows.Forms.DataGridView
    Friend WithEvents rbtnImpresoraMatricial As System.Windows.Forms.RadioButton
    Friend WithEvents gbxImpresora As System.Windows.Forms.GroupBox
    Friend WithEvents tbxCantLineas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbxTicket As System.Windows.Forms.GroupBox
    Friend WithEvents cbxSinValorLegal As System.Windows.Forms.RadioButton
    Friend WithEvents cbxConValorLegal As System.Windows.Forms.RadioButton
    Friend WithEvents tbxCantImpresion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxNuevoR As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxEliminarR As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxModificaR As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxGuardarR As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxCancelarR As System.Windows.Forms.PictureBox
    Friend WithEvents pnlDatosCliente As System.Windows.Forms.Panel
    Friend WithEvents TIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsSettings As ContaExpress.DsSettings
    Friend WithEvents TIPOCOMPROBANTETableAdapter As ContaExpress.DsSettingsTableAdapters.TIPOCOMPROBANTETableAdapter
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxNoRegCobros As System.Windows.Forms.CheckBox
    Friend WithEvents chbxAutoFactura As System.Windows.Forms.CheckBox
    Friend WithEvents txtIdComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxPresupuesto As System.Windows.Forms.CheckBox
    Friend WithEvents cbxOrdCompra As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNotaDeDebitoCompra As System.Windows.Forms.CheckBox
    Friend WithEvents cbxPagares As System.Windows.Forms.CheckBox
    Friend WithEvents cbxNotaDeRemision As System.Windows.Forms.CheckBox
    Friend WithEvents cbxProyectos As System.Windows.Forms.CheckBox
    Friend WithEvents CODCOMPROBANTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NDEBITOVENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NDEBITOCOMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORDCOMPRA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRESUPUESTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOREGCOBRO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMTIPOCOMPRODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCOMPROBANTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPRAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VENTAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COBROS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAGOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INVENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOTACREDITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOTADEBITO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RETENCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OTROS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRODUCCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FORMAIMPRESION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROLINEASDETALLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORFISCAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADIMPRESIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AUTOFACTURA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents RETENCIONRENTA As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents PAGARE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NREMISION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PROYECTO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
