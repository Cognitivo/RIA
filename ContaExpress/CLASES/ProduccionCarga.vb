'    Private Sub VerificarEstado()
'        Try
'            If txtEstado.Text = "0" Then
'                lblEstado.Text = "Pendiente"
'                lblEstado.ForeColor = Color.Black

'                btnAprobarProduccion.Enabled = True
'                btnAprobarProduccion.Image = My.Resources.Approve
'                btnAprobarProduccion.Cursor = Cursors.Hand
'                btnAnularProduccion.Enabled = False
'                btnAnularProduccion.Image = My.Resources.AnullOff
'                btnAnularProduccion.Cursor = Cursors.Arrow

'                EliminarPictureBox.Enabled = True
'                EliminarPictureBox.Image = My.Resources.Delete
'                EliminarPictureBox.Cursor = Cursors.Hand
'                ModificarPictureBox.Enabled = True
'                ModificarPictureBox.Image = My.Resources.Edit
'                ModificarPictureBox.Cursor = Cursors.Hand

'                pnlMotivoAnulacion.Visible = False
'                BtnAnular.Enabled = True
'                txtMotivoAnulacion.Enabled = True

'            ElseIf txtEstado.Text = "1" Then
'                lblEstado.Text = "Aprobada"
'                lblEstado.ForeColor = Color.YellowGreen

'                btnAprobarProduccion.Enabled = False
'                btnAprobarProduccion.Image = My.Resources.ApproveOff
'                btnAprobarProduccion.Cursor = Cursors.Arrow
'                btnAnularProduccion.Enabled = True
'                btnAnularProduccion.Image = My.Resources.Anull
'                btnAnularProduccion.Cursor = Cursors.Hand

'                EliminarPictureBox.Enabled = False
'                EliminarPictureBox.Image = My.Resources.DeleteOff
'                EliminarPictureBox.Cursor = Cursors.Arrow
'                ModificarPictureBox.Enabled = False
'                ModificarPictureBox.Image = My.Resources.EditOff
'                ModificarPictureBox.Cursor = Cursors.Arrow
'                CancelarPictureBox.Enabled = False
'                CancelarPictureBox.Image = My.Resources.SaveCancelOff
'                CancelarPictureBox.Cursor = Cursors.Arrow
'                GuardarPictureBox.Enabled = False
'                GuardarPictureBox.Image = My.Resources.SaveOff
'                GuardarPictureBox.Cursor = Cursors.Arrow

'                pnlMotivoAnulacion.Visible = False
'                BtnAnular.Enabled = True
'                txtMotivoAnulacion.Enabled = True

'            ElseIf txtEstado.Text = "2" Then
'                lblEstado.Text = "Anulada"
'                lblEstado.ForeColor = Color.Maroon

'                btnAprobarProduccion.Enabled = False
'                btnAprobarProduccion.Image = My.Resources.ApproveOff
'                btnAnularProduccion.Enabled = False
'                btnAnularProduccion.Image = My.Resources.AnullOff

'                EliminarPictureBox.Enabled = False
'                EliminarPictureBox.Image = My.Resources.DeleteOff
'                ModificarPictureBox.Enabled = False
'                ModificarPictureBox.Image = My.Resources.EditOff

'                pnlMotivoAnulacion.Visible = True
'                BtnAnular.Enabled = False
'                txtMotivoAnulacion.Enabled = False

'            ElseIf txtEstado.Text = "" Then
'                If dgvDetalleProduccion.RowCount <> 0 Then
'                    'Quiere decir que es nuevo
'                    'Habilita()
'                    lblEstado.Text = "Pendiente"
'                    lblEstado.ForeColor = Color.Black
'                    pnlMotivoAnulacion.Visible = False
'                End If
'            End If
'        Catch ex As Exception

'        End Try
'    End Sub


'    Private Sub Limpiar()
'        txtPlanilla.Text = ""
'        txtPlanilla.Text = ""
'        txtCodigo.Text = ""
'        txtProducto.Text = ""
'        txtcantidad.Text = ""
'        cmbCategoria.Text = ""
'        txtDescripcion.Text = ""
'        dtpFecha.Text = ""
'        txtCantidadConsumo.Text = ""
'        txtCodigoItem.Text = ""
'    End Sub

