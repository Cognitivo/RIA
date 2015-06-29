<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateBarCode
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
        Me.dgvProductView = New System.Windows.Forms.DataGridView()
        Me.btnExtraer = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.rtbConn = New System.Windows.Forms.RichTextBox()
        CType(Me.dgvProductView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvProductView
        '
        Me.dgvProductView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductView.Location = New System.Drawing.Point(12, 40)
        Me.dgvProductView.Name = "dgvProductView"
        Me.dgvProductView.Size = New System.Drawing.Size(486, 330)
        Me.dgvProductView.TabIndex = 0
        '
        'btnExtraer
        '
        Me.btnExtraer.Location = New System.Drawing.Point(12, 12)
        Me.btnExtraer.Name = "btnExtraer"
        Me.btnExtraer.Size = New System.Drawing.Size(141, 23)
        Me.btnExtraer.TabIndex = 1
        Me.btnExtraer.Text = "1. Traer Codigos"
        Me.btnExtraer.UseVisualStyleBackColor = True
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(193, 12)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(135, 23)
        Me.btnGenerar.TabIndex = 2
        Me.btnGenerar.Text = "2.Generar Codigos"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(370, 12)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(128, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "3.Actualizar Codigos"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'rtbConn
        '
        Me.rtbConn.Location = New System.Drawing.Point(12, 376)
        Me.rtbConn.Name = "rtbConn"
        Me.rtbConn.Size = New System.Drawing.Size(486, 61)
        Me.rtbConn.TabIndex = 4
        Me.rtbConn.Text = ""
        '
        'UpdateBarCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(510, 449)
        Me.Controls.Add(Me.rtbConn)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.btnExtraer)
        Me.Controls.Add(Me.dgvProductView)
        Me.Name = "UpdateBarCode"
        Me.Text = "UpdateBarCode"
        CType(Me.dgvProductView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProductView As System.Windows.Forms.DataGridView
    Friend WithEvents btnExtraer As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents rtbConn As System.Windows.Forms.RichTextBox
End Class
