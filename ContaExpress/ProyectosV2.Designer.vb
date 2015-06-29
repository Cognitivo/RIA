<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProyectosV2
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
        Dim NUMEVENTOLabel As System.Windows.Forms.Label
        Dim Label10 As System.Windows.Forms.Label
        Dim Label11 As System.Windows.Forms.Label
        Dim Label12 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label42 As System.Windows.Forms.Label
        Dim Label41 As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label6 As System.Windows.Forms.Label
        Dim Label40 As System.Windows.Forms.Label
        Dim DESUSUARIOLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim DESTINATARIOLabel As System.Windows.Forms.Label
        Dim Label21 As System.Windows.Forms.Label
        Dim Label29 As System.Windows.Forms.Label
        Dim Label30 As System.Windows.Forms.Label
        Dim Label32 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label26 As System.Windows.Forms.Label
        Dim Label34 As System.Windows.Forms.Label
        Dim Label17 As System.Windows.Forms.Label
        Dim Label31 As System.Windows.Forms.Label
        Dim Label16 As System.Windows.Forms.Label
        Dim Label20 As System.Windows.Forms.Label
        Dim Label15 As System.Windows.Forms.Label
        Dim Label25 As System.Windows.Forms.Label
        Dim Label24 As System.Windows.Forms.Label
        Dim Label23 As System.Windows.Forms.Label
        Dim lblFechaSalida As System.Windows.Forms.Label
        Dim Label13 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProyectosV2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.pbxImprimir = New System.Windows.Forms.PictureBox()
        Me.pbxActivoInactivo = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.CancelarPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuardarPictureBox = New System.Windows.Forms.PictureBox()
        Me.ModificarPictureBox = New System.Windows.Forms.PictureBox()
        Me.EliminarPictureBox = New System.Windows.Forms.PictureBox()
        Me.NuevoPictureBox = New System.Windows.Forms.PictureBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.txtBuscarSeguimiento = New System.Windows.Forms.TextBox()
        Me.pbxResfresh = New System.Windows.Forms.PictureBox()
        Me.btnInsertarComentario = New System.Windows.Forms.Button()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgwComentarios = New System.Windows.Forms.DataGridView()
        Me.PagePrincipal = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.tbxObservacion = New System.Windows.Forms.TextBox()
        Me.txtFechaSalida = New System.Windows.Forms.MaskedTextBox()
        Me.txtLlegadaTransb = New System.Windows.Forms.MaskedTextBox()
        Me.txtTransbSalida = New System.Windows.Forms.MaskedTextBox()
        Me.txtFechaLlegada = New System.Windows.Forms.MaskedTextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pbxAsteriscoProv = New System.Windows.Forms.PictureBox()
        Me.cmbModoTransporte = New System.Windows.Forms.ComboBox()
        Me.EVENTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsEventos = New ContaExpress.DsEventos()
        Me.pbxAgregarProveedor = New System.Windows.Forms.PictureBox()
        Me.cmbTipoEmbarque = New System.Windows.Forms.ComboBox()
        Me.cmbProveedorAgente = New System.Windows.Forms.ComboBox()
        Me.tbxCantBultos = New System.Windows.Forms.TextBox()
        Me.tbxMasterDoc = New System.Windows.Forms.TextBox()
        Me.tbxPesoBruto = New System.Windows.Forms.TextBox()
        Me.cmbFormaPagoHouse = New System.Windows.Forms.ComboBox()
        Me.tbxVolumen = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cmbIncoterm = New System.Windows.Forms.ComboBox()
        Me.tbxCodIncoterm = New System.Windows.Forms.TextBox()
        Me.cmbSeguroCarga = New System.Windows.Forms.ComboBox()
        Me.tbxDimensiones = New System.Windows.Forms.TextBox()
        Me.cmbCiudadOrigen = New System.Windows.Forms.ComboBox()
        Me.tbxMercaderia = New System.Windows.Forms.TextBox()
        Me.tbxZipCodeDestino = New System.Windows.Forms.TextBox()
        Me.tbxCodCiudadOrigen = New System.Windows.Forms.TextBox()
        Me.cmbCiudadDestino = New System.Windows.Forms.ComboBox()
        Me.tbxZipCodeOrigen = New System.Windows.Forms.TextBox()
        Me.tbxCodCiudadDestino = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtNroProyecto = New System.Windows.Forms.TextBox()
        Me.txtIdOT = New System.Windows.Forms.TextBox()
        Me.tbxCodCodigo = New System.Windows.Forms.TextBox()
        Me.pnlCliente = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbxMailContacto = New System.Windows.Forms.TextBox()
        Me.cmbCliente = New System.Windows.Forms.ComboBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.tbxCelContacto = New System.Windows.Forms.TextBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.tbxRuc = New System.Windows.Forms.TextBox()
        Me.tbxDireccion = New System.Windows.Forms.TextBox()
        Me.tbxShpr = New System.Windows.Forms.TextBox()
        Me.tbxTelefono = New System.Windows.Forms.TextBox()
        Me.tbxContacto = New System.Windows.Forms.TextBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.rbnExterior = New System.Windows.Forms.RadioButton()
        Me.rbnExport = New System.Windows.Forms.RadioButton()
        Me.rbnImport = New System.Windows.Forms.RadioButton()
        Me.dtpFechaCotizacion = New System.Windows.Forms.MaskedTextBox()
        Me.dtpFechaProyecto = New System.Windows.Forms.DateTimePicker()
        Me.tabEventos = New System.Windows.Forms.TabControl()
        Me.EVENTOTableAdapter = New ContaExpress.DsEventosTableAdapters.EVENTOTableAdapter()
        NUMEVENTOLabel = New System.Windows.Forms.Label()
        Label10 = New System.Windows.Forms.Label()
        Label11 = New System.Windows.Forms.Label()
        Label12 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label42 = New System.Windows.Forms.Label()
        Label41 = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label6 = New System.Windows.Forms.Label()
        Label40 = New System.Windows.Forms.Label()
        DESUSUARIOLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        DESTINATARIOLabel = New System.Windows.Forms.Label()
        Label21 = New System.Windows.Forms.Label()
        Label29 = New System.Windows.Forms.Label()
        Label30 = New System.Windows.Forms.Label()
        Label32 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label26 = New System.Windows.Forms.Label()
        Label34 = New System.Windows.Forms.Label()
        Label17 = New System.Windows.Forms.Label()
        Label31 = New System.Windows.Forms.Label()
        Label16 = New System.Windows.Forms.Label()
        Label20 = New System.Windows.Forms.Label()
        Label15 = New System.Windows.Forms.Label()
        Label25 = New System.Windows.Forms.Label()
        Label24 = New System.Windows.Forms.Label()
        Label23 = New System.Windows.Forms.Label()
        lblFechaSalida = New System.Windows.Forms.Label()
        Label13 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxActivoInactivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxResfresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgwComentarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PagePrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxAsteriscoProv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EVENTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsEventos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxAgregarProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCliente.SuspendLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabEventos.SuspendLayout()
        Me.SuspendLayout()
        '
        'NUMEVENTOLabel
        '
        NUMEVENTOLabel.AutoSize = True
        NUMEVENTOLabel.Location = New System.Drawing.Point(22, 8)
        NUMEVENTOLabel.Name = "NUMEVENTOLabel"
        NUMEVENTOLabel.Size = New System.Drawing.Size(108, 17)
        NUMEVENTOLabel.TabIndex = 544
        NUMEVENTOLabel.Text = "Nro Referencia:"
        '
        'Label10
        '
        Label10.AutoSize = True
        Label10.Location = New System.Drawing.Point(6, 40)
        Label10.Name = "Label10"
        Label10.Size = New System.Drawing.Size(127, 17)
        Label10.TabIndex = 546
        Label10.Text = "Inicio del Proyecto:"
        '
        'Label11
        '
        Label11.AutoSize = True
        Label11.Location = New System.Drawing.Point(10, 77)
        Label11.Name = "Label11"
        Label11.Size = New System.Drawing.Size(120, 17)
        Label11.TabIndex = 547
        Label11.Text = "Fecha Cotización:"
        '
        'Label12
        '
        Label12.AutoSize = True
        Label12.Location = New System.Drawing.Point(529, 8)
        Label12.Name = "Label12"
        Label12.Size = New System.Drawing.Size(56, 17)
        Label12.TabIndex = 604
        Label12.Text = "Estado:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New System.Drawing.Point(52, 103)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(68, 17)
        Label2.TabIndex = 607
        Label2.Text = "Contacto:"
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Location = New System.Drawing.Point(30, 163)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(91, 17)
        Label3.TabIndex = 609
        Label3.Text = "SHPR/CNEE:"
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Location = New System.Drawing.Point(80, 74)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(41, 17)
        Label4.TabIndex = 611
        Label4.Text = "RUC:"
        '
        'Label42
        '
        Label42.AutoSize = True
        Label42.Location = New System.Drawing.Point(45, 133)
        Label42.Name = "Label42"
        Label42.Size = New System.Drawing.Size(75, 17)
        Label42.TabIndex = 602
        Label42.Text = "Telefonos:"
        '
        'Label41
        '
        Label41.AutoSize = True
        Label41.Location = New System.Drawing.Point(505, 74)
        Label41.Name = "Label41"
        Label41.Size = New System.Drawing.Size(71, 17)
        Label41.TabIndex = 601
        Label41.Text = "Direccion:"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Location = New System.Drawing.Point(540, 102)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(36, 17)
        Label5.TabIndex = 613
        Label5.Text = "Cel.:"
        '
        'Label6
        '
        Label6.AutoSize = True
        Label6.Location = New System.Drawing.Point(539, 133)
        Label6.Name = "Label6"
        Label6.Size = New System.Drawing.Size(37, 17)
        Label6.TabIndex = 615
        Label6.Text = "Mail:"
        '
        'Label40
        '
        Label40.AutoSize = True
        Label40.Location = New System.Drawing.Point(66, 42)
        Label40.Name = "Label40"
        Label40.Size = New System.Drawing.Size(55, 17)
        Label40.TabIndex = 583
        Label40.Text = "Cliente:"
        '
        'DESUSUARIOLabel
        '
        DESUSUARIOLabel.AutoSize = True
        DESUSUARIOLabel.Location = New System.Drawing.Point(477, 47)
        DESUSUARIOLabel.Name = "DESUSUARIOLabel"
        DESUSUARIOLabel.Size = New System.Drawing.Size(108, 17)
        DESUSUARIOLabel.TabIndex = 642
        DESUSUARIOLabel.Text = "Ejec.de Cuenta:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New System.Drawing.Point(54, 165)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(69, 17)
        Label1.TabIndex = 624
        Label1.Text = "Zip Code:"
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Location = New System.Drawing.Point(509, 168)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(69, 17)
        Label8.TabIndex = 626
        Label8.Text = "Zip Code:"
        '
        'DESTINATARIOLabel
        '
        DESTINATARIOLabel.AutoSize = True
        DESTINATARIOLabel.Location = New System.Drawing.Point(68, 136)
        DESTINATARIOLabel.Name = "DESTINATARIOLabel"
        DESTINATARIOLabel.Size = New System.Drawing.Size(55, 17)
        DESTINATARIOLabel.TabIndex = 618
        DESTINATARIOLabel.Text = "Origen:"
        '
        'Label21
        '
        Label21.AutoSize = True
        Label21.Location = New System.Drawing.Point(518, 138)
        Label21.Name = "Label21"
        Label21.Size = New System.Drawing.Size(60, 17)
        Label21.TabIndex = 619
        Label21.Text = "Destino:"
        '
        'Label29
        '
        Label29.AutoSize = True
        Label29.Location = New System.Drawing.Point(40, 200)
        Label29.Name = "Label29"
        Label29.Size = New System.Drawing.Size(83, 17)
        Label29.TabIndex = 630
        Label29.Text = "Mercaderia:"
        '
        'Label30
        '
        Label30.AutoSize = True
        Label30.Location = New System.Drawing.Point(31, 232)
        Label30.Name = "Label30"
        Label30.Size = New System.Drawing.Size(93, 17)
        Label30.TabIndex = 631
        Label30.Text = "Dimensiones:"
        '
        'Label32
        '
        Label32.AutoSize = True
        Label32.Location = New System.Drawing.Point(490, 232)
        Label32.Name = "Label32"
        Label32.Size = New System.Drawing.Size(88, 17)
        Label32.TabIndex = 633
        Label32.Text = "Cant. Bultos:"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.Location = New System.Drawing.Point(511, 200)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(67, 17)
        Label33.TabIndex = 634
        Label33.Text = "Volumen:"
        '
        'Label26
        '
        Label26.AutoSize = True
        Label26.Location = New System.Drawing.Point(469, 106)
        Label26.Name = "Label26"
        Label26.Size = New System.Drawing.Size(109, 17)
        Label26.TabIndex = 554
        Label26.Text = "Forma de Pago:"
        '
        'Label34
        '
        Label34.AutoSize = True
        Label34.Location = New System.Drawing.Point(496, 264)
        Label34.Name = "Label34"
        Label34.Size = New System.Drawing.Size(82, 17)
        Label34.TabIndex = 636
        Label34.Text = "Peso Bruto:"
        '
        'Label17
        '
        Label17.AutoSize = True
        Label17.Location = New System.Drawing.Point(478, 42)
        Label17.Name = "Label17"
        Label17.Size = New System.Drawing.Size(100, 17)
        Label17.TabIndex = 551
        Label17.Text = "Seguro Carga:"
        '
        'Label31
        '
        Label31.AutoSize = True
        Label31.Location = New System.Drawing.Point(34, 264)
        Label31.Name = "Label31"
        Label31.Size = New System.Drawing.Size(90, 17)
        Label31.TabIndex = 638
        Label31.Text = "Prov/Agente:"
        '
        'Label16
        '
        Label16.AutoSize = True
        Label16.Location = New System.Drawing.Point(39, 74)
        Label16.Name = "Label16"
        Label16.Size = New System.Drawing.Size(84, 17)
        Label16.TabIndex = 550
        Label16.Text = "Tipo Embq.:"
        '
        'Label20
        '
        Label20.AutoSize = True
        Label20.Location = New System.Drawing.Point(12, 106)
        Label20.Name = "Label20"
        Label20.Size = New System.Drawing.Size(111, 17)
        Label20.TabIndex = 506
        Label20.Text = "Master BL/AWB:"
        '
        'Label15
        '
        Label15.AutoSize = True
        Label15.Location = New System.Drawing.Point(2, 42)
        Label15.Name = "Label15"
        Label15.Size = New System.Drawing.Size(121, 17)
        Label15.TabIndex = 549
        Label15.Text = "Modo Transporte:"
        '
        'Label25
        '
        Label25.AutoSize = True
        Label25.Location = New System.Drawing.Point(438, 328)
        Label25.Name = "Label25"
        Label25.Size = New System.Drawing.Size(138, 17)
        Label25.TabIndex = 650
        Label25.Text = "Est. Tiempo Llegada"
        '
        'Label24
        '
        Label24.AutoSize = True
        Label24.Location = New System.Drawing.Point(9, 328)
        Label24.Name = "Label24"
        Label24.Size = New System.Drawing.Size(112, 17)
        Label24.TabIndex = 649
        Label24.Text = "Llegada Transb."
        '
        'Label23
        '
        Label23.AutoSize = True
        Label23.Location = New System.Drawing.Point(476, 295)
        Label23.Name = "Label23"
        Label23.Size = New System.Drawing.Size(100, 17)
        Label23.TabIndex = 648
        Label23.Text = "Salida Transb."
        '
        'lblFechaSalida
        '
        lblFechaSalida.AutoSize = True
        lblFechaSalida.Location = New System.Drawing.Point(-4, 296)
        lblFechaSalida.Name = "lblFechaSalida"
        lblFechaSalida.Size = New System.Drawing.Size(126, 17)
        lblFechaSalida.TabIndex = 647
        lblFechaSalida.Text = "Est. Tiempo Salida"
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.Location = New System.Drawing.Point(80, 361)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(42, 17)
        Label13.TabIndex = 651
        Label13.Text = "Obs.:"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.Tan
        Me.Panel5.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.pbxImprimir)
        Me.Panel5.Controls.Add(Me.pbxActivoInactivo)
        Me.Panel5.Controls.Add(Me.PictureBox8)
        Me.Panel5.Controls.Add(Me.txtBuscar)
        Me.Panel5.Controls.Add(Me.CancelarPictureBox)
        Me.Panel5.Controls.Add(Me.GuardarPictureBox)
        Me.Panel5.Controls.Add(Me.ModificarPictureBox)
        Me.Panel5.Controls.Add(Me.EliminarPictureBox)
        Me.Panel5.Controls.Add(Me.NuevoPictureBox)
        Me.Panel5.Location = New System.Drawing.Point(1, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(956, 37)
        Me.Panel5.TabIndex = 556
        '
        'pbxImprimir
        '
        Me.pbxImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxImprimir.BackColor = System.Drawing.Color.Transparent
        Me.pbxImprimir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxImprimir.Image = Global.ContaExpress.My.Resources.Resources.Print
        Me.pbxImprimir.Location = New System.Drawing.Point(879, -1)
        Me.pbxImprimir.Name = "pbxImprimir"
        Me.pbxImprimir.Size = New System.Drawing.Size(35, 35)
        Me.pbxImprimir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxImprimir.TabIndex = 466
        Me.pbxImprimir.TabStop = False
        '
        'pbxActivoInactivo
        '
        Me.pbxActivoInactivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxActivoInactivo.BackColor = System.Drawing.Color.Transparent
        Me.pbxActivoInactivo.Image = Global.ContaExpress.My.Resources.Resources.AbiertoActive
        Me.pbxActivoInactivo.Location = New System.Drawing.Point(915, -1)
        Me.pbxActivoInactivo.Name = "pbxActivoInactivo"
        Me.pbxActivoInactivo.Size = New System.Drawing.Size(35, 35)
        Me.pbxActivoInactivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxActivoInactivo.TabIndex = 465
        Me.pbxActivoInactivo.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.Tan
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox8.Location = New System.Drawing.Point(4, 3)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(35, 29)
        Me.PictureBox8.TabIndex = 456
        Me.PictureBox8.TabStop = False
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.Tan
        Me.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtBuscar.ForeColor = System.Drawing.Color.Black
        Me.txtBuscar.Location = New System.Drawing.Point(37, 3)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(207, 29)
        Me.txtBuscar.TabIndex = 455
        '
        'CancelarPictureBox
        '
        Me.CancelarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.CancelarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CancelarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveCancelOff
        Me.CancelarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CancelarPictureBox.Location = New System.Drawing.Point(377, 0)
        Me.CancelarPictureBox.Name = "CancelarPictureBox"
        Me.CancelarPictureBox.Size = New System.Drawing.Size(32, 34)
        Me.CancelarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CancelarPictureBox.TabIndex = 4
        Me.CancelarPictureBox.TabStop = False
        '
        'GuardarPictureBox
        '
        Me.GuardarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.GuardarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.GuardarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.SaveOff
        Me.GuardarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GuardarPictureBox.Location = New System.Drawing.Point(345, 0)
        Me.GuardarPictureBox.Name = "GuardarPictureBox"
        Me.GuardarPictureBox.Size = New System.Drawing.Size(32, 34)
        Me.GuardarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GuardarPictureBox.TabIndex = 3
        Me.GuardarPictureBox.TabStop = False
        '
        'ModificarPictureBox
        '
        Me.ModificarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ModificarPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ModificarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Edit
        Me.ModificarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ModificarPictureBox.Location = New System.Drawing.Point(313, 0)
        Me.ModificarPictureBox.Name = "ModificarPictureBox"
        Me.ModificarPictureBox.Size = New System.Drawing.Size(32, 34)
        Me.ModificarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ModificarPictureBox.TabIndex = 2
        Me.ModificarPictureBox.TabStop = False
        '
        'EliminarPictureBox
        '
        Me.EliminarPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.EliminarPictureBox.Image = Global.ContaExpress.My.Resources.Resources.Delete
        Me.EliminarPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EliminarPictureBox.Location = New System.Drawing.Point(281, 0)
        Me.EliminarPictureBox.Name = "EliminarPictureBox"
        Me.EliminarPictureBox.Size = New System.Drawing.Size(32, 34)
        Me.EliminarPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.EliminarPictureBox.TabIndex = 1
        Me.EliminarPictureBox.TabStop = False
        '
        'NuevoPictureBox
        '
        Me.NuevoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.NuevoPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NuevoPictureBox.Image = CType(resources.GetObject("NuevoPictureBox.Image"), System.Drawing.Image)
        Me.NuevoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.NuevoPictureBox.Location = New System.Drawing.Point(246, 0)
        Me.NuevoPictureBox.Name = "NuevoPictureBox"
        Me.NuevoPictureBox.Size = New System.Drawing.Size(35, 34)
        Me.NuevoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.NuevoPictureBox.TabIndex = 0
        Me.NuevoPictureBox.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(948, 611)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Seguimiento"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.txtBuscarSeguimiento)
        Me.Panel2.Controls.Add(Me.pbxResfresh)
        Me.Panel2.Controls.Add(Me.btnInsertarComentario)
        Me.Panel2.Controls.Add(Me.txtComentario)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.dgwComentarios)
        Me.Panel2.Location = New System.Drawing.Point(1, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(947, 611)
        Me.Panel2.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Tan
        Me.PictureBox2.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(477, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 23)
        Me.PictureBox2.TabIndex = 508
        Me.PictureBox2.TabStop = False
        '
        'txtBuscarSeguimiento
        '
        Me.txtBuscarSeguimiento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBuscarSeguimiento.BackColor = System.Drawing.Color.Tan
        Me.txtBuscarSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBuscarSeguimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.txtBuscarSeguimiento.ForeColor = System.Drawing.Color.Black
        Me.txtBuscarSeguimiento.Location = New System.Drawing.Point(506, 3)
        Me.txtBuscarSeguimiento.Name = "txtBuscarSeguimiento"
        Me.txtBuscarSeguimiento.Size = New System.Drawing.Size(400, 23)
        Me.txtBuscarSeguimiento.TabIndex = 507
        '
        'pbxResfresh
        '
        Me.pbxResfresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxResfresh.BackColor = System.Drawing.Color.Transparent
        Me.pbxResfresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxResfresh.Image = CType(resources.GetObject("pbxResfresh.Image"), System.Drawing.Image)
        Me.pbxResfresh.Location = New System.Drawing.Point(908, 3)
        Me.pbxResfresh.Name = "pbxResfresh"
        Me.pbxResfresh.Size = New System.Drawing.Size(26, 24)
        Me.pbxResfresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxResfresh.TabIndex = 506
        Me.pbxResfresh.TabStop = False
        '
        'btnInsertarComentario
        '
        Me.btnInsertarComentario.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInsertarComentario.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnInsertarComentario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInsertarComentario.ForeColor = System.Drawing.Color.White
        Me.btnInsertarComentario.Location = New System.Drawing.Point(864, 581)
        Me.btnInsertarComentario.Name = "btnInsertarComentario"
        Me.btnInsertarComentario.Size = New System.Drawing.Size(71, 27)
        Me.btnInsertarComentario.TabIndex = 505
        Me.btnInsertarComentario.Text = "Insertar"
        Me.btnInsertarComentario.UseVisualStyleBackColor = False
        '
        'txtComentario
        '
        Me.txtComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtComentario.Location = New System.Drawing.Point(8, 582)
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(852, 26)
        Me.txtComentario.TabIndex = 447
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Light", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(3, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(262, 27)
        Me.Label14.TabIndex = 446
        Me.Label14.Text = "Seguimiento / Detalles"
        '
        'dgwComentarios
        '
        Me.dgwComentarios.AllowUserToAddRows = False
        Me.dgwComentarios.AllowUserToDeleteRows = False
        Me.dgwComentarios.AllowUserToResizeColumns = False
        Me.dgwComentarios.AllowUserToResizeRows = False
        Me.dgwComentarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgwComentarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgwComentarios.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgwComentarios.ColumnHeadersHeight = 34
        Me.dgwComentarios.Location = New System.Drawing.Point(8, 28)
        Me.dgwComentarios.Name = "dgwComentarios"
        Me.dgwComentarios.ReadOnly = True
        Me.dgwComentarios.RowHeadersVisible = False
        Me.dgwComentarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgwComentarios.Size = New System.Drawing.Size(928, 551)
        Me.dgwComentarios.TabIndex = 0
        '
        'PagePrincipal
        '
        Me.PagePrincipal.AutoScroll = True
        Me.PagePrincipal.BackColor = System.Drawing.SystemColors.Control
        Me.PagePrincipal.Controls.Add(Me.Panel1)
        Me.PagePrincipal.Controls.Add(DESUSUARIOLabel)
        Me.PagePrincipal.Controls.Add(Me.txtUsuario)
        Me.PagePrincipal.Controls.Add(Me.txtNroProyecto)
        Me.PagePrincipal.Controls.Add(Me.txtIdOT)
        Me.PagePrincipal.Controls.Add(Me.tbxCodCodigo)
        Me.PagePrincipal.Controls.Add(Me.pnlCliente)
        Me.PagePrincipal.Controls.Add(Label12)
        Me.PagePrincipal.Controls.Add(Me.cmbEstado)
        Me.PagePrincipal.Controls.Add(Me.rbnExterior)
        Me.PagePrincipal.Controls.Add(Me.rbnExport)
        Me.PagePrincipal.Controls.Add(Me.rbnImport)
        Me.PagePrincipal.Controls.Add(Me.dtpFechaCotizacion)
        Me.PagePrincipal.Controls.Add(Label11)
        Me.PagePrincipal.Controls.Add(Label10)
        Me.PagePrincipal.Controls.Add(Me.dtpFechaProyecto)
        Me.PagePrincipal.Controls.Add(NUMEVENTOLabel)
        Me.PagePrincipal.Location = New System.Drawing.Point(4, 28)
        Me.PagePrincipal.Name = "PagePrincipal"
        Me.PagePrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.PagePrincipal.Size = New System.Drawing.Size(948, 611)
        Me.PagePrincipal.TabIndex = 0
        Me.PagePrincipal.Text = "Principales"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.tbxObservacion)
        Me.Panel1.Controls.Add(Label13)
        Me.Panel1.Controls.Add(lblFechaSalida)
        Me.Panel1.Controls.Add(Label23)
        Me.Panel1.Controls.Add(Label24)
        Me.Panel1.Controls.Add(Label25)
        Me.Panel1.Controls.Add(Me.txtFechaSalida)
        Me.Panel1.Controls.Add(Me.txtLlegadaTransb)
        Me.Panel1.Controls.Add(Me.txtTransbSalida)
        Me.Panel1.Controls.Add(Me.txtFechaLlegada)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Label15)
        Me.Panel1.Controls.Add(Label20)
        Me.Panel1.Controls.Add(Me.pbxAsteriscoProv)
        Me.Panel1.Controls.Add(Me.cmbModoTransporte)
        Me.Panel1.Controls.Add(Me.pbxAgregarProveedor)
        Me.Panel1.Controls.Add(Me.cmbTipoEmbarque)
        Me.Panel1.Controls.Add(Me.cmbProveedorAgente)
        Me.Panel1.Controls.Add(Label16)
        Me.Panel1.Controls.Add(Label31)
        Me.Panel1.Controls.Add(Label17)
        Me.Panel1.Controls.Add(Me.tbxCantBultos)
        Me.Panel1.Controls.Add(Me.tbxMasterDoc)
        Me.Panel1.Controls.Add(Me.tbxPesoBruto)
        Me.Panel1.Controls.Add(Me.cmbFormaPagoHouse)
        Me.Panel1.Controls.Add(Label34)
        Me.Panel1.Controls.Add(Label26)
        Me.Panel1.Controls.Add(Me.tbxVolumen)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Controls.Add(Label33)
        Me.Panel1.Controls.Add(Me.cmbIncoterm)
        Me.Panel1.Controls.Add(Label32)
        Me.Panel1.Controls.Add(Me.tbxCodIncoterm)
        Me.Panel1.Controls.Add(Label30)
        Me.Panel1.Controls.Add(Me.cmbSeguroCarga)
        Me.Panel1.Controls.Add(Label29)
        Me.Panel1.Controls.Add(Label21)
        Me.Panel1.Controls.Add(Me.tbxDimensiones)
        Me.Panel1.Controls.Add(Me.cmbCiudadOrigen)
        Me.Panel1.Controls.Add(Me.tbxMercaderia)
        Me.Panel1.Controls.Add(DESTINATARIOLabel)
        Me.Panel1.Controls.Add(Me.tbxZipCodeDestino)
        Me.Panel1.Controls.Add(Me.tbxCodCiudadOrigen)
        Me.Panel1.Controls.Add(Label8)
        Me.Panel1.Controls.Add(Me.cmbCiudadDestino)
        Me.Panel1.Controls.Add(Me.tbxZipCodeOrigen)
        Me.Panel1.Controls.Add(Me.tbxCodCiudadDestino)
        Me.Panel1.Controls.Add(Label1)
        Me.Panel1.Location = New System.Drawing.Point(6, 300)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 305)
        Me.Panel1.TabIndex = 644
        '
        'tbxObservacion
        '
        Me.tbxObservacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxObservacion.Location = New System.Drawing.Point(141, 355)
        Me.tbxObservacion.Name = "tbxObservacion"
        Me.tbxObservacion.Size = New System.Drawing.Size(769, 24)
        Me.tbxObservacion.TabIndex = 652
        '
        'txtFechaSalida
        '
        Me.txtFechaSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtFechaSalida.Location = New System.Drawing.Point(143, 291)
        Me.txtFechaSalida.Mask = "00/00/0000"
        Me.txtFechaSalida.Name = "txtFechaSalida"
        Me.txtFechaSalida.Size = New System.Drawing.Size(130, 26)
        Me.txtFechaSalida.TabIndex = 643
        Me.txtFechaSalida.ValidatingType = GetType(Date)
        '
        'txtLlegadaTransb
        '
        Me.txtLlegadaTransb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLlegadaTransb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtLlegadaTransb.Location = New System.Drawing.Point(143, 323)
        Me.txtLlegadaTransb.Mask = "00/00/0000"
        Me.txtLlegadaTransb.Name = "txtLlegadaTransb"
        Me.txtLlegadaTransb.Size = New System.Drawing.Size(130, 26)
        Me.txtLlegadaTransb.TabIndex = 644
        Me.txtLlegadaTransb.ValidatingType = GetType(Date)
        '
        'txtTransbSalida
        '
        Me.txtTransbSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransbSalida.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtTransbSalida.Location = New System.Drawing.Point(593, 291)
        Me.txtTransbSalida.Mask = "00/00/0000"
        Me.txtTransbSalida.Name = "txtTransbSalida"
        Me.txtTransbSalida.Size = New System.Drawing.Size(130, 26)
        Me.txtTransbSalida.TabIndex = 645
        Me.txtTransbSalida.ValidatingType = GetType(Date)
        '
        'txtFechaLlegada
        '
        Me.txtFechaLlegada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaLlegada.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtFechaLlegada.Location = New System.Drawing.Point(593, 323)
        Me.txtFechaLlegada.Mask = "00/00/0000"
        Me.txtFechaLlegada.Name = "txtFechaLlegada"
        Me.txtFechaLlegada.Size = New System.Drawing.Size(130, 26)
        Me.txtFechaLlegada.TabIndex = 646
        Me.txtFechaLlegada.ValidatingType = GetType(Date)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Light", 17.0!)
        Me.Label9.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label9.Location = New System.Drawing.Point(4, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 31)
        Me.Label9.TabIndex = 642
        Me.Label9.Text = "Info de Carga"
        '
        'pbxAsteriscoProv
        '
        Me.pbxAsteriscoProv.BackColor = System.Drawing.Color.Transparent
        Me.pbxAsteriscoProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbxAsteriscoProv.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAsteriscoProv.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.pbxAsteriscoProv.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxAsteriscoProv.Location = New System.Drawing.Point(409, 259)
        Me.pbxAsteriscoProv.Name = "pbxAsteriscoProv"
        Me.pbxAsteriscoProv.Size = New System.Drawing.Size(24, 26)
        Me.pbxAsteriscoProv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAsteriscoProv.TabIndex = 641
        Me.pbxAsteriscoProv.TabStop = False
        '
        'cmbModoTransporte
        '
        Me.cmbModoTransporte.DataSource = Me.EVENTOBindingSource
        Me.cmbModoTransporte.DisplayMember = "MODOTRANS"
        Me.cmbModoTransporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbModoTransporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModoTransporte.FormattingEnabled = True
        Me.cmbModoTransporte.Location = New System.Drawing.Point(142, 37)
        Me.cmbModoTransporte.Name = "cmbModoTransporte"
        Me.cmbModoTransporte.Size = New System.Drawing.Size(318, 26)
        Me.cmbModoTransporte.TabIndex = 537
        Me.cmbModoTransporte.ValueMember = "MODOTRANS"
        '
        'EVENTOBindingSource
        '
        Me.EVENTOBindingSource.DataMember = "EVENTO"
        Me.EVENTOBindingSource.DataSource = Me.DsEventos
        '
        'DsEventos
        '
        Me.DsEventos.DataSetName = "DsEventos"
        Me.DsEventos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pbxAgregarProveedor
        '
        Me.pbxAgregarProveedor.BackColor = System.Drawing.Color.Transparent
        Me.pbxAgregarProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pbxAgregarProveedor.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxAgregarProveedor.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.pbxAgregarProveedor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbxAgregarProveedor.Location = New System.Drawing.Point(436, 259)
        Me.pbxAgregarProveedor.Name = "pbxAgregarProveedor"
        Me.pbxAgregarProveedor.Size = New System.Drawing.Size(24, 26)
        Me.pbxAgregarProveedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbxAgregarProveedor.TabIndex = 640
        Me.pbxAgregarProveedor.TabStop = False
        '
        'cmbTipoEmbarque
        '
        Me.cmbTipoEmbarque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoEmbarque.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEmbarque.FormattingEnabled = True
        Me.cmbTipoEmbarque.Items.AddRange(New Object() {"FCL/FCL", "LCL/LCL", "RO-RO", "REEFER", "B.BULLK"})
        Me.cmbTipoEmbarque.Location = New System.Drawing.Point(142, 69)
        Me.cmbTipoEmbarque.Name = "cmbTipoEmbarque"
        Me.cmbTipoEmbarque.Size = New System.Drawing.Size(318, 26)
        Me.cmbTipoEmbarque.TabIndex = 538
        '
        'cmbProveedorAgente
        '
        Me.cmbProveedorAgente.DisplayMember = "NOMBRE"
        Me.cmbProveedorAgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbProveedorAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProveedorAgente.FormattingEnabled = True
        Me.cmbProveedorAgente.Location = New System.Drawing.Point(143, 258)
        Me.cmbProveedorAgente.Name = "cmbProveedorAgente"
        Me.cmbProveedorAgente.Size = New System.Drawing.Size(261, 26)
        Me.cmbProveedorAgente.TabIndex = 639
        Me.cmbProveedorAgente.ValueMember = "CODPROVEEDOR"
        '
        'tbxCantBultos
        '
        Me.tbxCantBultos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCantBultos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCantBultos.Location = New System.Drawing.Point(593, 227)
        Me.tbxCantBultos.Name = "tbxCantBultos"
        Me.tbxCantBultos.Size = New System.Drawing.Size(317, 24)
        Me.tbxCantBultos.TabIndex = 632
        '
        'tbxMasterDoc
        '
        Me.tbxMasterDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMasterDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMasterDoc.Location = New System.Drawing.Point(143, 101)
        Me.tbxMasterDoc.Name = "tbxMasterDoc"
        Me.tbxMasterDoc.Size = New System.Drawing.Size(317, 24)
        Me.tbxMasterDoc.TabIndex = 540
        '
        'tbxPesoBruto
        '
        Me.tbxPesoBruto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxPesoBruto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxPesoBruto.Location = New System.Drawing.Point(593, 259)
        Me.tbxPesoBruto.Name = "tbxPesoBruto"
        Me.tbxPesoBruto.Size = New System.Drawing.Size(317, 24)
        Me.tbxPesoBruto.TabIndex = 637
        '
        'cmbFormaPagoHouse
        '
        Me.cmbFormaPagoHouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbFormaPagoHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPagoHouse.FormattingEnabled = True
        Me.cmbFormaPagoHouse.Items.AddRange(New Object() {"PREPAID", "COLLECT"})
        Me.cmbFormaPagoHouse.Location = New System.Drawing.Point(593, 101)
        Me.cmbFormaPagoHouse.Name = "cmbFormaPagoHouse"
        Me.cmbFormaPagoHouse.Size = New System.Drawing.Size(317, 26)
        Me.cmbFormaPagoHouse.TabIndex = 543
        '
        'tbxVolumen
        '
        Me.tbxVolumen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxVolumen.Location = New System.Drawing.Point(593, 195)
        Me.tbxVolumen.Name = "tbxVolumen"
        Me.tbxVolumen.Size = New System.Drawing.Size(317, 24)
        Me.tbxVolumen.TabIndex = 635
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(479, 74)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(99, 17)
        Me.Label27.TabIndex = 555
        Me.Label27.Text = "Cod. Incoterm:"
        '
        'cmbIncoterm
        '
        Me.cmbIncoterm.DisplayMember = "DESINCOTERM"
        Me.cmbIncoterm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbIncoterm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIncoterm.FormattingEnabled = True
        Me.cmbIncoterm.Location = New System.Drawing.Point(651, 69)
        Me.cmbIncoterm.Name = "cmbIncoterm"
        Me.cmbIncoterm.Size = New System.Drawing.Size(259, 26)
        Me.cmbIncoterm.TabIndex = 556
        Me.cmbIncoterm.ValueMember = "IDINCOTERM"
        '
        'tbxCodIncoterm
        '
        Me.tbxCodIncoterm.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodIncoterm.Location = New System.Drawing.Point(593, 71)
        Me.tbxCodIncoterm.Name = "tbxCodIncoterm"
        Me.tbxCodIncoterm.Size = New System.Drawing.Size(52, 24)
        Me.tbxCodIncoterm.TabIndex = 557
        '
        'cmbSeguroCarga
        '
        Me.cmbSeguroCarga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSeguroCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeguroCarga.FormattingEnabled = True
        Me.cmbSeguroCarga.Items.AddRange(New Object() {"Sin Seguro", "C.T.R", "L.A.P"})
        Me.cmbSeguroCarga.Location = New System.Drawing.Point(593, 37)
        Me.cmbSeguroCarga.Name = "cmbSeguroCarga"
        Me.cmbSeguroCarga.Size = New System.Drawing.Size(317, 26)
        Me.cmbSeguroCarga.TabIndex = 539
        '
        'tbxDimensiones
        '
        Me.tbxDimensiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDimensiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDimensiones.Location = New System.Drawing.Point(142, 227)
        Me.tbxDimensiones.Name = "tbxDimensiones"
        Me.tbxDimensiones.Size = New System.Drawing.Size(317, 24)
        Me.tbxDimensiones.TabIndex = 629
        '
        'cmbCiudadOrigen
        '
        Me.cmbCiudadOrigen.DisplayMember = "DESCIUDAD"
        Me.cmbCiudadOrigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCiudadOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudadOrigen.FormattingEnabled = True
        Me.cmbCiudadOrigen.Location = New System.Drawing.Point(201, 133)
        Me.cmbCiudadOrigen.Name = "cmbCiudadOrigen"
        Me.cmbCiudadOrigen.Size = New System.Drawing.Size(259, 26)
        Me.cmbCiudadOrigen.TabIndex = 620
        Me.cmbCiudadOrigen.ValueMember = "IDCIUDAD"
        '
        'tbxMercaderia
        '
        Me.tbxMercaderia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMercaderia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMercaderia.Location = New System.Drawing.Point(142, 195)
        Me.tbxMercaderia.Name = "tbxMercaderia"
        Me.tbxMercaderia.Size = New System.Drawing.Size(317, 24)
        Me.tbxMercaderia.TabIndex = 628
        '
        'tbxZipCodeDestino
        '
        Me.tbxZipCodeDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxZipCodeDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxZipCodeDestino.Location = New System.Drawing.Point(593, 163)
        Me.tbxZipCodeDestino.Name = "tbxZipCodeDestino"
        Me.tbxZipCodeDestino.Size = New System.Drawing.Size(317, 24)
        Me.tbxZipCodeDestino.TabIndex = 627
        '
        'tbxCodCiudadOrigen
        '
        Me.tbxCodCiudadOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodCiudadOrigen.Location = New System.Drawing.Point(143, 133)
        Me.tbxCodCiudadOrigen.Name = "tbxCodCiudadOrigen"
        Me.tbxCodCiudadOrigen.Size = New System.Drawing.Size(52, 24)
        Me.tbxCodCiudadOrigen.TabIndex = 621
        '
        'cmbCiudadDestino
        '
        Me.cmbCiudadDestino.DisplayMember = "DESCIUDAD"
        Me.cmbCiudadDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCiudadDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCiudadDestino.FormattingEnabled = True
        Me.cmbCiudadDestino.Location = New System.Drawing.Point(651, 133)
        Me.cmbCiudadDestino.Name = "cmbCiudadDestino"
        Me.cmbCiudadDestino.Size = New System.Drawing.Size(259, 26)
        Me.cmbCiudadDestino.TabIndex = 622
        Me.cmbCiudadDestino.ValueMember = "IDCIUDAD"
        '
        'tbxZipCodeOrigen
        '
        Me.tbxZipCodeOrigen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxZipCodeOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxZipCodeOrigen.Location = New System.Drawing.Point(142, 163)
        Me.tbxZipCodeOrigen.Name = "tbxZipCodeOrigen"
        Me.tbxZipCodeOrigen.Size = New System.Drawing.Size(317, 24)
        Me.tbxZipCodeOrigen.TabIndex = 625
        '
        'tbxCodCiudadDestino
        '
        Me.tbxCodCiudadDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodCiudadDestino.Location = New System.Drawing.Point(593, 135)
        Me.tbxCodCiudadDestino.Name = "tbxCodCiudadDestino"
        Me.tbxCodCiudadDestino.Size = New System.Drawing.Size(52, 24)
        Me.tbxCodCiudadDestino.TabIndex = 623
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtUsuario.Location = New System.Drawing.Point(600, 42)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(317, 26)
        Me.txtUsuario.TabIndex = 643
        '
        'txtNroProyecto
        '
        Me.txtNroProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNroProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNroProyecto.Location = New System.Drawing.Point(149, 3)
        Me.txtNroProyecto.Name = "txtNroProyecto"
        Me.txtNroProyecto.Size = New System.Drawing.Size(212, 26)
        Me.txtNroProyecto.TabIndex = 532
        '
        'txtIdOT
        '
        Me.txtIdOT.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtIdOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.txtIdOT.Location = New System.Drawing.Point(2341, 347)
        Me.txtIdOT.Multiline = True
        Me.txtIdOT.Name = "txtIdOT"
        Me.txtIdOT.Size = New System.Drawing.Size(35, 26)
        Me.txtIdOT.TabIndex = 524
        '
        'tbxCodCodigo
        '
        Me.tbxCodCodigo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tbxCodCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCodCodigo.Enabled = False
        Me.tbxCodCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.tbxCodCodigo.Location = New System.Drawing.Point(1489, 347)
        Me.tbxCodCodigo.Multiline = True
        Me.tbxCodCodigo.Name = "tbxCodCodigo"
        Me.tbxCodCodigo.Size = New System.Drawing.Size(27, 14)
        Me.tbxCodCodigo.TabIndex = 521
        '
        'pnlCliente
        '
        Me.pnlCliente.BackColor = System.Drawing.Color.LightGray
        Me.pnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCliente.Controls.Add(Me.Label7)
        Me.pnlCliente.Controls.Add(Label40)
        Me.pnlCliente.Controls.Add(Me.tbxMailContacto)
        Me.pnlCliente.Controls.Add(Me.cmbCliente)
        Me.pnlCliente.Controls.Add(Label6)
        Me.pnlCliente.Controls.Add(Me.PictureBox10)
        Me.pnlCliente.Controls.Add(Me.tbxCelContacto)
        Me.pnlCliente.Controls.Add(Me.PictureBox9)
        Me.pnlCliente.Controls.Add(Label5)
        Me.pnlCliente.Controls.Add(Label41)
        Me.pnlCliente.Controls.Add(Me.tbxRuc)
        Me.pnlCliente.Controls.Add(Label42)
        Me.pnlCliente.Controls.Add(Label4)
        Me.pnlCliente.Controls.Add(Me.tbxDireccion)
        Me.pnlCliente.Controls.Add(Me.tbxShpr)
        Me.pnlCliente.Controls.Add(Me.tbxTelefono)
        Me.pnlCliente.Controls.Add(Label3)
        Me.pnlCliente.Controls.Add(Label2)
        Me.pnlCliente.Controls.Add(Me.tbxContacto)
        Me.pnlCliente.Location = New System.Drawing.Point(7, 104)
        Me.pnlCliente.Name = "pnlCliente"
        Me.pnlCliente.Size = New System.Drawing.Size(935, 190)
        Me.pnlCliente.TabIndex = 617
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Light", 17.0!)
        Me.Label7.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label7.Location = New System.Drawing.Point(3, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(154, 31)
        Me.Label7.TabIndex = 617
        Me.Label7.Text = "Info de Cliente"
        '
        'tbxMailContacto
        '
        Me.tbxMailContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMailContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMailContacto.Location = New System.Drawing.Point(591, 129)
        Me.tbxMailContacto.Name = "tbxMailContacto"
        Me.tbxMailContacto.Size = New System.Drawing.Size(317, 24)
        Me.tbxMailContacto.TabIndex = 616
        '
        'cmbCliente
        '
        Me.cmbCliente.DisplayMember = "CODCLIENTE"
        Me.cmbCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCliente.FormattingEnabled = True
        Me.cmbCliente.Location = New System.Drawing.Point(141, 37)
        Me.cmbCliente.Name = "cmbCliente"
        Me.cmbCliente.Size = New System.Drawing.Size(317, 26)
        Me.cmbCliente.TabIndex = 593
        Me.cmbCliente.ValueMember = "CODCLIENTE"
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox10.Image = Global.ContaExpress.My.Resources.Resources.Aster
        Me.PictureBox10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox10.Location = New System.Drawing.Point(464, 37)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox10.TabIndex = 585
        Me.PictureBox10.TabStop = False
        '
        'tbxCelContacto
        '
        Me.tbxCelContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCelContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCelContacto.Location = New System.Drawing.Point(591, 99)
        Me.tbxCelContacto.Name = "tbxCelContacto"
        Me.tbxCelContacto.Size = New System.Drawing.Size(317, 24)
        Me.tbxCelContacto.TabIndex = 614
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox9.Image = Global.ContaExpress.My.Resources.Resources.UserActive
        Me.PictureBox9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox9.Location = New System.Drawing.Point(492, 37)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(24, 26)
        Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox9.TabIndex = 586
        Me.PictureBox9.TabStop = False
        '
        'tbxRuc
        '
        Me.tbxRuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxRuc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRuc.Location = New System.Drawing.Point(140, 69)
        Me.tbxRuc.Name = "tbxRuc"
        Me.tbxRuc.Size = New System.Drawing.Size(317, 24)
        Me.tbxRuc.TabIndex = 612
        '
        'tbxDireccion
        '
        Me.tbxDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxDireccion.Location = New System.Drawing.Point(591, 69)
        Me.tbxDireccion.Name = "tbxDireccion"
        Me.tbxDireccion.Size = New System.Drawing.Size(317, 24)
        Me.tbxDireccion.TabIndex = 605
        '
        'tbxShpr
        '
        Me.tbxShpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxShpr.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxShpr.Location = New System.Drawing.Point(140, 159)
        Me.tbxShpr.Name = "tbxShpr"
        Me.tbxShpr.Size = New System.Drawing.Size(317, 24)
        Me.tbxShpr.TabIndex = 610
        '
        'tbxTelefono
        '
        Me.tbxTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxTelefono.Location = New System.Drawing.Point(139, 130)
        Me.tbxTelefono.Name = "tbxTelefono"
        Me.tbxTelefono.Size = New System.Drawing.Size(317, 24)
        Me.tbxTelefono.TabIndex = 606
        '
        'tbxContacto
        '
        Me.tbxContacto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxContacto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxContacto.Location = New System.Drawing.Point(139, 99)
        Me.tbxContacto.Name = "tbxContacto"
        Me.tbxContacto.Size = New System.Drawing.Size(317, 24)
        Me.tbxContacto.TabIndex = 608
        '
        'cmbEstado
        '
        Me.cmbEstado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEstado.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cmbEstado.DisplayMember = "ESTADOSEG"
        Me.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(600, 3)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(329, 26)
        Me.cmbEstado.TabIndex = 603
        Me.cmbEstado.ValueMember = "ESTADOSEG"
        '
        'rbnExterior
        '
        Me.rbnExterior.AutoSize = True
        Me.rbnExterior.Location = New System.Drawing.Point(402, 65)
        Me.rbnExterior.Name = "rbnExterior"
        Me.rbnExterior.Size = New System.Drawing.Size(74, 21)
        Me.rbnExterior.TabIndex = 560
        Me.rbnExterior.TabStop = True
        Me.rbnExterior.Text = "Exterior"
        Me.rbnExterior.UseVisualStyleBackColor = True
        '
        'rbnExport
        '
        Me.rbnExport.AutoSize = True
        Me.rbnExport.Location = New System.Drawing.Point(402, 38)
        Me.rbnExport.Name = "rbnExport"
        Me.rbnExport.Size = New System.Drawing.Size(66, 21)
        Me.rbnExport.TabIndex = 559
        Me.rbnExport.TabStop = True
        Me.rbnExport.Text = "Export"
        Me.rbnExport.UseVisualStyleBackColor = True
        '
        'rbnImport
        '
        Me.rbnImport.AutoSize = True
        Me.rbnImport.Location = New System.Drawing.Point(402, 11)
        Me.rbnImport.Name = "rbnImport"
        Me.rbnImport.Size = New System.Drawing.Size(65, 21)
        Me.rbnImport.TabIndex = 558
        Me.rbnImport.TabStop = True
        Me.rbnImport.Text = "Import"
        Me.rbnImport.UseVisualStyleBackColor = True
        '
        'dtpFechaCotizacion
        '
        Me.dtpFechaCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.dtpFechaCotizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaCotizacion.Location = New System.Drawing.Point(149, 72)
        Me.dtpFechaCotizacion.Mask = "00/00/0000"
        Me.dtpFechaCotizacion.Name = "dtpFechaCotizacion"
        Me.dtpFechaCotizacion.Size = New System.Drawing.Size(129, 26)
        Me.dtpFechaCotizacion.TabIndex = 536
        Me.dtpFechaCotizacion.ValidatingType = GetType(Date)
        '
        'dtpFechaProyecto
        '
        Me.dtpFechaProyecto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.dtpFechaProyecto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaProyecto.Location = New System.Drawing.Point(149, 38)
        Me.dtpFechaProyecto.Name = "dtpFechaProyecto"
        Me.dtpFechaProyecto.Size = New System.Drawing.Size(129, 26)
        Me.dtpFechaProyecto.TabIndex = 535
        '
        'tabEventos
        '
        Me.tabEventos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabEventos.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabEventos.Controls.Add(Me.PagePrincipal)
        Me.tabEventos.Controls.Add(Me.TabPage1)
        Me.tabEventos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.tabEventos.Location = New System.Drawing.Point(1, 36)
        Me.tabEventos.Name = "tabEventos"
        Me.tabEventos.SelectedIndex = 0
        Me.tabEventos.Size = New System.Drawing.Size(956, 643)
        Me.tabEventos.TabIndex = 555
        Me.tabEventos.Tag = ""
        '
        'EVENTOTableAdapter
        '
        Me.EVENTOTableAdapter.ClearBeforeFill = True
        '
        'ProyectosV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(958, 675)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.tabEventos)
        Me.Name = "ProyectosV2"
        Me.Text = "ProyectosV2"
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.pbxImprimir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxActivoInactivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CancelarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GuardarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ModificarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EliminarPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NuevoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxResfresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgwComentarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PagePrincipal.ResumeLayout(False)
        Me.PagePrincipal.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbxAsteriscoProv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EVENTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsEventos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxAgregarProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCliente.ResumeLayout(False)
        Me.pnlCliente.PerformLayout()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabEventos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents pbxImprimir As System.Windows.Forms.PictureBox
    Friend WithEvents pbxActivoInactivo As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents CancelarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuardarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents ModificarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EliminarPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents NuevoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PagePrincipal As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tbxObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaSalida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtLlegadaTransb As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTransbSalida As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtFechaLlegada As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pbxAsteriscoProv As System.Windows.Forms.PictureBox
    Friend WithEvents cmbModoTransporte As System.Windows.Forms.ComboBox
    Friend WithEvents pbxAgregarProveedor As System.Windows.Forms.PictureBox
    Friend WithEvents cmbTipoEmbarque As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProveedorAgente As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCantBultos As System.Windows.Forms.TextBox
    Friend WithEvents tbxMasterDoc As System.Windows.Forms.TextBox
    Friend WithEvents tbxPesoBruto As System.Windows.Forms.TextBox
    Friend WithEvents cmbFormaPagoHouse As System.Windows.Forms.ComboBox
    Friend WithEvents tbxVolumen As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cmbIncoterm As System.Windows.Forms.ComboBox
    Friend WithEvents tbxCodIncoterm As System.Windows.Forms.TextBox
    Friend WithEvents cmbSeguroCarga As System.Windows.Forms.ComboBox
    Friend WithEvents tbxDimensiones As System.Windows.Forms.TextBox
    Friend WithEvents cmbCiudadOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents tbxMercaderia As System.Windows.Forms.TextBox
    Friend WithEvents tbxZipCodeDestino As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodCiudadOrigen As System.Windows.Forms.TextBox
    Friend WithEvents cmbCiudadDestino As System.Windows.Forms.ComboBox
    Friend WithEvents tbxZipCodeOrigen As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodCiudadDestino As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtNroProyecto As System.Windows.Forms.TextBox
    Friend WithEvents txtIdOT As System.Windows.Forms.TextBox
    Friend WithEvents tbxCodCodigo As System.Windows.Forms.TextBox
    Friend WithEvents pnlCliente As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tbxMailContacto As System.Windows.Forms.TextBox
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxCelContacto As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents tbxRuc As System.Windows.Forms.TextBox
    Friend WithEvents tbxDireccion As System.Windows.Forms.TextBox
    Friend WithEvents tbxShpr As System.Windows.Forms.TextBox
    Friend WithEvents tbxTelefono As System.Windows.Forms.TextBox
    Friend WithEvents tbxContacto As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents rbnExterior As System.Windows.Forms.RadioButton
    Friend WithEvents rbnExport As System.Windows.Forms.RadioButton
    Friend WithEvents rbnImport As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFechaCotizacion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents dtpFechaProyecto As System.Windows.Forms.DateTimePicker
    Friend WithEvents tabEventos As System.Windows.Forms.TabControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtBuscarSeguimiento As System.Windows.Forms.TextBox
    Friend WithEvents pbxResfresh As System.Windows.Forms.PictureBox
    Friend WithEvents btnInsertarComentario As System.Windows.Forms.Button
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dgwComentarios As System.Windows.Forms.DataGridView
    Friend WithEvents DsEventos As ContaExpress.DsEventos
    Friend WithEvents EVENTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EVENTOTableAdapter As ContaExpress.DsEventosTableAdapters.EVENTOTableAdapter
End Class
