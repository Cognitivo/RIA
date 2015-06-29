<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class ABMUnidadMedida
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend  WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend  WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend  WithEvents DsSettingFO As ContaExpress.DsSettingFO
    Friend  WithEvents grdBuscador As Telerik.WinControls.UI.RadGridView
    Friend WithEvents NOMFANTASIALabel As System.Windows.Forms.Label
    Friend  WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend  WithEvents txtCodMedida As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtDesMedida As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtSimbolo As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents UNIDADMEDIDABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents UNIDADMEDIDATableAdapter As ContaExpress.DsSettingFOTableAdapters.UNIDADMEDIDATableAdapter

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    #End Region 'Fields

    #Region "Methods"

    'Form overrides dispose to clean up the component list.
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim FilterExpression1 As Telerik.WinControls.Data.FilterExpression = New Telerik.WinControls.Data.FilterExpression()
        Dim FilterPredicate1 As Telerik.WinControls.Data.FilterPredicate = New Telerik.WinControls.Data.FilterPredicate()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMUnidadMedida))
        Me.NOMFANTASIALabel = New System.Windows.Forms.Label()
        Me.DESEMPRESALabel = New System.Windows.Forms.Label()
        Me.txtSimbolo = New Telerik.WinControls.UI.RadTextBox()
        Me.UNIDADMEDIDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettingFO = New ContaExpress.DsSettingFO()
        Me.txtDesMedida = New Telerik.WinControls.UI.RadTextBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.grdBuscador = New Telerik.WinControls.UI.RadGridView()
        Me.txtCodMedida = New Telerik.WinControls.UI.RadTextBox()
        Me.UNIDADMEDIDATableAdapter = New ContaExpress.DsSettingFOTableAdapters.UNIDADMEDIDATableAdapter()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.txtSimbolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodMedida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NOMFANTASIALabel
        '
        Me.NOMFANTASIALabel.AutoSize = True
        Me.NOMFANTASIALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.NOMFANTASIALabel.Location = New System.Drawing.Point(61, 60)
        Me.NOMFANTASIALabel.Name = "NOMFANTASIALabel"
        Me.NOMFANTASIALabel.Size = New System.Drawing.Size(56, 15)
        Me.NOMFANTASIALabel.TabIndex = 360
        Me.NOMFANTASIALabel.Text = "Símbolo:"
        '
        'DESEMPRESALabel
        '
        Me.DESEMPRESALabel.AutoSize = True
        Me.DESEMPRESALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DESEMPRESALabel.Location = New System.Drawing.Point(42, 19)
        Me.DESEMPRESALabel.Name = "DESEMPRESALabel"
        Me.DESEMPRESALabel.Size = New System.Drawing.Size(75, 15)
        Me.DESEMPRESALabel.TabIndex = 366
        Me.DESEMPRESALabel.Text = "Descripción:"
        '
        'txtSimbolo
        '
        Me.txtSimbolo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UNIDADMEDIDABindingSource, "SIMBOLO", True))
        Me.txtSimbolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtSimbolo.Location = New System.Drawing.Point(127, 54)
        Me.txtSimbolo.MaxLength = 50
        Me.txtSimbolo.Name = "txtSimbolo"
        Me.txtSimbolo.Size = New System.Drawing.Size(252, 26)
        Me.txtSimbolo.TabIndex = 1
        Me.txtSimbolo.TabStop = False
        Me.txtSimbolo.ThemeName = "Breeze"
        '
        'UNIDADMEDIDABindingSource
        '
        Me.UNIDADMEDIDABindingSource.DataMember = "UNIDADMEDIDA"
        Me.UNIDADMEDIDABindingSource.DataSource = Me.DsSettingFO
        '
        'DsSettingFO
        '
        Me.DsSettingFO.DataSetName = "DsSettingFO"
        Me.DsSettingFO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtDesMedida
        '
        Me.txtDesMedida.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UNIDADMEDIDABindingSource, "DESMEDIDA", True))
        Me.txtDesMedida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDesMedida.Location = New System.Drawing.Point(127, 13)
        Me.txtDesMedida.MaxLength = 50
        Me.txtDesMedida.Name = "txtDesMedida"
        Me.txtDesMedida.Size = New System.Drawing.Size(252, 26)
        Me.txtDesMedida.TabIndex = 0
        Me.txtDesMedida.TabStop = False
        Me.txtDesMedida.ThemeName = "Breeze"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Tan
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.CausesValidation = False
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.txtBuscar.Location = New System.Drawing.Point(35, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(179, 31)
        Me.txtBuscar.TabIndex = 391
        '
        'grdBuscador
        '
        Me.grdBuscador.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBuscador.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdBuscador.EnableAlternatingRowColor = True
        Me.grdBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdBuscador.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdBuscador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdBuscador.Location = New System.Drawing.Point(-1, 38)
        '
        '
        '
        Me.grdBuscador.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdBuscador.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODMEDIDA"
        GridViewDecimalColumn1.FieldName = "CODMEDIDA"
        GridViewDecimalColumn1.HeaderText = "CODMEDIDA"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODMEDIDA"
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
        GridViewTextBoxColumn1.FieldAlias = "NUMMEDIDA"
        GridViewTextBoxColumn1.FieldName = "NUMMEDIDA"
        GridViewTextBoxColumn1.HeaderText = "NUMMEDIDA"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.UniqueName = "NUMMEDIDA"
        GridViewTextBoxColumn2.FieldAlias = "DESMEDIDA"
        GridViewTextBoxColumn2.FieldName = "DESMEDIDA"
        FilterExpression1.FieldName = "DESMEDIDA"
        FilterPredicate1.Function = Telerik.WinControls.UI.GridKnownFunction.Contains
        FilterPredicate1.Values.Add("@FilterEditor1")
        FilterExpression1.Predicates.AddRange(New Telerik.WinControls.Data.FilterPredicate() {FilterPredicate1})
        GridViewTextBoxColumn2.Filter = FilterExpression1
        GridViewTextBoxColumn2.HeaderText = "Unidad de Medida"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.UniqueName = "DESMEDIDA"
        GridViewTextBoxColumn2.Width = 190
        GridViewTextBoxColumn3.FieldAlias = "SIMBOLO"
        GridViewTextBoxColumn3.FieldName = "SIMBOLO"
        GridViewTextBoxColumn3.HeaderText = "SIMBOLO"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.UniqueName = "SIMBOLO"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.grdBuscador.MasterGridViewTemplate.DataSource = Me.UNIDADMEDIDABindingSource
        Me.grdBuscador.MasterGridViewTemplate.EnableFiltering = True
        Me.grdBuscador.MasterGridViewTemplate.EnableGrouping = False
        Me.grdBuscador.MasterGridViewTemplate.ShowFilteringRow = False
        Me.grdBuscador.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.grdBuscador.Name = "grdBuscador"
        Me.grdBuscador.ReadOnly = True
        Me.grdBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdBuscador.ShowGroupPanel = False
        Me.grdBuscador.Size = New System.Drawing.Size(214, 313)
        Me.grdBuscador.TabIndex = 392
        '
        'txtCodMedida
        '
        Me.txtCodMedida.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.UNIDADMEDIDABindingSource, "CODMEDIDA", True))
        Me.txtCodMedida.Location = New System.Drawing.Point(800, 7)
        Me.txtCodMedida.Name = "txtCodMedida"
        Me.txtCodMedida.Size = New System.Drawing.Size(59, 20)
        Me.txtCodMedida.TabIndex = 0
        Me.txtCodMedida.TabStop = False
        '
        'UNIDADMEDIDATableAdapter
        '
        Me.UNIDADMEDIDATableAdapter.ClearBeforeFill = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pbxNuevaFicha)
        Me.Panel1.Controls.Add(Me.pbxModificarFicha)
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Location = New System.Drawing.Point(-2, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(707, 40)
        Me.Panel1.TabIndex = 403
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Tan
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(5, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 398
        Me.PictureBox1.TabStop = False
        '
        'pbxNuevaFicha
        '
        Me.pbxNuevaFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevaFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevaFicha.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevaFicha.InitialImage = Nothing
        Me.pbxNuevaFicha.Location = New System.Drawing.Point(224, 2)
        Me.pbxNuevaFicha.Name = "pbxNuevaFicha"
        Me.pbxNuevaFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxNuevaFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuevaFicha.TabIndex = 3
        Me.pbxNuevaFicha.TabStop = False
        '
        'pbxModificarFicha
        '
        Me.pbxModificarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxModificarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxModificarFicha.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.pbxModificarFicha.InitialImage = Nothing
        Me.pbxModificarFicha.Location = New System.Drawing.Point(294, 2)
        Me.pbxModificarFicha.Name = "pbxModificarFicha"
        Me.pbxModificarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxModificarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxModificarFicha.TabIndex = 5
        Me.pbxModificarFicha.TabStop = False
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(364, 2)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(35, 35)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 7
        Me.pbxCancelar.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.pbxGuardar.InitialImage = Nothing
        Me.pbxGuardar.Location = New System.Drawing.Point(329, 2)
        Me.pbxGuardar.Name = "pbxGuardar"
        Me.pbxGuardar.Size = New System.Drawing.Size(35, 35)
        Me.pbxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGuardar.TabIndex = 6
        Me.pbxGuardar.TabStop = False
        '
        'pbxEliminarFicha
        '
        Me.pbxEliminarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxEliminarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEliminarFicha.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.pbxEliminarFicha.InitialImage = Nothing
        Me.pbxEliminarFicha.Location = New System.Drawing.Point(259, 2)
        Me.pbxEliminarFicha.Name = "pbxEliminarFicha"
        Me.pbxEliminarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxEliminarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEliminarFicha.TabIndex = 4
        Me.pbxEliminarFicha.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtDesMedida)
        Me.Panel2.Controls.Add(Me.txtSimbolo)
        Me.Panel2.Controls.Add(Me.DESEMPRESALabel)
        Me.Panel2.Controls.Add(Me.NOMFANTASIALabel)
        Me.Panel2.Location = New System.Drawing.Point(241, 131)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(424, 100)
        Me.Panel2.TabIndex = 404
        '
        'ABMUnidadMedida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(704, 350)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCodMedida)
        Me.Controls.Add(Me.grdBuscador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(710, 378)
        Me.MinimumSize = New System.Drawing.Size(710, 378)
        Me.Name = "ABMUnidadMedida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de Medidas | Cogent SIG"
        CType(Me.txtSimbolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UNIDADMEDIDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesMedida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodMedida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

    #End Region 'Methods

End Class