'    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
'        permiso = PermisoAplicado(UsuCodigo, 207)
'        If permiso = 0 Then
'            MessageBox.Show("Usted no tiene permiso para Modificar una Produccion", "Pos Express")
'            Exit Sub
'        End If

'        ModificarPictureBox.Image = My.Resources.EditActive
'        Habilita()
'        txtCodigo.Focus()
'        nuevo = 0 : editar = 1
'        pnlProductos.SendToBack()
'    End Sub

'    Private Sub txtCodigo_GotFocus(sender As Object, e As System.EventArgs)
'        txtCodigo.BackColor = Color.LightSteelBlue
'    End Sub

'    Private Sub txtCodigo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
'        Dim KeyAscii As Short = Asc(e.KeyChar)
'        If KeyAscii = 13 Then
'            txtcantidad.Focus()
'        ElseIf KeyAscii = 42 Then
'            Cabecera = 1 : detalle = 0
'            PRODUCTOSBindingSource.RemoveFilter()
'            pnlProductos.Visible = True
'            pnlProductos.BringToFront()
'            txtBuscarProducto.Focus()
'        End If
'    End Sub

'    Private Sub txtcantidad_GotFocus(sender As Object, e As System.EventArgs)
'        txtcantidad.BackColor = Color.LightSteelBlue
'    End Sub

'    Private Sub txtcantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
'        Dim KeyAscii As Short = Asc(e.KeyChar)
'        If KeyAscii = 13 Then
'            cbxDeposito.Focus()
'        End If
'    End Sub

'    Private Sub dtpFecha_GotFocus(sender As Object, e As System.EventArgs)
'        dtpFecha.BackColor = Color.LightSteelBlue
'    End Sub


'    Private Sub cmbCategoria_GotFocus(sender As Object, e As System.EventArgs) Handles cmbCategoria.GotFocus
'        cmbCategoria.BackColor = Color.LightSteelBlue
'    End Sub

'  

'    Private Sub txtCantidadConsumo_GotFocus(sender As Object, e As System.EventArgs) Handles txtCantidadConsumo.GotFocus
'        txtCantidadConsumo.BackColor = Color.LightSteelBlue
'    End Sub


'    Private Sub txtCodigoItem_GotFocus(sender As Object, e As System.EventArgs) Handles txtCodigoItem.GotFocus
'        txtCodigoItem.BackColor = Color.LightSteelBlue
'    End Sub

'    Private Sub txtCodigoItem_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoItem.KeyPress
'        Dim KeyAscii As Short = Asc(e.KeyChar)
'        If KeyAscii = 13 Then
'            txtCantidadConsumo.Focus()
'        ElseIf KeyAscii = 42 Then
'            Cabecera = 0 : detalle = 1
'            txtBuscarProducto.Text = ""
'            pnlProductos.Visible = True

'            'Filtramos segun el tipo de producto
'            If cmbCategoria.Text = "Producto" Then
'                Me.PRODUCTOSTableAdapter.FillBy(Me.DsProduccion.PRODUCTOS, 0)
'            ElseIf cmbCategoria.Text = "Servicio" Then
'                Me.PRODUCTOSTableAdapter.FillBy(Me.DsProduccion.PRODUCTOS, 1)
'            ElseIf cmbCategoria.Text = "Producto Producido" Then
'                Me.PRODUCTOSTableAdapter.FillBy(Me.DsProduccion.PRODUCTOS, 2)
'            ElseIf cmbCategoria.Text = "Materia Prima" Then
'                Me.PRODUCTOSTableAdapter.FillBy(Me.DsProduccion.PRODUCTOS, 3)
'            End If

'            pnlProductos.BringToFront()
'            txtBuscarProducto.Focus()
'        End If
'    End Sub

'    Private Sub txtCodigo_LostFocus(sender As Object, e As System.EventArgs)
'        txtCodigo.BackColor = Color.Gainsboro

'        If txtCodigo.Text <> "" Then
'            txtProducto.Text = f.FuncionConsultaDosTablas("DESPRODUCTO", "PRODUCTOS", "CODIGOS", "CODPRODUCTO", "CODIGO", "" & txtCodigo.Text & "")
'            CodCodigoDetalleProducto.Text = f.FuncionConsultaDecimal("CODCODIGO", "CODIGOS", "CODIGO", txtCodigo.Text)
'        End If
'    End Sub

'    Private Sub txtcantidad_LostFocus(sender As Object, e As System.EventArgs)
'        txtcantidad.BackColor = Color.Gainsboro
'    End Sub

