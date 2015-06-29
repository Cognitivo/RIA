<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class ABMEmpresa
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend  WithEvents AquaTheme1 As Telerik.WinControls.Themes.AquaTheme
    Friend  WithEvents AUDITORIATABLASBindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents AUDITORIATABLASTableAdapter As ContaExpress.dsFacturacionTableAdapters.AUDITORIATABLASTableAdapter
    Friend  WithEvents CachedCdCCompras1 As Reportes.CachedCdCCompras
    Friend  WithEvents CarpetaComTextBox As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents chkRetentor As Telerik.WinControls.UI.RadCheckBox
    Friend  WithEvents ConfCarpetaButton As Telerik.WinControls.UI.RadButton
    Friend  WithEvents DESEMPRESALabel As System.Windows.Forms.Label
    Friend  WithEvents DIRECCIONLabel As System.Windows.Forms.Label
    Friend  WithEvents DsFacturacion As ContaExpress.dsFacturacion
    Friend  WithEvents EMAILLabel As System.Windows.Forms.Label
    Friend  WithEvents EMPRESABindingSource As System.Windows.Forms.BindingSource
    Friend  WithEvents EMPRESATableAdapter As ContaExpress.dsFacturacionTableAdapters.EMPRESATableAdapter
    Friend  WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend  WithEvents grdBuscador As Telerik.WinControls.UI.RadGridView
    Friend  WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LOCALIDADLabel As System.Windows.Forms.Label
    Friend  WithEvents LOGOTIPOTextBox As System.Windows.Forms.TextBox
    Friend  WithEvents NOMCONTRIBUYENTELabel As System.Windows.Forms.Label
    Friend  WithEvents NOMFANTASIALabel As System.Windows.Forms.Label
    Friend  WithEvents NOMREPRESENTANTELabel As System.Windows.Forms.Label
    Friend  WithEvents NUMREGISTROLabel As System.Windows.Forms.Label
    Friend  WithEvents NUMREGPATRONALLabel As System.Windows.Forms.Label
    Friend  WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pbxCancelar As System.Windows.Forms.PictureBox
    Friend  WithEvents pbxGuardar As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend  WithEvents PictureBoxLogotipo As System.Windows.Forms.PictureBox
    Friend  WithEvents PORRETENCIOLabel As System.Windows.Forms.Label
    Friend  WithEvents RadGroupBox1 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox2 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadGroupBox8 As Telerik.WinControls.UI.RadGroupBox
    Friend  WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
    Friend  WithEvents RadPanel2 As Telerik.WinControls.UI.RadPanel
    Friend  WithEvents RETENTORLabel As System.Windows.Forms.Label
    Friend  WithEvents RUCCONTRIBUYENTELabel As System.Windows.Forms.Label
    Friend  WithEvents RUCREPRESENTANTELabel As System.Windows.Forms.Label
    Friend  WithEvents TableAdapterManager As ContaExpress.dsFacturacionTableAdapters.TableAdapterManager
    Friend  WithEvents TELEFONOLabel As System.Windows.Forms.Label
    Friend  WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend  WithEvents txtCodEmpresa As System.Windows.Forms.TextBox
    Friend  WithEvents txtDesEmpresa As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtDireccion As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtEmail As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtLocalidad As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNomContribuyente As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNomFantasia As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNomRepresentante As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNroRegistro As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtNumRegPatronal As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtPorRetencion As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend  WithEvents txtRUCContribuyente As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtRUCRepresentante As Telerik.WinControls.UI.RadTextBox
    Friend  WithEvents txtTelefono As Telerik.WinControls.UI.RadTextBox

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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMEmpresa))
        Me.NOMFANTASIALabel = New System.Windows.Forms.Label()
        Me.NOMCONTRIBUYENTELabel = New System.Windows.Forms.Label()
        Me.RUCCONTRIBUYENTELabel = New System.Windows.Forms.Label()
        Me.DESEMPRESALabel = New System.Windows.Forms.Label()
        Me.DIRECCIONLabel = New System.Windows.Forms.Label()
        Me.TELEFONOLabel = New System.Windows.Forms.Label()
        Me.EMAILLabel = New System.Windows.Forms.Label()
        Me.NUMREGPATRONALLabel = New System.Windows.Forms.Label()
        Me.RETENTORLabel = New System.Windows.Forms.Label()
        Me.NOMREPRESENTANTELabel = New System.Windows.Forms.Label()
        Me.RUCREPRESENTANTELabel = New System.Windows.Forms.Label()
        Me.LOCALIDADLabel = New System.Windows.Forms.Label()
        Me.NUMREGISTROLabel = New System.Windows.Forms.Label()
        Me.PORRETENCIOLabel = New System.Windows.Forms.Label()
        Me.grdBuscador = New Telerik.WinControls.UI.RadGridView()
        Me.EMPRESABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsFacturacion = New ContaExpress.dsFacturacion()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.txtCodEmpresa = New System.Windows.Forms.TextBox()
        Me.RadGroupBox8 = New Telerik.WinControls.UI.RadGroupBox()
        Me.txtCodGNU = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadPanel2 = New Telerik.WinControls.UI.RadPanel()
        Me.PictureBoxLogotipo = New System.Windows.Forms.PictureBox()
        Me.LOGOTIPOTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTelefono = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLocalidad = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDesEmpresa = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDireccion = New Telerik.WinControls.UI.RadTextBox()
        Me.txtNomFantasia = New Telerik.WinControls.UI.RadTextBox()
        Me.RadGroupBox1 = New Telerik.WinControls.UI.RadGroupBox()
        Me.umePorcRetRenta = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Empresa2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEmpresa = New ContaExpress.DsEmpresa()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbExportador = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPorRetencion = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.chkRetentor = New Telerik.WinControls.UI.RadCheckBox()
        Me.txtNroRegistro = New Telerik.WinControls.UI.RadTextBox()
        Me.txtRUCRepresentante = New Telerik.WinControls.UI.RadTextBox()
        Me.txtNumRegPatronal = New Telerik.WinControls.UI.RadTextBox()
        Me.txtRUCContribuyente = New Telerik.WinControls.UI.RadTextBox()
        Me.txtNomRepresentante = New Telerik.WinControls.UI.RadTextBox()
        Me.txtNomContribuyente = New Telerik.WinControls.UI.RadTextBox()
        Me.AquaTheme1 = New Telerik.WinControls.Themes.AquaTheme()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CarpetaComTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        Me.ConfCarpetaButton = New Telerik.WinControls.UI.RadButton()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.RadGroupBox2 = New Telerik.WinControls.UI.RadGroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pbxCancelar = New System.Windows.Forms.PictureBox()
        Me.pbxGuardar = New System.Windows.Forms.PictureBox()
        Me.EMPRESATableAdapter = New ContaExpress.dsFacturacionTableAdapters.EMPRESATableAdapter()
        Me.TableAdapterManager = New ContaExpress.dsFacturacionTableAdapters.TableAdapterManager()
        Me.AUDITORIATABLASTableAdapter = New ContaExpress.dsFacturacionTableAdapters.AUDITORIATABLASTableAdapter()
        Me.AUDITORIATABLASBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CachedCdCCompras1 = New Reportes.CachedCdCCompras()
        Me.EMPRESATableAdapter1 = New ContaExpress.DsEmpresaTableAdapters.EMPRESATableAdapter()
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox8.SuspendLayout()
        CType(Me.txtCodGNU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadPanel2.SuspendLayout()
        CType(Me.PictureBoxLogotipo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomFantasia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox1.SuspendLayout()
        CType(Me.Empresa2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkRetentor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNroRegistro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRUCRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumRegPatronal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRUCContribuyente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNomContribuyente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CarpetaComTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConfCarpetaButton, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RadGroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NOMFANTASIALabel
        '
        Me.NOMFANTASIALabel.AutoSize = True
        Me.NOMFANTASIALabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.NOMFANTASIALabel.Location = New System.Drawing.Point(82, 29)
        Me.NOMFANTASIALabel.Name = "NOMFANTASIALabel"
        Me.NOMFANTASIALabel.Size = New System.Drawing.Size(123, 15)
        Me.NOMFANTASIALabel.TabIndex = 360
        Me.NOMFANTASIALabel.Text = "Nombre de Fantasía:"
        '
        'NOMCONTRIBUYENTELabel
        '
        Me.NOMCONTRIBUYENTELabel.AutoSize = True
        Me.NOMCONTRIBUYENTELabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.NOMCONTRIBUYENTELabel.Location = New System.Drawing.Point(78, 28)
        Me.NOMCONTRIBUYENTELabel.Name = "NOMCONTRIBUYENTELabel"
        Me.NOMCONTRIBUYENTELabel.Size = New System.Drawing.Size(134, 15)
        Me.NOMCONTRIBUYENTELabel.TabIndex = 362
        Me.NOMCONTRIBUYENTELabel.Text = "Nombre Contribuyente:"
        '
        'RUCCONTRIBUYENTELabel
        '
        Me.RUCCONTRIBUYENTELabel.AutoSize = True
        Me.RUCCONTRIBUYENTELabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RUCCONTRIBUYENTELabel.Location = New System.Drawing.Point(96, 57)
        Me.RUCCONTRIBUYENTELabel.Name = "RUCCONTRIBUYENTELabel"
        Me.RUCCONTRIBUYENTELabel.Size = New System.Drawing.Size(116, 15)
        Me.RUCCONTRIBUYENTELabel.TabIndex = 364
        Me.RUCCONTRIBUYENTELabel.Text = "RUC Contribuyente:"
        '
        'DESEMPRESALabel
        '
        Me.DESEMPRESALabel.AutoSize = True
        Me.DESEMPRESALabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DESEMPRESALabel.Location = New System.Drawing.Point(129, 59)
        Me.DESEMPRESALabel.Name = "DESEMPRESALabel"
        Me.DESEMPRESALabel.Size = New System.Drawing.Size(76, 15)
        Me.DESEMPRESALabel.TabIndex = 366
        Me.DESEMPRESALabel.Text = "Descripción:"
        '
        'DIRECCIONLabel
        '
        Me.DIRECCIONLabel.AutoSize = True
        Me.DIRECCIONLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.DIRECCIONLabel.Location = New System.Drawing.Point(143, 89)
        Me.DIRECCIONLabel.Name = "DIRECCIONLabel"
        Me.DIRECCIONLabel.Size = New System.Drawing.Size(62, 15)
        Me.DIRECCIONLabel.TabIndex = 368
        Me.DIRECCIONLabel.Text = "Dirección:"
        '
        'TELEFONOLabel
        '
        Me.TELEFONOLabel.AutoSize = True
        Me.TELEFONOLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TELEFONOLabel.Location = New System.Drawing.Point(148, 119)
        Me.TELEFONOLabel.Name = "TELEFONOLabel"
        Me.TELEFONOLabel.Size = New System.Drawing.Size(57, 15)
        Me.TELEFONOLabel.TabIndex = 370
        Me.TELEFONOLabel.Text = "Teléfono:"
        '
        'EMAILLabel
        '
        Me.EMAILLabel.AutoSize = True
        Me.EMAILLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.EMAILLabel.Location = New System.Drawing.Point(161, 149)
        Me.EMAILLabel.Name = "EMAILLabel"
        Me.EMAILLabel.Size = New System.Drawing.Size(44, 15)
        Me.EMAILLabel.TabIndex = 372
        Me.EMAILLabel.Text = "E-Mail:"
        '
        'NUMREGPATRONALLabel
        '
        Me.NUMREGPATRONALLabel.AutoSize = True
        Me.NUMREGPATRONALLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.NUMREGPATRONALLabel.Location = New System.Drawing.Point(101, 86)
        Me.NUMREGPATRONALLabel.Name = "NUMREGPATRONALLabel"
        Me.NUMREGPATRONALLabel.Size = New System.Drawing.Size(111, 15)
        Me.NUMREGPATRONALLabel.TabIndex = 374
        Me.NUMREGPATRONALLabel.Text = "Nro. Reg. Patronal:"
        '
        'RETENTORLabel
        '
        Me.RETENTORLabel.AutoSize = True
        Me.RETENTORLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RETENTORLabel.Location = New System.Drawing.Point(155, 115)
        Me.RETENTORLabel.Name = "RETENTORLabel"
        Me.RETENTORLabel.Size = New System.Drawing.Size(57, 15)
        Me.RETENTORLabel.TabIndex = 376
        Me.RETENTORLabel.Text = "Retentor:"
        '
        'NOMREPRESENTANTELabel
        '
        Me.NOMREPRESENTANTELabel.AutoSize = True
        Me.NOMREPRESENTANTELabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.NOMREPRESENTANTELabel.Location = New System.Drawing.Point(52, 144)
        Me.NOMREPRESENTANTELabel.Name = "NOMREPRESENTANTELabel"
        Me.NOMREPRESENTANTELabel.Size = New System.Drawing.Size(160, 15)
        Me.NOMREPRESENTANTELabel.TabIndex = 378
        Me.NOMREPRESENTANTELabel.Text = "Nombre del Representante:"
        '
        'RUCREPRESENTANTELabel
        '
        Me.RUCREPRESENTANTELabel.AutoSize = True
        Me.RUCREPRESENTANTELabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RUCREPRESENTANTELabel.Location = New System.Drawing.Point(70, 173)
        Me.RUCREPRESENTANTELabel.Name = "RUCREPRESENTANTELabel"
        Me.RUCREPRESENTANTELabel.Size = New System.Drawing.Size(142, 15)
        Me.RUCREPRESENTANTELabel.TabIndex = 380
        Me.RUCREPRESENTANTELabel.Text = "RUC del Representante:"
        '
        'LOCALIDADLabel
        '
        Me.LOCALIDADLabel.AutoSize = True
        Me.LOCALIDADLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.LOCALIDADLabel.Location = New System.Drawing.Point(141, 179)
        Me.LOCALIDADLabel.Name = "LOCALIDADLabel"
        Me.LOCALIDADLabel.Size = New System.Drawing.Size(64, 15)
        Me.LOCALIDADLabel.TabIndex = 384
        Me.LOCALIDADLabel.Text = "Localidad:"
        '
        'NUMREGISTROLabel
        '
        Me.NUMREGISTROLabel.AutoSize = True
        Me.NUMREGISTROLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.NUMREGISTROLabel.Location = New System.Drawing.Point(129, 202)
        Me.NUMREGISTROLabel.Name = "NUMREGISTROLabel"
        Me.NUMREGISTROLabel.Size = New System.Drawing.Size(83, 15)
        Me.NUMREGISTROLabel.TabIndex = 386
        Me.NUMREGISTROLabel.Text = "Nro. Registro:"
        '
        'PORRETENCIOLabel
        '
        Me.PORRETENCIOLabel.AutoSize = True
        Me.PORRETENCIOLabel.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PORRETENCIOLabel.Location = New System.Drawing.Point(114, 230)
        Me.PORRETENCIOLabel.Name = "PORRETENCIOLabel"
        Me.PORRETENCIOLabel.Size = New System.Drawing.Size(98, 15)
        Me.PORRETENCIOLabel.TabIndex = 388
        Me.PORRETENCIOLabel.Text = "Retención IVA %:"
        '
        'grdBuscador
        '
        Me.grdBuscador.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdBuscador.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdBuscador.EnableAlternatingRowColor = True
        Me.grdBuscador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.grdBuscador.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdBuscador.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdBuscador.Location = New System.Drawing.Point(127, 292)
        '
        '
        '
        Me.grdBuscador.MasterGridViewTemplate.AllowAddNewRow = False
        Me.grdBuscador.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn1.FieldName = "CODEMPRESA"
        GridViewDecimalColumn1.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODEMPRESA"
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "USUGRA"
        GridViewDecimalColumn2.FieldName = "USUGRA"
        GridViewDecimalColumn2.HeaderText = "USUGRA"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "USUGRA"
        GridViewTextBoxColumn1.FieldAlias = "NOMFANTASIA"
        GridViewTextBoxColumn1.FieldName = "NOMFANTASIA"
        GridViewTextBoxColumn1.HeaderText = "Empresa"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.UniqueName = "NOMFANTASIA"
        GridViewTextBoxColumn1.Width = 170
        GridViewTextBoxColumn2.FieldAlias = "NOMCONTRIBUYENTE"
        GridViewTextBoxColumn2.FieldName = "NOMCONTRIBUYENTE"
        GridViewTextBoxColumn2.HeaderText = "NOMCONTRIBUYENTE"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.UniqueName = "NOMCONTRIBUYENTE"
        GridViewTextBoxColumn3.FieldAlias = "RUCCONTRIBUYENTE"
        GridViewTextBoxColumn3.FieldName = "RUCCONTRIBUYENTE"
        GridViewTextBoxColumn3.HeaderText = "RUCCONTRIBUYENTE"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.UniqueName = "RUCCONTRIBUYENTE"
        GridViewTextBoxColumn4.FieldAlias = "DESEMPRESA"
        GridViewTextBoxColumn4.FieldName = "DESEMPRESA"
        GridViewTextBoxColumn4.HeaderText = "DESEMPRESA"
        GridViewTextBoxColumn4.IsAutoGenerated = True
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.UniqueName = "DESEMPRESA"
        GridViewTextBoxColumn5.FieldAlias = "DIRECCION"
        GridViewTextBoxColumn5.FieldName = "DIRECCION"
        GridViewTextBoxColumn5.HeaderText = "DIRECCION"
        GridViewTextBoxColumn5.IsAutoGenerated = True
        GridViewTextBoxColumn5.IsVisible = False
        GridViewTextBoxColumn5.UniqueName = "DIRECCION"
        GridViewTextBoxColumn6.FieldAlias = "TELEFONO"
        GridViewTextBoxColumn6.FieldName = "TELEFONO"
        GridViewTextBoxColumn6.HeaderText = "TELEFONO"
        GridViewTextBoxColumn6.IsAutoGenerated = True
        GridViewTextBoxColumn6.IsVisible = False
        GridViewTextBoxColumn6.UniqueName = "TELEFONO"
        GridViewTextBoxColumn7.FieldAlias = "EMAIL"
        GridViewTextBoxColumn7.FieldName = "EMAIL"
        GridViewTextBoxColumn7.HeaderText = "EMAIL"
        GridViewTextBoxColumn7.IsAutoGenerated = True
        GridViewTextBoxColumn7.IsVisible = False
        GridViewTextBoxColumn7.UniqueName = "EMAIL"
        GridViewTextBoxColumn8.FieldAlias = "NUMREGPATRONAL"
        GridViewTextBoxColumn8.FieldName = "NUMREGPATRONAL"
        GridViewTextBoxColumn8.HeaderText = "NUMREGPATRONAL"
        GridViewTextBoxColumn8.IsAutoGenerated = True
        GridViewTextBoxColumn8.IsVisible = False
        GridViewTextBoxColumn8.UniqueName = "NUMREGPATRONAL"
        GridViewDecimalColumn3.DataType = GetType(Byte)
        GridViewDecimalColumn3.FieldAlias = "RETENTOR"
        GridViewDecimalColumn3.FieldName = "RETENTOR"
        GridViewDecimalColumn3.HeaderText = "RETENTOR"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "RETENTOR"
        GridViewTextBoxColumn9.FieldAlias = "NOMREPRESENTANTE"
        GridViewTextBoxColumn9.FieldName = "NOMREPRESENTANTE"
        GridViewTextBoxColumn9.HeaderText = "NOMREPRESENTANTE"
        GridViewTextBoxColumn9.IsAutoGenerated = True
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.UniqueName = "NOMREPRESENTANTE"
        GridViewTextBoxColumn10.FieldAlias = "RUCREPRESENTANTE"
        GridViewTextBoxColumn10.FieldName = "RUCREPRESENTANTE"
        GridViewTextBoxColumn10.HeaderText = "RUCREPRESENTANTE"
        GridViewTextBoxColumn10.IsAutoGenerated = True
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.UniqueName = "RUCREPRESENTANTE"
        GridViewDateTimeColumn1.DataType = GetType(Date)
        GridViewDateTimeColumn1.FieldAlias = "FECGRA"
        GridViewDateTimeColumn1.FieldName = "FECGRA"
        GridViewDateTimeColumn1.HeaderText = "FECGRA"
        GridViewDateTimeColumn1.IsAutoGenerated = True
        GridViewDateTimeColumn1.IsVisible = False
        GridViewDateTimeColumn1.UniqueName = "FECGRA"
        GridViewTextBoxColumn11.FieldAlias = "LOCALIDAD"
        GridViewTextBoxColumn11.FieldName = "LOCALIDAD"
        GridViewTextBoxColumn11.HeaderText = "LOCALIDAD"
        GridViewTextBoxColumn11.IsAutoGenerated = True
        GridViewTextBoxColumn11.IsVisible = False
        GridViewTextBoxColumn11.UniqueName = "LOCALIDAD"
        GridViewTextBoxColumn12.FieldAlias = "NUMREGISTRO"
        GridViewTextBoxColumn12.FieldName = "NUMREGISTRO"
        GridViewTextBoxColumn12.HeaderText = "NUMREGISTRO"
        GridViewTextBoxColumn12.IsAutoGenerated = True
        GridViewTextBoxColumn12.IsVisible = False
        GridViewTextBoxColumn12.UniqueName = "NUMREGISTRO"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "PORRETENCIO"
        GridViewDecimalColumn4.FieldName = "PORRETENCIO"
        GridViewDecimalColumn4.HeaderText = "PORRETENCIO"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "PORRETENCIO"
        GridViewTextBoxColumn13.FieldAlias = "CARPETACOMPARTIDA"
        GridViewTextBoxColumn13.FieldName = "CARPETACOMPARTIDA"
        GridViewTextBoxColumn13.HeaderText = "CARPETACOMPARTIDA"
        GridViewTextBoxColumn13.IsAutoGenerated = True
        GridViewTextBoxColumn13.IsVisible = False
        GridViewTextBoxColumn13.UniqueName = "CARPETACOMPARTIDA"
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn4)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn5)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn6)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn7)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn8)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn9)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn10)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDateTimeColumn1)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn11)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn12)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.grdBuscador.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn13)
        Me.grdBuscador.MasterGridViewTemplate.DataSource = Me.EMPRESABindingSource
        Me.grdBuscador.MasterGridViewTemplate.EnableGrouping = False
        Me.grdBuscador.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.grdBuscador.Name = "grdBuscador"
        Me.grdBuscador.ReadOnly = True
        Me.grdBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdBuscador.ShowGroupPanel = False
        Me.grdBuscador.Size = New System.Drawing.Size(63, 155)
        Me.grdBuscador.TabIndex = 353
        Me.grdBuscador.Visible = False
        '
        'EMPRESABindingSource
        '
        Me.EMPRESABindingSource.DataMember = "EMPRESA"
        Me.EMPRESABindingSource.DataSource = Me.DsFacturacion
        '
        'DsFacturacion
        '
        Me.DsFacturacion.DataSetName = "dsFacturacion"
        Me.DsFacturacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtBuscar
        '
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtBuscar.CausesValidation = False
        Me.txtBuscar.Location = New System.Drawing.Point(51, 105)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(119, 13)
        Me.txtBuscar.TabIndex = 0
        Me.txtBuscar.Text = "Buscar..."
        '
        'txtCodEmpresa
        '
        Me.txtCodEmpresa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "CODEMPRESA", True))
        Me.txtCodEmpresa.Location = New System.Drawing.Point(634, 111)
        Me.txtCodEmpresa.Name = "txtCodEmpresa"
        Me.txtCodEmpresa.Size = New System.Drawing.Size(48, 20)
        Me.txtCodEmpresa.TabIndex = 357
        '
        'RadGroupBox8
        '
        Me.RadGroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox8.Controls.Add(Me.txtCodGNU)
        Me.RadGroupBox8.Controls.Add(Me.Label4)
        Me.RadGroupBox8.Controls.Add(Me.RadPanel2)
        Me.RadGroupBox8.Controls.Add(Me.LOGOTIPOTextBox)
        Me.RadGroupBox8.Controls.Add(Me.Label1)
        Me.RadGroupBox8.Controls.Add(Me.txtEmail)
        Me.RadGroupBox8.Controls.Add(Me.txtTelefono)
        Me.RadGroupBox8.Controls.Add(Me.txtLocalidad)
        Me.RadGroupBox8.Controls.Add(Me.txtDesEmpresa)
        Me.RadGroupBox8.Controls.Add(Me.txtDireccion)
        Me.RadGroupBox8.Controls.Add(Me.txtNomFantasia)
        Me.RadGroupBox8.Controls.Add(Me.NOMFANTASIALabel)
        Me.RadGroupBox8.Controls.Add(Me.DESEMPRESALabel)
        Me.RadGroupBox8.Controls.Add(Me.DIRECCIONLabel)
        Me.RadGroupBox8.Controls.Add(Me.TELEFONOLabel)
        Me.RadGroupBox8.Controls.Add(Me.EMAILLabel)
        Me.RadGroupBox8.Controls.Add(Me.LOCALIDADLabel)
        Me.RadGroupBox8.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox8.FooterImageIndex = -1
        Me.RadGroupBox8.FooterImageKey = ""
        Me.RadGroupBox8.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox8.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox8.HeaderImageIndex = -1
        Me.RadGroupBox8.HeaderImageKey = ""
        Me.RadGroupBox8.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox8.HeaderText = "Datos de la Empresa"
        Me.RadGroupBox8.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox8.Location = New System.Drawing.Point(7, 41)
        Me.RadGroupBox8.Name = "RadGroupBox8"
        Me.RadGroupBox8.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox8.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox8.Size = New System.Drawing.Size(691, 237)
        Me.RadGroupBox8.TabIndex = 390
        Me.RadGroupBox8.Text = "Datos de la Empresa"
        Me.RadGroupBox8.ThemeName = "Breeze"
        CType(Me.RadGroupBox8.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox8.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox8.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox8.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox8.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'txtCodGNU
        '
        Me.txtCodGNU.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Empresa2BindingSource, "CODGNU", True))
        Me.txtCodGNU.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtCodGNU.Location = New System.Drawing.Point(216, 203)
        Me.txtCodGNU.Name = "txtCodGNU"
        Me.txtCodGNU.Size = New System.Drawing.Size(325, 26)
        Me.txtCodGNU.TabIndex = 404
        Me.txtCodGNU.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(83, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 15)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Código GNU SEPSA:"
        '
        'RadPanel2
        '
        Me.RadPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(139, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.RadPanel2.Controls.Add(Me.PictureBoxLogotipo)
        Me.RadPanel2.Location = New System.Drawing.Point(564, 20)
        Me.RadPanel2.Name = "RadPanel2"
        Me.RadPanel2.Size = New System.Drawing.Size(108, 101)
        Me.RadPanel2.TabIndex = 387
        Me.RadPanel2.ThemeName = "Examples"
        '
        'PictureBoxLogotipo
        '
        Me.PictureBoxLogotipo.BackgroundImage = Global.ContaExpress.My.Resources.Resources.No_Tiene_Imagen
        Me.PictureBoxLogotipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxLogotipo.Location = New System.Drawing.Point(9, 9)
        Me.PictureBoxLogotipo.Name = "PictureBoxLogotipo"
        Me.PictureBoxLogotipo.Size = New System.Drawing.Size(90, 84)
        Me.PictureBoxLogotipo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxLogotipo.TabIndex = 385
        Me.PictureBoxLogotipo.TabStop = False
        '
        'LOGOTIPOTextBox
        '
        Me.LOGOTIPOTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "LOGOTIPO", True))
        Me.LOGOTIPOTextBox.Location = New System.Drawing.Point(569, 97)
        Me.LOGOTIPOTextBox.Name = "LOGOTIPOTextBox"
        Me.LOGOTIPOTextBox.Size = New System.Drawing.Size(100, 20)
        Me.LOGOTIPOTextBox.TabIndex = 403
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(596, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 386
        Me.Label1.Text = "Logotipo"
        '
        'txtEmail
        '
        Me.txtEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "EMAIL", True))
        Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtEmail.Location = New System.Drawing.Point(216, 143)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(325, 26)
        Me.txtEmail.TabIndex = 4
        Me.txtEmail.TabStop = False
        '
        'txtTelefono
        '
        Me.txtTelefono.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "TELEFONO", True))
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtTelefono.Location = New System.Drawing.Point(216, 113)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(325, 26)
        Me.txtTelefono.TabIndex = 3
        Me.txtTelefono.TabStop = False
        '
        'txtLocalidad
        '
        Me.txtLocalidad.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "LOCALIDAD", True))
        Me.txtLocalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtLocalidad.Location = New System.Drawing.Point(216, 173)
        Me.txtLocalidad.Name = "txtLocalidad"
        Me.txtLocalidad.Size = New System.Drawing.Size(325, 26)
        Me.txtLocalidad.TabIndex = 5
        Me.txtLocalidad.TabStop = False
        '
        'txtDesEmpresa
        '
        Me.txtDesEmpresa.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "DESEMPRESA", True))
        Me.txtDesEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDesEmpresa.Location = New System.Drawing.Point(216, 53)
        Me.txtDesEmpresa.Name = "txtDesEmpresa"
        Me.txtDesEmpresa.Size = New System.Drawing.Size(325, 26)
        Me.txtDesEmpresa.TabIndex = 1
        Me.txtDesEmpresa.TabStop = False
        '
        'txtDireccion
        '
        Me.txtDireccion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "DIRECCION", True))
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtDireccion.Location = New System.Drawing.Point(216, 83)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(325, 26)
        Me.txtDireccion.TabIndex = 2
        Me.txtDireccion.TabStop = False
        '
        'txtNomFantasia
        '
        Me.txtNomFantasia.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "NOMFANTASIA", True))
        Me.txtNomFantasia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNomFantasia.Location = New System.Drawing.Point(216, 23)
        Me.txtNomFantasia.Name = "txtNomFantasia"
        Me.txtNomFantasia.Size = New System.Drawing.Size(325, 26)
        Me.txtNomFantasia.TabIndex = 0
        Me.txtNomFantasia.TabStop = False
        '
        'RadGroupBox1
        '
        Me.RadGroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox1.Controls.Add(Me.umePorcRetRenta)
        Me.RadGroupBox1.Controls.Add(Me.Label3)
        Me.RadGroupBox1.Controls.Add(Me.cmbExportador)
        Me.RadGroupBox1.Controls.Add(Me.Label2)
        Me.RadGroupBox1.Controls.Add(Me.txtPorRetencion)
        Me.RadGroupBox1.Controls.Add(Me.chkRetentor)
        Me.RadGroupBox1.Controls.Add(Me.txtNroRegistro)
        Me.RadGroupBox1.Controls.Add(Me.txtRUCRepresentante)
        Me.RadGroupBox1.Controls.Add(Me.txtNumRegPatronal)
        Me.RadGroupBox1.Controls.Add(Me.txtRUCContribuyente)
        Me.RadGroupBox1.Controls.Add(Me.txtNomRepresentante)
        Me.RadGroupBox1.Controls.Add(Me.txtNomContribuyente)
        Me.RadGroupBox1.Controls.Add(Me.PORRETENCIOLabel)
        Me.RadGroupBox1.Controls.Add(Me.RETENTORLabel)
        Me.RadGroupBox1.Controls.Add(Me.NOMCONTRIBUYENTELabel)
        Me.RadGroupBox1.Controls.Add(Me.NUMREGISTROLabel)
        Me.RadGroupBox1.Controls.Add(Me.RUCCONTRIBUYENTELabel)
        Me.RadGroupBox1.Controls.Add(Me.RUCREPRESENTANTELabel)
        Me.RadGroupBox1.Controls.Add(Me.NUMREGPATRONALLabel)
        Me.RadGroupBox1.Controls.Add(Me.NOMREPRESENTANTELabel)
        Me.RadGroupBox1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox1.FooterImageIndex = -1
        Me.RadGroupBox1.FooterImageKey = ""
        Me.RadGroupBox1.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox1.HeaderImageIndex = -1
        Me.RadGroupBox1.HeaderImageKey = ""
        Me.RadGroupBox1.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox1.HeaderText = "Datos Legales"
        Me.RadGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox1.Location = New System.Drawing.Point(7, 282)
        Me.RadGroupBox1.Name = "RadGroupBox1"
        Me.RadGroupBox1.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox1.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox1.Size = New System.Drawing.Size(691, 259)
        Me.RadGroupBox1.TabIndex = 391
        Me.RadGroupBox1.Text = "Datos Legales"
        Me.RadGroupBox1.ThemeName = "Breeze"
        CType(Me.RadGroupBox1.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox1.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'umePorcRetRenta
        '
        Appearance1.FontData.SizeInPoints = 11.0!
        Me.umePorcRetRenta.Appearance = Appearance1
        Me.umePorcRetRenta.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.umePorcRetRenta.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.Empresa2BindingSource, "PORCRETRENTA", True))
        Me.umePorcRetRenta.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umePorcRetRenta.InputMask = "nn.nn"
        Me.umePorcRetRenta.Location = New System.Drawing.Point(453, 225)
        Me.umePorcRetRenta.Name = "umePorcRetRenta"
        Me.umePorcRetRenta.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.umePorcRetRenta.Size = New System.Drawing.Size(93, 24)
        Me.umePorcRetRenta.TabIndex = 394
        '
        'Empresa2BindingSource
        '
        Me.Empresa2BindingSource.DataMember = "EMPRESA"
        Me.Empresa2BindingSource.DataSource = Me.DsEmpresa
        '
        'DsEmpresa
        '
        Me.DsEmpresa.DataSetName = "DsEmpresa"
        Me.DsEmpresa.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(338, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 15)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "Retención Renta %:"
        '
        'cmbExportador
        '
        Me.cmbExportador.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.EMPRESABindingSource, "EXPORTADOR1", True))
        Me.cmbExportador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbExportador.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.cmbExportador.FormattingEnabled = True
        Me.cmbExportador.Items.AddRange(New Object() {"Si", "No"})
        Me.cmbExportador.Location = New System.Drawing.Point(460, 109)
        Me.cmbExportador.Name = "cmbExportador"
        Me.cmbExportador.Size = New System.Drawing.Size(83, 26)
        Me.cmbExportador.TabIndex = 392
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(385, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 391
        Me.Label2.Text = "Exportador:"
        '
        'txtPorRetencion
        '
        Appearance2.FontData.SizeInPoints = 11.0!
        Me.txtPorRetencion.Appearance = Appearance2
        Me.txtPorRetencion.BorderStyle = Infragistics.Win.UIElementBorderStyle.Rounded4
        Me.txtPorRetencion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "PORRETENCIO", True))
        Me.txtPorRetencion.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.txtPorRetencion.InputMask = "nn.nn"
        Me.txtPorRetencion.Location = New System.Drawing.Point(221, 225)
        Me.txtPorRetencion.Name = "txtPorRetencion"
        Me.txtPorRetencion.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.txtPorRetencion.Size = New System.Drawing.Size(93, 24)
        Me.txtPorRetencion.TabIndex = 390
        '
        'chkRetentor
        '
        Me.chkRetentor.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Me.EMPRESABindingSource, "RETENTOR", True))
        Me.chkRetentor.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRetentor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.chkRetentor.Location = New System.Drawing.Point(221, 116)
        Me.chkRetentor.Name = "chkRetentor"
        '
        '
        '
        Me.chkRetentor.RootElement.ForeColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer), CType(CType(5, Byte), Integer))
        Me.chkRetentor.Size = New System.Drawing.Size(100, 13)
        Me.chkRetentor.TabIndex = 3
        '
        'txtNroRegistro
        '
        Me.txtNroRegistro.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "NUMREGISTRO", True))
        Me.txtNroRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNroRegistro.Location = New System.Drawing.Point(221, 196)
        Me.txtNroRegistro.Name = "txtNroRegistro"
        Me.txtNroRegistro.Size = New System.Drawing.Size(325, 26)
        Me.txtNroRegistro.TabIndex = 6
        Me.txtNroRegistro.TabStop = False
        '
        'txtRUCRepresentante
        '
        Me.txtRUCRepresentante.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "RUCREPRESENTANTE", True))
        Me.txtRUCRepresentante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtRUCRepresentante.Location = New System.Drawing.Point(221, 167)
        Me.txtRUCRepresentante.Name = "txtRUCRepresentante"
        Me.txtRUCRepresentante.Size = New System.Drawing.Size(325, 26)
        Me.txtRUCRepresentante.TabIndex = 5
        Me.txtRUCRepresentante.TabStop = False
        '
        'txtNumRegPatronal
        '
        Me.txtNumRegPatronal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "NUMREGPATRONAL", True))
        Me.txtNumRegPatronal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNumRegPatronal.Location = New System.Drawing.Point(221, 80)
        Me.txtNumRegPatronal.Name = "txtNumRegPatronal"
        Me.txtNumRegPatronal.Size = New System.Drawing.Size(325, 26)
        Me.txtNumRegPatronal.TabIndex = 2
        Me.txtNumRegPatronal.TabStop = False
        '
        'txtRUCContribuyente
        '
        Me.txtRUCContribuyente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "RUCCONTRIBUYENTE", True))
        Me.txtRUCContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtRUCContribuyente.Location = New System.Drawing.Point(221, 51)
        Me.txtRUCContribuyente.Name = "txtRUCContribuyente"
        Me.txtRUCContribuyente.Size = New System.Drawing.Size(325, 26)
        Me.txtRUCContribuyente.TabIndex = 1
        Me.txtRUCContribuyente.TabStop = False
        '
        'txtNomRepresentante
        '
        Me.txtNomRepresentante.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "NOMREPRESENTANTE", True))
        Me.txtNomRepresentante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNomRepresentante.Location = New System.Drawing.Point(221, 138)
        Me.txtNomRepresentante.Name = "txtNomRepresentante"
        Me.txtNomRepresentante.Size = New System.Drawing.Size(325, 26)
        Me.txtNomRepresentante.TabIndex = 4
        Me.txtNomRepresentante.TabStop = False
        '
        'txtNomContribuyente
        '
        Me.txtNomContribuyente.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "NOMCONTRIBUYENTE", True))
        Me.txtNomContribuyente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtNomContribuyente.Location = New System.Drawing.Point(221, 22)
        Me.txtNomContribuyente.Name = "txtNomContribuyente"
        Me.txtNomContribuyente.Size = New System.Drawing.Size(325, 26)
        Me.txtNomContribuyente.TabIndex = 0
        Me.txtNomContribuyente.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox1.Location = New System.Drawing.Point(24, 96)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(157, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 355
        Me.PictureBox1.TabStop = False
        '
        'CarpetaComTextBox
        '
        Me.CarpetaComTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EMPRESABindingSource, "CARPETACOMPARTIDA", True))
        Me.CarpetaComTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.CarpetaComTextBox.Location = New System.Drawing.Point(221, 18)
        Me.CarpetaComTextBox.Name = "CarpetaComTextBox"
        Me.CarpetaComTextBox.ReadOnly = True
        Me.CarpetaComTextBox.Size = New System.Drawing.Size(325, 26)
        Me.CarpetaComTextBox.TabIndex = 392
        Me.CarpetaComTextBox.TabStop = False
        '
        'RadLabel1
        '
        Me.RadLabel1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RadLabel1.Location = New System.Drawing.Point(93, 21)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(121, 17)
        Me.RadLabel1.TabIndex = 393
        Me.RadLabel1.Text = "Carpeta Compartida:"
        '
        'ConfCarpetaButton
        '
        Me.ConfCarpetaButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.ConfCarpetaButton.Location = New System.Drawing.Point(562, 18)
        Me.ConfCarpetaButton.Name = "ConfCarpetaButton"
        Me.ConfCarpetaButton.Size = New System.Drawing.Size(62, 23)
        Me.ConfCarpetaButton.TabIndex = 0
        Me.ConfCarpetaButton.Text = "Buscar"
        '
        'RadGroupBox2
        '
        Me.RadGroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.RadGroupBox2.Controls.Add(Me.RadLabel1)
        Me.RadGroupBox2.Controls.Add(Me.ConfCarpetaButton)
        Me.RadGroupBox2.Controls.Add(Me.CarpetaComTextBox)
        Me.RadGroupBox2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RadGroupBox2.FooterImageIndex = -1
        Me.RadGroupBox2.FooterImageKey = ""
        Me.RadGroupBox2.FooterTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox2.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        Me.RadGroupBox2.HeaderImageIndex = -1
        Me.RadGroupBox2.HeaderImageKey = ""
        Me.RadGroupBox2.HeaderMargin = New System.Windows.Forms.Padding(0)
        Me.RadGroupBox2.HeaderText = "Carpeta de Imágenes en el sistema"
        Me.RadGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadGroupBox2.Location = New System.Drawing.Point(7, 547)
        Me.RadGroupBox2.Name = "RadGroupBox2"
        Me.RadGroupBox2.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        '
        '
        '
        Me.RadGroupBox2.RootElement.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
        Me.RadGroupBox2.Size = New System.Drawing.Size(691, 49)
        Me.RadGroupBox2.TabIndex = 394
        Me.RadGroupBox2.Text = "Carpeta de Imágenes en el sistema"
        Me.RadGroupBox2.ThemeName = "Breeze"
        CType(Me.RadGroupBox2.GetChildAt(0), Telerik.WinControls.UI.RadGroupBoxElement).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor2 = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor3 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor4 = System.Drawing.Color.Gainsboro
        CType(Me.RadGroupBox2.GetChildAt(0).GetChildAt(0).GetChildAt(0), Telerik.WinControls.Primitives.FillPrimitive).BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel2.Controls.Add(Me.pbxCancelar)
        Me.Panel2.Controls.Add(Me.pbxGuardar)
        Me.Panel2.Location = New System.Drawing.Point(-1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(713, 41)
        Me.Panel2.TabIndex = 402
        '
        'pbxCancelar
        '
        Me.pbxCancelar.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SaveCancel
        Me.pbxCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxCancelar.InitialImage = Nothing
        Me.pbxCancelar.Location = New System.Drawing.Point(49, 3)
        Me.pbxCancelar.Name = "pbxCancelar"
        Me.pbxCancelar.Size = New System.Drawing.Size(35, 33)
        Me.pbxCancelar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxCancelar.TabIndex = 7
        Me.pbxCancelar.TabStop = False
        '
        'pbxGuardar
        '
        Me.pbxGuardar.BackgroundImage = Global.ContaExpress.My.Resources.Resources.Save
        Me.pbxGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxGuardar.InitialImage = Nothing
        Me.pbxGuardar.Location = New System.Drawing.Point(11, 3)
        Me.pbxGuardar.Name = "pbxGuardar"
        Me.pbxGuardar.Size = New System.Drawing.Size(35, 33)
        Me.pbxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxGuardar.TabIndex = 6
        Me.pbxGuardar.TabStop = False
        '
        'EMPRESATableAdapter
        '
        Me.EMPRESATableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AUDITORIAMOVIMIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.AUDITORIATABLASTableAdapter = Me.AUDITORIATABLASTableAdapter
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
        Me.TableAdapterManager.EMPRESATableAdapter = Me.EMPRESATableAdapter
        Me.TableAdapterManager.EMPRESATRANSPORTETableAdapter = Nothing
        Me.TableAdapterManager.ENCARGADOTableAdapter = Nothing
        Me.TableAdapterManager.INSTRUMENTOTableAdapter = Nothing
        Me.TableAdapterManager.MONEDASINFILTROTableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
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
        'AUDITORIATABLASTableAdapter
        '
        Me.AUDITORIATABLASTableAdapter.ClearBeforeFill = True
        '
        'AUDITORIATABLASBindingSource
        '
        Me.AUDITORIATABLASBindingSource.DataMember = "AUDITORIATABLAS"
        Me.AUDITORIATABLASBindingSource.DataSource = Me.DsFacturacion
        '
        'EMPRESATableAdapter1
        '
        Me.EMPRESATableAdapter1.ClearBeforeFill = True
        '
        'ABMEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GhostWhite
        Me.ClientSize = New System.Drawing.Size(707, 601)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.RadGroupBox2)
        Me.Controls.Add(Me.RadGroupBox1)
        Me.Controls.Add(Me.RadGroupBox8)
        Me.Controls.Add(Me.txtCodEmpresa)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grdBuscador)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(713, 594)
        Me.Name = "ABMEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de la Empresa | Cogent SIG"
        CType(Me.grdBuscador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EMPRESABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsFacturacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox8.ResumeLayout(False)
        Me.RadGroupBox8.PerformLayout()
        CType(Me.txtCodGNU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadPanel2.ResumeLayout(False)
        CType(Me.PictureBoxLogotipo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomFantasia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox1.ResumeLayout(False)
        Me.RadGroupBox1.PerformLayout()
        CType(Me.Empresa2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkRetentor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNroRegistro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRUCRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumRegPatronal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRUCContribuyente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNomContribuyente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CarpetaComTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConfCarpetaButton, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadGroupBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RadGroupBox2.ResumeLayout(False)
        Me.RadGroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pbxCancelar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxGuardar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AUDITORIATABLASBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbExportador As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents umePorcRetRenta As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Empresa2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsEmpresa As ContaExpress.DsEmpresa
    Friend WithEvents EMPRESATableAdapter1 As ContaExpress.DsEmpresaTableAdapters.EMPRESATableAdapter
    Friend WithEvents txtCodGNU As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

    #End Region 'Methods

End Class