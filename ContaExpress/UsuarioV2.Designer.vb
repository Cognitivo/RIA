<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsuarioV2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UsuarioV2))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlUsuario = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.chbxVendedor = New System.Windows.Forms.CheckBox()
        Me.pbxWallpaper = New System.Windows.Forms.PictureBox()
        Me.USUARIOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsUsuario = New ContaExpress.DsUsuario()
        Me.cbxSupervisor = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblContraseña = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblCI = New System.Windows.Forms.Label()
        Me.tbxEmail = New System.Windows.Forms.TextBox()
        Me.tbxRepContraseña = New System.Windows.Forms.TextBox()
        Me.tbxContraseña = New System.Windows.Forms.TextBox()
        Me.tbxNomUsuario = New System.Windows.Forms.TextBox()
        Me.tbxCIUsuario = New System.Windows.Forms.TextBox()
        Me.pnlSupervisor = New System.Windows.Forms.GroupBox()
        Me.btnImprimirCodigo = New System.Windows.Forms.Button()
        Me.txtCodigoSupervisor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGenerarCodigo = New System.Windows.Forms.Button()
        Me.pnlAccesos = New System.Windows.Forms.Panel()
        Me.cbxPermisos = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbxBuscarPermiso = New System.Windows.Forms.TextBox()
        Me.dgvPermisoUsuario = New System.Windows.Forms.DataGridView()
        Me.PermisoUsuarioBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pbxPersonalizacion = New System.Windows.Forms.PictureBox()
        Me.pbxAccesso = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.btnNuevo = New System.Windows.Forms.PictureBox()
        Me.pbxDatosUsuario = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.tbxBuscar = New System.Windows.Forms.TextBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.CODUSUARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODSUPERVISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SUPERVISOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODEMPRESADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBREDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CEDULADataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODGRUPODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PASSUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAILDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESUSUARIODataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FONDO = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ESTADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pbxLink = New System.Windows.Forms.PictureBox()
        Me.tbxUsuarios = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.DESUSUARIODataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USUARIOTableAdapter = New ContaExpress.DsUsuarioTableAdapters.USUARIOTableAdapter()
        Me.PermisoUsuarioTableAdapter = New ContaExpress.DsUsuarioTableAdapters.PermisoUsuarioTableAdapter()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.pnlPersonalizacion = New System.Windows.Forms.Panel()
        Me.pnlVistaPrevia = New System.Windows.Forms.Panel()
        Me.pbxVistaPrevia = New System.Windows.Forms.PictureBox()
        Me.tbxNombreImagen = New System.Windows.Forms.TextBox()
        Me.btnGuardarFondo = New System.Windows.Forms.Button()
        Me.btnSubirFondo = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnVistaPrevia = New System.Windows.Forms.Button()
        Me.rbtRepetirFondo = New System.Windows.Forms.RadioButton()
        Me.rbtEstirarImagen = New System.Windows.Forms.RadioButton()
        Me.lblNombreImagen = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvPersonalizacion = New System.Windows.Forms.DataGridView()
        Me.CODIMAGEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESCRIPCION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMAGEN = New System.Windows.Forms.DataGridViewImageColumn()
        Me.USUARIOFONDOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.USUARIOFONDOTableAdapter = New ContaExpress.DsUsuarioTableAdapters.USUARIOFONDOTableAdapter()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MODULO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PreguntaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Permisoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ver = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlUsuario.SuspendLayout()
        CType(Me.pbxWallpaper, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSupervisor.SuspendLayout()
        Me.pnlAccesos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPermisoUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PermisoUsuarioBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pbxPersonalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAccesso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxDatosUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPersonalizacion.SuspendLayout()
        Me.pnlVistaPrevia.SuspendLayout()
        CType(Me.pbxVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPersonalizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.USUARIOFONDOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlUsuario
        '
        Me.pnlUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlUsuario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlUsuario.BackColor = System.Drawing.Color.LightGray
        Me.pnlUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUsuario.Controls.Add(Me.Label7)
        Me.pnlUsuario.Controls.Add(Me.cmbEstado)
        Me.pnlUsuario.Controls.Add(Me.chbxVendedor)
        Me.pnlUsuario.Controls.Add(Me.pbxWallpaper)
        Me.pnlUsuario.Controls.Add(Me.cbxSupervisor)
        Me.pnlUsuario.Controls.Add(Me.Label2)
        Me.pnlUsuario.Controls.Add(Me.lblemail)
        Me.pnlUsuario.Controls.Add(Me.Label1)
        Me.pnlUsuario.Controls.Add(Me.lblContraseña)
        Me.pnlUsuario.Controls.Add(Me.lblUsuario)
        Me.pnlUsuario.Controls.Add(Me.lblCI)
        Me.pnlUsuario.Controls.Add(Me.tbxEmail)
        Me.pnlUsuario.Controls.Add(Me.tbxRepContraseña)
        Me.pnlUsuario.Controls.Add(Me.tbxContraseña)
        Me.pnlUsuario.Controls.Add(Me.tbxNomUsuario)
        Me.pnlUsuario.Controls.Add(Me.tbxCIUsuario)
        Me.pnlUsuario.Controls.Add(Me.pnlSupervisor)
        Me.pnlUsuario.Location = New System.Drawing.Point(222, 102)
        Me.pnlUsuario.Name = "pnlUsuario"
        Me.pnlUsuario.Size = New System.Drawing.Size(549, 521)
        Me.pnlUsuario.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(89, 211)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 16)
        Me.Label7.TabIndex = 493
        Me.Label7.Text = "Estado:"
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.BackColor = System.Drawing.Color.White
        Me.cmbEstado.CausesValidation = False
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstado.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Items.AddRange(New Object() {"Inactivo", "Activo"})
        Me.cmbEstado.Location = New System.Drawing.Point(144, 207)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(330, 25)
        Me.cmbEstado.TabIndex = 492
        '
        'chbxVendedor
        '
        Me.chbxVendedor.AutoSize = True
        Me.chbxVendedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.chbxVendedor.Location = New System.Drawing.Point(275, 242)
        Me.chbxVendedor.Name = "chbxVendedor"
        Me.chbxVendedor.Size = New System.Drawing.Size(128, 21)
        Me.chbxVendedor.TabIndex = 309
        Me.chbxVendedor.Text = "Crear Vendedor"
        Me.chbxVendedor.UseVisualStyleBackColor = True
        '
        'pbxWallpaper
        '
        Me.pbxWallpaper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxWallpaper.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.USUARIOBindingSource, "Fondo", True))
        Me.pbxWallpaper.Location = New System.Drawing.Point(70, 363)
        Me.pbxWallpaper.Name = "pbxWallpaper"
        Me.pbxWallpaper.Size = New System.Drawing.Size(399, 149)
        Me.pbxWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxWallpaper.TabIndex = 308
        Me.pbxWallpaper.TabStop = False
        '
        'USUARIOBindingSource
        '
        Me.USUARIOBindingSource.DataMember = "USUARIO"
        Me.USUARIOBindingSource.DataSource = Me.DsUsuario
        '
        'DsUsuario
        '
        Me.DsUsuario.DataSetName = "DsUsuario"
        Me.DsUsuario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxSupervisor
        '
        Me.cbxSupervisor.AutoSize = True
        Me.cbxSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.cbxSupervisor.Location = New System.Drawing.Point(144, 242)
        Me.cbxSupervisor.Name = "cbxSupervisor"
        Me.cbxSupervisor.Size = New System.Drawing.Size(107, 21)
        Me.cbxSupervisor.TabIndex = 16
        Me.cbxSupervisor.Text = "Supervisor/a"
        Me.cbxSupervisor.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 28)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Datos del Usuario"
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.Location = New System.Drawing.Point(93, 181)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(49, 16)
        Me.lblemail.TabIndex = 9
        Me.lblemail.Text = "E-mail:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Repetir Contraseña:"
        '
        'lblContraseña
        '
        Me.lblContraseña.AutoSize = True
        Me.lblContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContraseña.Location = New System.Drawing.Point(62, 115)
        Me.lblContraseña.Name = "lblContraseña"
        Me.lblContraseña.Size = New System.Drawing.Size(80, 16)
        Me.lblContraseña.TabIndex = 7
        Me.lblContraseña.Text = "Contraseña:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(84, 82)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(58, 16)
        Me.lblUsuario.TabIndex = 6
        Me.lblUsuario.Text = "Usuario:"
        '
        'lblCI
        '
        Me.lblCI.AutoSize = True
        Me.lblCI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCI.Location = New System.Drawing.Point(113, 48)
        Me.lblCI.Name = "lblCI"
        Me.lblCI.Size = New System.Drawing.Size(29, 16)
        Me.lblCI.TabIndex = 5
        Me.lblCI.Text = "C.I.:"
        '
        'tbxEmail
        '
        Me.tbxEmail.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxEmail.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "EMAIL", True))
        Me.tbxEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxEmail.Location = New System.Drawing.Point(144, 173)
        Me.tbxEmail.Name = "tbxEmail"
        Me.tbxEmail.Size = New System.Drawing.Size(325, 27)
        Me.tbxEmail.TabIndex = 15
        '
        'tbxRepContraseña
        '
        Me.tbxRepContraseña.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxRepContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRepContraseña.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "PASSUSUARIO", True))
        Me.tbxRepContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxRepContraseña.Location = New System.Drawing.Point(144, 140)
        Me.tbxRepContraseña.Name = "tbxRepContraseña"
        Me.tbxRepContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.tbxRepContraseña.Size = New System.Drawing.Size(325, 27)
        Me.tbxRepContraseña.TabIndex = 14
        '
        'tbxContraseña
        '
        Me.tbxContraseña.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxContraseña.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "PASSUSUARIO", True))
        Me.tbxContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxContraseña.Location = New System.Drawing.Point(144, 107)
        Me.tbxContraseña.Name = "tbxContraseña"
        Me.tbxContraseña.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.tbxContraseña.Size = New System.Drawing.Size(325, 27)
        Me.tbxContraseña.TabIndex = 13
        '
        'tbxNomUsuario
        '
        Me.tbxNomUsuario.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxNomUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNomUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "DESUSUARIO", True))
        Me.tbxNomUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxNomUsuario.Location = New System.Drawing.Point(144, 74)
        Me.tbxNomUsuario.Name = "tbxNomUsuario"
        Me.tbxNomUsuario.Size = New System.Drawing.Size(325, 27)
        Me.tbxNomUsuario.TabIndex = 12
        '
        'tbxCIUsuario
        '
        Me.tbxCIUsuario.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxCIUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCIUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "CEDULA", True))
        Me.tbxCIUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.tbxCIUsuario.Location = New System.Drawing.Point(144, 40)
        Me.tbxCIUsuario.Name = "tbxCIUsuario"
        Me.tbxCIUsuario.Size = New System.Drawing.Size(325, 27)
        Me.tbxCIUsuario.TabIndex = 11
        '
        'pnlSupervisor
        '
        Me.pnlSupervisor.BackColor = System.Drawing.Color.LightGray
        Me.pnlSupervisor.Controls.Add(Me.btnImprimirCodigo)
        Me.pnlSupervisor.Controls.Add(Me.txtCodigoSupervisor)
        Me.pnlSupervisor.Controls.Add(Me.Label3)
        Me.pnlSupervisor.Controls.Add(Me.btnGenerarCodigo)
        Me.pnlSupervisor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pnlSupervisor.Location = New System.Drawing.Point(70, 262)
        Me.pnlSupervisor.Name = "pnlSupervisor"
        Me.pnlSupervisor.Size = New System.Drawing.Size(399, 95)
        Me.pnlSupervisor.TabIndex = 307
        Me.pnlSupervisor.TabStop = False
        Me.pnlSupervisor.Text = "Supervisor"
        '
        'btnImprimirCodigo
        '
        Me.btnImprimirCodigo.BackColor = System.Drawing.Color.DimGray
        Me.btnImprimirCodigo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImprimirCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnImprimirCodigo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnImprimirCodigo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimirCodigo.Location = New System.Drawing.Point(74, 50)
        Me.btnImprimirCodigo.Name = "btnImprimirCodigo"
        Me.btnImprimirCodigo.Size = New System.Drawing.Size(250, 35)
        Me.btnImprimirCodigo.TabIndex = 19
        Me.btnImprimirCodigo.Text = "Imprimir"
        Me.btnImprimirCodigo.UseVisualStyleBackColor = False
        '
        'txtCodigoSupervisor
        '
        Me.txtCodigoSupervisor.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtCodigoSupervisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigoSupervisor.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "CODSUPERVISOR", True))
        Me.txtCodigoSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.txtCodigoSupervisor.Location = New System.Drawing.Point(74, 17)
        Me.txtCodigoSupervisor.Name = "txtCodigoSupervisor"
        Me.txtCodigoSupervisor.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.txtCodigoSupervisor.Size = New System.Drawing.Size(154, 27)
        Me.txtCodigoSupervisor.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Código:"
        '
        'btnGenerarCodigo
        '
        Me.btnGenerarCodigo.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnGenerarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerarCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.btnGenerarCodigo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnGenerarCodigo.Location = New System.Drawing.Point(234, 17)
        Me.btnGenerarCodigo.Name = "btnGenerarCodigo"
        Me.btnGenerarCodigo.Size = New System.Drawing.Size(90, 27)
        Me.btnGenerarCodigo.TabIndex = 18
        Me.btnGenerarCodigo.Text = "Generar"
        Me.btnGenerarCodigo.UseVisualStyleBackColor = False
        '
        'pnlAccesos
        '
        Me.pnlAccesos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlAccesos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlAccesos.BackColor = System.Drawing.Color.LightGray
        Me.pnlAccesos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAccesos.Controls.Add(Me.cbxPermisos)
        Me.pnlAccesos.Controls.Add(Me.PictureBox1)
        Me.pnlAccesos.Controls.Add(Me.tbxBuscarPermiso)
        Me.pnlAccesos.Controls.Add(Me.dgvPermisoUsuario)
        Me.pnlAccesos.Controls.Add(Me.Label22)
        Me.pnlAccesos.Location = New System.Drawing.Point(222, 102)
        Me.pnlAccesos.Name = "pnlAccesos"
        Me.pnlAccesos.Size = New System.Drawing.Size(549, 521)
        Me.pnlAccesos.TabIndex = 1
        '
        'cbxPermisos
        '
        Me.cbxPermisos.AutoSize = True
        Me.cbxPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxPermisos.Location = New System.Drawing.Point(286, 8)
        Me.cbxPermisos.Name = "cbxPermisos"
        Me.cbxPermisos.Size = New System.Drawing.Size(89, 17)
        Me.cbxPermisos.TabIndex = 30
        Me.cbxPermisos.Text = "Marcar Todos"
        Me.cbxPermisos.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(381, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(22, 22)
        Me.PictureBox1.TabIndex = 457
        Me.PictureBox1.TabStop = False
        '
        'tbxBuscarPermiso
        '
        Me.tbxBuscarPermiso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxBuscarPermiso.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxBuscarPermiso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscarPermiso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscarPermiso.Location = New System.Drawing.Point(402, 5)
        Me.tbxBuscarPermiso.Name = "tbxBuscarPermiso"
        Me.tbxBuscarPermiso.Size = New System.Drawing.Size(140, 22)
        Me.tbxBuscarPermiso.TabIndex = 6
        '
        'dgvPermisoUsuario
        '
        Me.dgvPermisoUsuario.AllowUserToAddRows = False
        Me.dgvPermisoUsuario.AllowUserToDeleteRows = False
        Me.dgvPermisoUsuario.AllowUserToResizeColumns = False
        Me.dgvPermisoUsuario.AllowUserToResizeRows = False
        Me.dgvPermisoUsuario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPermisoUsuario.AutoGenerateColumns = False
        Me.dgvPermisoUsuario.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvPermisoUsuario.ColumnHeadersHeight = 35
        Me.dgvPermisoUsuario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MODULO, Me.PreguntaDataGridViewTextBoxColumn, Me.Permisoid, Me.Ver})
        Me.dgvPermisoUsuario.DataSource = Me.PermisoUsuarioBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPermisoUsuario.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPermisoUsuario.Location = New System.Drawing.Point(4, 33)
        Me.dgvPermisoUsuario.Name = "dgvPermisoUsuario"
        Me.dgvPermisoUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvPermisoUsuario.RowHeadersVisible = False
        Me.dgvPermisoUsuario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPermisoUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPermisoUsuario.Size = New System.Drawing.Size(539, 481)
        Me.dgvPermisoUsuario.TabIndex = 1
        Me.dgvPermisoUsuario.TabStop = False
        '
        'PermisoUsuarioBindingSource
        '
        Me.PermisoUsuarioBindingSource.DataMember = "PermisoUsuario"
        Me.PermisoUsuarioBindingSource.DataSource = Me.DsUsuario
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label22.Location = New System.Drawing.Point(2, 2)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(94, 28)
        Me.Label22.TabIndex = 4
        Me.Label22.Text = "Permisos"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel2.BackColor = System.Drawing.Color.Tan
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.Controls.Add(Me.pbxPersonalizacion)
        Me.Panel2.Controls.Add(Me.pbxAccesso)
        Me.Panel2.Controls.Add(Me.EliminarPictureBox)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Controls.Add(Me.pbxDatosUsuario)
        Me.Panel2.Controls.Add(Me.CancelarPictureBox)
        Me.Panel2.Controls.Add(Me.ModificarPictureBox)
        Me.Panel2.Controls.Add(Me.GuardarPictureBox)
        Me.Panel2.Controls.Add(Me.PictureBox8)
        Me.Panel2.Controls.Add(Me.tbxBuscar)
        Me.Panel2.Location = New System.Drawing.Point(-1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(785, 40)
        Me.Panel2.TabIndex = 1
        '
        'pbxPersonalizacion
        '
        Me.pbxPersonalizacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxPersonalizacion.BackColor = System.Drawing.Color.Transparent
        Me.pbxPersonalizacion.Image = CType(resources.GetObject("pbxPersonalizacion.Image"), System.Drawing.Image)
        Me.pbxPersonalizacion.Location = New System.Drawing.Point(745, 2)
        Me.pbxPersonalizacion.Name = "pbxPersonalizacion"
        Me.pbxPersonalizacion.Size = New System.Drawing.Size(35, 35)
        Me.pbxPersonalizacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxPersonalizacion.TabIndex = 462
        Me.pbxPersonalizacion.TabStop = False
        '
        'pbxAccesso
        '
        Me.pbxAccesso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxAccesso.BackColor = System.Drawing.Color.Transparent
        Me.pbxAccesso.Image = CType(resources.GetObject("pbxAccesso.Image"), System.Drawing.Image)
        Me.pbxAccesso.Location = New System.Drawing.Point(708, 2)
        Me.pbxAccesso.Name = "pbxAccesso"
        Me.pbxAccesso.Size = New System.Drawing.Size(35, 35)
        Me.pbxAccesso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAccesso.TabIndex = 462
        Me.pbxAccesso.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = CType(resources.GetObject("EliminarPictureBox.Image"), System.Drawing.Image)
        Me.EliminarPictureBox.Location = New System.Drawing.Point(259, 2)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 458
        Me.EliminarPictureBox.TabStop = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.Transparent
        Me.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNuevo.Enabled = False
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(223, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(35, 35)
        Me.btnNuevo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnNuevo.TabIndex = 457
        Me.btnNuevo.TabStop = False
        '
        'pbxDatosUsuario
        '
        Me.pbxDatosUsuario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxDatosUsuario.BackColor = System.Drawing.Color.Transparent
        Me.pbxDatosUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxDatosUsuario.Image = CType(resources.GetObject("pbxDatosUsuario.Image"), System.Drawing.Image)
        Me.pbxDatosUsuario.Location = New System.Drawing.Point(671, 2)
        Me.pbxDatosUsuario.Name = "pbxDatosUsuario"
        Me.pbxDatosUsuario.Size = New System.Drawing.Size(35, 35)
        Me.pbxDatosUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxDatosUsuario.TabIndex = 461
        Me.pbxDatosUsuario.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Enabled = False
        Me.CancelarPictureBox.Image = CType(resources.GetObject("CancelarPictureBox.Image"), System.Drawing.Image)
        Me.CancelarPictureBox.Location = New System.Drawing.Point(370, 2)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 461
        Me.CancelarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = CType(resources.GetObject("ModificarPictureBox.Image"), System.Drawing.Image)
        Me.ModificarPictureBox.Location = New System.Drawing.Point(296, 2)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 459
        Me.ModificarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Enabled = False
        Me.GuardarPictureBox.Image = CType(resources.GetObject("GuardarPictureBox.Image"), System.Drawing.Image)
        Me.GuardarPictureBox.Location = New System.Drawing.Point(333, 2)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(35, 35)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 460
        Me.GuardarPictureBox.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = CType(resources.GetObject("PictureBox8.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Location = New System.Drawing.Point(4, 5)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 456
        Me.PictureBox8.TabStop = False
        '
        'tbxBuscar
        '
        Me.tbxBuscar.BackColor = System.Drawing.Color.Tan
        Me.tbxBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxBuscar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.tbxBuscar.Location = New System.Drawing.Point(32, 5)
        Me.tbxBuscar.Name = "tbxBuscar"
        Me.tbxBuscar.Size = New System.Drawing.Size(182, 30)
        Me.tbxBuscar.TabIndex = 455
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToAddRows = False
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.AllowUserToResizeColumns = False
        Me.dgvUsuarios.AllowUserToResizeRows = False
        Me.dgvUsuarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvUsuarios.AutoGenerateColumns = False
        Me.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsuarios.BackgroundColor = System.Drawing.Color.Lavender
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUsuarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvUsuarios.ColumnHeadersHeight = 35
        Me.dgvUsuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODUSUARIO, Me.CODSUPERVISOR, Me.SUPERVISOR, Me.CODEMPRESADataGridViewTextBoxColumn, Me.NOMBREDataGridViewTextBoxColumn, Me.DataGridViewTextBoxColumn2, Me.CEDULADataGridViewTextBoxColumn, Me.CODGRUPODataGridViewTextBoxColumn, Me.PASSUSUARIODataGridViewTextBoxColumn, Me.EMAILDataGridViewTextBoxColumn, Me.DESUSUARIODataGridViewTextBoxColumn, Me.FONDO, Me.ESTADO})
        Me.dgvUsuarios.DataSource = Me.USUARIOBindingSource
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUsuarios.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvUsuarios.Location = New System.Drawing.Point(0, 40)
        Me.dgvUsuarios.MultiSelect = False
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersVisible = False
        Me.dgvUsuarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(213, 583)
        Me.dgvUsuarios.TabIndex = 2
        '
        'CODUSUARIO
        '
        Me.CODUSUARIO.DataPropertyName = "CODUSUARIO"
        Me.CODUSUARIO.HeaderText = "CODUSUARIO"
        Me.CODUSUARIO.Name = "CODUSUARIO"
        Me.CODUSUARIO.ReadOnly = True
        Me.CODUSUARIO.Visible = False
        '
        'CODSUPERVISOR
        '
        Me.CODSUPERVISOR.DataPropertyName = "CODSUPERVISOR"
        Me.CODSUPERVISOR.HeaderText = "CODSUPERVISOR"
        Me.CODSUPERVISOR.Name = "CODSUPERVISOR"
        Me.CODSUPERVISOR.ReadOnly = True
        Me.CODSUPERVISOR.Visible = False
        '
        'SUPERVISOR
        '
        Me.SUPERVISOR.DataPropertyName = "SUPERVISOR"
        Me.SUPERVISOR.HeaderText = "SUPERVISOR"
        Me.SUPERVISOR.Name = "SUPERVISOR"
        Me.SUPERVISOR.ReadOnly = True
        Me.SUPERVISOR.Visible = False
        '
        'CODEMPRESADataGridViewTextBoxColumn
        '
        Me.CODEMPRESADataGridViewTextBoxColumn.DataPropertyName = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.HeaderText = "CODEMPRESA"
        Me.CODEMPRESADataGridViewTextBoxColumn.Name = "CODEMPRESADataGridViewTextBoxColumn"
        Me.CODEMPRESADataGridViewTextBoxColumn.ReadOnly = True
        Me.CODEMPRESADataGridViewTextBoxColumn.Visible = False
        '
        'NOMBREDataGridViewTextBoxColumn
        '
        Me.NOMBREDataGridViewTextBoxColumn.DataPropertyName = "NOMBRE"
        Me.NOMBREDataGridViewTextBoxColumn.HeaderText = "Lista de Usuario"
        Me.NOMBREDataGridViewTextBoxColumn.Name = "NOMBREDataGridViewTextBoxColumn"
        Me.NOMBREDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FECHANAC"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FECHANAC"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'CEDULADataGridViewTextBoxColumn
        '
        Me.CEDULADataGridViewTextBoxColumn.DataPropertyName = "CEDULA"
        Me.CEDULADataGridViewTextBoxColumn.HeaderText = "CEDULA"
        Me.CEDULADataGridViewTextBoxColumn.Name = "CEDULADataGridViewTextBoxColumn"
        Me.CEDULADataGridViewTextBoxColumn.ReadOnly = True
        Me.CEDULADataGridViewTextBoxColumn.Visible = False
        '
        'CODGRUPODataGridViewTextBoxColumn
        '
        Me.CODGRUPODataGridViewTextBoxColumn.DataPropertyName = "CODGRUPO"
        Me.CODGRUPODataGridViewTextBoxColumn.HeaderText = "CODGRUPO"
        Me.CODGRUPODataGridViewTextBoxColumn.Name = "CODGRUPODataGridViewTextBoxColumn"
        Me.CODGRUPODataGridViewTextBoxColumn.ReadOnly = True
        Me.CODGRUPODataGridViewTextBoxColumn.Visible = False
        '
        'PASSUSUARIODataGridViewTextBoxColumn
        '
        Me.PASSUSUARIODataGridViewTextBoxColumn.DataPropertyName = "PASSUSUARIO"
        Me.PASSUSUARIODataGridViewTextBoxColumn.HeaderText = "PASSUSUARIO"
        Me.PASSUSUARIODataGridViewTextBoxColumn.Name = "PASSUSUARIODataGridViewTextBoxColumn"
        Me.PASSUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.PASSUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'EMAILDataGridViewTextBoxColumn
        '
        Me.EMAILDataGridViewTextBoxColumn.DataPropertyName = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.HeaderText = "EMAIL"
        Me.EMAILDataGridViewTextBoxColumn.Name = "EMAILDataGridViewTextBoxColumn"
        Me.EMAILDataGridViewTextBoxColumn.ReadOnly = True
        Me.EMAILDataGridViewTextBoxColumn.Visible = False
        '
        'DESUSUARIODataGridViewTextBoxColumn
        '
        Me.DESUSUARIODataGridViewTextBoxColumn.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIODataGridViewTextBoxColumn.HeaderText = "DESUSUARIO"
        Me.DESUSUARIODataGridViewTextBoxColumn.Name = "DESUSUARIODataGridViewTextBoxColumn"
        Me.DESUSUARIODataGridViewTextBoxColumn.ReadOnly = True
        Me.DESUSUARIODataGridViewTextBoxColumn.Visible = False
        '
        'FONDO
        '
        Me.FONDO.DataPropertyName = "FONDO"
        Me.FONDO.HeaderText = "FONDO"
        Me.FONDO.Name = "FONDO"
        Me.FONDO.ReadOnly = True
        Me.FONDO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FONDO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FONDO.Visible = False
        '
        'ESTADO
        '
        Me.ESTADO.DataPropertyName = "ESTADO"
        Me.ESTADO.HeaderText = "ESTADO"
        Me.ESTADO.Name = "ESTADO"
        Me.ESTADO.ReadOnly = True
        Me.ESTADO.Visible = False
        '
        'pbxLink
        '
        Me.pbxLink.BackColor = System.Drawing.Color.Transparent
        Me.pbxLink.BackgroundImage = CType(resources.GetObject("pbxLink.BackgroundImage"), System.Drawing.Image)
        Me.pbxLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pbxLink.Location = New System.Drawing.Point(222, 66)
        Me.pbxLink.Name = "pbxLink"
        Me.pbxLink.Size = New System.Drawing.Size(79, 30)
        Me.pbxLink.TabIndex = 5
        Me.pbxLink.TabStop = False
        '
        'tbxUsuarios
        '
        Me.tbxUsuarios.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tbxUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxUsuarios.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "NOMBRE", True))
        Me.tbxUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.tbxUsuarios.Location = New System.Drawing.Point(306, 66)
        Me.tbxUsuarios.Name = "tbxUsuarios"
        Me.tbxUsuarios.Size = New System.Drawing.Size(465, 30)
        Me.tbxUsuarios.TabIndex = 10
        '
        'lblNombre
        '
        Me.lblNombre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "NOMBRE", True))
        Me.lblNombre.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(304, 60)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(467, 41)
        Me.lblNombre.TabIndex = 29
        Me.lblNombre.Text = "lblNombre"
        '
        'DESUSUARIODataGridViewTextBoxColumn1
        '
        Me.DESUSUARIODataGridViewTextBoxColumn1.DataPropertyName = "DESUSUARIO"
        Me.DESUSUARIODataGridViewTextBoxColumn1.HeaderText = "DESUSUARIO"
        Me.DESUSUARIODataGridViewTextBoxColumn1.Name = "DESUSUARIODataGridViewTextBoxColumn1"
        Me.DESUSUARIODataGridViewTextBoxColumn1.Visible = False
        '
        'USUARIOTableAdapter
        '
        Me.USUARIOTableAdapter.ClearBeforeFill = True
        '
        'PermisoUsuarioTableAdapter
        '
        Me.PermisoUsuarioTableAdapter.ClearBeforeFill = True
        '
        'txtUsuario
        '
        Me.txtUsuario.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.USUARIOBindingSource, "CODUSUARIO", True))
        Me.txtUsuario.Location = New System.Drawing.Point(266, 71)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(22, 20)
        Me.txtUsuario.TabIndex = 16
        '
        'pnlPersonalizacion
        '
        Me.pnlPersonalizacion.BackColor = System.Drawing.Color.LightGray
        Me.pnlPersonalizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPersonalizacion.Controls.Add(Me.pnlVistaPrevia)
        Me.pnlPersonalizacion.Controls.Add(Me.btnSubirFondo)
        Me.pnlPersonalizacion.Controls.Add(Me.GroupBox1)
        Me.pnlPersonalizacion.Controls.Add(Me.Label4)
        Me.pnlPersonalizacion.Controls.Add(Me.dgvPersonalizacion)
        Me.pnlPersonalizacion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPersonalizacion.Location = New System.Drawing.Point(222, 102)
        Me.pnlPersonalizacion.Name = "pnlPersonalizacion"
        Me.pnlPersonalizacion.Size = New System.Drawing.Size(549, 521)
        Me.pnlPersonalizacion.TabIndex = 30
        '
        'pnlVistaPrevia
        '
        Me.pnlVistaPrevia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVistaPrevia.BackColor = System.Drawing.Color.LightSlateGray
        Me.pnlVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVistaPrevia.Controls.Add(Me.pbxVistaPrevia)
        Me.pnlVistaPrevia.Controls.Add(Me.tbxNombreImagen)
        Me.pnlVistaPrevia.Controls.Add(Me.btnGuardarFondo)
        Me.pnlVistaPrevia.Location = New System.Drawing.Point(189, -1)
        Me.pnlVistaPrevia.Name = "pnlVistaPrevia"
        Me.pnlVistaPrevia.Size = New System.Drawing.Size(359, 264)
        Me.pnlVistaPrevia.TabIndex = 14
        Me.pnlVistaPrevia.Visible = False
        '
        'pbxVistaPrevia
        '
        Me.pbxVistaPrevia.BackColor = System.Drawing.Color.Gray
        Me.pbxVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbxVistaPrevia.Location = New System.Drawing.Point(3, 33)
        Me.pbxVistaPrevia.Name = "pbxVistaPrevia"
        Me.pbxVistaPrevia.Size = New System.Drawing.Size(349, 225)
        Me.pbxVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxVistaPrevia.TabIndex = 15
        Me.pbxVistaPrevia.TabStop = False
        '
        'tbxNombreImagen
        '
        Me.tbxNombreImagen.BackColor = System.Drawing.Color.LightGray
        Me.tbxNombreImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxNombreImagen.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNombreImagen.Location = New System.Drawing.Point(1, 1)
        Me.tbxNombreImagen.Name = "tbxNombreImagen"
        Me.tbxNombreImagen.Size = New System.Drawing.Size(246, 29)
        Me.tbxNombreImagen.TabIndex = 14
        '
        'btnGuardarFondo
        '
        Me.btnGuardarFondo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnGuardarFondo.Location = New System.Drawing.Point(253, 0)
        Me.btnGuardarFondo.Name = "btnGuardarFondo"
        Me.btnGuardarFondo.Size = New System.Drawing.Size(100, 30)
        Me.btnGuardarFondo.TabIndex = 13
        Me.btnGuardarFondo.Text = "Guardar"
        Me.btnGuardarFondo.UseVisualStyleBackColor = True
        '
        'btnSubirFondo
        '
        Me.btnSubirFondo.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSubirFondo.Location = New System.Drawing.Point(6, 31)
        Me.btnSubirFondo.Name = "btnSubirFondo"
        Me.btnSubirFondo.Size = New System.Drawing.Size(156, 25)
        Me.btnSubirFondo.TabIndex = 13
        Me.btnSubirFondo.Text = "Adjuntar Imagen >>"
        Me.btnSubirFondo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnVistaPrevia)
        Me.GroupBox1.Controls.Add(Me.rbtRepetirFondo)
        Me.GroupBox1.Controls.Add(Me.rbtEstirarImagen)
        Me.GroupBox1.Controls.Add(Me.lblNombreImagen)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 422)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(541, 91)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Personalizar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Visualizar:"
        '
        'btnVistaPrevia
        '
        Me.btnVistaPrevia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnVistaPrevia.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnVistaPrevia.Location = New System.Drawing.Point(403, 53)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(132, 33)
        Me.btnVistaPrevia.TabIndex = 2
        Me.btnVistaPrevia.Text = "Vista Previa"
        Me.btnVistaPrevia.UseVisualStyleBackColor = True
        '
        'rbtRepetirFondo
        '
        Me.rbtRepetirFondo.AutoSize = True
        Me.rbtRepetirFondo.Enabled = False
        Me.rbtRepetirFondo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtRepetirFondo.Location = New System.Drawing.Point(76, 64)
        Me.rbtRepetirFondo.Name = "rbtRepetirFondo"
        Me.rbtRepetirFondo.Size = New System.Drawing.Size(120, 21)
        Me.rbtRepetirFondo.TabIndex = 1
        Me.rbtRepetirFondo.Text = "Repetir Imagen"
        Me.rbtRepetirFondo.UseVisualStyleBackColor = True
        '
        'rbtEstirarImagen
        '
        Me.rbtEstirarImagen.AutoSize = True
        Me.rbtEstirarImagen.Checked = True
        Me.rbtEstirarImagen.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtEstirarImagen.Location = New System.Drawing.Point(76, 44)
        Me.rbtEstirarImagen.Name = "rbtEstirarImagen"
        Me.rbtEstirarImagen.Size = New System.Drawing.Size(115, 21)
        Me.rbtEstirarImagen.TabIndex = 1
        Me.rbtEstirarImagen.TabStop = True
        Me.rbtEstirarImagen.Text = "Estirar Imagen"
        Me.rbtEstirarImagen.UseVisualStyleBackColor = True
        '
        'lblNombreImagen
        '
        Me.lblNombreImagen.AutoSize = True
        Me.lblNombreImagen.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreImagen.Location = New System.Drawing.Point(74, 21)
        Me.lblNombreImagen.Name = "lblNombreImagen"
        Me.lblNombreImagen.Size = New System.Drawing.Size(181, 17)
        Me.lblNombreImagen.TabIndex = 0
        Me.lblNombreImagen.Text = "Elija un Fondo para Guardar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nombre:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Light", 15.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label4.Location = New System.Drawing.Point(2, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(156, 28)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Personalizacion"
        '
        'dgvPersonalizacion
        '
        Me.dgvPersonalizacion.AllowUserToAddRows = False
        Me.dgvPersonalizacion.AllowUserToDeleteRows = False
        Me.dgvPersonalizacion.AllowUserToResizeRows = False
        Me.dgvPersonalizacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPersonalizacion.AutoGenerateColumns = False
        Me.dgvPersonalizacion.BackgroundColor = System.Drawing.Color.Lavender
        Me.dgvPersonalizacion.ColumnHeadersHeight = 25
        Me.dgvPersonalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvPersonalizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CODIMAGEN, Me.DESCRIPCION, Me.IMAGEN})
        Me.dgvPersonalizacion.DataSource = Me.USUARIOFONDOBindingSource
        Me.dgvPersonalizacion.Location = New System.Drawing.Point(3, 60)
        Me.dgvPersonalizacion.Name = "dgvPersonalizacion"
        Me.dgvPersonalizacion.ReadOnly = True
        Me.dgvPersonalizacion.RowHeadersVisible = False
        Me.dgvPersonalizacion.RowTemplate.Height = 200
        Me.dgvPersonalizacion.Size = New System.Drawing.Size(540, 358)
        Me.dgvPersonalizacion.TabIndex = 0
        '
        'CODIMAGEN
        '
        Me.CODIMAGEN.DataPropertyName = "CODIMAGEN"
        Me.CODIMAGEN.HeaderText = "CODIMAGEN"
        Me.CODIMAGEN.Name = "CODIMAGEN"
        Me.CODIMAGEN.ReadOnly = True
        Me.CODIMAGEN.Visible = False
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.DataPropertyName = "DESCRIPCION"
        Me.DESCRIPCION.FillWeight = 48.42615!
        Me.DESCRIPCION.HeaderText = "Nombre"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.ReadOnly = True
        '
        'IMAGEN
        '
        Me.IMAGEN.DataPropertyName = "IMAGEN"
        Me.IMAGEN.FillWeight = 151.5739!
        Me.IMAGEN.HeaderText = "Fondo"
        Me.IMAGEN.Name = "IMAGEN"
        Me.IMAGEN.ReadOnly = True
        Me.IMAGEN.Width = 353
        '
        'USUARIOFONDOBindingSource
        '
        Me.USUARIOFONDOBindingSource.DataMember = "USUARIOFONDO"
        Me.USUARIOFONDOBindingSource.DataSource = Me.DsUsuario
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'USUARIOFONDOTableAdapter
        '
        Me.USUARIOFONDOTableAdapter.ClearBeforeFill = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Title = "Elija una Imagen"
        '
        'MODULO
        '
        Me.MODULO.DataPropertyName = "MODULO"
        Me.MODULO.Frozen = True
        Me.MODULO.HeaderText = "Modulo"
        Me.MODULO.Name = "MODULO"
        Me.MODULO.ReadOnly = True
        Me.MODULO.Width = 170
        '
        'PreguntaDataGridViewTextBoxColumn
        '
        Me.PreguntaDataGridViewTextBoxColumn.DataPropertyName = "Pregunta"
        Me.PreguntaDataGridViewTextBoxColumn.Frozen = True
        Me.PreguntaDataGridViewTextBoxColumn.HeaderText = "Prermiso"
        Me.PreguntaDataGridViewTextBoxColumn.Name = "PreguntaDataGridViewTextBoxColumn"
        Me.PreguntaDataGridViewTextBoxColumn.ReadOnly = True
        Me.PreguntaDataGridViewTextBoxColumn.Width = 300
        '
        'Permisoid
        '
        Me.Permisoid.DataPropertyName = "Permiso_id"
        Me.Permisoid.HeaderText = "Permiso_id"
        Me.Permisoid.Name = "Permisoid"
        Me.Permisoid.ReadOnly = True
        Me.Permisoid.Visible = False
        '
        'Ver
        '
        Me.Ver.HeaderText = "Habilitar"
        Me.Ver.Name = "Ver"
        Me.Ver.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Ver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Ver.Width = 50
        '
        'UsuarioV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(780, 623)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pbxLink)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.tbxUsuarios)
        Me.Controls.Add(Me.pnlUsuario)
        Me.Controls.Add(Me.pnlAccesos)
        Me.Controls.Add(Me.pnlPersonalizacion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "UsuarioV2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios | Cogent SIG"
        Me.pnlUsuario.ResumeLayout(False)
        Me.pnlUsuario.PerformLayout()
        CType(Me.pbxWallpaper, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSupervisor.ResumeLayout(False)
        Me.pnlSupervisor.PerformLayout()
        Me.pnlAccesos.ResumeLayout(False)
        Me.pnlAccesos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPermisoUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PermisoUsuarioBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.pbxPersonalizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAccesso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxDatosUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxLink, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPersonalizacion.ResumeLayout(False)
        Me.pnlPersonalizacion.PerformLayout()
        Me.pnlVistaPrevia.ResumeLayout(False)
        Me.pnlVistaPrevia.PerformLayout()
        CType(Me.pbxVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPersonalizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.USUARIOFONDOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlUsuario As System.Windows.Forms.Panel
    Friend WithEvents tbxEmail As System.Windows.Forms.TextBox
    Friend WithEvents tbxRepContraseña As System.Windows.Forms.TextBox
    Friend WithEvents tbxContraseña As System.Windows.Forms.TextBox
    Friend WithEvents tbxNomUsuario As System.Windows.Forms.TextBox
    Friend WithEvents tbxCIUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents pnlAccesos As System.Windows.Forms.Panel
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblCI As System.Windows.Forms.Label
    Friend WithEvents lblContraseña As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblemail As System.Windows.Forms.Label
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxBuscar As System.Windows.Forms.TextBox
    Friend WithEvents pbxLink As System.Windows.Forms.PictureBox
    Friend WithEvents tbxUsuarios As System.Windows.Forms.TextBox
    Friend WithEvents APELLIDODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONTACTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONOCONTACTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMAGENDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEXODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INICIOCOMPRASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INICIOVENTASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CELULARDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODCIUDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHANACDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMSISTEMASDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnNuevo As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lbDatosUser As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents UsuarioidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Permiso_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PermisoIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxBuscarPermiso As System.Windows.Forms.TextBox
    Public WithEvents dgvPermisoUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents DsUsuario As ContaExpress.DsUsuario
    Friend WithEvents USUARIOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USUARIOTableAdapter As ContaExpress.DsUsuarioTableAdapters.USUARIOTableAdapter
    Friend WithEvents PermisoUsuarioBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PermisoUsuarioTableAdapter As ContaExpress.DsUsuarioTableAdapters.PermisoUsuarioTableAdapter
    Friend WithEvents cbxPermisos As System.Windows.Forms.CheckBox
    Friend WithEvents pbxDatosUsuario As System.Windows.Forms.PictureBox
    Friend WithEvents pbxAccesso As System.Windows.Forms.PictureBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents cbxSupervisor As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSupervisor As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSupervisor As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimirCodigo As System.Windows.Forms.Button
    Friend WithEvents btnGenerarCodigo As System.Windows.Forms.Button
    Friend WithEvents pnlPersonalizacion As System.Windows.Forms.Panel
    Friend WithEvents dgvPersonalizacion As System.Windows.Forms.DataGridView
    Friend WithEvents pbxPersonalizacion As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pbxWallpaper As System.Windows.Forms.PictureBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents USUARIOFONDOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents USUARIOFONDOTableAdapter As ContaExpress.DsUsuarioTableAdapters.USUARIOFONDOTableAdapter
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombreImagen As System.Windows.Forms.Label
    Friend WithEvents btnVistaPrevia As System.Windows.Forms.Button
    Friend WithEvents rbtRepetirFondo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtEstirarImagen As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlVistaPrevia As System.Windows.Forms.Panel
    Friend WithEvents btnGuardarFondo As System.Windows.Forms.Button
    Friend WithEvents btnSubirFondo As System.Windows.Forms.Button
    Friend WithEvents tbxNombreImagen As System.Windows.Forms.TextBox
    Friend WithEvents pbxVistaPrevia As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents CODIMAGEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESCRIPCION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMAGEN As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents chbxVendedor As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents CODUSUARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODSUPERVISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SUPERVISOR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CEDULADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODGRUPODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PASSUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FONDO As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ESTADO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents MODULO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PreguntaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Permisoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ver As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
