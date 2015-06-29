<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMSmtp
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ABMSmtp))
        Me.SMTPRadGridView = New Telerik.WinControls.UI.RadGridView()
        Me.SMTPBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSMTP = New ContaExpress.DsSMTP()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.EditablePictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoGrisPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarGrisPictureBox = New System.Windows.Forms.PictureBox()
        Me.BloqueoPictureBox = New System.Windows.Forms.PictureBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarGrisPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.ServidorSMTPTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.PuertoTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.UsuarioTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PassTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ConfirmapassTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.ConfLabel = New System.Windows.Forms.Label()
        Me.CodSMTPTextBox = New System.Windows.Forms.TextBox()
        Me.SMTPTableAdapter = New ContaExpress.DsSMTPTableAdapters.SMTPTableAdapter()
        Me.BreezeTheme1 = New Telerik.WinControls.Themes.BreezeTheme()
        Me.RemitenteTextBox = New Telerik.WinControls.UI.RadTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.SMTPRadGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SMTPBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSMTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EditablePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoGrisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarGrisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BloqueoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarGrisPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServidorSMTPTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PuertoTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UsuarioTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PassTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConfirmapassTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RemitenteTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SMTPRadGridView
        '
        Me.SMTPRadGridView.BackColor = System.Drawing.SystemColors.Control
        Me.SMTPRadGridView.Cursor = System.Windows.Forms.Cursors.Default
        Me.SMTPRadGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.SMTPRadGridView.ForeColor = System.Drawing.SystemColors.ControlText
        Me.SMTPRadGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SMTPRadGridView.Location = New System.Drawing.Point(12, 133)
        '
        '
        '
        Me.SMTPRadGridView.MasterGridViewTemplate.AllowAddNewRow = False
        Me.SMTPRadGridView.MasterGridViewTemplate.AllowColumnReorder = False
        GridViewDecimalColumn1.DataType = GetType(Decimal)
        GridViewDecimalColumn1.FieldAlias = "CODSMTP"
        GridViewDecimalColumn1.FieldName = "CODSMTP"
        GridViewDecimalColumn1.HeaderText = "CODSMTP"
        GridViewDecimalColumn1.IsAutoGenerated = True
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.UniqueName = "CODSMTP"
        GridViewTextBoxColumn1.FieldAlias = "SERVIDORSMTP"
        GridViewTextBoxColumn1.FieldName = "SERVIDORSMTP"
        GridViewTextBoxColumn1.HeaderText = "SERVIDOR SMTP"
        GridViewTextBoxColumn1.IsAutoGenerated = True
        GridViewTextBoxColumn1.UniqueName = "SERVIDORSMTP"
        GridViewTextBoxColumn1.Width = 225
        GridViewDecimalColumn2.DataType = GetType(Decimal)
        GridViewDecimalColumn2.FieldAlias = "PUERTO"
        GridViewDecimalColumn2.FieldName = "PUERTO"
        GridViewDecimalColumn2.HeaderText = "PUERTO"
        GridViewDecimalColumn2.IsAutoGenerated = True
        GridViewDecimalColumn2.IsVisible = False
        GridViewDecimalColumn2.UniqueName = "PUERTO"
        GridViewTextBoxColumn2.FieldAlias = "USUARIO"
        GridViewTextBoxColumn2.FieldName = "USUARIO"
        GridViewTextBoxColumn2.HeaderText = "USUARIO"
        GridViewTextBoxColumn2.IsAutoGenerated = True
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.UniqueName = "USUARIO"
        GridViewTextBoxColumn3.FieldAlias = "CONTRASEÑA"
        GridViewTextBoxColumn3.FieldName = "CONTRASEÑA"
        GridViewTextBoxColumn3.HeaderText = "CONTRASEÑA"
        GridViewTextBoxColumn3.IsAutoGenerated = True
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.UniqueName = "CONTRASEÑA"
        GridViewDecimalColumn3.DataType = GetType(Decimal)
        GridViewDecimalColumn3.FieldAlias = "CODUSUARIO"
        GridViewDecimalColumn3.FieldName = "CODUSUARIO"
        GridViewDecimalColumn3.HeaderText = "CODUSUARIO"
        GridViewDecimalColumn3.IsAutoGenerated = True
        GridViewDecimalColumn3.IsVisible = False
        GridViewDecimalColumn3.UniqueName = "CODUSUARIO"
        GridViewDecimalColumn4.DataType = GetType(Decimal)
        GridViewDecimalColumn4.FieldAlias = "CODEMPRESA"
        GridViewDecimalColumn4.FieldName = "CODEMPRESA"
        GridViewDecimalColumn4.HeaderText = "CODEMPRESA"
        GridViewDecimalColumn4.IsAutoGenerated = True
        GridViewDecimalColumn4.IsVisible = False
        GridViewDecimalColumn4.UniqueName = "CODEMPRESA"
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn1)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn1)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn2)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn2)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewTextBoxColumn3)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn3)
        Me.SMTPRadGridView.MasterGridViewTemplate.Columns.Add(GridViewDecimalColumn4)
        Me.SMTPRadGridView.MasterGridViewTemplate.DataSource = Me.SMTPBindingSource
        Me.SMTPRadGridView.MasterGridViewTemplate.EnableSorting = False
        Me.SMTPRadGridView.MasterGridViewTemplate.ShowRowHeaderColumn = False
        Me.SMTPRadGridView.Name = "SMTPRadGridView"
        Me.SMTPRadGridView.ReadOnly = True
        Me.SMTPRadGridView.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SMTPRadGridView.ShowGroupPanel = False
        Me.SMTPRadGridView.Size = New System.Drawing.Size(252, 319)
        Me.SMTPRadGridView.TabIndex = 7
        '
        'SMTPBindingSource
        '
        Me.SMTPBindingSource.DataMember = "SMTP"
        Me.SMTPBindingSource.DataSource = Me.DsSMTP
        '
        'DsSMTP
        '
        Me.DsSMTP.DataSetName = "DsSMTP"
        Me.DsSMTP.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.EditablePictureBox)
        Me.Panel1.Controls.Add(Me.NuevoPictureBox)
        Me.Panel1.Controls.Add(Me.NuevoGrisPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarPictureBox)
        Me.Panel1.Controls.Add(Me.EliminarGrisPictureBox)
        Me.Panel1.Controls.Add(Me.BloqueoPictureBox)
        Me.Panel1.Controls.Add(Me.CancelarPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarGrisPictureBox)
        Me.Panel1.Controls.Add(Me.GuardarPictureBox)
        Me.Panel1.Controls.Add(Me.ModificarPictureBox)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 87)
        Me.Panel1.TabIndex = 154
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(690, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1, 79)
        Me.PictureBox2.TabIndex = 69
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.Location = New System.Drawing.Point(327, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1, 79)
        Me.PictureBox3.TabIndex = 68
        Me.PictureBox3.TabStop = False
        '
        'EditablePictureBox
        '
        Me.EditablePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EditablePictureBox.Image = Global.ContaExpress.My.Resources.Resources.planilla_editable
        Me.EditablePictureBox.Location = New System.Drawing.Point(697, 3)
        Me.EditablePictureBox.Name = "EditablePictureBox"
        Me.EditablePictureBox.Size = New System.Drawing.Size(75, 78)
        Me.EditablePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EditablePictureBox.TabIndex = 5
        Me.EditablePictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImage = Global.ContaExpress.My.Resources.Resources.nueva_ficha
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.nueva_ficha
        Me.NuevoPictureBox.Location = New System.Drawing.Point(8, 4)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'NuevoGrisPictureBox
        '
        Me.NuevoGrisPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoGrisPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NuevoGrisPictureBox.Image = Global.ContaExpress.My.Resources.Resources.nueva_fichagris
        Me.NuevoGrisPictureBox.Location = New System.Drawing.Point(8, 4)
        Me.NuevoGrisPictureBox.Name = "NuevoGrisPictureBox"
        Me.NuevoGrisPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.NuevoGrisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoGrisPictureBox.TabIndex = 1
        Me.NuevoGrisPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.eliminar_ficha
        Me.EliminarPictureBox.Location = New System.Drawing.Point(87, 4)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'EliminarGrisPictureBox
        '
        Me.EliminarGrisPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarGrisPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.EliminarGrisPictureBox.Image = Global.ContaExpress.My.Resources.Resources.eliminar_fichagris
        Me.EliminarGrisPictureBox.Location = New System.Drawing.Point(87, 4)
        Me.EliminarGrisPictureBox.Name = "EliminarGrisPictureBox"
        Me.EliminarGrisPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.EliminarGrisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarGrisPictureBox.TabIndex = 7
        Me.EliminarGrisPictureBox.TabStop = False
        '
        'BloqueoPictureBox
        '
        Me.BloqueoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.BloqueoPictureBox.Image = Global.ContaExpress.My.Resources.Resources.planilla_bloqueada
        Me.BloqueoPictureBox.Location = New System.Drawing.Point(697, 3)
        Me.BloqueoPictureBox.Name = "BloqueoPictureBox"
        Me.BloqueoPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.BloqueoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.BloqueoPictureBox.TabIndex = 8
        Me.BloqueoPictureBox.TabStop = False
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.cancelar
        Me.CancelarPictureBox.Location = New System.Drawing.Point(253, 3)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarGrisPictureBox
        '
        Me.GuardarGrisPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarGrisPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarGrisPictureBox.Location = New System.Drawing.Point(245, 4)
        Me.GuardarGrisPictureBox.Name = "GuardarGrisPictureBox"
        Me.GuardarGrisPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.GuardarGrisPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarGrisPictureBox.TabIndex = 9
        Me.GuardarGrisPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.guardar
        Me.GuardarPictureBox.Location = New System.Drawing.Point(166, 4)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.modificarficha
        Me.ModificarPictureBox.Location = New System.Drawing.Point(245, 4)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(75, 78)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.BuscarTextBox.Location = New System.Drawing.Point(41, 103)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(100, 13)
        Me.BuscarTextBox.TabIndex = 6
        Me.BuscarTextBox.Text = "Buscar..."
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.ContaExpress.My.Resources.Resources.Busqueda_Rapida
        Me.PictureBox4.Location = New System.Drawing.Point(12, 93)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(160, 30)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 389
        Me.PictureBox4.TabStop = False
        '
        'ServidorSMTPTextBox
        '
        Me.ServidorSMTPTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "SERVIDORSMTP", True))
        Me.ServidorSMTPTextBox.Location = New System.Drawing.Point(413, 170)
        Me.ServidorSMTPTextBox.Name = "ServidorSMTPTextBox"
        Me.ServidorSMTPTextBox.Size = New System.Drawing.Size(225, 20)
        Me.ServidorSMTPTextBox.TabIndex = 0
        Me.ServidorSMTPTextBox.TabStop = False
        Me.ServidorSMTPTextBox.ThemeName = "Breeze"
        CType(Me.ServidorSMTPTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(325, 173)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(82, 13)
        Me.Label16.TabIndex = 390
        Me.Label16.Text = "Servidor SMTP:"
        '
        'PuertoTextBox
        '
        Me.PuertoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "PUERTO", True))
        Me.PuertoTextBox.Location = New System.Drawing.Point(413, 199)
        Me.PuertoTextBox.Name = "PuertoTextBox"
        Me.PuertoTextBox.Size = New System.Drawing.Size(90, 20)
        Me.PuertoTextBox.TabIndex = 1
        Me.PuertoTextBox.TabStop = False
        Me.PuertoTextBox.ThemeName = "Breeze"
        CType(Me.PuertoTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 202)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 392
        Me.Label1.Text = "Puerto:"
        '
        'UsuarioTextBox
        '
        Me.UsuarioTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "USUARIO", True))
        Me.UsuarioTextBox.Location = New System.Drawing.Point(413, 251)
        Me.UsuarioTextBox.Name = "UsuarioTextBox"
        Me.UsuarioTextBox.Size = New System.Drawing.Size(225, 20)
        Me.UsuarioTextBox.TabIndex = 3
        Me.UsuarioTextBox.TabStop = False
        Me.UsuarioTextBox.ThemeName = "Breeze"
        CType(Me.UsuarioTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(361, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 394
        Me.Label2.Text = "Usuario:"
        '
        'PassTextBox
        '
        Me.PassTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "CONTRASENHA", True))
        Me.PassTextBox.Location = New System.Drawing.Point(413, 277)
        Me.PassTextBox.Name = "PassTextBox"
        Me.PassTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PassTextBox.Size = New System.Drawing.Size(225, 20)
        Me.PassTextBox.TabIndex = 4
        Me.PassTextBox.TabStop = False
        Me.PassTextBox.ThemeName = "Breeze"
        CType(Me.PassTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(343, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 396
        Me.Label3.Text = "Contraseña:"
        '
        'ConfirmapassTextBox
        '
        Me.ConfirmapassTextBox.Location = New System.Drawing.Point(413, 303)
        Me.ConfirmapassTextBox.Name = "ConfirmapassTextBox"
        Me.ConfirmapassTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.ConfirmapassTextBox.Size = New System.Drawing.Size(225, 20)
        Me.ConfirmapassTextBox.TabIndex = 5
        Me.ConfirmapassTextBox.TabStop = False
        Me.ConfirmapassTextBox.ThemeName = "Breeze"
        CType(Me.ConfirmapassTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'ConfLabel
        '
        Me.ConfLabel.AutoSize = True
        Me.ConfLabel.Location = New System.Drawing.Point(353, 305)
        Me.ConfLabel.Name = "ConfLabel"
        Me.ConfLabel.Size = New System.Drawing.Size(54, 13)
        Me.ConfLabel.TabIndex = 398
        Me.ConfLabel.Text = "Confirmar:"
        '
        'CodSMTPTextBox
        '
        Me.CodSMTPTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "CODSMTP", True))
        Me.CodSMTPTextBox.Location = New System.Drawing.Point(231, 133)
        Me.CodSMTPTextBox.Name = "CodSMTPTextBox"
        Me.CodSMTPTextBox.ReadOnly = True
        Me.CodSMTPTextBox.Size = New System.Drawing.Size(33, 20)
        Me.CodSMTPTextBox.TabIndex = 400
        '
        'SMTPTableAdapter
        '
        Me.SMTPTableAdapter.ClearBeforeFill = True
        '
        'RemitenteTextBox
        '
        Me.RemitenteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SMTPBindingSource, "REMITENTE", True))
        Me.RemitenteTextBox.Location = New System.Drawing.Point(413, 225)
        Me.RemitenteTextBox.Name = "RemitenteTextBox"
        Me.RemitenteTextBox.Size = New System.Drawing.Size(225, 20)
        Me.RemitenteTextBox.TabIndex = 2
        Me.RemitenteTextBox.TabStop = False
        Me.RemitenteTextBox.ThemeName = "Breeze"
        CType(Me.RemitenteTextBox.GetChildAt(0).GetChildAt(2), Telerik.WinControls.Primitives.BorderPrimitive).ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(149, Byte), Integer), CType(CType(237, Byte), Integer))
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(349, 228)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 402
        Me.Label4.Text = "Remitente:"
        '
        'ABMSmtp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 460)
        Me.Controls.Add(Me.RemitenteTextBox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ConfirmapassTextBox)
        Me.Controls.Add(Me.ConfLabel)
        Me.Controls.Add(Me.PassTextBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UsuarioTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PuertoTextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ServidorSMTPTextBox)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BuscarTextBox)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SMTPRadGridView)
        Me.Controls.Add(Me.CodSMTPTextBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ABMSmtp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Servidor de Correo"
        CType(Me.SMTPRadGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SMTPBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSMTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EditablePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoGrisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarGrisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BloqueoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarGrisPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServidorSMTPTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PuertoTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UsuarioTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PassTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConfirmapassTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RemitenteTextBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SMTPRadGridView As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents EditablePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoGrisPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarGrisPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BloqueoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarGrisPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents DsSMTP As ContaExpress.DsSMTP
    Friend WithEvents SMTPBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SMTPTableAdapter As ContaExpress.DsSMTPTableAdapters.SMTPTableAdapter
    Friend WithEvents ServidorSMTPTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents PuertoTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents UsuarioTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PassTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ConfirmapassTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents ConfLabel As System.Windows.Forms.Label
    Friend WithEvents CodSMTPTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BreezeTheme1 As Telerik.WinControls.Themes.BreezeTheme
    Friend WithEvents RemitenteTextBox As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