'    Private Sub dtpFecha_LostFocus(sender As Object, e As System.EventArgs)
'        dtpFecha.BackColor = Color.Gainsboro
'    End Sub

'    Private Sub cmbCategoria_LostFocus(sender As Object, e As System.EventArgs) Handles cmbCategoria.LostFocus
'        cmbCategoria.BackColor = Color.Gainsboro
'    End Sub

'    Private Sub txtCodigoItem_LostFocus(sender As Object, e As System.EventArgs) Handles txtCodigoItem.LostFocus
'        txtCodigoItem.BackColor = Color.Gainsboro

'        If txtCodigoItem.Text <> "" Then
'            txtDescripcion.Text = f.FuncionConsultaDosTablas("DESPRODUCTO", "PRODUCTOS", "CODIGOS", "CODPRODUCTO", "CODIGO", "" & txtCodigoItem.Text & "")
'            txtCodCodigoOperacionDetalle.Text = f.FuncionConsultaDecimal("CODCODIGO", "CODIGOS", "CODIGO", txtCodigoItem.Text)
'            Dim CodMedida As Integer = f.FuncionConsultaDosTablas("CODMEDIDA", "PRODUCTOS", "CODIGOS", "CODPRODUCTO", "CODIGO", "" & txtCodigoItem.Text & "")
'            cbxMedida.Text = f.FuncionConsultaString("DESMEDIDA", "UNIDADMEDIDA", "CODMEDIDA", CodMedida)
'        End If
'    End Sub

'    Private Sub txtCantidadConsumo_LostFocus(sender As Object, e As System.EventArgs) Handles txtCantidadConsumo.LostFocus
'        txtCantidadConsumo.BackColor = Color.Gainsboro
'    End Sub

'    Private Sub txtBuscarProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarProducto.TextChanged
'        Try
'            PRODUCTOSBindingSource.Filter = "CODIGO like '%" & txtBuscarProducto.Text & "%' OR DESPRODUCTO like '%" & txtBuscarProducto.Text & "%'"
'        Catch ex As Exception
'        End Try
'    End Sub


'    Private Sub btnAgregarGrilla_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregarGrilla.Click
'        Dim CodCategoria As Integer

'        If txtCodigoItem.Text = "" Then
'            MessageBox.Show("Indique el Código del Producto", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            txtCodigoItem.Focus()
'            txtCodigoItem.BackColor = Color.Pink
'            Exit Sub
'        End If
'        If txtCantidadConsumo.Text = "" Then
'            MessageBox.Show("Indique la cantidad a produción", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            txtCantidadConsumo.Focus()
'            txtCantidadConsumo.BackColor = Color.Pink
'            Exit Sub
'        End If

'        If cbxMedida.Text = "" Then
'            MessageBox.Show("Indique la Unidad de Medida ", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            cbxMedida.Focus()
'            cbxMedida.BackColor = Color.Pink
'            Exit Sub
'        End If

'        Try
'            Me.PRODUCCIONDETBindingSource.AddNew()
'            Dim c As Integer = dgvOperacion.RowCount

'            If cmbCategoria.Text = "Producto" Then
'                CodCategoria = 0
'            ElseIf cmbCategoria.Text = "Servicio" Then
'                CodCategoria = 1
'            ElseIf cmbCategoria.Text = "Producto Producido" Then
'                CodCategoria = 2
'            ElseIf cmbCategoria.Text = "Materia Prima" Then
'                CodCategoria = 3
'            End If

'            dgvOperacion.Rows(c - 1).Cells("DESCRIPTIPORELACIONDataGridViewTextBoxColumn").Value = cmbCategoria.Text
'            dgvOperacion.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value = txtCantidadConsumo.Text
'            dgvOperacion.Rows(c - 1).Cells("IDRELACIONDataGridViewTextBoxColumn").Value = txtCodCodigoOperacionDetalle.Text
'            dgvOperacion.Rows(c - 1).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = txtDescripcion.Text
'            dgvOperacion.Rows(c - 1).Cells("CODTIPORELACIONDataGridViewTextBoxColumn").Value = CodCategoria
'            dgvOperacion.Rows(c - 1).Cells("UNIDADMEDIDA").Value = cbxMedida.Text
'            dgvOperacion.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I"

