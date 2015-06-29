<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReporteFlujoCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteFlujoCaja))
        Me.FiltrarPorFechas = New System.Windows.Forms.Button()
        Me.DsFlujoCaja = New ContaExpress.DsFlujoCaja()
        Me.FlujodeCajaTableAdapter = New ContaExpress.DsFlujoCajaTableAdapters.FlujodeCajaTableAdapter()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtpFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.dtpFechaDesde = New System.Windows.Forms.DateTimePicker()
        CType(Me.DsFlujoCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FiltrarPorFechas
        '
        Me.FiltrarPorFechas.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FiltrarPorFechas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FiltrarPorFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FiltrarPorFechas.Location = New System.Drawing.Point(673, 2)
        Me.FiltrarPorFechas.Name = "FiltrarPorFechas"
        Me.FiltrarPorFechas.Size = New System.Drawing.Size(157, 28)
        Me.FiltrarPorFechas.TabIndex = 5
        Me.FiltrarPorFechas.Text = "Filtrar"
        Me.FiltrarPorFechas.UseVisualStyleBackColor = True
        '
        'DsFlujoCaja
        '
        Me.DsFlujoCaja.DataSetName = "DsFlujoCaja"
        Me.DsFlujoCaja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FlujodeCajaTableAdapter
        '
        Me.FlujodeCajaTableAdapter.ClearBeforeFill = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(-2, 34)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGotoPageButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(895, 625)
        Me.CrystalReportViewer1.TabIndex = 6
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Panel2
        '
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.Tan
        Me.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dtpFechaHasta)
        Me.Panel2.Controls.Add(Me.lblFechaH)
        Me.Panel2.Controls.Add(Me.lblFechaD)
        Me.Panel2.Controls.Add(Me.dtpFechaDesde)
        Me.Panel2.Controls.Add(Me.FiltrarPorFechas)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(892, 35)
        Me.Panel2.TabIndex = 456
        '
        'dtpFechaHasta
        '
        Me.dtpFechaHasta.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaHasta.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue
        Me.dtpFechaHasta.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaHasta.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHasta.Location = New System.Drawing.Point(449, 3)
        Me.dtpFechaHasta.Name = "dtpFechaHasta"
        Me.dtpFechaHasta.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaHasta.TabIndex = 21
        Me.dtpFechaHasta.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'lblFechaH
        '
        Me.lblFechaH.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFechaH.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaH.ForeColor = System.Drawing.Color.Black
        Me.lblFechaH.Location = New System.Drawing.Point(365, 8)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(82, 20)
        Me.lblFechaH.TabIndex = 22
        Me.lblFechaH.Text = "Hasta Fecha"
        '
        'lblFechaD
        '
        Me.lblFechaD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblFechaD.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaD.ForeColor = System.Drawing.Color.Black
        Me.lblFechaD.Location = New System.Drawing.Point(66, 8)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(80, 15)
        Me.lblFechaD.TabIndex = 23
        Me.lblFechaD.Text = "Desde Fecha"
        '
        'dtpFechaDesde
        '
        Me.dtpFechaDesde.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpFechaDesde.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.CalendarTitleBackColor = System.Drawing.Color.RoyalBlue
        Me.dtpFechaDesde.CalendarTitleForeColor = System.Drawing.Color.DarkOrange
        Me.dtpFechaDesde.CalendarTrailingForeColor = System.Drawing.Color.Gray
        Me.dtpFechaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDesde.Location = New System.Drawing.Point(152, 3)
        Me.dtpFechaDesde.Name = "dtpFechaDesde"
        Me.dtpFechaDesde.Size = New System.Drawing.Size(170, 26)
        Me.dtpFechaDesde.TabIndex = 20
        Me.dtpFechaDesde.Value = New Date(2012, 8, 22, 0, 0, 0, 0)
        '
        'ReporteFlujoCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 657)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReporteFlujoCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujo de Caja"
        CType(Me.DsFlujoCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FiltrarPorFechas As System.Windows.Forms.Button
    Friend WithEvents ReporteCaja As CrystalDecisions.Windows.Forms.CrystalReportViewer

    Friend WithEvents DsFlujoCaja As ContaExpress.DsFlujoCaja
    Friend WithEvents FlujodeCajaTableAdapter As ContaExpress.DsFlujoCajaTableAdapters.FlujodeCajaTableAdapter
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents dtpFechaDesde As System.Windows.Forms.DateTimePicker
End Class
