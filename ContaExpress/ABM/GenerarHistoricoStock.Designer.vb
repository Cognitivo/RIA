<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GenerarHistoricoStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GenerarHistoricoStock))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCalcularAjuste = New System.Windows.Forms.Button()
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.HistoricoStockTableAdapter1 = New ContaExpress.DsProduccionTableAdapters.HistoricoStockTableAdapter()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnVerificarFecha = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Location = New System.Drawing.Point(-2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 41)
        Me.Panel1.TabIndex = 355
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(50, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(346, 61)
        Me.Label1.TabIndex = 402
        Me.Label1.Text = "Proceso que se encarga de almacenar el stock Actual de cada Producto, en cada Dep" & _
    "osito cada 30 dias. Ejecutar esta funcion solo el 1ro de cada mes."
        '
        'btnCalcularAjuste
        '
        Me.btnCalcularAjuste.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCalcularAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcularAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnCalcularAjuste.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCalcularAjuste.Location = New System.Drawing.Point(54, 116)
        Me.btnCalcularAjuste.Name = "btnCalcularAjuste"
        Me.btnCalcularAjuste.Size = New System.Drawing.Size(334, 86)
        Me.btnCalcularAjuste.TabIndex = 403
        Me.btnCalcularAjuste.Text = "Generar Histórico Stock"
        Me.btnCalcularAjuste.UseVisualStyleBackColor = False
        '
        'DsProduccion
        '
        Me.DsProduccion.DataSetName = "DsProduccion"
        Me.DsProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox2.Location = New System.Drawing.Point(12, 54)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 405
        Me.PictureBox2.TabStop = False
        '
        'HistoricoStockTableAdapter1
        '
        Me.HistoricoStockTableAdapter1.ClearBeforeFill = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dtpFecha)
        Me.GroupBox1.Controls.Add(Me.btnVerificarFecha)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 222)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(435, 112)
        Me.GroupBox1.TabIndex = 406
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Verificar"
        '
        'btnVerificarFecha
        '
        Me.btnVerificarFecha.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnVerificarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVerificarFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.btnVerificarFecha.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnVerificarFecha.Location = New System.Drawing.Point(247, 65)
        Me.btnVerificarFecha.Name = "btnVerificarFecha"
        Me.btnVerificarFecha.Size = New System.Drawing.Size(101, 31)
        Me.btnVerificarFecha.TabIndex = 406
        Me.btnVerificarFecha.Text = "Verificar"
        Me.btnVerificarFecha.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(2, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(427, 26)
        Me.Label2.TabIndex = 403
        Me.Label2.Text = "Muestra la ultima fecha en la cual se registro el ultimo Historico del Stock"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(70, 65)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(157, 26)
        Me.dtpFecha.TabIndex = 407
        '
        'GenerarHistoricoStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(449, 353)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.btnCalcularAjuste)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "GenerarHistoricoStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Histórico Stock | Cogent SIG"
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCalcularAjuste As System.Windows.Forms.Button
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents HistoricoStockTableAdapter1 As ContaExpress.DsProduccionTableAdapters.HistoricoStockTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnVerificarFecha As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
End Class