'            cmbCategoria.Text = "Materia Prima"
'            txtCodigoItem.Text = ""
'            txtCantidadConsumo.Text = ""
'            txtDescripcion.Text = ""
'            lblUnidadMedida.Text = ""
'            txtCodCodigoOperacionDetalle.Text = ""
'            txtCodigoItem.Focus()

'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub cbxMedida_GotFocus(sender As Object, e As System.EventArgs) Handles cbxMedida.GotFocus
'        cbxMedida.BackColor = Color.LightSteelBlue
'    End Sub



'    Private Sub cbxMedida_LostFocus(sender As Object, e As System.EventArgs) Handles cbxMedida.LostFocus
'        cbxMedida.BackColor = Color.Gainsboro
'    End Sub

'    Private Sub dgvProducto_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProducto.CellDoubleClick
'        If dgvProducto.RowCount <> 0 Then
'            If Cabecera = 1 Then
'                CodCodigoDetalleProducto.Text = dgvProducto.CurrentRow.Cells("CODCODIGO").Value
'                txtCodigo.Text = dgvProducto.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
'                txtProducto.Text = dgvProducto.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
'                txtcantidad.Focus()
'            ElseIf detalle = 1 Then
'                txtCodCodigoOperacionDetalle.Text = dgvProducto.CurrentRow.Cells("CODCODIGO").Value
'                txtCodigoItem.Text = dgvProducto.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
'                txtDescripcion.Text = dgvProducto.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
'                cbxMedida.Text = dgvProducto.CurrentRow.Cells("DESMEDIDA").Value
'                txtCantidadConsumo.Focus()
'            End If
'            pnlProductos.Visible = False
'            pnlProductos.BringToFront()
'        End If
'    End Sub

'    Private Sub btnCerrarPanel_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarPanel.Click
'        pnlProductos.SendToBack()
'        pnlProductos.Visible = False
'    End Sub

'    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
'        Dim transaction As SqlTransaction = Nothing

'        'Verificaciones
'        If txtCodigo.Text = "" Then
'            MessageBox.Show("Indique el Código del Producto", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            txtCodigo.Focus()
'            txtCodigo.BackColor = Color.Pink
'            Exit Sub
'        End If

'        If cbxDeposito.Text = "" Then
'            MessageBox.Show("Indique un Desposito", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            cbxDeposito.Focus()
'            cbxDeposito.BackColor = Color.Pink
'            Exit Sub
'        End If

'        If dgvOperacion.RowCount = 0 Then
'            MessageBox.Show("La Produccion debe tener un detalle", "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            cmbCategoria.Focus()
'            cmbCategoria.BackColor = Color.Pink
'            Exit Sub
'        End If

'        Me.Cursor = Cursors.AppStarting
'        'verificamos si es un Insert o Un Update
'        If editar = 1 Then
'            ser.Abrir(sqlc)
'            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

'            cmd.Connection = sqlc
'            cmd.Transaction = myTrans
'            Try
'                ActualizaProduccionCabecera(myTrans)
'                ActualizaProduccionDetalleProducto(myTrans)
'                vgProduccionCab = txtPlanilla.Text
'                InsertarProduccionDetalleOperacion(myTrans)

'                myTrans.Commit()

'            Catch ex As Exception
'                Try
'                    myTrans.Rollback("Insertar")
'                Catch

'                End Try
'                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Me.CancelarPictureBox.PerformLayout()

'            Finally
'                sqlc.Close()

'            End Try

'        ElseIf nuevo = 1 Then
'            ser.Abrir(sqlc)
'            myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

'            cmd.Connection = sqlc
'            cmd.Transaction = myTrans
'            Try
'                InsertarProduccionCabecera(myTrans)
'                InsertarProduccionDetalleProducto(myTrans)
'                InsertarProduccionDetalleOperacion(myTrans)

'                myTrans.Commit()

'            Catch ex As Exception
'                Try
'                    myTrans.Rollback("Insertar")
'                Catch

'                End Try
'                MessageBox.Show("Error al Guardar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Me.CancelarPictureBox.PerformLayout()

'            Finally
'                sqlc.Close()

'            End Try
'        End If

'        FechaFiltro()

'        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'        Dim Concat As Date = FechaFiltro1
'        Dim Concat2 As Date = FechaFiltro2

