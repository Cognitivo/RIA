<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockInicial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StockInicial))
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PRODUCTOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos = New ContaExpress.DsProductos()
        Me.BuscadorGroupBox = New Telerik.WinControls.UI.RadGroupBox()
        Me.BuscadorTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BuscadorGridView = New Telerik.WinControls.UI.RadGridView()
        Me.CODIGOSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsInventario = New ContaExpress.DsInventario()
        Me.RadButtonInserta = New Telerik.WinControls.UI.RadButton()
        Me.CantidadInvTextBox = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.RadButtonEliminar = New Telerik.WinControls.UI.RadButton()
        Me.TxtPrecio = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.CodigoProdTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.CodCodigoRadTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.UltraPopupControlContainer1 = New Infragistics.Win.Misc.UltraPopupControlContainer(Me.components)
        Me.PRODUCTOSTableAdapter = New ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsProductosTableAdapters.TableAdapterManager()
        Me.PRODUCTOSBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableAdapterManager2 = New ContaExpress.DsInventarioTableAdapters.TableAdapterManager()
        Me.CODIGOSTableAdapter = New ContaExpress.DsInventarioTableAdapters.CODIGOSTableAdapter()
        Me.RadTextBoxDesproducto = New System.Windows.Forms.TextBox()
        Me.RadTextBoxBuscar = New System.Windows.Forms.TextBox()
        Me.RadComboBoxSucursal = New System.Windows.Forms.ComboBox()
        Me.SUCURSALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SUCURSALTableAdapter = New ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter()
        Me.TbxCodigoProducto = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgwStockInicial = New System.Windows.Forms.DataGridView()
        Me.STOCKINICIALBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProductos1 = New ContaExpress.DsProductos()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.STOCKINICIALTableAdapter1 = New ContaExpress.DsProductosTableAdapters.STOCKINICIALTableAdapter()
        Me.BtnAsterisco = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CODIGODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESPRODUCTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESSUCURSALDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALORDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONCEPTODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMOVIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BuscadorGroupBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BuscadorGroupBox.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BuscadorGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BuscadorGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButtonInserta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadButtonEliminar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodigoProdTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CodCodigoRadTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRODUCTOSBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwStockInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.STOCKINICIALBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProductos1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.BtnAsterisco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRODUCTOSBindingSource
        '
        Me.PRODUCTOSBindingSource.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource.DataSource = Me.DsProductosBindingSource
        '
        'DsProductosBindingSource
        '
        Me.DsProductosBindingSource.DataSource = Me.DsProductos
        Me.DsProductosBindingSource.Position = 0
        '
        'DsProductos
        '
        Me.DsProductos.DataSetName = "DsProductos"
        Me.DsProductos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BuscadorGroupBox
        '
        Me.BuscadorGroupBox.BackColor = System.Drawing.Color.Transparent
        Me.BuscadorGroupBox.Controls.Add(Me.BuscadorTextBox)
        Me.BuscadorGroupBox.Controls.Add(Me.PictureBox2)
        Me.BuscadorGroupBox.Controls.Add(Me.BuscadorGridView)
        resources.ApplyResources(Me.BuscadorGroupBox, "BuscadorGroupBox")
        Me.BuscadorGroupBox.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.BuscadorGroupBox.Name = "BuscadorGroupBox"
        '
        '
        '
        Me.BuscadorGroupBox.RootElement.Alignment = CType(resources.GetObject("BuscadorGroupBox.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.BuscadorGroupBox.RootElement.AngleTransform = CType(resources.GetObject("BuscadorGroupBox.RootElement.AngleTransform"), Single)
        Me.BuscadorGroupBox.RootElement.FlipText = CType(resources.GetObject("BuscadorGroupBox.RootElement.FlipText"), Boolean)
        Me.BuscadorGroupBox.RootElement.Margin = CType(resources.GetObject("BuscadorGroupBox.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.BuscadorGroupBox.RootElement.Padding = CType(resources.GetObject("BuscadorGroupBox.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.BuscadorGroupBox.RootElement.StringAlignment = CType(resources.GetObject("BuscadorGroupBox.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.BuscadorGroupBox.RootElement.Text = resources.GetString("BuscadorGroupBox.RootElement.Text")
        Me.BuscadorGroupBox.RootElement.TextOrientation = CType(resources.GetObject("BuscadorGroupBox.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.BuscadorGroupBox.ThemeName = "Breeze"
        CType(Me.BuscadorGroupBox.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        CType(Me.BuscadorGroupBox.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.SystemColors.ControlLight
        '
        'BuscadorTextBox
        '
        resources.ApplyResources(Me.BuscadorTextBox, "BuscadorTextBox")
        Me.BuscadorTextBox.BackColor = System.Drawing.Color.Gray
        Me.BuscadorTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscadorTextBox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.BuscadorTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscadorTextBox.Name = "BuscadorTextBox"
        '
        'PictureBox2
        '
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.BackColor = System.Drawing.Color.Gray
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Search
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'BuscadorGridView
        '
        Me.BuscadorGridView.BackColor = System.Drawing.Color.FromArgb(CType(CType(191, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.BuscadorGridView.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.BuscadorGridView, "BuscadorGridView")
        Me.BuscadorGridView.ForeColor = System.Drawing.SystemColors.ControlText
        '
        '
        '
        Me.BuscadorGridView.MasterGridViewTemplate.AllowAddNewRow = False
        resources.ApplyResources(GridViewTextBoxColumn1, "GridViewTextBoxColumn1")
        GridViewTextBoxColumn1.FieldName = "PRODUCTO"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.UniqueName = "PRODUCTO"
        GridViewTextBoxColumn1.Width = 150
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        resources.ApplyResources(GridViewDecimalColumn1, "GridViewDecimalColumn1")
        GridViewDecimalColumn1.FieldName = "CODCODIGO"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODCODIGO"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        resources.ApplyResources(GridViewDecimalColumn2, "GridViewDecimalColumn2")
        GridViewDecimalColumn2.FieldName = "CODPRODUCTO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODPRODUCTO"
        resources.ApplyResources(GridViewTextBoxColumn2, "GridViewTextBoxColumn2")
        GridViewTextBoxColumn2.FieldName = "CODIGO"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.UniqueName = "CODIGO"
        GridViewTextBoxColumn2.Width = 140
        resources.ApplyResources(GridViewTextBoxColumn3, "GridViewTextBoxColumn3")
        GridViewTextBoxColumn3.FieldName = "DESPRODUCTO"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.UniqueName = "DESPRODUCTO"
        GridViewTextBoxColumn3.Width = 240
        resources.ApplyResources(GridViewTextBoxColumn4, "GridViewTextBoxColumn4")
        GridViewTextBoxColumn4.FieldName = "DESCODIGO1"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.UniqueName = "DESCODIGO1"
        GridViewTextBoxColumn4.Width = 180
        resources.ApplyResources(GridViewTextBoxColumn5, "GridViewTextBoxColumn5")
        GridViewTextBoxColumn5.FieldName = "DESCODIGO2"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.IsVisible = False
        GridViewTextBoxColumn5.UniqueName = "DESCODIGO2"
        GridViewTextBoxColumn5.Width = 150
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        resources.ApplyResources(GridViewDecimalColumn3, "GridViewDecimalColumn3")
        GridViewDecimalColumn3.FieldName = "CODUSUARIO"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        resources.ApplyResources(GridViewDecimalColumn4, "GridViewDecimalColumn4")
        GridViewDecimalColumn4.FieldName = "CODEMPRESA"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODEMPRESA"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        resources.ApplyResources(GridViewDateTimeColumn1, "GridViewDateTimeColumn1")
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        resources.ApplyResources(GridViewTextBoxColumn6, "GridViewTextBoxColumn6")
        GridViewTextBoxColumn6.FieldName = "PRODUCTO"
        GridViewTextBoxColumn6.IsAutoGenerated = True
        GridViewTextBoxColumn6.IsVisible = False
        GridViewTextBoxColumn6.ReadOnly = True
        GridViewTextBoxColumn6.UniqueName = "PRODUCTO1"
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn4)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn5)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.BuscadorGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn6)
        Me.BuscadorGridView.MasterGridViewTemplate.DataSource = Me.CODIGOSBindingSource
        Me.BuscadorGridView.MasterGridViewTemplate.EnableGrouping = False
        Me.BuscadorGridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.BuscadorGridView.Name = "BuscadorGridView"
        Me.BuscadorGridView.ReadOnly = True
        '
        '
        '
        Me.BuscadorGridView.RootElement.Alignment = CType(resources.GetObject("BuscadorGridView.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.BuscadorGridView.RootElement.AngleTransform = CType(resources.GetObject("BuscadorGridView.RootElement.AngleTransform"), Single)
        Me.BuscadorGridView.RootElement.FlipText = CType(resources.GetObject("BuscadorGridView.RootElement.FlipText"), Boolean)
        Me.BuscadorGridView.RootElement.Margin = CType(resources.GetObject("BuscadorGridView.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.BuscadorGridView.RootElement.Padding = CType(resources.GetObject("BuscadorGridView.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.BuscadorGridView.RootElement.StringAlignment = CType(resources.GetObject("BuscadorGridView.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.BuscadorGridView.RootElement.Text = resources.GetString("BuscadorGridView.RootElement.Text")
        Me.BuscadorGridView.RootElement.TextOrientation = CType(resources.GetObject("BuscadorGridView.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.BuscadorGridView.ShowGroupPanel = False
        '
        'CODIGOSBindingSource
        '
        Me.CODIGOSBindingSource.DataMember = "CODIGOS"
        Me.CODIGOSBindingSource.DataSource = Me.DsInventario
        '
        'DsInventario
        '
        Me.DsInventario.DataSetName = "DsInventario"
        Me.DsInventario.EnforceConstraints = False
        Me.DsInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadButtonInserta
        '
        resources.ApplyResources(Me.RadButtonInserta, "RadButtonInserta")
        Me.RadButtonInserta.Name = "RadButtonInserta"
        '
        '
        '
        Me.RadButtonInserta.RootElement.Alignment = CType(resources.GetObject("RadButtonInserta.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.RadButtonInserta.RootElement.AngleTransform = CType(resources.GetObject("RadButtonInserta.RootElement.AngleTransform"), Single)
        Me.RadButtonInserta.RootElement.FlipText = CType(resources.GetObject("RadButtonInserta.RootElement.FlipText"), Boolean)
        Me.RadButtonInserta.RootElement.Margin = CType(resources.GetObject("RadButtonInserta.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.RadButtonInserta.RootElement.Padding = CType(resources.GetObject("RadButtonInserta.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.RadButtonInserta.RootElement.StringAlignment = CType(resources.GetObject("RadButtonInserta.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.RadButtonInserta.RootElement.Text = resources.GetString("RadButtonInserta.RootElement.Text")
        Me.RadButtonInserta.RootElement.TextOrientation = CType(resources.GetObject("RadButtonInserta.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'CantidadInvTextBox
        '
        Me.CantidadInvTextBox.AllowDrop = True
        resources.ApplyResources(Me.CantidadInvTextBox, "CantidadInvTextBox")
        resources.ApplyResources(Appearance2.FontData, "Appearance2.FontData")
        resources.ApplyResources(Appearance2, "Appearance2")
        Appearance2.ForceApplyResources = "FontData|"
        Me.CantidadInvTextBox.Appearance = Appearance2
        Me.CantidadInvTextBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.CantidadInvTextBox.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.CantidadInvTextBox.InputMask = "nnn,nnn.nn"
        Me.CantidadInvTextBox.Name = "CantidadInvTextBox"
        Me.CantidadInvTextBox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        '
        'RadButtonEliminar
        '
        resources.ApplyResources(Me.RadButtonEliminar, "RadButtonEliminar")
        Me.RadButtonEliminar.Name = "RadButtonEliminar"
        '
        '
        '
        Me.RadButtonEliminar.RootElement.Alignment = CType(resources.GetObject("RadButtonEliminar.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.RadButtonEliminar.RootElement.AngleTransform = CType(resources.GetObject("RadButtonEliminar.RootElement.AngleTransform"), Single)
        Me.RadButtonEliminar.RootElement.FlipText = CType(resources.GetObject("RadButtonEliminar.RootElement.FlipText"), Boolean)
        Me.RadButtonEliminar.RootElement.Margin = CType(resources.GetObject("RadButtonEliminar.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.RadButtonEliminar.RootElement.Padding = CType(resources.GetObject("RadButtonEliminar.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.RadButtonEliminar.RootElement.StringAlignment = CType(resources.GetObject("RadButtonEliminar.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.RadButtonEliminar.RootElement.Text = resources.GetString("RadButtonEliminar.RootElement.Text")
        Me.RadButtonEliminar.RootElement.TextOrientation = CType(resources.GetObject("RadButtonEliminar.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        '
        'TxtPrecio
        '
        Me.TxtPrecio.AllowDrop = True
        resources.ApplyResources(Me.TxtPrecio, "TxtPrecio")
        resources.ApplyResources(Appearance1.FontData, "Appearance1.FontData")
        resources.ApplyResources(Appearance1, "Appearance1")
        Appearance1.ForceApplyResources = "FontData|"
        Me.TxtPrecio.Appearance = Appearance1
        Me.TxtPrecio.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.TxtPrecio.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.TxtPrecio.InputMask = "nn,nnn,nnn.nn"
        Me.TxtPrecio.Name = "TxtPrecio"
        Me.TxtPrecio.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        '
        'CodigoProdTextBox
        '
        resources.ApplyResources(Me.CodigoProdTextBox, "CodigoProdTextBox")
        Me.CodigoProdTextBox.Name = "CodigoProdTextBox"
        '
        '
        '
        Me.CodigoProdTextBox.RootElement.Alignment = CType(resources.GetObject("CodigoProdTextBox.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.CodigoProdTextBox.RootElement.AngleTransform = CType(resources.GetObject("CodigoProdTextBox.RootElement.AngleTransform"), Single)
        Me.CodigoProdTextBox.RootElement.FlipText = CType(resources.GetObject("CodigoProdTextBox.RootElement.FlipText"), Boolean)
        Me.CodigoProdTextBox.RootElement.Margin = CType(resources.GetObject("CodigoProdTextBox.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.CodigoProdTextBox.RootElement.Padding = CType(resources.GetObject("CodigoProdTextBox.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.CodigoProdTextBox.RootElement.StringAlignment = CType(resources.GetObject("CodigoProdTextBox.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.CodigoProdTextBox.RootElement.Text = resources.GetString("CodigoProdTextBox.RootElement.Text")
        Me.CodigoProdTextBox.RootElement.TextOrientation = CType(resources.GetObject("CodigoProdTextBox.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.CodigoProdTextBox.TabStop = False
        '
        'CodCodigoRadTextBox
        '
        resources.ApplyResources(Me.CodCodigoRadTextBox, "CodCodigoRadTextBox")
        Me.CodCodigoRadTextBox.Name = "CodCodigoRadTextBox"
        '
        '
        '
        Me.CodCodigoRadTextBox.RootElement.Alignment = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.Alignment"), System.Drawing.ContentAlignment)
        Me.CodCodigoRadTextBox.RootElement.AngleTransform = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.AngleTransform"), Single)
        Me.CodCodigoRadTextBox.RootElement.FlipText = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.FlipText"), Boolean)
        Me.CodCodigoRadTextBox.RootElement.Margin = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.Margin"), System.Windows.Forms.Padding)
        Me.CodCodigoRadTextBox.RootElement.Padding = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.Padding"), System.Windows.Forms.Padding)
        Me.CodCodigoRadTextBox.RootElement.StringAlignment = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.StringAlignment"), System.Drawing.StringAlignment)
        Me.CodCodigoRadTextBox.RootElement.Text = resources.GetString("CodCodigoRadTextBox.RootElement.Text")
        Me.CodCodigoRadTextBox.RootElement.TextOrientation = CType(resources.GetObject("CodCodigoRadTextBox.RootElement.TextOrientation"), System.Windows.Forms.Orientation)
        Me.CodCodigoRadTextBox.TabStop = False
        '
        'UltraPopupControlContainer1
        '
        Me.UltraPopupControlContainer1.PopupControl = Me.BuscadorGroupBox
        '
        'PRODUCTOSTableAdapter
        '
        Me.PRODUCTOSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.FAMILIATableAdapter = Nothing
        Me.TableAdapterManager.IVATableAdapter = Nothing
        Me.TableAdapterManager.LINEATableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PROVEEDORTableAdapter = Nothing
        Me.TableAdapterManager.RUBROTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCLIENTETableAdapter = Nothing
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProductosTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PRODUCTOSBindingSource1
        '
        Me.PRODUCTOSBindingSource1.DataMember = "PRODUCTOS"
        Me.PRODUCTOSBindingSource1.DataSource = Me.DsProductos
        '
        'TableAdapterManager2
        '
        Me.TableAdapterManager2.AJUSTEDETALLETableAdapter = Nothing
        Me.TableAdapterManager2.AJUSTETableAdapter = Nothing
        Me.TableAdapterManager2.AUDITORIATABLASTableAdapter = Nothing
        Me.TableAdapterManager2.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager2.CONCEPTOTableAdapter = Nothing
        Me.TableAdapterManager2.Connection = Nothing
        Me.TableAdapterManager2.LINEATableAdapter = Nothing
        Me.TableAdapterManager2.MONEDATableAdapter = Nothing
        Me.TableAdapterManager2.RUBROTableAdapter = Nothing
        Me.TableAdapterManager2.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager2.TIPOCOMPROBANTETableAdapter = Nothing
        Me.TableAdapterManager2.TRANFERENCIATableAdapter = Nothing
        Me.TableAdapterManager2.TRANSFERENCIASDETALLETableAdapter = Nothing
        Me.TableAdapterManager2.UpdateOrder = ContaExpress.DsInventarioTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CODIGOSTableAdapter
        '
        Me.CODIGOSTableAdapter.ClearBeforeFill = True
        '
        'RadTextBoxDesproducto
        '
        resources.ApplyResources(Me.RadTextBoxDesproducto, "RadTextBoxDesproducto")
        Me.RadTextBoxDesproducto.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.RadTextBoxDesproducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RadTextBoxDesproducto.Name = "RadTextBoxDesproducto"
        '
        'RadTextBoxBuscar
        '
        Me.RadTextBoxBuscar.BackColor = System.Drawing.Color.Tan
        Me.RadTextBoxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RadTextBoxBuscar.Cursor = System.Windows.Forms.Cursors.Arrow
        resources.ApplyResources(Me.RadTextBoxBuscar, "RadTextBoxBuscar")
        Me.RadTextBoxBuscar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.RadTextBoxBuscar.Name = "RadTextBoxBuscar"
        '
        'RadComboBoxSucursal
        '
        resources.ApplyResources(Me.RadComboBoxSucursal, "RadComboBoxSucursal")
        Me.RadComboBoxSucursal.DataSource = Me.SUCURSALBindingSource
        Me.RadComboBoxSucursal.DisplayMember = "DESSUCURSAL"
        Me.RadComboBoxSucursal.FormattingEnabled = True
        Me.RadComboBoxSucursal.Name = "RadComboBoxSucursal"
        Me.RadComboBoxSucursal.ValueMember = "CODSUCURSAL"
        '
        'SUCURSALBindingSource
        '
        Me.SUCURSALBindingSource.DataMember = "SUCURSAL"
        Me.SUCURSALBindingSource.DataSource = Me.DsInventario
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Name = "Label3"
        '
        'SUCURSALTableAdapter
        '
        Me.SUCURSALTableAdapter.ClearBeforeFill = True
        '
        'TbxCodigoProducto
        '
        resources.ApplyResources(Me.TbxCodigoProducto, "TbxCodigoProducto")
        Me.TbxCodigoProducto.BackColor = System.Drawing.Color.White
        Me.TbxCodigoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TbxCodigoProducto.Name = "TbxCodigoProducto"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Name = "Label4"
        '
        'dgwStockInicial
        '
        Me.dgwStockInicial.AllowUserToAddRows = False
        Me.dgwStockInicial.AllowUserToDeleteRows = False
        Me.dgwStockInicial.AllowUserToResizeColumns = False
        Me.dgwStockInicial.AllowUserToResizeRows = False
        resources.ApplyResources(Me.dgwStockInicial, "dgwStockInicial")
        Me.dgwStockInicial.AutoGenerateColumns = False
        Me.dgwStockInicial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgwStockInicial.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGODataGridViewTextBoxColumn, Me.DESPRODUCTODataGridViewTextBoxColumn, Me.DESSUCURSALDataGridViewTextBoxColumn, Me.CANTIDADDataGridViewTextBoxColumn, Me.VALORDataGridViewTextBoxColumn, Me.FECHAMOVIMIENTODataGridViewTextBoxColumn, Me.CONCEPTODataGridViewTextBoxColumn, Me.CODMOVIMIENTO})
        Me.dgwStockInicial.DataSource = Me.STOCKINICIALBindingSource
        Me.dgwStockInicial.Name = "dgwStockInicial"
        Me.dgwStockInicial.ReadOnly = True
        Me.dgwStockInicial.RowHeadersVisible = False
        Me.dgwStockInicial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'STOCKINICIALBindingSource
        '
        Me.STOCKINICIALBindingSource.DataMember = "STOCKINICIAL"
        Me.STOCKINICIALBindingSource.DataSource = Me.DsProductos
        '
        'DsProductos1
        '
        Me.DsProductos1.DataSetName = "DsProductos"
        Me.DsProductos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel5
        '
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.RadTextBoxBuscar)
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Name = "Panel5"
        '
        'STOCKINICIALTableAdapter1
        '
        Me.STOCKINICIALTableAdapter1.ClearBeforeFill = True
        '
        'BtnAsterisco
        '
        resources.ApplyResources(Me.BtnAsterisco, "BtnAsterisco")
        Me.BtnAsterisco.BackColor = System.Drawing.Color.Transparent
        Me.BtnAsterisco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAsterisco.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.BtnAsterisco.Name = "BtnAsterisco"
        Me.BtnAsterisco.TabStop = False
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Name = "Label5"
        '
        'dtpFecha
        '
        resources.ApplyResources(Me.dtpFecha, "dtpFecha")
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Name = "dtpFecha"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.SizingGrip = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Image = Global.ContaExpress.My.Resources.Resources.help
        Me.ToolStripStatusLabel1.IsLink = True
        Me.ToolStripStatusLabel1.LinkColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Black
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        Me.ToolStripStatusLabel2.Spring = True
        '
        'CODIGODataGridViewTextBoxColumn
        '
        Me.CODIGODataGridViewTextBoxColumn.DataPropertyName = "CODIGO"
        Me.CODIGODataGridViewTextBoxColumn.FillWeight = 70.0!
        resources.ApplyResources(Me.CODIGODataGridViewTextBoxColumn, "CODIGODataGridViewTextBoxColumn")
        Me.CODIGODataGridViewTextBoxColumn.Name = "CODIGODataGridViewTextBoxColumn"
        Me.CODIGODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESPRODUCTODataGridViewTextBoxColumn
        '
        Me.DESPRODUCTODataGridViewTextBoxColumn.DataPropertyName = "DESPRODUCTO"
        Me.DESPRODUCTODataGridViewTextBoxColumn.FillWeight = 230.0!
        resources.ApplyResources(Me.DESPRODUCTODataGridViewTextBoxColumn, "DESPRODUCTODataGridViewTextBoxColumn")
        Me.DESPRODUCTODataGridViewTextBoxColumn.Name = "DESPRODUCTODataGridViewTextBoxColumn"
        Me.DESPRODUCTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'DESSUCURSALDataGridViewTextBoxColumn
        '
        Me.DESSUCURSALDataGridViewTextBoxColumn.DataPropertyName = "DESSUCURSAL"
        Me.DESSUCURSALDataGridViewTextBoxColumn.FillWeight = 80.0!
        resources.ApplyResources(Me.DESSUCURSALDataGridViewTextBoxColumn, "DESSUCURSALDataGridViewTextBoxColumn")
        Me.DESSUCURSALDataGridViewTextBoxColumn.Name = "DESSUCURSALDataGridViewTextBoxColumn"
        Me.DESSUCURSALDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CANTIDADDataGridViewTextBoxColumn
        '
        Me.CANTIDADDataGridViewTextBoxColumn.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.CANTIDADDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.CANTIDADDataGridViewTextBoxColumn.FillWeight = 60.0!
        resources.ApplyResources(Me.CANTIDADDataGridViewTextBoxColumn, "CANTIDADDataGridViewTextBoxColumn")
        Me.CANTIDADDataGridViewTextBoxColumn.Name = "CANTIDADDataGridViewTextBoxColumn"
        Me.CANTIDADDataGridViewTextBoxColumn.ReadOnly = True
        '
        'VALORDataGridViewTextBoxColumn
        '
        Me.VALORDataGridViewTextBoxColumn.DataPropertyName = "VALOR"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.VALORDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.VALORDataGridViewTextBoxColumn.FillWeight = 60.0!
        resources.ApplyResources(Me.VALORDataGridViewTextBoxColumn, "VALORDataGridViewTextBoxColumn")
        Me.VALORDataGridViewTextBoxColumn.Name = "VALORDataGridViewTextBoxColumn"
        Me.VALORDataGridViewTextBoxColumn.ReadOnly = True
        '
        'FECHAMOVIMIENTODataGridViewTextBoxColumn
        '
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.DataPropertyName = "FECHAMOVIMIENTO"
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.FillWeight = 60.0!
        resources.ApplyResources(Me.FECHAMOVIMIENTODataGridViewTextBoxColumn, "FECHAMOVIMIENTODataGridViewTextBoxColumn")
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.Name = "FECHAMOVIMIENTODataGridViewTextBoxColumn"
        Me.FECHAMOVIMIENTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CONCEPTODataGridViewTextBoxColumn
        '
        Me.CONCEPTODataGridViewTextBoxColumn.DataPropertyName = "CONCEPTO"
        resources.ApplyResources(Me.CONCEPTODataGridViewTextBoxColumn, "CONCEPTODataGridViewTextBoxColumn")
        Me.CONCEPTODataGridViewTextBoxColumn.Name = "CONCEPTODataGridViewTextBoxColumn"
        Me.CONCEPTODataGridViewTextBoxColumn.ReadOnly = True
        '
        'CODMOVIMIENTO
        '
        Me.CODMOVIMIENTO.DataPropertyName = "CODMOVIMIENTO"
        resources.ApplyResources(Me.CODMOVIMIENTO, "CODMOVIMIENTO")
        Me.CODMOVIMIENTO.Name = "CODMOVIMIENTO"
        Me.CODMOVIMIENTO.ReadOnly = True
        '
        'StockInicial
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPrecio)
        Me.Controls.Add(Me.TbxCodigoProducto)
        Me.Controls.Add(Me.BtnAsterisco)
        Me.Controls.Add(Me.BuscadorGroupBox)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CantidadInvTextBox)
        Me.Controls.Add(Me.RadButtonEliminar)
        Me.Controls.Add(Me.RadButtonInserta)
        Me.Controls.Add(Me.RadTextBoxDesproducto)
        Me.Controls.Add(Me.RadComboBoxSucursal)
        Me.Controls.Add(Me.dgwStockInicial)
        Me.Controls.Add(Me.CodigoProdTextBox)
        Me.Controls.Add(Me.CodCodigoRadTextBox)
        Me.Name = "StockInicial"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        CType(Me.PRODUCTOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BuscadorGroupBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BuscadorGroupBox.ResumeLayout(False)
        Me.BuscadorGroupBox.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BuscadorGridView.MasterGridViewTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BuscadorGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CODIGOSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsInventario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButtonInserta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadButtonEliminar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodigoProdTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CodCodigoRadTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRODUCTOSBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SUCURSALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwStockInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.STOCKINICIALBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProductos1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.BtnAsterisco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DsProductos As ContaExpress.DsProductos
    Friend WithEvents DsProductosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRODUCTOSTableAdapter As ContaExpress.DsProductosTableAdapters.PRODUCTOSTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsProductosTableAdapters.TableAdapterManager
    Friend WithEvents BuscadorGroupBox As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadButtonInserta As Telerik.WinControls.UI.RadButton
    Friend WithEvents CantidadInvTextBox As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents RadButtonEliminar As Telerik.WinControls.UI.RadButton
    Friend WithEvents CodigoProdTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents UltraPopupControlContainer1 As Infragistics.Win.Misc.UltraPopupControlContainer
    Friend WithEvents PRODUCTOSBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BuscadorGridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents CodCodigoRadTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents DsInventario As ContaExpress.DsInventario
    Friend WithEvents TableAdapterManager2 As ContaExpress.DsInventarioTableAdapters.TableAdapterManager
    Friend WithEvents CODIGOSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CODIGOSTableAdapter As ContaExpress.DsInventarioTableAdapters.CODIGOSTableAdapter
    Friend WithEvents TxtPrecio As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents RadTextBoxDesproducto As System.Windows.Forms.TextBox
    Friend WithEvents RadTextBoxBuscar As System.Windows.Forms.TextBox
    Friend WithEvents RadComboBoxSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscadorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SUCURSALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SUCURSALTableAdapter As ContaExpress.DsInventarioTableAdapters.SUCURSALTableAdapter
    Friend WithEvents TbxCodigoProducto As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgwStockInicial As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents DsProductos1 As ContaExpress.DsProductos
    Friend WithEvents STOCKINICIALTableAdapter As ContaExpress.DsProductosTableAdapters.STOCKINICIALTableAdapter
    Friend WithEvents CODMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents STOCKINICIALBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents STOCKINICIALTableAdapter1 As ContaExpress.DsProductosTableAdapters.STOCKINICIALTableAdapter
    Friend WithEvents BtnAsterisco As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CODIGODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESPRODUCTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESSUCURSALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALORDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAMOVIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONCEPTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMOVIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
