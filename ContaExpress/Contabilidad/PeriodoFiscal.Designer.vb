<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PeriodoFiscal
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PeriodoFiscal))
        Me.FechaInicio = New Fecha.Fecha()
        Me.lblFecInicio = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.FechaFin = New Fecha.Fecha()
        Me.GridViewPeriodos = New System.Windows.Forms.DataGridView()
        Me.ESTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxtDescripcion = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel2 = New Telerik.WinControls.UI.RadLabel()
        Me.Txtcodperiodofiscal = New Telerik.WinControls.UI.RadTextBox()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.BtnAgregar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.RadGroupBox4 = New Telerik.WinControls.UI.RadGroupBox()
        Me.RadLabel4 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel3 = New Telerik.WinControls.UI.RadLabel()
        Me.RadLabel26 = New Telerik.WinControls.UI.RadLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvPresupuestoFiscal = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CODPERIODOFISCAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPeriodoFiscal = New ContaExpress.DsPeriodoFiscal()
        Me.PeriodofiscalTableAdapter = New ContaExpress.DsPeriodoFiscalTableAdapters.periodofiscalTableAdapter()
        CType(Me.lblFecInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Txtcodperiodofiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox4.SuspendLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPresupuestoFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPeriodoFiscal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FechaInicio
        '
        Me.FechaInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FechaInicio.FechaDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.FechaInicio.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FechaInicio.Location = New System.Drawing.Point(314, 117)
        Me.FechaInicio.MaxLength = 10
        Me.FechaInicio.Name = "FechaInicio"
        Me.FechaInicio.Size = New System.Drawing.Size(96, 26)
        Me.FechaInicio.TabIndex = 83
        Me.FechaInicio.Text = "01/01/1900"
        '
        'lblFecInicio
        '
        Me.lblFecInicio.BackColor = System.Drawing.Color.Transparent
        Me.lblFecInicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblFecInicio.ForeColor = System.Drawing.Color.Black
        Me.lblFecInicio.Location = New System.Drawing.Point(269, 121)
        Me.lblFecInicio.Name = "lblFecInicio"
        '
        '
        '
        Me.lblFecInicio.RootElement.ForeColor = System.Drawing.Color.Black
        Me.lblFecInicio.Size = New System.Drawing.Size(43, 19)
        Me.lblFecInicio.TabIndex = 85
        Me.lblFecInicio.Text = "Inicio:"
        '
        'RadLabel1
        '
        Me.RadLabel1.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.RadLabel1.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Location = New System.Drawing.Point(433, 121)
        Me.RadLabel1.Name = "RadLabel1"
        '
        '
        '
        Me.RadLabel1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel1.Size = New System.Drawing.Size(30, 19)
        Me.RadLabel1.TabIndex = 88
        Me.RadLabel1.Text = "Fin:"
        '
        'FechaFin
        '
        Me.FechaFin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FechaFin.FechaDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.FechaFin.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.FechaFin.Location = New System.Drawing.Point(469, 117)
        Me.FechaFin.MaxLength = 10
        Me.FechaFin.Name = "FechaFin"
        Me.FechaFin.Size = New System.Drawing.Size(94, 26)
        Me.FechaFin.TabIndex = 86
        Me.FechaFin.Text = "01/01/1900"
        '
        'GridViewPeriodos
        '
        Me.GridViewPeriodos.AllowUserToAddRows = False
        Me.GridViewPeriodos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        Me.GridViewPeriodos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.GridViewPeriodos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridViewPeriodos.AutoGenerateColumns = False
        Me.GridViewPeriodos.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewPeriodos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.GridViewPeriodos.ColumnHeadersHeight = 35
        Me.GridViewPeriodos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODPERIODOFISCAL, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.ESTADO})
        Me.GridViewPeriodos.DataSource = Me.PeriodofiscalBindingSource
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GridViewPeriodos.DefaultCellStyle = DataGridViewCellStyle5
        Me.GridViewPeriodos.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.GridViewPeriodos.Location = New System.Drawing.Point(3, 83)
        Me.GridViewPeriodos.Name = "GridViewPeriodos"
        Me.GridViewPeriodos.ReadOnly = True
        Me.GridViewPeriodos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridViewPeriodos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GridViewPeriodos.RowHeadersVisible = False
        Me.GridViewPeriodos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridViewPeriodos.Size = New System.Drawing.Size(226, 520)
        Me.GridViewPeriodos.TabIndex = 424
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "Estado"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Width = 70
        '
        'TxtDescripcion
        '
        Me.TxtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TxtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Location = New System.Drawing.Point(314, 83)
        Me.TxtDescripcion.Name = "TxtDescripcion"
        '
        '
        '
        Me.TxtDescripcion.RootElement.ForeColor = System.Drawing.Color.Black
        Me.TxtDescripcion.Size = New System.Drawing.Size(421, 26)
        Me.TxtDescripcion.TabIndex = 28
        Me.TxtDescripcion.TabStop = False
        Me.TxtDescripcion.ThemeName = "Breeze"
        CType(Me.TxtDescripcion.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'RadLabel2
        '
        Me.RadLabel2.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.RadLabel2.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Location = New System.Drawing.Point(249, 87)
        Me.RadLabel2.Name = "RadLabel2"
        '
        '
        '
        Me.RadLabel2.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadLabel2.Size = New System.Drawing.Size(63, 19)
        Me.RadLabel2.TabIndex = 425
        Me.RadLabel2.Text = "Ejercicio:"
        '
        'Txtcodperiodofiscal
        '
        Me.Txtcodperiodofiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcodperiodofiscal.ForeColor = System.Drawing.Color.Black
        Me.Txtcodperiodofiscal.Location = New System.Drawing.Point(314, 55)
        Me.Txtcodperiodofiscal.Name = "Txtcodperiodofiscal"
        '
        '
        '
        Me.Txtcodperiodofiscal.RootElement.ForeColor = System.Drawing.Color.Black
        Me.Txtcodperiodofiscal.Size = New System.Drawing.Size(26, 22)
        Me.Txtcodperiodofiscal.TabIndex = 29
        Me.Txtcodperiodofiscal.TabStop = False
        Me.Txtcodperiodofiscal.ThemeName = "Breeze"
        CType(Me.Txtcodperiodofiscal.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'TxtBuscar
        '
        Me.TxtBuscar.BackColor = System.Drawing.Color.Tan
        Me.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.TxtBuscar.Location = New System.Drawing.Point(41, 47)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(189, 30)
        Me.TxtBuscar.TabIndex = 454
        Me.TxtBuscar.Text = "Buscar..."
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Tan
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Location = New System.Drawing.Point(6, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox2.TabIndex = 455
        Me.PictureBox2.TabStop = False
        '
        'BtnAgregar
        '
        Me.BtnAgregar.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAgregar.Location = New System.Drawing.Point(579, 116)
        Me.BtnAgregar.Name = "BtnAgregar"
        Me.BtnAgregar.Size = New System.Drawing.Size(74, 28)
        Me.BtnAgregar.TabIndex = 457
        Me.BtnAgregar.Text = "Agregar"
        Me.BtnAgregar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.Gainsboro
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnEliminar.Location = New System.Drawing.Point(661, 116)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(74, 28)
        Me.BtnEliminar.TabIndex = 457
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'RadGroupBox4
        '
        Me.RadGroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadGroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox4.Controls.Add(Me.RadLabel4)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel3)
        Me.RadGroupBox4.Controls.Add(Me.RadLabel26)
        Me.RadGroupBox4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox4.FooterImageIndex = -1
        Me.RadGroupBox4.FooterImageKey = ""
        Me.RadGroupBox4.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox4.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox4.HeaderImageIndex = -1
        Me.RadGroupBox4.HeaderImageKey = ""
        Me.RadGroupBox4.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox4.HeaderText = "Leyenda"
        Me.RadGroupBox4.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox4.Location = New System.Drawing.Point(235, 554)
        Me.RadGroupBox4.Name = "RadGroupBox4"
        Me.RadGroupBox4.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox4.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox4.Size = New System.Drawing.Size(498, 49)
        Me.RadGroupBox4.TabIndex = 458
        Me.RadGroupBox4.Text = "Leyenda"
        Me.RadGroupBox4.ThemeName = "Breeze"
        CType(Me.RadGroupBox4.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox4.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        '
        'RadLabel4
        '
        Me.RadLabel4.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel4.Location = New System.Drawing.Point(10, 22)
        Me.RadLabel4.Name = "RadLabel4"
        Me.RadLabel4.Size = New System.Drawing.Size(84, 16)
        Me.RadLabel4.TabIndex = 362
        Me.RadLabel4.Text = "Estado Periodo"
        Me.RadLabel4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLabel3
        '
        Me.RadLabel3.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel3.Location = New System.Drawing.Point(304, 21)
        Me.RadLabel3.Name = "RadLabel3"
        Me.RadLabel3.Size = New System.Drawing.Size(176, 18)
        Me.RadLabel3.TabIndex = 362
        Me.RadLabel3.Text = "0 = Periodo Fiscal Cerrado"
        Me.RadLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadLabel26
        '
        Me.RadLabel26.BackColor = System.Drawing.Color.Transparent
        Me.RadLabel26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadLabel26.Location = New System.Drawing.Point(121, 21)
        Me.RadLabel26.Name = "RadLabel26"
        Me.RadLabel26.Size = New System.Drawing.Size(172, 18)
        Me.RadLabel26.TabIndex = 362
        Me.RadLabel26.Text = "1 = Periodo Fiscal Abierto"
        Me.RadLabel26.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Location = New System.Drawing.Point(-6, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 41)
        Me.Panel1.TabIndex = 459
        '
        'dgvPresupuestoFiscal
        '
        Me.dgvPresupuestoFiscal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPresupuestoFiscal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPresupuestoFiscal.Location = New System.Drawing.Point(269, 169)
        Me.dgvPresupuestoFiscal.Name = "dgvPresupuestoFiscal"
        Me.dgvPresupuestoFiscal.Size = New System.Drawing.Size(466, 331)
        Me.dgvPresupuestoFiscal.TabIndex = 460
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(659, 506)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(74, 28)
        Me.Button1.TabIndex = 461
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CODPERIODOFISCAL
        '
        Me.CODPERIODOFISCAL.DataPropertyName = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.HeaderText = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.Name = "CODPERIODOFISCAL"
        Me.CODPERIODOFISCAL.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FECHAINICIO"
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn2.HeaderText = "Fecha de Inicio"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 110
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FECHAFIN"
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha Fin"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 110
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESEJERCICIO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Ejercicio"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 170
        '
        'PeriodofiscalBindingSource
        '
        Me.PeriodofiscalBindingSource.DataMember = "periodofiscal"
        Me.PeriodofiscalBindingSource.DataSource = Me.DsPeriodoFiscal
        '
        'DsPeriodoFiscal
        '
        Me.DsPeriodoFiscal.DataSetName = "DsPeriodoFiscal"
        Me.DsPeriodoFiscal.EnforceConstraints = False
        Me.DsPeriodoFiscal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'PeriodoFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(745, 608)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvPresupuestoFiscal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RadGroupBox4)
        Me.Controls.Add(Me.BtnEliminar)
        Me.Controls.Add(Me.BtnAgregar)
        Me.Controls.Add(Me.TxtBuscar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.RadLabel2)
        Me.Controls.Add(Me.TxtDescripcion)
        Me.Controls.Add(Me.GridViewPeriodos)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.FechaFin)
        Me.Controls.Add(Me.lblFecInicio)
        Me.Controls.Add(Me.FechaInicio)
        Me.Controls.Add(Me.Txtcodperiodofiscal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "PeriodoFiscal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodo Fiscal  | Cogent SIG"
        CType(Me.lblFecInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Txtcodperiodofiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox4.ResumeLayout(False)
        Me.RadGroupBox4.PerformLayout()
        CType(Me.RadLabel4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPresupuestoFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPeriodoFiscal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FechaInicio As Fecha.Fecha
    Friend WithEvents lblFecInicio As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents FechaFin As Fecha.Fecha
    Friend WithEvents GridViewPeriodos As System.Windows.Forms.DataGridView
    Friend WithEvents TxtDescripcion As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadLabel2 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents CODPERIODOFISCALDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESEJERCICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINICIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAFINDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DsPeriodoFiscal As ContaExpress.DsPeriodoFiscal
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DsPeriodoFiscalTableAdapters.periodofiscalTableAdapter
    Friend WithEvents FECHAINICIO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAFIN1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESEJERCICIO1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Txtcodperiodofiscal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnAgregar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents RadGroupBox4 As Telerik.WinControls.UI.RadGroupBox
    Friend WithEvents RadLabel4 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel3 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents RadLabel26 As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvPresupuestoFiscal As System.Windows.Forms.DataGridView
    Friend WithEvents CODPERIODOFISCAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