'        fecha = Concat.ToString("dd/MM/yyy")
'        fecha2 = Concat2.ToString("dd/MM/yyy")
'        FechaDesde = fecha & " 00:00:00"
'        FechaHasta = fecha2 & " 23:59:00"

'        TempIdProduccion = Me.txtPlanilla.Text
'        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)

'        For i = 0 To dgvDetalleProduccion.RowCount - 1
'            If dgvDetalleProduccion.Rows(i).Cells("IDPRODCABDataGridViewTextBoxColumn").Value = TempIdProduccion Then
'                PRODUCCIONCABBindingSource.Position = i
'            End If
'        Next

'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If

'        Deshabilita()

'        Me.Cursor = Cursors.Arrow
'    End Sub

'    Private Sub InsertarProduccionCabecera(ByRef myTrans As System.Data.Common.DbTransaction)
'        Dim consulta As System.String
'        Dim hora As String = Now.ToString("HH:mm:ss")
'        Dim Concat As String = dtpFecha.Text
'        Dim Concatenar As String = Concat & " " + hora

'        consulta = "INSERT INTO PRODUCCIONCAB  (DESCRIPCION,FECHAINICIO,CODUSUARIO,ESTADO, CODSUCURSAL) VALUES" & _
'                   "('" & txtProducto.Text & "',CONVERT(DATETIME, '" & Concatenar & "', 103)," & UsuCodigo & ",0," & cbxDeposito.SelectedValue & ")" & _
'                   "SELECT IDPRODCAB FROM PRODUCCIONCAB WHERE IDPRODCAB = SCOPE_IDENTITY();"
'        cmd.CommandText = consulta
'        vgProduccionCab = cmd.ExecuteScalar()
'    End Sub

'    Private Sub ActualizaProduccionCabecera(ByRef myTrans As System.Data.Common.DbTransaction)
'        Dim consulta As System.String
'        Dim hora As String = Now.ToString("HH:mm:ss")
'        Dim Concat As String = dtpFecha.Text
'        Dim Concatenar As String = Concat & " " + hora

'        consulta = "UPDATE PRODUCCIONCAB SET DESCRIPCION= '" & txtProducto.Text & "' ,FECHAINICIO = CONVERT(DATETIME, '" & Concatenar & "', 103),CODUSUARIO = " & UsuCodigo & ",ESTADO= 0 , " & _
'                    "CODSUCURSAL = " & cbxDeposito.SelectedValue & "    WHERE IDPRODCAB = " & txtPlanilla.Text

'        cmd.CommandText = consulta
'        vgProduccionCab = cmd.ExecuteScalar()
'    End Sub

'    Private Sub InsertarProduccionDetalleProducto(ByRef myTrans As System.Data.Common.DbTransaction)
'        Dim consulta As System.String
'        Dim Cantidad As Integer

'        If txtcantidad.Text = "" Then
'            Cantidad = 0
'        Else
'            Cantidad = CDec(txtcantidad.Text)
'        End If

'        consulta = "INSERT INTO PRODUCCIONDETPRODUCTO (IDPRODCAB,CODCODIGO,DESCRIPRODUCTO,CANTIDAD) VALUES  " & _
'            "(" & vgProduccionCab & "," & CDec(CodCodigoDetalleProducto.Text) & ",'" & txtProducto.Text & "'," & Cantidad & ")"
'        Consultas.ConsultaComando(myTrans, consulta)
'    End Sub

'    Private Sub ActualizaProduccionDetalleProducto(ByRef myTrans As System.Data.Common.DbTransaction)
'        Dim consulta As System.String
'        Dim Cantidad As Integer

'        If txtcantidad.Text = "" Then
'            Cantidad = 0
'        Else
'            Cantidad = CDec(txtcantidad.Text)
'        End If

'        consulta = "UPDATE PRODUCCIONDETPRODUCTO SET CODCODIGO = " & CDec(CodCodigoDetalleProducto.Text) & ",DESCRIPRODUCTO = '" & txtProducto.Text & "',CANTIDAD = " & Cantidad & "   " & _
'                    "WHERE IDPRODCAB = " & txtPlanilla.Text

'        Consultas.ConsultaComando(myTrans, consulta)
'    End Sub

'    Private Sub InsertarProduccionDetalleOperacion(ByRef myTrans As System.Data.Common.DbTransaction)
'        Dim consulta As System.String
'        Dim CodCategoria, Cantidad, CodCodigo As Integer
'        Dim Categoria, DescripItem, UnidadMedida As String

