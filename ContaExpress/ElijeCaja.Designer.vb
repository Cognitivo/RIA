<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ElijeCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElijeCaja))
        Me.CAJABindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSettings = New ContaExpress.DsSettings()
        Me.PCBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PCTableAdapter = New ContaExpress.DsSettingsTableAdapters.PCTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DsSettingsTableAdapters.TableAdapterManager()
        Me.CAJATableAdapter = New ContaExpress.DsSettingsTableAdapters.CAJATableAdapter()
        Me.DsSettingFO = New ContaExpress.DsSettingFO()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DsCaja = New ContaExpress.DsCaja()
        Me.cbxCuenta = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CAJABindingSource
        '
        Me.CAJABindingSource.DataMember = "CAJA"
        Me.CAJABindingSource.DataSource = Me.DsSettings
        '
        'DsSettings
        '
        Me.DsSettings.DataSetName = "DsSettings"
        Me.DsSettings.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PCBindingSource
        '
        Me.PCBindingSource.DataMember = "PC"
        Me.PCBindingSource.DataSource = Me.DsSettings
        '
        'PCTableAdapter
        '
        Me.PCTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AUDITORIAMOVIMIENTOSTableAdapter = Nothing
        Me.TableAdapterManager.AUDITORIATABLASTableAdapter = Nothing
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CAJATableAdapter = Me.CAJATableAdapter
        Me.TableAdapterManager.CIUDADTableAdapter = Nothing
        Me.TableAdapterManager.CONFIGURACIONPASSWTableAdapter = Nothing
        Me.TableAdapterManager.DETPCTableAdapter = Nothing
        Me.TableAdapterManager.EMPRESATableAdapter = Nothing
        Me.TableAdapterManager.ENCARGADOTableAdapter = Nothing
        Me.TableAdapterManager.GRUPODETALLETableAdapter = Nothing
        Me.TableAdapterManager.GRUPOTableAdapter = Nothing
        Me.TableAdapterManager.MODULOSTableAdapter = Nothing
        Me.TableAdapterManager.MONEDATableAdapter = Nothing
        Me.TableAdapterManager.PAISTableAdapter = Nothing
        Me.TableAdapterManager.PRECIOOPERACIONMINUTOTableAdapter = Nothing
        Me.TableAdapterManager.SISTEMASTableAdapter = Nothing
        Me.TableAdapterManager.SUCURSALTableAdapter = Nothing
        Me.TableAdapterManager.TIPOCOMPROBANTETableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DsSettingsTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CAJATableAdapter
        '
        Me.CAJATableAdapter.ClearBeforeFill = True
        '
        'DsSettingFO
        '
        Me.DsSettingFO.DataSetName = "DsSettingFO"
        Me.DsSettingFO.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel1.BackColor = System.Drawing.Color.DarkOrange
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(543, 52)
        Me.Panel1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 26.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(2, -1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(264, 47)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Elija una Cuenta:"
        '
        'DsCaja
        '
        Me.DsCaja.DataSetName = "DsCaja"
        Me.DsCaja.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cbxCuenta
        '
        Me.cbxCuenta.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbxCuenta.BackColor = System.Drawing.Color.Gainsboro
        Me.cbxCuenta.DataSource = Me.CAJABindingSource
        Me.cbxCuenta.DisplayMember = "NUMEROCAJA"
        Me.cbxCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxCuenta.FormattingEnabled = True
        Me.cbxCuenta.Location = New System.Drawing.Point(94, 102)
        Me.cbxCuenta.Name = "cbxCuenta"
        Me.cbxCuenta.Size = New System.Drawing.Size(324, 33)
        Me.cbxCuenta.TabIndex = 8
        Me.cbxCuenta.ValueMember = "NUMCAJA"
        '
        'btnAceptar
        '
        Me.btnAceptar.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnAceptar.Location = New System.Drawing.Point(327, 141)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(91, 28)
        Me.btnAceptar.TabIndex = 10
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = False
        '
        'ElijeCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(540, 224)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cbxCuenta)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ElijeCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccion de Cuentas"
        CType(Me.CAJABindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PCBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSettingFO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DsCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DsSettings As ContaExpress.DsSettings
    Friend WithEvents PCBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PCTableAdapter As ContaExpress.DsSettingsTableAdapters.PCTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DsSettingsTableAdapters.TableAdapterManager
    Friend WithEvents DsSettingFO As ContaExpress.DsSettingFO
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CAJABindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DsCaja As ContaExpress.DsCaja
    Friend WithEvents CAJATableAdapter As ContaExpress.DsSettingsTableAdapters.CAJATableAdapter
    Friend WithEvents cbxCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
