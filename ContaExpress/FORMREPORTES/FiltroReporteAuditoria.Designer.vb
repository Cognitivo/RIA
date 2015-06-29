<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiltroReporteAuditoria
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
        Dim CheckBoxProperties1 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiltroReporteAuditoria))
        Dim CheckBoxProperties2 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim CheckBoxProperties3 As PresentationControls.CheckBoxProperties = New PresentationControls.CheckBoxProperties()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.lblReporteDescrip = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.CrystalReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlTipo = New System.Windows.Forms.Panel()
        Me.lblTipoComp = New System.Windows.Forms.Label()
        Me.cmbTipo = New PresentationControls.CheckBoxComboBox()
        Me.pnlComprobante = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbComprobante = New PresentationControls.CheckBoxComboBox()
        Me.pnlSucursal = New System.Windows.Forms.Panel()
        Me.cmbSucursal = New PresentationControls.CheckBoxComboBox()
        Me.lblPos7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chbxNuevaVent = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlfechas = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pbxCerrarFiltros = New System.Windows.Forms.PictureBox()
        Me.pnlSinFiltro = New System.Windows.Forms.Panel()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnFiltros = New System.Windows.Forms.Button()
        Me.ProductosGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.ProductosGridView = New System.Windows.Forms.DataGridView()
        Me.TabBuscador = New Telerik.WinControls.UI.RadTabStrip()
        Me.BuscarProductoTextBox = New System.Windows.Forms.TextBox()
        Me.Producto = New Telerik.WinControls.UI.TabItem()
        Me.Remision = New Telerik.WinControls.UI.TabItem()
        Me.RadGridViewDetalleRemisiones = New Telerik.WinControls.UI.RadGridView()
        Me.dgvListaReportes = New System.Windows.Forms.DataGridView()
        Me.TITULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.REFERENCIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PALABRASCLAVE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DsReportesAuditoria = New ContaExpress.DsReportesAuditoria()
        Me.ASUCURSALTableAdapter = New ContaExpress.DsReportesAuditoriaTableAdapters.ASUCURSALTableAdapter()
        Me.AtipocomprobanteTableAdapter = New ContaExpress.DsReportesAuditoriaTableAdapters.ATIPOCOMPROBANTETableAdapter()
        Me.AVentasAprobadasTableAdapter = New ContaExpress.DsReportesAuditoriaTableAdapters.AVentasAprobadasTableAdapter()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlTipo.SuspendLayout()
        Me.pnlComprobante.SuspendLayout()
        Me.pnlSucursal.SuspendLayout()
        Me.pnlfechas.SuspendLayout()
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSinFiltro.SuspendLayout()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ProductosGroupBox.SuspendLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Remision.ContentPanel.SuspendLayout()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DsReportesAuditoria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(372, 6)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaHasta.TabIndex = 1
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke
        Me.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(102, 6)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 0
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(288, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 20)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Hasta Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(265, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 28)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Filtros para:"
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label20.Location = New System.Drawing.Point(3, 517)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(559, 22)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "Nota: Si quiere ver Todos los Datos, simplemente inserte ""%"" en el campo correspo" & _
    "ndiente"
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.Font = New System.Drawing.Font("Segoe UI Semibold", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporte.ForeColor = System.Drawing.Color.DarkOrange
        Me.lblReporte.Location = New System.Drawing.Point(368, 1)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(106, 28)
        Me.lblReporte.TabIndex = 4
        Me.lblReporte.Text = "lblReporte"
        '
        'lblReporteDescrip
        '
        Me.lblReporteDescrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReporteDescrip.ForeColor = System.Drawing.Color.DarkGray
        Me.lblReporteDescrip.Location = New System.Drawing.Point(267, 28)
        Me.lblReporteDescrip.Name = "lblReporteDescrip"
        Me.lblReporteDescrip.Size = New System.Drawing.Size(740, 21)
        Me.lblReporteDescrip.TabIndex = 9
        Me.lblReporteDescrip.Text = "lblReporteDescrip"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Tan
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBig
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(4, 7)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.TabIndex = 460
        Me.PictureBox2.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarTextBox.Location = New System.Drawing.Point(32, 7)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(228, 30)
        Me.BuscarTextBox.TabIndex = 459
        '
        'CrystalReportViewer
        '
        Me.CrystalReportViewer.ActiveViewIndex = -1
        Me.CrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer.DisplayStatusBar = False
        Me.CrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer.Name = "CrystalReportViewer"
        Me.CrystalReportViewer.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer.ShowCloseButton = False
        Me.CrystalReportViewer.ShowGotoPageButton = False
        Me.CrystalReportViewer.ShowGroupTreeButton = False
        Me.CrystalReportViewer.ShowParameterPanelButton = False
        Me.CrystalReportViewer.Size = New System.Drawing.Size(815, 655)
        Me.CrystalReportViewer.TabIndex = 462
        Me.CrystalReportViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlFiltros.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFiltros.Controls.Add(Me.pnlTipo)
        Me.pnlFiltros.Controls.Add(Me.pnlComprobante)
        Me.pnlFiltros.Controls.Add(Me.pnlSucursal)
        Me.pnlFiltros.Controls.Add(Me.Panel1)
        Me.pnlFiltros.Controls.Add(Me.chbxNuevaVent)
        Me.pnlFiltros.Controls.Add(Me.Label7)
        Me.pnlFiltros.Controls.Add(Me.Label20)
        Me.pnlFiltros.Controls.Add(Me.pnlfechas)
        Me.pnlFiltros.Controls.Add(Me.pbxCerrarFiltros)
        Me.pnlFiltros.Controls.Add(Me.pnlSinFiltro)
        Me.pnlFiltros.Controls.Add(Me.btnGenerar)
        Me.pnlFiltros.Location = New System.Drawing.Point(254, 1)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(560, 593)
        Me.pnlFiltros.TabIndex = 466
        '
        'pnlTipo
        '
        Me.pnlTipo.BackColor = System.Drawing.Color.Transparent
        Me.pnlTipo.Controls.Add(Me.lblTipoComp)
        Me.pnlTipo.Controls.Add(Me.cmbTipo)
        Me.pnlTipo.Location = New System.Drawing.Point(5, 96)
        Me.pnlTipo.Name = "pnlTipo"
        Me.pnlTipo.Size = New System.Drawing.Size(551, 39)
        Me.pnlTipo.TabIndex = 490
        '
        'lblTipoComp
        '
        Me.lblTipoComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComp.ForeColor = System.Drawing.Color.Black
        Me.lblTipoComp.Location = New System.Drawing.Point(3, 7)
        Me.lblTipoComp.Name = "lblTipoComp"
        Me.lblTipoComp.Size = New System.Drawing.Size(89, 25)
        Me.lblTipoComp.TabIndex = 3
        Me.lblTipoComp.Text = "Tipo Factura"
        Me.lblTipoComp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbTipo.CheckBoxProperties = CheckBoxProperties1
        Me.cmbTipo.DisplayMemberSingleItem = ""
        Me.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(98, 3)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(440, 33)
        Me.cmbTipo.TabIndex = 488
        '
        'pnlComprobante
        '
        Me.pnlComprobante.BackColor = System.Drawing.Color.Transparent
        Me.pnlComprobante.BackgroundImage = CType(resources.GetObject("pnlComprobante.BackgroundImage"), System.Drawing.Image)
        Me.pnlComprobante.Controls.Add(Me.Label1)
        Me.pnlComprobante.Controls.Add(Me.cmbComprobante)
        Me.pnlComprobante.Location = New System.Drawing.Point(5, 141)
        Me.pnlComprobante.Name = "pnlComprobante"
        Me.pnlComprobante.Size = New System.Drawing.Size(551, 39)
        Me.pnlComprobante.TabIndex = 484
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 25)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Comprobante"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbComprobante
        '
        Me.cmbComprobante.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbComprobante.CheckBoxProperties = CheckBoxProperties2
        Me.cmbComprobante.DisplayMemberSingleItem = ""
        Me.cmbComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComprobante.FormattingEnabled = True
        Me.cmbComprobante.Location = New System.Drawing.Point(98, 3)
        Me.cmbComprobante.Name = "cmbComprobante"
        Me.cmbComprobante.Size = New System.Drawing.Size(440, 33)
        Me.cmbComprobante.TabIndex = 491
        '
        'pnlSucursal
        '
        Me.pnlSucursal.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.pnlSucursal.Controls.Add(Me.cmbSucursal)
        Me.pnlSucursal.Controls.Add(Me.lblPos7)
        Me.pnlSucursal.Location = New System.Drawing.Point(5, 51)
        Me.pnlSucursal.Name = "pnlSucursal"
        Me.pnlSucursal.Size = New System.Drawing.Size(551, 39)
        Me.pnlSucursal.TabIndex = 483
        '
        'cmbSucursal
        '
        Me.cmbSucursal.BackColor = System.Drawing.Color.WhiteSmoke
        CheckBoxProperties3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmbSucursal.CheckBoxProperties = CheckBoxProperties3
        Me.cmbSucursal.DisplayMemberSingleItem = ""
        Me.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.Location = New System.Drawing.Point(98, 3)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(440, 33)
        Me.cmbSucursal.TabIndex = 490
        '
        'lblPos7
        '
        Me.lblPos7.BackColor = System.Drawing.Color.Transparent
        Me.lblPos7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPos7.ForeColor = System.Drawing.Color.Black
        Me.lblPos7.Location = New System.Drawing.Point(3, 7)
        Me.lblPos7.Name = "lblPos7"
        Me.lblPos7.Size = New System.Drawing.Size(89, 25)
        Me.lblPos7.TabIndex = 27
        Me.lblPos7.Text = "Sucursal"
        Me.lblPos7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(573, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(442, 33)
        Me.Panel1.TabIndex = 476
        '
        'chbxNuevaVent
        '
        Me.chbxNuevaVent.BackColor = System.Drawing.Color.Transparent
        Me.chbxNuevaVent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.chbxNuevaVent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chbxNuevaVent.ForeColor = System.Drawing.Color.Black
        Me.chbxNuevaVent.Image = Global.ContaExpress.My.Resources.Resources.new_window
        Me.chbxNuevaVent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chbxNuevaVent.Location = New System.Drawing.Point(358, 12)
        Me.chbxNuevaVent.Name = "chbxNuevaVent"
        Me.chbxNuevaVent.Size = New System.Drawing.Size(154, 16)
        Me.chbxNuevaVent.TabIndex = 475
        Me.chbxNuevaVent.Text = "Abrir en Ventana Nueva"
        Me.chbxNuevaVent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chbxNuevaVent.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label7.Location = New System.Drawing.Point(6, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 25)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Filtros:"
        '
        'pnlfechas
        '
        Me.pnlfechas.BackgroundImage = CType(resources.GetObject("pnlfechas.BackgroundImage"), System.Drawing.Image)
        Me.pnlfechas.Controls.Add(Me.dtpFechaHasta)
        Me.pnlfechas.Controls.Add(Me.Label11)
        Me.pnlfechas.Controls.Add(Me.Label8)
        Me.pnlfechas.Controls.Add(Me.dtpFechaDesde)
        Me.pnlfechas.Location = New System.Drawing.Point(5, 186)
        Me.pnlfechas.Name = "pnlfechas"
        Me.pnlfechas.Size = New System.Drawing.Size(551, 39)
        Me.pnlfechas.TabIndex = 479
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(16, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Desde Fecha"
        '
        'pbxCerrarFiltros
        '
        Me.pbxCerrarFiltros.BackColor = System.Drawing.Color.Transparent
        Me.pbxCerrarFiltros.Image = Global.ContaExpress.My.Resources.Resources.cerrar
        Me.pbxCerrarFiltros.Location = New System.Drawing.Point(516, 0)
        Me.pbxCerrarFiltros.Name = "pbxCerrarFiltros"
        Me.pbxCerrarFiltros.Size = New System.Drawing.Size(40, 46)
        Me.pbxCerrarFiltros.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbxCerrarFiltros.TabIndex = 0
        Me.pbxCerrarFiltros.TabStop = False
        '
        'pnlSinFiltro
        '
        Me.pnlSinFiltro.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlSinFiltro.BackColor = System.Drawing.Color.Transparent
        Me.pnlSinFiltro.Controls.Add(Me.Label22)
        Me.pnlSinFiltro.Location = New System.Drawing.Point(5, 31)
        Me.pnlSinFiltro.Name = "pnlSinFiltro"
        Me.pnlSinFiltro.Size = New System.Drawing.Size(551, 174)
        Me.pnlSinFiltro.TabIndex = 474
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(70, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(413, 22)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "Este Reporte no requiere de Filtros Especiales!"
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnGenerar.BackColor = System.Drawing.Color.GreenYellow
        Me.btnGenerar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnGenerar.Location = New System.Drawing.Point(309, 542)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(246, 42)
        Me.btnGenerar.TabIndex = 486
        Me.btnGenerar.Text = "Generar Reporte"
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'btnFiltros
        '
        Me.btnFiltros.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnFiltros.BackColor = System.Drawing.Color.DarkOrange
        Me.btnFiltros.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltros.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnFiltros.Location = New System.Drawing.Point(977, 7)
        Me.btnFiltros.Name = "btnFiltros"
        Me.btnFiltros.Size = New System.Drawing.Size(102, 30)
        Me.btnFiltros.TabIndex = 487
        Me.btnFiltros.Text = "Filtros"
        Me.btnFiltros.UseVisualStyleBackColor = False
        '
        'ProductosGroupBox
        '
        Me.ProductosGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ProductosGroupBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ProductosGroupBox.Controls.Add(Me.ProductosGridView)
        Me.ProductosGroupBox.Controls.Add(Me.TabBuscador)
        Me.ProductosGroupBox.Controls.Add(Me.BuscarProductoTextBox)
        Me.ProductosGroupBox.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductosGroupBox.FooterImageIndex = -1
        Me.ProductosGroupBox.FooterImageKey = ""
        Me.ProductosGroupBox.HeaderImageIndex = -1
        Me.ProductosGroupBox.HeaderImageKey = ""
        Me.ProductosGroupBox.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.HeaderText = "Búsqueda de Productos"
        Me.ProductosGroupBox.Location = New System.Drawing.Point(430, 34)
        Me.ProductosGroupBox.Name = "ProductosGroupBox"
        Me.ProductosGroupBox.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.ProductosGroupBox.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.ProductosGroupBox.RootElement.AngleTransform = 0.0!
        Me.ProductosGroupBox.RootElement.FlipText = False
        Me.ProductosGroupBox.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.ProductosGroupBox.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.ProductosGroupBox.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.ProductosGroupBox.RootElement.Text = Nothing
        Me.ProductosGroupBox.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.ProductosGroupBox.Size = New System.Drawing.Size(568, 529)
        Me.ProductosGroupBox.TabIndex = 489
        Me.ProductosGroupBox.Text = "Búsqueda de Productos"
        Me.ProductosGroupBox.ThemeName = "Breeze"
        Me.ProductosGroupBox.Visible = False
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Text = "Búsqueda de Productos"
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Font = New System.Drawing.Font("Arial", 10.0!)
        CType(Me.ProductosGroupBox.GetChildAt(0).GetChildAt(1).GetChildAt(2).GetChildAt(1), Telerik.WinControls.Primitives.TextPrimitive).Alignment = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductosGridView
        '
        Me.ProductosGridView.ColumnHeadersHeight = 30
        Me.ProductosGridView.Location = New System.Drawing.Point(10, 55)
        Me.ProductosGridView.Name = "ProductosGridView"
        Me.ProductosGridView.RowHeadersVisible = False
        Me.ProductosGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ProductosGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ProductosGridView.Size = New System.Drawing.Size(548, 461)
        Me.ProductosGridView.TabIndex = 378
        '
        'TabBuscador
        '
        Me.TabBuscador.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.TabBuscador.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.TabBuscador.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TabBuscador.Location = New System.Drawing.Point(723, 28)
        Me.TabBuscador.Name = "TabBuscador"
        '
        '
        '
        Me.TabBuscador.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.TabBuscador.RootElement.AngleTransform = 0.0!
        Me.TabBuscador.RootElement.FlipText = False
        Me.TabBuscador.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.TabBuscador.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.TabBuscador.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.TabBuscador.RootElement.Text = Nothing
        Me.TabBuscador.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.TabBuscador.ScrollOffsetStep = 5
        Me.TabBuscador.Size = New System.Drawing.Size(680, 554)
        Me.TabBuscador.TabIndex = 377
        Me.TabBuscador.TabScrollButtonsPosition = Telerik.WinControls.UI.TabScrollButtonsPosition.RightBottom
        Me.TabBuscador.Text = "Productos"
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).TabScrollButtonsPosition = Telerik.WinControls.UI.TabScrollButtonsPosition.RightBottom
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).StretchBaseMode = Telerik.WinControls.UI.TabBaseStretchMode.StretchToRemainingSpace
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).ForeColor = System.Drawing.Color.GhostWhite
        CType(Me.TabBuscador.GetChildAt(0), Telerik.WinControls.UI.RadTabStripElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).ZIndex = 739
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.TabLayoutPanel).Margin = New System.Windows.Forms.Padding(0, 2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).ZIndex = 6
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).Margin = New System.Windows.Forms.Padding(0, -2, 0, 0)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.FillPrimitive).MinSize = New System.Drawing.Size(0, 7)
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor2 = System.Drawing.Color.GhostWhite
        CType(Me.TabBuscador.GetChildAt(0).GetChildAt(0).GetChildAt(1).GetChildAt(0), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.GhostWhite
        '
        'BuscarProductoTextBox
        '
        Me.BuscarProductoTextBox.BackColor = System.Drawing.Color.LightGray
        Me.BuscarProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BuscarProductoTextBox.Font = New System.Drawing.Font("Arial", 16.0!)
        Me.BuscarProductoTextBox.Location = New System.Drawing.Point(10, 26)
        Me.BuscarProductoTextBox.Name = "BuscarProductoTextBox"
        Me.BuscarProductoTextBox.Size = New System.Drawing.Size(548, 25)
        Me.BuscarProductoTextBox.TabIndex = 376
        Me.BuscarProductoTextBox.Text = "Buscar..."
        '
        'Producto
        '
        Me.Producto.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.Producto.AngleTransform = 0.0!
        '
        'Producto.ContentPanel
        '
        Me.Producto.ContentPanel.BackColor = System.Drawing.Color.White
        Me.Producto.ContentPanel.CausesValidation = True
        Me.Producto.ContentPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Producto.ContentPanel.ForeColor = System.Drawing.Color.GhostWhite
        Me.Producto.ContentPanel.Location = New System.Drawing.Point(1, 29)
        Me.Producto.ContentPanel.Size = New System.Drawing.Size(678, 524)
        Me.Producto.FlipText = False
        Me.Producto.Image = Nothing
        Me.Producto.ImageIndex = -1
        Me.Producto.ImageKey = ""
        Me.Producto.IsSelected = True
        Me.Producto.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Producto.Name = "Producto"
        Me.Producto.Padding = New System.Windows.Forms.Padding(0)
        Me.Producto.RightToLeft = False
        Me.Producto.StretchHorizontally = False
        Me.Producto.StringAlignment = System.Drawing.StringAlignment.Near
        Me.Producto.Text = "Producto"
        Me.Producto.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Producto.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        '
        'Remision
        '
        Me.Remision.Alignment = System.Drawing.ContentAlignment.BottomLeft
        Me.Remision.AngleTransform = 0.0!
        '
        'Remision.ContentPanel
        '
        Me.Remision.ContentPanel.BackColor = System.Drawing.Color.White
        Me.Remision.ContentPanel.CausesValidation = True
        Me.Remision.ContentPanel.Controls.Add(Me.RadGridViewDetalleRemisiones)
        Me.Remision.ContentPanel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Remision.ContentPanel.ForeColor = System.Drawing.Color.GhostWhite
        Me.Remision.ContentPanel.Location = New System.Drawing.Point(1, 29)
        Me.Remision.ContentPanel.Size = New System.Drawing.Size(678, 524)
        Me.Remision.FlipText = False
        Me.Remision.Image = Nothing
        Me.Remision.ImageIndex = -1
        Me.Remision.ImageKey = ""
        Me.Remision.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.Remision.Name = "Remision"
        Me.Remision.Padding = New System.Windows.Forms.Padding(0)
        Me.Remision.RightToLeft = False
        Me.Remision.StretchHorizontally = False
        Me.Remision.StringAlignment = System.Drawing.StringAlignment.Near
        Me.Remision.Text = "Remisión"
        Me.Remision.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        Me.Remision.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.Remision.Visibility = Telerik.WinControls.ElementVisibility.Hidden
        '
        'RadGridViewDetalleRemisiones
        '
        Me.RadGridViewDetalleRemisiones.BackColor = System.Drawing.Color.Transparent
        Me.RadGridViewDetalleRemisiones.Cursor = System.Windows.Forms.Cursors.Default
        Me.RadGridViewDetalleRemisiones.EnableHotTracking = False
        Me.RadGridViewDetalleRemisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.RadGridViewDetalleRemisiones.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RadGridViewDetalleRemisiones.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RadGridViewDetalleRemisiones.Location = New System.Drawing.Point(5, 12)
        '
        '
        '
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.AllowAddNewRow = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.FieldAlias = "NUMENVIO"
        GridViewTextBoxColumn1.FieldName = "NUMENVIO"
        GridViewTextBoxColumn1.HeaderText = "Nro. de Remisión"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.UniqueName = "NUMENVIO"
        GridViewTextBoxColumn1.Width = 100
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CANTIDAD"
        GridViewDecimalColumn1.FieldName = "CANTIDAD"
        GridViewDecimalColumn1.HeaderText = "Cantidad"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.UniqueName = "CANTIDAD"
        GridViewDecimalColumn1.Width = 100
        GridViewTextBoxColumn2.FieldName = "PRODUCTO"
        GridViewTextBoxColumn2.HeaderText = "Producto"
        GridViewTextBoxColumn2.UniqueName = "PRODUCTO"
        GridViewTextBoxColumn2.Width = 350
        GridViewTextBoxColumn3.FieldAlias = "PRECIO"
        GridViewTextBoxColumn3.FieldName = "PRECIO"
        GridViewTextBoxColumn3.HeaderText = "Precio"
        GridViewTextBoxColumn3.UniqueName = "PRECIO"
        GridViewTextBoxColumn3.Width = 100
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "CODPRODUCTO"
        GridViewDecimalColumn2.FieldName = "CODPRODUCTO"
        GridViewDecimalColumn2.HeaderText = "CODPRODUCTO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODPRODUCTO"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODVENTA"
        GridViewDecimalColumn3.FieldName = "CODVENTA"
        GridViewDecimalColumn3.HeaderText = "CODVENTA"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODVENTA"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODCODIGO"
        GridViewDecimalColumn4.FieldName = "CODCODIGO"
        GridViewDecimalColumn4.HeaderText = "CODCODIGO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODCODIGO"
        GridViewDecimalColumn5.DataType = GetType(Decimal)
        GridViewDecimalColumn5.FieldAlias = "CODCOMBO"
        GridViewDecimalColumn5.FieldName = "CODCOMBO"
        GridViewDecimalColumn5.HeaderText = "CODCOMBO"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "CODCOMBO"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldAlias = "CODCLIENTE"
        GridViewDecimalColumn6.FieldName = "CODCLIENTE"
        GridViewDecimalColumn6.HeaderText = "CODCLIENTE"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "CODCLIENTE"
        GridViewDecimalColumn7.DataType = GetType(Decimal)
        GridViewDecimalColumn7.FieldAlias = "CODENVIODETALLE"
        GridViewDecimalColumn7.FieldName = "CODENVIODETALLE"
        GridViewDecimalColumn7.HeaderText = "CODENVIODETALLE"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.UniqueName = "CODENVIODETALLE"
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn7)
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.EnableFiltering = True
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.EnableGrouping = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.ShowFilteringRow = False
        Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.RadGridViewDetalleRemisiones.Name = "RadGridViewDetalleRemisiones"
        Me.RadGridViewDetalleRemisiones.ReadOnly = True
        Me.RadGridViewDetalleRemisiones.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.RadGridViewDetalleRemisiones.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadGridViewDetalleRemisiones.RootElement.AngleTransform = 0.0!
        Me.RadGridViewDetalleRemisiones.RootElement.FlipText = False
        Me.RadGridViewDetalleRemisiones.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadGridViewDetalleRemisiones.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadGridViewDetalleRemisiones.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadGridViewDetalleRemisiones.RootElement.Text = Nothing
        Me.RadGridViewDetalleRemisiones.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadGridViewDetalleRemisiones.ShowGroupPanel = False
        Me.RadGridViewDetalleRemisiones.Size = New System.Drawing.Size(659, 504)
        Me.RadGridViewDetalleRemisiones.TabIndex = 261
        '
        'dgvListaReportes
        '
        Me.dgvListaReportes.AllowUserToDeleteRows = False
        Me.dgvListaReportes.AllowUserToOrderColumns = True
        Me.dgvListaReportes.AllowUserToResizeColumns = False
        Me.dgvListaReportes.AllowUserToResizeRows = False
        Me.dgvListaReportes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvListaReportes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvListaReportes.BackgroundColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaReportes.ColumnHeadersHeight = 35
        Me.dgvListaReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TITULO, Me.REFERENCIA, Me.PALABRASCLAVE})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListaReportes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvListaReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvListaReportes.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.dgvListaReportes.Location = New System.Drawing.Point(0, 0)
        Me.dgvListaReportes.MultiSelect = False
        Me.dgvListaReportes.Name = "dgvListaReportes"
        Me.dgvListaReportes.ReadOnly = True
        Me.dgvListaReportes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvListaReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvListaReportes.RowHeadersVisible = False
        Me.dgvListaReportes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvListaReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaReportes.Size = New System.Drawing.Size(260, 655)
        Me.dgvListaReportes.TabIndex = 490
        '
        'TITULO
        '
        Me.TITULO.HeaderText = "Lista de Reportes"
        Me.TITULO.Name = "TITULO"
        Me.TITULO.ReadOnly = True
        '
        'REFERENCIA
        '
        Me.REFERENCIA.HeaderText = "REFERENCIA"
        Me.REFERENCIA.Name = "REFERENCIA"
        Me.REFERENCIA.ReadOnly = True
        Me.REFERENCIA.Visible = False
        '
        'PALABRASCLAVE
        '
        Me.PALABRASCLAVE.HeaderText = "PALABRASCLAVE"
        Me.PALABRASCLAVE.Name = "PALABRASCLAVE"
        Me.PALABRASCLAVE.ReadOnly = True
        Me.PALABRASCLAVE.Visible = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(1, 43)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvListaReportes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlFiltros)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CrystalReportViewer)
        Me.SplitContainer1.Size = New System.Drawing.Size(1079, 655)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 491
        '
        'DsReportesAuditoria
        '
        Me.DsReportesAuditoria.DataSetName = "DsReportesAuditoria"
        Me.DsReportesAuditoria.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ASUCURSALTableAdapter
        '
        Me.ASUCURSALTableAdapter.ClearBeforeFill = True
        '
        'AtipocomprobanteTableAdapter
        '
        Me.AtipocomprobanteTableAdapter.ClearBeforeFill = True
        '
        'AVentasAprobadasTableAdapter
        '
        Me.AVentasAprobadasTableAdapter.ClearBeforeFill = True
        '
        'FiltroReporteAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1081, 698)
        Me.Controls.Add(Me.btnFiltros)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.lblReporteDescrip)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProductosGroupBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(5000, 900)
        Me.MinimumSize = New System.Drawing.Size(863, 676)
        Me.Name = "FiltroReporteAuditoria"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Auditoria  | Cogent SIG"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlFiltros.PerformLayout()
        Me.pnlTipo.ResumeLayout(False)
        Me.pnlComprobante.ResumeLayout(False)
        Me.pnlSucursal.ResumeLayout(False)
        Me.pnlfechas.ResumeLayout(False)
        CType(Me.pbxCerrarFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSinFiltro.ResumeLayout(False)
        Me.pnlSinFiltro.PerformLayout()
        CType(Me.ProductosGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ProductosGroupBox.ResumeLayout(False)
        Me.ProductosGroupBox.PerformLayout()
        CType(Me.ProductosGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Remision.ContentPanel.ResumeLayout(False)
        CType(Me.RadGridViewDetalleRemisiones.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGridViewDetalleRemisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DsReportesAuditoria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIARIORESUMENCAJATableAdapter As ContaExpress.DsReporteVentasTableAdapters.DIARIORESUMENCAJATableAdapter
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents lblReporteDescrip As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CompraMovimientoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents CrystalReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pbxCerrarFiltros As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPos7 As System.Windows.Forms.Label
    Friend WithEvents pnlSinFiltro As System.Windows.Forms.Panel
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents chbxNuevaVent As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlfechas As System.Windows.Forms.Panel
    Friend WithEvents pnlComprobante As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlSucursal As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnFiltros As System.Windows.Forms.Button
    Friend WithEvents ProductosGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents TabBuscador As Telerik.WinControls.UI.RadTabStrip
    Friend WithEvents Producto As Telerik.WinControls.UI.TabItem
    Friend WithEvents Remision As Telerik.WinControls.UI.TabItem
    Friend WithEvents RadGridViewDetalleRemisiones As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BuscarProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProductosGridView As System.Windows.Forms.DataGridView
    Friend WithEvents dgvListaReportes As System.Windows.Forms.DataGridView
    Friend WithEvents TITULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents REFERENCIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PALABRASCLAVE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmbComprobante As PresentationControls.CheckBoxComboBox
    Friend WithEvents cmbSucursal As PresentationControls.CheckBoxComboBox
    Friend WithEvents pnlTipo As System.Windows.Forms.Panel
    Friend WithEvents lblTipoComp As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As PresentationControls.CheckBoxComboBox
    Friend WithEvents DsReportesAuditoria As ContaExpress.DsReportesAuditoria
    Friend WithEvents ASUCURSALTableAdapter As ContaExpress.DsReportesAuditoriaTableAdapters.ASUCURSALTableAdapter
    Friend WithEvents AtipocomprobanteTableAdapter As ContaExpress.DsReportesAuditoriaTableAdapters.ATIPOCOMPROBANTETableAdapter
    Friend WithEvents AVentasAprobadasTableAdapter As ContaExpress.DsReportesAuditoriaTableAdapters.AVentasAprobadasTableAdapter
    'Friend WithEvents CompraMovimientoTableAdapter As ContaExpress.DsReporteVentasTableAdapters.CompraMovimientoTableAdapter
End Class