'        For c = 0 To dgvOperacion.RowCount - 1
'            If IsDBNull(dgvOperacion.Rows(c).Cells("CODTIPORELACIONDataGridViewTextBoxColumn").Value) Then
'            Else
'                CodCategoria = dgvOperacion.Rows(c).Cells("CODTIPORELACIONDataGridViewTextBoxColumn").Value
'            End If
'            If IsDBNull(dgvOperacion.Rows(c).Cells("DESCRIPTIPORELACIONDataGridViewTextBoxColumn").Value) Then
'            Else
'                Categoria = dgvOperacion.Rows(c).Cells("DESCRIPTIPORELACIONDataGridViewTextBoxColumn").Value
'            End If
'            If IsDBNull(dgvOperacion.Rows(c).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value) Then
'            Else
'                DescripItem = dgvOperacion.Rows(c).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
'            End If
'            If IsDBNull(dgvOperacion.Rows(c).Cells("UNIDADMEDIDA").Value) Then
'            Else
'                UnidadMedida = dgvOperacion.Rows(c).Cells("UNIDADMEDIDA").Value
'            End If
'            If IsDBNull(dgvOperacion.Rows(c).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
'            Else
'                Cantidad = dgvOperacion.Rows(c).Cells("CANTIDADDataGridViewTextBoxColumn").Value
'            End If
'            If IsDBNull(dgvOperacion.Rows(c).Cells("IDRELACIONDataGridViewTextBoxColumn").Value) Then
'            Else
'                CodCodigo = dgvOperacion.Rows(c).Cells("IDRELACIONDataGridViewTextBoxColumn").Value
'            End If

'            If dgvOperacion.Rows(c).Cells("ESTADOGRILLA").Value = "I" Then
'                consulta = "INSERT INTO PRODUCCIONDETOPERACION (IDPRODCAB,IDRELACION,CODTIPORELACION,DESCRIPTIPORELACION,CANTIDAD,UNIDADMEDIDA) VALUES" & _
'                            "(" & vgProduccionCab & "," & CodCodigo & "," & CodCategoria & ",'" & Categoria & "'," & Cantidad & ",'" & UnidadMedida & "')"
'                Consultas.ConsultaComando(myTrans, consulta)
'            End If
'        Next
'    End Sub

'    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
'        Deshabilita()
'        Me.PRODUCCIONCABBindingSource.CancelEdit()
'        Me.PRODUCCIONDETBindingSource.CancelEdit()

'        FechaFiltro()

'        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'        Dim Concat As Date = FechaFiltro1
'        Dim Concat2 As Date = FechaFiltro2

'        fecha = Concat.ToString("dd/MM/yyy")
'        fecha2 = Concat2.ToString("dd/MM/yyy")
'        FechaDesde = fecha & " 00:00:00"
'        FechaHasta = fecha2 & " 23:59:00"

'        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If
'    End Sub

'    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
'        FechaFiltro()

'        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'        Dim Concat As Date = FechaFiltro1
'        Dim Concat2 As Date = FechaFiltro2

'        fecha = Concat.ToString("dd/MM/yyy")
'        fecha2 = Concat2.ToString("dd/MM/yyy")
'        FechaDesde = fecha & " 00:00:00"
'        FechaHasta = fecha2 & " 23:59:00"

'        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If
'    End Sub

'    Private Sub btnEliminarGrilla_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarGrilla.Click
'        Dim sql As String

'        If dgvOperacion.RowCount = 0 Then
'            MessageBox.Show("Debe seleccionar un Dato a eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        If MessageBox.Show("¿Desea Eliminar este Registro?", "Pos Express", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
'            Exit Sub
'        End If

'        If dgvOperacion.CurrentRow.Cells("ESTADOGRILLA").Value = "I" Then
'            dgvOperacion.Rows.Remove(Me.dgvOperacion.CurrentRow)
'        Else
'            Try
'                dgvOperacion.Rows.Remove(Me.dgvOperacion.CurrentRow)

'                ser.Abrir(sqlc)
'                cmd.Connection = sqlc
'                sql = ""
'                sql = "DELETE PRODUCCIONDETOPERACION WHERE IDPRODCAB  = " & txtPlanilla.Text & "  AND IDRELACION = " & dgvOperacion.CurrentRow.Cells("IDRELACIONDataGridViewTextBoxColumn").Value
'                cmd.CommandText = sql
'                cmd.ExecuteNonQuery()

