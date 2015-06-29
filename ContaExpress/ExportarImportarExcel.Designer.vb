<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportarImportarExcel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportarImportarExcel))
        Me.ExcelToSQLGridView = New System.Windows.Forms.DataGridView
        Me.ProvLinkLabel = New System.Windows.Forms.LinkLabel
        Me.ProdLinkLabel = New System.Windows.Forms.LinkLabel
        Me.ClientesLinkLabel = New System.Windows.Forms.LinkLabel
        Me.GuardarBDButton = New Telerik.WinControls.UI.RadButton
        Me.GuardandoLabel = New System.Windows.Forms.Label
        Me.Button1 = New Telerik.WinControls.UI.RadButton
        Me.CargarGrillaButton = New Telerik.WinControls.UI.RadButton
        Me.BuscarPlantillaButton = New Telerik.WinControls.UI.RadButton
        Me.RadWaitingBar1 = New Telerik.WinControls.UI.RadWaitingBar
        Me.NroRegLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextHoja = New System.Windows.Forms.TextBox
        Me.TextPathExcel = New System.Windows.Forms.TextBox
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme
        Me.VistaTheme1 = New Telerik.WinControls.Themes.VistaTheme
        Me.RadTabStrip1 = New Telerik.WinControls.UI.RadTabStrip
        Me.TabItem1 = New Telerik.WinControls.UI.TabItem
        Me.PlanLinkLabel4 = New System.Windows.Forms.LinkLabel
        Me.TabItem2 = New Telerik.WinControls.UI.TabItem
        CType(Me.ExcelToSQLGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarBDButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CargarGrillaButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BuscarPlantillaButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadWaitingBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadTabStrip1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadTabStrip1.SuspendLayout()
        Me.TabItem1.ContentPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExcelToSQLGridView
        '
        Me.ExcelToSQLGridView.AllowUserToAddRows = False
        Me.ExcelToSQLGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.ExcelToSQLGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExcelToSQLGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ExcelToSQLGridView.ColumnHeadersHeight = 35
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ExcelToSQLGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ExcelToSQLGridView.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.ExcelToSQLGridView.Location = New System.Drawing.Point(12, 76)
        Me.ExcelToSQLGridView.Name = "ExcelToSQLGridView"
        Me.ExcelToSQLGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ExcelToSQLGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ExcelToSQLGridView.RowHeadersVisible = False
        Me.ExcelToSQLGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.ExcelToSQLGridView.Size = New System.Drawing.Size(759, 404)
        Me.ExcelToSQLGridView.TabIndex = 425
        '
        'ProvLinkLabel
        '
        Me.ProvLinkLabel.AutoSize = True
        Me.ProvLinkLabel.Location = New System.Drawing.Point(501, 30)
        Me.ProvLinkLabel.Name = "ProvLinkLabel"
        Me.ProvLinkLabel.Size = New System.Drawing.Size(122, 14)
        Me.ProvLinkLabel.TabIndex = 444
        Me.ProvLinkLabel.TabStop = True
        Me.ProvLinkLabel.Text = "Plantilla de Proveedores"
        '
        'ProdLinkLabel
        '
        Me.ProdLinkLabel.AutoSize = True
        Me.ProdLinkLabel.Location = New System.Drawing.Point(501, 48)
        Me.ProdLinkLabel.Name = "ProdLinkLabel"
        Me.ProdLinkLabel.Size = New System.Drawing.Size(109, 14)
        Me.ProdLinkLabel.TabIndex = 443
        Me.ProdLinkLabel.TabStop = True
        Me.ProdLinkLabel.Text = "Plantilla de Productos"
        '
        'ClientesLinkLabel
        '
        Me.ClientesLinkLabel.AutoSize = True
        Me.ClientesLinkLabel.Location = New System.Drawing.Point(634, 30)
        Me.ClientesLinkLabel.Name = "ClientesLinkLabel"
        Me.ClientesLinkLabel.Size = New System.Drawing.Size(98, 14)
        Me.ClientesLinkLabel.TabIndex = 442
        Me.ClientesLinkLabel.TabStop = True
        Me.ClientesLinkLabel.Text = "Plantilla de Clientes"
        '
        'GuardarBDButton
        '
        Me.GuardarBDButton.ForeColor = System.Drawing.Color.Black
        Me.GuardarBDButton.Location = New System.Drawing.Point(685, 486)
        Me.GuardarBDButton.Name = "GuardarBDButton"
        '
        '
        '
        Me.GuardarBDButton.RootElement.ForeColor = System.Drawing.Color.Black
        Me.GuardarBDButton.Size = New System.Drawing.Size(86, 23)
        Me.GuardarBDButton.TabIndex = 441
        Me.GuardarBDButton.Text = "Guardar"
        '
        'GuardandoLabel
        '
        Me.GuardandoLabel.AutoSize = True
        Me.GuardandoLabel.Location = New System.Drawing.Point(513, 491)
        Me.GuardandoLabel.Name = "GuardandoLabel"
        Me.GuardandoLabel.Size = New System.Drawing.Size(64, 14)
        Me.GuardandoLabel.TabIndex = 440
        Me.GuardandoLabel.Text = "Guardando:"
        Me.GuardandoLabel.Visible = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(149, 486)
        Me.Button1.Name = "Button1"
        '
        '
        '
        Me.Button1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 439
        Me.Button1.Text = "Limpiar Grilla"
        '
        'CargarGrillaButton
        '
        Me.CargarGrillaButton.ForeColor = System.Drawing.Color.Black
        Me.CargarGrillaButton.Location = New System.Drawing.Point(276, 47)
        Me.CargarGrillaButton.Name = "CargarGrillaButton"
        '
        '
        '
        Me.CargarGrillaButton.RootElement.ForeColor = System.Drawing.Color.Black
        Me.CargarGrillaButton.Size = New System.Drawing.Size(86, 23)
        Me.CargarGrillaButton.TabIndex = 438
        Me.CargarGrillaButton.Text = "Cargar Grilla"
        '
        'BuscarPlantillaButton
        '
        Me.BuscarPlantillaButton.ForeColor = System.Drawing.Color.Black
        Me.BuscarPlantillaButton.Location = New System.Drawing.Point(276, 21)
        Me.BuscarPlantillaButton.Name = "BuscarPlantillaButton"
        '
        '
        '
        Me.BuscarPlantillaButton.RootElement.ForeColor = System.Drawing.Color.Black
        Me.BuscarPlantillaButton.Size = New System.Drawing.Size(30, 23)
        Me.BuscarPlantillaButton.TabIndex = 437
        Me.BuscarPlantillaButton.Text = "..."
        '
        'RadWaitingBar1
        '
        Me.RadWaitingBar1.ForeColor = System.Drawing.Color.Black
        Me.RadWaitingBar1.Location = New System.Drawing.Point(582, 486)
        Me.RadWaitingBar1.Name = "RadWaitingBar1"
        '
        '
        '
        Me.RadWaitingBar1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadWaitingBar1.Size = New System.Drawing.Size(97, 23)
        Me.RadWaitingBar1.TabIndex = 436
        Me.RadWaitingBar1.Text = "RadWaitingBar1"
        Me.RadWaitingBar1.ThemeName = "Breeze"
        Me.RadWaitingBar1.Visible = False
        Me.RadWaitingBar1.WaitingSpeed = 10
        '
        'NroRegLabel
        '
        Me.NroRegLabel.AutoSize = True
        Me.NroRegLabel.Location = New System.Drawing.Point(72, 491)
        Me.NroRegLabel.Name = "NroRegLabel"
        Me.NroRegLabel.Size = New System.Drawing.Size(25, 14)
        Me.NroRegLabel.TabIndex = 434
        Me.NroRegLabel.Text = "999"
        Me.NroRegLabel.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 491)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 14)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "Registros:"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 14)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Hoja Plantilla:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Plantilla Excel:"
        '
        'TextHoja
        '
        Me.TextHoja.Location = New System.Drawing.Point(95, 50)
        Me.TextHoja.Name = "TextHoja"
        Me.TextHoja.Size = New System.Drawing.Size(175, 20)
        Me.TextHoja.TabIndex = 429
        Me.TextHoja.Text = "Hoja1"
        '
        'TextPathExcel
        '
        Me.TextPathExcel.Location = New System.Drawing.Point(95, 24)
        Me.TextPathExcel.Name = "TextPathExcel"
        Me.TextPathExcel.ReadOnly = True
        Me.TextPathExcel.Size = New System.Drawing.Size(175, 20)
        Me.TextPathExcel.TabIndex = 427
        '
        'RadTabStrip1
        '
        Me.RadTabStrip1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.RadTabStrip1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.RadTabStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.RadTabStrip1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadTabStrip1.ForeColor = System.Drawing.Color.Black
        Me.RadTabStrip1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.TabItem1, Me.TabItem2})
        Me.RadTabStrip1.Location = New System.Drawing.Point(0, -1)
        Me.RadTabStrip1.Name = "RadTabStrip1"
        '
        '
        '
        Me.RadTabStrip1.RootElement.ForeColor = System.Drawing.Color.Black
        Me.RadTabStrip1.ScrollOffsetStep = 5
        Me.RadTabStrip1.Size = New System.Drawing.Size(787, 563)
        Me.RadTabStrip1.TabIndex = 445
        Me.RadTabStrip1.TabScrollButtonsPosition = Telerik.WinControls.UI.TabScrollButtonsPosition.RightBottom
        Me.RadTabStrip1.Text = "RadTabStrip1"
        Me.RadTabStrip1.ThemeName = "Breeze"
        '
        'TabItem1
        '
        Me.TabItem1.Alignment = System.Drawing.ContentAlignment.BottomLeft
        '
        'TabItem1.ContentPanel
        '
        Me.TabItem1.ContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TabItem1.ContentPanel.CausesValidation = True
        Me.TabItem1.ContentPanel.Controls.Add(Me.PlanLinkLabel4)
        Me.TabItem1.ContentPanel.Controls.Add(Me.Label1)
        Me.TabItem1.ContentPanel.Controls.Add(Me.GuardarBDButton)
        Me.TabItem1.ContentPanel.Controls.Add(Me.ProvLinkLabel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.RadWaitingBar1)
        Me.TabItem1.ContentPanel.Controls.Add(Me.ProdLinkLabel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.NroRegLabel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.BuscarPlantillaButton)
        Me.TabItem1.ContentPanel.Controls.Add(Me.ClientesLinkLabel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.Label3)
        Me.TabItem1.ContentPanel.Controls.Add(Me.ExcelToSQLGridView)
        Me.TabItem1.ContentPanel.Controls.Add(Me.CargarGrillaButton)
        Me.TabItem1.ContentPanel.Controls.Add(Me.Label2)
        Me.TabItem1.ContentPanel.Controls.Add(Me.TextPathExcel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.Button1)
        Me.TabItem1.ContentPanel.Controls.Add(Me.GuardandoLabel)
        Me.TabItem1.ContentPanel.Controls.Add(Me.TextHoja)
        Me.TabItem1.ContentPanel.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabItem1.ContentPanel.ForeColor = System.Drawing.Color.Black
        Me.TabItem1.ContentPanel.Location = New System.Drawing.Point(1, 35)
        Me.TabItem1.ContentPanel.Size = New System.Drawing.Size(785, 527)
        Me.TabItem1.IsSelected = True
        Me.TabItem1.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.StretchHorizontally = False
        Me.TabItem1.Text = "Planilla Electrónoca a BD"
        '
        'PlanLinkLabel4
        '
        Me.PlanLinkLabel4.AutoSize = True
        Me.PlanLinkLabel4.Location = New System.Drawing.Point(634, 46)
        Me.PlanLinkLabel4.Name = "PlanLinkLabel4"
        Me.PlanLinkLabel4.Size = New System.Drawing.Size(140, 14)
        Me.PlanLinkLabel4.TabIndex = 445
        Me.PlanLinkLabel4.TabStop = True
        Me.PlanLinkLabel4.Text = "Plantilla del Plan de Cuentas"
        '
        'TabItem2
        '
        Me.TabItem2.Alignment = System.Drawing.ContentAlignment.BottomLeft
        '
        'TabItem2.ContentPanel
        '
        Me.TabItem2.ContentPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TabItem2.ContentPanel.CausesValidation = True
        Me.TabItem2.ContentPanel.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TabItem2.ContentPanel.ForeColor = System.Drawing.Color.Black
        Me.TabItem2.ContentPanel.Location = New System.Drawing.Point(1, 35)
        Me.TabItem2.ContentPanel.Size = New System.Drawing.Size(785, 527)
        Me.TabItem2.Margin = New System.Windows.Forms.Padding(1, 0, 0, 0)
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.StretchHorizontally = False
        Me.TabItem2.Text = "BD a Planilla Electrónica"
        '
        'ExportarImportarExcel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.RadTabStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExportarImportarExcel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar/Exportar Datos"
        CType(Me.ExcelToSQLGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarBDButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Button1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CargarGrillaButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BuscarPlantillaButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadWaitingBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadTabStrip1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadTabStrip1.ResumeLayout(False)
        Me.TabItem1.ContentPanel.ResumeLayout(False)
        Me.TabItem1.ContentPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ExcelToSQLGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextHoja As System.Windows.Forms.TextBox
    Friend WithEvents TextPathExcel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NroRegLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadWaitingBar1 As Telerik.WinControls.UI.RadWaitingBar
    Friend WithEvents BuscarPlantillaButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents CargarGrillaButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents GuardandoLabel As System.Windows.Forms.Label
    Friend WithEvents Button1 As Telerik.WinControls.UI.RadButton
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents VistaTheme1 As Telerik.WinControls.Themes.VistaTheme
    Friend WithEvents GuardarBDButton As Telerik.WinControls.UI.RadButton
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents ClientesLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ProvLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents ProdLinkLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents RadTabStrip1 As Telerik.WinControls.UI.RadTabStrip
    Friend WithEvents TabItem1 As Telerik.WinControls.UI.TabItem
    Friend WithEvents TabItem2 As Telerik.WinControls.UI.TabItem
    Friend WithEvents PlanLinkLabel4 As System.Windows.Forms.LinkLabel
End Class
