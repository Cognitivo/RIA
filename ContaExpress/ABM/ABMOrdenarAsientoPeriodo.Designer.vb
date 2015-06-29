<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMOrdenarAsientoPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMOrdenarAsientoPeriodo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CmbPeriodo = New System.Windows.Forms.ComboBox()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsPeriodosFiscales = New ContaExpress.DsPeriodosFiscales()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOrdenarPeriodo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelNroCobrador = New System.Windows.Forms.Label()
        Me.DsOrdenarAsientoPeriodo = New ContaExpress.DsOrdenarAsientoPeriodo()
        Me.OrdenarAsientoPeriodoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrdenarAsientoPeriodoTableAdapter = New ContaExpress.DsOrdenarAsientoPeriodoTableAdapters.OrdenarAsientoPeriodoTableAdapter()
        Me.PeriodofiscalTableAdapter = New ContaExpress.DsPeriodosFiscalesTableAdapters.periodofiscalTableAdapter()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsPeriodosFiscales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DsOrdenarAsientoPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrdenarAsientoPeriodoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox1.Location = New System.Drawing.Point(7, 54)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 411
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CmbPeriodo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 93)
        Me.GroupBox1.TabIndex = 410
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Periodo"
        '
        'CmbPeriodo
        '
        Me.CmbPeriodo.DataSource = Me.PeriodofiscalBindingSource
        Me.CmbPeriodo.DisplayMember = "DESEJERCICIO"
        Me.CmbPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbPeriodo.FormattingEnabled = True
        Me.CmbPeriodo.Location = New System.Drawing.Point(155, 56)
        Me.CmbPeriodo.Name = "CmbPeriodo"
        Me.CmbPeriodo.Size = New System.Drawing.Size(121, 28)
        Me.CmbPeriodo.TabIndex = 404
        Me.CmbPeriodo.ValueMember = "CODPERIODOFISCAL"
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
        Me.Label2.Text = "Seleccione el Periodo que desea ordenar."
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOrdenarPeriodo
        '
        Me.btnOrdenarPeriodo.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnOrdenarPeriodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrdenarPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnOrdenarPeriodo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnOrdenarPeriodo.Location = New System.Drawing.Point(68, 222)
        Me.btnOrdenarPeriodo.Name = "btnOrdenarPeriodo"
        Me.btnOrdenarPeriodo.Size = New System.Drawing.Size(315, 86)
        Me.btnOrdenarPeriodo.TabIndex = 409
        Me.btnOrdenarPeriodo.Text = "Ordenar Periodo"
        Me.btnOrdenarPeriodo.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(43, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(402, 67)
        Me.Label1.TabIndex = 408
        Me.Label1.Text = "Proceso que ordena todos los asientos de un periodo en especifico empezando desde" & _
    " el asiento numero 1 (uno). Se recomienda correrlo al menos una vez antes de ord" & _
    "enar los asientos por meses." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.LabelNroCobrador)
        Me.Panel1.Location = New System.Drawing.Point(-1, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 41)
        Me.Panel1.TabIndex = 407
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
        'DsOrdenarAsientoPeriodo
        '
        Me.DsOrdenarAsientoPeriodo.DataSetName = "DsOrdenarAsientoPeriodo"
        Me.DsOrdenarAsientoPeriodo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OrdenarAsientoPeriodoBindingSource
        '
        Me.OrdenarAsientoPeriodoBindingSource.DataMember = "OrdenarAsientoPeriodo"
        Me.OrdenarAsientoPeriodoBindingSource.DataSource = Me.DsOrdenarAsientoPeriodo
        '
        'OrdenarAsientoPeriodoTableAdapter
        '
        Me.OrdenarAsientoPeriodoTableAdapter.ClearBeforeFill = True
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'ABMOrdenarAsientoPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 315)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnOrdenarPeriodo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ABMOrdenarAsientoPeriodo"
        Me.Text = "Ordenar Asientos por Periodo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsPeriodosFiscales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DsOrdenarAsientoPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrdenarAsientoPeriodoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmbPeriodo As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOrdenarPeriodo As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelNroCobrador As System.Windows.Forms.Label
    Friend WithEvents DsOrdenarAsientoPeriodo As ContaExpress.DsOrdenarAsientoPeriodo
    Friend WithEvents OrdenarAsientoPeriodoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OrdenarAsientoPeriodoTableAdapter As ContaExpress.DsOrdenarAsientoPeriodoTableAdapters.OrdenarAsientoPeriodoTableAdapter
    Friend WithEvents DsPeriodosFiscales As ContaExpress.DsPeriodosFiscales
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DsPeriodosFiscalesTableAdapters.periodofiscalTableAdapter
End Class
