<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CambioServidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CambioServidor))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxSQLAddress = New System.Windows.Forms.TextBox()
        Me.cbxSQLAddress = New System.Windows.Forms.ComboBox()
        Me.chbxWinAuth = New System.Windows.Forms.CheckBox()
        Me.tbxPassSQL = New System.Windows.Forms.TextBox()
        Me.tbxUserSQL = New System.Windows.Forms.TextBox()
        Me.btnBuscarSQL = New System.Windows.Forms.Button()
        Me.btnConnectar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxBDEmpresa = New System.Windows.Forms.ComboBox()
        Me.cbxEncrytar = New System.Windows.Forms.CheckBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxBDSucursal = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxBDMaquina = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(65, 88)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Servidor:"
        '
        'tbxSQLAddress
        '
        Me.tbxSQLAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxSQLAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxSQLAddress.Location = New System.Drawing.Point(136, 81)
        Me.tbxSQLAddress.Multiline = True
        Me.tbxSQLAddress.Name = "tbxSQLAddress"
        Me.tbxSQLAddress.Size = New System.Drawing.Size(348, 30)
        Me.tbxSQLAddress.TabIndex = 0
        '
        'cbxSQLAddress
        '
        Me.cbxSQLAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxSQLAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxSQLAddress.FormattingEnabled = True
        Me.cbxSQLAddress.Location = New System.Drawing.Point(137, 82)
        Me.cbxSQLAddress.Name = "cbxSQLAddress"
        Me.cbxSQLAddress.Size = New System.Drawing.Size(347, 28)
        Me.cbxSQLAddress.TabIndex = 1
        '
        'chbxWinAuth
        '
        Me.chbxWinAuth.AutoSize = True
        Me.chbxWinAuth.ForeColor = System.Drawing.Color.White
        Me.chbxWinAuth.Location = New System.Drawing.Point(137, 115)
        Me.chbxWinAuth.Name = "chbxWinAuth"
        Me.chbxWinAuth.Size = New System.Drawing.Size(275, 21)
        Me.chbxWinAuth.TabIndex = 1
        Me.chbxWinAuth.Text = "Conectar con ""Windows Authentication"""
        Me.chbxWinAuth.UseVisualStyleBackColor = True
        '
        'tbxPassSQL
        '
        Me.tbxPassSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxPassSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxPassSQL.Location = New System.Drawing.Point(137, 176)
        Me.tbxPassSQL.Name = "tbxPassSQL"
        Me.tbxPassSQL.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbxPassSQL.Size = New System.Drawing.Size(347, 27)
        Me.tbxPassSQL.TabIndex = 3
        '
        'tbxUserSQL
        '
        Me.tbxUserSQL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbxUserSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxUserSQL.Location = New System.Drawing.Point(137, 143)
        Me.tbxUserSQL.Name = "tbxUserSQL"
        Me.tbxUserSQL.Size = New System.Drawing.Size(347, 27)
        Me.tbxUserSQL.TabIndex = 2
        '
        'btnBuscarSQL
        '
        Me.btnBuscarSQL.BackColor = System.Drawing.Color.Gainsboro
        Me.btnBuscarSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscarSQL.Location = New System.Drawing.Point(490, 80)
        Me.btnBuscarSQL.Name = "btnBuscarSQL"
        Me.btnBuscarSQL.Size = New System.Drawing.Size(106, 31)
        Me.btnBuscarSQL.TabIndex = 10
        Me.btnBuscarSQL.Text = "Buscar"
        Me.btnBuscarSQL.UseVisualStyleBackColor = False
        '
        'btnConnectar
        '
        Me.btnConnectar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnConnectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnectar.Location = New System.Drawing.Point(137, 209)
        Me.btnConnectar.Name = "btnConnectar"
        Me.btnConnectar.Size = New System.Drawing.Size(347, 38)
        Me.btnConnectar.TabIndex = 4
        Me.btnConnectar.Text = "Conectar"
        Me.btnConnectar.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(37, 148)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Usuario SQL:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(51, 181)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Clave SQL:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(62, 266)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Empresa:"
        '
        'cbxBDEmpresa
        '
        Me.cbxBDEmpresa.Enabled = False
        Me.cbxBDEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBDEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.cbxBDEmpresa.FormattingEnabled = True
        Me.cbxBDEmpresa.Location = New System.Drawing.Point(137, 260)
        Me.cbxBDEmpresa.Name = "cbxBDEmpresa"
        Me.cbxBDEmpresa.Size = New System.Drawing.Size(347, 28)
        Me.cbxBDEmpresa.TabIndex = 5
        '
        'cbxEncrytar
        '
        Me.cbxEncrytar.AutoSize = True
        Me.cbxEncrytar.ForeColor = System.Drawing.Color.White
        Me.cbxEncrytar.Location = New System.Drawing.Point(136, 369)
        Me.cbxEncrytar.Name = "cbxEncrytar"
        Me.cbxEncrytar.Size = New System.Drawing.Size(230, 21)
        Me.cbxEncrytar.TabIndex = 6
        Me.cbxEncrytar.Text = "Encryptar la Conexion (128-bits)"
        Me.cbxEncrytar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGuardar.Location = New System.Drawing.Point(136, 394)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(347, 38)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(644, 52)
        Me.Panel1.TabIndex = 33
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Light", 26.25!)
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(256, 47)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Elija un Servidor"
        '
        'cbxBDSucursal
        '
        Me.cbxBDSucursal.Enabled = False
        Me.cbxBDSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBDSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.cbxBDSucursal.FormattingEnabled = True
        Me.cbxBDSucursal.Location = New System.Drawing.Point(137, 294)
        Me.cbxBDSucursal.Name = "cbxBDSucursal"
        Me.cbxBDSucursal.Size = New System.Drawing.Size(347, 28)
        Me.cbxBDSucursal.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(63, 300)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Sucursal:"
        '
        'cbxBDMaquina
        '
        Me.cbxBDMaquina.Enabled = False
        Me.cbxBDMaquina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxBDMaquina.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!)
        Me.cbxBDMaquina.FormattingEnabled = True
        Me.cbxBDMaquina.Location = New System.Drawing.Point(137, 328)
        Me.cbxBDMaquina.Name = "cbxBDMaquina"
        Me.cbxBDMaquina.Size = New System.Drawing.Size(347, 28)
        Me.cbxBDMaquina.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(64, 334)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Maquina:"
        '
        'CambioServidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(643, 452)
        Me.Controls.Add(Me.cbxBDMaquina)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbxBDSucursal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.cbxEncrytar)
        Me.Controls.Add(Me.cbxBDEmpresa)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnConnectar)
        Me.Controls.Add(Me.btnBuscarSQL)
        Me.Controls.Add(Me.tbxUserSQL)
        Me.Controls.Add(Me.tbxPassSQL)
        Me.Controls.Add(Me.chbxWinAuth)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbxSQLAddress)
        Me.Controls.Add(Me.cbxSQLAddress)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "CambioServidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Servidor"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbxSQLAddress As System.Windows.Forms.TextBox
    Friend WithEvents cbxSQLAddress As System.Windows.Forms.ComboBox
    Friend WithEvents chbxWinAuth As System.Windows.Forms.CheckBox
    Friend WithEvents tbxPassSQL As System.Windows.Forms.TextBox
    Friend WithEvents tbxUserSQL As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarSQL As System.Windows.Forms.Button
    Friend WithEvents btnConnectar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxBDEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents cbxEncrytar As System.Windows.Forms.CheckBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbxBDSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbxBDMaquina As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
