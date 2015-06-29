Imports System
Imports System.Data
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Data.SqlClient
Imports Osuna.Utiles.Conectividad

Public Class OrdenProduccion
    Private ser As BDConexión.BDConexion
    Private cmd As SqlCommand
    Private sqlc As SqlConnection
    Private myTrans As SqlTransaction

    Dim permiso As Double
    Dim f As New Funciones.Funciones
    Dim FechaFiltro1, FechaFiltro2 As Date
    Dim vgNuevo As Integer

    Public Sub New()
        Me.InitializeComponent()
        ser = New BDConexión.BDConexion

        cmd = New SqlCommand

        sqlc = New SqlConnection
        sqlc.ConnectionString = My.Settings.GESTIONConnectionString2
    End Sub

    Private Sub PlanillaProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DsOrdProduccion1.TIPOPRODUCCION' table. You can move, or remove it, as needed.
        Me.TIPOPRODUCCIONTableAdapter.Fill(Me.DsOrdProduccion1.TIPOPRODUCCION)
        Try
            permiso = PermisoAplicado(UsuCodigo, 237)
            If permiso = 0 Then
                MessageBox.Show("Usted no tiene permiso Abrir esta Ventana", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.Close()
            Else
                CmbAño.SelectedText = Today.Year.ToString
                CmbMes.SelectedIndex = Today.Month - 1

                FechaFiltro()
                Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
                Me.OPDETALLETableAdapter.Fill(DsOrdProduccion1.OPDETALLE)
                chkSortType.Checked = True
                DesHabilitar()
                SumarTotales()
                vgNuevo = 0
            End If

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

    Private Sub DesHabilitar()
        pnlCabecera.Enabled = False
        pnlDetalle.Enabled = False

        dgwOrdenProduccion.Enabled = True
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
    End Sub

    Private Sub Habilitar()
        pnlCabecera.Enabled = True
        pnlDetalle.Enabled = True

        dgwOrdenProduccion.Enabled = False
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
    End Sub

    Private Sub BtnFiltro_Click(sender As System.Object, e As System.EventArgs) Handles BtnFiltro.Click
        FechaFiltro()
        If chkSortType.Checked = True Then
            Me.ORDENPRODUCCIONTableAdapter.FillBy(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2, cbxFiltroTipoProd.SelectedValue)
        Else
            Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
        End If

        Me.OPDETALLETableAdapter.Fill(DsOrdProduccion1.OPDETALLE)
        SumarTotales()
    End Sub

    Private Sub BuscarTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles BuscarTextBox.TextChanged
        ORDENPRODUCCIONBindingSource.Filter = "CODIGOLOTE LIKE '%" & BuscarTextBox.Text & "%' "
    End Sub

    Private Sub NuevoPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles NuevoPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 234)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Crear una Orden de Produccion", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        Habilitar()
        dtpFecha.Value = Now()
        dtpFecha.Focus()
        vgNuevo = 1 : txtIdOT.Text = ""

        Try
            ORDENPRODUCCIONBindingSource.AddNew()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnGenerarLote_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerarLote.Click
        Try
            'Generacion del Codigo de Barra Formato EAN13 
            Dim CodPais, Aleatorio As String
            Dim w As New Funciones.Funciones
            Dim tamanho As Integer
            Dim result As String
            Dim first As Integer
            Dim check As Integer
            Dim digit As Integer
            Dim i As Integer
            Dim r As Integer

            CodPais = "569"  'Colocamos el codigo del pais correspondiente a Ireland , considreando que este pais no vende a Paraguay

            Aleatorio = "000000001"   'Debemos generar 9 digitos de forma aleatoria, estos digitos corresponden a el codigo del producto y fabricante
            Minimo = "1"
            Maximo = "999999999"
            CodigoExistente = 1 'Para que siempre entre al ciclo la primera ves

            Randomize() ' inicializar la semilla

            Do While CodigoExistente <> Nothing
                Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)

                'Se debe verificar que el codigo generado contenga 9 digitos.
                tamanho = Aleatorio.Length

                While (tamanho < 9)
                    Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
                    tamanho = Aleatorio.Length
                End While

                'Se debe calcular el Digito de Comprobacion.
                Aleatorio = CodPais + Aleatorio
                result = Aleatorio.Substring(0, 1)
                first = Convert.ToInt32(result)
                check = first
                digit = 0
                i = 11

                Do While (i >= 1)
                    digit = Convert.ToInt32(Aleatorio.Substring(i, 1))
                    If i Mod 2 = 0 Then
                        r = 1
                    Else
                        r = 3
                    End If
                    check = (check + (digit * (r)))
                    i = (i - 1)
                Loop
                digit = ((10 - (check Mod 10)) Mod 10)

                'Concatenamos todo
                Aleatorio = Aleatorio + System.Convert.ToString(digit)

                'Verificamos si el codigo de barra ya existe en la base de datos
                CodigoExistente = w.FuncionConsultaString("CODIGOLOTE", "ORDENPRODUCCION", "CODIGOLOTE", Aleatorio)
                If CodigoExistente <> "" Then
                    MessageBox.Show("El código ya existe para orden,elija otro código", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            Loop

            txtCodigoLote.Text = Aleatorio
        Catch ex As Exception
            MessageBox.Show("Error al Generará el Código Aleatorio", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub dtpFecha_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFecha.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtCodigoLote.Focus()
        End If
    End Sub

    Private Sub txtCodigoLote_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoLote.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            cmbEstado.Focus()
        End If
    End Sub

    Private Sub txtOBS_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOBS.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            TxtNroOT.Focus()
        End If
    End Sub

    Private Sub txtBuscarCliente_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarNroOT.TextChanged
        NROOTBindingSource.Filter = "NROORDENTRABAJO LIKE '%" & txtBuscarNroOT.Text & "%' OR NOMBRE LIKE '%" & txtBuscarNroOT.Text & "%'"
    End Sub

    Private Sub BtnAsterisco_Click(sender As System.Object, e As System.EventArgs) Handles BtnAsterisco.Click
        Me.NROOTTableAdapter.Fill(Me.DsOrdProduccion1.NROOT)
        upcNroOT.Show()
        txtBuscarNroOT.Focus()
    End Sub

    Private Sub dgwNroOT_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwNroOT.DoubleClick
        Try
            If dgwNroOT.Rows.Count <> 0 Then
                TxtNroOT.Text = dgwNroOT.CurrentRow.Cells("NROORDENTRABAJODataGridViewTextBoxColumn").Value
                txtIdOT.Text = dgwNroOT.CurrentRow.Cells("IDDataGridViewTextBoxColumn").Value

                cbxSolodePedido.Checked = True

                upcNroOT.Close()
                dtpFecha.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtBuscarProductoCombo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarProductoCombo.TextChanged
        PRODUCTOCOMBOFILLBindingSource.Filter = "CODIGO LIKE '%" & txtBuscarProductoCombo.Text & "%' OR DESPRODUCTO LIKE '%" & txtBuscarProductoCombo.Text & "%'"
    End Sub

    Private Sub dgwProductosCombo_DoubleClick(sender As Object, e As System.EventArgs) Handles dgwProductosCombo.DoubleClick
        Try
            If dgwProductosCombo.Rows.Count <> 0 Then
                tbxCodCodigo.Text = dgwProductosCombo.CurrentRow.Cells("CODCODIGODataGridViewTextBoxColumn").Value
                tbxCodigoProducto.Text = dgwProductosCombo.CurrentRow.Cells("CODIGODataGridViewTextBoxColumn").Value
                DesProductoTextBox.Text = dgwProductosCombo.CurrentRow.Cells("DESPRODUCTODataGridViewTextBoxColumn").Value
                lblEnStock.Text = FormatNumber(dgwProductosCombo.CurrentRow.Cells("STOCKACTUAL").Value, 2)

                If TxtNroOT.Text <> "" Then
                    If Not IsDBNull(dgwProductosCombo.CurrentRow.Cells("CANTIDADPEDIDA").Value) Then
                        txtCantidad.Text = dgwProductosCombo.CurrentRow.Cells("CANTIDADPEDIDA").Value
                    End If
                    If Not IsDBNull(dgwProductosCombo.CurrentRow.Cells("CANTIDADAPRODUCIRDataGridViewTextBoxColumn").Value) Then
                        tbxCantidadProducir.Text = dgwProductosCombo.CurrentRow.Cells("CANTIDADAPRODUCIRDataGridViewTextBoxColumn").Value
                    End If
                End If

                upcProducto.Close()
                txtCantidad.Focus()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscProductos_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscProductos.Click
        If TxtNroOT.Text = "" Then
            cbxSolodePedido.Checked = False
        Else
            cbxSolodePedido.Checked = True
        End If
        cbxSolodePedido_CheckedChanged(Nothing, Nothing)

        upcProducto.Show()
        txtBuscarProductoCombo.Focus()
    End Sub

    Private Sub CancelarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles CancelarPictureBox.Click
        Try
            ORDENPRODUCCIONBindingSource.CancelEdit()
            OPDETALLEBindingSource.CancelEdit()

            DesHabilitar()
            Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
            Me.OPDETALLETableAdapter.Fill(DsOrdProduccion1.OPDETALLE)

            tbxCodigoProducto.Text = "" : txtCantidad.Text = "" : DesProductoTextBox.Text = "" : tbxCodCodigo.Text = "" : lblEnStock.Text = "En Stock" : tbxCantidadProducir.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ModificarPictureBox_Click(sender As System.Object, e As System.EventArgs) Handles ModificarPictureBox.Click
        vgNuevo = 0
        Habilitar()
        dtpFecha.Focus()
    End Sub

    Private Sub GuardarPictureBox_Click(sender As Object, e As EventArgs) Handles GuardarPictureBox.Click
        Try
            Dim UltimoRegistro As Integer
            If vgNuevo = 1 Then
                ser.Abrir(sqlc)
                cmd.Connection = sqlc

                Dim IdOP As Integer = 0
                If txtIdOT.Text <> "" Then
                    IdOP = CInt(txtIdOT.Text)
                Else
                    IdOP = 0
                End If

                Dim Sql As String = "INSERT INTO ORDENPRODUCCION (CODIGOLOTE,ESTADO ,FECHA,OBS, TIPOPRODUCCION) " & _
                                    "VALUES('" & txtCodigoLote.Text & "','" & cmbEstado.Text & "', CONVERT (DATETIME, '" & dtpFecha.Text & "',103), '" & txtOBS.Text & "', '" & cbxTipoProd.SelectedValue & "')" & _
                                    "SELECT ID FROM ORDENPRODUCCION WHERE ID = SCOPE_IDENTITY();"

                cmd.CommandText = Sql
                UltimoRegistro = cmd.ExecuteScalar

                For i = 0 To dgwOPDetalle.Rows.Count - 1
                    OPDETALLETableAdapter.InsertQuery(UltimoRegistro, dgwOPDetalle.Rows(i).Cells("CODCODIGOOPDET").Value, dgwOPDetalle.Rows(i).Cells("CANTIDADOPDET").Value, dgwOPDetalle.Rows(i).Cells("ID_ORDENTRABAJO").Value)
                Next

            Else
                UltimoRegistro = dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value
                ORDENPRODUCCIONTableAdapter.UpdateQuery(txtCodigoLote.Text, cmbEstado.Text, dtpFecha.Value, txtOBS.Text, cbxTipoProd.SelectedValue, UltimoRegistro)
                For i = 0 To dgwOPDetalle.Rows.Count - 1
                    If dgwOPDetalle.Rows(i).Cells("EstadoGrilla").Value = "I" Then
                        OPDETALLETableAdapter.InsertQuery(UltimoRegistro, dgwOPDetalle.Rows(i).Cells("CODCODIGOOPDET").Value, dgwOPDetalle.Rows(i).Cells("CANTIDADOPDET").Value, dgwOPDetalle.Rows(i).Cells("ID_ORDENTRABAJO").Value)
                    ElseIf dgwOPDetalle.Rows(i).Cells("EstadoGrilla").Value = "D" Then
                        OPDETALLETableAdapter.DeleteQuery(dgwOPDetalle.Rows(i).Cells("IDOPDET").Value)
                    End If
                Next
            End If

            vgNuevo = 0 : vgEditar = 0

            If chkSortType.Checked = True Then
                Me.ORDENPRODUCCIONTableAdapter.FillBy(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2, cbxFiltroTipoProd.SelectedValue)
            Else
                Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
            End If
            For i = 0 To dgwOrdenProduccion.Rows.Count - 1
                If UltimoRegistro = dgwOrdenProduccion.Rows(i).Cells("IDOP").Value Then
                    ORDENPRODUCCIONBindingSource.Position = i
                End If
            Next
            Me.OPDETALLETableAdapter.Fill(DsOrdProduccion1.OPDETALLE)

            DesHabilitar()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarPictureBox_Click(sender As Object, e As EventArgs) Handles EliminarPictureBox.Click
        permiso = PermisoAplicado(UsuCodigo, 236)
        If permiso = 0 Then
            MessageBox.Show("Usted no tiene permiso para Eliminar una Orden de Producción", "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If MessageBox.Show("¿Esta seguro que quiere Eliminar?", "COGENT SIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.No Then
            Exit Sub
        End If

        Try
            Dim RegistroActual As Integer = dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value
            OPDETALLETableAdapter.DeleteQueryTodo(RegistroActual)
            ORDENPRODUCCIONTableAdapter.DeleteQuery(RegistroActual)

            If chkSortType.Checked = True Then
                Me.ORDENPRODUCCIONTableAdapter.FillBy(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2, cbxFiltroTipoProd.SelectedValue)
            Else
                Me.ORDENPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.ORDENPRODUCCION, FechaFiltro1, FechaFiltro2)
            End If
            Me.OPDETALLETableAdapter.Fill(DsOrdProduccion1.OPDETALLE)

        Catch ex As Exception
            MessageBox.Show("Error al Eliminar :" & ex.Message, "COGENT SIG", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cbxSolodePedido_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSolodePedido.CheckedChanged
        Try
            If cbxSolodePedido.Checked = True Then
                If txtIdOT.Text <> "" Then
                    Me.PRODUCTOCOMBOFILLTableAdapter.FillPC(Me.DsOrdProduccion1.PRODUCTOCOMBOFILL, txtIdOT.Text)
                    CANTIDADAPRODUCIRDataGridViewTextBoxColumn.Visible = True
                    CANTIDADPEDIDA.Visible = True
                End If
            Else
                Me.PRODUCTOCOMBOFILLTableAdapter.FillByTodos(Me.DsOrdProduccion1.PRODUCTOCOMBOFILL)
                CANTIDADAPRODUCIRDataGridViewTextBoxColumn.Visible = False
                CANTIDADPEDIDA.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tbxCodigoProducto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxCodigoProducto.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)

        If KeyAscii = 13 Then
            txtCantidad.Focus()
        End If

        If KeyAscii = 42 Then
            If TxtNroOT.Text = "" Then
                cbxSolodePedido.Checked = False
            Else
                cbxSolodePedido.Checked = True
            End If

            upcProducto.Show()
            txtBuscarProductoCombo.Focus()

            e.Handled = True
        End If
    End Sub

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
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

    Private Sub tbxCantidadProducir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbxCantidadProducir.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            btnAgregar.Focus()
        End If
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
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

            OPDETALLEBindingSource.AddNew()
            Dim c As Integer = dgwOPDetalle.RowCount

            dgwOPDetalle.Rows(c - 1).Cells("NROORDENTRABAJO").Value = TxtNroOT.Text
            If txtIdOT.Text = "" Then
                dgwOPDetalle.Rows(c - 1).Cells("ID_ORDENTRABAJO").Value = 0
            Else
                dgwOPDetalle.Rows(c - 1).Cells("ID_ORDENTRABAJO").Value = txtIdOT.Text
            End If
            dgwOPDetalle.Rows(c - 1).Cells("CODIGOOPDET").Value = tbxCodigoProducto.Text
            dgwOPDetalle.Rows(c - 1).Cells("DESPRODUCTOOPDET").Value = DesProductoTextBox.Text
            dgwOPDetalle.Rows(c - 1).Cells("CODCODIGOOPDET").Value = tbxCodCodigo.Text
            dgwOPDetalle.Rows(c - 1).Cells("CANTIDADOPDET").Value = CDec(tbxCantidadProducir.Text)
            dgwOPDetalle.Rows(c - 1).Cells("EstadoGrilla").Value = "I"

            tbxCodigoProducto.Text = "" : txtCantidad.Text = "" : DesProductoTextBox.Text = "" : tbxCodCodigo.Text = "" : lblEnStock.Text = "En Stock" : tbxCantidadProducir.Text = ""
            TxtNroOT.Text = "" : txtIdOT.Text = ""
            TxtNroOT.Focus()

            SumarTotales()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SumarTotales()
        Dim Total As Integer = 0
        If dgwOPDetalle.Rows.Count <> 0 Then
            For i = 0 To dgwOPDetalle.Rows.Count - 1
                Total = Total + CDec(dgwOPDetalle.Rows(i).Cells("CANTIDADOPDET").Value)
            Next
        End If
        tbxTotal.Text = FormatNumber(Total, 2)
    End Sub

    Private Sub dgwOrdenProduccion_SelectionChanged(sender As Object, e As EventArgs) Handles dgwOrdenProduccion.SelectionChanged
        SumarTotales()
    End Sub

    Private Sub btnEliminarProducto_Click(sender As Object, e As EventArgs) Handles btnEliminarProducto.Click
        Try
            Dim indice As Integer = dgwOPDetalle.CurrentRow.Index

            dgwOPDetalle.CurrentRow.Cells("DESPRODUCTOOPDET").Value = "Registro Para Eliminar"
            dgwOPDetalle.CurrentRow.Cells("EstadoGrilla").Value = "D"

            For r = 0 To 5
                dgwOPDetalle.Item(r, indice).Style.BackColor = Color.Pink
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub pbxImprimir_Click(sender As Object, e As EventArgs) Handles pbxImprimir.Click
        pnlImprimir.Visible = True
    End Sub

    Private Sub btnCerrarEmail_Click(sender As Object, e As EventArgs) Handles btnCerrarEmail.Click
        pnlImprimir.Visible = False
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        Dim frm = New VerInformes
        Me.ImpproductotermTableAdapter.FillBy(DsOrdProduccion1.IMPPRODUCTOTERM)
        
        If rbnProductosTerminados.Checked = True Then
            If cbxTipoProd.SelectedValue = 13 Then
                Dim rpt As New Reportes.prodComponentesPrensas
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 12 Then
                Dim rpt As New Reportes.prodComponentesCorte
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 10 Then
                Dim rpt As New Reportes.prodComponentesBarnizado
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 14 Then
                Dim rpt As New Reportes.prodCuerposEsmaltado
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 15 Then
                Dim rpt As New Reportes.prodCuerposLitografia
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 16 Then
                Dim rpt As New Reportes.prodCuerposBarnizado
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 17 Then
                Dim rpt As New Reportes.prodCuerposCorte
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            ElseIf cbxTipoProd.SelectedValue = 18 Then
                Dim rpt As New Reportes.OrdenProduccion
                Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
                rpt.SetDataSource([DsOrdProduccion1])

                Dim vEanCode As New EanCode
                rpt.SetParameterValue("EanCode", vEanCode.EAN13(txtCodigoLote.Text))

                frm.CrystalReportViewer1.ReportSource = rpt
                frm.WindowState = FormWindowState.Maximized
                frm.Show()
            End If

        Else

            Dim rpt As New Reportes.OrdenProdMatPrima
            Me.IMPMATERIAPRIMATableAdapter.Fill(DsOrdProduccion1.IMPMATERIAPRIMA, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
            Me.ImpproductotermTableAdapter.Fill(DsOrdProduccion1.IMPPRODUCTOTERM, dgwOrdenProduccion.CurrentRow.Cells("IDOP").Value)
            rpt.SetDataSource([DsOrdProduccion1])
            frm.CrystalReportViewer1.ReportSource = rpt
            frm.WindowState = FormWindowState.Maximized
            frm.Show()
        End If

    End Sub

    Private Sub cmbEstado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEstado.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            txtOBS.Focus()
        End If
    End Sub

    Private Sub TxtNroOT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNroOT.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If KeyAscii = 13 Then
            tbxCodigoProducto.Focus()
        End If

        If KeyAscii = 42 Then
            Me.NROOTTableAdapter.Fill(Me.DsOrdProduccion1.NROOT)
            upcNroOT.Show()
            txtBuscarNroOT.Focus()

            e.Handled = True
        End If
    End Sub

    Sub chkSortType_ischeked(sender As Object, e As EventArgs) Handles chkSortType.CheckedChanged
        If chkSortType.Checked = True Then
            cbxFiltroTipoProd.Enabled = True
        Else
            cbxFiltroTipoProd.Enabled = False
        End If
    End Sub

    Private Sub pbxAgregarTipoProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxAgregarTipoProd.Click
        cbxTipoProd.SelectedItem = Nothing
        TipoProduccion.ShowDialog()
        Me.TIPOPRODUCCIONTableAdapter.Fill(DsOrdProduccion1.TIPOPRODUCCION)
    End Sub

End Class