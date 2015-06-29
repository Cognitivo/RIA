
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class Transferencias

    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim Config2, Config3 As String
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim permiso As Double
    Dim AccNuevo, AccEditar, modifdet As Integer
    Dim SUCORIGORIG, SUCDESTORIG As Integer
    Dim ConceptoP1 As String
    Dim f As New Funciones.Funciones
    Dim vgCodCodigo, vgCodProducto, vgCodCabecera, vgLineaConsumo As Integer
    Dim EntradaSalida As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ProdSaliaEntredaProduccion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If NuevoPictureBox.Enabled = True Then
                NuevoPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F6 Then
            If ModificarPictureBox.Enabled = True Then
                ModificarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F7 Then
            If GuardarPictureBox.Enabled = True Then
                GuardarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F8 Then
            If CancelarPictureBox.Enabled = True Then
                CancelarPictureBox_Click(Nothing, Nothing)
            End If
        End If

        If e.KeyCode = Keys.F9 Then 'Cambiamos Panel
            If lblTexto.Text = "Información de Salida" Then
                pbxEntrada_Click(Nothing, Nothing)

            ElseIf lblTexto.Text = "Información de Entrada" Then
                pbxSalida_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub Transferencias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 245)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso Abrir esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            Me.SUCURSALTableAdapter.Fill(Me.DsInventario1.SUCURSAL)
            Me.PRODUCTOSTableAdapter.Fill(Me.DsProdSimple.PRODUCTOS)
            ObtenerConfig()

            InicializaFechaFiltro()
            lblTexto.Text = "Información de Salida"
            Try
                If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                    Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
                Else
                    Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
                End If
            Catch ex As Exception
            End Try

            dtpFechaSalida.Visible = True
            dtpFechaEntrada.Visible = False
            Deshabilita()

            If dgwProduccion.RowCount = 0 Then
                lblInfo.Text = ""
            End If
        End If
    End Sub

    Private Sub ObtenerConfig()
        'Obtenemos los Valores de Configuracion del Sistema 
        Dim objCommand As New SqlCommand

        Try
            objCommand.CommandText = "SELECT  CONFIG2, CONFIG3 FROM MODULO WHERE MODULO_ID = 13"
            objCommand.Connection = New SqlConnection(ser.CadenaConexion)
            objCommand.Connection.Open()
            Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

            If odrConfig.HasRows Then
                Do While odrConfig.Read()
                    Config2 = odrConfig("CONFIG2")
                    Config3 = odrConfig("CONFIG3")
                Loop
            End If

            odrConfig.Close()
            objCommand.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub InicializaFechaFiltro()
        Dim nromes, nroaño As Integer
        Dim fechacompleta1, fechacompleta2, mes As String
        nromes = Today.Month
        nroaño = Today.Year

        CmbAño.Text = nroaño
        CmbMes.SelectedIndex = nromes - 1

        If nromes = 10 Or nromes = 11 Or nromes = 12 Then
            mes = nromes.ToString
        Else
            mes = "0" + nromes.ToString
        End If

        fechacompleta1 = "01" + "/" + mes + "/" + nroaño.ToString
        fechacompleta2 = ""
        If nromes = 1 Or nromes = 3 Or nromes = 5 Or nromes = 7 Or nromes = 8 Or nromes = 10 Or nromes = 12 Then
            fechacompleta2 = "31" + "/" + mes + "/" + nroaño.ToString

        ElseIf nromes = 2 Or nromes = 4 Or nromes = 6 Or nromes = 7 Or nromes = 9 Or nromes = 11 Then
            If nromes = 2 Then
                If (nroaño - 1992) Mod 4 = 0 Then
                    fechacompleta2 = "29" + "/" + mes + "/" + nroaño.ToString
                Else
                    fechacompleta2 = "28" + "/" + mes + "/" + nroaño.ToString
                End If
            Else
                fechacompleta2 = "30" + "/" + mes + "/" + nroaño.ToString
            End If
        End If

        fechacompleta1 = fechacompleta1 + " 00:00:00.000"
        fechacompleta2 = fechacompleta2 + " 23:59:59.900"

        FechaFiltro1 = CDate(fechacompleta1)
        FechaFiltro2 = CDate(fechacompleta2)
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

    Private Sub Deshabilita()
        pnlProduccionCab.Enabled = False
        pnlProduccionDet.Enabled = True

        NuevoPictureBox.Image = My.Resources.New_
        NuevoPictureBox.Enabled = True
        NuevoPictureBox.Cursor = Cursors.Hand
        EliminarPictureBox.Image = My.Resources.Delete
        EliminarPictureBox.Enabled = True
        EliminarPictureBox.Cursor = Cursors.Hand
        ModificarPictureBox.Image = My.Resources.Edit
        ModificarPictureBox.Enabled = True
        ModificarPictureBox.Cursor = Cursors.Hand
        tbxCodigoProducto.Enabled = False
        btnBuscProductos.Enabled = False
        txtCantidad.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarProducto.Enabled = False
        btnModificarDet.Enabled = False
        btnCancelarDet.Enabled = False

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        BuscarTextBox.Enabled = True
        BtnFiltro.Enabled = True
        dgwProduccion.Enabled = True
        dgwProduccionDet.Enabled = True
        CmbMes.Enabled = True
        CmbAño.Enabled = True
    End Sub

    Private Sub Habilita()
        pnlProduccionCab.Enabled = True
        pnlProduccionDet.Enabled = True

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
        tbxCodigoProducto.Enabled = True
        btnBuscProductos.Enabled = True
        txtCantidad.Enabled = True
        btnAgregar.Enabled = True
        btnEliminarProducto.Enabled = True
        btnModificarDet.Enabled = True
        btnCancelarDet.Enabled = True

        BuscarTextBox.Enabled = False
        dgwProduccion.Enabled = False
        dgwProduccionDet.Enabled = True
        BtnFiltro.Enabled = False
        CmbMes.Enabled = False
        CmbAño.Enabled = False
    End Sub

    Private Sub pbxEntrada_Click(sender As System.Object, e As System.EventArgs) Handles pbxEntrada.Click
        pbxEntrada.Image = My.Resources.Entrada
        pbxSalida.Image = My.Resources.SalidaOff
        EntradaSalida = 1
        lblTexto.Text = "Información de Entrada"
        cmbDepositoDestino.Enabled = False
        cmbDepositoOrigen.Enabled = False

        If SUCDESTORIG = 0 And SUCORIGORIG = 0 Then
            If AccNuevo = 1 Then
                SUCORIGORIG = cmbDepositoOrigen.SelectedValue
                SUCDESTORIG = cmbDepositoDestino.SelectedValue
            End If
        End If
        dtpFechaSalida.Visible = False
        dtpFechaEntrada.Visible = True

        If SUCDESTORIG <> 0 And SUCORIGORIG <> 0 Then
            cmbDepositoOrigen.SelectedValue = SUCDESTORIG
            cmbDepositoDestino.SelectedValue = SUCORIGORIG
        End If

        RecorreDetalle()
        'Ocultamos las Filas de Salida
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("CANTIDAD").Value > 0 And dgwProduccionDet.Rows(i).Cells("CODDEPOSITO").Value = cmbDepositoDestino.SelectedValue And dgwProduccionDet.Rows(i).Cells("TIPOPROD").Value = cmbDepositoOrigen.SelectedValue Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            End If
        Next
    End Sub

    Private Sub pbxSalida_Click(sender As System.Object, e As System.EventArgs) Handles pbxSalida.Click
        pbxEntrada.Image = My.Resources.EntradaOff
        pbxSalida.Image = My.Resources.Salida
        EntradaSalida = 0
        lblTexto.Text = "Información de Salida"

        cmbDepositoDestino.Enabled = True
        cmbDepositoOrigen.Enabled = True
        
        dtpFechaSalida.Visible = True
        dtpFechaEntrada.Visible = False
        If SUCDESTORIG = 0 And SUCORIGORIG = 0 Then
            If AccNuevo = 1 Then
                SUCORIGORIG = cmbDepositoOrigen.SelectedValue
                SUCDESTORIG = cmbDepositoDestino.SelectedValue
            End If
        End If
        If SUCDESTORIG <> 0 And SUCORIGORIG <> 0 Then
            cmbDepositoOrigen.SelectedValue = SUCORIGORIG
            cmbDepositoDestino.SelectedValue = SUCDESTORIG
        End If

        RecorreDetalle()
        'Ocultamos las Filas de Entrada
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("CANTIDAD").Value > 0 And dgwProduccionDet.Rows(i).Cells("CODDEPOSITO").Value = cmbDepositoDestino.SelectedValue And dgwProduccionDet.Rows(i).Cells("TIPOPROD").Value = cmbDepositoOrigen.SelectedValue Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            End If
        Next

    End Sub

    Private Sub cmbDepositoOrigen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepositoOrigen.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbDepositoDestino.Focus()
        End If
    End Sub
    Private Sub cmbDepositoDestino_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDepositoDestino.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFechaSalida.Focus()
        End If
    End Sub
    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFechaSalida.KeyPress
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

    Private Sub tbxCodigoProducto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCantidad.Focus()
        End If

        If KeyAscii = 42 Then
            upcProductos.PopupControl = gbxProductos
            upcProductos.Show()

            BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub CantidadVentaMaskedEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If modifdet = 1 Then
                btnModificarDet.Focus()
            Else
                btnAgregar.Focus()
            End If
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 242)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso crear un Nuevo Consumo Interno", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        SUCDESTORIG = 0 : SUCORIGORIG = 0
        AccNuevo = 1 : AccEditar = 0 : modifdet = 0
        Habilita()
        FechaFiltro1 = "01/01/2000" : FechaFiltro2 = "01/01/3000"

        Try
            If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
            Else
                Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception
        End Try

        Me.TRANSFERENCIACABBindingSource.AddNew()

        Try
            cmbDepositoOrigen.SelectedIndex = cmbDepositoOrigen.SelectedIndex + 1
            cmbDepositoDestino.SelectedValue = f.FuncionConsulta("CODSUCURSAL", "SUCURSAL", "(TIPOSUCURSAL='Factura y Stock' OR TIPOSUCURSAL='Solo Stock') AND CODSUCURSAL", SucCodigo)
        Catch ex As Exception
        End Try

        Try
            Me.TRANSFERENCIADETTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIADET, 0)
        Catch ex As Exception
        End Try

        lblNroProduccion.Visible = False : txtNroProduccion.Visible = True

        Dim MaxNro As Integer


        If Config3 = "Numeracion Global" Then
            Dim wheresql As String = "CONCEPTO LIKE '%TRANSF%' AND MODULO"
            Try
                MaxNro = f.FuncionConsultaString("NROMOVIMIENTO", "MOVPRODUCTO", wheresql, 13)
            Catch ex As Exception
                MaxNro = 0
            End Try
            'Obtenemos los Valores de Configuracion del Sistema 
        Else
            Dim objCommand As New SqlCommand

            Try
                objCommand.CommandText = "SELECT MAX(NROMOVIMIENTO) AS NROMAXIMO " & _
                                         "FROM (SELECT dbo.CODIGOS.CODIGO, SUM(MP.CANTIDAD) AS CANTIDAD, dbo.PRODUCTOS.DESPRODUCTO + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) " & _
                                         "+ ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')) AS PRODUCTO, SUCURSAL_1.DESSUCURSAL AS SUCDESTINO, MP.NROMOVIMIENTO " & _
                                         "FROM dbo.MOVPRODUCTO AS MP INNER JOIN " & _
                                         "dbo.SUCURSAL AS SUCURSAL_1 ON MP.CODDEPOSITO = SUCURSAL_1.CODSUCURSAL INNER JOIN " & _
                                         "dbo.CODIGOS ON MP.CODCODIGO = dbo.CODIGOS.CODCODIGO INNER JOIN " & _
                                         "dbo.PRODUCTOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO " & _
                                         "WHERE (MP.NROMOVIMIENTO IS NOT NULL) AND (SUCURSAL_1.DESSUCURSAL LIKE '" & cmbDepositoDestino.Text & "') AND (MP.CANTIDAD > 0) " & _
                                         "GROUP BY dbo.CODIGOS.CODIGO, dbo.PRODUCTOS.DESPRODUCTO + ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO1, '')) " & _
                                         "+ ' ' + LTRIM(ISNULL(dbo.CODIGOS.DESCODIGO2, '')), SUCURSAL_1.DESSUCURSAL, MP.NROMOVIMIENTO) AS derivedtbl_1 "

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrConfig As SqlDataReader = objCommand.ExecuteReader()

                If odrConfig.HasRows Then
                    Do While odrConfig.Read()
                        MaxNro = odrConfig("NROMAXIMO")
                    Loop
                End If

                odrConfig.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        End If

        MaxNro = MaxNro + 1
        txtNroProduccion.Text = MaxNro
        txtUsuario.Text = UsuNombre
        cmbDepositoOrigen.Focus()
        lblInfo.Text = "(De " & cmbDepositoOrigen.Text & " a " & cmbDepositoDestino.Text & ")"

        pbxSalida_Click(Nothing, Nothing)
    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        If ProductosGridView.RowCount <> 0 Then
            vgCodCodigo = ProductosGridView.CurrentRow.Cells("CODCODIGO").Value
            vgCodProducto = ProductosGridView.CurrentRow.Cells("CODPRODUCTO").Value
            Me.tbxCodigoProducto.Text = ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn1").Value

            DesProductoTextBox.Text = ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
        End If

        upcProductos.Close()
    End Sub

    Private Sub ProductosGridView_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles ProductosGridView.KeyPress
        If ProductosGridView.RowCount <> 0 Then
            Dim KeyAscii As Short = Asc(e.KeyChar)
            If KeyAscii = 13 Then
                Try
                    Dim pos As Integer = ProductosGridView.CurrentRow.Index
                    Dim cantReg As Integer = ProductosGridView.RowCount - 1

                    If (pos <> 0) And (pos <> cantReg) Then
                        pos = pos - 1
                    End If

                    vgCodCodigo = ProductosGridView.Rows(pos).Cells("CODCODIGO").Value
                    vgCodProducto = ProductosGridView.Rows(pos).Cells("CODPRODUCTO").Value
                    Me.tbxCodigoProducto.Text = ProductosGridView.Rows(pos).Cells("CODIGODataGridViewTextBoxColumn1").Value

                    DesProductoTextBox.Text = ProductosGridView.Rows(pos).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
                Catch ex As Exception
                End Try
            End If

            upcProductos.Close()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles BuscarProductoTextBox.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            ProductosGridView.Select()
        End If
    End Sub

    Private Sub BuscarProductoTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarProductoTextBox.TextChanged
        Me.PRODUCTOSBindingSource.Filter = "DESPRODUCTO LIKE '%" & BuscarProductoTextBox.Text & "%' OR CODIGO LIKE '%" & BuscarProductoTextBox.Text & "%' "
    End Sub

    Private Sub tbxCodigoProducto_LostFocus(sender As Object, e As System.EventArgs) Handles tbxCodigoProducto.LostFocus
        If tbxCodigoProducto.Text <> "" Then
            Dim objCommand As New SqlCommand

            ErrorCodigoLabel.Visible = False
            Try
                objCommand.CommandText = "SELECT dbo.CODIGOS.CODPRODUCTO,dbo.CODIGOS.CODCODIGO, dbo.PRODUCTOS.DESPRODUCTO, dbo.CODIGOS.PRECIO " & _
                                         "FROM dbo.PRODUCTOS INNER JOIN dbo.CODIGOS ON dbo.PRODUCTOS.CODPRODUCTO = dbo.CODIGOS.CODPRODUCTO " & _
                                         "WHERE dbo.CODIGOS.CODIGO = '" & tbxCodigoProducto.Text & "'"

                objCommand.Connection = New SqlConnection(ser.CadenaConexion)
                objCommand.Connection.Open()
                Dim odrProducto As SqlDataReader = objCommand.ExecuteReader()

                If odrProducto.HasRows Then
                    Do While odrProducto.Read()
                        vgCodCodigo = odrProducto("CODCODIGO")
                        vgCodProducto = odrProducto("CODPRODUCTO")
                        'Me.tbxPrecio.Text = odrProducto("PRECIO")
                        Me.DesProductoTextBox.Text = odrProducto("DESPRODUCTO")
                    Loop

                    txtCantidad.Focus()
                Else
                    ErrorCodigoLabel.Visible = True
                    tbxCodigoProducto.Focus()
                End If

                odrProducto.Close()
                objCommand.Dispose()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As System.Object, e As System.EventArgs) Handles btnAgregar.Click
        If tbxCodigoProducto.Text = "" Then
            MessageBox.Show("Seleccione el Producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxCodigoProducto.Focus()
            tbxCodigoProducto.BackColor = Color.Pink
            Exit Sub
        End If
        If cmbDepositoOrigen.Text = "" Then
            MessageBox.Show("Ingrese el Deposito Origen", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDepositoOrigen.Focus()
            cmbDepositoOrigen.BackColor = Color.Pink
            Exit Sub
        End If
        If cmbDepositoDestino.Text = "" Then
            MessageBox.Show("Ingrese el Deposito Destino", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDepositoDestino.Focus()
            cmbDepositoDestino.BackColor = Color.Pink
            Exit Sub
        End If
        If txtCantidad.Text = "" Then
            MessageBox.Show("Ingrese la Cantidad", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            txtCantidad.BackColor = Color.Pink
            Exit Sub
        End If

        If CDec(txtCantidad.Text) = 0 Then
            MessageBox.Show("Ingrese la Cantidad Devuelta mayor a cero", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCantidad.Focus()
            txtCantidad.BackColor = Color.Pink
            Exit Sub
        End If

        'If tbxPrecio.Text = "" Then
        '    MessageBox.Show("Ingrese el Costo del Producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    tbxPrecio.Focus()
        '    tbxPrecio.BackColor = Color.Pink
        '    Exit Sub
        'End If

        TRANSFERENCIADETBindingSource.AddNew()
        Dim c As Integer = dgwProduccionDet.RowCount

        dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODET").Value = vgCodCodigo
        dgwProduccionDet.Rows(c - 1).Cells("CODPRODUCTODET").Value = vgCodProducto
        dgwProduccionDet.Rows(c - 1).Cells("CODIGO").Value = tbxCodigoProducto.Text
        dgwProduccionDet.Rows(c - 1).Cells("DESPRODUCTO").Value = DesProductoTextBox.Text
        dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value = CDec(Me.txtCantidad.Text)
        'dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value = CDec(Me.tbxPrecio.Text)
        dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value = cmbDepositoDestino.SelectedValue
        dgwProduccionDet.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I" 'Insert
        dgwProduccionDet.Rows(c - 1).Cells("TIPO").Value = EntradaSalida
        dgwProduccionDet.Rows(c - 1).Cells("TIPOPROD").Value = cmbDepositoOrigen.SelectedValue

        'Ocultamos las Filas de Entrada
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("CANTIDAD").Value > 0 And dgwProduccionDet.Rows(i).Cells("CODDEPOSITO").Value = cmbDepositoDestino.SelectedValue And dgwProduccionDet.Rows(i).Cells("TIPOPROD").Value = cmbDepositoOrigen.SelectedValue Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            End If
        Next

        'RecorreDetalle()
        Limpiar()
        tbxCodigoProducto.Focus()
    End Sub

    Private Sub Limpiar()
        tbxCodigoProducto.Text = ""
        txtCantidad.Text = ""
        'tbxPrecio.Text = ""
        DesProductoTextBox.Text = ""
    End Sub

    Private Sub RecorreDetalle()
        Try
            If dgwProduccion.RowCount <> 0 Then
                If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                    Me.TRANSFERENCIADETTableAdapter.FillByDepositos(Me.DsInventario1.TRANSFERENCIADET, dgwProduccion.CurrentRow.Cells("NROMOVIMIENTODataGridViewTextBoxColumn").Value, CInt(cmbDepositoDestino.SelectedValue), CInt(cmbDepositoOrigen.SelectedValue))
                Else
                    Me.TRANSFERENCIADETTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIADET, dgwProduccion.CurrentRow.Cells("NROMOVIMIENTODataGridViewTextBoxColumn").Value)
                End If
            Else
                Me.TRANSFERENCIADETTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIADET, 0)
                'txtTotalConsumo.Text = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 243)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Modificar estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        AccNuevo = 0 : AccEditar = 1
        lblNroProduccion.Visible = False : txtNroProduccion.Visible = True

        Habilita()
        'cmbDepositoOrigen.Enabled = False
        'cmbDepositoDestino.Enabled = False
        dtpFechaSalida.Focus()
        txtNroProduccion.Visible = False
        lblNroProduccion.Visible = True
        ModificarPictureBox.Image = My.Resources.EditActive
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            TRANSFERENCIACABBindingSource.CancelEdit()
            TRANSFERENCIACABBindingSource.RemoveFilter()

            FechaFiltro()

            'Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
            'TRANSFERENCIACABBindingSource.Filter = "SUCDESTINO = " & SucCodigo
            'RecorreDetalle()
            Try
                If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                    Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
                Else
                    Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
                End If
            Catch ex As Exception
            End Try

            btnCancelarDet_Click(Nothing, Nothing)

            AccNuevo = 0 : AccEditar = 0 : modifdet = 0
            lblNroProduccion.Visible = True : txtNroProduccion.Visible = False
            Deshabilita()
        Catch ex As Exception

        End Try
        dgwProduccion.Refresh()
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim vError As Integer = 0

        'Verificamos los Campos Necesarios antes de Guardar
        If cmbDepositoOrigen.Text = "" Then
            MessageBox.Show("Ingrese el Deposito Origen", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDepositoOrigen.Focus()
            cmbDepositoOrigen.BackColor = Color.Pink
            Exit Sub
        End If
        If cmbDepositoDestino.Text = "" Then
            MessageBox.Show("Ingrese el Deposito Destino", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbDepositoDestino.Focus()
            cmbDepositoDestino.BackColor = Color.Pink
            Exit Sub
        End If

        'Guardamos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")
        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If vError = 0 Then
            'Actualiza / Descuenta Stock
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            Try
                InsertaMovProducto()
                myTrans.Commit()
            Catch ex As Exception
                myTrans.Rollback()
                MessageBox.Show("Ocurrio un error al Actualizar el Stock : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Dim CodTemp = txtNroProduccion.Text

        FechaFiltro()
        'Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
        'TRANSFERENCIACABBindingSource.Filter = "SUCDESTINO = " & SucCodigo

        Try
            If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
            Else
                Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception
        End Try

        'Buscamos la posicion del registro guardado
        For i = 0 To dgwProduccion.RowCount - 1
            If dgwProduccion.Rows(i).Cells("NROMOVIMIENTODataGridViewTextBoxColumn").Value = CodTemp Then
                TRANSFERENCIACABBindingSource.Position = i
            End If
        Next

        AccNuevo = 0 : AccEditar = 0 : modifdet = 0
        lblNroProduccion.Visible = True : txtNroProduccion.Visible = False

        pbxSalida_Click(Nothing, Nothing)

        Deshabilita()
        Me.Refresh()
        dgwProduccion.Refresh()
    End Sub

    Private Sub InsertaMovProducto()
        Dim Sql As String = ""
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable, DepOrigen, DepDestino, Concepto As String
        Dim c As Integer = dgwProduccionDet.RowCount
        Costeable = 0

        If AccEditar = 1 Then
            Concepto = ConceptoP1 + txtObservacion.Text
        Else
            Concepto = "Transf. Nro " & txtNroProduccion.Text & "," & txtObservacion.Text
        End If

        For c = 1 To c
            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value) Then
                CantidadFactura = "NULL"
            Else
                CantidadFactura = dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value
                CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                CantidadFactura = Replace(CantidadFactura, ",", ".")
            End If

            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value) Then
                DepDestino = "NULL"
            Else
                DepDestino = dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value
            End If

            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("TIPOPROD").Value) Then
                DepOrigen = "NULL"
            Else
                DepOrigen = dgwProduccionDet.Rows(c - 1).Cells("TIPOPROD").Value
            End If

            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODET").Value) Then
                CodCodigoFactura = "NULL"
            Else
                CodCodigoFactura = dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODET").Value
            End If

            Precio = "NULL"

            Dim hora As String = Now.ToString("HH:mm:ss")

            Dim Concat As String = ""
            If AccNuevo = 0 Then
                If (dgwProduccion.CurrentRow.Cells("SUCORIGENDataGridViewTextBoxColumn").Value = dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value And dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value < 0) Or (dgwProduccion.CurrentRow.Cells("SUCDESTINODataGridViewTextBoxColumn").Value = dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value And dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value > 0) Then
                    'ES INFORMACION DE SALIDA
                    Concat = dtpFechaSalida.Text
                Else
                    'ES INFORMACION DE ENTRADA
                    Concat = dtpFechaEntrada.Text
                End If
            Else
                If (SUCORIGORIG = dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value And dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value < 0) Or (SUCDESTORIG = dgwProduccionDet.Rows(c - 1).Cells("CODDEPOSITO").Value And dgwProduccionDet.Rows(c - 1).Cells("CANTIDAD").Value > 0) Then
                    'ES INFORMACION DE SALIDA
                    Concat = dtpFechaSalida.Text
                Else
                    'ES INFORMACION DE ENTRADA
                    Concat = dtpFechaEntrada.Text
                End If
            End If

            Dim Concatenar As String = Concat & " " + hora

            If dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value Is Nothing Then
                '-- ACTUALIZA LA "CABECERA"
                Sql = ""
                Sql = "UPDATE MOVPRODUCTO SET CODUSUARIO=" & UsuCodigo & ", FECHAMOVIMIENTO=CONVERT(Datetime,'" & Concatenar & "',103),CONCEPTO ='" & Concepto & "' WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(c - 1).Cells("CODMOVIMIENTO").Value
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "I" Then
                '--------------- INSERTA EL MOVIMIENTO EN LA TRANSFERENCIA DE DESTINO ---------------

                Sql = ""
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK, NROMOVIMIENTO) " & _
                                         "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & DepOrigen & ",CONVERT(Datetime,'" & Concatenar & "',103),13," & txtNroProduccion.Text & _
                                         ",-" & CantidadFactura & "," & Precio & ",'" & Concepto & "'," & Costeable & "," & DepDestino & ",1," & txtNroProduccion.Text & ")"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()


                '--------------- INSERTA EL MOVIMIENTO EN LA TRANSFERENCIA DESTINO ---------------
                Sql = ""
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK, NROMOVIMIENTO) " & _
                                         "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & DepDestino & ",CONVERT(Datetime,'" & Concatenar & "',103),13," & txtNroProduccion.Text & _
                                         ", " & CantidadFactura & "," & Precio & ",'" & Concepto & "'," & Costeable & "," & DepOrigen & ",1," & txtNroProduccion.Text & ")"



                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "U" Then
                'ELIMINAMOS EL VIEJO HE INSERTAMOS EL NUEVO
                '--------------- ELIMINA EL MOVIMIENTO EN LA TRANSFERENCIA DEL DEP DESTINO ---------------
                Sql = ""
                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(c - 1).Cells("CODMOVIMIENTO").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

                '--------------- ELIMINA EL MOVIMIENTO EN LA TRANSFERENCIA DEL DEP ORIGEN --------------- 'SI O SI ES EL ANTERIOR
                Sql = ""
                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(c - 2).Cells("CODMOVIMIENTO").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

                '--------------- INSERTA EL NUEVO MOVIMIENTO EN LA TRANSFERENCIA DE ORIGEN ---------------

                Sql = ""
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK, NROMOVIMIENTO) " & _
                                         "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & DepOrigen & ",CONVERT(Datetime,'" & Concatenar & "',103),13," & txtNroProduccion.Text & _
                                         ",-" & CantidadFactura & "," & Precio & ",'" & Concepto & "'," & Costeable & "," & DepDestino & ",1," & txtNroProduccion.Text & ")"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()


                '--------------- INSERTA EL MOVIMIENTO EN LA TRANSFERENCIA DESTINO ---------------
                Sql = ""
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK, NROMOVIMIENTO) " & _
                                         "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & DepDestino & ",CONVERT(Datetime,'" & Concatenar & "',103),13," & txtNroProduccion.Text & _
                                         ", " & CantidadFactura & "," & Precio & ",'" & Concepto & "'," & Costeable & "," & DepOrigen & ",1," & txtNroProduccion.Text & ")"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            ElseIf dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "D" Then
                '--------------- ELIMINA EL MOVIMIENTO EN LA TRANSFERENCIA DEL DEP DESTINO ---------------
                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(c - 1).Cells("CODMOVIMIENTO").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

                '--------------- ELIMINA EL MOVIMIENTO EN LA TRANSFERENCIA DEL DEP ORIGEN --------------- 'SI O SI ES EL ANTERIOR
                Sql = ""
                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(c - 2).Cells("CODMOVIMIENTO").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub txtNroProduccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProduccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cmbDepositoOrigen.Enabled = True Then
                cmbDepositoOrigen.Focus()
            Else
                dtpFechaSalida.Focus()
            End If
        End If
    End Sub

    Private Sub btnEliminarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarProducto.Click
        Dim c As Integer = dgwProduccionDet.RowCount

        If dgwProduccionDet.RowCount = 0 Then
            Exit Sub
        End If

        Dim CRDGV As Integer = Me.dgwProduccionDet.CurrentRow.Index
        Me.dgwProduccionDet.CurrentRow.Cells("EstadoGrilla").Value = "D" 'Insert
        Me.dgwProduccionDet.Item(0, CRDGV).Style.BackColor = Color.Pink
        Me.dgwProduccionDet.Item(1, CRDGV).Style.BackColor = Color.Pink
        Me.dgwProduccionDet.Item(2, CRDGV).Style.BackColor = Color.Pink
        Me.dgwProduccionDet.Item(3, CRDGV).Style.BackColor = Color.Pink
        Me.dgwProduccionDet.Item(4, CRDGV).Style.BackColor = Color.Pink
        Me.dgwProduccionDet.CurrentRow.Cells("DESPRODUCTO").Value = "Esta Línea sera Eliminada"
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        'Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
        'TRANSFERENCIACABBindingSource.Filter = "SUCDESTINO = " & SucCodigo
        Try
            If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
            Else
                Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dgwProduccion_Click(sender As Object, e As System.EventArgs) Handles dgwProduccion.Click
        Me.refresh()
    End Sub

    Private Sub dgwProduccion_LostFocus(sender As Object, e As System.EventArgs) Handles dgwProduccion.LostFocus
        Me.refresh()
    End Sub

    Private Sub dgwProduccion_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwProduccion.SelectionChanged
        If dgwProduccion.RowCount <> 0 Then
            If AccNuevo <> 1 Then
                SUCORIGORIG = dgwProduccion.CurrentRow.Cells("SUCORIGENDataGridViewTextBoxColumn").Value
                SUCDESTORIG = dgwProduccion.CurrentRow.Cells("SUCDESTINODataGridViewTextBoxColumn").Value

                Dim TestPos As Integer
                If Not IsDBNull(dgwProduccion.CurrentRow.Cells("CONCEPTODataGridViewTextBoxColumn").Value) Then
                    TestPos = InStr(1, dgwProduccion.CurrentRow.Cells("CONCEPTODataGridViewTextBoxColumn").Value, ",", CompareMethod.Text)
                    ConceptoP1 = (Mid(dgwProduccion.CurrentRow.Cells("CONCEPTODataGridViewTextBoxColumn").Value, 1, TestPos))
                End If
            End If

            If lblTexto.Text = "Información de Salida" Then
                pbxSalida_Click(Nothing, Nothing)

            ElseIf lblTexto.Text = "Información de Entrada" Then
                pbxEntrada_Click(Nothing, Nothing)
            End If
        Else
            Me.TRANSFERENCIADETTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIADET, 0)
            lblInfo.Text = ""
        End If
        Me.Refresh()
        cmbDepositoDestino.Refresh()
        cmbDepositoOrigen.Refresh()

    End Sub

    Private Sub btnVerProximo_Click(sender As System.Object, e As System.EventArgs) Handles btnVerProximo.Click
        Dim MaxNro As Integer
        Try
            MaxNro = f.MaximoconWhere("NROMOVIMIENTO", "MOVPRODUCTO", "CONCEPTO LIKE '%TRANSF%' AND MODULO", 13)
        Catch ex As Exception
            MaxNro = 0
        End Try
        MaxNro = MaxNro + 1

        MessageBox.Show("Proximo Nro a Generar : " & MaxNro.ToString, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "" Then
            Me.TRANSFERENCIACABBindingSource.Filter = "NROMOVIMIENTO = " & BuscarTextBox.Text
        Else
            Me.TRANSFERENCIACABBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 244)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Eliminar estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            'Se debe Aumentar Stock y eliminar los datos de Movimiento de Producto
            EliminaMovProducto()

            myTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un Error al Eliminar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AccNuevo = 0 : AccEditar = 0 : modifdet = 0
        FechaFiltro()
        'Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
        'TRANSFERENCIACABBindingSource.Filter = "SUCDESTINO = " & SucCodigo

        Try
            If Config2 = "Deposito Destino seleccionado segun DashBoard" Then
                Me.TRANSFERENCIACABTableAdapter.FillBySucDestino(Me.DsInventario1.TRANSFERENCIACAB, SucCodigo, FechaFiltro1, FechaFiltro2)
            Else
                Me.TRANSFERENCIACABTableAdapter.Fill(Me.DsInventario1.TRANSFERENCIACAB, FechaFiltro1, FechaFiltro2)
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub EliminaMovProducto()
        Dim Sql As String = ""

        For i = 0 To dgwProduccionDet.RowCount - 1  ' PASA POR TODOS LOS MOVIMIENTOS TANTO EN DEP. ORIGEN COMO EN DESTINO
            Sql = ""
            Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=" & dgwProduccionDet.Rows(i).Cells("CODMOVIMIENTO").Value

            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub pbxImprimirOrden_Click(sender As System.Object, e As System.EventArgs) Handles pbxImprimirOrden.Click
        Dim frm = New VerInformes
        Dim rptmat As New Reportes.InvTransferenciasMATR
        Me.AjusteHistoricoAPedidoTableAdapter.FillBy(DsProduccion.AjusteHistoricoAPedido, dtpFechaEntrada.Value.Date)
        Dim desde As String = dtpFechaSalida.Text
        Dim hasta As String = ""
        If dtpFechaEntrada.Value.Hour = Nothing Then ' Si no tiene hora es porque lee la fecha (sin hora) de la grilla derecha
            hasta = dtpFechaEntrada.Text
        Else 'Si tiene hora es porque trae la fecha actual, porque no tiene dato Fecha Entrada
            hasta = "0"
        End If

        
        If Config3 <> "Numeracion Global" Then
            RiTransferenciaTableAdapter.FillByNroDep(DsRITransferencias.RITransferencia, txtNroProduccion.Text, cmbDepositoDestino.Text, cmbDepositoOrigen.Text)
        Else
            RiTransferenciaTableAdapter.FillByNroMov(DsRITransferencias.RITransferencia, txtNroProduccion.Text)
        End If

        rptmat.SetDataSource([DsRITransferencias])
        rptmat.SetParameterValue("pmtNroMov", "Nro. de Transferencia:" & txtNroProduccion.Text)
        rptmat.SetParameterValue("pmtObs", "Observación: " & txtObservacion.Text)
        rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
        If hasta = "0" Then
            rptmat.SetParameterValue("pmtRangoFecha", "Fecha Salida: " + desde)
        Else
            rptmat.SetParameterValue("pmtRangoFecha", "Fecha Salida: " + desde + "  Fecha Entrada: " + hasta)
        End If

        frm.CrystalReportViewer1.ReportSource = rptmat
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub btnModificarDet_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarDet.Click
        'se verifica que los campos principales no esten en blanco
        If (tbxCodigoProducto.Text <> "") And (txtCantidad.Text <> "") Then 'And (tbxPrecio.Text <> "")
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODPRODUCTODET").Value = vgCodProducto
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODCODIGODET").Value = vgCodCodigo
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODIGO").Value = tbxCodigoProducto.Text
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODDEPOSITO").Value = cmbDepositoDestino.SelectedValue
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("DESPRODUCTO").Value = DesProductoTextBox.Text
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CANTIDAD").Value = CDec(txtCantidad.Text)
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("TIPOPROD").Value = cmbDepositoOrigen.SelectedValue
            'dgwProduccionDet.Rows(vgLineaConsumo).Cells("PRECIODataGridViewTextBoxColumn").Value = CDec(tbxPrecio.Text)
            If AccEditar = 1 Then
                dgwProduccionDet.Rows(vgLineaConsumo).Cells("ESTADOGRILLA").Value = "U"
            ElseIf AccNuevo = 1 Then
                dgwProduccionDet.Rows(vgLineaConsumo).Cells("ESTADOGRILLA").Value = "I"
            End If

            btnAgregar.BringToFront() : btnEliminarProducto.BringToFront()
            tbxCodigoProducto.Enabled = True

            'RecorreDetalle()
            Limpiar()
            tbxCodigoProducto.Focus()
        End If
        modifdet = 0
    End Sub

    Private Sub btnCancelarDet_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelarDet.Click
        Limpiar()
        btnAgregar.BringToFront() : btnEliminarProducto.BringToFront()
        tbxCodigoProducto.Enabled = True
        tbxCodigoProducto.Focus()
        modifdet = 0
    End Sub

    Private Sub dgwProduccionDet_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwProduccionDet.DoubleClick
        Try
            If IsDBNull(dgwProduccionDet.CurrentRow) Then
                Exit Sub
            Else
                vgLineaConsumo = dgwProduccionDet.CurrentRow.Index
                modifdet = 1

                If IsDBNull(dgwProduccionDet.CurrentRow.Cells("CODIGO").Value) Then
                    tbxCodigoProducto.Text = ""
                Else
                    tbxCodigoProducto.Text = dgwProduccionDet.CurrentRow.Cells("CODIGO").Value
                End If

                If tbxCodigoProducto.Text = "" Then
                    vgCodProducto = 0
                    vgCodCodigo = 0
                Else
                    vgCodCodigo = dgwProduccionDet.CurrentRow.Cells("CODCODIGODET").Value
                    vgCodProducto = dgwProduccionDet.CurrentRow.Cells("CODPRODUCTODET").Value
                End If

                txtCantidad.Text = CDec(dgwProduccionDet.CurrentRow.Cells("CANTIDAD").Value)
                'tbxPrecio.Text = CDec(dgwProduccionDet.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn").Value)
                DesProductoTextBox.Text = dgwProduccionDet.CurrentRow.Cells("DESPRODUCTO").Value
                dgwProduccionDet.CurrentRow.Cells("CantAnterior").Value = txtCantidad.Text
            End If

        Catch ex As Exception

        End Try
        btnModificarDet.BringToFront() : btnCancelarDet.BringToFront()
        'tbxCodigoProducto.Enabled = True
        'tbxCodigoProducto.Focus()
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        upcProductos.PopupControl = gbxProductos
        upcProductos.Show()

        BuscarProductoTextBox.Text = ""
        BuscarProductoTextBox.Focus()
    End Sub

    Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
        lblInfo.Text = "(De " & cmbDepositoOrigen.Text & " a " & cmbDepositoDestino.Text & ")"
        If lblTexto.Text = "Información de Salida" And cmbDepositoDestino.SelectedValue <> cmbDepositoOrigen.SelectedValue Then
            SUCORIGORIG = cmbDepositoOrigen.SelectedValue
            SUCDESTORIG = cmbDepositoDestino.SelectedValue
        End If
    End Sub

    Private Sub cmbDepositoDestino_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDepositoDestino.SelectedIndexChanged
        lblInfo.Text = "(De " & cmbDepositoOrigen.Text & " a " & cmbDepositoDestino.Text & ")"
        If lblTexto.Text = "Información de Salida" And cmbDepositoDestino.SelectedValue <> cmbDepositoOrigen.SelectedValue Then
            SUCORIGORIG = cmbDepositoOrigen.SelectedValue
            SUCDESTORIG = cmbDepositoDestino.SelectedValue
        End If
    End Sub

    Private Sub dgwProduccionDet_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgwProduccionDet.CellContentClick

    End Sub
End Class