'                sqlc.Close()

'            Catch ex As Exception
'                MessageBox.Show("Problema al Eliminar: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'                Exit Sub
'            End Try
'        End If
'    End Sub

'    Private Sub txtEstado_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEstado.TextChanged
'        VerificarEstado()
'    End Sub

'    Private Sub btnAprobarProduccion_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobarProduccion.Click
'        permiso = PermisoAplicado(UsuCodigo, 208)
'        If permiso = 0 Then
'            MessageBox.Show("Usted no tiene permiso para Aprobar una Produccion", "Pos Express")
'            Exit Sub
'        End If

'        Dim sql As String = ""
'        'Antes de Aprobar Verificamos que tenga alguna cantidad ingresada distinto de Cero
'        If txtcantidad.Text = "" Or txtcantidad.Text = "0" Or txtcantidad.Text = "0,00" Then
'            MessageBox.Show("Debe Ingresar una Cantidad Mayor a Cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End If

'        FechaFiltro()

'        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'        Dim Concat As Date = FechaFiltro1
'        Dim Concat2 As Date = FechaFiltro2

'        fecha = Concat.ToString("dd/MM/yyy")
'        fecha2 = Concat2.ToString("dd/MM/yyy")
'        FechaDesde = fecha & " 00:00:00"
'        FechaHasta = fecha2 & " 23:59:00"

'        ProduccionCosteo(Me.txtPlanilla.Text)

'        'Actualizamos el Estado de Plantilla
'        Try
'            ser.Abrir(sqlc)
'            cmd.Connection = sqlc
'            sql = ""
'            sql = "UPDATE PRODUCCIONCAB  SET ESTADO = 1 WHERE IDPRODCAB  = " & txtPlanilla.Text
'            cmd.CommandText = Sql
'            cmd.ExecuteNonQuery()

'            sqlc.Close()

'        Catch ex As Exception
'            MessageBox.Show("Problema al Aprobar la Produccion: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End Try

'        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)

'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If

'        Deshabilita()
'    End Sub

'    Private Sub dgvDetalleProduccion_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDetalleProduccion.DataError
'        Try

'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub dgvDetalleProduccion_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgvDetalleProduccion.SelectionChanged
'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If
'    End Sub

'    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
'        Try
'            If BuscarTextBox.Text <> "" Then
'                Me.PRODUCCIONCABBindingSource.Filter = "IDPRODCAB =  " & BuscarTextBox.Text
'            Else
'                Me.PRODUCCIONCABBindingSource.RemoveFilter()
'            End If
'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub btnAnularProduccion_Click(sender As System.Object, e As System.EventArgs) Handles btnAnularProduccion.Click
'        pnlMotivoAnulacion.Visible = True
'        pnlMotivoAnulacion.BringToFront()
'        txtMotivoAnulacion.Focus()
'    End Sub

'    Private Sub BtnCerrarAnular_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrarAnular.Click
'        pnlMotivoAnulacion.Visible = False
'    End Sub

'    Private Sub BtnAnular_Click(sender As System.Object, e As System.EventArgs) Handles BtnAnular.Click
'        permiso = PermisoAplicado(UsuCodigo, 209)
'        If permiso = 0 Then
'            MessageBox.Show("Usted no tiene permiso para Anular una Produccion", "Pos Express")
'            Exit Sub
'        End If

'        Dim sql As String
'        'Se debe descontar el Stock del Producto y Aumentar el Stock de la Materia Prima.
'        If txtMotivoAnulacion.Text = "" Then
'            MessageBox.Show("Debe Ingresar un Motivo de Anulacion", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            txtMotivoAnulacion.Focus()
'            Exit Sub
'        End If

'        If MessageBox.Show("¿Desea Anular este Registro?", "Pos Express", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
'            Exit Sub
'        End If

'        FechaFiltro()

'        Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'        Dim Concat As Date = FechaFiltro1
'        Dim Concat2 As Date = FechaFiltro2

'        fecha = Concat.ToString("dd/MM/yyy")
'        fecha2 = Concat2.ToString("dd/MM/yyy")
'        FechaDesde = fecha & " 00:00:00"
'        FechaHasta = fecha2 & " 23:59:00"

