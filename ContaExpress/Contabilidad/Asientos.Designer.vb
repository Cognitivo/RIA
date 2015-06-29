<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Asientos
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
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Asientos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbAnho = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.pbxBuscar = New System.Windows.Forms.PictureBox()
        Me.pbxAsientos = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.dgvAsiento = New System.Windows.Forms.DataGridView()
        Me.NUMASIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAASIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DETALLE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COTIZACIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AsientoID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTED = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMPORTEH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIFERENCIADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AsientosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPlantillasConta = New ContaExpress.DsPlantillasConta()
        Me.DsPlantillasContaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxPeriodoFiscal = New System.Windows.Forms.ComboBox()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPeriodoFiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPeriodoFiscal = New ContaExpress.DsPeriodoFiscal()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlDetalleAsiento = New System.Windows.Forms.Panel()
        Me.txtAsientoNroManual = New System.Windows.Forms.TextBox()
        Me.rdbCargarManual = New System.Windows.Forms.RadioButton()
        Me.rdbUltimoNro = New System.Windows.Forms.RadioButton()
        Me.rdbNuevoNro = New System.Windows.Forms.RadioButton()
        Me.dttFecha = New System.Windows.Forms.DateTimePicker()
        Me.tbxHaber = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxDebe = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxNombreCuenta = New System.Windows.Forms.TextBox()
        Me.tbxComentarios = New System.Windows.Forms.TextBox()
        Me.tbxNroCuenta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlBuscarAsiento = New System.Windows.Forms.Panel()
        Me.btnLimpiarCuentas = New System.Windows.Forms.Button()
        Me.btnFiltrarCuentas = New System.Windows.Forms.Button()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbxBuscador = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PeriodofiscalTableAdapter = New ContaExpress.DsPeriodoFiscalTableAdapters.periodofiscalTableAdapter()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtTotalGenHaber = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtTotalGenDebe = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbxTotalHaber = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbxTotakDebe = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.PlancuentasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PlancuentasTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.gbxCuenta = New Telerik.WinControls.UI.RadGroupBox()
        Me.dgbPlanCuentas = New System.Windows.Forms.DataGridView()
        Me.CODPLANCUENTA1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NUMPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPLANCUENTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVELCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ASENTABLEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCUENTADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUENTAMADREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbxBuscarCuenta = New System.Windows.Forms.TextBox()
        Me.tbxCodCuenta = New System.Windows.Forms.TextBox()
        Me.tbxAsientoID = New System.Windows.Forms.TextBox()
        Me.AsientosTableAdapter = New ContaExpress.DsPlantillasContaTableAdapters.AsientosTableAdapter()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAsientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAsiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AsientosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlantillasContaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPeriodoFiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPeriodoFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalleAsiento.SuspendLayout()
        Me.pnlBuscarAsiento.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gbxCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxCuenta.SuspendLayout()
        CType(Me.dgbPlanCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmbAnho)
        Me.Panel1.Controls.Add(Me.cmbMes)
        Me.Panel1.Controls.Add(Me.pbxBuscar)
        Me.Panel1.Controls.Add(Me.pbxAsientos)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1063, 41)
        Me.Panel1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Tan
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Button1.Location = New System.Drawing.Point(187, 8)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 26)
        Me.Button1.TabIndex = 540
        Me.Button1.Text = "Filtrar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbAnho
        '
        Me.cmbAnho.BackColor = System.Drawing.Color.Tan
        Me.cmbAnho.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAnho.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbAnho.FormattingEnabled = True
        Me.cmbAnho.Items.AddRange(New Object() {"2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020"})
        Me.cmbAnho.Location = New System.Drawing.Point(113, 7)
        Me.cmbAnho.MaxDropDownItems = 12
        Me.cmbAnho.Name = "cmbAnho"
        Me.cmbAnho.Size = New System.Drawing.Size(67, 28)
        Me.cmbAnho.TabIndex = 85
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.Tan
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(8, 7)
        Me.cmbMes.MaxDropDownItems = 12
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(99, 28)
        Me.cmbMes.TabIndex = 84
        '
        'pbxBuscar
        '
        Me.pbxBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxBuscar.BackColor = System.Drawing.Color.Transparent
        Me.pbxBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxBuscar.Image = Global.ContaExpress.My.Resources.Resources.SearchBig
        Me.pbxBuscar.Location = New System.Drawing.Point(1009, 4)
        Me.pbxBuscar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbxBuscar.Name = "pbxBuscar"
        Me.pbxBuscar.Size = New System.Drawing.Size(32, 33)
        Me.pbxBuscar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxBuscar.TabIndex = 83
        Me.pbxBuscar.TabStop = False
        '
        'pbxAsientos
        '
        Me.pbxAsientos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxAsientos.BackColor = System.Drawing.Color.Transparent
        Me.pbxAsientos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAsientos.Image = Global.ContaExpress.My.Resources.Resources.PaymentBigOff
        Me.pbxAsientos.Location = New System.Drawing.Point(972, 4)
        Me.pbxAsientos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbxAsientos.Name = "pbxAsientos"
        Me.pbxAsientos.Size = New System.Drawing.Size(32, 33)
        Me.pbxAsientos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAsientos.TabIndex = 82
        Me.pbxAsientos.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(252, 4)
        Me.NuevoPictureBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 77
        Me.NuevoPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Enabled = False
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(290, 4)
        Me.EliminarPictureBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 78
        Me.EliminarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(328, 4)
        Me.ModificarPictureBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 79
        Me.ModificarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(366, 4)
        Me.GuardarPictureBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 80
        Me.GuardarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(404, 4)
        Me.CancelarPictureBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 81
        Me.CancelarPictureBox.TabStop = False
        '
        'dgvAsiento
        '
        Me.dgvAsiento.AllowUserToAddRows = False
        Me.dgvAsiento.AllowUserToDeleteRows = False
        Me.dgvAsiento.AllowUserToResizeRows = False
        Me.dgvAsiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAsiento.AutoGenerateColumns = False
        Me.dgvAsiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAsiento.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvAsiento.ColumnHeadersHeight = 35
        Me.dgvAsiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NUMASIENTODataGridViewTextBoxColumn, Me.FECHAASIENTO, Me.DETALLE, Me.DESCRIPCIONDataGridViewTextBoxColumn, Me.DESMONEDADataGridViewTextBoxColumn, Me.COTIZACIONDataGridViewTextBoxColumn, Me.AsientoID, Me.IMPORTED, Me.IMPORTEH, Me.CODPLANCUENTA, Me.CODPERIODOFISCALDataGridViewTextBoxColumn, Me.DIFERENCIADataGridViewTextBoxColumn})
        Me.dgvAsiento.DataSource = Me.AsientosBindingSource
        Me.dgvAsiento.Location = New System.Drawing.Point(8, 155)
        Me.dgvAsiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvAsiento.Name = "dgvAsiento"
        Me.dgvAsiento.ReadOnly = True
        Me.dgvAsiento.RowHeadersVisible = False
        Me.dgvAsiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAsiento.ShowCellErrors = False
        Me.dgvAsiento.ShowRowErrors = False
        Me.dgvAsiento.Size = New System.Drawing.Size(1043, 454)
        Me.dgvAsiento.TabIndex = 1
        '
        'NUMASIENTODataGridViewTextBoxColumn
        '
        Me.NUMASIENTODataGridViewTextBoxColumn.DataPropertyName = "NUMASIENTO"
        Me.NUMASIENTODataGridViewTextBoxColumn.FillWeight = 40.0!
        Me.NUMASIENTODataGridViewTextBoxColumn.HeaderText = "Nro"
        Me.NUMASIENTODataGridViewTextBoxColumn.Name = "NUMASIENTODataGridViewTextBoxColumn"
        Me.NUMASIENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHAASIENTO
        '
        Me.FECHAASIENTO.DataPropertyName = "FECHAASIENTO"
        Me.FECHAASIENTO.FillWeight = 70.0!
        Me.FECHAASIENTO.HeaderText = "Fecha"
        Me.FECHAASIENTO.Name = "FECHAASIENTO"
        Me.FECHAASIENTO.ReadOnly = True
        '
        'DETALLE
        '
        Me.DETALLE.DataPropertyName = "DETALLE"
        Me.DETALLE.FillWeight = 180.0!
        Me.DETALLE.HeaderText = "Detalle"
        Me.DETALLE.Name = "DETALLE"
        Me.DETALLE.ReadOnly = True
        '
        'DESCRIPCIONDataGridViewTextBoxColumn
        '
        Me.DESCRIPCIONDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.FillWeight = 120.0!
        Me.DESCRIPCIONDataGridViewTextBoxColumn.HeaderText = "Cuenta"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.Name = "DESCRIPCIONDataGridViewTextBoxColumn"
        Me.DESCRIPCIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESMONEDADataGridViewTextBoxColumn
        '
        Me.DESMONEDADataGridViewTextBoxColumn.DataPropertyName = "DESMONEDA"
        Me.DESMONEDADataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.DESMONEDADataGridViewTextBoxColumn.HeaderText = "Moneda"
        Me.DESMONEDADataGridViewTextBoxColumn.Name = "DESMONEDADataGridViewTextBoxColumn"
        Me.DESMONEDADataGridViewTextBoxColumn.ReadOnly = True
        '
        'COTIZACIONDataGridViewTextBoxColumn
        '
        Me.COTIZACIONDataGridViewTextBoxColumn.DataPropertyName = "COTIZACION"
        Me.COTIZACIONDataGridViewTextBoxColumn.FillWeight = 40.0!
        Me.COTIZACIONDataGridViewTextBoxColumn.HeaderText = "Cot."
        Me.COTIZACIONDataGridViewTextBoxColumn.Name = "COTIZACIONDataGridViewTextBoxColumn"
        Me.COTIZACIONDataGridViewTextBoxColumn.ReadOnly = True
        '
        'AsientoID
        '
        Me.AsientoID.DataPropertyName = "AsientoID"
        Me.AsientoID.HeaderText = "AsientoID"
        Me.AsientoID.Name = "AsientoID"
        Me.AsientoID.ReadOnly = True
        Me.AsientoID.Visible = False
        '
        'IMPORTED
        '
        Me.IMPORTED.DataPropertyName = "IMPORTED"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.IMPORTED.DefaultCellStyle = DataGridViewCellStyle1
        Me.IMPORTED.FillWeight = 120.0!
        Me.IMPORTED.HeaderText = "Debe"
        Me.IMPORTED.Name = "IMPORTED"
        Me.IMPORTED.ReadOnly = True
        '
        'IMPORTEH
        '
        Me.IMPORTEH.DataPropertyName = "IMPORTEH"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.IMPORTEH.DefaultCellStyle = DataGridViewCellStyle2
        Me.IMPORTEH.FillWeight = 120.0!
        Me.IMPORTEH.HeaderText = "Haber"
        Me.IMPORTEH.Name = "IMPORTEH"
        Me.IMPORTEH.ReadOnly = True
        '
        'CODPLANCUENTA
        '
        Me.CODPLANCUENTA.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTA.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTA.Name = "CODPLANCUENTA"
        Me.CODPLANCUENTA.ReadOnly = True
        Me.CODPLANCUENTA.Visible = False
        '
        'CODPERIODOFISCALDataGridViewTextBoxColumn
        '
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn.DataPropertyName = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn.HeaderText = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn.Name = "CODPERIODOFISCALDataGridViewTextBoxColumn"
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODPERIODOFISCALDataGridViewTextBoxColumn.Visible = False
        '
        'DIFERENCIADataGridViewTextBoxColumn
        '
        Me.DIFERENCIADataGridViewTextBoxColumn.DataPropertyName = "DIFERENCIA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DIFERENCIADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.DIFERENCIADataGridViewTextBoxColumn.HeaderText = "Diferencia"
        Me.DIFERENCIADataGridViewTextBoxColumn.Name = "DIFERENCIADataGridViewTextBoxColumn"
        Me.DIFERENCIADataGridViewTextBoxColumn.ReadOnly = True
        '
        'AsientosBindingSource
        '
        Me.AsientosBindingSource.DataMember = "Asientos"
        Me.AsientosBindingSource.DataSource = Me.DsPlantillasConta
        '
        'DsPlantillasConta
        '
        Me.DsPlantillasConta.DataSetName = "DsPlantillasConta"
        Me.DsPlantillasConta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsPlantillasContaBindingSource
        '
        Me.DsPlantillasContaBindingSource.DataSource = Me.DsPlantillasConta
        Me.DsPlantillasContaBindingSource.Position = 0
        '
        'cbxPeriodoFiscal
        '
        Me.cbxPeriodoFiscal.BackColor = System.Drawing.Color.White
        Me.cbxPeriodoFiscal.DataSource = Me.PeriodofiscalBindingSource
        Me.cbxPeriodoFiscal.DisplayMember = "DESEJERCICIO"
        Me.cbxPeriodoFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPeriodoFiscal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPeriodoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPeriodoFiscal.FormattingEnabled = True
        Me.cbxPeriodoFiscal.Location = New System.Drawing.Point(15, 52)
        Me.cbxPeriodoFiscal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbxPeriodoFiscal.Name = "cbxPeriodoFiscal"
        Me.cbxPeriodoFiscal.Size = New System.Drawing.Size(176, 28)
        Me.cbxPeriodoFiscal.TabIndex = 0
        Me.cbxPeriodoFiscal.ValueMember = "CODPERIODOFISCAL"
        '
        'PeriodofiscalBindingSource
        '
        Me.PeriodofiscalBindingSource.DataMember = "periodofiscal"
        Me.PeriodofiscalBindingSource.DataSource = Me.DsPeriodoFiscalBindingSource
        '
        'DsPeriodoFiscalBindingSource
        '
        Me.DsPeriodoFiscalBindingSource.DataSource = Me.DsPeriodoFiscal
        Me.DsPeriodoFiscalBindingSource.Position = 0
        '
        'DsPeriodoFiscal
        '
        Me.DsPeriodoFiscal.DataSetName = "DsPeriodoFiscal"
        Me.DsPeriodoFiscal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Lista y Detalle del Asiento"
        '
        'pnlDetalleAsiento
        '
        Me.pnlDetalleAsiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalleAsiento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetalleAsiento.BackColor = System.Drawing.Color.LightGray
        Me.pnlDetalleAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetalleAsiento.Controls.Add(Me.txtAsientoNroManual)
        Me.pnlDetalleAsiento.Controls.Add(Me.rdbCargarManual)
        Me.pnlDetalleAsiento.Controls.Add(Me.rdbUltimoNro)
        Me.pnlDetalleAsiento.Controls.Add(Me.rdbNuevoNro)
        Me.pnlDetalleAsiento.Controls.Add(Me.dttFecha)
        Me.pnlDetalleAsiento.Controls.Add(Me.tbxHaber)
        Me.pnlDetalleAsiento.Controls.Add(Me.tbxDebe)
        Me.pnlDetalleAsiento.Controls.Add(Me.tbxNombreCuenta)
        Me.pnlDetalleAsiento.Controls.Add(Me.tbxComentarios)
        Me.pnlDetalleAsiento.Controls.Add(Me.tbxNroCuenta)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label9)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label8)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label6)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label5)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label2)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label7)
        Me.pnlDetalleAsiento.Controls.Add(Me.Label13)
        Me.pnlDetalleAsiento.Location = New System.Drawing.Point(8, 47)
        Me.pnlDetalleAsiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlDetalleAsiento.Name = "pnlDetalleAsiento"
        Me.pnlDetalleAsiento.Size = New System.Drawing.Size(1044, 104)
        Me.pnlDetalleAsiento.TabIndex = 1
        '
        'txtAsientoNroManual
        '
        Me.txtAsientoNroManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAsientoNroManual.BackColor = System.Drawing.Color.White
        Me.txtAsientoNroManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsientoNroManual.Enabled = False
        Me.txtAsientoNroManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtAsientoNroManual.Location = New System.Drawing.Point(945, 76)
        Me.txtAsientoNroManual.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtAsientoNroManual.Name = "txtAsientoNroManual"
        Me.txtAsientoNroManual.Size = New System.Drawing.Size(91, 24)
        Me.txtAsientoNroManual.TabIndex = 462
        '
        'rdbCargarManual
        '
        Me.rdbCargarManual.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbCargarManual.AutoSize = True
        Me.rdbCargarManual.Location = New System.Drawing.Point(707, 78)
        Me.rdbCargarManual.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbCargarManual.Name = "rdbCargarManual"
        Me.rdbCargarManual.Size = New System.Drawing.Size(237, 21)
        Me.rdbCargarManual.TabIndex = 461
        Me.rdbCargarManual.Text = "Cargar Manual de Nro de Asiento"
        Me.rdbCargarManual.UseVisualStyleBackColor = True
        '
        'rdbUltimoNro
        '
        Me.rdbUltimoNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbUltimoNro.AutoSize = True
        Me.rdbUltimoNro.Location = New System.Drawing.Point(501, 78)
        Me.rdbUltimoNro.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbUltimoNro.Name = "rdbUltimoNro"
        Me.rdbUltimoNro.Size = New System.Drawing.Size(197, 21)
        Me.rdbUltimoNro.TabIndex = 460
        Me.rdbUltimoNro.Text = "Usar Ultimo Nro de Asiento"
        Me.rdbUltimoNro.UseVisualStyleBackColor = True
        '
        'rdbNuevoNro
        '
        Me.rdbNuevoNro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rdbNuevoNro.AutoSize = True
        Me.rdbNuevoNro.Checked = True
        Me.rdbNuevoNro.Location = New System.Drawing.Point(275, 78)
        Me.rdbNuevoNro.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rdbNuevoNro.Name = "rdbNuevoNro"
        Me.rdbNuevoNro.Size = New System.Drawing.Size(217, 21)
        Me.rdbNuevoNro.TabIndex = 459
        Me.rdbNuevoNro.TabStop = True
        Me.rdbNuevoNro.Text = "Genera Nuevo Nro de Asiento"
        Me.rdbNuevoNro.UseVisualStyleBackColor = True
        '
        'dttFecha
        '
        Me.dttFecha.CalendarMonthBackground = System.Drawing.Color.Gainsboro
        Me.dttFecha.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dttFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dttFecha.Location = New System.Drawing.Point(5, 46)
        Me.dttFecha.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dttFecha.Name = "dttFecha"
        Me.dttFecha.Size = New System.Drawing.Size(121, 26)
        Me.dttFecha.TabIndex = 457
        '
        'tbxHaber
        '
        Me.tbxHaber.AllowDrop = True
        Me.tbxHaber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance2.BackColor = System.Drawing.Color.White
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.SizeInPoints = 12.75!
        Appearance2.TextHAlignAsString = "Right"
        Appearance2.TextVAlignAsString = "Middle"
        Me.tbxHaber.Appearance = Appearance2
        Me.tbxHaber.AutoSize = False
        Me.tbxHaber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxHaber.CausesValidation = False
        Me.tbxHaber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxHaber.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.tbxHaber.Location = New System.Drawing.Point(912, 46)
        Me.tbxHaber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxHaber.Name = "tbxHaber"
        Me.tbxHaber.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxHaber.Size = New System.Drawing.Size(124, 27)
        Me.tbxHaber.TabIndex = 5
        '
        'tbxDebe
        '
        Me.tbxDebe.AllowDrop = True
        Me.tbxDebe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance3.BackColor = System.Drawing.Color.White
        Appearance3.BorderColor = System.Drawing.Color.White
        Appearance3.FontData.BoldAsString = "False"
        Appearance3.FontData.SizeInPoints = 12.75!
        Appearance3.TextHAlignAsString = "Right"
        Appearance3.TextVAlignAsString = "Middle"
        Me.tbxDebe.Appearance = Appearance3
        Me.tbxDebe.AutoSize = False
        Me.tbxDebe.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxDebe.CausesValidation = False
        Me.tbxDebe.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxDebe.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.tbxDebe.Location = New System.Drawing.Point(785, 46)
        Me.tbxDebe.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxDebe.Name = "tbxDebe"
        Me.tbxDebe.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxDebe.Size = New System.Drawing.Size(124, 27)
        Me.tbxDebe.TabIndex = 4
        '
        'tbxNombreCuenta
        '
        Me.tbxNombreCuenta.BackColor = System.Drawing.Color.White
        Me.tbxNombreCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNombreCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNombreCuenta.Location = New System.Drawing.Point(251, 46)
        Me.tbxNombreCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxNombreCuenta.Name = "tbxNombreCuenta"
        Me.tbxNombreCuenta.Size = New System.Drawing.Size(175, 27)
        Me.tbxNombreCuenta.TabIndex = 2
        '
        'tbxComentarios
        '
        Me.tbxComentarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxComentarios.BackColor = System.Drawing.Color.White
        Me.tbxComentarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxComentarios.Location = New System.Drawing.Point(429, 46)
        Me.tbxComentarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxComentarios.Name = "tbxComentarios"
        Me.tbxComentarios.Size = New System.Drawing.Size(352, 27)
        Me.tbxComentarios.TabIndex = 3
        '
        'tbxNroCuenta
        '
        Me.tbxNroCuenta.BackColor = System.Drawing.Color.White
        Me.tbxNroCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNroCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNroCuenta.Location = New System.Drawing.Point(131, 46)
        Me.tbxNroCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxNroCuenta.Name = "tbxNroCuenta"
        Me.tbxNroCuenta.Size = New System.Drawing.Size(117, 27)
        Me.tbxNroCuenta.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(914, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 17)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Haber"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(787, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 17)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Debe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(253, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 17)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Nombre de Cuenta"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(135, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nro de Cuenta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(431, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 17)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Comentarios"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(11, 25)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 17)
        Me.Label13.TabIndex = 458
        Me.Label13.Text = "Fecha"
        '
        'pnlBuscarAsiento
        '
        Me.pnlBuscarAsiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBuscarAsiento.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlBuscarAsiento.BackColor = System.Drawing.Color.LightGray
        Me.pnlBuscarAsiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBuscarAsiento.Controls.Add(Me.btnLimpiarCuentas)
        Me.pnlBuscarAsiento.Controls.Add(Me.btnFiltrarCuentas)
        Me.pnlBuscarAsiento.Controls.Add(Me.dtpFechaHasta)
        Me.pnlBuscarAsiento.Controls.Add(Me.dtpFechaDesde)
        Me.pnlBuscarAsiento.Controls.Add(Me.Label12)
        Me.pnlBuscarAsiento.Controls.Add(Me.tbxBuscador)
        Me.pnlBuscarAsiento.Controls.Add(Me.Label11)
        Me.pnlBuscarAsiento.Controls.Add(Me.Label4)
        Me.pnlBuscarAsiento.Controls.Add(Me.Label3)
        Me.pnlBuscarAsiento.Controls.Add(Me.cbxPeriodoFiscal)
        Me.pnlBuscarAsiento.Controls.Add(Me.Label1)
        Me.pnlBuscarAsiento.Location = New System.Drawing.Point(8, 47)
        Me.pnlBuscarAsiento.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pnlBuscarAsiento.Name = "pnlBuscarAsiento"
        Me.pnlBuscarAsiento.Size = New System.Drawing.Size(1044, 104)
        Me.pnlBuscarAsiento.TabIndex = 3
        '
        'btnLimpiarCuentas
        '
        Me.btnLimpiarCuentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiarCuentas.BackColor = System.Drawing.Color.Gainsboro
        Me.btnLimpiarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLimpiarCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnLimpiarCuentas.Location = New System.Drawing.Point(971, 53)
        Me.btnLimpiarCuentas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnLimpiarCuentas.Name = "btnLimpiarCuentas"
        Me.btnLimpiarCuentas.Size = New System.Drawing.Size(59, 26)
        Me.btnLimpiarCuentas.TabIndex = 540
        Me.btnLimpiarCuentas.Text = "Limpiar"
        Me.btnLimpiarCuentas.UseVisualStyleBackColor = False
        '
        'btnFiltrarCuentas
        '
        Me.btnFiltrarCuentas.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltrarCuentas.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnFiltrarCuentas.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnFiltrarCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrarCuentas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnFiltrarCuentas.Location = New System.Drawing.Point(894, 53)
        Me.btnFiltrarCuentas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnFiltrarCuentas.Name = "btnFiltrarCuentas"
        Me.btnFiltrarCuentas.Size = New System.Drawing.Size(71, 26)
        Me.btnFiltrarCuentas.TabIndex = 539
        Me.btnFiltrarCuentas.Text = "Filtrar"
        Me.btnFiltrarCuentas.UseVisualStyleBackColor = False
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(752, 53)
        Me.dtpFechaHasta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(124, 27)
        Me.dtpFechaHasta.TabIndex = 6
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(623, 53)
        Me.dtpFechaDesde.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(124, 27)
        Me.dtpFechaDesde.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(755, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(92, 17)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Fecha Hasta:"
        '
        'tbxBuscador
        '
        Me.tbxBuscador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxBuscador.BackColor = System.Drawing.Color.White
        Me.tbxBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscador.Location = New System.Drawing.Point(200, 53)
        Me.tbxBuscador.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxBuscador.Name = "tbxBuscador"
        Me.tbxBuscador.Size = New System.Drawing.Size(417, 27)
        Me.tbxBuscador.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(624, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 17)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Fecha Desde:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(197, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(242, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cuentas / Concepto / Nro de Asiento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Periodo Fiscal:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtro de Asientos"
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.LightGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtTotalGenHaber)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtTotalGenDebe)
        Me.Panel3.Controls.Add(Me.tbxTotalHaber)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.tbxTotakDebe)
        Me.Panel3.Location = New System.Drawing.Point(8, 612)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1044, 40)
        Me.Panel3.TabIndex = 4
        '
        'txtTotalGenHaber
        '
        Me.txtTotalGenHaber.AllowDrop = True
        Appearance1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance1.BorderColor = System.Drawing.Color.White
        Appearance1.FontData.BoldAsString = "True"
        Appearance1.FontData.SizeInPoints = 12.0!
        Appearance1.TextHAlignAsString = "Right"
        Me.txtTotalGenHaber.Appearance = Appearance1
        Me.txtTotalGenHaber.AutoSize = False
        Me.txtTotalGenHaber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtTotalGenHaber.CausesValidation = False
        Me.txtTotalGenHaber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtTotalGenHaber.InputMask = "nnn,nnn,nnn,nnn"
        Me.txtTotalGenHaber.Location = New System.Drawing.Point(305, 6)
        Me.txtTotalGenHaber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalGenHaber.Name = "txtTotalGenHaber"
        Me.txtTotalGenHaber.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTotalGenHaber.ReadOnly = True
        Me.txtTotalGenHaber.Size = New System.Drawing.Size(202, 27)
        Me.txtTotalGenHaber.TabIndex = 470
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(2, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 17)
        Me.Label14.TabIndex = 468
        Me.Label14.Text = "Total General:"
        '
        'txtTotalGenDebe
        '
        Me.txtTotalGenDebe.AllowDrop = True
        Appearance4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance4.BorderColor = System.Drawing.Color.White
        Appearance4.FontData.BoldAsString = "True"
        Appearance4.FontData.SizeInPoints = 12.0!
        Appearance4.TextHAlignAsString = "Right"
        Me.txtTotalGenDebe.Appearance = Appearance4
        Me.txtTotalGenDebe.AutoSize = False
        Me.txtTotalGenDebe.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtTotalGenDebe.CausesValidation = False
        Me.txtTotalGenDebe.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtTotalGenDebe.InputMask = "nnn,nnn,nnn,nnn"
        Me.txtTotalGenDebe.Location = New System.Drawing.Point(101, 6)
        Me.txtTotalGenDebe.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTotalGenDebe.Name = "txtTotalGenDebe"
        Me.txtTotalGenDebe.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtTotalGenDebe.ReadOnly = True
        Me.txtTotalGenDebe.Size = New System.Drawing.Size(202, 27)
        Me.txtTotalGenDebe.TabIndex = 469
        '
        'tbxTotalHaber
        '
        Me.tbxTotalHaber.AllowDrop = True
        Me.tbxTotalHaber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance5.BorderColor = System.Drawing.Color.White
        Appearance5.FontData.BoldAsString = "True"
        Appearance5.FontData.SizeInPoints = 12.0!
        Appearance5.TextHAlignAsString = "Right"
        Me.tbxTotalHaber.Appearance = Appearance5
        Me.tbxTotalHaber.AutoSize = False
        Me.tbxTotalHaber.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotalHaber.CausesValidation = False
        Me.tbxTotalHaber.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotalHaber.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotalHaber.Location = New System.Drawing.Point(835, 6)
        Me.tbxTotalHaber.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxTotalHaber.Name = "tbxTotalHaber"
        Me.tbxTotalHaber.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotalHaber.ReadOnly = True
        Me.tbxTotalHaber.Size = New System.Drawing.Size(202, 27)
        Me.tbxTotalHaber.TabIndex = 467
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(532, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 17)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Totale p/ Mes:"
        '
        'tbxTotakDebe
        '
        Me.tbxTotakDebe.AllowDrop = True
        Me.tbxTotakDebe.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Appearance6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Appearance6.BorderColor = System.Drawing.Color.White
        Appearance6.FontData.BoldAsString = "True"
        Appearance6.FontData.SizeInPoints = 12.0!
        Appearance6.TextHAlignAsString = "Right"
        Me.tbxTotakDebe.Appearance = Appearance6
        Me.tbxTotakDebe.AutoSize = False
        Me.tbxTotakDebe.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.tbxTotakDebe.CausesValidation = False
        Me.tbxTotakDebe.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxTotakDebe.InputMask = "nnn,nnn,nnn,nnn"
        Me.tbxTotakDebe.Location = New System.Drawing.Point(631, 6)
        Me.tbxTotakDebe.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxTotakDebe.Name = "tbxTotakDebe"
        Me.tbxTotakDebe.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxTotakDebe.ReadOnly = True
        Me.tbxTotakDebe.Size = New System.Drawing.Size(202, 27)
        Me.tbxTotakDebe.TabIndex = 467
        '
        'PlancuentasBindingSource
        '
        Me.PlancuentasBindingSource.DataMember = "plancuentas"
        Me.PlancuentasBindingSource.DataSource = Me.DsPlantillasConta
        '
        'PlancuentasTableAdapter
        '
        Me.PlancuentasTableAdapter.ClearBeforeFill = True
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.gbxCuenta
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
        Me.gbxCuenta.HeaderText = "Buscador de Plan de Cuentas"
        Me.gbxCuenta.Location = New System.Drawing.Point(1059, 62)
        Me.gbxCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbxCuenta.Name = "gbxCuenta"
        Me.gbxCuenta.Padding = New System.Windows.Forms.Padding(11, 20, 11, 10)
        '
        '
        '
        Me.gbxCuenta.RootElement.Padding = New System.Windows.Forms.Padding(11, 20, 11, 10)
        Me.gbxCuenta.Size = New System.Drawing.Size(363, 399)
        Me.gbxCuenta.TabIndex = 464
        Me.gbxCuenta.Text = "Buscador de Plan de Cuentas"
        Me.gbxCuenta.ThemeName = "Breeze"
        Me.gbxCuenta.Visible = False
        CType(Me.gbxCuenta.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).Padding = New System.Windows.Forms.Padding(11, 20, 11, 10)
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = "Buscador de Plan de Cuentas"
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.gbxCuenta.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgbPlanCuentas
        '
        Me.dgbPlanCuentas.AllowUserToAddRows = False
        Me.dgbPlanCuentas.AllowUserToDeleteRows = False
        Me.dgbPlanCuentas.AllowUserToResizeRows = False
        Me.dgbPlanCuentas.AutoGenerateColumns = False
        Me.dgbPlanCuentas.BackgroundColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbPlanCuentas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgbPlanCuentas.ColumnHeadersHeight = 35
        Me.dgbPlanCuentas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPLANCUENTA1, Me.NUMPLANCUENTA, Me.DESPLANCUENTA, Me.TIPOCUENTADataGridViewTextBoxColumn, Me.NIVELCUENTADataGridViewTextBoxColumn, Me.ASENTABLEDataGridViewTextBoxColumn, Me.FECGRADataGridViewTextBoxColumn, Me.CODMONEDADataGridViewTextBoxColumn, Me.DESTIPOCUENTADataGridViewTextBoxColumn, Me.CUENTAMADREDataGridViewTextBoxColumn})
        Me.dgbPlanCuentas.DataSource = Me.PlancuentasBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgbPlanCuentas.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgbPlanCuentas.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgbPlanCuentas.Location = New System.Drawing.Point(11, 56)
        Me.dgbPlanCuentas.Name = "dgbPlanCuentas"
        Me.dgbPlanCuentas.ReadOnly = True
        Me.dgbPlanCuentas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgbPlanCuentas.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgbPlanCuentas.RowHeadersVisible = False
        Me.dgbPlanCuentas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgbPlanCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgbPlanCuentas.Size = New System.Drawing.Size(342, 335)
        Me.dgbPlanCuentas.TabIndex = 424
        '
        'CODPLANCUENTA1
        '
        Me.CODPLANCUENTA1.DataPropertyName = "CODPLANCUENTA"
        Me.CODPLANCUENTA1.HeaderText = "CODPLANCUENTA"
        Me.CODPLANCUENTA1.Name = "CODPLANCUENTA1"
        Me.CODPLANCUENTA1.ReadOnly = True
        Me.CODPLANCUENTA1.Visible = False
        '
        'NUMPLANCUENTA
        '
        Me.NUMPLANCUENTA.DataPropertyName = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.HeaderText = "Nro Cuenta"
        Me.NUMPLANCUENTA.Name = "NUMPLANCUENTA"
        Me.NUMPLANCUENTA.ReadOnly = True
        Me.NUMPLANCUENTA.Width = 110
        '
        'DESPLANCUENTA
        '
        Me.DESPLANCUENTA.DataPropertyName = "DESPLANCUENTA"
        Me.DESPLANCUENTA.HeaderText = "Cuenta"
        Me.DESPLANCUENTA.Name = "DESPLANCUENTA"
        Me.DESPLANCUENTA.ReadOnly = True
        Me.DESPLANCUENTA.Width = 220
        '
        'TIPOCUENTADataGridViewTextBoxColumn
        '
        Me.TIPOCUENTADataGridViewTextBoxColumn.DataPropertyName = "TIPOCUENTA"
        Me.TIPOCUENTADataGridViewTextBoxColumn.HeaderText = "TIPOCUENTA"
        Me.TIPOCUENTADataGridViewTextBoxColumn.Name = "TIPOCUENTADataGridViewTextBoxColumn"
        Me.TIPOCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.TIPOCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'NIVELCUENTADataGridViewTextBoxColumn
        '
        Me.NIVELCUENTADataGridViewTextBoxColumn.DataPropertyName = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.HeaderText = "NIVELCUENTA"
        Me.NIVELCUENTADataGridViewTextBoxColumn.Name = "NIVELCUENTADataGridViewTextBoxColumn"
        Me.NIVELCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.NIVELCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'ASENTABLEDataGridViewTextBoxColumn
        '
        Me.ASENTABLEDataGridViewTextBoxColumn.DataPropertyName = "ASENTABLE"
        Me.ASENTABLEDataGridViewTextBoxColumn.HeaderText = "ASENTABLE"
        Me.ASENTABLEDataGridViewTextBoxColumn.Name = "ASENTABLEDataGridViewTextBoxColumn"
        Me.ASENTABLEDataGridViewTextBoxColumn.ReadOnly = True
        Me.ASENTABLEDataGridViewTextBoxColumn.Visible = False
        '
        'FECGRADataGridViewTextBoxColumn
        '
        Me.FECGRADataGridViewTextBoxColumn.DataPropertyName = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.HeaderText = "FECGRA"
        Me.FECGRADataGridViewTextBoxColumn.Name = "FECGRADataGridViewTextBoxColumn"
        Me.FECGRADataGridViewTextBoxColumn.ReadOnly = True
        Me.FECGRADataGridViewTextBoxColumn.Visible = False
        '
        'CODMONEDADataGridViewTextBoxColumn
        '
        Me.CODMONEDADataGridViewTextBoxColumn.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.Name = "CODMONEDADataGridViewTextBoxColumn"
        Me.CODMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMONEDADataGridViewTextBoxColumn.Visible = False
        '
        'DESTIPOCUENTADataGridViewTextBoxColumn
        '
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.DataPropertyName = "DESTIPOCUENTA"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.HeaderText = "DESTIPOCUENTA"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.Name = "DESTIPOCUENTADataGridViewTextBoxColumn"
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.ReadOnly = True
        Me.DESTIPOCUENTADataGridViewTextBoxColumn.Visible = False
        '
        'CUENTAMADREDataGridViewTextBoxColumn
        '
        Me.CUENTAMADREDataGridViewTextBoxColumn.DataPropertyName = "CUENTAMADRE"
        Me.CUENTAMADREDataGridViewTextBoxColumn.HeaderText = "CUENTAMADRE"
        Me.CUENTAMADREDataGridViewTextBoxColumn.Name = "CUENTAMADREDataGridViewTextBoxColumn"
        Me.CUENTAMADREDataGridViewTextBoxColumn.ReadOnly = True
        Me.CUENTAMADREDataGridViewTextBoxColumn.Visible = False
        '
        'tbxBuscarCuenta
        '
        Me.tbxBuscarCuenta.BackColor = System.Drawing.Color.LightGray
        Me.tbxBuscarCuenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxBuscarCuenta.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.tbxBuscarCuenta.Location = New System.Drawing.Point(12, 25)
        Me.tbxBuscarCuenta.Name = "tbxBuscarCuenta"
        Me.tbxBuscarCuenta.Size = New System.Drawing.Size(341, 25)
        Me.tbxBuscarCuenta.TabIndex = 376
        Me.tbxBuscarCuenta.Text = "Buscar..."
        '
        'tbxCodCuenta
        '
        Me.tbxCodCuenta.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxCodCuenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodCuenta.Location = New System.Drawing.Point(45, 246)
        Me.tbxCodCuenta.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxCodCuenta.Name = "tbxCodCuenta"
        Me.tbxCodCuenta.Size = New System.Drawing.Size(69, 27)
        Me.tbxCodCuenta.TabIndex = 3
        '
        'tbxAsientoID
        '
        Me.tbxAsientoID.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxAsientoID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxAsientoID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxAsientoID.Location = New System.Drawing.Point(45, 219)
        Me.tbxAsientoID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbxAsientoID.Name = "tbxAsientoID"
        Me.tbxAsientoID.Size = New System.Drawing.Size(69, 27)
        Me.tbxAsientoID.TabIndex = 3
        '
        'AsientosTableAdapter
        '
        Me.AsientosTableAdapter.ClearBeforeFill = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 654)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.StatusStrip1.Size = New System.Drawing.Size(1059, 22)
        Me.StatusStrip1.TabIndex = 467
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(987, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "F5 - Nuevo / F6 - Editar / F7 - Guardar / F8 - Cancelar  / F9 - Navegar entre Pan" & _
    "eles"
        '
        'Asientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(1059, 676)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbxCuenta)
        Me.Controls.Add(Me.dgvAsiento)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tbxAsientoID)
        Me.Controls.Add(Me.tbxCodCuenta)
        Me.Controls.Add(Me.pnlBuscarAsiento)
        Me.Controls.Add(Me.pnlDetalleAsiento)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Asientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asientos  | Cogent SIG"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbxBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAsientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAsiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AsientosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlantillasConta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlantillasContaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPeriodoFiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPeriodoFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalleAsiento.ResumeLayout(False)
        Me.pnlDetalleAsiento.PerformLayout()
        Me.pnlBuscarAsiento.ResumeLayout(False)
        Me.pnlBuscarAsiento.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PlancuentasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gbxCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxCuenta.ResumeLayout(False)
        Me.gbxCuenta.PerformLayout()
        CType(Me.dgbPlanCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvAsiento As System.Windows.Forms.DataGridView
    Friend WithEvents cbxPeriodoFiscal As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlDetalleAsiento As System.Windows.Forms.Panel
    Friend WithEvents pnlBuscarAsiento As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbxBuscador As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbxComentarios As System.Windows.Forms.TextBox
    Friend WithEvents tbxNroCuenta As System.Windows.Forms.TextBox
    Friend WithEvents tbxNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DsPlantillasContaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsPlantillasConta As ContaExpress.DsPlantillasConta
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsPeriodoFiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsPeriodoFiscal As ContaExpress.DsPeriodoFiscal
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DsPeriodoFiscalTableAdapters.periodofiscalTableAdapter
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbxTotakDebe As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tbxTotalHaber As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents pbxBuscar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAsientos As System.Windows.Forms.PictureBox
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnLimpiarCuentas As System.Windows.Forms.Button
    Friend WithEvents btnFiltrarCuentas As System.Windows.Forms.Button
    Friend WithEvents PlancuentasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PlancuentasTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.plancuentasTableAdapter
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents gbxCuenta As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents dgbPlanCuentas As System.Windows.Forms.DataGridView
    Friend WithEvents tbxBuscarCuenta As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodCuenta As System.Windows.Forms.TextBox
    Friend WithEvents CODPLANCUENTA1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVELCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ASENTABLEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCUENTADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUENTAMADREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbxAsientoID As System.Windows.Forms.TextBox
    Friend WithEvents tbxHaber As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents tbxDebe As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents dttFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rdbNuevoNro As System.Windows.Forms.RadioButton
    Friend WithEvents rdbUltimoNro As System.Windows.Forms.RadioButton
    Friend WithEvents AsientosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AsientosTableAdapter As ContaExpress.DsPlantillasContaTableAdapters.AsientosTableAdapter
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmbAnho As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents txtAsientoNroManual As System.Windows.Forms.TextBox
    Friend WithEvents rdbCargarManual As System.Windows.Forms.RadioButton
    Friend WithEvents txtTotalGenHaber As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTotalGenDebe As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents NUMASIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAASIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETALLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COTIZACIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AsientoID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTED As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTEH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPLANCUENTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPERIODOFISCALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIFERENCIADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
