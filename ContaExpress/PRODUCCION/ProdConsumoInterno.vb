'Desing by Yolanda Zelaya
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class ProdConsumoInterno
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim permiso As Double
    Dim AccNuevo, AccEditar As Integer
    Dim f As New Funciones.Funciones
    Dim vgCodCodigo, vgCodProducto, vgCodCabecera, vgLineaConsumo, modifdet As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub ProdConsumoInterno_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    End Sub

    Private Sub ProdConsumoInterno_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        permiso = PermisoAplicado(UsuCodigo, 231)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso Abrir esta Ventana", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        Else
            Me.PRODUCTOSTableAdapter.Fill(Me.DsProdSimple.PRODUCTOS)
            Me.SUCURSALTableAdapter.Fill(Me.DsProdSimple.SUCURSAL)

            InicializaFechaFiltro()
            Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)
            Try
                Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value)
            Catch ex As Exception
            End Try

            dgwComsumo_SelectionChanged(Nothing, Nothing)

            AccNuevo = 0 : AccEditar = 0
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

    Private Sub Deshabilita()
        pnlConsumoCab.Enabled = False
        pnlConsumoDet.Enabled = True
        txtTotalConsumo.Enabled = False

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
        dgwComsumo.Enabled = True
        CmbMes.Enabled = True
        CmbAño.Enabled = True

        tbxCodigoProducto.Enabled = False
        btnBuscProductos.Enabled = False
        txtCantidad.Enabled = False
        tbxPrecio.Enabled = False
        btnAgregar.Enabled = False
        btnModificarDet.Enabled = False
        btnEliminarProducto.Enabled = False
        btnCancelarDet.Enabled = False
        DesProductoTextBox.Enabled = False
        dgwConsumoDet.Enabled = True

    End Sub

    Private Sub Habilita()
        pnlConsumoCab.Enabled = True
        pnlConsumoDet.Enabled = True
        txtTotalConsumo.Enabled = True

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
        BtnFiltro.Enabled = False
        dgwComsumo.Enabled = False
        CmbMes.Enabled = False
        CmbAño.Enabled = False

        tbxCodigoProducto.Enabled = True
        btnBuscProductos.Enabled = True
        txtCantidad.Enabled = True
        tbxPrecio.Enabled = True
        btnAgregar.Enabled = True
        btnModificarDet.Enabled = True
        btnEliminarProducto.Enabled = True
        btnCancelarDet.Enabled = True
        DesProductoTextBox.Enabled = True
        dgwConsumoDet.Enabled = True

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
        permiso = PermisoAplicado(UsuCodigo, 228)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso crear un Nuevo Consumo Interno", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        AccNuevo = 1 : AccEditar = 0
        Habilita()
        FechaFiltro1 = "01/01/2000" : FechaFiltro2 = "01/01/3000"

        Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)
        Me.PRODCONSUMOINTERNOBindingSource.AddNew()

        Try
            Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, 0)
        Catch ex As Exception
        End Try

        If cbxDeposito.Text = "" Then
            cbxDeposito.SelectedIndex = cbxDeposito.SelectedIndex + 1
        End If

        lblNroConsumo.Visible = False : txtNroConsumo.Visible = True
        Dim MaxNro As Double = f.MaximoconWhere("NROCONSUMO", "PRODCONSUMOINTERNO", "TIPO", 4)
        MaxNro = MaxNro + 1
        txtNroConsumo.Text = MaxNro

        txtUsuario.Text = UsuNombre
        cbxDeposito.Focus()
        cbxDeposito.Enabled = True
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        upcProductos.Show()
        BuscarProductoTextBox.Text = ""
        BuscarProductoTextBox.Focus()
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

    Private Sub ProductosGridView_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles ProductosGridView.CellDoubleClick
        If ProductosGridView.RowCount <> 0 Then
            vgCodCodigo = ProductosGridView.CurrentRow.Cells("CODCODIGO").Value
            vgCodProducto = ProductosGridView.CurrentRow.Cells("CODPRODUCTO").Value
            Me.tbxCodigoProducto.Text = ProductosGridView.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn1").Value

            If IsDBNull(ProductosGridView.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn").Value) Then
                Me.tbxPrecio.Text = 1
            Else
                Me.tbxPrecio.Text = ProductosGridView.CurrentRow.Cells("PRECIODataGridViewTextBoxColumn").Value
            End If

            DesProductoTextBox.Text = ProductosGridView.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
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

                    If IsDBNull(ProductosGridView.Rows(pos).Cells("PRECIODataGridViewTextBoxColumn").Value) Then
                        Me.tbxPrecio.Text = 1
                    Else
                        Me.tbxPrecio.Text = ProductosGridView.Rows(pos).Cells("PRECIODataGridViewTextBoxColumn").Value
                    End If

                    DesProductoTextBox.Text = ProductosGridView.Rows(pos).Cells("DESPRODUCTODataGridViewTextBoxColumn1").Value
                Catch ex As Exception
                End Try
            End If

            upcProductos.Close()
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
            For i = 0 To dgwConsumoDet.Rows.Count - 1
                If IsDBNull(dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                Else
                    If vgCodCodigo = dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value Then
                        MessageBox.Show("El Producto ya se encuentra en el detalle", "Cogent")
                        tbxCodigoProducto.Focus()
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception

        End Try

        PRODCONSUMOINTERNODETBindingSource.AddNew()
        Dim c As Integer = dgwConsumoDet.RowCount

        dgwConsumoDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value = vgCodCodigo
        dgwConsumoDet.Rows(c - 1).Cells("CODPRODUCTO2").Value = vgCodProducto
        dgwConsumoDet.Rows(c - 1).Cells("CODIGODataGridViewTextBoxColumn").Value = tbxCodigoProducto.Text
        dgwConsumoDet.Rows(c - 1).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = DesProductoTextBox.Text
        dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value = CDec(Me.txtCantidad.Text)
        dgwConsumoDet.Rows(c - 1).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value = CDec(Me.tbxPrecio.Text)
        dgwConsumoDet.Rows(c - 1).Cells("EstadoGrilla").Value = "I" 'Insert

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
        Dim c As Integer = dgwConsumoDet.RowCount
        Dim SubTotal, Total As Double

        For c = 1 To c
            SubTotal = dgwConsumoDet.Rows(c - 1).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value * dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
            dgwConsumoDet.Rows(c - 1).Cells("SubTotal").Value = SubTotal

            Total = Total + SubTotal
            txtTotalConsumo.Text = FormatNumber(Total, 0)
        Next
    End Sub

    Private Sub RecorreDetalleSinTotal()
        Dim c As Integer = dgwConsumoDet.RowCount
        Dim SubTotal As Double

        For c = 1 To c
            SubTotal = dgwConsumoDet.Rows(c - 1).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value * dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
            dgwConsumoDet.Rows(c - 1).Cells("SubTotal").Value = SubTotal
        Next
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

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 229)
        If permiso = 0 Then
            MessageBox.Show("Usted No tiene Permiso para Modificar estos Datos", "Pos Express", MessageBoxButtons.OK, MessageBoxIcon.Question)
            Exit Sub
        End If

        AccNuevo = 0 : AccEditar = 1
        lblNroConsumo.Visible = False : txtNroConsumo.Visible = True

        For i = 0 To dgwConsumoDet.Rows.Count - 1
            dgwConsumoDet.Rows(i).Cells("CantAnterior").Value = dgwConsumoDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value
            dgwConsumoDet.Rows(i).Cells("CodCodigoAnt").Value = dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
        Next

        Habilita()
        cbxDeposito.Enabled = False
        dtpFecha.Focus()
        txtNroConsumo.Visible = False
        lblNroConsumo.Visible = True
        ModificarPictureBox.Image = My.Resources.EditActive
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            PRODCONSUMOINTERNOBindingSource.CancelEdit()
            PRODCONSUMOINTERNOBindingSource.RemoveFilter()

            FechaFiltro()

            Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)

            If dgwComsumo.RowCount <> 0 Then
                Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value)
            Else
                Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, 0)
                txtTotalConsumo.Text = 0
            End If

            btnCancelarDet_Click(Nothing, Nothing)

            AccNuevo = 0 : AccEditar = 0 : modifdet = 0
            lblNroConsumo.Visible = True : txtNroConsumo.Visible = False
            Deshabilita()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnVerProximo_Click(sender As System.Object, e As System.EventArgs) Handles btnVerProximo.Click
        'Muestra el Siguiente Nro a Generar
        Dim MaxNro As Double = f.MaximoconWhere("NROCONSUMO", "PRODCONSUMOINTERNO", "TIPO", 4)
        MaxNro = MaxNro + 1

        MessageBox.Show("Proximo Nro a Generar : " & MaxNro.ToString, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEliminarProducto_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminarProducto.Click
        Dim c As Integer = dgwConsumoDet.RowCount

        If dgwConsumoDet.RowCount = 0 Then
            Exit Sub
        End If

        Dim CRDGV As Integer = Me.dgwConsumoDet.CurrentRow.Index
        Me.dgwConsumoDet.CurrentRow.Cells("EstadoGrilla").Value = "D" 'Insert
        Me.dgwConsumoDet.Item(0, CRDGV).Style.BackColor = Color.Pink
        Me.dgwConsumoDet.Item(1, CRDGV).Style.BackColor = Color.Pink
        Me.dgwConsumoDet.Item(2, CRDGV).Style.BackColor = Color.Pink
        Me.dgwConsumoDet.Item(3, CRDGV).Style.BackColor = Color.Pink
        Me.dgwConsumoDet.Item(4, CRDGV).Style.BackColor = Color.Pink
        Me.dgwConsumoDet.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = "Este Codigo sera Eliminado"
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
                vgCodCabecera = dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value

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
        Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)

        'Buscamos la posicion del registro guardado
        For i = 0 To dgwComsumo.RowCount - 1
            If dgwComsumo.Rows(i).Cells("CODCONSUMODataGridViewTextBoxColumn").Value = CodTemp Then
                PRODCONSUMOINTERNOBindingSource.Position = i
            End If
        Next

        Try
            Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try

        AccNuevo = 0 : AccEditar = 0 : modifdet = 0
        lblNroConsumo.Visible = True : txtNroConsumo.Visible = False

        RecorreDetalleSinTotal()
        Deshabilita()
    End Sub

    Private Sub ActualizaCabecera()
        Dim Sql As String = ""
        Dim Obs, TotalConsumo As String

        If txtObservacion.Text = "" Then
            Obs = " "
        Else
            Obs = txtObservacion.Text
        End If

        TotalConsumo = txtTotalConsumo.Text
        TotalConsumo = Funciones.Cadenas.QuitarCad(TotalConsumo, ".")
        TotalConsumo = Replace(TotalConsumo, ",", ".")

        Sql = "UPDATE PRODCONSUMOINTERNO SET OBSERVACION = '" & Obs & "',TOTALCONSUMO = " & TotalConsumo & ",FECHA= CONVERT (DATETIME, '" & Me.dtpFecha.Text & "',103) , NROCONSUMO = " & txtNroConsumo.Text & ", TIPO=" & 4 & "   " & _
              "WHERE CODCONSUMO = " & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value

        cmd.CommandText = Sql
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub InsertaMovProducto()
        Dim Sql As String = ""
        Dim CantidadFactura, CodCodigoFactura, Precio, Costeable As String
        Dim c As Integer = dgwConsumoDet.RowCount

        Costeable = 0
        For c = 1 To c
            If IsDBNull(dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
                CantidadFactura = "NULL"
            Else
                CantidadFactura = dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                CantidadFactura = Funciones.Cadenas.QuitarCad(CantidadFactura, ".")
                CantidadFactura = Replace(CantidadFactura, ",", ".")

                CantidadFactura = "-" + CantidadFactura

            End If

            If IsDBNull(dgwConsumoDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigoFactura = "NULL"
            Else
                CodCodigoFactura = dgwConsumoDet.Rows(c - 1).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwConsumoDet.Rows(c - 1).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value) Then
                Precio = "NULL"
            Else
                Precio = dgwConsumoDet.Rows(c - 1).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value
                Precio = Funciones.Cadenas.QuitarCad(Precio, ".")
                Precio = Replace(Precio, ",", ".")
            End If

            Dim hora As String = Now.ToString("HH:mm:ss")
            Dim Concat As String = dtpFecha.Text
            Dim Concatenar As String = Concat & " " + hora

            If dgwConsumoDet.Rows(c - 1).Cells("EstadoGrilla").Value = "I" Then
                Sql = "INSERT MOVPRODUCTO (CODUSUARIO,CODCODIGO,CODDEPOSITO,FECHAMOVIMIENTO,MODULO,MODULOTRANSID,CANTIDAD,VALOR,CONCEPTO,COSTEABLE,TIPOPRODUCCION,STOCK) " & _
                       "VALUES(" & UsuCodigo & "," & CodCodigoFactura & "," & cbxDeposito.SelectedValue & ",CONVERT(Datetime,'" & Concatenar & "',103),28," & vgCodCabecera & _
                       "," & CantidadFactura & "," & Precio & ",'Consumo Interno Nro " & txtNroConsumo.Text & "'," & Costeable & ",4,1)"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwConsumoDet.Rows(c - 1).Cells("EstadoGrilla").Value = "U" Then

                Dim CantNueva, CantAnterior As String
                CantNueva = dgwConsumoDet.Rows(c - 1).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                CantAnterior = dgwConsumoDet.Rows(c - 1).Cells("CantAnterior").Value

                CantNueva = CDec(CantNueva) * -1
                CantAnterior = CDec(CantAnterior) * -1

                CantNueva = Funciones.Cadenas.QuitarCad(CantNueva, ".")
                CantNueva = Replace(CantNueva, ",", ".")
                CantAnterior = Funciones.Cadenas.QuitarCad(CantAnterior, ".")
                CantAnterior = Replace(CantAnterior, ",", ".")

                Sql = "UPDATE MOVPRODUCTO SET CANTIDAD=" & CantNueva & ", CODCODIGO=" & CodCodigoFactura & ",VALOR=" & Precio & " WHERE CANTIDAD=" & CantAnterior & " AND CODCODIGO=" & dgwConsumoDet.Rows(c - 1).Cells("CodCodigoAnt").Value & " AND CODDEPOSITO=" & cbxDeposito.SelectedValue & " AND MODULOTRANSID=" & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value & " AND MODULO=28 AND TIPOPRODUCCION=4"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwConsumoDet.Rows(c - 1).Cells("EstadoGrilla").Value = "D" Then

                Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=(SELECT MAX(CODMOVIMIENTO) FROM MOVPRODUCTO WHERE CODCODIGO = " & CodCodigoFactura & " AND MODULO  = 28 AND MODULOTRANSID= " & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value & _
                      " AND CANTIDAD = " & CantidadFactura & " AND TIPOPRODUCCION  = 4)"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub EliminaMovProducto()
        Dim Sql As String = ""
        Dim CodCodigo As String
        Dim c As Integer = dgwConsumoDet.RowCount

        For i = 0 To c - 1
            If IsDBNull(dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
                CodCodigo = "NULL"
            Else
                CodCodigo = dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            Sql = "DELETE FROM MOVPRODUCTO WHERE CODMOVIMIENTO=(SELECT MAX(CODMOVIMIENTO) FROM MOVPRODUCTO WHERE TIPOPRODUCCION  = 4 AND MODULO  = 28 AND MODULOTRANSID= " & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value & ")"

            cmd.CommandText = Sql
            cmd.ExecuteNonQuery()
        Next
    End Sub

    Private Sub InsertaCabecera()
        Dim Sql As String = ""
        Dim Obs, TotalConsumo As String

        If txtObservacion.Text = "" Then
            Obs = " "
        Else
            Obs = txtObservacion.Text
        End If

        TotalConsumo = txtTotalConsumo.Text
        TotalConsumo = Funciones.Cadenas.QuitarCad(TotalConsumo, ".")
        TotalConsumo = Replace(TotalConsumo, ",", ".")

        Sql = "INSERT INTO PRODCONSUMOINTERNO (CODUSUARIO ,CODDEPOSITO,NROCONSUMO,OBSERVACION,TOTALCONSUMO,FECHA,TIPO)  " & _
              "VALUES(" & UsuCodigo & "," & cbxDeposito.SelectedValue & "," & txtNroConsumo.Text & ",'" & Obs & "'," & TotalConsumo & ", CONVERT (DATETIME, '" & Me.dtpFecha.Text & "',103), " & 4 & ")   " & _
              "SELECT CODCONSUMO FROM PRODCONSUMOINTERNO WHERE CODCONSUMO = SCOPE_IDENTITY();"

        cmd.CommandText = Sql
        vgCodCabecera = cmd.ExecuteScalar()
    End Sub

    Private Sub InsertaActualizaDetalle()
        Dim Sql As String = ""
        Dim CodCodigo, Cantidad, Costo As String

        CodCodigo = "" : Cantidad = "" : Costo = ""

        For i = 0 To dgwConsumoDet.RowCount - 1
            If IsDBNull(dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value) Then
            Else
                CodCodigo = dgwConsumoDet.Rows(i).Cells("CODCODIGODataGridViewTextBoxColumn").Value
            End If

            If IsDBNull(dgwConsumoDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value) Then
            Else
                Cantidad = dgwConsumoDet.Rows(i).Cells("CANTIDADDataGridViewTextBoxColumn").Value
                Cantidad = Funciones.Cadenas.QuitarCad(Cantidad, ".")
                Cantidad = Replace(Cantidad, ",", ".")
            End If

            If IsDBNull(dgwConsumoDet.Rows(i).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value) Then
            Else
                Costo = dgwConsumoDet.Rows(i).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value
                Costo = Funciones.Cadenas.QuitarCad(Costo, ".")
                Costo = Replace(Costo, ",", ".")
            End If

            If dgwConsumoDet.Rows(i).Cells("EstadoGrilla").Value = "I" Then
                Sql = "INSERT INTO PRODCONSUMOINTERNODET (CODCONSUMO,CODCODIGO,CANTIDAD,PRECIOUNITARIO)  " & _
                  "VALUES(" & vgCodCabecera & "," & CodCodigo & "," & Cantidad & "," & Costo & ")"

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwConsumoDet.Rows(i).Cells("EstadoGrilla").Value = "U" Then
                Sql = " UPDATE PRODCONSUMOINTERNODET SET CODCODIGO=" & CodCodigo & ", CANTIDAD= " & Cantidad & ", PRECIOUNITARIO = " & Costo & " WHERE CODCONSUMODET =" & dgwConsumoDet.Rows(i).Cells("CODCONSUMODET").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

            ElseIf dgwConsumoDet.Rows(i).Cells("EstadoGrilla").Value = "D" Then
                Sql = "DELETE FROM PRODCONSUMOINTERNODET WHERE CODCONSUMODET=" & dgwConsumoDet.Rows(i).Cells("CODCONSUMODET").Value

                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()
            End If
        Next
    End Sub

    Private Sub dgwComsumo_SelectionChanged(sender As Object, e As System.EventArgs) Handles dgwComsumo.SelectionChanged
        If dgwComsumo.RowCount <> 0 Then
            Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value)
            RecorreDetalleSinTotal()
        Else
            Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, 0)
        End If
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)
    End Sub

    Private Sub EliminarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 230)
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

            'Se debe eliminar la Cabecera y el detalle, aumentar stock y Eliminar de Movimientos
            sql = "DELETE FROM PRODCONSUMOINTERNODET WHERE CODCONSUMODET= " & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value & " "
            sql = sql + "DELETE FROM PRODCONSUMOINTERNO WHERE CODCONSUMO = " & dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value & " "

            cmd.CommandText = sql
            cmd.ExecuteNonQuery()

            myTrans.Commit()
        Catch ex As Exception
            MessageBox.Show("Ocurrio un Error al Eliminar: " + ex.Message, "POSEXPRESS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        AccEditar = 0 : AccNuevo = 0 : modifdet = 0
        FechaFiltro()
        Me.PRODCONSUMOINTERNOTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNO, FechaFiltro1, FechaFiltro2, 4)
        Try
            Me.PRODCONSUMOINTERNODETTableAdapter.Fill(Me.DsProdSimple.PRODCONSUMOINTERNODET, dgwComsumo.CurrentRow.Cells("CODCONSUMODataGridViewTextBoxColumn").Value)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        If BuscarTextBox.Text <> "" Then
            Me.PRODCONSUMOINTERNOBindingSource.Filter = "NROCONSUMO = " & BuscarTextBox.Text
        Else
            Me.PRODCONSUMOINTERNOBindingSource.RemoveFilter()
        End If
    End Sub

    Private Sub txtNroConsumo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNroConsumo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            If cbxDeposito.Enabled = True Then
                cbxDeposito.Focus()
            Else
                dtpFecha.Focus()
            End If
        End If
    End Sub

    Private Sub pbxImprimirOrden_Click(sender As System.Object, e As System.EventArgs) Handles pbxImprimirOrden.Click
        Dim frm = New VerInformes
        Dim rptmat As New Reportes.ProdConsumoInternoMATR

        Me.AjusteHistoricoAPedidoTableAdapter.FillBy(DsProduccion.AjusteHistoricoAPedido, dtpFecha.Value.Date)
        Me.RPTCONSUMOINTERNOTableAdapter.Fill(DsProdSimple.RPTCONSUMOINTERNO, Me.lblNroConsumo.Text, 4)

        rptmat.SetDataSource([DsProdSimple])
        rptmat.SetParameterValue("pmtEmpresa", EmpDescripcion)
        rptmat.SetParameterValue("pmtComprobante", "Salida de Consumo Interno")

        frm.CrystalReportViewer1.ReportSource = rptmat
        frm.WindowState = FormWindowState.Maximized
        frm.Show()
    End Sub

    Private Sub btnModificarDet_Click(sender As System.Object, e As System.EventArgs) Handles btnModificarDet.Click
        'se verifica que los campos principales no esten en blanco
        If (tbxCodigoProducto.Text <> "") And (txtCantidad.Text <> "") And (tbxPrecio.Text <> "") Then
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("CODPRODUCTO2").Value = vgCodProducto
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("CODCODIGODataGridViewTextBoxColumn").Value = vgCodCodigo
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("CODIGODataGridViewTextBoxColumn").Value = tbxCodigoProducto.Text
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("DESPRODUCTODataGridViewTextBoxColumn").Value = DesProductoTextBox.Text
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("CANTIDADDataGridViewTextBoxColumn").Value = CDec(txtCantidad.Text)
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value = CDec(tbxPrecio.Text)

            If AccEditar = 1 Then
                dgwConsumoDet.Rows(vgLineaConsumo).Cells("EstadoGrilla").Value = "U"
            ElseIf AccNuevo = 1 Then
                dgwConsumoDet.Rows(vgLineaConsumo).Cells("EstadoGrilla").Value = "I"
            End If

            Dim CalculoTotal As Integer = (dgwConsumoDet.Rows(vgLineaConsumo).Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value * dgwConsumoDet.Rows(vgLineaConsumo).Cells("CANTIDADDataGridViewTextBoxColumn").Value)
            dgwConsumoDet.Rows(vgLineaConsumo).Cells("SubTotal").Value = CalculoTotal

            btnAgregar.BringToFront() : btnEliminarProducto.BringToFront()
            tbxCodigoProducto.Enabled = True

            RecorreDetalle()
            Limpiar()
            tbxCodigoProducto.Focus()
            tbxCodigoProducto.Enabled = False
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

    Private Sub tbxRedondeo_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbxRedondeo.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtTotalConsumo.Text = tbxRedondeo.Text
            PanelRedondeo.Visible = False
            Me.tbxRedondeo.Text = ""

            GuardarPictureBox.Focus()
            KeyAscii = 0
        End If
    End Sub

    Private Sub txtTotalConsumo_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtTotalConsumo.MouseDoubleClick
        PanelRedondeo.Visible = True
        tbxRedondeo.Focus()
    End Sub

    Private Sub dgwConsumoDet_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwConsumoDet.DoubleClick
        Try
            If IsDBNull(dgwConsumoDet.CurrentRow) Then
                Exit Sub
            Else
                vgLineaConsumo = dgwConsumoDet.CurrentRow.Index
                modifdet = 1

                If IsDBNull(dgwConsumoDet.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value) Then
                    tbxCodigoProducto.Text = ""
                Else
                    tbxCodigoProducto.Text = dgwConsumoDet.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
                End If

                If tbxCodigoProducto.Text = "" Then
                    vgCodProducto = 0
                    vgCodCodigo = 0
                End If

                txtCantidad.Text = CDec(dgwConsumoDet.CurrentRow.Cells("CANTIDADDataGridViewTextBoxColumn").Value)
                tbxPrecio.Text = CDec(dgwConsumoDet.CurrentRow.Cells("PRECIOUNITARIODataGridViewTextBoxColumn").Value)
                DesProductoTextBox.Text = dgwConsumoDet.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
            End If

        Catch ex As Exception

        End Try

        btnModificarDet.BringToFront() : btnCancelarDet.BringToFront()
        ' tbxCodigoProducto.Enabled = False
        txtCantidad.Focus()
    End Sub
End Class