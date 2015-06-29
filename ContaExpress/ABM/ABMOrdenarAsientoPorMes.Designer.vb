<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMOrdenarAsientoPorMes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMOrdenarAsientoPorMes))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPeriodosFiscales = New ContaExpress.DsPeriodosFiscales()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOrdenarMes = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelNroCobrador = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PeriodofiscalTableAdapter = New ContaExpress.DsPeriodosFiscalesTableAdapters.periodofiscalTableAdapter()
        Me.DsOrdenarAsientoPeriodo = New ContaExpress.DsOrdenarAsientoPeriodo()
        Me.OrdenarAsientoMesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdenarAsientoMesTableAdapter = New ContaExpress.DsOrdenarAsientoPeriodoTableAdapters.OrdenarAsientoMesTableAdapter()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPeriodosFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsOrdenarAsientoPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenarAsientoMesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmbAño)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbMes)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 144)
        Me.GroupBox1.TabIndex = 414
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo - Mes - Año"
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAño.Location = New System.Drawing.Point(259, 101)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(121, 28)
        Me.cmbAño.TabIndex = 409
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(224, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 17)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Año:"
        '
        'cmbMes
        '
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(89, 101)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 28)
        Me.cmbMes.TabIndex = 407
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label4.Location = New System.Drawing.Point(51, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 406
        Me.Label4.Text = "Mes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(122, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 17)
        Me.Label3.TabIndex = 405
        Me.Label3.Text = "Periodo:"
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.DataSource = Me.PeriodofiscalBindingSource
        Me.cmbPeriodo.DisplayMember = "DESEJERCICIO"
        Me.cmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.Location = New System.Drawing.Point(184, 56)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(121, 28)
        Me.cmbPeriodo.TabIndex = 404
        Me.cmbPeriodo.ValueMember = "CODPERIODOFISCAL"
        '
        'PeriodofiscalBindingSource
        '
        Me.PeriodofiscalBindingSource.DataMember = "periodofiscal"
        Me.PeriodofiscalBindingSource.DataSource = Me.DsPeriodosFiscales
        '
        'DsPeriodosFiscales
        '
        Me.DsPeriodosFiscales.DataSetName = "DsPeriodosFiscales"
        Me.DsPeriodosFiscales.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(2, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(427, 26)
        Me.Label2.TabIndex = 403
        Me.Label2.Text = "Seleccione los siguientes datos que desea ordenar."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOrdenarMes
        '
        Me.btnOrdenarMes.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnOrdenarMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrdenarMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnOrdenarMes.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnOrdenarMes.Location = New System.Drawing.Point(68, 263)
        Me.btnOrdenarMes.Name = "btnOrdenarMes"
        Me.btnOrdenarMes.Size = New System.Drawing.Size(315, 86)
        Me.btnOrdenarMes.TabIndex = 413
        Me.btnOrdenarMes.Text = "Ordenar Mes"
        Me.btnOrdenarMes.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(43, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 37)
        Me.Label1.TabIndex = 412
        Me.Label1.Text = "Proceso que ordena todos los asientos de un mes en especifico continuando con el " & _
    "ultimo numero de asiento del mes anterior." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.LabelNroCobrador)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 41)
        Me.Panel1.TabIndex = 411
        '
        'LabelNroCobrador
        '
        Me.LabelNroCobrador.AutoSize = True
        Me.LabelNroCobrador.Location = New System.Drawing.Point(591, 13)
        Me.LabelNroCobrador.Name = "LabelNroCobrador"
        Me.LabelNroCobrador.Size = New System.Drawing.Size(93, 13)
        Me.LabelNroCobrador.TabIndex = 401
        Me.LabelNroCobrador.Text = "LabelNroCobrador"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox2.Location = New System.Drawing.Point(7, 66)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 406
        Me.PictureBox2.TabStop = False
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'DsOrdenarAsientoPeriodo
        '
        Me.DsOrdenarAsientoPeriodo.DataSetName = "DsOrdenarAsientoPeriodo"
        Me.DsOrdenarAsientoPeriodo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrdenarAsientoMesBindingSource
        '
        Me.OrdenarAsientoMesBindingSource.DataMember = "OrdenarAsientoMes"
        Me.OrdenarAsientoMesBindingSource.DataSource = Me.DsOrdenarAsientoPeriodo
        '
        'OrdenarAsientoMesTableAdapter
        '
        Me.OrdenarAsientoMesTableAdapter.ClearBeforeFill = True
        '
        'ABMOrdenarAsientoPorMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 355)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOrdenarMes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ABMOrdenarAsientoPorMes"
        Me.Text = "Ordenar Asientos por Mes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPeriodosFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsOrdenarAsientoPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenarAsientoMesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOrdenarMes As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelNroCobrador As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents DsPeriodosFiscales As ContaExpress.DsPeriodosFiscales
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DsPeriodosFiscalesTableAdapters.periodofiscalTableAdapter
    Friend WithEvents DsOrdenarAsientoPeriodo As ContaExpress.DsOrdenarAsientoPeriodo
    Friend WithEvents OrdenarAsientoMesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenarAsientoMesTableAdapter As ContaExpress.DsOrdenarAsientoPeriodoTableAdapters.OrdenarAsientoMesTableAdapter
End Class
