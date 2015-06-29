<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated> _
Partial Class Logeo
    Inherits System.Windows.Forms.Form

    #Region "Fields"

    Friend  WithEvents AuditoriatablasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents LinkLabelAqui As System.Windows.Forms.LinkLabel
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Logeo))
        Me.LinkLabelAqui = New System.Windows.Forms.LinkLabel()
        Me.PasswordTextBox = New System.Windows.Forms.TextBox()
        Me.UsernameTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.bckwrkSplash = New System.ComponentModel.BackgroundWorker()
        Me.pnlSimplificado = New System.Windows.Forms.Panel()
        Me.lblCambiarUsuario = New System.Windows.Forms.LinkLabel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.tbxPassSimple = New System.Windows.Forms.TextBox()
        Me.pnlComplejo = New System.Windows.Forms.Panel()
        Me.cbxRecodarUser = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlSimplificado.SuspendLayout()
        Me.pnlComplejo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LinkLabelAqui
        '
        Me.LinkLabelAqui.ActiveLinkColor = System.Drawing.Color.Red
        Me.LinkLabelAqui.AutoSize = True
        Me.LinkLabelAqui.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelAqui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelAqui.ForeColor = System.Drawing.Color.DarkOrange
        Me.LinkLabelAqui.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.LinkLabelAqui.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabelAqui.LinkColor = System.Drawing.Color.DarkOrange
        Me.LinkLabelAqui.Location = New System.Drawing.Point(412, 300)
        Me.LinkLabelAqui.Name = "LinkLabelAqui"
        Me.LinkLabelAqui.Size = New System.Drawing.Size(83, 15)
        Me.LinkLabelAqui.TabIndex = 5
        Me.LinkLabelAqui.TabStop = True
        Me.LinkLabelAqui.Text = "Configuración"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.Location = New System.Drawing.Point(23, 102)
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.PasswordTextBox.Size = New System.Drawing.Size(300, 40)
        Me.PasswordTextBox.TabIndex = 3
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.BackColor = System.Drawing.Color.Gainsboro
        Me.UsernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!)
        Me.UsernameTextBox.ForeColor = System.Drawing.SystemColors.WindowText
        Me.UsernameTextBox.Location = New System.Drawing.Point(23, 31)
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(300, 40)
        Me.UsernameTextBox.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(154, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label2.Location = New System.Drawing.Point(144, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Contrasena"
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.Color.LightGray
        Me.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.Location = New System.Drawing.Point(283, 236)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(114, 31)
        Me.btnIngresar.TabIndex = 25
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'bckwrkSplash
        '
        Me.bckwrkSplash.WorkerSupportsCancellation = True
        '
        'pnlSimplificado
        '
        Me.pnlSimplificado.Controls.Add(Me.lblCambiarUsuario)
        Me.pnlSimplificado.Controls.Add(Me.lblUser)
        Me.pnlSimplificado.Controls.Add(Me.tbxPassSimple)
        Me.pnlSimplificado.Location = New System.Drawing.Point(75, 85)
        Me.pnlSimplificado.Name = "pnlSimplificado"
        Me.pnlSimplificado.Size = New System.Drawing.Size(347, 177)
        Me.pnlSimplificado.TabIndex = 26
        '
        'lblCambiarUsuario
        '
        Me.lblCambiarUsuario.AutoSize = True
        Me.lblCambiarUsuario.LinkColor = System.Drawing.Color.DarkOrange
        Me.lblCambiarUsuario.Location = New System.Drawing.Point(24, 154)
        Me.lblCambiarUsuario.Name = "lblCambiarUsuario"
        Me.lblCambiarUsuario.Size = New System.Drawing.Size(99, 13)
        Me.lblCambiarUsuario.TabIndex = 30
        Me.lblCambiarUsuario.TabStop = True
        Me.lblCambiarUsuario.Text = "Cambiar de Usuario"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.ForeColor = System.Drawing.Color.AliceBlue
        Me.lblUser.Location = New System.Drawing.Point(24, 83)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(214, 13)
        Me.lblUser.TabIndex = 29
        Me.lblUser.Text = "Hola COGENT, favor ingrese su contraseña"
        '
        'tbxPassSimple
        '
        Me.tbxPassSimple.BackColor = System.Drawing.Color.Gainsboro
        Me.tbxPassSimple.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbxPassSimple.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxPassSimple.Location = New System.Drawing.Point(26, 102)
        Me.tbxPassSimple.Name = "tbxPassSimple"
        Me.tbxPassSimple.PasswordChar = Global.Microsoft.VisualBasic.ChrW(8226)
        Me.tbxPassSimple.Size = New System.Drawing.Size(296, 40)
        Me.tbxPassSimple.TabIndex = 27
        '
        'pnlComplejo
        '
        Me.pnlComplejo.Controls.Add(Me.cbxRecodarUser)
        Me.pnlComplejo.Controls.Add(Me.Label1)
        Me.pnlComplejo.Controls.Add(Me.Label2)
        Me.pnlComplejo.Controls.Add(Me.PasswordTextBox)
        Me.pnlComplejo.Controls.Add(Me.UsernameTextBox)
        Me.pnlComplejo.Location = New System.Drawing.Point(74, 85)
        Me.pnlComplejo.Name = "pnlComplejo"
        Me.pnlComplejo.Size = New System.Drawing.Size(347, 176)
        Me.pnlComplejo.TabIndex = 29
        '
        'cbxRecodarUser
        '
        Me.cbxRecodarUser.AutoSize = True
        Me.cbxRecodarUser.ForeColor = System.Drawing.Color.AliceBlue
        Me.cbxRecodarUser.Location = New System.Drawing.Point(24, 151)
        Me.cbxRecodarUser.Name = "cbxRecodarUser"
        Me.cbxRecodarUser.Size = New System.Drawing.Size(118, 17)
        Me.cbxRecodarUser.TabIndex = 24
        Me.cbxRecodarUser.Text = "Recordar quien soy"
        Me.cbxRecodarUser.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Light", 26.25!)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(24, -1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 47)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Cogent SIG"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(-21, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 52)
        Me.Panel1.TabIndex = 32
        '
        'Logeo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 322)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.LinkLabelAqui)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlComplejo)
        Me.Controls.Add(Me.pnlSimplificado)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Logeo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LogIn  | Cogent SIG"
        Me.pnlSimplificado.ResumeLayout(False)
        Me.pnlSimplificado.PerformLayout()
        Me.pnlComplejo.ResumeLayout(False)
        Me.pnlComplejo.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents bckwrkSplash As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlSimplificado As System.Windows.Forms.Panel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents tbxPassSimple As System.Windows.Forms.TextBox
    Friend WithEvents pnlComplejo As System.Windows.Forms.Panel
    Friend WithEvents cbxRecodarUser As System.Windows.Forms.CheckBox
    Friend WithEvents lblCambiarUsuario As System.Windows.Forms.LinkLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel

    #End Region 'Methods

End Class