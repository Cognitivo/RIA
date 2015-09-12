<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PeriodoFiscalV2
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
        Dim FECHAINICIOLabel As System.Windows.Forms.Label
        Dim FECHAFINLabel As System.Windows.Forms.Label
        Dim DESEJERCICIOLabel As System.Windows.Forms.Label
        Dim ESTADOLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PeriodoFiscalV2))
        Me.DSPeriodoFiscalForm = New ContaExpress.DSPeriodoFiscalForm()
        Me.PeriodofiscalBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PeriodofiscalTableAdapter = New ContaExpress.DSPeriodoFiscalFormTableAdapters.periodofiscalTableAdapter()
        Me.TableAdapterManager = New ContaExpress.DSPeriodoFiscalFormTableAdapters.TableAdapterManager()
        Me.PERIODOFISCALPRESUPUESTOTableAdapter = New ContaExpress.DSPeriodoFiscalFormTableAdapters.PERIODOFISCALPRESUPUESTOTableAdapter()
        Me.PeriodofiscalBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PeriodofiscalBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.PeriodofiscalDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERIODOFISCALPRESUPUESTOBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PERIODOFISCALPRESUPUESTODataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHAINICIODateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.FECHAFINDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DESEJERCICIOTextBox = New System.Windows.Forms.TextBox()
        Me.ESTADOCheckBox = New System.Windows.Forms.CheckBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        FECHAINICIOLabel = New System.Windows.Forms.Label()
        FECHAFINLabel = New System.Windows.Forms.Label()
        DESEJERCICIOLabel = New System.Windows.Forms.Label()
        ESTADOLabel = New System.Windows.Forms.Label()
        CType(Me.DSPeriodoFiscalForm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PeriodofiscalBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PeriodofiscalBindingNavigator.SuspendLayout()
        CType(Me.PeriodofiscalDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PERIODOFISCALPRESUPUESTOBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PERIODOFISCALPRESUPUESTODataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FECHAINICIOLabel
        '
        FECHAINICIOLabel.AutoSize = True
        FECHAINICIOLabel.Location = New System.Drawing.Point(215, 55)
        FECHAINICIOLabel.Name = "FECHAINICIOLabel"
        FECHAINICIOLabel.Size = New System.Drawing.Size(77, 13)
        FECHAINICIOLabel.TabIndex = 5
        FECHAINICIOLabel.Text = "FECHAINICIO:"
        '
        'FECHAFINLabel
        '
        FECHAFINLabel.AutoSize = True
        FECHAFINLabel.Location = New System.Drawing.Point(215, 81)
        FECHAFINLabel.Name = "FECHAFINLabel"
        FECHAFINLabel.Size = New System.Drawing.Size(62, 13)
        FECHAFINLabel.TabIndex = 7
        FECHAFINLabel.Text = "FECHAFIN:"
        '
        'DESEJERCICIOLabel
        '
        DESEJERCICIOLabel.AutoSize = True
        DESEJERCICIOLabel.Location = New System.Drawing.Point(215, 28)
        DESEJERCICIOLabel.Name = "DESEJERCICIOLabel"
        DESEJERCICIOLabel.Size = New System.Drawing.Size(87, 13)
        DESEJERCICIOLabel.TabIndex = 9
        DESEJERCICIOLabel.Text = "DESEJERCICIO:"
        '
        'ESTADOLabel
        '
        ESTADOLabel.AutoSize = True
        ESTADOLabel.Location = New System.Drawing.Point(248, 106)
        ESTADOLabel.Name = "ESTADOLabel"
        ESTADOLabel.Size = New System.Drawing.Size(54, 13)
        ESTADOLabel.TabIndex = 10
        ESTADOLabel.Text = "ESTADO:"
        '
        'DSPeriodoFiscalForm
        '
        Me.DSPeriodoFiscalForm.DataSetName = "DSPeriodoFiscalForm"
        Me.DSPeriodoFiscalForm.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PeriodofiscalBindingSource
        '
        Me.PeriodofiscalBindingSource.DataMember = "periodofiscal"
        Me.PeriodofiscalBindingSource.DataSource = Me.DSPeriodoFiscalForm
        '
        'PeriodofiscalTableAdapter
        '
        Me.PeriodofiscalTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.PERIODOFISCALPRESUPUESTOTableAdapter = Me.PERIODOFISCALPRESUPUESTOTableAdapter
        Me.TableAdapterManager.periodofiscalTableAdapter = Me.PeriodofiscalTableAdapter
        Me.TableAdapterManager.plancuentasTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = ContaExpress.DSPeriodoFiscalFormTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'PERIODOFISCALPRESUPUESTOTableAdapter
        '
        Me.PERIODOFISCALPRESUPUESTOTableAdapter.ClearBeforeFill = True
        '
        'PeriodofiscalBindingNavigator
        '
        Me.PeriodofiscalBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.PeriodofiscalBindingNavigator.BindingSource = Me.PeriodofiscalBindingSource
        Me.PeriodofiscalBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.PeriodofiscalBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.PeriodofiscalBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.PeriodofiscalBindingNavigatorSaveItem})
        Me.PeriodofiscalBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.PeriodofiscalBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.PeriodofiscalBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.PeriodofiscalBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.PeriodofiscalBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.PeriodofiscalBindingNavigator.Name = "PeriodofiscalBindingNavigator"
        Me.PeriodofiscalBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.PeriodofiscalBindingNavigator.Size = New System.Drawing.Size(792, 25)
        Me.PeriodofiscalBindingNavigator.TabIndex = 0
        Me.PeriodofiscalBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'PeriodofiscalBindingNavigatorSaveItem
        '
        Me.PeriodofiscalBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PeriodofiscalBindingNavigatorSaveItem.Image = CType(resources.GetObject("PeriodofiscalBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.PeriodofiscalBindingNavigatorSaveItem.Name = "PeriodofiscalBindingNavigatorSaveItem"
        Me.PeriodofiscalBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.PeriodofiscalBindingNavigatorSaveItem.Text = "Save Data"
        '
        'PeriodofiscalDataGridView
        '
        Me.PeriodofiscalDataGridView.AutoGenerateColumns = False
        Me.PeriodofiscalDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PeriodofiscalDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5})
        Me.PeriodofiscalDataGridView.DataSource = Me.PeriodofiscalBindingSource
        Me.PeriodofiscalDataGridView.Location = New System.Drawing.Point(0, 28)
        Me.PeriodofiscalDataGridView.Name = "PeriodofiscalDataGridView"
        Me.PeriodofiscalDataGridView.Size = New System.Drawing.Size(209, 546)
        Me.PeriodofiscalDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CODPERIODOFISCAL"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CODPERIODOFISCAL"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "FECHAINICIO"
        Me.DataGridViewTextBoxColumn2.HeaderText = "FECHAINICIO"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "FECHAFIN"
        Me.DataGridViewTextBoxColumn3.HeaderText = "FECHAFIN"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "DESEJERCICIO"
        Me.DataGridViewTextBoxColumn4.HeaderText = "DESEJERCICIO"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "ESTADO"
        Me.DataGridViewTextBoxColumn5.HeaderText = "ESTADO"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'PERIODOFISCALPRESUPUESTOBindingSource
        '
        Me.PERIODOFISCALPRESUPUESTOBindingSource.DataMember = "periodofiscal_PERIODOFISCALPRESUPUESTO"
        Me.PERIODOFISCALPRESUPUESTOBindingSource.DataSource = Me.PeriodofiscalBindingSource
        '
        'PERIODOFISCALPRESUPUESTODataGridView
        '
        Me.PERIODOFISCALPRESUPUESTODataGridView.AutoGenerateColumns = False
        Me.PERIODOFISCALPRESUPUESTODataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PERIODOFISCALPRESUPUESTODataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.PERIODOFISCALPRESUPUESTODataGridView.DataSource = Me.PERIODOFISCALPRESUPUESTOBindingSource
        Me.PERIODOFISCALPRESUPUESTODataGridView.Location = New System.Drawing.Point(215, 180)
        Me.PERIODOFISCALPRESUPUESTODataGridView.Name = "PERIODOFISCALPRESUPUESTODataGridView"
        Me.PERIODOFISCALPRESUPUESTODataGridView.Size = New System.Drawing.Size(557, 394)
        Me.PERIODOFISCALPRESUPUESTODataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "codpresupuestofiscal"
        Me.DataGridViewTextBoxColumn6.HeaderText = "codpresupuestofiscal"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "codperiodofiscal"
        Me.DataGridViewTextBoxColumn7.HeaderText = "codperiodofiscal"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "codplandecuentas"
        Me.DataGridViewTextBoxColumn8.HeaderText = "codplandecuentas"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "valor"
        Me.DataGridViewTextBoxColumn9.HeaderText = "valor"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'FECHAINICIODateTimePicker
        '
        Me.FECHAINICIODateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.PeriodofiscalBindingSource, "FECHAINICIO", True))
        Me.FECHAINICIODateTimePicker.Location = New System.Drawing.Point(310, 51)
        Me.FECHAINICIODateTimePicker.Name = "FECHAINICIODateTimePicker"
        Me.FECHAINICIODateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.FECHAINICIODateTimePicker.TabIndex = 6
        '
        'FECHAFINDateTimePicker
        '
        Me.FECHAFINDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.PeriodofiscalBindingSource, "FECHAFIN", True))
        Me.FECHAFINDateTimePicker.Location = New System.Drawing.Point(310, 77)
        Me.FECHAFINDateTimePicker.Name = "FECHAFINDateTimePicker"
        Me.FECHAFINDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.FECHAFINDateTimePicker.TabIndex = 8
        '
        'DESEJERCICIOTextBox
        '
        Me.DESEJERCICIOTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.PeriodofiscalBindingSource, "DESEJERCICIO", True))
        Me.DESEJERCICIOTextBox.Location = New System.Drawing.Point(310, 25)
        Me.DESEJERCICIOTextBox.Name = "DESEJERCICIOTextBox"
        Me.DESEJERCICIOTextBox.Size = New System.Drawing.Size(200, 20)
        Me.DESEJERCICIOTextBox.TabIndex = 10
        '
        'ESTADOCheckBox
        '
        Me.ESTADOCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.PeriodofiscalBindingSource, "ESTADO", True))
        Me.ESTADOCheckBox.Location = New System.Drawing.Point(310, 101)
        Me.ESTADOCheckBox.Name = "ESTADOCheckBox"
        Me.ESTADOCheckBox.Size = New System.Drawing.Size(104, 24)
        Me.ESTADOCheckBox.TabIndex = 11
        Me.ESTADOCheckBox.Text = "CheckBox1"
        Me.ESTADOCheckBox.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(215, 156)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 12
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(339, 157)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(445, 157)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 20)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(445, 106)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PeriodoFiscalV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 577)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(ESTADOLabel)
        Me.Controls.Add(Me.ESTADOCheckBox)
        Me.Controls.Add(FECHAINICIOLabel)
        Me.Controls.Add(Me.FECHAINICIODateTimePicker)
        Me.Controls.Add(FECHAFINLabel)
        Me.Controls.Add(Me.FECHAFINDateTimePicker)
        Me.Controls.Add(DESEJERCICIOLabel)
        Me.Controls.Add(Me.DESEJERCICIOTextBox)
        Me.Controls.Add(Me.PERIODOFISCALPRESUPUESTODataGridView)
        Me.Controls.Add(Me.PeriodofiscalDataGridView)
        Me.Controls.Add(Me.PeriodofiscalBindingNavigator)
        Me.Name = "PeriodoFiscalV2"
        Me.Text = "Periodo Fiscal"
        CType(Me.DSPeriodoFiscalForm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodofiscalBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PeriodofiscalBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PeriodofiscalBindingNavigator.ResumeLayout(False)
        Me.PeriodofiscalBindingNavigator.PerformLayout()
        CType(Me.PeriodofiscalDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PERIODOFISCALPRESUPUESTOBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PERIODOFISCALPRESUPUESTODataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DSPeriodoFiscalForm As ContaExpress.DSPeriodoFiscalForm
    Friend WithEvents PeriodofiscalBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PeriodofiscalTableAdapter As ContaExpress.DSPeriodoFiscalFormTableAdapters.periodofiscalTableAdapter
    Friend WithEvents TableAdapterManager As ContaExpress.DSPeriodoFiscalFormTableAdapters.TableAdapterManager
    Friend WithEvents PeriodofiscalBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PeriodofiscalBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PERIODOFISCALPRESUPUESTOTableAdapter As ContaExpress.DSPeriodoFiscalFormTableAdapters.PERIODOFISCALPRESUPUESTOTableAdapter
    Friend WithEvents PeriodofiscalDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERIODOFISCALPRESUPUESTOBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PERIODOFISCALPRESUPUESTODataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHAINICIODateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents FECHAFINDateTimePicker As System.Windows.Forms.DateTimePicker
    Friend WithEvents DESEJERCICIOTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ESTADOCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
