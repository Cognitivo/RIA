<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LibroVenta
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LibroVenta))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.btnCalculadora = New System.Windows.Forms.PictureBox()
        Me.btnAsentar = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.dgvParaAsentar = New System.Windows.Forms.DataGridView()
        Me.ModuloID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegistroID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIMBRADODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COTIZACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPERIODOFISCAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DETALLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARAASENTARCABCOMPRASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPlantillasConta = New ContaExpress.DsPlantillasConta()
        Me.tbxRUC = New System.Windows.Forms.TextBox()
        Me.tbxTimbrado = New System.Windows.Forms.TextBox()
        Me.tbxComprobante = New System.Windows.Forms.TextBox()
        Me.dgbParaAsentarDetalle = New System.Windows.Forms.DataGridView()
        Me.FECHAASIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULOID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AsientoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REGISTROID1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPLANCUENTA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTED1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTEH1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPLANCUENTADetalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoGrilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PARAASENTARDETBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblRUC = New System.Windows.Forms.Label()
        Me.lblTimbrado = New System.Windows.Forms.Label()
        Me.lblComprobante = New System.Windows.Forms.Label()
        Me.tbxCotizacion = New System.Windows.Forms.TextBox()
        Me.lblTipoTrans = New System.Windows.Forms.Label()
        Me.lblMoneda = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbxGrabIva10 = New System.Windows.Forms.TextBox()
        Me.tbxGrabIva5 = New System.Windows.Forms.TextBox()
        Me.tbxExcentas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbxIva10 = New System.Windows.Forms.TextBox()
        Me.tbxIva5 = New System.Windows.Forms.TextBox()
        Me.tbxTotalIva = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblVerModulo = New System.Windows.Forms.Label()
        Me.tbxEmpresa = New System.Windows.Forms.TextBox()
        Me.tbxMoneda = New System.Windows.Forms.TextBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.tbxCuenta = New System.Windows.Forms.TextBox()
        Me.tbxNroCuenta = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbxDebeHaber = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.tbxDebe = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbxHaber = New System.Windows.Forms.TextBox()
        Me.tbxTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.TIPOCOMPROBANTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TIPOCOMPROBANTETableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.TIPOCOMPROBANTETableAdapter()
        Me.PARAASENTARDETTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.PARAASENTARDETTableAdapter()
        Me.gbxCuenta = New Telerik.WinControls.UI.RadGroupBox()
        Me.dgbPlanCuentas = New System.Windows.Forms.DataGridView()
        Me.CODPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlancuentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxBuscarCuenta = New System.Windows.Forms.TextBox()
        Me.PlancuentasTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.tbxCodCuenta = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxTipoPago = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tbxTotalFactura = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbxDetalleAsiento = New System.Windows.Forms.TextBox()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.tbxTotalHaber = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxTotalDebe = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtFechaCuenta = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btModificar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PARAASENTARCAB_COMPRASTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.PARAASENTARCAB_COMPRASTableAdapter()
        Me.tbxFecha = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.CmbMes = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem1 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem2 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem3 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem4 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem5 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem6 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem7 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem8 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem9 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem10 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem11 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem12 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.CmbAño = New Telerik.WinControls.UI.RadComboBox()
        Me.RadComboBoxItem13 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem14 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem15 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem16 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem17 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem18 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem19 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem20 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem21 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem22 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.RadComboBoxItem23 = New Telerik.WinControls.UI.RadComboBoxItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCalculadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnAsentar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvParaAsentar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PARAASENTARCABCOMPRASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgbParaAsentarDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PARAASENTARDETBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCuenta.SuspendLayout()
        CType(Me.dgbPlanCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.Panel1.Controls.Add(Me.btnCalculadora)
        Me.Panel1.Controls.Add(Me.btnAsentar)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 41)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(6, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.TabIndex = 462
        Me.PictureBox1.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(34, 4)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(229, 30)
        Me.BuscarTextBox.TabIndex = 461
        Me.BuscarTextBox.Text = "Buscar..."
        '
        'btnCalculadora
        '
        Me.btnCalculadora.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalculadora.BackColor = System.Drawing.Color.Transparent
        Me.btnCalculadora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnCalculadora.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCalculadora.Image = Global.ContaExpress.My.Resources.Resources.Credit
        Me.btnCalculadora.Location = New System.Drawing.Point(991, 3)
        Me.btnCalculadora.Name = "btnCalculadora"
        Me.btnCalculadora.Size = New System.Drawing.Size(32, 33)
        Me.btnCalculadora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnCalculadora.TabIndex = 78
        Me.btnCalculadora.TabStop = False
        '
        'btnAsentar
        '
        Me.btnAsentar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAsentar.BackColor = System.Drawing.Color.Transparent
        Me.btnAsentar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnAsentar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAsentar.Image = Global.ContaExpress.My.Resources.Resources.Approve
        Me.btnAsentar.Location = New System.Drawing.Point(1026, 3)
        Me.btnAsentar.Name = "btnAsentar"
        Me.btnAsentar.Size = New System.Drawing.Size(32, 33)
        Me.btnAsentar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnAsentar.TabIndex = 77
        Me.btnAsentar.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.NewOff
        Me.NuevoPictureBox.Location = New System.Drawing.Point(269, 3)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 72
        Me.NuevoPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Enabled = False
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(303, 3)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 73
        Me.EliminarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(337, 3)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 74
        Me.ModificarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(371, 3)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 75
        Me.GuardarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(405, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 76
        Me.CancelarPictureBox.TabStop = False
        '
        'dgvParaAsentar
        '
        Me.dgvParaAsentar.AllowUserToAddRows = False
        Me.dgvParaAsentar.AllowUserToDeleteRows = False
        Me.dgvParaAsentar.AllowUserToResizeRows = False
        Me.dgvParaAsentar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvParaAsentar.AutoGenerateColumns = False
        Me.dgvParaAsentar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvParaAsentar.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvParaAsentar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvParaAsentar.ColumnHeadersHeight = 35
        Me.dgvParaAsentar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ModuloID, Me.RegistroID, Me.TIMBRADODataGridViewTextBoxColumn, Me.CODMONEDA, Me.COTIZACIONDataGridViewTextBoxColumn, Me.CODPERIODOFISCAL, Me.DataGridViewTextBoxColumn1, Me.DETALLE})
        Me.dgvParaAsentar.DataSource = Me.PARAASENTARCABCOMPRASBindingSource
        Me.dgvParaAsentar.Location = New System.Drawing.Point(0, 81)
        Me.dgvParaAsentar.Name = "dgvParaAsentar"
        Me.dgvParaAsentar.ReadOnly = True
        Me.dgvParaAsentar.RowHeadersVisible = False
        Me.dgvParaAsentar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvParaAsentar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvParaAsentar.ShowCellErrors = False
        Me.dgvParaAsentar.Size = New System.Drawing.Size(264, 579)
        Me.dgvParaAsentar.TabIndex = 1
        '
        'ModuloID
        '
        Me.ModuloID.DataPropertyName = "ModuloID"
        Me.ModuloID.HeaderText = "ModuloID"
        Me.ModuloID.Name = "ModuloID"
        Me.ModuloID.ReadOnly = True
        Me.ModuloID.Visible = False
        '
        'RegistroID
        '
        Me.RegistroID.DataPropertyName = "RegistroID"
        Me.RegistroID.HeaderText = "RegistroID"
        Me.RegistroID.Name = "RegistroID"
        Me.RegistroID.ReadOnly = True
        Me.RegistroID.Visible = False
        '
        'TIMBRADODataGridViewTextBoxColumn
        '
        Me.TIMBRADODataGridViewTextBoxColumn.DataPropertyName = "TIMBRADO"
        Me.TIMBRADODataGridViewTextBoxColumn.HeaderText = "TIMBRADO"
        Me.TIMBRADODataGridViewTextBoxColumn.Name = "TIMBRADODataGridViewTextBoxColumn"
        Me.TIMBRADODataGridViewTextBoxColumn.ReadOnly = True
        Me.TIMBRADODataGridViewTextBoxColumn.Visible = False
        '
        'CODMONEDA
        '
        Me.CODMONEDA.DataPropertyName = "CODMONEDA"
        Me.CODMONEDA.HeaderText = "CODMONEDA"
        Me.CODMONEDA.Name = "CODMONEDA"
        Me.CODMONEDA.ReadOnly = True
        Me.CODMONEDA.Visible = False
        '
        'COTIZACIONDataGridViewTextBoxColumn
        '
        Me.COTIZACIONDataGridViewTextBoxColumn.DataPropertyName = "COTIZACION"
        Me.COTIZACIONDataGridViewTextBoxColumn.HeaderText = "COTIZACION"
        Me.COTIZACIONDataGridViewTextBoxColumn.Name = "COTIZACIONDataGridViewTextBoxColumn"
        Me.COTIZACIONDataGridViewTextBoxColumn.ReadOnly = True
        Me.COTIZACIONDataGridViewTextBoxColumn.Visible = False
        '
        'CODPERIODOFISCAL
        '
        Me.CODPERIODOFISCAL.DataPropertyName = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.HeaderText = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.Name = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.ReadOnly = True
        Me.CODPERIODOFISCAL.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "FECHAASIENTO"
        Me.DataGridViewTextBoxColumn1.FillWeight = 50.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DETALLE
        '
        Me.DETALLE.DataPropertyName = "DETALLE"
        Me.DETALLE.HeaderText = "Detalle Asiento"
        Me.DETALLE.Name = "DETALLE"
        Me.DETALLE.ReadOnly = True
        '
        'PARAASENTARCABCOMPRASBindingSource
        '
        Me.PARAASENTARCABCOMPRASBindingSource.DataMember = "PARAASENTARCAB_COMPRAS"
        Me.PARAASENTARCABCOMPRASBindingSource.DataSource = Me.DsPlantillasConta
        '
        'DsPlantillasConta
        '
        Me.DsPlantillasConta.DataSetName = "DsPlantillasConta"
        Me.DsPlantillasConta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tbxRUC
        '
        Me.tbxRUC.BackColor = System.Drawing.Color.White
        Me.tbxRUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRUC.Enabled = False
        Me.tbxRUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRUC.Location = New System.Drawing.Point(382, 125)
        Me.tbxRUC.Name = "tbxRUC"
        Me.tbxRUC.Size = New System.Drawing.Size(246, 26)
        Me.tbxRUC.TabIndex = 2
        '
        'tbxTimbrado
        '
        Me.tbxTimbrado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTimbrado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PARAASENTARCABCOMPRASBindingSource, "TIMBRADO", True))
        Me.tbxTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTimbrado.Location = New System.Drawing.Point(382, 157)
        Me.tbxTimbrado.Name = "tbxTimbrado"
        Me.tbxTimbrado.Size = New System.Drawing.Size(246, 26)
        Me.tbxTimbrado.TabIndex = 2
        '
        'tbxComprobante
        '
        Me.tbxComprobante.BackColor = System.Drawing.Color.White
        Me.tbxComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxComprobante.Enabled = False
        Me.tbxComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxComprobante.Location = New System.Drawing.Point(382, 189)
        Me.tbxComprobante.Name = "tbxComprobante"
        Me.tbxComprobante.Size = New System.Drawing.Size(246, 26)
        Me.tbxComprobante.TabIndex = 2
        '
        'dgbParaAsentarDetalle
        '
        Me.dgbParaAsentarDetalle.AllowUserToAddRows = False
        Me.dgbParaAsentarDetalle.AllowUserToDeleteRows = False
        Me.dgbParaAsentarDetalle.AllowUserToResizeColumns = False
        Me.dgbParaAsentarDetalle.AllowUserToResizeRows = False
        Me.dgbParaAsentarDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgbParaAsentarDetalle.AutoGenerateColumns = False
        Me.dgbParaAsentarDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbParaAsentarDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgbParaAsentarDetalle.ColumnHeadersHeight = 35
        Me.dgbParaAsentarDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAASIENTO, Me.MODULOID1, Me.AsientoID, Me.REGISTROID1, Me.NUMPLANCUENTA1, Me.DESCRIPCION1, Me.IMPORTED1, Me.IMPORTEH1, Me.CODPLANCUENTADetalle, Me.EstadoGrilla})
        Me.dgbParaAsentarDetalle.DataSource = Me.PARAASENTARDETBindingSource
        Me.dgbParaAsentarDetalle.Location = New System.Drawing.Point(6, 89)
        Me.dgbParaAsentarDetalle.Name = "dgbParaAsentarDetalle"
        Me.dgbParaAsentarDetalle.ReadOnly = True
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbParaAsentarDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgbParaAsentarDetalle.RowHeadersVisible = False
        Me.dgbParaAsentarDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgbParaAsentarDetalle.Size = New System.Drawing.Size(781, 152)
        Me.dgbParaAsentarDetalle.TabIndex = 1
        '
        'FECHAASIENTO
        '
        Me.FECHAASIENTO.DataPropertyName = "FECHAASIENTO"
        Me.FECHAASIENTO.HeaderText = "Fecha"
        Me.FECHAASIENTO.Name = "FECHAASIENTO"
        Me.FECHAASIENTO.ReadOnly = True
        '
        'MODULOID1
        '
        Me.MODULOID1.DataPropertyName = "ModuloID"
        Me.MODULOID1.HeaderText = "ModuloID"
        Me.MODULOID1.Name = "MODULOID1"
        Me.MODULOID1.ReadOnly = True
        Me.MODULOID1.Visible = False
        '
        'AsientoID
        '
        Me.AsientoID.DataPropertyName = "AsientoID"
        Me.AsientoID.HeaderText = "AsientoID"
        Me.AsientoID.Name = "AsientoID"
        Me.AsientoID.ReadOnly = True
        Me.AsientoID.Visible = False
        '
        'REGISTROID1
        '
        Me.REGISTROID1.DataPropertyName = "RegistroID"
        Me.REGISTROID1.HeaderText = "RegistroID"
        Me.REGISTROID1.Name = "REGISTROID1"
        Me.REGISTROID1.ReadOnly = True
        Me.REGISTROID1.Visible = False
        '
        'NUMPLANCUENTA1
        '
        Me.NUMPLANCUENTA1.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA1.FillWeight = 170.0!
        Me.NUMPLANCUENTA1.HeaderText = "Cuenta Nro"
        Me.NUMPLANCUENTA1.Name = "NUMPLANCUENTA1"
        Me.NUMPLANCUENTA1.ReadOnly = True
        '
        'DESCRIPCION1
        '
        Me.DESCRIPCION1.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION1.FillWeight = 240.0!
        Me.DESCRIPCION1.HeaderText = "Descripcion"
        Me.DESCRIPCION1.Name = "DESCRIPCION1"
        Me.DESCRIPCION1.ReadOnly = True
        '
        'IMPORTED1
        '
        Me.IMPORTED1.DataPropertyName = "IMPORTED"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IMPORTED1.DefaultCellStyle = DataGridViewCellStyle3
        Me.IMPORTED1.FillWeight = 125.0!
        Me.IMPORTED1.HeaderText = "Debe"
        Me.IMPORTED1.Name = "IMPORTED1"
        Me.IMPORTED1.ReadOnly = True
        '
        'IMPORTEH1
        '
        Me.IMPORTEH1.DataPropertyName = "IMPORTEH"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.IMPORTEH1.DefaultCellStyle = DataGridViewCellStyle4
        Me.IMPORTEH1.FillWeight = 125.0!
        Me.IMPORTEH1.HeaderText = "Haber"
        Me.IMPORTEH1.Name = "IMPORTEH1"
        Me.IMPORTEH1.ReadOnly = True
        '
        'CODPLANCUENTADetalle
        '
        Me.CODPLANCUENTADetalle.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTADetalle.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTADetalle.Name = "CODPLANCUENTADetalle"
        Me.CODPLANCUENTADetalle.ReadOnly = True
        Me.CODPLANCUENTADetalle.Visible = False
        '
        'EstadoGrilla
        '
        Me.EstadoGrilla.HeaderText = "EstadoGrilla"
        Me.EstadoGrilla.Name = "EstadoGrilla"
        Me.EstadoGrilla.ReadOnly = True
        Me.EstadoGrilla.Visible = False
        '
        'PARAASENTARDETBindingSource
        '
        Me.PARAASENTARDETBindingSource.DataMember = "PARAASENTARDET"
        Me.PARAASENTARDETBindingSource.DataSource = Me.DsPlantillasConta
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BackColor = System.Drawing.Color.LightGray
        Me.lblEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(282, 95)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(95, 23)
        Me.lblEmpresa.TabIndex = 4
        Me.lblEmpresa.Text = "Cliente:"
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRUC
        '
        Me.lblRUC.AutoSize = True
        Me.lblRUC.BackColor = System.Drawing.Color.LightGray
        Me.lblRUC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRUC.Location = New System.Drawing.Point(337, 132)
        Me.lblRUC.Name = "lblRUC"
        Me.lblRUC.Size = New System.Drawing.Size(40, 16)
        Me.lblRUC.TabIndex = 4
        Me.lblRUC.Text = "RUC:"
        Me.lblRUC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimbrado
        '
        Me.lblTimbrado.AutoSize = True
        Me.lblTimbrado.BackColor = System.Drawing.Color.LightGray
        Me.lblTimbrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimbrado.Location = New System.Drawing.Point(307, 164)
        Me.lblTimbrado.Name = "lblTimbrado"
        Me.lblTimbrado.Size = New System.Drawing.Size(70, 16)
        Me.lblTimbrado.TabIndex = 5
        Me.lblTimbrado.Text = "Timbrado:"
        Me.lblTimbrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblComprobante
        '
        Me.lblComprobante.AutoSize = True
        Me.lblComprobante.BackColor = System.Drawing.Color.LightGray
        Me.lblComprobante.Enabled = False
        Me.lblComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComprobante.Location = New System.Drawing.Point(282, 196)
        Me.lblComprobante.Name = "lblComprobante"
        Me.lblComprobante.Size = New System.Drawing.Size(95, 16)
        Me.lblComprobante.TabIndex = 6
        Me.lblComprobante.Text = "Nro Comprob.:"
        Me.lblComprobante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxCotizacion
        '
        Me.tbxCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCotizacion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PARAASENTARCABCOMPRASBindingSource, "COTIZACION", True))
        Me.tbxCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCotizacion.Location = New System.Drawing.Point(810, 221)
        Me.tbxCotizacion.Name = "tbxCotizacion"
        Me.tbxCotizacion.Size = New System.Drawing.Size(246, 26)
        Me.tbxCotizacion.TabIndex = 2
        '
        'lblTipoTrans
        '
        Me.lblTipoTrans.AutoSize = True
        Me.lblTipoTrans.BackColor = System.Drawing.Color.LightGray
        Me.lblTipoTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoTrans.Location = New System.Drawing.Point(657, 129)
        Me.lblTipoTrans.Name = "lblTipoTrans"
        Me.lblTipoTrans.Size = New System.Drawing.Size(143, 16)
        Me.lblTipoTrans.TabIndex = 4
        Me.lblTipoTrans.Text = "Tipo de Comprobante:"
        Me.lblTipoTrans.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.BackColor = System.Drawing.Color.LightGray
        Me.lblMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoneda.Location = New System.Drawing.Point(739, 194)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(61, 16)
        Me.lblMoneda.TabIndex = 4
        Me.lblMoneda.Text = "Moneda:"
        Me.lblMoneda.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.LightGray
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(728, 226)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Cotizacion:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.LightGray
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(752, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 16)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Fecha:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxGrabIva10
        '
        Me.tbxGrabIva10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxGrabIva10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxGrabIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxGrabIva10.Location = New System.Drawing.Point(382, 284)
        Me.tbxGrabIva10.Name = "tbxGrabIva10"
        Me.tbxGrabIva10.ReadOnly = True
        Me.tbxGrabIva10.Size = New System.Drawing.Size(246, 26)
        Me.tbxGrabIva10.TabIndex = 2
        Me.tbxGrabIva10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxGrabIva5
        '
        Me.tbxGrabIva5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxGrabIva5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxGrabIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxGrabIva5.Location = New System.Drawing.Point(382, 253)
        Me.tbxGrabIva5.Name = "tbxGrabIva5"
        Me.tbxGrabIva5.ReadOnly = True
        Me.tbxGrabIva5.Size = New System.Drawing.Size(246, 26)
        Me.tbxGrabIva5.TabIndex = 2
        Me.tbxGrabIva5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxExcentas
        '
        Me.tbxExcentas.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxExcentas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxExcentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxExcentas.Location = New System.Drawing.Point(382, 221)
        Me.tbxExcentas.Name = "tbxExcentas"
        Me.tbxExcentas.ReadOnly = True
        Me.tbxExcentas.Size = New System.Drawing.Size(246, 26)
        Me.tbxExcentas.TabIndex = 2
        Me.tbxExcentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.LightGray
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(281, 291)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Grav. IVA 10%:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.LightGray
        Me.Label2.Enabled = False
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(318, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Exentas:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.LightGray
        Me.Label3.Enabled = False
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(288, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Grav. IVA 5%:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.LightGray
        Me.Label4.Enabled = False
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(273, 321)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Total Comprob.:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxIva10
        '
        Me.tbxIva10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxIva10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIva10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxIva10.Location = New System.Drawing.Point(810, 284)
        Me.tbxIva10.Name = "tbxIva10"
        Me.tbxIva10.ReadOnly = True
        Me.tbxIva10.Size = New System.Drawing.Size(246, 26)
        Me.tbxIva10.TabIndex = 2
        Me.tbxIva10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxIva5
        '
        Me.tbxIva5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxIva5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIva5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxIva5.Location = New System.Drawing.Point(810, 253)
        Me.tbxIva5.Name = "tbxIva5"
        Me.tbxIva5.ReadOnly = True
        Me.tbxIva5.Size = New System.Drawing.Size(246, 26)
        Me.tbxIva5.TabIndex = 2
        Me.tbxIva5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbxTotalIva
        '
        Me.tbxTotalIva.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxTotalIva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTotalIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTotalIva.Location = New System.Drawing.Point(810, 316)
        Me.tbxTotalIva.Name = "tbxTotalIva"
        Me.tbxTotalIva.ReadOnly = True
        Me.tbxTotalIva.Size = New System.Drawing.Size(246, 26)
        Me.tbxTotalIva.TabIndex = 2
        Me.tbxTotalIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.LightGray
        Me.Label5.Enabled = False
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.DimGray
        Me.Label5.Location = New System.Drawing.Point(740, 289)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "IVA 10%:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.LightGray
        Me.Label9.Enabled = False
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DimGray
        Me.Label9.Location = New System.Drawing.Point(735, 321)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 16)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Total IVA:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.LightGray
        Me.Label10.Enabled = False
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DimGray
        Me.Label10.Location = New System.Drawing.Point(746, 258)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "IVA 5%:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Black
        Me.lblTitulo.Location = New System.Drawing.Point(267, 42)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(240, 37)
        Me.lblTitulo.TabIndex = 8
        Me.lblTitulo.Text = "Libro de Venta"
        '
        'lblVerModulo
        '
        Me.lblVerModulo.AutoSize = True
        Me.lblVerModulo.BackColor = System.Drawing.Color.Transparent
        Me.lblVerModulo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblVerModulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblVerModulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.lblVerModulo.Location = New System.Drawing.Point(916, 58)
        Me.lblVerModulo.Name = "lblVerModulo"
        Me.lblVerModulo.Size = New System.Drawing.Size(141, 17)
        Me.lblVerModulo.TabIndex = 1
        Me.lblVerModulo.Text = "Ver Datos en Modulo"
        '
        'tbxEmpresa
        '
        Me.tbxEmpresa.BackColor = System.Drawing.Color.White
        Me.tbxEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmpresa.Enabled = False
        Me.tbxEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxEmpresa.Location = New System.Drawing.Point(382, 94)
        Me.tbxEmpresa.Name = "tbxEmpresa"
        Me.tbxEmpresa.Size = New System.Drawing.Size(246, 26)
        Me.tbxEmpresa.TabIndex = 2
        '
        'tbxMoneda
        '
        Me.tbxMoneda.BackColor = System.Drawing.Color.White
        Me.tbxMoneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMoneda.Enabled = False
        Me.tbxMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMoneda.Location = New System.Drawing.Point(810, 189)
        Me.tbxMoneda.Name = "tbxMoneda"
        Me.tbxMoneda.Size = New System.Drawing.Size(246, 26)
        Me.tbxMoneda.TabIndex = 2
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminar.Location = New System.Drawing.Point(725, 25)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(62, 27)
        Me.btnEliminar.TabIndex = 20
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(658, 25)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(63, 27)
        Me.btnAgregar.TabIndex = 19
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'tbxCuenta
        '
        Me.tbxCuenta.BackColor = System.Drawing.Color.White
        Me.tbxCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCuenta.Enabled = False
        Me.tbxCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCuenta.Location = New System.Drawing.Point(6, 58)
        Me.tbxCuenta.Name = "tbxCuenta"
        Me.tbxCuenta.Size = New System.Drawing.Size(783, 27)
        Me.tbxCuenta.TabIndex = 17
        '
        'tbxNroCuenta
        '
        Me.tbxNroCuenta.BackColor = System.Drawing.Color.White
        Me.tbxNroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxNroCuenta.Location = New System.Drawing.Point(131, 25)
        Me.tbxNroCuenta.Name = "tbxNroCuenta"
        Me.tbxNroCuenta.Size = New System.Drawing.Size(140, 27)
        Me.tbxNroCuenta.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.LightGray
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label11.Location = New System.Drawing.Point(275, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Debe / Haber"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.LightGray
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label12.Location = New System.Drawing.Point(130, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 17)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Cuenta Nro"
        '
        'cbxDebeHaber
        '
        Me.cbxDebeHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxDebeHaber.FormattingEnabled = True
        Me.cbxDebeHaber.Items.AddRange(New Object() {"Debe", "Haber"})
        Me.cbxDebeHaber.Location = New System.Drawing.Point(277, 24)
        Me.cbxDebeHaber.Name = "cbxDebeHaber"
        Me.cbxDebeHaber.Size = New System.Drawing.Size(123, 28)
        Me.cbxDebeHaber.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.LightGray
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label8.Location = New System.Drawing.Point(410, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 17)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Debe"
        '
        'tbxDebe
        '
        Me.tbxDebe.BackColor = System.Drawing.Color.White
        Me.tbxDebe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxDebe.Location = New System.Drawing.Point(406, 25)
        Me.tbxDebe.Name = "tbxDebe"
        Me.tbxDebe.Size = New System.Drawing.Size(120, 27)
        Me.tbxDebe.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.LightGray
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label13.Location = New System.Drawing.Point(538, 5)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 17)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Haber"
        '
        'tbxHaber
        '
        Me.tbxHaber.BackColor = System.Drawing.Color.White
        Me.tbxHaber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxHaber.Location = New System.Drawing.Point(532, 25)
        Me.tbxHaber.Name = "tbxHaber"
        Me.tbxHaber.Size = New System.Drawing.Size(120, 27)
        Me.tbxHaber.TabIndex = 15
        '
        'tbxTipoComprobante
        '
        Me.tbxTipoComprobante.BackColor = System.Drawing.Color.White
        Me.tbxTipoComprobante.DataSource = Me.TIPOCOMPROBANTEBindingSource
        Me.tbxTipoComprobante.DisplayMember = "DESCOMPROBANTE"
        Me.tbxTipoComprobante.Enabled = False
        Me.tbxTipoComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tbxTipoComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTipoComprobante.FormattingEnabled = True
        Me.tbxTipoComprobante.Location = New System.Drawing.Point(810, 125)
        Me.tbxTipoComprobante.Name = "tbxTipoComprobante"
        Me.tbxTipoComprobante.Size = New System.Drawing.Size(246, 24)
        Me.tbxTipoComprobante.TabIndex = 21
        Me.tbxTipoComprobante.ValueMember = "CODCOMPROBANTE"
        '
        'TIPOCOMPROBANTEBindingSource
        '
        Me.TIPOCOMPROBANTEBindingSource.DataMember = "TIPOCOMPROBANTE"
        Me.TIPOCOMPROBANTEBindingSource.DataSource = Me.DsPlantillasConta
        '
        'TIPOCOMPROBANTETableAdapter
        '
        Me.TIPOCOMPROBANTETableAdapter.ClearBeforeFill = True
        '
        'PARAASENTARDETTableAdapter
        '
        Me.PARAASENTARDETTableAdapter.ClearBeforeFill = True
        '
        'gbxCuenta
        '
        Me.gbxCuenta.BackColor = System.Drawing.Color.Transparent
        Me.gbxCuenta.Controls.Add(Me.dgbPlanCuentas)
        Me.gbxCuenta.Controls.Add(Me.tbxBuscarCuenta)
        Me.gbxCuenta.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.gbxCuenta.FooterImageIndex = -1
        Me.gbxCuenta.FooterImageKey = ""
        Me.gbxCuenta.HeaderImageIndex = -1
        Me.gbxCuenta.HeaderImageKey = ""
        Me.gbxCuenta.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.gbxCuenta.HeaderText = ""
        Me.gbxCuenta.Location = New System.Drawing.Point(683, 129)
        Me.gbxCuenta.Name = "gbxCuenta"
        Me.gbxCuenta.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.gbxCuenta.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.gbxCuenta.Size = New System.Drawing.Size(363, 414)
        Me.gbxCuenta.TabIndex = 464
        Me.gbxCuenta.ThemeName = "Breeze"
        Me.gbxCuenta.Visible = False
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = ""
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgbPlanCuentas
        '
        Me.dgbPlanCuentas.AllowUserToAddRows = False
        Me.dgbPlanCuentas.AllowUserToDeleteRows = False
        Me.dgbPlanCuentas.AllowUserToResizeRows = False
        Me.dgbPlanCuentas.AutoGenerateColumns = False
        Me.dgbPlanCuentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgbPlanCuentas.BackgroundColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbPlanCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgbPlanCuentas.ColumnHeadersHeight = 35
        Me.dgbPlanCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPLANCUENTA, Me.NUMPLANCUENTA, Me.DESPLANCUENTA})
        Me.dgbPlanCuentas.DataSource = Me.PlancuentasBindingSource
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgbPlanCuentas.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgbPlanCuentas.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgbPlanCuentas.Location = New System.Drawing.Point(11, 48)
        Me.dgbPlanCuentas.Name = "dgbPlanCuentas"
        Me.dgbPlanCuentas.ReadOnly = True
        Me.dgbPlanCuentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbPlanCuentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgbPlanCuentas.RowHeadersVisible = False
        Me.dgbPlanCuentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgbPlanCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgbPlanCuentas.ShowCellErrors = False
        Me.dgbPlanCuentas.ShowCellToolTips = False
        Me.dgbPlanCuentas.Size = New System.Drawing.Size(342, 355)
        Me.dgbPlanCuentas.TabIndex = 424
        '
        'CODPLANCUENTA
        '
        Me.CODPLANCUENTA.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTA.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTA.Name = "CODPLANCUENTA"
        Me.CODPLANCUENTA.ReadOnly = True
        Me.CODPLANCUENTA.Visible = False
        '
        'NUMPLANCUENTA
        '
        Me.NUMPLANCUENTA.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.FillWeight = 60.0!
        Me.NUMPLANCUENTA.HeaderText = "Cuenta Nro"
        Me.NUMPLANCUENTA.Name = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.ReadOnly = True
        '
        'DESPLANCUENTA
        '
        Me.DESPLANCUENTA.DataPropertyName = "DESPLANCUENTA"
        Me.DESPLANCUENTA.FillWeight = 150.0!
        Me.DESPLANCUENTA.HeaderText = "Descripcion"
        Me.DESPLANCUENTA.Name = "DESPLANCUENTA"
        Me.DESPLANCUENTA.ReadOnly = True
        '
        'PlancuentasBindingSource
        '
        Me.PlancuentasBindingSource.DataMember = "plancuentas"
        Me.PlancuentasBindingSource.DataSource = Me.DsPlantillasConta
        '
        'tbxBuscarCuenta
        '
        Me.tbxBuscarCuenta.BackColor = System.Drawing.Color.White
        Me.tbxBuscarCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxBuscarCuenta.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.tbxBuscarCuenta.Location = New System.Drawing.Point(12, 16)
        Me.tbxBuscarCuenta.Name = "tbxBuscarCuenta"
        Me.tbxBuscarCuenta.Size = New System.Drawing.Size(340, 25)
        Me.tbxBuscarCuenta.TabIndex = 376
        Me.tbxBuscarCuenta.Text = "Buscar..."
        '
        'PlancuentasTableAdapter
        '
        Me.PlancuentasTableAdapter.ClearBeforeFill = True
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.gbxCuenta
        '
        'tbxCodCuenta
        '
        Me.tbxCodCuenta.BackColor = System.Drawing.Color.White
        Me.tbxCodCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCodCuenta.Location = New System.Drawing.Point(101, 380)
        Me.tbxCodCuenta.Name = "tbxCodCuenta"
        Me.tbxCodCuenta.Size = New System.Drawing.Size(45, 27)
        Me.tbxCodCuenta.TabIndex = 15
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.LightGray
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(706, 161)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 16)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Tipo de Pago:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbxTipoPago
        '
        Me.cbxTipoPago.BackColor = System.Drawing.Color.White
        Me.cbxTipoPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxTipoPago.FormattingEnabled = True
        Me.cbxTipoPago.Items.AddRange(New Object() {"Contado", "Crédito"})
        Me.cbxTipoPago.Location = New System.Drawing.Point(810, 157)
        Me.cbxTipoPago.Name = "cbxTipoPago"
        Me.cbxTipoPago.Size = New System.Drawing.Size(246, 24)
        Me.cbxTipoPago.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label16.Location = New System.Drawing.Point(810, 735)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 17)
        Me.Label16.TabIndex = 12
        Me.Label16.Text = "Balance:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label17.Location = New System.Drawing.Point(943, 894)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 17)
        Me.Label17.TabIndex = 12
        Me.Label17.Text = "Balance:"
        '
        'tbxTotalFactura
        '
        Me.tbxTotalFactura.AllowDrop = True
        Appearance1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.Name = "Microsoft Sans Serif"
        Appearance1.FontData.SizeInPoints = 15.0!
        Appearance1.TextHAlignAsString = "Right"
        Me.tbxTotalFactura.Appearance = Appearance1
        Me.tbxTotalFactura.AutoSize = False
        Me.tbxTotalFactura.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalFactura.CausesValidation = False
        Me.tbxTotalFactura.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalFactura.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalFactura.Location = New System.Drawing.Point(382, 316)
        Me.tbxTotalFactura.Name = "tbxTotalFactura"
        Me.tbxTotalFactura.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalFactura.ReadOnly = True
        Me.tbxTotalFactura.Size = New System.Drawing.Size(246, 26)
        Me.tbxTotalFactura.TabIndex = 466
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.LightGray
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(323, 354)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 16)
        Me.Label18.TabIndex = 468
        Me.Label18.Text = "Detalle:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbxDetalleAsiento
        '
        Me.tbxDetalleAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDetalleAsiento.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PARAASENTARCABCOMPRASBindingSource, "DETALLE", True))
        Me.tbxDetalleAsiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDetalleAsiento.Location = New System.Drawing.Point(113, 266)
        Me.tbxDetalleAsiento.Name = "tbxDetalleAsiento"
        Me.tbxDetalleAsiento.Size = New System.Drawing.Size(675, 26)
        Me.tbxDetalleAsiento.TabIndex = 467
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetalle.BackColor = System.Drawing.Color.LightGray
        Me.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetalle.Controls.Add(Me.tbxTotalHaber)
        Me.pnlDetalle.Controls.Add(Me.tbxTotalDebe)
        Me.pnlDetalle.Controls.Add(Me.Label15)
        Me.pnlDetalle.Controls.Add(Me.txtFechaCuenta)
        Me.pnlDetalle.Controls.Add(Me.Label13)
        Me.pnlDetalle.Controls.Add(Me.tbxDebe)
        Me.pnlDetalle.Controls.Add(Me.cbxDebeHaber)
        Me.pnlDetalle.Controls.Add(Me.Label19)
        Me.pnlDetalle.Controls.Add(Me.tbxHaber)
        Me.pnlDetalle.Controls.Add(Me.btnEliminar)
        Me.pnlDetalle.Controls.Add(Me.Label8)
        Me.pnlDetalle.Controls.Add(Me.tbxNroCuenta)
        Me.pnlDetalle.Controls.Add(Me.dgbParaAsentarDetalle)
        Me.pnlDetalle.Controls.Add(Me.tbxCuenta)
        Me.pnlDetalle.Controls.Add(Me.Label11)
        Me.pnlDetalle.Controls.Add(Me.Label12)
        Me.pnlDetalle.Controls.Add(Me.btnAgregar)
        Me.pnlDetalle.Controls.Add(Me.btModificar)
        Me.pnlDetalle.Controls.Add(Me.btnCancelar)
        Me.pnlDetalle.Location = New System.Drawing.Point(269, 384)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(793, 276)
        Me.pnlDetalle.TabIndex = 469
        '
        'tbxTotalHaber
        '
        Me.tbxTotalHaber.AllowDrop = True
        Me.tbxTotalHaber.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "True"
        Appearance2.FontData.SizeInPoints = 12.0!
        Me.tbxTotalHaber.Appearance = Appearance2
        Me.tbxTotalHaber.AutoSize = False
        Me.tbxTotalHaber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalHaber.CausesValidation = False
        Me.tbxTotalHaber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalHaber.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalHaber.Location = New System.Drawing.Point(626, 245)
        Me.tbxTotalHaber.Name = "tbxTotalHaber"
        Me.tbxTotalHaber.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalHaber.ReadOnly = True
        Me.tbxTotalHaber.Size = New System.Drawing.Size(160, 26)
        Me.tbxTotalHaber.TabIndex = 468
        '
        'tbxTotalDebe
        '
        Me.tbxTotalDebe.AllowDrop = True
        Me.tbxTotalDebe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "True"
        Appearance3.FontData.SizeInPoints = 12.0!
        Me.tbxTotalDebe.Appearance = Appearance3
        Me.tbxTotalDebe.AutoSize = False
        Me.tbxTotalDebe.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalDebe.CausesValidation = False
        Me.tbxTotalDebe.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalDebe.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalDebe.Location = New System.Drawing.Point(463, 245)
        Me.tbxTotalDebe.Name = "tbxTotalDebe"
        Me.tbxTotalDebe.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalDebe.ReadOnly = True
        Me.tbxTotalDebe.Size = New System.Drawing.Size(160, 26)
        Me.tbxTotalDebe.TabIndex = 469
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.LightGray
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label15.Location = New System.Drawing.Point(397, 250)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(63, 17)
        Me.Label15.TabIndex = 467
        Me.Label15.Text = "Balance:"
        '
        'txtFechaCuenta
        '
        Me.txtFechaCuenta.CalendarMonthBackground = System.Drawing.Color.DimGray
        Me.txtFechaCuenta.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.txtFechaCuenta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.txtFechaCuenta.Location = New System.Drawing.Point(8, 26)
        Me.txtFechaCuenta.Name = "txtFechaCuenta"
        Me.txtFechaCuenta.Size = New System.Drawing.Size(117, 26)
        Me.txtFechaCuenta.TabIndex = 457
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.LightGray
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label19.Location = New System.Drawing.Point(9, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 17)
        Me.Label19.TabIndex = 13
        Me.Label19.Text = "Fecha"
        '
        'btModificar
        '
        Me.btModificar.BackColor = System.Drawing.Color.Gainsboro
        Me.btModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btModificar.Location = New System.Drawing.Point(658, 25)
        Me.btModificar.Name = "btModificar"
        Me.btModificar.Size = New System.Drawing.Size(63, 27)
        Me.btModificar.TabIndex = 21
        Me.btModificar.Text = "Editar"
        Me.btModificar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Location = New System.Drawing.Point(725, 25)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(62, 27)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'PARAASENTARCAB_COMPRASTableAdapter
        '
        Me.PARAASENTARCAB_COMPRASTableAdapter.ClearBeforeFill = True
        '
        'tbxFecha
        '
        Me.tbxFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxFecha.Location = New System.Drawing.Point(808, 92)
        Me.tbxFecha.Name = "tbxFecha"
        Me.tbxFecha.Size = New System.Drawing.Size(250, 26)
        Me.tbxFecha.TabIndex = 470
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.tbxDetalleAsiento)
        Me.Panel2.Location = New System.Drawing.Point(269, 81)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 298)
        Me.Panel2.TabIndex = 471
        '
        'BtnFiltro
        '
        Me.BtnFiltro.AllowDrop = True
        Me.BtnFiltro.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnFiltro.Location = New System.Drawing.Point(199, 46)
        Me.BtnFiltro.Name = "BtnFiltro"
        '
        '
        '
        Me.BtnFiltro.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.BtnFiltro.RootElement.AngleTransform = 0.0!
        Me.BtnFiltro.RootElement.FlipText = False
        Me.BtnFiltro.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFiltro.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.BtnFiltro.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.BtnFiltro.RootElement.Text = Nothing
        Me.BtnFiltro.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.BtnFiltro.Size = New System.Drawing.Size(60, 26)
        Me.BtnFiltro.TabIndex = 497
        Me.BtnFiltro.Text = "Filtrar"
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.Transparent
        Me.CmbMes.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbMes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMes.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2, Me.RadComboBoxItem3, Me.RadComboBoxItem4, Me.RadComboBoxItem5, Me.RadComboBoxItem6, Me.RadComboBoxItem7, Me.RadComboBoxItem8, Me.RadComboBoxItem9, Me.RadComboBoxItem10, Me.RadComboBoxItem11, Me.RadComboBoxItem12})
        Me.CmbMes.Location = New System.Drawing.Point(3, 46)
        Me.CmbMes.MaxDropDownItems = 12
        Me.CmbMes.Name = "CmbMes"
        '
        '
        '
        Me.CmbMes.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.CmbMes.RootElement.AngleTransform = 0.0!
        Me.CmbMes.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbMes.RootElement.FlipText = False
        Me.CmbMes.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMes.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.CmbMes.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.CmbMes.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.CmbMes.RootElement.Text = Nothing
        Me.CmbMes.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.CmbMes.Size = New System.Drawing.Size(101, 26)
        Me.CmbMes.TabIndex = 495
        Me.CmbMes.TabStop = False
        Me.CmbMes.ThemeName = "Breeze"
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.Black
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'RadComboBoxItem1
        '
        Me.RadComboBoxItem1.Name = "RadComboBoxItem1"
        Me.RadComboBoxItem1.Text = "Enero"
        '
        'RadComboBoxItem2
        '
        Me.RadComboBoxItem2.Name = "RadComboBoxItem2"
        Me.RadComboBoxItem2.Text = "Febrero"
        '
        'RadComboBoxItem3
        '
        Me.RadComboBoxItem3.Name = "RadComboBoxItem3"
        Me.RadComboBoxItem3.Text = "Marzo"
        '
        'RadComboBoxItem4
        '
        Me.RadComboBoxItem4.Name = "RadComboBoxItem4"
        Me.RadComboBoxItem4.Text = "Abril"
        '
        'RadComboBoxItem5
        '
        Me.RadComboBoxItem5.Name = "RadComboBoxItem5"
        Me.RadComboBoxItem5.Text = "Mayo"
        '
        'RadComboBoxItem6
        '
        Me.RadComboBoxItem6.Name = "RadComboBoxItem6"
        Me.RadComboBoxItem6.Text = "Junio"
        '
        'RadComboBoxItem7
        '
        Me.RadComboBoxItem7.Name = "RadComboBoxItem7"
        Me.RadComboBoxItem7.Text = "Julio"
        '
        'RadComboBoxItem8
        '
        Me.RadComboBoxItem8.Name = "RadComboBoxItem8"
        Me.RadComboBoxItem8.Text = "Agosto"
        '
        'RadComboBoxItem9
        '
        Me.RadComboBoxItem9.Name = "RadComboBoxItem9"
        Me.RadComboBoxItem9.Text = "Septiembre"
        '
        'RadComboBoxItem10
        '
        Me.RadComboBoxItem10.Name = "RadComboBoxItem10"
        Me.RadComboBoxItem10.Text = "Octubre"
        '
        'RadComboBoxItem11
        '
        Me.RadComboBoxItem11.Name = "RadComboBoxItem11"
        Me.RadComboBoxItem11.Text = "Noviembre"
        '
        'RadComboBoxItem12
        '
        Me.RadComboBoxItem12.Name = "RadComboBoxItem12"
        Me.RadComboBoxItem12.Text = "Diciembre"
        '
        'CmbAño
        '
        Me.CmbAño.BackColor = System.Drawing.Color.Transparent
        Me.CmbAño.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem13, Me.RadComboBoxItem14, Me.RadComboBoxItem15, Me.RadComboBoxItem16, Me.RadComboBoxItem17, Me.RadComboBoxItem18, Me.RadComboBoxItem19, Me.RadComboBoxItem20, Me.RadComboBoxItem21, Me.RadComboBoxItem22, Me.RadComboBoxItem23})
        Me.CmbAño.Location = New System.Drawing.Point(110, 46)
        Me.CmbAño.MaxDropDownItems = 12
        Me.CmbAño.Name = "CmbAño"
        '
        '
        '
        Me.CmbAño.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.CmbAño.RootElement.AngleTransform = 0.0!
        Me.CmbAño.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.WrapAroundChildren
        Me.CmbAño.RootElement.FlipText = False
        Me.CmbAño.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.CmbAño.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.CmbAño.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.CmbAño.RootElement.Text = Nothing
        Me.CmbAño.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.CmbAño.Size = New System.Drawing.Size(84, 26)
        Me.CmbAño.TabIndex = 496
        Me.CmbAño.TabStop = False
        Me.CmbAño.ThemeName = "Breeze"
        CType(Me.CmbAño.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.Black
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'RadComboBoxItem13
        '
        Me.RadComboBoxItem13.Name = "RadComboBoxItem13"
        Me.RadComboBoxItem13.Text = "2010"
        '
        'RadComboBoxItem14
        '
        Me.RadComboBoxItem14.Name = "RadComboBoxItem14"
        Me.RadComboBoxItem14.Text = "2011"
        '
        'RadComboBoxItem15
        '
        Me.RadComboBoxItem15.Name = "RadComboBoxItem15"
        Me.RadComboBoxItem15.Text = "2012"
        '
        'RadComboBoxItem16
        '
        Me.RadComboBoxItem16.Name = "RadComboBoxItem16"
        Me.RadComboBoxItem16.Text = "2013"
        '
        'RadComboBoxItem17
        '
        Me.RadComboBoxItem17.Name = "RadComboBoxItem17"
        Me.RadComboBoxItem17.Text = "2014"
        '
        'RadComboBoxItem18
        '
        Me.RadComboBoxItem18.Name = "RadComboBoxItem18"
        Me.RadComboBoxItem18.Text = "2015"
        '
        'RadComboBoxItem19
        '
        Me.RadComboBoxItem19.Name = "RadComboBoxItem19"
        Me.RadComboBoxItem19.Text = "2016"
        '
        'RadComboBoxItem20
        '
        Me.RadComboBoxItem20.Name = "RadComboBoxItem20"
        Me.RadComboBoxItem20.Text = "2017"
        '
        'RadComboBoxItem21
        '
        Me.RadComboBoxItem21.Name = "RadComboBoxItem21"
        Me.RadComboBoxItem21.Text = "2018"
        '
        'RadComboBoxItem22
        '
        Me.RadComboBoxItem22.Name = "RadComboBoxItem22"
        Me.RadComboBoxItem22.Text = "2019"
        '
        'RadComboBoxItem23
        '
        Me.RadComboBoxItem23.Name = "RadComboBoxItem23"
        Me.RadComboBoxItem23.Text = "2020"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 664)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(1069, 22)
        Me.StatusStrip1.TabIndex = 498
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel2.IsLink = True
        Me.ToolStripStatusLabel2.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(57, 17)
        Me.ToolStripStatusLabel2.Text = "Ayuda"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(997, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "F6 - Editar / F7 - Guardar / F8 - Cancelar  / F9 - Asentar / F10 - Ver en Modulo"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Lavender
        Me.Panel3.Location = New System.Drawing.Point(-3, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(267, 67)
        Me.Panel3.TabIndex = 545
        '
        'LibroVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(1069, 686)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.BtnFiltro)
        Me.Controls.Add(Me.CmbMes)
        Me.Controls.Add(Me.CmbAño)
        Me.Controls.Add(Me.tbxFecha)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.tbxTotalFactura)
        Me.Controls.Add(Me.cbxTipoPago)
        Me.Controls.Add(Me.tbxTipoComprobante)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblVerModulo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblComprobante)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTimbrado)
        Me.Controls.Add(Me.lblMoneda)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblRUC)
        Me.Controls.Add(Me.lblTipoTrans)
        Me.Controls.Add(Me.lblEmpresa)
        Me.Controls.Add(Me.tbxMoneda)
        Me.Controls.Add(Me.tbxCotizacion)
        Me.Controls.Add(Me.tbxTotalIva)
        Me.Controls.Add(Me.tbxExcentas)
        Me.Controls.Add(Me.tbxIva5)
        Me.Controls.Add(Me.tbxGrabIva5)
        Me.Controls.Add(Me.tbxIva10)
        Me.Controls.Add(Me.tbxGrabIva10)
        Me.Controls.Add(Me.tbxComprobante)
        Me.Controls.Add(Me.tbxTimbrado)
        Me.Controls.Add(Me.tbxEmpresa)
        Me.Controls.Add(Me.tbxRUC)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dgvParaAsentar)
        Me.Controls.Add(Me.tbxCodCuenta)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.gbxCuenta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "LibroVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Libro de Venta  | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCalculadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnAsentar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvParaAsentar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PARAASENTARCABCOMPRASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgbParaAsentarDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PARAASENTARDETBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCOMPROBANTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCuenta.ResumeLayout(False)
        Me.gbxCuenta.PerformLayout()
        CType(Me.dgbPlanCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvParaAsentar As System.Windows.Forms.DataGridView
    Friend WithEvents tbxRUC As System.Windows.Forms.TextBox
    Friend WithEvents tbxTimbrado As System.Windows.Forms.TextBox
    Friend WithEvents tbxComprobante As System.Windows.Forms.TextBox
    Friend WithEvents dgbParaAsentarDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblRUC As System.Windows.Forms.Label
    Friend WithEvents lblTimbrado As System.Windows.Forms.Label
    Friend WithEvents lblComprobante As System.Windows.Forms.Label
    Friend WithEvents tbxCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoTrans As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbxGrabIva10 As System.Windows.Forms.TextBox
    Friend WithEvents tbxGrabIva5 As System.Windows.Forms.TextBox
    Friend WithEvents tbxExcentas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxIva10 As System.Windows.Forms.TextBox
    Friend WithEvents tbxIva5 As System.Windows.Forms.TextBox
    Friend WithEvents tbxTotalIva As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnCalculadora As System.Windows.Forms.PictureBox
    Friend WithEvents btnAsentar As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblVerModulo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DsPlantillasConta As ContaExpress.DsPlantillasConta
    Friend WithEvents tbxEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents tbxMoneda As System.Windows.Forms.TextBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents tbxCuenta As System.Windows.Forms.TextBox
    Friend WithEvents tbxNroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbxDebeHaber As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents tbxDebe As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tbxHaber As System.Windows.Forms.TextBox
    Friend WithEvents tbxTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents TIPOCOMPROBANTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCOMPROBANTETableAdapter As ContaExpress.DsPlantillasContaTableAdapters.TIPOCOMPROBANTETableAdapter

    Friend WithEvents PARAASENTARDETBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PARAASENTARDETTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.PARAASENTARDETTableAdapter
    Friend WithEvents gbxCuenta As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dgbPlanCuentas As System.Windows.Forms.DataGridView
    Friend WithEvents tbxBuscarCuenta As System.Windows.Forms.TextBox
    Friend WithEvents PlancuentasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlancuentasTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents tbxCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbxTotalFactura As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbxDetalleAsiento As System.Windows.Forms.TextBox
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents PARAASENTARCABCOMPRASBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PARAASENTARCAB_COMPRASTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.PARAASENTARCAB_COMPRASTableAdapter
    Friend WithEvents tbxFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents CmbMes As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents CmbAño As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents RadComboBoxItem1 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem2 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem3 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem4 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem5 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem6 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem7 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem8 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem9 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem10 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem11 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem12 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem13 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem14 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem15 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem16 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem17 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem18 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem19 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem20 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem21 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem22 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents RadComboBoxItem23 As Telerik.WinControls.UI.RadComboBoxItem
    Friend WithEvents btModificar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtFechaCuenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tbxTotalHaber As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tbxTotalDebe As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CODPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAASIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODULOID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AsientoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REGISTROID1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPLANCUENTA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTED1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTEH1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPLANCUENTADetalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EstadoGrilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModuloID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RegistroID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIMBRADODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COTIZACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPERIODOFISCAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETALLE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
