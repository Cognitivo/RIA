<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AjusteHistoricoStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AjusteHistoricoStock))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCalcularAjuste = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblManual = New System.Windows.Forms.Label()
        Me.cmbTipoAjuste = New System.Windows.Forms.ComboBox()
        Me.pnlManual = New System.Windows.Forms.Panel()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Mes = New System.Windows.Forms.Label()
        Me.pnlAutomatico = New System.Windows.Forms.Panel()
        Me.lblSegunConfig = New System.Windows.Forms.Label()
        Me.DsProduccion = New ContaExpress.DsProduccion()
        Me.TableAdapterManager = New ContaExpress.DsProduccionTableAdapters.TableAdapterManager()
        Me.AjustesHistoricoStockTableAdapter = New ContaExpress.DsProduccionTableAdapters.AjustesHistoricoStockTableAdapter()
        Me.AjusteHistoricoAPedidoTableAdapter = New ContaExpress.DsProduccionTableAdapters.AjusteHistoricoAPedidoTableAdapter()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.pnlManual.SuspendLayout()
        Me.pnlAutomatico.SuspendLayout()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BackgroundImage = Global.ContaExpress.My.Resources.Resources.LeatherTileStitchless
        Me.Panel1.Location = New System.Drawing.Point(-2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 41)
        Me.Panel1.TabIndex = 355
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(42, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(401, 75)
        Me.Label1.TabIndex = 402
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'btnCalcularAjuste
        '
        Me.btnCalcularAjuste.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCalcularAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcularAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.btnCalcularAjuste.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnCalcularAjuste.Location = New System.Drawing.Point(69, 291)
        Me.btnCalcularAjuste.Name = "btnCalcularAjuste"
        Me.btnCalcularAjuste.Size = New System.Drawing.Size(315, 86)
        Me.btnCalcularAjuste.TabIndex = 403
        Me.btnCalcularAjuste.Text = "Ajustar Histórico Stock"
        Me.btnCalcularAjuste.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblManual)
        Me.GroupBox1.Controls.Add(Me.cmbTipoAjuste)
        Me.GroupBox1.Controls.Add(Me.pnlManual)
        Me.GroupBox1.Controls.Add(Me.pnlAutomatico)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 143)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(425, 142)
        Me.GroupBox1.TabIndex = 404
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ajuste:"
        '
        'lblManual
        '
        Me.lblManual.AutoSize = True
        Me.lblManual.BackColor = System.Drawing.Color.Transparent
        Me.lblManual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManual.Location = New System.Drawing.Point(17, 60)
        Me.lblManual.Name = "lblManual"
        Me.lblManual.Size = New System.Drawing.Size(130, 16)
        Me.lblManual.TabIndex = 406
        Me.lblManual.Text = "Por movimientos del"
        '
        'cmbTipoAjuste
        '
        Me.cmbTipoAjuste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTipoAjuste.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbTipoAjuste.FormattingEnabled = True
        Me.cmbTipoAjuste.Items.AddRange(New Object() {"Automático", "Manual"})
        Me.cmbTipoAjuste.Location = New System.Drawing.Point(45, 26)
        Me.cmbTipoAjuste.Name = "cmbTipoAjuste"
        Me.cmbTipoAjuste.Size = New System.Drawing.Size(190, 28)
        Me.cmbTipoAjuste.TabIndex = 13
        '
        'pnlManual
        '
        Me.pnlManual.Controls.Add(Me.cmbAño)
        Me.pnlManual.Controls.Add(Me.cmbMes)
        Me.pnlManual.Controls.Add(Me.Label4)
        Me.pnlManual.Controls.Add(Me.Mes)
        Me.pnlManual.Location = New System.Drawing.Point(14, 75)
        Me.pnlManual.Name = "pnlManual"
        Me.pnlManual.Size = New System.Drawing.Size(398, 53)
        Me.pnlManual.TabIndex = 12
        '
        'cmbAño
        '
        Me.cmbAño.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Items.AddRange(New Object() {"2010", "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033", "2034", "2035", "2036", "2037", "2038", "2039", "2040", "2041", "2042", "2043", "2044", "2045", "2046", "2047", "2048", "2049", "2050"})
        Me.cmbAño.Location = New System.Drawing.Point(232, 21)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(138, 28)
        Me.cmbAño.TabIndex = 12
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.White
        Me.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.cmbMes.Location = New System.Drawing.Point(30, 21)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(190, 28)
        Me.cmbMes.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(231, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Año"
        '
        'Mes
        '
        Me.Mes.AutoSize = True
        Me.Mes.BackColor = System.Drawing.Color.Transparent
        Me.Mes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mes.Location = New System.Drawing.Point(29, 4)
        Me.Mes.Name = "Mes"
        Me.Mes.Size = New System.Drawing.Size(31, 15)
        Me.Mes.TabIndex = 15
        Me.Mes.Text = "Mes"
        '
        'pnlAutomatico
        '
        Me.pnlAutomatico.Controls.Add(Me.lblSegunConfig)
        Me.pnlAutomatico.Location = New System.Drawing.Point(14, 75)
        Me.pnlAutomatico.Name = "pnlAutomatico"
        Me.pnlAutomatico.Size = New System.Drawing.Size(398, 53)
        Me.pnlAutomatico.TabIndex = 405
        '
        'lblSegunConfig
        '
        Me.lblSegunConfig.AutoSize = True
        Me.lblSegunConfig.BackColor = System.Drawing.Color.Transparent
        Me.lblSegunConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSegunConfig.Location = New System.Drawing.Point(33, 19)
        Me.lblSegunConfig.Name = "lblSegunConfig"
        Me.lblSegunConfig.Size = New System.Drawing.Size(290, 16)
        Me.lblSegunConfig.TabIndex = 14
        Me.lblSegunConfig.Text = "A partir de X meses atrás (según Configuración)"
        '
        'DsProduccion
        '
        Me.DsProduccion.DataSetName = "DsProduccion"
        Me.DsProduccion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.UNIDADMEDIDATableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsProduccionTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'AjustesHistoricoStockTableAdapter
        '
        Me.AjustesHistoricoStockTableAdapter.ClearBeforeFill = True
        '
        'AjusteHistoricoAPedidoTableAdapter
        '
        Me.AjusteHistoricoAPedidoTableAdapter.ClearBeforeFill = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.ContaExpress.My.Resources.Resources.helpOff
        Me.PictureBox2.Location = New System.Drawing.Point(8, 47)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 405
        Me.PictureBox2.TabStop = False
        '
        'AjusteHistoricoStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.BackgroundImage = Global.ContaExpress.My.Resources.Resources.lino
        Me.ClientSize = New System.Drawing.Size(449, 387)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCalcularAjuste)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "AjusteHistoricoStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ajuste Histórico Stock | Cogent SIG"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlManual.ResumeLayout(False)
        Me.pnlManual.PerformLayout()
        Me.pnlAutomatico.ResumeLayout(False)
        Me.pnlAutomatico.PerformLayout()
        CType(Me.DsProduccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCalcularAjuste As System.Windows.Forms.Button
    Friend WithEvents DsProduccion As ContaExpress.DsProduccion
    Friend WithEvents TableAdapterManager As ContaExpress.DsProduccionTableAdapters.TableAdapterManager
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AjustesHistoricoStockTableAdapter As ContaExpress.DsProduccionTableAdapters.AjustesHistoricoStockTableAdapter
    Friend WithEvents pnlAutomatico As System.Windows.Forms.Panel
    Friend WithEvents lblSegunConfig As System.Windows.Forms.Label
    Friend WithEvents cmbTipoAjuste As System.Windows.Forms.ComboBox
    Friend WithEvents pnlManual As System.Windows.Forms.Panel
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Mes As System.Windows.Forms.Label
    Friend WithEvents AjusteHistoricoAPedidoTableAdapter As ContaExpress.DsProduccionTableAdapters.AjusteHistoricoAPedidoTableAdapter
    Friend WithEvents lblManual As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
