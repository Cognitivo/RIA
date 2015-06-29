<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class ABMMonedas
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend  WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend WithEvents DIRECCIONLabel As System.Windows.Forms.Label
    Friend WithEvents DsFacturacion As ContaExpress.dsFacturacion
    Friend WithEvents grdCotizacion As System.Windows.Forms.DataGridView
    Friend WithEvents MONEDABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MONEDATableAdapter As ContaExpress.dsFacturacionTableAdapters.MONEDATableAdapter
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxEliminarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents pbxModificarFicha As System.Windows.Forms.PictureBox
    Friend WithEvents pbxNuevaFicha As System.Windows.Forms.PictureBox
    Friend WithEvents rbtnAgregarCotizacion As Telerik.WinControls.UI.RadButton
    Friend WithEvents TableAdapterManager As ContaExpress.dsFacturacionTableAdapters.TableAdapterManager
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMoneda As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDesMoneda As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFechaCotizacion As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtImagen As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSimbolo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtVentaCotizacion As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

#End Region 'Fields

#Region "Methods"

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMMonedas))
        Me.DIRECCIONLabel = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtDesMoneda = New Telerik.WinControls.UI.RadTextBox()
        Me.txtCodMoneda = New Telerik.WinControls.UI.RadTextBox()
        Me.MONEDABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFacturacion = New ContaExpress.dsFacturacion()
        Me.txtSimbolo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtVentaCotizacion = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.txtFechaCotizacion = New Telerik.WinControls.UI.RadTextBox()
        Me.rbtnAgregarCotizacion = New Telerik.WinControls.UI.RadButton()
        Me.grdCotizacion = New System.Windows.Forms.DataGridView()
        Me.FECHAMOVIMIENTOCOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODMONEDACOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODUSUARIOCOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESACOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FACTORVENTACOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECGRACOTIZACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COTIZACIONBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.txtImagen = New Telerik.WinControls.UI.RadTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbxNuevaFicha = New System.Windows.Forms.PictureBox()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxModificarFicha = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.pbxEliminarFicha = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtMultiplicador = New System.Windows.Forms.ComboBox()
        Me.lblEjemplo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pbxEnPromocion = New System.Windows.Forms.PictureBox()
        Me.txtCantDecimales = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxDecimales = New System.Windows.Forms.ComboBox()
        Me.cbxUsarDecimales = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DESEMPRESALabel = New System.Windows.Forms.Label()
        Me.grdBuscador = New System.Windows.Forms.DataGridView()
        Me.CODMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESMONEDADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SIMBOLODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRIORIDADDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MONEDATableAdapter = New ContaExpress.dsFacturacionTableAdapters.MONEDATableAdapter()
        Me.TableAdapterManager = New ContaExpress.dsFacturacionTableAdapters.TableAdapterManager()
        Me.COTIZACIONTableAdapter = New ContaExpress.dsFacturacionTableAdapters.COTIZACIONTableAdapter()
        CType(Me.txtDesMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.txtDesMoneda.SuspendLayout()
        CType(Me.txtCodMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSimbolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbtnAgregarCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCotizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COTIZACIONBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbxEnPromocion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DIRECCIONLabel
        '
        Me.DIRECCIONLabel.AutoSize = True
        Me.DIRECCIONLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DIRECCIONLabel.Location = New System.Drawing.Point(358, 20)
        Me.DIRECCIONLabel.Name = "DIRECCIONLabel"
        Me.DIRECCIONLabel.Size = New System.Drawing.Size(47, 17)
        Me.DIRECCIONLabel.TabIndex = 368
        Me.DIRECCIONLabel.Text = "Símb.:"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Tan
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.CausesValidation = False
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.txtBuscar.Location = New System.Drawing.Point(33, 4)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(164, 31)
        Me.txtBuscar.TabIndex = 356
        '
        'txtDesMoneda
        '
        Me.txtDesMoneda.Controls.Add(Me.txtCodMoneda)
        Me.txtDesMoneda.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MONEDABindingSource, "DESMONEDA", True))
        Me.txtDesMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtDesMoneda.Location = New System.Drawing.Point(114, 15)
        Me.txtDesMoneda.MaxLength = 50
        Me.txtDesMoneda.Name = "txtDesMoneda"
        Me.txtDesMoneda.Size = New System.Drawing.Size(241, 27)
        Me.txtDesMoneda.TabIndex = 0
        Me.txtDesMoneda.TabStop = False
        Me.txtDesMoneda.ThemeName = "Breeze"
        '
        'txtCodMoneda
        '
        Me.txtCodMoneda.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MONEDABindingSource, "CODMONEDA", True))
        Me.txtCodMoneda.Location = New System.Drawing.Point(114, -156)
        Me.txtCodMoneda.Name = "txtCodMoneda"
        Me.txtCodMoneda.Size = New System.Drawing.Size(80, 27)
        Me.txtCodMoneda.TabIndex = 2
        Me.txtCodMoneda.TabStop = False
        '
        'MONEDABindingSource
        '
        Me.MONEDABindingSource.DataMember = "MONEDA"
        Me.MONEDABindingSource.DataSource = Me.DsFacturacion
        '
        'DsFacturacion
        '
        Me.DsFacturacion.DataSetName = "dsFacturacion"
        Me.DsFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtSimbolo
        '
        Me.txtSimbolo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MONEDABindingSource, "SIMBOLO", True))
        Me.txtSimbolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtSimbolo.Location = New System.Drawing.Point(408, 15)
        Me.txtSimbolo.MaxLength = 50
        Me.txtSimbolo.Name = "txtSimbolo"
        Me.txtSimbolo.Size = New System.Drawing.Size(75, 27)
        Me.txtSimbolo.TabIndex = 1
        Me.txtSimbolo.TabStop = False
        Me.txtSimbolo.ThemeName = "Breeze"
        '
        'txtVentaCotizacion
        '
        Appearance1.FontData.SizeInPoints = 13.0!
        Appearance1.TextHAlignAsString = "Right"
        Me.txtVentaCotizacion.Appearance = Appearance1
        Me.txtVentaCotizacion.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtVentaCotizacion.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtVentaCotizacion.InputMask = "nnn,nnn,nnn.nn"
        Me.txtVentaCotizacion.Location = New System.Drawing.Point(204, 165)
        Me.txtVentaCotizacion.Name = "txtVentaCotizacion"
        Me.txtVentaCotizacion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtVentaCotizacion.Size = New System.Drawing.Size(175, 27)
        Me.txtVentaCotizacion.TabIndex = 1
        '
        'txtFechaCotizacion
        '
        Me.txtFechaCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCotizacion.Location = New System.Drawing.Point(26, 165)
        Me.txtFechaCotizacion.Name = "txtFechaCotizacion"
        Me.txtFechaCotizacion.ReadOnly = True
        Me.txtFechaCotizacion.Size = New System.Drawing.Size(172, 27)
        Me.txtFechaCotizacion.TabIndex = 0
        Me.txtFechaCotizacion.TabStop = False
        Me.txtFechaCotizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFechaCotizacion.ThemeName = "Breeze"
        '
        'rbtnAgregarCotizacion
        '
        Me.rbtnAgregarCotizacion.BackColor = System.Drawing.Color.Transparent
        Me.rbtnAgregarCotizacion.Location = New System.Drawing.Point(385, 165)
        Me.rbtnAgregarCotizacion.Name = "rbtnAgregarCotizacion"
        Me.rbtnAgregarCotizacion.Size = New System.Drawing.Size(80, 27)
        Me.rbtnAgregarCotizacion.TabIndex = 3
        Me.rbtnAgregarCotizacion.Text = "Guardar"
        Me.rbtnAgregarCotizacion.ThemeName = "ControlDefault"
        '
        'grdCotizacion
        '
        Me.grdCotizacion.AllowUserToAddRows = False
        Me.grdCotizacion.AllowUserToDeleteRows = False
        Me.grdCotizacion.AutoGenerateColumns = False
        Me.grdCotizacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdCotizacion.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCotizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grdCotizacion.ColumnHeadersHeight = 35
        Me.grdCotizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FECHAMOVIMIENTOCOTIZACION, Me.CODMONEDACOTIZACION, Me.CODUSUARIOCOTIZACION, Me.CODEMPRESACOTIZACION, Me.FACTORVENTACOTIZACION, Me.FECGRACOTIZACION})
        Me.grdCotizacion.DataSource = Me.COTIZACIONBindingSource
        Me.grdCotizacion.Location = New System.Drawing.Point(26, 198)
        Me.grdCotizacion.Name = "grdCotizacion"
        Me.grdCotizacion.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdCotizacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grdCotizacion.RowHeadersVisible = False
        Me.grdCotizacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdCotizacion.ShowEditingIcon = False
        Me.grdCotizacion.Size = New System.Drawing.Size(439, 222)
        Me.grdCotizacion.TabIndex = 4
        '
        'FECHAMOVIMIENTOCOTIZACION
        '
        Me.FECHAMOVIMIENTOCOTIZACION.DataPropertyName = "FECHAMOVIMIENTO"
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.FECHAMOVIMIENTOCOTIZACION.DefaultCellStyle = DataGridViewCellStyle2
        Me.FECHAMOVIMIENTOCOTIZACION.HeaderText = "Fecha"
        Me.FECHAMOVIMIENTOCOTIZACION.Name = "FECHAMOVIMIENTOCOTIZACION"
        Me.FECHAMOVIMIENTOCOTIZACION.ReadOnly = True
        Me.FECHAMOVIMIENTOCOTIZACION.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'CODMONEDACOTIZACION
        '
        Me.CODMONEDACOTIZACION.DataPropertyName = "CODMONEDA"
        Me.CODMONEDACOTIZACION.HeaderText = "CODMONEDA"
        Me.CODMONEDACOTIZACION.Name = "CODMONEDACOTIZACION"
        Me.CODMONEDACOTIZACION.ReadOnly = True
        Me.CODMONEDACOTIZACION.Visible = False
        '
        'CODUSUARIOCOTIZACION
        '
        Me.CODUSUARIOCOTIZACION.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIOCOTIZACION.HeaderText = "CODUSUARIO"
        Me.CODUSUARIOCOTIZACION.Name = "CODUSUARIOCOTIZACION"
        Me.CODUSUARIOCOTIZACION.ReadOnly = True
        Me.CODUSUARIOCOTIZACION.Visible = False
        '
        'CODEMPRESACOTIZACION
        '
        Me.CODEMPRESACOTIZACION.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESACOTIZACION.HeaderText = "CODEMPRESA"
        Me.CODEMPRESACOTIZACION.Name = "CODEMPRESACOTIZACION"
        Me.CODEMPRESACOTIZACION.ReadOnly = True
        Me.CODEMPRESACOTIZACION.Visible = False
        '
        'FACTORVENTACOTIZACION
        '
        Me.FACTORVENTACOTIZACION.DataPropertyName = "FACTORVENTA"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.FACTORVENTACOTIZACION.DefaultCellStyle = DataGridViewCellStyle3
        Me.FACTORVENTACOTIZACION.HeaderText = "Cotizacion"
        Me.FACTORVENTACOTIZACION.Name = "FACTORVENTACOTIZACION"
        Me.FACTORVENTACOTIZACION.ReadOnly = True
        Me.FACTORVENTACOTIZACION.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FECGRACOTIZACION
        '
        Me.FECGRACOTIZACION.DataPropertyName = "FECGRA"
        Me.FECGRACOTIZACION.HeaderText = "FECGRA"
        Me.FECGRACOTIZACION.Name = "FECGRACOTIZACION"
        Me.FECGRACOTIZACION.ReadOnly = True
        Me.FECGRACOTIZACION.Visible = False
        '
        'COTIZACIONBindingSource
        '
        Me.COTIZACIONBindingSource.DataMember = "COTIZACION"
        Me.COTIZACIONBindingSource.DataSource = Me.DsFacturacion
        '
        'txtImagen
        '
        Me.txtImagen.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MONEDABindingSource, "IMAGEN", True))
        Me.txtImagen.Location = New System.Drawing.Point(834, 39)
        Me.txtImagen.Name = "txtImagen"
        Me.txtImagen.Size = New System.Drawing.Size(80, 20)
        Me.txtImagen.TabIndex = 3
        Me.txtImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.pbxNuevaFicha)
        Me.Panel1.Controls.Add(Me.pbxCancelar)
        Me.Panel1.Controls.Add(Me.pbxModificarFicha)
        Me.Panel1.Controls.Add(Me.pbxGuardar)
        Me.Panel1.Controls.Add(Me.pbxEliminarFicha)
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
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
        Me.PictureBox1.Location = New System.Drawing.Point(3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 397
        Me.PictureBox1.TabStop = False
        '
        'pbxNuevaFicha
        '
        Me.pbxNuevaFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevaFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevaFicha.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevaFicha.InitialImage = Nothing
        Me.pbxNuevaFicha.Location = New System.Drawing.Point(207, 2)
        Me.pbxNuevaFicha.Name = "pbxNuevaFicha"
        Me.pbxNuevaFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxNuevaFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuevaFicha.TabIndex = 3
        Me.pbxNuevaFicha.TabStop = False
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackColor = System.Drawing.Color.Transparent
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(343, 2)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(35, 35)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 7
        Me.pbxCancelar.TabStop = False
        '
        'pbxModificarFicha
        '
        Me.pbxModificarFicha.BackColor = System.Drawing.Color.Transparent
        Me.pbxModificarFicha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxModificarFicha.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.pbxModificarFicha.InitialImage = Nothing
        Me.pbxModificarFicha.Location = New System.Drawing.Point(275, 2)
        Me.pbxModificarFicha.Name = "pbxModificarFicha"
        Me.pbxModificarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxModificarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxModificarFicha.TabIndex = 5
        Me.pbxModificarFicha.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackColor = System.Drawing.Color.Transparent
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.pbxGuardar.InitialImage = Nothing
        Me.pbxGuardar.Location = New System.Drawing.Point(309, 2)
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
        Me.pbxEliminarFicha.Location = New System.Drawing.Point(241, 2)
        Me.pbxEliminarFicha.Name = "pbxEliminarFicha"
        Me.pbxEliminarFicha.Size = New System.Drawing.Size(35, 35)
        Me.pbxEliminarFicha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEliminarFicha.TabIndex = 4
        Me.pbxEliminarFicha.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtMultiplicador)
        Me.Panel2.Controls.Add(Me.lblEjemplo)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.pbxEnPromocion)
        Me.Panel2.Controls.Add(Me.txtCantDecimales)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cbxDecimales)
        Me.Panel2.Controls.Add(Me.cbxUsarDecimales)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtDesMoneda)
        Me.Panel2.Controls.Add(Me.DIRECCIONLabel)
        Me.Panel2.Controls.Add(Me.DESEMPRESALabel)
        Me.Panel2.Controls.Add(Me.txtVentaCotizacion)
        Me.Panel2.Controls.Add(Me.grdCotizacion)
        Me.Panel2.Controls.Add(Me.txtSimbolo)
        Me.Panel2.Controls.Add(Me.txtFechaCotizacion)
        Me.Panel2.Controls.Add(Me.rbtnAgregarCotizacion)
        Me.Panel2.Location = New System.Drawing.Point(209, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(491, 428)
        Me.Panel2.TabIndex = 404
        '
        'txtMultiplicador
        '
        Me.txtMultiplicador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.txtMultiplicador.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtMultiplicador.FormattingEnabled = True
        Me.txtMultiplicador.Items.AddRange(New Object() {"*", "/"})
        Me.txtMultiplicador.Location = New System.Drawing.Point(114, 81)
        Me.txtMultiplicador.Name = "txtMultiplicador"
        Me.txtMultiplicador.Size = New System.Drawing.Size(68, 28)
        Me.txtMultiplicador.TabIndex = 481
        '
        'lblEjemplo
        '
        Me.lblEjemplo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.lblEjemplo.Location = New System.Drawing.Point(188, 81)
        Me.lblEjemplo.Name = "lblEjemplo"
        Me.lblEjemplo.Size = New System.Drawing.Size(293, 78)
        Me.lblEjemplo.TabIndex = 480
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label3.Location = New System.Drawing.Point(23, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 17)
        Me.Label3.TabIndex = 478
        Me.Label3.Text = "Multiplicador:"
        '
        'pbxEnPromocion
        '
        Me.pbxEnPromocion.BackColor = System.Drawing.Color.Transparent
        Me.pbxEnPromocion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEnPromocion.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEnPromocion.Image = Global.ContaExpress.My.Resources.Resources.star___copia
        Me.pbxEnPromocion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxEnPromocion.Location = New System.Drawing.Point(7, 12)
        Me.pbxEnPromocion.Name = "pbxEnPromocion"
        Me.pbxEnPromocion.Size = New System.Drawing.Size(41, 37)
        Me.pbxEnPromocion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEnPromocion.TabIndex = 477
        Me.pbxEnPromocion.TabStop = False
        '
        'txtCantDecimales
        '
        Me.txtCantDecimales.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtCantDecimales.Location = New System.Drawing.Point(385, 48)
        Me.txtCantDecimales.MaxLength = 50
        Me.txtCantDecimales.Name = "txtCantDecimales"
        Me.txtCantDecimales.Size = New System.Drawing.Size(98, 27)
        Me.txtCantDecimales.TabIndex = 374
        Me.txtCantDecimales.TabStop = False
        Me.txtCantDecimales.ThemeName = "Breeze"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(224, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 17)
        Me.Label1.TabIndex = 373
        Me.Label1.Text = "Cantidad de Decimales:"
        '
        'cbxDecimales
        '
        Me.cbxDecimales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDecimales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cbxDecimales.FormattingEnabled = True
        Me.cbxDecimales.Items.AddRange(New Object() {"Si", "No"})
        Me.cbxDecimales.Location = New System.Drawing.Point(114, 47)
        Me.cbxDecimales.Name = "cbxDecimales"
        Me.cbxDecimales.Size = New System.Drawing.Size(103, 28)
        Me.cbxDecimales.TabIndex = 372
        '
        'cbxUsarDecimales
        '
        Me.cbxUsarDecimales.AutoSize = True
        Me.cbxUsarDecimales.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbxUsarDecimales.Location = New System.Drawing.Point(3, 53)
        Me.cbxUsarDecimales.Name = "cbxUsarDecimales"
        Me.cbxUsarDecimales.Size = New System.Drawing.Size(111, 17)
        Me.cbxUsarDecimales.TabIndex = 371
        Me.cbxUsarDecimales.Text = "Usar Decimales:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 21)
        Me.Label2.TabIndex = 370
        Me.Label2.Text = "Cotizacion Historico"
        '
        'DESEMPRESALabel
        '
        Me.DESEMPRESALabel.AutoSize = True
        Me.DESEMPRESALabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.DESEMPRESALabel.Location = New System.Drawing.Point(51, 20)
        Me.DESEMPRESALabel.Name = "DESEMPRESALabel"
        Me.DESEMPRESALabel.Size = New System.Drawing.Size(63, 17)
        Me.DESEMPRESALabel.TabIndex = 366
        Me.DESEMPRESALabel.Text = "Moneda:"
        '
        'grdBuscador
        '
        Me.grdBuscador.AllowUserToAddRows = False
        Me.grdBuscador.AllowUserToDeleteRows = False
        Me.grdBuscador.AllowUserToResizeColumns = False
        Me.grdBuscador.AllowUserToResizeRows = False
        Me.grdBuscador.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grdBuscador.AutoGenerateColumns = False
        Me.grdBuscador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grdBuscador.BackgroundColor = System.Drawing.Color.Lavender
        Me.grdBuscador.CausesValidation = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBuscador.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdBuscador.ColumnHeadersHeight = 35
        Me.grdBuscador.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODMONEDADataGridViewTextBoxColumn, Me.DESMONEDADataGridViewTextBoxColumn, Me.SIMBOLODataGridViewTextBoxColumn, Me.PRIORIDADDataGridViewTextBoxColumn})
        Me.grdBuscador.DataSource = Me.MONEDABindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdBuscador.DefaultCellStyle = DataGridViewCellStyle6
        Me.grdBuscador.GridColor = System.Drawing.SystemColors.AppWorkspace
        Me.grdBuscador.Location = New System.Drawing.Point(1, 43)
        Me.grdBuscador.MultiSelect = False
        Me.grdBuscador.Name = "grdBuscador"
        Me.grdBuscador.ReadOnly = True
        Me.grdBuscador.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LightSkyBlue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdBuscador.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.grdBuscador.RowHeadersVisible = False
        Me.grdBuscador.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.grdBuscador.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdBuscador.ShowCellErrors = False
        Me.grdBuscador.ShowRowErrors = False
        Me.grdBuscador.Size = New System.Drawing.Size(203, 427)
        Me.grdBuscador.TabIndex = 423
        '
        'CODMONEDADataGridViewTextBoxColumn
        '
        Me.CODMONEDADataGridViewTextBoxColumn.DataPropertyName = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.HeaderText = "CODMONEDA"
        Me.CODMONEDADataGridViewTextBoxColumn.Name = "CODMONEDADataGridViewTextBoxColumn"
        Me.CODMONEDADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODMONEDADataGridViewTextBoxColumn.Visible = False
        '
        'DESMONEDADataGridViewTextBoxColumn
        '
        Me.DESMONEDADataGridViewTextBoxColumn.DataPropertyName = "DESMONEDA"
        Me.DESMONEDADataGridViewTextBoxColumn.HeaderText = "Moneda"
        Me.DESMONEDADataGridViewTextBoxColumn.Name = "DESMONEDADataGridViewTextBoxColumn"
        Me.DESMONEDADataGridViewTextBoxColumn.ReadOnly = True
        '
        'SIMBOLODataGridViewTextBoxColumn
        '
        Me.SIMBOLODataGridViewTextBoxColumn.DataPropertyName = "SIMBOLO"
        Me.SIMBOLODataGridViewTextBoxColumn.HeaderText = "Simbolo"
        Me.SIMBOLODataGridViewTextBoxColumn.Name = "SIMBOLODataGridViewTextBoxColumn"
        Me.SIMBOLODataGridViewTextBoxColumn.ReadOnly = True
        '
        'PRIORIDADDataGridViewTextBoxColumn
        '
        Me.PRIORIDADDataGridViewTextBoxColumn.DataPropertyName = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.HeaderText = "PRIORIDAD"
        Me.PRIORIDADDataGridViewTextBoxColumn.Name = "PRIORIDADDataGridViewTextBoxColumn"
        Me.PRIORIDADDataGridViewTextBoxColumn.ReadOnly = True
        Me.PRIORIDADDataGridViewTextBoxColumn.Visible = False
        '
        'MONEDATableAdapter
        '
        Me.MONEDATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AUDITORIAMOVIMIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.AUDITORIATABLASTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.BANCOTableAdapter = Nothing
        Me.TableAdapterManager.CIUDADTableAdapter = Nothing
        Me.TableAdapterManager.CLIENTESTableAdapter = Nothing
        Me.TableAdapterManager.COMBODETALLETableAdapter = Nothing
        Me.TableAdapterManager.COMBOTableAdapter = Nothing
        Me.TableAdapterManager.COTIZACIONTableAdapter = Nothing
        Me.TableAdapterManager.CUENTABANCARIATableAdapter = Nothing
        Me.TableAdapterManager.CUOTAVENTATableAdapter = Nothing
        Me.TableAdapterManager.DEPARTAMENTOTableAdapter = Nothing
        Me.TableAdapterManager.DEVOLUCIONDETALLETableAdapter = Nothing
        Me.TableAdapterManager.DEVOLUCIONTableAdapter = Nothing
        Me.TableAdapterManager.DIRECCIONESFILTROTableAdapter = Nothing
        Me.TableAdapterManager.DIRECCIONESTableAdapter = Nothing
        Me.TableAdapterManager.EMPRESATableAdapter = Nothing
        Me.TableAdapterManager.EMPRESATRANSPORTETableAdapter = Nothing
        Me.TableAdapterManager.ENCARGADOTableAdapter = Nothing
        Me.TableAdapterManager.INSTRUMENTOTableAdapter = Nothing
        Me.TableAdapterManager.MONEDASINFILTROTableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Me.MONEDATableAdapter
        Me.TableAdapterManager.PAISTableAdapter = Nothing
        Me.TableAdapterManager.PCTableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOENVIODETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOENVIOTableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTAPAGODETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTASDETALLETableAdapter = Nothing
        Me.TableAdapterManager.PRESUPUESTOVENTASTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCHEQUETableAdapter = Nothing
        Me.TableAdapterManager.TIPOCOMPROBANTE_VENTATableAdapter = Nothing
        Me.TableAdapterManager.TIPOCOMPROBANTETableAdapter = Nothing
        Me.TableAdapterManager.TIPOCUENTATableAdapter = Nothing
        Me.TableAdapterManager.TIPOTARJETATableAdapter = Nothing
        Me.TableAdapterManager.TIPOTRANSPORTETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.dsFacturacionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VENTASASRTableAdapter = Nothing
        Me.TableAdapterManager.VENTASDETALLETableAdapter = Nothing
        Me.TableAdapterManager.VENTASENVIOSDETALLESTableAdapter = Nothing
        Me.TableAdapterManager.VENTASENVIOSTableAdapter = Nothing
        Me.TableAdapterManager.VENTASFORMACOBROTableAdapter = Nothing
        Me.TableAdapterManager.VENTASOTTableAdapter = Nothing
        Me.TableAdapterManager.VENTASPRESUPUESTOTableAdapter = Nothing
        Me.TableAdapterManager.VENTASTableAdapter = Nothing
        Me.TableAdapterManager.ZONATableAdapter = Nothing
        '
        'COTIZACIONTableAdapter
        '
        Me.COTIZACIONTableAdapter.ClearBeforeFill = True
        '
        'ABMMonedas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(707, 474)
        Me.Controls.Add(Me.grdBuscador)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtImagen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(713, 500)
        Me.Name = "ABMMonedas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Moneda & Cotizacion | Cogent SIG"
        CType(Me.txtDesMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.txtDesMoneda.ResumeLayout(False)
        Me.txtDesMoneda.PerformLayout()
        CType(Me.txtCodMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MONEDABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSimbolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbtnAgregarCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCotizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COTIZACIONBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevaFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxModificarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxEliminarFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbxEnPromocion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCantDecimales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents COTIZACIONBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents COTIZACIONTableAdapter As ContaExpress.dsFacturacionTableAdapters.COTIZACIONTableAdapter
    Friend WithEvents txtCantDecimales As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxDecimales As System.Windows.Forms.ComboBox
    Friend WithEvents cbxUsarDecimales As System.Windows.Forms.Label
    Friend WithEvents grdBuscador As System.Windows.Forms.DataGridView
    Friend WithEvents CODMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESMONEDADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIMBOLODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIORIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbxEnPromocion As System.Windows.Forms.PictureBox
    Friend WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblEjemplo As System.Windows.Forms.Label
    Friend WithEvents txtMultiplicador As System.Windows.Forms.ComboBox
    Friend WithEvents FECHAMOVIMIENTOCOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODMONEDACOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODUSUARIOCOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESACOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FACTORVENTACOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRACOTIZACION As System.Windows.Forms.DataGridViewTextBoxColumn

#End Region 'Methods

End Class