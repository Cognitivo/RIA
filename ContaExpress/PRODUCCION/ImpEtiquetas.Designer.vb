<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImpEtiquetas
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
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpEtiquetas))
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pnlDetalle = New System.Windows.Forms.Panel()
        Me.tbxCantEtiquetas = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxMarcarTodos = New System.Windows.Forms.CheckBox()
        Me.tbxTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.OPDETALLEDataGridView = New System.Windows.Forms.DataGridView()
        Me.OPDETALLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtCodProductoMP = New System.Windows.Forms.TextBox()
        Me.TotalIvaVentaMaskedEdit = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgwOrdenProduccion = New System.Windows.Forms.DataGridView()
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
        Me.BtnFiltro = New Telerik.WinControls.UI.RadButton()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.rbnMateriaPrima = New System.Windows.Forms.RadioButton()
        Me.rbnProductosTerminados = New System.Windows.Forms.RadioButton()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.CODIGOLOTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ORDENPRODUCCIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsOrdProduccion = New ContaExpress.dsOrdProduccion()
        Me.ORDENPRODUCCIONTableAdapter = New ContaExpress.dsOrdProduccionTableAdapters.ORDENPRODUCCIONTableAdapter()
        Me.OPDETALLETableAdapter = New ContaExpress.dsOrdProduccionTableAdapters.OPDETALLETableAdapter()
        Me.TableAdapterManager = New ContaExpress.dsOrdProduccionTableAdapters.TableAdapterManager()
        Me.NROORDENTRABAJO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODIGO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad_Lote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Marcar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESLINEA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESFAMILIA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlDetalle.SuspendLayout()
        CType(Me.OPDETALLEDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OPDETALLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgwOrdenProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrdProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(637, 35)
        Me.Panel5.TabIndex = 471
        '
        'pnlDetalle
        '
        Me.pnlDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlDetalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlDetalle.BackColor = System.Drawing.Color.LightGray
        Me.pnlDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDetalle.Controls.Add(Me.tbxCantEtiquetas)
        Me.pnlDetalle.Controls.Add(Me.Label1)
        Me.pnlDetalle.Controls.Add(Me.cbxMarcarTodos)
        Me.pnlDetalle.Controls.Add(Me.tbxTotal)
        Me.pnlDetalle.Controls.Add(Me.Label4)
        Me.pnlDetalle.Controls.Add(Me.OPDETALLEDataGridView)
        Me.pnlDetalle.Controls.Add(Me.txtCodProductoMP)
        Me.pnlDetalle.Controls.Add(Me.TotalIvaVentaMaskedEdit)
        Me.pnlDetalle.Location = New System.Drawing.Point(4, 69)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(629, 434)
        Me.pnlDetalle.TabIndex = 470
        '
        'tbxCantEtiquetas
        '
        Me.tbxCantEtiquetas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxCantEtiquetas.BackColor = System.Drawing.Color.White
        Me.tbxCantEtiquetas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantEtiquetas.CausesValidation = False
        Me.tbxCantEtiquetas.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.tbxCantEtiquetas.Location = New System.Drawing.Point(153, 4)
        Me.tbxCantEtiquetas.Name = "tbxCantEtiquetas"
        Me.tbxCantEtiquetas.Size = New System.Drawing.Size(34, 24)
        Me.tbxCantEtiquetas.TabIndex = 528
        Me.tbxCantEtiquetas.Text = "1"
        Me.tbxCantEtiquetas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 10.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 19)
        Me.Label1.TabIndex = 527
        Me.Label1.Text = "Cantidad de Etiquetas:"
        '
        'cbxMarcarTodos
        '
        Me.cbxMarcarTodos.AutoSize = True
        Me.cbxMarcarTodos.Location = New System.Drawing.Point(529, 8)
        Me.cbxMarcarTodos.Name = "cbxMarcarTodos"
        Me.cbxMarcarTodos.Size = New System.Drawing.Size(92, 17)
        Me.cbxMarcarTodos.TabIndex = 526
        Me.cbxMarcarTodos.Text = "Marcar Todos"
        Me.cbxMarcarTodos.UseVisualStyleBackColor = True
        '
        'tbxTotal
        '
        Me.tbxTotal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.tbxTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTotal.CausesValidation = False
        Me.tbxTotal.Enabled = False
        Me.tbxTotal.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.tbxTotal.Location = New System.Drawing.Point(452, 402)
        Me.tbxTotal.Name = "tbxTotal"
        Me.tbxTotal.Size = New System.Drawing.Size(172, 27)
        Me.tbxTotal.TabIndex = 525
        Me.tbxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Light", 13.0!)
        Me.Label4.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label4.Location = New System.Drawing.Point(312, 403)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 25)
        Me.Label4.TabIndex = 524
        Me.Label4.Text = "Total  Producido:"
        '
        'OPDETALLEDataGridView
        '
        Me.OPDETALLEDataGridView.AllowUserToAddRows = False
        Me.OPDETALLEDataGridView.AllowUserToDeleteRows = False
        Me.OPDETALLEDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OPDETALLEDataGridView.AutoGenerateColumns = False
        Me.OPDETALLEDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OPDETALLEDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.OPDETALLEDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OPDETALLEDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NROORDENTRABAJO, Me.CODIGO, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn5, Me.Cantidad_Lote, Me.Marcar, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn6, Me.DESLINEA, Me.DESFAMILIA, Me.NOMBRE})
        Me.OPDETALLEDataGridView.DataSource = Me.OPDETALLEBindingSource
        Me.OPDETALLEDataGridView.Location = New System.Drawing.Point(7, 31)
        Me.OPDETALLEDataGridView.Name = "OPDETALLEDataGridView"
        Me.OPDETALLEDataGridView.RowHeadersVisible = False
        Me.OPDETALLEDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.OPDETALLEDataGridView.Size = New System.Drawing.Size(617, 368)
        Me.OPDETALLEDataGridView.TabIndex = 514
        '
        'OPDETALLEBindingSource
        '
        Me.OPDETALLEBindingSource.DataMember = "ORDENPRODUCCION_OPDETALLE"
        Me.OPDETALLEBindingSource.DataSource = Me.ORDENPRODUCCIONBindingSource
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
        Me.TotalIvaVentaMaskedEdit.Location = New System.Drawing.Point(409, 481)
        Me.TotalIvaVentaMaskedEdit.Name = "TotalIvaVentaMaskedEdit"
        Me.TotalIvaVentaMaskedEdit.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TotalIvaVentaMaskedEdit.ReadOnly = True
        Me.TotalIvaVentaMaskedEdit.Size = New System.Drawing.Size(111, 28)
        Me.TotalIvaVentaMaskedEdit.TabIndex = 485
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.rbnMateriaPrima)
        Me.SplitContainer1.Panel2.Controls.Add(Me.rbnProductosTerminados)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnImprimir)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pnlDetalle)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel5)
        Me.SplitContainer1.Size = New System.Drawing.Size(879, 507)
        Me.SplitContainer1.SplitterDistance = 237
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwOrdenProduccion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgwOrdenProduccion.ColumnHeadersHeight = 35
        Me.dgwOrdenProduccion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIGOLOTEDataGridViewTextBoxColumn, Me.FECHADataGridViewTextBoxColumn, Me.IDDataGridViewTextBoxColumn})
        Me.dgwOrdenProduccion.DataSource = Me.ORDENPRODUCCIONBindingSource
        Me.dgwOrdenProduccion.Location = New System.Drawing.Point(-1, 69)
        Me.dgwOrdenProduccion.Name = "dgwOrdenProduccion"
        Me.dgwOrdenProduccion.RowHeadersVisible = False
        Me.dgwOrdenProduccion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwOrdenProduccion.Size = New System.Drawing.Size(237, 438)
        Me.dgwOrdenProduccion.TabIndex = 496
        '
        'CmbAño
        '
        Me.CmbAño.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbAño.BackColor = System.Drawing.Color.White
        Me.CmbAño.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.CmbAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.CmbAño.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem13, Me.RadComboBoxItem14, Me.RadComboBoxItem15, Me.RadComboBoxItem16, Me.RadComboBoxItem17, Me.RadComboBoxItem18, Me.RadComboBoxItem19, Me.RadComboBoxItem20, Me.RadComboBoxItem21, Me.RadComboBoxItem22, Me.RadComboBoxItem23})
        Me.CmbAño.Location = New System.Drawing.Point(114, 40)
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
        Me.CmbAño.Size = New System.Drawing.Size(67, 26)
        Me.CmbAño.TabIndex = 496
        Me.CmbAño.TabStop = False
        Me.CmbAño.ThemeName = "Breeze"
        CType(Me.CmbAño.GetChildAt(0), Telerik.WinControls.UI.RadComboBoxElement).Font = New System.Drawing.Font("Arial", 12.0!)
        CType(Me.CmbAño.GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.White
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
        'BtnFiltro
        '
        Me.BtnFiltro.AllowDrop = True
        Me.BtnFiltro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnFiltro.BackColor = System.Drawing.Color.Transparent
        Me.BtnFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnFiltro.Location = New System.Drawing.Point(184, 40)
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
        Me.BuscarTextBox.Size = New System.Drawing.Size(204, 35)
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
        Me.CmbMes.Items.AddRange(New Telerik.WinControls.RadItem() {Me.RadComboBoxItem1, Me.RadComboBoxItem2, Me.RadComboBoxItem3, Me.RadComboBoxItem4, Me.RadComboBoxItem5, Me.RadComboBoxItem6, Me.RadComboBoxItem7, Me.RadComboBoxItem8, Me.RadComboBoxItem9, Me.RadComboBoxItem10, Me.RadComboBoxItem11, Me.RadComboBoxItem12})
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
        Me.CmbMes.Size = New System.Drawing.Size(109, 26)
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
        'rbnMateriaPrima
        '
        Me.rbnMateriaPrima.AutoSize = True
        Me.rbnMateriaPrima.BackColor = System.Drawing.Color.Transparent
        Me.rbnMateriaPrima.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rbnMateriaPrima.Location = New System.Drawing.Point(157, 39)
        Me.rbnMateriaPrima.Name = "rbnMateriaPrima"
        Me.rbnMateriaPrima.Size = New System.Drawing.Size(161, 24)
        Me.rbnMateriaPrima.TabIndex = 510
        Me.rbnMateriaPrima.Text = "Para Materia Prima"
        Me.rbnMateriaPrima.UseVisualStyleBackColor = False
        '
        'rbnProductosTerminados
        '
        Me.rbnProductosTerminados.AutoSize = True
        Me.rbnProductosTerminados.BackColor = System.Drawing.Color.Transparent
        Me.rbnProductosTerminados.Checked = True
        Me.rbnProductosTerminados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.rbnProductosTerminados.Location = New System.Drawing.Point(4, 41)
        Me.rbnProductosTerminados.Name = "rbnProductosTerminados"
        Me.rbnProductosTerminados.Size = New System.Drawing.Size(136, 24)
        Me.rbnProductosTerminados.TabIndex = 509
        Me.rbnProductosTerminados.TabStop = True
        Me.rbnProductosTerminados.Text = "Para Productos"
        Me.rbnProductosTerminados.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnImprimir.ForeColor = System.Drawing.Color.White
        Me.btnImprimir.Location = New System.Drawing.Point(497, 38)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(136, 27)
        Me.btnImprimir.TabIndex = 505
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'CODIGOLOTEDataGridViewTextBoxColumn
        '
        Me.CODIGOLOTEDataGridViewTextBoxColumn.DataPropertyName = "CODIGOLOTE"
        Me.CODIGOLOTEDataGridViewTextBoxColumn.FillWeight = 110.0!
        Me.CODIGOLOTEDataGridViewTextBoxColumn.HeaderText = "Código"
        Me.CODIGOLOTEDataGridViewTextBoxColumn.Name = "CODIGOLOTEDataGridViewTextBoxColumn"
        '
        'FECHADataGridViewTextBoxColumn
        '
        Me.FECHADataGridViewTextBoxColumn.DataPropertyName = "FECHA"
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.FECHADataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.FECHADataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FECHADataGridViewTextBoxColumn.Name = "FECHADataGridViewTextBoxColumn"
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'ORDENPRODUCCIONBindingSource
        '
        Me.ORDENPRODUCCIONBindingSource.DataMember = "ORDENPRODUCCION"
        Me.ORDENPRODUCCIONBindingSource.DataSource = Me.DsOrdProduccion
        '
        'DsOrdProduccion
        '
        Me.DsOrdProduccion.DataSetName = "dsOrdProduccion"
        Me.DsOrdProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ORDENPRODUCCIONTableAdapter
        '
        Me.ORDENPRODUCCIONTableAdapter.ClearBeforeFill = True
        '
        'OPDETALLETableAdapter
        '
        Me.OPDETALLETableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.dsOrdProduccionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'NROORDENTRABAJO
        '
        Me.NROORDENTRABAJO.DataPropertyName = "NROORDENTRABAJO"
        Me.NROORDENTRABAJO.HeaderText = "Nro Pedido"
        Me.NROORDENTRABAJO.Name = "NROORDENTRABAJO"
        '
        'CODIGO
        '
        Me.CODIGO.DataPropertyName = "CODIGO"
        Me.CODIGO.HeaderText = "Código"
        Me.CODIGO.Name = "CODIGO"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DESPRODUCTO"
        Me.DataGridViewTextBoxColumn2.FillWeight = 220.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Producto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CANTIDAD"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cantidad Producida"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'Cantidad_Lote
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Cantidad_Lote.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cantidad_Lote.HeaderText = "Cantidad por Lote"
        Me.Cantidad_Lote.Name = "Cantidad_Lote"
        '
        'Marcar
        '
        Me.Marcar.FillWeight = 60.0!
        Me.Marcar.HeaderText = "Marcar"
        Me.Marcar.Name = "Marcar"
        Me.Marcar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Marcar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CODCODIGO"
        Me.DataGridViewTextBoxColumn3.HeaderText = "CODCODIGO"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ID_ORDEN_PRODUCCION"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ID_ORDEN_PRODUCCION"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DESLINEA
        '
        Me.DESLINEA.DataPropertyName = "DESLINEA"
        Me.DESLINEA.HeaderText = "DESLINEA"
        Me.DESLINEA.Name = "DESLINEA"
        Me.DESLINEA.Visible = False
        '
        'DESFAMILIA
        '
        Me.DESFAMILIA.DataPropertyName = "DESFAMILIA"
        Me.DESFAMILIA.HeaderText = "DESFAMILIA"
        Me.DESFAMILIA.Name = "DESFAMILIA"
        Me.DESFAMILIA.Visible = False
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.Visible = False
        '
        'ImpEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(879, 507)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ImpEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Impresion de Etiquetas | Cogent SIG"
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlDetalle.PerformLayout()
        CType(Me.OPDETALLEDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OPDETALLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgwOrdenProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbAño, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnFiltro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ORDENPRODUCCIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOrdProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pnlDetalle As System.Windows.Forms.Panel
    Friend WithEvents txtCodProductoMP As System.Windows.Forms.TextBox
    Friend WithEvents TotalIvaVentaMaskedEdit As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgwOrdenProduccion As System.Windows.Forms.DataGridView
    Friend WithEvents ORDENPRODUCCIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsOrdProduccion As ContaExpress.dsOrdProduccion
    Friend WithEvents CmbAño As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents BtnFiltro As Telerik.WinControls.UI.RadButton
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmbMes As Telerik.WinControls.UI.RadComboBox
    Friend WithEvents ORDENPRODUCCIONTableAdapter As ContaExpress.dsOrdProduccionTableAdapters.ORDENPRODUCCIONTableAdapter
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
    Friend WithEvents OPDETALLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OPDETALLETableAdapter As ContaExpress.dsOrdProduccionTableAdapters.OPDETALLETableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.dsOrdProduccionTableAdapters.TableAdapterManager
    Friend WithEvents OPDETALLEDataGridView As System.Windows.Forms.DataGridView
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
    Friend WithEvents NROORDENTRABAJODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbxMarcarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents tbxTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents rbnMateriaPrima As System.Windows.Forms.RadioButton
    Friend WithEvents rbnProductosTerminados As System.Windows.Forms.RadioButton
    Friend WithEvents tbxCantEtiquetas As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CODIGOLOTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NROORDENTRABAJO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODIGO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad_Lote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Marcar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESLINEA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESFAMILIA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