'        AnularProduccion(Me.txtPlanilla.Text)

'        'Actualizamos el Estado de Plantilla
'        Try
'            ser.Abrir(sqlc)
'            cmd.Connection = sqlc
'            sql = ""
'            sql = "UPDATE PRODUCCIONCAB  SET ESTADO = 2 , MOTIVOANULADO = '" & txtMotivoAnulacion.Text & "'   WHERE IDPRODCAB  = " & txtPlanilla.Text
'            cmd.CommandText = sql
'            cmd.ExecuteNonQuery()

'            sqlc.Close()

'        Catch ex As Exception
'            MessageBox.Show("Problema al Aprobar la Produccion: " & ex.Message, "PosExpress", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            Exit Sub
'        End Try

'        Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)

'        If dgvDetalleProduccion.RowCount <> 0 Then
'            Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'        End If
'    End Sub

'    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
'        permiso = PermisoAplicado(UsuCodigo, 206)
'        If permiso = 0 Then
'            MessageBox.Show("Usted no tiene permiso para Eliminar una Produccion", "Pos Express")
'            Exit Sub
'        End If

'        If MessageBox.Show("¿Esta seguro que quiere eliminar la Produccion?", "PosExpress", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
'            Exit Sub
'        End If

'        Me.Cursor = Cursors.AppStarting
'        Dim transaction As SqlTransaction = Nothing
'        ser.Abrir(sqlc)
'        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Eliminar")

'        cmd.Connection = sqlc
'        cmd.Transaction = myTrans

'        Try
'            EliminaProduccionDetalleOperacion()
'            EliminaProduccionDetalleProducto()
'            EliminaProduccionCabecera()

'            myTrans.Commit()

'            Deshabilita()
'            FechaFiltro()

'            Dim FechaDesde, FechaHasta, fecha, fecha2 As String
'            Dim Concat As Date = FechaFiltro1
'            Dim Concat2 As Date = FechaFiltro2

'            fecha = Concat.ToString("dd/MM/yyy")
'            fecha2 = Concat2.ToString("dd/MM/yyy")
'            FechaDesde = fecha & " 00:00:00"
'            FechaHasta = fecha2 & " 23:59:00"

'            Me.PRODUCCIONCABTableAdapter.Fill(Me.DsProduccion.PRODUCCIONCAB, FechaDesde, FechaHasta)
'            If dgvDetalleProduccion.RowCount <> 0 Then
'                Me.PRODUCCIONDETTableAdapter.Fill(Me.DsProduccion.PRODUCCIONDET, dgvDetalleProduccion.CurrentRow.Cells("IDPRODCAB").Value)
'            End If

'        Catch ex As SqlException
'            Try
'                myTrans.Rollback("")
'            Catch

'            End Try

'            Dim NroError As Integer = ex.Number
'            Dim Mensaje As String = ex.Message
'            If NroError = 547 Then
'                MessageBox.Show("Esta Produccion que desea eliminar tiene relaciones con otros datos del sistema, y por tanto no se podra eliminar", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
'            Else
'                MessageBox.Show("Error al Eliminar la  Produccion: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Warning)
'            End If

'        Finally
'            sqlc.Close()
'        End Try

'        Me.Cursor = Cursors.Arrow
'    End Sub

'    Private Sub EliminaProduccionDetalleOperacion()
'        Dim sql As String

'        sql = ""
'        sql = " DELETE FROM PRODUCCIONDETOPERACION " & _
'              " WHERE IDPRODCAB= " & CDec(Me.txtPlanilla.Text)
'        cmd.CommandText = sql
'        cmd.ExecuteNonQuery()
'    End Sub

'    Private Sub EliminaProduccionDetalleProducto()
'        Dim sql As String

'        sql = ""
'        sql = " DELETE FROM PRODUCCIONDETPRODUCTO " & _
'              " WHERE IDPRODCAB= " & CDec(Me.txtPlanilla.Text)
'        cmd.CommandText = sql
'        cmd.ExecuteNonQuery()
'    End Sub

'    Private Sub EliminaProduccionCabecera()
'        Dim sql As String

'        sql = ""
'        sql = " DELETE FROM PRODUCCIONCAB " & _
'              " WHERE IDPRODCAB= " & CDec(Me.txtPlanilla.Text)
'        cmd.CommandText = sql
'        cmd.ExecuteNonQuery()
'    End Sub
