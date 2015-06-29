<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaDeProduccion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlanillaDeProduccion))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgwOrdenProduccion = New System.Windows.Forms.DataGridView()
        Me.FECHADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGOLOTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PLANILLAPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPlanilladeProduccion = New ContaExpress.dsPlanilladeProduccion()
        Me.CmbAño = New Telerik.WinControls.UI.RadComboBox()
        Me.BtnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmbMes = New Telerik.WinControls.UI.RadComboBox()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.lblCostoTotal = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdOT = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxProductoReceta = New System.Windows.Forms.ComboBox()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RadLabel12 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.tbxCantidadMateriaPrima = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.cbxCodigo = New System.Windows.Forms.ComboBox()
        Me.CODIGOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxCodCodigo = New System.Windows.Forms.TextBox()
        Me.btnEliminarProducto = New System.Windows.Forms.Button()
        Me.DesProductoTextBox = New System.Windows.Forms.TextBox()
        Me.dgwOPDetalle = New System.Windows.Forms.DataGridView()
        Me.IDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventoGrilla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_PLANILLAPRODUCCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADPRODUCIDA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODPRODUCTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAPRODREAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_ORDENTRABAJO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUCURSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPOPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.txtCodProductoMP = New System.Windows.Forms.TextBox()
        Me.TotalIvaVentaMaskedEdit = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.pnlCabecera = New System.Windows.Forms.Panel()
        Me.tbxCantidadNeto = New System.Windows.Forms.TextBox()
        Me.RadLabel15 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel16 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel13 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel14 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel10 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel11 = New Telerik.WinControls.UI.RadLabel()
        Me.tbxCantidadAveriado = New System.Windows.Forms.TextBox()
        Me.RadLabel8 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxSucursal = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxCantidadAProducir = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.cbxCombo = New System.Windows.Forms.ComboBox()
        Me.COMBOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cbxOrdenProduccion = New System.Windows.Forms.ComboBox()
        Me.ORDENPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tbxIdOrdenProduccion = New System.Windows.Forms.TextBox()
        Me.txtOBS = New System.Windows.Forms.TextBox()
        Me.RadLabel7 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel5 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgwMovProducto = New System.Windows.Forms.DataGridView()
        Me.CODMOVIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODCODIGODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODDEPOSITODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODULOTRANSIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STOCKDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CONCEPTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COSTEABLEDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TIPOPRODUCCIONDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NROMOVIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOVPRODUCTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PLANILLAPRODUCCIONTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.PLANILLAPRODUCCIONTableAdapter()
        Me.ORDENPRODUCCIONTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.ORDENPRODUCCIONTableAdapter()
        Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.PLANILLADEDEPRODUCCIONDETALLETableAdapter()
        Me.COMBOSTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.COMBOSTableAdapter()
        Me.PRODUCTOSTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.PRODUCTOSTableAdapter()
        Me.CODIGOSTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.CODIGOSTableAdapter()
        Me.MOVPRODUCTOTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.MOVPRODUCTOTableAdapter()
        Me.SUCURSALTableAdapter = New ContaExpress.dsPlanilladeProduccionTableAdapters.SUCURSALTableAdapter()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgwOrdenProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLANILLAPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPlanilladeProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetalle.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwOPDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCabecera.SuspendLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadLabel15.SuspendLayout()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadLabel13.SuspendLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadLabel10.SuspendLayout()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COMBOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwMovProducto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MOVPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgwOrdenProduccion)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbAño)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BtnFiltro)
        Me.SplitContainer1.Panel1.Controls.Add(Me.BuscarTextBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CmbMes)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.SplitContainer1.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetalle)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlCabecera)
        Me.SplitContainer1.Size = New System.Drawing.Size(934, 667)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 475
        '
        'dgwOrdenProduccion
        '
        Me.dgwOrdenProduccion.AllowUserToAddRows = False
        Me.dgwOrdenProduccion.AllowUserToDeleteRows = False
        Me.dgwOrdenProduccion.AllowUserToResizeRows = False
        Me.dgwOrdenProduccion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwOrdenProduccion.AutoGenerateColumns = False
        Me.dgwOrdenProduccion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwOrdenProduccion.BackgroundColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwOrdenProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwOrdenProduccion.ColumnHeadersHeight = 35
        Me.dgwOrdenProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHADataGridViewTextBoxColumn, Me.CODIGOLOTEDataGridViewTextBoxColumn, Me.IDDataGridViewTextBoxColumn, Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn})
        Me.dgwOrdenProduccion.DataSource = Me.PLANILLAPRODUCCIONBindingSource
        Me.dgwOrdenProduccion.Location = New System.Drawing.Point(-1, 69)
        Me.dgwOrdenProduccion.Name = "dgwOrdenProduccion"
        Me.dgwOrdenProduccion.RowHeadersVisible = False
        Me.dgwOrdenProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwOrdenProduccion.Size = New System.Drawing.Size(232, 598)
        Me.dgwOrdenProduccion.TabIndex = 496
        '
        'FECHADataGridViewTextBoxColumn
        '
        Me.FECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA"
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHADataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.FECHADataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHADataGridViewTextBoxColumn.Name = "FECHADataGridViewTextBoxColumn"
        '
        'CODIGOLOTEDataGridViewTextBoxColumn
        '
        Me.CODIGOLOTEDataGridViewTextBoxColumn.DataPropertyName = "CODIGOLOTE"
        Me.CODIGOLOTEDataGridViewTextBoxColumn.FillWeight = 140.0!
        Me.CODIGOLOTEDataGridViewTextBoxColumn.HeaderText = "Codigo Produccion"
        Me.CODIGOLOTEDataGridViewTextBoxColumn.Name = "CODIGOLOTEDataGridViewTextBoxColumn"
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'IDORDENPRODUCCIONDataGridViewTextBoxColumn
        '
        Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn.DataPropertyName = "ID_ORDENPRODUCCION"
        Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn.HeaderText = "ID_ORDENPRODUCCION"
        Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn.Name = "IDORDENPRODUCCIONDataGridViewTextBoxColumn"
        Me.IDORDENPRODUCCIONDataGridViewTextBoxColumn.Visible = False
        '
        'PLANILLAPRODUCCIONBindingSource
        '
        Me.PLANILLAPRODUCCIONBindingSource.DataMember = "PLANILLAPRODUCCION"
        Me.PLANILLAPRODUCCIONBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'DsPlanilladeProduccion
        '
        Me.DsPlanilladeProduccion.DataSetName = "dsPlanilladeProduccion"
        Me.DsPlanilladeProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CmbAño
        '
        Me.CmbAño.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAño.BackColor = System.Drawing.Color.White
        Me.CmbAño.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.Location = New System.Drawing.Point(97, 40)
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
        Me.CmbAño.Size = New System.Drawing.Size(82, 26)
        Me.CmbAño.TabIndex = 496
        Me.CmbAño.TabStop = False
        Me.CmbAño.ThemeName = "Breeze"
        CType(Me.CmbAño.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'BtnFiltro
        '
        Me.BtnFiltro.AllowDrop = True
        Me.BtnFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltro.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnFiltro.Location = New System.Drawing.Point(181, 40)
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
        Me.BtnFiltro.Size = New System.Drawing.Size(48, 26)
        Me.BtnFiltro.TabIndex = 494
        Me.BtnFiltro.Text = "Filtrar"
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuscarTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(32, 0)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(199, 35)
        Me.BuscarTextBox.TabIndex = 413
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.Location = New System.Drawing.Point(-2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 35)
        Me.PictureBox1.TabIndex = 453
        Me.PictureBox1.TabStop = False
        '
        'CmbMes
        '
        Me.CmbMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.CmbMes.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbMes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbMes.Location = New System.Drawing.Point(2, 40)
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
        Me.CmbMes.Size = New System.Drawing.Size(92, 26)
        Me.CmbMes.TabIndex = 495
        Me.CmbMes.TabStop = False
        Me.CmbMes.ThemeName = "Breeze"
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(1), Telerik.WinControls.Primitives.BorderPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(253, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        CType(Me.CmbMes.GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetalle.BackColor = System.Drawing.Color.LightGray
        Me.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetalle.Controls.Add(Me.TabControl1)
        Me.pnlDetalle.Controls.Add(Me.txtCodProductoMP)
        Me.pnlDetalle.Controls.Add(Me.TotalIvaVentaMaskedEdit)
        Me.pnlDetalle.Location = New System.Drawing.Point(3, 191)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(691, 471)
        Me.pnlDetalle.TabIndex = 470
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TabControl1.Location = New System.Drawing.Point(3, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(685, 461)
        Me.TabControl1.TabIndex = 515
        '
        'TabPage1
        '
        Me.TabPage1.AutoScroll = True
        Me.TabPage1.BackColor = System.Drawing.Color.LightGray
        Me.TabPage1.Controls.Add(Me.lblCostoTotal)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtIdOT)
        Me.TabPage1.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPage1.Controls.Add(Me.tbxCodCodigo)
        Me.TabPage1.Controls.Add(Me.btnEliminarProducto)
        Me.TabPage1.Controls.Add(Me.DesProductoTextBox)
        Me.TabPage1.Controls.Add(Me.dgwOPDetalle)
        Me.TabPage1.Controls.Add(Me.btnAgregar)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(677, 429)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Productos a Producir"
        '
        'lblCostoTotal
        '
        Me.lblCostoTotal.AutoSize = True
        Me.lblCostoTotal.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.lblCostoTotal.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblCostoTotal.Location = New System.Drawing.Point(506, 398)
        Me.lblCostoTotal.Name = "lblCostoTotal"
        Me.lblCostoTotal.Size = New System.Drawing.Size(0, 28)
        Me.lblCostoTotal.TabIndex = 527
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(388, 398)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 28)
        Me.Label1.TabIndex = 526
        Me.Label1.Text = "Costo Total :"
        '
        'txtIdOT
        '
        Me.txtIdOT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIdOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtIdOT.Location = New System.Drawing.Point(2130, 201)
        Me.txtIdOT.Multiline = True
        Me.txtIdOT.Name = "txtIdOT"
        Me.txtIdOT.Size = New System.Drawing.Size(35, 26)
        Me.txtIdOT.TabIndex = 524
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel3.ColumnCount = 6
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.18109!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.609658!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.609658!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.80282!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.609658!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.19316!))
        Me.TableLayoutPanel3.Controls.Add(Me.RadLabel1, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxProductoReceta, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.RadLabel12, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.RadLabel4, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.tbxCantidadMateriaPrima, 5, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxCodigo, 3, 1)
        Me.TableLayoutPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.55319!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.44681!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(497, 51)
        Me.TableLayoutPanel3.TabIndex = 498
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Location = New System.Drawing.Point(165, 3)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel1.RootElement.AngleTransform = 0.0!
        Me.RadLabel1.RootElement.FlipText = False
        Me.RadLabel1.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel1.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel1.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel1.RootElement.Text = Nothing
        Me.RadLabel1.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel1.Size = New System.Drawing.Size(82, 15)
        Me.RadLabel1.TabIndex = 430
        Me.RadLabel1.Text = "Cód. Producto :"
        '
        'cbxProductoReceta
        '
        Me.cbxProductoReceta.DataSource = Me.PRODUCTOSBindingSource
        Me.cbxProductoReceta.DisplayMember = "DESPRODUCTO"
        Me.cbxProductoReceta.FormattingEnabled = True
        Me.cbxProductoReceta.Location = New System.Drawing.Point(3, 24)
        Me.cbxProductoReceta.Name = "cbxProductoReceta"
        Me.cbxProductoReceta.Size = New System.Drawing.Size(142, 21)
        Me.cbxProductoReceta.TabIndex = 522
        Me.cbxProductoReceta.ValueMember = "CODPRODUCTO"
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'RadLabel12
        '
        Me.RadLabel12.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel12.Location = New System.Drawing.Point(3, 3)
        Me.RadLabel12.Name = "RadLabel12"
        '
        '
        '
        Me.RadLabel12.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel12.RootElement.AngleTransform = 0.0!
        Me.RadLabel12.RootElement.FlipText = False
        Me.RadLabel12.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel12.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel12.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel12.RootElement.Text = Nothing
        Me.RadLabel12.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel12.Size = New System.Drawing.Size(77, 15)
        Me.RadLabel12.TabIndex = 429
        Me.RadLabel12.Text = "Materia Prima:"
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Location = New System.Drawing.Point(338, 3)
        Me.RadLabel4.Name = "RadLabel4"
        '
        '
        '
        Me.RadLabel4.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel4.RootElement.AngleTransform = 0.0!
        Me.RadLabel4.RootElement.FlipText = False
        Me.RadLabel4.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel4.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel4.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel4.RootElement.Text = Nothing
        Me.RadLabel4.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel4.Size = New System.Drawing.Size(50, 15)
        Me.RadLabel4.TabIndex = 506
        Me.RadLabel4.Text = "Cantidad"
        '
        'tbxCantidadMateriaPrima
        '
        Me.tbxCantidadMateriaPrima.AllowDrop = True
        Appearance2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Appearance2.BorderColor = System.Drawing.Color.White
        Appearance2.FontData.BoldAsString = "False"
        Appearance2.FontData.SizeInPoints = 12.0!
        Appearance2.TextHAlignAsString = "Right"
        Me.tbxCantidadMateriaPrima.Appearance = Appearance2
        Me.tbxCantidadMateriaPrima.AutoSize = False
        Me.tbxCantidadMateriaPrima.CausesValidation = False
        Me.tbxCantidadMateriaPrima.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.tbxCantidadMateriaPrima.InputMask = "nnn,nnn,nnn,nnn.nn"
        Me.tbxCantidadMateriaPrima.Location = New System.Drawing.Point(338, 24)
        Me.tbxCantidadMateriaPrima.Name = "tbxCantidadMateriaPrima"
        Me.tbxCantidadMateriaPrima.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.tbxCantidadMateriaPrima.Size = New System.Drawing.Size(137, 24)
        Me.tbxCantidadMateriaPrima.TabIndex = 505
        '
        'cbxCodigo
        '
        Me.cbxCodigo.DataSource = Me.CODIGOSBindingSource
        Me.cbxCodigo.DisplayMember = "CODIGO"
        Me.cbxCodigo.FormattingEnabled = True
        Me.cbxCodigo.Location = New System.Drawing.Point(165, 24)
        Me.cbxCodigo.Name = "cbxCodigo"
        Me.cbxCodigo.Size = New System.Drawing.Size(142, 21)
        Me.cbxCodigo.TabIndex = 523
        Me.cbxCodigo.ValueMember = "CODCODIGO"
        '
        'CODIGOSBindingSource
        '
        Me.CODIGOSBindingSource.DataMember = "CODIGOS"
        Me.CODIGOSBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'tbxCodCodigo
        '
        Me.tbxCodCodigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCodCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodCodigo.Enabled = False
        Me.tbxCodCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.tbxCodCodigo.Location = New System.Drawing.Point(1278, 201)
        Me.tbxCodCodigo.Multiline = True
        Me.tbxCodCodigo.Name = "tbxCodCodigo"
        Me.tbxCodCodigo.Size = New System.Drawing.Size(27, 14)
        Me.tbxCodCodigo.TabIndex = 521
        '
        'btnEliminarProducto
        '
        Me.btnEliminarProducto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEliminarProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.btnEliminarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEliminarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnEliminarProducto.Location = New System.Drawing.Point(593, 22)
        Me.btnEliminarProducto.Name = "btnEliminarProducto"
        Me.btnEliminarProducto.Size = New System.Drawing.Size(63, 27)
        Me.btnEliminarProducto.TabIndex = 497
        Me.btnEliminarProducto.Text = "Eliminar"
        Me.btnEliminarProducto.UseVisualStyleBackColor = False
        '
        'DesProductoTextBox
        '
        Me.DesProductoTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DesProductoTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DesProductoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesProductoTextBox.CausesValidation = False
        Me.DesProductoTextBox.Enabled = False
        Me.DesProductoTextBox.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.DesProductoTextBox.Location = New System.Drawing.Point(5, 52)
        Me.DesProductoTextBox.Name = "DesProductoTextBox"
        Me.DesProductoTextBox.Size = New System.Drawing.Size(669, 27)
        Me.DesProductoTextBox.TabIndex = 499
        '
        'dgwOPDetalle
        '
        Me.dgwOPDetalle.AllowUserToAddRows = False
        Me.dgwOPDetalle.AllowUserToDeleteRows = False
        Me.dgwOPDetalle.AllowUserToResizeRows = False
        Me.dgwOPDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwOPDetalle.AutoGenerateColumns = False
        Me.dgwOPDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwOPDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgwOPDetalle.ColumnHeadersHeight = 35
        Me.dgwOPDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn1, Me.EventoGrilla, Me.ID_PLANILLAPRODUCCION, Me.CODIGO, Me.CODCODIGO, Me.CANTIDADPRODUCIDA, Me.CODPRODUCTO, Me.COSTO, Me.CANTIDAPRODREAL, Me.ID_ORDENTRABAJO, Me.CODSUCURSAL, Me.TIPOPRODUCTODataGridViewTextBoxColumn})
        Me.dgwOPDetalle.DataSource = Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource
        Me.dgwOPDetalle.Location = New System.Drawing.Point(7, 85)
        Me.dgwOPDetalle.Name = "dgwOPDetalle"
        Me.dgwOPDetalle.ReadOnly = True
        Me.dgwOPDetalle.RowHeadersVisible = False
        Me.dgwOPDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwOPDetalle.Size = New System.Drawing.Size(666, 306)
        Me.dgwOPDetalle.TabIndex = 523
        '
        'IDDataGridViewTextBoxColumn1
        '
        Me.IDDataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn1.Name = "IDDataGridViewTextBoxColumn1"
        Me.IDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn1.Visible = False
        '
        'EventoGrilla
        '
        Me.EventoGrilla.HeaderText = "EventoGrilla"
        Me.EventoGrilla.Name = "EventoGrilla"
        Me.EventoGrilla.ReadOnly = True
        Me.EventoGrilla.Visible = False
        '
        'ID_PLANILLAPRODUCCION
        '
        Me.ID_PLANILLAPRODUCCION.DataPropertyName = "ID_PLANILLAPRODUCCION"
        Me.ID_PLANILLAPRODUCCION.HeaderText = "ID_PLANILLAPRODUCCION"
        Me.ID_PLANILLAPRODUCCION.Name = "ID_PLANILLAPRODUCCION"
        Me.ID_PLANILLAPRODUCCION.ReadOnly = True
        Me.ID_PLANILLAPRODUCCION.Visible = False
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "Codigo"
        Me.CODIGO.Name = "CODIGO"
        Me.CODIGO.ReadOnly = True
        '
        'CODCODIGO
        '
        Me.CODCODIGO.DataPropertyName = "CODCODIGO"
        Me.CODCODIGO.HeaderText = "CODCODIGO"
        Me.CODCODIGO.Name = "CODCODIGO"
        Me.CODCODIGO.ReadOnly = True
        Me.CODCODIGO.Visible = False
        '
        'CANTIDADPRODUCIDA
        '
        Me.CANTIDADPRODUCIDA.DataPropertyName = "CANTIDADPRODUCIDA"
        Me.CANTIDADPRODUCIDA.HeaderText = "Cantidad"
        Me.CANTIDADPRODUCIDA.Name = "CANTIDADPRODUCIDA"
        Me.CANTIDADPRODUCIDA.ReadOnly = True
        '
        'CODPRODUCTO
        '
        Me.CODPRODUCTO.DataPropertyName = "CODPRODUCTO"
        Me.CODPRODUCTO.HeaderText = "CODPRODUCTO"
        Me.CODPRODUCTO.Name = "CODPRODUCTO"
        Me.CODPRODUCTO.ReadOnly = True
        Me.CODPRODUCTO.Visible = False
        '
        'COSTO
        '
        Me.COSTO.HeaderText = "COSTO"
        Me.COSTO.Name = "COSTO"
        Me.COSTO.ReadOnly = True
        Me.COSTO.Visible = False
        '
        'CANTIDAPRODREAL
        '
        Me.CANTIDAPRODREAL.DataPropertyName = "CANTIDAPRODREAL"
        Me.CANTIDAPRODREAL.HeaderText = "Cantidad Real"
        Me.CANTIDAPRODREAL.Name = "CANTIDAPRODREAL"
        Me.CANTIDAPRODREAL.ReadOnly = True
        '
        'ID_ORDENTRABAJO
        '
        Me.ID_ORDENTRABAJO.DataPropertyName = "ID_ORDENTRABAJO"
        Me.ID_ORDENTRABAJO.HeaderText = "ID_ORDENTRABAJO"
        Me.ID_ORDENTRABAJO.Name = "ID_ORDENTRABAJO"
        Me.ID_ORDENTRABAJO.ReadOnly = True
        Me.ID_ORDENTRABAJO.Visible = False
        '
        'CODSUCURSAL
        '
        Me.CODSUCURSAL.HeaderText = "CODSUCURSAL"
        Me.CODSUCURSAL.Name = "CODSUCURSAL"
        Me.CODSUCURSAL.ReadOnly = True
        Me.CODSUCURSAL.Visible = False
        '
        'TIPOPRODUCTODataGridViewTextBoxColumn
        '
        Me.TIPOPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "TIPOPRODUCTO"
        Me.TIPOPRODUCTODataGridViewTextBoxColumn.HeaderText = "Tipo Producto"
        Me.TIPOPRODUCTODataGridViewTextBoxColumn.Name = "TIPOPRODUCTODataGridViewTextBoxColumn"
        Me.TIPOPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PLANILLADEDEPRODUCCIONDETALLEBindingSource
        '
        Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource.DataMember = "PLANILLADEDEPRODUCCIONDETALLE"
        Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'btnAgregar
        '
        Me.btnAgregar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAgregar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.btnAgregar.ForeColor = System.Drawing.Color.White
        Me.btnAgregar.Location = New System.Drawing.Point(503, 22)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(67, 27)
        Me.btnAgregar.TabIndex = 496
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'txtCodProductoMP
        '
        Me.txtCodProductoMP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodProductoMP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtCodProductoMP.Location = New System.Drawing.Point(1222, -107)
        Me.txtCodProductoMP.Name = "txtCodProductoMP"
        Me.txtCodProductoMP.Size = New System.Drawing.Size(10, 26)
        Me.txtCodProductoMP.TabIndex = 514
        '
        'TotalIvaVentaMaskedEdit
        '
        Me.TotalIvaVentaMaskedEdit.AllowDrop = True
        Me.TotalIvaVentaMaskedEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Appearance10.BackColor = System.Drawing.Color.Gainsboro
        Appearance10.BorderColor = System.Drawing.Color.CornflowerBlue
        Appearance10.FontData.Name = "Arial"
        Appearance10.FontData.SizeInPoints = 9.75!
        Appearance10.ForeColor = System.Drawing.Color.Black
        Me.TotalIvaVentaMaskedEdit.Appearance = Appearance10
        Me.TotalIvaVentaMaskedEdit.AutoSize = False
        Me.TotalIvaVentaMaskedEdit.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TotalIvaVentaMaskedEdit.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TotalIvaVentaMaskedEdit.Enabled = False
        Me.TotalIvaVentaMaskedEdit.InputMask = "nnn,nnn,nnn,nnn"
        Me.TotalIvaVentaMaskedEdit.Location = New System.Drawing.Point(448, 518)
        Me.TotalIvaVentaMaskedEdit.Name = "TotalIvaVentaMaskedEdit"
        Me.TotalIvaVentaMaskedEdit.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TotalIvaVentaMaskedEdit.ReadOnly = True
        Me.TotalIvaVentaMaskedEdit.Size = New System.Drawing.Size(111, 28)
        Me.TotalIvaVentaMaskedEdit.TabIndex = 485
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.CancelarPictureBox)
        Me.Panel5.Controls.Add(Me.GuardarPictureBox)
        Me.Panel5.Controls.Add(Me.ModificarPictureBox)
        Me.Panel5.Controls.Add(Me.EliminarPictureBox)
        Me.Panel5.Controls.Add(Me.NuevoPictureBox)
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(697, 35)
        Me.Panel5.TabIndex = 471
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CancelarPictureBox.Location = New System.Drawing.Point(131, 0)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GuardarPictureBox.Location = New System.Drawing.Point(99, 0)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ModificarPictureBox.Location = New System.Drawing.Point(67, 0)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EliminarPictureBox.Location = New System.Drawing.Point(35, 0)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 33)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NuevoPictureBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoPictureBox.Dock = System.Windows.Forms.DockStyle.Left
        Me.NuevoPictureBox.Image = CType(resources.GetObject("NuevoPictureBox.Image"), System.Drawing.Image)
        Me.NuevoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NuevoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 33)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'pnlCabecera
        '
        Me.pnlCabecera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlCabecera.BackColor = System.Drawing.Color.LightGray
        Me.pnlCabecera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCabecera.Controls.Add(Me.tbxCantidadNeto)
        Me.pnlCabecera.Controls.Add(Me.RadLabel15)
        Me.pnlCabecera.Controls.Add(Me.RadLabel13)
        Me.pnlCabecera.Controls.Add(Me.RadLabel10)
        Me.pnlCabecera.Controls.Add(Me.tbxCantidadAveriado)
        Me.pnlCabecera.Controls.Add(Me.RadLabel8)
        Me.pnlCabecera.Controls.Add(Me.cbxSucursal)
        Me.pnlCabecera.Controls.Add(Me.tbxCantidadAProducir)
        Me.pnlCabecera.Controls.Add(Me.TextBox1)
        Me.pnlCabecera.Controls.Add(Me.RadLabel3)
        Me.pnlCabecera.Controls.Add(Me.cbxCombo)
        Me.pnlCabecera.Controls.Add(Me.cbxOrdenProduccion)
        Me.pnlCabecera.Controls.Add(Me.tbxIdOrdenProduccion)
        Me.pnlCabecera.Controls.Add(Me.txtOBS)
        Me.pnlCabecera.Controls.Add(Me.RadLabel7)
        Me.pnlCabecera.Controls.Add(Me.RadLabel5)
        Me.pnlCabecera.Controls.Add(Me.RadLabel2)
        Me.pnlCabecera.Controls.Add(Me.dtpFecha)
        Me.pnlCabecera.Controls.Add(Me.Label2)
        Me.pnlCabecera.Controls.Add(Me.dgwMovProducto)
        Me.pnlCabecera.Location = New System.Drawing.Point(3, 38)
        Me.pnlCabecera.Name = "pnlCabecera"
        Me.pnlCabecera.Size = New System.Drawing.Size(691, 149)
        Me.pnlCabecera.TabIndex = 469
        '
        'tbxCantidadNeto
        '
        Me.tbxCantidadNeto.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCantidadNeto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantidadNeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxCantidadNeto.Location = New System.Drawing.Point(614, 94)
        Me.tbxCantidadNeto.Name = "tbxCantidadNeto"
        Me.tbxCantidadNeto.Size = New System.Drawing.Size(66, 26)
        Me.tbxCantidadNeto.TabIndex = 529
        '
        'RadLabel15
        '
        Me.RadLabel15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel15.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel15.Controls.Add(Me.RadLabel16)
        Me.RadLabel15.Enabled = False
        Me.RadLabel15.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.Location = New System.Drawing.Point(614, 75)
        Me.RadLabel15.Name = "RadLabel15"
        '
        '
        '
        Me.RadLabel15.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel15.RootElement.AngleTransform = 0.0!
        Me.RadLabel15.RootElement.FlipText = False
        Me.RadLabel15.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel15.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel15.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel15.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel15.RootElement.Text = Nothing
        Me.RadLabel15.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel15.Size = New System.Drawing.Size(33, 16)
        Me.RadLabel15.TabIndex = 528
        Me.RadLabel15.Text = "Neto:"
        Me.RadLabel15.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel16
        '
        Me.RadLabel16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel16.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel16.Enabled = False
        Me.RadLabel16.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.Location = New System.Drawing.Point(68, 3)
        Me.RadLabel16.Name = "RadLabel16"
        '
        '
        '
        Me.RadLabel16.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel16.RootElement.AngleTransform = 0.0!
        Me.RadLabel16.RootElement.FlipText = False
        Me.RadLabel16.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel16.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel16.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel16.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel16.RootElement.Text = Nothing
        Me.RadLabel16.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel16.Size = New System.Drawing.Size(109, 16)
        Me.RadLabel16.TabIndex = 525
        Me.RadLabel16.Text = "Cantidad a Producir:"
        Me.RadLabel16.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel13
        '
        Me.RadLabel13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel13.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel13.Controls.Add(Me.RadLabel14)
        Me.RadLabel13.Enabled = False
        Me.RadLabel13.ForeColor = System.Drawing.Color.Black
        Me.RadLabel13.Location = New System.Drawing.Point(518, 75)
        Me.RadLabel13.Name = "RadLabel13"
        '
        '
        '
        Me.RadLabel13.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel13.RootElement.AngleTransform = 0.0!
        Me.RadLabel13.RootElement.FlipText = False
        Me.RadLabel13.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel13.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel13.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel13.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel13.RootElement.Text = Nothing
        Me.RadLabel13.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel13.Size = New System.Drawing.Size(60, 16)
        Me.RadLabel13.TabIndex = 526
        Me.RadLabel13.Text = "Averiados:"
        Me.RadLabel13.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel14
        '
        Me.RadLabel14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel14.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel14.Enabled = False
        Me.RadLabel14.ForeColor = System.Drawing.Color.Black
        Me.RadLabel14.Location = New System.Drawing.Point(82, 3)
        Me.RadLabel14.Name = "RadLabel14"
        '
        '
        '
        Me.RadLabel14.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel14.RootElement.AngleTransform = 0.0!
        Me.RadLabel14.RootElement.FlipText = False
        Me.RadLabel14.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel14.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel14.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel14.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel14.RootElement.Text = Nothing
        Me.RadLabel14.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel14.Size = New System.Drawing.Size(109, 16)
        Me.RadLabel14.TabIndex = 525
        Me.RadLabel14.Text = "Cantidad a Producir:"
        Me.RadLabel14.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel10
        '
        Me.RadLabel10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel10.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel10.Controls.Add(Me.RadLabel11)
        Me.RadLabel10.Enabled = False
        Me.RadLabel10.ForeColor = System.Drawing.Color.Black
        Me.RadLabel10.Location = New System.Drawing.Point(429, 75)
        Me.RadLabel10.Name = "RadLabel10"
        '
        '
        '
        Me.RadLabel10.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel10.RootElement.AngleTransform = 0.0!
        Me.RadLabel10.RootElement.FlipText = False
        Me.RadLabel10.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel10.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel10.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel10.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel10.RootElement.Text = Nothing
        Me.RadLabel10.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel10.Size = New System.Drawing.Size(36, 16)
        Me.RadLabel10.TabIndex = 527
        Me.RadLabel10.Text = "Bruto:"
        Me.RadLabel10.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel11
        '
        Me.RadLabel11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel11.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel11.Enabled = False
        Me.RadLabel11.ForeColor = System.Drawing.Color.Black
        Me.RadLabel11.Location = New System.Drawing.Point(70, 3)
        Me.RadLabel11.Name = "RadLabel11"
        '
        '
        '
        Me.RadLabel11.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel11.RootElement.AngleTransform = 0.0!
        Me.RadLabel11.RootElement.FlipText = False
        Me.RadLabel11.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel11.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel11.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel11.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel11.RootElement.Text = Nothing
        Me.RadLabel11.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel11.Size = New System.Drawing.Size(109, 16)
        Me.RadLabel11.TabIndex = 525
        Me.RadLabel11.Text = "Cantidad a Producir:"
        Me.RadLabel11.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'tbxCantidadAveriado
        '
        Me.tbxCantidadAveriado.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCantidadAveriado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantidadAveriado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxCantidadAveriado.Location = New System.Drawing.Point(518, 94)
        Me.tbxCantidadAveriado.Name = "tbxCantidadAveriado"
        Me.tbxCantidadAveriado.Size = New System.Drawing.Size(66, 26)
        Me.tbxCantidadAveriado.TabIndex = 526
        '
        'RadLabel8
        '
        Me.RadLabel8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel8.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel8.Enabled = False
        Me.RadLabel8.ForeColor = System.Drawing.Color.Black
        Me.RadLabel8.Location = New System.Drawing.Point(518, 27)
        Me.RadLabel8.Name = "RadLabel8"
        '
        '
        '
        Me.RadLabel8.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel8.RootElement.AngleTransform = 0.0!
        Me.RadLabel8.RootElement.FlipText = False
        Me.RadLabel8.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel8.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel8.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel8.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel8.RootElement.Text = Nothing
        Me.RadLabel8.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel8.Size = New System.Drawing.Size(54, 16)
        Me.RadLabel8.TabIndex = 509
        Me.RadLabel8.Text = "Depósito:"
        Me.RadLabel8.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxSucursal
        '
        Me.cbxSucursal.DataSource = Me.SUCURSALBindingSource
        Me.cbxSucursal.DisplayMember = "DESSUCURSAL"
        Me.cbxSucursal.FormattingEnabled = True
        Me.cbxSucursal.Location = New System.Drawing.Point(480, 46)
        Me.cbxSucursal.Name = "cbxSucursal"
        Me.cbxSucursal.Size = New System.Drawing.Size(134, 21)
        Me.cbxSucursal.TabIndex = 526
        Me.cbxSucursal.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'tbxCantidadAProducir
        '
        Me.tbxCantidadAProducir.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCantidadAProducir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantidadAProducir.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.tbxCantidadAProducir.Location = New System.Drawing.Point(429, 94)
        Me.tbxCantidadAProducir.Name = "tbxCantidadAProducir"
        Me.tbxCantidadAProducir.Size = New System.Drawing.Size(66, 26)
        Me.tbxCantidadAProducir.TabIndex = 524
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.TextBox1.Location = New System.Drawing.Point(323, 94)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(66, 21)
        Me.TextBox1.TabIndex = 523
        '
        'RadLabel3
        '
        Me.RadLabel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel3.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel3.Enabled = False
        Me.RadLabel3.ForeColor = System.Drawing.Color.Black
        Me.RadLabel3.Location = New System.Drawing.Point(2, 94)
        Me.RadLabel3.Name = "RadLabel3"
        '
        '
        '
        Me.RadLabel3.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel3.RootElement.AngleTransform = 0.0!
        Me.RadLabel3.RootElement.FlipText = False
        Me.RadLabel3.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel3.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel3.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel3.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel3.RootElement.Text = Nothing
        Me.RadLabel3.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel3.Size = New System.Drawing.Size(112, 16)
        Me.RadLabel3.TabIndex = 509
        Me.RadLabel3.Text = "Producto a Realizar :"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'cbxCombo
        '
        Me.cbxCombo.DataSource = Me.COMBOSBindingSource
        Me.cbxCombo.DisplayMember = "DESPRODUCTO"
        Me.cbxCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCombo.FormattingEnabled = True
        Me.cbxCombo.Location = New System.Drawing.Point(119, 94)
        Me.cbxCombo.Name = "cbxCombo"
        Me.cbxCombo.Size = New System.Drawing.Size(198, 21)
        Me.cbxCombo.TabIndex = 522
        Me.cbxCombo.ValueMember = "CODPRODUCTO"
        '
        'COMBOSBindingSource
        '
        Me.COMBOSBindingSource.DataMember = "COMBOS"
        Me.COMBOSBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'cbxOrdenProduccion
        '
        Me.cbxOrdenProduccion.DataSource = Me.ORDENPRODUCCIONBindingSource
        Me.cbxOrdenProduccion.DisplayMember = "CODIGOLOTE"
        Me.cbxOrdenProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxOrdenProduccion.FormattingEnabled = True
        Me.cbxOrdenProduccion.Location = New System.Drawing.Point(119, 67)
        Me.cbxOrdenProduccion.Name = "cbxOrdenProduccion"
        Me.cbxOrdenProduccion.Size = New System.Drawing.Size(198, 21)
        Me.cbxOrdenProduccion.TabIndex = 521
        Me.cbxOrdenProduccion.ValueMember = "ID"
        '
        'ORDENPRODUCCIONBindingSource
        '
        Me.ORDENPRODUCCIONBindingSource.DataMember = "ORDENPRODUCCION"
        Me.ORDENPRODUCCIONBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'tbxIdOrdenProduccion
        '
        Me.tbxIdOrdenProduccion.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxIdOrdenProduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxIdOrdenProduccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.tbxIdOrdenProduccion.Location = New System.Drawing.Point(323, 67)
        Me.tbxIdOrdenProduccion.Name = "tbxIdOrdenProduccion"
        Me.tbxIdOrdenProduccion.Size = New System.Drawing.Size(66, 21)
        Me.tbxIdOrdenProduccion.TabIndex = 520
        '
        'txtOBS
        '
        Me.txtOBS.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtOBS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtOBS.Location = New System.Drawing.Point(119, 119)
        Me.txtOBS.Multiline = True
        Me.txtOBS.Name = "txtOBS"
        Me.txtOBS.Size = New System.Drawing.Size(270, 26)
        Me.txtOBS.TabIndex = 518
        '
        'RadLabel7
        '
        Me.RadLabel7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel7.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel7.Enabled = False
        Me.RadLabel7.ForeColor = System.Drawing.Color.Black
        Me.RadLabel7.Location = New System.Drawing.Point(41, 124)
        Me.RadLabel7.Name = "RadLabel7"
        '
        '
        '
        Me.RadLabel7.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel7.RootElement.AngleTransform = 0.0!
        Me.RadLabel7.RootElement.FlipText = False
        Me.RadLabel7.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel7.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel7.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel7.RootElement.Text = Nothing
        Me.RadLabel7.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel7.Size = New System.Drawing.Size(73, 16)
        Me.RadLabel7.TabIndex = 517
        Me.RadLabel7.Text = "Observación:"
        Me.RadLabel7.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel5
        '
        Me.RadLabel5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel5.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel5.Enabled = False
        Me.RadLabel5.ForeColor = System.Drawing.Color.Black
        Me.RadLabel5.Location = New System.Drawing.Point(8, 67)
        Me.RadLabel5.Name = "RadLabel5"
        '
        '
        '
        Me.RadLabel5.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel5.RootElement.AngleTransform = 0.0!
        Me.RadLabel5.RootElement.FlipText = False
        Me.RadLabel5.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel5.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel5.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel5.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel5.RootElement.Text = Nothing
        Me.RadLabel5.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel5.Size = New System.Drawing.Size(106, 16)
        Me.RadLabel5.TabIndex = 508
        Me.RadLabel5.Text = "Nro de  Produccion:"
        Me.RadLabel5.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'RadLabel2
        '
        Me.RadLabel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.RadLabel2.BackColor = System.Drawing.Color.LightGray
        Me.RadLabel2.Enabled = False
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(73, 42)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.Alignment = System.Drawing.ContentAlignment.TopLeft
        Me.RadLabel2.RootElement.AngleTransform = 0.0!
        Me.RadLabel2.RootElement.FlipText = False
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.RootElement.Margin = New System.Windows.Forms.Padding(0)
        Me.RadLabel2.RootElement.Padding = New System.Windows.Forms.Padding(0)
        Me.RadLabel2.RootElement.StringAlignment = System.Drawing.StringAlignment.Near
        Me.RadLabel2.RootElement.Text = Nothing
        Me.RadLabel2.RootElement.TextOrientation = System.Windows.Forms.Orientation.Horizontal
        Me.RadLabel2.Size = New System.Drawing.Size(41, 16)
        Me.RadLabel2.TabIndex = 507
        Me.RadLabel2.Text = "Fecha:"
        Me.RadLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFecha.CalendarMonthBackground = System.Drawing.Color.DimGray
        Me.dtpFecha.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(119, 37)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(198, 26)
        Me.dtpFecha.TabIndex = 504
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!)
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(294, 28)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Datos de la Planilla de Producción"
        '
        'dgwMovProducto
        '
        Me.dgwMovProducto.AutoGenerateColumns = False
        Me.dgwMovProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgwMovProducto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODMOVIMIENTODataGridViewTextBoxColumn, Me.CODUSUARIODataGridViewTextBoxColumn, Me.CODCODIGODataGridViewTextBoxColumn1, Me.CODDEPOSITODataGridViewTextBoxColumn, Me.FECHAMOVIMIENTODataGridViewTextBoxColumn, Me.MODULODataGridViewTextBoxColumn, Me.MODULOTRANSIDDataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.VALORDataGridViewTextBoxColumn, Me.STOCKDataGridViewCheckBoxColumn, Me.CONCEPTODataGridViewTextBoxColumn, Me.COSTEABLEDataGridViewCheckBoxColumn, Me.TIPOPRODUCCIONDataGridViewTextBoxColumn, Me.NROMOVIMIENTODataGridViewTextBoxColumn})
        Me.dgwMovProducto.DataSource = Me.MOVPRODUCTOBindingSource
        Me.dgwMovProducto.Location = New System.Drawing.Point(393, 3)
        Me.dgwMovProducto.Name = "dgwMovProducto"
        Me.dgwMovProducto.Size = New System.Drawing.Size(240, 150)
        Me.dgwMovProducto.TabIndex = 525
        Me.dgwMovProducto.Visible = False
        '
        'CODMOVIMIENTODataGridViewTextBoxColumn
        '
        Me.CODMOVIMIENTODataGridViewTextBoxColumn.DataPropertyName = "CODMOVIMIENTO"
        Me.CODMOVIMIENTODataGridViewTextBoxColumn.HeaderText = "CODMOVIMIENTO"
        Me.CODMOVIMIENTODataGridViewTextBoxColumn.Name = "CODMOVIMIENTODataGridViewTextBoxColumn"
        Me.CODMOVIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODUSUARIODataGridViewTextBoxColumn
        '
        Me.CODUSUARIODataGridViewTextBoxColumn.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.HeaderText = "CODUSUARIO"
        Me.CODUSUARIODataGridViewTextBoxColumn.Name = "CODUSUARIODataGridViewTextBoxColumn"
        '
        'CODCODIGODataGridViewTextBoxColumn1
        '
        Me.CODCODIGODataGridViewTextBoxColumn1.DataPropertyName = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.HeaderText = "CODCODIGO"
        Me.CODCODIGODataGridViewTextBoxColumn1.Name = "CODCODIGODataGridViewTextBoxColumn1"
        '
        'CODDEPOSITODataGridViewTextBoxColumn
        '
        Me.CODDEPOSITODataGridViewTextBoxColumn.DataPropertyName = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.HeaderText = "CODDEPOSITO"
        Me.CODDEPOSITODataGridViewTextBoxColumn.Name = "CODDEPOSITODataGridViewTextBoxColumn"
        '
        'FECHAMOVIMIENTODataGridViewTextBoxColumn
        '
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.DataPropertyName = "FECHAMOVIMIENTO"
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.HeaderText = "FECHAMOVIMIENTO"
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.Name = "FECHAMOVIMIENTODataGridViewTextBoxColumn"
        '
        'MODULODataGridViewTextBoxColumn
        '
        Me.MODULODataGridViewTextBoxColumn.DataPropertyName = "MODULO"
        Me.MODULODataGridViewTextBoxColumn.HeaderText = "MODULO"
        Me.MODULODataGridViewTextBoxColumn.Name = "MODULODataGridViewTextBoxColumn"
        '
        'MODULOTRANSIDDataGridViewTextBoxColumn
        '
        Me.MODULOTRANSIDDataGridViewTextBoxColumn.DataPropertyName = "MODULOTRANSID"
        Me.MODULOTRANSIDDataGridViewTextBoxColumn.HeaderText = "MODULOTRANSID"
        Me.MODULOTRANSIDDataGridViewTextBoxColumn.Name = "MODULOTRANSIDDataGridViewTextBoxColumn"
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.HeaderText = "CANTIDAD"
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        '
        'VALORDataGridViewTextBoxColumn
        '
        Me.VALORDataGridViewTextBoxColumn.DataPropertyName = "VALOR"
        Me.VALORDataGridViewTextBoxColumn.HeaderText = "VALOR"
        Me.VALORDataGridViewTextBoxColumn.Name = "VALORDataGridViewTextBoxColumn"
        '
        'STOCKDataGridViewCheckBoxColumn
        '
        Me.STOCKDataGridViewCheckBoxColumn.DataPropertyName = "STOCK"
        Me.STOCKDataGridViewCheckBoxColumn.HeaderText = "STOCK"
        Me.STOCKDataGridViewCheckBoxColumn.Name = "STOCKDataGridViewCheckBoxColumn"
        '
        'CONCEPTODataGridViewTextBoxColumn
        '
        Me.CONCEPTODataGridViewTextBoxColumn.DataPropertyName = "CONCEPTO"
        Me.CONCEPTODataGridViewTextBoxColumn.HeaderText = "CONCEPTO"
        Me.CONCEPTODataGridViewTextBoxColumn.Name = "CONCEPTODataGridViewTextBoxColumn"
        '
        'COSTEABLEDataGridViewCheckBoxColumn
        '
        Me.COSTEABLEDataGridViewCheckBoxColumn.DataPropertyName = "COSTEABLE"
        Me.COSTEABLEDataGridViewCheckBoxColumn.HeaderText = "COSTEABLE"
        Me.COSTEABLEDataGridViewCheckBoxColumn.Name = "COSTEABLEDataGridViewCheckBoxColumn"
        '
        'TIPOPRODUCCIONDataGridViewTextBoxColumn
        '
        Me.TIPOPRODUCCIONDataGridViewTextBoxColumn.DataPropertyName = "TIPOPRODUCCION"
        Me.TIPOPRODUCCIONDataGridViewTextBoxColumn.HeaderText = "TIPOPRODUCCION"
        Me.TIPOPRODUCCIONDataGridViewTextBoxColumn.Name = "TIPOPRODUCCIONDataGridViewTextBoxColumn"
        '
        'NROMOVIMIENTODataGridViewTextBoxColumn
        '
        Me.NROMOVIMIENTODataGridViewTextBoxColumn.DataPropertyName = "NROMOVIMIENTO"
        Me.NROMOVIMIENTODataGridViewTextBoxColumn.HeaderText = "NROMOVIMIENTO"
        Me.NROMOVIMIENTODataGridViewTextBoxColumn.Name = "NROMOVIMIENTODataGridViewTextBoxColumn"
        '
        'MOVPRODUCTOBindingSource
        '
        Me.MOVPRODUCTOBindingSource.DataMember = "MOVPRODUCTO"
        Me.MOVPRODUCTOBindingSource.DataSource = Me.DsPlanilladeProduccion
        '
        'PLANILLAPRODUCCIONTableAdapter
        '
        Me.PLANILLAPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'ORDENPRODUCCIONTableAdapter
        '
        Me.ORDENPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'PLANILLADEDEPRODUCCIONDETALLETableAdapter
        '
        Me.PLANILLADEDEPRODUCCIONDETALLETableAdapter.ClearBeforeFill = True
        '
        'COMBOSTableAdapter
        '
        Me.COMBOSTableAdapter.ClearBeforeFill = True
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'CODIGOSTableAdapter
        '
        Me.CODIGOSTableAdapter.ClearBeforeFill = True
        '
        'MOVPRODUCTOTableAdapter
        '
        Me.MOVPRODUCTOTableAdapter.ClearBeforeFill = True
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'PlanillaDeProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 667)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "PlanillaDeProduccion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla de Producción | Cogent SIG"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgwOrdenProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLANILLAPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPlanilladeProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwOPDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PLANILLADEDEPRODUCCIONDETALLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCabecera.ResumeLayout(False)
        Me.pnlCabecera.PerformLayout()
        CType(Me.RadLabel15, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadLabel15.ResumeLayout(False)
        Me.RadLabel15.PerformLayout()
        CType(Me.RadLabel16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel13, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadLabel13.ResumeLayout(False)
        Me.RadLabel13.PerformLayout()
        CType(Me.RadLabel14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadLabel10.ResumeLayout(False)
        Me.RadLabel10.PerformLayout()
        CType(Me.RadLabel11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COMBOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwMovProducto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MOVPRODUCTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgwOrdenProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents CmbAño As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents BtnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbMes As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtIdOT As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tbxCantidadMateriaPrima As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents RadLabel12 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnEliminarProducto As System.Windows.Forms.Button
    Friend WithEvents tbxCodCodigo As System.Windows.Forms.TextBox
    Friend WithEvents DesProductoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents dgwOPDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodProductoMP As System.Windows.Forms.TextBox
    Friend WithEvents TotalIvaVentaMaskedEdit As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents pnlCabecera As System.Windows.Forms.Panel
    Friend WithEvents txtOBS As System.Windows.Forms.TextBox
    Friend WithEvents RadLabel7 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel5 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxIdOrdenProduccion As System.Windows.Forms.TextBox
    Friend WithEvents DsPlanilladeProduccion As ContaExpress.dsPlanilladeProduccion
    Friend WithEvents PLANILLAPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PLANILLAPRODUCCIONTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.PLANILLAPRODUCCIONTableAdapter
    Friend WithEvents FECHADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGOLOTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDORDENPRODUCCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxOrdenProduccion As System.Windows.Forms.ComboBox
    Friend WithEvents ORDENPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ORDENPRODUCCIONTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.ORDENPRODUCCIONTableAdapter
    Friend WithEvents PLANILLADEDEPRODUCCIONDETALLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PLANILLADEDEPRODUCCIONDETALLETableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.PLANILLADEDEPRODUCCIONDETALLETableAdapter
    Friend WithEvents cbxProductoReceta As System.Windows.Forms.ComboBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxCodigo As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCantidadAProducir As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxCombo As System.Windows.Forms.ComboBox
    Friend WithEvents COMBOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COMBOSTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.COMBOSTableAdapter
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents CODIGOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGOSTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.CODIGOSTableAdapter
    Friend WithEvents dgwMovProducto As System.Windows.Forms.DataGridView
    Friend WithEvents MOVPRODUCTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MOVPRODUCTOTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.MOVPRODUCTOTableAdapter
    Friend WithEvents CODMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODDEPOSITODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODULODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODULOTRANSIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CONCEPTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTEABLEDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TIPOPRODUCCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.dsPlanilladeProduccionTableAdapters.SUCURSALTableAdapter
    Friend WithEvents lblCostoTotal As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents IDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EventoGrilla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID_PLANILLAPRODUCCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADPRODUCIDA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODPRODUCTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COSTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAPRODREAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID_ORDENTRABAJO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUCURSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPOPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadLabel8 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents cbxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCantidadNeto As System.Windows.Forms.TextBox
    Friend WithEvents RadLabel15 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel16 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel13 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel14 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel10 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel11 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents tbxCantidadAveriado As System.Windows.Forms.TextBox
End Class
