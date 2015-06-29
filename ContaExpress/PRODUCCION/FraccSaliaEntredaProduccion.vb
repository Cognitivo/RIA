'Desing by Yolanda Zelaya
' 0 - Fraccionamiento  / 1 - Produccion
' 0 - Salida / 1 - Entrada

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class FraccSaliaEntredaProduccion

    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim permiso As Double
    Dim AccNuevo, AccEditar, modifdet As Integer
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

    Private Sub ProdSaliaEntredaProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 241)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso Abrir esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            Me.SUCURSALTableAdapter.Fill(Me.DsProdSimple.SUCURSAL)
            Me.PRODUCTOSTableAdapter.Fill(Me.DsProdSimple.PRODUCTOS)

            InicializaFechaFiltro()
            Try
                Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)
                Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try

            pbxSalida_Click(Nothing, Nothing)
            Deshabilita()
        End If
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

        CancelarPictureBox.Enabled = False
        CancelarPictureBox.Image = My.Resources.SaveCancelOff
        CancelarPictureBox.Cursor = Cursors.Arrow
        GuardarPictureBox.Enabled = False
        GuardarPictureBox.Image = My.Resources.SaveOff
        GuardarPictureBox.Cursor = Cursors.Arrow

        BuscarTextBox.Enabled = True
        BtnFiltro.Enabled = True
        dgwProduccion.Enabled = True
        CmbMes.Enabled = True
        CmbAño.Enabled = True

        tbxCodigoProducto.Enabled = False
        btnBuscProductos.Enabled = False
        txtCantidad.Enabled = False
        tbxPrecio.Enabled = False
        btnAgregar.Enabled = False
        btnEliminarProducto.Enabled = False
        btnModificarDet.Enabled = False
        btnCancelarDet.Enabled = False
        DesProductoTextBox.Enabled = False
        dgwProduccionDet.Enabled = True

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

        BuscarTextBox.Enabled = False
        dgwProduccion.Enabled = False
        BtnFiltro.Enabled = False
        CmbMes.Enabled = False
        CmbAño.Enabled = False

        tbxCodigoProducto.Enabled = True
        btnBuscProductos.Enabled = True
        txtCantidad.Enabled = True
        tbxPrecio.Enabled = True
        btnAgregar.Enabled = True
        btnEliminarProducto.Enabled = True
        btnModificarDet.Enabled = True
        btnCancelarDet.Enabled = True
        DesProductoTextBox.Enabled = True
        dgwProduccionDet.Enabled = True

    End Sub

    Private Sub pbxEntrada_Click(sender As System.Object, e As System.EventArgs) Handles pbxEntrada.Click
        pbxEntrada.Image = My.Resources.Entrada
        pbxSalida.Image = My.Resources.SalidaOff
        EntradaSalida = 1
        lblTexto.Text = "Información de Entrada"

        'Ocultamos las Filas de Salida
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value = 0 Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            End If
        Next
        RecorreDetalle()
    End Sub

    Private Sub pbxSalida_Click(sender As System.Object, e As System.EventArgs) Handles pbxSalida.Click
        pbxEntrada.Image = My.Resources.EntradaOff
        pbxSalida.Image = My.Resources.Salida
        EntradaSalida = 0
        lblTexto.Text = "Información de Salida"

        'Ocultamos las Filas de Entrada
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value = 1 Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            End If
        Next

        RecorreDetalle()
    End Sub

    Private Sub cbxDeposito_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cbxDeposito.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            dtpFecha.Focus()
        End If
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
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
            upcProductos.Show()

            BuscarProductoTextBox.Text = ""
            BuscarProductoTextBox.Focus()
            e.Handled = True
        End If
    End Sub

    Private Sub CantidadVentaMaskedEdit_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantidad.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxPrecio.Focus()
        End If
    End Sub

    Private Sub tbxPrecioVenta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxPrecio.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If modifdet = 0 Then
                btnAgregar.Focus()
            Else
                btnModificarDet.Focus()
            End If
        End If
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 238)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso crear un Nuevo Consumo Interno", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        AccNuevo = 1 : AccEditar = 0
        Habilita()
        FechaFiltro1 = "01/01/2000" : FechaFiltro2 = "01/01/3000"

        Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)
        Me.PRODENTRADASALIDABindingSource.AddNew()

        Try
            Me.PRODENTRADASALIDADETTableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDADET, 0, EntradaSalida)
        Catch ex As Exception
        End Try

        If cbxDeposito.Text = "" Then
            cbxDeposito.SelectedIndex = cbxDeposito.SelectedIndex + 1
        End If

        lblNroProduccion.Visible = False : txtNroProduccion.Visible = True

        Dim MaxNro As Double = f.MaximoconWhere("NROPRODUCCION", "PRODENTRADASALIDA", "TIPO", 0)
        MaxNro = MaxNro + 1
        txtNroProduccion.Text = MaxNro

        txtUsuario.Text = UsuNombre
        cbxDeposito.Focus()
        cbxDeposito.Enabled = True
    End Sub

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        If ProductosGridView.RowCount <> 0 Then
            vgCodCodigo = ProductosGridView.CurrentRow.Cells("CODCODIGO").Value
            vgCodProducto = ProductosGridView.CurrentRow.Cells("CODPRODUCTO").Value
            Me.tbxCodigoProducto.Text = ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn1").Value

            If IsDBNull(ProductosGridView.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn1").Value) Then
                Me.tbxPrecio.Text = 1
            Else
                Me.tbxPrecio.Text = ProductosGridView.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn1").Value
            End If

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

                    If IsDBNull(ProductosGridView.Rows(pos).Cells("PRECIODataGridViewTextBoxColumn1").Value) Then
                        Me.tbxPrecio.Text = 1
                    Else
                        Me.tbxPrecio.Text = ProductosGridView.Rows(pos).Cells("PRECIODataGridViewTextBoxColumn1").Value
                    End If

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
                        Me.tbxPrecio.Text = odrProducto("PRECIO")
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

        If tbxPrecio.Text = "" Then
            MessageBox.Show("Ingrese el Costo del Producto", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            tbxPrecio.Focus()
            tbxPrecio.BackColor = Color.Pink
            Exit Sub
        End If

        Try
            For i = 0 To dgwProduccionDet.Rows.Count - 1
                If IsDBNull(dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                Else
                    If vgCodCodigo = dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value And dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value = EntradaSalida Then
                        MessageBox.Show("El Producto ya se encuentra en el detalle", "Cogent")
                        tbxCodigoProducto.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        PRODENTRADASALIDADETBindingSource.AddNew()
        Dim c As Integer = dgwProduccionDet.RowCount

        dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value = vgCodCodigo
        dgwProduccionDet.Rows(c - 1).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = vgCodProducto
        dgwProduccionDet.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = tbxCodigoProducto.Text
        dgwProduccionDet.Rows(c - 1).Cells("DESPRODUCTO").Value = DesProductoTextBox.Text
        dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value = CDec(Me.txtCantidad.Text)
        dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value = CDec(Me.tbxPrecio.Text)
        dgwProduccionDet.Rows(c - 1).Cells("ESTADOGRILLA").Value = "I" 'Insert
        dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = EntradaSalida

        'Ocultamos las Filas de Entrada
        For i = 0 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value = EntradaSalida Then
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = True
            Else
                dgwProduccionDet.CurrentCell = Nothing
                Me.dgwProduccionDet.Rows(i).Visible = False
            End If
        Next

        RecorreDetalle()
        Limpiar()
        tbxCodigoProducto.Focus()
    End Sub

    Private Sub Limpiar()
        tbxCodigoProducto.Text = ""
        txtCantidad.Text = ""
        tbxPrecio.Text = ""
        DesProductoTextBox.Text = ""
    End Sub

    Private Sub RecorreDetalle()
        Dim c As Integer = dgwProduccionDet.RowCount
        Dim SubTotal, Total As Double

        txtTotalConsumo.Text = 0

        For c = 1 To c
            If dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = EntradaSalida Then
                SubTotal = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                dgwProduccionDet.Rows(c - 1).Cells("SUBTOTALPROD").Value = SubTotal

                Total = Total + SubTotal
                txtTotalConsumo.Text = FormatNumber(Total, 0)
            End If
        Next
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 239)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Modificar estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        AccNuevo = 0 : AccEditar = 1
        lblNroProduccion.Visible = False : txtNroProduccion.Visible = True

        For i = 0 To dgwProduccionDet.Rows.Count - 1
            dgwProduccionDet.Rows(i).Cells("CantAnterior").Value = dgwProduccionDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value
            dgwProduccionDet.Rows(i).Cells("CodCodigoAnt").Value = dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
        Next

        Habilita()
        cbxDeposito.Enabled = False
        dtpFecha.Focus()
        txtNroProduccion.Visible = False
        lblNroProduccion.Visible = True
        ModificarPictureBox.Image = My.Resources.EditActive
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            PRODENTRADASALIDABindingSource.CancelEdit()
            PRODENTRADASALIDABindingSource.RemoveFilter()

            FechaFiltro()

            Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)

            If dgwProduccion.RowCount <> 0 Then
                Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value)
            Else
                Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, 0)
                txtTotalConsumo.Text = 0
            End If

            If lblTexto.Text = "Información de Entrada" Then
                pbxEntrada_Click(Nothing, Nothing)
            Else
                pbxSalida_Click(Nothing, Nothing)
            End If

            btnCancelarDet_Click(Nothing, Nothing)

            AccNuevo = 0 : AccEditar = 0 : modifdet = 0
            lblNroProduccion.Visible = True : txtNroProduccion.Visible = False
            Deshabilita()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GuardarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles GuardarPictureBox.Click
        Dim vError As Integer = 0
        'Verificamos los Campos Necesarios antes de Guardar
        If cbxDeposito.Text = "" Then
            MessageBox.Show("Ingrese un Deposito", "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbxDeposito.Focus()
            cbxDeposito.BackColor = Color.Pink
            Exit Sub
        End If

        'Guardamos
        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        If AccEditar = 1 Then
            Try
                vgCodCabecera = dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value

                ActualizaCabecera()
                InsertaActualizaDetalle()

                myTrans.Commit()
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al Guardar : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                vError = 1
            End Try

        Else
            Try
                InsertaCabecera()
                InsertaActualizaDetalle()

                myTrans.Commit()
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al Guardar : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                vError = 1
            End Try

        End If

        myTrans.Dispose()

        If vError = 0 Then
            'Actualiza / Descuenta Stock
            ser.Abrir(sqlc)
            cmd.Connection = sqlc

            Try
                InsertaMovProducto()
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al Actualizar el Stock : " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

        Dim CodTemp = vgCodCabecera

        FechaFiltro()
        Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)

        'Buscamos la posicion del registro guardado
        For i = 0 To dgwProduccion.RowCount - 1
            If dgwProduccion.Rows(i).Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value = CodTemp Then
                PRODENTRADASALIDABindingSource.Position = i
                Exit For
            End If
        Next

        Try
            Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try

        AccNuevo = 0 : AccEditar = 0 : modifdet = 0
        lblNroProduccion.Visible = True : txtNroProduccion.Visible = False

        pbxSalida_Click(Nothing, Nothing)
        RecorreDetalle()
        Deshabilita()
    End Sub

    Private Sub InsertaMovProducto()
        Dim Sql As String = ""
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable As String
        Dim c As Integer = dgwProduccionDet.RowCount
        Costeable = ""

        For c = 1 To c
            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
                CantidadFactura = "NULL"
            Else
                CantidadFactura = dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                CantidadFactura = Replace(CantidadFactura, ",", ".")

                'Verificamos si es ENTRADA o SALIDA
                If dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 0 Then 'SALIDA
                    CantidadFactura = "-" + CantidadFactura
                    Costeable = 0
                ElseIf dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 1 Then  'ENTRADA
                    Costeable = 1
                End If
            End If

            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigoFactura = "NULL"
            Else
                CodCodigoFactura = dgwProduccionDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value) Then
                Precio = "NULL"
            Else
                Precio = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value
                Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                Precio = Replace(Precio, ",", ".")
            End If

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFecha.Text
            Dim Concatenar As String = Concat & " " + hora

            If dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "I" Then
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK) " & _
                       "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & cbxDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),28," & vgCodCabecera & _
                       "," & CantidadFactura & "," & Precio & ",'Fraccionamiento Nro " & txtNroProduccion.Text & "'," & Costeable & ",0,1)"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "U" Then

                Dim CantNueva, CantAnterior As String
                CantNueva = dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                CantAnterior = dgwProduccionDet.Rows(c - 1).Cells("CantAnterior").Value

                'Verificamos si es ENTRADA o SALIDA
                If dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 0 Then 'SALIDA
                    CantNueva = CDec(CantNueva) * -1
                    CantAnterior = CDec(CantAnterior) * -1
                End If

                CantNueva = Funciones.Cadenas.QuitarCad(CantNueva, ".")
                CantNueva = Replace(CantNueva, ",", ".")
                CantAnterior = Funciones.Cadenas.QuitarCad(CantAnterior, ".")
                CantAnterior = Replace(CantAnterior, ",", ".")

                Sql = "UPDATE MOVPRODUCTO SET CANTIDAD=" & CantNueva & ", CODCODIGO=" & CodCodigoFactura & ",VALOR=" & Precio & " WHERE CANTIDAD=" & CantAnterior & " AND CODCODIGO=" & dgwProduccionDet.Rows(c - 1).Cells("CodCodigoAnt").Value & " AND CODDEPOSITO=" & cbxDeposito.SelectedValue & " AND MODULOTRANSID=" & dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value & " AND MODULO=28 AND TIPOPRODUCCION=0"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("EstadoGrilla").Value = "D" Then
                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=(SELECT MAX(CODMOVIMIENTO) FROM MOVPRODUCTO WHERE CODCODIGO = " & CodCodigoFactura & " AND MODULO  = 28 AND MODULOTRANSID= " & dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value & _
                      " AND CANTIDAD = " & CantidadFactura & " AND TIPOPRODUCCION = 0)"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub InsertaCabecera()
        Dim Sql As String = ""
        Dim Obs As String
        Dim SubTotalSalida, SubTotalEntrada, TotalEntrada, TotalSalida As Double

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFecha.Text
        Dim FechaCompleta As String = Concat & " " + hora

        If txtObservacion.Text = "" Then
            Obs = " "
        Else
            Obs = txtObservacion.Text
        End If

        'Obtenemos el TotalEntrada y el TotalSalida
        For c = 1 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 0 Then 'Salida
                SubTotalSalida = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                TotalSalida = TotalSalida + SubTotalSalida

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 1 Then 'Entrada
                SubTotalEntrada = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                TotalEntrada = TotalEntrada + SubTotalEntrada
            End If
        Next

        TotalEntrada = Funciones.Cadenas.QuitarCad(TotalEntrada, ".")
        TotalEntrada = Replace(TotalEntrada, ",", ".")
        TotalSalida = Funciones.Cadenas.QuitarCad(TotalSalida, ".")
        TotalSalida = Replace(TotalSalida, ",", ".")

        Sql = "INSERT INTO PRODENTRADASALIDA (CODUSUARIO,CODDEPOSITO,FECHA,NROPRODUCCION,OBSERVACION,TIPO,TOTALPRODENTRADA,TOTALPRODSALIDA)  " & _
              "VALUES(" & UsuCodigo & "," & cbxDeposito.SelectedValue & ",CONVERT (DATETIME, '" & FechaCompleta & "',103), " & Me.txtNroProduccion.Text & ",'" & Obs & "'," & _
              0 & "," & TotalEntrada & "," & TotalSalida & ")   " & _
              "SELECT CODPRODUCCION FROM PRODENTRADASALIDA WHERE CODPRODUCCION = SCOPE_IDENTITY();"

        cmd.CommandText = Sql
        vgCodCabecera = cmd.ExecuteScalar()
    End Sub

    Private Sub ActualizaCabecera()
        Dim Sql As String = ""
        Dim Obs As String
        Dim SubTotalSalida, SubTotalEntrada, TotalEntrada, TotalSalida As Double

        Dim hora As String = Now.ToString("HH:mm:ss")
        Dim Concat As String = dtpFecha.Text
        Dim FechaCompleta As String = Concat & " " + hora

        If txtObservacion.Text = "" Then
            Obs = " "
        Else
            Obs = txtObservacion.Text
        End If

        'Obtenemos el TotalEntrada y el TotalSalida
        For c = 1 To dgwProduccionDet.RowCount - 1
            If dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 0 Then 'Salida
                SubTotalSalida = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                TotalSalida = TotalSalida + SubTotalSalida

            ElseIf dgwProduccionDet.Rows(c - 1).Cells("TIPODataGridViewTextBoxColumn1").Value = 1 Then 'Entrada
                SubTotalEntrada = dgwProduccionDet.Rows(c - 1).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                TotalEntrada = TotalEntrada + SubTotalEntrada
            End If
        Next

        TotalEntrada = Funciones.Cadenas.QuitarCad(TotalEntrada, ".")
        TotalEntrada = Replace(TotalEntrada, ",", ".")
        TotalSalida = Funciones.Cadenas.QuitarCad(TotalSalida, ".")
        TotalSalida = Replace(TotalSalida, ",", ".")

        Sql = "UPDATE PRODENTRADASALIDA SET CODUSUARIO = " & UsuCodigo & ", CODDEPOSITO = " & cbxDeposito.SelectedValue & ",FECHA = CONVERT (DATETIME, '" & FechaCompleta & "',103), NROPRODUCCION = " & _
               Me.txtNroProduccion.Text & ",OBSERVACION = '" & Obs & "', TIPO = " & 0 & ",TOTALPRODENTRADA = " & TotalEntrada & ",TOTALPRODSALIDA = " & TotalSalida & "  " & _
               "WHERE CODPRODUCCION = " & vgCodCabecera

        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaActualizaDetalle()
        Dim Sql As String = ""
        Dim CodCodigo, Cantidad, Costo, Tipo As String

        CodCodigo = "" : Cantidad = "" : Costo = "" : Tipo = ""

        For i = 0 To dgwProduccionDet.RowCount - 1
            If IsDBNull(dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
            Else
                CodCodigo = dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwProduccionDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
            Else
                Cantidad = dgwProduccionDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                Cantidad = Funciones.Cadenas.QuitarCad(Cantidad, ".")
                Cantidad = Replace(Cantidad, ",", ".")
            End If

            If IsDBNull(dgwProduccionDet.Rows(i).Cells("PRECIODataGridViewTextBoxColumn").Value) Then
            Else
                Costo = dgwProduccionDet.Rows(i).Cells("PRECIODataGridViewTextBoxColumn").Value
                Costo = Funciones.Cadenas.QuitarCad(Costo, ".")
                Costo = Replace(Costo, ",", ".")
            End If

            If IsDBNull(dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value) Then
            Else
                Tipo = dgwProduccionDet.Rows(i).Cells("TIPODataGridViewTextBoxColumn1").Value
            End If

            If dgwProduccionDet.Rows(i).Cells("EstadoGrilla").Value = "I" Then
                Sql = "INSERT INTO PRODENTRADASALIDADET (CODPRODUCCION,CODCODIGO,CANTIDAD,COSTO,TIPO)  " & _
                     "VALUES(" & vgCodCabecera & "," & CodCodigo & "," & Cantidad & "," & Costo & "," & Tipo & ")"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(i).Cells("EstadoGrilla").Value = "U" Then

                Sql = " UPDATE PRODENTRADASALIDADET SET CODCODIGO=" & CodCodigo & ", CANTIDAD= " & Cantidad & ", COSTO = " & Costo & " WHERE CODPRODUCCIONDET =" & dgwProduccionDet.Rows(i).Cells("CODPRODUCCIONDETDataGridViewTextBoxColumn").Value
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwProduccionDet.Rows(i).Cells("EstadoGrilla").Value = "D" Then
                Sql = "DELETE FROM PRODENTRADASALIDADET WHERE CODPRODUCCIONDET=" & dgwProduccionDet.Rows(i).Cells("CODPRODUCCIONDETDataGridViewTextBoxColumn").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub txtNroProduccion_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroProduccion.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxDeposito.Enabled = True Then
                cbxDeposito.Focus()
            Else
                dtpFecha.Focus()
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
        Me.dgwProduccionDet.CurrentRow.Cells("DESPRODUCTO").Value = "Este Codigo sera Eliminado"
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)
    End Sub

    Private Sub dgwProduccion_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwProduccion.SelectionChanged
        If dgwProduccion.RowCount <> 0 Then
            Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value)

            If lblTexto.Text = "Información de Salida" Then
                pbxSalida_Click(Nothing, Nothing)

            ElseIf lblTexto.Text = "Información de Entrada" Then
                pbxEntrada_Click(Nothing, Nothing)
            End If
        Else
            Me.PRODENTRADASALIDADETTableAdapter.FillBy(Me.DsProdSimple.PRODENTRADASALIDADET, 0)
        End If
    End Sub

    Private Sub btnVerProximo_Click(sender As System.Object, e As System.EventArgs) Handles btnVerProximo.Click
        Dim MaxNro As Double = f.MaximoconWhere("NROPRODUCCION", "PRODENTRADASALIDA", "TIPO", 0)
        MaxNro = MaxNro + 1

        MessageBox.Show("Proximo Nro a Generar : " & MaxNro.ToString, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "" Then
            Me.PRODENTRADASALIDABindingSource.Filter = "NROPRODUCCION = " & BuscarTextBox.Text
        Else
            Me.PRODENTRADASALIDABindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 240)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Eliminar estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar?", "POSEXPRESS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim sql As String

        ser.Abrir(sqlc)
        myTrans = sqlc.BeginTransaction(IsolationLevel.ReadCommitted, "Actualizar")

        cmd.Connection = sqlc
        cmd.Transaction = myTrans

        Try
            'Se debe Aumentar Stock y eliminar los datos de Movimiento de Producto
            EliminaMovProducto()

            'Se debe eliminar la Cabecera y el detalle, Aumentar/Disminuye stock y Eliminar de Movimientos
            sql = "DELETE FROM PRODENTRADASALIDA WHERE CODPRODUCCION= " & dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value & " "
            sql = sql + "DELETE FROM PRODENTRADASALIDADET WHERE CODPRODUCCION = " & dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un Error al Eliminar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AccNuevo = 0 : AccEditar = 0 : modifdet = 0
        FechaFiltro()
        Me.PRODENTRADASALIDATableAdapter.Fill(Me.DsProdSimple.PRODENTRADASALIDA, FechaFiltro1, FechaFiltro2, 0)
    End Sub

    Private Sub EliminaMovProducto()
        Dim Sql As String = ""
        Dim CodCodigo As String
        Dim c As Integer = dgwProduccionDet.RowCount

        For i = 0 To c - 1
            If IsDBNull(dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigo = "NULL"
            Else
                CodCodigo = dgwProduccionDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=(SELECT MAX(CODMOVIMIENTO) FROM MOVPRODUCTO WHERE MODULO  = 28 AND TIPOPRODUCCION = 0 AND CODCODIGO = " & CodCodigo & "AND MODULOTRANSID= " & dgwProduccion.CurrentRow.Cells("CODPRODUCCIONDataGridViewTextBoxColumn").Value & ")"

            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub pbxImprimirOrden_Click(sender As System.Object, e As System.EventArgs) Handles pbxImprimirOrden.Click
        Dim frm = New VerInformes
        Dim rptmat As New Reportes.ProdProduccionMATR

        Me.AjusteHistoricoAPedidoTableAdapter.FillBy(DsProduccion.AjusteHistoricoAPedido, dtpFecha.Value.Date)
        Me.RPTPRODUCCIONTableAdapter.Fill(DsProdSimple.RPTPRODUCCION, Me.lblNroProduccion.Text, 0)

        rptmat.SetDataSource([DsProdSimple])
        rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
        rptmat.SetParameterValue("pmtComprobante", "Entrada / Salida de Fraccionamiento")

        frm.CrystalReportViewer1.ReportSource = rptmat
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub
 
    Private Sub btnModificarDet_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarDet.Click

        'se verifica que los campos principales no esten en blanco
        If (tbxCodigoProducto.Text <> "") And (txtCantidad.Text <> "") And (tbxPrecio.Text <> "") Then
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODPRODUCTODataGridViewTextBoxColumn").Value = vgCodProducto
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODCODIGODataGridViewTextBoxColumn").Value = vgCodCodigo
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CODIGODataGridViewTextBoxColumn").Value = tbxCodigoProducto.Text
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("DESPRODUCTO").Value = DesProductoTextBox.Text
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("CANTIDADDataGridViewTextBoxColumn").Value = CDec(txtCantidad.Text)
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("PRECIODataGridViewTextBoxColumn").Value = CDec(tbxPrecio.Text)
            If AccEditar = 1 Then
                dgwProduccionDet.Rows(vgLineaConsumo).Cells("ESTADOGRILLA").Value = "U"
            ElseIf AccNuevo = 1 Then
                dgwProduccionDet.Rows(vgLineaConsumo).Cells("ESTADOGRILLA").Value = "I"
            End If

            Dim CalculoTotal As Integer = (dgwProduccionDet.Rows(vgLineaConsumo).Cells("PRECIODataGridViewTextBoxColumn").Value * dgwProduccionDet.Rows(vgLineaConsumo).Cells("CANTIDADDataGridViewTextBoxColumn").Value)
            dgwProduccionDet.Rows(vgLineaConsumo).Cells("SUBTOTALPROD").Value = CalculoTotal

            btnAgregar.BringToFront() : btnEliminarProducto.BringToFront()
            tbxCodigoProducto.Enabled = True

            RecorreDetalle()
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
                If IsDBNull(dgwProduccionDet.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                    tbxCodigoProducto.Text = ""
                Else
                    tbxCodigoProducto.Text = dgwProduccionDet.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
                End If

                If tbxCodigoProducto.Text = "" Then
                    vgCodProducto = 0
                    vgCodCodigo = 0
                End If

                txtCantidad.Text = CDec(dgwProduccionDet.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value)
                tbxPrecio.Text = CDec(dgwProduccionDet.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn").Value)
                DesProductoTextBox.Text = dgwProduccionDet.CurrentRow.Cells("DESPRODUCTO").Value
            End If
        Catch ex As Exception
        End Try

        btnModificarDet.BringToFront() : btnCancelarDet.BringToFront()
        tbxCodigoProducto.Enabled = True
        tbxCodigoProducto.Focus()
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        upcProductos.Show()
        BuscarProductoTextBox.Text = ""
        BuscarProductoTextBox.Focus()
    End Sub
End Class