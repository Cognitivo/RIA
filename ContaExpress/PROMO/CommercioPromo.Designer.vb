<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommercioPromo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CommercioPromo))
        Me.btnActivarPrueba = New System.Windows.Forms.Button()
        Me.wwwLinkOn = New System.Windows.Forms.WebBrowser()
        Me.pnlLinkOff = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnActivarPrueba
        '
        Me.btnActivarPrueba.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnActivarPrueba.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnActivarPrueba.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActivarPrueba.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnActivarPrueba.Location = New System.Drawing.Point(633, 8)
        Me.btnActivarPrueba.Name = "btnActivarPrueba"
        Me.btnActivarPrueba.Size = New System.Drawing.Size(206, 41)
        Me.btnActivarPrueba.TabIndex = 0
        Me.btnActivarPrueba.Text = "Quiero Probar Comercio Plus"
        Me.btnActivarPrueba.UseVisualStyleBackColor = False
        '
        'wwwLinkOn
        '
        Me.wwwLinkOn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wwwLinkOn.Location = New System.Drawing.Point(0, 59)
        Me.wwwLinkOn.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wwwLinkOn.Name = "wwwLinkOn"
        Me.wwwLinkOn.Size = New System.Drawing.Size(846, 504)
        Me.wwwLinkOn.TabIndex = 1
        Me.wwwLinkOn.Url = New System.Uri("http://www.cogentpotential.com/modulos/", System.UriKind.Absolute)
        '
        'pnlLinkOff
        '
        Me.pnlLinkOff.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlLinkOff.AutoScroll = True
        Me.pnlLinkOff.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlLinkOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.pnlLinkOff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLinkOff.Location = New System.Drawing.Point(-1, 59)
        Me.pnlLinkOff.Name = "pnlLinkOff"
        Me.pnlLinkOff.Size = New System.Drawing.Size(849, 504)
        Me.pnlLinkOff.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 31)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Commercio Plus"
        '
        'CommercioPromo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(847, 562)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnActivarPrueba)
        Me.Controls.Add(Me.wwwLinkOn)
        Me.Controls.Add(Me.pnlLinkOff)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CommercioPromo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comercio Plus"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnActivarPrueba As System.Windows.Forms.Button
    Friend WithEvents wwwLinkOn As System.Windows.Forms.WebBrowser
    Friend WithEvents pnlLinkOff As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
