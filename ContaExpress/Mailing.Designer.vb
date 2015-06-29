<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MailingMail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MailingMail))
        Me.DsMassEmailingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsMassEmailing = New ContaExpress.DsMassEmailing()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbxEnviarEmail = New System.Windows.Forms.PictureBox()
        Me.pbxPublico = New System.Windows.Forms.PictureBox()
        Me.pbxNuevoEmail = New System.Windows.Forms.PictureBox()
        Me.pbxVistaPrevia = New System.Windows.Forms.PictureBox()
        Me.pbxHtml = New System.Windows.Forms.PictureBox()
        Me.pbxMensajeEmail = New System.Windows.Forms.PictureBox()
        Me.pnlEmailBody = New System.Windows.Forms.Panel()
        Me.btAplicarEstilos = New System.Windows.Forms.Button()
        Me.btnEstiloDer = New System.Windows.Forms.Button()
        Me.btnEstiloCentro = New System.Windows.Forms.Button()
        Me.btnEstiloIzq = New System.Windows.Forms.Button()
        Me.btnEstiloColor = New System.Windows.Forms.Button()
        Me.btnColorSel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnLinea = New System.Windows.Forms.Button()
        Me.btnItalico = New System.Windows.Forms.Button()
        Me.btnNegrita = New System.Windows.Forms.Button()
        Me.btnH2 = New System.Windows.Forms.Button()
        Me.btnP = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExaminar = New System.Windows.Forms.Button()
        Me.tbxMessageBody = New System.Windows.Forms.TextBox()
        Me.txtAsunto = New System.Windows.Forms.TextBox()
        Me.tbxImage = New System.Windows.Forms.TextBox()
        Me.tbxColorFondo = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblCampaignName = New System.Windows.Forms.Label()
        Me.tbxCampaignName = New System.Windows.Forms.TextBox()
        Me.colorMailingBackground = New System.Windows.Forms.ColorDialog()
        Me.pnlHTML = New System.Windows.Forms.Panel()
        Me.tbxHTMLHead = New System.Windows.Forms.TextBox()
        Me.tbxHTMLBody = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlVistaPrevia = New System.Windows.Forms.Panel()
        Me.wwwVistaPrevia = New System.Windows.Forms.WebBrowser()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.pnlPublico = New System.Windows.Forms.Panel()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.BuscarTextBox = New System.Windows.Forms.TextBox()
        Me.cmbMesHasta = New System.Windows.Forms.ComboBox()
        Me.cmbMesDesde = New System.Windows.Forms.ComboBox()
        Me.cmbDiaHasta = New System.Windows.Forms.ComboBox()
        Me.cmbDiaDesde = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbListaPrecio = New System.Windows.Forms.ComboBox()
        Me.TIPOCLIENTEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvListaCliente = New System.Windows.Forms.DataGridView()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENTESMTKBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgvTipoCliente = New System.Windows.Forms.DataGridView()
        Me.Agregar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CODTIPOCLIENTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTIPOCLIENTE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtCodEmail = New System.Windows.Forms.TextBox()
        Me.CLIENTESBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CLIENTESTableAdapter = New ContaExpress.DsMassEmailingTableAdapters.CLIENTESTableAdapter()
        Me.TIPOCLIENTETableAdapter = New ContaExpress.DsMassEmailingTableAdapters.TIPOCLIENTETableAdapter()
        Me.DETALLEEMAILBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DETALLEEMAILTableAdapter = New ContaExpress.DsMassEmailingTableAdapters.DETALLEEMAILTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsMassEmailingTableAdapters.TableAdapterManager()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblEnviados = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pgBarEnviado = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlMensajeError = New System.Windows.Forms.Panel()
        Me.lblMalisError = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbxCadenaError = New System.Windows.Forms.TextBox()
        Me.CLIENTESMKTTableAdapter = New ContaExpress.DsMassEmailingTableAdapters.CLIENTESMKTTableAdapter()
        CType(Me.DsMassEmailingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsMassEmailing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbxEnviarEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxPublico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxNuevoEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxHtml, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxMensajeEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmailBody.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlHTML.SuspendLayout()
        Me.pnlVistaPrevia.SuspendLayout()
        Me.pnlPublico.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvListaCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESMTKBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTipoCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DETALLEEMAILBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlMensajeError.SuspendLayout()
        Me.SuspendLayout()
        '
        'DsMassEmailingBindingSource
        '
        Me.DsMassEmailingBindingSource.DataSource = Me.DsMassEmailing
        Me.DsMassEmailingBindingSource.Position = 0
        '
        'DsMassEmailing
        '
        Me.DsMassEmailing.DataSetName = "DsMassEmailing"
        Me.DsMassEmailing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Tan
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.pbxEnviarEmail)
        Me.Panel1.Controls.Add(Me.pbxPublico)
        Me.Panel1.Controls.Add(Me.pbxNuevoEmail)
        Me.Panel1.Controls.Add(Me.pbxVistaPrevia)
        Me.Panel1.Controls.Add(Me.pbxHtml)
        Me.Panel1.Controls.Add(Me.pbxMensajeEmail)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1010, 40)
        Me.Panel1.TabIndex = 1
        '
        'pbxEnviarEmail
        '
        Me.pbxEnviarEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxEnviarEmail.BackColor = System.Drawing.Color.Transparent
        Me.pbxEnviarEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxEnviarEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxEnviarEmail.Image = Global.ContaExpress.My.Resources.Resources.SendEmailOff
        Me.pbxEnviarEmail.Location = New System.Drawing.Point(53, 2)
        Me.pbxEnviarEmail.Name = "pbxEnviarEmail"
        Me.pbxEnviarEmail.Size = New System.Drawing.Size(35, 35)
        Me.pbxEnviarEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxEnviarEmail.TabIndex = 9
        Me.pbxEnviarEmail.TabStop = False
        '
        'pbxPublico
        '
        Me.pbxPublico.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxPublico.BackColor = System.Drawing.Color.Transparent
        Me.pbxPublico.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxPublico.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxPublico.Image = Global.ContaExpress.My.Resources.Resources.User
        Me.pbxPublico.Location = New System.Drawing.Point(933, 2)
        Me.pbxPublico.Name = "pbxPublico"
        Me.pbxPublico.Size = New System.Drawing.Size(35, 35)
        Me.pbxPublico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxPublico.TabIndex = 11
        Me.pbxPublico.TabStop = False
        '
        'pbxNuevoEmail
        '
        Me.pbxNuevoEmail.BackColor = System.Drawing.Color.Transparent
        Me.pbxNuevoEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxNuevoEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxNuevoEmail.Image = Global.ContaExpress.My.Resources.Resources.New_
        Me.pbxNuevoEmail.Location = New System.Drawing.Point(12, 2)
        Me.pbxNuevoEmail.Name = "pbxNuevoEmail"
        Me.pbxNuevoEmail.Size = New System.Drawing.Size(35, 35)
        Me.pbxNuevoEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxNuevoEmail.TabIndex = 9
        Me.pbxNuevoEmail.TabStop = False
        '
        'pbxVistaPrevia
        '
        Me.pbxVistaPrevia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxVistaPrevia.BackColor = System.Drawing.Color.Transparent
        Me.pbxVistaPrevia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxVistaPrevia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxVistaPrevia.Image = Global.ContaExpress.My.Resources.Resources.Display
        Me.pbxVistaPrevia.Location = New System.Drawing.Point(895, 2)
        Me.pbxVistaPrevia.Name = "pbxVistaPrevia"
        Me.pbxVistaPrevia.Size = New System.Drawing.Size(35, 35)
        Me.pbxVistaPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxVistaPrevia.TabIndex = 9
        Me.pbxVistaPrevia.TabStop = False
        '
        'pbxHtml
        '
        Me.pbxHtml.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxHtml.BackColor = System.Drawing.Color.Transparent
        Me.pbxHtml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxHtml.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxHtml.Image = Global.ContaExpress.My.Resources.Resources.Html
        Me.pbxHtml.Location = New System.Drawing.Point(971, 2)
        Me.pbxHtml.Name = "pbxHtml"
        Me.pbxHtml.Size = New System.Drawing.Size(35, 35)
        Me.pbxHtml.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxHtml.TabIndex = 9
        Me.pbxHtml.TabStop = False
        Me.pbxHtml.Visible = False
        '
        'pbxMensajeEmail
        '
        Me.pbxMensajeEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxMensajeEmail.BackColor = System.Drawing.Color.Transparent
        Me.pbxMensajeEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbxMensajeEmail.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxMensajeEmail.Image = Global.ContaExpress.My.Resources.Resources.EmailMessage
        Me.pbxMensajeEmail.Location = New System.Drawing.Point(971, 2)
        Me.pbxMensajeEmail.Name = "pbxMensajeEmail"
        Me.pbxMensajeEmail.Size = New System.Drawing.Size(35, 35)
        Me.pbxMensajeEmail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbxMensajeEmail.TabIndex = 9
        Me.pbxMensajeEmail.TabStop = False
        '
        'pnlEmailBody
        '
        Me.pnlEmailBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlEmailBody.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlEmailBody.BackColor = System.Drawing.Color.DarkGray
        Me.pnlEmailBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEmailBody.Controls.Add(Me.btAplicarEstilos)
        Me.pnlEmailBody.Controls.Add(Me.btnEstiloDer)
        Me.pnlEmailBody.Controls.Add(Me.btnEstiloCentro)
        Me.pnlEmailBody.Controls.Add(Me.btnEstiloIzq)
        Me.pnlEmailBody.Controls.Add(Me.btnEstiloColor)
        Me.pnlEmailBody.Controls.Add(Me.btnColorSel)
        Me.pnlEmailBody.Controls.Add(Me.Label8)
        Me.pnlEmailBody.Controls.Add(Me.btnLinea)
        Me.pnlEmailBody.Controls.Add(Me.btnItalico)
        Me.pnlEmailBody.Controls.Add(Me.btnNegrita)
        Me.pnlEmailBody.Controls.Add(Me.btnH2)
        Me.pnlEmailBody.Controls.Add(Me.btnP)
        Me.pnlEmailBody.Controls.Add(Me.Label10)
        Me.pnlEmailBody.Controls.Add(Me.Label7)
        Me.pnlEmailBody.Controls.Add(Me.Label6)
        Me.pnlEmailBody.Controls.Add(Me.Label4)
        Me.pnlEmailBody.Controls.Add(Me.Label3)
        Me.pnlEmailBody.Controls.Add(Me.btnExaminar)
        Me.pnlEmailBody.Controls.Add(Me.tbxMessageBody)
        Me.pnlEmailBody.Controls.Add(Me.txtAsunto)
        Me.pnlEmailBody.Controls.Add(Me.tbxImage)
        Me.pnlEmailBody.Controls.Add(Me.tbxColorFondo)
        Me.pnlEmailBody.Location = New System.Drawing.Point(11, 114)
        Me.pnlEmailBody.Name = "pnlEmailBody"
        Me.pnlEmailBody.Size = New System.Drawing.Size(989, 443)
        Me.pnlEmailBody.TabIndex = 2
        '
        'btAplicarEstilos
        '
        Me.btAplicarEstilos.BackColor = System.Drawing.Color.Gainsboro
        Me.btAplicarEstilos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btAplicarEstilos.Location = New System.Drawing.Point(682, 152)
        Me.btAplicarEstilos.Name = "btAplicarEstilos"
        Me.btAplicarEstilos.Size = New System.Drawing.Size(94, 23)
        Me.btAplicarEstilos.TabIndex = 13
        Me.btAplicarEstilos.Text = "Aplicar Estilos"
        Me.btAplicarEstilos.UseVisualStyleBackColor = False
        '
        'btnEstiloDer
        '
        Me.btnEstiloDer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEstiloDer.BackColor = System.Drawing.Color.Silver
        Me.btnEstiloDer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstiloDer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnEstiloDer.ForeColor = System.Drawing.Color.Black
        Me.btnEstiloDer.Location = New System.Drawing.Point(589, 152)
        Me.btnEstiloDer.Name = "btnEstiloDer"
        Me.btnEstiloDer.Size = New System.Drawing.Size(91, 23)
        Me.btnEstiloDer.TabIndex = 12
        Me.btnEstiloDer.Text = "Alineacion Der."
        Me.btnEstiloDer.UseVisualStyleBackColor = False
        '
        'btnEstiloCentro
        '
        Me.btnEstiloCentro.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEstiloCentro.BackColor = System.Drawing.Color.Silver
        Me.btnEstiloCentro.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstiloCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnEstiloCentro.ForeColor = System.Drawing.Color.Black
        Me.btnEstiloCentro.Location = New System.Drawing.Point(496, 152)
        Me.btnEstiloCentro.Name = "btnEstiloCentro"
        Me.btnEstiloCentro.Size = New System.Drawing.Size(91, 23)
        Me.btnEstiloCentro.TabIndex = 11
        Me.btnEstiloCentro.Text = "Alin. Centrado"
        Me.btnEstiloCentro.UseVisualStyleBackColor = False
        '
        'btnEstiloIzq
        '
        Me.btnEstiloIzq.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEstiloIzq.BackColor = System.Drawing.Color.Silver
        Me.btnEstiloIzq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstiloIzq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnEstiloIzq.ForeColor = System.Drawing.Color.Black
        Me.btnEstiloIzq.Location = New System.Drawing.Point(403, 152)
        Me.btnEstiloIzq.Name = "btnEstiloIzq"
        Me.btnEstiloIzq.Size = New System.Drawing.Size(91, 23)
        Me.btnEstiloIzq.TabIndex = 11
        Me.btnEstiloIzq.Text = "Alineacion Izq."
        Me.btnEstiloIzq.UseVisualStyleBackColor = False
        '
        'btnEstiloColor
        '
        Me.btnEstiloColor.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEstiloColor.BackColor = System.Drawing.Color.Silver
        Me.btnEstiloColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEstiloColor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnEstiloColor.ForeColor = System.Drawing.Color.Maroon
        Me.btnEstiloColor.Location = New System.Drawing.Point(310, 152)
        Me.btnEstiloColor.Name = "btnEstiloColor"
        Me.btnEstiloColor.Size = New System.Drawing.Size(91, 23)
        Me.btnEstiloColor.TabIndex = 10
        Me.btnEstiloColor.Text = "Color de Texto"
        Me.btnEstiloColor.UseVisualStyleBackColor = False
        '
        'btnColorSel
        '
        Me.btnColorSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnColorSel.Location = New System.Drawing.Point(112, 403)
        Me.btnColorSel.Name = "btnColorSel"
        Me.btnColorSel.Size = New System.Drawing.Size(75, 27)
        Me.btnColorSel.TabIndex = 8
        Me.btnColorSel.Text = "Button1"
        Me.btnColorSel.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkGray
        Me.Label8.ForeColor = System.Drawing.Color.DimGray
        Me.Label8.Location = New System.Drawing.Point(110, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(488, 28)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Cargue el mensaje que queira mostrar aqui. Vendra antes del imagen. Utilice los b" & _
    "otones del costado para hacer sus textos lucir mas atractivos. Cargue los entre " & _
    "<> su texto </>"
        '
        'btnLinea
        '
        Me.btnLinea.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnLinea.BackColor = System.Drawing.Color.Silver
        Me.btnLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnLinea.ForeColor = System.Drawing.Color.Black
        Me.btnLinea.Location = New System.Drawing.Point(4, 313)
        Me.btnLinea.Name = "btnLinea"
        Me.btnLinea.Size = New System.Drawing.Size(106, 23)
        Me.btnLinea.TabIndex = 6
        Me.btnLinea.Text = "Linea Horizontal"
        Me.btnLinea.UseVisualStyleBackColor = False
        '
        'btnItalico
        '
        Me.btnItalico.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnItalico.BackColor = System.Drawing.Color.Silver
        Me.btnItalico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnItalico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnItalico.Location = New System.Drawing.Point(3, 284)
        Me.btnItalico.Name = "btnItalico"
        Me.btnItalico.Size = New System.Drawing.Size(106, 23)
        Me.btnItalico.TabIndex = 6
        Me.btnItalico.Text = "Italico"
        Me.btnItalico.UseVisualStyleBackColor = False
        '
        'btnNegrita
        '
        Me.btnNegrita.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnNegrita.BackColor = System.Drawing.Color.Silver
        Me.btnNegrita.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNegrita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNegrita.Location = New System.Drawing.Point(3, 257)
        Me.btnNegrita.Name = "btnNegrita"
        Me.btnNegrita.Size = New System.Drawing.Size(106, 23)
        Me.btnNegrita.TabIndex = 5
        Me.btnNegrita.Text = "Negrita"
        Me.btnNegrita.UseVisualStyleBackColor = False
        '
        'btnH2
        '
        Me.btnH2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnH2.BackColor = System.Drawing.Color.Silver
        Me.btnH2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnH2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnH2.Location = New System.Drawing.Point(3, 203)
        Me.btnH2.Name = "btnH2"
        Me.btnH2.Size = New System.Drawing.Size(106, 23)
        Me.btnH2.TabIndex = 4
        Me.btnH2.Text = "Titulo <h2>"
        Me.btnH2.UseVisualStyleBackColor = False
        '
        'btnP
        '
        Me.btnP.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnP.BackColor = System.Drawing.Color.Silver
        Me.btnP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP.Location = New System.Drawing.Point(3, 230)
        Me.btnP.Name = "btnP"
        Me.btnP.Size = New System.Drawing.Size(106, 23)
        Me.btnP.TabIndex = 4
        Me.btnP.Text = "¶ Parafo Nuevo"
        Me.btnP.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(58, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Asunto:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(47, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 16)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Mensaje:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(54, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Imagen:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 411)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Color Fondo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(168, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cuerpo del Mensaje"
        '
        'btnExaminar
        '
        Me.btnExaminar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnExaminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExaminar.Location = New System.Drawing.Point(671, 76)
        Me.btnExaminar.Name = "btnExaminar"
        Me.btnExaminar.Size = New System.Drawing.Size(106, 27)
        Me.btnExaminar.TabIndex = 1
        Me.btnExaminar.Text = "Examinar"
        Me.btnExaminar.UseVisualStyleBackColor = False
        '
        'tbxMessageBody
        '
        Me.tbxMessageBody.AcceptsReturn = True
        Me.tbxMessageBody.AcceptsTab = True
        Me.tbxMessageBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxMessageBody.BackColor = System.Drawing.Color.White
        Me.tbxMessageBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxMessageBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxMessageBody.Location = New System.Drawing.Point(112, 180)
        Me.tbxMessageBody.Multiline = True
        Me.tbxMessageBody.Name = "tbxMessageBody"
        Me.tbxMessageBody.Size = New System.Drawing.Size(869, 219)
        Me.tbxMessageBody.TabIndex = 0
        '
        'txtAsunto
        '
        Me.txtAsunto.BackColor = System.Drawing.Color.White
        Me.txtAsunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAsunto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAsunto.Location = New System.Drawing.Point(112, 43)
        Me.txtAsunto.Name = "txtAsunto"
        Me.txtAsunto.Size = New System.Drawing.Size(553, 27)
        Me.txtAsunto.TabIndex = 0
        '
        'tbxImage
        '
        Me.tbxImage.AcceptsReturn = True
        Me.tbxImage.BackColor = System.Drawing.Color.White
        Me.tbxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxImage.Location = New System.Drawing.Point(112, 76)
        Me.tbxImage.Name = "tbxImage"
        Me.tbxImage.Size = New System.Drawing.Size(553, 27)
        Me.tbxImage.TabIndex = 0
        '
        'tbxColorFondo
        '
        Me.tbxColorFondo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbxColorFondo.BackColor = System.Drawing.Color.White
        Me.tbxColorFondo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxColorFondo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxColorFondo.Location = New System.Drawing.Point(193, 403)
        Me.tbxColorFondo.Name = "tbxColorFondo"
        Me.tbxColorFondo.Size = New System.Drawing.Size(587, 27)
        Me.tbxColorFondo.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.lblCampaignName)
        Me.Panel3.Controls.Add(Me.tbxCampaignName)
        Me.Panel3.Location = New System.Drawing.Point(12, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(988, 50)
        Me.Panel3.TabIndex = 3
        '
        'lblCampaignName
        '
        Me.lblCampaignName.AutoSize = True
        Me.lblCampaignName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCampaignName.Location = New System.Drawing.Point(9, 16)
        Me.lblCampaignName.Name = "lblCampaignName"
        Me.lblCampaignName.Size = New System.Drawing.Size(95, 16)
        Me.lblCampaignName.TabIndex = 0
        Me.lblCampaignName.Text = "Descripcion:"
        '
        'tbxCampaignName
        '
        Me.tbxCampaignName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxCampaignName.BackColor = System.Drawing.Color.White
        Me.tbxCampaignName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCampaignName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCampaignName.Location = New System.Drawing.Point(104, 11)
        Me.tbxCampaignName.Name = "tbxCampaignName"
        Me.tbxCampaignName.Size = New System.Drawing.Size(873, 27)
        Me.tbxCampaignName.TabIndex = 3
        '
        'pnlHTML
        '
        Me.pnlHTML.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlHTML.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlHTML.BackColor = System.Drawing.Color.DarkGray
        Me.pnlHTML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHTML.Controls.Add(Me.tbxHTMLHead)
        Me.pnlHTML.Controls.Add(Me.tbxHTMLBody)
        Me.pnlHTML.Controls.Add(Me.Label9)
        Me.pnlHTML.Controls.Add(Me.Label1)
        Me.pnlHTML.Location = New System.Drawing.Point(11, 114)
        Me.pnlHTML.Name = "pnlHTML"
        Me.pnlHTML.Size = New System.Drawing.Size(989, 443)
        Me.pnlHTML.TabIndex = 3
        '
        'tbxHTMLHead
        '
        Me.tbxHTMLHead.AcceptsReturn = True
        Me.tbxHTMLHead.AcceptsTab = True
        Me.tbxHTMLHead.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxHTMLHead.BackColor = System.Drawing.Color.White
        Me.tbxHTMLHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxHTMLHead.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxHTMLHead.Location = New System.Drawing.Point(3, 26)
        Me.tbxHTMLHead.Multiline = True
        Me.tbxHTMLHead.Name = "tbxHTMLHead"
        Me.tbxHTMLHead.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbxHTMLHead.Size = New System.Drawing.Size(981, 74)
        Me.tbxHTMLHead.TabIndex = 0
        Me.tbxHTMLHead.Text = "<!DOCTYPE>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<HTML>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<HEAD>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</HEAD>"
        '
        'tbxHTMLBody
        '
        Me.tbxHTMLBody.AcceptsReturn = True
        Me.tbxHTMLBody.AcceptsTab = True
        Me.tbxHTMLBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxHTMLBody.BackColor = System.Drawing.Color.White
        Me.tbxHTMLBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxHTMLBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxHTMLBody.Location = New System.Drawing.Point(3, 106)
        Me.tbxHTMLBody.Multiline = True
        Me.tbxHTMLBody.Name = "tbxHTMLBody"
        Me.tbxHTMLBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbxHTMLBody.Size = New System.Drawing.Size(981, 332)
        Me.tbxHTMLBody.TabIndex = 0
        Me.tbxHTMLBody.Text = "<BODY>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</BODY>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</HTML>"
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(198, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(393, 18)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Evite el uso de Javascirpts para asegurar que su Correo no se clasifique como No " & _
    "Deseado"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-2, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Inserte su propio HTML"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'pnlVistaPrevia
        '
        Me.pnlVistaPrevia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlVistaPrevia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlVistaPrevia.BackColor = System.Drawing.Color.DarkGray
        Me.pnlVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlVistaPrevia.Controls.Add(Me.wwwVistaPrevia)
        Me.pnlVistaPrevia.Controls.Add(Me.Label5)
        Me.pnlVistaPrevia.Location = New System.Drawing.Point(11, 114)
        Me.pnlVistaPrevia.Name = "pnlVistaPrevia"
        Me.pnlVistaPrevia.Size = New System.Drawing.Size(989, 443)
        Me.pnlVistaPrevia.TabIndex = 4
        '
        'wwwVistaPrevia
        '
        Me.wwwVistaPrevia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wwwVistaPrevia.Location = New System.Drawing.Point(-1, 26)
        Me.wwwVistaPrevia.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wwwVistaPrevia.Name = "wwwVistaPrevia"
        Me.wwwVistaPrevia.Size = New System.Drawing.Size(989, 416)
        Me.wwwVistaPrevia.TabIndex = 2
        Me.wwwVistaPrevia.Url = New System.Uri("", System.UriKind.Relative)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(-2, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 25)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Vista Previa"
        '
        'pnlPublico
        '
        Me.pnlPublico.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlPublico.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlPublico.BackColor = System.Drawing.Color.DarkGray
        Me.pnlPublico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPublico.Controls.Add(Me.PictureBox8)
        Me.pnlPublico.Controls.Add(Me.BuscarTextBox)
        Me.pnlPublico.Controls.Add(Me.cmbMesHasta)
        Me.pnlPublico.Controls.Add(Me.cmbMesDesde)
        Me.pnlPublico.Controls.Add(Me.cmbDiaHasta)
        Me.pnlPublico.Controls.Add(Me.cmbDiaDesde)
        Me.pnlPublico.Controls.Add(Me.Label16)
        Me.pnlPublico.Controls.Add(Me.cmbListaPrecio)
        Me.pnlPublico.Controls.Add(Me.cmbSexo)
        Me.pnlPublico.Controls.Add(Me.Label18)
        Me.pnlPublico.Controls.Add(Me.Label19)
        Me.pnlPublico.Controls.Add(Me.Label20)
        Me.pnlPublico.Controls.Add(Me.Label17)
        Me.pnlPublico.Controls.Add(Me.Label14)
        Me.pnlPublico.Controls.Add(Me.Label12)
        Me.pnlPublico.Controls.Add(Me.Label13)
        Me.pnlPublico.Controls.Add(Me.Button1)
        Me.pnlPublico.Controls.Add(Me.dgvListaCliente)
        Me.pnlPublico.Controls.Add(Me.Label15)
        Me.pnlPublico.Controls.Add(Me.dgvTipoCliente)
        Me.pnlPublico.Controls.Add(Me.txtCodEmail)
        Me.pnlPublico.Location = New System.Drawing.Point(11, 114)
        Me.pnlPublico.Name = "pnlPublico"
        Me.pnlPublico.Size = New System.Drawing.Size(989, 443)
        Me.pnlPublico.TabIndex = 10
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.DarkGray
        Me.PictureBox8.BackgroundImage = Global.ContaExpress.My.Resources.Resources.SearchBigOff
        Me.PictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox8.Location = New System.Drawing.Point(313, 37)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox8.TabIndex = 463
        Me.PictureBox8.TabStop = False
        '
        'BuscarTextBox
        '
        Me.BuscarTextBox.BackColor = System.Drawing.Color.DarkGray
        Me.BuscarTextBox.CausesValidation = False
        Me.BuscarTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuscarTextBox.ForeColor = System.Drawing.Color.Black
        Me.BuscarTextBox.Location = New System.Drawing.Point(341, 37)
        Me.BuscarTextBox.Name = "BuscarTextBox"
        Me.BuscarTextBox.Size = New System.Drawing.Size(444, 30)
        Me.BuscarTextBox.TabIndex = 462
        '
        'cmbMesHasta
        '
        Me.cmbMesHasta.BackColor = System.Drawing.Color.White
        Me.cmbMesHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMesHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesHasta.FormattingEnabled = True
        Me.cmbMesHasta.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMesHasta.Location = New System.Drawing.Point(190, 110)
        Me.cmbMesHasta.Name = "cmbMesHasta"
        Me.cmbMesHasta.Size = New System.Drawing.Size(105, 26)
        Me.cmbMesHasta.TabIndex = 29
        Me.cmbMesHasta.Text = "Diciembre"
        '
        'cmbMesDesde
        '
        Me.cmbMesDesde.BackColor = System.Drawing.Color.White
        Me.cmbMesDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMesDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesDesde.FormattingEnabled = True
        Me.cmbMesDesde.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMesDesde.Location = New System.Drawing.Point(65, 110)
        Me.cmbMesDesde.Name = "cmbMesDesde"
        Me.cmbMesDesde.Size = New System.Drawing.Size(105, 26)
        Me.cmbMesDesde.TabIndex = 28
        Me.cmbMesDesde.Text = "Enero"
        '
        'cmbDiaHasta
        '
        Me.cmbDiaHasta.BackColor = System.Drawing.Color.White
        Me.cmbDiaHasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDiaHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiaHasta.FormattingEnabled = True
        Me.cmbDiaHasta.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbDiaHasta.Location = New System.Drawing.Point(190, 74)
        Me.cmbDiaHasta.Name = "cmbDiaHasta"
        Me.cmbDiaHasta.Size = New System.Drawing.Size(105, 26)
        Me.cmbDiaHasta.TabIndex = 27
        Me.cmbDiaHasta.Text = "31"
        '
        'cmbDiaDesde
        '
        Me.cmbDiaDesde.BackColor = System.Drawing.Color.White
        Me.cmbDiaDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbDiaDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiaDesde.FormattingEnabled = True
        Me.cmbDiaDesde.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cmbDiaDesde.Location = New System.Drawing.Point(65, 74)
        Me.cmbDiaDesde.Name = "cmbDiaDesde"
        Me.cmbDiaDesde.Size = New System.Drawing.Size(105, 26)
        Me.cmbDiaDesde.TabIndex = 26
        Me.cmbDiaDesde.Text = "1"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(7, 408)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(288, 28)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Presione F12 en los filtros Sexo y Lista de Precios para traer todos los datos en" & _
    " esos filtros"
        '
        'cmbListaPrecio
        '
        Me.cmbListaPrecio.BackColor = System.Drawing.Color.White
        Me.cmbListaPrecio.DataSource = Me.TIPOCLIENTEBindingSource
        Me.cmbListaPrecio.DisplayMember = "DESTIPOCLIENTE"
        Me.cmbListaPrecio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbListaPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbListaPrecio.FormattingEnabled = True
        Me.cmbListaPrecio.Location = New System.Drawing.Point(28, 245)
        Me.cmbListaPrecio.Name = "cmbListaPrecio"
        Me.cmbListaPrecio.Size = New System.Drawing.Size(175, 26)
        Me.cmbListaPrecio.TabIndex = 24
        Me.cmbListaPrecio.ValueMember = "CODTIPOCLIENTE"
        '
        'TIPOCLIENTEBindingSource
        '
        Me.TIPOCLIENTEBindingSource.DataMember = "TIPOCLIENTE"
        Me.TIPOCLIENTEBindingSource.DataSource = Me.DsMassEmailingBindingSource
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.Color.White
        Me.cmbSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Items.AddRange(New Object() {"Masculino", "Femenino"})
        Me.cmbSexo.Location = New System.Drawing.Point(28, 172)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(175, 26)
        Me.cmbSexo.TabIndex = 23
        Me.cmbSexo.Text = "%"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(172, 113)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 16)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "a"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(14, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 16)
        Me.Label19.TabIndex = 22
        Me.Label19.Text = "Día del"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(170, 78)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 16)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "al"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(14, 113)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 16)
        Me.Label17.TabIndex = 22
        Me.Label17.Text = "Mes de"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 149)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 16)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Sexo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 217)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 16)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Grupo:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 43)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(155, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Fecha de Nacimiento"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(238, 186)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(57, 74)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'dgvListaCliente
        '
        Me.dgvListaCliente.AllowUserToAddRows = False
        Me.dgvListaCliente.AutoGenerateColumns = False
        Me.dgvListaCliente.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvListaCliente.ColumnHeadersHeight = 35
        Me.dgvListaCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOMBRE, Me.EMAIL, Me.CODTIPOCLIENTEDataGridViewTextBoxColumn})
        Me.dgvListaCliente.DataSource = Me.CLIENTESMTKBindingSource
        Me.dgvListaCliente.Location = New System.Drawing.Point(313, 76)
        Me.dgvListaCliente.Name = "dgvListaCliente"
        Me.dgvListaCliente.ReadOnly = True
        Me.dgvListaCliente.RowHeadersWidth = 27
        Me.dgvListaCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvListaCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvListaCliente.Size = New System.Drawing.Size(472, 365)
        Me.dgvListaCliente.TabIndex = 10
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.HeaderText = "Cliente"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Width = 230
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.HeaderText = "Email"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        Me.EMAIL.Width = 220
        '
        'CODTIPOCLIENTEDataGridViewTextBoxColumn
        '
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Name = "CODTIPOCLIENTEDataGridViewTextBoxColumn"
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.ReadOnly = True
        Me.CODTIPOCLIENTEDataGridViewTextBoxColumn.Visible = False
        '
        'CLIENTESMTKBindingSource
        '
        Me.CLIENTESMTKBindingSource.DataMember = "CLIENTESMKT"
        Me.CLIENTESMTKBindingSource.DataSource = Me.DsMassEmailingBindingSource
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(189, 20)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Filtro Lista de Clientes"
        '
        'dgvTipoCliente
        '
        Me.dgvTipoCliente.AllowUserToAddRows = False
        Me.dgvTipoCliente.AllowUserToDeleteRows = False
        Me.dgvTipoCliente.AutoGenerateColumns = False
        Me.dgvTipoCliente.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvTipoCliente.ColumnHeadersHeight = 35
        Me.dgvTipoCliente.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Agregar, Me.CODTIPOCLIENTE, Me.DESTIPOCLIENTE1})
        Me.dgvTipoCliente.DataSource = Me.TIPOCLIENTEBindingSource
        Me.dgvTipoCliente.Location = New System.Drawing.Point(319, 339)
        Me.dgvTipoCliente.Name = "dgvTipoCliente"
        Me.dgvTipoCliente.RowHeadersVisible = False
        Me.dgvTipoCliente.Size = New System.Drawing.Size(65, 36)
        Me.dgvTipoCliente.TabIndex = 12
        Me.dgvTipoCliente.Visible = False
        '
        'Agregar
        '
        Me.Agregar.HeaderText = "Agregar"
        Me.Agregar.Name = "Agregar"
        Me.Agregar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Agregar.Width = 60
        '
        'CODTIPOCLIENTE
        '
        Me.CODTIPOCLIENTE.DataPropertyName = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.HeaderText = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.Name = "CODTIPOCLIENTE"
        Me.CODTIPOCLIENTE.Visible = False
        '
        'DESTIPOCLIENTE1
        '
        Me.DESTIPOCLIENTE1.DataPropertyName = "DESTIPOCLIENTE"
        Me.DESTIPOCLIENTE1.HeaderText = "Tipo de Cliente"
        Me.DESTIPOCLIENTE1.Name = "DESTIPOCLIENTE1"
        Me.DESTIPOCLIENTE1.Width = 150
        '
        'txtCodEmail
        '
        Me.txtCodEmail.BackColor = System.Drawing.Color.DarkGray
        Me.txtCodEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodEmail.Enabled = False
        Me.txtCodEmail.Location = New System.Drawing.Point(743, 4)
        Me.txtCodEmail.Name = "txtCodEmail"
        Me.txtCodEmail.ReadOnly = True
        Me.txtCodEmail.Size = New System.Drawing.Size(35, 20)
        Me.txtCodEmail.TabIndex = 13
        Me.txtCodEmail.Visible = False
        '
        'CLIENTESBindingSource
        '
        Me.CLIENTESBindingSource.DataMember = "CLIENTES"
        Me.CLIENTESBindingSource.DataSource = Me.DsMassEmailingBindingSource
        '
        'CLIENTESTableAdapter
        '
        Me.CLIENTESTableAdapter.ClearBeforeFill = True
        '
        'TIPOCLIENTETableAdapter
        '
        Me.TIPOCLIENTETableAdapter.ClearBeforeFill = True
        '
        'DETALLEEMAILBindingSource
        '
        Me.DETALLEEMAILBindingSource.DataMember = "DETALLEEMAIL"
        Me.DETALLEEMAILBindingSource.DataSource = Me.DsMassEmailing
        '
        'DETALLEEMAILTableAdapter
        '
        Me.DETALLEEMAILTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CATEGORIACLIENTETableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.EMAILTableAdapter = Nothing
        Me.TableAdapterManager.EVENTOTableAdapter = Nothing
        Me.TableAdapterManager.FORMULARIOSTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsMassEmailingTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Tan
        Me.StatusStrip1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblEnviados, Me.pgBarEnviado, Me.lblError})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 560)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1009, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.RightToLeftAutoMirrorImage = True
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(892, 17)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'lblEnviados
        '
        Me.lblEnviados.BackColor = System.Drawing.Color.Transparent
        Me.lblEnviados.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblEnviados.ForeColor = System.Drawing.Color.Black
        Me.lblEnviados.Name = "lblEnviados"
        Me.lblEnviados.Size = New System.Drawing.Size(0, 17)
        '
        'pgBarEnviado
        '
        Me.pgBarEnviado.BackColor = System.Drawing.Color.White
        Me.pgBarEnviado.Name = "pgBarEnviado"
        Me.pgBarEnviado.Size = New System.Drawing.Size(100, 16)
        Me.pgBarEnviado.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'lblError
        '
        Me.lblError.BackColor = System.Drawing.Color.Transparent
        Me.lblError.ForeColor = System.Drawing.Color.Maroon
        Me.lblError.IsLink = True
        Me.lblError.LinkVisited = True
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(0, 17)
        '
        'pnlMensajeError
        '
        Me.pnlMensajeError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlMensajeError.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlMensajeError.BackColor = System.Drawing.Color.Gray
        Me.pnlMensajeError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlMensajeError.Controls.Add(Me.lblMalisError)
        Me.pnlMensajeError.Controls.Add(Me.Label11)
        Me.pnlMensajeError.Controls.Add(Me.btnCerrar)
        Me.pnlMensajeError.Controls.Add(Me.Label2)
        Me.pnlMensajeError.Controls.Add(Me.tbxCadenaError)
        Me.pnlMensajeError.Location = New System.Drawing.Point(175, 219)
        Me.pnlMensajeError.Name = "pnlMensajeError"
        Me.pnlMensajeError.Size = New System.Drawing.Size(705, 206)
        Me.pnlMensajeError.TabIndex = 13
        Me.pnlMensajeError.Visible = False
        '
        'lblMalisError
        '
        Me.lblMalisError.AutoSize = True
        Me.lblMalisError.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMalisError.Location = New System.Drawing.Point(324, 9)
        Me.lblMalisError.Name = "lblMalisError"
        Me.lblMalisError.Size = New System.Drawing.Size(49, 16)
        Me.lblMalisError.TabIndex = 5
        Me.lblMalisError.Text = "Emails"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(282, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 16)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Total : "
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Location = New System.Drawing.Point(388, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(106, 27)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Emalis no Enviados"
        '
        'tbxCadenaError
        '
        Me.tbxCadenaError.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbxCadenaError.BackColor = System.Drawing.Color.White
        Me.tbxCadenaError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxCadenaError.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCadenaError.Location = New System.Drawing.Point(4, 33)
        Me.tbxCadenaError.Multiline = True
        Me.tbxCadenaError.Name = "tbxCadenaError"
        Me.tbxCadenaError.Size = New System.Drawing.Size(693, 166)
        Me.tbxCadenaError.TabIndex = 3
        '
        'CLIENTESMKTTableAdapter
        '
        Me.CLIENTESMKTTableAdapter.ClearBeforeFill = True
        '
        'MailingMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(1009, 582)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEmailBody)
        Me.Controls.Add(Me.pnlVistaPrevia)
        Me.Controls.Add(Me.pnlHTML)
        Me.Controls.Add(Me.pnlMensajeError)
        Me.Controls.Add(Me.pnlPublico)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MailingMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mailing | Cogent SIG"
        CType(Me.DsMassEmailingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsMassEmailing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbxEnviarEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxPublico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxNuevoEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxHtml, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxMensajeEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmailBody.ResumeLayout(False)
        Me.pnlEmailBody.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlHTML.ResumeLayout(False)
        Me.pnlHTML.PerformLayout()
        Me.pnlVistaPrevia.ResumeLayout(False)
        Me.pnlVistaPrevia.PerformLayout()
        Me.pnlPublico.ResumeLayout(False)
        Me.pnlPublico.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TIPOCLIENTEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvListaCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESMTKBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTipoCliente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CLIENTESBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DETALLEEMAILBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlMensajeError.ResumeLayout(False)
        Me.pnlMensajeError.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlEmailBody As System.Windows.Forms.Panel
    Friend WithEvents tbxMessageBody As System.Windows.Forms.TextBox
    Friend WithEvents tbxImage As System.Windows.Forms.TextBox
    Friend WithEvents tbxColorFondo As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents colorMailingBackground As System.Windows.Forms.ColorDialog
    Friend WithEvents btnExaminar As System.Windows.Forms.Button
    Friend WithEvents lblCampaignName As System.Windows.Forms.Label
    Friend WithEvents pnlHTML As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxHTMLBody As System.Windows.Forms.TextBox
    Friend WithEvents pbxVistaPrevia As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbxHTMLHead As System.Windows.Forms.TextBox
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pnlVistaPrevia As System.Windows.Forms.Panel
    Friend WithEvents tbxCampaignName As System.Windows.Forms.TextBox
    Friend WithEvents wwwVistaPrevia As System.Windows.Forms.WebBrowser
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnItalico As System.Windows.Forms.Button
    Friend WithEvents btnNegrita As System.Windows.Forms.Button
    Friend WithEvents btnH2 As System.Windows.Forms.Button
    Friend WithEvents btnP As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAsunto As System.Windows.Forms.TextBox
    Friend WithEvents pbxEnviarEmail As System.Windows.Forms.PictureBox
    Friend WithEvents pbxMensajeEmail As System.Windows.Forms.PictureBox
    Friend WithEvents pbxHtml As System.Windows.Forms.PictureBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents btnColorSel As System.Windows.Forms.Button
    Friend WithEvents pnlPublico As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pbxPublico As System.Windows.Forms.PictureBox
    Friend WithEvents dgvListaCliente As System.Windows.Forms.DataGridView
    Friend WithEvents CLIENTESBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsMassEmailingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsMassEmailing As ContaExpress.DsMassEmailing
    Friend WithEvents CLIENTESTableAdapter As ContaExpress.DsMassEmailingTableAdapters.CLIENTESTableAdapter
    Friend WithEvents CODUSUARIODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODEMPRESADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NUMTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECGRADataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RUCDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIRECCIONDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TELEFONODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRIORIDADDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvTipoCliente As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodEmail As System.Windows.Forms.TextBox
    Friend WithEvents TIPOCLIENTEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TIPOCLIENTETableAdapter As ContaExpress.DsMassEmailingTableAdapters.TIPOCLIENTETableAdapter
    Friend WithEvents DETALLEEMAILBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DETALLEEMAILTableAdapter As ContaExpress.DsMassEmailingTableAdapters.DETALLEEMAILTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsMassEmailingTableAdapters.TableAdapterManager
    Friend WithEvents pbxNuevoEmail As System.Windows.Forms.PictureBox
    Friend WithEvents Agregar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CODTIPOCLIENTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTIPOCLIENTE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEnviados As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pgBarEnviado As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents lblError As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pnlMensajeError As System.Windows.Forms.Panel
    Friend WithEvents lblMalisError As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbxCadenaError As System.Windows.Forms.TextBox
    Friend WithEvents btnLinea As System.Windows.Forms.Button
    Friend WithEvents btnEstiloDer As System.Windows.Forms.Button
    Friend WithEvents btnEstiloCentro As System.Windows.Forms.Button
    Friend WithEvents btnEstiloIzq As System.Windows.Forms.Button
    Friend WithEvents btnEstiloColor As System.Windows.Forms.Button
    Friend WithEvents btAplicarEstilos As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CLIENTESMKTTableAdapter As ContaExpress.DsMassEmailingTableAdapters.CLIENTESMKTTableAdapter
    Friend WithEvents NOMBREDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHANACIMIENTODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SEXODataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAILDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbSexo As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbListaPrecio As System.Windows.Forms.ComboBox
    Friend WithEvents CLIENTESMTKBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CODTIPOCLIENTEDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbDiaHasta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDiaDesde As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMesDesde As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMesHasta As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents BuscarTextBox As System.Windows.Forms.TextBox
End Class
