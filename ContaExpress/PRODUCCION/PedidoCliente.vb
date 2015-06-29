Imports System
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class PedidoCliente
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim permiso As Double
    Dim f As New Funciones.Funciones
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim vgNuevo, vgEditar As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub OrdenProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            permiso = PermisoAplicado(UsuCodigo, 278)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso Abrir esta Ventana", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            Else
                CmbAño.SelectedText = Today.Year.ToString
                CmbMes.SelectedIndex = Today.Month - 1

                FechaFiltro()

                Me.CLIENTESTableAdapter.Fill(Me.DsOrdenTrabajo.CLIENTES)
                ORDENTRABAJOCONSULTATableAdapter.Fill(DsOrdenTrabajo1.ORDENTRABAJOCONSULTA, FechaFiltro1, FechaFiltro2)
                Me.PRODUCTOSOTTableAdapter.Fill(Me.DsOrdenTrabajo.PRODUCTOSOT)
            End If
        Catch ex As Exception
        End Try

        DesHabilitar()
        vgNuevo = 0 : vgEditar = 0
    End Sub

    Private Sub DesHabilitar()
        pnlCabecera.Enabled = False

        tbxCodigoProducto.Enabled = False
        btnBuscProductos.Enabled = False
        txtCantidad.Enabled = False
        tbxCantidadProducir.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarProducto.Enabled = False

        dgwOrdenTrabajo.Enabled = True
        BuscarTextBox.Enabled = True

        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        pbxImprimirOrden.Enabled = True
        pbxImprimirOrden.Image = My.Resources.Print
        pbxImprimirOrden.Cursor = Cursors.Hand
        btnRenviar.Enabled = True
        btnRenviar.Image = My.Resources.SendEmail
        btnRenviar.Cursor = Cursors.Hand

        Try
            STOCKACTUAL.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Habilitar()
        pnlCabecera.Enabled = True

        tbxCodigoProducto.Enabled = True
        btnBuscProductos.Enabled = True
        txtCantidad.Enabled = True
        tbxCantidadProducir.Enabled = True
        btnAgregar.Enabled = True
        btnEliminarProducto.Enabled = True

        dgwOrdenTrabajo.Enabled = False
        BuscarTextBox.Enabled = False

        NuevoPictureBox.Image = My.Resources.NewOff
        NuevoPictureBox.Enabled = False
        NuevoPictureBox.Cursor = Cursors.Arrow
        EliminarPictureBox.Enabled = False
        EliminarPictureBox.Image = My.Resources.DeleteOff
        EliminarPictureBox.Cursor = Cursors.Arrow
        ModificarPictureBox.Enabled = False
        ModificarPictureBox.Image = My.Resources.EditOff
        ModificarPictureBox.Cursor = Cursors.Arrow

        CancelarPictureBox.Enabled = True
        CancelarPictureBox.Image = My.Resources.SaveCancel
        CancelarPictureBox.Cursor = Cursors.Hand
        GuardarPictureBox.Enabled = True
        GuardarPictureBox.Image = My.Resources.Save
        GuardarPictureBox.Cursor = Cursors.Hand

        pbxImprimirOrden.Enabled = False
        pbxImprimirOrden.Image = My.Resources.PrintOff
        pbxImprimirOrden.Cursor = Cursors.Default
        btnRenviar.Enabled = False
        btnRenviar.Image = My.Resources.SendEmailOff
        btnRenviar.Cursor = Cursors.Default

        Try
            STOCKACTUAL.Visible = True
        Catch ex As Exception
        End Try
    End Sub

    Sub FechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String

        nromes = CmbMes.SelectedIndex + 1
        nroaño = CInt(CmbAño.Text)

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString
        End If

        fechacompleta1 = "01" + "/" + nromes.ToString + "/" + CmbAño.Text
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + nromes.ToString + "/" + CmbAño.Text

        ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
            If nromes = 2 Then
                If (nroaño - 1992) Mod 4 = 0 Then
                    fechacompleta2 = "29" + "/" + mes.ToString + "/" + nroaño.ToString
                Else
                    fechacompleta2 = "28" + "/" + mes.ToString + "/" + nroaño.ToString
                End If
            Else
                fechacompleta2 = "30" + "/" + mes.ToString + "/" + nroaño.ToString
            End If

        End If

        fechacompleta1 = fechacompleta1 + " 00:00:00.000"
        fechacompleta2 = fechacompleta2 + " 23:59:59.900"

        FechaFiltro1 = CDate(fechacompleta1)
        FechaFiltro2 = CDate(fechacompleta2)
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 274)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear una Orden de Trabajo", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Dim UltimoNro, NroDigitos, Existe As Integer
        Dim NroOrdenTrabajo As String

        Habilitar()
        TxtNumCliente.Focus()

        Try
            ORDENTRABAJOCONSULTABindingSource.AddNew()
            OTDETCONSULTATableAdapter.Fill(DsOrdenTrabajo.OTDETCONSULTA, 0)
        Catch ex As Exception
        End Try

        vgNuevo = 1
        txtUsuario.Text = UsuNombre

        Try
            'Obtenemos la numeracion de la Orden de trabajo
            Dim objCommand As New SqlCommand
            objCommand.CommandText = "SELECT ULTIMO, NRODIGITOS FROM dbo.DETPC WHERE (CODCOMPROBANTE = 9) AND (ACTIVO = 1)"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()

            Dim odrNumeracion As SqlDataReader = objCommand.ExecuteReader()
            If odrNumeracion.HasRows Then
                Do While odrNumeracion.Read()
                    UltimoNro = odrNumeracion("ULTIMO") + 1
                    NroDigitos = odrNumeracion("NRODIGITOS")
                    Existe = 1
                Loop
            Else
                Existe = 0
            End If

            odrNumeracion.Close()
            objCommand.Dispose()

            If Existe = 1 Then
                NroOrdenTrabajo = CStr(UltimoNro)
                For i = 1 To NroDigitos
                    If Len(NroOrdenTrabajo) = NroDigitos Then
                        Exit For
                    Else
                        NroOrdenTrabajo = "0" & NroOrdenTrabajo
                    End If
                Next

                lblNroConsumo.Text = NroOrdenTrabajo
            Else
                MessageBox.Show("Verifique el Rango del Comprobante (DashBoard >> Configuracion >> 'Rango de Comprobantes')", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNumCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNumCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            CmbCliente.Focus()
        End If
    End Sub

    Private Sub TxtNumCliente_LostFocus(sender As Object, e As System.EventArgs) Handles TxtNumCliente.LostFocus
        'Obtenemos los datos del cliente
        Try
            Dim objCommand As New SqlCommand

            objCommand.CommandText = "SELECT CODCLIENTE, NUMCLIENTE, NOMBRE FROM dbo.CLIENTES WHERE (NUMCLIENTE = " & TxtNumCliente.Text & ")"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()

            Dim odrNumeracion As SqlDataReader = objCommand.ExecuteReader()
            If odrNumeracion.HasRows Then
                Do While odrNumeracion.Read()
                    CmbCliente.Text = odrNumeracion("NOMBRE")
                Loop
            End If

            odrNumeracion.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbCliente_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCliente.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaInicio.Focus()
        End If

        If KeyAscii = 42 Then
            upcClientes.Show()
            txtBuscarCliente.Text = ""
            txtBuscarCliente.Focus()

            e.Handled = True
        End If
    End Sub

    Private Sub dtpFechaFin_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtObservacion.Focus()
        End If
    End Sub

    Private Sub txtObservacion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCodigoProducto.Focus()
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            'Calculamos la cantidad a produccir
            Dim vAprod As Integer = 0
            If lblEnStock.Text > 0 Then
                If CDec(txtCantidad.Text) > CDec(lblEnStock.Text) Then
                    vAprod = CDec(txtCantidad.Text) - CDec(lblEnStock.Text)
                Else
                    vAprod = 0
                End If
            Else
                vAprod = CDec(txtCantidad.Text)
            End If

            tbxCantidadProducir.Text = vAprod
            tbxCantidadProducir.Focus()
        End If
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        upcClientes.Show()
        txtBuscarCliente.Text = ""
        txtBuscarCliente.Focus()
    End Sub

    Private Sub txtBuscarCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarCliente.TextChanged
        CLIENTESBindingSource.Filter = "NOMBRE LIKE '%" & txtBuscarCliente.Text & "%' OR RUC LIKE '%" & txtBuscarCliente.Text & "%'"
    End Sub

    Private Sub dgwClientes_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwClientes.DoubleClick
        If dgwClientes.Rows.Count <> 0 Then
            TxtNumCliente.Text = dgwClientes.CurrentRow.Cells("NUMCLIENTEDataGridViewTextBoxColumn").Value
            CmbCliente.Text = dgwClientes.CurrentRow.Cells("NOMBREDataGridViewTextBoxColumn1").Value
        End If
        upcClientes.Close()
    End Sub

    Private Sub txtBuscarProducto_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarProducto.TextChanged
        PRODUCTOSOTBindingSource.Filter = "DESPRODUCTO LIKE '%" & txtBuscarProducto.Text & "%' OR CODIGO LIKE '%" & txtBuscarProducto.Text & "%'"
    End Sub

    Private Sub dgwProductos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwProductos.DoubleClick
        If dgwProductos.Rows.Count <> 0 Then
            tbxCodigoProducto.Text = dgwProductos.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
            DesProductoTextBox.Text = dgwProductos.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
            txtCodCodigo.Text = dgwProductos.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
            lblEnStock.Text = FormatNumber(dgwProductos.CurrentRow.Cells("STOCKACTUALDataGridViewTextBoxColumn2").Value, 0)

            txtCantidad.Focus()
        End If
        upcProductos.Close()
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        upcProductos.Show()
        txtBuscarProducto.Text = ""
        txtBuscarProducto.Focus()
    End Sub

    Private Sub tbxCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCantidad.Focus()
        End If

        If KeyAscii = 42 Then
            upcProductos.Show()
            txtBuscarProducto.Text = ""
            txtBuscarProducto.Focus()

            e.Handled = True
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        Try
            If tbxCodigoProducto.Text = "" Then
                MessageBox.Show("Ingrese el Codigo del Producto", "COGENT SIG", MessageBoxButtons.OK)
                tbxCodigoProducto.Focus()
                Exit Sub
            End If

            If txtCantidad.Text = "" Then
                MessageBox.Show("Ingrese la Cantidad", "COGENT SIG", MessageBoxButtons.OK)
                txtCantidad.Focus()
                Exit Sub
            End If

            OTDETCONSULTABindingSource.AddNew()
            Dim c As Integer = dgwOTDetalle.RowCount

            dgwOTDetalle.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn1").Value = tbxCodigoProducto.Text
            dgwOTDetalle.Rows(c - 1).Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value = DesProductoTextBox.Text
            dgwOTDetalle.Rows(c - 1).Cells("CANTIDADPEDIDA").Value = CDec(txtCantidad.Text)
            dgwOTDetalle.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn1").Value = txtCodCodigo.Text
            dgwOTDetalle.Rows(c - 1).Cells("STOCKACTUAL").Value = CDec(lblEnStock.Text)
            dgwOTDetalle.Rows(c - 1).Cells("CANTIDADAPRODUCIR").Value = CDec(tbxCantidadProducir.Text)
            dgwOTDetalle.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

            tbxCodigoProducto.Text = "" : txtCantidad.Text = "" : DesProductoTextBox.Text = "" : txtCodCodigo.Text = "" : lblEnStock.Text = "En Stock" : tbxCantidadProducir.Text = ""
            tbxCodigoProducto.Focus()

            SumarTotales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            ORDENTRABAJOCONSULTABindingSource.CancelEdit()
            OTDETCONSULTABindingSource.CancelEdit()

            DesHabilitar()
            ORDENTRABAJOCONSULTATableAdapter.Fill(DsOrdenTrabajo1.ORDENTRABAJOCONSULTA, FechaFiltro1, FechaFiltro2)

            tbxCodigoProducto.Text = "" : txtCantidad.Text = "" : DesProductoTextBox.Text = "" : txtCodCodigo.Text = ""
            vgNuevo = 0 : vgEditar = 0
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Try
            Dim UltimoRegistro As Integer
            If vgNuevo = 1 Then
                ser.Abrir(sqlc)
                cmd.Connection = sqlc

                Dim Sql As String = "INSERT INTO ORDENTRABAJO (CODCLIENTE, CODUSUARIO, OBS, FECHAINI, NROORDENTRABAJO,ESTADO)  " & _
                                    "VALUES (" & CInt(CmbCliente.SelectedValue) & ", " & UsuCodigo & ",'" & txtObservacion.Text & "', CONVERT (DATETIME, '" & dtpFechaInicio.Text & "',103),'" & lblNroConsumo.Text & "','" & cbxEstado.Text & "')  " & _
                                    "SELECT ID FROM ORDENTRABAJO WHERE ID = SCOPE_IDENTITY();"

                cmd.CommandText = Sql
                UltimoRegistro = cmd.ExecuteScalar

                For i = 0 To dgwOTDetalle.Rows.Count - 1
                    If dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value <> 0 Then
                        OTDETCONSULTATableAdapter.InsertQuery(UltimoRegistro, dgwOTDetalle.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value, dgwOTDetalle.Rows(i).Cells("CANTIDADPEDIDA").Value, dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value)
                    End If
                Next

                'quemamos el nro de OT generado
                DetpC_OTTableAdapter.UpdateQuery()

            Else
                UltimoRegistro = dgwOrdenTrabajo.CurrentRow.Cells("id").Value
                ORDENTRABAJOCONSULTATableAdapter.UpdateQuery(CInt(CmbCliente.SelectedValue), txtObservacion.Text, dtpFechaInicio.Text, cbxEstado.Text, dgwOrdenTrabajo.CurrentRow.Cells("id").Value)
                For i = 0 To dgwOTDetalle.Rows.Count - 1
                    If dgwOTDetalle.Rows(i).Cells("EstadoGrilla").Value = "I" Then
                        If dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value <> 0 Then
                            OTDETCONSULTATableAdapter.InsertQuery(UltimoRegistro, dgwOTDetalle.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn1").Value, dgwOTDetalle.Rows(i).Cells("CANTIDADPEDIDA").Value, dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value)
                        End If
                    ElseIf dgwOTDetalle.Rows(i).Cells("EstadoGrilla").Value = "D" Then
                        OTDETCONSULTATableAdapter.DeleteQuery(dgwOTDetalle.Rows(i).Cells("ID_OTDET").Value)
                    End If
                Next
            End If

            vgNuevo = 0 : vgEditar = 0

            ORDENTRABAJOCONSULTATableAdapter.Fill(DsOrdenTrabajo1.ORDENTRABAJOCONSULTA, FechaFiltro1, FechaFiltro2)

            'Nos Posicionamos en el resgistro 
            For i = 0 To dgwOrdenTrabajo.Rows.Count - 1
                If UltimoRegistro = dgwOrdenTrabajo.Rows(i).Cells("ID").Value Then
                    OTDETCONSULTABindingSource.Position = i
                End If
            Next

            DesHabilitar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        vgNuevo = 0 : vgEditar = 1
        Habilitar()
        TxtNumCliente.Focus()
    End Sub

    Private Sub dgwOrdenTrabajo_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwOrdenTrabajo.SelectionChanged
        Try
            OTDETCONSULTATableAdapter.Fill(DsOrdenTrabajo.OTDETCONSULTA, dgwOrdenTrabajo.CurrentRow.Cells("id").Value)
            SumarTotales()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnEliminarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarProducto.Click
        Try
            Dim indice As Integer = dgwOTDetalle.CurrentRow.Index

            dgwOTDetalle.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value = "Registro Para Eliminar"
            dgwOTDetalle.CurrentRow.Cells("EstadoGrilla").Value = "D"

            For r = 0 To 4
                dgwOTDetalle.Item(r, indice).Style.BackColor = Color.Pink
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        ORDENTRABAJOCONSULTABindingSource.Filter = "OBS LIKE '%" & BuscarTextBox.Text & "%' OR NROORDENTRABAJO LIKE '%" & BuscarTextBox.Text & "%' OR NOMBRE LIKE '%" & BuscarTextBox.Text & "%'"
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        ORDENTRABAJOCONSULTATableAdapter.Fill(DsOrdenTrabajo1.ORDENTRABAJOCONSULTA, FechaFiltro1, FechaFiltro2)
    End Sub

    Private Sub btnRenviar_Click(sender As System.Object, e As System.EventArgs) Handles btnRenviar.Click
        Me.USUARIOTableAdapter.Fill(Me.DsOrdenTrabajo1.USUARIO)
        pnlEnviarEmail.Visible = True
        pnlEnviarEmail.BringToFront()
        btnRenviar.Image = My.Resources.SendEmailActive
    End Sub

    Private Sub btnCerrarEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrarEmail.Click
        pnlEnviarEmail.Visible = False
        btnRenviar.Image = My.Resources.SendEmail
    End Sub

    Private Sub btnEnviarEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarEmail.Click
        Try
            Dim ServidorSMTP, Puerto, Usuario, Pass, Remitente, ErrorCadena, email As String
            Dim Existe As Integer = 0
            Dim QtyEnvio As Integer = 0

            ServidorSMTP = "" : Puerto = "" : Usuario = "" : Pass = "" : Remitente = "" : ErrorCadena = "" : email = ""

            '========================== OBTENEMOS LOS DATOS SMPT PARA EL ENVIO ==========================
            Dim objCommand As New SqlCommand
            objCommand.CommandText = "SELECT CODSMTP, SERVIDORSMTP, PUERTO, USUARIO, CONTRASENHA, REMITENTE FROM dbo.SMTP"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()

            Dim odrSMTP As SqlDataReader = objCommand.ExecuteReader()
            If odrSMTP.HasRows Then
                Do While odrSMTP.Read()
                    ServidorSMTP = odrSMTP("SERVIDORSMTP")
                    Puerto = odrSMTP("PUERTO")
                    Usuario = odrSMTP("USUARIO")
                    Pass = odrSMTP("CONTRASENHA")
                    Remitente = odrSMTP("REMITENTE")
                    Existe = 1
                Loop
            Else
                Existe = 0
            End If

            '========================== ARMAMOS EL MENSAJE A ENVIAR ==========================
            Dim encabezado, titulo, mensaje, cuerpo As String

            If Existe = 1 Then
                titulo = "<h2>Pedido de Clientes Nro : " & lblNroConsumo.Text & "</h2>"

                encabezado = "<div>Cliente : " & TxtNumCliente.Text & " - " & CmbCliente.Text & "</div>"
                encabezado = encabezado & "<div>Fecha Pedido : " & dtpFechaInicio.Text & "</div>"
                encabezado = encabezado & "<div>Observacion : " & txtObservacion.Text & "</div>"

                cuerpo = "<h3>Trabajos a Realizar : </h3>"
                cuerpo = cuerpo & "<TABLE BORDER=1>"
                cuerpo = cuerpo & "<TR><TH>Código</TH><TH>Producto</TH><TH>Cantidad Pedida</TH><TH>Cantidad a Producir</TH></TR>"

                For i = 0 To dgwOTDetalle.Rows.Count - 1
                    cuerpo = cuerpo & "<TR><TH align='left'>" & dgwOTDetalle.Rows(i).Cells("CODIGODataGridViewTextBoxColumn1").Value & "</TH><TH align='left'>" & dgwOTDetalle.Rows(i).Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value & "</TH><TH align='right'>" & FormatNumber(dgwOTDetalle.Rows(i).Cells("CANTIDADPEDIDA").Value, 0) & "</TH><TH align='right'>" & FormatNumber(dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value, 0) & "</TH></TR>"
                Next

                cuerpo = cuerpo & "</TABLE>"

                mensaje = titulo & encabezado & cuerpo

            Else
                MessageBox.Show("No exite ninguna configuracion SMTP, verifique en el modulo de Configuraciones")
                Exit Sub
            End If

            '========================== ENVIAMOS EL EMAIL ==========================
            EmailError = 0 : ErrorCadena = ""

            If Existe = 1 Then
                For i = 0 To dgwUsuarios.Rows.Count - 1
                    Try
                        If dgwUsuarios.Rows(i).Cells("Marcar").Value = True Then
                            email = dgwUsuarios.Rows(i).Cells("EMAILDataGridViewTextBoxColumn").Value

                            Dim insMail As New MailMessage(New MailAddress(Usuario), New MailAddress(email))
                            With insMail
                                .Subject = "Pedido de Clientes"
                                .IsBodyHtml = True 'envia el mensaje como html
                                .Body = mensaje
                                .From = New MailAddress(Usuario)
                                .ReplyTo = New MailAddress(email)
                            End With

                            Dim smtp As New System.Net.Mail.SmtpClient
                            smtp.Host = ServidorSMTP
                            smtp.Port = Puerto
                            smtp.EnableSsl = True
                            smtp.UseDefaultCredentials = False
                            smtp.Credentials = New System.Net.NetworkCredential(Usuario, Pass)

                            Dim vistahtml As AlternateView = AlternateView.CreateAlternateViewFromString(mensaje, Nothing, MediaTypeNames.Text.Html)

                            QtyEnvio += 1
                            Me.Cursor = Cursors.WaitCursor

                            smtp.Send(insMail)

                            lblMensaje.Text = "Enviados " & CStr(QtyEnvio) & " de " & CStr(dgwUsuarios.Rows.Count)
                            Application.DoEvents()
                            Me.Cursor = Cursors.AppStarting
                        End If

                    Catch ex As Exception
                        MessageBox.Show(ex.Message)

                    End Try
                    Application.DoEvents()
                Next
            Else
                MessageBox.Show("No exite ninguna configuracion SMTP, verifique en el modulo de Configuraciones")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" + ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        btnRenviar.Image = My.Resources.SendEmail
        Me.Cursor = Cursors.Arrow
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 275)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar una Orden de Trabajo", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar?", "COGENT SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim RegistroActual As Integer = dgwOrdenTrabajo.CurrentRow.Cells("id").Value
            OTDETCONSULTATableAdapter.DeleteQueryTodo(RegistroActual)
            ORDENTRABAJOCONSULTATableAdapter.DeleteQuery(RegistroActual)

            ORDENTRABAJOCONSULTATableAdapter.Fill(DsOrdenTrabajo1.ORDENTRABAJOCONSULTA, FechaFiltro1, FechaFiltro2)
        Catch ex As Exception
            MessageBox.Show("Error al Eliminar :" & ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub pbxImprimirOrden_Click(sender As System.Object, e As System.EventArgs) Handles pbxImprimirOrden.Click
        Try
            Dim frm = New VerInformes
            Dim rptmat As New Reportes.OrdendeProduccion

            Me.OtimprimirTableAdapter.Fill(DsOrdenTrabajo.OTIMPRIMIR, dgwOrdenTrabajo.CurrentRow.Cells("id").Value)
            rptmat.SetDataSource([DsOrdenTrabajo])

            frm.CrystalReportViewer1.ReportSource = rptmat
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFechaInicio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtpFechaInicio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cbxEstado.Focus()
        End If
    End Sub

    Private Sub tbxCantidadProducir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxCantidadProducir.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub SumarTotales()
        Dim Total As Integer = 0
        If dgwOTDetalle.Rows.Count <> 0 Then
            For i = 0 To dgwOTDetalle.Rows.Count - 1
                Total = Total + CDec(dgwOTDetalle.Rows(i).Cells("CANTIDADAPRODUCIR").Value)
            Next
        End If
        tbxTotal.Text = FormatNumber(Total, 2)
    End Sub

    Private Sub dgwOTDetalle_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwOTDetalle.CellDoubleClick
        'Verificamos que este en Editar  y que el detalle no este vacio
        If vgEditar = 1 And dgwOTDetalle.Rows.Count Then
            Try
                Dim nvoEstado As String = InputBox("Ingrese el Estado del Producto: ", " Pedido de CLiente ", "")

                OTDETCONSULTATableAdapter.UpdateQuery(nvoEstado, dgwOTDetalle.CurrentRow.Cells("ID_OTDET").Value)
                dgwOTDetalle.CurrentRow.Cells("ESTADO").Value = nvoEstado
            Catch ex As Exception
                MessageBox.Show("Error al Actualizar el Estado :" & ex.Message, "Cogent SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgwOTDetalle_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgwOTDetalle.CellContentClick

    End Sub
End Class