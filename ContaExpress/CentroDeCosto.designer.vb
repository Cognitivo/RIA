<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class CentroDeCosto
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend WithEvents BuscarChoferTextBox As System.Windows.Forms.TextBox
    Friend  WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend  WithEvents CENTROCOSTOBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents CentroCostoGridView As Telerik.WinControls.UI.RadGridView
    Friend  WithEvents CENTROCOSTOTableAdapter As ContaExpress.DsCentroDeCostoTableAdapters.CENTROCOSTOTableAdapter
    Friend  WithEvents CodCentroTextBox As System.Windows.Forms.TextBox
    Friend  WithEvents ConceptoTextBox As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents CostoFijoCheckBox As Telerik.WinControls.UI.RadCheckBox
    Friend  WithEvents DesCentroTextBox As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents DsCentroDeCosto As ContaExpress.DsCentroDeCosto
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend  WithEvents EnlazadoCheckBox As Telerik.WinControls.UI.RadCheckBox
    Friend  WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend  WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelFocoRango As System.Windows.Forms.Panel
    Friend WithEvents PrioridadCheckBox As Telerik.WinControls.UI.RadCheckBox
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend  WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    #End Region 'Fields

    #Region "Methods"

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CentroDeCosto))
        Me.CentroCostoGridView = New Telerik.WinControls.UI.RadGridView()
        Me.CENTROCOSTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsCentroDeCosto = New ContaExpress.DsCentroDeCosto()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.DesCentroTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.CostoFijoCheckBox = New Telerik.WinControls.UI.RadCheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EnlazadoCheckBox = New Telerik.WinControls.UI.RadCheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConceptoTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.PanelFocoRango = New System.Windows.Forms.Panel()
        Me.CodCentroTextBox = New System.Windows.Forms.TextBox()
        Me.BuscarChoferTextBox = New System.Windows.Forms.TextBox()
        Me.PrioridadCheckBox = New Telerik.WinControls.UI.RadCheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CENTROCOSTOTableAdapter = New ContaExpress.DsCentroDeCostoTableAdapters.CENTROCOSTOTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.CentroCostoGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsCentroDeCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DesCentroTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CostoFijoCheckBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CostoFijoCheckBox.SuspendLayout()
        CType(Me.EnlazadoCheckBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EnlazadoCheckBox.SuspendLayout()
        CType(Me.ConceptoTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PrioridadCheckBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CentroCostoGridView
        '
        Me.CentroCostoGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CentroCostoGridView.BackColor = System.Drawing.Color.White
        Me.CentroCostoGridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.CentroCostoGridView.EnableAlternatingRowColor = True
        Me.CentroCostoGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CentroCostoGridView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CentroCostoGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CentroCostoGridView.Location = New System.Drawing.Point(-1, 41)
        '
        '
        '
        Me.CentroCostoGridView.MasterGridViewTemplate.AllowAddNewRow = False
        Me.CentroCostoGridView.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODCENTRO"
        GridViewDecimalColumn1.FieldName = "CODCENTRO"
        GridViewDecimalColumn1.HeaderText = "CODCENTRO"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODCENTRO"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn2.FieldName = "CODUSUARIO"
        GridViewDecimalColumn2.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn3.FieldName = "CODEMPRESA"
        GridViewDecimalColumn3.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODEMPRESA"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODSUCURSAL"
        GridViewDecimalColumn4.FieldName = "CODSUCURSAL"
        GridViewDecimalColumn4.HeaderText = "CODSUCURSAL"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODSUCURSAL"
        GridViewTextBoxColumn1.FieldAlias = "NUMCENTRO"
        GridViewTextBoxColumn1.FieldName = "NUMCENTRO"
        GridViewTextBoxColumn1.HeaderText = "NUMCENTRO"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.UniqueName = "NUMCENTRO"
        GridViewTextBoxColumn2.FieldAlias = "DESCENTRO"
        GridViewTextBoxColumn2.FieldName = "DESCENTRO"
        GridViewTextBoxColumn2.HeaderText = "Centro de Costo"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.UniqueName = "DESCENTRO"
        GridViewTextBoxColumn2.Width = 200
        GridViewDecimalColumn5.DataType = GetType(Byte)
        GridViewDecimalColumn5.FieldAlias = "PRIORIDAD"
        GridViewDecimalColumn5.FieldName = "PRIORIDAD"
        GridViewDecimalColumn5.HeaderText = "PRIORIDAD"
        GridViewDecimalColumn5.IsAutoGenerated = True
        GridViewDecimalColumn5.IsVisible = False
        GridViewDecimalColumn5.UniqueName = "PRIORIDAD"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        GridViewDecimalColumn6.DataType = GetType(Decimal)
        GridViewDecimalColumn6.FieldAlias = "ENLAZADO"
        GridViewDecimalColumn6.FieldName = "ENLAZADO"
        GridViewDecimalColumn6.HeaderText = "ENLAZADO"
        GridViewDecimalColumn6.IsAutoGenerated = True
        GridViewDecimalColumn6.IsVisible = False
        GridViewDecimalColumn6.UniqueName = "ENLAZADO"
        GridViewDecimalColumn7.DataType = GetType(Decimal)
        GridViewDecimalColumn7.FieldAlias = "COSTOFIJO"
        GridViewDecimalColumn7.FieldName = "COSTOFIJO"
        GridViewDecimalColumn7.HeaderText = "COSTOFIJO"
        GridViewDecimalColumn7.IsAutoGenerated = True
        GridViewDecimalColumn7.IsVisible = False
        GridViewDecimalColumn7.UniqueName = "COSTOFIJO"
        GridViewTextBoxColumn3.FieldAlias = "CONCEPTO"
        GridViewTextBoxColumn3.FieldName = "CONCEPTO"
        GridViewTextBoxColumn3.HeaderText = "CONCEPTO"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.UniqueName = "CONCEPTO"
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn5)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn6)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn7)
        Me.CentroCostoGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.CentroCostoGridView.MasterGridViewTemplate.DataSource = Me.CENTROCOSTOBindingSource
        Me.CentroCostoGridView.MasterGridViewTemplate.EnableFiltering = True
        Me.CentroCostoGridView.MasterGridViewTemplate.EnableGrouping = False
        Me.CentroCostoGridView.MasterGridViewTemplate.ShowFilteringRow = False
        Me.CentroCostoGridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.CentroCostoGridView.Name = "CentroCostoGridView"
        Me.CentroCostoGridView.ReadOnly = True
        Me.CentroCostoGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CentroCostoGridView.ShowGroupPanel = False
        Me.CentroCostoGridView.Size = New System.Drawing.Size(222, 361)
        Me.CentroCostoGridView.TabIndex = 1
        CType(Me.CentroCostoGridView.GetChildAt(0), Telerik.WinControls.UI.GridTableElement).Text = ""
        CType(Me.CentroCostoGridView.GetChildAt(0), Telerik.WinControls.UI.GridTableElement).BackColor = System.Drawing.Color.Lavender
        '
        'CENTROCOSTOBindingSource
        '
        Me.CENTROCOSTOBindingSource.DataMember = "CENTROCOSTO"
        Me.CENTROCOSTOBindingSource.DataSource = Me.DsCentroDeCosto
        '
        'DsCentroDeCosto
        '
        Me.DsCentroDeCosto.DataSetName = "DsCentroDeCosto"
        Me.DsCentroDeCosto.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel1.Location = New System.Drawing.Point(249, 116)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(81, 18)
        Me.RadLabel1.TabIndex = 0
        Me.RadLabel1.Text = "Descripcion:"
        '
        'DesCentroTextBox
        '
        Me.DesCentroTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CENTROCOSTOBindingSource, "DESCENTRO", True))
        Me.DesCentroTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesCentroTextBox.Location = New System.Drawing.Point(336, 111)
        Me.DesCentroTextBox.Name = "DesCentroTextBox"
        Me.DesCentroTextBox.Size = New System.Drawing.Size(291, 26)
        Me.DesCentroTextBox.TabIndex = 2
        Me.DesCentroTextBox.TabStop = False
        CType(Me.DesCentroTextBox.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        '
        'CostoFijoCheckBox
        '
        Me.CostoFijoCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.CostoFijoCheckBox.Controls.Add(Me.Label2)
        Me.CostoFijoCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CENTROCOSTOBindingSource, "COSTOFIJO", True))
        Me.CostoFijoCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CostoFijoCheckBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.CostoFijoCheckBox.Location = New System.Drawing.Point(336, 225)
        Me.CostoFijoCheckBox.Name = "CostoFijoCheckBox"
        '
        '
        '
        Me.CostoFijoCheckBox.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.CostoFijoCheckBox.Size = New System.Drawing.Size(258, 21)
        Me.CostoFijoCheckBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Calcula dentro de Costo Fijo"
        '
        'EnlazadoCheckBox
        '
        Me.EnlazadoCheckBox.BackColor = System.Drawing.Color.Transparent
        Me.EnlazadoCheckBox.Controls.Add(Me.Label3)
        Me.EnlazadoCheckBox.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EnlazadoCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CENTROCOSTOBindingSource, "ENLAZADO", True))
        Me.EnlazadoCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EnlazadoCheckBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.EnlazadoCheckBox.Location = New System.Drawing.Point(336, 244)
        Me.EnlazadoCheckBox.Name = "EnlazadoCheckBox"
        '
        '
        '
        Me.EnlazadoCheckBox.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.EnlazadoCheckBox.Size = New System.Drawing.Size(299, 62)
        Me.EnlazadoCheckBox.TabIndex = 4
        Me.EnlazadoCheckBox.TextAlignment = System.Drawing.ContentAlignment.BottomLeft
        Me.EnlazadoCheckBox.TextWrap = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(281, 40)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Marcar si servira para Sumar Stock de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Productos"
        '
        'ConceptoTextBox
        '
        Me.ConceptoTextBox.BackColor = System.Drawing.Color.White
        Me.ConceptoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CENTROCOSTOBindingSource, "CONCEPTO", True))
        Me.ConceptoTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConceptoTextBox.Location = New System.Drawing.Point(336, 143)
        Me.ConceptoTextBox.Multiline = True
        Me.ConceptoTextBox.Name = "ConceptoTextBox"
        '
        '
        '
        Me.ConceptoTextBox.RootElement.StretchVertically = True
        Me.ConceptoTextBox.Size = New System.Drawing.Size(291, 66)
        Me.ConceptoTextBox.TabIndex = 5
        Me.ConceptoTextBox.TabStop = False
        CType(Me.ConceptoTextBox.GetChildAt(0), Telerik.WinControls.UI.RadTextBoxElement).StretchVertically = True
        CType(Me.ConceptoTextBox.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).StretchVertically = True
        CType(Me.ConceptoTextBox.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).BackColor = System.Drawing.Color.White
        CType(Me.ConceptoTextBox.GetChildAt(0).GetChildAt(0), Telerik.WinControls.UI.RadTextBoxItem).Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel2.Location = New System.Drawing.Point(262, 147)
        Me.RadLabel2.Name = "RadLabel2"
        Me.RadLabel2.Size = New System.Drawing.Size(68, 18)
        Me.RadLabel2.TabIndex = 154
        Me.RadLabel2.Text = "Concepto:"
        '
        'PanelFocoRango
        '
        Me.PanelFocoRango.BackColor = System.Drawing.Color.Blue
        Me.PanelFocoRango.Location = New System.Drawing.Point(502, 11)
        Me.PanelFocoRango.Name = "PanelFocoRango"
        Me.PanelFocoRango.Size = New System.Drawing.Size(66, 14)
        Me.PanelFocoRango.TabIndex = 158
        '
        'CodCentroTextBox
        '
        Me.CodCentroTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CENTROCOSTOBindingSource, "CODCENTRO", True))
        Me.CodCentroTextBox.Location = New System.Drawing.Point(498, 268)
        Me.CodCentroTextBox.Name = "CodCentroTextBox"
        Me.CodCentroTextBox.Size = New System.Drawing.Size(41, 20)
        Me.CodCentroTextBox.TabIndex = 157
        '
        'BuscarChoferTextBox
        '
        Me.BuscarChoferTextBox.BackColor = System.Drawing.Color.Tan
        Me.BuscarChoferTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BuscarChoferTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarChoferTextBox.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BuscarChoferTextBox.Location = New System.Drawing.Point(36, 5)
        Me.BuscarChoferTextBox.Name = "BuscarChoferTextBox"
        Me.BuscarChoferTextBox.Size = New System.Drawing.Size(186, 31)
        Me.BuscarChoferTextBox.TabIndex = 6
        '
        'PrioridadCheckBox
        '
        Me.PrioridadCheckBox.BackColor = System.Drawing.Color.DarkGray
        Me.PrioridadCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.CENTROCOSTOBindingSource, "PRIORIDAD", True))
        Me.PrioridadCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrioridadCheckBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.PrioridadCheckBox.Location = New System.Drawing.Point(358, 175)
        Me.PrioridadCheckBox.Name = "PrioridadCheckBox"
        '
        '
        '
        Me.PrioridadCheckBox.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.PrioridadCheckBox.Size = New System.Drawing.Size(69, 18)
        Me.PrioridadCheckBox.TabIndex = 155
        Me.PrioridadCheckBox.Text = "Es Prioridad"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.BuscarChoferTextBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(692, 40)
        Me.Panel1.TabIndex = 0
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.NuevoPictureBox.Location = New System.Drawing.Point(226, 3)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.Location = New System.Drawing.Point(297, 4)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.Location = New System.Drawing.Point(263, 3)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.Location = New System.Drawing.Point(368, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.Location = New System.Drawing.Point(333, 3)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(6, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 397
        Me.PictureBox1.TabStop = False
        '
        'CENTROCOSTOTableAdapter
        '
        Me.CENTROCOSTOTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label1.Location = New System.Drawing.Point(222, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 32)
        Me.Label1.TabIndex = 159
        Me.Label1.Text = "Centro de Costo"
        '
        'CentroDeCosto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(688, 397)
        Me.Controls.Add(Me.CostoFijoCheckBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ConceptoTextBox)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.DesCentroTextBox)
        Me.Controls.Add(Me.EnlazadoCheckBox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CentroCostoGridView)
        Me.Controls.Add(Me.PanelFocoRango)
        Me.Controls.Add(Me.CodCentroTextBox)
        Me.Controls.Add(Me.PrioridadCheckBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CentroDeCosto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Centro de Costo | Cogent SIG"
        CType(Me.CentroCostoGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CENTROCOSTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsCentroDeCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DesCentroTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CostoFijoCheckBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CostoFijoCheckBox.ResumeLayout(False)
        Me.CostoFijoCheckBox.PerformLayout()
        CType(Me.EnlazadoCheckBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EnlazadoCheckBox.ResumeLayout(False)
        Me.EnlazadoCheckBox.PerformLayout()
        CType(Me.ConceptoTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PrioridadCheckBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

    #End Region 'Methods

End Class