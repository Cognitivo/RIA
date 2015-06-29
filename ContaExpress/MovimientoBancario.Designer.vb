<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MovimientoBancario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientoBancario))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gbxTotales = New System.Windows.Forms.GroupBox()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSalidaTotal = New System.Windows.Forms.TextBox()
        Me.txtEntradaTotal = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboMonedaFiltro = New System.Windows.Forms.ComboBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsMovBancario = New ContaExpress.DsMovBancario()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.gbxrangofechas = New System.Windows.Forms.GroupBox()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbobanco = New System.Windows.Forms.ComboBox()
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.gbxAgregar = New System.Windows.Forms.GroupBox()
        Me.txtCotizacion = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cbxMoneda = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtImporte = New System.Windows.Forms.TextBox()
        Me.cboTipoMovi = New System.Windows.Forms.ComboBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.TIPOFORMACOBROBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboCaja = New System.Windows.Forms.ComboBox()
        Me.dtpFechaMov = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.dgvMovimiento = New System.Windows.Forms.DataGridView()
        Me.MOVBANCARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CAJATableAdapter = New ContaExpress.DsMovBancarioTableAdapters.CAJATableAdapter()
        Me.TIPOFORMACOBROTableAdapter = New ContaExpress.DsMovBancarioTableAdapters.TIPOFORMACOBROTableAdapter()
        Me.MOVBANCARIOTableAdapter = New ContaExpress.DsMovBancarioTableAdapters.MOVBANCARIOTableAdapter()
        Me.MONEDATableAdapter = New ContaExpress.DsMovBancarioTableAdapters.MONEDATableAdapter()
        Me.FechamtoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EntradaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalidaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.gbxTotales.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsMovBancario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxrangofechas.SuspendLayout()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxAgregar.SuspendLayout()
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MOVBANCARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 34)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxTotales)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.gbxAgregar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvMovimiento)
        Me.SplitContainer1.Size = New System.Drawing.Size(1085, 587)
        Me.SplitContainer1.SplitterDistance = 548
        Me.SplitContainer1.TabIndex = 0
        '
        'gbxTotales
        '
        Me.gbxTotales.Controls.Add(Me.txtDiferencia)
        Me.gbxTotales.Controls.Add(Me.Label7)
        Me.gbxTotales.Controls.Add(Me.txtSalidaTotal)
        Me.gbxTotales.Controls.Add(Me.txtEntradaTotal)
        Me.gbxTotales.Controls.Add(Me.Label6)
        Me.gbxTotales.Controls.Add(Me.Label5)
        Me.gbxTotales.Location = New System.Drawing.Point(3, 480)
        Me.gbxTotales.Name = "gbxTotales"
        Me.gbxTotales.Size = New System.Drawing.Size(539, 99)
        Me.gbxTotales.TabIndex = 30
        Me.gbxTotales.TabStop = False
        Me.gbxTotales.Text = "Totales"
        '
        'txtDiferencia
        '
        Me.txtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferencia.Enabled = False
        Me.txtDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtDiferencia.Location = New System.Drawing.Point(351, 56)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.Size = New System.Drawing.Size(181, 29)
        Me.txtDiferencia.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(351, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 24)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Diferencia:"
        '
        'txtSalidaTotal
        '
        Me.txtSalidaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalidaTotal.Enabled = False
        Me.txtSalidaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtSalidaTotal.Location = New System.Drawing.Point(136, 56)
        Me.txtSalidaTotal.Name = "txtSalidaTotal"
        Me.txtSalidaTotal.Size = New System.Drawing.Size(205, 29)
        Me.txtSalidaTotal.TabIndex = 31
        '
        'txtEntradaTotal
        '
        Me.txtEntradaTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEntradaTotal.Enabled = False
        Me.txtEntradaTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtEntradaTotal.Location = New System.Drawing.Point(136, 15)
        Me.txtEntradaTotal.Name = "txtEntradaTotal"
        Me.txtEntradaTotal.Size = New System.Drawing.Size(205, 29)
        Me.txtEntradaTotal.TabIndex = 30
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 24)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Salida Total:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(7, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 24)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Entrada Total:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.cboMonedaFiltro)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.gbxrangofechas)
        Me.GroupBox1.Controls.Add(Me.btnFiltrar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbobanco)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(539, 197)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtros"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 100)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 24)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Moneda:"
        '
        'cboMonedaFiltro
        '
        Me.cboMonedaFiltro.DataSource = Me.MONEDABindingSource
        Me.cboMonedaFiltro.DisplayMember = "DESMONEDA"
        Me.cboMonedaFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMonedaFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMonedaFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaFiltro.FormattingEnabled = True
        Me.cboMonedaFiltro.Location = New System.Drawing.Point(94, 96)
        Me.cboMonedaFiltro.Name = "cboMonedaFiltro"
        Me.cboMonedaFiltro.Size = New System.Drawing.Size(127, 32)
        Me.cboMonedaFiltro.TabIndex = 27
        Me.cboMonedaFiltro.ValueMember = "CODMONEDA"
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsMovBancario
        '
        'DsMovBancario
        '
        Me.DsMovBancario.DataSetName = "DsMovBancario"
        Me.DsMovBancario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label13.Location = New System.Drawing.Point(330, 134)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(140, 13)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "F12 para ver todas las cajas"
        '
        'gbxrangofechas
        '
        Me.gbxrangofechas.Controls.Add(Me.dtpHasta)
        Me.gbxrangofechas.Controls.Add(Me.dtpDesde)
        Me.gbxrangofechas.Controls.Add(Me.Label3)
        Me.gbxrangofechas.Controls.Add(Me.Label2)
        Me.gbxrangofechas.Location = New System.Drawing.Point(13, 26)
        Me.gbxrangofechas.Name = "gbxrangofechas"
        Me.gbxrangofechas.Size = New System.Drawing.Size(513, 61)
        Me.gbxrangofechas.TabIndex = 18
        Me.gbxrangofechas.TabStop = False
        Me.gbxrangofechas.Text = "Rango de Fechas"
        '
        'dtpHasta
        '
        Me.dtpHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(338, 16)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(133, 29)
        Me.dtpHasta.TabIndex = 1
        '
        'dtpDesde
        '
        Me.dtpDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(101, 16)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(133, 29)
        Me.dtpDesde.TabIndex = 0
        Me.dtpDesde.Value = New Date(2014, 1, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(258, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 24)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Hasta:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 24)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Desde:"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFiltrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFiltrar.Location = New System.Drawing.Point(66, 152)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(398, 38)
        Me.btnFiltrar.TabIndex = 1
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(230, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 24)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Cajas:"
        '
        'cbobanco
        '
        Me.cbobanco.DataSource = Me.CAJABindingSource
        Me.cbobanco.DisplayMember = "NUMEROCAJA"
        Me.cbobanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbobanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbobanco.FormattingEnabled = True
        Me.cbobanco.Location = New System.Drawing.Point(291, 96)
        Me.cbobanco.Name = "cbobanco"
        Me.cbobanco.Size = New System.Drawing.Size(240, 32)
        Me.cbobanco.TabIndex = 0
        Me.cbobanco.ValueMember = "NUMCAJA"
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsMovBancario
        '
        'gbxAgregar
        '
        Me.gbxAgregar.Controls.Add(Me.txtCotizacion)
        Me.gbxAgregar.Controls.Add(Me.Label14)
        Me.gbxAgregar.Controls.Add(Me.cbxMoneda)
        Me.gbxAgregar.Controls.Add(Me.Label15)
        Me.gbxAgregar.Controls.Add(Me.Label9)
        Me.gbxAgregar.Controls.Add(Me.txtConcepto)
        Me.gbxAgregar.Controls.Add(Me.txtImporte)
        Me.gbxAgregar.Controls.Add(Me.cboTipoMovi)
        Me.gbxAgregar.Controls.Add(Me.cboTipo)
        Me.gbxAgregar.Controls.Add(Me.cboCaja)
        Me.gbxAgregar.Controls.Add(Me.dtpFechaMov)
        Me.gbxAgregar.Controls.Add(Me.Label12)
        Me.gbxAgregar.Controls.Add(Me.Label11)
        Me.gbxAgregar.Controls.Add(Me.Label10)
        Me.gbxAgregar.Controls.Add(Me.Label8)
        Me.gbxAgregar.Controls.Add(Me.Label4)
        Me.gbxAgregar.Controls.Add(Me.btnAgregar)
        Me.gbxAgregar.Location = New System.Drawing.Point(4, 208)
        Me.gbxAgregar.Name = "gbxAgregar"
        Me.gbxAgregar.Size = New System.Drawing.Size(539, 268)
        Me.gbxAgregar.TabIndex = 28
        Me.gbxAgregar.TabStop = False
        Me.gbxAgregar.Text = "Agregar"
        '
        'txtCotizacion
        '
        Me.txtCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtCotizacion.Location = New System.Drawing.Point(384, 86)
        Me.txtCotizacion.Name = "txtCotizacion"
        Me.txtCotizacion.Size = New System.Drawing.Size(143, 24)
        Me.txtCotizacion.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label14.Location = New System.Drawing.Point(63, 90)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Moneda:"
        '
        'cbxMoneda
        '
        Me.cbxMoneda.DataSource = Me.MONEDABindingSource
        Me.cbxMoneda.DisplayMember = "DESMONEDA"
        Me.cbxMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cbxMoneda.FormattingEnabled = True
        Me.cbxMoneda.Location = New System.Drawing.Point(129, 85)
        Me.cbxMoneda.Name = "cbxMoneda"
        Me.cbxMoneda.Size = New System.Drawing.Size(143, 26)
        Me.cbxMoneda.TabIndex = 2
        Me.cbxMoneda.ValueMember = "CODMONEDA"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label15.Location = New System.Drawing.Point(306, 90)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 16)
        Me.Label15.TabIndex = 39
        Me.Label15.Text = "Cotizacion:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(85, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Tipo:"
        '
        'txtConcepto
        '
        Me.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtConcepto.Location = New System.Drawing.Point(129, 154)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(398, 24)
        Me.txtConcepto.TabIndex = 6
        '
        'txtImporte
        '
        Me.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.txtImporte.Location = New System.Drawing.Point(129, 52)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.Size = New System.Drawing.Size(398, 24)
        Me.txtImporte.TabIndex = 1
        '
        'cboTipoMovi
        '
        Me.cboTipoMovi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipoMovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboTipoMovi.FormattingEnabled = True
        Me.cboTipoMovi.Items.AddRange(New Object() {"Entrada", "Salida"})
        Me.cboTipoMovi.Location = New System.Drawing.Point(384, 119)
        Me.cboTipoMovi.Name = "cboTipoMovi"
        Me.cboTipoMovi.Size = New System.Drawing.Size(143, 26)
        Me.cboTipoMovi.TabIndex = 5
        '
        'cboTipo
        '
        Me.cboTipo.DataSource = Me.TIPOFORMACOBROBindingSource
        Me.cboTipo.DisplayMember = "DESFORCOBRO"
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(129, 119)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(143, 26)
        Me.cboTipo.TabIndex = 4
        Me.cboTipo.ValueMember = "CODFORCOBRO"
        '
        'TIPOFORMACOBROBindingSource
        '
        Me.TIPOFORMACOBROBindingSource.DataMember = "TIPOFORMACOBRO"
        Me.TIPOFORMACOBROBindingSource.DataSource = Me.DsMovBancario
        '
        'cboCaja
        '
        Me.cboCaja.DataSource = Me.CAJABindingSource
        Me.cboCaja.DisplayMember = "NUMEROCAJA"
        Me.cboCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.cboCaja.FormattingEnabled = True
        Me.cboCaja.Location = New System.Drawing.Point(129, 17)
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.Size = New System.Drawing.Size(398, 26)
        Me.cboCaja.TabIndex = 0
        Me.cboCaja.ValueMember = "numcaja"
        '
        'dtpFechaMov
        '
        Me.dtpFechaMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.dtpFechaMov.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaMov.Location = New System.Drawing.Point(129, 187)
        Me.dtpFechaMov.Name = "dtpFechaMov"
        Me.dtpFechaMov.Size = New System.Drawing.Size(398, 24)
        Me.dtpFechaMov.TabIndex = 7
        Me.dtpFechaMov.Value = New Date(2014, 1, 1, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label12.Location = New System.Drawing.Point(55, 158)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(69, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Concepto:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label11.Location = New System.Drawing.Point(278, 124)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Entrada/Salida:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(3, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(121, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Fecha Movimiento:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(76, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Monto:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(22, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Cuenta / Banco:"
        '
        'btnAgregar
        '
        Me.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Location = New System.Drawing.Point(66, 227)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(398, 35)
        Me.btnAgregar.TabIndex = 8
        Me.btnAgregar.Text = "Agregar Movimiento"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'dgvMovimiento
        '
        Me.dgvMovimiento.AllowUserToAddRows = False
        Me.dgvMovimiento.AllowUserToDeleteRows = False
        Me.dgvMovimiento.AllowUserToResizeColumns = False
        Me.dgvMovimiento.AllowUserToResizeRows = False
        Me.dgvMovimiento.AutoGenerateColumns = False
        Me.dgvMovimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMovimiento.ColumnHeadersHeight = 34
        Me.dgvMovimiento.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FechamtoDataGridViewTextBoxColumn, Me.concepto, Me.EntradaDataGridViewTextBoxColumn, Me.SalidaDataGridViewTextBoxColumn})
        Me.dgvMovimiento.DataSource = Me.MOVBANCARIOBindingSource
        Me.dgvMovimiento.Location = New System.Drawing.Point(0, 0)
        Me.dgvMovimiento.Name = "dgvMovimiento"
        Me.dgvMovimiento.ReadOnly = True
        Me.dgvMovimiento.RowHeadersVisible = False
        Me.dgvMovimiento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMovimiento.Size = New System.Drawing.Size(533, 587)
        Me.dgvMovimiento.TabIndex = 0
        '
        'MOVBANCARIOBindingSource
        '
        Me.MOVBANCARIOBindingSource.DataMember = "MOVBANCARIO"
        Me.MOVBANCARIOBindingSource.DataSource = Me.DsMovBancario
        '
        'Panel2
        '
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.Tan
        Me.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1085, 35)
        Me.Panel2.TabIndex = 455
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'TIPOFORMACOBROTableAdapter
        '
        Me.TIPOFORMACOBROTableAdapter.ClearBeforeFill = True
        '
        'MOVBANCARIOTableAdapter
        '
        Me.MOVBANCARIOTableAdapter.ClearBeforeFill = True
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'FechamtoDataGridViewTextBoxColumn
        '
        Me.FechamtoDataGridViewTextBoxColumn.DataPropertyName = "fecha_mto"
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.FechamtoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.FechamtoDataGridViewTextBoxColumn.FillWeight = 80.0!
        Me.FechamtoDataGridViewTextBoxColumn.HeaderText = "Fecha"
        Me.FechamtoDataGridViewTextBoxColumn.Name = "FechamtoDataGridViewTextBoxColumn"
        Me.FechamtoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'concepto
        '
        Me.concepto.DataPropertyName = "concepto"
        Me.concepto.FillWeight = 150.0!
        Me.concepto.HeaderText = "Concepto"
        Me.concepto.Name = "concepto"
        Me.concepto.ReadOnly = True
        '
        'EntradaDataGridViewTextBoxColumn
        '
        Me.EntradaDataGridViewTextBoxColumn.DataPropertyName = "Entrada"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = "0"
        Me.EntradaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.EntradaDataGridViewTextBoxColumn.HeaderText = "Entrada"
        Me.EntradaDataGridViewTextBoxColumn.Name = "EntradaDataGridViewTextBoxColumn"
        Me.EntradaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'SalidaDataGridViewTextBoxColumn
        '
        Me.SalidaDataGridViewTextBoxColumn.DataPropertyName = "Salida"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = "0"
        Me.SalidaDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.SalidaDataGridViewTextBoxColumn.HeaderText = "Salida"
        Me.SalidaDataGridViewTextBoxColumn.Name = "SalidaDataGridViewTextBoxColumn"
        Me.SalidaDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MovimientoBancario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1085, 622)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MovimientoBancario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Movimiento Bancario"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.gbxTotales.ResumeLayout(False)
        Me.gbxTotales.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsMovBancario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxrangofechas.ResumeLayout(False)
        Me.gbxrangofechas.PerformLayout()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxAgregar.ResumeLayout(False)
        Me.gbxAgregar.PerformLayout()
        CType(Me.TIPOFORMACOBROBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MOVBANCARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvMovimiento As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gbxrangofechas As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbobanco As System.Windows.Forms.ComboBox
    Friend WithEvents gbxAgregar As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents txtImporte As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoMovi As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCaja As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaMov As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents DsMovBancario As ContaExpress.DsMovBancario
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CAJATableAdapter As ContaExpress.DsMovBancarioTableAdapters.CAJATableAdapter
    Friend WithEvents TIPOFORMACOBROBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOFORMACOBROTableAdapter As ContaExpress.DsMovBancarioTableAdapters.TIPOFORMACOBROTableAdapter
    Friend WithEvents MOVBANCARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MOVBANCARIOTableAdapter As ContaExpress.DsMovBancarioTableAdapters.MOVBANCARIOTableAdapter
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCotizacion As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cbxMoneda As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.DsMovBancarioTableAdapters.MONEDATableAdapter
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboMonedaFiltro As System.Windows.Forms.ComboBox
    Friend WithEvents gbxTotales As System.Windows.Forms.GroupBox
    Friend WithEvents txtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSalidaTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtEntradaTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FechamtoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EntradaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalidaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
